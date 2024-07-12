using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.AccesoDatos
{
    public class clsRPTADSocio
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADDeudorAnexo6(DateTime dFecha)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptDeudoresAnexo6_sp", dFecha);
            return dt;
        }

        public DataTable ADRptSaldoAportes(DateTime dFecha)
        {
            DataTable dt = objEjeSp.EjecSP("CLI_RptSaldoAportes_Sp", dFecha);
            return dt;
        }
    }
}
