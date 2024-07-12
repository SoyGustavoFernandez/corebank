using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsRevisionEvalCred
    {
        public int idRevEvalCred { get; set; }
        public int idEstadoRevEvalCred { get; set; }
        public int idSolicitud { get; set; }
        public int idEvalCred { get; set; }
        public int idCli { get; set; }
        public int idTipEval { get; set; }
        public int idNivelAprobacion { get; set; }
        public int idEstadoEvalCred { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuRevisor { get; set; }
        public int idPerfilRevisor { get; set; }
        public string cComentario { get; set; }
        public bool lVerificacion { get; set; }
        public decimal nLongitud { get; set; }
        public decimal nLatitud { get; set; }
        public int idAsesor { set; get; }
        public string cAsesor { set; get; }
        public bool lVigente { get; set; }

        public List<clsObservacionAprobador> lstObsAprobador { get; set; }

        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public string cOperacion { get; set; }
        public string cModalidadCredito { get; set; }

        public clsRevisionEvalCred()
        {

        }
    }
}
