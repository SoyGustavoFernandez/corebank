using CNT.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNT.CapaNegocio
{
    public class clsCNITF
    {
        clsADITF objctactb = new clsADITF();
        public DataTable CNValidaCalculoITF(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objctactb.ADValidaCalculoITF(dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataTable CNValidaAsientoTrx(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objctactb.ADValidaAsientoTrx(dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataSet CNTransTXT(DateTime dFecIni, DateTime dFecFin, int nmes, int nAnio, Boolean lReporte)
        {
            return objctactb.ADTransTXT(dFecIni, dFecFin, nmes, nAnio, lReporte);
        }
        public DataTable DatoTRX(int idCli, DateTime dFecIni, DateTime dFecFin)
        {
            return objctactb.DatoTRX(idCli, dFecIni, dFecFin);
        }
        public DataTable DatoVariableITF()
        {
            return objctactb.DatoVariableITF();
        }
    }
}
