using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsFlujoPlanillaMovilidad
    {
        public int idFlujoPlanillaMovilidad { get; set; }
        public int idPlanillaMovilidad { get; set; }
        public int idEstadoFlujoRecuperacion { get; set; }
        public int idAgencia { get; set; }
        [XmlIgnore]
        public string cAgencia { get; set; }
        [XmlIgnore]
        public string cPeriodo { get; set; }
        public int idEstadoInicial { get; set; }
        [XmlIgnore]
        public string cEstadoInicial { get; set; }
        public int idEstadoFinal { get; set; }
        [XmlIgnore]
        public string cEstadoFinal { get; set; }

        public int idUsuario { get; set; }
        public int idPerfilFlujo { get; set; }
        [XmlIgnore]
        public string cUsuario { get; set; }
        [XmlIgnore]
        public string cCargo { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public bool lVigente { get; set; }
        [XmlIgnore]
        public int idUsuarioRegistra { get; set; }
        [XmlIgnore]
        public int idUsuarioModifica { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistra { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraModifica { get; set; }


        public clsFlujoPlanillaMovilidad()
        {
            idFlujoPlanillaMovilidad        = 0;
            idPlanillaMovilidad             = 0;
            cPeriodo                        = String.Empty;
            idEstadoInicial                 = 0;
            cEstadoFinal                    = String.Empty;
            idEstadoFinal                   = 0;
            cEstadoInicial                  = String.Empty;
            idUsuario                       = 0;
            cUsuario                        = String.Empty;
            cCargo                          = String.Empty;
            dFechaRegistro                  = clsVarGlobal.dFecSystem;
            lVigente                        = false;
            idUsuarioRegistra               = 0;
            idUsuarioModifica               = 0;
            dFechaHoraRegistra              = clsVarGlobal.dFecSystem;
            dFechaHoraModifica              = clsVarGlobal.dFecSystem;
        }
    }
}
