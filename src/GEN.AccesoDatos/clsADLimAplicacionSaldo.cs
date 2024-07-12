using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADLimAplicacionSaldo
    {
        public DataTable ListarTodoLimAplicacionSaldo()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarLimAplicSaldo_SP", 0);
        }
    }
}
