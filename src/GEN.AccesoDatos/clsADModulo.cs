using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADModulo
    {
        public DataTable LisModulo()
        {
            return new clsGENEjeSP().EjecSP("GEN_LisModulo_SP");
        }
    }
}
