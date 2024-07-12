using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CNT.AccesoDatos
{
    public class clsADBalance
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADProcesaEPG(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("CNT_ProcesaEPG_sp", nAnio, nMes);
        }
        public DataTable ADProcesaBG(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("CNT_ProcesaBG_sp", nAnio, nMes);
        }
        public DataTable ADProcesaBalance(int nAnio, int nMes)
        {
           return objEjeSp.EjecSP("CNT_ProcesaBalance_sp", nAnio, nMes);
        }
    }
}
