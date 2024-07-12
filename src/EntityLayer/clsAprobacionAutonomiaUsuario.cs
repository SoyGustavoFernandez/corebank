using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAprobacionAutonomiaUsuario : ICloneable
    {
        public int idAprobacionAutonomiaUsuario { get; set; }
        public int idCanalAproCred { get; set; }
        [XmlIgnore]
        public string cCanalAproCred { get; set; }
        public int idNivelAprobacion { get; set; }
        [XmlIgnore]
        public string cNivelAprobacion { get; set; }
        public int idUsuario { get; set; }
        [XmlIgnore]
        public string cUsuario { get; set; }
        public int idPerfil { get; set; }
        [XmlIgnore]
        public string cPerfil { get; set; }
        public decimal nMonto { get; set; }
        public int idEstado { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
       
        [XmlIgnore]
        public int idUsuModifica { get; set; }
        [XmlIgnore]
        public DateTime dFecHoraModifica { get; set; }
        public bool lVigente { get; set; }

        public clsAprobacionAutonomiaUsuario()
        {
            this.idAprobacionAutonomiaUsuario = 0;
            this.idCanalAproCred = 0;
            this.idNivelAprobacion = 0;
            this.idUsuario = 0;
            this.idPerfil = 0;
            this.nMonto = Decimal.Zero;
            this.idEstado = 0;

            this.idUsuModifica = 0;
            this.dFecHoraModifica = DateTime.Now;
            this.lVigente = true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
