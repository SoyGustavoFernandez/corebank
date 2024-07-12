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
    public class clsDetalleProcesoAdj
    {

        public int idProceso { get; set; }
        public int idDetalleNotapedido { get; set; }
        public int nItem { get; set; }
        public int idCatalogo { get; set; }
        public int idNotPedido { get; set; }
        public string cProducto { get; set; }
        public int idUnidad { get; set; }
        public string cUnidad { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nPrecioUnit { get; set; }
        public int? idGrupo { get; set; }
        public string cDesGrupo { get; set; }
        public decimal nsubTotal { get; set; }
        public int lIgv { get; set; }

        public clsDetalleProcesoAdj() { }

        public clsDetalleProcesoAdj(clsDetalleProcesoAdj objDetallePro)
        {
            this.idProceso = objDetallePro.idProceso;
            this.idDetalleNotapedido = objDetallePro.idDetalleNotapedido;
            this.nItem = objDetallePro.nItem;
            this.idCatalogo = objDetallePro.idCatalogo;
            this.idNotPedido = objDetallePro.idNotPedido;
            this.cProducto = objDetallePro.cProducto;
            this.idUnidad = objDetallePro.idUnidad;
            this.cUnidad = objDetallePro.cUnidad;
            this.nCantidad = objDetallePro.nCantidad;
            this.nPrecioUnit = objDetallePro.nPrecioUnit;
            this.idGrupo = objDetallePro.idGrupo;
            this.cDesGrupo = objDetallePro.cDesGrupo;
            this.nsubTotal = objDetallePro.nsubTotal;
            this.lIgv = objDetallePro.lIgv;
        }
    }

    public class clsListaDetalleProcesoAdj : BindingList<clsDetalleProcesoAdj>
    {
        public clsListaDetalleProcesoAdj() { }
        public clsListaDetalleProcesoAdj(IList<clsDetalleProcesoAdj> lstDet)
        {
            foreach (var item in lstDet)
            {
                this.Add(new clsDetalleProcesoAdj(item));
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

    public struct Grupo
    {
        public Grupo(int pidGrupo,string pDesGrupo)
        {
            _idGrupo = 0;
            _desGrupo = string.Empty;
            this.idGrupo = pidGrupo;
            this.DesGrupo = pDesGrupo;

        }
        private int _idGrupo;
        private string _desGrupo;
        public int idGrupo { get { return _idGrupo; } private set { _idGrupo = value; } }
        public string DesGrupo { get { return _desGrupo; } private set { _desGrupo = value; } }
    }
}
