using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOtrosIngresosEvalRuralM
    {
        public Guid idOtrIngM { get; set; }
        public int idEvalCred { get; set; }
        public int idTipo { get; set; }
        public string cTipoOtrosIngresosEvalRural { get; set; }
        public int idPeriodo { get; set; }
        public string cPeriodoOtrosIngresosEvalRural { get; set; }
        public int nCantidadItems { get; set; }
        public decimal nIngresoTotal { get; set; }
        public int nPlazo { get; set; }

        public List<clsOtrosIngresosEvalRuralD> listaDetalle { get; set; }

        public clsOtrosIngresosEvalRuralM ()
	    {
            listaDetalle = new List<clsOtrosIngresosEvalRuralD>();
	    }
    }
}
