using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAproEvalCredGrupoSol
    {
        public int idAproEvalCredGrupoSol { get; set; }
        public int idEstadoAproEvalCred { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idEvalCredGrupoSol { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idTipEvalCred { get; set; }
        public int idNivelAprobacion { get; set; }
        public int idEstadoEvalCred { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuAprobador { get; set; }
        public int idPerfilAprobador { get; set; }
        public string cComentario { get; set; }
        public bool lVerificacion { get; set; }
        public int idMotRechazo { get; set; }
        public decimal nLongitud { get; set; }
        public decimal nLatitud { get; set; }
        public bool lVigente { get; set; }
        public string cNombre { get; set; }
        public string cOperacion { get; set; }
        public string cModalidadCredito { get; set; }
        public int idAsesor { get; set; }
        public List<clsObsAprobadorGrupoSol> lstObsAprobadorGrupoSol { get; set; }
    }
}
