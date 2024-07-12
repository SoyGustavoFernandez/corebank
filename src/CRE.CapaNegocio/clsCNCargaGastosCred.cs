using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CRE.AccesoDatos;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNCargaGastosCred
    {
        clsADCargaGastosCred objCargaGastosCred = new clsADCargaGastosCred();
        public IList<clsGasto> ListGastos { get; set; }

        public DataTable dtGatosOptativos = new DataTable();
        public decimal nGastosCouta = 0;
        public bool EsRetecion = false;
        public DataTable dtGastos
        {
            get { return GetGastos(); }
        }

        private readonly DataTable _dtConfigGasto;
        private readonly clsCreditoGasto _creditoGasto;

        public clsCNCargaGastosCred() { }

        public clsCNCargaGastosCred(DataTable dtConfigGasto,clsCreditoGasto creditoGasto)
        {
            ListGastos = new List<clsGasto>();
            _dtConfigGasto = dtConfigGasto;
            _creditoGasto = creditoGasto;
        }

        public void CargarGastoCuotaConstantes(DataRow cuota, DataRow cuotaAnt)
        {
            var filterGastos = _dtConfigGasto.AsEnumerable()
                .Where(x => x.Field<bool>("lObligatorio")
                            && x.Field<int>("nIdTipoValor").In(2, 3)
                            && x.Field<int>("nIdAplicaConcepto") == 1).ToList();

            AddGasto(cuota, cuotaAnt, filterGastos);
        }

        public void CargarGastoCuotaNoConstantes(DataRow cuota, DataRow cuotaAnt)
        {
            var filterGastos = _dtConfigGasto.AsEnumerable()
                .Where(x => x.Field<bool>("lObligatorio")
                            && !(x.Field<int>("nIdTipoValor").In(2, 3)
                            && x.Field<int>("nIdAplicaConcepto") == 1)).ToList();

            AddGasto(cuota,cuotaAnt,filterGastos);
        }

        public void iniciaDTSegurosOptativos()
        {
            dtGatosOptativos = null;
            dtGatosOptativos = new DataTable();
            
            dtGatosOptativos.Columns.Add("idSolicitud", typeof(int));
            dtGatosOptativos.Columns.Add("idPlanPagos", typeof(int));
            dtGatosOptativos.Columns.Add("idCuota", typeof(int));
            dtGatosOptativos.Columns.Add("nGasto", typeof(decimal));
            dtGatosOptativos.Columns.Add("nGastoIncSeg", typeof(decimal));
            dtGatosOptativos.Columns.Add("nValor", typeof(decimal));
            dtGatosOptativos.Columns.Add("idTipoGasto", typeof(int));
            dtGatosOptativos.Columns.Add("idTipoValor", typeof(int));
            dtGatosOptativos.Columns.Add("idAplicaConc", typeof(int));
            dtGatosOptativos.Columns.Add("lVigente", typeof(bool));
            dtGatosOptativos.Columns.Add("idCuenta", typeof(int));
            dtGatosOptativos.Columns.Add("lCargaManual", typeof(bool));
            dtGatosOptativos.Columns.Add("idCargaGasto", typeof(int));
        }

        public void CargarSegurosOptativos(clsSolicitudCreditoCargaSeguro objSolCargaSeguro, DataRow drCuotaAct, DataRow drCuotaAnt, 
                                            bool lAplicaNuevoMultirriesgo, IEnumerable<clsPaqueteSeguro> lstPlanesSegurosPermitidos, bool lEsPrePago = false)
        {
            var lstSegurosOptativos = objSolCargaSeguro.lstSolicitudCreditoSeguro.Where(x => x.lSeleccionado && x.lPagoCuotas).ToList();

            var objPaqueteSeguro = (lstPlanesSegurosPermitidos.Count() > 0) ? 
                                    lstPlanesSegurosPermitidos.FirstOrDefault(p => lstSegurosOptativos.Any(x => x.idTipoSeguro == p.idTipoSeguro)) : null;

            if (lstSegurosOptativos.Count <= 0)
                return;

            foreach (var item in lstSegurosOptativos)
            {
                bool lSeguroMultiriesgo = (item.idTipoSeguro == 1 && lAplicaNuevoMultirriesgo);

                if (!lAplicaNuevoMultirriesgo && item.idTipoSeguro == 1)
                    continue;

                if (!lSeguroMultiriesgo && item.idTipoSeguro != objPaqueteSeguro.idTipoSeguro)
                    continue;

                decimal nPrimaDiaria = (item.idTipoValor == 1) ? (item.nValor * item.nMontoCobertura / 30) : //Porcentual
                                       (item.nValor / 30); //Monto Fijo

                var idTipoPeriodoCredito = objSolCargaSeguro.idTipoPlazo;
                int idCuota = drCuotaAct.Field<int>("cuota");
                int nDiasPlazoReal = 0;

                DateTime dFechaDesde = idCuota == 1 ? objSolCargaSeguro.dFechaDesembolso : drCuotaAnt.Field<DateTime>("fecha");
                DateTime dFechaHasta = idCuota == 1 ? objSolCargaSeguro.dFechaPrimeraCuota : drCuotaAct.Field<DateTime>("fecha");

                if (idTipoPeriodoCredito == (int)TipoPeriodo.FechaFija)
                {
                    if (idCuota == 1)
                    {
                        int nDia = dFechaDesde.Day;
                        int nMes = dFechaDesde.Month + 1;
                        int nAnio = dFechaDesde.Year;
                        if (nMes > 12) { nAnio++; nMes = 1;}
                        int nUltimoDiaMes = DateTime.DaysInMonth(nAnio, nMes);
                        if (nDia > nUltimoDiaMes) nDia = nUltimoDiaMes;

                        DateTime dFechaHastaTemp = new DateTime(nAnio, nMes, nDia);
                        int nDiasGracia = (dFechaHasta - dFechaHastaTemp).Days;
                        nDiasGracia = (nDiasGracia < 0) ? 0 : nDiasGracia;

                        int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaHastaTemp).Days / 30m));
                        nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;

                                nDiasPlazoReal = (lEsPrePago) ? (dFechaHasta - dFechaDesde).Days : nDiasPlazoReal + nDiasGracia;

                                if(nDiasPlazoReal < 0) 
                                {
                                    nDiasPlazoReal = 30;
                                }                            
                                else
                                {
                                    nDiasPlazoReal = 30;
                                }
                        
                    }
                    else
                    {
                        int nCuotas = Convert.ToInt32(Math.Round((dFechaHasta - dFechaDesde).Days / 30m));
                        nDiasPlazoReal = (nCuotas > 0) ? nCuotas * 30 : 30;
                        if (nDiasPlazoReal < Convert.ToInt32(objSolCargaSeguro.nPlazo)) 
                        { 
                            nDiasPlazoReal = Convert.ToInt32(objSolCargaSeguro.nPlazo);
                        } 
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

                decimal nMontoSeguro = Math.Round(nDiasPlazoReal * nPrimaDiaria, 2);

                var nValor = (item.idTipoValor == 1) ? item.nValor * 100 : item.nValor;

                if (EsRetecion == true) 
                {
                    clsCNPlanPago ObjPlanPagos = new clsCNPlanPago();
                    DataTable dtDetalleGastos = ObjPlanPagos.ListarDetalleGastoXSolicitud(_creditoGasto.Id, item.idConcepto, drCuotaAct.Field<int>("cuota"));
                    if (dtDetalleGastos.Rows.Count > 0) 
                    {
                        nMontoSeguro = Convert.ToDecimal(dtDetalleGastos.Rows[0]["nGasto"]);
                    }
                }

                DataRow drSegOptativo = dtGatosOptativos.NewRow();
                drSegOptativo["idSolicitud"] = _creditoGasto.Id;
                drSegOptativo["idPlanPagos"] = _creditoGasto.IdPlanPagos;
                drSegOptativo["idCuota"] = drCuotaAct.Field<int>("cuota");
                drSegOptativo["nGasto"] = nMontoSeguro;
                drSegOptativo["nGastoIncSeg"] = 0;
                drSegOptativo["nValor"] = nValor;
                drSegOptativo["idTipoGasto"] = item.idConcepto;
                drSegOptativo["idTipoValor"] = 2;
                drSegOptativo["idAplicaConc"] = 1;
                drSegOptativo["lVigente"] = true;
                drSegOptativo["idCuenta"] = _creditoGasto.Id;
                drSegOptativo["lCargaManual"] = 0;
                drSegOptativo["idCargaGasto"] = 0;
                dtGatosOptativos.Rows.Add(drSegOptativo);
            }
        }

        private void AddGasto(DataRow cuota, DataRow cuotaAnt, List<DataRow> filterGastos)
        {
            if (!filterGastos.Any())
                return;

            foreach (DataRow row in filterGastos)
            {
                AplicaCuota aplicaCuota = (AplicaCuota) row.Field<int>("nIdCuota");
                if (aplicaCuota == AplicaCuota.PrimeraCuota && cuota.Field<int>("cuota") != 1)
                    continue;

                if (aplicaCuota == AplicaCuota.UltimaCuota && cuota.Field<int>("cuota") != _creditoGasto.nNumCuotas)
                    continue;

                TipoGasto tipoGasto = new TipoGasto
                {
                    IdTipoGasto = row.Field<int>("nIdTipoGasto"),
                    cTipoGasto = row.Field<string>("cIdTipoGasto")
                };

                ListGastos.Add(new clsGasto(_creditoGasto)
                               {
                                   ConceptoAplicaGasto = (ConceptoAplicaGasto) row.Field<int>("nIdAplicaConcepto"),
                                   Cuota = cuota,
                                   CuotaAnt = cuotaAnt,
                                   nValor = row.Field<decimal>("nValor"),
                                   TipoGasto = tipoGasto,
                                   TipoValorGasto = (TipoValorGasto) row.Field<int>("nIdTipoValor"),
                                   AplicaCuota = aplicaCuota
                               });
            }
        }

        public void AgregarGastosManualesCuenta(DataTable dtPlanPagos, DateTime dFechaPrimeraCuota)
        {
            DataTable dtGastosManuales = objCargaGastosCred.GetGastosManualesCuenta(_creditoGasto.Id);
            dtGastosManuales.Columns["lAplicado"].ReadOnly = false;
            const AplicaCuota aplicaCuota = AplicaCuota.CuotaEspecifica;

            var gastosFilter =
                dtGastosManuales.AsEnumerable().Where(x => x.Field<DateTime>("dFechaProg").Date >= dFechaPrimeraCuota);
            if ( gastosFilter.Any() )
            {
                dtGastosManuales = gastosFilter.CopyToDataTable();
            }
            else
            {
                dtGastosManuales = dtGastosManuales.Clone();
            }

            foreach ( DataRow cuota in dtPlanPagos.Rows )
            {
                DateTime dFechaProg = cuota.Field<DateTime>("fecha");

                foreach ( DataRow row in dtGastosManuales.AsEnumerable()
                                                         .Where(x => !x.Field<bool>("lAplicado"))
                                                         .ToList() )
                {
                    TipoGasto tipoGasto = new TipoGasto
                                          {
                                              IdTipoGasto = row.Field<int>("nIdTipoGasto"),
                                          };

                    if ( row.Field<DateTime>("dFechaProg").Date == dFechaProg.Date )
                    {
                        ListGastos.Add(new clsGasto(_creditoGasto)
                        {
                            Cuota = cuota,
                            ConceptoAplicaGasto = ConceptoAplicaGasto.MontoPrestamo,
                            nValor = row.Field<decimal>("nGasto"),
                            TipoGasto = tipoGasto,
                            TipoValorGasto = TipoValorGasto.Fijo,
                            AplicaCuota = aplicaCuota,
                            lCargaManual = true
                        });
                        row["lAplicado"] = true;
                    }
                }

            }


            foreach ( DataRow row in dtGastosManuales.AsEnumerable()
                                                     .Where(x => !x.Field<bool>("lAplicado")).ToList() )
            {
                TipoGasto tipoGasto = new TipoGasto
                                      {
                                          IdTipoGasto = row.Field<int>("nIdTipoGasto"),
                                      };

                ListGastos.Add(new clsGasto(_creditoGasto)
                {
                    Cuota = GetPrimeraCuota(),
                    ConceptoAplicaGasto = ConceptoAplicaGasto.MontoPrestamo,
                    nValor = row.Field<decimal>("nGasto"),
                    TipoGasto = tipoGasto,
                    TipoValorGasto = TipoValorGasto.Fijo,
                    AplicaCuota = aplicaCuota,
                    lCargaManual = true
                });
            }

            foreach ( DataRow cuota in dtPlanPagos.Rows )
            {
                decimal idCuota = cuota.Field<int>("cuota");
                decimal nCapital = cuota.Field<decimal>("capital");
                decimal nInteres = cuota.Field<decimal>("interes");
                decimal nOtros = ListGastos.Where(x => x.idCuota == idCuota).Sum(x => x.nGasto) +
                                 dtGatosOptativos.Rows.Cast<DataRow>().Where(x => x.Field<int>("idcuota") == idCuota).Sum(x => x.Field<decimal>("nGasto")); ;
                cuota["comisiones"] = nOtros;
                cuota["imp_cuota"] = nCapital + nInteres + nOtros;
            }
        }

        private DataTable GetGastos()
        {
            DataTable dtGastos = new DataTable("TablaDetalleGastosSolicitud");

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
            dtGastos.Columns.Add("lCargaManual", typeof (bool));
            dtGastos.Columns.Add("idCargaGasto", typeof(int));

            foreach (clsGasto gasto in ListGastos)
            {
                DataRow dr = dtGastos.NewRow();

                dr["idSolicitud"] = _creditoGasto.Id;
                dr["idPlanPagos"] = _creditoGasto.IdPlanPagos;
                dr["idCuota"] = gasto.idCuota;
                dr["nGasto"] = gasto.nGasto;
                dr["nGastoIncSeg"] = 0;
                dr["nValor"] = gasto.nValor;
                dr["idTipoGasto"] = gasto.TipoGasto.IdTipoGasto;
                dr["idTipoValor"] = (int)gasto.TipoValorGasto;
                dr["idAplicaConc"] = (int)gasto.ConceptoAplicaGasto;
                dr["lVigente"] = true;
                dr["idCuenta"] = _creditoGasto.Id;
                dr["lCargaManual"] = gasto.lCargaManual;
                dr["idCargaGasto"] = gasto.idCargaGasto;

                dtGastos.Rows.Add(dr);
            }

            foreach (DataRow row in dtGatosOptativos.Rows)
            {
                DataRow dr = dtGastos.NewRow();

                dr["idSolicitud"] = row["idSolicitud"];
                dr["idPlanPagos"] = row["idPlanPagos"];
                dr["idCuota"] = row["idCuota"];
                dr["nGasto"] = row["nGasto"];
                dr["nGastoIncSeg"] = row["nGastoIncSeg"];
                dr["nValor"] = row["nValor"];
                dr["idTipoGasto"] = row["idTipoGasto"];
                dr["idTipoValor"] = row["idTipoValor"];
                dr["idAplicaConc"] = row["idAplicaConc"];
                dr["lVigente"] = row["lVigente"];
                dr["idCuenta"] = row["idCuenta"];
                dr["lCargaManual"] = row["lCargaManual"];
                dr["idCargaGasto"] = row["idCargaGasto"];

                dtGastos.Rows.Add(dr);
            }

            return dtGastos;
        }

        private DataRow GetPrimeraCuota()
        {
            DataTable dtCuotas = new DataTable();
            dtCuotas.Columns.Add("cuota");
            dtCuotas.Columns.Add("fecha");

            DataRow drCuota = dtCuotas.NewRow();
            drCuota["cuota"] = 1;
            drCuota["fecha"] = clsVarGlobal.dFecSystem.Date;

            return drCuota;
        }

        public clsCreditoGasto GetCreditoGasto()
        {
            return _creditoGasto;
        }

        public DataTable listarGastosPorCuenta(int nCuenta)
        {
            return this.objCargaGastosCred.ListarCargaGastosPorCuenta(nCuenta);
        }

        public DataTable ListarOtrosGastosPorCuota(int nCuenta, int nCuota)
        {
            return this.objCargaGastosCred.ListarOtrosGastosPorCuota(nCuenta, nCuota);
        }
    }
}
