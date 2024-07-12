using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsNivelAprobacion
    {
        public int idNivelAprobacion { get; set; }
        public string cNivelAprobacion { get; set; }
        public int nOrden { get; set; }
        public string cIdsPerfiles { get; set; }
        public bool lRevision { get; set; }
        public bool lVigente { get; set; }
        public int idCanalAproCred { get; set; }
        public int idCapaAprobacion { get; set; }

        public clsNivelAprobacion()
        {
            this.idNivelAprobacion = 0;
            this.cNivelAprobacion = String.Empty;
            this.nOrden = 0;
            this.cIdsPerfiles = String.Empty;
            this.lRevision = false;
            this.lVigente = true;
            this.idCanalAproCred = 0;
            this.idCapaAprobacion = 0;
        }
    }
}
