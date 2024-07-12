using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsResumenAprobacion
    {
        public string cTipoAprobacion { get; set; }
        public string cTipoEntrega { get; set; }
        public int nEntregas { get; set; }
        public int nOrden { get; set; }
        public int idEntrega { get; set; }
        public int cEstado { get; set; }
        public int idEtapa { get; set; }
    }
}
