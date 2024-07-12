using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetNotaSalida
    {
        public int idDetalleNotaSalida { set; get; }
        public string cProducto { get { return objCatalogo.cProducto; } }
        public clsCatalogo objCatalogo { set; get; }
        public int idCatalogo { get { return objCatalogo.idCatalogo; } }
        public int idUniMedida { set; get; }
        public string cUnidMedida { set; get; }
        public decimal nCantidadSol { set; get; }
        public decimal nCantidadApro { set; get; }
        public decimal nCantidadAten { set; get; }
        public decimal nStock { get { return objCatalogo.nCantidadVirtual; } }
        public bool lVigente { set; get; }


        public clsDetNotaSalida(int idDetalleNotaSalida)
        {
            this.idDetalleNotaSalida = idDetalleNotaSalida;
            this.objCatalogo = new clsCatalogo();
            this.nCantidadSol = 0;
            this.nCantidadApro = 0;
            this.nCantidadAten = 0;
            this.lVigente = true;
        }

        public clsDetNotaSalida():this(0) { }

        public clsDetNotaSalida(clsDetNotaSalida objDetNotaSalida)
        {
            this.idDetalleNotaSalida = objDetNotaSalida.idDetalleNotaSalida;
            this.objCatalogo = objDetNotaSalida.objCatalogo;
            this.nCantidadSol = objDetNotaSalida.nCantidadSol;
            this.nCantidadApro = objDetNotaSalida.nCantidadApro;
            this.nCantidadAten = objDetNotaSalida.nCantidadAten;
            this.lVigente = objDetNotaSalida.lVigente;
        }
    }
}
