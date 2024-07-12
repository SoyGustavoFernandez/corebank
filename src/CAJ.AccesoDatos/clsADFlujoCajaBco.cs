using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CAJ.AccesoDatos
{
    public class clsADFlujoCajaBco
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADReprocesarFlujoCajaBco(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CAJ_ReprocesarFlujoCajaBco_SP", dFechaIni, dFechaFin);
        }

        public DataTable ADRptFlujoCajaBco(DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_RptFlujoCajaBco_SP", dFechaIni, dFechaFin, idMoneda);
        }
        public DataTable ADRptFlujoMensualCajaBco(DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return objEjeSp.EjecSP("CAJ_RptFlujoMensualCajaBco_SP", dFechaIni, dFechaFin, idMoneda);
        }
    }
}
