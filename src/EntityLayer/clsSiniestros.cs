using System;

namespace EntityLayer
{
    public class clsSiniestros
    {
        public int nIdSeguroSiniestro { get; set; }
        public int nTipoSeguro { get; set; }
        public int idSeguro { get; set; }
        public int idAgencia { get; set; }
        public int idCli { get; set; }
        public int idRecibo { get; set; }
        public int idCuenta { get; set; }
        public decimal saldoCapital { get; set; }
        public DateTime dFecIniCobertura { get; set; }
        public DateTime dFecFinCobertura { get; set; }
        public DateTime dFechaSiniestro { get; set; }
        public int idEstadoSiniestro { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime dFecReg { get; set; }
        public DateTime dFecMod { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsEstadoSiniestros
    {
        public int idEstadoSiniestro { get; set; }
        public string cEstado { get; set; }
        public int idUsuReg { get; set; }
        public DateTime dFecReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime dFecMod { get; set; }
        public bool lVigente { get; set; }
    }
}