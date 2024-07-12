using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsPagoGiro
    {
        public int idServicioGiro { get; set; }
        public int idEstablecimientoDestinatario { get; set; }
        public int idMoneda { get; set; }
        public string cClave { get; set; }
        public decimal nMontoGiro { get; set; }
        public decimal nMontoITF { get; set; }
        public decimal nMontoRedondeo { get; set; }
        public decimal nMontoEntregar { get; set; }
        public int idEstado { get; set; }
    }
}
