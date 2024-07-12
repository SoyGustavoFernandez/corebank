using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetTranfAlmacen
    {
        public int idTrasferencia { set; get; }
        public int nItem { set; get; }
        public clsCatalogo objCatalogo { set; get; }
        
        public decimal nCantidad { set; get; }
        public decimal nPrecUni { set; get; }
        public bool lVigente { set; get; }
        public decimal nCantidadEntrega { set; get; }
        public decimal nPorEntregar { set; get; }

        public int idCatalogo { get { return objCatalogo.idCatalogo; } }
        public string cProducto { get { return objCatalogo.cProducto; } }
        public int idUnidadMedida { get { return objCatalogo.idUnidadAlmacenaje; } }
        public string cUnidad { get{return objCatalogo.cUnidAlmacenaje;} }
        public decimal nCantStock { get { return objCatalogo.nCantidadVirtual; } }
        public int idTipoBien { get { return objCatalogo.idTipoBien; } }

        public clsDetTranfAlmacen()
        {
            this.idTrasferencia = 0;
            this.objCatalogo = new clsCatalogo();
            this.nCantidad = 0;
            this.nPrecUni = 0;
            this.lVigente = true;
        }
    }
}
