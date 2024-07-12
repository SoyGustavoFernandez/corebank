using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDetSolicitudAproba
    {
        public int idDetSolicitudAproba { get; set; }		
        public int idSolicitudAproba { get; set; }
		public int idVarNivelAproBase{ get; set; }
		public string cValor{ get; set; }
		public bool lVigente{ get; set; }
        public string cVarNivelAproBase { get; set; }
    }
}
