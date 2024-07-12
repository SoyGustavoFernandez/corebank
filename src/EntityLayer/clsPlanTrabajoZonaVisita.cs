using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsPlanTrabajoZonaVisita : ICloneable
    {
        public int idPlanTrabajoZonaVisita { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public int idPlanTrabajoObjetivo { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoObjetivo { get; set; }
        public DateTime  dFechaVisita { get; set; }
        public int idZona { get; set; }
        public string cZona { get; set; }
        public int idAgencia { get; set; }
        public string cAgencia { get; set; }
        public int idDistrito { get; set; }
        [XmlIgnore]
        public string cDistrito { get; set; }
        public string cDescripcionZonaVisita { get; set; }
        public bool lVigente { get; set; }
        
        public clsPlanTrabajoZonaVisita()
        {
            idPlanTrabajoZonaVisita     = 0;
            idPlanTrabajoRecuperacion   = 0;
            idPlanTrabajoObjetivo       = 0;
            dFechaVisita                = clsVarGlobal.dFecSystem;
            idAgencia                   = 0;
            idZona                      = 0;
            idDistrito                  = 0;
            cDescripcionZonaVisita      = String.Empty;
            lVigente                    = false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
