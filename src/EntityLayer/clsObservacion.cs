using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsObservacion
    {
        public int idObservacion { set; get; }
        public int idRegistro { set; get; }
        public int idCli { set; get; }
        public int idUsuDestino { set; get; }
        public int idTipoOperacion { set; get; }
        public int idSolAproba { set; get; }
        public int idNivelAprRanOpe { set; get; }
        public int idOrigenObs { set; get; }
        public string cOrigenObs { set; get; }
        public  int idGrupoObs { set; get; }
        public string cGrupoObs { set; get; }
        public int idTipObs { set; get; }
        public string cTipObs { set; get; }
        public string cObservacion { set; get; }
        public bool lSubsanado { set; get; }
        public int idUsuario { set; get; }
        public DateTime dFecha { set; get; }
        public string cNivelAproba { set; get; }
    }
}
