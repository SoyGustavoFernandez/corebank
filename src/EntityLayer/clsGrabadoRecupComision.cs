using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGrabadoRecupComision
    {
        public int idRecuperacionComisionTipo { get; set; }
        public string cRecuperacionComisionTipo { get; set; }
        public bool lRegistrado { get; set; }
        public decimal nMontoComision { get; set; }
        public int idEstado { get; set; }
        public string cEstado { get; set; }


        public clsGrabadoRecupComision()
        {
            this.idRecuperacionComisionTipo = 0;
            this.cRecuperacionComisionTipo = string.Empty;
            this.lRegistrado = false;
            this.nMontoComision = decimal.Zero;
            this.idEstado = 0;
            this.cEstado = string.Empty;
        }
    }
}
