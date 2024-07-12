using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLogistica.EntityLayer
{
    public class clsEntregaRendir
    {
        public int idEntrega { get; set; }
        public int idTipoEntrega { get; set; }
        public int idEtapa { get; set; }
        public int idEstado { get; set; }
		public int idUsuario { get; set; }
		public int idPerfil { get; set; }
		public int idArea { get; set; }
        public int idAgencia { get; set; }
        public int idMoneda { get; set; }
        public decimal nMonto { get; set; }
        public string cMotivo { get; set; }
        public DateTime? dFecha { get; set; }        
        public int? nNivelSolicitud { get; set; }        
        public int? nNivelRendicion { get; set; }        
        public bool? lVigente { get; set; }

        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public string cEstado { get; set; }
        public string cPerfil { get; set; }
        public string cCentroCosto { get; set; }
        public string cAgencia { get; set; }
        public string cTipoEntrega { get; set; }
        public DateTime? dFechaSolicitud { get; set; }
        public DateTime? dFechaAprobacion { get; set; }
        public int? nEntregas { get; set; }

        public string cError { get; set; }
    }
}
