using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPropDesembolso
    {
        public int idPropDesembolso { set; get; }
        public int idMoneda { set; get; }
        public int nCuotas { set; get; }
        public int idTasa { set; get; }
        public decimal nTea { set; get; }
        public int idTipoPeriodo { set; get; }
        public int nPlazoCuota { set; get; }
        public int nPlazo { set; get; }
        public int nCuotasGracia { set; get; }
        public DateTime dFechaDesemProp { set; get; }
        public decimal nMonto { set; get; }
        public decimal nMontoAcumulado { set; get; }
    }
}
