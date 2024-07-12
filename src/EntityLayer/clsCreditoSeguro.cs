using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsCreditoSeguro
    {
        public int idCreditoSeguro { get; set; }
        public int idCuenta { get; set; }
        public int idCliente { get; set; }
        public int idTipoSeguro { get; set; }
        public string cTipoSeguro { get; set; }
        public decimal nMontoPrima { get; set; }
        public decimal nMontoCobertura { get; set; }
        public string cMoneda { get; set; }
        public int nPlazoCobertura { get; set; }
        public int idMoneda { get; set; }
        public decimal nValorCobertura { get; set; }
        public int idConceptoRecibo { get; set; }
        public DateTime dFechaInicioVigencia { get; set; }
        public DateTime dFechaFinVigencia { get; set; }
        public int idZona { get; set; }
        public int idAgencia { get; set; }
        public int idUsuario { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idEstadoSeguro { get; set; }
        public string cEstadoSeguro { get; set; }
        public bool lVigente { get; set; }

        public clsCreditoSeguro()
        {
            idCreditoSeguro         = 0;
            idCuenta                = 0;
            idCliente               = 0;
            idTipoSeguro            = 0;
            cTipoSeguro             = String.Empty;
            nMontoPrima             = 0;
            nMontoCobertura         = 0;
            cMoneda                 = String.Empty;
            nPlazoCobertura         = 0;
            idMoneda                = 0;
            nValorCobertura         = 0;
            idConceptoRecibo        = 0;
            dFechaInicioVigencia    = clsVarGlobal.dFecSystem;
            dFechaFinVigencia       = clsVarGlobal.dFecSystem;
            idZona                  = 0;
            idAgencia               = 0;
            idUsuario               = 0;
            dFechaRegistro          = clsVarGlobal.dFecSystem;
            idEstadoSeguro          = 0;
            cEstadoSeguro           = String.Empty;
            lVigente                = false;
        }
    }
}
