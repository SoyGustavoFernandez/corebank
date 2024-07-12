using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDesactivacionPaqueteSeguro
    {
        public int idPaqueteSeguroOriginal { get; set; }
        public string cPaqueteSeguroOriginal { get; set; }
        public int idPaqueteSeguroActual { get; set; }
        public string cPaqueteSeguroActual { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCompleto { get; set; }
        public int idSolicitud { get; set; }
        public bool lEnviarCorreo  { get; set; }
    }
}
