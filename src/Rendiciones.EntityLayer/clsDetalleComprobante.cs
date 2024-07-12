using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsDetalleComprobante
    {
        public int idDetalleComprobante { get; set; }
        public int idComprobantePago { get; set; }
        public int idComprobantePagoTmp { get; set; }
        public int idConceptoComprobante { get; set; }
        public decimal nSubtotalImporte { get; set; }
        public decimal nIgvImporte { get; set; }
        public decimal nMontoImporte { get; set; }
        public decimal nMontoDetraccion { get; set; }
        public bool lVigente { get; set; }
        //public decimal? nCredFiscalImporte { get; set; }
        public decimal nCuartaCategImporte { get; set; }
        public decimal nOtrosImporte { get; set; }
        public int? idAgencia { get; set; }
        public int IdCentroCosto { get; set; }
        public int idEstablecimiento { get; set; }
        public int idProyecto { get; set; }
    }
}
