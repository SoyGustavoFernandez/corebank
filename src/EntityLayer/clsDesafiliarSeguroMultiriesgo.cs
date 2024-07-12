using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsDesafiliarSeguroMultiriesgo
    {
        public int idCuenta { get; set; }
        public int idSolicitud { get; set; }
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
    }
}
