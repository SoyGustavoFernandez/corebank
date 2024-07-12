using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace SPL.AccesoDatos
{
    public class clsADCreditos
    {
        clsGENEjeSP objEjeSp;
        public clsADCreditos()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public DataTable ADCreditosCanceladosAnticipadamente(DateTime dFecIni, DateTime dFecFin, Decimal nMontoIni, Decimal nMontoFin, int idAgencia, int idMoneda)
        {
            return objEjeSp.EjecSP("SPL_RptCreditosCancelacionAnticipada_SP", dFecIni, dFecFin, nMontoIni, nMontoFin, idAgencia, idMoneda);
        }

    }
}
