using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsComiteVirtual
    {
        public int idComiteCred { set; get; }
        public string cDesZona { set; get; }
        public string cNomCorto { set; get; }
        public string cNomComite { set; get; }
        public int nParticipantes { set; get; }
        public int nEvaluaciones { set; get; }
        public bool lConfirmAsis { get; set; }
        public bool lInvitacion { get; set; }
        public string cAsistencia { get; set; }
        public int idUsuario { set; get; }
    }
}
