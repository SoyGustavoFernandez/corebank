using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAprobacionSolicitudTipo : ICloneable
    {
        public int idAprobacionSolicitudTipo { get; set; }
        public string cAprobacionSolicitudTipo { get; set; }
        public string cAcronimo { get; set; }
        public string cTabla { get; set; }
        public string cCampoId { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public bool lVigente { get; set; }

        public clsAprobacionSolicitudTipo()
        {
            this.idAprobacionSolicitudTipo = 0;
            this.cAprobacionSolicitudTipo = string.Empty;
            this.cAcronimo = string.Empty;
            this.cTabla = string.Empty;
            this.cCampoId = string.Empty;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.lVigente = true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
