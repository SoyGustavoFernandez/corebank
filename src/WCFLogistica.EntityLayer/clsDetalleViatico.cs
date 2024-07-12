using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsDetalleViatico
    {
        public int idDetalleViatico { get; set; }
        public int idViatico { get; set; }
        public DateTime? dFecha { get; set; }
        public decimal? nAlimentacion { get; set; }
        public decimal? nHospedaje { get; set; }
        public decimal? nMovilidadLocal { get; set; }
        public decimal? nMovilidadAeropuerto { get; set; }
        public decimal? nPasajes { get; set; }
        public bool? lVigente { get; set; }
    }
}
