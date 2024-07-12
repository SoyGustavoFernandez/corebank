using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPT.AccesoDatos;
using System.Data;

namespace RPT.CapaNegocio
{
    public class clsRPTCNContabilidad
    {
        clsRPTADContabilidad ADCNT = new clsRPTADContabilidad();
        public DataTable CNLibroDiario(DateTime dFecha, int idAsiento, int idMoneda, int idAgencia, DateTime dInicio)
        {
            return ADCNT.ADLibroDiario(dFecha, idAsiento, idMoneda, idAgencia, dInicio);
        }
        public DataTable CNBalanceGeneral(DateTime dFecha, int idMoneda, int idAgencia)
        {
            return ADCNT.ADBalanceGeneral(dFecha, idMoneda, idAgencia);
        }
        public DataTable CNPerdidasGanancias(DateTime dFecha, int idMoneda, int idAgencia)
        {
            return ADCNT.ADPerdidasGanancias(dFecha, idMoneda, idAgencia);
        }
        public DataTable CNBalanceComprobacion(DateTime dFecha, int idMoneda,int idAgecia)
        {
            return ADCNT.ADBalanceComprobacion(dFecha, idMoneda,idAgecia);
        }
        public DataTable CNEEFF04(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADEEFF04(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataTable CNBalanceComprobacionSucave(DateTime dFecha, int idMoneda)
        {
            return ADCNT.ADBalanceComprobacionSucave(dFecha, idMoneda);
        }
        public DataTable CNBalComEEFF(DateTime dFecha, int idMoneda, int idNumDig, int idAgencia)
        {
            return ADCNT.ADBalComEEFF(dFecha, idMoneda, idNumDig, idAgencia);
        }
        public DataTable CNBalComDigitos(DateTime dFecha, int idMoneda, int idNumDig, int idAgencia)
        {
            return ADCNT.ADBalComDigitos(dFecha, idMoneda, idNumDig, idAgencia);
        }

        public DataTable CNAsientoTRX(DateTime dFecIni, DateTime dFecFin, int idCuenta, int idAsiento)
        {
            return ADCNT.ADAsientoTRX(dFecIni, dFecFin, idCuenta, idAsiento);
        }

        public DataTable CNLibroMayor(int idMoneda, DateTime dFechaInicial, DateTime dFechaFinal, int CuentaCtbIni, int CuentaCtbFin)
        {
            return ADCNT.ADLibroMayor(idMoneda, dFechaInicial, dFechaFinal,CuentaCtbIni, CuentaCtbFin);
        }
        public DataTable CNAnexo15BMN(DateTime dFecha)
        {
            return ADCNT.ADAnexo15BMN(dFecha);
        }
        public DataTable CNAnexo15BME(DateTime dFecha)
        {
            return ADCNT.ADAnexo15BME(dFecha);
        }
        public DataSet CNAnexo15C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADAnexo15C(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo15A(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADAnexo15A(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo15B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADAnexo15B(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNAnexo15AOtr(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADAnexo15AOtr(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte25B(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte25B(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte4A1(DateTime dFecha, string cReporteSBS, string cAnexoSbs, decimal nLimGlo)
        {
            return ADCNT.ADReporte4A1(dFecha, cReporteSBS, cAnexoSbs, nLimGlo);
        }
        public DataSet CNReporte4B1(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte4B1(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte4B2(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte4B2(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte4B3(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte4B3(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte4C(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte4C(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte4D(DateTime dFecha, string cReporteSBS, string cAnexoSbs, DateTime dFecProc)
        {
            return ADCNT.ADReporte4D(dFecha, cReporteSBS, cAnexoSbs, dFecProc);
        }
        public DataSet CNReporte25_I(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte25_I(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte25_III(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte25_III(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataSet CNReporte03(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCNT.ADReporte03(dFecha, cReporteSBS, cAnexoSbs);
        }
        public DataTable CNErrorAsientos(DateTime dFecini, DateTime dFecFin)
        {
            return ADCNT.CNErrorAsientos(dFecini, dFecFin);
        }

        public DataTable CNReporte03Cop(DateTime dFecha)
        {
            return ADCNT.ADReporte03Cop(dFecha);
        }

        public DataTable CNAnexo15BMECop(DateTime dFecha)
        {
            return ADCNT.ADAnexo15BMECop(dFecha);
        }
        public DataTable CNAnexo15BMNCop(DateTime dFecha)
        {
            return ADCNT.ADAnexo15BMNCop(dFecha);
        }
        //--
        public DataSet CNReporte6A(DateTime dFecha,string cCodSBS,string cCodAnexo)
        {
            return ADCNT.ADReporte6A(dFecha, cCodSBS, cCodAnexo);
        }
        public DataSet CNReporte6B(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return ADCNT.ADReporte6B(dFecha, cCodSBS, cCodAnexo);
        }
        public DataTable CNReporteFormaF(DateTime dFecha, int idMoneda)
        {
            return ADCNT.ADReporteFormaF(dFecha, idMoneda);
        }
        public DataTable CNEmpleadosySocios(DateTime dFecha)
        {
            return ADCNT.ADEmpleadosySocios(dFecha);
        }
        public DataTable CNCalifCartera(DateTime dFecha)
        {
            return ADCNT.ADCalifCartera(dFecha);
        }
        public DataTable CNProvisionProc(DateTime dFecha)
        {
            return ADCNT.ADProvisionProc(dFecha);
        }
        public DataTable CNCreTipoSector(DateTime dFecha)
        {
            return ADCNT.ADCreTipoSector(dFecha);
        }
        public DataTable CNSaldosCreVenc(DateTime dFecha)
        {
            return ADCNT.ADSaldosCreVenc(dFecha);
        }
        public DataTable CNNroCreVenc(DateTime dFecha)
        {
            return ADCNT.ADNroCreVenc(dFecha);
        }
		public DataTable CNCuadreSaldosCredito(DateTime dFecha)
        {
            return ADCNT.ADCuadreSaldosCredito(dFecha);
        }
        public DataTable CNReporte20A(DateTime dFecPro)
        {
            return ADCNT.CNReporte20A(dFecPro);
        }
        public DataTable CNReporte20(DateTime dFecPro)
        {
            return ADCNT.CNReporte20(dFecPro);
        }
        public DataSet CNReporte21(DateTime dFecPro)
        {
            return ADCNT.CNReporte21(dFecPro);
        }
        public DataTable CNReporte21A(DateTime dFecPro)
        {
            return ADCNT.CNReporte21A(dFecPro);
        }
        public DataSet CNAnexo14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo14(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNReporte11(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADReporte11(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNReporte19_I(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADReporte19_I(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNReporte19_II(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADReporte19_II(dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNReporte19()
        {
            return ADCNT.CNReporte19();
        }

        public DataSet CNReporte19A(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADReporte19A(dFecha, cCodSBS, cAnexo);
        }

        public DataTable CNReporte19A2()
        {
            return ADCNT.CNReporte19A2();
        }

        public DataSet CNAnexo02(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo02(dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNBGFenacrep(DateTime dFecha)
        {
            return ADCNT.ADBGFenacrep(dFecha);
        }
        public DataTable CNLibroCaja(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADLibroCaja(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNSaldoCtaCtb(DateTime dFecha, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADSaldoCtaCtb(dFecha, cCuentaCtb, idMoneda);
        }
        public DataTable CNLibroBancos(DateTime dFechaInicial, DateTime dFechaFinal, int idMoneda)
        {
            return ADCNT.ADLibroBancos(dFechaInicial, dFechaFinal, idMoneda);
        }
        public DataTable CNLibroRetencion(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return ADCNT.ADLibroRetencion(dFechaInicial, dFechaFinal);
        }
        public DataTable CNRegCompras(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return ADCNT.ADRegCompras(dFechaInicial, dFechaFinal);
        }
        public DataTable CNLibroCastigo(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return ADCNT.ADLibroCastigo(dFechaInicial, dFechaFinal);
        }
        public DataTable CNRegVentas(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return ADCNT.ADRegVentas(dFechaInicial, dFechaFinal);
        }
        public DataTable CNInvBalCxC(DateTime dFecha)
        {
            return ADCNT.ADInvBalCxC(dFecha);
        }
        public DataTable CNInvBalCxCDiversa(DateTime dFecha)
        {
            return ADCNT.ADInvBalCxCDiversa(dFecha);
        }
        public DataTable CNInvBalProvision(DateTime dFecha)
        {
            return ADCNT.ADInvBalProvision(dFecha);
        }
        public DataTable CNInvBalProveedor(DateTime dFecha)
        {
            return ADCNT.ADInvBalProveedor(dFecha);
        }
        public DataTable CNInvBalAmortizacion(DateTime dFecha)
        {
            return ADCNT.ADInvBalAmortizacion(dFecha);
        }
        public DataTable CNInvBalCapital(DateTime dFecha)
        {
            return ADCNT.ADInvBalCapital(dFecha);
        }
        //Modificaciones 20150223
        public DataTable CNEPGFenacrep(DateTime dFecha)
        {
            return ADCNT.ADEPGFenacrep(dFecha);
        }
        //Modificaciones 20150716
        public DataSet CNFormaF(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADFormaF(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo13(DateTime dFecha, decimal nFSD, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo13(dFecha, nFSD, cCodSBS, cAnexo);
        }
        public DataTable CNSaldoCtaCnt(DateTime dFecha, int idMoneda, string cCuenta)
        {
            return ADCNT.ADSaldoCtaCnt(dFecha, idMoneda, cCuenta);
        }
        public DataSet CNAnexo07A(DateTime dFecha, int idMoneda, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo07A(dFecha, idMoneda, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo07C(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo07C(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo07B(DateTime dFecha, int idMoneda, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo07B(dFecha, idMoneda, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo07BC(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo07BC(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_01(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_01(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_02(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_02(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_03(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_03(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_04(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_04(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_05(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_05(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_06(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_06(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_07(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_07(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_08(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_08(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_09(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_09(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_10(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_10(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_11(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_11(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_12(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_12(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_13(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_13(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_14(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNAnexo08_15(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADAnexo08_15(dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNListaCtaCtb(bool lIndicaSBS)
        {
            DataTable dtCtaCbl= ADCNT.ADListarCtaCtb(lIndicaSBS);
            DataTable dtSoles = dtCtaCbl.Copy();
            DataTable dtDolar = dtCtaCbl.Copy();
            // dtCtaCbl.Columns["idMoneda"].ReadOnly = false;
            dtSoles.Columns["idMoneda"].ReadOnly = false;
            dtDolar.Columns["idMoneda"].ReadOnly = false;
            dtSoles.Columns["cMoneda"].ReadOnly = false;
            dtDolar.Columns["cMoneda"].ReadOnly = false;
            dtSoles.Columns["cCtaCtbFormato"].ReadOnly = false;
            dtDolar.Columns["cCtaCtbFormato"].ReadOnly = false;

            foreach (DataRow row in dtSoles.Rows)
            {
                string cCtaCtbFormato = row["cCtaCtbFormato"].ToString();
                row.SetField("idMoneda", "1");
                row.SetField("cMoneda", "MONEDA NACIONAL");
                row.SetField("cCtaCtbFormato", cObtieneCtaCbl(cCtaCtbFormato, "1"));
            }
            foreach (DataRow row in dtDolar.Rows)
            {
                string cCtaCtbFormato = row["cCtaCtbFormato"].ToString();
                row.SetField("idMoneda", "2");
                row.SetField("cMoneda", "MONEDA EXTRANJERA");
                row.SetField("cCtaCtbFormato", cObtieneCtaCbl(cCtaCtbFormato, "2"));
            }

            dtCtaCbl.Merge(dtSoles);
            dtCtaCbl.Merge(dtDolar);
            return dtCtaCbl;
        }
        public string cObtieneCtaCbl(string ctacbl, string idMoneda)
        {
            if (ctacbl.Length > 3)
            {
                ctacbl = ctacbl.Substring(0, 2) + idMoneda + ctacbl.Substring(3, ctacbl.Length - 3);
            }

            return ctacbl;

        }
        public DataTable CNRptListaHistoricoAsiento(DateTime dFecIni, DateTime dFecFin, int nVoucher)
        {
            return ADCNT.ADRptListaHistoricoAsiento(dFecIni,  dFecFin, nVoucher);
        }

        public DataTable CNRptFlujoEfectivo(DateTime dFecOpe,int idAgencia)
        {
            return ADCNT.ADRptFlujoEfectivo(dFecOpe, idAgencia);
        }
        public DataSet CNRptCambioPatrimonio(DateTime dFecOpe,int idAgencia, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADRptCambioPatrimonio(dFecOpe, idAgencia, cCodSBS, cAnexo);
        }
        public DataSet CNRptFormatoEEFF_MSV_Trim(DateTime dFecOpe)
        {
            return ADCNT.ADRptFormatoEEFF_MSV_Trim(dFecOpe);
        }
        public DataSet CNRptFormatoEEFF_MSV_Anual(DateTime dFecOpe)
        {
            return ADCNT.ADRptFormatoEEFF_MSV_Anual(dFecOpe);
        }

        public DataTable CNRptEEFF_Diario(DateTime dFecOpe)
        {
            return ADCNT.ADRptEEFF_Diario(dFecOpe);
        }

        public DataTable CNRptRatioFinanciero(int idAgencia, DateTime dFecOpe, Boolean lDistribuido)
        {
            return ADCNT.ADRptRatioFinanciero(idAgencia, dFecOpe, lDistribuido);
        }
        public DataTable CNMovCtaCtbEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADMovCtaCtbEspecifica(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }

        public DataTable CNMovCtaCtb(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADMovCtaCtb(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNResMovCtaCtbEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADResMovCtaCtbEspecifica(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNResMovCtaCtb(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADResMovCtaCtb(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNMovCtaCtbTotalEspecifica(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADMovCtaCtbTotalEspecifica(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNMovCtaCtbTotal(DateTime dFechaInicial, DateTime dFechaFinal, string cCuentaCtb, int idMoneda)
        {
            return ADCNT.ADMovCtaCtbTotal(dFechaInicial, dFechaFinal, cCuentaCtb, idMoneda);
        }
        public DataTable CNRptResumenCastigadosCNT(DateTime dFecIni, DateTime dFecFin, int idAgencia, int idMoneda)
        {
            return ADCNT.ADRptResumenCastigados(dFecIni, dFecFin, idAgencia, idMoneda);
        }
        public DataTable CNRptResumenIngresosCNT(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCNT.ADRptResumenIngresos(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptResumenSaldoProvisionCNT(DateTime dFecha, int idAgencia)
        {
            return ADCNT.ADRptResumenSaldoProvision(dFecha, idAgencia);
        }
        public DataTable CNRptResumenSaldoCapitalCNT(DateTime dFecha)
        {
            return ADCNT.ADRptResumenSaldoCapital(dFecha);
        }
        public DataTable CNRptCoposicionCuentaDiferido(DateTime dFechaInI)
        {
            return ADCNT.ADRptCoposicionCuentaDiferido(dFechaInI);
        }
        public DataTable CNBalanceComprobacionEEFF(DateTime dFecha)
        {
            return ADCNT.ADBalanceComprobacionEEFF(dFecha);
        }
        public DataTable CNLibroTributosPagar(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCNT.ADLibroTributosPagar(dFecIni, dFecFin);
        }
        public DataTable CNLibroRemuneracionPagar(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCNT.ADLibroRemuneraionesPagar(dFecIni, dFecFin);
        }
        /*FORMA 301*/
        public DataSet CNForma301(DateTime dFecha)
        {
            return ADCNT.ADForma301(dFecha);
        }
        public DataSet CNConsultaForma301(DateTime dFecha, string cAnexo)
        {
            return ADCNT.ADConsultaForma301(dFecha, cAnexo);
        }
        public DataTable CNAlmacenaForma301(DateTime dFecha, string sParteI, string sParteII, string sParteIII, string sParteIV, string sParteV, string sParteVI)
        {
            return ADCNT.ADAlmacenaForma301(dFecha, sParteI, sParteII, sParteIII, sParteIV, sParteV, sParteVI);
        }
        public DataSet CNSUCAVEForma301(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCNT.ADSUCAVEForma301(dFecha, cCodSBS, cAnexo);
        }
        public DataSet CNForma301_2(DateTime dFecha)
        {
            return ADCNT.ADForma301_2(dFecha);
        }
        public DataTable CNAlmacenaForma301_2(DateTime dFecha, string sParteI, string sParteII, string sParteV, string sParteVI)
        {
            return ADCNT.ADAlmacenaForma301_2(dFecha, sParteI, sParteII, sParteV, sParteVI);
        }
        public DataTable CNEPGAgencias(DateTime dFecOpe, int idAgencia, Boolean lDistri)
        {
            return ADCNT.ADEPGAgencias(dFecOpe, idAgencia, lDistri);
        }
        public DataTable CNRptMontosCuentasContabilidad(DateTime dFechaIni, DateTime dFechaFin, int idCentroCostos, int idAgencia, int idEstablecimiento,
            int idProyecto, int idCentroResp, int idMoneda, int nCifras)
        {
            return ADCNT.ADRptMontosCuentasContabilidad(dFechaIni, dFechaFin, idCentroCostos, idAgencia, idEstablecimiento, idProyecto, idCentroResp, idMoneda, nCifras);
        }
        public DataTable CNRptHistoricoCuentasContabilidad(int nAnio, int idCentroCostos, int idAgencia, int idEstablecimiento,
            int idProyecto, int idCentroResp, int idMoneda, int nCifras)
        {
            return ADCNT.ADRptHistoricoCuentasContabilidad(nAnio, idCentroCostos, idAgencia, idEstablecimiento, idProyecto, idCentroResp, idMoneda, nCifras);
        }
        public DataTable CNRptRentabilidadOficina(DateTime dFecha, int idZona, int idAgencia, bool lDistribuido, int nDigitos)
        {
            return ADCNT.ADRptRentabilidadOficina(dFecha, idZona, idAgencia, lDistribuido, nDigitos);
        }
        public DataTable CNRptRentabilidadOficinaHistorico(int nAnio, int idZona, int idAgencia, bool lDistribuido, int nDigitos)
        {
            return ADCNT.ADRptRentabilidadOficinaHistorico(nAnio, idZona, idAgencia, lDistribuido, nDigitos);
        }
        public DataTable CNRptRentabilidadOficinaIndicadores(DateTime dFecha, int idZona, int idAgencia, bool lDistribuido)
        {
            return ADCNT.ADRptRentabilidadOficinaIndicadores(dFecha, idZona, idAgencia, lDistribuido);
        }
        public DataTable CuadreCaja(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCNT.CuadreCaja(dFecIni, dFecFin);
        }
        public DataTable BCRAnexo01(DateTime dFecOpe)
        {
            return ADCNT.BCRAnexo01(dFecOpe);
        }
        public DataTable BCRForma05(DateTime dFecOpe)
        {
            return ADCNT.BCRForma05(dFecOpe);
        }
         public DataTable CuadreCaja()
        {
            return ADCNT.CuadreCaja();
        }
        public DataTable CuadreCreditos(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCNT.CuadreCreditos(dFecIni, dFecFin);
        }
    }
}
