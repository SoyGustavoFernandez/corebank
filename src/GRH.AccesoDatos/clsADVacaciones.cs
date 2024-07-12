using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADVacaciones
    {
         clsGENEjeSP objEjeSp = new clsGENEjeSP();

         public DataTable ADListarTipoUsoVacaciones()
         {
             return objEjeSp.EjecSP("GRH_ListarTipoUsoVacaciones_SP");
         }

        public DataTable ADListarVacacionesUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarVacacionesUsuario_SP", idUsuario);
        }

        public DataTable ADDetalleUsoVacaciones(int idVacaciones)
        {
            return objEjeSp.EjecSP("GRH_DetalleUsoVacaciones_SP", idVacaciones);
        }

        public DataTable ADEliminaVacaciones(int idVacaciones, int idPagVacaciones)
        {
            return objEjeSp.EjecSP("GRH_EliminaVacaciones_SP", idVacaciones, idPagVacaciones);
        }

        public DataTable ADDetallePagosVacaciones(int idVacaciones)
        {
            return objEjeSp.EjecSP("GRH_DetallePagosVacaciones_SP", idVacaciones);
        }

        public DataTable ADRegistrarUsoVacaciones(int idUsuario, int idVacaciones, int idTipoUso, int nDiasUso,
                                                  DateTime dFechaInicio, DateTime dFechaFin, DateTime dFechaReg, int idUsuarioReg)
        {
            return objEjeSp.EjecSP("GRH_RegistrarUsoVacaciones_SP", idUsuario, idVacaciones, idTipoUso, nDiasUso,
                                                                    dFechaInicio, dFechaFin, dFechaReg, idUsuarioReg);
        }
    }
}
