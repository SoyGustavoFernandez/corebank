using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsWCFUsuario
    {
        public int idUsuario { get; set; }
        public int idCli { get; set; }
        public string cWinUser{ get; set; }
        public string cPassword { get; set; }
        public string cDocumentoID { get; set; }  
        public string cNombre { get; set; }        
        public int idAgencia { get; set; }        
        public string cNombreAge { get; set; }
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
        public int idZona { get; set; }
        public string cDesZona { get; set; }
        public int idArea { get; set; }
        public string cArea { get; set; }
        public string cCargo { get; set; }
        
        public DateTime dFechaSistema { get; set; }
        public bool lIdentificado { get; set; }
        public string cToken { get; set; }        
        public string cRespuesta { get; set; }
        public bool lAprobadorSolicitud { get; set; }
        public bool lAprobadorRendicion { get; set; }        

        public List<clsAgencia> lstAgencia { get; set; }
        public List<clsPerfil> lstPerfil { get; set; } 
    }
}
