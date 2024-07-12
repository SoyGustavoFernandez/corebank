using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFResultadoGestion
    {
        public string cToken { get; set; }
        public int idDetalleHojaRuta { get; set; }
        public int idResultado { get; set; }
        public int idMotivoMora { get; set; }
        public int idTipoCliente { get; set; }
        public bool lRecuperable { get; set; }
        public string cObservacion { get; set; }
        public string dFechaPromesa { get; set; }
        public decimal nMontoPromesa { get; set; }
        public string cObservacionPromesa { get; set; }
        public bool lVisitar { get; set; }
        public string dFechaVisita { get; set; }
        public string cObservacionVisita { get; set; }
        public string cLatitud { get; set; }
        public string cLongitud { get; set; }
        public string dFechaRegCliente { get; set; }
        public bool lDomVerificado { get; set; }
        public bool lNotificacionEntregada { get; set; }
        public string dFechaRegistraCliente { get; set; }
    }
}
