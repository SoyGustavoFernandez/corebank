using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsNivelAprobaBase
    {
        public int idNivelAprobaBase { get; set; }
		public string cNivelAprobaBase { get; set; }
		public int idNivelAprobaBaseReq { get; set; }
		public int idModulo { get; set; }
		public int idTipoOperacion { get; set; }
		public int nOrdenAprobacion { get; set; }
		public int idUsuReg { get; set; }
		public DateTime dFechaReg { get; set; }
		public int idUsuMod	 { get; set; }
		public DateTime dFechaMod  { get; set; }
        public bool lVigente { get; set; }

        public int idCaracteristicaNA { get; set; }
        public string cCaracteristicaNA { get; set; }
        public string cRegla { get; set; }

        public string cCaracteristicaNAReemp{ get; set; }
        public string cReglaReemp { get; set; }
        public int idTipoVar { get; set; }
    }
}
