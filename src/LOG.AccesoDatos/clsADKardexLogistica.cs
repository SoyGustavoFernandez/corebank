using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace LOG.AccesoDatos
{
    public class clsADKardexLogistica
    {
        public DataTable BusKardexLog(int idKardex)
        {
            return new clsGENEjeSP().EjecSP("LOG_BusKardexLogistica_SP", idKardex);
        }
    }
}
