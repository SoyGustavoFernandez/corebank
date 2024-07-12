using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsAprobacionEntrega
    {
        public int? idAprobSolicitud { get; set; }
        public int? idPerfilAprobSolicitud { get; set; }
        public int? idEntrega { get; set; }
        public int? idEstado { get; set; }
        public int? idUsuario { get; set; }
        public int? idAgencia { get; set; }
        public DateTime? dFecha { get; set; }
        public string cComentario { get; set; }
        public bool? lVigente { get; set; }
        
        public int? nNivel { get; set; }
        public string cNivelAprobacion { get; set; }
        public int? idNivelAprueba { get; set; }
        public string cPerfilAprueba { get; set; }
        public string cDecision { get; set; }
        public string idPerfilAprobadores { get; set; }
        public string cPerfilAprobadores { get; set; }
        public DateTime? dFechaSolicitud { get; set; }
        public DateTime? dFechaAprobacion { get; set; }
        public string cEstado { get; set; }
        public string cAprobador { get; set; }
        public string cPerfilAprobador { get; set; }

        public string cTipoAprobacion { get; set; }
        public string cTipoEntrega{ get; set; }
        public int nEntregas { get; set; }
        public int nOrden { get; set; }
    }
}
