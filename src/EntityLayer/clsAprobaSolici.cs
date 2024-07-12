using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAprobaSolici
    {
        public int idAprobadorSol { get; set; }
        public int idSolAproba { get; set; } 
        public int idNivelAprRanOpe { get; set; }
        public int nOrdenAprobacion { get; set; }
        public int idEstado { get; set; }
        public int idUsuarioEmiOpi { get; set; }
        public int idAgeUsuEmiOpi { get; set; }
        public int idPerfilEmiOpi { get; set; }
        public int idCargoEmiOpi { get; set; }
        public DateTime dFechaEmiOpi { get; set; }
        public String cOpinion { get; set; }
        public bool lSoloComent { get; set; }
        public DateTime dFecHoraEmiOpi { get; set; }

        [XmlIgnore]
        public string cNivelAproba { get; set; }
        [XmlIgnore]
        public string cEstadoSol { get; set; }
        [XmlIgnore]
        public string cWinUser { get; set; }
        [XmlIgnore]
        public string cNombreUsuario { get; set; }
        [XmlIgnore]
        public string cAgenciaEmiteOpinion { get; set; }
        [XmlIgnore]
        public string cPerfilEmiteOpinion { get; set; }
        [XmlIgnore]
        public string cCargoEmiteOpinion { get; set; }


        public clsAprobaSolici()
        {
            idAprobadorSol          = 0;
            idSolAproba             = 0;
            idNivelAprRanOpe        = 0;
            nOrdenAprobacion        = 0;
            idEstado                = 0;
            idUsuarioEmiOpi         = 0;
            idAgeUsuEmiOpi          = 0;
            idPerfilEmiOpi          = 0;
            idCargoEmiOpi           = 0;
            dFechaEmiOpi            = clsVarGlobal.dFecSystem;
            cOpinion                = String.Empty;
            lSoloComent             = false;
            dFecHoraEmiOpi          = clsVarGlobal.dFecSystem;

            cNivelAproba            = String.Empty;
            cEstadoSol              = String.Empty;
            cWinUser                = String.Empty;
            cNombreUsuario          = String.Empty;
            cAgenciaEmiteOpinion    = String.Empty;
            cPerfilEmiteOpinion     = String.Empty;
            cCargoEmiteOpinion      = String.Empty;
        }
    }
}
