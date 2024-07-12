using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsProveedor
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public string cDocumentoID { get; set; }
        public string cDireccion { get; set; }

        public int idTipoPersona { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cRuc { get; set; }
        public string cDni { get; set; }        
        public int idActivEco { get; set; }
        public int idUsuario { get; set; }
        public int idAgenciaReg { get; set; }

        public string cMensaje { get; set; }
    }
}
