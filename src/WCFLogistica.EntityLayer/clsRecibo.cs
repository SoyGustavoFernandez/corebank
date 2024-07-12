using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsRecibo
    {
        public int idReciboRendicion { get; set; }
        public int? idEntrega { get; set; }
        public int? idTipRecibo { get; set; }
        public int? idConcepto { get; set; }
        public decimal? nMonto { get; set; }
        public DateTime? dFecha { get; set; }
        public int? idUsuario { get; set; }
        public int? idRecibo { get; set; }
        public bool? lVigente { get; set; }
        public string cSustento { get; set; }
        public int? idMoneda { get; set; }
    }
}
