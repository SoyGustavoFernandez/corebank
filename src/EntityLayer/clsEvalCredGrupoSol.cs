using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEvalCredGrupoSol
    {
        public int idNivelAprobacion { get; set; }
        public string cNivelAprobacion { get; set; }
        public string cDescripcion { get; set; }
        public int nOrden { get; set; }
        public string cIdsPerfiles { get; set; }
        public int idEstadoEvalCred { get; set; }
        public int idEtapaEvalCred { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int idEvalCredGrupoSol { get; set; }
        public string cNombre { get; set; }
        public string cWinUser { get; set; }
        public string cDireccion { get; set; }
        public string cTipo { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public int idMoneda { get; set; }
        public decimal nMonto { get; set; }
        public int nCuotas { get; set; }
        public int idTasa { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public int nCuotasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public int idProducto { get; set; }
        public int idSubProducto { get; set; }
        public int idOperacion { get; set; }
        public int idModalidadCredito { get; set; }
        public int idModalidadDes { get; set; }
        public decimal nTEA { get; set; }
        public int idAsesor { get; set; }
        public int idAgencia { get; set; }
        public string cComSituacionAct { get; set; }
        public string cComGarantias { get; set; }
        public string cComConclusiones { get; set; }
        public bool lEditar { get; set; }
        public decimal nTipoCambio { get; set; }
        public int idGrupoSolidarioCiclo { get; set; }
        public int idGrupoSolidarioTipo { get; set; }
    }
}
