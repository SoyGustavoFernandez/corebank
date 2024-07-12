using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RPT.AccesoDatos;
namespace RPT.CapaNegocio
{
    public class clsRPTCNCredito
    {
        clsRPTADCredito ADCuenta = new clsRPTADCredito();

        public DataTable CNDatosCuenta(int idCuenta)
        {
            return ADCuenta.ADDatosCuenta(idCuenta);
        }
        public DataTable CNCarteraVencida(int idAgencia, DateTime dFecha)
        {
            return ADCuenta.ADCarteraVencida(idAgencia, dFecha);
        }
        public DataTable CNCarteraTotal(int idAgencia, DateTime dFecha)
        {
            return ADCuenta.ADCarteraTotal(idAgencia, dFecha);
        }
        public DataTable CNDesembolso(int idAgencia, int idTipCli, DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADDesembolso(idAgencia, idTipCli, dFecIni, dFecFin);
        }
        public DataTable CNTotalDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADTotalDesembolso(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNConsolidadoDesembolso(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADConsolidadoDesembolso(dFecIni, dFecFin);
        }
        public DataTable CNConsolidadoDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADConsolidadoDesembolso(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNCarteraVigente(string cIdAsesores)
        {
            return ADCuenta.ADCarteraVigente(cIdAsesores);
        }
        public DataTable CNCarteraVigente(string cIdAsesores, DateTime dFecha)
        {
            return ADCuenta.ADCarteraVigente(cIdAsesores, dFecha);
        }
        public DataTable CNCancelados(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADCancelados(idAgencia, dFecIni, dFecFin);
        }
        public DataTable CNOperacionesCredito(DateTime dFecha, int idAgencia, int idUsuario)
        {
            return ADCuenta.ADOperacionesCredito(dFecha, idAgencia, idUsuario);
        }
        public DataTable CNSolicitudesPendientes()
        {
            return ADCuenta.ADSolicitudesPendientes();
        }
        public DataTable CNSolicitudesPendientes(int idAgencia)
        {
            return ADCuenta.ADSolicitudesPendientes(idAgencia);
        }
        public DataTable CNHistCredCliente(int idCliente)
        {
            return ADCuenta.ADHistCredCliente(idCliente);
        }
        public DataTable CNCalificCredClient(int idCliente)
        {
            return ADCuenta.ADCalificCredClient(idCliente);
        }
        // Modificaciones
        public DataSet CNReporte14(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADReporte14(dFecha, cCodSBS, cAnexo);
        }
        public DataTable CNAnexo03(DateTime dFecha)
        {
            return ADCuenta.ADAnexo03(dFecha);
        }
        public DataTable CNAnexo10(DateTime dFecha)
        {
            return ADCuenta.ADAnexo10(dFecha);
        }
        public DataTable ADAnexo01A(DateTime dFecha)
        {
            return ADCuenta.ADAnexo01A(dFecha);
        }
        public DataTable ADAnexo01B(DateTime dFecha)
        {
            return ADCuenta.ADAnexo01B(dFecha);
        }
        public DataTable CNValidaAnexo03(DateTime dFecha)
        {
            return ADCuenta.ADValidaAnexo03(dFecha);
        }
        public DataTable CNSaldosCNTAnexo03(DateTime dFecha)
        {
            return ADCuenta.ADSaldosCNTAnexo03(dFecha);
        }
        public DataTable CNReporte06(DateTime dFecha)
        {
            return ADCuenta.ADReporte06(dFecha);
        }

        public DataTable CNSaldoAnexo03(DateTime dFecha)
        {
            try
            {
                return ADCuenta.ADSaldoAnexo03(dFecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CNSaldoProducto(int idAgencia, DateTime dFecha)
        {
            return ADCuenta.ADSaldoProducto(idAgencia, dFecha);
        }
        //JUDICIALES
        public DataTable CNLiquidacionJudiciales(int idCuenta)
        {
            return ADCuenta.ADLiquidacionJudiciales(idCuenta);
        }
        //--=========================================================================
        //--Reporte DEL ANEXO F
        //--=========================================================================
        #region Reporte DEL ANEXO F
        public DataSet CNAnexoF(string cReporteSBS, string cAnexoSbs)
        {
            return ADCuenta.CNAnexoF(cReporteSBS, cAnexoSbs);
        }
        #endregion
        //--=========================================================================
        //--=========================================================================
        //--Reporte DEL ANEXO B
        //--=========================================================================
        #region Reporte DEL ANEXO B
        public DataSet CNAnexoB(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCuenta.ADAnexoB(dFecha, cReporteSBS, cAnexoSbs);
        }
        #endregion
        //--=========================================================================
        //--Reporte de Anexo16B 
        //--=========================================================================
        #region Reporte de Anexo16B

        public DataSet CNAnexo16B(DateTime dFec)
        {
            return ADCuenta.ADDatoInicialAnexo16B(dFec);
        }
        public DataSet CNDatosContingenciaAnexo16B(DateTime dFec)
        {
            return ADCuenta.ADDatosContingenciaAnexo16B(dFec);
        }
        public DataTable CNConsultaPE(DateTime dFec)
        {
            return ADCuenta.ADConsultaPE(dFec);
        }
        public DataTable CNInsertaConting(DateTime dFec, string tMN, string tME)
        {
            return ADCuenta.ADInsertaConting(dFec, tMN, tME);
        }
        public DataSet CNAnexo16BSucave(DateTime dFec, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADAnexo16BSucave(dFec, cCodSBS, cAnexo);
        }
        #endregion
        //--=========================================================================
        //--Reporte de Anexo16
        //--=========================================================================

        #region Reporte de Anexo16

        public DataSet CNAnexo16(DateTime dFec, decimal nFSD, int idMoneda, decimal nPatrimonio, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADAnexo16(dFec, nFSD, idMoneda, nPatrimonio, cCodSBS, cAnexo);
        }
        public DataSet CNAnexoInd16(DateTime dFec, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADAnexoInd16(dFec, cCodSBS, cAnexo);
        }

        #endregion

        public DataTable CNSaldoCartera(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADSaldoCartera(dFecha, idAgencia);
        }
        public DataTable CNSaldoCartera(DateTime dFecha)
        {
            return ADCuenta.ADSaldoCartera(dFecha);
        }
        public DataTable CNCarteraAnalistas(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADCarteraAnalistas(dFecha, idAgencia);
        }
        public DataTable CNIntervMora(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor)
        {
            return ADCuenta.ADIntervMora(nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor);
        }
        public DataTable CNSIGDesembolso(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADSIGDesembolso(dFecIni, dFecFin);
        }
        public DataTable CNSIGDesembolso(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADSIGDesembolso(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNSIGClientes(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADSIGClientes(dFecIni, dFecFin);
        }
        public DataTable CNSIGClientes(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADSIGClientes(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNSIGSaldo(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADSIGSaldo(dFecIni, dFecFin);
        }
        public DataTable CNSIGSaldo(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADSIGSaldo(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNMora(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor)
        {
            return ADCuenta.ADMora(nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor);
        }
        public DataTable CNRptCobranza(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRptCobranza(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptResumenCobranza(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRptResumenCobranza(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptCobraAsesor(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRptCobraAsesor(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptConsolAmortiza(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADRptConsolAmortiza(dFecIni, dFecFin);
        }
        public DataTable CNRptAmortizaAse(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRptAmortizaAse(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptConsolMora(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADRptConsolMora(dFecIni, dFecFin);
        }
        public DataTable CNRptConsolMoraAge(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRptConsolMoraAge(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRptListaOperac(int idAgencia, DateTime dFecBus)
        {
            return ADCuenta.ADRptListaOperac(idAgencia, dFecBus);
        }
        public DataTable CNRptOperaRemotas(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADRptOperaRemotas(dFecIni, dFecFin);
        }
        //=====================================================================
        //--Anexo 09
        //=====================================================================
        public DataSet CNAnexo9(DateTime dFecha, string cReporteSBS, string cAnexoSbs)
        {
            return ADCuenta.ADAnexo9(dFecha, cReporteSBS, cAnexoSbs);
        }

        //=====================================================================
        //--Anexo 12-II Deuda Subordinada
        //=====================================================================
        public DataSet CNAnexo12_I(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADAnexo12_I(dFecha, cCodSBS, cAnexo);
        }

        public DataSet CNAnexo12II(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCuenta.ADAnexo12II(dFecha, cCodSBS, cAnexo);
        }

        //=====================================================================
        //--Reporte 5 Demanda Moneda Extranjera
        //=====================================================================
        public DataSet CNReporte5(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return ADCuenta.ADReporte5(dFecha, cCodSBS, cCodAnexo);
        }

        public DataTable CNReporte502(DateTime dFecha, string cCodSBS, string cCodAnexo)
        {
            return ADCuenta.ADReporte502(dFecha, cCodSBS, cCodAnexo);
        }

        //=====================================================================
        //--Reporte 12 Adeudados peq. y Micro Empresa
        //=====================================================================
        public DataTable CNReporte12(DateTime dFecha)
        {
            return ADCuenta.ADReporte12(dFecha);
        }

        //=====================================================================
        //--Reporte Encaje 1, página 1
        //=====================================================================
        public DataTable CNEncaje1(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return ADCuenta.ADEncaje1(dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //=====================================================================
        //--Reporte Encaje 1 TXT
        //=====================================================================
        public DataTable CNEncaje1Txt(DateTime dFecha, int idMoneda)
        {
            return ADCuenta.ADEncaje1Txt(dFecha, idMoneda);
        }

        //=====================================================================
        //--Reporte Encaje 1.1, página 2
        //=====================================================================
        public DataTable CNEncaje1_1(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return ADCuenta.ADEncaje1_1(dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        public DataTable CNGuardarAnexo16(DateTime dFec)
        {
            return ADCuenta.ADGuardarAnexo16(dFec);
        }
        public DataTable CNRptSaldosCredito(DateTime dFecha)
        {
            return ADCuenta.ADRptSaldosCredito(dFecha);
        }


        //EVALUACION EMPRESARIAL

        #region EVALUACION EMPRESARIAL

        public DataTable CNFlujoCajaVariablesPorcentuales(int IdEvalEmpr)
        {
            return ADCuenta.ADFlujoCajaVariablesPorcentuales(IdEvalEmpr);
        }

        public DataTable CNFlujoCajaIngresoEvalEmpresarial(int IdEvalEmpr)
        {
            return ADCuenta.ADFlujoCajaIngresoEvalEmpresarial(IdEvalEmpr);
        }
        public DataTable CNFlujoCajaEgresoEvalEmpresarial(int IdEvalEmpr)
        {
            return ADCuenta.ADFlujoCajaEgresoEvalEmpresarial(IdEvalEmpr);
        }

        public DataTable CNBalancesGeneral1erCre(int CodigoCliente)
        {
            return ADCuenta.ADBalancesGeneral1erCre(CodigoCliente);
        }
        public DataTable CNBalancesGeneralUltimoCre(int CodigoCliente)
        {
            return ADCuenta.ADBalancesGeneralUltimoCre(CodigoCliente);
        }
        public DataTable CNBalancesGeneralActualEval(int IdEvalEmpr)
        {
            return ADCuenta.ADBalancesGeneralActualEval(IdEvalEmpr);
        }

        public DataTable CNEstPerdidasGananc1erCreEvalEmpresarial(int CodigoCliente)
        {
            return ADCuenta.ADEstPerdidasGananc1erCreEvalEmpresarial(CodigoCliente);
        }
        public DataTable CNEstPerdidasGanancUltimoCreEvalEmpresarial(int CodigoCliente)
        {
            return ADCuenta.ADEstPerdidasGanancUltimoCreEvalEmpresarial(CodigoCliente);
        }
        public DataTable CNEstPerdidasGanancActualEvalEmpresarial(int IdEvalEmpr)
        {
            return ADCuenta.ADEstPerdidasGanancActualEvalEmpresarial(IdEvalEmpr);
        }

        public DataTable CNMesesGeneradosFlujoCaja(int IdEvalEmpr)
        {
            return ADCuenta.ADMesesGeneradosFlujoCaja(IdEvalEmpr);
        }
        #endregion

        //REPORTES GERENCIALES

        #region REPORTES GERENCIALES

        public DataTable CNMoraAgencia(DateTime dFecha)
        {
            return ADCuenta.ADMoraAgencia(dFecha);
        }
        public DataTable CNMoraAnalista(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADMoraAnalista(dFecha, idAgencia);
        }
        public DataTable CNMoraMoneda(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADMoraMoneda(dFecha, idAgencia);
        }
        public DataTable CNDesembolsoProducto(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADDesembolsoProducto(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNDesembolsoAgencia(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADDesembolsoAgencia(dFecIni, dFecFin);
        }
        public DataTable CNDesembolsoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADDesembolsoAnalista(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNSaldoPlazos(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADSaldoPlazos(dFecha, idAgencia);
        }
        public DataTable CNSaldoMontos(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADSaldoMontos(dFecha, idAgencia);
        }
        public DataTable CNSaldoMontosDesembolsado(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADSaldoMontosDesembolsado(dFecha, idAgencia);
        }
        public DataTable CNSaldoEvolutivoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADSaldoEvolutivoAnalista(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNSaldoEvolutivoCliente(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADSaldoEvolutivoCliente(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNMoraEvolutivoAtraso(DateTime dFecIni, DateTime dFecFin, int idAgencia, int idRangoAtraso)
        {
            return ADCuenta.ADMoraEvolutivoAtraso(dFecIni, dFecFin, idAgencia, idRangoAtraso);
        }
        public DataTable CNIngresosAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADIngresosAnalista(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNRecuperaAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADRecuperaAnalista(dFecIni, dFecFin, idAgencia);
        }

        public DataTable ADRecuperaExtornoOpe(string dFecIni, string dFecFin, int idRegion, int idOficina, int idEstablecimiento, int idModulo)
        {
            return ADCuenta.ADRecuperaExtornoOpe(dFecIni, dFecFin, idRegion, idOficina, idEstablecimiento, idModulo);
        }
        public DataTable CNDatosReimpresionVoucherPersonal(string dFecIni, string dFecFin, int idRegion, int idOficina)
        {
            return ADCuenta.ADDatosReimpresionVoucherPersonal(dFecIni, dFecFin, idRegion, idOficina);
        }
 
        public DataTable CNEvolDesembolsoAnalista(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADEvolDesembolsoAnalista(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNProvisiones(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADProvisiones(dFecha, idAgencia);
        }
        public DataTable CNMoraProducto(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADMoraProducto(dFecha, idAgencia);
        }

        #endregion

        //Cambios 20140904

        #region Cambios 20140904

        public DataTable CNDetalleCampania(int idProducto, decimal nPorcentaje, int nAtrasoMax, decimal nPromedioAtr)
        {
            return ADCuenta.ADDetalleCampania(idProducto, nPorcentaje, nAtrasoMax, nPromedioAtr);
        }
        public DataTable CNSaldoProvision(string XMLMeses)
        {
            return ADCuenta.ADSaldoProvision(XMLMeses);
        }
        public DataTable CNSaldoProvisionAnual(string XMLAnual)
        {
            return ADCuenta.ADSaldoProvisionAnual(XMLAnual);
        }
        public DataTable CNSaldoContableAnual(string XMLAnual)
        {
            return ADCuenta.ADSaldoContableAnual(XMLAnual);
        }
        public DataTable CNSaldoContable(string XMLMeses)
        {
            return ADCuenta.ADSaldoContable(XMLMeses);
        }
        public DataTable CNSaldodeProvision(string XMLAnual)
        {
            return ADCuenta.ADSaldodeProvision(XMLAnual);
        }
        public DataTable CNEstructuraTipCre(DateTime dFecProceso)
        {
            return ADCuenta.ADEstructuraTipCre(dFecProceso);
        }
        public DataTable CNVariacionTipoCred(string XMLAnual)
        {
            return ADCuenta.ADVariacionTipoCred(XMLAnual);
        }
        public DataTable CNSaldoCalificacionTipCre(string XMLAnual)
        {
            return ADCuenta.ADSaldoCalificacionTipCre(XMLAnual);
        }

        #endregion
        //Fin Cambios 20140904

        //EVALUACION CONSUMO
        #region EVALUACION CONSUMO

        public DataTable CNTarjetasCreEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADTarjetasCreEvalConsumo(IdEvalConsumo);
        }
        public DataTable CNOtrosCreEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADOtrosCreEvalConsumo(IdEvalConsumo);
        }
        public DataTable CNRefPersonalEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADRefPersonalEvalConsumo(IdEvalConsumo);
        }
        public DataTable CNRefLaboralEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADRefLaboralEvalConsumo(IdEvalConsumo);
        }
        public DataTable CNEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADEvalConsumo(IdEvalConsumo);
        }
        public DataTable CNIngresosTitular(int IdEvalConsumo)
        {
            return ADCuenta.ADIngresosTitular(IdEvalConsumo);
        }
        public DataTable CNIngresosConyugue(int IdEvalConsumo)
        {
            return ADCuenta.ADIngresosConyugue(IdEvalConsumo);
        }
        public DataTable CNEgresos(int IdEvalConsumo)
        {
            return ADCuenta.ADEgresos(IdEvalConsumo);
        }
        public DataTable CNBalanceGeneral(int IdEvalConsumo)
        {
            return ADCuenta.ADBalanceGeneral(IdEvalConsumo);
        }
        public DataTable CNEstPerdGananciasEvalConsumo(int IdEvalConsumo)
        {
            return ADCuenta.ADEstPerdGananciasEvalConsumo(IdEvalConsumo);
        }
		public DataTable CNCondonadosCRE(DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADCondonadosCRE(dFecIni, dFecFin);
        }
        public DataTable CNCondonadosCRE(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADCondonadosCRE(dFecIni, dFecFin, idAgencia);
        }
        public DataTable CNDetalleCondonados(DateTime dFecIni, DateTime dFecFin, int idAgencia)
        {
            return ADCuenta.ADDetalleCondonados(dFecIni, dFecFin, idAgencia);
        }
        #endregion

        public DataTable DatosSolicitudImpPPG(int idSolicitud)
        {
            return ADCuenta.DatosSolicitudImpPPG(idSolicitud);
        }

        //  Mora
        public DataTable CNMoraUbigeo(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor,
                                        int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return ADCuenta.ADMoraUbigeo(nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor, idTipoDir, idUbigeo, idTipoInterv);
        }
        public DataTable CNIntervMoraUbigeo(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cAsesor,
                                            int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return ADCuenta.ADIntervMoraUbigeo(nDiaMin, nDiaMax, nSalMin, nSalMax, cAsesor, idTipoDir, idUbigeo, idTipoInterv);
        }

        public DataTable MoraUbigeoRecup(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cRecuperador,
                                        int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return ADCuenta.MoraUbigeoRecup(nDiaMin, nDiaMax, nSalMin, nSalMax, cRecuperador, idTipoDir, idUbigeo, idTipoInterv);
        }

        public DataTable IntervMoraUbigeoRecup(int nDiaMin, int nDiaMax, decimal nSalMin, decimal nSalMax, string cRecuperador,
                                           int idTipoDir, int idUbigeo, int idTipoInterv)
        {
            return ADCuenta.IntervMoraUbigeoRecup(nDiaMin, nDiaMax, nSalMin, nSalMax, cRecuperador, idTipoDir, idUbigeo, idTipoInterv);
        }

        public DataTable RptDetCobranzaRecup(DateTime dFecIni, DateTime dFecFin, int idAgencia, string cRecuperador)
        {
            return ADCuenta.RptDetCobranzaRecup(dFecIni, dFecFin, idAgencia, cRecuperador);
        }

        public DataTable CNDetallePagDsctoPlanilla(int idEntidad, int idCuenta, string cNroTrx)
        {
            return ADCuenta.ADDetallePagDsctoPlanilla(idEntidad, idCuenta, cNroTrx);
        }
        // Sustento Saldos Constables
        public DataTable CNRptSaldosDevengado(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptSaldosDevengado(dFecha, idAgencia);
        }
        public DataTable CNRptSaldoProvisiones(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptSaldoProvisiones(dFecha, idAgencia);
        }
        public DataTable CNInformeRiesgos(DateTime dFechaIni, DateTime dFechaFin)
        {
            return ADCuenta.ADInformeRiesgo(dFechaIni, dFechaFin);
        }
        public DataTable CNRptSaldoGarantia(DateTime dFecha)
        {
            return ADCuenta.ADRptSaldoGarantia(dFecha);
        }
        public DataTable CNRptSaldosSuspenso(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptSaldosSuspenso(dFecha, idAgencia);
        }
        public DataTable CNRptSaldoCastigados(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptSaldoCastigados(dFecha, idAgencia);
        }
        public DataTable CNRptColocaciones(DateTime dFecha)
        {
            return ADCuenta.ADRptColocaciones(dFecha);
        }

        public DataTable CNrptConcZonaDistrito(DateTime dFecha)
        {
            return ADCuenta.ADrptConcZonaDistrito(dFecha);
        }

        public DataTable CNrptConcMonedaProd(DateTime dFecha)
        {
            return ADCuenta.ADrptConcMonedaProd(dFecha);
        }
        public DataTable CNRptMoraTramoAsesor(int idAgencia, DateTime dfecha)
        {
            return ADCuenta.ADRptMoraTramoAsesor(idAgencia, dfecha);
        }
        public DataTable CNrptConcAsesorOficina(DateTime dFecha)
        {
            return ADCuenta.ADrptConcAsesorOficina(dFecha);
        }
        public DataTable CNrptConcPlazo(DateTime dFecha)
        {
            return ADCuenta.ADrptConcPlazo(dFecha);
        }

        public DataTable CNrptConcMonto(DateTime dFecha)
        {
            return ADCuenta.ADrptConcMonto(dFecha);
        }

        public DataTable CNrptConcPromotores(DateTime dFecha)
        {
            return ADCuenta.ADrptConcPromotores(dFecha);
        }
        public DataTable CNrptConcActEco(DateTime dFecha)
        {
            return ADCuenta.ADrptConcActEco(dFecha);
        }

        public DataTable CNrptConcOficiProd(DateTime dFecha)
        {
            return ADCuenta.ADrptConcOficiProd(dFecha);
        }
        public DataTable CNrptColocPromotores(DateTime dFecha)
        {
            return ADCuenta.ADrptColocPromotores(dFecha);
        }
        public DataTable CNrptConcOficinaAsesorDistrito(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADrptConcOficinaAsesorDistrito(dFecha, idAgencia);
        }

        public DataTable CNrptConcCarteraAsesorGeneral(DateTime dFecha)
        {
            return ADCuenta.ADrptConcCarteraAsesorGeneral(dFecha);
        }
        public DataTable CNRptConcentCartAseTramo(int idAgencia, DateTime dFecha)
        {
            return ADCuenta.ADRptConcentCartAseTramo(idAgencia, dFecha);
        }

        public DataTable CNrptConcOficiAsesor(DateTime dFecha)
        {
            return ADCuenta.ADrptConcOficiAsesor(dFecha);
        }
        public DataTable CNrptCumpliMetasAsesor(DateTime dFecha)
        {
            return ADCuenta.ADrptCumpliMetasAsesor(dFecha);
        }
        public DataTable CNrptMoraTramoPromotor(DateTime dFecha, int idagencia)
        {
            return ADCuenta.ADrptMoraTramoPromotor(dFecha, idagencia);
        }
        public DataTable CNrptConcAsesorOficinaOpe(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADrptConcAsesorOficinaOpe(dFecha, idAgencia);
        }

        public DataTable DatosSolicitud(int idsolicitud)
        {
            return ADCuenta.ADrptsolicitud(idsolicitud);
        }
        public DataTable DatosAprobador(int idsolicitud)
        {
            return ADCuenta.ADrptaprobador(idsolicitud);
        }
        public DataTable DatosFamiliar(int idcli)
        {
            return ADCuenta.ADrptDatosFamiliar(idcli);
        }
        public DataTable DatosclienteJur(int idcli)
        {
            return ADCuenta.ADrptDatosClienteJur(idcli);
        }

        public DataTable DatosclienteVin(int idcli)
        {
            return ADCuenta.ADrptDatosClienteVin(idcli);
        }






        //=====================================================================
        //--Reporte Encaje 5
        //=====================================================================
        public DataTable CNEncaje5(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return ADCuenta.ADEncaje5(dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //=====================================================================
        //--Reporte Encaje 2
        //=====================================================================
        public DataTable CNEncaje2(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return ADCuenta.ADEncaje2(dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //=====================================================================
        //--Reporte Encaje 2 TXT
        //=====================================================================
        public DataTable CNEncaje2Txt(DateTime dFecha, int idMoneda)
        {
            return ADCuenta.ADEncaje2Txt(dFecha, idMoneda);
        }

        //=====================================================================
        //--Reporte Encaje 4, página 1 y 2
        //=====================================================================
        public DataTable CNEncaje4(DateTime dFecha, int idMoneda, DateTime x_dFechaReg, int x_idUsuario, bool lGrabar)
        {
            return ADCuenta.ADEncaje4(dFecha, idMoneda, x_dFechaReg, x_idUsuario, lGrabar);
        }

        //=====================================================================
        //--Reporte Encaje 4, página 1 y 2 en TXT
        //=====================================================================
        public DataTable CNEncaje4Txt(DateTime dFecha, int idMoneda)
        {
            return ADCuenta.ADEncaje4Txt(dFecha, idMoneda);
        }

        //=====================================================================
        //--Reporte 2
        //=====================================================================
        public DataSet CNReporte2A(DateTime dFecha, string cCodSBS, string cCodAnexo01, string cCodAnexo02, string cCodAnexo03)
        {
            return ADCuenta.ADReporte2A(dFecha, cCodSBS, cCodAnexo01, cCodAnexo02, cCodAnexo03);
        }
        public DataSet CNReporte2B1An3(DateTime dFecha, string cCodSBS, string cAnexoSbs)
        {
            return ADCuenta.ADReporte2B1An3(dFecha, cCodSBS, cAnexoSbs);
        }
        public DataSet CNReporte2B1An3II(DateTime dFecha, string cCodSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju)
        {
            return ADCuenta.ADReporte2B1An3II(dFecha, cCodSBS, cAnexoSbs, nLimGlo, nFacAju);
        }
        public DataSet CNReporte2C1(DateTime dFecha, string cCodSBS, string cAnexoSbs, decimal nLimGlo, decimal nFacAju, decimal nPatEfeAdi)
        {
            return ADCuenta.ADReporte2C1(dFecha, cCodSBS, cAnexoSbs, nLimGlo, nFacAju, nPatEfeAdi);
        }
        public DataSet CNReporte2D(DateTime dFecha, string cCodSBS, string cAnexoSbs)
        {
            return ADCuenta.ADReporte2D(dFecha, cCodSBS, cAnexoSbs);
        }
        public DataTable CNGenActaComiteCred(int idComite)
        {
            return ADCuenta.ADGenActaComiteCred(idComite);
        }
        public DataTable CNGenActaAprobCreditos(DateTime dFecIni, DateTime dFecFin, int idNivAprobacion, int idZona, int idAgencias)
        {
            return ADCuenta.ADGenActaAprobCreditos(dFecIni, dFecFin, idNivAprobacion, idZona, idAgencias);
        }
        public DataSet CNGenActaAprobDenegCred(int idSolicitud)
        {
            return ADCuenta.ADGenActaAprobDenegCred(idSolicitud);
        }
        public DataTable CNGenReasignacionesCarteraCred(string idAge, string idUsu, DateTime dFecIni, DateTime dFecFin)
        {
            return ADCuenta.ADGenReasignacionesCred(idAge, idUsu, dFecIni, dFecFin);
        }
        public DataTable CNBNDesembolso(DateTime dFecha)
        {
            return ADCuenta.ADBNDesembolso(dFecha);
        }
        public DataTable CNBNCobranza(DateTime dFecha)
        {
            return ADCuenta.ADBNCobranza(dFecha);
        }

        #region Sistema de Información Gerencial

        public DataTable CNRpt001(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRpt001(dFecha, idAgencia);
        }

        public DataTable CNRpt001Hist(DateTime dFecha, bool lEnLinea = false, int idAgencia = 0, int idZona = 0, int idUsuario = 0)
        {
            return ADCuenta.ADRpt001Hist(dFecha, idAgencia, idZona, idUsuario, lEnLinea);
        }

        public DataTable CNRpt001Histini(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRpt001HistIni(dFecha, idAgencia);
        }


        public DataTable CNRpt002(DateTime dFecha, int idAgencia, int idCalificacion)
        {
            return ADCuenta.ADRpt002(dFecha, idAgencia, idCalificacion);
        }

        public DataTable CNRpt003(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRpt003(dFecha, idAgencia);
        }

        public DataTable CNRptAvanceMoraTramoAsesor(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptAvanceMoraTramoAsesor(dFecha, idAgencia);
        }

        public DataTable CNRptLibEfectRecup(DateTime dFecha, int idAgencia)
        {
            return ADCuenta.ADRptLibEfectRecup(dFecha, idAgencia);
        }

        public DataSet rptComiteCreditoDetallado(int idZona, int idAgencia, DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ADCuenta.rptComiteCreditoDetallado(idZona, idAgencia, dFechaInicio, dFechaFin);
        }

        #endregion

        public DataSet retornarLimGlobalIndividualAnexo13(DateTime dFecha, string cCodSBS, string cAnexo)
        {
            return ADCuenta.retornarLimGlobalIndividualAnexo13(dFecha, cCodSBS, cAnexo);
        }

        public DataTable CNActualizaSIGOnline(int idUsuario, int idEstadoInicio)
        {
            return ADCuenta.ADActualizaSIGOnline(idUsuario, idEstadoInicio);
        }

        public DataTable CNDatosScore(int idsolicitud)
        {
            return ADCuenta.ADDatosScore(idsolicitud);
        }

        public DataTable CNDatosDetalleScore(int idsolicitud)
        {
            return ADCuenta.ADDatosDetalleScore(idsolicitud);
        }

        public DataTable CNDatosSolicitudScore(int idSolicitud)
        {
            return ADCuenta.ADDatosSolicitudScore(idSolicitud);
        }

        public DataTable CNReportePolizaSeguroDesgravamen(int idZona, int idAgencia, int nTipoPoliza, int nTrama, DateTime dFecha)
        {
            return ADCuenta.ADObtenerReportePolizaSeguroDesgravamen(idZona, idAgencia, nTipoPoliza, nTrama, dFecha);
        }
        public DataTable rptMinutaGarantiaAviso(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ADCuenta.rptMinutaGarantiaAviso(dFechaInicio, dFechaFin);
        }
        public DataTable CNReporteMotivoHistorico(DateTime dFechaInicio, DateTime dFechaFin)
        {
            return ADCuenta.ADReporteMotivoHistorico(dFechaInicio, dFechaFin);
        }
    }
}
