using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADSplaft
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();

        public DataTable ADRegistroOperacionesUnicas(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesUnicas_SP", dFechaInicio, dFechaFinal);
        }

        public DataTable ADRegistroOperacionesMultiples(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesMultiples_SP", dFechaInicio, dFechaFinal);
        }

        public DataTable ADRegistroOperacionesEfectivo(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesEfectivo_SP", dFechaInicio, dFechaFinal);
        }

        public DataTable ADSplaftAnexo04(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("SPL_Anexo04_SP", dFechaInicio, dFechaFinal);
        }

        public DataTable ADSplaftAnexo08(DateTime dFechaInicio, DateTime dFechaFinal, int idAgencia)
        {
            return objEjeSP.EjecSP("SPL_Anexo08_SP", dFechaInicio, dFechaFinal, idAgencia);
        }

        public DataTable ADRegistroOperacionesUnicasCoop(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesUnicasCOOP_SP", dFechaInicio, dFechaFinal);
        }
        /*=====================================================================================================================================*/
        /* reporte clientes que cambiaron informacion en registro de operaciones */
        /*=====================================================================================================================================*/
        public DataTable ADListaModificRegOpe(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, int idModulo, int idMoneda)
        {
            return objEjeSP.EjecSP("SPL_ListaClientesModifRegOpe_SP", dFechaDesde, dFechaHasta, idAgencia, idModulo, idMoneda);
        }
        /*=====================================================================================================================================*/
        /* reporte de faltantes en registro de operaciones */
        /*=====================================================================================================================================*/
        public DataTable ADListaFaltantesRegOpe(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, int idModulo, int idMoneda)
        {
            return objEjeSP.EjecSP("SPL_ListaFaltantesRegOpe_SP", dFechaDesde, dFechaHasta, idAgencia, idModulo, idMoneda);
        }

        public DataTable ADListaPEPOpe(int idAgencia, DateTime dFecDesde, DateTime dFecHasta)
        {
            return objEjeSP.EjecSP("SPL_ObtenerReportePEP_SP", idAgencia, dFecDesde, dFecHasta);
        }
        
        public DataTable ADReporteVisitasSPLAFT(DateTime dFechaIni, DateTime dFechaFin, int idAgencia, int idModulo, int idTipoRiesgo)
        {
            return objEjeSP.EjecSP("SPL_RptVistaClientesRegimenReforzado_Sp", dFechaIni, dFechaFin, idAgencia, idModulo, idTipoRiesgo);
        }

        public DataTable ADRegOpeUnicaNue(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesUnicasN_SP", dFecIni, dFecFin);
        }
        public DataTable ADRegOpeMulNue(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesMultiplesN_SP", dFecIni, dFecFin);
        }

        public DataTable ADRegOpeUnicaNueUlt(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesUnicasNUtl_SP", dFecIni, dFecFin);
        }
        public DataTable ADRegOpeMulNueUlt(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesMultiplesNUlt_SP", dFecIni , dFecFin);
        }

        public DataTable ADRegOpeUnicaN2021(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesUnicasN2021_SP", dFecIni, dFecFin);
        }

        public DataTable ADRegOpeMulN2021(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSP.EjecSP("RPT_RegistroOperacionesMultiplesN2021_SP", dFecIni, dFecFin);
        }

        public DataTable ADScoringSplaft(string sDocumentoID, int nCodigoEvaluacion, DateTime dFechaEvalInicio, DateTime dFechaEvalFin, int nTipoEvaluacionID, int nCalificativoID)
        {
            return objEjeSP.EjecSP("SPL_ScoringEvaluaciones_SP", sDocumentoID, nCodigoEvaluacion, dFechaEvalInicio, dFechaEvalFin, nTipoEvaluacionID, nCalificativoID);
        }
        public DataTable ADReporteExtornoSPL(string dFechaEvalInicio, string dFechaEvalFin)
        {
            return objEjeSP.EjecSP("SPL_ReporteExtornos_SP", dFechaEvalInicio, dFechaEvalFin);
        }
            
    }
}