using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADContabilidad
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADLibroDiario(DateTime dFecha, int idAsiento, int idMoneda, int idAgencia, DateTime dInicio)
        {
            return objEjeSp.EjecSP("CNT_LibroDiario_sp", dFecha, idAsiento, idMoneda, idAgencia, dInicio);
        }
        public DataTable ADBalanceGeneral(DateTime dFecha, int idMoneda, int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_ReportaBalanceGeneral_sp", dFecha, idMoneda, idAgencia);
        }
        public DataTable ADPerdidasGanancias(DateTime dFecha, int idMoneda, int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_ReportaPerdidasGanancias_sp", dFecha, idMoneda, idAgencia);
        }
        public DataTable ADBalanceComprobacion(DateTime dFecha, int idMoneda, int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_BalanceComprobacion_sp", dFecha, idMoneda, idAgencia);
        }
        public DataTable ADBalanceComprobacionSucave(DateTime dFecha, int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_BalanceComprobacionIntegrado_sp", dFecha, idMoneda);
        }
        public DataTable ADEEFF04(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.EjecSP("RPT_EEFF100_04_SP", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataTable ADBalComEEFF(DateTime dFecha, int idMoneda, int idNumDig, int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_BalComCtaActPasPat_sp", dFecha, idMoneda, idNumDig,idAgencia);
        }
        public DataTable ADBalComDigitos(DateTime dFecha, int idMoneda, int idNumDig, int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_BalComNumDig_sp", dFecha, idMoneda, idNumDig, idAgencia);
        }
        public DataTable ADAsientoTRX(DateTime dFecIni, DateTime dFecFin, int idCuenta, int idAsiento)
        {
            return objEjeSp.EjecSP("CNT_ReporteAsientoxTransacción_sp", dFecIni, dFecFin, idCuenta, idAsiento);
        }

        public DataTable ADLibroMayor(int idMoneda, DateTime dFechaInicial, DateTime dFechaFinal, int CuentaCtbIni, int CuentaCtbFin)
        {
            return new clsGENEjeSP().EjecSP("CNT_LibroMayor_sp", idMoneda, dFechaInicial, dFechaFinal, CuentaCtbIni, CuentaCtbFin);
        }
        public DataTable ADAnexo15BMN(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_Anexo15BMN_sp", dFecha);
        }
        public DataTable ADAnexo15BME(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_Anexo15BME_sp", dFecha);
        }
        public DataSet ADAnexo15C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("CNT_Anexo15C_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo15A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("CNT_Anexo15A_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo15B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("CNT_Anexo15B_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADAnexo15AOtr(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo15_OtrOpe_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte25B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte252_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte4A1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4A1_sp", dFecha, cReporteSBS, cAnexoSbs, nLimGlo);
        }
        public DataSet ADReporte4B1(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4B1_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte4B2(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4B2_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte4B3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4B3_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte4C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4C_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte4D(DateTime dFecha, string cReporteSBS, string cAnexoSbs, DateTime dFecProc)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte4D_sp", dFecha, cReporteSBS, cAnexoSbs, dFecProc);
        }
        public DataSet ADReporte25_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte25_1_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte25_III(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte25_3_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet ADReporte03(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objEjeSp.DSEjecSP("CNT_Reporte03_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataTable CNErrorAsientos(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("RPT_ListaErrorAsientos_sp", dFecIni, dFecFin);
        }

        public DataTable ADReporte03Cop(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_Reporte03Coop_sp", dFecha);
        }

        public DataTable ADAnexo15BMECop(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_Anexo15BMECoop_sp", dFecha);
        }
        public DataTable ADAnexo15BMNCop(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_Anexo15BCoop_sp", dFecha);
        }
        //----
        public DataSet ADReporte6A(DateTime dFecha,string cCodSBS,string cCodAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte6A_SP", dFecha, cCodSBS, cCodAnexo);
        }
        public DataSet ADReporte6B(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte6B_SP", dFecha, cCodSBS, cCodAnexo);
        }
        public DataTable ADReporteFormaF(DateTime dFecha, int idMoneda)
        {
            return objEjeSp.EjecSP("RPT_BalanceComprobSaldo_sp", dFecha, idMoneda);
        }
        public DataTable ADEmpleadosySocios(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_EmpleadosSocios_sp", dFecha);
        }
        public DataTable ADCalifCartera(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_CalificaCartera_sp", dFecha);
        }
        public DataTable ADProvisionProc(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_ResProvProc_sp", dFecha);
        }
        public DataTable ADCreTipoSector(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_SaldoTipoSector_sp", dFecha);
        }
        public DataTable ADSaldosCreVenc(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_SaldoVenJud_sp", dFecha);
        }
        public DataTable ADNroCreVenc(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RPT_CuoVenJud_sp", dFecha);
        }
		public DataTable ADCuadreSaldosCredito(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_ValidaSaldoCredito_sp", dFecha);
        }
        public DataTable CNReporte20A(DateTime dFecPro)
        {
            return objEjeSp.EjecSP("CRE_LisVinRieUni_Sp", dFecPro);
        }
        public DataTable CNReporte20(DateTime dFecPro)
        {
            return objEjeSp.EjecSP("RPT_Reporte20_sp", dFecPro);
        }
        public DataSet CNReporte21(DateTime dFecPro)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte21_sp", dFecPro);
        }
        public DataTable CNReporte21A(DateTime dFecPro)
        {
            return objEjeSp.EjecSP("RPT_Reporte21A_sp", dFecPro);
        }
        public DataSet ADAnexo14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo14_Sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADReporte11(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte11SBS_Sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADReporte19_I(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_reporte19_I_Sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADReporte19_II(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Reporte19_II_Sp", dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNReporte19()
        {
            return objEjeSp.EjecSP("RPT_reporte19_Sp");
        }
        public DataSet ADReporte19A(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_reporte19A_Sp", dFecha, cCodSBS, cAnexo);
        }

        public DataTable CNReporte19A2()
        {
            return objEjeSp.EjecSP("RPT_reporte19A_2_Sp");
        }

        public DataSet ADAnexo02(DateTime dFecha, string cCodSbs, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo02_Sp", dFecha, cCodSbs, cAnexo);
        }

        public DataTable ADBGFenacrep(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_ReportaBGFENACREP_sp", dFecha);
        }
        public DataTable ADLibroCaja(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb,int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_LibroCaja_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADSaldoCtaCtb(DateTime dFecha, string cCuentaCtb, int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_SaldoCtaCtb_sp", dFecha, cCuentaCtb, idMoneda);
        }
        public DataTable ADLibroBancos(DateTime dFechaInicial, DateTime dFechaFinal, int idMoneda)
        {
            return objEjeSp.EjecSP("CNT_LibroBancos_SP", dFechaInicial, dFechaFinal, idMoneda);
        }
        public DataTable ADLibroRetencion(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNT_LibroRetenciones_SP", dFechaInicial, dFechaFinal);
        }
        public DataTable ADRegCompras(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNT_RegistroCompras_SP", dFechaInicial, dFechaFinal);
        }
        public DataTable ADLibroCastigo(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNT_LibroCastigo_SP", dFechaInicial, dFechaFinal);
        }
        public DataTable ADRegVentas(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return objEjeSp.EjecSP("CNT_RegistroVentas_SP", dFechaInicial, dFechaFinal);
        }
        public DataTable ADInvBalCxC(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalCxC_sp", dFecha);
        }
        public DataTable ADInvBalCxCDiversa(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalCxCDiversa_sp", dFecha);
        }
        public DataTable ADInvBalProvision(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalProvis_sp", dFecha);
        }
        public DataTable ADInvBalProveedor(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalProveedor_sp", dFecha);
        }
        public DataTable ADInvBalAmortizacion(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalIntangible_sp", dFecha);
        }
        public DataTable ADInvBalCapital(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_LibroInvBalCapital_sp", dFecha);
        }
        // Cambio 20150223
        public DataTable ADEPGFenacrep(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_ReportaPerdidasGananciasFENACREP_sp", dFecha);
        }
        public DataTable ADListarCtaCtb(bool lIndicaSBS)
        {
            return objEjeSp.EjecSP("CNT_RptListaPlanContable_SP", lIndicaSBS);
        }
        public DataTable ADRptListaHistoricoAsiento(DateTime dFecIni, DateTime dFecFin, int nVoucher)
        {
            return objEjeSp.EjecSP("CNT_RptHistAsientoManual", dFecIni, dFecFin, nVoucher);
        }
        // Cambio 20150716
        public DataSet ADFormaF(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_PlantillaFormaB2_sp", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADAnexo13(DateTime dFecha, decimal nFSD, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo13_SP", dFecha, nFSD, cCodSBS, cAnexo);
        }
        public DataTable ADSaldoCtaCnt(DateTime dFecha, int idMoneda, string cCuenta)
        {
            return objEjeSp.EjecSP("RPT_SaldoCuentaCnt_SP", dFecha, idMoneda, cCuenta);
        }
        public DataSet ADAnexo07A(DateTime dFecha, int idMoneda, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo7_A_sp", dFecha, idMoneda, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo07C(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo7C_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo07B(DateTime dFecha, int idMoneda, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo7_B_sp", dFecha, idMoneda, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo07BC(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo7B_C_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_01(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_01_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_02(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_02_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_03(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_03_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_04(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_04_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_05(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_05_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_06(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_06_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_07(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_07_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_08(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_08_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_09(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_09_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_10(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_10_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_11(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_11_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_12(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_12_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_13(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_13_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_14_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADAnexo08_15(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_Anexo08_15_sp", dFecha, cCodSBS, cAnexo);
        }
     
        public DataTable ADRptFlujoEfectivo(DateTime dFecOpe,int idAgencia)
        {
            return objEjeSp.EjecSP("CNT_ReporteFlujoEfectivo_sp", dFecOpe, idAgencia);
        }

        public DataSet ADRptCambioPatrimonio(DateTime dFecOpe, int idAgencia, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("CNT_ReporteCambioPatrimonio_sp", dFecOpe, idAgencia, cCodSBS, cAnexo);
        }
        public DataSet ADRptFormatoEEFF_MSV_Trim(DateTime dFecOpe)
        {
            return objEjeSp.DSEjecSP("CNT_RptEEFF_MSV_Trim_sp", dFecOpe);
        }
        public DataSet ADRptFormatoEEFF_MSV_Anual(DateTime dFecOpe)
        {
            return objEjeSp.DSEjecSP("CNT_RptEEFF_MSV_Anual_sp", dFecOpe);
        }

        public DataTable ADRptEEFF_Diario(DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("CNT_RptBGFormatoDiario_sp", dFecOpe);
        }
        public DataTable ADRptRatioFinanciero(int idAgencia, DateTime dFecOpe, Boolean lDistribuido)
        {
            return objEjeSp.EjecSP("CNT_RatioFinancieroCtb_sp", idAgencia, dFecOpe, lDistribuido);
        }
        public DataTable ADMovCtaCtbEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_MovimientoCtaCtbEspecifica_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
 
        public DataTable ADMovCtaCtb(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_MovimientoCtaCtb_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADResMovCtaCtbEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenMovimientoCtaCtbEspecifica_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADResMovCtaCtb(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_ResumenMovimientoCtaCtb_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADMovCtaCtbTotal(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_MovimientoCtaCtb2_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADMovCtaCtbTotalEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return new clsGENEjeSP().EjecSP("CNT_MovimientoCtaCtb2Especifica_sp", dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable ADRptResumenCastigados(DateTime dFecIni,DateTime dFecFin,int idAgencia, int idMoneda )
        {
            return objEjeSp.EjecSP("RPT_ListaResumenCastigados_SP", dFecIni, dFecFin, idAgencia,  idMoneda);
        }
        public DataTable ADRptResumenIngresos(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objEjeSp.EjecSP("RPT_ListaResumenIngresosCNT_SP", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptResumenSaldoProvision(DateTime dFecha, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ResumenSaldoProvisionesCNT_sp", dFecha, idAgencia);
        }
        public DataTable ADRptResumenSaldoCapital(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_ResumenSaldoCapitalCNT_sp", dFecha);
        }
        public DataTable ADRptCoposicionCuentaDiferido(DateTime dFechaInI)
        {
            return objEjeSp.EjecSP("RPT_ComposicionCuentaDiferido_sp", dFechaInI);
        }
        public DataTable ADBalanceComprobacionEEFF(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CNT_BalanceComprobacionEEFF_sp", dFecha);
        }
        public DataTable ADLibroTributosPagar(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CNT_LibTributosxPagar_sp", dFechaIni, dFechaFin);
        }
        public DataTable ADLibroRemuneraionesPagar(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CNT_LibRemuneracionesXPagar_sp",  dFechaIni, dFechaFin);
        }
        /*FORMA 301*/
        public DataSet ADForma301(DateTime dFecha)
        {
            return objEjeSp.DSEjecSP("RPT_Forma301A_SP", dFecha);
        }
        public DataSet ADConsultaForma301(DateTime dFecha, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_ConsultaForma301A_SP", dFecha, cAnexo);
        }
        public DataTable ADAlmacenaForma301(DateTime dFecha, string sParteI, string sParteII, string sParteIII, string sParteIV, string sParteV, string sParteVI)
        {
            return objEjeSp.EjecSP("RPT_GrabaModificacionesForma301A_SP", dFecha, sParteI, sParteII, sParteIII, sParteIV, sParteV, sParteVI);
        }
        public DataSet ADSUCAVEForma301(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_ConsultaForma301ASUCAVE_SP", dFecha, cCodSBS, cAnexo);
        }
        public DataSet ADForma301_2(DateTime dFecha)
        {
            return objEjeSp.DSEjecSP("RPT_Forma301B_SP", dFecha);
        }
        public DataTable ADAlmacenaForma301_2(DateTime dFecha, string sParteI, string sParteII, string sParteV, string sParteVI)
        {
            return objEjeSp.EjecSP("RPT_GrabaModificacionesForma301B_SP", dFecha, sParteI, sParteII, sParteV, sParteVI);
        }
        public DataSet ADSUCAVEForma301_2(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objEjeSp.DSEjecSP("RPT_ConsultaForma301ASUCAVE_SP", dFecha, cCodSBS, cAnexo);
        }
        public DataTable ADEPGAgencias(DateTime dFecOpe, int idAgencia, Boolean lDistri)
        {
            return objEjeSp.EjecSP("CNT_EPGAgencia_sp", dFecOpe, idAgencia, lDistri);
        }
        public DataTable ADRptMontosCuentasContabilidad(DateTime dFechaIni, DateTime dFechaFin, int idCentroCostos, int idAgencia, int idEstablecimiento,
            int idProyecto, int idCentroResp, int idMoneda, int nCifras)
        {
            return objEjeSp.EjecSP("CNT_RptMontosCuentasContables_SP", dFechaIni, dFechaFin, idCentroCostos, idAgencia, idEstablecimiento, idProyecto, idCentroResp, idMoneda, nCifras);
        }
        public DataTable ADRptHistoricoCuentasContabilidad(int nAnio, int idCentroCostos, int idAgencia, int idEstablecimiento,
            int idProyecto, int idCentroResp, int idMoneda, int nCifras)
        {
            return objEjeSp.EjecSP("CNT_RptCuentasContablesHistoricoMes_SP", nAnio, idCentroCostos, idAgencia, idEstablecimiento, idProyecto, idCentroResp, idMoneda, nCifras);
        }
        public DataTable ADRptRentabilidadOficina(DateTime dFecha, int idZona, int idAgencia, bool lDistribuido, int nDigitos)
        {
            return objEjeSp.EjecSP("CNT_RptRentabilidadPorOficina_sp", dFecha, idZona, idAgencia, lDistribuido, nDigitos);
        }
        public DataTable ADRptRentabilidadOficinaHistorico(int nAnio, int idZona, int idAgencia, bool lDistribuido, int nDigitos)
        {
            return objEjeSp.EjecSP("CNT_RptRentabilidadOficinaHistorico_SP", nAnio, idZona, idAgencia, lDistribuido, nDigitos);
        }
        public DataTable ADRptRentabilidadOficinaIndicadores(DateTime dFecha, int idZona, int idAgencia, bool lDistribuido)
        {
            return objEjeSp.EjecSP("CNT_RptRentabilidadPorOficinaIndicadores_SP", dFecha, idZona, idAgencia, lDistribuido);
        }
        public DataTable CuadreCaja(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CNT_DetalleTransaccionesDescuadreCaja_sp", dFecIni, dFecFin);
        }
        public DataTable BCRAnexo01(DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("RPT_BCRAnexo01_sp", dFecOpe);
        }
        public DataTable BCRForma05(DateTime dFecOpe)
        {
            return objEjeSp.EjecSP("RPT_BCRForma05_sp", dFecOpe);
        }
        public DataTable CuadreCaja()
        {
            return objEjeSp.EjecSP("CNT_DetalleTransaccionesDescuadreCaja_sp");
        }
        public DataTable CuadreCreditos(DateTime dFecIni, DateTime dFecFin)
        {
            return objEjeSp.EjecSP("CNT_DetalleTransaccionesDescuadreCreditos_sp", dFecIni, dFecFin);
        }
    }
}
