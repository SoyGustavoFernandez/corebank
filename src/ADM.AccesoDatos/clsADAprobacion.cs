using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using SolIntEls.GEN.Helper;
namespace ADM.AccesoDatos
{
    public class clsADAprobacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable listarAprobacionSolicitud(int idPerfil, int idEstablecimiento, int idAgencia)
        {
            return this.objEjeSp.EjecSP("ADM_ListarAprobacionSolicitud_SP", idPerfil, idEstablecimiento, idAgencia);
        }
        public DataTable obtenerAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro)
        {
            return this.objEjeSp.EjecSP("ADM_ObtenerAprobacionSolicitud_SP", idAprobacionSolicitudTipo, idRegistro);
        }
        public DataTable grabarAprobacionSolicitud(
            int idAprobacionSolicitudTipo, int idRegistro, int idAprobacionCanal, int idEstablecimiento,
            int idClienteBeneficiario, int idUsuario, string cValor, decimal nMonto, DateTime dFecha, string cSustento
            )
        {
            return this.objEjeSp.EjecSP("ADM_GrabarAprobacionSolicitud_SP",
                idAprobacionSolicitudTipo, idRegistro, idAprobacionCanal,
                idEstablecimiento, idClienteBeneficiario, idUsuario, cValor, nMonto, dFecha, cSustento);
        }
        public DataTable gestionarAprobacionBasica(int idPerfil, int idNivelAprobacion, int idCanalAprobacion)
        {
            return this.objEjeSp.EjecSP("ADM_GestionarAprobacionBasica_SP", idPerfil, idNivelAprobacion, idCanalAprobacion);
        }
        public DataTable grabarResolucionAprobacion(
            int idAprobacionSolicitud, int idAprobacionSolicitudTipo, int idRegistro, int idEstado, int idEtapa,
            int idAprobacionNivel, int idAprobacionNivelSig, int idAprobacionCanal, int idEstablecimiento, int idClienteBeneficiario,
            int idUsuarioSolicitante, int idUsuarioAprobador, decimal nMonto, DateTime dFecha, string cComentario
            )
        {
            return this.objEjeSp.EjecSP("ADM_GrabarResolucionAprobacion_SP",
                idAprobacionSolicitud, idAprobacionSolicitudTipo, idRegistro, idEstado, idEtapa,
                idAprobacionNivel, idAprobacionNivelSig, idAprobacionCanal, idEstablecimiento, idClienteBeneficiario,
                idUsuarioSolicitante, idUsuarioAprobador, nMonto, dFecha, cComentario
                );
        }
        public DataTable actualizarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro, string cValor)
        {
            return this.objEjeSp.EjecSP("ADM_ActualizarAprobacionSolicitud_SP", idAprobacionSolicitudTipo, idRegistro, cValor);
        }
        public DataTable ejecutarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro, int idUsuario)
        {
            return this.objEjeSp.EjecSP("ADM_EjecutarAprobacionSolicitud_SP", idAprobacionSolicitudTipo, idRegistro, idUsuario);
        }
        public DataTable expirarAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro, int idUsuario, DateTime dFechaSistema)
        {
            return this.objEjeSp.EjecSP("ADM_ExpirarAprobacionSolicitud_SP", idAprobacionSolicitudTipo, idRegistro, idUsuario, dFechaSistema);
        }
        public DataTable anularAprobacionSolicitud(int idAprobacionSolicitudTipo, int idRegistro, int idUsuario, DateTime dFechaSistema)
        {
            return this.objEjeSp.EjecSP("ADM_AnularAprobacionSolicitud_SP", idAprobacionSolicitudTipo, idRegistro, idUsuario, dFechaSistema);
        }
    }
}
