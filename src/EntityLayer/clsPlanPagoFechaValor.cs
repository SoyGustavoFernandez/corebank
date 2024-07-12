using System;

namespace EntityLayer
{
    public class clsPlanPagoFechaValor
    {
        public bool lSeleccionado { get; set; }
        public int idCuota { get; set; }
        public int idCanal { get; set; }
        public string cCanal { get; set; }
        public int nCodigoCliente { get; set; }
        public string cDNI { get; set; }
        public long nNumeroCredito { get; set; }
        public DateTime dFechaPagoCanalExterno { get; set; }
        public long nNumeroOperacionCanalExterno { get; set; }
        public string cMoneda { get; set; }
        public string cOficinaEOB { get; set; }
        public string cNombre { get; set; }
        public string cDireccion { get; set; }
        public DateTime dFechaPagoCronograma { get; set; }
        public DateTime dFechaValorizacion { get; set; }
        public decimal nMontoCuotaCronograma { get; set; }
        public decimal nMontoCuotaFechaActual { get; set; }
        public int nDiasAtraso { get; set; }
        public decimal nCapital { get; set; }
        public decimal nInteresProgramado { get; set; }
        public decimal nInteresCompensatorio { get; set; }
        public decimal nInteresMoratorio { get; set; }
        public decimal nInteresMoratorioFechaValor { get; set; }
        public decimal nInteresDevengado { get; set; }
        public decimal nOtros { get; set; }
        public decimal nOtrosFechaValor { get; set; }
        public decimal nSaldoTotal { get; set; }
        public decimal nMontoPagarFechaValor { get; set; }
        public string cEstadoPago { get; set; }
        public long idKardex { get; set; }
    }
}