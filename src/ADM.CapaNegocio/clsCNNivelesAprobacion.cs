using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNNivelesAprobacion
    {
        clsADNivelesAprobacion obj;
        public clsCNNivelesAprobacion()
        {
            obj = new clsADNivelesAprobacion();
        }

        public DataTable CNListaVariablesNivelesAproba(int idModulo, int idTipoOperacion)
        {
            return obj.ADListaVariablesNivelesAproba(idModulo, idTipoOperacion);
        }

        public DataTable CNListaCondSolicitudAprobacion(int idSolicitud)
        {
            return obj.ADListaCondSolicitudAprobacion(idSolicitud);
        }

        public DataTable CNCargandoCaracteristicasNivelesAprobacion(int idNivelAprobaBase, int idModulo, int idTipoOperacion)
        {
            return obj.ADCargandoCaracteristicasNivelesAprobacion(idNivelAprobaBase, idModulo, idTipoOperacion);
        }

        public DataTable CNGuardarNivelAprobacion(int idSolicitudAproba, int idNivelAprobacion, int idEstadoAProba)
        {
            return obj.ADGuardarNivelAprobacion(idSolicitudAproba, idNivelAprobacion, idEstadoAProba);
        }

        public DataTable CNRegistroVoBoNivelesAprobacion(string cComentario, int idUsuario, int idPerfil, DateTime dFecha, int idEstadoAproba, int idSolicitud )
        {
            return obj.ADRegistroVoBoNivelesAprobacion(cComentario, idUsuario, idPerfil, dFecha, idEstadoAproba, idSolicitud);
        }
        public DataTable CNRegistroParaAprobacion(int idEstadoAproba, int idSolicitud )
        {
            return obj.ADRegistroParaAprobacion(idEstadoAproba, idSolicitud);
        }
        

        public DataTable CNValidaVoBoNivelAprobacion(int idSolicitudAproba)
        {
            return obj.ADValidaVoBoNivelAprobacion(idSolicitudAproba);
        }

        public DataTable CNListarSolicitudesParaAprobar(int idPerfil, int idAgencia)
        {
            return obj.ADListarSolicitudesParaAprobar(idPerfil, idAgencia);
        }

        public DataTable CNrevisarVistoBuenoNivelAprobacion(int idSolicitudAproba)
        {
            return obj.ADrevisarVistoBuenoNivelAprovacion(idSolicitudAproba);
        }
        public DataTable CNGuardarDesicionSolicitud(int idNivelAprobaSol, int idSolicitudAproba, DateTime dFechaSis, int idEstadoAproba, int idUsu, string cComentario, int idPerfil, int idCuenta)
        {
            return obj.ADGuardarDesicionSolicitud(idNivelAprobaSol, idSolicitudAproba, dFechaSis, idEstadoAproba, idUsu, cComentario, idPerfil, idCuenta);
        }

        public DataTable dtsPropuestaNegociacion(int idSolAproba)
        {
            return obj.dtsPropuestaNegociacion(idSolAproba);
        }

        public DataTable listarGruposAfectacion()
        {
            return obj.listarGruposAfectacion();
        }

        public DataTable listarCobsGrupo(int idGrupo)
        {
            return obj.listarCobsGrupo( idGrupo );
        }

        public DataTable registrarDecicionAfectacion(int idGrupo, int idEstado, int idUsuario, DateTime dFecha, string cComentario)
        {
            return obj.registrarDecicionAfectacion(idGrupo, idEstado, idUsuario, dFecha, cComentario);
        }
    }
}
