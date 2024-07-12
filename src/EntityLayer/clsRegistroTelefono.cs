using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsRegistroTelefono : ICloneable
    {
        public int idRegTel { get; set; }
        public int idCli { get; set; }
        public string cDocumentoID { get; set; }
        public string cNumeroTelefonico { get; set; }
        [XmlIgnore]
        public string cDetalleNumero { get; set; }
        public int idCodTelFijo { get; set; }
        public int idTipoTelefono { get; set; }
        public string cTipoTelefono { get; set; }
        public int idCondicionTelf { get; set; }
        public string cCondicionTelf { get; set; }
        public bool lVigente { get; set; }
        public bool lNumeroValidado { get; set; }
        public bool lSeleccionado { get; set; }
        public int idTipoOperador { get; set; }
        public string cTipoOperador { get; set; }

        public clsRegistroTelefono()
        {
            idRegTel                = 0;
            idCli                   = 0;
            cDocumentoID            = String.Empty;
            cNumeroTelefonico       = String.Empty;
            cDetalleNumero          = String.Empty;
            idCodTelFijo            = 0;
            idTipoTelefono          = 0;
            cTipoTelefono           = String.Empty;
            idCondicionTelf         = 0;
            cCondicionTelf          = String.Empty;
            lVigente                = false;
            lNumeroValidado         = false;
            lSeleccionado           = false;
            idTipoOperador          = 0;
            cTipoOperador           = String.Empty;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
