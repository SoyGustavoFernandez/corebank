using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable]
    public class clsRastreoTasaNegociable
    {
        public int nOrden { get; set; }
        public int idSolicitud { get; set; }
        public int idTasaNegociada { get; set; }
        public int idSolAproba { get; set; }
        public int idEstado { get; set; }
        public string cEstado { get; set; }
        public int idNivelAprRanOpe { get; set; }
        public string cNivelAprRanOpe { get; set; }
        public int nOrdenAprobacion { get; set; }
        public int idUsuarioEmiOpi { get; set; }
        public string cWinUser { get; set; }
        public string cOpinion { get; set; }
        public int idAgeUsuEmiOpi { get; set; }
        public int idTipoTasa { get; set; }
        public string cTipoTasa { get; set; }
        public int idTasaPropuesta { get; set; }
        public decimal nTasaPropuesta { get; set; }
        public string cAgenciaUsuarioOpinion { get; set; }
        public int idPerfilEmiteOpinion { get; set; } 
        public string cPerfilEmiteOpinion { get; set; } 
        public DateTime dFechaHoraEmiteOpinion { get; set; }
        public decimal nTasaMora { get; set; }

    }
}
