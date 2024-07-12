#region 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
using EntityLayer;
#endregion

namespace CRE.AccesoDatos
{
    public class clsADCreditoCargaSeguro
    {
        #region Variables Globales
        private clsGENEjeSP objEjeSP { get; set; }
        #endregion

        #region Constructores
        public clsADCreditoCargaSeguro()
        {
            objEjeSP = new clsGENEjeSP();
        }
        #endregion

        #region Metodos

        public DataTable ADObtenerSolicitudSeguroTipo(int idSolicitud)
        {
            return objEjeSP.EjecSP("CRE_ObtenerSolicitudSeguroTipo_SP", idSolicitud);
        }
        public DataSet ADObtenerSolicitudCargaSeguro(int idSolicitud)
        {
            return objEjeSP.DSEjecSP("CRE_ObtenerSolicitudSeguroCompleto_SP", idSolicitud);
        }
        public DataTable ADRegistrarSolicitudCreditoSeguro(int idSolicitud, string xmlSolicitudCreditoSeguro, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("CRE_RegistroSolicitudCreditoSeguro_SP", idSolicitud, xmlSolicitudCreditoSeguro, idUsuario, dFechaSistema);
        }
        public DataTable ADRegistroListaSeguroCredito(int idSolicitud, string xmlCreditoSeguro, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("CRE_RegistroListaSeguroCredito_SP", idSolicitud, xmlCreditoSeguro, idUsuario, dFechaSistema);
        }
        public DataTable ADObtenerListaCreditoSeguro(int idSolicitud)
        {
            return objEjeSP.EjecSP("CRE_ObtenerListaCreditoSeguro_SP", idSolicitud);
        }
        public DataTable ADObtenerDatosUsuarioZona(int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerDatosUsuarioZona_SP", idUsuario);
        }

        public DataTable ADObtenerListaUsuarioSeguro(int idZona, int idAgencia, DateTime dFechaDesde, DateTime dFechaHasta, int idTipoSeguro)
        {
            return objEjeSP.EjecSP("CRE_ObtenerListaUsuarioSeguro_SP", idZona, idAgencia, dFechaDesde, dFechaHasta, idTipoSeguro);
        }

        public DataTable ADObtenerDatosRPTSeguimientoSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPSeguimientoSeguroMultiriesgo_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADObtenerDatosRPTSolicitudes(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idEstab,string cEstados)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRPTSolicitudes_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idEstab, cEstados);
        }
        public DataTable ADObtenerDatosRPTSolicitudesTasa(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idEstab, string cEstados, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRPTSolicitudesPRE_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idEstab, cEstados, idUsuario);
        }
        public DataTable ADListarEstadosSolicitud(string cEstados)
        {
            return objEjeSP.EjecSP("CRE_ObtenerListaEstadosSolicitud_SP",cEstados);
        }
        public DataTable ADListarEstadosSolicitudTasa()
        {
            return objEjeSP.EjecSP("Gen_ListarEstadoSolicitud_sp");
        }
        public DataTable ADObtenerDatosRPTSeguimientoSeguroVida(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPSeguimientoSeguroVida_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADObtenerRecibosVinculadoCuenta(int idCuenta)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRecibosVinculadoCuenta_SP", idCuenta);
        }
        public DataTable ADObtenerDatosRPTResumenSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPResumenSeguroMultiriesgo_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADObtenerDatosRPTResumenSeguroVida(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPResumenSeguroVida_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADVerificarProductoTipoSeguro(int idProducto)
        {
            return objEjeSP.EjecSP("CRE_VerificarProductoTipoSeguro_SP", idProducto);
        }
        
        public DataTable ADVerificarConfiguracionSeguro(int idProducto, int idPerfil, int idAgencia)
        {
            return objEjeSP.EjecSP("ADM_VerificaConfiguracionSeguroOptativo_SP", idProducto, idPerfil, idAgencia);
        }

        public DataTable ADVerificarConfiguracionSeguroActivos(int idSolicitud, int idProducto, int idPerfil, int idAgencia)
        {
            return objEjeSP.EjecSP("ADM_VerificarSeguroRegistradoAct_SP", idSolicitud, idProducto, idPerfil, idAgencia);
        }

        public DataTable ADObtenerDatosRPTSeguimientoSeguroAgricola(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPSeguimientoSeguroAgricola_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADObtenerDatosRPTResumenSeguroAgricola(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario)
        {
            return objEjeSP.EjecSP("CRE_ObtenerRTPResumenSeguroAgricola_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario);
        }

        public DataTable ADValidarActaulizarDesgravamenEspecial(int idSolicitud, decimal nMontoAprobado)
        {
            return objEjeSP.EjecSP("CRE_ValidarActualizarSeguroDesgravamenEspecial_SP", idSolicitud, nMontoAprobado);
        }

        public DataTable ADValidarSeguros(int idCli, string cTipoSeguroXml, int nMesesCobertura, int idOperacion)
        {
            return objEjeSP.EjecSP("CRE_ValidaVentaSeguro_SP", idCli, cTipoSeguroXml, nMesesCobertura, idOperacion);
        }

        public DataTable ADValidarSeguroOncologico(int idCli, int nMesesCobertura, int idSolicitud)
        {
            return objEjeSP.EjecSP("CRE_ValidaVentaSeguroOncologico_SP", idCli, nMesesCobertura, idSolicitud);
        }

        public List<clsDesafiliarSeguroMultiriesgo> ADConsultaDesafiliacionSeguroMultiriesgo(int idCli)
        {
            return objEjeSP.LOEjecutar<clsDesafiliarSeguroMultiriesgo>("CRE_ConsultaDesafiliacionSeguroMultiriesgo_SP", idCli);
        }

        public clsDBResp ADDesafiliarSeguroMultiriesgo(int idSeguroMultiriesgo, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.OEjecutar<clsDBResp>("CRE_DesafiliarSeguroMultiriesgo_SP", idSeguroMultiriesgo, idUsuario, dFechaSistema);
        }

        public DataTable ADConsultaSeguroMultiriesgo(DateTime dFechaDesde, DateTime dFechaHasta, int idZona, int idAgencia, int idUsuario, int idEstadoSeguroMultiriesgo)
        {
            return objEjeSP.EjecSP("CRE_RptConsultaSeguroMultiriesgo_SP", dFechaDesde, dFechaHasta, idZona, idAgencia, idUsuario, idEstadoSeguroMultiriesgo);
        }

        public DataTable ADListarEstadoSeguroMultiriesgo()
        {
            return objEjeSP.EjecSP("CRE_ListarEstadoSeguroMultiriesgo_SP");
        }
        public DataTable ADObtenerListaSegurosCliente(int idCliente)
        {
            return objEjeSP.EjecSP("CRE_ObtenerListaSegurosCliente_SP", idCliente);
        }

        public DateTime? ADObtenerFechaCoberturaSeguroMultiriesgo(int idCuenta, int idTipoPeriodo)
        {
            var resp = objEjeSP.EjecSP("CRE_ObtenerFechaCoberturaSeguroMultiriesgo_SP", idCuenta, idTipoPeriodo);
            DateTime? date = null;

            if (resp.Rows.Count > 0 && resp.Rows[0]["dFechaFinCobertura"] != DBNull.Value)
                date = Convert.ToDateTime(resp.Rows[0]["dFechaFinCobertura"].ToString());
               
            return date;
        }

        public clsSolicitudCreditoSeguro ADObtenerSolicitudCreditoSeguroPreliminar(int idSolicitud, int idTipoSeguro, DateTime dFechaSistema, int idUsuario)
        {
            var result = objEjeSP.LOEjecutar<clsSolicitudCreditoSeguro>("CRE_ObtenerSolicitudCreditoSeguroPreliminar_SP", idSolicitud, idTipoSeguro, dFechaSistema, idUsuario);
            return result.FirstOrDefault();
        }

        public List<clsDesafiliarPaqueteSeguro> ADConsultaDesafiliacionPaqueteSeguro(int idCli)
        {
            return objEjeSP.LOEjecutar<clsDesafiliarPaqueteSeguro>("CRE_ConsultaDesafiliacionPaqueteSeguro_SP", idCli);
        }

        public clsDBResp ADDesafiliarSeguroOpcional(int idSeguroOpcional, int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.OEjecutar<clsDBResp>("CRE_DesafiliarSeguroOpcional_SP", idSeguroOpcional, idUsuario, dFechaSistema);
        }

        public DataTable ADConsultaPaqueteSeguroAlta(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSP.EjecSP("CRE_RptConsultaPaqueteSeguroAlta_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADConsultaPaqueteSeguroBaja(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSP.EjecSP("CRE_RptConsultaPaqueteSeguroBaja_SP", dFechaDesde, dFechaHasta);
        }

        public DataTable ADConsultaPaqueteSeguroCobro(DateTime dFechaDesde, DateTime dFechaHasta)
        {
            return objEjeSP.EjecSP("CRE_RptConsultaPaqueteSeguroCobro_SP", dFechaDesde, dFechaHasta);
        }

        public bool ADOValidaNuevoSeguroMultiriesgo(int idSolicitud)
        {
            var resp = objEjeSP.EjecSP("CRE_ValidaNuevoSegMultirriesgo_SP", idSolicitud);
            bool lAplica = false;
            if (resp.Rows.Count > 0)
            {
                lAplica = Convert.ToBoolean(resp.Rows[0]["lAplica"].ToString());
            }
            return lAplica;
        }

        public DataTable ADObtenerPromotorInicialSeguro(int idSolicitud, int idTipoSeguro)
        {
            return objEjeSP.EjecSP("CRE_ObtenerPromotorInicialSeguro_SP", idSolicitud, idTipoSeguro);
        }


        public DataTable ADActualizarEstadoSolicitudCreditoSeguro(int idSolicitud,int idUsuario, DateTime dFechaSistema)
        {
            return objEjeSP.EjecSP("CRE_ActualizaEstadoSolicitudCreditoSeguro_SP", idSolicitud, idUsuario, dFechaSistema);
        }

        public DataTable CNRegistrarSustentoDesmarcado(string lstSegurosDesmarcadosXML)
        {
            return objEjeSP.EjecSP("CRE_InsUpdSeguroDesmarcado_SP", lstSegurosDesmarcadosXML);
        }

        public clsSolicitudCreditoSeguro CNObtenerSeguroIndividual(int idSolicitudCreditoSeguro)
        {
            return objEjeSP.OEjecutar<clsSolicitudCreditoSeguro>("CRE_ObtenerSeguroDeSolicitud_SP", idSolicitudCreditoSeguro);
        }

        public clsDBResp CNEnvioCorreosSeguroDesmarcados(string cDestinatario, string cAsunto, string cMensaje)
        {
            return objEjeSP.OEjecutar<clsDBResp>("CRE_EnvioCorreosSeguroDesmarcados_SP", cDestinatario, cAsunto, cMensaje);
        }

        public string ADObtenerCorreoUsuarioSolicitud(int idSolicitud)
        {
            var obj = objEjeSP.OEjecutar<clsDBResp>("CRE_ObtenerCorreoUsuarioSolicitud_SP", idSolicitud);
            return obj.cMsje;
        }
        
         public bool ADOValidaNuevoPaqueteSeguro(int idSolicitud)
        {
            var resp = objEjeSP.EjecSP("CRE_ValidaNuevoPaqSeguro_SP", idSolicitud);
            bool lAplica = false;
            if (resp.Rows.Count > 0)
            {
                lAplica = Convert.ToBoolean(resp.Rows[0]["lAplica"].ToString());
            }
            return lAplica;
        }
        #endregion
    }
}
