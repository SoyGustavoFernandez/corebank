using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsObsAprobadorGrupoSol
    {
        public int idObsAprobadorGrupoSol { get; set; }
        public int idEvalCredGrupoSol { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idUsuReg { get; set; }
        public int idNivelAproReg { get; set; }
        public int idTipObservacion { get; set; }
        public string cTipObservacion { get; set; }
        public string cObservacion { get; set; }
        public int idGrupoObs { get; set; }
        public bool lSubsanado { get; set; }
        public DateTime dFechaHrReg { get; set; }
        public bool lVigente { get; set; }
    }
}
