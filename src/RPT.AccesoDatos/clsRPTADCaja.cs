using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADCaja
    {
        public DataTable ADCorteFracc(DateTime dFecha, int idUsuario, int idAgencia, int idTipResCaj)
        {
            return new clsGENEjeSP().EjecSP("CAJ_rptCorteFrac_Sp", dFecha, idUsuario, idAgencia, idTipResCaj);
        }
        public DataTable ADDetalleHabilita(DateTime dFecha, int idUsuario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("RPT_DetHabCuadre_Sp", dFecha, idAgencia, idUsuario);
        }
        public DataTable ADDetalleRecibos(DateTime dFecha, int idAgencia, int idUsuario)
        {
            return new clsGENEjeSP().EjecSP("RPT_DetRecCuadre_Sp", dFecha, idAgencia, idUsuario);
        }
        public DataTable ADResumenOpeSol(DateTime dFecha, int idUsuario, int idAgencia, int idTipOpeCaj,int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptResumenOpe_Sp", dFecha, idUsuario, idAgencia,idTipOpeCaj, idMoneda);
        }
        public DataTable ADDetallOperaciones(DateTime dFecha, int idUsuario, int idAgencia, int idTipResCaj)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDetalleOpe_Sp", dFecha, idUsuario, idAgencia, idTipResCaj);
        }
        public DataTable ADConRecibos(string idAge, string idUsu, DateTime dFecIni, DateTime dFecFin, string idMon, string idConcep)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptConRecibos_Sp", idAge, idUsu, dFecIni, dFecFin, idMon, idConcep);
        }
        public DataTable ADMovimientoCajBoveda(DateTime dFecha, int idUsuario, int idAgencia, int idTipoMov)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptMovCajPulmonboveda_Sp", dFecha, idUsuario, idAgencia, idTipoMov);
        }
        public DataTable ADSaldoEnLinea(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, Decimal nLimPor, Int32 idZona = 0)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptSaldoEnLinea_sp", idAgencia, dFechaHasta, nLimPor, idZona, dFechaDesde);
        }
        public DataTable ADExtractoBcos(int idCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptExtactoBancos_sp", idCtaBco, dFechaIni, dFechaFin);
        }
        public DataTable ADExtractoBcosResumen(int idCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptExtactoBancosRes_sp", idCtaBco, dFechaIni, dFechaFin);
        }
        public DataTable ADLibroAuxilarBcos(string cIdCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("CAJ_LibroAuxiliarBcos_sp", cIdCtaBco, dFechaIni, dFechaFin);
        }
        public DataTable ADDatosBco(int idCtaBco)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDatosBco_sp", idCtaBco);
        }
        public DataTable ADDetCajChica(int idResp, int idCajChica, int nNroCajChica, int EstadoCpg)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDetCajaChica_sp", idResp, idCajChica, nNroCajChica,EstadoCpg);
        }
        public DataTable ADDatosCajChica(int idCajChica,int nNroCajChica)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDatosCajaChica_sp", idCajChica,nNroCajChica);
        }
        public DataTable ADDetChequeBco(int idCtaBco, string idEstado, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptChequeBco_sp", idCtaBco, idEstado, dFechaIni, dFechaFin);
        }
        public DataTable AdRepMensualAdeudado(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptMensualAdeudado_sp", dFechaInicio, dFechaFin);
        }
        public DataTable AdRepMEFCreditoAdeudado(DateTime dFechaProceso)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptMEFAdeudadoCredito_sp", dFechaProceso);
        }
        public DataTable AdRepMEFDesembolsoAdeudado(DateTime dFechaProceso)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptMEFDesembolsoAdeudado_sp", dFechaProceso);
        }
        public DataTable AdRepMEFPagoAdeudado(DateTime dFechaProceso)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptMEFPagoAdeudado_sp", dFechaProceso);
        }
        public DataTable AdRepMEFCalendarioAdeudado(DateTime dFechaProceso)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptMEFCalendarioAdeudado_sp", dFechaProceso);
        }
		//Habilitaciones
        public DataTable AdRptHabilitaciones(DateTime dFecIni, DateTime dFecFin, int idUsuario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CAJ_rptHabilitaciones_Sp", dFecIni, dFecFin, idUsuario, idAgencia);
        }
		
        //CobroRec
        public DataTable AdRptCobroRec(int idAgencia, int idUsuario, DateTime dFechaIni, DateTime dFechaFin, int idMoneda, string cidConcepto)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptCobroRec_Sp", idAgencia, idUsuario, dFechaIni, dFechaFin, idMoneda, cidConcepto);
        }

        //ResumenRec
        public DataTable AdRptResumenRec(int idAgencia, DateTime dFechaIni, DateTime dFechaFin, int IdTipoRecibo,string idConcepto,int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptResumenRec_Sp", idAgencia, dFechaIni, dFechaFin, IdTipoRecibo, idConcepto,idMoneda);
        }
		
        //Recibos Sobrantes faltantes
        public DataTable AdRptRecSobFal(int idAgencia, int idUsuario, DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptRecSobFal_Sp", idAgencia, idUsuario, dFechaIni, dFechaFin, idMoneda);
        }

        //Recibos
        public DataTable AdRptRecibos( DateTime dFechaOpe, int idUsuario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDetRecibos_Sp", dFechaOpe, idUsuario, idAgencia);
        }
		//detalle de operaciones de trasferencias
        public DataTable ADDetallOpeTrasferencias(DateTime dFecha, int idUsuario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptDetalleOpeTransf_Sp", dFecha, idUsuario, idAgencia);
        }
        //detalle de interes devengado bancos
        public DataTable ADInteresDevengadoBanco(DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptIntDevengadoBancos_Sp", dFecha);
        }
		//Saldo caja chica
        public DataTable ADSaldosCajaChica(int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptSaldosCajaChica_Sp", idAgencia, dFechaIni, dFechaFin);
        }
        //Saldo caja chica
        public DataTable ADRptListaIniCierreOpe(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,string cEstCie)
        {
            return new clsGENEjeSP().EjecSP("CAJ_ListaInicioOperaciones_SP",  dFechaIni, dFechaFin, idAgencia,cEstCie);
        }
        //Saldo libro caja boveda con billetaje
        public DataTable ADRptListaLibroCajBov(int idAgencia, DateTime dFechaOpe)
        {
            return new clsGENEjeSP().EjecSP("CAJ_BillLibroCajaBov_SP", dFechaOpe, idAgencia);
        }
        //lista las activaciones de billetaje y caja
        public DataTable ADRptListaActivaCajBill(int idAgencia, DateTime dFechaIni, DateTime dFechaFin, int idColaboradorSol,int idColaboradorAut)
        {
            return new clsGENEjeSP().EjecSP("CAJ_rptActivaCajBill_SP", idAgencia, dFechaIni, dFechaFin, idColaboradorSol, idColaboradorAut);
        }
        //lista los colaboradores de  activaciones de billetaje y caja
        public DataTable ADRptListaColaboradorActivaCajBill(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,int idOpcion)
        {
            return new clsGENEjeSP().EjecSP("CAJ_ListaColaboradorActCaja_SP", idAgencia, dFechaIni, dFechaFin, idOpcion);
        }
        //Habilitaciones con billetaje
        public DataTable AdRptHabilitacionesBill(DateTime dFecIni, DateTime dFecFin, int idUsuario, int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("CAJ_ListaBillHab_SP", dFecIni, dFecFin, idUsuario, idAgencia);
        }
        //lista historico de responsables de caja 
        public DataTable ADRptListaResponsableCaja(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,DateTime dFecOpe)
        {
            return new clsGENEjeSP().EjecSP("CAJ_RptResponsableCaja_SP", idAgencia, dFechaIni, dFechaFin, dFecOpe);
        }
        //lista reasignacion de caja 
        public DataTable ADRptListaReasignacionCaja( DateTime dFechaIni, DateTime dFechaFin,int idAgencia)
        {
            return new clsGENEjeSP().EjecSP("Caj_RptReasignacionCaja_SP", dFechaIni, dFechaFin, idAgencia);
        }
        //lista reasignacion de caja 
        public DataTable ADRptReporteEfectivoBCRCaja(DateTime dFecha, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CAJ_ReporteEfectivoBCR_SP", dFecha, idMoneda);
        }
        //Conciliación bancos
        public DataTable ADConciliaBancos(DateTime dFecIni, DateTime dFecFin, Boolean lPendiente)
        {
            return new clsGENEjeSP().EjecSP("CAJ_ConciliaBanco_sp", dFecIni, dFecFin, lPendiente);
        }
    }
}
   