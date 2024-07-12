using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOtrosIngresosEvalRuralD
    {
        public Guid idOtrIngD { get; set; }
        public Guid idOtrIngM { get; set; }
        public string dFechaCuota { get; set; }
        public int nFechaCuota { get; set; }
        public int nItem { get; set; }
        public int nOrden { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nPrecioUnitario { get; set; }
        public decimal nTotal { get; set; }
    }
}
