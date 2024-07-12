using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsExcepcionReglaNeg
    {
        public int idExcepcionReglaNeg { get; set; }
        public int idTipoExcepcion { get; set; }
        public int idSolicitud { get; set; }
        public int idEstado { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        public int idAprobacionNivel { get; set; }
        public int idMenu { get; set; }
        public bool lAutomatico { get; set; }
        public int idRegla { get; set; }
        public string cAprobacionCanal { get; set; }
        public string cAcronimo { get; set; }
        public string cNombreCorto { get; set; }
        public int idAprobacionCanal { get; set; }
        [XmlIgnore]
        public string cRegla { get; set; }
        public int idProducto { get; set; }
        public decimal nMonto { get; set; }
        public string cSustento { get; set; }
        public int idUsuAprobador { get; set; }
        public DateTime dFecHraResolucion { get; set; }
        public DateTime dFecha { get; set; }
        public bool lVigente { get; set; }

        public clsExcepcionReglaNeg()
        {
            this.idExcepcionReglaNeg = 0;
            this.idTipoExcepcion = 0;
            this.idSolicitud = 0;
            this.idEstado = 0;
            this.idAprobacionNivel = 0;
            this.idMenu = 0;
            this.lAutomatico = true;
            this.idRegla = 0;
            this.cAprobacionCanal = string.Empty;
            this.cAcronimo = string.Empty;
            this.cNombreCorto = string.Empty;
            this.idAprobacionCanal = 0;
            this.idProducto = 0;
            this.nMonto = decimal.Zero;
            this.cSustento = string.Empty;
            this.idUsuAprobador = 0;
            this.dFecHraResolucion = clsVarGlobal.dFecSystem;
            this.dFecha = clsVarGlobal.dFecSystem;
            this.lVigente = true;
            this.cEstado = string.Empty;
            this.cRegla = string.Empty;
        }
    }
}
