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
   public class clsDetalleNotaPedido:ICloneable
    {
       public int? idDetalleNotaPedido { get; set; }
       public int nItem { get; set; }
       public int idNotaPedido { get; set; }
       public int idCatalogo { set; get; }
       public string cProducto { get; set; }
       public int idUnidad  { get; set; }
       public string cUnidad { get; set; }
       public decimal nCantidad { get; set; }
       public decimal  nPrecioUnit { get; set; }
       public decimal nSubTotal { get; set; }
       public string cEstado { get; set; }
       public decimal nCantApro { get; set; }
       public decimal nSubTotApro { get; set; }
       public bool lVigente { get; set; }
       public int? idProveedor { get; set; }

       public List<clsEvaRequisitosMinimos> lstReqMin { set; get; }

       public clsDetalleNotaPedido() : this(0) { }

       public clsDetalleNotaPedido(int idDetalleNotaPedido)
       {
           this.idDetalleNotaPedido = idDetalleNotaPedido;
           this.nItem = 0;
           this.idNotaPedido = 0;
           this.idCatalogo = 0;
           this.cProducto = string.Empty;
           this.idUnidad = 0;
           this.cUnidad = string.Empty;
           this.nCantidad = 0;
           this.nPrecioUnit = 0;
           this.nSubTotal = 0;
           this.cEstado = string.Empty;
           this.nCantApro = 0;
           this.nSubTotApro = 0;
           this.lVigente = true;
           this.idProveedor = 0;
           this.lstReqMin = new List<clsEvaRequisitosMinimos>();
       }

       public clsDetalleNotaPedido(clsDetalleNotaPedido objDetNotPed) 
       {
           this.idDetalleNotaPedido = objDetNotPed.idDetalleNotaPedido;
           this.nItem = objDetNotPed.nItem;
           this.idNotaPedido = objDetNotPed.idNotaPedido;
           //this.idGrupoActivo = objDetNotPed.idGrupoActivo;
           this.idCatalogo = objDetNotPed.idCatalogo;
           this.cProducto = objDetNotPed.cProducto;
           this.idUnidad = objDetNotPed.idUnidad;
           this.cUnidad = objDetNotPed.cUnidad;
           this.nCantidad = objDetNotPed.nCantidad;
           this.nPrecioUnit = objDetNotPed.nPrecioUnit;
           this.nSubTotal = objDetNotPed.nSubTotal;
           this.cEstado = objDetNotPed.cEstado;
           this.nCantApro = objDetNotPed.nCantApro;
           this.nSubTotApro = objDetNotPed.nSubTotApro;
           this.lVigente = objDetNotPed.lVigente;
           this.idProveedor = objDetNotPed.idProveedor;
       }

       public object Clone()
       {
           return new clsDetalleNotaPedido()
           {
               idDetalleNotaPedido = this.idDetalleNotaPedido,
               nItem = this.nItem,
               idNotaPedido = this.idNotaPedido,
               idCatalogo = this.idCatalogo,
               cProducto = this.cProducto,
               idUnidad = this.idUnidad,
               cUnidad = this.cUnidad,
               nCantidad = this.nCantidad,
               nPrecioUnit = this.nPrecioUnit,
               nSubTotal = this.nSubTotal,
               cEstado = this.cEstado,
               nCantApro = this.nCantApro,
               nSubTotApro = this.nSubTotApro,
               lVigente = this.lVigente,
               idProveedor = this.idProveedor,
               lstReqMin = this.lstReqMin
           };
       }
    }

   public class clsListaDetNotaPedido :BindingList<clsDetalleNotaPedido>
    {
       public clsListaDetNotaPedido() { }

       public clsListaDetNotaPedido(IList<clsDetalleNotaPedido> lstDetNotPed)
       {
           foreach (var item in lstDetNotPed)
           {
               this.Add(new clsDetalleNotaPedido(item));
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
