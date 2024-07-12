#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace EntityLayer
{
    public class clsPlanillaMovilidadResumen
    {
        #region Variables Globales
        public string cGuidPlanillaMovilidadResumen { get; set; }
        public int idPlanillaMovilidadResumen { get; set; }
        public int idPlanillaMovilidad { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public int idPlanTrabajoObjetivoEspecifico { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoObjetivoGeneral { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoObjetivoEspecifico { get; set; }
        public int idPlanTrabajoObjetivoGeneral { get; set; }
        public int idPlanTrabajoAccion { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoAccion { get; set; }
        public DateTime dFechaAccion { get; set; }
        public bool lVigente { get; set; }
        public decimal nMontoAsignado{ get; set; }

        #endregion

        public clsPlanillaMovilidadResumen()
        {
            cGuidPlanillaMovilidadResumen   = Convert.ToString(System.Guid.NewGuid());
            idPlanillaMovilidadResumen      = 0;
            idPlanillaMovilidad             = 0;
            idPlanTrabajoRecuperacion     = 0;
            idPlanTrabajoObjetivoEspecifico = 0;
            cPlanTrabajoObjetivoEspecifico  = String.Empty;
            idPlanTrabajoObjetivoGeneral    = 0;
            cPlanTrabajoObjetivoGeneral     = String.Empty;
            idPlanTrabajoAccion             = 0;
            cPlanTrabajoAccion              = String.Empty;
            dFechaAccion                    = clsVarGlobal.dFecSystem;
            lVigente                        = false;
            nMontoAsignado                  = 0.00m;
        }
    }
}
