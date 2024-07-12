using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPeriodoCredito
    {
        public int idPeriodoCredito { get; set; }
        public string cPeriodoCredito { get; set; }
        public string cAcronimo { get; set; }
        public int nDias { get; set; }
        public int nDiasMin { get; set; }
        public int nDiasMax { get; set; }

        public clsPeriodoCredito()
        {
            this.idPeriodoCredito = 0;
            this.cPeriodoCredito = string.Empty;
            this.cAcronimo = string.Empty;
            this.nDias = 0;
            this.nDiasMin = 0;
            this.nDiasMax = 0;
        }
    }
}
