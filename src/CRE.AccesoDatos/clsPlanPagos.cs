using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using System.Xml.Linq;
using GEN.Funciones;

namespace CRE.AccesoDatos
{
    public class clsPlanPagos
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        /**********   Plan Pagos Grupo Solidario    **************/

        public DataTable ADdtPlanPagoGrupal(int idGrupoSol, int idSoliGS)
        {
            return objEjeSp.EjecSP("CRE_PlanPagosGrupal_SP", idGrupoSol, idSoliGS);
        }

        public DataTable ADdtBuscarSoliGrupal(int idGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_BuscarSoliGrupal_SP", idGrupoSol);
        }
        public DataTable ADdtPlanPagoGS(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_LisPlanPago_SP", nNumCredito);
        }
        public DataTable ADdtBuscarCli(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_BuscarDatosCli_SP", nNumCredito);
        }
        public DataTable ADdtBuscarPresi(int idSoliGS)
        {
            return objEjeSp.EjecSP("CRE_BuscarPresidenteSoliGrupal_SP", idSoliGS);
        }
        public DataTable ADdtRegPagosGrup(int idVoucher, int idKardex, int idEstado, int idSolGS, int idCuenta, int idCli, decimal dMonto, decimal nMonRedondeo, decimal nMonSinRedondeo)
        {
            return objEjeSp.EjecSP("CRE_InsertarRegPagoGrupal_SP", idVoucher, idKardex, idEstado, idSolGS, idCuenta, idCli, dMonto, nMonRedondeo, nMonSinRedondeo);
        }
        public DataTable ADdtVoucherGrupal(int idGrupo)
        {
            return objEjeSp.EjecSP("CRE_ConsultaUltimoVoucherGrupal_SP", idGrupo);
        }
        public DataTable ADdtActVoucherGrupal(int idVoucher)
        {
            return objEjeSp.EjecSP("CRE_ActualizaCantVoucherGrupal_SP", idVoucher);
        }
        public DataTable ADdtDatosVoucherGrupal(int idVoucher, decimal dMontoEfectivo)
        {
            return objEjeSp.EjecSP("CRE_ExtraeDatosVoucherGrupal_SP", idVoucher, dMontoEfectivo);
        }
        public DataTable ADdtExtraeProducto(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ExtraeProductoXCuenta_SP", idCuenta);
        }

        public DataTable ADdtCliente(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_DevuelveClixCuenta_SP", idCuenta);
        }
        public DataTable ADdtPlanPagoGrupalDatos(int idSoliGS)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosGS_SP", idSoliGS);
        }
        public DataTable ADdtBuscarSoliGrupal2(int idSoliGS)
        {
            return objEjeSp.EjecSP("CRE_BuscarSolicitudesGS_SP", idSoliGS);
        }
        /************************/

        //Crear Método para ejecutar SP
        public DataTable InsPlanPago(string cPpgXml, DateTime dFecdesemb, decimal nTasaCostoEfectivoAnual, decimal TEA, int nSumaDiasCredito,
            DateTime dFechaUltimoPagoCredito, bool lDesembolsoExterno, bool lExtractoPagos, int idMedioEnvio, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_InsPlanPagos_SP", cPpgXml, dFecdesemb, nTasaCostoEfectivoAnual, TEA, nSumaDiasCredito, dFechaUltimoPagoCredito, lDesembolsoExterno, lExtractoPagos, idMedioEnvio, idUsuario);
        }

        public DataTable ADdtGetCobro(int nIdKardex)
        {
            return objEjeSp.EjecSP("CRE_GetCobro_sp", nIdKardex);
        }

        public DataTable ADdtPlanPago(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_LisPlanPago_SP", nNumCredito);
        }

        public clsPlanPago retonarPlanPago(int nNumCredito)
        {
            clsPlanPago objplanpago = new clsPlanPago();
            foreach (DataRow item in objEjeSp.EjecSP("CRE_LisPlanPago_SP", nNumCredito).Rows)
            {
                objplanpago.Add(new clsCuota()
                                {
                                    idCuenta        = Convert.ToInt32(item["idCuenta"])         ,
                                    idPlanPago      = Convert.ToInt32(item["idPlanPagos"])      ,
                                    idCuota         = Convert.ToInt32(item["idCuota"])          ,
                                    idTipoCuota     = Convert.ToInt32(item["idTipoCuota"])      ,
                                    idEstadocuota   = Convert.ToInt32(item["idEstadocuota"])    ,
                                    dFechaProg      = Convert.ToDateTime(item["dFechaProg"])    ,
                                    dFechaPago      = item["dFechaPago"]==null?null: item["dFechaPago"]  ,
                                    nCapital        = Convert.ToDecimal(item["nCapital"])       ,
                                    nCapitalPagado  = Convert.ToDecimal(item["nCapitalPagado"]) ,
                                    nInteres        = Convert.ToDecimal(item["nInteres"])       ,
                                    nInteresFecha   = Convert.ToDecimal(item["nInteresFecha"])  ,
                                    nInteresPagado  = Convert.ToDecimal(item["nInteresPagado"]) ,
                                    nIntComp        = Convert.ToDecimal(item["nInteresComp"])   ,
                                    nInteresCompPago  = Convert.ToDecimal(item["nInteresCompPago"]),
                                    nOtros          = Convert.ToDecimal(item["nOtros"])         ,
                                    nOtrosPagado    = Convert.ToDecimal(item["nOtrosPagado"])   ,
                                    nMora           = Convert.ToDecimal(item["nMora"])          ,
                                    nMoraPagada     = Convert.ToDecimal(item["nMoraPagada"])    ,
                                    nNumDiaCuota    = Convert.ToInt32(item["nNumDiaCuota"])     ,
                                    nAtrasoCuota    = Convert.ToInt32(item["nAtrasoCuota"])     ,
                                    idAgencia       = Convert.ToInt32(item["idAgencia"])
                                });
            }

            return objplanpago;
        }

        public clsPlanPago retonarPlanPagoTotal(int nNumCredito)
        {
            clsPlanPago objplanpago = new clsPlanPago();
            foreach (DataRow item in objEjeSp.EjecSP("CRE_LisPlanPagoTot_SP", nNumCredito).Rows)
            {
                objplanpago.Add(new clsCuota()
                {
                    idCuenta        = Convert.ToInt32(item["idCuenta"]),
                    idPlanPago      = Convert.ToInt32(item["idPlanPagos"]),
                    idCuota         = Convert.ToInt32(item["idCuota"]),
                    idTipoCuota     = Convert.ToInt32(item["idTipoCuota"]),
                    idEstadocuota   = Convert.ToInt32(item["idEstadocuota"]),
                    dFechaProg      = Convert.ToDateTime(item["dFechaProg"]),
                    dFechaPago      = item["dFechaPago"] == null ? null : item["dFechaPago"],
                    dFechaValor     = item["dFechaValor"] == null ? null : item["dFechaValor"],
                    nCapital        = Convert.ToDecimal(item["nCapital"]),
                    nCapitalPagado  = Convert.ToDecimal(item["nCapitalPagado"]),
                    nInteres        = Convert.ToDecimal(item["nInteres"]),
                    nInteresFecha   = Convert.ToDecimal(item["nInteresFecha"]),
                    nInteresPagado  = Convert.ToDecimal(item["nInteresPagado"]),
                    nIntComp        = Convert.ToDecimal(item["nInteresComp"]),
                    nInteresCompPago= Convert.ToDecimal(item["nInteresCompPago"]),
                    nOtros          = Convert.ToDecimal(item["nOtros"]),
                    nOtrosPagado    = Convert.ToDecimal(item["nOtrosPagado"]),
                    nMora           = Convert.ToDecimal(item["nMora"]),
                    nMoraPagada     = Convert.ToDecimal(item["nMoraPagada"]),
                    nNumDiaCuota    = Convert.ToInt32(item["nNumDiaCuota"]),
                    nAtrasoCuota    = Convert.ToInt32(item["nAtrasoCuota"]),
                    idAgencia       = Convert.ToInt32(item["idAgencia"]),
                    nSaldoCapital   = Convert.ToDecimal(item["nSaldoCapital"]),
                    idModPagoCre    = Convert.ToInt32(item["idModPagoCre"]),
                    dFechaDesembolso = Convert.ToDateTime(item["dFechaDesembolso"]),
                    idContable      = Convert.ToInt32(item["idContable"])
                });
            }

            return objplanpago;
        }

        public DataTable ADdtSolAprobadas(int nNumAgencia, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_LisSolGenPPG_SP", nNumAgencia, idEstado);
        }

        public DataTable ADListarSolicitudEstados(int nNumAgencia, string cEstados)
        {
            return objEjeSp.EjecSP("CRE_LisSolGenPPD_SP", nNumAgencia, cEstados);
        }
        public DataTable ADObtenerSolicitudEstado(string cEstadoSolicitud)
        {
            return objEjeSp.EjecSP("GEN_RetornaValorVariable_sp", cEstadoSolicitud);
        }

        public DataTable ADObtenerCuentaSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_GetCuentaSol_SP", idSolicitud);
        }

        public DataTable ADdtRegCobPlanPago(string cPpgXml, DateTime dFecSis, int nUsuSis, Int32 nIdAgencia, Decimal nMoraPagada,
                                            int idCuenta, int idCanal, Decimal nMonRedondeo, Decimal nImpuesto, decimal nITFNormal,
                                            int idTipoPago, int idEntidad, int idCtaEntidad, string cNroTrx, int idMotivoOperacion, string cXmlCobs,
                                            bool lModificaSaldoLinea, int idTipoTransac, int idMoneda, decimal nMontoOpe)
        {
            return objEjeSp.EjecSP("CRE_RegCobro_SP", cPpgXml, dFecSis, nUsuSis, nIdAgencia, nMoraPagada,
                                                        idCuenta, idCanal, nMonRedondeo, nImpuesto, nITFNormal,
                                                        idTipoPago, idEntidad, idCtaEntidad, cNroTrx, idMotivoOperacion, cXmlCobs,
                                                        lModificaSaldoLinea, idTipoTransac, idMoneda, nMontoOpe);
        }

        public DataTable ADGuardarCargaGasto(string ppgXML, int nIdGasto, decimal nOtros, Int32 nIdPlanPagos, Int32 nIdAplicaConcepto, Int32 nIdTipoValor)
        {
            return objEjeSp.EjecSP("Cre_GuardarCargaGasto_Sp", ppgXML, nIdGasto, nOtros, nIdPlanPagos, nIdAplicaConcepto, nIdTipoValor);
        }

        public DataTable ADEliminarGasto(string ppgXML, decimal nGastoAGuardar)
        {
            return objEjeSp.EjecSP("Cre_EliminarCargaGasto_Sp", ppgXML, nGastoAGuardar);
        }

        public DataTable ADdtPlanPagPosi(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_LisPlanPagCre_SP", nNumCredito);
        }

        public DataTable ADdtPlanPagPosiCon(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_LisPlanPagCreCon_SP", nNumCredito);
        }


        public clsDBResp RegistrarPrepago(int idCuenta, clsPlanPago planpagoPagados, string xmlPagador, DateTime dFechaOpe,
                                    int idCanal, int idUsuario, int idAgeOpera, int idMotivoOperacion,
                                    decimal nItfNormal, decimal nItfTruncado, decimal nMonRedondeo,
                                    bool lModificaSaldoLinea, int idTipoTransac, int idMoneda_Saldo, decimal nMontoOpe)
        {
            int idPlanPagos = planpagoPagados.First(x => x.lCuotaPrepago).idPlanPago;
            string cxml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsplanpago",
                                          from item in planpagoPagados
                                          select new XElement("dtplanpago",
                                                              new XAttribute("idCuenta", item.idCuenta),
                                                              new XAttribute("idPlanPagos", item.idPlanPago),
                                                              new XAttribute("idCuota", item.idCuota),
                                                              new XAttribute("idTipoCuota", item.idTipoCuota),
                                                              new XAttribute("idEstadoCuota", item.idEstadocuota),
                                                              new XAttribute("dFechaProg", item.dFechaProg),
                                                              new XAttribute("dFechaPago", item.dFechaPago ?? ""),
                                                              new XAttribute("nCapital", item.nCapital),
                                                              new XAttribute("nCapitalPagado", item.nCapitalPagado),
                                                              new XAttribute("nInteres", item.nInteres),
                                                              new XAttribute("nInteresFecha", item.nInteresFecha),
                                                              new XAttribute("nInteresPagado", item.nInteresPagado),
                                                              new XAttribute("nInteresComp", item.nIntComp),
                                                              new XAttribute("nInteresCompPago", item.nInteresCompPago),
                                                              new XAttribute("nOtros", item.nOtros),
                                                              new XAttribute("nOtrosSinSeg", item.nOtrosSinSeg),
                                                              new XAttribute("nOtrosPagado", item.nOtrosPagado),
                                                              new XAttribute("nMora", item.nMora),
                                                              new XAttribute("nMoraPagada", item.nMoraPagada),
                                                              new XAttribute("nAtrasoCuota", item.nAtrasoCuota),
                                                              new XAttribute("nNumDiaCuota", item.nNumDiaCuota),
                                                              new XAttribute("nSaldoCapital", item.nSaldoCapital),
                                                              new XAttribute("idModPagoCre", item.idModPagoCre),
                                                              new XAttribute("lCuotaPrepago", item.lCuotaPrepago),
                                                              new XAttribute("lDiferido", item.lDiferido)
                                                              ))).ToString();

            DataTable dtResult =  objEjeSp.EjecSP("CRE_RegCobroPrePago_SP", idCuenta, cxml, xmlPagador, dFechaOpe,
                                         idCanal, idUsuario, idAgeOpera, idMotivoOperacion,
                                         nItfNormal, nItfTruncado, nMonRedondeo,
                                         lModificaSaldoLinea, idTipoTransac, idMoneda_Saldo, nMontoOpe);

            return new clsDBResp(dtResult);
        }

        public DataTable ListarDetalleGasto(int nIdNumCuenta, int nNumCuotaActual, int nidPlanPagos)
        {
            return objEjeSp.EjecSP("CRE_ListarDetalleCargaGasto_sp", nIdNumCuenta, nNumCuotaActual, nidPlanPagos);
        }

        public clsDBResp RegistrarReprogramacion(int idCuenta, int idSolicitud, int nDiasGracia, clsPlanPago planPagos, string xmlReprogramacion, DateTime dFechaOpe, int idUsuario)
        {
            string xmlPlanPagos = planPagos.GetXml();
            DataTable dtResult = objEjeSp.EjecSP("CRE_RegReprogramacion_SP", idCuenta, idSolicitud, nDiasGracia, xmlPlanPagos, xmlReprogramacion, dFechaOpe, idUsuario);
            return new clsDBResp(dtResult);
        }


        public DataTable ADListarDetalleCargaGastoCobroCredito(string ppgXML)
        {
            return objEjeSp.EjecSP("CRE_ListarDetalleCargaGastoCobroCre_sp", ppgXML);
        }

        //=============================================================
        //-- Solicitar Autorización para Cambio orden Prelación
        //=============================================================
        public DataTable SolicitarAutorizOrdenPrelac(string xmlSolicitudOrdenPrelac, string xmlConcepto,
                            int idAgencia, int idCliente, int EstOper,
                            int idMoneda, int idProducto, decimal Monto, int nNumCredito,
                            DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                            DateTime FecAprob, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_InsSolAutorizOrdenPrelacion_Sp",
                                    xmlSolicitudOrdenPrelac, xmlConcepto,
                                    idAgencia, idCliente, EstOper,
                                    idMoneda, idProducto, Monto, nNumCredito,
                                    FecSolic, idMotivo, sustento, idEstSolic,
                                    FecAprob, idUsuario);
        }

        //=======================================================
        //-- Buscar las solicitudes de Cambio de orden Prelación
        //=======================================================
        public DataSet ADBuscarSolicitudAutorizOrdenPrelac(int idCuenta, int idCliente, int idMoneda, int idProducto)
        {
            return objEjeSp.DSEjecSP("CRE_SituacSolicAutorizOrdenPrelac_Sp", idCuenta, idCliente, idMoneda, idProducto);
        }

        public DataTable ADActualizarEstadoSolicitudAprobac(int idSolicitudAutorizacOrdenPrelac, int idSolicitudAprobacOrdenPrelac)
        {
            return objEjeSp.EjecSP("CRE_UpdEstadoSolAprobacOrdenPrelac_Sp", idSolicitudAutorizacOrdenPrelac, idSolicitudAprobacOrdenPrelac);
        }

        public DataTable ADListarModificacionesSolicitud(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListarModificacionesSolicitud_SP", idCuenta);
        }

        public DataTable ADRetornaCuentaXSolicitud(int nidSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ExtraeCuentaXSolicitud_SP", nidSolicitud);
        }
                
        public DataTable ADRegistrarSolHojaTramite(int idSolicitudHojaTramite, int idUsuarioRegistra, int idTipoOperacion, int idCuenta, int idCliPagador, int idTipoPagador, bool lCartaPoder, int idTipoOpePrePago, int nIdKardex)
        {
            return objEjeSp.EjecSP("CRE_RegistrarSolHojaTramite_SP", idSolicitudHojaTramite, idUsuarioRegistra, idTipoOperacion, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, nIdKardex);
        }

        public DataTable ADObtenerVoucherHojaTramite(int idSolicitudHojaTramite, int idTipoOperacion)
        {
            return objEjeSp.EjecSP("RPT_ObtenerVoucherHojaTramite_SP", idSolicitudHojaTramite, idTipoOperacion);
        }

        #region Descuento Camp Nav.
        public DataTable ADValidaClienteCampNav(int idCli, string dMonto, int idSolicitud, int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_SeleccionaClientesBonoCampNavi_SP", idCli, dMonto, idSolicitud, idCuenta);
        }

        public DataTable ADVerificaDatosClienteCampNav(int idCliente, int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerificarClienteCampNav_SP", idCliente, idCuenta);
        }

        public DataTable ADVerificarEstadoCredito(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerificarEstadoCredito_SP", idCuenta);
        }

        public DataTable ADActualizarEstadoBonoNav(int idCuenta, int idCliente, int idEstado)
        {
            return objEjeSp.EjecSP("CRE_ActualizarEstadoBonoNav_SP", idCuenta, idCliente, idEstado);
        }
        #endregion

        #region PlanPagos Grupo Solidario

        public DataTable ADGuardarPlanPagosGrupoSol(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_GuardarPlanPagosGrupoSol_SP", idSolicitudCredGrupoSol);
        }

        public DataTable ADrptIntegrantesGrupo(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_rptIntegrantesGrupo_SP", idSolicitudCredGrupoSol);
        }

        public DataTable ADrptPlanPagosGrupal(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_rptPlanPagosGrupal_SP", idSolicitudCredGrupoSol);
        }


        public DataTable ADrptDatosCreditoGrupal(int idSolicitudCredGrupoSol)
        {
            return objEjeSp.EjecSP("CRE_rptDatosCreditoGrupal_SP", idSolicitudCredGrupoSol);
        }

        #endregion

        #region Validación histórico de solicitud de crédito (Fecha 1ra cuota).
        public DataTable ADListarMotivo(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListaMotivo1raCuota_SP", idSolicitud);
        }
        public DataTable ADRegistrarMotivo(int idSolicitud, int idUsuario, DateTime dFechaIncial, DateTime dFechaModificado, string cMotivo, DateTime dFecSystem, int idCondHistSolCred)
        {
            return objEjeSp.EjecSP("CRE_GuardaMotivo1raCuota_SP", idSolicitud, idUsuario, dFechaIncial, dFechaModificado, cMotivo, dFecSystem, idCondHistSolCred);
        }
        #endregion
    }
}
