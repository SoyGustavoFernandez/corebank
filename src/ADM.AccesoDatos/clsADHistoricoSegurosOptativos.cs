using SolIntEls.GEN.Helper;
using System;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADHistoricoSegurosOptativos
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable GuardarHistoricoSegurosOptativos(string xmlHistorico)
        {
            return objEjeSp.EjecSP("ADM_GuardarHistoricoSegurosOptativos_SP", xmlHistorico);
        }

        public DataTable CNObtenerHistoricoSegurosOptativos(DateTime dFechaDesde, DateTime dFechaHasta, int idSeguro)
        {
            return objEjeSp.EjecSP("ADM_HistoricoSegurosOptativos_SP", dFechaDesde, dFechaHasta, idSeguro);
        }
    }
}