using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDisenioCredito
    {
        public int idDisCred { get; set; }
        public int  nCuota { get; set; }
        public DateTime? dFecha { get; set; }
        public string cMesCuota { get; set; }
        public int nDiaDesembolso { get; set; }
        public decimal nMontoCuota { get; set; }
        public decimal nCapIntSeg { get; set; }
        public decimal nExedenteFinal { get; set; }
    }
}
