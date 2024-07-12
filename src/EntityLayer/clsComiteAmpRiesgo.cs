using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsComiteAmpRiesgo
    {
        public int idComiteAmpRiesgo { get; set; }
        public string cNombreComite { get; set; }
        public string cMotivoComite { get; set; }
        public DateTime dFechaSistema { get; set; }
        public int idUsuarioRegistra { get; set; }
        public int idUsuarioModifica { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistra { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraModifica { get; set; }
        public bool lVigente { get; set; }
        public List<clsUsuarioComiteAmpRsg> lstParticipanteComite { get; set; }

        public clsComiteAmpRiesgo()
        {
            idComiteAmpRiesgo   = 0;
            cNombreComite       = String.Empty;
            cMotivoComite       = String.Empty;
            dFechaSistema       = DateTime.Now;
            idUsuarioRegistra   = 0;
            idUsuarioModifica   = 0;
            dFechaHoraRegistra  = DateTime.Now;
            dFechaHoraModifica  = DateTime.Now;
            lVigente            = false;
            lstParticipanteComite = new List<clsUsuarioComiteAmpRsg>();
        }
    }
}
