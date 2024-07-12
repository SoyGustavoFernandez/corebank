using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using CRE.CapaNegocio;
using GEN.Funciones;
using System.Data;
using Newtonsoft;
using System.Globalization;
using EntityLayer;
using GEN.ControlesBase;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer.MotorDecisionWebService;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;

namespace GEN.Servicio
{
    //TODO: SolTechnologies - 1.Logica interna del Motor de Decisiones
    public class clsMotorDecision
    {

        #region Metodos
        public bool ValidaCliRechazadoMNB(int IdCli, out TimeSpan? tRestante)
        {
            //Obtiene parámetros para intentos rechazados
            clsVarGen valIntentosDia = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIntentosDia"));
            int nIntentosDia = Convert.ToInt32(valIntentosDia.cValVar);
            clsVarGen valPeriodoEspera = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nPeriodoEspera"));
            int nPeriodoEspera = Convert.ToInt32(valPeriodoEspera.cValVar);

            bool flagR = false; //Determina si se lanzara la excepcion
            tRestante = null;
            DataTable dtScorexCli = new clsCNMotorDecision().BuscaScoreMNBxCliente(IdCli);
            if (dtScorexCli.Rows.Count <= 0)
                return flagR;

            int ultimoResultadoMNB = Convert.ToInt32(dtScorexCli.Rows[0]["idPrediccion"]);
            string dFechaP = dtScorexCli.Rows[0]["dFechaP"].ToString();

            string format = "yyyy-MM-dd";
            DateTime dFechaMNB = DateTime.ParseExact(dFechaP, format, CultureInfo.InvariantCulture);
            var sysFecha = clsVarGlobal.dFecSystem;
            dFechaMNB = dFechaMNB.AddDays(nPeriodoEspera);

            TimeSpan ts1 = dFechaMNB - sysFecha; //Tiempo restante para generar nueva solicitud
            TimeSpan ts2 = TimeSpan.Zero;

            DateTime dFechaHoy = clsVarGlobal.dFecSystem;
            dFechaHoy = dFechaHoy.AddDays(-nPeriodoEspera);
            string cExpresion = "dFechaP > '" + dFechaHoy.ToString("yyyy-MM-dd") + "' AND dFechaP <= '" + dFechaP + "' AND idPrediccion = 3"; //Revisa intentos en el día del último resultado rechazado
            DataRow[] dtUltimIntentosDia = dtScorexCli.Select(cExpresion);

            if (ultimoResultadoMNB == 3)
            {
                if (ts1 > ts2)
                {
                    if (dtUltimIntentosDia.Length != 0 && dtUltimIntentosDia.Length < nIntentosDia)
                    {
                        flagR = false;
                    }
                    else
                    {
                        flagR = true;
                        tRestante = ts1;
                    }
                }
                else
                {
                    flagR = false;
                }
            }
            return flagR;
        }
        #endregion

        #region Comunicacion con el API
        public string API_CalcularModeloDiario(clsCalcularModeloDiarioRequest _body)
        {
            //Variables de acceso
            clsVarGen userToken = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("userApiToken"));
            clsVarGen passwordToken = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("passwordApiToken"));
            clsVarGen urlApi = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("urlApiMotorDecision"));

            //Obtengo el token de acceso al API
            clsTokenRequest ocredenciales = new clsTokenRequest();
            ocredenciales.username = userToken.cValVar;
            ocredenciales.password = passwordToken.cValVar;

            string url = urlApi.cValVar + "auth";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(ocredenciales);
            IRestResponse requestToken = client.Execute(request);
            if (requestToken.StatusCode != HttpStatusCode.OK && string.IsNullOrEmpty(requestToken.Content))
                return "Error";
            clsTokenResponse tokenResponse = JsonConvert.DeserializeObject<clsTokenResponse>(requestToken.Content);
            string Authtoken = tokenResponse.token;


            //Obtengo la respuesta del Motor de decisiones 
            url = urlApi.cValVar + "calcularModeloDiario";
            client = new RestClient(url);
            request = new RestRequest(Method.POST);
            request.AddJsonBody(_body);
            request.AddHeader("Authorization", "Bearer " + Authtoken);
            IRestResponse requestMNB = client.Execute(request);
            if (requestMNB.StatusCode != HttpStatusCode.OK && string.IsNullOrEmpty(requestMNB.Content))
                return "Error";
            string respuesta = requestMNB.Content;

            return respuesta;
        }

        public string API_ObtenerExcepcion(clsObtenerExcepcionRequest _body)
        {
            clsVarGen urlApi = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("urlApiMotorDecision"));

            string url = urlApi.cValVar + "ObtenerExcepcion";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(_body);
            IRestResponse requestMNB = client.Execute(request);
            string respuesta = (requestMNB.StatusCode == HttpStatusCode.OK) ? requestMNB.Content : "No se pudo establecer conexion con el API";

            return respuesta;
        }

        public clsCalcularModeloDiarioResponse MotorDecision(int idSolicitud, decimal nuevoMontoSolicitado, int nuevoPlazo, string cFormulario = "")
        {
            //Datos parametros para el metodo API_CalcularModeloDiario
            DataTable dtbody1 = new clsCNMotorDecision().CalcularModeloDiarioRequest(idSolicitud);
            if (dtbody1.Rows.Count <= 0)
                return null;
            string jsonR = JsonConvert.SerializeObject(dtbody1);
            List<clsCalcularModeloDiarioRequest> _API_Request = JsonConvert.DeserializeObject<List<clsCalcularModeloDiarioRequest>>(jsonR);
            clsCalcularModeloDiarioRequest API_Request = _API_Request.First();

            API_Request.nMontoSolicitado = (API_Request.nMontoSolicitado != nuevoMontoSolicitado) ? nuevoMontoSolicitado : API_Request.nMontoSolicitado;
            API_Request.nPlazo = (API_Request.nPlazo != nuevoPlazo) ? nuevoPlazo : API_Request.nPlazo;
            API_Request.cFormulario = cFormulario;

            //Configuracion del Motor de Decisiones
            DataTable dtconfiguracionMotor = new clsCNMotorDecision().ListarConfiguracion();
            if (dtconfiguracionMotor.Rows.Count <= 0)
                return null;
            string jsonC = JsonConvert.SerializeObject(dtconfiguracionMotor);
            List<clsConfiguracionMotorDecision> lConfig = JsonConvert.DeserializeObject<List<clsConfiguracionMotorDecision>>(jsonC);

            //Se llama al metodo CalcularModeloDiario del API
            var respuesta = API_CalcularModeloDiario(API_Request);
            if (respuesta == "Error")
                return null;
            clsCalcularModeloDiarioResponse CalcularModeloDiarioResponse = JsonConvert.DeserializeObject<clsCalcularModeloDiarioResponse>(respuesta);

            var configResult = lConfig.Find(x => x.IdRespuesta == CalcularModeloDiarioResponse.data.idPrediccion);
            if (configResult != null)
                CalcularModeloDiarioResponse.comentario = configResult.Comentario;
            else
                return null;

            // --- GUARDA DATOS EN LA TABLA DE REPORTE HISTORICO --- //

            //Obtiene la edad partiendo de la fecha de nacimiento
            DateTime fechaNacimiento = Convert.ToDateTime(API_Request.dFechaNacimiento);
            int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;

            //Obtiene el dia de la semana partiendo de la fecha de sistema
            DateTime FechaP = Convert.ToDateTime(API_Request.dFechaP);
            string diaSemana = FechaP.ToString("dddd", new CultureInfo("es-ES"));

            //Se inserta la respuesta en la tabla de ReporteHistoricoDecisionEngine
            clsReporteHistoricoMotorDecision oReporte = new clsReporteHistoricoMotorDecision();
            oReporte.dFechaP = API_Request.dFechaP;
            oReporte.nNumeroSolicitud = API_Request.nNumeroSolicitud;
            oReporte.nResultadoScore = CalcularModeloDiarioResponse.data.cProbabilidad;
            oReporte.idPrediccion = CalcularModeloDiarioResponse.data.idPrediccion;
            oReporte.cResultadoModelo = CalcularModeloDiarioResponse.data.cPrediccion;
            oReporte.CMotivoRechazo = "";
            oReporte.cOficina = API_Request.cOficina;
            oReporte.cAsesor = API_Request.cAsesor;
            oReporte.nEdad = edad;
            oReporte.cSexo = API_Request.cSexo;
            oReporte.cEstadoCivil = API_Request.cEstadoCivil;
            oReporte.cTipoVivienda = API_Request.cTipoVivienda;
            oReporte.cNivelInstruccion = API_Request.cNivelInstruccion;
            oReporte.nMontoSolicitado = API_Request.nMontoSolicitado;
            oReporte.nPlazo = API_Request.nPlazo;
            oReporte.nNroDependientes = API_Request.nNroDependientes;
            oReporte.nAniosResidencia = API_Request.nAniosResidencia;
            oReporte.cTelefono = API_Request.cTelefono;
            oReporte.cProfesion = API_Request.cProfesion;
            oReporte.cDiaSemana = diaSemana;
            oReporte.cDepartamento = API_Request.cDepartamento;
            oReporte.cDestinoCredito = API_Request.cDestinoCredito;
            oReporte.cUsuarioReg = clsVarGlobal.User.cWinUser; //Se añadio como campo adicional al Anexo1
            oReporte.dFechaReg = DateTime.Now; //Se añadio como campo adicional al Anexo1
            oReporte.cFormulario = cFormulario;

            new clsCNMotorDecision().InsertarReporteHistorico(oReporte);

            //Valor necesario para evaluar el monto parametrizable que decide el flujo de la la evaluacion
            CalcularModeloDiarioResponse.data.nMonto = API_Request.nMontoSolicitado;

            return CalcularModeloDiarioResponse;
        }

        public bool CallMotorDecisionSolicitud(int idSol, decimal nuevoMontoSolicitado, int nuevoPlazo, bool migra = true, string cFormulario = "")
        {
            bool flagRespuesta = false;

            if (nuevoMontoSolicitado <= 0 || nuevoPlazo <= 0)
            {
                return flagRespuesta;
            }

            var respuestaAPI = MotorDecision(idSol, nuevoMontoSolicitado, nuevoPlazo, cFormulario);
            if (respuestaAPI == null)
                return flagRespuesta;

            if (respuestaAPI.succes != 1)
            {
                string msgError = string.Empty;
                foreach (var item in respuestaAPI.errores)
                    msgError += "Código: " + item.codigo + " - " + item.mensaje + "\n";
                MessageBox.Show(msgError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return flagRespuesta;
            }

            clsVarGen _VarGlobal = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecision"));
            decimal montoParametrisable = Convert.ToDecimal(_VarGlobal.cValVar);

            decimal montoTotal = respuestaAPI.data.nMonto;
            string hora = DateTime.Now.ToString("hh:mm:ss tt");

            //Solo se muestra el mensaje del API en caso sea "Rechazado"
            if (respuestaAPI.data.idPrediccion == 3)
            {
                frmRespuestaMotor msjRespuesta =
                new frmRespuestaMotor(respuestaAPI.data.idPrediccion,
                                      respuestaAPI.data.num_solicitud,
                                      respuestaAPI.data.cPrediccion.ToUpper(),
                                      hora,
                                      respuestaAPI.comentario);
                msjRespuesta.ShowDialog();
                flagRespuesta = true;
                //new clsCNMotorDecision().CambiarEstadoSol(idSol, 4); //Solicitud Rechazada por el modelo
                MessageBox.Show("La solicitud ha sido rechazada por el Motor de decisiones del Modelo No Bancarizado.\n" +
                "Debera anular la solicitud.", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return flagRespuesta;
            }
            else
            {
                if (montoTotal > montoParametrisable && migra)
                {
                    MessageBox.Show("Debera pasar por un proceso de evaluacion normal", "Motor de Decisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flagRespuesta = true;
                    return flagRespuesta;
                }
                else if (montoTotal < montoParametrisable && migra)
                {
                    MessageBox.Show("Debera pasar por un proceso de evaluacion resumida", "Motor de Decisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flagRespuesta = true;
                    return flagRespuesta;
                }
                else 
                {
                    flagRespuesta = true;
                    return flagRespuesta;
                }
                
            }
        }

        public clsCalcularModeloDiarioResponse CallMotorDecisionEvaluacion(int idSol, decimal nuevoMontoSolicitado, int nuevoPlazo, bool migra, string cFormulario = "")
        {
            clsCalcularModeloDiarioResponse respuestaAPI = null;

            if (nuevoMontoSolicitado <= 0 || nuevoPlazo <= 0)
            {
                return respuestaAPI;
            }

            respuestaAPI = MotorDecision(idSol, nuevoMontoSolicitado, nuevoPlazo, cFormulario);
            if (respuestaAPI == null)
                return respuestaAPI;

            if (respuestaAPI.succes != 1)
            {
                string msgError = string.Empty;
                foreach (var item in respuestaAPI.errores)
                    msgError += "Código: " + item.codigo + " - " + item.mensaje + "\n";
                MessageBox.Show(msgError, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return respuestaAPI;
            }

            return respuestaAPI;

        }

        public void MensajesPorExcepcionesYRespuestaApi(int idSolicitud, decimal nMonto, int nPlazo, Nullable<bool> lRequireMigrar, List<clsReglaNegocioEvaluada> aReglasEvaluadas, clsCalcularModeloDiarioResponse respuestaAPI, bool lMostrarMensajes = true)
        {
            var aReglasTruncantesFallidas = aReglasEvaluadas.FindAll(x => x.lResul == "NO" && x.lIndExcepcion == 0);

            if (aReglasTruncantesFallidas.Count > 0)
            {
                List<String> listExp = new List<String>();
                foreach (var item in aReglasTruncantesFallidas)
                {
                    listExp.Add(item.cMensajeError);
                }
                var _cMotivoRechazo = string.Join("\r\n", listExp);

                new clsCNMotorDecision().ActualizaMotivoRechazo(idSolicitud, _cMotivoRechazo);

                clsObtenerExcepcionRequest _bodyExcepcion = new clsObtenerExcepcionRequest();
                _bodyExcepcion.nNumeroSolicitud = idSolicitud;
                _bodyExcepcion.dFechaP = clsVarGlobal.dFecSystem.ToString();
                _bodyExcepcion.nMontoSolicitado = nMonto;
                _bodyExcepcion.nPlazo = nPlazo;
                _bodyExcepcion.cMotivoRechazo = _cMotivoRechazo;
                new clsMotorDecision().API_ObtenerExcepcion(_bodyExcepcion);

                if (lMostrarMensajes)
                {
                    frmRespuestaMotor msjRespuesta = new frmRespuestaMotor(
                            3
                            , idSolicitud
                            , "Rechazado"
                            , DateTime.Now.ToString("hh:mm:ss tt")
                            , "Rechazado por reglas del MNB"
                            , _cMotivoRechazo
                            );
                    msjRespuesta.ShowDialog();
                }
            }
            else
            {
                if (lRequireMigrar != null && !lRequireMigrar.Value) // flujo normal
                {
                    if (lMostrarMensajes)
                    {
                        frmRespuestaMotor msjRespuesta = new frmRespuestaMotor(
                                respuestaAPI.data.idPrediccion,
                                respuestaAPI.data.num_solicitud,
                                respuestaAPI.data.cPrediccion.ToUpper(),
                                DateTime.Now.ToString("hh:mm:ss tt"),
                                respuestaAPI.comentario);
                        msjRespuesta.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}
