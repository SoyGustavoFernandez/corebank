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
    public class clsConfigDocxMonto: clsConfiguracionDocumento
        {
            //public int id { get; set; }
            //public int idPadre { get; set; }
            //public bool lVisible { get; set; }
            //public string cDescripcion { get; set; }
            //public bool lObligatorio { get; set; }

            public decimal nMontoMinimo { get; set; }
            public decimal nMontoMaximo { get; set; }
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
    public class clsListaConfigDocxMonto : BindingList<clsConfigDocxMonto>
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
