using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPT.AccesoDatos
{
    public class clsRPTADCanElectronicos
    {
        public DataTable ADAdmTarjetas(int idEstado, int idTipTarjeta, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CNE_RptTarjetas_sp", idEstado, idTipTarjeta, idAgencia);
        }

        public DataTable ADTarjVincCtas(int idTipTarjeta, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CNE_RptTarjVincCtas_sp", idTipTarjeta, idAgencia);
        }

        public DataTable ADTarjBloqueadas(int idAgencia,DateTime dFecIni,DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("CNE_BloqTarjetas_sp", idAgencia,dFecIni,dFecFin);
        }
    }
}
