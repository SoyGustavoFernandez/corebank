using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsUsuarioComiteAmpRsg
    {
        public int idUsuarioComiteAmpRsg { get; set; }
        public int idComiteAmpRiesgo { get; set; }
        public int idUsuarioComite { get; set; }
        [XmlIgnore]
        public string cNombre { get; set; }
        [XmlIgnore]
        public string cWinUser { get; set; }
        public int idUsuarioRegistra { get; set; }
        public int idUsuarioModifica { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistra { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraModifica { get; set; }
        public bool lVigente { get; set; }
    }
}
