using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SolIntEls.GEN.Helper;
namespace RPT.AccesoDatos
{
    public class clsRPTADProvisionCartaFianza
    {
        public DataTable ADProvisionCartaFianza(DateTime dFecha, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CRE_ProvisionesCFContable_sp", dFecha, idAgencia);
        }
    }
}
