using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsActividadEconomicaConfig
    {
        public int idActividadEconomicaConfig { get; set; }
        public int idActividadInterna { get; set; }
        [XmlIgnore]
        public string cActividadInterna { get; set; }
        public int idActividad { get; set; }
        [XmlIgnore]
        public string cActividad { get; set; }
        public int idSectorEcon { get; set; }
        [XmlIgnore]
        public string cSectorEcon { get; set; }
        public int idSector { get; set; }
        [XmlIgnore]
        public string cSector { get; set; }
        public decimal nMargenGanancia { get; set; }
        public bool lVigente { get; set; }

        public clsActividadEconomicaConfig()
        {
            this.idActividadEconomicaConfig = 0;
            this.idActividadInterna         = 0;
            this.cActividadInterna          = String.Empty;
            this.idActividad                = 0;
            this.cActividad                 = String.Empty;
            this.idSectorEcon               = 0;
            this.cSectorEcon                = String.Empty;
            this.idSector                   = 0;
            this.cSector                    = String.Empty;
            this.nMargenGanancia            = 0;
            this.lVigente                   = false;
        }
    }
}
