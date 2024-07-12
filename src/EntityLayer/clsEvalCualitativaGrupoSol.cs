using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCualitativaGrupoSol
    {
        public int idEvalCualitativaGrupoSol { get; set; }
        public int idItemCualit { get; set; }
        public string cDescripcion { get; set; }
        public string cCriterios { get; set; }
        public string cPuntajes { get; set; }
        public decimal nPuntaje { get; set; }
        public object oPuntaje { get; set; }
        public decimal nComputado { get; set; }
        public bool lAutomatico { get; set; }
    }
}
