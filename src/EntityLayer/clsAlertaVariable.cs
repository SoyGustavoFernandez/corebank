using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsAlertaVariable
    {
        public int idAlertaVariable { get; set; }
        public int idClaseAnalisis { get; set; }
        [XmlIgnore]
        public string cClaseAnalisis { get; set; }
        public int idTipoAnalisis { get; set; }
        [XmlIgnore]
        public string cTipoAnalisis { get; set; }
        public int idFuncionDinamica { get; set; }
        public string cIdsSectorEcon { get; set; }
        public string cAlertaVariable { get; set; }
        public string cDescripcion { get; set; }
        public string cCondicion { get; set; }
        public int idTipoValor { get; set; }
        public bool lReqVistoBueno { get; set; }
        public bool lVigente { get; set; }

        public clsAlertaVariable()
        {
            this.idAlertaVariable = 0;
            this.idClaseAnalisis = 0;
            this.cClaseAnalisis = string.Empty;
            this.idTipoAnalisis = 0;
            this.cTipoAnalisis = string.Empty;
            this.idFuncionDinamica = 0;
            this.cIdsSectorEcon = string.Empty;
            this.cAlertaVariable = string.Empty;
            this.cDescripcion = string.Empty;
            this.cCondicion = string.Empty;
            this.idTipoValor = 0;
            this.lReqVistoBueno = false;
            this.lVigente = false;
        }
    }
}
