using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCalculoDisenioCred
    {
        public int nCuota { get; set; }
        public decimal nMontoCuota { get; set; }
        public DateTime? dFecha { get; set; }
        public decimal nAbonoCapital { get; set; }
        public decimal nAbonoInteres { get; set; }
        public decimal nInteresLapso { get; set; }
        public decimal nInteresVigente { get; set; }
        public decimal nCapital { get; set; }
        public decimal ntotalSeguroDegrav { get; set; }
        public decimal nTotal { get; set; }
        public decimal nExedenteMensual { get; set; }
        public decimal nExedenteFinal { get; set; }
    }
}
