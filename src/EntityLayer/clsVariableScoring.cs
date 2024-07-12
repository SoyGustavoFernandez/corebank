using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsVariableScoring
    {        
        public string cVariable{ get; set; }
		public string nRiesgoBajoValor{ get; set; }
		public decimal nRiesgoBajoCalificacion{ get; set; }
		public string nRiesgoMedioValor{ get; set; }
		public decimal nRiesgoMedioCalificacion{ get; set; }
		public string nRiesgoAltoValor{ get; set; }
		public decimal nRiesgoAltoCalificacion{ get; set; }
		public decimal nPuntuacion{ get; set; }
		public bool lVigente{ get; set; }
		public bool lExcluyente{ get; set; }
    }
}
