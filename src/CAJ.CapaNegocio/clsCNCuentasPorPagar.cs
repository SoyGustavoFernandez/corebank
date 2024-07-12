using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;

namespace CAJ.CapaNegocio
{
    public class clsCNCuentasPorPagar
    {
        clsADCuentasPorPagar clsCuentasPagar = new clsADCuentasPorPagar();

        public DataTable listarSolicitudesCuentasPagarAprobados(int idUsuario)
        {
            return clsCuentasPagar.listarSolicitudesCuentasPagarAprobados(idUsuario);
        }

        public DataTable listarRendicionesAprobadas(int idUsuario)
        {
            return clsCuentasPagar.listarRendicionesAprobadas(idUsuario);
        }

        public DataTable registrarConfirmacionDesembolso(int idEntrega, int nRecibo, decimal nMonto, int idUsuario)
        {
            return clsCuentasPagar.registrarConfirmacionDesembolso(idEntrega, nRecibo, nMonto, idUsuario);
        }

        #region Rendicion
        public DataTable obtenerComprobantesRendicion(int idEntrega)
        {
            return clsCuentasPagar.obtenerComprobantesRendicion(idEntrega);
        }

        public DataTable obtenerRecibosRendicion(int idEntrega)
        {
            return clsCuentasPagar.obtenerRecibosRendicion(idEntrega);
        }

        public DataTable cambiarEstadoSolicitudRendicion(int idEntrega, int idUsuario)
        {
            return clsCuentasPagar.cambiarEstadoSolicitudRendicion(idEntrega, idUsuario);
        }

        public DataTable obtenerComprobanteTemporal(int idComprobantePagoTmp)
        {
            return clsCuentasPagar.obtenerComprobanteTemporal(idComprobantePagoTmp);
        }

        public DataTable obtenerDetalleComprobanteTemporal(int idComprobantePagoTmp)
        {
            return clsCuentasPagar.obtenerDetalleComprobanteTemporal(idComprobantePagoTmp);
        }

        public DataTable copiarComprobanteRendicion(string xmlComprPago, string xmlDetComprPago, int idEntrega, int idComprobantePagoTmp)
        {
            return clsCuentasPagar.copiarComprobanteRendicion(xmlComprPago, xmlDetComprPago, idEntrega, idComprobantePagoTmp);
        }

        public DataTable validarFinalizacionRendicion(int idEntrega)
        {
            return clsCuentasPagar.validarFinalizacionRendicion(idEntrega);
        }

        public DataTable vincularReciboRendicion(int idEntrega, int idConcepto, int idRecibo)
        {
            return clsCuentasPagar.vincularReciboRendicion(idEntrega, idConcepto, idRecibo);
        }

        public DataTable obtenerImagenComprobante(int idComprobantePago)
        {
            return clsCuentasPagar.obtenerImagenComprobante(idComprobantePago);
        }

        public DataTable obtenerUsuarioInicioRendicion(int idEntrega)
        {
            return clsCuentasPagar.obtenerUsuarioInicioRendicion(idEntrega);
        }
        #endregion

        #region Reportes
        public DataTable listarRendicionesVencidas()
        {
            return clsCuentasPagar.listarRendicionesVencidas();
        }

        public DataTable listarRendicionesPendientes(int idMoneda)
        {
            return clsCuentasPagar.listarRendicionesPendientes(idMoneda);
        }
        #endregion

        #region Configuración Aprobadores
        public DataTable listarConfiguracionAprobadores(int idTipo, int idEtapa, int idSolicitante, int idAprobador)
        {
            return clsCuentasPagar.listarConfiguracionAprobadores(idTipo, idEtapa, idSolicitante, idAprobador);
        }

        public DataTable quitarAprobadorEntrega(int idEtapa, int idConfiguracion, int idUsuario)
        {
            return clsCuentasPagar.quitarAprobadorEntrega(idEtapa, idConfiguracion, idUsuario);
        }

        public DataTable agregarAprobadorEntrega(int idTipo, int idEtapa, int idPerfilSolicita, int idPerfilAprueba, int idUsuario)
        {
            return clsCuentasPagar.agregarAprobadorEntrega(idTipo, idEtapa, idPerfilSolicita, idPerfilAprueba, idUsuario);
        }

        public DataTable listarPerfilesAlcanceEntrega(int idPerfil)
        {
            return clsCuentasPagar.listarPerfilesAlcanceEntrega(idPerfil);
        }

        public DataTable agregarPerfilAlcanceEntrega(int idAlcance, int idPerfil, int idUsuario)
        {
            return clsCuentasPagar.agregarPerfilAlcanceEntrega(idAlcance, idPerfil, idUsuario);
        }

        public DataTable quitarPerfilEntregaEntrega(int idAlcance, int idUsuario)
        {
            return clsCuentasPagar.quitarPerfilEntregaEntrega(idAlcance, idUsuario);
        }
        #endregion
        public DataTable listarTipoEntrega()
        {
            return clsCuentasPagar.listarTipoEntrega();
        }
    }
}
