using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsReferenciaEval
    {
        public int idReferenciaEval { get; set; }
        public int idEvalCred { get; set; }
        public int idTipReferEval { get; set; }
        public int idTipVinculoEval { get; set; }
        public string cConcepto { get; set; }
        public string cDireccion { get; set; }
        public string cNumeroCelular { get; set; }
        public int nEstado { get; set; }
        public string cComentarios { get; set; }
        public string cVinculo { get; set; }
        public bool lVigente { get; set; }
    }
}
