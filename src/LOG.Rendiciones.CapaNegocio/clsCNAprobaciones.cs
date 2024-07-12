using LOG.Rendiciones.AccesoDatos;
using WCFLogistica.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

namespace LOG.Rendiciones.CapaNegocio
{
    public class clsCNAprobaciones
    {
        #region propiedades privadas
        private clsADAprobaciones adAprobaciones;
        #endregion

        #region constructores
        public clsCNAprobaciones()
        {
            this.adAprobaciones = new clsADAprobaciones();
        }
        #endregion

        #region métodos públicos
        public IList<clsEntregaRendir> obtenerAprobacionesEntrega(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID)
        {
            DataTable dtAprobacionesEntrega = this.adAprobaciones.obtenerAprobacionesEntrega(idPerfil, idUsuario, idTipoEntrega, cNombre, cDocumentoID);
            return dtAprobacionesEntrega.SoftToList<clsEntregaRendir>();
        }

        public clsWCFRespuesta registrarAprobacionEntrega(clsAprobacionEntrega objAprobacionEntrega)
        {
            DataTable dtAprobacionEntrega = this.adAprobaciones.registrarAprobacionEntrega(
                objAprobacionEntrega.idNivelAprueba,
                objAprobacionEntrega.idPerfilAprobSolicitud,
                objAprobacionEntrega.idEntrega,
                objAprobacionEntrega.cDecision,
                objAprobacionEntrega.idUsuario,
                objAprobacionEntrega.idAgencia,
                objAprobacionEntrega.cComentario
            );
            return dtAprobacionEntrega.Rows[0].ToObject<clsWCFRespuesta>();
        }

        public IList<clsEntregaRendir> obtenerAprobacionesRendicion(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID)
        {
            DataTable dt = this.adAprobaciones.obtenerAprobacionesRendicion(idPerfil, idUsuario, idTipoEntrega, cNombre, cDocumentoID);
            return dt.SoftToList<clsEntregaRendir>();
        }

        public clsWCFRespuesta registrarAprobacionRendicion(clsAprobacionRendicion objAprobacionRendicion)
        {
            DataTable dtAprobacionRendicion = this.adAprobaciones.registrarAprobacionRendicion(
                objAprobacionRendicion.idNivelAprueba,
                objAprobacionRendicion.idPerfilAprobRendicion,
                objAprobacionRendicion.idEntrega,
                objAprobacionRendicion.cDecision,
                objAprobacionRendicion.idUsuario,
                objAprobacionRendicion.idAgencia,
                objAprobacionRendicion.cComentario
            );
            return dtAprobacionRendicion.Rows[0].ToObject<clsWCFRespuesta>();
        }

        public IList<clsResumenAprobacion> obtenerResumenAprobaciones(int idPerfil, int idUsuario)
        {
            DataTable dtResumenAprobaciones = this.adAprobaciones.obtenerResumenAprobaciones(idPerfil, idUsuario);
            return dtResumenAprobaciones.SoftToList<clsResumenAprobacion>();
        }
        #endregion
        
    }
}
