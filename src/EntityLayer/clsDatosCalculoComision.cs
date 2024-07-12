using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDatosCalculoComision
    {
        public decimal nMontoTotal { get; set; }

        public decimal nComision { get; set; }

        public decimal nRedondeo { get; set; }

        public decimal nITF { get; set; }

        public decimal nMontoGiro { get; set; }

        public clsTarifarioGiros objTarifario { get; set; }
    }
}
