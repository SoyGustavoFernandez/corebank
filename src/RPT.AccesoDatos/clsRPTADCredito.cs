using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SolIntEls.GEN.Helper;

namespace RPT.AccesoDatos
{
    public class clsRPTADCredito
    {
        clsGENEjeSP objejecuta = new clsGENEjeSP();

        public DataTable ADDatosCuenta(int idCuenta)
        {
            return objejecuta.EjecSP("CRE_DatCuenta_sp", idCuenta);
        }
        public DataTable ADCarteraVencida(int idAgencia, DateTime dfecha)
        {
            return objejecuta.EjecSP("Rpt_SaldosAnalistas_sp", idAgencia, dfecha);
        }
        public DataTable ADCarteraTotal(int idAgencia, DateTime dfecha)
        {
            return objejecuta.EjecSP("Rpt_SaldosAnalistasTotal_sp", idAgencia, dfecha);
        }
        public DataTable ADDesembolso(int idAgencia, int idTipCli, DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ClienteDesembolsado_sp", idAgencia, idTipCli, dFecIni, dFecFin);
        }
        public DataTable ADTotalDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_Desembolso_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADConsolidadoDesembolso(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("CNT_Desembolsos_sp", dFecIni, dFecFin);
        }
        public DataTable ADConsolidadoDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("CNT_DesembolsosAge_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADCarteraVigente(string cIdAsesores)
        {
            return objejecuta.EjecSP("CRE_LisCreCliVig_SP", cIdAsesores);
        }
        public DataTable ADCarteraVigente(string cIdAsesores, DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_LisCreVigPas_sp", cIdAsesores, dFecha);
        }
        public DataTable ADCancelados(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_DetalleCancelados_sp", idAgencia, dFecIni, dFecFin);
        }
        public DataTable ADOperacionesCredito(DateTime dFecha, int idAgencia, int idUsuario)
        {
            return objejecuta.EjecSP("RPT_DetCobDesembolsos_sp", dFecha, idAgencia, idUsuario);
        }
        public DataTable ADSolicitudesPendientes()
        {
            return objejecuta.EjecSP("RPT_SoliPendienteConsolidado_sp");
        }
        public DataTable ADSolicitudesPendientes(int idAgencia)
        {
            return objejecuta.EjecSP("RPT_SoliPendiente_sp", idAgencia);
        }
        public DataTable ADHistCredCliente(int idCliente)
        {
            return objejecuta.EjecSP("CRE_HistCredCli_SP", idCliente);
        }
        public DataTable ADCalificCredClient(int idCliente)
        {
            return objejecuta.EjecSP("CRE_CalifCrexCli_SP", idCliente);
        }
        public DataSet ADReporte14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("CRE_Reporte14_sp", dFecha, cCodSBS, cAnexo);
        }
        public DataTable ADAnexo03(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_Anexo3_sp", dFecha);
        }
        public DataTable ADAnexo10(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_Anexo10_sp", dFecha);
        }
        public DataTable ADAnexo01A(DateTime dFecha)
        {
            return objejecuta.EjecSP("RPT_Anexo01A_sp", dFecha);
        }
        public DataTable ADAnexo01B(DateTime dFecha)
        {
            return objejecuta.EjecSP("RPT_Anexo01B_sp", dFecha);
        }
        public DataTable ADValidaAnexo03(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ValidaAnexo3_sp", dFecha);
        }
        public DataTable ADSaldosCNTAnexo03(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_SaldoCNTAnexo03_sp", dFecha);
        }
        public DataTable ADReporte06(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_SaldoCNTReporte06_sp", dFecha);
        }
        public DataTable ADSaldoAnexo03(DateTime dFecha)
        {
            try
            {
                return objejecuta.EjecSP("CRE_SaldoCREAnexo03_sp", dFecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ADSaldoProducto(int idAgencia, DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_SalProductos_sp", idAgencia, dFecha);
        }
        //JUDICIALES
        public DataTable ADLiquidacionJudiciales(int idCuenta)
        {
            return objejecuta.EjecSP("CRE_LiquidacPago_SP", idCuenta);
        }

        //--=========================================================================
        //--Reporte DEL ANEXO F
        //--=========================================================================	
        public DataSet CNAnexoF(string cReporteSBS, string cAnexoSbs)
        {
            return objejecuta.DSEjecSP("RPT_AnexoF_sp", cReporteSBS, cAnexoSbs);
        }
        //--=========================================================================
        //--Reporte DEL ANEXO B
        //--=========================================================================	
        public DataSet ADAnexoB(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objejecuta.DSEjecSP("RPT_AnexoB_sp", dFecha, cReporteSBS, cAnexoSbs);
        }
        //--=========================================================================
        //--Reporte de Anexo16 B
        //--=========================================================================
        public DataSet ADDatoInicialAnexo16B(DateTime dFec)
        {
            return objejecuta.DSEjecSP("RPT_DatoInicialAnexo16B_SP", dFec);
        }
        public DataSet ADDatosContingenciaAnexo16B(DateTime dFec)
        {
            return objejecuta.DSEjecSP("RPT_DatosContingenciaAnexo16B_SP", dFec);
        }
        public DataTable ADConsultaPE(DateTime dFec)
        {
            return objejecuta.EjecSP("RPT_ConsultaPE_SP", dFec);
        }
        public DataTable ADInsertaConting(DateTime dFec, string tMN, string tME)
        {
            return objejecuta.EjecSP("RPT_InsertaContinAnexo16B_SP", dFec, tMN, tME);
        }
        public DataSet ADAnexo16BSucave(DateTime dFec, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Anexo16B_SP", dFec, cCodSBS, cAnexo);
        }
        //--=========================================================================
        //--Reporte de Anexo16
        //--=========================================================================
        public DataSet ADAnexo16(DateTime dFec, decimal nFSD, int idMoneda, decimal nPatrimonio, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Anexo16_SP", dFec, nFSD, idMoneda, nPatrimonio, cCodSBS, cAnexo);
        }
        public DataSet ADAnexoInd16(DateTime dFec, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Anexo16Ind_sp", dFec, cCodSBS, cAnexo);
        }
        public DataTable ADSaldoCartera(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_SaldoDesembolsoAse_sp", dFecha, idAgencia);
        }
        public DataTable ADSaldoCartera(DateTime dFecha)
        {
            return objejecuta.EjecSP("RPT_SaldoDesembolsoOfi_sp", dFecha);
        }
        public DataTable ADCarteraAnalistas(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_DetalleVencidos_sp", dFecha, idAgencia);
        }
        public DataTable ADMora(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor)
        {
            return objejecuta.EjecSP("RPT_CreMora_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor);
        }
        public DataTable ADIntervMora(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor)
        {
            return objejecuta.EjecSP("RPT_IntervMora_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor);
        }
        public DataTable ADSIGDesembolso(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ConsolidaDesembolso_sp", dFecIni, dFecFin);
        }
        public DataTable ADSIGDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ConsolidaDesemAse_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADSIGClientes(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ConsolidaClientes_sp", dFecIni, dFecFin);
        }
        public DataTable ADSIGClientes(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ConsolidaClientesAgencia_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADSIGSaldo(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ConsolidaSaldo_sp", dFecIni, dFecFin);
        }
        public DataTable ADSIGSaldo(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ConsolidaSaldoAgencia_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptCobranza(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_Cobranzas_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptResumenCobranza(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ResumenCobranzas_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptCobraAsesor(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ResumenCobranzasAsesor_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptConsolAmortiza(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ConsolidaAmortizacion_sp", dFecIni, dFecFin);
        }
        public DataTable ADRptAmortizaAse(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ConsolidaAmortAse_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptConsolMora(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_ConsolidaMora_sp", dFecIni, dFecFin);
        }
        public DataTable ADRptConsolMoraAge(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("RPT_ConsolidaMoraAgencia_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRptListaOperac(int idAgencia, DateTime dFecBus)
        {
            return objejecuta.EjecSP("CRE_LisOpeCre_sp", idAgencia, dFecBus);
        }
        public DataTable ADRptOperaRemotas(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("RPT_OperacionesRemotas_sp", dFecIni, dFecFin);
        }
		
		//--=========================================================================
        //--Reporte DEL ANEXO 09
        //--=========================================================================
        public DataSet ADAnexo9(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return objejecuta.DSEjecSP("RPT_Anexo9_SP", dFecha, cReporteSBS, cAnexoSbs);
        }

        //--=========================================================================
        //--Reporte DEL ANEXO 12 Deuda Subordinada
        //--=========================================================================
        public DataSet ADAnexo12_I(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Anexo12I_sp", dFecha, cCodSBS, cAnexo);
        }

        public DataSet ADAnexo12II(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Anexo12II_SP", dFecha, cCodSBS, cAnexo);
        }

        //--=========================================================================
        //--Reporte 5 Demanda Moneda Extranjera
        //--=========================================================================
        public DataSet ADReporte5(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return objejecuta.DSEjecSP("RPT_Reporte5_SP", dFecha, cCodSBS, cCodAnexo);
        }

        public DataTable ADReporte502(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return objejecuta.EjecSP("RPT_Reporte502_SP", dFecha, cCodSBS, cCodAnexo);
        }

        //--=========================================================================
        //--Reporte 12 Adeudados
        //--=========================================================================
        public DataTable ADReporte12(DateTime dFecha)
        {
            return objejecuta.EjecSP("RPT_Reporte12_SP", dFecha);
        }

        //--=========================================================================
        //--Reporte Encaje 1
        //--=========================================================================
        public DataTable ADEncaje1(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return objejecuta.EjecSP("RPT_Encaje1_SP", dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //--=========================================================================
        //--Reporte Encaje 1 TXT
        //--=========================================================================
        public DataTable ADEncaje1Txt(DateTime dFecha, int idMoneda)
        {
            return objejecuta.EjecSP("RPT_Encaje1Txt_SP", dFecha, idMoneda);
        }

        //--=========================================================================
        //--Reporte Encaje 1.1 Pagina 2
        //--=========================================================================
        public DataTable ADEncaje1_1(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return objejecuta.EjecSP("RPT_Encaje1_1_SP", dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }
        public DataTable ADGuardarAnexo16(DateTime dFec)
        {
            return objejecuta.EjecSP("RPT_Anexo16Archivar_sp", dFec);
        }
        public DataTable ADRptSaldosCredito(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_SaldoCuadreContable_sp", dFecha);
        }

        //EVALUACION EMPRESARIAL
        public DataTable ADFlujoCajaVariablesPorcentuales(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_ObtenerVariablesPorcentualesEvalEmpresarial_sp", IdEvalEmpr);
        }

        public DataTable ADFlujoCajaIngresoEvalEmpresarial(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_ObtenerFlujoCajaIngresoEvalEmpresarial_sp", IdEvalEmpr);
        }
        public DataTable ADFlujoCajaEgresoEvalEmpresarial(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_ObtenerFlujoCajaEgresoEvalEmpresarial_sp", IdEvalEmpr);
        }


        public DataTable ADBalancesGeneral1erCre(int CodigoCliente)
        {
            return objejecuta.EjecSP("CRE_ObtenerBalancesGeneral1erCreEvalEmpresarial_sp", CodigoCliente);
        }
        public DataTable ADBalancesGeneralUltimoCre(int CodigoCliente)
        {
            return objejecuta.EjecSP("CRE_ObtenerBalancesGeneralUltimoCreEvalEmpresarial_sp", CodigoCliente);
        }
        public DataTable ADBalancesGeneralActualEval(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_ObtenerBalancesGeneralActualEvalEmpresarial_sp", IdEvalEmpr);
        }

        public DataTable ADEstPerdidasGananc1erCreEvalEmpresarial(int CodigoCliente)
        {
            return objejecuta.EjecSP("CRE_ObtenerEstPerdidasGananc1erCreEvalEmpresarial_sp", CodigoCliente);
        }
        public DataTable ADEstPerdidasGanancUltimoCreEvalEmpresarial(int CodigoCliente)
        {
            return objejecuta.EjecSP("CRE_ObtenerEstPerdidasGanancUltimoCreEvalEmpresarial_sp", CodigoCliente);
        }
        public DataTable ADEstPerdidasGanancActualEvalEmpresarial(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_ObtenerEstPerdidasGanancActualEvalEmpresarial_sp", IdEvalEmpr);
        }
		public DataTable ADMesesGeneradosFlujoCaja(int IdEvalEmpr)
        {
            return objejecuta.EjecSP("CRE_GeneraMesFlujoCajaEvaEmpr_sp", IdEvalEmpr);
        }
        // reportes gerenciales
        public DataTable ADMoraAgencia(DateTime dFecha)
        {
            return objejecuta.EjecSP("Rpt_MoraAgenciaTotal_sp", dFecha);
        }
        public DataTable ADMoraAnalista(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_MoraAnalista_sp", dFecha, idAgencia);
        }
        public DataTable ADMoraMoneda(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_MoraMoneda_sp", dFecha, idAgencia);
        }
        public DataTable ADDesembolsoProducto(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_DesembolsoProducto_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADDesembolsoAgencia(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("Rpt_DesembolsoAgencia_sp", dFecIni, dFecFin);
        }
        public DataTable ADDesembolsoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_DesembolsoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADSaldoPlazos(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_SaldoPlazos_sp", dFecha, idAgencia);
        }
        public DataTable ADSaldoMontos(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_SaldoMontos_sp", dFecha, idAgencia);
        }
        public DataTable ADSaldoMontosDesembolsado(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_SaldoMontosDesembolso_sp", dFecha, idAgencia);
        }
        public DataTable ADSaldoEvolutivoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_SaldoEvoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADSaldoEvolutivoCliente(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_ClienteEvoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADMoraEvolutivoAtraso(DateTime dFecIni, DateTime dFecFin, int idAgencia, int idRangoAtraso)
        {
            return objejecuta.EjecSP("Rpt_AtrasoEvoAnalista_sp", dFecIni, dFecFin, idAgencia, idRangoAtraso);
        }
        public DataTable ADIngresosAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_IngresosEvoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADRecuperaAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_RecuperaEvoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
       
        public DataTable ADRecuperaExtornoOpe(string dFecIni, string dFecFin, int idRegion, int idOficina, int idEstablecimiento,int idModulo)
        {
            return objejecuta.EjecSP("RPT_DatosExtornoOpe_sp", dFecIni, dFecFin, idRegion, idOficina, idEstablecimiento, idModulo);
        }
        public DataTable ADDatosReimpresionVoucherPersonal(string dFecIni, string dFecFin, int idRegion, int idOficina)
        {
            return objejecuta.EjecSP("RPT_DatosReimpresionVoucherPersonal_sp", dFecIni, dFecFin, idRegion, idOficina);
        }

        public DataTable ADEvolDesembolsoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_DesembolsoEvoAnalista_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADProvisiones(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptProvisiones_SP", dFecha, idAgencia);
        }
        public DataTable ADMoraProducto(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("Rpt_MoraProductoTotal_sp", dFecha, idAgencia);
        }
        //Cambio 20140904
        public DataTable ADDetalleCampania(int idProducto, decimal nPorcentaje, int nAtrasoMax, decimal nPromedioAtr)
        {
            return objejecuta.EjecSP("CRE_DetalleCampania_sp", idProducto, nPorcentaje, nAtrasoMax, nPromedioAtr);
        }
        public DataTable ADSaldoProvision(string XMLMeses)
        {
            return objejecuta.EjecSP("CRE_ReporteProvisiones_sp", XMLMeses);
        }
        public DataTable ADSaldoProvisionAnual(string XMLAnual)
        {
            return objejecuta.EjecSP("CRE_ReporteProvisionesAnu_sp", XMLAnual);
        }
        public DataTable ADSaldoContableAnual(string XMLAnual)
        {
            return objejecuta.EjecSP("CRE_ReporteVencidosAnu_sp", XMLAnual);
        }
        public DataTable ADSaldoContable(string XMLMeses)
        {
            return objejecuta.EjecSP("CRE_ReporteVencido_sp", XMLMeses);
        }
        public DataTable ADSaldodeProvision(string XMLAnual)
        {
            return objejecuta.EjecSP("CRE_ReporteProvisionAnu_sp", XMLAnual);
        }
        public DataTable ADEstructuraTipCre(DateTime dFecProceso)
        {
            return objejecuta.EjecSP("CRE_EstSaldoTipoCredito_sp", dFecProceso);
        }
        public DataTable ADVariacionTipoCred(string XMLAnual)
        {
            return objejecuta.EjecSP("CRE_VarSaldoTipoCredito_sp", XMLAnual);
        }
        public DataTable ADSaldoCalificacionTipCre(string XMLAnual)
        {
            return objejecuta.EjecSP("CRE_SaldoCarteraTipCalifica_sp", XMLAnual);
        }
        // FIN Cambio 20140904
        
		//EVALUACION CONSUMO
        public DataTable ADTarjetasCreEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_TarjetasDeCreditoEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADOtrosCreEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_OtrosCreditoEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADRefPersonalEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_RefPersonalesEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADRefLaboralEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_RefLaboralesEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_BusEvaConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADIngresosTitular(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_IngresosTitularEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADIngresosConyugue(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_IngresosConyugueEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADEgresos(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_EgresosEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADBalanceGeneral(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_BalanceGeneralEvalConsumo_Sp", IdEvalConsumo);
        }
        public DataTable ADEstPerdGananciasEvalConsumo(int IdEvalConsumo)
        {
            return objejecuta.EjecSP("Cre_EstPerdGananciasEvalConsumo_Sp", IdEvalConsumo);
        }
		public DataTable ADCondonadosCRE(DateTime dFecIni, DateTime dFecFin)
        {
            return objejecuta.EjecSP("CNT_ResumenCondonados_sp", dFecIni, dFecFin);
        }
        public DataTable ADCondonadosCRE(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("CNT_ResumenCondonadosAge_sp", dFecIni, dFecFin, idAgencia);
        }
        public DataTable ADDetalleCondonados(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return objejecuta.EjecSP("CNT_DetalleCondonados_sp", dFecIni, dFecFin, idAgencia);
        }

        public DataTable DatosSolicitudImpPPG(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_DatosSolicitudImpPPG_sp", idSolicitud);
        }
		//Mora Ubigeo
        public DataTable ADMoraUbigeo(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor,
                                        int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return objejecuta.EjecSP("RPT_CreMoraUbigeo_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor, 
                                                                    idTipoDir, idUbigeo, idTipoInterv);
        }

        public DataTable ADIntervMoraUbigeo(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor,
                                            int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return objejecuta.EjecSP("RPT_IntervMoraUbigeo_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor,
                                                                        idTipoDir, idUbigeo, idTipoInterv);
        } 

        //Mora Ubigeo
        public DataTable MoraUbigeoRecup(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cRecuperador, 
                                        int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return objejecuta.EjecSP("RPT_CreMoraUbigeoRecup_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cRecuperador, 
                                                                    idTipoDir, idUbigeo, idTipoInterv);
        }

        public DataTable IntervMoraUbigeoRecup(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cRecuperador,
                                           int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return objejecuta.EjecSP("RPT_IntervMoraUbigeoRecup_SP", nDiaMin, nDiaMax, nSalMin, nSalMax, cRecuperador,
                                                                        idTipoDir, idUbigeo, idTipoInterv);
        }
        public DataTable RptDetCobranzaRecup(DateTime dFecIni, DateTime dFecFin, int idAgencia, string cRecuperador)
        {
            return objejecuta.EjecSP("RPT_RptDetCobranzaRecup_SP", dFecIni, dFecFin, idAgencia, cRecuperador);
        }

        public DataTable ADDetallePagDsctoPlanilla(int idEntidad, int idCuenta, string cNroTrx)
        {
            return objejecuta.EjecSP("CRE_DetalleCtasPagoDctoPlanilla_SP", idEntidad, idCuenta, cNroTrx);
        }

        //Reportes sustento Contabilidad
        public DataTable ADRptSaldosDevengado(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_SaldoCuadreDevengadoContable_sp", dFecha, idAgencia);
        }
        public DataTable ADRptSaldoProvisiones(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_ProvisionesContable_sp", dFecha, idAgencia);
        }
        public DataTable ADInformeRiesgo(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objejecuta.EjecSP("GEN_GeneraInformeRiesgos_SP", dFechaIni, dFechaFin);
        }
        public DataTable ADRptSaldoGarantia(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_SaldoGarantiaContabilidad_SP", dFecha);
        }
        public DataTable ADRptSaldosSuspenso(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_SaldoCuadreSuspensoContable_sp", dFecha, idAgencia);
        }
        public DataTable ADRptSaldoCastigados(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_SaldoCastigos_sp", dFecha, idAgencia);
        }
        public DataTable ADRptColocaciones(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ReporteControlColocaciones_SP", dFecha);
        }
        public DataTable ADrptConcZonaDistrito(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcZonaDistrito_SP", dFecha);
        }

        public DataTable ADrptConcMonedaProd(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcMonedaProd_SP", dFecha);
        }
        public DataTable ADRptMoraTramoAsesor(int idAgencia, DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ReporteMoraTramoAsesor_SP", idAgencia, dFecha);
        }
        public DataTable ADrptConcOficiAsesor(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcOficiAsesor_SP", dFecha);
        }
        public DataTable ADrptConcAsesorOficina(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcAsesorOficina_Sp", dFecha);
        }
        public DataTable ADrptConcPlazo(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcPlazo_Sp", dFecha);
        }

        public DataTable ADrptConcMonto(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcMontoCred_Sp", dFecha);
        }

        public DataTable ADrptConcPromotores(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcPromotor_Sp", dFecha);
        }

        public DataTable ADrptConcActEco(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcActEco_SP", dFecha);
        }

        public DataTable ADrptConcOficiProd(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcOficiProd_SP", dFecha);
        }
        public DataTable ADrptColocPromotores(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptColocPromotor_Sp", dFecha);
        }
        public DataTable ADrptConcOficinaAsesorDistrito(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_rptConcOfiAseDist_Sp", dFecha, idAgencia);
        }

        public DataTable ADrptConcCarteraAsesorGeneral(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptConcCarteraAsesorGeneral_SP", dFecha);
        }
        public DataTable ADRptConcentCartAseTramo(int idAgencia, DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ReporteConOficinaAsesorTramoDias_SP", dFecha, idAgencia);
        }
        public DataTable ADrptCumpliMetasAsesor(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_rptCumpliMetasAsesor_SP", dFecha);
        }
        public DataTable ADrptMoraTramoPromotor(DateTime dFecha, int idagencia)
        {
            return objejecuta.EjecSP("CRE_rptMoraTramoPromotor_Sp", dFecha, idagencia);
        }
        public DataTable ADrptConcAsesorOficinaOpe(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_rptConcAsesorOficinaOpe_Sp", dFecha, idAgencia);
        }
        public DataTable ADrptsolicitud( int idsolicitud)
        {
            return objejecuta.EjecSP("CRE_RetDatosSolicitudCre_SP", idsolicitud);
        }
        public DataTable ADrptaprobador(int idsolicitud)
        {
            return objejecuta.EjecSP("CRE_BuscarAprobadorSoli_SP", idsolicitud);
        }

        public DataTable ADrptDatosFamiliar( int idcli)
        {
            return objejecuta.EjecSP("CRE_DatoSoLCliente_SP", idcli);
        }
        public DataTable ADrptDatosClienteJur(int idcli)
        {
            return objejecuta.EjecSP("CRE_DatoSoLClienteJuri_SP", idcli);
        }
        public DataTable ADrptDatosClienteVin(int idcli)
        {
            return objejecuta.EjecSP("Gen_ListaClienteVinculoSol_Sp", idcli);
        }      


     

        //--=========================================================================
        //--Reporte Encaje 5
        //--=========================================================================
        public DataTable ADEncaje5(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return objejecuta.EjecSP("RPT_Encaje5_SP", dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //--=========================================================================
        //--Reporte Encaje 2
        //--=========================================================================
        public DataTable ADEncaje2(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return objejecuta.EjecSP("RPT_Encaje2_SP", dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //--=========================================================================
        //--Reporte Encaje 2 TXT
        //--=========================================================================
        public DataTable ADEncaje2Txt(DateTime dFecha, int idMoneda)
        {
            return objejecuta.EjecSP("RPT_Encaje2Txt_SP", dFecha, idMoneda);
        }

        //--=========================================================================
        //--Reporte Encaje 4
        //--=========================================================================
        public DataTable ADEncaje4(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return objejecuta.EjecSP("RPT_Encaje4_SP", dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //--=========================================================================
        //--Reporte Encaje 4 TXT
        //--=========================================================================
        public DataTable ADEncaje4Txt(DateTime dFecha, int idMoneda)
        {
            return objejecuta.EjecSP("RPT_Encaje4Txt_SP", dFecha, idMoneda);
        }
        
        //--=========================================================================
        //--Reporte 2 
        //--=========================================================================
        public DataSet ADReporte2A(DateTime dFecha, string cCodSBS, string cCodAnexo01, string cCodAnexo02, string cCodAnexo03)
        {
            return objejecuta.DSEjecSP("RPT_Reporte2A_sp", dFecha, cCodSBS, cCodAnexo01, cCodAnexo02, cCodAnexo03);
        }
        public DataSet ADReporte2B1An3(DateTime dFecha, string cCodSBS, string cAnexoSbs)
        {
            return objejecuta.DSEjecSP("RPT_Reporte2B1An3_sp", dFecha, cCodSBS, cAnexoSbs);
        }
        public DataSet ADReporte2B1An3II(DateTime dFecha, string cCodSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju)
        {
            return objejecuta.DSEjecSP("RPT_Reporte2B1An3_II_sp", dFecha, cCodSBS, cAnexoSbs, nLimGlo, nFacAju);
        }
        public DataSet ADReporte2C1(DateTime dFecha, string cCodSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju, decimal nPatEfeAdi)
        {
            return objejecuta.DSEjecSP("RPT_Reporte2C1_sp", dFecha, cCodSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);
        }
        public DataSet ADReporte2D(DateTime dFecha, string cCodSBS, string cAnexoSbs)
        {
            return objejecuta.DSEjecSP("RPT_Reporte2D_sp", dFecha, cCodSBS, cAnexoSbs);
        }
        public DataTable ADGenActaComiteCred(int idComite)
        {
            return objejecuta.EjecSP("CRE_GenActaComite_Sp", idComite);
        }

        public DataTable GenExcepcionesGeneradas(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_GenActaComite_Sp", idSolicitud);
        }

        public DataTable ADGenExcepcionesGeneradas(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_GenExcepcionesGEN_Sp", idSolicitud);
        }

        public DataTable ADGenActaAprobCreditos(DateTime dFecIni, DateTime dFecFin, int idNivAprobacion, int idZona, int idAgencias)
        {
            return objejecuta.EjecSP("CRE_GenActaAprobCredFecha_Sp", dFecIni, dFecFin, idNivAprobacion, idZona, idAgencias);
        }
        public DataSet ADGenActaAprobDenegCred(int idSolicitud)
        {
            DataSet dsReport = new DataSet("dsReport");
            DataTable dtDatosGenerales = objejecuta.EjecSP("CRE_GenActaAprobacionCredito_Sp", idSolicitud);
            DataTable dtDestCredSol = objejecuta.EjecSP("CRE_LisDestCredSolCred_Sp", idSolicitud);
            DataTable dtComite = objejecuta.EjecSP("CRE_DatosComiteCredSol_Sp", idSolicitud);
            DataTable dtNivAproba = objejecuta.EjecSP("CRE_LisNivAprobaSolCred_Sp", idSolicitud);
            DataTable dtIntervSolCre = objejecuta.EjecSP("CRE_LisIntervSolCre_Sp", idSolicitud);
            DataTable dtExcepciones = objejecuta.EjecSP("RPT_ListarExcepcionReglaNegocio_SP", idSolicitud);
            DataTable dtParticipantes = objejecuta.EjecSP("CRE_LstMiembrosComiteCredSol_Sp", idSolicitud);
            DataTable dtHistObs = objejecuta.EjecSP("CRE_LstObsSolApro_Sp", idSolicitud);

            dtDatosGenerales.TableName = "dtDatosGenerales";
            dtDestCredSol.TableName = "dtDestCredSol";
            dtComite.TableName = "dtComite";
            dtNivAproba.TableName = "dtNivAproba";
            dtIntervSolCre.TableName = "dtIntervSolCre";
            dtExcepciones.TableName = "dtExcepciones";
            dtParticipantes.TableName = "dtParticipantes";
            dtHistObs.TableName = "dtHistObs";

            dsReport.Tables.Add(dtDatosGenerales);
            dsReport.Tables.Add(dtDestCredSol);
            dsReport.Tables.Add(dtComite);
            dsReport.Tables.Add(dtNivAproba);
            dsReport.Tables.Add(dtIntervSolCre);
            dsReport.Tables.Add(dtExcepciones);
            dsReport.Tables.Add(dtParticipantes);
            dsReport.Tables.Add(dtHistObs);

            return dsReport;
        }

        public DataTable ADGenReasignacionesCred(string idAge, string idUsu, DateTime dFecIni, DateTime dFecFin)
        {
            DataTable datos = objejecuta.EjecSP("CRE_LisCreReasignaciones_SP", idAge, idUsu, dFecIni, dFecFin);
            return datos;
        }

        public DataTable ADBNDesembolso(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ReporteDesembolsoBN_sp", dFecha);
        }
        public DataTable ADBNCobranza(DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_ReporteCobranzaBN_sp", dFecha);
        }

        #region Sistema de Información Gerencial

        public DataTable ADRpt001(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptSIGCarteraDesembolsoMoraCliente_SP", dFecha, idAgencia);
        }

        public DataTable ADRpt001Hist(DateTime dFecha, int idAgencia, int idZona = 0, int idUsuario = 0, bool lEnLinea = false, bool lImprimir = true)
        {
            return objejecuta.EjecSP("CRE_RptSIGCarteraDesembolsoMoraClienteHisto_SP", dFecha, idAgencia, idZona, idUsuario, lEnLinea, lImprimir);
        }

        public DataTable ADRpt001HistIni(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptSIGCarteraDesembolsoMoraClienteHistoPuntoIni_SP", dFecha, idAgencia);
        }

        public DataTable ADRpt002(DateTime dFecha, int idAgencia, int idCalificacion)
        {
            return objejecuta.EjecSP("CRE_SIGProvisiones_SP", dFecha, idAgencia, idCalificacion);
        }

        public DataTable ADRpt003(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptSIGTramosPorLiberar_SP", dFecha, idAgencia);
        }

        public DataTable ADRptAvanceMoraTramoAsesor(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptAvanceMoraTramoAsesor_Sp", dFecha, idAgencia);
        }

        public DataTable ADRptLibEfectRecup(DateTime dFecha, int idAgencia)
        {
            return objejecuta.EjecSP("CRE_RptEfectividadLiberacionRecuperacion_Sp", dFecha, idAgencia);
        }

        public DataSet rptComiteCreditoDetallado(int idZona, int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return objejecuta.DSEjecSP("CRE_RptComiteCreditoDetallado_SP", idZona, idAgencia, dFechaInicio, dFechaFin);
        }

        #endregion
        public DataSet retornarLimGlobalIndividualAnexo13(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return objejecuta.DSEjecSP("CLI_RptControlLimGloAnexo13_sp", dFecha, cCodSBS, cAnexo);
        }

        public DataTable ADActualizaSIGOnline(int idUsuario, int idEstadoInicio)
        {
            return objejecuta.EjecSP("CRE_InicioYFinSIGOnline_SP", idUsuario, idEstadoInicio);
        }

        public DataTable ADDatosScore(int idsolicitud)
        {
            return objejecuta.EjecSP("CRE_DatosScoreCredito_SP", idsolicitud);
        }

        public DataTable ADDatosDetalleScore(int idsolicitud)
        {
            return objejecuta.EjecSP("CRE_DatosDetalleScoreCredito_SP", idsolicitud);
        }

        public DataTable ADDatosSolicitudScore(int idSolicitud)
        {
            return objejecuta.EjecSP("CRE_RetDatosSolicitudCre_SP", idSolicitud);
        }

        public DataTable ADObtenerReportePolizaSeguroDesgravamen(int idZona, int idAgencia, int nTipoPoliza, int nTrama, DateTime dFecha)
        {
            return objejecuta.EjecSP("CRE_RptPolizaSeguroDesgravamen_SP", idZona, idAgencia, nTipoPoliza, nTrama, dFecha);
        }
        public DataTable rptMinutaGarantiaAviso(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return objejecuta.EjecSP("CRE_RptMinutaLibGarantiaAviso_SP", dFechaInicio, dFechaFin);
        }
        public DataTable ADReporteMotivoHistorico(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return objejecuta.EjecSP("CRE_RptMotivoModFech_SP", dFechaInicio, dFechaFin);
        }
    }
}
