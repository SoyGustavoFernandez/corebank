using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNT.AccesoDatos
{
    public class clsADITF
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADValidaCalculoITF(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objEjeSp.EjecSP("CNT_ValidaCalculoITF_sp", dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataTable ADValidaAsientoTrx(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objEjeSp.EjecSP("CNT_ValidaAsientoKardex_sp", dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataSet ADTransTXT(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objEjeSp.DSEjecSP("CNT_PDTDatosITF_sp", dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataTable DatoTRX(int idCli, DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CNT_CertificadoITF_sp", idCli, dFecIni, dFecFin);
        }
        public DataTable DatoVariableITF()
        {
            return objEjeSp.EjecSP("CNT_VariablesCertificadoITF_sp");
        }
    }
}
