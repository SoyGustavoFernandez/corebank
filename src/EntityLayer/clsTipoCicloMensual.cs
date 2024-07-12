using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTipoCicloMensual
    {
        public int idTipoCicloMensual { get; set; }
        public string cTipoCicloMensual { get; set; }
        public decimal nPorcentaje { get; set; }
        public bool lVigente { get; set; }

        public clsTipoCicloMensual()
        {
            idTipoCicloMensual = 0;
            cTipoCicloMensual = String.Empty;
            nPorcentaje = Decimal.Zero;
            lVigente = false;
        }
    }
}
