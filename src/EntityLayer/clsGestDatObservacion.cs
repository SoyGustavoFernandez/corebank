using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGestDatObservacion
    {
        public int idRegistroObs { get; set; }
        public int idSolicitud { get; set; }
        public string cDescripcion { get; set; }
        public string cComentario { get; set; }
        public int idUsuario { get; set; }
        public int idUsuarioReg { get; set; }
        public int idTipObs { get; set; }
        public string cFecha { get; set; }
        public int idPerfil { get; set; }
        public int idEtapaEvalCred { get; set; }
        public int idEstado { get; set; }
        public int idMenu { get; set; }
        public int lVigente { get; set; }
    }
}
