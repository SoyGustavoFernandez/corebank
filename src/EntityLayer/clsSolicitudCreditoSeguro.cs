using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudCreditoSeguro
    {
        public int idSolicitudCreditoSeguro { get; set; }
        public int idSolicitud { get;  set; }
        public bool lSeleccionado { get; set; }
        public int idTipoSeguro { get; set; }
        public string cTipoSeguro { get; set; }
        public decimal nValor { get; set; }
        public int idTipoValor { get; set; }
        public int idConceptoRecibo { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public decimal nMontoCobertura { get; set; }
        public int nPlazoCobertura { get; set; }
        public decimal nValorCobertura { get; set; }
        public decimal nMontoPrima { get; set; }
        public DateTime dFechaInicioVigencia { get; set; }
        public DateTime dFechaFinVigencia { get; set; }
        public int idZona { get; set; }
        public int idAgencia { get; set; }
        public int idUsuario { get; set; }
        public int idCargo { get; set; }
        public string cCargo { get; set; }
        public int idUsuarioCancelacion { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaCancelacion { get; set; }
        public bool lVigente { get; set; }
        public int idKardexRetiro { get; set; }
        public int idKardexRecibo { get; set; }
        public int idCli { get; set; }
        public int idCanalRegistro { get; set; }
        public bool lPagoCuotas { get; set; }
        public bool lHistorico { get; set; }
        public bool lCambioPrima { get; set; }
        public bool lModificado { get; set; }
        public bool lPermitirMarcacion { get; set; }
        public int idConcepto { get; set; }
        public int idTipoPagoSeguroOptativo { get; set; }

        public clsSolicitudCreditoSeguro()
        {
            idSolicitudCreditoSeguro    = 0;
            idSolicitud                 = 0;
            lSeleccionado               = false;
            idTipoSeguro                = 0;
            cTipoSeguro                 = String.Empty;
            nValor                      = 0;
            idTipoValor                 = 0;
            idConceptoRecibo            = 0;
            idMoneda                    = 0;
            cMoneda                     = String.Empty;
            nMontoCobertura             = 0;
            nPlazoCobertura             = 0;
            nValorCobertura             = 0;
            nMontoPrima                 = 0;
            dFechaInicioVigencia        = clsVarGlobal.dFecSystem;
            dFechaFinVigencia           = clsVarGlobal.dFecSystem;
            idAgencia                   = 0;
            idZona                      = 0;
            idUsuario                   = 0;
            idCargo                     = 0;
            cCargo                      = String.Empty;
            idUsuarioCancelacion        = 0;
            dFechaRegistro              = clsVarGlobal.dFecSystem;
            dFechaCancelacion           = clsVarGlobal.dFecSystem;
            lVigente                    = false;
            idKardexRetiro = 0;
            idKardexRecibo = 0;
            idCli = 0;
            idCanalRegistro = 0;
            lPermitirMarcacion = true;
            idConcepto = 0;
            idTipoPagoSeguroOptativo = 0;
        }
    }
}
