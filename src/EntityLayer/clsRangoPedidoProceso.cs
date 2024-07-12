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
    /// <summary>
    /// entidad RangoPedido de un Proceso
    /// </summary>
   public class clsRangoPedidoProceso
    {
        public int idTipoPedido	{get;set;}
        public int idTipoProceso	{get;set;}
        public string cTipoPedio { get; set; }
        public decimal nValorMin	{get;set;}
        public decimal nValorMax	{get;set;}
        public bool lVigente { get; set; }
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
       public int idTipoEvaluacion { get; set; }
       public int idRelPedidoProceso { get; set; }
    }
     /// <summary>
    /// coleccion de item de Rango de pedidos del proceso
    /// </summary>
    public class clsListaRangoPedidoProceso : List<clsRangoPedidoProceso>{
    }
    /// <summary>
    /// entidad Tipo de Pedio 
    /// </summary>
    public class clsTipoPedio
    {
        public int  idTipoPedido	{get;set;}
        public string  cTipoPedido	{get;set;}
        public bool lVigente { get; set; }
    }
    /// <summary>
    /// coleccion de item de tipos de pedidos
    /// </summary>
    public class clsListaTipoPedido:List<clsTipoPedio>{
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
    /// <summary>
    /// entidad Tipo de Proceso
    /// </summary>
    public class clsTipoProceso
    {
        public int  idTipoProceso	{get;set;}
        public string  cTipoProceso	{get;set;}
        public string cDescCorta	{get;set;}
        public bool lVigente { get; set; }
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
    /// <summary>
    /// coleccion de item de tipos de Proceso
    /// </summary>
    public  class clsListaTipoProceso:List<clsTipoProceso>{
    }
} 
