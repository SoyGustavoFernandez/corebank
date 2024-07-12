using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsInversionInsumo
    {
        public Guid idInversionInsumo { get; set; }
        public string cNombreInsumo { get; set; }
        public int idUnidad { get; set; }
        public decimal nExtension { get; set; }
        public decimal nCantidad { get; set; }        
        public decimal nPrecio { get; set; }
        public decimal nTotal 
        { 
            get{ return this.nPrecio * this.nCantidad * this.nExtension; }
            set { }
        }
        public Guid idProyeccionIngreso { get; set; }
                
        public decimal nUnidadMedida { get; set; }

    }
}
