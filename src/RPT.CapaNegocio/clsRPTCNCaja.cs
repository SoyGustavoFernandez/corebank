using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNCaja
    {
        clsRPTADCaja ADCaja = new clsRPTADCaja();
        public DataTable CNCorteFracc(DateTime dFecha, int idUsuario, int idAgencia,int idTipResCaj)
        {
            return ADCaja.ADCorteFracc(dFecha, idUsuario, idAgencia, idTipResCaj);
        }
        public DataTable CNDetalleHabilita(DateTime dFecha, int idUsuario, int idAgencia)
        {
            return ADCaja.ADDetalleHabilita(dFecha, idUsuario, idAgencia);
        }
        public DataTable CNDetalleRecibos(DateTime dFecha, int idUsuario, int idAgencia)
        {
            return ADCaja.ADDetalleRecibos(dFecha, idUsuario, idAgencia);
        }
        public DataTable CNResumenOpeSol(DateTime dFecha, int idUsuario, int idAgencia, int idTipOpeCaj,int idMoneda)
        {
            return ADCaja.ADResumenOpeSol(dFecha, idUsuario, idAgencia,idTipOpeCaj, idMoneda);
        }
  
        public DataTable CNDetallOperaciones(DateTime dFecha, int idUsuario, int idAgencia,int idTipResCaj)
        {
            return ADCaja.ADDetallOperaciones(dFecha, idUsuario, idAgencia, idTipResCaj);
        }
        public DataTable CNConRecibos(string idAge, string idUsu, DateTime dFecIni, DateTime dFecFin, string idMon, string idConcep)
        {
            return ADCaja.ADConRecibos(idAge, idUsu, dFecIni, dFecFin, idMon, idConcep);
        }

        public DataTable CNSaldoEnLinea(DateTime dFechaDesde, DateTime dFechaHasta, int idAgencia, Decimal nLimPor, Int32 idZona)
        {
            return ADCaja.ADSaldoEnLinea(dFechaDesde, dFechaHasta, idAgencia, nLimPor, idZona);
        }
        public DataTable CNExtractoBcos(int idCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADCaja.ADExtractoBcos(idCtaBco, dFechaIni, dFechaFin);
        }
        public DataTable CNExtractoBcosResumen(int idCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADCaja.ADExtractoBcosResumen(idCtaBco, dFechaIni, dFechaFin);
        }
        public DataTable CNLibroAuxilarBcos(string cIdCtaBco, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADCaja.ADLibroAuxilarBcos(cIdCtaBco,dFechaIni,dFechaFin);
        }
        public DataTable CNDatosBco(int idCtaBco)
        {
            return ADCaja.ADDatosBco(idCtaBco);
        }
        public DataTable CNDetCajChica(int idResp, int idCajChica, int nNroCajChica, int EstadoCpg)
        {
            return ADCaja.ADDetCajChica(idResp, idCajChica, nNroCajChica, EstadoCpg);
        }
        public DataTable CNDatosCajChica(int idCajChica, int nNroCajChica)
        {
            return ADCaja.ADDatosCajChica(idCajChica,nNroCajChica);
        }
        public DataTable CNDetChequeBco(int idCtaBco, string idEstado,DateTime dFechaIni,DateTime dFechaFin)
        {
            return ADCaja.ADDetChequeBco(idCtaBco, idEstado, dFechaIni, dFechaFin);
        }
        public DataTable CNRepMensualAdeudado(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ADCaja.AdRepMensualAdeudado(dFechaInicio, dFechaFin);
        }
        public DataTable CNRepMEFCreditoAdeudado(DateTime dFechaProceso)
        {
            return ADCaja.AdRepMEFCreditoAdeudado(dFechaProceso);

        }
        public DataTable CNRepMEFDesembolsoAdeudado(DateTime dFechaProceso)
        {
            return ADCaja.AdRepMEFDesembolsoAdeudado(dFechaProceso);

        }
        public DataTable CNRepMEFPagoAdeudado(DateTime dFechaProceso)
        {
            return ADCaja.AdRepMEFPagoAdeudado(dFechaProceso);

        }
        public DataTable CNRepMEFCalendarioAdeudado(DateTime dFechaProceso)
        {
            return ADCaja.AdRepMEFCalendarioAdeudado(dFechaProceso);
        }  

		//Habilitaciones
        public DataTable CNRptHabilitaciones(DateTime dFecIni, DateTime dFecFin, int idUsuario, int idAgencia)
        {
            return ADCaja.AdRptHabilitaciones(dFecIni, dFecFin, idUsuario, idAgencia);
        }
		
        //CobroRec
        public DataTable CNRptCobroRec(int idAgencia, int idUsuario, DateTime dFechaIni, DateTime dFechaFin, int idMoneda, string cidConcepto)
        {
            return ADCaja.AdRptCobroRec(idAgencia, idUsuario, dFechaIni, dFechaFin, idMoneda, cidConcepto);
        }

        //ResumenRec
        public DataTable CNRptResumenRec(int idAgencia, DateTime dFechaIni, DateTime dFechaFin, int IdTipoRecibo, string idConcepto,int idMoneda)
        {
            return ADCaja.AdRptResumenRec(idAgencia, dFechaIni, dFechaFin, IdTipoRecibo, idConcepto, idMoneda);
        }

        //Recibos Sobrantes faltantes
        public DataTable CNRptRecSobFal(int idAgencia, int idUsuario, DateTime dFechaIni, DateTime dFechaFin, int idMoneda)
        {
            return ADCaja.AdRptRecSobFal(idAgencia, idUsuario, dFechaIni, dFechaFin, idMoneda);
        }

        //Recibos
        public DataTable CNRptRecibos(DateTime dFechaOpe, int idUsuario, int idAgencia)
        {
            return ADCaja.AdRptRecibos(dFechaOpe, idUsuario, idAgencia);
        }
		//detalle de operaciones de trasferencias
        public DataTable CNDetallOpeTrasferencias(DateTime dFecha, int idUsuario, int idAgencia)
        {
            return ADCaja.ADDetallOpeTrasferencias(dFecha, idUsuario, idAgencia);
        }
        //detalle de interes devengado bancos
        public DataTable CNInteresDevengadoBancos(DateTime dFecha)
        {
            return ADCaja.ADInteresDevengadoBanco(dFecha);
        }
		//Saldo caja chica
		public DataTable CNSaldosCajaChica(int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADCaja.ADSaldosCajaChica(idAgencia, dFechaIni, dFechaFin);
        }
        ////Lista movimiento de boveda
        //public DataTable CNSaldosMovBoveda(DateTime dFechaOpe, int idAgencia)
        //{
        //    return ADCaja.ADSaldosMovBoveda(dFechaOpe, idAgencia);
        //}

        //lista el incio y cierre de los operadores por agencia.
        public DataTable CNRptListaIniCierreOpe(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,string cEstCie)
        {
            return ADCaja.ADRptListaIniCierreOpe(idAgencia, dFechaIni, dFechaFin, cEstCie);
        }
        //lista el incio y cierre de los operadores por agencia.
        public DataTable CNRptListaLibroCajBov(int idAgencia, DateTime dFechaOpe )
        {
            return ADCaja.ADRptListaLibroCajBov(idAgencia, dFechaOpe);
        }
        //lista las activaciones de billetaje y caja
        public DataTable CNRptListaActivaCajBill(int idAgencia, DateTime dFechaIni, DateTime dFechaFin, int idColaboradorSol,int idColaboradorAut)
        {
            return ADCaja.ADRptListaActivaCajBill(idAgencia, dFechaIni, dFechaFin, idColaboradorSol, idColaboradorAut);
        }
        //lista los colaboradorede de activaciones de billetaje y caja
        public DataTable CNRptListaColaboradorActivaCajBill(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,int idOpcion)
        {
            return ADCaja.ADRptListaColaboradorActivaCajBill(idAgencia, dFechaIni, dFechaFin, idOpcion);
        }

        //Habilitaciones con billetaje
        public DataTable CNRptHabilitacionesBill(DateTime dFecIni, DateTime dFecFin, int idUsuario, int idAgencia)
        {
            return ADCaja.AdRptHabilitacionesBill(dFecIni, dFecFin, idUsuario, idAgencia);
        }
        //lista historico de responsables de caja
        public DataTable CNRptListaResponsableCaja(int idAgencia, DateTime dFechaIni, DateTime dFechaFin,DateTime dFecOpe)
        {
            return ADCaja.ADRptListaResponsableCaja(idAgencia, dFechaIni, dFechaFin, dFecOpe);
        }
        //lista reasignacion de caja
        public DataTable CNRptListaReasignacionCaja(DateTime dFechaIni, DateTime dFechaFin, int idAgencia)
        {
            return ADCaja.ADRptListaReasignacionCaja(dFechaIni, dFechaFin, idAgencia);
        }
        //lista reporte BCR
        public DataTable CNRptReporteEfectivoBCRCaja(DateTime dFecha, int idMoneda)
        {
            return ADCaja.ADRptReporteEfectivoBCRCaja(dFecha, idMoneda);
        }
        //Conciliación bancos
        public DataTable CNConciliaBancos(DateTime dFecIni, DateTime dFecFin, Boolean lPendiente)
        {
            return ADCaja.ADConciliaBancos(dFecIni, dFecFin, lPendiente);
        }
    }
}
