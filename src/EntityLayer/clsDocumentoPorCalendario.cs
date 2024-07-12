using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsDocumentoPorCalendario
    {
        public int idCalendario { get; set; }
        public int idEtapaCalendario { get; set; }
        public int idTipoDocProAdqui { get; set; }
        public string cDesTipoDoc { get; set; }
        public bool lVigente { get; set; }
        public clsDocumentoPorCalendario() { }

        public clsDocumentoPorCalendario(clsDocumentoPorCalendario objDocCal)
        {
            this.idCalendario = objDocCal.idCalendario;
            this.idEtapaCalendario = objDocCal.idEtapaCalendario;
            this.idTipoDocProAdqui = objDocCal.idTipoDocProAdqui;
            this.cDesTipoDoc = objDocCal.cDesTipoDoc;
            this.lVigente = objDocCal.lVigente;

        }
    }

    public class clsListaDocumentoPorCalendario : List<clsDocumentoPorCalendario>
    {
        public string obtenerXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
    }
    public class clsEvaDocumentoProceso
    {
        public int idEvaDocumento { set; get; }
        public int idCalendario { set; get; }
        public int idProveedor { set; get; }
        public int idProceso { set; get; }
        public int idTipoDocProAdqui { set; get; }
        public bool lVigente { set; get; }
        public string cTipoDocProAdqui { set; get; }
        public int? idEstadoEvaDoc { set; get; }
        public string dFechaEva { set; get; }
        public int idEtapaCalendario { set; get; }
    }
    public class clsListaEvaDocumentoProceso : BindingList<clsEvaDocumentoProceso>
    {
        public string obtenerXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, this);
                ms.Position = 0;
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }
    }   
}
