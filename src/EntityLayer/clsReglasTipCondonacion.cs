using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SI_FinDetalleTipoCondonacion
    {
        public int idDetalleTipoCond { get; set; }
        public int idTipoCondonacion { get; set; }
        public int idTipoCartera { get; set; }
        public int idRangoTipoDato { get; set; }
        public string cRangoTipoDato { get; set; }
        public int nRangoMinimo { get; set; }
        public int nRangoMaximo { get; set; }
        public decimal nPorcDsctoCapital { get; set; }
        public decimal nPorcDsctoInteres { get; set; }
        public decimal nPorcDsctoIntComp { get; set; }
        public decimal nPorcDsctoMora { get; set; }
        public decimal nPorcDsctoGastos { get; set; }
        public bool lVigente { get; set; }
    }
}
