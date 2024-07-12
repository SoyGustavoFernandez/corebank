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
    public class clsVinculoNotaPedido
    {
        public int  idProceso {get;set;}
        public int idNotaPedido {get;set;}        
        public DateTime dFechaVinculacion	{get;set;}
        public int idUsuReg { get; set; }

        public bool lVigente { get; set; }
        public DateTime? dFechaMod {get;set;}        
        public int? idUsuMod {get;set;}

        public string cAgencia { get; set; }
        public string cArea { get; set; }        
        public int idMoneda { get; set; }
        public string cUsuReg { get; set; }
        public int idTipoPed { get; set; }
    }
    public class clslistaVinculoNotaPedido : BindingList<clsVinculoNotaPedido>
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
