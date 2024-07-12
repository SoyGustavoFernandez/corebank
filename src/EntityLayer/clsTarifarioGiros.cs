using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsTarifarioGiros
    {
        public int idGiroTarifario { get; set; }
        public int idMoneda { get; set; }
        public int idTipoPersona { get; set; }
        public int idTipComGiro { get; set; }        
        public decimal nMontoMinimo { get; set; }
        public decimal nMontoMaximo { get; set; }
        public decimal nMontoComision { get; set; }
    }
}
