using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.AccesoDatos
{
    public class clsADTipoCuentasCobrar
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarTipoCuentasCobrar()
        {
            return new clsGENEjeSP().EjecSP("GEN_ListarTipoCuentasCobrarDiv_SP");
        }
     
    }
}
