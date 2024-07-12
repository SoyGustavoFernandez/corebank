using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsMotivoVinculacionArchivo
    {
        public int idMotivoVinculacionArchivo { get; set; }
        public string cMotivoVinculacionArchivo { get; set; }
        public int idTipoArchivo { get; set; }
        public bool lVigente { get; set; }

        public clsMotivoVinculacionArchivo()
        {
            idMotivoVinculacionArchivo  = 0;
            cMotivoVinculacionArchivo   = String.Empty;
            idTipoArchivo               = 0;
            lVigente                    = false;
        }
    }
}
