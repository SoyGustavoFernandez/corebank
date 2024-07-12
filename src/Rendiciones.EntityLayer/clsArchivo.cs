using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsArchivo
    {
        public int idArchivo { get; set; }        
        public string cNombreArchivo { get; set; }        
        public string cArchivoBase64 { get; set; }
        public string cExtension { get; set; }
        public string cTipo { get; set; }
        public bool lVigente { get; set; }
    }
}
