using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNVacaciones
    {
        clsADVacaciones objVacaciones = new clsADVacaciones();

        public DataTable CNListarTipoUsoVacaciones()
        {
            return objVacaciones.ADListarTipoUsoVacaciones();
        }

        public DataTable CNListarVacacionesUsuario(int idUsuario)
        {
            return objVacaciones.ADListarVacacionesUsuario(idUsuario);
        }

        public DataTable CNDetalleUsoVacaciones(int idVacaciones)
        {
            return objVacaciones.ADDetalleUsoVacaciones(idVacaciones);
        }

        public DataTable CNEliminaVacaciones(int idVacaciones,int idPagVacaciones)
        {
            return objVacaciones.ADEliminaVacaciones(idVacaciones, idPagVacaciones);
        }
        

        public DataTable CNDetallePagosVacaciones(int idVacaciones)
        {
            return objVacaciones.ADDetallePagosVacaciones(idVacaciones);
        }

        public DataTable CNRegistrarUsoVacaciones(int idUsuario, int idVacaciones, int idTipoUso, int nDiasUso,
                                                  DateTime dFechaInicio, DateTime dFechaFin, DateTime dFechaReg, int idUsuarioReg)
        {
            return objVacaciones.ADRegistrarUsoVacaciones(idUsuario, idVacaciones, idTipoUso, nDiasUso,
                                                          dFechaInicio, dFechaFin, dFechaReg, idUsuarioReg);
        }
    }
}
