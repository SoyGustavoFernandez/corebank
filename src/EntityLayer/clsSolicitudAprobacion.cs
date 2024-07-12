using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudAprobacion
    {
        public int idSolicitudAproba{ get; set; }
		public string cSolicitudAproba{ get; set; }
		public int idDocumento{ get; set; }		
		public int idModulo{ get; set; }
		public int idTipoOperacion{ get; set; }
		public int idUsuReg	{ get; set; }
		public DateTime dFechaReg{ get; set; }
		public int idUsuMod{ get; set; }
		public DateTime dFechaMod{ get; set; }
		public int idNivelAprobaBase{ get; set; }
		public int idEstadoAproba{ get; set; }
        public bool lVigente { get; set; }
        public string cNombre { get; set; }		
        public string cProducto { get; set; }	
        public string cModulo { get; set; }
        public string cTipoOperacion{ get; set; }
        public string cWinUser { get; set; }
        public int idAgencia { get; set; }
        public int idProducto { get; set; }
        public string cSustento { get; set; }
        public int idNivelAprobaSol { get; set; }
        public int idCli { get; set; }
    }
}
