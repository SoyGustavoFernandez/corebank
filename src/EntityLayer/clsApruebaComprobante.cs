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
   public class clsApruebaCPGPago
    {
       public bool lSeleccion { get; set; }
       public int idAprobador { get; set; }
       public string cAprobador { get; set; }        
       public bool lVigente { get; set; }
    }
   public class clsListaApruebaCPGPago : BindingList<clsApruebaCPGPago>
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
