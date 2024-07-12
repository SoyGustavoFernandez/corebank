using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFCreditosRecuperaciones
    {
        public string cNombre { get; set; }
        public string cTipoIntervencion { get; set; }
        public string cTipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public int idCli { get; set; }
        public int idSexo { get; set; }
        public string cUbigeo { get; set; }
        public int idDireccion { get; set; }
        public string cDireccion { get; set; }
        public int idCuenta { get; set; }
        public int idPlanPagos { get; set; }
        public string cEstado { get; set; }
        public int idIntervCre { get; set; }
        public string cCodCliente { get; set; }
        public string dFechaDesembolso { get; set; }
        public int nCuotas { get; set; }
        public decimal nMontoCuota { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public decimal nMontoDesembolsado { get; set; }
        public decimal nSaldoCapitalTotal { get; set; }
        public decimal nSaldoCapitalVencido { get; set; }
        public int nAtraso { get; set; }
        public string cEstadoCredito { get; set; }
        public string dFechaPago { get; set; }
        public int nCuotasAtrasadas { get; set; }
        public int nCuotasTotal { get; set; }
        public decimal nCuotaSaldoCapital { get; set; }
        public decimal nCuotaSaldoInteres { get; set; }
        public decimal nCuotaSaldoCompensatorio { get; set; }
        public decimal nCuotaSaldoMora { get; set; }
        public decimal nCuotaSaldoOtros { get; set; }
        public decimal nCuotaSaldoTotal { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public string cSimbolo { get; set; }

        public string dFechaGestion { get; set; }
        public string cAccionAnterior { get; set; }
        public string cAccionResultado { get; set; }
        public string cObservacionUlt { get; set; }
        public string cNombreUsuario { get; set; }
        public string cPerfilUsuario { get; set; }
        public IList<clsWCFPlanPagosPendientes> pagosPendientes { get; set; }
    }

    public class clsWCFPlanPagosPendientes
    {
        public int idCuota { get; set; }
        public int nAtrasoCuota { get; set; }
        public string dFechaProg { get; set; }
        public decimal nCapital { get; set; }
        public decimal nCapitalPagado { get; set; }
        public decimal nSalCap { get; set; }
        public decimal nInteres { get; set; }
        public decimal nSalTot { get; set; }
        public decimal nSalIntComp { get; set; }
        public decimal nSalMor { get; set; }
        public decimal nSalOtr { get; set; }
    }

    public class clsWCFResultadoRecuperacionVisita
    {
        public int idDetalleHojaRuta { get; set; }
        public int idResultado { get; set; }
        public int idMotivoMora { get; set; }
        public int idTipoCliente { get; set; }
        public bool lRecuperable { get; set; }
        public string cObservacion { get; set; }
        public string dFechaPromesa { get; set; }
        public decimal nMontoPromesa { get; set; }
        public string cObservacionPromesa { get; set; }
        public bool lVisitar { get; set; }
        public bool lDomVerificado { get; set; }
        public bool lNotificacionEntregada { get; set; }
        public int idCuenta { get; set; }
        public int idIntervCre { get; set; }
        public int idTipoAccion { get; set; }
        public int idTipoNotificacion { get; set; }
        public bool lRegistraNuevoTelefono { get; set; }
        public int idTipoNumeroTelefonico { get; set; }
        public int idCodigoDepartamental { get; set; }
        public string cNuevoNumeroTelefonico { get; set; }
        public bool lViewPromesaPago { get; set; }
    }
}
