using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.CoreBank.Interface;
using EntityLayer;
using CRE.CapaNegocio;
using System.Data;
using GEN.Funciones;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using CLI.Servicio;
using System.Web.Script.Serialization;
using System.Web;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WCF.CoreBank.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SolicitudCreditos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SolicitudCreditos.svc or SolicitudCreditos.svc.cs at the Solution Explorer and start debugging.
    public class SolicitudCreditos : AbstractConexion , ISolicitudCreditos 
    {
        private clsCNSolCre cnSolCred = new clsCNSolCre(true);
        private clsCNProducto cnProducto = new clsCNProducto(true);
        private clsCNSolicitud cnSolicitud = new clsCNSolicitud(true);
        private clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas(true);

        public SolicitudCreditos()
        {
            this.setConectionString();
        }

        #region WebServices
        public clsSolicitudCreditos RegistrarSolicitudCredito(string cToken, clsSolicitudCreditos objSolicitud)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            try
            {
                if (!usuario.validaToken(cToken))
                {
                    clsSolicitudCreditos objErr = new clsSolicitudCreditos();
                    objErr.oResultado = new clsWCFRespuesta();
                    objErr.oResultado.idRespuesta = 0;
                    objErr.oResultado.cMensaje = "Acceso denegado";
                    return objErr;
                }
                new clsCNVarGen().LisVar(datosToken.idAgencia);
                new clsCNVarApl().LisVar(datosToken.idAgencia); //revisar
                

                ConCreditoTasa con = new ConCreditoTasa();
                clsCreditoProp oProp = GeneraCreditoProPorSolicitudCred(objSolicitud);
                con.AsignarDatosObj(oProp);
                con.GeneraPlanPagos();
                objSolicitud.nCuotaAprox = con.CuotaAprox();
                objSolicitud.nCuotaGraciaAprox = con.CuotaGraciaAprox();
                //TODO:Validar el token y los registros de las clases

                objSolicitud.idAgencia = datosToken.idAgencia;
                objSolicitud.idUsuario = datosToken.idUsuario;
                objSolicitud.idUsuRegistro = datosToken.idUsuario;

                //Algoritmo de cliente nuevo o recurrente
                clsTipoCliente objTipCli = new clsTipoCliente(objSolicitud.idCli, objSolicitud.idTipoCli);
                objSolicitud.idTipoCli = objTipCli.initClienteRecurrente();

                DataTable dtRes = new DataTable();
                
                dtRes = cnSolCred.CNRegistrarSolicitudCredito(objSolicitud, datosToken.idUsuario, datosToken.idAgencia);
                if (dtRes.Rows.Count > 0)
                {
                    objSolicitud.oResultado = new clsWCFRespuesta();
                    objSolicitud.oResultado.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["nResultado"]);
                    if (objSolicitud.oResultado.idRespuesta == 1)
                    {
                        objSolicitud.idSolicitud = Convert.ToInt32(dtRes.Rows[0]["idSolicitud"]);
                        objSolicitud.oResultado.cMensaje = dtRes.Rows[0]["cMensaje"].ToString();
                    }
                }
                

                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                string cCumpleReglas = String.Empty;
                cCumpleReglas = cnregladinamica.ValidarReglasCreditos(ArmarTablaParametros(objSolicitud, datosToken), "frmRegistroSolicitudCredito",
                                                                       datosToken.idAgencia, objSolicitud.idCli,
                                                                       1, objSolicitud.IdMoneda, objSolicitud.idProducto,
                                                                       objSolicitud.nCapitalSolicitado, objSolicitud.idSolicitud, datosToken.dFechaSistema,
                                                                       2, 1,
                                                                       datosToken.idUsuario, ref  nNivAuto, false, true);

                //bool lFlagExcepciones = PermitirActualizarPorExcepcionCred(Convert.ToInt32(txtCodigoSol.Text));
                int idSolicitud = Convert.ToInt32(objSolicitud.idSolicitud);
                if (cCumpleReglas.Equals("Cumple"))
                {
                    objSolicitud.oResultado.idRespuesta = 1;
                    cnSolicitud.CNActualizaEstadoSolCre(idSolicitud, 1);
                }
                else
                {
                    objSolicitud.oResultado.idRespuesta = 2;
                    objSolicitud.oResultado.cMensaje = objSolicitud.oResultado.cMensaje + Environment.NewLine + cnregladinamica.cMensajeErrores;
                    cnSolicitud.CNActualizaEstadoSolCre(idSolicitud, 0);
                }
            }
            catch (Exception e)
            {
                clsSolicitudCreditos objErr = new clsSolicitudCreditos();
                objErr.oResultado = new clsWCFRespuesta();
                objErr.oResultado.idRespuesta = 0;
                objErr.oResultado.cMensaje = e.Message;
                return objErr;
            }

            return objSolicitud;
        }

        public IList<clsWCFClienteCriterioExpresion> BusquedaClienteCriterioExpresion(string cToken, int idCriterio, string cExpresion, bool lReniec)
        {
            IList<clsWCFClienteCriterioExpresion> lstClientes = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtClientes = cnSolicitud.BuscarClienteCriterioExpresion(idCriterio, cExpresion);
                lstClientes = dtClientes.SoftToList<clsWCFClienteCriterioExpresion>();
                if (dtClientes.Rows.Count == 0 && idCriterio == 1 && cExpresion.Length == 8 && lReniec)
                {
                    dynamic obj = new { cNroDni = cExpresion, cDocAutorizado = "42155044", cIdUsu = datosToken.idUsuario.ToString() };
                    string json = new JavaScriptSerializer().Serialize(obj);
                    byte[] request = Encoding.ASCII.GetBytes(json);
                    try
                    {
                        WebClient wc = new WebClient();
                        wc.Headers["Content-type"] = "application/json";
                        wc.Encoding = Encoding.UTF8;
                        byte[] response = wc.UploadData("http://10.5.5.70:8000/ServicioReniec.svc/ConsultaIndInfPerReniec", "POST", request);
                        Stream stream = new MemoryStream(response);
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(clsProcesaDatosRen));
                        clsProcesaDatosRen persona = serializer.ReadObject(stream) as clsProcesaDatosRen;
                        if (persona.cErrorF == "0000")
                        {
                            lstClientes.Add(toClienteBasico(persona));
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            return lstClientes;
        }

        clsWCFClienteCriterioExpresion toClienteBasico(clsProcesaDatosRen datos)
        {
            clsWCFClienteCriterioExpresion persona = new clsWCFClienteCriterioExpresion();
            persona.idCli = 0;
            persona.cDocumentoID = datos.cDniF;
            persona.cNombreCliente = datos.cApellidoPater.Trim() + " " + datos.cApellidoMater.Trim() + " " + datos.cNombres.Trim();
            persona.lReniec = 1;
            persona.idTipoDocumento = 1;
            return persona;
        }

        public IList<clsVinculadoCredito> ObtenerVinculados(string cToken, int idSolicitud)
        {
            IList<clsVinculadoCredito> listaVinculados = null;
            clsDatosToken datosToken = this.getUsuario().obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dt = cnSolicitud.ObtenerVinculados(idSolicitud);
                listaVinculados = dt.ToList<clsVinculadoCredito>();
                return listaVinculados;
            }
            return listaVinculados;
        }

        public IList<clsClienteVincular> BurcarClienteVincular(string cToken, int idTipoDocumento, string cDocumentoID)
        {
            IList<clsClienteVincular> listaClientes = null;
            clsDatosToken datosToken = this.getUsuario().obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                DataTable dt = cnSolicitud.BuscarClientesVincular(idTipoDocumento, cDocumentoID);
                listaClientes = dt.ToList<clsClienteVincular>();
                return listaClientes;
            }
            return listaClientes;
        }

        public clsWCFRespuesta RegistroInterviniente(string cToken, int idSolicitud, int idCli, int idTipoInterviniente, int idProducto)
        {
            clsWCFRespuesta resultado = new clsWCFRespuesta();
            clsDatosToken datosToken = this.getUsuario().obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                if ((idTipoInterviniente == 3 || idTipoInterviniente == 2) && validarRegla(idSolicitud, idCli, idTipoInterviniente, idProducto, datosToken) == "NoCumple")
                {
                    resultado.idRespuesta = 1;
                    resultado.cMensaje = cnregladinamica.cMensajeErrores;
                    return resultado;
                }
                if (cnSolicitud.RegistroInterviniente(idSolicitud, idCli, idTipoInterviniente, datosToken.idUsuario, datosToken.dFechaSistema))
                {
                    resultado.idRespuesta = 0;
                    resultado.cMensaje = "Registro Exitoso";
                }
                else
                {
                    resultado.idRespuesta = 1;
                    resultado.cMensaje = "Fallo en el registro";
                }
                return resultado;
            }
            resultado.idRespuesta = 2;
            resultado.cMensaje = "No hay sesion";
            return resultado;
        }

        private string validarRegla(int idSolicitud, int idCli, int idTipoInterviniente, int idProducto, clsDatosToken datosToken)
        {
            int nNivAuto = 0;
            return cnregladinamica.ValidarReglasCreditos(ArmarParametrosInterviniente(idCli, idTipoInterviniente, idProducto, datosToken.dFechaSistema), "FrmRegIntervieneCre",
                                                                           datosToken.idAgencia, idCli,
                                                                           1, 1, idProducto, 0, idSolicitud, datosToken.dFechaSistema,
                                                                           2, 1, datosToken.idUsuario, ref nNivAuto, false, true);
        }

        public clsWCFRespuesta EliminarInterviniente(string cToken, int idIntervinienteCredito)
        {
            clsWCFRespuesta resultado = new clsWCFRespuesta();
            clsDatosToken datosToken = this.getUsuario().obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                if (cnSolicitud.EliminarInterviniente(idIntervinienteCredito, datosToken.idUsuario, datosToken.idAgencia, datosToken.dFechaSistema))
                {
                    resultado.idRespuesta = 0;
                    resultado.cMensaje = "Eliminado Exitosamente";
                }
                else
                {
                    resultado.idRespuesta = 1;
                    resultado.cMensaje = "Fallo en el eliminar";
                }
                return resultado;
            }
            resultado.idRespuesta = 2;
            resultado.cMensaje = "No hay sesion";
            return resultado;
        }
        
        public IList<clsTasa> ObtenerTasa(string cToken, int nPlazo , int idProducto , decimal nMonto, int idSolicitud)
        {
            IList<clsTasa> listTasa = null;
            if (!usuario.validaToken(cToken))
            {
                return listTasa;
            }

            clsCNTasaCredito cnObjTasa = new clsCNTasaCredito(true);
            //TODO:Validar el token y los registros de las clases
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = this.getUsuario().obtenerDatosToken(cToken);
            DataTable dtTasa;
            if (idSolicitud == 0)
            {
                dtTasa = cnObjTasa.ListaTasaCredito(nPlazo, idProducto, nMonto, Moneda.MonedaNacional, datosToken.idAgencia, OperacionSolCred.OTORGAMIENTO, 0);
            }
            else
            {
                dtTasa = cnObjTasa.ListaTasaEval(nPlazo, idProducto, nMonto, Moneda.MonedaNacional, datosToken.idAgencia, idSolicitud, 0);
            }
            listTasa = dtTasa.ToList<clsTasa>();
            return listTasa;
        }

        public clsWCFRespuesta ComprobarBaseNegativa(string cToken, string cDocumentoID)
        {
            clsWCFRespuesta response = new clsWCFRespuesta();
            response.idRespuesta = 0;
            response.cMensaje = "";
            if (usuario.validaToken(cToken))
            {
                string msg = cnSolicitud.ValidaBaseNegativa(cDocumentoID);
                if (msg != "")
                {
                    response.idRespuesta = 1;
                    response.cMensaje = msg;
                }
                msg = cnSolicitud.ValidaPep(cDocumentoID);
                if (msg != "")
                {
                    response.idRespuesta = 1;
                    response.cMensaje = msg;
                }
            }
            return response;
        }

        public clsWCFRespuesta EnviarSolicitud(string cToken, int idSolicitud)
        {
            clsCreditoProp obj = new clsCreditoProp();
            clsWCFRespuesta objRes;

            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            try
            {

                if (!usuario.validaToken(cToken))
                {
                    objRes = new clsWCFRespuesta();
                    objRes.cMensaje = "Error en el Tocken";
                    return objRes;
                }
            
                DataTable dtSolicitud = cnSolicitud.ConsultaSolicitud(idSolicitud);

                if (dtSolicitud.Rows.Count == 0)
                {
                    objRes = new clsWCFRespuesta();
                    objRes.idRespuesta = 0;
                    objRes.cMensaje = "No existe una solicitud";
                    return objRes;
                }

                obj = FormatearSolicitud(dtSolicitud, datosToken.idAgencia);
                string cXML = cargarDeudasFinan("", 0, obj.idCli);
                DataTable dtRes = cnSolicitud.CNEnviarAEvaluacionWS(obj.GetXml(), datosToken.idUsuario, idSolicitud, cXML);

                objRes = new clsWCFRespuesta();
                objRes.idRespuesta = Convert.ToInt32(dtRes.Rows[0]["nResultado"]);
                objRes.cMensaje = Convert.ToString(dtRes.Rows[0]["cMensaje"]);

            }
            catch (Exception e) 
            {
                objRes = new clsWCFRespuesta();
                objRes.idRespuesta = 1;
                objRes.cMensaje = e.StackTrace;
            }
            return objRes;
        }

        public IList<clsClienteCampanaVigente> TieneCampanaVigente(string cToken, int idTipoDocumento, string cDocumentoId)
        {
            IList<clsClienteCampanaVigente> obj = null;
            
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = this.getUsuario().obtenerDatosToken(cToken);

            if (!usuario.validaToken(cToken))
            {
                return obj;
            }
            

            DataTable dtResult = cnSolCred.CNListaCampanaxCliente(idTipoDocumento, cDocumentoId, datosToken.idUsuario);
            obj = dtResult.ToList<clsClienteCampanaVigente>();

            return obj;

        }

        public IList<clsProducto> ProductoXCampana(string cToken, int idGrupoCamp)
        {
            IList<clsProducto> listProducto = null;
            if (!usuario.validaToken(cToken))
            {
                return listProducto;
            }

            DataTable dtResult = cnProducto.CNListarProductoPorCampana(idGrupoCamp);
            listProducto = dtResult.ToList<clsProducto>();

            return listProducto;
        }

        public IList<clsSubProducto> ObtenerSubProductos(string cToken)
        {
            IList<clsSubProducto> listProducto = null;
            if (!usuario.validaToken(cToken))
            {
                return listProducto;
            }

            DataTable dtResult = cnProducto.CNListarSubProducto();
            listProducto = dtResult.ToList<clsSubProducto>();

            return listProducto;
        }

        public IList<clsProducto> ProductosVigentes(string cToken)
        {
            IList<clsProducto> listProducto = null;
            if (!usuario.validaToken(cToken))
            {
                return listProducto;
            }

            DataTable dtResult = cnProducto.CNListaProductos();
            listProducto = dtResult.ToList<clsProducto>();

            return listProducto;
        }

        public IList<clsCreditoCliente> ListaCreditosCliente(string cToken, int idCli)
        {
            IList<clsCreditoCliente> listCreditoCiente = null;
            if (!usuario.validaToken(cToken))
            {
                return listCreditoCiente;
            }

            DataTable dtResult = cnSolCred.CNListaCreditosCliente(idCli);
            listCreditoCiente = dtResult.ToList<clsCreditoCliente>();

            return listCreditoCiente;
        }

        public clsSolicitudCreditos TieneSolicitudCreditos(string cToken, int idTipoDocumento, string cDocumentoId)
        {
            clsDatosToken datosToken = new clsDatosToken();
            IList<clsSolicitudCreditos> listSolicitud = null;
            clsSolicitudCreditos objSol = new clsSolicitudCreditos();
            try
            {
                datosToken = this.getUsuario().obtenerDatosToken(cToken);


                if (!usuario.validaToken(cToken))
                {
                    objSol.oResultado = new clsWCFRespuesta();
                    objSol.oResultado.idRespuesta = 0;
                    objSol.oResultado.cMensaje = "Acceso denegado";
                    return objSol;
                }

                DataSet dtRes = cnSolCred.CNBuscarSolicitudCred(idTipoDocumento, cDocumentoId);
                if (dtRes.Tables.Count == 0)
                {
                    objSol.oResultado = new clsWCFRespuesta();
                    objSol.oResultado.idRespuesta = 0;
                    objSol.oResultado.cMensaje = "No se encontraron solicitudes";
                    return objSol;
                }

                listSolicitud = dtRes.Tables[0].SoftToList<clsSolicitudCreditos>();
                objSol = listSolicitud[0];

                if (dtRes.Tables[1].Rows.Count > 0)
                {
                    IList<clsCreditoCliente> lstCreditos = dtRes.Tables[1].ToList<clsCreditoCliente>();
                    objSol.lstCreditos = new List<clsCreditoCliente>(lstCreditos);
                }

                objSol.oResultado = new clsWCFRespuesta();
                objSol.oResultado.idRespuesta = 1;
                objSol.oResultado.cMensaje = "Se encontro una solicitud pendiente";
                return objSol;
            }
            catch (Exception e)
            {
                objSol.oResultado = new clsWCFRespuesta();
                objSol.oResultado.idRespuesta = 0;
                objSol.oResultado.cMensaje = "Se encontro una solicitud pendiente : "+e.Message+" ----  "+e.StackTrace;
                return objSol;
            }
            
        }

        public IList<clsProductoAgricolaCultivo> ListaProductoAgricolaCultivo(string cToken)
        {
            IList<clsProductoAgricolaCultivo> listProductoAgricolaCultivo = null;
            if (!usuario.validaToken(cToken))
            {
                return listProductoAgricolaCultivo;
            }

            DataTable dtResult = cnSolCred.CNListaProductoAgricolaCultivo();
            listProductoAgricolaCultivo = dtResult.ToList<clsProductoAgricolaCultivo>();

            return listProductoAgricolaCultivo;
        }

        public IList<clsProductoAgricolaCultivoVariedad> ListaProductoAgricolaCultivoVariedad(string cToken, int idCultivoEval)
        {
            IList<clsProductoAgricolaCultivoVariedad> listProductoAgricolaCultivoVariedad = null;
            if (!usuario.validaToken(cToken))
            {
                return listProductoAgricolaCultivoVariedad;
            }

            DataTable dtResult = cnSolCred.CNListaProductoAgricolaCultivoVariedad(idCultivoEval);
            listProductoAgricolaCultivoVariedad = dtResult.ToList<clsProductoAgricolaCultivoVariedad>();

            return listProductoAgricolaCultivoVariedad;
        }

        public clsWCFRespuesta RegistroCultivoVariedadEvaluacion(string cToken, int idEvalCred, int idCultivoEval, int idVariedadCultivoEval)
        {
            clsWCFRespuesta respuesta = new clsWCFRespuesta();
            if (!usuario.validaToken(cToken))
            {
                respuesta.idRespuesta = 1;
                respuesta.cMensaje = "No hay sesion activa";
                return respuesta;
            }
            try
            {
                clsDatosToken objToken = usuario.obtenerDatosToken(cToken);
                DataTable dtResult = cnSolCred.CNRegistroCultivoVariedadEvaluacion(idEvalCred, idCultivoEval, idVariedadCultivoEval, objToken.idAgencia);
                if (dtResult.Rows.Count > 0)
                {
                    respuesta.idRespuesta = Convert.ToInt32(dtResult.Rows[0]["idRespuesta"].ToString());
                    respuesta.cMensaje = dtResult.Rows[0]["cMensaje"].ToString();
                }
            }
            catch (Exception e)
            {
                respuesta.idRespuesta = 1;
                respuesta.cMensaje = e.Message;
            }

            return respuesta;
        }

        public clsProductoAgricolaCultivoVariedadSeleccionado ProductoAgricolaCultivoVariedad(string cToken, int idCultivoEval, int idSubProducto)
        {
            if (!usuario.validaToken(cToken))
            {
                return null;
            }
            DataTable dtResult = cnSolCred.CNProductoAgricolaCultivoVariedad(idCultivoEval, idSubProducto);
            if (dtResult.Rows.Count == 0)
            {
                return null;
            }
            IList<clsProductoAgricolaCultivoVariedadSeleccionado> listProductoAgricolaCultivoVariedad = dtResult.ToList<clsProductoAgricolaCultivoVariedadSeleccionado>();
            return listProductoAgricolaCultivoVariedad[0];
        }

        #endregion

        #region Metodos 
        public clsCreditoProp FormatearSolicitud(DataTable dt, int idAgencia)
        {
            new clsCNVarGen().LisVar(idAgencia);
            new clsCNVarApl().LisVar(idAgencia); //revisar
            
            clsCreditoProp oProp= new clsCreditoProp()
            {
                idOrigenCredProp = 1,
                idSolicitud = Convert.ToInt32(dt.Rows[0]["idSolicitud"]),
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = Convert.ToDecimal(dt.Rows[0]["nCapitalSolicitado"]),
                nCuotas = Convert.ToInt32(dt.Rows[0]["nCuotas"]),
                idTipoPeriodo = Convert.ToInt32(dt.Rows[0]["idTipoPeriodo"]),
                nPlazoCuota = Convert.ToInt32(dt.Rows[0]["nPlazoCuota"]),
                nDiasGracia = Convert.ToInt32(dt.Rows[0]["ndiasgracia"]),
                idTasa = Convert.ToInt32(dt.Rows[0]["idTasa"]),
                dFechaDesembolso = Convert.ToDateTime(dt.Rows[0]["dFechaDesembolsoSugerido"]),
                dFechaPrimeraCuota = Convert.ToDateTime(dt.Rows[0]["dFechaPrimeraCuota"]),
                nTasaCompensatoria = Convert.ToDecimal(dt.Rows[0]["nTasaCompensatoria"]),
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = Convert.ToString(dt.Rows[0]["tObservacion"]),
                idCli = Convert.ToInt32(dt.Rows[0]["idCli"]),
                nCuotasGracia = Convert.ToInt32(dt.Rows[0]["nCuotasGracia"])
            };

            ConCreditoTasa con = new ConCreditoTasa();

            con.AsignarDatosObj(oProp);
            con.GeneraPlanPagos();
            oProp.nCuotaAprox = con.CuotaAprox();
            oProp.nCuotaGraciaAprox = con.CuotaGraciaAprox();

            return oProp;

        }

        public clsCreditoProp GeneraCreditoProPorSolicitudCred(clsSolicitudCreditos obj)
        {
            clsCreditoProp objRes = new clsCreditoProp();
            objRes.idTipoPeriodo = obj.idTipoPeriodo;
            objRes.idMoneda = obj.IdMoneda;
            objRes.nMonto = obj.nCapitalSolicitado;
            objRes.nCuotas = obj.nCuotas;
            objRes.nPlazoCuota = obj.nPlazoCuota;
            objRes.nCuotasGracia = obj.nCuotasGracia;
            objRes.nDiasGracia = obj.ndiasgracia;
            objRes.dFechaDesembolso = obj.dFechaDesembolsoSugerido;
            objRes.idProducto = obj.idProducto;
            objRes.idTasa = obj.idTasa;
            objRes.nTasaCompensatoria = obj.nTasaCompensatoria;
            objRes.dFechaPrimeraCuota = obj.dFechaPrimeraCuota;

            return objRes;
        }

        private DataTable ArmarTablaParametros(clsSolicitudCreditos objSol, clsDatosToken datosToken)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");
            //123
            int idUsuario = objSol.idUsuario;

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = objSol.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = "'0'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = idUsuario;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = objSol.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoTasaCredito";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + datosToken.dFechaSistema.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSolicitud";
            drfila[1] = "'" + objSol.dFechaRegistro.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = objSol.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = objSol.nCapitalSolicitado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = objSol.IdMoneda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = objSol.nCuotas.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = objSol.idTipoPeriodo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = objSol.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = objSol.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nDiasGracia";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaDesembolso";
            drfila[1] = "'" + objSol.dFechaDesembolsoSugerido.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idActivEcon";
            drfila[1] = objSol.idActividad.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "CIIU";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "PersonalCre";
            drfila[1] = objSol.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoCredito";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubTipoCredito";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Producto";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = objSol.idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "DestinoCredito";
            drfila[1] = objSol.idDestino.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idFuenteRecur";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAdeudado";
            drfila[1] = "";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMes";
            drfila[1] = objSol.nTasaCompensatoria.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMin";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMax";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "ModDesembolso";
            drfila[1] = objSol.idModalidadDes;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = "''";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = datosToken.idAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = datosToken.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = datosToken.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVigente";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = objSol.dFechaRegistro.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoAsesorFam = new GEN.CapaNegocio.clsCNCredito(true);
            DataTable SaldoIndividual = SaldoAsesorFam.CNRetornSaldoxAseFam(objSol.idCli, objSol.nCapitalSolicitado, objSol.IdMoneda, datosToken.idAgencia);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nSaldoInd";
            drfila[1] = SaldoIndividual.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoTotalAsesorFam = new GEN.CapaNegocio.clsCNCredito(true);
            DataTable SaldoGlobal = SaldoTotalAsesorFam.CNRetornSaldoTotalAseFam(datosToken.idAgencia, objSol.nCapitalSolicitado, objSol.IdMoneda);
            drfila = dtTablaParametros.NewRow();

            drfila[0] = "nSaldoGlobal";
            drfila[1] = SaldoGlobal.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);
            //agregar idCuenta en una sola cadena

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cCadenaIdCuenta";
            drfila[1] = "'" + this.ConcatenarIdCuenta(objSol) + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = "500000";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdTipologiaCre";
            drfila[1] = objSol.idModalidadCredito.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoTasaCredito";
            drfila[1] = objSol.idTasa;
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = objSol.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            int nPlazoTotal = 0;

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = nPlazoTotal;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = objSol.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotasGracia";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaProximoVencimiento";
            drfila[1] = "'" + datosToken.dFechaSistema.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCliente";
            drfila[1] = objSol.idTipoCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoLocalActividad";
            drfila[1] = 0;
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }
        #endregion

        private string cargarDeudasFinan(string cDocID, int idEvalCred, int idCli)
        {
            #region Obtener datos DB
            DataSet ds = (new clsCNEvalPyme(true)).ObtenerSaldosEntFinancieras(cDocID, idCli);

            //-- Table[0] : Saldos RCC
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[0]) as List<clsDeudasEval>;

            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();


            //-- Table[1] : Saldos CRAC - LASA
            var listCRACSaldos = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[1]) as List<clsDeudasEval>;

            foreach (var item in listCRACSaldos)
            {
                listSaldosRCC.Add(item);
            }


            #region Saldos con entidades financieras
            List<clsDeudasEval> objSaldosDeudas = new List<clsDeudasEval>();
            foreach (clsDeudasEval saldos in listSalRCCDirectos)
            {
                saldos.nCuotasPag = 0;
                saldos.nCuotasPen = 0;
                saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                saldos.nSCapLargoPlz = 0;
                saldos.nMontoCuota = 0;
                //saldos.dFechaConsulta = "";
                saldos.lAutomatico = true;
                //saldos.idTipoCredito = 0;

                objSaldosDeudas.Add(saldos);
            }

            foreach (clsDeudasEval saldos in listSalRCCDIndirec)
            {
                saldos.nCuotasPag = 0;
                saldos.nCuotasPen = 0;
                saldos.nSCapCortoPlz = 0;
                saldos.nSCapLargoPlz = saldos.nSCapTotalSis;
                saldos.nMontoCuota = 0;
                //saldos.dFechaConsulta = "";
                saldos.lAutomatico = true;
                //saldos.idTipoCredito = 0;

                objSaldosDeudas.Add(saldos);
            }

            foreach (clsDeudasEval saldos in listCRACSaldos)
            {
                //saldos.nCuotasPag       = 0;
                //saldos.nCuotasPen       = 0;
                saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                saldos.nSCapLargoPlz = 0;
                //saldos.nMontoCuota      = 0;
                saldos.dFechaConsulta = clsVarGlobal.dFecSystem; ;
                saldos.lAutomatico = true;
                saldos.idTipoCredito = 4;

                objSaldosDeudas.Add(saldos);
            }

            string xmlSaldosDeudas = SaldosEnXML(objSaldosDeudas);
            return xmlSaldosDeudas;
            //DataTable obj = new clsCNEvaluacion().CNGuardaDeudasEvalResumidas(idEvalCred, xmlSaldosDeudas);

            #endregion
            #endregion
        }

        private string SaldosEnXML(List<clsDeudasEval> listDeudas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDeudasEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idTipoDeuda", typeof(int));
            dt.Columns.Add("idDeudaCA", typeof(int));
            dt.Columns.Add("cCodigoEmpresa", typeof(string));
            dt.Columns.Add("cNombreEmpresa", typeof(string));
            dt.Columns.Add("idCuenta", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nMontoAprobado", typeof(decimal));
            dt.Columns.Add("nCuotasPag", typeof(int));
            dt.Columns.Add("nCuotasPen", typeof(int));
            dt.Columns.Add("nCuotasTotal", typeof(int));
            dt.Columns.Add("nSCapTotalSis", typeof(decimal));
            dt.Columns.Add("nSCapTotal", typeof(decimal));
            dt.Columns.Add("nSCapCortoPlz", typeof(decimal));
            dt.Columns.Add("nSCapLargoPlz", typeof(decimal));
            dt.Columns.Add("nMontoCuota", typeof(decimal));
            //dt.Columns.Add("cCronograma", typeof(string));
            dt.Columns.Add("dFechaConsulta", typeof(DateTime));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("lAutomatico", typeof(bool));
            dt.Columns.Add("idTipoCredito", typeof(int));
            dt.Columns.Add("cGUID", typeof(string));

            foreach (var deuda in listDeudas)
            {
                DataRow row = dt.NewRow();

                row["idDeudasEval"] = deuda.idDeudasEval;
                //newCustomersRow["idEvalCred"] = rcc.idEvalCred;
                row["idTipoDeuda"] = deuda.idTipoDeuda;
                row["idDeudaCA"] = deuda.idDeudaCA;
                row["cCodigoEmpresa"] = deuda.cCodigoEmpresa;
                row["cNombreEmpresa"] = deuda.cNombreEmpresa;
                row["idCuenta"] = deuda.idCuenta;
                row["idProducto"] = deuda.idProducto;
                row["idMoneda"] = deuda.idMoneda;
                row["nMontoAprobado"] = deuda.nMontoAprobado;
                row["nCuotasPag"] = deuda.nCuotasPag;
                row["nCuotasPen"] = deuda.nCuotasPen;
                row["nCuotasTotal"] = deuda.nCuotasTotal;
                row["nSCapTotalSis"] = deuda.nSCapTotalSis;
                row["nSCapTotal"] = deuda.nSCapTotal;
                row["nSCapCortoPlz"] = deuda.nSCapCortoPlz;
                row["nSCapLargoPlz"] = deuda.nSCapLargoPlz;
                row["nMontoCuota"] = deuda.nMontoCuota;
                //row["cCronograma"] = deuda.cCronograma;
                row["dFechaConsulta"] = deuda.dFechaConsulta;
                row["idMonedaMA"] = Evaluacion.idMoneda;
                row["lAutomatico"] = deuda.lAutomatico;
                row["idTipoCredito"] = deuda.idTipoCredito;
                row["cGUID"] = deuda.cGUID;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DeudasEval", "Item");
            
        }

        private DataTable ArmarParametrosInterviniente(int idCli, int idTipoInterviniente, int idProducto, DateTime dFechaSistema)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliInterv";
            drfila[1] = idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoInterv";
            drfila[1] = idTipoInterviniente;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();//
            drfila[0] = "idTipoPerInterv";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();//
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + dFechaSistema.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();//
            drfila[0] = "SubProducto";
            drfila[1] = idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private string ConcatenarIdCuenta(clsSolicitudCreditos objSol)
        {
            string idCuentas = "";

            foreach (clsCreditoCliente item in objSol.lstCreditos)
            {
                idCuentas = idCuentas + "," + item.idCuenta.ToString();
            }

            if (!String.IsNullOrEmpty(idCuentas))
            {
                idCuentas = idCuentas.Substring(1);
            }

            return idCuentas;
        }
    }
}
