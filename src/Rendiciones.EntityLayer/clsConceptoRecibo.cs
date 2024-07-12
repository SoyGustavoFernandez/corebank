using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsConceptoRecibo
    {
        public int idConcepto { get; set; }
        public string cConcepto { get; set; }
        public string cTipMonto { get; set; }
        public decimal nMontoCon { get; set; }
        public int nAfectoITF { get; set; }
        public int nIndSoloPer { get; set; }
        public bool lAfectaCaja { get; set; }
    }
}
