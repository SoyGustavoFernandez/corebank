using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.AccesoDatos
{
    public class clsRPTADSaldoDeposito
    {
        clsGENEjeSP ObjEjecuta = new clsGENEjeSP();

        public DataTable ADSaldoDeposito(DateTime dFecha)
        {
            DataTable dt = ObjEjecuta.EjecSP("CNT_SaldoDeposito_sp",dFecha);
            return dt;
        }
    
    }
}
