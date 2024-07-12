using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAprobacionNivel : ICloneable
    {
        public int idAprobacionNivel { get; set; }
        public string cAprobacionNivel { get; set; }
        public string cAcronimo { get; set; }
        public int idAprobacionCanal { get; set; }
        public string cIdsPerfil { get; set; }
        public int nOrden { get; set; }
        public string cDescripcion { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistro { get; set; }
        public bool lVigente { get; set; }
        [XmlIgnore]
        public bool lIdsPerfilModif { get; set; }
        [XmlIgnore]
        public List<clsPerfil> lstPerfil { get; set; }

        public clsAprobacionNivel()
        {
            this.idAprobacionNivel = 0;
            this.cAprobacionNivel = string.Empty;
            this.cAcronimo = string.Empty;
            this.idAprobacionCanal = 0;
            this.cIdsPerfil = string.Empty;
            this.nOrden = 0;
            this.cDescripcion = string.Empty;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.lIdsPerfilModif = false;
            this.lVigente = true;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
