using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    [XmlInclude(typeof(clsRemesa))]
    public class clsRemesa
    {
        public int idRemesa { set; get; }
        public int idTipoRemesa { set; get; }
        public int idEstadoRemesa { set; get; }
        public int idEstadoRegistro { set; get; }
        public int idEstadoRemesaRec { set; get; }
        public DateTime dFechaHoraRegistro { set; get; }
        public int idAgenciaRemesa { set; get; }
        public int idEstablecimientoRemesa { set; get; }
        public int idPersonalSolicitante { set; get; }
        public int idMoneda { set; get; }
        public decimal nMontoRemesa { set; get; }
        public int idModalidadSolicitud { set; get; }
        public string cNroCuenta { set; get; }
        public string cCCI { set; get; }
        public string cEntidad { set; get; }
        public string cDireccion { set; get; }
        public int nCelular { set; get; }
        public string cOtro { set; get; }
        public string cNombreChequeGiro { set; get; }
        public string cDniChequeGiro { set; get; }
        public string cSustento { set; get; }
        public int idPersonalApruebaSolicitud { set; get; }
        public int idEstadoRespuesta { set; get; }
        public DateTime dFechaHoraRespuesta { set; get; }
        public int idPersonalRemesante { set; get; }
        public int idCuentaInstitucion { set; get; }
        public string cDescripcion { set; get; }
        public int idAgenciaRecepcion { set; get; }
        public int idEstablecimientoRecepcion { set; get; }
        public DateTime dFechaHoraRecepcion { set; get; }
        public decimal nCostoRecepcion { set; get; }
        public decimal nMontoRecepcion { set; get; }
        public bool lHabilitacion { set; get; }
        public int idPersonalHabilitar { set; get; }
        public int idEstadoHabilitar { set; get; }
        public DateTime dFechaHoraHabilitacion { set; get; }
        public int idAgenciaHabilita { set; get; }
        public int idEstablecimientoHabilita { set; get; }
        public string cMotivoOperacion { set; get; }
        public decimal nCostoHabilitacion { set; get; }
        public decimal nMontoHabilitacion { set; get; }
        public decimal nMontoRecibido { set; get; }
        public decimal nMontoEnviado { set; get; }
        public bool lVigente { set; get; }
        public List<clsRemesa> lstRemesa { set; get; }

        public clsRemesa()
        {
            this.idRemesa = 0;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.dFechaHoraRespuesta = clsVarGlobal.dFecSystem;
            this.dFechaHoraRecepcion = clsVarGlobal.dFecSystem;
            this.dFechaHoraHabilitacion = clsVarGlobal.dFecSystem;
            this.lVigente = true;
            this.lHabilitacion = false;
        }
    }
}
