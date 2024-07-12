using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTipoAfectacionCuentaCtb
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarTipoAfectacionCuentaCtb()
        {
            return objEjeSp.EjecSP("GEN_ListarTipoAfectacionCuentaCtb_SP");
        }
    }
}
