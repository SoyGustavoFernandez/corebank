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
   public class clsConfiguracionTipoArchivoEscaneado
   {
       public int idSubProducto { get; set; }
       public string cSubProducto { get; set; }
       public int idTipoCredito { get; set; }
       public string cTipoCredito { get; set; }
        public int idTipoPersona { get; set; }
        public string cTipoPersona { get; set; }
        public int idTipoOperacion { get; set; }
        public string cTipoOperacion { get; set; }  
        public int idDestinoCredito { get; set; }
        public string cDestinoCredito { get; set; }
        public int idRangoMonto { get; set; }
        public string cRangoMonto { get; set; }
        public int idTipoArchivo { get; set; }
        public string cTipoArchivo { get; set; }
        public bool lVisible { get; set; }
        public bool lObligatorio { get; set; }
        public string cTipoCreditoSubProducto
        {
            get
            {
                return this.cTipoCredito +" - "+ this.cSubProducto;
            }
            set
            {
                this.cTipoCreditoSubProducto = value;
            }
        }
        //public int idUsuReg { get; set; }
        //public DateTime dFecRegistro { get; set; }
        //public int? idUsuAct { get; set; }
        //public DateTime? dFecAct { get; set; }
    }
   public class clsListaConfiguracionTipoArchivoEscaneado : BindingList<clsConfiguracionTipoArchivoEscaneado>
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
