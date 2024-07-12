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
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADProcesaEPG(DateTime dFecha, decimal nPorImpRent)
        {
            return objEjeSp.EjecSP("CNT_ProcesaEPG_sp", dFecha, nPorImpRent);
        }
        public DataTable ADProcesaBG(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_ProcesaBG_sp", dFecha);
        }
        public DataTable ADProcesaBalance(DateTime dFecha)
        {
           return objEjeSp.EjecSP("CNT_ProcesaBalance_sp", dFecha);
        }
        public DataTable ADResumMovSaldo(DateTime dFecIni, DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenMovSaldos_sp", dFecIni, dFecFin);
        }
        public DataTable ADResumMovSaldoAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenMovSaldoAge_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADResumCobranAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenCobranzas_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADResumDeposito(DateTime dFecIni, DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenDeposito_sp", dFecIni, dFecFin);
        }
        public DataTable ADResumDepositoAge(DateTime dFecIni, DateTime dFecFin, Int32 idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenDepositoAge_sp", dFecIni, dFecFin, idAgencia);
        }

        public DataTable ADActualizaSaldoEnPresupuesto(DateTime dFecFin)
        {
            return new clsGENEjeSP().EjecSP("PRE_ActualMontoEjecutadoEnPresupuestos_SP", dFecFin);
        }
        public DataTable ADGeneraEPG(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CNT_GeneraEPGAgencia_sp", dFecha);
        }
        public DataTable ADInsEPGManual(DateTime dFecha, string cXML)
        {
            return new clsGENEjeSP().EjecSP("CNT_InsertaDistribucionManualEPG_sp", dFecha, cXML);
        }
        public DataTable ADBSI(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CRE_GeneraDatosBSI_sp", dFecha);
        }
        public DataTable ADConsultaBSI(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CRE_ExportaDatosBSI_sp", dFecha);
        }
        public DataTable ADInteresGracia(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CRE_SaldoDiferidoInteresGracia_sp", dFecha);
        }
        public DataTable ValidaProcesoEEFF(string cFrm, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("CNT_ValidaProceso_sp", cFrm, idUsuario);
        }
        public DataTable LiberaProcesoEEFF(string cFrm, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("CNT_LiberaProceso_sp", cFrm, idUsuario);
        }
        public DataTable DiferidoxAmpliacion(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CNT_SaldoDiferidoxAmpliacion_sp", dFecha);
        }
        public DataTable DiferidoxCapNeg(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CNT_SaldoDiferidoxCapNeg_sp", dFecha);
        }

    }
}
