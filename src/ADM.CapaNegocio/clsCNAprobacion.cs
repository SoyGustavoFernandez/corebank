using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using ADM.AccesoDatos;
using GEN.Funciones;
using EntityLayer;
namespace ADM.CapaNegocio
{
    public class clsCNAprobacion
    {
        private clsADAprobacion objADAprobacion;

        public clsCNAprobacion()
        {
            this.objADAprobacion = new clsADAprobacion();
        }
        public List<clsAprobacionSolicitud> listarAprobacionSolicitud()
        {
            DataTable dtAprobacionSolicitud = this.objADAprobacion.listarAprobacionSolicitud(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.User.idEstablecimiento, clsVarGlobal.nIdAgencia);
            return (dtAprobacionSolicitud.Rows.Count > 0) ?
                dtAprobacionSolicitud.ToList<clsAprobacionSolicitud>() as List<clsAprobacionSolicitud> :
                new List<clsAprobacionSolicitud>();
        }
        public clsAprobacionSolicitud obtenerAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro)
        {
            DataTable dtAprobacionSolicitud = this.objADAprobacion.obtenerAprobacionSolicitud(idAprobacionSolicitudTipo, idRegistro);

            return (dtAprobacionSolicitud.Rows.Count > 0)?
                dtAprobacionSolicitud.Rows[0].ToObject<clsAprobacionSolicitud>() :
                new clsAprobacionSolicitud();
        }

        public clsRespuestaServidor grabarAprobacionSolicitud(
            int idAprobacionSolicitudTipo, int idRegistro, int idAprobacionCanal,
            int idClienteBeneficiario, string cValor, decimal nMonto, string cSustento
            )
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.grabarAprobacionSolicitud(
                idAprobacionSolicitudTipo, idRegistro, idAprobacionCanal,
                clsVarGlobal.User.idEstablecimiento, idClienteBeneficiario, clsVarGlobal.User.idUsuario, cValor, nMonto, clsVarGlobal.dFecSystem, cSustento
                );
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public clsAprobacionGestion gestionarAprobacionBasica(int idNivelAprobacion, int idCanalAprobacion)
        {
            DataTable dtAprobacionGestion = this.objADAprobacion.gestionarAprobacionBasica(clsVarGlobal.PerfilUsu.idPerfil, idNivelAprobacion, idCanalAprobacion);
            return (dtAprobacionGestion.Rows.Count > 0) ?
                dtAprobacionGestion.Rows[0].ToObject<clsAprobacionGestion>() :
                new clsAprobacionGestion();
        }

        public clsRespuestaServidor grabarResolucionAprobacion(
            int idAprobacionSolicitud, int idAprobacionSolicitudTipo, int idRegistro, int idEstado, int idEtapa,
            int idAprobacionNivel, int idAprobacionNivelSig, int idAprobacionCanal, int idEstablecimiento, int idClienteBeneficiario,
            int idUsuarioSolicitante, int idUsuarioAprobador, decimal nMonto, DateTime dFecha, string cComentario
            )
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.grabarResolucionAprobacion(
                idAprobacionSolicitud, idAprobacionSolicitudTipo, idRegistro, idEstado, idEtapa,
                idAprobacionNivel, idAprobacionNivelSig, idAprobacionCanal, idEstablecimiento, idClienteBeneficiario,
                idUsuarioSolicitante, idUsuarioAprobador, nMonto, dFecha, cComentario
                );
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor actualizarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro, string cValor)
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.actualizarAprobacionSolicitud(idAprobacionSolicitudTipo, idRegistro, cValor);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor ejecutarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro)
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.ejecutarAprobacionSolicitud(idAprobacionSolicitudTipo, idRegistro, clsVarGlobal.User.idUsuario);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor expirarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro)
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.expirarAprobacionSolicitud(idAprobacionSolicitudTipo, idRegistro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
        public clsRespuestaServidor anularAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro)
        {
            DataTable dtRespuestaServidor = this.objADAprobacion.anularAprobacionSolicitud(idAprobacionSolicitudTipo, idRegistro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            return (dtRespuestaServidor.Rows.Count > 0) ?
                dtRespuestaServidor.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }
    }
}
