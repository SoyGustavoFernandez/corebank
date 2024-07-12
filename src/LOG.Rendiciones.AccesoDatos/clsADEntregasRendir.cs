using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.Rendiciones.AccesoDatos
{
    public class clsADEntregasRendir
    {
        #region propiedades privadas
        private IntConexion objEjeSp;
        #endregion

        #region constructores
        public clsADEntregasRendir()
        {
            this.objEjeSp = new clsWCFEjeSP();
        }
        #endregion

        #region métodos públicos       
        public DataTable obtenerResumenEntregas(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerMisEntregasPorEstado_SP", parametros);
        }

        public DataTable cambiarEstadoEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_CambiarEstadoEntrega_SP", parametros);
        }

        #region etapa - registro
        public DataTable obtenerEntregasRendir(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerEntregas_SP", parametros);
        }

        public DataTable registrarEntregaRendir(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarEntrega_SP", parametros);
        }

        public DataTable solicitarEntregaRendir(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_SolicitarEntrega_SP", parametros);
        }

        public DataTable obtenerArchivoEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerArchivoSustentoEntrega_SP", parametros);
        }

        public DataTable obtenerDatosArchivosEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerDatosArchivoSustentoEntrega_SP", parametros);
        }

        public DataTable registrarArchivoEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarArchivoSustentoEntrega_SP", parametros);
        }
        #endregion

        #region etapa - aprobación de entrega
        public DataTable obtenerEntregaAprobaciones(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RetornaAprobacionesEntrega_SP", parametros);
        }
        #endregion

        #region etapa - desembolso
        public DataTable obtenerDesembolsoEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerDesembolsoEntrega_SP", parametros);
        }        
        #endregion

        #region etapa - rendición
        public DataTable obtenerRendicionEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerRendicionEntrega_SP", parametros);
        }

        public DataTable obtenerComprobantesPago(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerComprobantesRendicion_SP", parametros);
        }

        public DataTable obtenerDetallesComprobante(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RetornaDetalleComprobanteTmpRendicion_SP", parametros);
        }

        public DataTable registrarComprobantePago(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarComprobanteRendicion_SP", parametros);
        }

        public DataTable enviarRendicionEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarRendicion_SP", parametros);
        }

        public DataTable actualizarRendicionEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarRendicion_SP", parametros);
        }       

        public DataTable obtenerArchivoComprobante(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerArchivoComprobante_SP", parametros);
        }

        public DataTable registrarArchivoComprobante(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarArchivoComprobante_SP", parametros);
        }

        public DataTable registrarRecibo(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistrarReciboRendicion_SP", parametros);
        }

        public DataTable obtenerRecibos(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerRecibosRendicion_SP", parametros);
        }

        public DataTable registrarProveedor(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RegistroProveedorCliente_SP", parametros);
        }
        #endregion                

        #region etapa - aprobación de rendición
        public DataTable obtenerRendicionAprobaciones(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_RetornaAprobacionesRendicion_SP", parametros);
        }
        #endregion

        #region etapa - rendido
        public DataTable obtenerRendidoEntrega(params object[] parametros)
        {
            return this.objEjeSp.EjecSP("LOG_ObtenerEntregaRendido_SP", parametros);
        }
        #endregion
        #endregion
    }
}
