using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAproSolicitudRecComision
    {
        public int idAproSolicitudRecComision { get; set; }
        public int idEstado { get; set; }
        public int idNivelAprobacion { get; set; }
        public DateTime dFecha { get; set; }
        public DateTime dFechaComision { get; set; }
        public decimal nMontoComision { get; set; }
        public int idUsuRegistro { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public string cNombre { get; set; }
        public bool lVigente { get; set; }

        public clsAproSolicitudRecComision()
        {
            this.idAproSolicitudRecComision = 0;
            this.idEstado = 0;
            this.idNivelAprobacion = 0;
            this.dFecha = clsVarGlobal.dFecSystem;
            this.dFechaComision = clsVarGlobal.dFecSystem;
            this.nMontoComision = decimal.Zero;
            this.idUsuRegistro = 0;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.cNombre = string.Empty;
            this.lVigente = true;
        }
    }
}
