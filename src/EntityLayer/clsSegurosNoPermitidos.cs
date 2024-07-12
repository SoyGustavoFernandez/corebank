using System;

namespace EntityLayer
{
    public class clsSegurosNoPermitidos
    {
        public int idSeguroDesmarcado { get; set; }
        public int idTipoSeguro { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime dFecReg { get; set; }
        public DateTime dFecMod { get; set; }
        public bool lVigente { get; set; }
    }
}