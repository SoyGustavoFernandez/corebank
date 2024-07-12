using System;

namespace EntityLayer
{
    public class clsDesafiliarPaqueteSeguro
    {
        public int idCuenta { get; set; }
        public int idSeguroOpcional { get; set; }
        public decimal nMontoPrima { get; set; }
        public int idEstadoSeguroOpcional { get; set; }
        public string cEstadoSeguroOpcional { get; set; }
        public int idDetalleSeguroOpcional { get; set; }
        public int nCuota { get; set; }
        public int idEstadoCuota { get; set; }
        public string cEstadoCuota { get; set; }
        public decimal nMontoGeneradoCuota { get; set; }
        public DateTime dFechaInicioCobertura { get; set; }
        public DateTime dFechaFinCobertura { get; set; }
        public int idConcepto { get; set; }
        public string cConcepto { get; set; }
        public int idPaqueteSeguro { get; set; }
        public string cPaqueteSeguroCompleto { get; set; }
        public string cPaqueteSeguroCorto { get; set; }
        public int idSolicitud { get; set; }
    }
}
