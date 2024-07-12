using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPermisoJustificacion
    {
        clsADPermisoJustificacion objPermisoJustificacion = new clsADPermisoJustificacion();

        public DataTable CNListarPermisosUsuario(int idUsuario)
        {
            return objPermisoJustificacion.ADListarPermisosUsuario(idUsuario);
        }

        public DataTable CNRegistrarSolicitudPermiso(int idUsuario, int idTipoPermiso, int idMotivo,
                                                     DateTime dFechaInicio, DateTime dFechaFin, int idDetalleHorario,
                                                     DateTime dHoraInicio, DateTime dHoraFin, DateTime dFechaReg,
                                                     int idUsuarioReg)
        {
            return objPermisoJustificacion.ADRegistrarSolicitudPermiso(idUsuario, idTipoPermiso, idMotivo,
                                                                       dFechaInicio, dFechaFin, idDetalleHorario,
                                                                       dHoraInicio, dHoraFin, dFechaReg,
                                                                       idUsuarioReg);
        }

        public DataTable CNEliminarSolicitudPermiso(int idPermiso, DateTime dFechaMod, int idUsuarioMod)
        {
            return objPermisoJustificacion.ADEliminarSolicitudPermiso(idPermiso, dFechaMod, idUsuarioMod);
        }
        public DataTable CNPapeletaPermiso(int idPermiso)
        {
            return objPermisoJustificacion.ADPapeletaPermiso(idPermiso);
        }
    }
}
