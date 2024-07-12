using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsIngresoVentaActivoRural
    {
        public int idIngVtaInvAtvRural { get; set; }
        public int idEvalCred { get; set; }
        public string cProducto { get; set; }
        public int idUnidadMedida { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nKgxGanado { get; set; }
        public decimal nPrecio { get; set; }
        public decimal nTotal
        {
            get { return (nKgxGanado * nPrecio) * nCantidad; }
            set { }
        }
        public int dFechaVenta { get; set; }
    }
}