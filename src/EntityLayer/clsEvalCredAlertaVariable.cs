using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsEvalCredAlertaVariable
    {
        [XmlIgnore]
        public int idClaseAnalisis { get; set; }
        [XmlIgnore]
        public string cClaseAnalisis { get; set; }
        [XmlIgnore]
        public int idTipoAnalisis { get; set; }
        [XmlIgnore]
        public string cTipoAnalisis { get; set; }
        [XmlIgnore]
        public int idFuncionDinamica { get; set; }
        [XmlIgnore]
        public string cIdsSectorEcon { get; set; }
        [XmlIgnore]
        public string cAlertaVariable { get; set; }
        [XmlIgnore]
        public bool lReqVistoBueno { get; set; }

        public int idEvalCredAlertaVariable { get; set; }
        public int idEvalCred { get; set; }
        public int idAlertaVariable { get; set; }
        public int idSolicitud { get; set; }
        public string cValor { get; set; }
        public string cSustento { get; set; } 
        public string cIdsPerfil { get; set; }
        public int idUsuResolucion { get; set; }
        public int idTipoResolucion { get; set; }
        public int idTipoResolucionRecd { get; set; }
        public bool lVigente { get; set; }
        public string cComenRevision { get; set; }
        public string cDescripcion { get; set; }
        public string cResulEval { get; set; }

        public string cTipoResolucion
        {
            get
            {
                switch (this.idTipoResolucion)
                {
                    case 1:
                        return "Favorable";
                    case 2:
                        return "Desfavorable";
                    default:
                        return "Ninguno";
                }
            }
        }

        public string cTipoResolucionRecd
        {
            get
            {
                switch (this.idTipoResolucionRecd)
                {
                    case 1:
                        return "Favorable";
                    case 2:
                        return "Desfavorable";
                    default:
                        return "Ninguno";
                }
            }
        }

        public clsEvalCredAlertaVariable()
        {
            this.idClaseAnalisis = 0;
            this.cClaseAnalisis = string.Empty;
            this.idTipoAnalisis = 0;
            this.cTipoAnalisis = string.Empty;
            this.idFuncionDinamica = 0;
            this.cIdsSectorEcon = string.Empty;
            this.cAlertaVariable = string.Empty;
            this.lReqVistoBueno = false;

            this.idEvalCredAlertaVariable = 0;
            this.idEvalCred = 0;
            this.idAlertaVariable = 0;
            this.idSolicitud = 0;
            this.cValor = string.Empty;
            this.cSustento = string.Empty;
            this.cIdsPerfil = string.Empty;
            this.idUsuResolucion = 0;
            this.idTipoResolucion = 0;
            this.idTipoResolucionRecd = 0;
            this.lVigente = true;
        }
    }
}
