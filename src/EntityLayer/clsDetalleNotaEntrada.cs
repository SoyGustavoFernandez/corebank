using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetalleNotaEntrada
    {
        public int nNum {set; get; }
		public int idNotaEntrada {set; get; }
        public decimal nTotal {set; get; }
        public int idCatalogo {set; get; }
        public string cProducto {set; get; }
        public int idUnidad { set; get; }
        public string cUnidad { set; get; }
        public decimal nCantidad { set; get; }
        public decimal nPrecioUnitario { set; get; }
        public decimal nSubTotal {set; get; }
        public int idTipoBien { set; get; }

        public List<clsActivo> lstActivos { set; get; }

        public clsDetalleNotaEntrada()
        {
            nNum = 0;
            idNotaEntrada = 0;
            nTotal = 0;
            idCatalogo = 0;
            cProducto = string.Empty;
            idUnidad = 0;
            cUnidad = string.Empty;
            nCantidad = 0;
            nPrecioUnitario = 0;
            nSubTotal = 0;
            idTipoBien = 0;
            lstActivos = new List<clsActivo>();
        }
    }
}
