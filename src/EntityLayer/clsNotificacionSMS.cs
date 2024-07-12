using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsNotificacionSMS : ICloneable
    {
        public int idNotificacionSMS { get; set; }
        public int idCliente { get; set; }
        public int idTipoMensaje { get; set; }
        public int idRegistro { get; set; }
        public int idModulo { get; set; }
        public int idAgencia { get; set; }
        public int idEstablecimiento { get; set; }
        public string cCodigoValidacion { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idEstadoNotificacionSMS { get; set; }
        [XmlIgnore]
        public string cEstadoNotificacion { get; set; }
        public string cNumeroTelefonico { get; set; }
        public int idNumeroTelefonico { get; set; }
        public string cIDMensajeTexto { get; set; }
        public string cMensajeSMS { get; set; }
        public int idTipoPlantillaSMS { get; set; }
        public int idKardex { get; set; }
        [XmlIgnore]
        public int idUsuarioRegistra { get; set; }
        [XmlIgnore]
        public int idUsuarioModifica { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistra { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraModifica { get; set; }
        public bool lVigente { get; set; }
        public clsRegistroTelefono objRegistroTelefono { get; set; }

        public clsNotificacionSMS()
        {
            idNotificacionSMS       = 0;
            idCliente               = 0;
            idTipoMensaje           = 0;
            idRegistro              = 0;
            idAgencia               = 0;
            idEstablecimiento       = 0;
            cCodigoValidacion       = String.Empty;
            dFechaRegistro          = clsVarGlobal.dFecSystem;
            idEstadoNotificacionSMS = 0;
            cEstadoNotificacion     = String.Empty;
            cNumeroTelefonico       = String.Empty;
            idNumeroTelefonico      = 0;
            cIDMensajeTexto         = String.Empty;
            cMensajeSMS             = String.Empty;
            idTipoPlantillaSMS      = 0;
            idKardex                = 0;
            idUsuarioRegistra       = 0;
            idUsuarioModifica       = 0;
            dFechaHoraRegistra      = clsVarGlobal.dFecSystem;
            dFechaHoraModifica      = clsVarGlobal.dFecSystem;
            lVigente                = false;
            objRegistroTelefono     = new clsRegistroTelefono();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
