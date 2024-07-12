using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPT.AccesoDatos;

namespace RPT.CapaNegocio
{
    public class clsRPTCNSplaft
    {
        clsRPTADSplaft objSplaft = new clsRPTADSplaft();

        public DataTable CNRegistroOperacionesUnicas(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objSplaft.ADRegistroOperacionesUnicas(dFechaInicio, dFechaFinal);
        }
        public DataTable CNRegistroOperacionesMultiples(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objSplaft.ADRegistroOperacionesMultiples(dFechaInicio, dFechaFinal);
        }
        public DataTable CNRegistroOperacionesEfectivo(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objSplaft.ADRegistroOperacionesEfectivo(dFechaInicio, dFechaFinal);
        }

        public DataTable CNSplaftAnexo04(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objSplaft.ADSplaftAnexo04(dFechaInicio, dFechaFinal);
        }

        public DataTable CNSplaftAnexo08(DateTime dFechaInicio, DateTime dFechaFinal, int idAgencia)
        {
            return objSplaft.ADSplaftAnexo08(dFechaInicio, dFechaFinal, idAgencia);
        }

        public DataTable CNRegistroOperacionesUnicasCoop(DateTime dFechaInicio, DateTime dFechaFinal)
        {
            return objSplaft.ADRegistroOperacionesUnicasCoop(dFechaInicio, dFechaFinal);
        }
        /*=====================================================================================================================================*/
        /* reporte clientes que cambiaron informacion en registro de operaciones */
        /*=====================================================================================================================================*/
        public DataTable CNListaModificRegOpe(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, int idModulo, int idMoneda)
        {
            return objSplaft.ADListaModificRegOpe(dFechaDesde, dFechaHasta, idAgencia, idModulo, idMoneda);
        }
        /*=====================================================================================================================================*/
        /* reporte de faltantes en registro de operaciones */
        /*=====================================================================================================================================*/
        public DataTable CNListaFaltantesRegOpe(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, int idModulo, int idMoneda)
        {
            return objSplaft.ADListaFaltantesRegOpe(dFechaDesde, dFechaHasta, idAgencia, idModulo, idMoneda);
        }

        public DataTable CNListaPEPOpe(int idAgencia, DateTime dFecDesde, DateTime dFecHasta)
        {
            return objSplaft.ADListaPEPOpe(idAgencia, dFecDesde, dFecHasta);
        }

        public DataTable CNReporteVisitasSPLAFT(DateTime dFechaIni, DateTime dFechaFin, int idAgencia, int idModulo, int idTipoRiesgo)
        {
            return objSplaft.ADReporteVisitasSPLAFT(dFechaIni, dFechaFin, idAgencia, idModulo, idTipoRiesgo);
        }

        public DataTable CNRegOpeUnicaNue(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeUnicaNue(dFecIni, dFecFin);
        }

        public DataTable CNRegOpeMulNue(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeMulNue(dFecIni, dFecFin);
        }
        public DataTable CNRegOpeUnicaNueUlt(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeUnicaNueUlt(dFecIni, dFecFin);
        }

        public DataTable CNRegOpeMulNueUlt(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeMulNueUlt( dFecIni, dFecFin );
        }

        public DataTable CNRegOpeUnicaN2021(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeUnicaN2021(dFecIni, dFecFin);
        }

        public DataTable CNRegOpeMulN2021(DateTime dFecIni, DateTime dFecFin)
        {
            return objSplaft.ADRegOpeMulN2021(dFecIni, dFecFin);
        }

        public DataTable CNScoringSplaft(string sDocumentoID, int nCodigoEvaluacion, DateTime dFechaEvalInicio, DateTime dFechaEvalFin, int nTipoEvaluacionID, int nCalificativoID)
        {
            return objSplaft.ADScoringSplaft(sDocumentoID, nCodigoEvaluacion, dFechaEvalInicio, dFechaEvalFin, nTipoEvaluacionID, nCalificativoID);
        }
        public DataTable CNReporteExtornoSPL(string dFechaEvalInicio, string dFechaEvalFin)
        {
            return objSplaft.ADReporteExtornoSPL(dFechaEvalInicio, dFechaEvalFin);
        }
    }
}
