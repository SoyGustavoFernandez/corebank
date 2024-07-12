using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsEstablecimientoGestorRecuperacion
    {
        public int idEstablecimientoGestorRecuperacion { get; set; }
        public int idUsuRecuperador { get; set; }
        public int idEstablecimiento { get; set; }
        public bool lVigente { get; set; }

        public clsEstablecimientoGestorRecuperacion()
        {
            this.idEstablecimientoGestorRecuperacion = 0;
            this.idUsuRecuperador = 0;
            this.idEstablecimiento = 0;
            this.lVigente = true;
        }
    }
}
