using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNPrePago
    {
        public TipoPrepago TipoPrepago { get; set; }
        public DataTable DtModificaciones { get; set; }
        public DateTime FecPrimeraCuota { get; set; }
        private decimal _tasa;
        public decimal Tasa
        {
            get { return _tasa / 100.0m; }
            set { _tasa = value; }
        }
        public int IdSolicitud { get; set; }
        public int IdCuenta { get; set; }
        public int IdMoneda { get; set; }
        public short IdTipoPeriodo { get; set; }
        public int PlazoCuota { get; set; }
        public decimal MontoCalculo { get; set; }
        public int NumCuotas { get; set; }
        public decimal CapitalMaxCobSeg { get; set; }
        public int NumCuotasGracia { get; set; }
        public decimal MontoCuota { get; set; }
        public DataTable ConfigGastos { get; set; }
        public DataTable GastosPlanPagos { get; private set; }
        public DataTable GastosCuotaPrePago { get; set; }
        public decimal MontoCuotaNuevo { get; private set; }

        private static readonly DateTime FechaDesembolso = clsVarGlobal.dFecSystem.Date;

        public clsPlanPago DistribuirPrePago(clsPlanPago planPagos, decimal nMontoPrepago,
                                                    DateTime dFechaDesembolso, ref decimal nRestoPrepago)
        {
            clsPlanPago planPagoPagados = new clsPlanPago();
            clsCuota cuotaDifIntFecha = null;
            clsCuota cuotaPrePago = planPagos.Where(x => clsVarGlobal.dFecSystem.Date <= x.dFechaProg)
                                             .OrderBy(x => x.idCuota).First();
            clsCuota cuotaPagar = (clsCuota) cuotaPrePago.Clone();
            clsCuota cuotaAnterior = planPagos.FirstOrDefault(x => x.idCuota == cuotaPrePago.idCuota - 1);
            decimal nSaldoInteres = planPagos.Sum(x => x.nInteresFechaSaldo);
            decimal nSaldoOtros = planPagos.Where(x => x.dFechaProg.Date <= cuotaPrePago.dFechaProg.Date).Sum(x => x.nOtrosSaldo);

            decimal nCapitalAdelantado =
                planPagos.Where(x => x.idCuota >= cuotaPrePago.idCuota).Sum(x => x.nCapitalPagado);
            decimal nInteresAdelantado =
                planPagos.Where(x => x.idCuota >= cuotaPrePago.idCuota).Sum(x => x.nInteresPagado);

            cuotaPagar.dFechaProg = clsVarGlobal.dFecSystem.Date;
            cuotaPagar.dFechaPago = clsVarGlobal.dFecSystem.Date;
            cuotaPagar.nNumDiaCuota = (clsVarGlobal.dFecSystem.Date -
                                       (cuotaAnterior == null
                                            ? dFechaDesembolso.Date
                                            : cuotaAnterior.dFechaProg.Date)).Days;
            cuotaPagar.lCuotaPrepago = true;
            cuotaPagar.nAtrasoCuota = 0;
            cuotaPagar.idModPagoCre = 4;
            cuotaPagar.idEstadocuota = 2;

            if (nSaldoOtros > 0)
            {
            cuotaPagar.nOtros = nSaldoOtros;
            cuotaPagar.nOtrosPagado = cuotaPagar.nOtros;
            }
            else 
            {
                cuotaPagar.nOtrosPagado = cuotaPagar.nOtros;
            }

            /*
            
            */

            cuotaPagar.nInteres = nSaldoInteres >= 0 ? nSaldoInteres + nInteresAdelantado : cuotaPagar.nInteresFecha;

            cuotaPagar.nInteresPagado = cuotaPagar.nInteres;
            cuotaPagar.nInteresFecha = cuotaPagar.nInteres;

            cuotaPagar.nCapital = nMontoPrepago + nCapitalAdelantado -
                                  (nSaldoInteres >= 0 ? nSaldoInteres : 0) - nSaldoOtros;
            cuotaPagar.nCapitalPagado = cuotaPagar.nCapital;
            cuotaPagar.nMonCuota = cuotaPagar.nCapital + cuotaPagar.nInteres + cuotaPagar.nOtros;

            GastosCuotaPrePago = DistribuirGastosPrePago((clsPlanPago)planPagos.Clone(), cuotaPrePago);

            if ( nSaldoInteres < 0 )
            {
                cuotaDifIntFecha = (clsCuota) cuotaPrePago.Clone();

                cuotaDifIntFecha.idCuota = cuotaPagar.idCuota + 1;
                cuotaDifIntFecha.nCapital = -1 * nSaldoInteres;
                cuotaDifIntFecha.nCapitalPagado = -1 * nSaldoInteres;
                cuotaDifIntFecha.nInteres = 0m;
                cuotaDifIntFecha.nInteresPagado = 0m;
                cuotaDifIntFecha.nInteresFecha = 0m;
                cuotaDifIntFecha.dFechaProg = clsVarGlobal.dFecSystem.Date;
                cuotaDifIntFecha.dFechaPago = clsVarGlobal.dFecSystem.Date;

                cuotaDifIntFecha.nOtros = 0;
                cuotaDifIntFecha.nOtrosPagado = 0;

                cuotaDifIntFecha.nAtrasoCuota = 0;
                cuotaDifIntFecha.nNumDiaCuota = 0;
                cuotaDifIntFecha.idModPagoCre = 4;
                cuotaDifIntFecha.idEstadocuota = 2;
                cuotaDifIntFecha.lDiferido = true;
                cuotaDifIntFecha.nSaldoCapital = cuotaPagar.nSaldoCapital - cuotaPagar.nCapital;

                //cuotaDifIntFecha.nMonCuota = cuotaPagar.nCapital + cuotaPagar.nInteres + cuotaPagar.nOtros;
                cuotaDifIntFecha.nMonCuota = cuotaDifIntFecha.nCapital + cuotaDifIntFecha.nInteres + cuotaDifIntFecha.nOtros;
            }

            planPagoPagados.AddRange(planPagos.Where(x => x.idCuota < cuotaPrePago.idCuota).ToList());
            planPagoPagados.Add(cuotaPagar);

            if ( cuotaDifIntFecha != null )
            {
                planPagoPagados.Add(cuotaDifIntFecha);
            }

            nRestoPrepago -= nSaldoOtros;
            nRestoPrepago -= (nSaldoInteres > 0) ? nSaldoInteres : 0;

            return planPagoPagados;
        }

        public clsPlanPago CronogramaPagoPrePago(clsCuota cuotaPrePago, int idCuotaIni, DataTable dtGastosPagados, int nNumeroCuotas, bool lUnicuota, clsSolicitudCreditoCargaSeguro _objSolCargaSeguros = null, bool lAplicaNuevoMultirriesgo = true)
        {
            int idCuotaInicial = idCuotaIni;
            clsPlanPago planPagoNuevo = new clsPlanPago();
            clsCNPlanPago objCnPlanPago = new clsCNPlanPago();
            DataTable dtCuotasDobles = new DataTable();
            DataTable dtPlanPagos = new DataTable();

            switch (TipoPrepago)
            {
                case TipoPrepago.Cuota:
                    {
                        int nDiasGracia;
                        int nNumCuotasGracia;
                        if (IdTipoPeriodo == 1)
                        {
                            nDiasGracia = 0;
                            nNumCuotasGracia = 0;
                        }
                        else
                        {
                            if (lUnicuota) // para el caso de unicoutas
                            {
                                nDiasGracia = 0;
                                nNumCuotasGracia = NumCuotasGracia;
                                PlazoCuota = (FecPrimeraCuota - FechaDesembolso).Days;
                            }
                            else
                            {
                                nDiasGracia = (FecPrimeraCuota.Date - clsVarGlobal.dFecSystem.Date).Days - PlazoCuota;
                                nNumCuotasGracia = NumCuotasGracia;
                            }
                        }

                        dtPlanPagos = objCnPlanPago.CalculaPpgCuotasConstantes2(MontoCalculo, Tasa, FechaDesembolso,
                                                                                NumCuotas, nDiasGracia, IdTipoPeriodo,
                                                                                PlazoCuota, IdSolicitud, ConfigGastos,
                                                                                IdMoneda, dtCuotasDobles,
                                                                                FecPrimeraCuota, 0, CapitalMaxCobSeg,
                                                                                nNumCuotasGracia, true, 0, _objSolCargaSeguros, lAplicaNuevoMultirriesgo, true);
                        MontoCuotaNuevo = objCnPlanPago.nMontoCuota;
                    }
                    break;
                case TipoPrepago.Plazo:
                    {
                        DateTime dFecDesemb = clsVarGlobal.dFecSystem.Date;
                        int nDiasGracia = (FecPrimeraCuota - clsVarGlobal.dFecSystem.Date).Days - PlazoCuota;

                        dtPlanPagos = objCnPlanPago.CalculaPpgDesdeCuota(MontoCuota, MontoCalculo, Tasa,
                                                                         dFecDesemb, nDiasGracia, IdTipoPeriodo,
                                                                         PlazoCuota, IdSolicitud, 0, 0, FecPrimeraCuota,
                                                                         ConfigGastos, CapitalMaxCobSeg, true, _objSolCargaSeguros, lAplicaNuevoMultirriesgo, true);
                        MontoCuotaNuevo = MontoCuota;
                    }
                    break;
            }

            DateTime dFechaPrimeraCuota = dtPlanPagos.AsEnumerable().First().Field<DateTime>("fecha");
            objCnPlanPago.ObjCargaGastosCred.AgregarGastosManualesCuenta(dtPlanPagos, dFechaPrimeraCuota);

            const AplicaCuota aplicaCuota = AplicaCuota.CuotaEspecifica;
            DataTable dtCuotas = new DataTable();
            dtCuotas.Columns.Add("cuota");
            dtCuotas.Columns.Add("fecha");

            DataRow drCuota = dtCuotas.NewRow();
            drCuota["cuota"] = 0;
            drCuota["fecha"] = clsVarGlobal.dFecSystem.Date;
            dtCuotas.Rows.Add(drCuota);

            foreach (DataRow gastosPagado in dtGastosPagados.Rows)
            {
                TipoGasto tipoGasto = new TipoGasto()
                {
                    IdTipoGasto = gastosPagado.Field<int>("idAplicaConc")
                };
                clsGasto objGasto = new clsGasto(objCnPlanPago.ObjCargaGastosCred.GetCreditoGasto())
                                    {
                                        Cuota = drCuota,
                                        ConceptoAplicaGasto = ConceptoAplicaGasto.MontoPrestamo,
                                        nValor = gastosPagado.Field<decimal>("nGasto"),
                                        TipoGasto = tipoGasto,
                                        TipoValorGasto = TipoValorGasto.Fijo,
                                        AplicaCuota = aplicaCuota,
                                        idCargaGasto = gastosPagado.Field<int>("idCargaGasto")
                                        
                                    };
                objCnPlanPago.ObjCargaGastosCred.ListGastos.Add(objGasto);
            }

            idCuotaInicial = idCuotaInicial + 1;

            foreach ( DataRow item in dtPlanPagos.Rows )
            {
                clsCuota cuotaAnt = planPagoNuevo.FirstOrDefault(x => x.idCuota == idCuotaInicial - 1);
                clsCuota objCuota = new clsCuota
                                    {
                                        idCuota = idCuotaInicial++,
                                        dFechaProg = Convert.ToDateTime(item["fecha"]),
                                        nCapital = Convert.ToDecimal(item["capital"]),
                                        nInteres = Convert.ToDecimal(item["interes"]),
                                        nIntComp = 0,
                                        nOtros = Convert.ToDecimal(item["comisiones"]),
                                        nOtrosSinSeg = 0,
                                        nMora = 0,
                                        idEstadocuota = 1,
                                        idTipoCuota = cuotaPrePago.idTipoCuota,
                                        idCuenta = cuotaPrePago.idCuenta,
                                        idPlanPago = cuotaPrePago.idPlanPago + 1,
                                        idModPagoCre = 0
                                    };
                objCuota.nNumDiaCuota =
                    (objCuota.dFechaProg.Date - (cuotaAnt == null ? FechaDesembolso : cuotaAnt.dFechaProg.Date)).Days;
                objCuota.nAtrasoCuota = (clsVarGlobal.dFecSystem.Date - objCuota.dFechaProg.Date).Days;
                
                objCuota.nMonCuota = objCuota.nCapital + objCuota.nInteres + objCuota.nOtros;

                if ( cuotaAnt != null )
                {
                    objCuota.nSaldoCapital = cuotaAnt.nSaldoCapital - cuotaAnt.nCapital;
                }
                else
                {
                    objCuota.nSaldoCapital = Convert.ToDecimal(item["sal_cap"]);
                }
                planPagoNuevo.Add(objCuota);
            }

            idCuotaInicial = idCuotaIni;
            DataTable dtGastos = objCnPlanPago.GetdtGastos();
            foreach ( DataRow row in dtGastos.Rows )
            {
                row["idCuota"] = row.Field<int>("idCuota") + idCuotaInicial;
                row["idCuenta"] = IdCuenta;
                row["idPlanPagos"] = cuotaPrePago.idPlanPago + 1;
            }

            GastosPlanPagos = dtGastos;

            return planPagoNuevo;
        }

        public clsPlanPago CronogramaPrePagoCuotasLibres(clsPlanPago planPago, clsCuota cuotaPrePago, int idCuotaIni, DataTable dtGastosPagados, int nNumeroCuotas, clsSolicitudCreditoCargaSeguro objSolCargaSeguros = null, bool lAplicaNuevoMultirriesgo = true)
        {
            int idCuotaInicial = idCuotaIni;
            clsPlanPago planPagoNuevo = new clsPlanPago();
            clsCNPlanPago objCnPlanPago = new clsCNPlanPago();
            DataTable dtCuotasDobles = new DataTable();
            DataTable dtPlanPagos = new DataTable();

            dtPlanPagos = objCnPlanPago.CalcularCuotasLibresEvalRural(NumCuotas, MontoCalculo, FechaDesembolso, IdSolicitud, Tasa, FecPrimeraCuota,
            ConfigGastos, CapitalMaxCobSeg, 2, planPago, true, objSolCargaSeguros, lAplicaNuevoMultirriesgo);

            MontoCuotaNuevo = 0m;

            DateTime dFechaPrimeraCuota = dtPlanPagos.AsEnumerable().First().Field<DateTime>("fecha");
            objCnPlanPago.ObjCargaGastosCred.AgregarGastosManualesCuenta(dtPlanPagos, dFechaPrimeraCuota);

            const AplicaCuota aplicaCuota = AplicaCuota.CuotaEspecifica;
            DataTable dtCuotas = new DataTable();
            dtCuotas.Columns.Add("cuota");
            dtCuotas.Columns.Add("fecha");

            DataRow drCuota = dtCuotas.NewRow();
            drCuota["cuota"] = 0;
            drCuota["fecha"] = clsVarGlobal.dFecSystem.Date;
            dtCuotas.Rows.Add(drCuota);

            foreach (DataRow gastosPagado in dtGastosPagados.Rows)
            {
                TipoGasto tipoGasto = new TipoGasto()
                {
                    IdTipoGasto = gastosPagado.Field<int>("idAplicaConc")
                };
                clsGasto objGasto = new clsGasto(objCnPlanPago.ObjCargaGastosCred.GetCreditoGasto())
                {
                    Cuota = drCuota,
                    ConceptoAplicaGasto = ConceptoAplicaGasto.MontoPrestamo,
                    nValor = gastosPagado.Field<decimal>("nGasto"),
                    TipoGasto = tipoGasto,
                    TipoValorGasto = TipoValorGasto.Fijo,
                    AplicaCuota = aplicaCuota,
                    idCargaGasto = gastosPagado.Field<int>("idCargaGasto")

                };
                objCnPlanPago.ObjCargaGastosCred.ListGastos.Add(objGasto);
            }

            idCuotaInicial = idCuotaInicial + 1;

            foreach (DataRow item in dtPlanPagos.Rows)
            {
                clsCuota cuotaAnt = planPagoNuevo.FirstOrDefault(x => x.idCuota == idCuotaInicial - 1);
                clsCuota objCuota = new clsCuota
                {
                    idCuota = idCuotaInicial++,
                    dFechaProg = Convert.ToDateTime(item["fecha"]),
                    nCapital = Convert.ToDecimal(item["capital"]),
                    nInteres = Convert.ToDecimal(item["interes"]),
                    nIntComp = 0,
                    nOtros = Convert.ToDecimal(item["comisiones"]),
                    nOtrosSinSeg = 0,
                    nMora = 0,
                    idEstadocuota = 1,
                    idTipoCuota = cuotaPrePago.idTipoCuota,
                    idCuenta = cuotaPrePago.idCuenta,
                    idPlanPago = cuotaPrePago.idPlanPago + 1,
                    idModPagoCre = 0
                };
                objCuota.nNumDiaCuota =
                    (objCuota.dFechaProg.Date - (cuotaAnt == null ? FechaDesembolso : cuotaAnt.dFechaProg.Date)).Days;
                objCuota.nAtrasoCuota = (clsVarGlobal.dFecSystem.Date - objCuota.dFechaProg.Date).Days;

                objCuota.nMonCuota = objCuota.nCapital + objCuota.nInteres + objCuota.nOtros;

                if (cuotaAnt != null)
                {
                    objCuota.nSaldoCapital = cuotaAnt.nSaldoCapital - cuotaAnt.nCapital;
                }
                else
                {
                    objCuota.nSaldoCapital = Convert.ToDecimal(item["sal_cap"]);
                }
                planPagoNuevo.Add(objCuota);
            }

            idCuotaInicial = idCuotaIni;
            DataTable dtGastos = objCnPlanPago.GetdtGastos();
            foreach (DataRow row in dtGastos.Rows)
            {
                row["idCuota"] = row.Field<int>("idCuota") + idCuotaInicial;
                row["idCuenta"] = IdCuenta;
                row["idPlanPagos"] = cuotaPrePago.idPlanPago + 1;
            }

            GastosPlanPagos = dtGastos;

            return planPagoNuevo;
        }

        public DataTable DistribuirGastosPrePago(List<clsCuota> planPagos, clsCuota cuotaPrePago)
        {
            List<clsCuota> cuotasConSaldoOtros = planPagos.Where(x => x.dFechaProg.Date <= cuotaPrePago.dFechaProg.Date
                                                            && x.nOtrosSaldo > 0).ToList();

            cuotasConSaldoOtros.ForEach(x=>
                                        {
                                            x.nOtros = x.nOtrosSaldo;
                                            x.nOtrosPagado = x.nOtros;
                                        });

            DataTable dtPlanPagos = ConvertToDataTable(cuotasConSaldoOtros);

            DataTable dtDetGastos = new clsCNPlanPago().DistribuirGastosPagados(dtPlanPagos);

            foreach ( DataRow gasto in dtDetGastos.Rows )
            {
                gasto["nIdNumCuota"] = cuotaPrePago.idCuota;
            }

            return dtDetGastos;
        }

        private static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            string name;

            foreach (PropertyDescriptor prop in properties)
            {
                name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                name = (name == "idEstadocuota" ? "idEstadoCuota" : name);
                Type type = (prop.Name == "dFechaPago" ? typeof(DateTime) : Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                table.Columns.Add(name, type);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                    row[name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

    }

    public enum TipoPrepago
    {
        Plazo = 1,
        Cuota = 2
    }
}
