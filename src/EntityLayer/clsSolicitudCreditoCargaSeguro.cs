using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntityLayer
{
    public class clsSolicitudCreditoCargaSeguro
    {
        public int idSolicitud { get; set; }
        public int idProducto { get; set; }
        public int idOperacion { get; set; }
        public decimal nMontoCoberturaSeguro { get; set; }
        public int nPlazoCoberturaSeguro { get; set; }
        public decimal nMontoPrimaTotal { get; set; }
        [XmlIgnore]
        public int idEstadoSolicitud { get; set; }
        public decimal nMontoSolicitado { get; set; }
        public decimal nMontoAmpliado { get; set; }
        [XmlIgnore]
        public int nCuotas { get; set; }
        [XmlIgnore]
        public int idTipoPlazo { get; set; }
        [XmlIgnore]
        public int nPlazo { get; set; }
        [XmlIgnore]
        public int idMoneda { get; set; }
        [XmlIgnore]
        public string cMoneda { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public DateTime dFechaCancelacion { get; set; }
        [XmlIgnore]
        public int nDiasGracia { get; set; }
        [XmlIgnore]
        public int nCuotaGracia { get; set; }
        public bool lAceptacionListaSeguro { get; set; }
        public bool lAceptacionInclusionCapital { get; set; }
        [XmlIgnore]
        public bool lParametrosActualizado { get; set; }
        public List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro { get; set; }
        public List<clsSegurosDesmarcados> lstSegurosDesmarcados { get; set; }
        public List<clsSegurosDesmarcados> lstSegurosCambiados { get; set; }
        [XmlIgnore]
        public bool lPlanPagosGenerado { get; set; }
        public int idCli { get; set; }
        public int nEstado { get; set; }
        public int nEsSimulador { get; set; }
        public bool lEsPlanPagos { get; set; }
        public bool lEsDesembolso { get; set; }
        public bool lEsRegistro { get; set; }
        public DateTime dFechaPrimeraCuota { get; set; }
        public bool lCuotasConstantes { get; set; }
        public bool lPrimaModificada { get; set; }

        public int idPaqueteSeguro { get; set; }
        public int idFrmPaqueteSeguro { get; set; }     //1: Registrado en solicitud        2: Registrado en Plan de Pagos      3: Evaluación
        public bool lPlanSeguroBD { get; set; } //Validar si el plan de seguro viene de BD o se adquirió de manera local
        public int idDetalleGasto { get; set; }
        public int idTipoPagoSeguroOptativo { get; set; }
        public clsSolicitudCreditoCargaSeguro()
        {
            idSolicitud                     = 0;
            idProducto                      = 0;
            idOperacion                     = 0;
            nMontoCoberturaSeguro           = 0;
            nPlazoCoberturaSeguro           = 0;
            nMontoPrimaTotal                = 0;
            idEstadoSolicitud               = 0;
            nMontoSolicitado                = 0;
            nCuotas                         = 0;
            idTipoPlazo                     = 0;
            nPlazo                          = 0;
            idMoneda                        = 0;
            cMoneda                         = String.Empty;
            dFechaDesembolso                = clsVarGlobal.dFecSystem;
            dFechaCancelacion               = clsVarGlobal.dFecSystem;
            dFechaPrimeraCuota              = clsVarGlobal.dFecSystem;
            nDiasGracia                     = 0;
            nCuotaGracia                    = 0;
            lAceptacionListaSeguro          = false;
            lAceptacionInclusionCapital     = false;
            lParametrosActualizado          = false;
            idTipoPagoSeguroOptativo        = 0;
            lstSolicitudCreditoSeguro       = new List<clsSolicitudCreditoSeguro>();
            lPlanPagosGenerado              = false;

            idCli = 0;
            nEstado = 0;
            nEsSimulador = 0;
        }
    }
}
