using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsUsuAprobBiometrico : ICloneable
    {
        public int idBiometriaExcepcion { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        [XmlIgnore]
        public string cDocumentoID { get; set; }
        [XmlIgnore]
        public string cNombres { get; set; }
        public int idPerfil { get; set; }
        [XmlIgnore]
        public string cPerfil { get; set; }
        public int idCargo { get; set; }
        [XmlIgnore]
        public string cCargo { get; set; }
        public bool lConfirmaAprobacion { get; set; }
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        [XmlIgnore]
        public string cWinUser { get; set; }

        public clsUsuAprobBiometrico()
        {
            idBiometriaExcepcion    = 0;
            idUsuario               = 0;
            idCliente               = 0;
            cDocumentoID            = String.Empty;
            cNombres                = String.Empty;
            idPerfil                = 0;
            cPerfil                 = String.Empty;
            idCargo                 = 0;
            cCargo                  = String.Empty;
            lConfirmaAprobacion     = false;
            idAgencia               = 0;
            idEstablecimiento       = 0;
            cWinUser                = String.Empty;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
