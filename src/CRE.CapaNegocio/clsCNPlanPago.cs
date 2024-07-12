using System;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using GEN.AccesoDatos;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CRE.CapaNegocio
{
    public class clsCNPlanPago
    {
        clsFunUtiles cnFuncionesUtiles = new clsFunUtiles();
        private DataTable dtGastos;
        public bool EsRetencion = false;
        private DataTable dtGastosSegOptativos = new DataTable();
        IEnumerable<clsPaqueteSeguro> lstPlanesSegurosPermitidos;

        public enum Origen {GeneracionPlanPagos = 1, PrePago = 2}
        /// <summary>
        /// Monto de la cuota al calcular el cronograma
        /// </summary>
        public decimal nMontoCuota { get; private set; }

        /// <summary>
        /// Cantidad de decimales para el redondeo de la cuota
        /// </summary>
        private const int nDecRedonCalcPpg = 1;

        /// <summary>
        /// Constante de valor cero(0)
        /// </summary>
        private const decimal nCero = 0.0M;

        public clsCNCargaGastosCred ObjCargaGastosCred { get; private set; }

        public clsCNPlanPago()
        {
            iniciarDTGastos();
        }

        public DataTable GetdtGastos()
        {
            return dtGastos;
        }
        #region Carga gastos

        public DataTable CNGuardarCargarGasto(string ppgXML, int nIdGasto, decimal nOtros, Int32 nIdPlanPagos,
                                                Int32 nIdAplicaConcepto, Int32 nIdTipoValor)
        {
            return objPlanPago.ADGuardarCargaGasto(ppgXML, nIdGasto, nOtros, nIdPlanPagos,
                                                    nIdAplicaConcepto, nIdTipoValor);
        }

        public DataTable CNEliminarGasto(string ppgXML, decimal nGastoAGuardar)
        {
            return objPlanPago.ADEliminarGasto(ppgXML, nGastoAGuardar);
        }

        #endregion

        #region otros

        public clsPlanPagos objPlanPago = new clsPlanPagos();

        /**************  plan pagos grupal  ****************/
        public DataTable CNdtPlanPagoGrupal(int idGrupoSol, int idSoliGS)
        {
            return objPlanPago.ADdtPlanPagoGrupal(idGrupoSol, idSoliGS);
        }
        public DataTable CNdtBuscarSoliGrupal(int idGrupoSol)
        {
            return objPlanPago.ADdtBuscarSoliGrupal(idGrupoSol);
        }
        public DataTable CNdtPlanPagoGS(int nNumCredito)
        {
            return objPlanPago.ADdtPlanPagoGS(nNumCredito);
        }
        public DataTable CNdtBuscarCli(int nNumCredito)
        {
            return objPlanPago.ADdtBuscarCli(nNumCredito);
        }
        public DataTable CNdtBuscarPresi(int idSoliGS)
        {
            return objPlanPago.ADdtBuscarPresi(idSoliGS);
        }
        public DataTable CNdtRegPagosGrup(int idVoucher, int idKardex, int idEstado, int idSolGS, int idCuenta, int idCli, decimal dMonto, decimal nMonRedondeo, decimal nMonSinRedondeo)
        {
            return objPlanPago.ADdtRegPagosGrup(idVoucher, idKardex, idEstado, idSolGS, idCuenta, idCli, dMonto, nMonRedondeo, nMonSinRedondeo);
        }
        public DataTable CNdtVoucherGrupal(int idGrupo)
        {
            return objPlanPago.ADdtVoucherGrupal(idGrupo);
        }
        public DataTable CNdtActVoucherGrupal(int idVoucher)
        {
            return objPlanPago.ADdtActVoucherGrupal(idVoucher);
        }
        public DataTable CNdtDatosVoucherGrupal(int idVoucher, decimal dMontoEfectivo)
        {
            return objPlanPago.ADdtDatosVoucherGrupal(idVoucher, dMontoEfectivo);
        }
        public DataTable CNdtExtraeProducto(int idCuenta)
        {
            return objPlanPago.ADdtExtraeProducto(idCuenta);
        }
        public DataTable CNdtCiente(int idCuenta)
        {
            return objPlanPago.ADdtCliente(idCuenta);
        }
        public DataTable CNdtPlanPagoGrupalDatos(int idSoliGS)
        {
            return objPlanPago.ADdtPlanPagoGrupalDatos(idSoliGS);
        }
        public DataTable CNdtBuscarSoliGrupal2(int idSoliGS)
        {
            return objPlanPago.ADdtBuscarSoliGrupal2(idSoliGS);
        }
        /*****************************/

        public DataTable InsPpg(string PpgXml, DateTime dfecdesemb, decimal nTasaCostoEfectivoAnual, decimal TEA, int nSumaDiasCredito,
            DateTime dFechaUltimoPagoCredito, bool lDesembolsoExterno, bool lExtractoPagos, int idMedioEnvio)
        {
            int idUsuario = clsVarGlobal.User.idUsuario;
            return objPlanPago.InsPlanPago(PpgXml, dfecdesemb, nTasaCostoEfectivoAnual, TEA, nSumaDiasCredito, dFechaUltimoPagoCredito, lDesembolsoExterno, lExtractoPagos, idMedioEnvio, idUsuario);
        }

        public DataTable CNGetCobro(int nIdKardex)
        {
            return objPlanPago.ADdtGetCobro(nIdKardex);
        }

        public DataTable CNdtSolAprobadas(int nNumAgencia, int idEstado)
        {
            return objPlanPago.ADdtSolAprobadas(nNumAgencia, idEstado);
        }

        public DataTable CNListarSolicitudEstados(int nNumAgencia, string cEstados)
        {
            return objPlanPago.ADListarSolicitudEstados(nNumAgencia, cEstados);
        }
        public DataTable CNObtenerSolicitudEstado(string cEstadoSolicitud)
        {
            return objPlanPago.ADObtenerSolicitudEstado(cEstadoSolicitud);
        }

        public DataTable CNObtenerCuentaSolicitud(int idSolicitud)
        {
            return objPlanPago.ADObtenerCuentaSolicitud(idSolicitud);
        }

        public DataTable CNdtPlanPago(int nNumCredito)
        {
            return objPlanPago.ADdtPlanPago(nNumCredito);
        }

        public clsPlanPago retonarPlanPago(int nNumCredito)
        {
            return objPlanPago.retonarPlanPago(nNumCredito);
        }

        public clsPlanPago retonarPlanPagoTotal(int nNumCredito)
        {
            return objPlanPago.retonarPlanPagoTotal(nNumCredito);
        }

        public DataTable UpCobroPpg(String PpgXml, DateTime dFecSis, int nUsuSis, Int32 nIdAgencia,
                                    decimal nMoraPagada, int idCuenta, int idCanal, decimal nMonRedondeo,
                                    decimal nImpuesto, decimal nITFNormal, int idTipoPago, int idEntidad,
                                    int idCtaEntidad, string cNroTrx, int idMotivoOperacion, string cXmlCobs,
                                    bool lModificaSaldoLinea, int idTipoTransac, int idMoneda, decimal nMontoOpe)
        {
            return objPlanPago.ADdtRegCobPlanPago(PpgXml, dFecSis, nUsuSis, nIdAgencia,
                                                nMoraPagada, idCuenta, idCanal, nMonRedondeo,
                                                nImpuesto, nITFNormal, idTipoPago, idEntidad,
                                                idCtaEntidad, cNroTrx, idMotivoOperacion, cXmlCobs,
                                                lModificaSaldoLinea, idTipoTransac, idMoneda, nMontoOpe);
        }

        public int nCuotasVencidas(DataTable Ppg)
        {
            int nCuotaVen = 0;
            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if ((Convert.ToInt32(Ppg.Rows[i]["nAtrasoCuota"]) > 0) & Convert.ToInt32(Ppg.Rows[i]["idEstadoCuota"]) == 1)
                {
                    nCuotaVen++;
                }
            }
            return nCuotaVen;
        }

        public int nPrimeraCuotaPen(DataTable Ppg)
        {
            int nPrimeraCuoPen = 1;
            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (Convert.ToInt32(Ppg.Rows[i]["idEstadoCuota"]) == 1)
                {
                    nPrimeraCuoPen = Convert.ToInt32(Ppg.Rows[i]["idCuota"]);
                    break;
                }
            }
            return nPrimeraCuoPen;
        }

        public int nPrimeraCuotaVen(DataTable Ppg)
        {
            int nPrimeraCuoVen = 0;
            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (Convert.ToInt32(Ppg.Rows[i]["idEstadoCuota"]) == 1 & Convert.ToInt32(Ppg.Rows[i]["nAtrasoCuota"]) > 0)
                {
                    nPrimeraCuoVen = Convert.ToInt32(Ppg.Rows[i]["idCuota"]);
                    break;
                }
            }
            return nPrimeraCuoVen;
        }

        public int nNumCuotasPen(DataTable Ppg)
        {
            int nNumCuoPen = 0;
            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (Convert.ToInt32(Ppg.Rows[i]["idEstadoCuota"]) == 1)
                {
                    nNumCuoPen++;
                }
            }
            return nNumCuoPen;
        }

        public decimal nDeuDaCuotas(DataTable Ppg, int nNumCuotas)
        {
            decimal nSumDeudaCuo = 0.00m;
            for (int i = 0; i < nNumCuotas; i++)
            {
                if (Convert.ToInt32(Ppg.Rows[i]["idEstadoCuota"]) == 1)
                {
                    nSumDeudaCuo = nSumDeudaCuo + Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nMora"]) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                }

            }

            return nSumDeudaCuo;
        }

        public DataTable dtCNDeudaPendiente(DataTable Ppg, int nDiaAtraso)
        {
            int nNumCuotasVen = nCuotasVencidas(Ppg);

            DataTable dtDeuodaPen = new DataTable("dtDeuodaPen");
            dtDeuodaPen.Columns.Add("nCapitalPen", typeof(decimal));
            dtDeuodaPen.Columns.Add("nInteresPen", typeof(decimal));
            dtDeuodaPen.Columns.Add("nIntCompPen", typeof(decimal));
            dtDeuodaPen.Columns.Add("nMoraPen", typeof(decimal));
            dtDeuodaPen.Columns.Add("nOtrosPen", typeof(decimal));
            dtDeuodaPen.Columns.Add("nTotalPen", typeof(decimal));
            dtDeuodaPen.Rows.Add(dtDeuodaPen.NewRow());

            dtDeuodaPen.Rows[0]["nCapitalPen"] = 0;
            dtDeuodaPen.Rows[0]["nInteresPen"] = 0;
            dtDeuodaPen.Rows[0]["nIntCompPen"] = 0;
            dtDeuodaPen.Rows[0]["nMoraPen"] = 0;
            dtDeuodaPen.Rows[0]["nOtrosPen"] = 0;
            dtDeuodaPen.Rows[0]["nTotalPen"] = 0;

            if (nNumCuotasVen > 0)
            {
                int i = 0;
                while (Convert.ToInt32(Ppg.Rows[i]["nAtrasoCuota"]) >= 0)
                {
                    dtDeuodaPen.Rows[0]["nCapitalPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nCapitalPen"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nCapital"])) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]);
                    dtDeuodaPen.Rows[0]["nInteresPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nInteresPen"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteres"])) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]);
                    dtDeuodaPen.Rows[0]["nIntCompPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nIntCompPen"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"])) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]);
                    dtDeuodaPen.Rows[0]["nMoraPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nMoraPen"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nMora"])) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                    dtDeuodaPen.Rows[0]["nOtrosPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nOtrosPen"]) +
                                                    Convert.ToDecimal(Ppg.Rows[i]["nOtros"])) -
                                                    Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]);
                    dtDeuodaPen.Rows[0]["nTotalPen"] = Convert.ToDecimal(dtDeuodaPen.Rows[0]["nCapitalPen"]) +
                                                    Convert.ToDecimal(dtDeuodaPen.Rows[0]["nInteresPen"]) +
                                                    Convert.ToDecimal(dtDeuodaPen.Rows[0]["nIntCompPen"]) +
                                                    Convert.ToDecimal(dtDeuodaPen.Rows[0]["nMoraPen"]) +
                                                    Convert.ToDecimal(dtDeuodaPen.Rows[0]["nOtrosPen"]);
                    i++;
                    if (i == Ppg.Rows.Count)
                    {
                        break;
                    }
                }
            }
            else
            {
                dtDeuodaPen.Rows[0]["nCapitalPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nCapitalPen"]) +
                                                Convert.ToDecimal(Ppg.Rows[0]["nCapital"])) -
                                                Convert.ToDecimal(Ppg.Rows[0]["nCapitalPagado"]);
                dtDeuodaPen.Rows[0]["nInteresPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nInteresPen"]) +
                                                Convert.ToDecimal(Ppg.Rows[0]["nInteres"])) -
                                                Convert.ToDecimal(Ppg.Rows[0]["nInteresPagado"]);
                //dtDeuodaPen.Rows[0]["nIntCompPen"] = (Convert.ToDecimal (dtDeuodaPen.Rows[0]["nIntCompPen"]) +
                //                                    Convert.ToDecimal (Ppg.Rows[0]["nInteresComp"])) -
                //                                    Convert.ToDecimal (Ppg.Rows[0]["nInteresCompPago"]);
                //dtDeuodaPen.Rows[0]["nMoraPen"] = (Convert.ToDecimal (dtDeuodaPen.Rows[0]["nMoraPen"]) +
                //                                Convert.ToDecimal (Ppg.Rows[0]["nMora"])) -
                //                                Convert.ToDecimal (Ppg.Rows[0]["nMoraPagada"]);
                dtDeuodaPen.Rows[0]["nOtrosPen"] = (Convert.ToDecimal(dtDeuodaPen.Rows[0]["nOtrosPen"]) +
                                                Convert.ToDecimal(Ppg.Rows[0]["nOtros"])) -
                                                Convert.ToDecimal(Ppg.Rows[0]["nOtrosPagado"]);
                dtDeuodaPen.Rows[0]["nTotalPen"] = Convert.ToDecimal(dtDeuodaPen.Rows[0]["nCapitalPen"]) +
                                                Convert.ToDecimal(dtDeuodaPen.Rows[0]["nInteresPen"]) +
                                                //Convert.ToDecimal (dtDeuodaPen.Rows[0]["nIntCompPen"])
                                                //Convert.ToDecimal (dtDeuodaPen.Rows[0]["nMoraPen"]) +
                                                Convert.ToDecimal(dtDeuodaPen.Rows[0]["nOtrosPen"]);
            }
            dtDeuodaPen.AcceptChanges();
            return dtDeuodaPen;
        }

        public DataTable dtCNPagoDistribuido(DataTable Ppg, decimal nMontoPagado, bool lPagaMora)
        {
            DataTable dtPagoDist = new DataTable("dtPagoDist");
            dtPagoDist.Columns.Add("nCapitalPag", typeof(decimal));
            dtPagoDist.Columns.Add("nInteresPag", typeof(decimal));
            dtPagoDist.Columns.Add("nIntCompPag", typeof(decimal));
            dtPagoDist.Columns.Add("nMoraPag", typeof(decimal));
            dtPagoDist.Columns.Add("nOtrosPag", typeof(decimal));
            dtPagoDist.Columns.Add("nTotalPag", typeof(decimal));

            dtPagoDist.Rows.Add(dtPagoDist.NewRow());
            dtPagoDist.Rows[0]["nOtrosPag"] = 0D;
            dtPagoDist.Rows[0]["nMoraPag"] = 0D;
            dtPagoDist.Rows[0]["nIntCompPag"] = 0D;
            dtPagoDist.Rows[0]["nInteresPag"] = 0D;
            dtPagoDist.Rows[0]["nCapitalPag"] = 0D;
            dtPagoDist.Rows[0]["nTotalPag"] = 0D;

            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (nMontoPagado == 0)
                {
                    Ppg.Rows[i]["nOtrosPagado"] = 0D;
                    Ppg.Rows[i]["nMoraPagada"] = 0D;
                    Ppg.Rows[i]["nInteresCompPago"] = 0D;
                    Ppg.Rows[i]["nInteresPagado"] = 0D;
                    Ppg.Rows[i]["nCapitalPagado"] = 0D;
                }
                else
                {
                    //Caso capital negativo
                    if (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]) < 0)
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        Ppg.Rows[i]["nCapitalPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }

                    #region Pago otros
                    if (nMontoPagado == 0) break;
                    if ((Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"])) > nMontoPagado)
                    {
                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) + nMontoPagado;
                        Ppg.Rows[i]["nOtrosPagado"] = nMontoPagado;
                        nMontoPagado = 0.00m;
                        Ppg.Rows[i]["nMoraPagada"] = 0.00;
                        Ppg.Rows[i]["nInteresCompPago"] = 0.00;
                        Ppg.Rows[i]["nInteresPagado"] = 0.00;
                        Ppg.Rows[i]["nCapitalPagado"] = 0.00;
                        Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                        //break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]));
                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]));
                        Ppg.Rows[i]["nOtrosPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    #endregion

                    #region Pago mora
                    if (nMontoPagado == 0) break;
                    if ((Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"])) > nMontoPagado)
                    {
                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) + nMontoPagado;
                        Ppg.Rows[i]["nMoraPagada"] = nMontoPagado;
                        nMontoPagado = 0.00m;
                        Ppg.Rows[i]["nInteresCompPago"] = 0.00;
                        Ppg.Rows[i]["nInteresPagado"] = 0.00;
                        Ppg.Rows[i]["nCapitalPagado"] = 0.00;
                        Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                        //break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                        Ppg.Rows[i]["nMoraPagada"] = Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    #endregion

                    #region Pago interes compensatorio
                    if (nMontoPagado == 0) break;
                    if ((Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"])) > nMontoPagado)
                    {
                        dtPagoDist.Rows[0]["nIntCompPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) + nMontoPagado;
                        Ppg.Rows[i]["nInteresCompPago"] = nMontoPagado;
                        nMontoPagado = 0.00m;
                        Ppg.Rows[i]["nInteresPagado"] = 0.00;
                        Ppg.Rows[i]["nCapitalPagado"] = 0.00;
                        Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                        //break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]));
                        dtPagoDist.Rows[0]["nIntCompPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]));
                        Ppg.Rows[i]["nInteresCompPago"] = Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    #endregion

                    #region Pago interes
                    if (nMontoPagado == 0) break;
                    if ((Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"])) > nMontoPagado)
                    {
                        dtPagoDist.Rows[0]["nInteresPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) + nMontoPagado;
                        Ppg.Rows[i]["nInteresPagado"] = nMontoPagado;
                        nMontoPagado = 0.00m;
                        if (Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]) >= 0)
                        {
                            Ppg.Rows[i]["nCapitalPagado"] = 0.00m;
                        }
                        Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                        //break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]));
                        dtPagoDist.Rows[0]["nInteresPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]));
                        Ppg.Rows[i]["nInteresPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    #endregion

                    #region Pagar Capital
                    if (nMontoPagado == 0) break;
                    if ((Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"])) > nMontoPagado)
                    {
                        dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) + nMontoPagado;
                        Ppg.Rows[i]["nCapitalPagado"] = nMontoPagado;
                        nMontoPagado = 0.00m;
                        Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                        //break;
                    }
                    else
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        Ppg.Rows[i]["nCapitalPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }
                    #endregion

                    Ppg.Rows[i]["dFechaPago"] = DateTime.Today; // Debe guardar la fecha del sistema

                }
            }

            dtPagoDist.Rows[0]["nTotalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]);

            Ppg.AcceptChanges();
            dtPagoDist.AcceptChanges();
            return dtPagoDist;
        }

        public DataTable dtCNPagoDistConOrdenPrelacion(DataTable Ppg, decimal nMontoPagado, bool lPagaMora, DataTable dtOrdenPrelacion, clsPlanPagoFechaValor pagoFechaValor = null)
        {
            DataTable dtPagoDist = new DataTable("dtPagoDist");
            dtPagoDist.Columns.Add("nCapitalPag", typeof(decimal));
            dtPagoDist.Columns.Add("nInteresPag", typeof(decimal));
            dtPagoDist.Columns.Add("nIntCompPag", typeof(decimal));
            dtPagoDist.Columns.Add("nMoraPag", typeof(decimal));
            dtPagoDist.Columns.Add("nOtrosPag", typeof(decimal));
            dtPagoDist.Columns.Add("nTotalPag", typeof(decimal));

            dtPagoDist.Rows.Add(dtPagoDist.NewRow());
            dtPagoDist.Rows[0]["nOtrosPag"] = 0D;
            dtPagoDist.Rows[0]["nMoraPag"] = 0D;
            dtPagoDist.Rows[0]["nIntCompPag"] = 0D;
            dtPagoDist.Rows[0]["nInteresPag"] = 0D;
            dtPagoDist.Rows[0]["nCapitalPag"] = 0D;
            dtPagoDist.Rows[0]["nTotalPag"] = 0D;

            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (nMontoPagado == 0)
                {
                    Ppg.Rows[i]["nOtrosPagado"] = 0D;
                    Ppg.Rows[i]["nMoraPagada"] = 0D;
                    Ppg.Rows[i]["nInteresCompPago"] = 0D;
                    Ppg.Rows[i]["nInteresPagado"] = 0D;
                    Ppg.Rows[i]["nCapitalPagado"] = 0D;
                }
                else
                {
                    Ppg.Rows[i]["nCapitalPagado"] = 0.00;
                    Ppg.Rows[i]["nInteresPagado"] = 0.00;
                    Ppg.Rows[i]["nInteresCompPago"] = 0.00;
                    Ppg.Rows[i]["nMoraPagada"] = 0.00;
                    Ppg.Rows[i]["nOtrosPagado"] = 0.00;

                    //Caso capital negativo
                    if (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]) < 0)
                    {
                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                         (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                        Ppg.Rows[i]["nCapitalPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]);
                        nMontoPagado = Math.Round(nMontoPagado, 2);
                    }

                    foreach (DataRow drOrden in dtOrdenPrelacion.Rows)
                    {
                        if (nMontoPagado == 0) break;
                        switch (Convert.ToInt32(drOrden["idConcepto"]))
                        {
                            case 1://"CAPITAL":
                                #region Pagar Capital

                                if ((Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"])) == 0)
                                    continue;
                                if ((Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"])) > nMontoPagado)
                                {
                                    dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) + nMontoPagado;
                                    Ppg.Rows[i]["nCapitalPagado"] = nMontoPagado;
                                    nMontoPagado = 0.00m;
                                }
                                else
                                {
                                    nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                                    dtPagoDist.Rows[0]["nCapitalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                                     (Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]));
                                    Ppg.Rows[i]["nCapitalPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) - Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]);
                                    nMontoPagado = Math.Round(nMontoPagado, 2);
                                }
                                #endregion
                                break;
                            case 4://"INTERES":
                                #region Pago interes
                                if ((Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"])) > nMontoPagado)
                                {
                                    dtPagoDist.Rows[0]["nInteresPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) + nMontoPagado;
                                    Ppg.Rows[i]["nInteresPagado"] = nMontoPagado;
                                    nMontoPagado = 0.00m;
                                }
                                else
                                {
                                    nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]));
                                    dtPagoDist.Rows[0]["nInteresPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) +
                                                                     (Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]));
                                    Ppg.Rows[i]["nInteresPagado"] = Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]);
                                    nMontoPagado = Math.Round(nMontoPagado, 2);
                                }
                                #endregion
                                break;
                            case 24://"INT. COMPENSATORIO":
                                #region Pago interes compensatorio
                                if ((Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"])) > nMontoPagado)
                                {
                                    dtPagoDist.Rows[0]["nIntCompPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) + nMontoPagado;
                                    Ppg.Rows[i]["nInteresCompPago"] = nMontoPagado;
                                    nMontoPagado = 0.00m;
                                }
                                else
                                {
                                    nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]));
                                    dtPagoDist.Rows[0]["nIntCompPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) +
                                                                     (Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]));
                                    Ppg.Rows[i]["nInteresCompPago"] = Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) - Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]);
                                    nMontoPagado = Math.Round(nMontoPagado, 2);
                                }
                                #endregion
                                break;
                            case 3://"MORA":
                                #region Pago mora
                                if (pagoFechaValor != null && pagoFechaValor.nInteresMoratorioFechaValor > 0)
                                {
                                    if ((Convert.ToDecimal(pagoFechaValor.nInteresMoratorioFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"])) > nMontoPagado)
                                    {
                                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) + nMontoPagado;
                                        Ppg.Rows[i]["nMoraPagada"] = nMontoPagado;
                                        nMontoPagado = 0.00m;
                                        pagoFechaValor.nInteresMoratorioFechaValor -= nMontoPagado;
                                    }
                                    else
                                    {
                                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(pagoFechaValor.nInteresMoratorioFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                                         (Convert.ToDecimal(pagoFechaValor.nInteresMoratorioFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                                        Ppg.Rows[i]["nMoraPagada"] = Convert.ToDecimal(pagoFechaValor.nInteresMoratorioFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                                        nMontoPagado = Math.Round(nMontoPagado, 2);
                                        pagoFechaValor.nInteresMoratorioFechaValor -= nMontoPagado;
                                    }
                                }
                                else
                                {
                                    if ((Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"])) > nMontoPagado)
                                    {
                                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) + nMontoPagado;
                                        Ppg.Rows[i]["nMoraPagada"] = nMontoPagado;
                                        nMontoPagado = 0.00m;
                                    }
                                    else
                                    {
                                        nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                                        dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                                         (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                                        Ppg.Rows[i]["nMoraPagada"] = Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                                        nMontoPagado = Math.Round(nMontoPagado, 2);
                                    }
                                }
                                #endregion
                                break;
                            case 63://"GASTOS":
                                #region Pago otros
                                if (pagoFechaValor != null && pagoFechaValor.nOtrosFechaValor > 0)
                                {
                                    if ((Convert.ToDecimal(pagoFechaValor.nOtrosFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"])) > nMontoPagado)
                                    {
                                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) + nMontoPagado;
                                        Ppg.Rows[i]["nOtrosPagado"] = nMontoPagado;
                                        nMontoPagado = 0.00m;
                                        pagoFechaValor.nOtrosFechaValor -= nMontoPagado;
                                    }
                                    else
                                    {
                                        decimal nMontoPagadoTemp = (Convert.ToDecimal(pagoFechaValor.nOtrosFechaValor) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]));
                                        nMontoPagado -= nMontoPagadoTemp;
                                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) + nMontoPagadoTemp;
                                        Ppg.Rows[i]["nOtrosPagado"] = nMontoPagadoTemp;
                                        nMontoPagado = Math.Round(nMontoPagado, 2);
                                        pagoFechaValor.nOtrosFechaValor -= nMontoPagado;
                                    }
                                }
                                else
                                {
                                    if ((Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"])) > nMontoPagado)
                                    {
                                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) + nMontoPagado;
                                        Ppg.Rows[i]["nOtrosPagado"] = nMontoPagado;
                                        nMontoPagado = 0.00m;
                                    }
                                    else
                                    {
                                        decimal nMontoPagadoTemp = (Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) - Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]));
                                        nMontoPagado -= nMontoPagadoTemp;
                                        dtPagoDist.Rows[0]["nOtrosPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]) + nMontoPagadoTemp;
                                        Ppg.Rows[i]["nOtrosPagado"] = nMontoPagadoTemp;
                                        nMontoPagado = Math.Round(nMontoPagado, 2);
                                    }
                                }
                                #endregion
                                break;
                            default:
                                break;
                        }
                    }

                    Ppg.Rows[i]["dFechaPago"] = clsVarGlobal.dFecSystem.Date; // Debe guardar la fecha del sistema
                    if (pagoFechaValor != null)
                    {
                        Ppg.Rows[i]["dFechaPago"] = pagoFechaValor.dFechaPagoCanalExterno;
                        Ppg.Rows[i]["dFechaValor"] = pagoFechaValor.dFechaValorizacion;
                    }
                }
            }

            dtPagoDist.Rows[0]["nTotalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nIntCompPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]);

            Ppg.AcceptChanges();
            dtPagoDist.AcceptChanges();
            return dtPagoDist;
        }

        public DataTable dtCNDistriPagoMora(DataTable Ppg, decimal nMontoPagado)
        {
            DataTable dtPagoDist = new DataTable("dtPagoDist");
            dtPagoDist.Columns.Add("nCapitalPag", typeof(decimal));
            dtPagoDist.Columns.Add("nInteresPag", typeof(decimal));
            dtPagoDist.Columns.Add("nMoraPag", typeof(decimal));
            dtPagoDist.Columns.Add("nOtrosPag", typeof(decimal));
            dtPagoDist.Columns.Add("nTotalPag", typeof(decimal));
            dtPagoDist.Rows.Add(dtPagoDist.NewRow());
            dtPagoDist.Rows[0]["nOtrosPag"] = 0.0;
            dtPagoDist.Rows[0]["nMoraPag"] = 0.0;
            dtPagoDist.Rows[0]["nInteresPag"] = 0.0;
            dtPagoDist.Rows[0]["nCapitalPag"] = 0.0;
            dtPagoDist.Rows[0]["nTotalPag"] = 0.0;

            for (int i = 0; i < Ppg.Rows.Count; i++)
            {

                //Pagando la Mora
                if ((Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"])) > nMontoPagado)
                {
                    dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) + nMontoPagado;
                    Ppg.Rows[i]["nMoraPagada"] = nMontoPagado;
                    nMontoPagado = 0.00m;
                    Ppg.Rows[i]["dFechaPago"] = DateTime.Today; // Debe guardar la fecha del sistema
                    break;
                }
                else
                {
                    nMontoPagado = nMontoPagado - (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                    dtPagoDist.Rows[0]["nMoraPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                     (Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]));
                    Ppg.Rows[i]["nMoraPagada"] = Convert.ToDecimal(Ppg.Rows[i]["nMora"]) - Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);
                    nMontoPagado = Math.Round(nMontoPagado, 2);
                }

                Ppg.Rows[i]["dFechaPago"] = DateTime.Today; // Debe guardar la fecha del sistema
            }

            dtPagoDist.Rows[0]["nTotalPag"] = Convert.ToDecimal(dtPagoDist.Rows[0]["nCapitalPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nInteresPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nMoraPag"]) +
                                                   Convert.ToDecimal(dtPagoDist.Rows[0]["nOtrosPag"]);
            Ppg.AcceptChanges();
            dtPagoDist.AcceptChanges();
            return dtPagoDist;
        }

        ///método que calcula el plan de pagos
        public DataTable CalculaPpg(decimal nMonDesemb, decimal nTasEfeMen, DateTime dFecDesemb,
                                    int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag,
                                    int nNumsolicitud, decimal nTasSegDesgra, decimal nTasSegMulRie)
        {
            double nTasEfeDia = Math.Pow((1.0 + (double)nTasEfeMen), (1.0 / 360.0)) - 1; //Tasa de interes efectiva diaria

            int nDiaAcumul = 0;
            decimal nFacRecCap = 0.00m;
            decimal nFacAcumul = 0.00m;
            int nValRedond = 10;
            DateTime dFecNewCuo = dFecDesemb.AddDays(Convert.ToDouble(nDiaGraCta));
            DateTime DfecVeriFec;
            decimal nCuoSugIni = 0.00m;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));
            ppg.Columns.Add("frc", typeof(decimal));
            ppg.Columns.Add("sal_cap", typeof(decimal));
            ppg.Columns.Add("capital", typeof(decimal));
            ppg.Columns.Add("interes", typeof(decimal));
            ppg.Columns.Add("comisiones", typeof(decimal));
            ppg.Columns.Add("itf", typeof(decimal));
            ppg.Columns.Add("imp_cuota", typeof(decimal));
            ppg.Columns.Add("nIdSolicitud", typeof(int));

            int nNumMesCuo = 0;
            int nNumAñoCuo = 0;

            //Cargando la tabla de feriados
            DataTable dtFeriado = new DataTable("dtFeriado");
            clsADFeriado CNFeriado = new clsADFeriado();
            dtFeriado = CNFeriado.ADdtFeriado();
            int nDiaAdicionalFeriado = 0;
            int nFeriadoAcumulado = 0;


            if (nTipPerPag == 1) //Fecha Fija
            {
                if (nDiaGraCta == 0)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));

                    //Si frecuencia de pago es diaria y la fecha de la cuota cae en día feriado
                }
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = i;
                    if (i == 1) // Si primera cuota
                    {

                        if ((dFecNewCuo.Day > nDiaFecPag))
                        {
                            nNumMesCuo = dFecNewCuo.Month + 1;
                        }
                        else
                        {
                            nNumMesCuo = dFecNewCuo.Month;
                        }

                        if (dFecNewCuo.Month == nNumMesCuo)
                        {
                            nNumMesCuo++;
                        }

                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    nDiaFecAux = nDiaFecPag;
                    while (true)
                    {
                        if (DateTime.TryParse((nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString()), out DfecVeriFec))
                        {
                            dFecNewCuo = DateTime.Parse(nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString());
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1;
                    }

                    if (i == 1)
                    {
                        if ((dFecNewCuo - dFecDesemb).Days < 20)
                        {
                            dFecNewCuo = dFecNewCuo.AddMonths(1);
                        }
                    }

                    fila["fecha"] = dFecNewCuo;
                    if (i == 1)
                    {
                        fila["dias"] = (dFecNewCuo - dFecDesemb).Days;
                    }
                    else
                    {
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(ppg.Rows[i - 2]["fecha"])).Days; //FALTA VERIFICAR
                    }
                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;
                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul));
                    nFacAcumul = nFacAcumul + nFacRecCap;
                    fila["frc"] = nFacRecCap;
                    ppg.Rows.Add(fila);
                }
            }
            else //Periodo Fijo
            {
                //nDiaAdicionalFeriado = 0;
                nFeriadoAcumulado = 0;
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = i;
                    if (i == 1)
                    {
                        nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaAcumul - nDiaGraCta));
                        //Si frecuencia de pago es diaria y la fecha de la cuota cae en día feriado
                        if (nDiaFecPag == 1)
                        {
                            for (int j = 0; j < dtFeriado.Rows.Count; j++)
                            {
                                if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                                {
                                    nDiaAcumul = nDiaAcumul + 1;
                                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                                    nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                                    nFeriadoAcumulado++;
                                    //break;
                                }
                            }
                        }
                        fila["fecha"] = dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                        fila["dias"] = nDiaFecPag + nDiaGraCta + nDiaAdicionalFeriado;
                        fila["dias_acu"] = nDiaAcumul;
                        nDiaAdicionalFeriado = 0;
                    }
                    else
                    {
                        nDiaAcumul = nDiaAcumul + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                        if (nDiaFecPag == 1)
                        {
                            for (int j = 0; j < dtFeriado.Rows.Count; j++)
                            {
                                if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                                {
                                    nDiaAcumul = nDiaAcumul + 1;
                                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                                    nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                                    nFeriadoAcumulado++;
                                    //break;
                                }
                            }
                        }

                        fila["fecha"] = dFecNewCuo;
                        fila["dias"] = nDiaFecPag + nDiaAdicionalFeriado;
                        fila["dias_acu"] = nDiaAcumul;
                        nDiaAdicionalFeriado = 0;
                    }
                    nFacRecCap = nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), (nDiaAcumul - nFeriadoAcumulado)));
                    nFacAcumul = nFacAcumul + nFacRecCap;
                    fila["frc"] = nFacRecCap;
                    ppg.Rows.Add(fila);
                }
            }

            nCuoSugIni = Math.Round(nMonDesemb / nFacAcumul, nValRedond);
            decimal nMonCuoAux = nCuoSugIni; //Auxiliar para buscar la cuota sugerida óptima
            int nNumIterac = 0; //Número de iteraciones en total
            decimal nMonSalCap = nMonDesemb; //Saldo de Capital

            int nMaxIterac = 20; // Máximo de Iteraciones
            decimal nValErrMax = 0.5m; //Valor máximo de error

            bool lFlgFactor = false;    //Flag para controlar la multiplicación o división de 2
            int nIteraTrue = 0;          //Numero de iteraciones a ser tomadas en cuenta
            bool lIndSalIte = false;     //Flag que contrala la salida del bucle cuando la razon sea 0
            int lNumSalIte = 0;          //Posicion actual del bucle para su salida
            int nDiaCuoCta = 0;
            decimal nMonIntCuo = 0.00m;
            decimal nMonCapCuo = 0.00m;
            decimal nMonCuoSin = 0.00m;
            decimal nItf = 0.00m;
            decimal nMonSegDesgra = 0.00m;
            decimal nMonSegMulRie = 0.00m;
            decimal nPotencDos = 2.00m;
            decimal nRazBusCuo = 0.00m;

            DataTable tabitera = new DataTable();
            clsFunUtiles FunUtiles = new clsFunUtiles();
            tabitera.Columns.Add("salcap", typeof(decimal));
            tabitera.Columns.Add("razbus", typeof(decimal));
            tabitera.Columns.Add("poten2", typeof(int));
            tabitera.Columns.Add("cuosug", typeof(decimal));

            while (Math.Abs(nMonSalCap) > nValErrMax & nNumIterac < nMaxIterac)
            {
                nMonSalCap = nMonDesemb;
                for (int i = 0; i < nNumCuoCta; i++)
                {
                    //nMonCuoAux = System.Math.Round(nMonCuoAux, 1);
                    clsCNOperArit FunAritmetic = new clsCNOperArit();
                    nMonCuoAux = FunAritmetic.RedxExceso(nMonCuoAux, 1);
                    nDiaCuoCta = Convert.ToInt32(ppg.Rows[i]["dias"]);

                    //Temporalmente se calculará los interéses por 1 día pesea a haber feriados//

                    if (nDiaFecPag == 1)// si frecuencia de pago es diaria
                    {
                        if (i == 0) // Si es la primera cuota se calcula con los días de la cuota, si la cuota cae en domigno no es necesario incluir días de gracia para que caiga lunes (para incluir los días de gracia)
                        {
                            nMonIntCuo = Math.Round(((nMonSalCap * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nMonSalCap), 2);
                        }
                        else
                        {
                            nMonIntCuo = Math.Round(((nMonSalCap * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaFecPag))) - nMonSalCap), 2);
                        }
                    }
                    else
                    {
                        nMonIntCuo = Math.Round(((nMonSalCap * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nMonSalCap), 2);
                    }

                    //ppg.Columns.Add("comisiones", typeof(decimal));
                    //ppg.Columns.Add("Itf", typeof(decimal));
                    //decimal nMonSegDesgra = 0.00;
                    //decimal nMonSegMulRie = 0.00;

                    //se modifico para redondeo a 1 decimal
                    nMonCapCuo = Math.Round(nMonCuoAux - nMonIntCuo, 2);// - nMonSegCuo
                    nMonCuoSin = Math.Round(nMonCuoAux, 2);

                    //nItf =  0.0005 * //clsVarGlobal
                    nMonSegDesgra = Math.Round(nMonSalCap * nTasSegDesgra / 100, 2);
                    nMonSegMulRie = Math.Round(nMonSalCap * nTasSegMulRie / 100, 2);
                    nItf = 0;// FunUtiles.truncar(((nMonCuoSin + nMonSegDesgra + nMonSegMulRie) * Convert.ToDecimal (clsVarGlobal.nITF) / 100.00), 2, 1);
                    ppg.Rows[i]["Itf"] = Math.Round(nItf, 2);
                    ppg.Rows[i]["imp_cuota"] = Math.Round(nMonCuoSin + nMonSegDesgra + nMonSegMulRie + nItf, 1);
                    ppg.Rows[i]["comisiones"] = Math.Round(nMonSegDesgra + nMonSegMulRie, 2);
                    ppg.Rows[i]["interes"] = Math.Round(nMonIntCuo, 2);
                    ppg.Rows[i]["capital"] = Math.Round(nMonCapCuo, 2);
                    nMonSalCap = nMonSalCap - nMonCapCuo;
                    ppg.Rows[i]["sal_cap"] = Math.Round(nMonSalCap, 2);
                    ppg.Rows[i]["nIdSolicitud"] = nNumsolicitud;

                }

                nNumIterac = nNumIterac + 1;

                if (nIteraTrue > 0)
                {
                    if (nMonSalCap < 0)
                    {
                        nPotencDos = nPotencDos / 2;
                        nMonSalCap = Convert.ToDecimal(tabitera.Rows[(nIteraTrue - 1)]["salcap"]);
                        nMonCuoAux = Convert.ToDecimal(tabitera.Rows[(nIteraTrue - 1)]["cuosug"]) - Convert.ToDecimal(tabitera.Rows[(nIteraTrue - 1)]["razbus"]);

                        lFlgFactor = true;
                    }
                    else
                    {
                        if (lFlgFactor == false)
                        {
                            nPotencDos = nPotencDos * 2;
                        }
                    }
                }
                else
                {
                    nPotencDos = 2;
                }

                nRazBusCuo = Math.Round(nMonSalCap * nPotencDos / (nDiaAcumul - nFeriadoAcumulado), nValRedond);
                nMonCuoAux = nMonCuoAux + nRazBusCuo;

                tabitera.Rows.Add(tabitera.NewRow());
                tabitera.Rows[nIteraTrue]["salcap"] = nMonSalCap;
                tabitera.Rows[nIteraTrue]["razbus"] = nRazBusCuo;
                tabitera.Rows[nIteraTrue]["poten2"] = nPotencDos;
                tabitera.Rows[nIteraTrue]["cuosug"] = nMonCuoAux;

                nIteraTrue = nIteraTrue + 1;

                if (nRazBusCuo == 0)
                {
                    if (lIndSalIte == false)
                    {
                        lIndSalIte = true;
                        lNumSalIte = nNumIterac;
                    }
                    nMonCuoAux = nMonCuoAux + 0.01m; // con un decimal
                }
                if ((nNumIterac == (lNumSalIte + 1)) & lNumSalIte > 0)
                {
                    break;
                }
            }

            // Ajustando la última cuota
            decimal nSumCapital = 0.0m;
            for (int i = 0; i < nNumCuoCta - 1; i++)
            {
                nSumCapital = nSumCapital + Convert.ToDecimal(ppg.Rows[i]["capital"]);
            }

            nMonSegDesgra = Math.Round(Math.Round(nMonDesemb - nSumCapital, 1) * nTasSegDesgra / 100, 2);
            nMonSegMulRie = Math.Round(Math.Round(nMonDesemb - nSumCapital, 1) * nTasSegMulRie / 100, 2);

            ppg.Rows[nNumCuoCta - 1]["sal_cap"] = 0.0;
            ppg.Rows[nNumCuoCta - 1]["capital"] = Math.Round(nMonDesemb - nSumCapital, 2);
            nMonIntCuo = Math.Round((((nMonDesemb - nSumCapital) * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - (nMonDesemb - nSumCapital)), 2);
            ppg.Rows[nNumCuoCta - 1]["interes"] = nMonIntCuo;

            nItf = 0;// FunUtiles.truncar((Math.Round(Math.Round(nMonDesemb - nSumCapital, 2) + nMonIntCuo + nMonSegDesgra + nMonSegMulRie, 1) * Convert.ToDecimal (clsVarGlobal.nITF) / 100.00), 2, 1);

            ppg.Rows[nNumCuoCta - 1]["Itf"] = Math.Round(nItf, 2);
            ppg.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(Math.Round(nMonDesemb - nSumCapital, 2) + nMonIntCuo + nMonSegDesgra + nMonSegMulRie + nItf, 2);

            //fila["capital"] = FunAritmetic.RedxDefecto(nMonDesemb - nMonCapAcum, 1);
            //fila["interes"] = FunAritmetic.RedxDefecto((nMonDevolver - nMonCuoAcum) - (nMonDesemb - nMonCapAcum), 1);
            //fila["imp_cuota"] = FunAritmetic.RedxDefecto(nMonDevolver - nMonCuoAcum, 1);
            //fila["nIdSolicitud"] = nNumsolicitud;

            ppg.AcceptChanges();
            tabitera.AcceptChanges();
            //this.dtgBase1.DataSource = ppg;
            //this.dtgBase2.DataSource = tabitera;
            return ppg;
        }

        public decimal nNumCuoAdelanto(DataTable Ppg, decimal nMontoPago)
        {
            decimal nCuotaAde = 0;
            decimal nSaldoCuota = 0m;
            decimal nCuotaProgramada = 0m;
            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                if (Convert.ToInt16(Ppg.Rows[i]["idEstadoCuota"]) == 2) continue;//Cuotas pagadas
                nSaldoCuota = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) -
                                    Convert.ToDecimal(Ppg.Rows[i]["nCapitalPagado"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) -
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresPagado"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) -
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresCompPago"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) -
                                    Convert.ToDecimal(Ppg.Rows[i]["nOtrosPagado"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nMora"]) -
                                    Convert.ToDecimal(Ppg.Rows[i]["nMoraPagada"]);

                nCuotaProgramada = Convert.ToDecimal(Ppg.Rows[i]["nCapital"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteres"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nInteresComp"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nOtros"]) +
                                    Convert.ToDecimal(Ppg.Rows[i]["nMora"]);

                if (nMontoPago >= nSaldoCuota)
                {
                    nMontoPago -= nSaldoCuota;
                    if (Convert.ToInt32(Ppg.Rows[i]["nAtrasoCuota"]) <= 0)
                    {
                        if (nSaldoCuota < nCuotaProgramada)
                        {
                            nCuotaAde += Convert.ToDecimal(nSaldoCuota / nCuotaProgramada);
                        }
                        else
                        {
                            nCuotaAde += 1;
                        }
                    }

                }
                else
                {
                    nMontoPago -= nMontoPago;
                    if (Convert.ToInt32(Ppg.Rows[i]["nAtrasoCuota"]) <= 0)
                    {
                        nCuotaAde += Convert.ToDecimal(nMontoPago / nSaldoCuota);
                    }
                }
            }
            return nCuotaAde;
        }

        #endregion

        #region CalculaPp2

        public DataTable CalculaPpg2(decimal nMonDesemb, decimal nTasEfeMen, DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta,
                                    short nTipPerPag, int nDiaFecPag, int nNumsolicitud, DataTable dtCargaGastos, int nTipoMoneda)
        {

            //Recorrer el dtCargaGastos -- Para clasificar en TIPOS DE GASTO
            //Verificar si se esta afectando a Saldo de Capital con %Compuesto
            decimal nTotalTasaEfectivaDiariaGastoTipo1 = 0;

            //Calcular la Tasa Efectiva Diaria cuando se aplique al SALDO CAPITAL: para el luego usarlo en el FRC
            //y deacuerdo a ésto se usar interpolación para hallar la cuota Inicial que incluya a éstos Gastos
            for (int i = 0; i < dtCargaGastos.Rows.Count; i++)
            {
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                {
                    if (dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        dtCargaGastos.Rows[i]["nClasificTipoGasto"] = 1;

                        //Se usará una Tasa Compuesta -- Sólo para este caso
                        decimal nValorTasa = Convert.ToDecimal(dtCargaGastos.Rows[i]["nGasto"]);
                        dtCargaGastos.Rows[i]["nTasaEfectivaDiaria"] = Math.Pow((1.0 + (double)nValorTasa), (1.0 / 30.0)) - 1;//Se utiliza TASA COMPUESTA
                        nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + Convert.ToDecimal(Math.Pow((1.0 + (double)nValorTasa), (1.0 / 30.0)) - 1);
                    }
                }
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                {
                    dtCargaGastos.Rows[i]["nClasificTipoGasto"] = 2;
                    if (dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nValorTasa = Convert.ToDecimal(dtCargaGastos.Rows[i]["nGasto"]);
                        dtCargaGastos.Rows[i]["nTasaEfectivaDiaria"] = nValorTasa / 30; //Se utiliza TASA SIMPLE
                    }
                }

                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                {
                    dtCargaGastos.Rows[i]["nClasificTipoGasto"] = 2;
                }
            }

            double nTasEfeDia = Math.Pow((1.0 + (double)nTasEfeMen), (1.0 / 30.0)) - 1; //Tasa de interes efectiva diaria
            //decimal nTasSegDesDia = Math.Pow((1.0 + nTasSegDesgra), (1.0 / 30.0)) - 1; //Tasa de seguro desgravamen diaria - si la tasa es compuesta
            //decimal nTasSegDesDia = nTasSegDesgra/ 30.0; //Tasa de seguro desgravamen diaria - se aplica esta fórmula si la tasa es simple
            //Se está cambiando x nTotalTasaEfectivaDiariaGastoTipo1

            int nDiaAcumul = 0;
            decimal nFacRecCap = 0.00m;
            decimal nFacAcumul = 0.00m;
            decimal nFacRecOtr = 0.00m;
            decimal nFacAcumOtr = 0.00m;
            DateTime dFecNewCuo = dFecDesemb.AddDays(Convert.ToDouble(nDiaGraCta)); //la fecha de la cuota siguiente será la del desembolso + la gracia
            DateTime DfecVeriFec;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));
            ppg.Columns.Add("frc", typeof(decimal));
            ppg.Columns.Add("sal_cap", typeof(decimal));
            ppg.Columns.Add("capital", typeof(decimal));
            ppg.Columns.Add("interes", typeof(decimal));
            ppg.Columns.Add("comisiones", typeof(decimal));
            ppg.Columns.Add("itf", typeof(decimal));
            ppg.Columns.Add("imp_cuota", typeof(decimal));
            ppg.Columns.Add("nIdSolicitud", typeof(int));

            int nNumMesCuo = 0;
            int nNumAñoCuo = 0;

            //Para definir las la Cuota se debe tener en cuenta solo los Gastos de tipo 1 (Los que afectana a SALDO CAPITAL y son Porcentuales Compuestas a la vez)
            //e incluirlos en el cálculo del factor de recuperación de Capital (FRC)

            #region DefineFechas

            if (nTipPerPag == 1) //Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)
            {
                if (nDiaGraCta == 0) // Para evitar que la primera cuota se genere el mismo día del desembolso (con 0 días)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                }
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = i;
                    if (i == 1) // Si primera cuota
                    {
                        if ((dFecNewCuo.Day > nDiaFecPag)) // La primera cuota caerá el siguiente mes de la (fecha de desembolso + los días de gracia)
                        {
                            nNumMesCuo = dFecNewCuo.Month + 1;
                        }
                        else //La cuota caera en el mismo mes de la (fecha de desembolso + los días de gracia)
                        {
                            nNumMesCuo = dFecNewCuo.Month;
                        }
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else // A partir de la 2da cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    nDiaFecAux = nDiaFecPag;
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (DateTime.TryParse((nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString()), out DfecVeriFec))
                        {
                            dFecNewCuo = DateTime.Parse(nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString());
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1; // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                    }

                    if (i == 1)
                    {
                        if ((dFecNewCuo - dFecDesemb).Days < 20)
                        {
                            dFecNewCuo = dFecNewCuo.AddMonths(1);
                        }
                    }

                    fila["fecha"] = dFecNewCuo;
                    // caluclando la cantidad de días para la cuota
                    if (i == 1) // para la primera cuota
                    {
                        fila["dias"] = (dFecNewCuo - dFecDesemb).Days;
                    }
                    else //Para las cuotas de la segunda en adelante
                    {
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(ppg.Rows[i - 2]["fecha"])).Days;
                    }
                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;
                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul)); //calculando el FRC de la cuota

                    //nFacRecOtr = 1 / Math.Pow((1 + (nTasEfeDia + nTasSegDesDia)), nDiaAcumul); //calculando el FRC que incluya gastos de la cuota
                    nFacRecOtr = 1 / Convert.ToDecimal(Math.Pow((1 + (nTasEfeDia + (double)nTotalTasaEfectivaDiariaGastoTipo1)), nDiaAcumul)); //calculando el FRC que incluya gastos de la cuota
                    //nFacRecOtr = 1 / Math.Pow((1 + (nTasEfeDia + TotalTasaEfectivaDiariaGastoTipo1(ref dtCargaGastos, i, nNumCuoCta))), nDiaAcumul); //calculando el FRC que incluya gastos de la cuota

                    nFacAcumul = nFacAcumul + nFacRecCap; //Acumulando el FRC
                    nFacAcumOtr = nFacAcumOtr + nFacRecOtr; // Acumulando el FRC que incluye gastos
                    fila["frc"] = nFacRecCap;
                    ppg.Rows.Add(fila);
                }
            }
            else //Periodo Fijo
            {
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = ppg.NewRow();
                    fila["cuota"] = i; //registrando la cuota
                    if (i == 1) //Para la primera cuota
                    {
                        nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaAcumul - nDiaGraCta));// se le resta los días de gracia porque ya se le sumo al inico (se duplicaría)
                        fila["fecha"] = dFecNewCuo; //dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                        fila["dias"] = nDiaFecPag + nDiaGraCta;
                        fila["dias_acu"] = nDiaAcumul;
                    }
                    else
                    {
                        nDiaAcumul = nDiaAcumul + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                        fila["fecha"] = dFecNewCuo;
                        fila["dias"] = nDiaFecPag;
                        fila["dias_acu"] = nDiaAcumul;
                    }
                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul)); //calculando el FRC de la cuota

                    nFacRecOtr = 1 / Convert.ToDecimal(Math.Pow((1 + (nTasEfeDia + (double)nTotalTasaEfectivaDiariaGastoTipo1)), nDiaAcumul)); //calculando el FRC que incluya gastos de la cuota

                    nFacAcumul = nFacAcumul + nFacRecCap; //Acumulando el FRC
                    nFacAcumOtr = nFacAcumOtr + nFacRecOtr; // Acumulando el FRC que incluye gastos
                    fila["frc"] = nFacRecCap;
                    ppg.Rows.Add(fila);
                }
            }

            #endregion

            decimal nCuotaFinal = 0.0m;
            decimal nCuotaFRC = 0.0m;
            decimal nCuotaFRCGas = 0.0m;
            int nValRedond = 1;
            clsCNOperArit FunAritmetic = new clsCNOperArit();
            clsFunUtiles FunUtiles = new clsFunUtiles();
            nCuotaFRC = FunAritmetic.RedxExceso(nMonDesemb / nFacAcumul, nValRedond);
            nCuotaFRCGas = FunAritmetic.RedxExceso(nMonDesemb / nFacAcumOtr, nValRedond);
            decimal nSalCapFRC;
            decimal nSalCapFRCGas;
            decimal nSalCapital;

            int nDiaCuoCta = 0;
            decimal nMonIntCuo = 0.00m;
            decimal nMonCapCuo = 0.00m;
            decimal nItf = 0.00m;
            decimal nMonSegDesgra = 0.00m;
            decimal nMonSegMulRie = 0.00m;

            if (nCuotaFRC != nCuotaFRCGas) //Si las cuota con FRC y la cuota con FRCGas son diferentes (para interpolar)
            {
                //PPG con FRC
                nSalCapFRC = nMonDesemb;
                for (int i = 0; i < nNumCuoCta; i++)
                {
                    nDiaCuoCta = Convert.ToInt32(ppg.Rows[i]["dias"]);
                    nMonIntCuo = Math.Round(((nSalCapFRC * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapFRC), 2);

                    nMonSegDesgra = Math.Round(nSalCapFRC * nTotalTasaEfectivaDiariaGastoTipo1 * nDiaCuoCta / 100, 2);

                    nMonCapCuo = nCuotaFRC - nMonIntCuo - nMonSegDesgra;
                    nSalCapFRC = Math.Round(nSalCapFRC - nMonCapCuo, 2);
                }
                //PPG con FRC que incluye Gastos
                nSalCapFRCGas = nMonDesemb;
                for (int i = 0; i < nNumCuoCta; i++)
                {
                    nDiaCuoCta = Convert.ToInt32(ppg.Rows[i]["dias"]);
                    nMonIntCuo = Math.Round(((nSalCapFRCGas * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapFRCGas), 2);

                    nMonSegDesgra = Math.Round(((nSalCapFRCGas * Convert.ToDecimal(Math.Pow((1 + (double)nTotalTasaEfectivaDiariaGastoTipo1), nDiaCuoCta))) - nSalCapFRCGas), 2); //cambiar por la suma de gastos que influyen en la cuota

                    nMonCapCuo = nCuotaFRCGas - nMonIntCuo - nMonSegDesgra;
                    nSalCapFRCGas = Math.Round(nSalCapFRCGas - nMonCapCuo, 2);
                }
                //INTERPOLANDO
                nCuotaFinal = Math.Round(((nCuotaFRC - nCuotaFRCGas) * (0 - nSalCapFRCGas) / (nSalCapFRC - nSalCapFRCGas)) + nCuotaFRCGas, nValRedond); //obtenemos la cuota final INTERPOLANDO
            }
            else
            {
                nCuotaFinal = nCuotaFRCGas;//Si la cuota FRC y la cuota FRC con gastos son iguales da lo mismo tomar cualquiera para cuota final
            }

            //PPG FINAL

            nSalCapital = nMonDesemb;
            for (int i = 0; i < nNumCuoCta; i++)
            {
                nMonSegDesgra = 0;//Para usarlo como acumulador -- Gastos tipo 1
                nMonSegMulRie = 0;//Para usarlo como acumulador -- Gastos tipo 2

                nDiaCuoCta = Convert.ToInt32(ppg.Rows[i]["dias"]);
                nMonIntCuo = Math.Round(((nSalCapital * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapital), 2);
                //nMonSegDesgra = Math.Round(nSalCapital * nTasSegDesDia * nDiaCuoCta / 100, 2);

                //RSH --Recorrer dtCargaGastos para calcular los montos de acuerdo al campo que afecta
                for (int f = 0; f < dtCargaGastos.Rows.Count; f++)
                {
                    //Para los Gastos Tipo 1
                    if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nTasaEfectivaDiaria"]);
                        nMonSegDesgra = nMonSegDesgra + Math.Round(nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                    }

                    //Para los Gastos tipo 2
                    if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                    {
                        if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nTasaEfectivaDiaria"]);
                            nMonSegMulRie = nMonSegMulRie + Math.Round(nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                        }

                        if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                            nMonSegMulRie = nMonSegMulRie + Math.Round(nMonDesemb * nTasaCalculadaDelTipoGasto / 100, 2);
                        }

                        if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                            //nMonSegMulRie = nMonSegMulRie + Math.Round((nMonCapCuo + nMonIntCuo) * nTasaC´+ñ{ñ}{ñ}ñalculadaDelTipoGasto / 100, 2);
                            nMonSegMulRie = nMonSegMulRie + Math.Round((
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))
                                + nMonIntCuo) * nTasaCalculadaDelTipoGasto / 100, 2);
                        }

                        if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("CAPITAL"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                            //nMonSegMulRie = nMonSegMulRie + Math.Round(nMonCapCuo * nTasaCalculadaDelTipoGasto / 100, 2);
                            nMonSegMulRie = nMonSegMulRie + Math.Round(
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100)) * (nTasaCalculadaDelTipoGasto / 100)
                                , 2);
                        }
                    }

                    //Para los Gastos tipo 2 -- FIJOS
                    if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("FIJO"))
                    {
                        nMonSegMulRie = nMonSegMulRie + Math.Round(Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]), 2);
                    }
                }

                //nMonSegMulRie = Math.Round(nMonDesemb * nTasSegMulRie / 100, nValRedond); // Lo redondeamos con los mismos digitos que la cuota porque se sumará directamente a la cuota

                nMonCapCuo = nCuotaFinal - nMonIntCuo - nMonSegDesgra;
                nItf = FunUtiles.truncar(((nCuotaFinal + nMonSegMulRie) * Convert.ToDecimal(clsVarGlobal.nITF) / 100.00m), 2, nTipoMoneda);
                ppg.Rows[i]["Itf"] = Math.Round(nItf, 2);
                ppg.Rows[i]["imp_cuota"] = Math.Round(nCuotaFinal + nMonSegMulRie + nItf, 2);
                ppg.Rows[i]["comisiones"] = Math.Round(nMonSegDesgra + nMonSegMulRie, 2);
                ppg.Rows[i]["interes"] = Math.Round(nMonIntCuo, 2);
                ppg.Rows[i]["capital"] = Math.Round(nMonCapCuo, 2);
                ppg.Rows[i]["sal_cap"] = Math.Round(nSalCapital, 2);
                nSalCapital = Math.Round(nSalCapital - nMonCapCuo, 2);
                ppg.Rows[i]["nIdSolicitud"] = nNumsolicitud;
            }

            // Ajustando la última cuota
            decimal nSumCapital = 0.0m;
            for (int i = 0; i < nNumCuoCta - 1; i++)
            {
                nSumCapital = nSumCapital + Convert.ToDecimal(ppg.Rows[i]["capital"]);
            }

            ppg.Rows[nNumCuoCta - 1]["sal_cap"] = Math.Round((nMonDesemb - nSumCapital), 2); ;
            ppg.Rows[nNumCuoCta - 1]["capital"] = Math.Round((nMonDesemb - nSumCapital), 2);
            nMonIntCuo = Math.Round((((nMonDesemb - nSumCapital) * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - (nMonDesemb - nSumCapital)), 2);

            //nMonSegDesgra = Math.Round((nMonDesemb - nSumCapital) * nTasSegDesgra / 100, 2);//-->
            //nMonSegMulRie = Math.Round(nMonDesemb * nTasSegMulRie / 100, 1);//-->
            nMonSegDesgra = 0;
            nMonSegMulRie = 0;

            nMonSegMulRie = 0;
            for (int f = 0; f < dtCargaGastos.Rows.Count; f++)
            {
                //Para los Gastos Tipo 1
                if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                {
                    decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nTasaEfectivaDiaria"]);
                    //nMonSegDesgra = nMonSegDesgra + Math.Round(nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                    nMonSegDesgra = nMonSegDesgra + Math.Round((nMonDesemb - nSumCapital) * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                }

                //Para los Gastos tipo 2
                if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                {
                    if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nTasaEfectivaDiaria"]);
                        //nMonSegMulRie = nMonSegMulRie + Math.Round(nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                        nMonSegMulRie = nMonSegMulRie + Math.Round((nMonDesemb - nSumCapital) * nTasaCalculadaDelTipoGasto * nDiaCuoCta / 100, 2);
                    }

                    if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                        nMonSegMulRie = nMonSegMulRie + Math.Round(nMonDesemb * nTasaCalculadaDelTipoGasto / 100, 2);
                    }

                    if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                        nMonSegMulRie = nMonSegMulRie + Math.Round((
                            ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))
                            + nMonIntCuo) * nTasaCalculadaDelTipoGasto / 100, 2);
                    }

                    if (dtCargaGastos.Rows[f]["cIdAplicaConcepto"].Equals("CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]);
                        nMonSegMulRie = nMonSegMulRie + Math.Round(
                            ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100)) * (nTasaCalculadaDelTipoGasto / 100)
                            , 2);
                    }
                }
                //Para los Gastos tipo 2 -- FIJOS
                if (dtCargaGastos.Rows[f]["cIdTipoValor"].Equals("FIJO"))
                {
                    nMonSegMulRie = nMonSegMulRie + Math.Round(Convert.ToDecimal(dtCargaGastos.Rows[f]["nGasto"]), 2);
                }
            }


            ppg.Rows[nNumCuoCta - 1]["interes"] = Math.Round(nMonIntCuo, 2);
            ppg.Rows[nNumCuoCta - 1]["comisiones"] = Math.Round(nMonSegDesgra + nMonSegMulRie, 2);//-->
            nItf = FunUtiles.truncar(((Math.Round((nMonDesemb - nSumCapital) + nMonIntCuo + nMonSegDesgra, nValRedond) + nMonSegMulRie) * Convert.ToDecimal(clsVarGlobal.nITF) / 100.00m), 2, nTipoMoneda);//-->
            ppg.Rows[nNumCuoCta - 1]["Itf"] = Math.Round(nItf, 2);
            ppg.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(Math.Round((nMonDesemb - nSumCapital) + nMonIntCuo + nMonSegDesgra, nValRedond) + nMonSegMulRie + nItf, 2);//-->
            ppg.AcceptChanges();
            return ppg;
        }
        #endregion

        public DataTable CNRegistrarSolHojaTramite(int idSolicitudHojaTramite, int idUsuarioRegistra, int idTipoOperacion, int idCuenta, int idCliPagador, int idTipoPagador, bool lCartaPoder, int idTipoOpePrePago, int nIdKardex)
        {
            return objPlanPago.ADRegistrarSolHojaTramite(idSolicitudHojaTramite, idUsuarioRegistra, idTipoOperacion, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, nIdKardex);
        }

        public DataTable CNObtenerVoucherHojaTramite(int idSolicitudHojaTramite, int idTipoOperacion)
        {
            return objPlanPago.ADObtenerVoucherHojaTramite(idSolicitudHojaTramite, idTipoOperacion);
        }

        private decimal TotalTasaEfectivaDiariaGastoTipo1(ref DataTable dtCargaGastos, Int32 nNumCuotaActual, Int32 nNumCuotasPPG)
        {
            decimal nTotalTasaEfectivaDiariaGastoTipo1 = 0;

            //Calcular la Tasa Efectiva Diaria cuando se aplique al SALDO CAPITAL: para el luego usarlo en el FRC
            //y deacuerdo a ésto se usar interpolación para hallar la cuota Inicial que incluya a éstos Gastos
            for (int i = 0; i < dtCargaGastos.Rows.Count; i++)
            {
                if (dtCargaGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                {
                    if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                    {
                        if (dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + Convert.ToDecimal(dtCargaGastos.Rows[i]["nTasaEfectivaDiaria"]);
                        }
                    }
                }

                if (dtCargaGastos.Rows[i]["cIdCuota"].Equals("PRIMERA CUOTA"))
                {
                    if (nNumCuotaActual == 1)
                    {
                        if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + Convert.ToDecimal(dtCargaGastos.Rows[i]["nTasaEfectivaDiaria"]);
                            }
                        }
                    }
                }

                if (dtCargaGastos.Rows[i]["cIdCuota"].Equals("ULTIMA CUOTA"))
                {
                    if (nNumCuotaActual == nNumCuotasPPG)
                    {
                        if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + Convert.ToDecimal(dtCargaGastos.Rows[i]["nTasaEfectivaDiaria"]);
                            }
                        }
                    }
                }
            }
            return nTotalTasaEfectivaDiariaGastoTipo1;
        }

        #region otros1

        /// Metodo que calcula el plan de pagos con interes simple y saltando los feriados
        public DataTable CalculaPpgFlat(decimal nMonDesemb, decimal nTasEfeMen, DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag, int nNumsolicitud)
        {
            int nDiaAcumul = 0;
            DateTime dFecNewCuo = dFecDesemb.AddDays(Convert.ToDouble(nDiaGraCta));
            clsCNOperArit FunAritmetic = new clsCNOperArit();
            decimal nTasEfeFin = FunAritmetic.RedxDefecto((((nDiaGraCta + (nNumCuoCta * nDiaFecPag)) / 30.00m) * nTasEfeMen), 4);
            if (nTasEfeFin < nTasEfeMen)
            {
                nTasEfeFin = nTasEfeMen;
            }
            decimal nMonInteres = FunAritmetic.RedxDefecto(nMonDesemb * nTasEfeFin, 1);
            decimal nMonDevolver = FunAritmetic.RedxDefecto(nMonDesemb + nMonInteres, 1);
            decimal nMontoCuota = FunAritmetic.RedxExceso(nMonDevolver / nNumCuoCta, 1);
            decimal nMonCapCuota = FunAritmetic.RedxDefecto(nMonDesemb / nNumCuoCta, 1);
            decimal nMonCuoAcum = 0;
            decimal nMonCapAcum = 0;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));
            //ppg.Columns.Add("sal_cap", typeof(decimal));
            ppg.Columns.Add("capital", typeof(decimal));
            ppg.Columns.Add("interes", typeof(decimal));
            ppg.Columns.Add("imp_cuota", typeof(decimal));
            ppg.Columns.Add("nIdSolicitud", typeof(int));

            //Cargando la tabla de feriados
            DataTable dtFeriado = new DataTable("dtFeriado");
            clsADFeriado CNFeriado = new clsADFeriado();
            dtFeriado = CNFeriado.ADdtFeriado();
            int nDiaAdicionalFeriado = 0;
            int nFeriadoAcumulado = 0;

            //nDiaAdicionalFeriado = 0;
            nFeriadoAcumulado = 0;
            for (int i = 1; i <= nNumCuoCta; i++)
            {
                DataRow fila = ppg.NewRow();
                fila["cuota"] = i;
                if (i == 1)
                {
                    nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaAcumul - nDiaGraCta));
                    //Si frecuencia de pago es diaria y la fecha de la cuota cae en día feriado
                    if (nDiaFecPag == 1)
                    {
                        for (int j = 0; j < dtFeriado.Rows.Count; j++)
                        {
                            if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                            {
                                nDiaAcumul = nDiaAcumul + 1;
                                dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                                nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                                nFeriadoAcumulado++;
                            }
                        }
                    }
                    fila["fecha"] = dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                    fila["dias"] = nDiaFecPag + nDiaGraCta + nDiaAdicionalFeriado;
                    fila["dias_acu"] = nDiaAcumul;
                    nDiaAdicionalFeriado = 0;
                }
                else
                {
                    nDiaAcumul = nDiaAcumul + nDiaFecPag;
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                    if (nDiaFecPag == 1)
                    {
                        for (int j = 0; j < dtFeriado.Rows.Count; j++)
                        {
                            if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                            {
                                nDiaAcumul = nDiaAcumul + 1;
                                dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                                nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                                nFeriadoAcumulado++;
                            }
                        }
                    }

                    fila["fecha"] = dFecNewCuo;
                    fila["dias"] = nDiaFecPag + nDiaAdicionalFeriado;
                    fila["dias_acu"] = nDiaAcumul;
                    nDiaAdicionalFeriado = 0;
                }
                if (i < nNumCuoCta)
                {
                    fila["capital"] = nMonCapCuota;
                    fila["interes"] = FunAritmetic.RedxDefecto(nMontoCuota - nMonCapCuota, 1);
                    fila["imp_cuota"] = nMontoCuota;
                    fila["nIdSolicitud"] = nNumsolicitud;
                    nMonCuoAcum = nMonCuoAcum + nMontoCuota;
                    nMonCapAcum = nMonCapAcum + nMonCapCuota;
                }
                else // Ajuste de última cuota
                {
                    fila["capital"] = FunAritmetic.RedxDefecto(nMonDesemb - nMonCapAcum, 1);
                    fila["interes"] = FunAritmetic.RedxDefecto((nMonDevolver - nMonCuoAcum) - (nMonDesemb - nMonCapAcum), 1);
                    fila["imp_cuota"] = FunAritmetic.RedxDefecto(nMonDevolver - nMonCuoAcum, 1);
                    fila["nIdSolicitud"] = nNumsolicitud;
                }
                ppg.Rows.Add(fila);
            }

            ppg.AcceptChanges();
            return ppg;


        }

        public DataTable CalculaPpgFlat_NOFer(decimal nMonDesemb, decimal nTasEfeMen, DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag, int nNumsolicitud)
        {
            int nDiaAcumul = 0;
            DateTime dFecNewCuo = dFecDesemb.AddDays(Convert.ToDouble(nDiaGraCta));
            clsCNOperArit FunAritmetic = new clsCNOperArit();
            decimal nTasEfeFin = FunAritmetic.RedxDefecto((((nDiaGraCta + (nNumCuoCta * nDiaFecPag)) / 30.00m) * nTasEfeMen), 4);
            //if (nTasEfeFin < nTasEfeMen)
            //{
            //    nTasEfeFin = nTasEfeMen;
            //}
            decimal nMonInteres = FunAritmetic.RedxDefecto(nMonDesemb * nTasEfeFin, 1);
            decimal nMonDevolver = FunAritmetic.RedxDefecto(nMonDesemb + nMonInteres, 1);
            decimal nMontoCuota = FunAritmetic.RedxExceso(nMonDevolver / nNumCuoCta, 1);
            decimal nMonCapCuota = FunAritmetic.RedxDefecto(nMonDesemb / nNumCuoCta, 1);
            decimal nMonCuoAcum = 0;
            decimal nMonCapAcum = 0;

            int nDiaFecAux = nDiaFecPag;

            DataTable ppg = new DataTable("dtPlanPago");
            ppg.Columns.Add("cuota", typeof(int));
            ppg.Columns.Add("fecha", typeof(DateTime));
            ppg.Columns.Add("dias", typeof(int));
            ppg.Columns.Add("dias_acu", typeof(int));
            //ppg.Columns.Add("sal_cap", typeof(decimal));
            ppg.Columns.Add("capital", typeof(decimal));
            ppg.Columns.Add("interes", typeof(decimal));
            ppg.Columns.Add("imp_cuota", typeof(decimal));
            ppg.Columns.Add("nIdSolicitud", typeof(int));

            //Cargando la tabla de feriados
            DataTable dtFeriado = new DataTable("dtFeriado");
            clsADFeriado CNFeriado = new clsADFeriado();
            dtFeriado = CNFeriado.ADdtFeriado();
            int nDiaAdicionalFeriado = 0;
            int nFeriadoAcumulado = 0;

            //nDiaAdicionalFeriado = 0;
            nFeriadoAcumulado = 0;
            for (int i = 1; i <= nNumCuoCta; i++)
            {
                DataRow fila = ppg.NewRow();
                fila["cuota"] = i;
                if (i == 1)
                {
                    nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaAcumul - nDiaGraCta));
                    //Si frecuencia de pago es diaria y la fecha de la cuota cae en día feriado
                    //if (nDiaFecPag == 1)
                    //{
                    for (int j = 0; j < dtFeriado.Rows.Count; j++)
                    {
                        if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                        {
                            nDiaAcumul = nDiaAcumul + 1;
                            dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                            nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                            nFeriadoAcumulado++;
                        }
                    }
                    //}
                    fila["fecha"] = dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                    fila["dias"] = nDiaFecPag + nDiaGraCta + nDiaAdicionalFeriado;
                    fila["dias_acu"] = nDiaAcumul;
                    nDiaAdicionalFeriado = 0;
                }
                else
                {
                    nDiaAcumul = nDiaAcumul + nDiaFecPag;
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                    //if (nDiaFecPag == 1)
                    //{
                    for (int j = 0; j < dtFeriado.Rows.Count; j++)
                    {
                        if (dFecNewCuo == Convert.ToDateTime(dtFeriado.Rows[j]["dferiado"]))
                        {
                            nDiaAcumul = nDiaAcumul + 1;
                            dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                            nDiaAdicionalFeriado = nDiaAdicionalFeriado + 1;
                            nFeriadoAcumulado++;
                        }
                    }
                    //}

                    fila["fecha"] = dFecNewCuo;
                    fila["dias"] = nDiaFecPag + nDiaAdicionalFeriado;
                    fila["dias_acu"] = nDiaAcumul;
                    nDiaAdicionalFeriado = 0;
                }
                if (i < nNumCuoCta)
                {
                    fila["capital"] = nMonCapCuota;
                    fila["interes"] = FunAritmetic.RedxDefecto(nMontoCuota - nMonCapCuota, 1);
                    fila["imp_cuota"] = nMontoCuota;
                    fila["nIdSolicitud"] = nNumsolicitud;
                    nMonCuoAcum = nMonCuoAcum + nMontoCuota;
                    nMonCapAcum = nMonCapAcum + nMonCapCuota;
                }
                else // Ajuste de última cuota
                {
                    fila["capital"] = FunAritmetic.RedxDefecto(nMonDesemb - nMonCapAcum, 1);
                    fila["interes"] = FunAritmetic.RedxDefecto((nMonDevolver - nMonCuoAcum) - (nMonDesemb - nMonCapAcum), 1);
                    fila["imp_cuota"] = FunAritmetic.RedxDefecto(nMonDevolver - nMonCuoAcum, 1);
                    fila["nIdSolicitud"] = nNumsolicitud;
                }
                ppg.Rows.Add(fila);
            }

            ppg.AcceptChanges();
            return ppg;


        }

        public DataTable TotalizaPpg(DataTable Ppg)
        {
            DataTable dtTotalPpg = new DataTable("dtTotalPpg");
            dtTotalPpg.Columns.Add("nTotdias", typeof(decimal));
            dtTotalPpg.Columns.Add("nTotCapitalPpg", typeof(decimal));
            dtTotalPpg.Columns.Add("nTotInteresPpg", typeof(decimal));
            dtTotalPpg.Columns.Add("nTotImportePpg", typeof(decimal));
            dtTotalPpg.Columns.Add("nTotItf", typeof(decimal));
            dtTotalPpg.Columns.Add("nTotComi", typeof(decimal));
            dtTotalPpg.Rows.Add(dtTotalPpg.NewRow());
            dtTotalPpg.Rows[0]["nTotdias"] = 0.0;
            dtTotalPpg.Rows[0]["nTotCapitalPpg"] = 0.0;
            dtTotalPpg.Rows[0]["nTotInteresPpg"] = 0.0;
            dtTotalPpg.Rows[0]["nTotImportePpg"] = 0.0;
            dtTotalPpg.Rows[0]["nTotItf"] = 0.0;
            dtTotalPpg.Rows[0]["nTotComi"] = 0.0;

            for (int i = 0; i < Ppg.Rows.Count; i++)
            {
                dtTotalPpg.Rows[0]["nTotdias"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotdias"]) + Convert.ToDecimal(Ppg.Rows[i]["dias"]);
                dtTotalPpg.Rows[0]["nTotCapitalPpg"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotCapitalPpg"]) + Convert.ToDecimal(Ppg.Rows[i]["capital"]);
                dtTotalPpg.Rows[0]["nTotInteresPpg"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotInteresPpg"]) + Convert.ToDecimal(Ppg.Rows[i]["interes"]);
                dtTotalPpg.Rows[0]["nTotImportePpg"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotImportePpg"]) + Convert.ToDecimal(Ppg.Rows[i]["imp_cuota"]);
                dtTotalPpg.Rows[0]["nTotItf"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotItf"]) + Convert.ToDecimal(Ppg.Rows[i]["itf"]);
                dtTotalPpg.Rows[0]["nTotComi"] = Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotComi"]) + Convert.ToDecimal(Ppg.Rows[i]["comisiones"]);
            }

            dtTotalPpg.Rows[0]["nTotdias"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotdias"]), 2);
            dtTotalPpg.Rows[0]["nTotCapitalPpg"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotCapitalPpg"]), 2);
            dtTotalPpg.Rows[0]["nTotInteresPpg"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotInteresPpg"]), 2);
            dtTotalPpg.Rows[0]["nTotImportePpg"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotImportePpg"]), 2);
            dtTotalPpg.Rows[0]["nTotItf"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotItf"]), 2);
            dtTotalPpg.Rows[0]["nTotComi"] = Math.Round(Convert.ToDecimal(dtTotalPpg.Rows[0]["nTotComi"]), 2);

            return dtTotalPpg;
        }

        public DataTable CNdtPlanPagPosi(int nNumCredito)
        {
            return objPlanPago.ADdtPlanPagPosi(nNumCredito);
        }

        public DataTable CNdtPlanPagPosiCon(int nNumCredito)
        {
            return objPlanPago.ADdtPlanPagPosiCon(nNumCredito);
        }

        /// <summary>
        /// Realiza el cálculo de la TCEA con la aproximación de Newton Raphson
        /// </summary>
        /// <param name="dtPlanPago"></param>
        /// <param name="nMonDesemb"></param>
        /// <param name="nTea"></param>
        /// <returns></returns>
        public decimal CNnCalculaTCEA(DataTable dtPlanPago, decimal nMonDesemb, decimal nTea)
        {
            decimal nTirValNegativo;
            decimal nTirValPositivo;
            decimal nTirFinal = 0;
            decimal nValorNegativo;
            decimal nValorPositivo;
            decimal nTCEA;
            decimal i = 0.0001m;
            decimal j = 0.0001m;
            const int nRepeticiones = 10;
            const int nNumMaxInteraciones = 100;
            int nContIteraciones = 0;
            int nContRepTir = 0;

            //Calculando la tea inicial
            decimal nTem = Convert.ToDecimal(Math.Pow((1 + ((double)nTea / 100.00)), (1.00 / 12.00))) - 1.00m;

            //Restando valor aprox para tir de valor negativo
            do
            {
                nTirValPositivo = (nTem - j) * 100.0m;
                nValorPositivo = RetornaSumaValorPresente(dtPlanPago, nMonDesemb, nTirValPositivo);
                j = j + 0.0001m;
            } while (nValorPositivo < 0.0m);

            do
            {
                //Sumando aprox para tir de valor positivo
                nTirValNegativo = (nTem + i) * 100.0m;
                nValorNegativo = RetornaSumaValorPresente(dtPlanPago, nMonDesemb, nTirValNegativo);
                i = i + 0.0001m;

            } while (nValorNegativo > 0.0m);

            if (nValorNegativo == 0.0m)
            {
                //Cálculo de TCEA a partir de una tir final
                nTCEA = Math.Round(Convert.ToDecimal(Math.Pow(1 + (double)nTirFinal / 100.0, 360.00) - 1), 8) * 100.0m;
                nTCEA = decimal.Round(nTCEA, 4);
                return nTCEA;
            }

            decimal nTirAnterior = decimal.Round(nTirValNegativo,8);
            do
            {
                nTirFinal = CalculaInterpolacion(nTirValPositivo, nValorPositivo, nTirValNegativo, nValorNegativo);
                decimal nValorAproxCero = RetornaSumaValorPresente(dtPlanPago, nMonDesemb, nTirFinal);

                if (nValorAproxCero < 0)
                {
                    nTirValNegativo = nTirFinal;
                    nValorNegativo = nValorAproxCero;

                }
                else
                {
                    nTirValPositivo = nTirFinal;
                    nValorPositivo = nValorAproxCero;
                }

                nTirFinal = decimal.Round(nTirFinal, 8);
                if ( nTirAnterior == nTirFinal )
                {
                    nContRepTir++;
                }

                nTirAnterior = nTirFinal;
                nContIteraciones++;
            } while ( nContRepTir <= nRepeticiones && nContIteraciones <= nNumMaxInteraciones);


            nTCEA = Math.Round(Convert.ToDecimal(Math.Pow(1 + (double)nTirAnterior / 100.0, 12) - 1), 8) * 100.0m;
            nTCEA = decimal.Round(nTCEA, 4);
            return nTCEA;
        }

        private static decimal RetornaSumaValorPresente(DataTable dtPlanPago, decimal nDesembolso, decimal nTasa)
        {
            decimal nValPres = 0;

            for (int i = 0; i < dtPlanPago.Rows.Count; i++)
            {
                decimal nCuotaFinal = Convert.ToDecimal(dtPlanPago.Rows[i]["imp_cuota"]);
                decimal nDiasAcumulados = Convert.ToDecimal(dtPlanPago.Rows[i]["dias_acu"]);
                decimal nValPresenteCuota = (nCuotaFinal / Convert.ToDecimal(Math.Pow((1 + (double)(nTasa / 100.00m)), (double)(nDiasAcumulados / 30.00m))));

                nValPres += nValPresenteCuota;
            }
            decimal nValor = nValPres - nDesembolso;
            return nValor;
        }

        ///Donde la estructura de interpolación es la siguiente:
        ///  A   C
        ///  B   D
        ///  E =>Valor a encontrar
        ///
        ///Formula general:
        ///(A-(C*(A-B)/(C-D)))
        private static decimal CalculaInterpolacion(decimal A, decimal B, decimal C, decimal D)
        {
            decimal E = A - (B * (A - C) / (B - D));
            return E;
        }

        /// <summary>
        /// Función de calculo de la serie del valor actual igualado a 0
        /// </summary>
        /// <param name="x">Valor de iteración</param>
        /// <param name="dtPlanPago">Plan de pagos</param>
        /// <param name="nDesembolso">Monto desembolso</param>
        /// <returns>Valor con tendencia a 0</returns>
        private decimal fxTCEA(decimal x, DataTable dtPlanPago, decimal nDesembolso)
        {
            decimal nValorFx = 0;

            for (int i = 0; i < dtPlanPago.Rows.Count; i++)
            {
                decimal nDias = Convert.ToDecimal(dtPlanPago.Rows[i][0]);//dias entre cuotas
                decimal nDiasAcu = Convert.ToDecimal(dtPlanPago.Rows[i][1]);//dias acumulados
                decimal nCuota = Convert.ToDecimal(dtPlanPago.Rows[i][2]);//monto de la cuota
                nValorFx = nValorFx + nCuota * Convert.ToDecimal(Math.Pow((double)(x), ((double)nDiasAcu / 30.0)));
            }
            nValorFx = nValorFx - nDesembolso;

            return nValorFx;
        }

        /// <summary>
        /// Función derivada, al derivar el monto desembolsado se vuelve cero
        /// </summary>
        /// <param name="x">Valor de iteración</param>
        /// <param name="dtPlanPago">Plan de pagos</param>
        /// <returns>factor de la función derivada</returns>
        private decimal dfxTCEA(decimal x, DataTable dtPlanPago)
        {
            decimal nValorFx = 0;

            for (int i = 0; i < dtPlanPago.Rows.Count; i++)
            {
                decimal nDias = Convert.ToDecimal(dtPlanPago.Rows[i][0]);//dias entre cuotas
                decimal nDiasAcu = Convert.ToDecimal(dtPlanPago.Rows[i][1]);//dias acumulados
                decimal nCuota = Convert.ToDecimal(dtPlanPago.Rows[i][2]);//monto de la cuota
                nValorFx = nValorFx + ((nDiasAcu / nDias) * nCuota) * Convert.ToDecimal(Math.Pow((double)(x), (((double)nDiasAcu / 30.0) - 1.0000)));
            }

            return nValorFx;
        }

        #endregion

        public clsDBResp RegistrarPrepago(int idCuenta, clsPlanPago planpagoPagados, string xmlPagador, DateTime dFechaOpe,
                                    int idCanal, int idUsuario, int idAgeOpera, int idMotivoOperacion,
                                    decimal nItfNormal, decimal nItfTruncado, decimal nMonRedondeo,
                                    bool lModificaSaldoLinea, int idTipoTransac, int idMoneda_Saldo, decimal nMontoOpe)
        {
            return objPlanPago.RegistrarPrepago(idCuenta, planpagoPagados, xmlPagador, dFechaOpe, idCanal, idUsuario,
                                                idAgeOpera, idMotivoOperacion, nItfNormal, nItfTruncado, nMonRedondeo,
                                                        lModificaSaldoLinea, idTipoTransac, idMoneda_Saldo, nMontoOpe);
        }

        /// <summary>
        /// Registra la reprogramacion de una cuenta de credito
        /// </summary>
        /// <param name="idCuenta">id de la cuenta</param>
        /// <param name="planPagos">Plan de pagos final</param>
        /// <param name="xmlPpg">Xml de plan de pagos, gastos y datos del crédito</param>
        /// <param name="dFechaOpe">Fecha de operación</param>
        public clsDBResp RegistrarReprogramacion(int idCuenta, int idSolicitud, int nDiasGracia, clsPlanPago planPagos, string xmlReprogramacion, DateTime dFechaOpe, int idUsuario)
        {
            return objPlanPago.RegistrarReprogramacion(idCuenta, idSolicitud, nDiasGracia, planPagos, xmlReprogramacion, dFechaOpe, idUsuario);
        }

        public DataTable ListarDetalleGasto(int nIdNumCuenta, int nNumCuotaActual, int nidPlanPagos)
        {
            return objPlanPago.ListarDetalleGasto(nIdNumCuenta, nNumCuotaActual, nidPlanPagos);
        }

        public DataTable ListarDetalleGastoXSolicitud(int idSolicitud, int idTipoGasto, int idCuota)
        {
            return objPlanPago.ListarDetalleGasto(idSolicitud, idTipoGasto, idCuota);
        }

        /// <summary>
        /// Calcula Plan Pagos con Pagos Iguales
        /// </summary>
        /// <param name="nMonDesemb"> Monto Desembolso</param>
        /// <param name="nTasEfeMen"> Tasa Efectiva Mensual</param>
        /// <param name="dFecDesemb">Fecha de Desembolso</param>
        /// <param name="nNumCuoCta">Número de cuotas</param>
        /// <param name="nDiaGraCta">Días de Gracia</param>
        /// <param name="nTipPerPag">Tipo de Perido de pago</param>
        /// <param name="nDiaFecPag">Día Fecha de Pago</param>
        /// <param name="nNumsolicitud">Número de solicitud</param>
        /// <param name="dtConfigGasto">Configuraciones de Gastos a aplicar</param>
        /// <param name="nIdMoneda">Tipo de Moneda</param>
        /// <param name="dtCuotasDobles">Cuotas Dobles</param>
        /// <param name="dFecPrimeraCuota">fecha de la primera cuota</param>
        /// <param name="nCuotaSugerida">Cuota sugerida</param>
        /// <param name="nCapitalMaxCobSegDes">Monto máximo de capital que se puede coberturar</param>
        /// <param name="nNroCuotasGracia">fecha de la primera cuota</param>
        /// <returns>DataTable</returns>
        public DataTable CalculaPpgCuotasConstantes(decimal nMonDesemb, decimal nTasa, DateTime dFecDesemb, int nNumCuoCta,
                                                    int nDiaGraCta, short nTipPerPag, int nDiaFecPag, int nNumsolicitud,
                                                    DataTable dtConfigGasto, int nIdMoneda, DataTable dtCuotasDobles,
                                                    DateTime dFecPrimeraCuota, decimal nCuotaSugerida = 0, decimal nCapitalMaxCobSegDes = 0, int nNroCuotasGracia = 0, bool lConstante = false)
        {
            decimal nTotalTEDGastoTipo1 = nCero;

            //Para definir la Cuota se debe tener en cuenta solo los 'Gastos de tipo 1' (Los que afectana a SALDO CAPITAL)
            //e incluirlos en el cálculo del factor de recuperación de Capital (FRC)
            #region Realizando la suma de las tasas de interes diaria para que sume en el calculo de la cuota sugerida

            nTotalTEDGastoTipo1 = retonarTEDTotalGastoTipo1(dtConfigGasto, nTotalTEDGastoTipo1);

            #endregion

            #region Realizando el cálculo de la tasa efectiva diaria

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];

            double nTasEfeDia = 0.00;

            if (nFormaCalculoTasa == 1)
            {
                //Cálculo de la tasa diaria a partir de la TEA
                nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 360.0)) - 1; //Tasa de interes efectiva diaria
            }

            if (nFormaCalculoTasa == 2)
            {
                //Cálculo de la tasa diaria a partir de la TEM
                nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 30.0)) - 1; //Tasa de interes efectiva diaria
            }

            #endregion

            #region Realizando la deficinión de la tabla de plan de pagos

            int nDiaAcumul = 0;
            decimal nFacRecCap = nCero;
            decimal nFacAcumul = nCero;
            decimal nFacRecOtr = nCero;
            decimal nFacAcumOtr = nCero;
            DateTime dFecNewCuo = dFecPrimeraCuota;
            DateTime DfecVeriFec;

            int nDiaFecAux = nDiaFecPag;

            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));
            dtPlanPago.Columns.Add("frc", typeof(decimal));
            dtPlanPago.Columns.Add("sal_cap", typeof(decimal));
            dtPlanPago.Columns.Add("capital", typeof(decimal));
            dtPlanPago.Columns.Add("interes", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones_sinSeg", typeof(decimal));  //comisiones sin seguro
            dtPlanPago.Columns.Add("itf", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));
            dtPlanPago.Columns.Add("nIdSolicitud", typeof(int));

            int nNumMesCuo = 0;
            int nNumAñoCuo = 0;

            #endregion

            #region DefineFechas

            int nTotCuotasDobles = dtCuotasDobles.Rows.Count;
            nNumCuoCta = nNumCuoCta + nTotCuotasDobles;
            #endregion

            #region Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)

            if (nTipPerPag == 1)
            {
                if (nDiaGraCta == 0) // Para evitar que la primera cuota se genere el mismo día del desembolso (con 0 días)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(1));
                }
                for (int i = 1; i <= nNumCuoCta; i++)//Recorrer las cuotas para definir las fechas de pago
                {
                    DataRow fila = dtPlanPago.NewRow();
                    fila["cuota"] = i;
                    if (i == 1) // Si primera cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }

                    }
                    else // A partir de la 2da cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12) // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    nDiaFecAux = nDiaFecPag;
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (i == 1)
                        {
                            dFecNewCuo = dFecPrimeraCuota;
                            break;
                        }
                        else
                        {
                            if (DateTime.TryParse((nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString()), out DfecVeriFec))
                            {
                                dFecNewCuo = DateTime.Parse(nDiaFecAux.ToString() + "/" + nNumMesCuo.ToString() + "/" + nNumAñoCuo.ToString());
                                break;
                            }
                            nDiaFecAux = nDiaFecAux - 1; // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                        }
                    }

                    if (i > 1)
                    {
                        foreach (DataRow item in dtCuotasDobles.Rows)
                        {
                            DateTime dFechaAnt = (DateTime)dtPlanPago.Rows[i - 2]["fecha"];
                            if ((int)item["nMes"] == dFechaAnt.Month && (int)item["nAnio"] == dFechaAnt.Year && (bool)item["lEstado"])
                            {
                                dFecNewCuo = dFechaAnt;
                                dtCuotasDobles.AsEnumerable().ToList().Where(x => (int)x["nMes"] == dFechaAnt.Month
                                                                             && (int)x["nAnio"] == dFechaAnt.Year).ToList().ForEach(p => p["lEstado"] = false);
                            }
                        }
                    }

                    fila["fecha"] = dFecNewCuo;
                    // caluclando la cantidad de días para la cuota
                    if (i == 1) // para la primera cuota
                    {
                        fila["dias"] = (dFecNewCuo - dFecDesemb).Days;
                    }
                    else //Para las cuotas de la segunda en adelante
                    {
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days;
                    }

                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;

                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul)); //calculando el FRC de la cuota
                    nFacRecOtr = 1 / Convert.ToDecimal(Math.Pow((1 + (nTasEfeDia + (double)nTotalTEDGastoTipo1)), nDiaAcumul)); //calculando el FRC que incluya gastos de la cuota

                    nFacAcumul = nFacAcumul + nFacRecCap; //Acumulando el FRC
                    nFacAcumOtr = nFacAcumOtr + nFacRecOtr; // Acumulando el FRC que incluye gastos
                    fila["frc"] = nFacRecCap;
                    dtPlanPago.Rows.Add(fila);
                }
            }

            #endregion

            #region Periodo Fijo

            else
            {
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    DataRow fila = dtPlanPago.NewRow();
                    fila["cuota"] = i; //registrando la cuota
                    if (i == 1) //Para la primera cuota
                    {
                        nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                        dFecNewCuo = dFecPrimeraCuota;// dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                        fila["fecha"] = dFecNewCuo;
                        //fila["fecha"] = dFecDesemb.AddDays(Convert.ToDouble(nDiaAcumul));
                        fila["dias"] = nDiaFecPag + nDiaGraCta;
                        fila["dias_acu"] = nDiaAcumul;
                    }
                    else
                    {
                        bool lCuotadoble = false;
                        foreach (DataRow item in dtCuotasDobles.Rows)
                        {
                            DateTime dFechaAnt = (DateTime)dtPlanPago.Rows[i - 2]["fecha"];
                            if ((int)item["nMes"] == dFechaAnt.Month
                                && (int)item["nAnio"] == dFechaAnt.Year
                                && (bool)item["lEstado"]
                                && (int)item["ndia"] == dFechaAnt.Day)
                            {
                                dFecNewCuo = dFechaAnt;
                                dtCuotasDobles.AsEnumerable().ToList().Where(x => (int)x["nMes"] == dFechaAnt.Month
                                                                             && (int)x["nAnio"] == dFechaAnt.Year).ToList().ForEach(p => p["lEstado"] = false);
                                lCuotadoble = true;
                            }
                        }
                        if (lCuotadoble)
                        {
                            nDiaAcumul = nDiaAcumul + 0;
                            dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(0));
                        }
                        else
                        {
                            nDiaAcumul = nDiaAcumul + nDiaFecPag;
                            dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                        }


                        fila["fecha"] = dFecNewCuo;
                        //fila["dias"] = nDiaFecPag;
                        fila["dias"] = (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days;
                        fila["dias_acu"] = nDiaAcumul;
                    }

                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul)); //calculando el FRC de la cuota
                    nFacRecOtr = 1 / Convert.ToDecimal(Math.Pow((1 + (nTasEfeDia + (double)nTotalTEDGastoTipo1)), nDiaAcumul)); //calculando el FRC que incluya gastos de la cuota

                    nFacAcumul = nFacAcumul + nFacRecCap; //Acumulando el FRC
                    nFacAcumOtr = nFacAcumOtr + nFacRecOtr; // Acumulando el FRC que incluye gastos
                    fila["frc"] = nFacRecCap;
                    dtPlanPago.Rows.Add(fila);
                }
            }

            //TODO: AQUI SE AGREGARA CUOTAS LIBRES

            #endregion

            decimal nCuotaFinal = nCero;
            decimal nCuotaFRC = nCero;
            decimal nCuotaFRCGas = nCero;
            int nValRedond = 1;

            nCuotaFRC = nMonDesemb / nFacAcumul;
            nCuotaFRCGas = nMonDesemb / nFacAcumOtr;

            decimal nSalCapFRC;
            decimal nSalCapFRCGas;
            decimal nSalCapital;

            int nDiaCuoCta = 0;
            decimal nMonIntCuo = nCero;
            decimal nMonCapCuo = nCero;
            decimal nMonGastosTipo1 = nCero;
            decimal nMonGastosTipo2 = nCero;

            if (nCuotaFRC != nCuotaFRCGas) //Si las cuota con FRC y la cuota con FRCGas son diferentes (para interpolar)
            {
                //PPG con FRC
                nSalCapFRC = nMonDesemb;
                for (int i = 0; i < nNumCuoCta; i++)
                {
                    nDiaCuoCta = Convert.ToInt32(dtPlanPago.Rows[i]["dias"]);
                    nMonIntCuo = ((nSalCapFRC * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapFRC);

                    //Identificar que tipo de Valor %SIMPLE ó %COMPUESTO afectan a SALDO CAPITAL
                    //Sólo puede ser uno de ellos no ambos.
                    for (int t = 0; t < dtConfigGasto.Rows.Count; t++)
                    {
                        if (dtConfigGasto.Rows[t]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            if (dtConfigGasto.Rows[t]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                            {
                                nMonGastosTipo1 = nSalCapFRC * nTotalTEDGastoTipo1 * nDiaCuoCta;
                                break;
                            }
                            if (dtConfigGasto.Rows[t]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                            {
                                nMonGastosTipo1 = nSalCapFRC * Convert.ToDecimal(Math.Pow((1.0 + (double)nTotalTEDGastoTipo1), nDiaCuoCta)) - nSalCapFRC;
                                break;
                            }
                        }
                    }

                    nMonCapCuo = nCuotaFRC - nMonIntCuo - nMonGastosTipo1;
                    nSalCapFRC = nSalCapFRC - nMonCapCuo;
                }
                //PPG con FRC que incluye Gastos
                nSalCapFRCGas = nMonDesemb;
                nMonGastosTipo1 = nCero;
                for (int j = 0; j < nNumCuoCta; j++)
                {
                    nDiaCuoCta = Convert.ToInt32(dtPlanPago.Rows[j]["dias"]);
                    nMonIntCuo = ((nSalCapFRCGas * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapFRCGas);

                    //Identificar que tipo de Valor %SIMPLE ó %COMPUESTO afectan a SALDO CAPITAL
                    //Sólo puede ser uno de ellos no ambos.
                    for (int t = 0; t < dtConfigGasto.Rows.Count; t++)
                    {
                        if (dtConfigGasto.Rows[t]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            if (dtConfigGasto.Rows[t]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                            {
                                //nMonGastosTipo1 = Math.Round(nSalCapFRC * nTasSegDesDia * nDiaCuoCta / 100, 2);
                                nMonGastosTipo1 = nSalCapFRCGas * nTotalTEDGastoTipo1 * nDiaCuoCta;
                                break;
                            }
                            if (dtConfigGasto.Rows[t]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                            {
                                nMonGastosTipo1 = nSalCapFRCGas * Convert.ToDecimal(Math.Pow((1.0 + (double)nTotalTEDGastoTipo1), nDiaCuoCta)) - nSalCapFRCGas;
                                break;
                            }
                        }
                    }

                    nMonCapCuo = nCuotaFRCGas - nMonIntCuo - nMonGastosTipo1;
                    nSalCapFRCGas = nSalCapFRCGas - nMonCapCuo;
                }
                //INTERPOLANDO
                nCuotaFinal = Math.Round(((nCuotaFRC - nCuotaFRCGas) * (0 - nSalCapFRCGas) / (nSalCapFRC - nSalCapFRCGas)) + nCuotaFRCGas, nValRedond); //obtenemos la cuota final INTERPOLANDO
            }
            else
            {
                nCuotaFinal = Math.Round(nCuotaFRCGas, nValRedond);//Si la cuota FRC y la cuota FRC con gastos son iguales da lo mismo tomar cualquiera para cuota final
            }

            //PPG FINAL
            decimal nMonGastosTipo1SinSeg;
            decimal nMonGastosTipo2SinSeg;
            DateTime dFechaIni, dFechaFin;

            nSalCapital = nMonDesemb;
            iniciarDTGastos();
            for (int i = 0; i < nNumCuoCta; i++)
            {
                nMonGastosTipo1 = nCero;//Para usarlo como acumulador -- Gastos tipo 1 : Gastos que influyen a que las cuotas del plan de Pagos sea CONSTANTE, sólo comprende a los Gastos que afectan a SALDO CAPITAL
                nMonGastosTipo2 = nCero;//Para usarlo como acumulador -- Gastos tipo 2 : Gastos que de manerá directa se suman a los 'Gastos tipo 1'.

                nMonGastosTipo1SinSeg = nCero;//Para usarlo como acumulador -- Gastos tipo 1 : Gastos que influyen a que las cuotas del plan de Pagos sea CONSTANTE, sólo comprende a los Gastos que afectan a SALDO CAPITAL
                nMonGastosTipo2SinSeg = nCero;//Para usarlo como acumulador -- Gastos tipo 2 : Gastos que de manerá directa se suman a los 'Gastos tipo 1'.

                nDiaCuoCta = Convert.ToInt32(dtPlanPago.Rows[i]["dias"]);
                nMonIntCuo = Math.Round(((nSalCapital * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSalCapital), 2);

                #region RSH --Recorrer dtConfigGasto para calcular los montos de acuerdo al campo que afecta

                dFechaIni = (i == 0) ? dFecDesemb : Convert.ToDateTime(dtPlanPago.Rows[i - 1]["fecha"]);
                dFechaFin = Convert.ToDateTime(dtPlanPago.Rows[i]["fecha"]);

                cargarGastoACuota(nMonDesemb, nNumCuoCta, dtConfigGasto, nCuotaFinal, nSalCapital, nDiaCuoCta,
                                   nMonIntCuo, ref nMonGastosTipo1, ref nMonGastosTipo2, i, ref nMonGastosTipo1SinSeg, ref nMonGastosTipo2SinSeg, Convert.ToInt32(dtPlanPago.Rows[i]["cuota"])
                                   , dFechaIni, dFechaFin, nCapitalMaxCobSegDes);



                #endregion


                decimal nCuotFinalAux = nCero;

                if (nCuotaSugerida > 0)
                {
                    nCuotFinalAux = nCuotaSugerida;
                }
                else
                {
                    if (lConstante)
                    {
                        nCuotFinalAux = nCuotaFRC;
                    }
                    else
                    {
                        nCuotFinalAux = Math.Round(nCuotaFinal + nMonGastosTipo2, 1);
                    }

                }

                if (i < nNroCuotasGracia)
                {
                    nMonCapCuo = 0;
                }
                else
                {
                    nMonCapCuo = nCuotFinalAux - nMonIntCuo - nMonGastosTipo1 - nMonGastosTipo2;
                }


                dtPlanPago.Rows[i]["Itf"] = nCero;
                dtPlanPago.Rows[i]["imp_cuota"] = Math.Round(nCuotFinalAux, 1);
                dtPlanPago.Rows[i]["comisiones"] = Math.Round(nMonGastosTipo1 + nMonGastosTipo2, 2);
                dtPlanPago.Rows[i]["comisiones_sinSeg"] = Math.Round(nMonGastosTipo1SinSeg + nMonGastosTipo2SinSeg, 2);
                dtPlanPago.Rows[i]["interes"] = Math.Round(nMonIntCuo, 2);
                dtPlanPago.Rows[i]["capital"] = Math.Round(nMonCapCuo, 2);
                dtPlanPago.Rows[i]["sal_cap"] = Math.Round(nSalCapital, 2);
                nSalCapital = Math.Round(nSalCapital - nMonCapCuo, 2);
                dtPlanPago.Rows[i]["nIdSolicitud"] = nNumsolicitud;
            }//Fin de recorrer todas las cuotas

            // Ajustando la última cuota
            decimal nSumCapital = nCero;
            for (int i = 0; i < nNumCuoCta - 1; i++)
            {
                nSumCapital = nSumCapital + Convert.ToDecimal(dtPlanPago.Rows[i]["capital"]);
            }

            var nSaldoCapitalUltcuota = Math.Round((nMonDesemb - nSumCapital), 2);

            dtPlanPago.Rows[nNumCuoCta - 1]["sal_cap"] = nSaldoCapitalUltcuota;
            dtPlanPago.Rows[nNumCuoCta - 1]["capital"] = Math.Round(nSaldoCapitalUltcuota, 2);
            nMonIntCuo = Math.Round(((nSaldoCapitalUltcuota * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaCuoCta))) - nSaldoCapitalUltcuota), 2);

            //==========================================================================
            // CALCULO DE GASTO PARA LA EL AJUSTE EN LA ÚLTIMA CUOTA
            //==========================================================================
            nMonGastosTipo1 = 0;
            nMonGastosTipo2 = 0;
            DateTime dFechaInicio = (dtPlanPago.Rows.Count == 1) ? dFecDesemb : Convert.ToDateTime(dtPlanPago.Rows[nNumCuoCta - 2]["fecha"]);
            dFechaFin = Convert.ToDateTime(dtPlanPago.Rows[nNumCuoCta - 1]["fecha"]);
            nSalCapital = Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["sal_cap"]);

            for (int f = 0; f < dtConfigGasto.Rows.Count; f++)
            {
                if (dtConfigGasto.Rows[f]["nClasificTipoGasto"].Equals("1"))//Para los Gastos del Tipo 1
                {
                    //Para los PORCENTUALES SIMPLES ó COMPUESTOS que afecten a 'SALDO CAPITAL', deben aplicarse a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                            decimal nGasto = Math.Round((nSaldoCapitalUltcuota * Convert.ToDecimal(Math.Pow((1.0 + (double)nTasaCalculadaDelTipoGasto), nDiaCuoCta)) - nSaldoCapitalUltcuota), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                        }
                        else
                        {
                            //obteniendo el calculo de gasto de seguro de desgravamen
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);

                            decimal nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                        }
                    }
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                            decimal nGasto = Math.Round(nSaldoCapitalUltcuota * nTasaCalculadaDelTipoGasto * nDiaCuoCta, 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                        }
                        else
                        {
                            //obteniendo el calculo de gasto de seguro de desgravamen
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);

                            decimal nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                        }
                    }
                }

                else//Para los Gastos del Tipo 2
                {
                    //Para los PORCENTUALES SIMPLES ó COMPUESTOS que afecten a 'SALDO CAPITAL', deben aplicarse a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                            decimal nGasto = Math.Round((nSaldoCapitalUltcuota * Convert.ToDecimal(Math.Pow((1.0 + (double)nTasaCalculadaDelTipoGasto), nDiaCuoCta)) - nSaldoCapitalUltcuota), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                        }
                        else
                        {
                            //obteniendo el calculo de gasto de seguro de desgravamen
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);

                            decimal nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                        }
                    }

                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                    {
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                                decimal nGasto = Math.Round(nSaldoCapitalUltcuota * nTasaCalculadaDelTipoGasto * nDiaCuoCta, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                            }
                            else
                            {
                                //obteniendo el calculo de gasto de seguro de desgravamen
                                int nCierres = 0;
                                decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);

                                decimal nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                            }
                        }

                        //Los Gastos PORCENTUALES SIMPLES que afecten a 'MONTO PRESTAMO' pueden aplicarse a cualquier cuota, no es obligatorio a TODAS LAS CUOTAS
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO"))
                        {
                            if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("ULTIMA CUOTA"))
                            {
                                decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                                decimal nGasto = Math.Round(nMonDesemb * nTasaCalculadaDelTipoGasto / 100, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                            }
                            if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                            {
                                decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                                decimal nGasto = Math.Round(nMonDesemb * nTasaCalculadaDelTipoGasto / 100, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                            }
                        }

                        //Para los PORCENTUALES SIMPLES que afecten a 'CAPITAL', 'CUOTA (CAPITAL + INTERÉS)', deben aplicarse a TODAS LAS CUOTAS
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                            decimal nGasto = Math.Round(((
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))//-->Monto Capital de la cuota
                                + nMonIntCuo//-->Monto del Interés
                                ) * nTasaCalculadaDelTipoGasto / 100), 2);

                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                        }
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("CAPITAL"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                            decimal nGasto = Math.Round((
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))//-->Monto Capital de la cuota
                                * (nTasaCalculadaDelTipoGasto / 100))
                                , 2);

                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                        }
                    }

                    //Los Gastos FIJOs puden aplicarse a cualquier cuota, no es obligatorio a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("FIJO"))
                    {
                        //Verificar la cuota a la que está aplicando el gasto
                        if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("ULTIMA CUOTA"))
                        {
                            decimal nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                        }
                        else if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            decimal nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                        }
                    }
                }
            }

            dtPlanPago.Rows[nNumCuoCta - 1]["interes"] = Math.Round(nMonIntCuo, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["comisiones"] = Math.Round(nMonGastosTipo1 + nMonGastosTipo2, 2);
            // nItf = cnFuncionesUtiles.truncar(((Math.Round((nMonDesemb - nSumCapital) + nMonIntCuo + nMonGastosTipo1, nValRedond) + nMonGastosTipo2) * Convert.ToDecimal (clsVarGlobal.nITF) / 100.00), 2, nIdMoneda);
            dtPlanPago.Rows[nNumCuoCta - 1]["Itf"] = 0.00;// Math.Round(nItf, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(nSaldoCapitalUltcuota + nMonIntCuo + nMonGastosTipo1 + nMonGastosTipo2, 2);

            dtPlanPago.AcceptChanges();
            return dtPlanPago;
        }

        public DataTable CalculaPpgCuotasConstantes2(decimal nMonDesemb, decimal nTasa, DateTime dFecDesemb,
                                                     int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag,
                                                     int nNumsolicitud, DataTable dtConfigGasto, int nIdMoneda,
                                                     DataTable dtCuotasDobles, DateTime dFecPrimeraCuota,
                                                     decimal nCuotaSugerida = 0, decimal nCapitalMaxCobSegDes = 0,
                                                     int nNroCuotasGracia = 0, bool lConstante = false, decimal _nCuota = 0,
                                                     clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null, bool lAplicaNuevoMultirriesgo = true, bool lEsPrePago = false)
        {
            #region Realizando el cálculo de la tasa efectiva diaria

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];

            double nTasEfeDia = 0.00;

            //Tasa de interes efectiva diaria TEA
            switch (nFormaCalculoTasa)
            {
                case 1:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 360.0)) - 1;
                    break;
                case 2:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 30.0)) - 1;
                    break;
            }

            #endregion

            #region Realizando la definición de la tabla de plan de pagos

            int nDiaAcumul = 0;
            decimal nFacRecCap;
            decimal nFacAcumul = nCero;
            DateTime dFecNewCuo = dFecPrimeraCuota;

            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));
            dtPlanPago.Columns.Add("frc", typeof(decimal));
            dtPlanPago.Columns.Add("sal_cap", typeof(decimal));
            dtPlanPago.Columns.Add("capital", typeof(decimal));
            dtPlanPago.Columns.Add("interes", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones_sinSeg", typeof(decimal)); //comisiones sin seguro
            dtPlanPago.Columns.Add("itf", typeof(decimal));
            dtPlanPago.Columns.Add("nAtrasoCuota", typeof(int));
            dtPlanPago.Columns.Add("nInteresComp", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));
            dtPlanPago.Columns.Add("nIdSolicitud", typeof(int));

            #endregion

            #region Fecha Fija - (Fecha Fija, solo es válido para frecuencias multiplos del mes)

            if (nTipPerPag == 1)
            {
                if (nDiaGraCta == 0)
                // Para evitar que la primera cuota se genere el mismo día del desembolso (con 0 días)
                {
                    dFecNewCuo = dFecNewCuo.AddDays(1);
                }
                for (int i = 1; i <= nNumCuoCta; i++) //Recorrer las cuotas para definir las fechas de pago
                {
                    DataRow fila = dtPlanPago.NewRow();
                    fila["cuota"] = i;
                    int nNumMesCuo;
                    int nNumAñoCuo;
                    if (i == 1) // Si primera cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else // A partir de la 2da cuota
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        // Si el mes de la nueva cuota superó a diciembre se pone a enero y se suma un año
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    var nDiaFecAux = nDiaFecPag;
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (i == 1)
                        {
                            dFecNewCuo = dFecPrimeraCuota;
                            break;
                        }
                        DateTime dfecVeriFec;
                        if (DateTime.TryParse(string.Format("{0}/{1}/{2}", nDiaFecAux, nNumMesCuo, nNumAñoCuo),
                            out dfecVeriFec))
                        {
                            dFecNewCuo = DateTime.Parse(string.Format("{0}/{1}/{2}", nDiaFecAux, nNumMesCuo, nNumAñoCuo));
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1;
                        // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                    }
                    bool lCuotaDoble = dtCuotasDobles.AsEnumerable()
                                                        .Any(x => x.Field<bool>("lEstado") &&
                                                                  x.Field<int>("nMes") == dFecNewCuo.Month &&
                                                                  x.Field<int>("nAnio") == dFecNewCuo.Year);
                    fila["fecha"] = dFecNewCuo;
                    // calculando la cantidad de días para la cuota
                    if (i == 1) // para la primera cuota
                    {
                        fila["dias"] = (dFecNewCuo - dFecNewCuo.AddMonths(-1)).Days;
                    }
                    else //Para las cuotas de la segunda en adelante
                    {
                        fila["dias"] =
                            (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days;
                    }

                    nDiaAcumul = nDiaAcumul + Convert.ToInt32(fila["dias"]);
                    fila["dias_acu"] = nDiaAcumul;

                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul));
                    //calculando el FRC de la cuota

                    nFacRecCap = nFacRecCap * (lCuotaDoble ? 2 : 1);
                    nFacAcumul = nFacAcumul + nFacRecCap; //Acumulando el FRC
                    fila["frc"] = nFacRecCap;
                    dtPlanPago.Rows.Add(fila);
                }
            }

            #endregion

            #region Periodo Fijo
            else
            {
                int difFechas = 0;
                for (int i = 1; i <= nNumCuoCta; i++)
                {
                    bool lCuotaDoble = false;
                    DataRow fila = dtPlanPago.NewRow();                    
                    fila["cuota"] = i; //registrando la cuota
                    if (i == 1) //Para la primera cuota
                    {
                        DateTime dFechaFormatPrimeracuota = dFecPrimeraCuota;
                        nDiaAcumul = nDiaAcumul + nDiaGraCta + nDiaFecPag;
                        dFecNewCuo = dFecPrimeraCuota;
                        fila["fecha"] = dFechaFormatPrimeracuota;
                        fila["dias"] = nDiaFecPag;
                        fila["dias_acu"] = nDiaAcumul;
                    }
                    else
                    {
                        lCuotaDoble = dtCuotasDobles.AsEnumerable()
                                                        .Any(x => x.Field<bool>("lEstado") &&
                                                                  x.Field<int>("nMes") == dFecNewCuo.Month &&
                                                                  x.Field<int>("nAnio") == dFecNewCuo.Year);
                        nDiaAcumul = nDiaAcumul + nDiaFecPag;
                        dFecNewCuo = dFecNewCuo.AddDays(Convert.ToDouble(nDiaFecPag));
                        fila["fecha"] = dFecNewCuo;
                        fila["dias"] =
                            (Convert.ToDateTime(dFecNewCuo) - Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"])).Days + difFechas;
                        fila["dias_acu"] = nDiaAcumul;
                        difFechas = 0;
                    }

                    nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul));
                    //calculando el FRC de la cuota

                    nFacRecCap = nFacRecCap * (lCuotaDoble ? 2 : 1);
                    nFacAcumul += nFacRecCap; //Acumulando el FRC
                    fila["frc"] = nFacRecCap;
                    dtPlanPago.Rows.Add(fila);
                }
            }
            #endregion

            #region Calculo de plan de pagos

            if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
            {
                lstPlanesSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            }

            //decimal nCuotaSugIni = decimal.Round(nMonDesemb / nFacAcumul, nDecRedonCalcPpg);
            decimal nCuotaSugIni = ObtenerCuotaAproximada(nMonDesemb, nFacAcumul, nDecRedonCalcPpg, _nCuota);

            decimal nMonCuoAux = nCuotaSugIni;
            int nNumIterac = 0;
            decimal nMonSalCap = decimal.Round(nMonDesemb, 2);

            const int nMaxIterac = 20;
            decimal nValErrMax = 0.09m * nNumCuoCta;

            bool lFlgFactor = false;
            int nIteraTrue = 0;

            bool lIndSalIte = false;
            int lNumSalIte = 0;
            decimal nPotencDos = 0;
            decimal nRazBusCuo = 0;

            decimal nOtrosCuota;
            decimal nValorSegurosOptativos = 0;

            clsCreditoGasto creditoGasto = new clsCreditoGasto
            {
                Id = nNumsolicitud,
                nNumCuotas = nNumCuoCta,
                dFechaDesembolso = dFecDesemb,
                nMontoDesembolso = nMonDesemb,
                nCapitalMaxCobSeg = nCapitalMaxCobSegDes
            };

            clsCNCargaGastosCred objCargaGastosCred = null;
            /*variable de apoyo*/
            decimal nMenorDiferencia = 99999999;

            /*dt temporal para seleccionar plan de pagos*/
            DataTable dtPlanPagosSeleccionado = new DataTable();

            if (lConstante)
            {
                nMontoCuota = nMonCuoAux;
                while (Math.Abs(nMonSalCap) > nValErrMax && nNumIterac < nMaxIterac)
                {
                    objCargaGastosCred = new clsCNCargaGastosCred(dtConfigGasto, creditoGasto);
                    ObjCargaGastosCred = objCargaGastosCred;
                    nMonSalCap = decimal.Round(nMonDesemb, 2);
                    iniciarDTGastos();
                    objCargaGastosCred.iniciaDTSegurosOptativos();
                    foreach (DataRow row in dtPlanPago.Rows)
                    {
                        int idCuota = Convert.ToInt32(row["cuota"]);
                        DataRow drCuotaAnt = null;
                        if (idCuota > 1)
                        {
                            drCuotaAnt = dtPlanPago.Rows[dtPlanPago.Rows.IndexOf(row) - 1];
                        }
                        int nDiaCuoCta = Convert.ToInt16(row["dias"]);
                        decimal nMonIntCuo =
                            decimal.Round((nMonSalCap * (decimal)(Math.Pow(1 + nTasEfeDia, nDiaCuoCta) - 1)), 2);

                        DateTime dFecha = row.Field<DateTime>("fecha");
                        bool lCuotaDoble = dtCuotasDobles.AsEnumerable()
                                                        .Any(x => x.Field<bool>("lEstado") &&
                                                                  x.Field<int>("nMes") == dFecha.Month &&
                                                                  x.Field<int>("nAnio") == dFecha.Year);
                        decimal nMontCuoRedond = Math.Round(nMonCuoAux, nDecRedonCalcPpg) * (lCuotaDoble ? 2 : 1);

                        row["sal_cap"] = nMonSalCap;
                        row["interes"] = nMonIntCuo;
                        row["comisiones_sinSeg"] = 0;
                        row["itf"] = 0;
                        row["imp_cuota"] = nMontCuoRedond;
                        row["nIdSolicitud"] = nNumsolicitud;

                        objCargaGastosCred.CargarGastoCuotaConstantes(row, drCuotaAnt);
                        nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);

                        if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                        {
                            objCargaGastosCred.nGastosCouta = nOtrosCuota;
                            objCargaGastosCred.EsRetecion = EsRetencion;
                            objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, row, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos, lEsPrePago);
                            nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                                .Cast<DataRow>()
                                .Where(x => x.Field<int>("idcuota") == idCuota)
                                .Sum(x => x.Field<decimal>("nGasto"));
                        }

                        row["comisiones"] = nOtrosCuota + nValorSegurosOptativos;

                        decimal nOtros = Convert.ToDecimal(row["comisiones"]);
                        decimal nMonCapCuo = (nNroCuotasGracia >= idCuota) ? 0.0m : nMontCuoRedond - nMonIntCuo - nOtros;

                        row["capital"] = nMonCapCuo;

                        objCargaGastosCred.CargarGastoCuotaNoConstantes(row, drCuotaAnt);
                        nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);

                        row["comisiones"] = nOtrosCuota + nValorSegurosOptativos;

                        row["imp_cuota"] = nMonCapCuo + nMonIntCuo + nOtrosCuota + nValorSegurosOptativos;

                        nMonSalCap = nMonSalCap - nMonCapCuo;
                    }

                    nMontoCuota = Math.Round(nMonCuoAux, nDecRedonCalcPpg);
                    nNumIterac = nNumIterac + 1;

                    //si esta seteado la cuota <> 0 entonces no se itera
                    if (_nCuota > 0)
                    {
                        break;
                    }

                    if (nIteraTrue > 0)
                    {
                        if (nMonSalCap < 0)
                        {
                            nPotencDos = nPotencDos / 2;
                            nMonCuoAux = nCuotaSugIni - nRazBusCuo;
                            lFlgFactor = true;
                        }
                        else
                        {
                            if (lFlgFactor == false)
                            {
                                nPotencDos = nPotencDos * 2;
                            }
                        }
                    }
                    else
                    {
                        nPotencDos = 2;
                    }

                    nIteraTrue = nIteraTrue + 1;

                    nRazBusCuo = decimal.Round(nMonSalCap * nPotencDos / nDiaAcumul, 10);
                    nMonCuoAux = nMonCuoAux + nRazBusCuo;
                    if (nRazBusCuo == 0)
                    {
                        if (lIndSalIte == false)
                        {
                            lIndSalIte = true;
                            lNumSalIte = nNumIterac;
                        }

                        nMonCuoAux = nMonCuoAux + 0.01m;
                    }

                    if ((nNumIterac == lNumSalIte + 1) && lNumSalIte > 0)
                    {
                        break;
                    }

                    /*Seleccion de Plan de Pagos con menor diferencia entre Saldo Capital y Capital*/
                    decimal nMenorDiferencia_ =
                        Math.Abs(Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["sal_cap"])
                        - Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["capital"]));
                    if (nMenorDiferencia >= nMenorDiferencia_)
                    {
                        nMenorDiferencia = nMenorDiferencia_;
                        dtPlanPagosSeleccionado = dtPlanPago.Copy();
                    }
                }
                /*Seteado de Pan de Pagos seleccionado*/
                dtPlanPago = dtPlanPagosSeleccionado.Copy();
            }
            else
            {
                objCargaGastosCred = new clsCNCargaGastosCred(dtConfigGasto, creditoGasto);
                ObjCargaGastosCred = objCargaGastosCred;
                nMonSalCap = decimal.Round(nMonDesemb, 2);
                iniciarDTGastos();
                nMontoCuota = nMonCuoAux;
                objCargaGastosCred.iniciaDTSegurosOptativos();
                foreach (DataRow row in dtPlanPago.Rows)
                {
                    int idCuota = Convert.ToInt32(row["cuota"]);
                    DataRow drCuotaAnt = null;
                    if (idCuota > 1)
                    {
                        drCuotaAnt = dtPlanPago.Rows[dtPlanPago.Rows.IndexOf(row) - 1];
                    }
                    int nDiaCuoCta = Convert.ToInt16(row["dias"]);
                    decimal nMonIntCuo = decimal.Round((nMonSalCap * (decimal)(Math.Pow(1 + nTasEfeDia, nDiaCuoCta) - 1)), 2);

                    DateTime dFecha = row.Field<DateTime>("fecha");
                    bool lCuotaDoble = dtCuotasDobles.AsEnumerable()
                                                        .Any(x => x.Field<bool>("lEstado") &&
                                                                  x.Field<int>("nMes") == dFecha.Month &&
                                                                  x.Field<int>("nAnio") == dFecha.Year);

                    row["sal_cap"] = nMonSalCap;
                    row["interes"] = nMonIntCuo;
                    row["comisiones_sinSeg"] = 0;
                    row["itf"] = 0;
                    if (nCuotaSugerida > 0)
                    {
                        row["imp_cuota"] = Math.Round(nCuotaSugerida, nDecRedonCalcPpg);
                    }
                    else
                    {
                        row["imp_cuota"] = Math.Round(nMonCuoAux, nDecRedonCalcPpg) * (lCuotaDoble ? 2 : 1); ;
                    }
                    row["nIdSolicitud"] = nNumsolicitud;

                    objCargaGastosCred.CargarGastoCuotaConstantes(row, drCuotaAnt);
                    nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);

                    row["comisiones"] = nOtrosCuota;

                    decimal nOtros = Convert.ToDecimal(row["comisiones"]);
                    decimal nMonCapCuo;
                    if (nCuotaSugerida > 0)
                    {
                        nMonCapCuo = (nNroCuotasGracia >= idCuota)
                            ? 0.0m
                            : (Math.Round(nCuotaSugerida, nDecRedonCalcPpg) - nMonIntCuo - nOtros);
                    }
                    else
                    {
                        nMonCapCuo = (nNroCuotasGracia >= idCuota)
                            ? 0.0m
                            : (Math.Round(nMonCuoAux, nDecRedonCalcPpg) * (lCuotaDoble ? 2 : 1) - nMonIntCuo);
                    }

                    row["capital"] = nMonCapCuo;

                    objCargaGastosCred.CargarGastoCuotaNoConstantes(row, drCuotaAnt);
                    nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);

                    if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                    {
                        objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, row, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos, lEsPrePago);
                        nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                            .Cast<DataRow>()
                            .Where(x => x.Field<int>("idcuota") == idCuota)
                            .Sum(x => x.Field<decimal>("nGasto"));
                    }

                    row["comisiones"] = nOtrosCuota + nValorSegurosOptativos;

                    nOtros = Convert.ToDecimal(row["comisiones"]);

                    row["comisiones"] = nOtros;
                    row["imp_cuota"] = nMonCapCuo + nMonIntCuo + nOtros;

                    nMonSalCap = nMonSalCap - nMonCapCuo;
                }
            }
            //Ajuste de la última cuota
            decimal nSumCapital = nCero;

            int nNumDiaUltCuo = Convert.ToInt16(dtPlanPago.Rows[nNumCuoCta - 1]["dias"]);
            decimal nSaldoCapUltcCuo = Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["sal_cap"]);
            decimal nCapUltCuo = nSaldoCapUltcCuo;
            decimal nMonIntUltCuo = Math.Round(((nSaldoCapUltcCuo * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nNumDiaUltCuo))) - nSaldoCapUltcCuo), 2);
            decimal nMonOtrosUltCuo = Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["comisiones"]);
            dtPlanPago.Rows[nNumCuoCta - 1]["capital"] = Math.Round(nCapUltCuo, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["interes"] = Math.Round(nMonIntUltCuo, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(nCapUltCuo + nMonIntUltCuo + nMonOtrosUltCuo, 2);

            dtGastos = objCargaGastosCred.dtGastos.Copy();

            #endregion

            dtPlanPago.AcceptChanges();
            return dtPlanPago;
        }

        public DataTable CalcularCuotasLibresEvalRural(int nNumCuoCta, decimal nMonDesemb, DateTime dFecDesembNueva, int idSolicitud, decimal nTasa, DateTime dFecPrimeraCuota,
            DataTable dtConfigGasto, decimal nCapitalMaxCobSegDes = 0, int origen = (int)Origen.GeneracionPlanPagos, clsPlanPago PlanPagoPrePago = null, bool lConstante = false,
            clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null, bool lAplicaNuevoMultirriesgo = true)
        {
            DateTime dFecDesemb;

            if (origen == (int)Origen.PrePago)
            {
                dFecDesemb = clsVarGlobal.dFecSystem.Date;
            }
            else
            {
                DataTable dtCredRural = new clsCNEvalCrediRural().ObtenerConfiguracionDiseCredRuralxSolicitud(idSolicitud);
                if (dtCredRural.Rows.Count == 0)
                {
                    dFecDesemb = clsVarGlobal.dFecSystem.Date;
                    return this.CalculaPpgCuotasConstantes2(nMonDesemb, nTasa, dFecDesemb, nNumCuoCta, 0, 3, 30, idSolicitud, dtConfigGasto, 1, new DataTable(), dFecPrimeraCuota);
                }
                else
                {
                    dFecDesemb = Convert.ToDateTime(dtCredRural.Rows[0]["dFechaDesembolso"]);
                }
            }

            #region Realizando el cálculo de la tasa efectiva diaria

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];

            double nTasEfeDia = 0.00;

            //Tasa de interes efectiva diaria TEA
            switch (nFormaCalculoTasa)
            {
                case 1:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 360.0)) - 1;
                    break;
                case 2:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 30.0)) - 1;
                    break;
            }

            #endregion

            #region Realizando la definición de la tabla de plan de pagos

            int nDiaAcumul = 0;
            decimal nFacRecCap;
            decimal nOtrosCuota1;
            decimal nOtrosCuota2;
            DateTime dFechAnt;
            int ndias;
            decimal nMonSalCap;
            nMonSalCap = decimal.Round(nMonDesemb, 2);

            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));
            dtPlanPago.Columns.Add("frc", typeof(decimal));
            dtPlanPago.Columns.Add("sal_cap", typeof(decimal));
            dtPlanPago.Columns.Add("capital", typeof(decimal));
            dtPlanPago.Columns.Add("interes", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones_sinSeg", typeof(decimal)); //comisiones sin seguro
            dtPlanPago.Columns.Add("itf", typeof(decimal));
            dtPlanPago.Columns.Add("nAtrasoCuota", typeof(int));
            dtPlanPago.Columns.Add("nInteresComp", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));
            dtPlanPago.Columns.Add("nIdSolicitud", typeof(int));

            #endregion

            #region Generar Calendario en base al disenio crediticio

            List<clsDisenioCredito> lstDisenioCredito = new List<clsDisenioCredito>();
            decimal calculoPorcentualCapital = 0m;
            decimal capitalInicialSolicitado = 0m;

            if (origen == (int)Origen.PrePago)
            {
                capitalInicialSolicitado = PlanPagoPrePago.First().nSaldoCapital;
                var lstPlanPagoPrePago = PlanPagoPrePago.FindAll(x => x.dFechaProg >= dFecPrimeraCuota).OrderBy(x => x.idCuota);

                foreach (var item in lstPlanPagoPrePago)
                {
                    clsDisenioCredito rowDisenioCred = new clsDisenioCredito();
                    rowDisenioCred.dFecha = item.dFechaProg;
                    rowDisenioCred.nDiaDesembolso = item.dFechaProg.Day;
                    lstDisenioCredito.Add(rowDisenioCred);

                    decimal porcentajeCapital = clsNumerico.Dividir(item.nCapital, capitalInicialSolicitado);
                    calculoPorcentualCapital = calculoPorcentualCapital + porcentajeCapital;
                }
            }
            else
            {
                DataTable dtDisenioCredito = new clsCNEvalCrediRural().SelectDisenioCrediticioxSolic(idSolicitud);
                lstDisenioCredito = DataTableToList.ConvertTo<clsDisenioCredito>(dtDisenioCredito) as List<clsDisenioCredito>;
                lstDisenioCredito = lstDisenioCredito.Skip(1).Where(x => x.nMontoCuota > 0).ToList();
            }

            int nCuota = 1;
            foreach (var item in lstDisenioCredito)
            {
                item.nCuota = nCuota;
                nCuota += 1;
            }

            foreach (var item in lstDisenioCredito)
            {
                DataRow fila = dtPlanPago.NewRow();

                if (item.nCuota > 1)
                {
                    dFechAnt = (DateTime)lstDisenioCredito.Find(x => x.nCuota == item.nCuota - 1).dFecha;
                    nDiaAcumul = Convert.ToInt32(((DateTime)item.dFecha - dFecDesemb).Days);
                }
                else
                {
                    dFechAnt = dFecDesemb;
                    nDiaAcumul = Convert.ToInt32(((DateTime)item.dFecha - dFechAnt).Days);
                }

                ndias = Convert.ToInt32(((DateTime)item.dFecha - dFechAnt).Days);
                nFacRecCap = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul));
                int nDiaCuoCta = Convert.ToInt16(ndias);
                decimal nMonIntCuo = decimal.Round((nMonSalCap * (decimal)(Math.Pow(1 + nTasEfeDia, nDiaCuoCta) - 1)), 2);
                decimal nMonCapCuo = 0m;
                decimal nImpCuota = 0m;

                if (origen == (int)Origen.PrePago)
                {
                    decimal capitalCuota = PlanPagoPrePago.Find(x => x.dFechaProg == item.dFecha).nCapital;
                    decimal porcentajeCapital = clsNumerico.Dividir(capitalCuota, capitalInicialSolicitado);
                    decimal nuevoPorcentajeCapital = clsNumerico.Dividir(porcentajeCapital, calculoPorcentualCapital);

                    nMonCapCuo = nuevoPorcentajeCapital * nMonDesemb;
                    nImpCuota = nMonCapCuo + nMonIntCuo;
                }
                else
                {
                    nMonCapCuo = item.nMontoCuota - nMonIntCuo;
                    nImpCuota = item.nMontoCuota;
                }

                fila["cuota"] = item.nCuota;
                fila["fecha"] = (DateTime)item.dFecha;
                fila["dias"] = ndias;
                fila["dias_acu"] = nDiaAcumul;
                fila["frc"] = nFacRecCap;
                fila["sal_cap"] = nMonSalCap;
                fila["capital"] = nMonCapCuo;
                fila["interes"] = nMonIntCuo;
                fila["comisiones"] = 0m;
                fila["comisiones_sinSeg"] = 0m;
                fila["itf"] = 0m;
                fila["nAtrasoCuota"] = 0m;
                fila["nInteresComp"] = 0m;
                fila["imp_cuota"] = nImpCuota;
                fila["nIdSolicitud"] = idSolicitud;
                dtPlanPago.Rows.Add(fila);

                nMonSalCap = nMonSalCap - nMonCapCuo;
            }

            #endregion

            #region Ajuste de primera cuota para desembolso fuera de fecha

            int nVarDias = Convert.ToInt32((dFecDesembNueva - dFecDesemb).Days);
            int nDias = Convert.ToInt32(dtPlanPago.Rows[0]["dias"]) - nVarDias;
            decimal nMonIntExd = decimal.Round((nMonDesemb * (decimal)(Math.Pow(1 + nTasEfeDia, nDias) - 1)), 2);
            decimal nMonIntAjuste = Convert.ToDecimal(dtPlanPago.Rows[0]["interes"]) - nMonIntExd;
            dtPlanPago.Rows[0]["dias"] = nDias;
            dtPlanPago.Rows[0]["interes"] = nMonIntExd;
            dtPlanPago.Rows[0]["imp_cuota"] = Convert.ToDecimal(dtPlanPago.Rows[0]["imp_cuota"]) - nMonIntAjuste;
            dFecDesemb = dFecDesembNueva;

            #endregion

            #region Calculo de Gastos (Seguro desgravamen y redondeo)

            if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
            {
                //Obtengo la lista de todos los planes que se pueden vender segun el perfil y la agencia
                lstPlanesSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            }

            clsCreditoGasto creditoGasto = new clsCreditoGasto
            {
                Id = idSolicitud,
                nNumCuotas = nCuota,
                dFechaDesembolso = dFecDesemb,
                nMontoDesembolso = nMonDesemb,
                nCapitalMaxCobSeg = nCapitalMaxCobSegDes
            };

            clsCNCargaGastosCred objCargaGastosCred = null;
            objCargaGastosCred = new clsCNCargaGastosCred(dtConfigGasto, creditoGasto);
            ObjCargaGastosCred = objCargaGastosCred;
            iniciarDTGastos();

            decimal nValorSegurosOptativos = 0;
            objCargaGastosCred.iniciaDTSegurosOptativos();

            nMonSalCap = decimal.Round(nMonDesemb, 2);
            nDiaAcumul = 0;

            foreach (DataRow row in dtPlanPago.Rows)
            {
                int idCuota = Convert.ToInt32(row["cuota"]);
                decimal nCuotaRedondeo = Convert.ToDecimal(row["imp_cuota"]);
                decimal nCuotaFinalRedondeo = decimal.Zero;
                int nDiasRedondeo = Convert.ToInt16(row["dias"]);
                decimal nMonIntRedondeo = Math.Round(((nMonSalCap * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiasRedondeo))) - nMonSalCap), 2);
                DataRow drCuotaAnt = null;
                int nDiaCuoCta = Convert.ToInt32(row["dias"]);

                nDiaAcumul = nDiaAcumul + nDiaCuoCta;
                row["dias_acu"] = nDiaAcumul;
                row["sal_cap"] = nMonSalCap;
                row["interes"] = nMonIntRedondeo;
                row["comisiones_sinSeg"] = 0;
                row["itf"] = 0;
                row["frc"] = 1 / Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nDiaAcumul));
                if (idCuota > 1)
                {
                    drCuotaAnt = dtPlanPago.Rows[dtPlanPago.Rows.IndexOf(row) - 1];
                }
                objCargaGastosCred.CargarGastoCuotaConstantes(row, drCuotaAnt);
                nOtrosCuota1 = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);
                if (lConstante)
                {
                    nCuotaFinalRedondeo = Math.Round(nCuotaRedondeo + nOtrosCuota1, clsCNPlanPago.nDecRedonCalcPpg);
                }
                else
                {
                    nCuotaFinalRedondeo = nCuotaRedondeo + nOtrosCuota1;
                }

                if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                {
                    objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, row, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos);
                    nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                        .Cast<DataRow>()
                        .Where(x => x.Field<int>("idcuota") == idCuota)
                        .Sum(x => x.Field<decimal>("nGasto"));
                }

                row["imp_cuota"] = nCuotaFinalRedondeo;
                row["comisiones"] = nOtrosCuota1 + nValorSegurosOptativos;

                decimal nOtros = Convert.ToDecimal(row["comisiones"]);
                decimal nMonCapCuo;
                nMonCapCuo = nCuotaFinalRedondeo - nMonIntRedondeo - nOtros;
                row["capital"] = nMonCapCuo;

                objCargaGastosCred.CargarGastoCuotaNoConstantes(row, drCuotaAnt);
                nOtrosCuota2 = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto);

                row["comisiones"] = nOtrosCuota2 + nValorSegurosOptativos;

                nOtros = Convert.ToDecimal(row["comisiones"]);

                nMonCapCuo = nCuotaFinalRedondeo - nMonIntRedondeo - nOtros;
                row["capital"] = nMonCapCuo;
                row["comisiones"] = nOtros;
                row["imp_cuota"] = nMonCapCuo + nMonIntRedondeo + nOtros;

                nMonSalCap = nMonSalCap - nMonCapCuo;
            }

            #endregion

            #region Ajuste de la última cuota

            int nNumDiaUltCuo = Convert.ToInt16(dtPlanPago.Rows[nNumCuoCta - 1]["dias"]);
            decimal nSaldoCapUltcCuo = Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["sal_cap"]);
            decimal nCapUltCuo = nSaldoCapUltcCuo;
            decimal nMonIntUltCuo = Math.Round(((nSaldoCapUltcCuo * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nNumDiaUltCuo))) - nSaldoCapUltcCuo), 2);
            decimal nMonOtrosUltCuo = Convert.ToDecimal(dtPlanPago.Rows[nNumCuoCta - 1]["comisiones"]);
            dtPlanPago.Rows[nNumCuoCta - 1]["capital"] = Math.Round(nCapUltCuo, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["interes"] = Math.Round(nMonIntUltCuo, 2);
            dtPlanPago.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(nCapUltCuo + nMonIntUltCuo + nMonOtrosUltCuo, 2);
            dtGastos = objCargaGastosCred.dtGastos;
            dtPlanPago.AcceptChanges();

            #endregion

            return dtPlanPago;
        }


        private void cargarGastoACuota(decimal nMonDesemb, int nNumCuoCta, DataTable dtConfigGasto, decimal nCuotaFinal,
                                        decimal nSalCapital, int nDiaCuoCta, decimal nMonIntCuo, ref decimal nMonGastosTipo1,
                                        ref decimal nMonGastosTipo2, int i, ref decimal nMonGastosTipo1SinSeg, ref decimal nMonGastosTipo2SinSeg
                                        , int nNroCuota, DateTime dFechaInicio, DateTime dFechaFin, decimal nCapitalMaxCobSegDes)
        {
            for (int f = 0; f < dtConfigGasto.Rows.Count; f++)
            {
                if (dtConfigGasto.Rows[f]["nClasificTipoGasto"].Equals("1"))//Para los Gastos del Tipo 1
                {
                    //Para los PORCENTUALES SIMPLES ó COMPUESTOS que afecten a 'SALDO CAPITAL', deben aplicarse a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                        decimal nGasto = 0.0m;
                        //es diferente del concepto de seguro de desgravamen
                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            nGasto = Math.Round((nSalCapital * Convert.ToDecimal(Math.Pow((1.0 + (double)nTasaCalculadaDelTipoGasto), nDiaCuoCta)) - nSalCapital), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                            nMonGastosTipo1SinSeg = nMonGastosTipo1SinSeg + nGasto;
                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                        }
                        else
                        {
                            //obteniendo el calculo de gasto de seguro de desgravamen
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);

                            nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                        }

                    }
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                        decimal nGasto = 0.0m;


                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            nGasto = Math.Round((nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;
                            nMonGastosTipo1SinSeg = nMonGastosTipo1SinSeg + nGasto;
                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                        }
                        else
                        {
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                            nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo1 = nMonGastosTipo1 + nGasto;

                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                        }
                    }
                }
                else//Para los Gastos del Tipo 2
                {
                    //Para los PORCENTUALES SIMPLES ó COMPUESTOS que afecten a 'SALDO CAPITAL', deben aplicarse a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                        decimal nGasto = 0.0M;


                        if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                        {
                            nGasto = Math.Round((nSalCapital * Convert.ToDecimal(Math.Pow((1.0 + (double)nTasaCalculadaDelTipoGasto), nDiaCuoCta)) - nSalCapital), 2); ;
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                            nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                        }
                        else
                        {
                            int nCierres = 0;
                            decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;
                            nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                            nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                            dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                            nMonGastosTipo2 = nMonGastosTipo2 + nGasto;

                            cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                        }
                    }
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                    {
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nTasaEfectivaDiaria"]);
                            decimal nGasto = 0.0M;


                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                nGasto = Math.Round(nSalCapital * nTasaCalculadaDelTipoGasto * nDiaCuoCta, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                            }
                            else
                            {
                                int nCierres = 0;
                                decimal nCapCober = (nSalCapital >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nSalCapital;

                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                            }
                        }

                        //Los Gastos PORCENTUALES SIMPLES que afecten a 'MONTO PRESTAMO' pueden aplicarse a cualquier cuota, no es obligatorio a TODAS LAS CUOTAS
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO"))
                        {
                            //Verificar la cuota a la que está aplicando el gasto
                            if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("PRIMERA CUOTA") && i == 0)
                            {
                                decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                                decimal nGasto = 0.0m;

                                //
                                if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                                {
                                    nGasto = Math.Round((nMonDesemb * nTasaCalculadaDelTipoGasto / 100), 2);
                                    dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                    nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                    nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                                    cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                                }
                                else
                                {
                                    int nCierres = 0;
                                    decimal nCapCober = (nMonDesemb >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nMonDesemb;

                                    nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                    nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                    dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                    nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                    cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                                }
                            }
                            if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                            {
                                decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                                decimal nGasto = 0.0m;

                                //Solo Seguros
                                if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                                {
                                    nGasto = Math.Round((nMonDesemb * nTasaCalculadaDelTipoGasto / 100), 2);
                                    dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                    nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                    nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                                    cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                                }
                                else
                                {
                                    int nCierres = 0;
                                    decimal nCapCober = (nMonDesemb >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : nMonDesemb;

                                    nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                    nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                    dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                    nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                    cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                                }
                            }
                        }

                        //Para los PORCENTUALES SIMPLES que afecten a 'CAPITAL', 'CUOTA (CAPITAL + INTERÉS)', deben aplicarse a TODAS LAS CUOTAS
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                            decimal nGasto = 0.0m;

                            //Solo Seguros
                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                nGasto = Math.Round(((
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))//-->Monto Capital de la cuota
                                + nMonIntCuo//-->Monto del Interés
                                ) * nTasaCalculadaDelTipoGasto / 100), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                            }
                            else
                            {
                                int nCierres = 0;
                                decimal nCapCober = ((nCuotaFinal + nMonIntCuo) >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : (nCuotaFinal + nMonIntCuo);

                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                            }
                        }
                        if (dtConfigGasto.Rows[f]["cIdAplicaConcepto"].Equals("CAPITAL"))
                        {
                            decimal nTasaCalculadaDelTipoGasto = Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]);
                            decimal nGasto = 0.0m;

                            //Solo Seguros
                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                nGasto = Math.Round((
                                ((nCuotaFinal - nMonIntCuo) / (1 + nTasaCalculadaDelTipoGasto / 100))//-->Monto Capital de la cuota
                                * (nTasaCalculadaDelTipoGasto / 100))
                                , 2);

                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;

                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                            }
                            else
                            {
                                int nCierres = 0;
                                decimal nCapCober = ((nCuotaFinal + nMonIntCuo) >= nCapitalMaxCobSegDes) ? nCapitalMaxCobSegDes : (nCuotaFinal + nMonIntCuo);

                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                nGasto = Math.Round((nCapCober * Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) / 100.0000m * nCierres), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                            }
                        }
                    }

                    //Los Gastos FIJOs puden aplicarse a cualquier cuota, no es obligatorio a TODAS LAS CUOTAS
                    if (dtConfigGasto.Rows[f]["cIdTipoValor"].Equals("FIJO"))
                    {
                        //Verificar la cuota a la que está aplicando el gasto
                        if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("PRIMERA CUOTA") && i == 0)
                        {
                            decimal nGasto = 0.0m;

                            //Solo Seguros
                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, nGasto, Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                            }
                            else
                            {
                                int nCierres = 0;

                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) * nCierres, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;

                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, nGasto, Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                            }
                        }

                        else if (dtConfigGasto.Rows[f]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            decimal nGasto = 0.0m;

                            //Solo Seguros
                            if (!dtConfigGasto.Rows[f]["nIdTipoGasto"].Equals(10))
                            {
                                nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]), 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                nMonGastosTipo2SinSeg = nMonGastosTipo2SinSeg + nGasto;

                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, nGasto, nGasto, Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, 0.0m);
                            }
                            else
                            {
                                int nCierres = 0;
                                nCierres = CalcularCierresMes(dFechaInicio, dFechaFin);
                                nGasto = Math.Round(Convert.ToDecimal(dtConfigGasto.Rows[f]["nValor"]) * nCierres, 2);
                                dtConfigGasto.Rows[f]["nGasto"] = nGasto;
                                nMonGastosTipo2 = nMonGastosTipo2 + nGasto;
                                cargaGastoDT(ref dtGastos, 0, 1, nNroCuota, 0.0m, nGasto, Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoGasto"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdTipoValor"]), Convert.ToInt32(dtConfigGasto.Rows[f]["nIdAplicaConcepto"]), true, nGasto);
                            }
                        }
                    }
                }
            }
        }

        private decimal retonarTEDTotalGastoTipo1(DataTable dtConfigGasto, decimal nTotalTasaEfectivaDiariaGastoTipo1)
        {
            #region Configuración de carga de gastos

            //Calcular la Tasa Efectiva Diaria sólo para los que se apliquen al SALDO CAPITAL: para luego usarlo en el FRC
            //y deacuerdo a ésto usar interpolación para hallar la cuota Inicial que incluya a éstos Gastos
            if (dtConfigGasto.Columns.Count > 0)
            {
                dtConfigGasto.Columns["nTasaEfectivaDiaria"].ReadOnly = false;
                dtConfigGasto.Columns["nGasto"].ReadOnly = false;
            }
            for (int i = 0; i < dtConfigGasto.Rows.Count; i++)
            {
                if (dtConfigGasto.Rows[i]["nClasificTipoGasto"].Equals("1"))
                {
                    if (dtConfigGasto.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        //Se utiliza TASA COMPUESTA
                        decimal nValorTasaEfectivaDiaria = Convert.ToDecimal(Math.Pow((1.0 + (Convert.ToDouble(dtConfigGasto.Rows[i]["nValor"]) / 100)), (1.0 / 30.0))) - 1;
                        dtConfigGasto.Rows[i]["nTasaEfectivaDiaria"] = nValorTasaEfectivaDiaria;
                        nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + nValorTasaEfectivaDiaria;
                    }

                    if (dtConfigGasto.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtConfigGasto.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        //Se utiliza TASA SIMPLE
                        decimal nValorTasaEfectivaDiaria = (Convert.ToDecimal(dtConfigGasto.Rows[i]["nValor"]) / 100.0m) / 30.0m;
                        dtConfigGasto.Rows[i]["nTasaEfectivaDiaria"] = nValorTasaEfectivaDiaria;
                        nTotalTasaEfectivaDiariaGastoTipo1 = nTotalTasaEfectivaDiariaGastoTipo1 + nValorTasaEfectivaDiaria;
                    }
                }
                if (dtConfigGasto.Rows[i]["nClasificTipoGasto"].Equals("2"))
                {
                    if (dtConfigGasto.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtConfigGasto.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        //Se utiliza TASA COMPUESTA
                        decimal nValorTasaEfectivaDiaria = Convert.ToDecimal(Math.Pow((1.0 + (Convert.ToDouble(dtConfigGasto.Rows[i]["nValor"]) / 100.0)), (1.0 / 30.0))) - 1;
                        dtConfigGasto.Rows[i]["nTasaEfectivaDiaria"] = nValorTasaEfectivaDiaria;
                    }
                    if (dtConfigGasto.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtConfigGasto.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        //Se utiliza TASA SIMPLE
                        decimal nValorTasaEfectivaDiaria = (Convert.ToDecimal(dtConfigGasto.Rows[i]["nValor"]) / 100.0m) / 30.0m;
                        dtConfigGasto.Rows[i]["nTasaEfectivaDiaria"] = nValorTasaEfectivaDiaria;
                    }
                }
            }

            #endregion

            return nTotalTasaEfectivaDiariaGastoTipo1;
        }

        public DataTable CalculaPpgDesdeCuota(decimal nMonCuota, decimal nSaldoCapital, decimal nTasa,
                                                DateTime dFecDesemb, int nDiaGraCta, short nTipPerPag, int nDiaFecPag,
                                                int nNumsolicitud, decimal nTasSegDesgra, decimal nTasSegMulRie,
                                                DateTime dFecPriCuota, DataTable dtGastosParam = null,
                                                decimal nCapitalMaxCobSeg = 0.0m, bool lConstante = false,
                                                clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null, bool lAplicaNuevoMultirriesgo = true, bool lEsPrePago = false)
        {

            #region Realizando la definición de la tabla de plan de pagos

            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));
            dtPlanPago.Columns.Add("frc", typeof(decimal));
            dtPlanPago.Columns.Add("sal_cap", typeof(decimal));
            dtPlanPago.Columns.Add("capital", typeof(decimal));
            dtPlanPago.Columns.Add("interes", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones_sinSeg", typeof(decimal));
            dtPlanPago.Columns.Add("itf", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));
            dtPlanPago.Columns.Add("nIdSolicitud", typeof(int));

            #endregion

            clsCreditoGasto creditoGasto = new clsCreditoGasto
            {
                Id = nNumsolicitud,
                nNumCuotas = 0,
                dFechaDesembolso = dFecDesemb,
                nMontoDesembolso = nMonCuota,
                nCapitalMaxCobSeg = nCapitalMaxCobSeg
            };

            clsCNCargaGastosCred objCargaGastosCred = new clsCNCargaGastosCred(dtGastosParam, creditoGasto);
            ObjCargaGastosCred = objCargaGastosCred;

            nMonCuota = Math.Round(nMonCuota, nDecRedonCalcPpg);
            int nDiaAcumul = 0;
            int idCuotaIni = 1;
            decimal nValorSegurosOptativos = 0;
            objCargaGastosCred.iniciaDTSegurosOptativos();

            if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
            {
                //Obtengo la lista de todos los planes que se pueden vender segun el perfil y la agencia
                lstPlanesSegurosPermitidos = new clsCNPaqueteSeguro().CNObtenerPaqueteSeguroVenta(0, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            }

            do
            {
                DataRow drCuota = dtPlanPago.NewRow();

                drCuota["cuota"] = idCuotaIni;
                drCuota["imp_cuota"] = 0;

                DataRow drCuotaAnt = dtPlanPago.AsEnumerable().FirstOrDefault(x => x.Field<int>("cuota") == idCuotaIni - 1);

                if (idCuotaIni == 1)
                {
                    drCuota["fecha"] = dFecPriCuota;
                    drCuota["dias"] = (dFecPriCuota - dFecDesemb).Days;
                }
                else
                {
                    if (drCuotaAnt == null)
                        break;

                    DateTime dFecha = clsVarGlobal.dFecSystem.Date;
                    if (nTipPerPag == 1)
                    {
                        dFecha = GetValidDate(drCuotaAnt.Field<DateTime>("fecha").AddMonths(1), nDiaFecPag);
                        drCuota["fecha"] = dFecha;
                        drCuota["dias"] = (dFecha.Date - drCuotaAnt.Field<DateTime>("fecha").Date).Days;
                    }
                    else
                    {
                        dFecha = drCuotaAnt.Field<DateTime>("fecha").Date.AddDays(nDiaFecPag);
                        drCuota["fecha"] = dFecha;
                        drCuota["dias"] = nDiaFecPag;
                    }
                }
                nDiaAcumul += drCuota.Field<int>("dias");
                drCuota["dias_acu"] = nDiaAcumul;

                decimal nInteres = CalcularInteres(nSaldoCapital, nTasa, drCuota.Field<int>("dias"));
                drCuota["sal_cap"] = nSaldoCapital;
                drCuota["interes"] = nInteres;

                objCargaGastosCred.CargarGastoCuotaConstantes(drCuota, drCuotaAnt);

                if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                {
                    objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, drCuota, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos, lEsPrePago);
                    nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                        .Cast<DataRow>()
                        .Where(x => x.Field<int>("idcuota") == idCuotaIni)
                        .Sum(x => x.Field<decimal>("nGasto"));
                }

                decimal nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaIni).Sum(x => x.nGasto) + nValorSegurosOptativos;

                decimal nCapital = nMonCuota - nInteres - nOtrosCuota;

                if (nCapital >= nSaldoCapital)
                {
                    creditoGasto.nNumCuotas = idCuotaIni;
                    nCapital = nSaldoCapital;
                }

                drCuota["capital"] = nCapital;

                objCargaGastosCred.CargarGastoCuotaNoConstantes(null, null);
                nOtrosCuota = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaIni).Sum(x => x.nGasto);

                drCuota["comisiones"] = nOtrosCuota + nValorSegurosOptativos;

                nSaldoCapital = nSaldoCapital - nCapital;

                dtPlanPago.Rows.Add(drCuota);
                idCuotaIni++;

            } while (nSaldoCapital > 0.00m);

            dtGastos = objCargaGastosCred.dtGastos.Copy();

            return dtPlanPago;
        }

        public DataTable RetornarDetalleCargaGasto(string ppgXML)
        {
            return objPlanPago.ADListarDetalleCargaGastoCobroCredito(ppgXML);
        }

        /// <summary>
        /// Realiza la distribuión de los gasto de acuerdo a un plan de pagos ya distribuido.
        /// </summary>
        /// <param name="dtPlanPago">Plan de pagos distribuido</param>
        /// <returns></returns>
        public DataTable DistribuirGastosPagados(DataTable dtPlanPago)
        {
            var cuotasGastosPagados = dtPlanPago.AsEnumerable().Where(x => x.Field<decimal>("nOtrosPagado") > 0);
            DataTable dtPlanPagosOtros = cuotasGastosPagados.Any() ? cuotasGastosPagados.CopyToDataTable() : dtPlanPago.Clone();

            DataSet ds = new DataSet("dsPlanPagos");

            dtPlanPagosOtros.TableName = "dtPlanPagos";
            ds.Tables.Add(dtPlanPagosOtros);

            string xmlPpg = ds.GetXml();

            ds.Tables.Clear();

            //Recuperar el detalle Carga Gastos  para las cuotas que se han pagado
            DataTable dtAuxDetalleCargaGasto = RetornarDetalleCargaGasto(xmlPpg);
            DataTable dtDetalleCargaGasto = dtAuxDetalleCargaGasto.Clone();

            if (dtAuxDetalleCargaGasto.Rows.Count > 0) //Existe Otros Gastos
            {
                //ACTUALIZAR
                foreach (DataRow cuota in dtPlanPagosOtros.Rows)
                {
                    decimal nTemporal = Convert.ToDecimal(cuota["nOtrosPagado"]);

                    foreach (DataRow gasto in dtAuxDetalleCargaGasto.Rows)
                    {
                        decimal nGasto = Convert.ToDecimal(gasto["nGasto"]);
                        decimal nGastoPag = Convert.ToDecimal(gasto["nGastoPag"]);

                        if (Convert.ToInt32(cuota["idCuota"]) != Convert.ToInt32(gasto["nIdNumCuota"]))
                            continue;

                        if (nGasto - nGastoPag == 0)
                            continue;

                        if (nTemporal < (nGasto - nGastoPag))
                        {
                            DataRow dr = dtDetalleCargaGasto.NewRow();
                            dr["idCargaGasto"] = gasto["idCargaGasto"];
                            dr["nidNumCuenta"] = gasto["nidNumCuenta"];
                            dr["idPlanPagos"] = gasto["idPlanPagos"];
                            dr["nIdNumCuota"] = gasto["nIdNumCuota"];
                            dr["nGasto"] = gasto["nGasto"];
                            dr["nGastoPag"] = nTemporal;
                            dr["idAplicaConc"] = gasto["idAplicaConc"];
                            dr["lVigente"] = gasto["lVigente"];
                            dtDetalleCargaGasto.Rows.Add(dr);
                            break;
                        }
                        else
                        {
                            decimal nSaldoGasto = nGasto - nGastoPag;
                            nTemporal = nTemporal - nSaldoGasto;

                            DataRow dr = dtDetalleCargaGasto.NewRow();
                            dr["idCargaGasto"] = gasto["idCargaGasto"];
                            dr["nidNumCuenta"] = gasto["nidNumCuenta"];
                            dr["idPlanPagos"] = gasto["idPlanPagos"];
                            dr["nIdNumCuota"] = gasto["nIdNumCuota"];
                            dr["nGasto"] = gasto["nGasto"];
                            dr["nGastoPag"] = nSaldoGasto;
                            dr["idAplicaConc"] = gasto["idAplicaConc"];
                            dr["lVigente"] = gasto["lVigente"];
                            dtDetalleCargaGasto.Rows.Add(dr);
                        }
                    }
                }
            }
            dtDetalleCargaGasto.Columns.Add(new DataColumn("dFechaPago"));  //GFernandez: Agregado para la carga de gastos de fecha valor, no existe en BD pero se mapeará por idCuota.
            return dtDetalleCargaGasto;
        }

        public DataTable FormarTablaDetalleGastos(DataTable dtAuxConfigGastos, Int32 nNumCuotasPPG, Int32 nIdSolicitud)
        {
            DataTable dtDetalleGastosSolicitud = null;
            dtDetalleGastosSolicitud = new DataTable("TablaDetalleGastosSolicitud");

            dtDetalleGastosSolicitud.Columns.Add("idSolicitud", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("idPlanPagos", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("idCuota", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("nGasto", typeof(decimal));
            dtDetalleGastosSolicitud.Columns.Add("nValor", typeof(decimal));
            dtDetalleGastosSolicitud.Columns.Add("idTipoGasto", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("idTipoValor", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("idAplicaConc", typeof(int));
            dtDetalleGastosSolicitud.Columns.Add("lVigente", typeof(bool));

            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("PRIMERA CUOTA"))
                {
                    DataRow dr = dtDetalleGastosSolicitud.NewRow();
                    dr["idSolicitud"] = nIdSolicitud;
                    dr["idPlanPagos"] = 1;
                    dr["idCuota"] = 1;
                    dr["nGasto"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nGasto"]);
                    dr["nValor"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nValor"]);
                    dr["idTipoGasto"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoGasto"]);
                    dr["idTipoValor"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoValor"]);
                    dr["idAplicaConc"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdAplicaConcepto"]);
                    dr["lVigente"] = true;
                    dtDetalleGastosSolicitud.Rows.Add(dr);
                }
                if (dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("ULTIMA CUOTA"))
                {
                    DataRow dr = dtDetalleGastosSolicitud.NewRow();
                    dr["idSolicitud"] = nIdSolicitud;
                    dr["idPlanPagos"] = 1;
                    dr["idCuota"] = nNumCuotasPPG;
                    dr["nGasto"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nGasto"]);
                    dr["nValor"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nValor"]);
                    dr["idTipoGasto"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoGasto"]);
                    dr["idTipoValor"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoValor"]);
                    //dr["idAplicaConc"] = Convert.ToInt32(dtAuxConfigGastos.Rows[nNumCuotasPPG - 1]["nIdAplicaConcepto"]);
                    dr["idAplicaConc"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdAplicaConcepto"]);
                    dr["lVigente"] = true;
                    dtDetalleGastosSolicitud.Rows.Add(dr);
                }
                if (dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                {
                    for (int j = 0; j < nNumCuotasPPG; j++)
                    {
                        DataRow dr = dtDetalleGastosSolicitud.NewRow();
                        dr["idSolicitud"] = nIdSolicitud;
                        dr["idPlanPagos"] = 1;
                        dr["idCuota"] = (j + 1);
                        dr["nGasto"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nGasto"]);
                        dr["nValor"] = Convert.ToDecimal(dtAuxConfigGastos.Rows[i]["nValor"]);
                        dr["idTipoGasto"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoGasto"]);
                        dr["idTipoValor"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdTipoValor"]);
                        dr["idAplicaConc"] = Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nIdAplicaConcepto"]);
                        dr["lVigente"] = true;
                        dtDetalleGastosSolicitud.Rows.Add(dr);
                    }
                }
            }
            return dtDetalleGastosSolicitud;
        }

        public decimal CalculaTEA(decimal nTasaMensual)
        {
            return Convert.ToDecimal(Math.Pow((1.0 + Convert.ToDouble(nTasaMensual) / 100.0), (360.0 / 30.0)) - 1) * 100.00M;
        }

        public double CalculaTEA(double nTasaMensual)
        {
            return Convert.ToDouble(Math.Pow((1.0 + nTasaMensual / 100.0), (360.0 / 30.0)) - 1) * 100.00;
        }

        public DataTable retornarCuotasDobles(DataTable dtModificaciones, DateTime dFecDesembolso, int nNumCuotas)
        {
            DataTable dtCuotasDobles = new DataTable();
            dtCuotasDobles.Columns.Add("nMes", typeof(int));
            dtCuotasDobles.Columns.Add("nAnio", typeof(int));
            dtCuotasDobles.Columns.Add("nDia", typeof(int));
            dtCuotasDobles.Columns.Add("lEstado", typeof(bool));

            foreach (DataRow item in dtModificaciones.AsEnumerable()
                                                        .Where(x => x.Field<int>("idTipoAccion") == 3).ToList())
            {
                bool lIndIndTodAnios = (bool)item["lIndTodAnios"];
                DataRow drCuotaDoble;
                if (!lIndIndTodAnios)
                {
                    drCuotaDoble = dtCuotasDobles.NewRow();

                    drCuotaDoble["nAnio"] = (int)item["nAnio"];
                    drCuotaDoble["nMes"] = (int)item["nMes"];
                    drCuotaDoble["lEstado"] = true;
                    drCuotaDoble["nDia"] = (int)item["nDia"];

                    dtCuotasDobles.Rows.Add(drCuotaDoble);
                }
                else
                {
                    int nAnio = dFecDesembolso.Year;
                    if ((int)item["nMes"] < dFecDesembolso.Month)
                    {
                        nAnio = nAnio + 1;
                    }

                    List<DateTime> lisFechas = new List<DateTime>();
                    for (int g = 0; g < nNumCuotas; g++)
                    {
                        lisFechas.Add(dFecDesembolso.AddMonths(g + 1));
                    }
                    var nTotCuoDobles = lisFechas.Count(x => x.Month == (int)item["nMes"]);

                    for (int i = 0; i < nTotCuoDobles; i++)
                    {
                        drCuotaDoble = dtCuotasDobles.NewRow();
                        drCuotaDoble["nAnio"] = nAnio;
                        drCuotaDoble["nMes"] = (int)item["nMes"];
                        drCuotaDoble["lEstado"] = true;
                        dtCuotasDobles.Rows.Add(drCuotaDoble);
                        nAnio++;
                    }
                }
            }

            return dtCuotasDobles;
        }

        /// <summary>
        /// Solicitar Autorización para Cambio orden Prelación
        /// </summary>
        /// <param name="xmlSolicitudOrdenPrelac"></param>
        /// <param name="xmlConcepto"></param>
        /// <param name="idAgencia"></param>
        /// <param name="idCliente"></param>
        /// <param name="EstOper"></param>
        /// <param name="idMoneda"></param>
        /// <param name="idProducto"></param>
        /// <param name="Monto"></param>
        /// <param name="nNumCredito"></param>
        /// <param name="FecSolic"></param>
        /// <param name="idMotivo"></param>
        /// <param name="sustento"></param>
        /// <param name="idEstSolic"></param>
        /// <param name="FecAprob"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DataTable SolicitarAutorizOrdenPrelac(string xmlSolicitudOrdenPrelac, string xmlConcepto,
                           int idAgencia, int idCliente, int EstOper,
                           int idMoneda, int idProducto, decimal Monto, int nNumCredito,
                           DateTime FecSolic, int idMotivo, string sustento, int idEstSolic,
                           DateTime FecAprob, int idUsuario)
        {
            return objPlanPago.SolicitarAutorizOrdenPrelac(xmlSolicitudOrdenPrelac, xmlConcepto,
                                   idAgencia, idCliente, EstOper,
                                   idMoneda, idProducto, Monto, nNumCredito,
                                   FecSolic, idMotivo, sustento, idEstSolic,
                                   FecAprob, idUsuario);
        }

        /// <summary>
        /// Buscar las solicitudes de Cambio de orden Prelación
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <param name="idCliente"></param>
        /// <param name="idMoneda"></param>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public DataSet BuscarSolicitudAutorizOrdenPrelac(int idCuenta, int idCliente, int idMoneda, int idProducto)
        {
            return objPlanPago.ADBuscarSolicitudAutorizOrdenPrelac(idCuenta, idCliente, idMoneda, idProducto);
        }

        /// <summary>
        /// Actualizar Estado Solicitud Aprobacón - Solicitud Autorización
        /// </summary>
        /// <param name="idSolicitudAutorizacOrdenPrelac"></param>
        /// <param name="idSolicitudAprobacOrdenPrelac"></param>
        /// <returns></returns>
        public DataTable ActualizarEstadoSolicitudAprobac(int idSolicitudAutorizacOrdenPrelac, int idSolicitudAprobacOrdenPrelac)
        {
            return objPlanPago.ADActualizarEstadoSolicitudAprobac(idSolicitudAutorizacOrdenPrelac, idSolicitudAprobacOrdenPrelac);
        }

        public DataTable CNListarModificacionesSolicitud(int idCuenta)
        {
            return objPlanPago.ADListarModificacionesSolicitud(idCuenta);
        }

        public DataTable CalcularCuotaBalon(DataTable dtCalendarioPagos, DataRow drModifica, DateTime dFecDesemboslo,
        short nTipPerPag, int nPlazo, decimal nTasa, DataTable dtCargaGastos, int idMoneda, DataTable dtCuotasDobles, bool lMantieneCuotaCtes,
        clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro, decimal nMontoMaxCobSeg = 0)
        {
            #region CUOTA BALON

            int nDiaFecPag = nPlazo;
            DataTable dtAux = dtCalendarioPagos.Clone();
            int idcuota = (int)drModifica["nCuota"];
            int idIndex = idcuota - 1;
            var drCuotaAnt = idIndex == 0 ? dtCalendarioPagos.Rows[idIndex] : dtCalendarioPagos.Rows[idIndex - 1];

            DataRow drCuotaBalon = dtCalendarioPagos.Rows[idIndex];
            DataRow drCuotaNext = dtCalendarioPagos.Rows[idIndex + 1];

            decimal nCuota = nMontoCuota == 0 ? (decimal)drCuotaAnt["imp_cuota"] : nMontoCuota;

            var dFecDesemb = idIndex == 0 ? dFecDesemboslo : (DateTime)drCuotaAnt["fecha"];
            decimal nSaldoCapital = (decimal)drCuotaBalon["sal_cap"];
            int nCuotaMax = dtCalendarioPagos.AsEnumerable().Max(x => (int)x["cuota"]);
            int nNumCuoCta = nCuotaMax - idcuota;

            int nDiaGraCta;
            if (idIndex == 0)
            {
                nDiaGraCta = ((DateTime)drCuotaNext["fecha"] - dFecDesemboslo).Days;
            }
            else
            {
                nDiaGraCta = ((DateTime)drCuotaNext["fecha"] - (DateTime)drCuotaAnt["fecha"]).Days;

            }

            if (nTipPerPag == 2)
            {
                nDiaGraCta = nPlazo;
            }
            DateTime dFecPrimeraCuota = drCuotaNext.Field<DateTime>("fecha");

            ReprocesarCalendarioCuotaBalon(nCuota, dtAux, idIndex, nSaldoCapital, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag,
             dtCalendarioPagos, dtCargaGastos, idMoneda, dtCuotasDobles, dFecPrimeraCuota, objSolicitudCreditoCargaSeguro, lMantieneCuotaCtes, nMontoMaxCobSeg);

            #endregion

            return dtCalendarioPagos;
        }

        private void ReprocesarCalendarioCuotaBalon(decimal nCuota, DataTable dtAux, int idIndex, decimal nSaldoCapital,
            decimal nTasa, DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, Int16 nTipPerPag, int nDiaFecPag,
            DataTable dtCalendarioPagos, DataTable dtCargaGastos, int idMoneda, DataTable dtCuotasDobles,
            DateTime dFecPricuota, clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro, bool lMantieneCuotaCtes, decimal nMontoMaxCobSeg = 0)
        {
            //var dFecPricuota = dFecDesemb.AddDays(nDiaGraCta);
            clsCNPlanPago objCnPlanPago = new clsCNPlanPago();
            int idCuotaMod = dtCalendarioPagos.Rows[idIndex].Field<int>("cuota");
            int idSolicitud = dtCalendarioPagos.Rows[0].Field<int>("nIdSolicitud");
            var enumGastosAnt = dtGastos.AsEnumerable().Where(x => x.Field<int>("idCuota") < idCuotaMod);

            int nNroCuotasGracia = 0;
            decimal _nCuota = 0;
            bool lAplicaNuevoMultirriesgo = true;

            DateTime dFechaDesemOri = objSolicitudCreditoCargaSeguro.dFechaDesembolso;
            DateTime dFechaPriCuoOri = objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota;

            objSolicitudCreditoCargaSeguro.dFechaDesembolso = dFecDesemb;
            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = dFecPricuota;

            var dtNuevoPlan = objCnPlanPago.CalculaPpgCuotasConstantes2(nSaldoCapital, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta,
            nTipPerPag, nDiaFecPag, idSolicitud, dtCargaGastos, idMoneda,dtCuotasDobles, dFecPricuota, nCuota, nMontoMaxCobSeg, 
            nNroCuotasGracia, lMantieneCuotaCtes, _nCuota, objSolicitudCreditoCargaSeguro, lAplicaNuevoMultirriesgo);

            objSolicitudCreditoCargaSeguro.dFechaDesembolso = dFechaDesemOri;
            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = dFechaPriCuoOri;

            ObjCargaGastosCred = objCnPlanPago.ObjCargaGastosCred;

            dtNuevoPlan.AsEnumerable().ToList().ForEach(x => x["cuota"] = (int)x["cuota"] + idIndex);
            dtGastos = objCnPlanPago.dtGastos;
            dtGastos.AsEnumerable().ToList().ForEach(x => x["idcuota"] = (int)x["idcuota"] + idIndex);

            var enumGastosFinal = enumGastosAnt.Union(dtGastos.AsEnumerable()).ToList();

            if (enumGastosFinal.Any())
            {
                dtGastos = enumGastosFinal.CopyToDataTable();
            }

            for (int k = 0; k < dtCalendarioPagos.Rows.Count - 1; k++)
            {
                dtAux.ImportRow(k < idIndex ? dtCalendarioPagos.Rows[k] : dtNuevoPlan.Rows[k - idIndex]);
            }

            dtCalendarioPagos.Rows.Clear();

            foreach (DataRow item in dtAux.Rows)
            {
                dtCalendarioPagos.ImportRow(item);
            }
        }

        public DataTable CalcularJuntarCuotas(DataTable dtCalendarioPagos, DataRow drModifica, decimal nTasa, DataTable dtConfigGasto,
                                                decimal nMonDesemb, DateTime dFecDesemb, decimal nCapitalMaxCobSegDes, 
                                                clsSolicitudCreditoCargaSeguro objSolCargaSeguros, bool lAplicaNuevoMultirriesgo = true)
        {
            #region JUNTAR CUOTAS

            int idcuotaJunta = (int)drModifica["nCuota"];
            int idIndexJunta = idcuotaJunta - 1;

            DataRow drCuotaJunta = dtCalendarioPagos.Rows[idIndexJunta];
            DataRow drCuoJuntaNext = dtCalendarioPagos.Rows[idIndexJunta + 1];

            drCuoJuntaNext["sal_cap"] = (decimal) drCuotaJunta["sal_cap"];
            drCuoJuntaNext["dias"] = (int) drCuotaJunta["dias"] + (int) drCuoJuntaNext["dias"];
            drCuoJuntaNext["interes"] = CalcularInteres(Convert.ToDecimal(drCuoJuntaNext["sal_cap"]), nTasa,
                                                        Convert.ToInt32(drCuoJuntaNext["dias"]));
            drCuoJuntaNext["comisiones"] = 0m;
            drCuoJuntaNext["imp_cuota"] = (decimal) drCuotaJunta["imp_cuota"] + (decimal) drCuoJuntaNext["imp_cuota"];
            drCuoJuntaNext["capital"] = (decimal) drCuoJuntaNext["imp_cuota"] - (decimal) drCuoJuntaNext["interes"] -
                                        (decimal) drCuoJuntaNext["comisiones"];

            dtCalendarioPagos.Rows.Remove(drCuotaJunta);

            for (int l = 0; l < dtCalendarioPagos.Rows.Count; l++)
            {
                dtCalendarioPagos.Rows[l]["cuota"] = l + 1;
            }

            RecalcularCronogramaPagos(dtCalendarioPagos, idcuotaJunta, nTasa, dtConfigGasto,
                                       nMonDesemb, dFecDesemb, nCapitalMaxCobSegDes, objSolCargaSeguros, lAplicaNuevoMultirriesgo);

            #endregion

            return dtCalendarioPagos;
        }

        public DataTable CalcularModificarCuota(DataTable dtCalendarioPagos, DataRow drModifica, DateTime dFecDesemboslo,
            short nTipPerPag, int nPlazo, decimal nTasa, DataTable dtCargaGastos, int idMoneda, DataTable dtCuotasDobles,
            bool lMantieneCuotaCtes, decimal nMontoMaxCobSeg = 0)
        {
            #region MODIFICAR CUOTA

            int nDiaFecPag = nPlazo;
            DataTable dtAux4 = dtCalendarioPagos.Clone();
            DataRow drModifica4 = drModifica;
            int idcuota4 = (int)drModifica4["nCuota"];
            int idIndex4 = idcuota4 - 1;
            decimal nMontoModifica = (decimal)drModifica4["nMonto"];

            DataRow drCuotaModifica = dtCalendarioPagos.Rows[idIndex4];
            decimal nCuota4 = Convert.ToDecimal(drCuotaModifica["imp_cuota"]);

            DateTime dFecDesemb4 = Convert.ToDateTime(drCuotaModifica["fecha"]);
            int nNumCuoCta4 = dtCalendarioPagos.Rows.Count - idcuota4;
            var nItfModificaCuota = cnFuncionesUtiles.truncar(((nMontoModifica) * Convert.ToDecimal(clsVarGlobal.nITF) / 100.00m), 2, idMoneda);

            drCuotaModifica["itf"] = 0;
            drCuotaModifica["imp_cuota"] = nMontoModifica;

            dtCalendarioPagos.AsEnumerable().ToList().ForEach(x => x["capital"] = (decimal)x["imp_cuota"] -
                                                                                  (decimal)x["interes"] -
                                                                                  (decimal)x["comisiones"]);
            int nNumCuotas = dtCalendarioPagos.Rows.Count;

            for (int j = 1; j < nNumCuotas; j++)
            {
                dtCalendarioPagos.Rows[j]["sal_cap"] = (decimal)dtCalendarioPagos.Rows[j - 1]["sal_cap"] - (decimal)dtCalendarioPagos.Rows[j - 1]["capital"];
            }
            dtCalendarioPagos.Rows[nNumCuotas - 1]["capital"] = (decimal)dtCalendarioPagos.Rows[nNumCuotas - 1]["sal_cap"];
            dtCalendarioPagos.Rows[nNumCuotas - 1]["imp_cuota"] = (decimal)dtCalendarioPagos.Rows[nNumCuotas - 1]["capital"] +
                                                                  (decimal)dtCalendarioPagos.Rows[nNumCuotas - 1]["interes"] +
                                                                  (decimal)dtCalendarioPagos.Rows[nNumCuotas - 1]["comisiones"];

            decimal nSaldoCapital4 = Convert.ToDecimal(dtCalendarioPagos.Rows[idIndex4 + 1]["sal_cap"]);
            decimal nSaldoCapitalVal = Convert.ToDecimal(dtCalendarioPagos.Rows[idIndex4]["sal_cap"]);

            var nExisteNega = dtCalendarioPagos.AsEnumerable().Count(z => (decimal)z["imp_cuota"] <= 0M);
            //recalculo de cronograma

            if (nMontoModifica > nSaldoCapitalVal && nExisteNega > 1)
            {
                return null;
            }

            ReprocesarCalendarioModificarCuota(nCuota4, dtAux4, idIndex4 + 1, nSaldoCapital4, nTasa, dFecDesemb4, nNumCuoCta4, 0, nTipPerPag, nDiaFecPag,
                dtCalendarioPagos, dtCargaGastos, idMoneda, new DataTable(), lMantieneCuotaCtes, nMontoMaxCobSeg);

            for (int k = 0; k < dtCalendarioPagos.Rows.Count; k++)
            {
                dtCalendarioPagos.Rows[k]["cuota"] = k + 1;
            }

            #endregion

            return dtCalendarioPagos;
        }

        /// <summary>
        /// Recalcula el cronograma de pagos para modificación de cuota
        /// </summary>
        /// <param name="dtCalendarioPagos">Calendario a recalcular</param>
        /// <param name="drModifica">Cuota a modificar</param>
        /// <param name="nMonDesemb">Monto desembolsado</param>
        /// <param name="nTasa">Tasa efectiva anual o mensual, de acuerdo a la variable de la base de datos</param>
        /// <param name="dFecDesemb">Fecha de desembolso</param>
        /// <param name="dtCargaGastos">Tabla de carga de gastos</param>
        /// <param name="nNuevoMonCuo">Monto de la nueva cuota</param>
        /// <param name="nCapitalMaxCobSegDes">Monto máximo de cobertura</param>
        /// <returns></returns>
        public DataTable RecalcModificarCuota(DataTable dtCalendarioPagos, DataRow drModifica, decimal nMonDesemb,
                                            decimal nTasa, DateTime dFecDesemb, DataTable dtCargaGastos,
                                            decimal nNuevoMonCuo, decimal nCapitalMaxCobSegDes,
                                            clsSolicitudCreditoCargaSeguro objSolCargaSeguros, bool lAplicaNuevoMultirriesgo = true)
        {
            #region Realizando el cálculo de la tasa efectiva diaria

            int idCuotaMod = (int) drModifica["nCuota"];
            decimal nMontoCuotaMod = (decimal) drModifica["nMonto"];
            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];

            double nTasEfeDia = 0.00;

            switch (nFormaCalculoTasa)
            {
                case 1:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 360.0)) - 1;
                    //Tasa de interes efectiva diaria TEA
                    break;
                case 2:
                    nTasEfeDia = Math.Pow((1.0 + (double)nTasa), (1.0 / 30.0)) - 1; //Tasa de interes efectiva diaria TEM
                    break;
            }

            #endregion

            #region Calculo de plan de pagos

            decimal nMonSalCap = decimal.Round(nMonDesemb, 2);
            int nNumCuoCta = dtCalendarioPagos.Rows.Count;
            iniciarDTGastos();

            nMontoCuota = nNuevoMonCuo;

            clsCreditoGasto objCreditoGasto = new clsCreditoGasto
            {
                dFechaDesembolso = dFecDesemb,
                nMontoDesembolso = nMonDesemb,
                nNumCuotas = dtCalendarioPagos.Rows.Count,
                nCapitalMaxCobSeg = nCapitalMaxCobSegDes
            };
            clsCNCargaGastosCred objGastosCuenta = new clsCNCargaGastosCred(dtCargaGastos, objCreditoGasto);
            ObjCargaGastosCred = objGastosCuenta;

            decimal nValorSegurosOptativos = 0;
            objGastosCuenta.iniciaDTSegurosOptativos();

            foreach (DataRow row in dtCalendarioPagos.Rows)
            {
                decimal nMonOtros = 0m;

                int idCuota = Convert.ToInt32(row["cuota"]);
                DataRow drCuotaAnt = null;
                if (idCuota > 1)
                {
                    drCuotaAnt = dtCalendarioPagos.Rows[dtCalendarioPagos.Rows.IndexOf(row) - 1];
                }
                int nDiaCuoCta = Convert.ToInt16(row["dias"]);
                decimal nMonIntCuo =
                    decimal.Round((nMonSalCap * (decimal)(Math.Pow(1 + nTasEfeDia, nDiaCuoCta) - 1)), 2);

                row["sal_cap"] = nMonSalCap;
                row["interes"] = nMonIntCuo;
                row["comisiones_sinSeg"] = 0;
                row["itf"] = 0;
                row["imp_cuota"] = idCuota == idCuotaMod ? nMontoCuotaMod : nNuevoMonCuo;

                objGastosCuenta.CargarGastoCuotaConstantes(row, drCuotaAnt);

                if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                {
                    objGastosCuenta.CargarSegurosOptativos(objSolCargaSeguros, row, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos);
                    nValorSegurosOptativos = objGastosCuenta.dtGatosOptativos.Rows
                        .Cast<DataRow>()
                        .Where(x => x.Field<int>("idcuota") == idCuota)
                        .Sum(x => x.Field<decimal>("nGasto"));
                }

                nMonOtros = objGastosCuenta.ListGastos.Where(x => x.idCuota == idCuota)
                                                        .Sum(x => x.nGasto);

                row["comisiones"] = nMonOtros + nValorSegurosOptativos;

                decimal nOtros = Convert.ToDecimal(row["comisiones"]);
                decimal nMonCapCuo = Math.Round((decimal)row["imp_cuota"], nDecRedonCalcPpg) - nMonIntCuo - nOtros;

                row["capital"] = nMonCapCuo;

                objGastosCuenta.CargarGastoCuotaNoConstantes(row, drCuotaAnt);

                nMonOtros = objGastosCuenta.ListGastos.Where(x => x.idCuota == idCuota)
                                                        .Sum(x => x.nGasto);

                row["comisiones"] = nMonOtros + nValorSegurosOptativos;
                row["imp_cuota"] = nMonCapCuo + nMonIntCuo + nMonOtros + nValorSegurosOptativos;
                nMonSalCap = nMonSalCap - nMonCapCuo;
            }

            //Ajuste de la última cuota

            int nNumDiaUltCuo = Convert.ToInt16(dtCalendarioPagos.Rows[nNumCuoCta - 1]["dias"]);
            decimal nSaldoCapUltcCuo = Convert.ToDecimal(dtCalendarioPagos.Rows[nNumCuoCta - 1]["sal_cap"]);
            decimal nCapUltCuo = nSaldoCapUltcCuo;
            decimal nMonIntUltCuo = Math.Round(((nSaldoCapUltcCuo * Convert.ToDecimal(Math.Pow((1 + nTasEfeDia), nNumDiaUltCuo))) - nSaldoCapUltcCuo), 2);
            decimal nMonOtrosUltCuo = Convert.ToDecimal(dtCalendarioPagos.Rows[nNumCuoCta - 1]["comisiones"]);
            dtCalendarioPagos.Rows[nNumCuoCta - 1]["capital"] = Math.Round(nCapUltCuo, 2);
            dtCalendarioPagos.Rows[nNumCuoCta - 1]["interes"] = Math.Round(nMonIntUltCuo, 2);
            dtCalendarioPagos.Rows[nNumCuoCta - 1]["imp_cuota"] = Math.Round(nCapUltCuo + nMonIntUltCuo + nMonOtrosUltCuo, 2);

            #endregion

            dtGastos = objGastosCuenta.dtGastos;
            dtCalendarioPagos.AcceptChanges();
            return dtCalendarioPagos;
        }

        private void ReprocesarCalendarioModificarCuota(decimal nCuota, DataTable dtAux, int idIndex, decimal nSaldoCapital, decimal nTasa,
            DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, Int16 nTipPerPag, int nDiaFecPag, DataTable dtCalendarioPagos, DataTable dtCargaGastos,
            int idMoneda, DataTable dtCuotasDobles, bool lMantieneCuotaCtes, decimal nMontoMaxCobSeg = 0)
        {


            var dtNuevoPlan = CalculaPpgCuotasConstantes2(nSaldoCapital, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta,
                                                           nTipPerPag, nDiaFecPag, 1, dtCargaGastos,
                                                           idMoneda, dtCuotasDobles, dFecDesemb.AddMonths(1), nCuota, nMontoMaxCobSeg, 0);

            dtNuevoPlan.AsEnumerable().ToList().ForEach(x => x["cuota"] = (int)x["cuota"] + idIndex);


            nNumCuoCta = dtNuevoPlan.Rows.Count;

            decimal nNueCuota = (decimal)dtNuevoPlan.Rows[nNumCuoCta - 1]["interes"] +
                              (decimal)dtNuevoPlan.Rows[nNumCuoCta - 1]["capital"] +
                              (decimal)dtNuevoPlan.Rows[nNumCuoCta - 1]["comisiones"];


            dtNuevoPlan.Rows[nNumCuoCta - 1]["itf"] = 0;
            dtNuevoPlan.Rows[nNumCuoCta - 1]["imp_cuota"] = nNueCuota;

            for (int k = 0; k < dtCalendarioPagos.Rows.Count - 1; k++)
            {
                if (k < idIndex)
                {
                    dtAux.ImportRow(dtCalendarioPagos.Rows[k]);
                }
            }

            for (int k = 0; k < dtNuevoPlan.Rows.Count; k++)
            {
                dtAux.ImportRow(dtNuevoPlan.Rows[k]);
            }

            for (int j = 1; j < dtAux.Rows.Count; j++)
            {
                dtAux.Rows[j]["dias_acu"] = (int)dtAux.Rows[j - 1]["dias_acu"] + (int)dtAux.Rows[j]["dias"];
            }

            dtCalendarioPagos.Rows.Clear();

            foreach (DataRow item in dtAux.Rows)
            {
                dtCalendarioPagos.ImportRow(item);
            }
        }

        public DataTable CalcularCuotasGracia(DataTable dtCalendarioPagos, decimal nMonDesemb, decimal nTasa, DateTime dFecDesemb, int nDiaGraCta,
            short nTipPerPag, int nDiaFecPag, DataTable dtCargaGastos, int idMoneda, DataTable dtCuotasDobles, DateTime dFecPrimeraCuota, int nNumCuoCta,
            int nCoutasGracia, decimal nMontoMaxCobSeg = 0, clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null)
        {

            #region CUOTAS DE GRACIA

            dtCalendarioPagos = CalculaPpgCuotasConstantes2(nMonDesemb, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag,
                                                    nDiaFecPag, 1, dtCargaGastos, idMoneda, dtCuotasDobles, dFecPrimeraCuota,
                                                    0, nMontoMaxCobSeg, nCoutasGracia, true, 0, objSolCargaSeguros);
            #endregion

            return dtCalendarioPagos;
        }

        public DataTable CalcularCuotasDobles(decimal nMonDesemb, decimal nTasa, DateTime dFecDesemb, int nNumCuoCta,
                                                int nDiaGraCta, short nTipPerPag, int nDiaFecPag, int nNumsolicitud,
                                                DataTable dtConfigGasto, int nIdMoneda, DataTable dtCuotasDobles,
                                                DateTime dFecPrimeraCuota, DataTable dtCalendarioPagos, decimal nCuotaSugerida = 0,
                                                decimal nMontoMaxCobSeg = 0)
        {
            #region CUOTAS DOBLES

            dtCalendarioPagos = CalculaPpgCuotasConstantes2(nMonDesemb, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag,
                                                           nDiaFecPag, nNumsolicitud, dtConfigGasto, nIdMoneda, dtCuotasDobles, dFecPrimeraCuota, 0, nMontoMaxCobSeg, 0, true);

            bool lCuotaMayoCero = true;

            for (int i = 0; i < dtCalendarioPagos.Rows.Count; i++)
            {
                if (nTipPerPag == 1)
                {
                    foreach (DataRow item in dtCuotasDobles.Rows)
                    {
                        if ((int)item["nMes"] == ((DateTime)dtCalendarioPagos.Rows[i]["fecha"]).Month
                            && (int)item["nAnio"] == ((DateTime)dtCalendarioPagos.Rows[i]["fecha"]).Year)
                        {
                            if ((i + 1) < dtCalendarioPagos.Rows.Count)
                            {
                                int idCuota = dtCalendarioPagos.Rows[i].Field<int>("cuota");
                                dtCalendarioPagos.Rows[i]["capital"] = (decimal)dtCalendarioPagos.Rows[i]["capital"] +
                                                                    (decimal)dtCalendarioPagos.Rows[i + 1]["capital"];

                                dtCalendarioPagos.Rows[i]["comisiones"] = (decimal)dtCalendarioPagos.Rows[i]["comisiones"] +
                                                                        (decimal)dtCalendarioPagos.Rows[i + 1]["comisiones"];

                                decimal nNueCuotaDoble = (decimal)dtCalendarioPagos.Rows[i]["imp_cuota"] +
                                                                       (decimal)dtCalendarioPagos.Rows[i + 1]["imp_cuota"];
                                dtCalendarioPagos.Rows[i]["itf"] = 0;
                                dtCalendarioPagos.Rows[i]["imp_cuota"] = nNueCuotaDoble;

                                #region Gastos en cuotas Dobles

                                //decimal nGastosCuota = dtGastos.AsEnumerable()
                                //                            .Where(x => x.Field<int>("cuota") == idCuota)
                                //                            .Sum(x => x.Field<decimal>("nGasto"));
                                //decimal nGastosCuotaDesp = dtGastos.AsEnumerable()
                                //                            .Where(x => x.Field<int>("cuota") == idCuota + 1)
                                //                            .Sum(x => x.Field<decimal>("nGasto"));
                                //dtGastos.Rows[i]["nGasto"] = nGastosCuota + nGastosCuotaDesp;

                                //dtGastos.Rows[i]["nGastoIncSeg"] = 0;

                                #endregion
                            }

                        }
                    }

                }
                else
                {
                    foreach (DataRow item in dtCuotasDobles.Rows)
                    {
                        if ((int)item["nMes"] == ((DateTime)dtCalendarioPagos.Rows[i]["fecha"]).Month
                            && (int)item["nAnio"] == ((DateTime)dtCalendarioPagos.Rows[i]["fecha"]).Year
                            && (int)item["nDia"] == ((DateTime)dtCalendarioPagos.Rows[i]["fecha"]).Day)
                        {
                            if ((i + 1) < dtCalendarioPagos.Rows.Count)
                            {
                                dtCalendarioPagos.Rows[i]["capital"] = (decimal)dtCalendarioPagos.Rows[i]["capital"] +
                                                                    (decimal)dtCalendarioPagos.Rows[i + 1]["capital"];

                                dtCalendarioPagos.Rows[i]["comisiones"] = (decimal)dtCalendarioPagos.Rows[i]["comisiones"] +
                                                                        (decimal)dtCalendarioPagos.Rows[i + 1]["comisiones"];

                                decimal nNueCuotaDoble = (decimal)dtCalendarioPagos.Rows[i]["imp_cuota"] +
                                                                       (decimal)dtCalendarioPagos.Rows[i + 1]["imp_cuota"];
                                dtCalendarioPagos.Rows[i]["itf"] = 0;
                                dtCalendarioPagos.Rows[i]["imp_cuota"] = nNueCuotaDoble;

                                #region Gastos en cuotas Dobles

                                //dtGastos.Rows[i]["nGasto"] = (decimal)dtGastos.Rows[i]["nGasto"] +
                                //                                (decimal)dtGastos.Rows[i + 1]["nGasto"];

                                //dtGastos.Rows[i]["nGastoIncSeg"] = (decimal)dtGastos.Rows[i]["nGastoIncSeg"] +
                                //                                (decimal)dtGastos.Rows[i + 1]["nGastoIncSeg"];

                                #endregion
                            }

                        }
                    }
                }
            }


            while (lCuotaMayoCero)
            {
                var contador = 0;
                int nIndice = 0;
                foreach (DataRow item in dtCalendarioPagos.Rows)
                {
                    if ((decimal)item["interes"] == 0.0m)
                    {
                        dtCalendarioPagos.Rows.Remove(item);
                        //dtGastos.Rows.RemoveAt(nIndice);
                        contador++;
                        break;
                    }
                    nIndice++;
                }


                if (contador == 0)
                {
                    lCuotaMayoCero = false;
                }
            }
            for (int l = 0; l < dtCalendarioPagos.Rows.Count; l++)
            {
                dtCalendarioPagos.Rows[l]["cuota"] = l + 1;
                //dtGastos.Rows[l]["idCuota"] = l + 1;
            }

            #endregion

            return dtCalendarioPagos;
        }

        public DataTable CalcularCuotaLibre(DataTable dtCalendarioPagos, DataRow drModifica, DateTime dFecDesemboslo,
            short nTipPerPag, int nPlazo, decimal nTasa, DataTable dtCargaGastos, int idMoneda, DataTable dtCuotasDobles,
            bool lMantieneCuotaCtes, decimal nCapitalMaxCobSegDes,
            clsSolicitudCreditoCargaSeguro objSolCargaSeguros, bool lAplicaNuevoMultirriesgo = true)
        {
            #region CUOTA LIBRE

            decimal nMontoDesembolsado = dtCalendarioPagos.AsEnumerable()
                                                        .First(x => x.Field<int>("cuota") == 1).Field<decimal>("sal_cap");
            DataTable dtAuxiliar = dtCalendarioPagos.Clone();
            int idCuotaMod = drModifica.Field<int>("nCuota");
            int idIndex = idCuotaMod - 1;

            int idCuotaLibre = Convert.ToInt32(drModifica["idCuotaLibre"]);

            DataRow drCuotaModifica = dtCalendarioPagos.AsEnumerable().First(x => x.Field<int>("cuota") == idCuotaMod);
            DataRow drCuotaAnt = dtCalendarioPagos.AsEnumerable().FirstOrDefault(x => x.Field<int>("cuota") == idCuotaMod - 1);
            DataRow drCuotaLibre = dtCalendarioPagos.AsEnumerable().First(x => x.Field<int>("cuota") == idCuotaMod + 1);

            DateTime dFechaDesembolso = Convert.ToDateTime(drCuotaModifica["fecha"]);
            DateTime dFecPricuota = dFechaDesembolso.AddDays(drCuotaLibre.Field<int>("dias"));
            int nDiasGracia = 0;

            clsCreditoGasto objCredito = new clsCreditoGasto
            {
                dFechaDesembolso = dFechaDesembolso,
                nMontoDesembolso = nMontoDesembolsado,
                nNumCuotas = dtCalendarioPagos.Rows.Count,
                nCapitalMaxCobSeg = nCapitalMaxCobSegDes
            };
            clsCNCargaGastosCred objCargaGastosCred = new clsCNCargaGastosCred(dtCargaGastos, objCredito);
            var gastosTemp = dtGastos.AsEnumerable().Where(x => x.Field<int>("idCuota") < idCuotaMod).ToList();
            decimal nOtros;

            objCargaGastosCred.iniciaDTSegurosOptativos();
            decimal nValorSegurosOptativos = 0;

            iniciarDTGastos();
            switch (idCuotaLibre)
            {
                case 1:
                    //nMontoModifica = (decimal)drCuotaModifica["imp_cuota"];
                    int nDiasCambio = Convert.ToInt32(drModifica["nMonto"]);
                    dFecPricuota = dFechaDesembolso.AddDays(nDiasCambio);
                    if (nTipPerPag == 2)
                    {
                        nDiasGracia = Convert.ToInt32(drModifica["nMonto"]) - nPlazo;
                    }
                    break;
                case 2:
                    objCargaGastosCred.CargarGastoCuotaConstantes(drCuotaModifica, drCuotaAnt);
                    nOtros = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaMod)
                                               .Sum(x => x.nGasto);
                    drCuotaModifica["comisiones"] = nOtros;
                    drCuotaModifica["capital"] = (decimal) drModifica["nMonto"];

                    if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                    {
                        objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, drCuotaModifica, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos);
                        nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                            .Cast<DataRow>()
                            .Where(x => x.Field<int>("idcuota") == idCuotaMod)
                            .Sum(x => x.Field<decimal>("nGasto"));
                    }

                    objCargaGastosCred.CargarGastoCuotaNoConstantes(drCuotaModifica, drCuotaAnt);
                    nOtros = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaMod)
                                               .Sum(x => x.nGasto);

                    drCuotaModifica["comisiones"] = nOtros + nValorSegurosOptativos;
                    drCuotaModifica["imp_cuota"] = (decimal) drCuotaModifica["capital"] +
                                                   (decimal) drCuotaModifica["interes"] +
                                                   (decimal) drCuotaModifica["comisiones"];
                    break;
                default:
                    drCuotaModifica["imp_cuota"] = (decimal) drModifica["nMonto"];
                    objCargaGastosCred.CargarGastoCuotaConstantes(drCuotaModifica, drCuotaAnt);
                    nOtros = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaMod)
                                               .Sum(x => x.nGasto);
                    
                    if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                    {
                        objCargaGastosCred.CargarSegurosOptativos(objSolCargaSeguros, drCuotaModifica, drCuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos);
                        nValorSegurosOptativos = objCargaGastosCred.dtGatosOptativos.Rows
                            .Cast<DataRow>()
                            .Where(x => x.Field<int>("idcuota") == idCuotaMod)
                            .Sum(x => x.Field<decimal>("nGasto"));
                    }

                    drCuotaModifica["comisiones"] = nOtros + nValorSegurosOptativos;

                    drCuotaModifica["capital"] = (decimal) drCuotaModifica["imp_cuota"] -
                                                 (decimal) drCuotaModifica["interes"] -
                                                 (decimal) drCuotaModifica["comisiones"];

                    objCargaGastosCred.CargarGastoCuotaNoConstantes(drCuotaModifica, drCuotaAnt);
                    nOtros = objCargaGastosCred.ListGastos.Where(x => x.idCuota == idCuotaMod)
                                               .Sum(x => x.nGasto);
                    drCuotaModifica["comisiones"] = nOtros + nValorSegurosOptativos;
                    drCuotaModifica["imp_cuota"] = (decimal) drCuotaModifica["capital"] +
                                                   (decimal) drCuotaModifica["interes"] +
                                                   (decimal) drCuotaModifica["comisiones"];
                    break;
            }
            dtGastos = objCargaGastosCred.dtGastos;
            drCuotaModifica["itf"] = 0;

            drCuotaLibre["sal_cap"] = (decimal)drCuotaModifica["sal_cap"] -
                                              (decimal)drCuotaModifica["capital"];

            decimal nSaldoCapital = Convert.ToDecimal(dtCalendarioPagos.Rows[idIndex + 1]["sal_cap"]);
            decimal nSaldoCapitalVal = Convert.ToDecimal(dtCalendarioPagos.Rows[idIndex]["sal_cap"]);

            var nExisteNega = dtCalendarioPagos.AsEnumerable().Count(z => (decimal)z["imp_cuota"] <= 0M);

            if (drModifica.Field<decimal>("nMonto") > nSaldoCapitalVal && nExisteNega > 1)
                return null;

            var gastosMod = gastosTemp.Union(dtGastos.AsEnumerable()).ToList();

            int nNumCuotaNuevo = dtCalendarioPagos.Rows.Count - idCuotaMod;

            ReprocesarCalendarioCuotaLibre(nMontoCuota, dtAuxiliar, idIndex + 1, nSaldoCapital, nTasa, dFechaDesembolso,
                nNumCuotaNuevo, nDiasGracia, nTipPerPag, nPlazo, dtCalendarioPagos, dtCargaGastos,
                idMoneda, dtCuotasDobles, dFecPricuota, nCapitalMaxCobSegDes, gastosMod, lMantieneCuotaCtes, objSolCargaSeguros, lAplicaNuevoMultirriesgo);

            #endregion

            return dtCalendarioPagos;
        }

        private void ReprocesarCalendarioCuotaLibre(decimal nCuota, DataTable dtAux, int idIndex, decimal nSaldoCapital, decimal nTasa,
            DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, short nTipPerPag, int nDiaFecPag, DataTable dtCalendarioPagos, DataTable dtCargaGastos,
            int idMoneda, DataTable dtCuotasDobles, DateTime dFechaPrimeraCuota, decimal nCapitalMaxCobSegDes,
            IEnumerable<DataRow> gastosMod, bool lMantieneCuotaCtes, clsSolicitudCreditoCargaSeguro objSolCargaSeguros, bool lAplicaNuevoMultirriesgo)
        {
            clsCNPlanPago clsCnPlanPago = new clsCNPlanPago();

            int nCuotasGracia = 0;

            DateTime dFechaDesOri = objSolCargaSeguros.dFechaDesembolso;
            DateTime dFechaPriCuoOri = objSolCargaSeguros.dFechaPrimeraCuota;

            objSolCargaSeguros.dFechaDesembolso = dFecDesemb;
            objSolCargaSeguros.dFechaPrimeraCuota = dFechaPrimeraCuota;

            var dtNuevoPlan = clsCnPlanPago.CalculaPpgCuotasConstantes2(nSaldoCapital, nTasa, dFecDesemb, nNumCuoCta, nDiaGraCta,
                                                        nTipPerPag, nDiaFecPag, 1, dtCargaGastos,
                                                        idMoneda, dtCuotasDobles, dFechaPrimeraCuota, nCuota,
                                                        nCapitalMaxCobSegDes, nCuotasGracia, lMantieneCuotaCtes, 0, objSolCargaSeguros, lAplicaNuevoMultirriesgo);

            objSolCargaSeguros.dFechaDesembolso = dFechaDesOri;
            objSolCargaSeguros.dFechaPrimeraCuota = dFechaPriCuoOri;

            ObjCargaGastosCred = clsCnPlanPago.ObjCargaGastosCred;

            dtGastos = clsCnPlanPago.dtGastos;
            dtNuevoPlan.AsEnumerable().ToList().ForEach(x => x["cuota"] = (int)x["cuota"] + idIndex);
            dtGastos.AsEnumerable().ToList().ForEach(x => x["idcuota"] = (int)x["idcuota"] + idIndex);

            var enumGastosFinal = gastosMod.Union(dtGastos.AsEnumerable()).ToList();

            if (enumGastosFinal.Any())
            {
                dtGastos = enumGastosFinal.CopyToDataTable();
            }

            for (int k = 0; k < dtCalendarioPagos.Rows.Count - 1; k++)
            {
                if (k < idIndex)
                {
                    dtAux.ImportRow(dtCalendarioPagos.Rows[k]);
                }
            }

            for (int k = 0; k < dtNuevoPlan.Rows.Count; k++)
            {
                dtAux.ImportRow(dtNuevoPlan.Rows[k]);
            }

            dtCalendarioPagos.Rows.Clear();

            foreach (DataRow item in dtAux.Rows)
            {
                dtCalendarioPagos.ImportRow(item);
            }
        }

        private decimal CalcularInteres(decimal nMonto, decimal nTasa, int nDiasCuota)
        {
            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
            double ted = Math.Pow((1.0 + (double)nTasa), (1.0 / (nFormaCalculoTasa == 1 ? 360.0 : 30.0))) - 1;

            return Math.Round(nMonto * ((decimal)Math.Pow((1 + ted), nDiasCuota) - 1), 2);
        }

        /// <summary>
        /// Recalcula el cronograma de pagos desde la cuota
        /// </summary>
        /// <param name="dtPlanPagos"></param>
        /// <param name="nCuota"></param>
        private void RecalcularCronogramaPagos(DataTable dtPlanPagos, int nCuota, decimal nTasa, DataTable dtConfigGasto,
                                                decimal nMonDesemb, DateTime dFecDesemb, decimal nCapitalMaxCobSegDes, 
                                                clsSolicitudCreditoCargaSeguro objSolCargaSeguros, bool lAplicaNuevoMultirriesgo)
        {
            clsCreditoGasto objCreditoGasto = new clsCreditoGasto
            {
                dFechaDesembolso = dFecDesemb,
                nMontoDesembolso = nMonDesemb,
                nNumCuotas = dtPlanPagos.Rows.Count,
                nCapitalMaxCobSeg = nCapitalMaxCobSegDes
            };
            clsCNCargaGastosCred objGastosCuenta = new clsCNCargaGastosCred(dtConfigGasto, objCreditoGasto);
            ObjCargaGastosCred = objGastosCuenta;
            var enumGastos = dtGastos.AsEnumerable().Where(x => x.Field<int>("idCuota") < nCuota);
            if (enumGastos.Any())
            {
                dtGastos = enumGastos.CopyToDataTable();
            }
            else
            {
                iniciarDTGastos();
            }

            decimal nValorSegurosOptativos = 0;
            objGastosCuenta.iniciaDTSegurosOptativos();

            foreach (DataRow cuota in dtPlanPagos.AsEnumerable().Where(x => x.Field<int>("cuota") >= nCuota))
            {
                int idCuota = Convert.ToInt32(cuota["cuota"]);
                int nDiaCuoCta = Convert.ToInt32(cuota["dias"]);
                DataRow cuotaAnt = dtPlanPagos.AsEnumerable().FirstOrDefault(x => x.Field<int>("cuota") == idCuota - 1);
                decimal nSaldoCapital = idCuota == 1
                    ? Convert.ToDecimal(cuota["sal_cap"])
                    : Convert.ToDecimal(cuotaAnt["sal_cap"]) - Convert.ToDecimal(cuotaAnt["capital"]);
                decimal nMonCuo = Convert.ToDecimal(cuota["imp_cuota"]);
                decimal nMonIntCuo = CalcularInteres(nSaldoCapital, nTasa, nDiaCuoCta);

                cuota["Itf"] = nCero;
                cuota["sal_cap"] = Math.Round(nSaldoCapital, 2);
                cuota["interes"] = Math.Round(nMonIntCuo, 2);

                objGastosCuenta.CargarGastoCuotaConstantes(cuota, cuotaAnt);

                if (objSolCargaSeguros != null && objSolCargaSeguros.lstSolicitudCreditoSeguro.Exists(x => x.lSeleccionado && x.lPagoCuotas))
                {
                    objGastosCuenta.CargarSegurosOptativos(objSolCargaSeguros, cuota, cuotaAnt, lAplicaNuevoMultirriesgo, lstPlanesSegurosPermitidos);
                    nValorSegurosOptativos = objGastosCuenta.dtGatosOptativos.Rows
                        .Cast<DataRow>()
                        .Where(x => x.Field<int>("idcuota") == idCuota)
                        .Sum(x => x.Field<decimal>("nGasto"));
                }

                decimal nMonOtros = objGastosCuenta.ListGastos.Where(x => x.idCuota == idCuota)
                                                                .Sum(x => x.nGasto);

                decimal nMonCapCuo = nMonCuo - nMonIntCuo - nMonOtros - nValorSegurosOptativos;

                cuota["capital"] = Math.Round(nMonCapCuo, 2);

                objGastosCuenta.CargarGastoCuotaNoConstantes(cuota, cuotaAnt);
                nMonOtros = objGastosCuenta.ListGastos.Where(x => x.idCuota == idCuota)
                                                        .Sum(x => x.nGasto);

                cuota["comisiones"] = nMonOtros + nValorSegurosOptativos;
                cuota["imp_cuota"] = nMonCapCuo + nMonIntCuo + nMonOtros + nValorSegurosOptativos;
            }

            DataRow ultimaCuota = dtPlanPagos.AsEnumerable().Last();
            ultimaCuota["capital"] = ultimaCuota["sal_cap"];
            ultimaCuota["imp_cuota"] = Convert.ToDecimal(ultimaCuota["capital"])
                                        + Convert.ToDecimal(ultimaCuota["interes"])
                                        + Convert.ToDecimal(ultimaCuota["comisiones"]);

            var enumFinal = dtGastos.AsEnumerable().Union(objGastosCuenta.dtGastos.AsEnumerable()).ToList();
            if (enumFinal.Any())
                dtGastos = enumFinal.CopyToDataTable();

        }

        private void cargaGastoDT(ref DataTable dt, int idSolicitud, int idPlanPagos, int idCuota, decimal nGasto, decimal nTasaCalculaTipoGasto, int idTipoGasto, int idTipoValor, int idAplicaConc, bool lVigente, decimal nGastoIncSeg)
        {
            DataRow dr = dt.NewRow();
            dr["idSolicitud"] = idSolicitud;
            dr["idPlanPagos"] = idPlanPagos;
            dr["idCuota"] = idCuota;
            dr["nGasto"] = nGasto;
            dr["nGastoIncSeg"] = nGastoIncSeg;
            dr["nValor"] = nTasaCalculaTipoGasto;
            dr["idTipoGasto"] = idTipoGasto;
            dr["idTipoValor"] = idTipoValor;
            dr["idAplicaConc"] = idAplicaConc;
            dr["lVigente"] = lVigente;
            dt.Rows.Add(dr);
        }

        private int CalcularCierresMes(DateTime dFechaInicio, DateTime dFechaFin)
        {
            DateTime dFechaTemp;
            int nCierres = 0;
            //nCierres 
            dFechaTemp = new DateTime(dFechaInicio.Year, dFechaInicio.Month, DateTime.DaysInMonth(dFechaInicio.Year, dFechaInicio.Month));
            //dFechaTemp = dFechaInicio.AddMonths(1).AddDays(-1*(dFechaInicio.Day));
            //nCierres = ts.TotalDays / 30;
            while (dFechaTemp < dFechaFin)
            {
                dFechaTemp = dFechaTemp.AddDays(1);
                dFechaTemp = new DateTime(dFechaTemp.Year, dFechaTemp.Month, DateTime.DaysInMonth(dFechaTemp.Year, dFechaTemp.Month));
                nCierres++;
            }

            return nCierres;
        }

        public DataTable ObtenerGastos(int idSolicitud)
        {
            foreach (DataRow item in dtGastos.Rows)
            {
                item["idSolicitud"] = idSolicitud;
            }
            return dtGastos;
        }

        public DataTable ObtenerGastosCuenta(int idCuenta)
        {
            foreach (DataRow item in dtGastos.Rows)
            {
                item["idCuenta"] = idCuenta;
            }
            return dtGastos;
        }

        public void iniciarDTGastos()
        {
            dtGastos = null;
            dtGastos = new DataTable("TablaDetalleGastosSolicitud");

            dtGastos.Columns.Add("idSolicitud", typeof(int));
            dtGastos.Columns.Add("idPlanPagos", typeof(int));
            dtGastos.Columns.Add("idCuota", typeof(int));
            dtGastos.Columns.Add("nGasto", typeof(decimal)); // todos los gastos exluyendo a los seguros
            dtGastos.Columns.Add("nGastoIncSeg", typeof(decimal));// solamente tienen valor los gastos de seguro de desgravamen
            dtGastos.Columns.Add("nValor", typeof(decimal));
            dtGastos.Columns.Add("idTipoGasto", typeof(int));
            dtGastos.Columns.Add("idTipoValor", typeof(int));
            dtGastos.Columns.Add("idAplicaConc", typeof(int));
            dtGastos.Columns.Add("lVigente", typeof(bool));
            dtGastos.Columns.Add("idCuenta", typeof(int));
        }

        private DateTime GetValidDate(int anio, int mes, int day)
        {
            DateTime fechaValida;
            while (!DateTime.TryParse(string.Format("{0}/{1}/{2}", anio, mes, day), out fechaValida))
            {
                day--;
            }
            return fechaValida;
        }

        public DataTable AgregarGastosManualesReprogramacion(DataTable dtPlanPagos, DateTime dFechaDesembolso, clsSolicitudReprogramacion objSolicitudReprogramacion, DataTable dtModificaciones)
        {
            var gastosNoManuales = dtGastos.AsEnumerable().Where(x => x.Field<bool>("lCargaManual"));
            if ( gastosNoManuales.Any() )
            {
                dtGastos = gastosNoManuales.CopyToDataTable();
            }
            clsADCargaGastosCred objCargaGastosCred = new clsADCargaGastosCred();
            int idCuenta = ObjCargaGastosCred.GetCreditoGasto().Id;
            DataTable dtGastosManuales = objCargaGastosCred.GetGastosManualesCuenta(objSolicitudReprogramacion.idSolicitudOrigen);
            dtGastosManuales.Columns["lAplicado"].ReadOnly = false;

            var gastosFilter =
                dtGastosManuales.AsEnumerable().Where(x => x.Field<DateTime>("dFechaProg").Date >= dFechaDesembolso);

            dtGastosManuales = gastosFilter.Any() ? gastosFilter.CopyToDataTable() : dtGastosManuales.Clone();

            int nCompensacionEquivalencia = 0;
            if (dtPlanPagos.Rows.Count < objSolicitudReprogramacion.nCuotasDestino)
            {
                if (objSolicitudReprogramacion.idOperacion == (int)OperacionCredito.ReprogramacionCuotaBalon && dtModificaciones.Rows.Count > 0)
                {
                    foreach (DataRow drCuota in dtModificaciones.AsEnumerable())
                    {
                        int idCuotaEquivalente = 0;
                        int idOtraCuotaEquivalente = 0;

                        idCuotaEquivalente = drCuota.Field<int>("nCuota") + objSolicitudReprogramacion.idCuotaOrigen - 1;
                        idOtraCuotaEquivalente = drCuota.Field<int>("nOtraCuota") + objSolicitudReprogramacion.idCuotaOrigen - 1;

                        dtGastosManuales.AsEnumerable().Where(x => x.Field<int>("idCuota") == idCuotaEquivalente).ToList().ForEach(
                            y =>
                            {
                                y["idCuota"] = idOtraCuotaEquivalente;
                                y["idTipoValor"] = (int)TipoValorGasto.Fijo;
                                y["idAplicaConc"] = (int)ConceptoAplicaGasto.MontoPrestamo;
                            });
                    }
                }
                nCompensacionEquivalencia = objSolicitudReprogramacion.nCuotasDestino - dtPlanPagos.Rows.Count - 1;
            }
            else
            {
                nCompensacionEquivalencia = -1;
            }

            foreach (DataRow cuota in dtPlanPagos.Rows)
            {
                int idCuota = cuota.Field<int>("cuota");
                int idCuotaEquivalente = idCuota + objSolicitudReprogramacion.idCuotaOrigen + nCompensacionEquivalencia;
                foreach (DataRow row in dtGastosManuales.AsEnumerable()
                                                         .Where(x => !x.Field<bool>("lAplicado"))
                                                         .ToList())
                {
                    if (row.Field<int>("idCuota") != idCuotaEquivalente)
                        continue;

                    DataRow drGasto = dtGastos.NewRow();

                    int idTipoValor = row.Field<int>("idTipoValor");
                    int idAplicaConc = row.Field<int>("idAplicaConc");
                    decimal nValor = row.Field<decimal>("nValor");
                    decimal nGasto = decimal.Zero;

                    if (idTipoValor.In((int)TipoValorGasto.PorcentualSimple, (int)TipoValorGasto.PorcentualCompuesto))
                    {
                        nGasto = this.calcularCargaGasto(cuota, idTipoValor, idAplicaConc, nValor, objSolicitudReprogramacion.nCapitalAprobado);
                    }
                    else
                    {
                        nGasto = row.Field<decimal>("nGasto");
                    }

                    drGasto["idSolicitud"] = 0;
                    drGasto["idPlanPagos"] = 0;
                    drGasto["idCuota"] = idCuota;
                    drGasto["nGasto"] = nGasto;
                    drGasto["nGastoIncSeg"] = 0;
                    drGasto["nValor"] = nValor;
                    drGasto["idTipoGasto"] = row.Field<int>("nIdTipoGasto");
                    drGasto["idTipoValor"] = idTipoValor;
                    drGasto["idAplicaConc"] = idAplicaConc;
                    drGasto["lVigente"] = 1;
                    drGasto["idCuenta"] = objSolicitudReprogramacion.idCuenta;
                    drGasto["lCargaManual"] = true;
                    drGasto["idCargaGasto"] = 0;
                    dtGastos.Rows.Add(drGasto);

                    row["lAplicado"] = true;
                }
            }


            foreach (DataRow row in dtGastosManuales.AsEnumerable()
                                                     .Where(x => !x.Field<bool>("lAplicado")).ToList())
            {
                DataRow drGasto = dtGastos.NewRow();
                drGasto["idSolicitud"] = 0;
                drGasto["idPlanPagos"] = 0;
                drGasto["idCuota"] = 1;
                drGasto["nGasto"] = row.Field<decimal>("nGasto");
                drGasto["nGastoIncSeg"] = 0;
                drGasto["nValor"] = row.Field<decimal>("nGasto");
                drGasto["idTipoGasto"] = row.Field<int>("nIdTipoGasto");
                drGasto["idTipoValor"] = (int)TipoValorGasto.Fijo;
                drGasto["idAplicaConc"] = (int)ConceptoAplicaGasto.MontoPrestamo;
                drGasto["lVigente"] = 1;
                drGasto["idCuenta"] = objSolicitudReprogramacion.idCuenta;
                drGasto["lCargaManual"] = true;
                drGasto["idCargaGasto"] = 0;
                dtGastos.Rows.Add(drGasto);
            }

            foreach (DataRow cuota in dtPlanPagos.Rows)
            {
                decimal idCuota = cuota.Field<int>("cuota");
                decimal nCapital = cuota.Field<decimal>("capital");
                decimal nInteres = cuota.Field<decimal>("interes");
                decimal nOtros =
                    dtGastos.AsEnumerable()
                            .Where(x => x.Field<int>("idCuota") == idCuota)
                            .Sum(x => x.Field<decimal>("nGasto"));
                cuota["comisiones"] = nOtros;
                cuota["imp_cuota"] = nCapital + nInteres + nOtros;
            }

            return dtPlanPagos;
        }

        private decimal calcularCargaGasto(DataRow drCuota, int idTipoValor, int idAplicaConc, decimal nValor, decimal nCapitalDesembolso)
        {
            decimal nTasaEfectivaDiaria = decimal.Zero;
            decimal nPorcentaje = nValor / 100M;
            decimal nGasto = decimal.Zero;

            if (idTipoValor == (int)TipoValorGasto.PorcentualSimple)
            {
                switch (idAplicaConc)
                {
                    case (int)ConceptoAplicaGasto.Capital:
                        nGasto = Math.Round(nPorcentaje * drCuota.Field<decimal>("capital"), 1);
                        return nGasto;
                    case (int)ConceptoAplicaGasto.CuotaCapitalMasInteres:
                        nGasto = Math.Round(nPorcentaje * (drCuota.Field<decimal>("capital") + drCuota.Field<decimal>("interes")), 1);
                        return nGasto;
                    case (int)ConceptoAplicaGasto.MontoPrestamo:
                        nGasto = Math.Round(nPorcentaje * nCapitalDesembolso, 1);
                        return nGasto;
                    case (int)ConceptoAplicaGasto.SaldoCapital:
                        nTasaEfectivaDiaria = nPorcentaje / 30M;
                        nGasto = Math.Round(drCuota.Field<decimal>("sal_cap") * nTasaEfectivaDiaria * drCuota.Field<int>("dias"), 1);
                        return nGasto;
                    default:
                        return nValor;
                }
            }
            else if (idTipoValor == (int)TipoValorGasto.PorcentualCompuesto)
            {
                switch (idAplicaConc)
                {
                    case (int)ConceptoAplicaGasto.SaldoCapital:
                        nTasaEfectivaDiaria = (decimal)(Math.Pow(1.0 + (double)nPorcentaje, (1.0 / 30.0))) - 1;
                        nGasto = Math.Round((drCuota.Field<decimal>("sal_cap") *
                            (decimal)(Math.Pow((1.0 + (double)nTasaEfectivaDiaria), drCuota.Field<int>("dias"))) - drCuota.Field<decimal>("sal_cap")), 1);
                        return nGasto;
                    default:
                        return nValor;
                }
            }
            else
            {
                return nValor;
            }
        }
        public clsPlanPago PlanPagosFinalReprogramacion(clsPlanPago objPlanPagos, DataTable dtPlanPagosPropuesto, DateTime dFechaUltPago, decimal nTasa, DataTable _dtConfigGastos)
        {
            // Convierto las filas filtradas a una lista
            List<clsOtrosGastos> listaFiltradaSeguros = _dtConfigGastos.AsEnumerable()
                .Where(fila => fila.Field<int>("idTipoGasto") != 10)    //Sin contar desgravamen porque se carga mensualmente.
                .Select(row => new clsOtrosGastos
                {
                    idCuota = Convert.ToInt32(row["idCuota"]),
                    idTipoGasto = Convert.ToInt32(row["idTipoGasto"]),
                    nGasto = Convert.ToDecimal(row["nGasto"])
                }).ToList();

            List<clsCuota> lstCuotasPagadas = objPlanPagos.Where(x => x.idEstadocuota == 2).ToList();
            List<clsCuota> lstCuotasPendientes = objPlanPagos.Where(x => x.idEstadocuota == 1).ToList();
            clsCuota objCuotaMasProxima = lstCuotasPendientes.OrderBy(x => x.dFechaProg).First();

            int nDiferenciaCuota = objCuotaMasProxima.idCuota;

            if (listaFiltradaSeguros.Any())  // Verificar si la lista tiene elementos
            {
                nDiferenciaCuota = objCuotaMasProxima.idCuota - listaFiltradaSeguros.First().idCuota;
                listaFiltradaSeguros.ForEach(x => x.idCuota += nDiferenciaCuota);
            }

            clsPlanPago objPlanPagosNuevo = ConvertToPlanPagos(dtPlanPagosPropuesto, objCuotaMasProxima.idCuota, objCuotaMasProxima.idTipoCuota,
                                                            objCuotaMasProxima.idCuenta);

            decimal nCapitalPag = lstCuotasPendientes.Sum(x => x.nCapitalPagado);
            decimal nIntPag = lstCuotasPendientes.Sum(x => x.nInteresPagado);
            decimal nIntFecha = lstCuotasPendientes.Sum(x => x.nInteresFecha);
            decimal nOtrosPagado = lstCuotasPendientes.Sum(x => x.nOtrosPagado);

            foreach (clsCuota objCuota in objPlanPagosNuevo)
            {
                if (objCuota.nCapital < decimal.Zero || nCapitalPag < decimal.Zero || nCapitalPag <= objCuota.nCapital)
                {
                    objCuota.nCapitalPagado = nCapitalPag;
                    break;
                }
                else
                {
                    objCuota.nCapitalPagado = objCuota.nCapital;
                    nCapitalPag -= objCuota.nCapitalPagado;
                }
            }

            foreach (clsCuota objCuota in objPlanPagosNuevo)
            {
                if (objCuota.nInteres < decimal.Zero || nIntPag < decimal.Zero || nIntPag <= objCuota.nInteres)
                {
                    objCuota.nInteresPagado = nIntPag;
                    break;
                }
                else
                {
                    objCuota.nInteresPagado = objCuota.nInteres;
                    nIntPag -= objCuota.nInteresPagado;
                }
            }

            int nCuotas = objPlanPagosNuevo.Count;
            for (int i = 0; i < nCuotas; i++)
            {

                if (objPlanPagosNuevo[i].dFechaProg < clsVarGlobal.dFecSystem)
                {
                    objPlanPagosNuevo[i].nInteresFecha = objPlanPagosNuevo[i].nInteres;
                }
                else
                {
                    int nDiasCuotaActual = 0;
                    if (i == 0)
                    {
                        nDiasCuotaActual = (int)(clsVarGlobal.dFecSystem - dFechaUltPago).TotalDays;
                    }
                    else
                    {
                        nDiasCuotaActual = (int)(clsVarGlobal.dFecSystem - objPlanPagosNuevo[i - 1].dFechaProg).TotalDays;
                    }

                    if (nDiasCuotaActual <= 0)
                    {
                        break;
                    }

                    decimal nBase = 1.00m + nTasa/ 100.00m;
                    decimal nExponente = nDiasCuotaActual / 360.00m;
                    decimal nInteresFecha = Math.Round(objPlanPagosNuevo[i].nSaldoCapital * (decimal)(Math.Pow((double)nBase, (double)nExponente) - 1), 2);
                    objPlanPagosNuevo[i].nInteresFecha = nInteresFecha;

                }
            }

            clsCuota objCuotaPrimera = objPlanPagosNuevo.OrderBy(x => x.idCuota).First();
            objCuotaPrimera.nMora = objCuotaMasProxima.nMora;
            objCuotaPrimera.nMoraPagada = objCuotaMasProxima.nMoraPagada;

            objCuotaPrimera.nIntComp = (objCuotaPrimera.nIntComp>decimal.Zero)? objCuotaPrimera.nIntComp : objCuotaMasProxima.nIntComp;
            objCuotaPrimera.nInteresCompPago = objCuotaMasProxima.nInteresCompPago;

            objPlanPagosNuevo.ForEach(x => { x.nOtros = decimal.Zero; x.nOtrosPagado = decimal.Zero; });

            foreach (var objeto in objPlanPagosNuevo)
            {
                int idCuota = objeto.idCuota;

                // Sumo ngasto de la lista filtrada donde idCuota coincida con el idCuota del objeto actual
                decimal sumaNgasto = listaFiltradaSeguros
                                    .Where(detalle => detalle.idCuota == idCuota)
                                    .Sum(detalle => detalle.nGasto);

                // Sumo la sumaNgasto al campo nOtros del objeto
                objeto.nOtros += sumaNgasto;
            }

            //Traigo toda la lista de gastos asociada a la siguiente cuota a cobrar
            List<clsOtrosGastos> listaGastos = DataTableToList.ConvertTo<clsOtrosGastos>(ObjCargaGastosCred.ListarOtrosGastosPorCuota(Convert.ToInt32(objCuotaPrimera.idCuenta), Convert.ToInt32(objCuotaPrimera.idCuota))) as List<clsOtrosGastos>;

            //Sumo los otros gastos asociados a la cuota
            if (listaGastos.Count > 0)
            {
                objCuotaPrimera.nOtros += listaGastos.Sum(x => x.nGasto);
                objCuotaPrimera.nOtrosPagado += listaGastos.Sum(x => x.nGastoPag);
            }
            objCuotaPrimera.nOtros = objCuotaMasProxima.nOtros;
            objCuotaPrimera.nOtrosPagado = objCuotaMasProxima.nOtrosPagado;

            objPlanPagosNuevo.InsertRange(0, lstCuotasPagadas);

            return objPlanPagosNuevo;
        }

        public void calcularInteresCompReprog(DataTable dtPlanPagos, decimal nTasaCompensatoria)
        {
            foreach (DataRow drCuota in dtPlanPagos.AsEnumerable())
            {
                int nAtraso = (int)(clsVarGlobal.dFecSystem - Convert.ToDateTime(drCuota["fecha"])).TotalDays;
                if (nAtraso > 0)
                {
                    drCuota["nAtrasoCuota"] = nAtraso;
                    decimal nBase = 1.00m + nTasaCompensatoria / 100.00m;
                    decimal nExponente = nAtraso / 360.00m;
                    decimal nInteresComp = Math.Round(Convert.ToDecimal(drCuota["capital"]) * (decimal)(Math.Pow((double)nBase, (double)nExponente) - 1), 2);
                    drCuota["nInteresComp"] = nInteresComp;
                    drCuota["imp_cuota"] = Convert.ToDecimal(drCuota["imp_cuota"]) + nInteresComp;
                }
                else
                {
                    drCuota["nAtrasoCuota"] = nAtraso;
                    drCuota["nInteresComp"] = decimal.Zero;
                }
            }
        }

        public DataTable ConvertToDataTablePlanPagos(List<clsCuota> planPago, int idSolicitud)
        {
            DataTable dtPlanPago = new DataTable("dtPlanPago");
            dtPlanPago.Columns.Add("cuota", typeof(int));
            dtPlanPago.Columns.Add("fecha", typeof(DateTime));
            dtPlanPago.Columns.Add("dias", typeof(int));
            dtPlanPago.Columns.Add("dias_acu", typeof(int));
            dtPlanPago.Columns.Add("frc", typeof(decimal));
            dtPlanPago.Columns.Add("sal_cap", typeof(decimal));
            dtPlanPago.Columns.Add("capital", typeof(decimal));
            dtPlanPago.Columns.Add("interes", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones", typeof(decimal));
            dtPlanPago.Columns.Add("comisiones_sinSeg", typeof(decimal)); //comisiones sin seguro
            dtPlanPago.Columns.Add("itf", typeof(decimal));
            dtPlanPago.Columns.Add("nAtrasoCuota", typeof(int));
            dtPlanPago.Columns.Add("nInteresComp", typeof(decimal));
            dtPlanPago.Columns.Add("imp_cuota", typeof(decimal));
            dtPlanPago.Columns.Add("nIdSolicitud", typeof(int));

            foreach (clsCuota cuota in planPago)
            {
                DataRow drCuota = dtPlanPago.NewRow();
                drCuota["cuota"] = cuota.idCuota;
                drCuota["fecha"] = cuota.dFechaProg;
                drCuota["dias"] = cuota.nNumDiaCuota;
                drCuota["dias_acu"] = cuota.nDiasAcu;
                drCuota["frc"] = cuota.FRC;
                drCuota["sal_cap"] = cuota.nSaldoCapital;
                drCuota["capital"] = cuota.nCapital;
                drCuota["interes"] = cuota.nInteres;
                drCuota["comisiones"] = cuota.nOtros;
                drCuota["comisiones_sinSeg"] = 0;
                drCuota["itf"] = cuota.nItf;
                drCuota["nAtrasoCuota"] = cuota.nAtrasoCuota;
                drCuota["nInteresComp"] = cuota.nIntComp;
                drCuota["imp_cuota"] = cuota.nCapital + cuota.nInteres + cuota.nOtros;
                drCuota["nIdSolicitud"] = idSolicitud;
                dtPlanPago.Rows.Add(drCuota);
            }

            return dtPlanPago;
        }

        public clsPlanPago ConvertToPlanPagos(DataTable dtPlanPagos, int idCuotaIni, int idTipoCuota, int idCuenta)
        {
            clsPlanPago planPagos = new clsPlanPago();
            int idCuoIni = idCuotaIni;
            planPagos.AddRange(from DataRow item in dtPlanPagos.Rows
                               select new clsCuota()
                               {
                                   idCuota = idCuoIni++,
                                   dFechaProg = Convert.ToDateTime(item["fecha"]),
                                   nCapital = Convert.ToDecimal(item["capital"]),
                                   nInteres = Convert.ToDecimal(item["interes"]),
                                   nOtros = Convert.ToDecimal(item["comisiones"]),
                                   nOtrosSinSeg = Convert.ToDecimal(item["comisiones_sinSeg"]),
                                   nMora = 0,
                                   idEstadocuota = 1,
                                   idTipoCuota = idTipoCuota,
                                   idCuenta = idCuenta,
                                   nNumDiaCuota = Convert.ToInt32(item["dias"]),
                                   nAtrasoCuota = Convert.ToInt32(item["nAtrasoCuota"]),
                                   nSaldoCapital = Convert.ToDecimal(item["sal_cap"]),
                                   nDiasAcu = Convert.ToInt32(item["dias_acu"]),
                                   nItf = Convert.ToInt32(item["itf"]),
                                   idModPagoCre = 0,
                                   nIntComp = Convert.ToDecimal(item["nInteresComp"]),
                                   nInteresCompPago = decimal.Zero
                               });
            return planPagos;
        }

        private DateTime GetValidDate(DateTime fechaMes, int day)
        {
            DateTime fechaValida;
            while (!DateTime.TryParse(string.Format("{0}/{1}/{2}", fechaMes.Year, fechaMes.Month, day), out fechaValida))
            {
                day--;
            }
            return fechaValida;
        }

        public DataTable CNRetornaCuentaXSolicitud(int nIdSolicitud)
        {
            return objPlanPago.ADRetornaCuentaXSolicitud(nIdSolicitud);
        }

        #region Descuento Camp Nav.
        public DataTable CNValidaClienteCampNav(int idCli, string dMonto, int idSolicitud, int idCuenta)
        {
            return objPlanPago.ADValidaClienteCampNav(idCli, dMonto, idSolicitud, idCuenta);
        }

        public DataTable CNVerificaDatosClienteCampNav(int idCli, int idCuenta)
        {
            return objPlanPago.ADVerificaDatosClienteCampNav(idCli, idCuenta);
        }

        public DataTable CNVerificarEstadoCredito(int idCuenta)
        {
            return objPlanPago.ADVerificarEstadoCredito(idCuenta);
        }

        public DataTable CNActualizarEstadoBonoNav(int idCuenta, int idCliente, int idEstado)
        {
            return objPlanPago.ADActualizarEstadoBonoNav(idCuenta, idCliente, idEstado);
        }

        #endregion

        #region PlanPagos Grupo Solidario

        public DataTable CNGuardarPlanPagosGrupoSol(int idSolicitudCredGrupoSol)
        {
            return objPlanPago.ADGuardarPlanPagosGrupoSol(idSolicitudCredGrupoSol);
        }

        public DataTable CNrptIntegrantesGrupo(int idSolicitudCredGrupoSol)
        {
            return objPlanPago.ADrptIntegrantesGrupo(idSolicitudCredGrupoSol);
        }

        public DataTable CNrptPlanPagosGrupal(int idSolicitudCredGrupoSol)
        {
            return objPlanPago.ADrptPlanPagosGrupal(idSolicitudCredGrupoSol);
        }


        public DataTable CNrptDatosCreditoGrupal(int idSolicitudCredGrupoSol)
        {
            return objPlanPago.ADrptDatosCreditoGrupal(idSolicitudCredGrupoSol);
        }

        #endregion

        private decimal ObtenerCuotaAproximada(decimal _nMonDesemb, decimal _nFacAcumul, int _nDecRedonCalcPpg, decimal _nCuotaAprox)
        {
            return (_nCuotaAprox == 0)? decimal.Round(_nMonDesemb / _nFacAcumul, _nDecRedonCalcPpg) : _nCuotaAprox;
        }

        public decimal CalculoMontoSeguroMultiriesgoPorCuota(int idTipoPeriodoCredito, DateTime dFechaDesde, DateTime dFechaHasta, int nCuota, int nPlazo, decimal nPrimaDiaria, bool lCuotasConstantes, out decimal nCentimosAjuste)
        {
            nCentimosAjuste = 0;
            decimal nMontoSeguroMultiriesgoCuota = 0m;
            int nDiasPlazoReal = 0;

            if (idTipoPeriodoCredito == (int)TipoPeriodo.FechaFija)
            {
                if (nCuota == 1)
                {
                    int nDia = dFechaDesde.Day;
                    int nMes = dFechaDesde.Month + 1;
                    int nAnio = dFechaDesde.Year;
                    if (nMes > 12) { nAnio++; nMes = 1; }
                    int nUltimoDiaMes = DateTime.DaysInMonth(nAnio, nMes);
                    if (nDia > nUltimoDiaMes) nDia = nUltimoDiaMes;

                    DateTime dFechaHastaTemp = new DateTime(nAnio, nMes, nDia);
                    int nDiasGracia = (dFechaHasta - dFechaHastaTemp).Days;
                    nDiasGracia = (nDiasGracia < 0) ? 0 : nDiasGracia;

                    int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaHastaTemp).Days / 30m));
                    nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;

                    nDiasPlazoReal = nDiasPlazoReal + nDiasGracia;
                }
                else
                {
                    int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaDesde).Days / 30m));
                    nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;
                }
            }
            else if (idTipoPeriodoCredito == (int)TipoPeriodo.PeriodoFijo)
            {
                nDiasPlazoReal = (dFechaHasta - dFechaDesde).Days;
            }
            else if (idTipoPeriodoCredito == (int)TipoPeriodo.CuotasLibres)
            {
                nDiasPlazoReal = (dFechaHasta - dFechaDesde).Days;
            }

            int numDecimalesRedondeo = lCuotasConstantes ? 1 : 2;

            nMontoSeguroMultiriesgoCuota = Math.Round(nDiasPlazoReal * nPrimaDiaria, 2);
            nCentimosAjuste = 0;

            return nMontoSeguroMultiriesgoCuota;
        }

        public DataTable ObtenerDistribucionPrimaMultiriesgo(decimal nValorPrimaMultiriesgo, DataTable dtPlanPagos, clsSolicitudCreditoCargaSeguro objSolCreCarSeg, decimal nMontoCobertura, bool lCuotasConstantes)
        {
            //Valor de la prima mensual
            var nValorPrimaDiaria = nMontoCobertura * nValorPrimaMultiriesgo / 30m;

            //Obtencion de datos para el calculo
            var dFechaPrimeraCuota = objSolCreCarSeg.dFechaPrimeraCuota;
            var dFechaDesembolso = objSolCreCarSeg.dFechaDesembolso;
            var idTipoPeriodoCredito = objSolCreCarSeg.idTipoPlazo;

            int numCuotas = dtPlanPagos.Rows.Count;

            DataTable dtSeguroMultiriesgo = new DataTable("dtSeguroMultiriesgo");
            dtSeguroMultiriesgo.Columns.Add("cuota", typeof(int));
            dtSeguroMultiriesgo.Columns.Add("monto", typeof(decimal));

            decimal nTotalCentimosAjuste = 0;

            for (int i = 1; i <= numCuotas; i++)
            {
                DataRow fila = dtSeguroMultiriesgo.NewRow();
                var nCuota = i;
                DateTime dFechaDesde = nCuota == 1 ? dFechaDesembolso : Convert.ToDateTime(dtPlanPagos.Rows[i - 2]["fecha"]);
                DateTime dFechaHasta = nCuota == 1 ? dFechaPrimeraCuota : Convert.ToDateTime(dtPlanPagos.Rows[i - 1]["fecha"]);
                int nPlazo = objSolCreCarSeg.nPlazo;
                decimal nCentimosAjuste = 0;
                decimal nMontoCuotaSeguroMultiriesgo = CalculoMontoSeguroMultiriesgoPorCuota(idTipoPeriodoCredito, dFechaDesde, dFechaHasta, nCuota, nPlazo, nValorPrimaDiaria, lCuotasConstantes, out nCentimosAjuste);
                nTotalCentimosAjuste = nTotalCentimosAjuste + nCentimosAjuste;

                if (i == numCuotas)
                {
                    nMontoCuotaSeguroMultiriesgo = nMontoCuotaSeguroMultiriesgo + nTotalCentimosAjuste;
                }
                fila["cuota"] = nCuota;
                fila["monto"] = nMontoCuotaSeguroMultiriesgo;
                dtSeguroMultiriesgo.Rows.Add(fila);
            }

            dtSeguroMultiriesgo.AcceptChanges();
            return dtSeguroMultiriesgo;
        }

        #region Validación histórico de solicitud de crédito (Fecha 1ra cuota).

        public DataTable CNListarMotivo(int idSolicitud)
        {
            return objPlanPago.ADListarMotivo(idSolicitud);
        }

        public DataTable CNRegistrarMotivo(int idSolicitud, int idUsuario, DateTime dFechaIncial, DateTime dFechaModificado, string cMotivo, DateTime dFecSystem, int idCondHistSolCred)
        {
            return objPlanPago.ADRegistrarMotivo(idSolicitud, idUsuario, dFechaIncial, dFechaModificado, cMotivo, dFecSystem, idCondHistSolCred);
        }
        #endregion
        
        /// <summary>
        /// Realiza el calculo de un cargo a una cuota
        /// </summary>
        /// <param name="idTipoPeriodoCredito">Tipo de periodo de credito: Periodo fijo, fecha fija, cuotas libres</param>
        /// <param name="dFechaDesde">Fecha desde</param>
        /// <param name="dFechaHasta">Fecha hasta</param>
        /// <param name="nCuota">Numero de cuota</param>
        /// <param name="nValorCargoDiario">Monto del cargo diario</param>
        /// <param name="lCuotasConstantes">Indica si se debe mantener las cuotas redondeados a multiplos de 10 centimos</param>
        /// <param name="nCentimosAjuste">Los centimos ajustados por las cuotas constantes</param>
        /// <returns>El monto del cargo que se debe aplicar a la cuota y los centimos de ajuste</returns>
        public decimal CalculoCargoPorCuota(int idTipoPeriodoCredito, DateTime dFechaDesde, DateTime dFechaHasta,
                                        int nCuota, decimal nValorCargoDiario, bool lCuotasConstantes,
                                        out decimal nCentimosAjuste)
        {
            int nDiasPlazoReal = 0;

            if (idTipoPeriodoCredito == (int)TipoPeriodo.FechaFija)
            {
                if (nCuota == 1)
                {
                    if (nCuota == 1)
                    {
                        int nDia = dFechaDesde.Day;
                        int nMes = dFechaDesde.Month + 1;
                        int nAnio = dFechaDesde.Year;
                        if (nMes > 12) { nAnio++; nMes = 1; }
                        int nUltimoDiaMes = DateTime.DaysInMonth(nAnio, nMes);
                        if (nDia > nUltimoDiaMes) nDia = nUltimoDiaMes;

                        DateTime dFechaHastaTemp = new DateTime(nAnio, nMes, nDia);
                        int nDiasGracia = (dFechaHasta - dFechaHastaTemp).Days;
                        nDiasGracia = (nDiasGracia < 0) ? 0 : nDiasGracia;

                        int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaHastaTemp).Days / 30m));
                        nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;

                        nDiasPlazoReal = nDiasPlazoReal + nDiasGracia;
                    }
                    else
                    {
                        int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaDesde).Days / 30m));
                        nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;
                    }
                }
                else
                {
                    nDiasPlazoReal = 30;
                }
            }
            else if (idTipoPeriodoCredito == (int)TipoPeriodo.PeriodoFijo)
            {
                nDiasPlazoReal = (dFechaHasta - dFechaDesde).Days;
            }
            else if (idTipoPeriodoCredito == (int)TipoPeriodo.CuotasLibres)
            {
                nDiasPlazoReal = (dFechaHasta - dFechaDesde).Days;
            }

            int numDecimalesRedondeo = lCuotasConstantes ? 1 : 2;

            decimal nMontoCargoCuota = Math.Round(nDiasPlazoReal * nValorCargoDiario, 2);
            //decimal nMontoCargoCuotaTruncado = cnFuncionesUtiles.truncarNumero(nMontoCargoCuota, numDecimalesRedondeo);

            nCentimosAjuste = 0;

            return nMontoCargoCuota;
        }

        /// <summary>
        /// Obtiene la distribucion de un cargo aplicado a un plan de pagos
        /// </summary>
        /// <param name="nCargoMensual">Cargo mensual en soles</param>
        /// <param name="dtPlanPago">Tabla del plan de pagos</param>
        /// <param name="dFechaPrimeraCuota">Fecha de la primera cuota</param>
        /// <param name="dFechaDesembolso">Fecha de desembolso</param>
        /// <param name="idTipoPeriodoCredito">Tipo de periodo de credito: Periodo fijo, fecha fija, cuotas libres</param>
        /// <param name="lCuotasConstantes">Indica si se debe mantener las cuotas redondeados a multiplos de 10 centimos</param>
        /// <returns>Retorna una tabla con las columnas 'monto' y 'cuota'</returns>
        public DataTable ObtenerDistribucionPorCargoMensual(decimal nCargoMensual, DataTable dtPlanPago, DateTime dFechaPrimeraCuota,
                                                            DateTime dFechaDesembolso, int idTipoPeriodoCredito, bool lCuotasConstantes)
        {
            var nValorCargoDiario = nCargoMensual / 30m;

            int numCuotas = dtPlanPago.Rows.Count;

            DataTable dtCargoMensual = new DataTable("dtCargoMensual");
            dtCargoMensual.Columns.Add("cuota", typeof(int));
            dtCargoMensual.Columns.Add("monto", typeof(decimal));

            decimal nTotalCentimosAjuste = 0;

            for (int i = 1; i <= numCuotas; i++)
            {
                DataRow fila = dtCargoMensual.NewRow();
                var nCuota = i;
                DateTime dFechaDesde = nCuota == 1 ? dFechaDesembolso : Convert.ToDateTime(dtPlanPago.Rows[i - 2]["fecha"]);
                DateTime dFechaHasta = nCuota == 1 ? dFechaPrimeraCuota : Convert.ToDateTime(dtPlanPago.Rows[i - 1]["fecha"]);
                decimal nCentimosAjuste = 0;
                decimal nMontoCuotaCargo = CalculoCargoPorCuota(idTipoPeriodoCredito, dFechaDesde, dFechaHasta, nCuota, nValorCargoDiario, lCuotasConstantes, out nCentimosAjuste);
                nTotalCentimosAjuste += nCentimosAjuste;

                if (i == numCuotas)
                {
                    nMontoCuotaCargo += nTotalCentimosAjuste;
                }
                fila["cuota"] = nCuota;
                fila["monto"] = nMontoCuotaCargo;
                dtCargoMensual.Rows.Add(fila);
            }

            dtCargoMensual.AcceptChanges();
            return dtCargoMensual;
        }
    }
}