
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer
{
  
    public  class clsPaqueteSeguro
    {
        public int idPaqueteSeguro {get; set; }
        public string cNombreCorto {get; set; }
        public string cNombreCompleto {get; set; }
        public decimal nPrecio {get; set; }
        public int idMoneda {get; set; }
        public string cMoneda {get; set; }
        public string cLink {get; set; }
        public string cCorreoReporte {get; set; }
        public int idDetalleGasto {get; set; }
        public string cDetalleGasto {get; set; }
        public int idTipoSeguro {get; set; }
        public string cTipoSeguro { get; set; }
    }
}
