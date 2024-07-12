using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSeguroComplementario
    {
        public int idSeguro { get; set; }
        public string cSeguro { get; set; }
        public string cSeguroCorto { get; set; }
        public decimal nPrecio { get; set; }
        public bool nSeguroComplementario { get; set; }
        public bool lVigente { get; set; }
        public bool lSelecciona { get; set; }
        public int  nOrden { get; set; }

    }
}
