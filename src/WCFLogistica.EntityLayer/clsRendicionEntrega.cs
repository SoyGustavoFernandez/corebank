using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsRendicionEntrega
    {
        public int idRendicion { get; set; }
        public int? idEntrega { get; set; }
        public decimal? nMontoRendido { get; set; }
        public decimal? nMontoFavor { get; set; }
        public decimal? nMontoSobrante { get; set; }
        public int? idUsuario { get; set; }
        public DateTime? dFecha { get; set; }
        public bool? lVigente { get; set; }
        public int? idUsuMod { get; set; }
    }
}
