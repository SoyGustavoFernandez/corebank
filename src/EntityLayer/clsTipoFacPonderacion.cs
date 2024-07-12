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
    public class clsTipoFacPonderacion
    {
        public int idTipoFacPonderacion { get; set; }
        public string cFactorPonderacion {get;set;}
        public int  idTipoPedido	{get;set;}
        public decimal nEvaMin	{get;set;}
        public decimal nEvaMax	{get;set;}
        public decimal nFacMin {get;set;}
        public decimal nFacMax	{get;set;}
        public decimal nTotal	{get;set;}
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
    public class clsListaTipoFacPonderacion : List<clsTipoFacPonderacion>
    {
    }
    public class clsFactorPonderacion
    {
        public int? idTipoFacPonderacion { set; get; }
        public int ? idProceso {set;get;}
        public int ? idGrupo	{set;get;}
        public bool ? lVigente	{set;get;}
        
        public string cFacPonderacion { set; get; }//

        public decimal nEvaluacion	{set;get;}
        public decimal nEvaMin { set; get; }//
        public decimal nEvaMax { set; get; }//

        public decimal nFactibilidad {set;get;}
        public decimal nFacMin { set; get; }//
        public decimal nFacMax { set; get; }//

        public decimal nEvaTotal { set; get; }
        public decimal nTotal { set; get; }//

    }
    public class clslistaFactorPonderacion : List<clsFactorPonderacion>
    {
        
    }
}
