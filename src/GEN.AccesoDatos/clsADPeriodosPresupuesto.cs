using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADPeriodosPresupuesto
    {
        public DataTable ADListarTodo()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarPeriodosPresupuesto_SP", 0);
        }
     
    }
}
