using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net;
using System.Web.Script.Serialization;
using GEN.Funciones;

namespace CAJ.AccesoDatos
{
    public class clsADCuentasPorPagar
    {
        #region Variables
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        #endregion

        /*Solicitudes de Viáticos y Entregas a Rendir Aprovados*/
        public DataTable listarSolicitudesCuentasPagarAprobados(int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_ObtenerEntregasRendirAprobadas_SP", idUsuario);
        }

        /*Rendiciones Aprobados*/
        public DataTable listarRendicionesAprobadas(int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_ObtenerRendicionesAprobadas_SP", idUsuario);
        }

        public DataTable registrarConfirmacionDesembolso(int idEntrega, int nRecibo, decimal nMonto, int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_RegistrarDesembolsoEntrega_SP", idEntrega, nRecibo, nMonto, idUsuario);
        }

        #region Rendicion
        public DataTable obtenerComprobantesRendicion(int idEntrega)
        {
            return objEjeSp.EjecSP("LOG_ObtenerComprobantesRendicion_SP", idEntrega, 0);
        }

        public DataTable obtenerRecibosRendicion(int idEntrega)
        {
            return objEjeSp.EjecSP("LOG_ObtenerRecibosAgrupadosRendicion_SP", idEntrega);
        }

        public DataTable cambiarEstadoSolicitudRendicion(int idEntrega, int idUsuario)
        {
            /*
             * idEtapa: 6 => Rendido
             * idEstado: 11 => Entrega a Rendir Finalizado
            */
            return objEjeSp.EjecSP("LOG_CambiarEstadoEntrega_SP", idEntrega, 6, 11, idUsuario, "Entrega Finalizado");
        }

        public DataTable obtenerComprobanteTemporal(int idComprobantePagoTmp)
        {
            return objEjeSp.EjecSP("LOG_RetornaComprobanteTmpRendicion_SP", idComprobantePagoTmp);
        }

        public DataTable obtenerDetalleComprobanteTemporal(int idComprobantePagoTmp)
        {
            return objEjeSp.EjecSP("LOG_RetornaDetalleComprobanteTmpRendicion_SP", 0, idComprobantePagoTmp);
        }

        public DataTable copiarComprobanteRendicion(string xmlComprPago, string xmlDetComprPago, int idEntrega, int idComprobantePagoTmp)
        {
            return objEjeSp.EjecSP("LOG_CopiarComprobanteRendicion_SP", xmlComprPago, xmlDetComprPago, idEntrega, idComprobantePagoTmp);
        }

        public DataTable validarFinalizacionRendicion(int idEntrega)
        {
            return objEjeSp.EjecSP("LOG_ValidarFinalizacionRendicioEntrega_SP", idEntrega, 0);
        }

        public DataTable vincularReciboRendicion(int idEntrega, int idConcepto, int idRecibo)
        {
            return objEjeSp.EjecSP("LOG_VincularReciboRendicion_SP", idEntrega, idConcepto, idRecibo);
        }

        public DataTable obtenerImagenComprobante(int idComprobantePago)
        {
            return objEjeSp.EjecSP("CAJ_ObtenerImagenComprobantePago_SP", idComprobantePago);
        }

        public DataTable obtenerUsuarioInicioRendicion(int idEntrega)
        {
            return objEjeSp.EjecSP("LOG_ObtenerUsuarioInicioRendicion_SP", idEntrega);
        }
        #endregion

        #region Reportes
        public DataTable listarRendicionesVencidas()
        {
            return objEjeSp.EjecSP("LOG_ObtenerRendicionesVencidas_SP", "detallado", 0);
        }

        public DataTable listarRendicionesPendientes( int idMoneda)
        {
            return objEjeSp.EjecSP("LOG_RptObtenerRendicionesPendientes_SP", idMoneda);
        }
        #endregion

        #region Configuración Aprobadores
        public DataTable listarConfiguracionAprobadores(int idTipo, int idEtapa, int idSolicitante, int idAprobador)
        {
            return objEjeSp.EjecSP("LOG_ListarConfiguracionAprobadoresEntrega_SP", idTipo, idEtapa, idSolicitante, idAprobador);
        }

        public DataTable quitarAprobadorEntrega(int idEtapa, int idConfiguracion, int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_QuitarAprobadorEntrega_SP", idEtapa, idConfiguracion, idUsuario);
        }

        public DataTable agregarAprobadorEntrega(int idTipo, int idEtapa, int idPerfilSolicita, int idPerfilAprueba, int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_AgregarAprobadorEntrega_SP", idTipo, idEtapa, idPerfilSolicita, idPerfilAprueba, idUsuario);
        }

        public DataTable listarPerfilesAlcanceEntrega(int idPerfil)
        {
            return objEjeSp.EjecSP("LOG_ListarPerfilAlcanceEntrega_SP", idPerfil);
        }

        public DataTable agregarPerfilAlcanceEntrega(int nAlcance, int idPerfil, int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_AgregarPerfilAlcanceEntrega_SP", nAlcance, idPerfil, idUsuario);
        }

        public DataTable quitarPerfilEntregaEntrega(int idAlcance, int idUsuario)
        {
            return objEjeSp.EjecSP("LOG_QuitarPerfilAlcanceEntrega_SP", idAlcance, idUsuario);
        }
        #endregion
        public DataTable listarTipoEntrega()
        {
            return objEjeSp.EjecSP("LOG_ListarTipoEntrega_SP");
        }
    }
}
