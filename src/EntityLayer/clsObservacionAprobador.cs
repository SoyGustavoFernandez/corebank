using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsObservacionAprobador
    {
        public int idObsAprobador{get; set;}
        public int idEvalCred{get; set;}
        public int idSolicitud{get; set;}
        public int idEstado { get; set; }
        public int idUsuReg{get; set;}
        public int idTipObservacion{get; set;}
        public string cTipObservacion { get; set; }
        public int idGrupoObs { get; set; }
        public string cObservacion{get; set;}
        public string cComentario { get; set; }
        public bool lSubsanado{get; set;}
        public DateTime dFechaHrReg{get; set;}

        public int idEtapaEvalCred { get; set; }
        public bool lEditEstado { get; set; }
        public bool lEditObserv { get; set; }
        public bool lEdit { get; set; }
        public bool lModif { get; set; }
    }
}
