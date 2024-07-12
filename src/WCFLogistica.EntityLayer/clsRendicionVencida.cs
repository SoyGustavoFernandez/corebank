using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsRendicionVencida
    {
        public int idEntrega { get; set; }
        public int idTipoEntrega { get; set; }
        public string cNombre { get; set; }
        public string cCargo { get; set; }
        public string cTipoEntrega { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public int nDiasAtraso { get; set; }

        public int nEntregas { get; set; }
    }
}
