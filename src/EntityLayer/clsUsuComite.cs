using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsUsuComite
    {
        public clsComiteCred ComiteCred { set; get; }
        public int idComiteCred { set; get; }
        public int idUsuario { set; get; }
        public string cNombre { set; get; }
        public string cWinUser { set; get; }
        public int idTipoParticip { set; get; }
        public string cTipoParticip { set; get; }
        public bool lConfirmAsis { set; get; }
        public bool lPresideComite { set; get; }
        public int idCargo { set; get; }
        public string cCargo { set; get; }
        public bool lAutenticacionBiometrica { set; get; }
        public bool lInvitacion { set; get; }

        public bool ShouldSerializeComiteCred()
        {
            return false;
        }

    }
}
