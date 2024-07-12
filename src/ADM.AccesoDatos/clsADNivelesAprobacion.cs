using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADNivelesAprobacion
    {
        clsGENEjeSP obj;

        public clsADNivelesAprobacion()
        {
            obj = new clsGENEjeSP();
        }
        #region Consultas Base Datos
        
        public DataTable ADListaVariablesNivelesAproba(int idModulo, int idTipoOperacion)
        {
            return obj.EjecSP("ADM_ListaVariablesNivelesAproba_SP", idModulo, idTipoOperacion);
        }

        public DataTable ADListaCondSolicitudAprobacion(int idSolicitud)
        {
            return obj.EjecSP("ADM_ListaCondSolicitudAprobacion_SP", idSolicitud);
        }

        public DataTable ADCargandoCaracteristicasNivelesAprobacion(int idNivelAprobaBase, int idModulo, int idTipoOperacion)
        {
            return obj.EjecSP("ADM_CargandoCaracteristicasNivelesAprobacion_SP", idNivelAprobaBase, idModulo, idTipoOperacion);
        }

        public DataTable ADGuardarNivelAprobacion(int idSolicitudAproba, int idNivelAprobacion, int idEstadoAproba)
        {
            return obj.EjecSP("ADM_GuardarNivelAprobacion_SP", idSolicitudAproba, idNivelAprobacion, idEstadoAproba);
        }

        public DataTable ADRegistroVoBoNivelesAprobacion(string cComentario, int idUsuario, int idPerfil, DateTime dFecha, int idEstadoAproba, int idSolicitud)
        {
            return obj.EjecSP("ADM_RegistroVoBoNivelesAprobacion_SP", cComentario, idUsuario, idPerfil, dFecha, idEstadoAproba, idSolicitud);
        }
        public DataTable ADRegistroParaAprobacion(int idEstadoAproba, int idSolicitud)
        {
            return obj.EjecSP("ADM_EnvioNivelesAprobacion_SP", idEstadoAproba, idSolicitud);
        }

        public DataTable ADValidaVoBoNivelAprobacion(int idSolicitudAproba)
        {
            return obj.EjecSP("ADM_ValidaVoBoNivelAprobacion_SP", idSolicitudAproba);
        }

        public DataTable ADListarSolicitudesParaAprobar(int idPerfil, int idAgencia)
        {
            return obj.EjecSP("ADM_ListarSolicitudesParaAprobar_SP", idPerfil, idAgencia);
        }
        public DataTable ADrevisarVistoBuenoNivelAprovacion(int idSolicitudAproba)
        {
            return obj.EjecSP("ADM_RevisarVistoBueno_SP", idSolicitudAproba);
        }

        public DataTable ADGuardarDesicionSolicitud(int idNivelAprobaSol, int idSolicitudAproba, DateTime dFechaSis, int idEstadoAproba, int idUsu, string cComentario, int idPerfil, int idCuenta)
        {
            return obj.EjecSP("ADM_GuardarDesicionSolicitud_SP", idNivelAprobaSol, idSolicitudAproba, dFechaSis, idEstadoAproba, idUsu, cComentario, idPerfil, idCuenta);
        }

        public DataTable dtsPropuestaNegociacion(int idSolAproba)
        {
            return obj.EjecSP("CRE_PropuestaNegociacion_SP", idSolAproba);
        }

        public DataTable listarGruposAfectacion()
        {
            return obj.EjecSP("CRE_ListarSolictudGrupoAfectacion_SP");
        }

        public DataTable listarCobsGrupo(int idGrupo)
        {
            return obj.EjecSP("CRE_ListarCobsGrupo_SP", idGrupo);
        }

        public DataTable registrarDecicionAfectacion(int idGrupo, int idEstado, int idUsuario, DateTime dFecha, string cComentario)
        {
            return obj.EjecSP("ADM_RegistrarDecicionAfectacion_SP", idGrupo, idEstado, idUsuario, dFecha, cComentario);
        }
        #endregion
    }
}
