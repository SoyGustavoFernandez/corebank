using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class clsVarNivelAproBase
    {
        public int idVarNivelAproBase { get; set; }
        public string cVarNivelAproBase { get; set; }
        public string cDescripcion { get; set; }
        public string cTipoDato { get; set; }
        public int idModulo { get; set; }
        public int idTipoOperacion { get; set; }
        public bool lVigente { get; set; }
    }
}
