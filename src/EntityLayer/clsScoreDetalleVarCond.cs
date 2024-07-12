using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsScoreDetalleVarCond
    {
        public int idScoreDetalleVarCond { get; set; }
        public int idScoreVar { get; set; }
        public string cVarScore { get; set; }
        public string cScoreVarCond { get; set; }
        public string cCondicionExpre { get; set; }
        public decimal nPuntaje { get; set; }
	    public int idScoreGrupoEvaluacion { get; set; } 
        public string cScoreGrupoEvaluacion { get; set; }
	    public int idScoreTipoRiesgo { get; set; }
        public string cScoreTipoRiesgo { get; set; }
        public int nOrden { get; set; }
        public bool lCumpleCond { get; set; }
    }
}
