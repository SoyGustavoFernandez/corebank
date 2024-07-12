using System;
using System.Data;

namespace EntityLayer
{
    [Serializable]
    public class clsCreditoGasto
    {
        public int Id { get; set; }
        public int IdPlanPagos { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public decimal nMontoDesembolso { get; set; }
        public int nNumCuotas { get; set; }
        public decimal nCapitalMaxCobSeg { get; set; }
        

    }
    [Serializable]
    public class clsGasto
    {
        public int idCuota
        {
            get
            {
                int idCuota = 0;
                if (Cuota != null && Cuota.Table.Columns.Contains("cuota"))
                {
                    idCuota = Convert.ToInt16(Cuota["cuota"]);
                }
                return idCuota;
            }
        }
        public int idCargaGasto { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public TipoValorGasto TipoValorGasto { get; set; }
        public ConceptoAplicaGasto ConceptoAplicaGasto { get; set; }
        public AplicaCuota AplicaCuota { get; set; }
        public decimal nValor { get; set; }
        public decimal nValorConcepto
        {
            get
            {
                decimal valorConcepto = 0m;
                if (Cuota == null) 
                    return valorConcepto;

                switch (ConceptoAplicaGasto)
                {
                    case ConceptoAplicaGasto.SaldoCapital:
                        if (Cuota.Table.Columns.Contains("sal_cap"))
                        {
                            valorConcepto = Cuota.Field<decimal>("sal_cap");
                        }
                        break;
                    case ConceptoAplicaGasto.Capital:
                        if (Cuota.Table.Columns.Contains("capital"))
                        {
                            valorConcepto = Cuota.Field<decimal>("capital");
                        }
                        break;
                    case ConceptoAplicaGasto.CuotaCapitalMasInteres:
                        if (Cuota.Table.Columns.Contains("capital") && 
                                Cuota.Table.Columns.Contains("interes"))
                        {
                            valorConcepto = Cuota.Field<decimal>("capital") + 
                                            Cuota.Field<decimal>("interes");
                        }
                        break;
                    case ConceptoAplicaGasto.MontoPrestamo:
                        valorConcepto = CreditoGasto.nMontoDesembolso;
                        break;
                }
                if (TipoGasto.IdTipoGasto == 10 && valorConcepto >= CreditoGasto.nCapitalMaxCobSeg)
                {
                    valorConcepto = CreditoGasto.nCapitalMaxCobSeg;
                }
                return valorConcepto;
            }
        } 
        public DataRow Cuota { get; set; }
        public DataRow CuotaAnt { get; set; }
        public int nDias
        {
            get
            {
                int nDiasCalc = (dFechaFin.Date - dFechaIni.Date).Days;
                if (TipoGasto.IdTipoGasto == 10)
                    nDiasCalc = GetNumCierres();
                return nDiasCalc;
            }
        }
        public decimal nTasaDiaria
        {
            get
            {
                decimal nTasa;
                switch (TipoValorGasto)
                {
                    case TipoValorGasto.Fijo:
                        nTasa = 1;
                        break;
                    case TipoValorGasto.PorcentualSimple:
                        nTasa = nValor / 30.00m;
                        break;
                    case TipoValorGasto.PorcentualCompuesto:
                        nTasa = (decimal)Math.Pow(1 + (double)nValor / 100.00, 1.00 / 30.00) - 1;
                        break;
                    default:
                        nTasa = 1;
                        break;
                }
                if (TipoGasto.IdTipoGasto == 10)
                {
                    nTasa =  nValor;
                }
                return nTasa;
            }
        }
        public decimal nGasto
        {
            get
            {
                decimal nGastoCalc;
                switch (TipoValorGasto)
                {
                    case TipoValorGasto.Fijo:
                        nGastoCalc = nValor;
                        break;
                    case TipoValorGasto.PorcentualSimple:
                        nGastoCalc = nValorConcepto * nTasaDiaria * nDias / 100.00m;
                        break;
                    case TipoValorGasto.PorcentualCompuesto:
                        nGastoCalc = nValorConcepto * ((decimal)Math.Pow(1 + (double)(nTasaDiaria / 100.00m), nDias) - 1);
                        break;
                    default:
                        nGastoCalc = nValor;
                        break;
                }
                return Math.Round(nGastoCalc,2);
            }
        }
        public DateTime dFechaIni
        {
            get
            {
                DateTime dFecha = DateTime.Now.Date;
                if (CuotaAnt == null || idCuota == 1)
                {
                    dFecha = CreditoGasto.dFechaDesembolso;
                }
                else
                {
                    if (CuotaAnt.Table.Columns.Contains("fecha"))
                    {
                        dFecha = CuotaAnt.Field<DateTime>("fecha");
                    }
                }
                return dFecha;
            }
        }
        public DateTime dFechaFin
        {
            get
            {
                DateTime dFecha = DateTime.Now.Date;
                if (Cuota != null && Cuota.Table.Columns.Contains("fecha"))
                {
                    dFecha = Cuota.Field<DateTime>("fecha");
                }
                return dFecha;
            }
        }
        public bool lCargaManual { get; set; }
        public clsCreditoGasto CreditoGasto { get; private set; }
        public clsGasto(clsCreditoGasto creditoGasto)
        {
            CreditoGasto = creditoGasto;
        }
        private int GetNumCierres()
        {
            return (dFechaFin.Year - dFechaIni.Year) * 12 + (dFechaFin.Month - dFechaIni.Month);
        }

    }

    [Serializable]
    public struct TipoGasto
    {
        public int IdTipoGasto { get; set; }
        public string cTipoGasto { get; set; }
    }

    public enum ConceptoAplicaGasto
    {
        SaldoCapital = 1,
        Capital = 4,
        CuotaCapitalMasInteres = 7,
        MontoPrestamo = 8
    }

    public enum TipoValorGasto
    {
        Fijo = 1,
        PorcentualSimple = 2,
        PorcentualCompuesto = 3
    }

    public enum AplicaCuota
    {
        PrimeraCuota = 1,
        UltimaCuota = 2,
        TodasLasCuotas = 3,
        CuotaEspecifica = 4
    }

}
