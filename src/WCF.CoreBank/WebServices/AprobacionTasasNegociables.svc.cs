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
    public class AprobacionTasasNegociables : AbstractConexion, IAprobacionTasasNegociables
    {
        clsCNUsuarioSistema usuario = new clsCNUsuarioSistema();

        public AprobacionTasasNegociables()
        {
            this.setConectionString();
        }

        public IList<clsWCFTasaNegociable> ListaSolicitudesTasaNegociable(string cToken)
        {
            IList<clsWCFTasaNegociable> lstTasaNegociable = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtTasaNegociablePre = new clsADSolicitud(true).ListaSolicitudesTasaNegociablePrepAprobacion(datosToken.idUsuario, datosToken.idPerfil);
                DataTable dtTasaNegociable = new clsADSolicitud(true).ListaSolicitudesTasaNegociable(datosToken.idUsuario, datosToken.idPerfil);
                lstTasaNegociable = dtTasaNegociablePre.ToList<clsWCFTasaNegociable>();
                IList<clsWCFTasaNegociable> lstTasaNegociableLast = dtTasaNegociable.ToList<clsWCFTasaNegociable>();
                for (int i = 0; i < lstTasaNegociableLast.Count; i++)
                {
                    lstTasaNegociable.Add(lstTasaNegociableLast[i]);
                }
                return lstTasaNegociable;
            }

            return lstTasaNegociable;
        }
        
        public IList<clsWCFDetalleTasaNegociable> DetalleSolicitudTasaNegociable(string cToken, int idSolicitud, int idTasaNegociada)
        {
            IList<clsWCFDetalleTasaNegociable> lstDetalleTasaNegociable = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtDetalleTasaNegociable = new clsADSolicitud(true).ExtraeDatosSolicitudTNegAproba(idSolicitud, idTasaNegociada);
                lstDetalleTasaNegociable = dtDetalleTasaNegociable.ToList<clsWCFDetalleTasaNegociable>();
            }

            return lstDetalleTasaNegociable;
        }

        public IList<clsWCFTasaCreditoNegociable> TasaCreditoNegociable(string cToken, int idTasa)
        {
            IList<clsWCFTasaCreditoNegociable> lstTasaNegociable = null;
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                DataTable dtTasaNegociable = new clsCNTasaCredito(true).TasaCreditoNegociable(idTasa);
                lstTasaNegociable = dtTasaNegociable.ToList<clsWCFTasaCreditoNegociable>();
            }

            return lstTasaNegociable;
        }

        public clsWCFAprobacionTasaNegociable AprobarTasaNegociable(string cToken, int idTasaNegociada, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual, string cJustificacionAprobacion, int idSolAproba, int idNivelAprRanOpe)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            if (usuario.validaToken(cToken))
            {
                if (idSolAproba == 0)
                {
                    IList<clsWCFAprobacionTasaNegociable> lstAprobacion = null;
                    Decimal nTEM = Convert.ToDecimal(clsMathFinanciera.TEM(Convert.ToDouble(nTasaInteresMensual)).ToString("n4"));
                    DataTable dtAprobacion = new clsCNSolicitud(true).RegistroAbprobacionTasaNegociable(idTasaNegociada, datosToken.idUsuario, nTasaInteres, nTasaMoratoria, nTEM, cJustificacionAprobacion);
                    lstAprobacion = dtAprobacion.ToList<clsWCFAprobacionTasaNegociable>();
                    if (lstAprobacion.Count == 0)
                    {
                        clsWCFAprobacionTasaNegociable error = new clsWCFAprobacionTasaNegociable();
                        error.idError = 1;
                        error.cMensaje = "Error Desconocido.";
                        return error;
                    }
                    return lstAprobacion[0];
                }
                else
                {
                    Decimal nTEM = Convert.ToDecimal(clsMathFinanciera.TEM(Convert.ToDouble(nTasaInteresMensual)).ToString("n4"));
                    DataTable RegistroSolicitud = new clsCNSolicitud(true).CNRegistroPreAprobacionTasaNegociable(idTasaNegociada, datosToken.idUsuario, nTasaInteres, nTasaMoratoria, nTEM);
                    if (RegistroSolicitud.Rows.Count == 0)
                    {
                        clsWCFAprobacionTasaNegociable error = new clsWCFAprobacionTasaNegociable();
                        error.idError = 1;
                        error.cMensaje = "Error en el registro de Pre-Aprobación de Tasa";
                        return error;
                    }
                    return RegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, datosToken.idUsuario, 2, cJustificacionAprobacion, datosToken.dFechaSistema, datosToken.idPerfil);
                }
            }
            return null;
        }

        public clsWCFAprobacionTasaNegociable DenegarTasaNegociable(string cToken, int idTasaNegociada, string cJustificacionAprobacion, int idSolAproba, int idNivelAprRanOpe)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);

            if (usuario.validaToken(cToken))
            {
                if (idSolAproba == 0)
                {
                    IList<clsWCFAprobacionTasaNegociable> lstDenegacion = null;
                    DataTable dtDenegacion = new clsCNSolicitud(true).DenegarAprobacionTasaNegociable(idTasaNegociada, datosToken.idUsuario);
                    lstDenegacion = dtDenegacion.ToList<clsWCFAprobacionTasaNegociable>();
                    clsWCFAprobacionTasaNegociable respuesta = new clsWCFAprobacionTasaNegociable();
                    if (lstDenegacion.Count == 0)
                    {
                        respuesta.idError = 1;
                        respuesta.cMensaje = "Error Desconocido.";
                        return respuesta;
                    }
                    respuesta.idError = 0;
                    respuesta.cMensaje = "Se Denego la Solicitud de la Tasa Negociada.";
                    return respuesta;
                }
                else
                {
                    return RegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, datosToken.idUsuario, 4, cJustificacionAprobacion, datosToken.dFechaSistema, datosToken.idPerfil);
                }
            }

            return null;
        }

        public clsWCFAprobacionTasaNegociable AnularTasaNegociable(string cToken, int idTasaNegociable, int idEstado, int idSolAproba)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFAprobacionTasaNegociable respuesta = new clsWCFAprobacionTasaNegociable();
            if (usuario.validaToken(cToken))
            {
                DataTable Resultado = new clsCNSolicitud(true).AnularSolicitudTasaNegociable(idTasaNegociable, idEstado, datosToken.idUsuario, idSolAproba);
                if (Resultado.Rows.Count > 0)
                {
                    respuesta.idError = 0;
                    respuesta.cMensaje = Resultado.Rows[0]["cMensaje"].ToString();
                }
                else
                {
                    respuesta.idError = 1;
                    respuesta.cMensaje = "No se pudo anular la Solicitud";
                }
                return respuesta;
            }
            respuesta.idError = 1;
            respuesta.cMensaje = "No hay sesión activa";
            return respuesta;
        }

        private clsWCFAprobacionTasaNegociable RegAprobaSolicitud(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado, string cOpinion, DateTime dFecSis, int idPerfil)
        {
            clsWCFAprobacionTasaNegociable respuesta = new clsWCFAprobacionTasaNegociable();
            clsCreditoProp objCreditoProp = new clsCreditoProp();
            objCreditoProp.idOrigenCredProp = 4;
            objCreditoProp.idSolAproba = idSolAproba;
            objCreditoProp.idNivelAprRanOpe = idNivelAprRanOpe;
            string xmlPropSolCred = objCreditoProp.GetXml();
            DataTable dtAprobaSolicitud = new clsADAprobacion().ADRegAprobaSolicitudWcf(idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dFecSis, idPerfil, xmlPropSolCred);
            int idRpta = Convert.ToInt32(dtAprobaSolicitud.Rows[0]["idRpta"]);
            respuesta.idError = idRpta==0?1:0;
            respuesta.cMensaje = dtAprobaSolicitud.Rows[0]["cMensage"].ToString();
            return respuesta;
        }

        public clsWCFDatosTasaNegociable ObtenerTasaNegociable(string cToken, int idSolicitud)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFDatosTasaNegociable response = new clsWCFDatosTasaNegociable();
            if (usuario.validaToken(cToken))
            {
                var cnsolicitud = new clsCNSolicitud(true);
                DataTable Sol = cnsolicitud.ExtraeDatosSolicitudTNegociable(idSolicitud, datosToken.idUsuario);
                if (Sol.Rows.Count > 0)
                {
                    DateTime dtFechaDesembolso = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? datosToken.dFechaSistema : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                    int nCuotas = (Sol.Rows[0]["nCuotas"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                    int nDiasGracia = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                    int nTipoPeriodo = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                    int nPlazo = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                    int idProducto = Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                    int idMoneda = Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                    int nOperacion = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                    int nTotalDias = cnsolicitud.ObtieneTotalDias(dtFechaDesembolso, nCuotas, nDiasGracia, nTipoPeriodo, nPlazo);
                    int idClasificacionInterna = Convert.ToInt32(Sol.Rows[0]["idClasificacionInterna"]);
                    decimal nMonto = Convert.ToDecimal((Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? "0.00" : Sol.Rows[0]["nCapitalSolicitado"].ToString());
                    clsCNTasaCredito TasaCredito = new clsCNTasaCredito(true);
                    DataTable dtTasa = TasaCredito.ListaTasaCreditoNegociable(nTotalDias, idProducto, nMonto, idMoneda, datosToken.idAgencia, nOperacion, idClasificacionInterna);

                    if (dtTasa.Rows.Count > 0 && dtTasa.Rows[0]["nTasaCompensatoria"].ToString() != "")
                    {
                        response = dtTasa.SoftToList<clsWCFDatosTasaNegociable>()[0];
                        DataTable dtListaSeguimiento = new clsCNTasaCredito(true).SeguimientoSolicitudTasasNegociables(idSolicitud);
                        response.lListaTasas = dtTasa.SoftToList<clsWCFSeleccionTasaNegociable>();
                        response.lSeguimiento = dtListaSeguimiento.SoftToList<clsWCFSeguimientoTasasNegociables>();
                        response.idError = 0;
                        response.cMensaje = "";
                    }
                    else
                    {
                        response.idError = 1;
                        response.cMensaje = "No tiene tasa negociable";
                    }
                }
                else
                {
                    response.idError = 1;
                    response.cMensaje = "No tiene tasa negociable";
                }
            }
            else
            {
                response.idError = 2;
                response.cMensaje = "No hay sesión";
            }

            return response;
        }

        public clsWCFDatosTasaNegociable RegistroSolicitudTasaNegociable(string cToken, clsWCFDatosTasaNegociable oDetalle)
        {
            clsDatosToken datosToken = new clsDatosToken();
            datosToken = usuario.obtenerDatosToken(cToken);
            clsWCFDatosTasaNegociable response = new clsWCFDatosTasaNegociable();
            if (usuario.validaToken(cToken))
            {
                var cnsolicitud = new clsCNSolicitud(true);
                DataTable Sol = cnsolicitud.ExtraeDatosSolicitudTNegociable(oDetalle.idSolicitud, datosToken.idUsuario);
                if (Sol.Rows.Count > 0)
                {
                    DataTable dtResultado = cnsolicitud.RegistraSolicitudTasaNegociable(
                                                    Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()),
                                                    oDetalle.idTasa,
                                                    oDetalle.nTasaNegociada,
                                                    oDetalle.nTasaMoratoria,
                                                    oDetalle.cJustificacion,
                                                    datosToken.idUsuario,
                                                    Convert.ToInt32(Sol.Rows[0]["idTasa"].ToString()),
                                                    Convert.ToDecimal(Sol.Rows[0]["nTasaCompensatoria"].ToString()),
                                                    datosToken.idAgencia,
                                                    datosToken.dFechaSistema.Date,

                                                    Convert.ToInt32(Sol.Rows[0]["nTipCre"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nSubTip"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nProdu"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nSubPro"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["IdMoneda"].ToString()),
                                                    Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nCuotas"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"].ToString()),
                                                    Convert.ToInt32(Sol.Rows[0]["ndiasgracia"].ToString()),
                                                    Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"].ToString())
                                                    );
                    if (dtResultado.Rows.Count > 0)
                    {
                        response.idError = Convert.ToInt32(dtResultado.Rows[0]["idError"].ToString());
                        response.cMensaje = dtResultado.Rows[0]["cMensaje"].ToString();
                        if (response.idError == 0)
                        {
                            DataTable dtListaSeguimiento = new clsCNTasaCredito(true).SeguimientoSolicitudTasasNegociables(oDetalle.idSolicitud);
                            response.lSeguimiento = dtListaSeguimiento.SoftToList<clsWCFSeguimientoTasasNegociables>();
                        }
                    }
                    else
                    {
                        response.idError = 1;
                        response.cMensaje = "No se Pudo hacer el registro de la Solicitud";
                    }
                }
                else
                {
                    response.idError = 1;
                    response.cMensaje = "No tiene tasa negociable";
                }
            }
            else
            {
                response.idError = 2;
                response.cMensaje = "No hay sesión";
            }

            return response;
        }
    }
}
