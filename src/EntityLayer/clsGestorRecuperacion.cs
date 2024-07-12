using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGestorRecuperacion
    {
        public int idUsuario { get; set; }
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int nEstablecimientos { get; set; }

        public clsGestorRecuperacion()
        {
            this.idUsuario = 0;
            this.idCli = 0;
            this.cNombre = string.Empty;
            this.nEstablecimientos = 0;
        }
    }
}
