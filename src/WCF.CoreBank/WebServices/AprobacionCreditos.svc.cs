using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WCF.CoreBank.Interface;
using EntityLayer;
using GEN.CapaNegocio;
using RCP.CapaNegocio;
using System.Data;
using GEN.Funciones;
using GEN.AccesoDatos;
using WCF.CoreBank;
using CRE.AccesoDatos;

namespace WCF.CoreBank.WebServices
{
    public class AprobacionCreditos : AbstractConexion, IAprobacionCreditos
    {
        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();

        public AprobacionCreditos()
        {
            this.setConectionString();
        }

        public IList<clsWCFCredito> ListarEvaluacionesParaAprobar(string cToken)
        {
            IList<clsWCFCredito> lstCredito = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtCreditos = new clsCNHojaRuta(true).WCFListaCreditosAprobacion(datosToken.idAgencia, datosToken.idPerfil, datosToken.idUsuario);
                lstCredito = dtCreditos.ToList<clsWCFCredito>();
            }

            return lstCredito;
        }
        
        public clsWCFDatosCliente ObtenerEvaluacion(string cToken, int idEvalCred, int idSolicitud)
        {
            clsWCFDatosCliente resultado = new clsWCFDatosCliente();
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {

                resultado.cActividad = new clsCNHojaRuta(true).WCFActividadEconomica(idEvalCred);
                DataTable dtIndicadores = new clsCNHojaRuta(true).WCFIndicadores(idEvalCred);
                resultado.lIndicadores = dtIndicadores.ToList<clsWCFIndicadores>();
                DataTable dtDeuda = new clsCNHojaRuta(true).WCFDeuda(idEvalCred);
                resultado.lDeuda = dtDeuda.ToList<clsWCFDeuda>();
                //DataTable dtEstadoResultados = new clsCNHojaRuta(true).WCFEstadoResultados(idEvalCred);
                //resultado.lEstadoResultados = dtEstadoResultados.ToList<clsWCFEstadoResultados>();
                resultado.nEvaluacionCualitativa = new clsCNHojaRuta(true).WCFEvaluacionCualitativa(idEvalCred);
                List<clsComposicionCredito> lDestino = new clsADInformeRiesgos(true).listarComposicionCredito(idEvalCred);
                resultado.lDestino = ListToIList.ConvertToListOf<clsComposicionCredito>(lDestino);
                if (resultado.lDestino.Count == 0)
                {
                    DataTable dtDestino = new clsCNHojaRuta(true).WCFEDestino(idEvalCred);
                    resultado.lDestino = dtDestino.ToList<clsComposicionCredito>();
                }

                DataSet dsGaratias = new clsADComiteCreditos(true).ADLstGarantiasSolCre(idSolicitud);
                DataTable dtGarantias = dsGaratias.Tables[0];
                resultado.lGarantias = dtGarantias.ToList<clsWCFGarantia>();

                DataTable dtRiesgos = new clsCNHojaRuta(true).WCFRiesgos(idSolicitud);
                if (dtRiesgos.Rows.Count != 0)
                {
                    if (dtRiesgos.Rows[0]["lFavorable"].ToString() == "True")
                    {
                        resultado.cRiesgos = "FAVORABLE";
                    }
                    else
                    {
                        resultado.cRiesgos = "DESFAVORABLE";
                    }
                }
                else
                {
                    resultado.cRiesgos = "NO TIENE";
                }
                DataTable dtIntervinientes = new clsCNHojaRuta(true).WCFIntervinientes(idSolicitud);
                resultado.lIntervinientes = dtIntervinientes.ToList<clsWCFInterviniente>();
            }
            return resultado;
        }

        public clsWCFGestionAprobacion GuardarDesicion(string cToken, int idSolicitud, int idAprobacion, int idEvalCred, decimal nMonto, string cComentario, int idMotRechazo)
        {
            IList<clsWCFGestionAprobacion> lstGestion = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFGestionAprobacion res = new clsWCFGestionAprobacion();
            int idCanalReg = 2;

            if (usuario.validaToken(cToken))
            {
                DataSet dsInicializacion = new clsCNHojaRuta(true).WCFInicializarCreditoAprobacion(idEvalCred, datosToken.idUsuario, datosToken.idPerfil, datosToken.dFechaSistema);
                if (Convert.ToInt32(dsInicializacion.Tables[0].Rows[0]["idError"]) == 1)
                {
                    res.cMensaje = Convert.ToString(dsInicializacion.Tables[0].Rows[0]["cMensaje"]);
                    res.idError = 1;
                    return res;
                }
                DataTable dtGestion = new clsCNHojaRuta(true).WCFCreditosAprobacionGestion(idSolicitud, idEvalCred, datosToken.idAgencia, nMonto);
                lstGestion = dtGestion.ToList<clsWCFGestionAprobacion>();
                
                if (idAprobacion == 5)
                {

                    if (lstGestion[0].idError == 0)
                    {
                        DataTable guardar = new clsCNHojaRuta(true).WCFCreditosAprobacionGuardar(idSolicitud, idEvalCred, datosToken.idUsuario, lstGestion[0].idEstadoEvalCred, 4, lstGestion[0].idNivelAprobacion, lstGestion[0].lEnviaSolInfRiesgos, lstGestion[0].lRevision, cComentario, false, 0, datosToken.dFechaSistema, idCanalReg);
                        if (Convert.ToInt32(guardar.Rows[0]["idError"]) == 0)
                        {
                            return lstGestion[0];
                        }
                        else
                        {
                            res.cMensaje = "" + guardar.Rows[0]["cMensaje"];
                            res.idError = 1;
                            return res;
                        }
                    }
                    else
                    {
                        res.cMensaje = lstGestion[0].cMensaje;
                        res.idError = 1;
                        return res;
                    }
                }
                else
                {
                    DataTable guardar = new clsCNHojaRuta(true).WCFCreditosAprobacionGuardar(idSolicitud, idEvalCred, datosToken.idUsuario, idAprobacion, 5, lstGestion[0].idNivelAprobacion, false, false, cComentario, false, idMotRechazo, datosToken.dFechaSistema, idCanalReg);
                    if (Convert.ToInt32(guardar.Rows[0]["idError"]) == 0)
                    {
                        res.cMensaje = "Credito rechazado";
                        return res;
                    }
                    else
                    {
                        res.cMensaje = "" + guardar.Rows[0]["cMensaje"];
                        res.idError = 1;
                        return res;
                    }
                }
            }

            return res;
        }

    }
}
