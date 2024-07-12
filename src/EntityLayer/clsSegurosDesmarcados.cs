using System;

namespace EntityLayer
{
    public class clsSegurosDesmarcados
    {
        public int idSeguroDesmarcado { get; set; }
        public int idSolicitud { get; set; }
        public int idSolicitudCreditoSeguro { get; set; }
        public int idTipoSeguro { get; set; }
        public DateTime dFecha { get; set; }
        public int idUsuario { get; set; }
        public string cSustento { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime dFecReg { get; set; }
        public DateTime dFecMod { get; set; }
        public bool lVigente { get; set; }

        public clsSegurosDesmarcados()
        {
            dFecMod = DateTime.Now;
        }
    }
}