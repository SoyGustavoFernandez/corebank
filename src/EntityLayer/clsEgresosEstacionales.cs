using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEgresosEstacionales
    {
        public Guid idEgresoEstacional { get; set; }
        public int idEvalCre { get; set; }
        public string cNombreInsumo { get; set; }
        public decimal nExtension { get; set; }
        public decimal nCantidad { get; set; }
        public decimal nPrecio { get; set; }
        public decimal nGasto
        {
            get {return this.nPrecio * this.nCantidad * this.nExtension;}
            set {   }
        }
        public int nFecha { get; set; }
        public Guid idIngresoEstacional { get; set; }

    }
}
