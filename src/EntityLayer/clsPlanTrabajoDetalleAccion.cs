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
    public class clsPlanTrabajoDetalleAccion : ICloneable
    {
        public int idPlanTrabajoDetalleAccion { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public string cPlanTrabajoDetalleAccion { get; set; }
        [XmlIgnore]
        public int idPlanTrabajoObjetivoGeneral { get; set; }
        public int idPlanTrabajoObjetivo { get; set; }
        public int idPlanTrabajoAccion { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoAccion { get; set; }
        [XmlIgnore]
        public string cPlanTrabajoObjetivo { get; set; }
        public DateTime dFechaAccion { get; set; }
        [XmlIgnore]
        public bool lVigente { get; set; }
        [XmlIgnore]
        public List<clsDatosCreditoCliente> lstDatosCreditoCliente { get; set; }

        public clsPlanTrabajoDetalleAccion()
        {
            idPlanTrabajoDetalleAccion      = 0;
            idPlanTrabajoRecuperacion       = 0;
            cPlanTrabajoDetalleAccion       = String.Empty;
            idPlanTrabajoObjetivo           = 0;
            cPlanTrabajoObjetivo            = String.Empty;
            dFechaAccion                    = clsVarGlobal.dFecSystem;
            lVigente                        = true;
            lstDatosCreditoCliente          = new List<clsDatosCreditoCliente>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
