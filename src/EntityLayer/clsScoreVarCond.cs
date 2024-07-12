using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsScoreVarCond
    {
        public int idScoreVarCond { get; set; }   
        public int idScoreVar { get; set; }  
		public string cScoreVarCond	{ get; set; }
        public string cVarScore	{ get; set; }
		public string cCondicionExpre { get; set; }
        public string cCondicionExpreReemplazo { get; set; }
        public int idScoreGrupoEvaluacion { get; set; }	
        public int idScoreTipoRiesgo { get; set; }
        public int nOrden { get; set; }	    
		public decimal nPuntaje	{ get; set; }
	    public string cScoreGrupoEvaluacion { get; set; }
		public string cScoreTipoRiesgo{ get; set; }
		public int idScoreBase { get; set; }
        public int idScore { get; set; }
        public int idTipoScore { get; set; }
		public bool lVigente { get; set; }
        public bool lCumpleCond { get; set; }
    }
}
