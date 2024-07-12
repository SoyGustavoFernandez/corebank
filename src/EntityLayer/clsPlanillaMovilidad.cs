using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPlanillaMovilidad
    {
        public string cGuidPlanillaMovilidad { get; set; }
        public int idPlanillaMovilidad { get; set; }
        public int idPlanTrabajoRecuperacion { get; set; }
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public int idEstado { get; set; }
        public int idAgencia { get; set; }
        public int nAnio { get; set; }
        public int nMes { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idUsuarioResolucion { get; set; }
        public DateTime dFechaResolucion { get; set; }
        public int idUsuarioRegistra { get; set; }
        public int idUsuarioModifica { get; set; }
        public DateTime dFechaHoraRegistra { get; set; }
        public DateTime dFechaHoraModifica { get; set; }
        public bool lVigente { get; set; }

        public List<clsPlanillaMovilidadResumen> lstPlanillaMovilidadResumen { get; set; }

        public clsPlanillaMovilidad()
        {
            cGuidPlanillaMovilidad          = Convert.ToString(System.Guid.NewGuid());
            idPlanillaMovilidad             = 0;
            idPlanTrabajoRecuperacion       = 0;
            idUsuario                       = 0;
            idPerfil                        = 0;
            idEstado                        = 0;
            idAgencia                       = 0;
            nAnio                           = 0;
            nMes                            = 0;
            dFechaInicio                    = clsVarGlobal.dFecSystem;
            dFechaFin                       = clsVarGlobal.dFecSystem;
            dFechaHoraRegistra              = clsVarGlobal.dFecSystem;
            idUsuarioResolucion             = 0;
            dFechaResolucion                = clsVarGlobal.dFecSystem;
            idUsuarioRegistra               = 0;
            idUsuarioModifica               = 0;
            dFechaHoraRegistra              = clsVarGlobal.dFecSystem;
            dFechaHoraModifica              = clsVarGlobal.dFecSystem;
            lVigente                        = false;
            lstPlanillaMovilidadResumen     = new List<clsPlanillaMovilidadResumen>();
        }
    }
}
