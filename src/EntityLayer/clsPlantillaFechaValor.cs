using System;

namespace EntityLayer
{
    public class clsPlantillaFechaValor
    {
        public string cCanal { get; set; }
        public long nNumeroCredito { get; set; }
        public DateTime dFechaValor { get; set; }
        public long nNumeroOperacionCanalExterno { get; set; }
        public decimal nMontoPagado { get; set; }
        public string cDetalleError{ get; set; }
        public bool lError { get; set; }
    }

}