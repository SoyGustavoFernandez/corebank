using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsArchivoComprobante : clsArchivo
    {
        public int idComprobantePago { get; set; }
        public int idEntrega { get; set; }
    }
}
