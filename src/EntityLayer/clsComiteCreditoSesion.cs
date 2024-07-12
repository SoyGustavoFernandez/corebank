using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsComiteCreditoSesion
    {
        public int idComiteCreditoSesion { get; set; }
        public int idComiteCred { get; set; }
        public int idComiteCreditoHorario { get; set; }
        public int idEstado { get; set; }
        [XmlIgnore]
        public string cEstado { get; set; }
        public int nReinicio { get; set; }
        public TimeSpan tHoraIniProg { get; set; }
        public TimeSpan tHoraFinProg { get; set; }
        public TimeSpan tTiempoAmpliado { get; set; }
        public TimeSpan tHoraReporte { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idUsuRegistra { get; set; }
        public bool lVigente { get; set; }

        [XmlIgnore]
        public TimeSpan tHoraActual { get; set; }
        [XmlIgnore]
        public int nTiempoRestante { get; set; }
        [XmlIgnore]
        public int nTiempoAlerta { get; set; }
        [XmlIgnore]
        public bool lTiempoAmpliado { get; set; }
        [XmlIgnore]
        public bool lValidoParaAmpliacion { get; set; }
        [XmlIgnore]
        public clsComiteCreditoConfig objComiteCreditoConfig;

        public clsComiteCreditoSesion()
        {
            this.idComiteCreditoSesion = 0;
            this.idComiteCred = 0;
            this.idComiteCreditoHorario = 0;
            this.idEstado = 0;
            this.cEstado = string.Empty;
            this.nReinicio = 0;
            this.tHoraIniProg = clsVarGlobal.dFecSystem.TimeOfDay;
            this.tHoraFinProg = clsVarGlobal.dFecSystem.TimeOfDay;
            this.tTiempoAmpliado = clsVarGlobal.dFecSystem.TimeOfDay;
            this.tHoraReporte = clsVarGlobal.dFecSystem.TimeOfDay;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.idUsuRegistra = 0;
            this.lVigente = true;

            this.nTiempoRestante = 0;
            this.nTiempoAlerta = 0;
            this.lTiempoAmpliado = false;
            this.lValidoParaAmpliacion = false;
        }
    }
}
