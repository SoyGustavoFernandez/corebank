using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFSolicitudTipoDocumento
    {
        public int idSolicitud { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public IList<clsWCFTipoDocumentoArchivo> lTipoDocumento { get; set; }
    }

    public class clsWCFTipoDocumentoArchivo
    {
        public int idDescTipoDoc { get; set; }
        public string cDescTipoDoc { get; set; }
        public int idTipoArchivo { get; set; }
        public string cTipoArchivo { get; set; }
        public string cMsg { get; set; }
    }
}
