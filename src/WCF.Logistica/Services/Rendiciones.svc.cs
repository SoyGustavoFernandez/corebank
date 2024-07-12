using GEN.WCFLogistica.CapaNegocio;
using LOG.Rendiciones.CapaNegocio;
using WCFLogistica.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Logistica.Services
{
    public class Rendiciones : IRendiciones
    {
        private clsCNEntregasRendir cnEntregasRendir;
        private clsCNFuenteDatos cnFuenteDatos;
        private clsCNAprobaciones cnAprobaciones;
        private clsCNViaticos cnViaticos;
        private clsCNRendicionesVencidas cnRendicionesVencidas;

        public Rendiciones()
        {
            this.cnEntregasRendir = new clsCNEntregasRendir();
            this.cnFuenteDatos = new clsCNFuenteDatos();
            this.cnAprobaciones = new clsCNAprobaciones();
            this.cnViaticos = new clsCNViaticos();
            this.cnRendicionesVencidas = new clsCNRendicionesVencidas();
        }

        #region métodos públicos
        public IList<clsProveedor> BuscarProveedor(int idCriterio, string cCriterio)
        {
            return this.cnFuenteDatos.buscarProveedor(idCriterio, cCriterio);
        }

        #region módulo - entregas a rendir
        public clsWCFRespuesta CambiarEstadoEntrega(int idEntrega, int idEtapa, int idEstado, int idUsuario, string cComentario)
        {
            return this.cnEntregasRendir.cambiarEstadoEntrega(idEntrega, idEtapa, idEstado, idUsuario, cComentario);
        }

        public IList<clsEntregaRendir> ObtenerResumenEntregas(int idUsuario, int idTipoEntrega)
        {
            return this.cnEntregasRendir.obtenerResumenEntregas(idUsuario, idTipoEntrega);            
        }

        #region etapa - registro
        public IList<clsEntregaRendir> ObtenerEntregasRendir(int idUsuario, int idTipo, int idEstado, int idEntrega)
        {
            return this.cnEntregasRendir.obtenerEntregasRendir(idUsuario, idTipo, idEstado, idEntrega);
        }

        public clsEntregaRendir RegistrarEntregaRendir(clsEntregaRendir objEntregaRendir)
        {
            return this.cnEntregasRendir.registrarEntregaRendir(objEntregaRendir);
        }

        public clsArchivoEntrega ObtenerArchivoEntrega(int idArchivo)
        {
            return this.cnEntregasRendir.obtenerArchivoEntrega(idArchivo);
        }

        public IList<clsArchivoEntrega> ObtenerDatosArchivosEntrega(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerDatosArchivosEntrega(idEntrega);
        }

        public clsWCFRespuesta RegistrarArchivoEntrega(clsArchivoEntrega objArchivoEntrega)
        {
            return this.cnEntregasRendir.registrarArchivoEntrega(objArchivoEntrega);
        }

        public clsWCFRespuesta RegistrarArchivosEntrega(List<clsArchivoEntrega> lstArchivoEntrega)
        {
            return this.cnEntregasRendir.registrarArchivosEntrega(lstArchivoEntrega);
        }

        public clsWCFRespuesta SolicitarEntregaRendir(int idEntrega, int idUsuario)
        {
            return this.cnEntregasRendir.solicitarEntregaRendir(idEntrega, idUsuario);
        }
        #endregion

        public IList<clsAprobacionEntrega> ObtenerEntregaAprobaciones(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerEntregaAprobaciones(idEntrega);
        }                

        #region etapa - desembolso
        public clsDesembolsoEntrega ObtenerDesembolsoEntrega(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerDesembolsoEntrega(idEntrega);            
        }        
        #endregion

        #region etapa - rendición
        public clsRendicionEntrega ObtenerRendicionEntrega(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerRendicionEntrega(idEntrega);
        }

        public IList<clsComprobantePago> ObtenerComprobantesPago(int idEntrega, int idComprobantePago)
        {
            return this.cnEntregasRendir.obtenerComprobantesPago(idEntrega, idComprobantePago);
        }

        public IList<clsDetalleComprobante> ObtenerDetallesComprobante(int idEntrega, int idComprobantePago)
        {
            return this.cnEntregasRendir.obtenerDetallesComprobante(idEntrega, idComprobantePago);
        }

        public clsComprobantePago RegistrarComprobantePago(int idEntrega, clsComprobantePago objComprobantePago, List<clsDetalleComprobante> lstDetalleComprobante)
        {
            return this.cnEntregasRendir.registrarComprobantePago(idEntrega, objComprobantePago, lstDetalleComprobante);
        }

        public clsArchivoComprobante ObtenerArchivoComprobante(int idComprobantePago)
        {
            return this.cnEntregasRendir.obtenerArchivoComprobante(idComprobantePago);            
        }

        public  clsWCFRespuesta RegistrarArchivoComprobante(clsArchivoComprobante objArchivoComprobante)
        {
            return this.cnEntregasRendir.registrarArchivoComprobante(objArchivoComprobante);            
        }

        public clsRendicionEntrega EnviarRendicionEntrega(clsRendicionEntrega objRendicionEntrega)
        {
            return this.cnEntregasRendir.enviarRendicionEntrega(objRendicionEntrega);            
        }

        public clsRendicionEntrega ActualizarRendicionEntrega(clsRendicionEntrega objRendicionEntrega)
        {
            return this.cnEntregasRendir.actualizarRendicionEntrega(objRendicionEntrega);
        }

        public IList<clsRecibo> ObtenerRecibos(int idEntrega, int idReciboRendicion)
        {
            return this.cnEntregasRendir.obtenerRecibos(idEntrega, idReciboRendicion);
        }

        public clsWCFRespuesta RegistrarRecibo(clsRecibo objRecibo)
        {
            return this.cnEntregasRendir.registrarRecibo(objRecibo);
        }

        public clsProveedor RegistrarProveedor(clsProveedor objProveedor)
        {
            return this.cnEntregasRendir.registrarProveedor(objProveedor);
        }
        #endregion

        #region etapa - aprobación de rendición
        public IList<clsAprobacionRendicion> ObtenerRendicionAprobaciones(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerRendicionAprobaciones(idEntrega);            
        }
        #endregion

        #region etapa - rendido
        public clsRendidoEntrega ObtenerRendidoEntrega(int idEntrega)
        {
            return this.cnEntregasRendir.obtenerRendidoEntrega(idEntrega);            
        }
        #endregion
        #endregion

        #region módulo - viáticos
        public clsEntregaRendir RegistrarViatico(clsEntregaRendir objEntregaRendir, clsViatico objViatico, List<clsDetalleViatico> lstDetalleViatico)
        {
            return this.cnViaticos.registrarViatico(objEntregaRendir, objViatico, lstDetalleViatico);
        }

        public clsViatico ObtenerViatico(int idEntrega, int idViatico)
        {            
            return this.cnViaticos.obtenerViatico(idEntrega, idViatico);
        }

        public IList<clsDetalleViatico> ObtenerDetallesViatico(int idViatico, int idDetalleViatico)
        {
            return this.cnViaticos.obtenerDetallesViatico(idViatico, idDetalleViatico);
        }
        #endregion

        #region módulo - aprobaciones
        public IList<clsEntregaRendir> ObtenerAprobacionesEntrega(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID)
        {
            return this.cnAprobaciones.obtenerAprobacionesEntrega(idPerfil, idUsuario, idTipoEntrega, cNombre, cDocumentoID);
        }

        public clsWCFRespuesta RegistrarAprobacionEntrega(clsAprobacionEntrega objAprobacionEntrega)
        {
            return this.cnAprobaciones.registrarAprobacionEntrega(objAprobacionEntrega);
        }

        public IList<clsEntregaRendir> ObtenerAprobacionesRendicion(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID)
        {
            return this.cnAprobaciones.obtenerAprobacionesRendicion(idPerfil, idUsuario, idTipoEntrega, cNombre, cDocumentoID);            
        }

        public clsWCFRespuesta RegistrarAprobacionRendicion(clsAprobacionRendicion objAprobacionRendicion)
        {
            return this.cnAprobaciones.registrarAprobacionRendicion(objAprobacionRendicion);            
        }

        public IList<clsResumenAprobacion> ObtenerResumenAprobaciones(int idPerfil, int idUsuario)
        {
            return this.cnAprobaciones.obtenerResumenAprobaciones(idPerfil, idUsuario);            
        }
        #endregion

        #region modulo - rendiciones vencidas
        public IList<clsRendicionVencida> ObtenerRendicionesVencidas(string cTipoConsulta, int idUsuario)
        {
            return this.cnRendicionesVencidas.obtenerRendicionesVencidas(cTipoConsulta, idUsuario);
        }

        public clsWCFRespuesta NotificarRendicionesVencidas(String cEmailOrigen, String cPassword, int idUsuario)
        {
            return this.cnRendicionesVencidas.notificarRendicionesVencidas(cEmailOrigen, cPassword, idUsuario);
        }
        #endregion        
        #endregion
    }
}
