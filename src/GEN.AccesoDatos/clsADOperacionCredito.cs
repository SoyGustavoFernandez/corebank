using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADOperacionCredito
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarOperacionCredito(string cIdsOperacion = "0")
        {
            return objEjeSp.EjecSP("CRE_ObtenerOperacionCredito_SP", cIdsOperacion);
        }
    }
}
