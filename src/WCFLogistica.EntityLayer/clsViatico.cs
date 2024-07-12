using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsViatico
    {
        public int idViatico { get; set; }
        public int idEntrega { get; set; }
        public string cDestino { get; set; }
        public DateTime? dFechaHoraSalida { get; set; }        
        public DateTime? dFechaHoraRetorno { get; set; }        
        public int? idEscalaPersonal { get; set; }
        public int? idEscalaDestino { get; set; }
        public bool? lVigente { get; set; }
    }
}
