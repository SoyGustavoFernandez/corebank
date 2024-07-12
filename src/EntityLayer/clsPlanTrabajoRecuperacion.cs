using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsPlanTrabajoRecuperacion
    {
        public string cGuidPlanTrabajoRecuperacion { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public int idEstado { get; set; }
        public int idAgencia { get; set; }
        public int nAnio { get; set; }
        public int nMes { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
        public int idUsuarioResolucion { get; set; }
        public DateTime dFechaResolucion { get; set; }
        [XmlIgnore]
        public int idUsuarioRegistra { get; set; }
        [XmlIgnore]
        public int idUsuarioModifica { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraRegistra { get; set; }
        [XmlIgnore]
        public DateTime dFechaHoraModifica { get; set; }
        [XmlIgnore]
        public bool lVigente { get; set; }

        public List<clsPlanTrabajoObjetivo> lstPlanTrabajoObjetivoGeneral { get; set; }
        public List<clsPlanTrabajoObjetivo> lstPlanTrabajoObjetivoEspecifico { get; set; }
        public List<clsPlanTrabajoDetalleAccion> lstPlanTrabajoAccion { get; set; }
        public List<clsPlanTrabajoZonaVisita> lstPlanTrabajoZonaVisita { get; set; }

        public List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculadoPlanTrabajo { get; set; }

        public clsPlanTrabajoRecuperacion()
        {
            cGuidPlanTrabajoRecuperacion        = Convert.ToString(System.Guid.NewGuid());
            idPlanTrabajoRecuperacion           = 0;
            idUsuario                           = 0;
            idPerfil                            = 0;
            idEstado                            = 0;
            idAgencia                           = 0;
            nAnio                               = 0;
            nMes                                = 0;
            dFechaInicio                        = clsVarGlobal.dFecSystem;
            dFechaFin                           = clsVarGlobal.dFecSystem;
            idUsuarioResolucion                 = 0;
            dFechaResolucion                    = clsVarGlobal.dFecSystem;
            idUsuarioRegistra                   = 0;
            idUsuarioModifica                   = 0;
            dFechaHoraRegistra                  = clsVarGlobal.dFecSystem;
            dFechaHoraModifica                  = clsVarGlobal.dFecSystem;
            lVigente                            = true;
            lstPlanTrabajoObjetivoGeneral       = new List<clsPlanTrabajoObjetivo>();
            lstPlanTrabajoObjetivoEspecifico    = new List<clsPlanTrabajoObjetivo>();
            lstPlanTrabajoAccion                = new List<clsPlanTrabajoDetalleAccion>();
            lstPlanTrabajoZonaVisita            = new List<clsPlanTrabajoZonaVisita>();
            lstClienteVinculadoPlanTrabajo      = new List<clsDatosCreditoClientePlanTrabajo>();
        }
    }
}
