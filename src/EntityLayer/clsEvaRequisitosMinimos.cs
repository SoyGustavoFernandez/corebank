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
   public class clsEvaRequisitosMinimos:ICloneable
    {
       public int idEvaReqMin { get; set; }
       public int? idReqMinimo { get; set; }
       public int? idDetalleNotaPedido { get; set; }
       public int? idProcesoAdj { get; set; }
       public int? idProveedor { get; set; }  
       public int? nItem	{get;set;}
       public int? idTipoReqMinimo {get;set;}
       public string cTipoReqMinimo { get; set; }
       public string cSustento	{get;set;}
       public int? idEstadoEvaGen { get; set; }
       public bool lIndica { get; set; }
       public bool lVigente { get; set; }

       public clsEvaRequisitosMinimos() { }

       public clsEvaRequisitosMinimos(clsEvaRequisitosMinimos objEvaReqMin) 
       {
           this.idEvaReqMin = objEvaReqMin.idEvaReqMin;
           this.idReqMinimo = objEvaReqMin.idReqMinimo;
           this.idDetalleNotaPedido = objEvaReqMin.idDetalleNotaPedido;
           this.idProcesoAdj = objEvaReqMin.idProcesoAdj;
           this.idProveedor = objEvaReqMin.idProveedor;
           this.nItem = objEvaReqMin.nItem;
           this.idTipoReqMinimo = objEvaReqMin.idTipoReqMinimo;
           this.cTipoReqMinimo = objEvaReqMin.cTipoReqMinimo;
           this.cSustento = objEvaReqMin.cSustento;
           this.idEstadoEvaGen= objEvaReqMin.idEstadoEvaGen;           
           this.lIndica = objEvaReqMin.lIndica;
       }

       public object Clone()
       {
           return new clsEvaRequisitosMinimos()
           {
               idEvaReqMin = this.idEvaReqMin,
               idReqMinimo = this.idReqMinimo,
               idDetalleNotaPedido = this.idDetalleNotaPedido,
               idProcesoAdj = this.idProcesoAdj,
               idProveedor = this.idProveedor,
               nItem = this.nItem,
               idTipoReqMinimo = this.idTipoReqMinimo,
               cTipoReqMinimo = this.cTipoReqMinimo,
               cSustento = this.cSustento,
               idEstadoEvaGen = this.idEstadoEvaGen,
               lIndica = this.lIndica,
               lVigente = this.lVigente
           };
       }
    }
   public class clsListaEvaRequisitosMinimos : List<clsEvaRequisitosMinimos>
   {
       public clsListaEvaRequisitosMinimos() { }

       public clsListaEvaRequisitosMinimos(IList<clsEvaRequisitosMinimos> lstEvaReqMin)
       {
           foreach (var item in lstEvaReqMin)
           {
               this.Add(new clsEvaRequisitosMinimos(item));
           }
       }

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
