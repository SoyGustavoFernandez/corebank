using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.CapaNegocio
{
    public class clsCNEstadosFinancierosResumen
    {
        public List<clsVentasCostos> listVentasCostos { get; set; }
        public List<clsDetEstResEval> listGFamiliares { get; set; }
        public List<clsDetEstResEval> listGPersonales { get; set; }
        public List<clsDetEstResEval> listGOperativos { get; set; }
        public List<clsDetEstResEval> listOtrosEgresos { get; set; }
        public List<clsDetEstResEval> listOtrosIngresos { get; set; }

        public List<clsDeudasEval> listCredDirectos { get; set; }
        public List<clsDeudasEval> listCredIndirect { get; set; }

        private int nPlazo;
        private int nAnual;
        private int nMaximo;
        private decimal nTipoCambio;
        private int idMonedaActual;
        private int idTipEvaluacion;

        #region Totales para los Estados Resultados
        public void ActualizarPlazo(int nPlazo, decimal nTipoCambio, int idMonedaActual, int idTipEvaluacion)
        {
            this.nPlazo = nPlazo;
            this.nAnual = 12;
            this.nTipoCambio = nTipoCambio;
            this.idMonedaActual = idMonedaActual;
            this.idTipEvaluacion = idTipEvaluacion;

            this.nMaximo = (this.nPlazo >= this.nAnual) ? this.nAnual : this.nPlazo;
        }
        #endregion

        #region Métodos Gastos Financieros
        public decimal CDirectosTotalSaldoCortoPlazoMA()
        {
            return this.listCredDirectos.Sum(x => x.nSCapCortoPlzMA);
        }

        public decimal CDirectosTotalSaldoLargoPlazoMA()
        {
            return this.listCredDirectos.Sum(x => x.nSCapLargoPlzMA);
        }

        public decimal CIndirectosTotalSaldoMA()
        {
            return this.listCredIndirect.Sum(x => x.nSCapLargoPlzMA);
        }

        public decimal CDirectosTotalSaldoMA()
        {
            return this.listCredDirectos.Sum(x => x.nSCapTotalMA);
        }

        public decimal ProvicionCIndirectosMA()
        {
            decimal nProvBalGeneralEvalPyme = Convert.ToDecimal(clsVarApl.dicVarGen["nProvBalGeneralEvalPyme"]);

            decimal nLargoPlazo = CIndirectosTotalSaldoMA() * nProvBalGeneralEvalPyme;

            return nLargoPlazo;
        }

        public decimal CDirectosTotalMontoCuotaMA()
        {
            return this.listCredDirectos.Sum(x => x.nMontoCuotaMA);
        }

        public decimal CDirectosTotalMontoCuotaMN()
        {
            return this.listCredDirectos
                .Where(x => x.idMoneda == (int)Monedas.MonedaNacional)
                .Sum(x => x.nMontoCuota);
        }

        public decimal CDirectosTotalMontoCuotaME()
        {
            return this.listCredDirectos
                .Where(x => x.idMoneda == (int)Monedas.MonedaExtranjera)
                .Sum(x => x.nMontoCuota);
        }

        public decimal TotalPasivoAC()
        {
            decimal nTotalPasicoAC = (from p in this.listCredDirectos
                                      where p.idDeudaCA == TipDeudasCA.CompraDeuda
                                          || p.idDeudaCA == TipDeudasCA.Ampliacion
                                          || p.idDeudaCA == TipDeudasCA.Reprogramacion
                                          || p.idDeudaCA == TipDeudasCA.Refinanciamiento
                                      select p).ToList().Sum(x => x.nSCapTotalMA);

            return nTotalPasicoAC;
        }
        #endregion

        #region Métodos privados
        public decimal TotalVentasMA()
        {
            return this.listVentasCostos.Sum(x => x.nTotalVentasMA);
        }

        public decimal TotalVentasAnualizadoMA()
        {
            return VentasxMoneda(Monedas.MonedaActual).Sum(x => x.nMonto);
        }

        public decimal TotalCostosMA()
        {
            return this.listVentasCostos.Sum(x => x.nTotalCostosMA);
        }

        public decimal TotalCostosAnualizadoMA()
        {
            return CostosxMoneda(Monedas.MonedaActual).Sum(x => x.nMonto);
        }

        public decimal TotalGFamiliaresMA()
        {
            return this.listGFamiliares.Sum(x => x.nTotalMA);
        }

        public decimal TotalGFamiliaresAnualizadoMA()
        {
            return (TotalGFamiliaresMA() * this.nMaximo);
        }

        public decimal TotalGPersonalesMA()
        {
            return this.listGPersonales.Sum(x => x.nTotalMA);
        }

        public decimal TotalGPersonalesAnualizadoMA()
        {
            return (TotalGPersonalesMA() * this.nMaximo);
        }

        public decimal TotalGOperativosMA()
        {
            return this.listGOperativos.Sum(x => x.nTotalMA);
        }

        public decimal TotalGOperativosAnualizadoMA()
        {
            return GOperativosxMoneda(Monedas.MonedaActual).Sum(x => x.nMonto);
        }

        public decimal TotalOtrosEgresosMA()
        {
            return this.listOtrosEgresos.Sum(x => x.nTotalMA);
        }

        public decimal TotalOtrosEgresosAnualizadoMA()
        {
            return (TotalOtrosEgresosMA() * this.nMaximo);
        }

        public decimal TotalOtrosIngresosMA()
        {
            return this.listOtrosIngresos.Sum(x => x.nTotalMA);
        }

        public decimal TotalOtrosIngresosAnualizadoMA()
        {
            return (TotalOtrosIngresosMA() * this.nMaximo);
        }

        public decimal TotalGFinancierosMA()
        {
            decimal nCDirectosTotalMontoCuota = CDirectosTotalMontoCuotaMA();
            decimal nProvicionCreditosIndirectos = ProvicionCreditosIndirectosMN();

            nProvicionCreditosIndirectos = clsMathFinanciera.Convertir(
                                           (int)Monedas.MonedaNacional,
                                           this.idMonedaActual,
                                           nProvicionCreditosIndirectos,
                                           this.nTipoCambio);

            return (nCDirectosTotalMontoCuota + nProvicionCreditosIndirectos);
        }

        public decimal TotalGFinancierosAnualizadoMA()
        {
            decimal nCDirectosTotalMontoCuota = CDirectosTotalMontoCuotaAnualizado(Monedas.MonedaActual);
            decimal nProvicionCreditosIndirectos = ProvicionCreditosIndirectosMN();

            nProvicionCreditosIndirectos = clsMathFinanciera.Convertir(
                                           (int)Monedas.MonedaNacional,
                                           this.idMonedaActual,
                                           nProvicionCreditosIndirectos,
                                           this.nTipoCambio);

            return (nCDirectosTotalMontoCuota + (nProvicionCreditosIndirectos * this.nMaximo));
        }
        #endregion

        #region RCC Moneda Nacional
        public decimal TotalVentasMN()
        {
            return this.listVentasCostos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotalVentas);
        }

        public decimal TotalVentasAnualizadoMN()
        {
            return VentasxMoneda(Monedas.MonedaNacional).Sum(x => x.nMonto);
        }

        public decimal TotalCostosMN()
        {
            return this.listVentasCostos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotalCostos);
        }

        public decimal TotalCostosAnualizadoMN()
        {
            return CostosxMoneda(Monedas.MonedaNacional).Sum(x => x.nMonto);
        }

        public decimal TotalGFamiliaresMN()
        {
            return this.listGFamiliares
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGFamiliaresAnualizadoMN()
        {
            return (TotalGFamiliaresMN() * this.nMaximo);
        }

        public decimal TotalGPersonalesMN()
        {
            return this.listGPersonales
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGPersonalesAnualizadoMN()
        {
            return (TotalGPersonalesMN() * this.nMaximo);
        }

        public decimal TotalGOperativosMN()
        {
            return this.listGOperativos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGOperativosAnualizadoMN()
        {
            return GOperativosxMoneda(Monedas.MonedaNacional).Sum(x => x.nMonto);
        }

        public decimal TotalOtrosIngresosMN()
        {
            return this.listOtrosIngresos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotal);
        }

        public decimal TotalOtrosIngresosAnualizadoMN()
        {
            return (TotalOtrosIngresosMN() * this.nMaximo);
        }

        public decimal TotalOtrosEgresosMN()
        {
            return this.listOtrosEgresos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaNacional))
                .Sum(x => x.nTotal);
        }

        public decimal TotalOtrosEgresosAnualizadoMN()
        {
            return (TotalOtrosEgresosMN() * this.nMaximo);
        }

        public decimal TotalGFinancierosMN()
        {
            decimal nCDirectosTotalMontoCuota = CDirectosTotalMontoCuotaMN();
            decimal nProvicionCreditosIndirectos = ProvicionCreditosIndirectosMN();

            return (nCDirectosTotalMontoCuota + nProvicionCreditosIndirectos);
        }

        public decimal TotalGFinancierosAnualizadoMN()
        {
            decimal nCDirectosTotalMontoCuota = CDirectosTotalMontoCuotaAnualizado(Monedas.MonedaNacional);
            decimal nProvicionCreditosIndirectos = ProvicionCreditosIndirectosMN();

            return (nCDirectosTotalMontoCuota + (nProvicionCreditosIndirectos * this.nMaximo));
        }
        #endregion

        #region RCC Moneda Extranjera
        public decimal TotalVentasME()
        {
            return this.listVentasCostos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotalVentas);
        }

        public decimal TotalVentasAnualizadoME()
        {
            return VentasxMoneda(Monedas.MonedaExtranjera).Sum(x => x.nMonto);
        }

        public decimal TotalCostosME()
        {
            return this.listVentasCostos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotalCostos);
        }

        public decimal TotalCostosAnualizadoME()
        {
            return CostosxMoneda(Monedas.MonedaExtranjera).Sum(x => x.nMonto);
        }

        public decimal TotalGFamiliaresME()
        {
            return this.listGFamiliares
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGFamiliaresAnualizadoME()
        {
            return (TotalGFamiliaresME() * this.nMaximo);
        }

        public decimal TotalGPersonalesME()
        {
            return this.listGPersonales
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGPersonalesAnualizadoME()
        {
            return (TotalGPersonalesME() * this.nMaximo);
        }

        public decimal TotalGOperativosME()
        {
            return this.listGOperativos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotal);
        }

        public decimal TotalGOperativosAnualizadoME()
        {
            return GOperativosxMoneda(Monedas.MonedaExtranjera).Sum(x => x.nMonto);
        }

        public decimal TotalOtrosIngresosME()
        {
            return this.listOtrosIngresos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotal);
        }

        public decimal TotalOtrosIngresosAnualizadoME()
        {
            return (TotalOtrosIngresosME() * this.nMaximo);
        }

        public decimal TotalOtrosEgresosME()
        {
            return this.listOtrosEgresos
                .Where(x => x.idMoneda == (int)(Monedas.MonedaExtranjera))
                .Sum(x => x.nTotal);
        }

        public decimal TotalOtrosEgresosAnualizadoME()
        {
            return (TotalOtrosEgresosME() * this.nMaximo);
        }

        public decimal TotalGFinancierosME()
        {
            return CDirectosTotalMontoCuotaME();
        }

        public decimal TotalGFinancierosAnualizadoME()
        {
            return CDirectosTotalMontoCuotaAnualizado(Monedas.MonedaExtranjera);
        }

        public decimal nTotalCapitalDeudaIndirectaMA()
        {
            return listCredIndirect.Sum(x => x.nSCapTotalMA);
        }

        public decimal nTotalCapitalDeudaIndirectaME()
        {
            return listCredIndirect.Sum(x => x.nSCapTotalME);
        }

        public decimal nTotalCapitalDeudaIndirectaMN()
        {
            return listCredIndirect.Sum(x => x.nSCapTotalMN);
        }

        public decimal nTotalProvisionDeudasIndirectasMA()
        {
            
            decimal nMontoDeudaIndirectaMA = this.nTotalCapitalDeudaIndirectaMA();

            decimal nProvNroMesesEvalConsumoHasta = (this.idTipEvaluacion == 18)? Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoHasta"]): 1;
            decimal nProvNroMesesEvalConsumoMayor = (this.idTipEvaluacion == 18)? Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor"]): 1;            

            if (nMontoDeudaIndirectaMA <= this.nMontoTopeMA1)
            {
                return (nMontoDeudaIndirectaMA * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])) / nProvNroMesesEvalConsumoHasta;
            }
            else
            {
                return (nMontoDeudaIndirectaMA * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])) / nProvNroMesesEvalConsumoMayor;
            }
        }

        public decimal nTotalProvisionDeudasIndirectasMN()
        {

            decimal nMontoDeudaIndirectaMN = this.nTotalCapitalDeudaIndirectaMN();
            if (nMontoDeudaIndirectaMN <= this.nMontoTopeMN1)
            {
                return (nMontoDeudaIndirectaMN * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"]));// / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoHasta"]);
            }
            else if (nMontoDeudaIndirectaMN <= this.nMontoTopeMN2)
            {
                return (nMontoDeudaIndirectaMN * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])); // /  Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor"]);
            }
            else
            {
                return (nMontoDeudaIndirectaMN * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])); // / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor2do"]);
            }
        }

        public decimal nTotalProvisionDeudasIndirectasME()
        {

            decimal nMontoDeudaIndirectaME = this.nTotalCapitalDeudaIndirectaME();
            if (nMontoDeudaIndirectaME <= this.nMontoTopeME1)
            {
                return (nMontoDeudaIndirectaME * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])); // /  Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoHasta"]);
            }
            else if (nMontoDeudaIndirectaME <= this.nMontoTopeME2)
            {
                return (nMontoDeudaIndirectaME * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])); // / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor"]);
            }
            else
            {
                return (nMontoDeudaIndirectaME * Convert.ToDecimal(clsVarApl.dicVarGen["nProvEvalConsumo"])); // / Convert.ToDecimal(clsVarApl.dicVarGen["nProvNroMesesEvalConsumoMayor2do"]);
            }
        }

        public decimal nMontoTopeMA1 
        {
            get 
            {
                return clsMathFinanciera.Convertir(1, idMonedaActual, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopProvEvalConsumo"]), nTipoCambio);
            }
        }

        public decimal nMontoTopeMA2
        {
            get
            {
                return clsMathFinanciera.Convertir(1, idMonedaActual, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTop2ProvEvalC"]), nTipoCambio);
            }
        }

        public decimal nMontoTopeMN1
        {
            get
            {
                return clsMathFinanciera.Convertir(1, 1, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopProvEvalConsumo"]), nTipoCambio);
            }
        }

        public decimal nMontoTopeMN2
        {
            get
            {
                return clsMathFinanciera.Convertir(1, 1, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTop2ProvEvalC"]), nTipoCambio);
            }
        }

        public decimal nMontoTopeME1
        {
            get
            {
                return clsMathFinanciera.Convertir(1, 2, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopProvEvalConsumo"]), nTipoCambio);
            }
        }

        public decimal nMontoTopeME2
        {
            get
            {
                return clsMathFinanciera.Convertir(1, 2, Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTop2ProvEvalC"]), nTipoCambio);
            }
        }

        public decimal CDirectosTotalSaldoSoloNormalMA()
        {
            return this.listCredDirectos.Where(x=> x.idDeudaCA == 1).Sum(x => x.nSCapTotalMA);
        }

        public decimal CDirectosTotalSaldoSoloNormalME()
        {
            return this.listCredDirectos.Where(x => x.idDeudaCA == 1).Sum(x => x.nSCapTotalME);
        }

        public decimal CDirectosTotalSaldoSoloNormalMN()
        {
            return this.listCredDirectos.Where(x => x.idDeudaCA == 1).Sum(x => x.nSCapTotalMN);
        }

        #endregion

        #region Métodos privados
        private List<clsFlujoCaja> VentasxMoneda(Monedas TipoMoneda)
        {
            decimal nMonto = 0;
            int nMes = 0;
            int nFrecuencia = 0;
            var listFlujoCaja = new List<clsFlujoCaja>();

            foreach (clsVentasCostos objVentasCostos in this.listVentasCostos)
            {
                nMonto = 0;
                for (int i = 1; i < (this.nMaximo + 1); i++)
                {
                    nMes = objVentasCostos.nMesVenta;
                    nFrecuencia = objVentasCostos.nFrecuencia;

                    if (TipoMoneda == Monedas.MonedaActual)
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalVentasMA : 0;

                    else if ((TipoMoneda == Monedas.MonedaNacional) && (objVentasCostos.idMoneda == Convert.ToInt32(Monedas.MonedaNacional)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalVentas : 0;

                    else if ((TipoMoneda == Monedas.MonedaExtranjera) && (objVentasCostos.idMoneda == Convert.ToInt32(Monedas.MonedaExtranjera)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalVentas : 0;

                    else
                        nMonto = 0;

                    listFlujoCaja.Add(new clsFlujoCaja { nMes = i, nMonto = nMonto });
                }
            }

            return listFlujoCaja;
        }

        private List<clsFlujoCaja> CostosxMoneda(Monedas TipoMoneda)
        {
            decimal nMonto = 0;
            int nMes = 0;
            int nFrecuencia = 0;
            var listFlujoCaja = new List<clsFlujoCaja>();

            foreach (clsVentasCostos objVentasCostos in this.listVentasCostos)
            {
                nMonto = 0;
                for (int i = 1; i < (this.nMaximo + 1); i++)
                {
                    nMes = objVentasCostos.nMesVenta;
                    nFrecuencia = objVentasCostos.nFrecuencia;

                    if (TipoMoneda == Monedas.MonedaActual)
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalCostosMA : 0;

                    else if ((TipoMoneda == Monedas.MonedaNacional) && (objVentasCostos.idMoneda == Convert.ToInt32(Monedas.MonedaNacional)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalCostos : 0;

                    else if ((TipoMoneda == Monedas.MonedaExtranjera) && (objVentasCostos.idMoneda == Convert.ToInt32(Monedas.MonedaExtranjera)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? objVentasCostos.nTotalCostos : 0;

                    else
                        nMonto = 0;

                    listFlujoCaja.Add(new clsFlujoCaja { nMes = i, nMonto = nMonto });
                }
            }

            return listFlujoCaja;
        }

        private List<clsFlujoCaja> GOperativosxMoneda(Monedas TipoMoneda)
        {
            decimal nMonto = 0;
            int nMes = 0;
            int nFrecuencia = 0;
            var listFlujoCaja = new List<clsFlujoCaja>();

            foreach (clsDetEstResEval list in this.listGOperativos)
            {
                nMonto = 0;
                for (int i = 1; i < (this.nMaximo + 1); i++)
                {
                    nMes = list.nMesVenta;
                    nFrecuencia = list.nFrecuencia;

                    if (TipoMoneda == Monedas.MonedaActual)
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? list.nTotalMA : 0;

                    else if ((TipoMoneda == Monedas.MonedaNacional) && (list.idMoneda == Convert.ToInt32(Monedas.MonedaNacional)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? list.nTotal : 0;

                    else if ((TipoMoneda == Monedas.MonedaExtranjera) && (list.idMoneda == Convert.ToInt32(Monedas.MonedaExtranjera)))
                        nMonto = (((i - nMes + nFrecuencia) % nFrecuencia) == 0) ? list.nTotal : 0;

                    else
                        nMonto = 0;

                    listFlujoCaja.Add(new clsFlujoCaja { nMes = i, nMonto = nMonto });
                }
            }

            return listFlujoCaja;
        }

        private decimal CDirectosTotalMontoCuotaAnualizado(Monedas TipoMoneda)
        {
            decimal nMontoMA = 0;
            decimal nTotalMontoCuotaAnualizado = 0;

            foreach (clsDeudasEval objDeuda in this.listCredDirectos)
            {
                nMontoMA = 0;
                if (TipoMoneda == Monedas.MonedaActual)
                {
                    nMontoMA = objDeuda.listCuotaPago
                                .Where(x => x.nMes <= this.nMaximo)
                                .Sum(x => x.nMontoMA);
                }
                else if ((TipoMoneda == Monedas.MonedaNacional) && (objDeuda.idMoneda == Convert.ToInt32(Monedas.MonedaNacional)))
                {
                    nMontoMA = objDeuda.listCuotaPago
                                .Where(x => x.nMes <= this.nMaximo)
                                .Sum(x => x.nMonto);
                }
                else if ((TipoMoneda == Monedas.MonedaExtranjera) && (objDeuda.idMoneda == Convert.ToInt32(Monedas.MonedaExtranjera)))
                {
                    nMontoMA = objDeuda.listCuotaPago
                                .Where(x => x.nMes <= this.nMaximo)
                                .Sum(x => x.nMonto);
                }

                nTotalMontoCuotaAnualizado += nMontoMA;
            }

            return nTotalMontoCuotaAnualizado;
        }

        private decimal ProvicionCreditosIndirectosMN()
        {
            int nNroMesesEvalPyme = 1;

            decimal nCIndirectosTotalSaldoMN = 0;
            decimal nCIndirectosTotalSaldoME = 0;

            int nNroMesesEvalPymeVar1 = Convert.ToInt32(clsVarApl.dicVarGen["nNroMesesEvalPymeVar1"]);
            int nNroMesesEvalPymeVar2 = Convert.ToInt32(clsVarApl.dicVarGen["nNroMesesEvalPymeVar2"]);
            decimal nMontoTopEvalPymeVar1 = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopEvalPymeVar1"]);
            decimal nMontoTopEvalPymeVar2 = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopEvalPymeVar2"]);
            decimal nProvEstResultadosEvalPyme = Convert.ToDecimal(clsVarApl.dicVarGen["nProvEstResultadosEvalPyme"]);

            nCIndirectosTotalSaldoMN = this.listCredIndirect
                                        .Where(x => x.idMoneda == (int)Monedas.MonedaNacional)
                                        .Sum(x => x.nSCapLargoPlz);

            nCIndirectosTotalSaldoME = this.listCredIndirect
                                        .Where(x => x.idMoneda == (int)Monedas.MonedaExtranjera)
                                        .Sum(x => x.nSCapLargoPlz);

            nCIndirectosTotalSaldoMN += clsMathFinanciera.Convertir(
                                        (int)Monedas.MonedaExtranjera,
                                        (int)Monedas.MonedaNacional,
                                        nCIndirectosTotalSaldoME,
                                        this.nTipoCambio);

            if (nCIndirectosTotalSaldoMN <= nMontoTopEvalPymeVar1) nNroMesesEvalPyme = nNroMesesEvalPymeVar1;
            else if (nCIndirectosTotalSaldoMN <= nMontoTopEvalPymeVar2) nNroMesesEvalPyme = nNroMesesEvalPymeVar2;

            decimal nProvicion = clsNumerico.Dividir(nCIndirectosTotalSaldoMN * nProvEstResultadosEvalPyme, nNroMesesEvalPyme);

            return nProvicion;
        }
        #endregion
    }
}
