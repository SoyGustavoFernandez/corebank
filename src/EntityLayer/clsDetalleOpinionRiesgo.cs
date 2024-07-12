using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetalleOpinionRiesgo
    {
        public int idSolInfRiesgo { get; set; }
        public int idSolCre { get; set; }
        public int idRegla { get; set; }
        public string cMotivo { get; set; }
        public bool lAtendido { get; set; }
        public bool lVigente { get; set; }
    }
}
