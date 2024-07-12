using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetalleOrdenCompra
    {
        public int idOrden { set; get; }
        public int nNum { set; get; }
        public int idCatalogo { set; get; }
        public int idProducto { set; get; }
        public string cProducto { set; get; }
        public decimal nCantidad { set; get; }
        public decimal nPrecioUnitario { set; get; }
        public decimal nSubTotal { set; get; }
        public decimal nCantidadEntrega { set; get; }
        public decimal nPorEntregar { set; get; }
        public bool lIncluImpuesto { set; get; }
        public int idNotaEntrada { set; get; }
        public decimal nTotal { set; get; }
        public string cDesTipoUniMed { set; get; }
        public int idTipoBien { set; get; }
        public int idUnidad { set; get; }
    }
}
