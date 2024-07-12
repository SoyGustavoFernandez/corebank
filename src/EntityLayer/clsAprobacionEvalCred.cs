using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAprobacionEvalCred
    {

        public int idAproEvalCred{get; set;}
        public int idEstadoAproEvalCred{get; set;}
        public int idSolicitud{get; set;}
        public int idEvalCred{get; set;}
        public int idCli { get; set; }
        public int idTipEval { get; set; }
        public int idNivelAprobacion{get; set;}
        public int idEstadoEvalCred{get; set;}
        public int idUsuReg{get; set;}
        public int idUsuAprobador{ get; set; }
        public int idPerfilAprobador{ get; set; }
        public string cComentario{get; set;}
        public bool lVerificacion{get; set;}
        public int idMotRechazo{get; set;}
        public int nLongitud{get; set;}
        public int nLatitud{get; set;}
        public DateTime dFecIni{get; set;}
        public DateTime dFecHoraIni{get; set;}
        public DateTime dFecFin{get; set;}
        public DateTime dFecHoraFin{get; set;}
        public DateTime dFecReg{get; set;}
        public DateTime dFecHoraReg{get; set;}
        public bool lVigente{get; set;}
        public int idAsesor { set; get; }
        public string cAsesor { set; get; }

        public List<clsObservacionAprobador> lstObsAprobador { get; set; }

        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public string cOperacion { get; set; }
        public string cModalidadCredito { get; set; }


        public clsAprobacionEvalCred()
        {
        }
    }
}
