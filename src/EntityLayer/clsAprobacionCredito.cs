using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAprobacionCredito
    {
        public string cMensaje{get; set;}
        public int idError{get; set;}
        public int idNivelAprobacion{get; set;}
        public bool lEnviaSolInfRiesgos{get; set;}
        public bool lRevision{get; set;}
        public int idEstadoEvalCred{get; set;}
    }
}
