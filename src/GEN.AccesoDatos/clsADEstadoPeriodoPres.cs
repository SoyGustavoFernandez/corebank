using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADEstadoPeriodoPres
    {
        public DataTable ADListarTodosEstados()
        {
            return new clsGENEjeSP().EjecSP("PRE_ListarEstadosPeriodoPres_SP", 0);
        }
        public DataTable ADListarUnEstado(int idEstado)
        {
            return new clsGENEjeSP().EjecSP("PRE_ListarEstadosPeriodoPres_SP", idEstado);
        }       
    }
}
