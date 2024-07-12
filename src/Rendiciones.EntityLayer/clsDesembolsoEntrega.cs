using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendiciones.EntityLayer
{
    public class clsDesembolsoEntrega
    {
        public int? idEntrega { get; set; }
        public int? idRecibo { get; set; }
        public decimal? nMonto { get; set; }
        public int? idUsuario { get; set; }
        public DateTime? dFecha { get; set; }
        public bool? lVigente { get; set; }

        public string cNombre { get; set; }
    }
}
