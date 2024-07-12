using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAprobacionSolicitud
    {
        public int idAprobacionSolicitud { get; set; }
        public int idAprobacionSolicitudTipo { get; set; }
        public string cAprobacionSolicitudTipo { get; set; }
        public int idRegistro { get; set; }
        public int idEstado { get; set; }
        public string cEstado { get; set; }
        public int idEtapa { get; set; }
        public string cEtapa { get; set; }
        public int idAprobacionNivel { get; set; }
        public string cAprobacionNivel { get; set; }
        public int idAprobacionCanal { get; set; }
        public string cAprobacionCanal { get; set; }
        public int idEstablecimiento { get; set; }
        public string cEstablecimiento { get; set; }
        public int idClienteBeneficiario { get; set; }
        public string cClienteBeneficiario { get; set; }
        public int idUsuarioSolicitante { get; set; }
        public string cUsuarioSolicitante { get; set; }
        public int idUsuarioAprobador { get; set; }
        public string cValor { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFecha { get; set; }
        public string cSustento { get; set; }
        public int idUsuarioRegistra { get; set; }
        public int idUsuarioModifica { get; set; }
        public DateTime dFechaHoraRegistro { get; set; }
        public DateTime dFechaHoraModifica { get; set; }
        public bool lVigente { get; set; }

        [XmlIgnore]
        public DateTime dFechaHoraServidor { get; set; }

        public clsAprobacionSolicitud()
        {
            this.idAprobacionSolicitud = 0;
            this.idAprobacionSolicitudTipo = 0;
            this.cAprobacionSolicitudTipo = string.Empty;
            this.idRegistro = 0;
            this.idEstado = 0;
            this.cEstado = string.Empty;
            this.idEtapa = 0;
            this.cEtapa = string.Empty;
            this.idAprobacionNivel = 0;
            this.cAprobacionNivel = string.Empty;
            this.idAprobacionCanal = 0;
            this.cAprobacionCanal = string.Empty;
            this.idEstablecimiento = 0;
            this.cEstablecimiento = string.Empty;
            this.idClienteBeneficiario = 0;
            this.cClienteBeneficiario = string.Empty;
            this.idUsuarioSolicitante = 0;
            this.cUsuarioSolicitante = string.Empty;
            this.idUsuarioAprobador = 0;
            this.cValor = string.Empty;
            this.nMonto = decimal.Zero;
            this.dFecha = clsVarGlobal.dFecSystem;
            this.cSustento = string.Empty;
            this.idUsuarioRegistra = 0;
            this.idUsuarioModifica = 0;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.dFechaHoraModifica = clsVarGlobal.dFecSystem;
            this.lVigente = true;

            this.dFechaHoraServidor = clsVarGlobal.dFecSystem;
        }

        public TimeSpan tAntiguedad
        {
            get { return (this.dFechaHoraServidor - this.dFechaHoraRegistro); }
        }
    }
}
