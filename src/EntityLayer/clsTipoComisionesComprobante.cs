using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsTipoComisionesComprobante
    {
        public bool lOpcion { get; set; }
        public int idTipoComisionComprPago { get; set; }
        public string cComision { get; set; }
        public decimal nMonto { get; set; }
        public int idComprobantePago { get; set; }
        public bool lVigente { get; set; }
    }
    public class clsListaTipoComisionesCpg : List<clsTipoComisionesComprobante>
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
