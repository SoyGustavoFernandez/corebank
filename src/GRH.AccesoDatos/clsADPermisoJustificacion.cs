using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPermisoJustificacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPermisosUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarPermisosUsuario_SP", idUsuario);
        }

        public DataTable ADRegistrarSolicitudPermiso(int idUsuario, int idTipoPermiso, int idMotivo,
                                                     DateTime dFechaInicio, DateTime dFechaFin, int idDetalleHorario,
                                                     DateTime dHoraInicio, DateTime dHoraFin, DateTime dFechaReg,
                                                     int idUsuarioReg)
        {
            return objEjeSp.EjecSP("GRH_RegistrarSolicitudPermiso_SP", idUsuario, idTipoPermiso, idMotivo,
                                                                       dFechaInicio, dFechaFin, idDetalleHorario,
                                                                       dHoraInicio, dHoraFin, dFechaReg,
                                                                       idUsuarioReg);
        }

        public DataTable ADEliminarSolicitudPermiso(int idPermiso, DateTime dFechaMod, int idUsuarioMod)
        {
            return objEjeSp.EjecSP("GRH_EliminarSolicitudPermiso_SP", idPermiso, dFechaMod, idUsuarioMod);
        }

        public DataTable ADPapeletaPermiso(int idPermiso)
        {
            return objEjeSp.EjecSP("GRH_PapeletaPermiso_SP", idPermiso);
        }
    }
}
