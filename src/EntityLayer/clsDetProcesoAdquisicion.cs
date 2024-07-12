using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetProcesoAdquisicion
    {
        public int idDetalleProcAdq { set; get; }
        public int idCatalogo { get { return objCatalogo.idCatalogo; } }
        public string cProducto { get { return objCatalogo.cProducto; } }
        public string cDetalleProducto { get; set; }
        public clsCatalogo objCatalogo { set; get; }
        public int idUniMedida { set; get; }
        public string cUnidMedida { set; get; }
        public decimal nCantidad { set; get; }

        public decimal nPrecioRef { set; get; }
        public int nDiasRef { set; get; }
        public decimal nLineaCreditoRef { set; get; }

        public decimal nPrecio { set; get;}
        public int nDias { set; get; }
        public decimal nLineaCredito { set; get; }
        public decimal nPuntaje { set; get; }

        public int idProvGanSis { set; get;}
        public int idprovGanModif {set; get; }

        public bool lVigente { set; get; }


        public clsDetProcesoAdquisicion(int idDetalleProcAdq)
        {
            this.idDetalleProcAdq = idDetalleProcAdq;
            this.objCatalogo = new clsCatalogo();
            this.nCantidad = 0;
            this.cDetalleProducto = "";

            this.nPrecioRef = 0;
            this.nDiasRef = 0;
            this.nLineaCreditoRef = 0;

            this.nPrecio = 0;
            this.nDias = 0;
            this.nLineaCredito = 0;
            this.nPuntaje = 0;

            this.lVigente = true;
        }

        public clsDetProcesoAdquisicion():this(0) { }

        public clsDetProcesoAdquisicion(clsDetProcesoAdquisicion objDetProcAdq)
        {
            this.idDetalleProcAdq = objDetProcAdq.idDetalleProcAdq;
            this.objCatalogo = objDetProcAdq.objCatalogo;
            this.nCantidad = objDetProcAdq.nCantidad;
            this.lVigente = objDetProcAdq.lVigente;
        }
    }
}
