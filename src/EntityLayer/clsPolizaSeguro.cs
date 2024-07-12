using System;

namespace EntityLayer
{
    public class clsPolizaSeguro
    {
        public int idPolizaSeguro { get; set; }
        public long nPoliza { get; set; }
        public int nTipoPoliza { get; set; }
        public string cPoliza { get; set; }
        public int idUsuReg { get; set; }
        public DateTime dFechaReg { get; set; }
        public int? idUsuMod { get; set; }
        public DateTime? dFechaMod { get; set; }
        public bool lVigente { get; set; }
        public int idVigente { get; set; }
    }
}