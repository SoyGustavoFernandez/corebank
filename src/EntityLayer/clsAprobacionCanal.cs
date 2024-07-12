using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAprobacionCanal : ICloneable
    {
        public int idAprobacionCanal { get; set; }
        public string cAprobacionCanal { get; set; }
        public string cAcronimo { get; set; }
        [XmlIgnore]
        public int idAprobacionNivelInicio { get; set; }
        [XmlIgnore]
        public int idAprobacionNivelFin { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistro { get; set; }
        public bool lVigente { get; set; }

        public clsAprobacionCanal()
        {
            this.idAprobacionCanal = 0;
            this.cAprobacionCanal = string.Empty;
            this.cAcronimo = string.Empty;
            this.idAprobacionNivelInicio = 0;
            this.idAprobacionNivelFin = 0;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.lVigente = true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
