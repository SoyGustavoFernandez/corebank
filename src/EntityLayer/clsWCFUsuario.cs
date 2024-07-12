using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFUsuario
    {
        public string cWinUser { get; set; }
        public string cPassword { get; set; }
        public string cImei { get; set; }
        public string cNombreEquipo { get; set; }
        public string cCaracteristicas { get; set; }
        public int idPerfil { get; set; }
        public int idAgencia { get; set; }

        //---------------------------------------------
        
        public string cNombres { get; set; }
        public string cPerfil { get; set; }
        public string cToken { get; set; }

        //---------------------------------------------

        public bool lIdentificado { get; set; }
        public string cMensaje { get; set; }
        public string dFechaSistema { get; set; }
        public string cVersion { get; set; }

        //---------------------------------------------

        public IList<clsWCFAgencia> lAgencias { get; set; }
        public IList<clsWCFPerfil> lPerfiles { get; set; }
    }

    public class clsWCFAgencia
    {
        public int idAgencia { get; set; }
        public string cNombreAge { get; set; }
    }

    public class clsWCFPerfil
    {
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
    }

    public class clsWCFToken
    {
        public string cEstado { get; set; }
        public string cMensaje { get; set; }
        public string cNivel { get; set; }
    }
}
