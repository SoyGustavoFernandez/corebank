using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsScoreEnt
    {
        public int idScore { get; set; }
        public int idTipoScore { get; set; }
        public int idScoreBase { get; set; }
        public decimal nPuntajeObtenido { get; set; }
        public decimal nMontoScore { get; set; }
        public int idSolicitud { get; set; }
        public string cTipoScore { get; set; }
        public int idScoreGrupoEvaluacion{get; set;}
        public string cScoreGrupoEvaluacion { get; set; }
        public int idTipEvalCred { get; set; }
        public string cTipEvalCred { get; set; }
        public int lCumpleBasico { get; set; }
        public string cMensajeScore { get; set; }
        public List<clsScoreDetalleVarCond> listScoreDetalle;
    }
}
