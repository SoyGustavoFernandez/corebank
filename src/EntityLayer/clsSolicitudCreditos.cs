using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSolicitudCreditos
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idOperacion { get; set; }
        public int IdMoneda { get; set; }
        public int idUsuario { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public System.DateTime dFechaRegistro { get; set; }
        public System.DateTime dFechaDesembolsoSugerido { get {
            return DateTime.ParseExact(this.cFechaDesembolsoSugerido, "yyyy-MM-dd", CultureInfo.CurrentCulture);
        } }
        public string cFechaDesembolsoSugerido { get; set; }
        public string tObservacion { get; set; }
        public int idDestino { get; set; }
        public int idAgencia { get; set; }
        public int idTasa { get; set; }
        public int idModalidadDes { get; set; }
        public int ndiasgracia { get; set; }
        public int idActividad { get; set; }
        public decimal nTasaCostoEfectivo { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idRecurso { get; set; }
        public int idAdeudado { get; set; }
        public decimal nSaldoCreditos { get; set; }
        public decimal nTasaEfectivaAnual { get; set; }
        public int nTotalDiasCredito { get; set; }
        public System.DateTime dFechaUltimoPago { get {
            return DateTime.ParseExact(this.cFechaUltimoPago, "yyyy-MM-dd", CultureInfo.CurrentCulture);
        } }
        public string cFechaUltimoPago { get; set; }
        public int idModalidadCredito { get; set; }
        public int idPromotor { get; set; }
        public string cComentAproba { get; set; }
        public int idActividadInterna { get; set; }
        public int idPreSolicitud { get; set; }
        public bool lVerificacion { get; set; }
        public string cVerificacion { get; set; }
        public bool lDesembolsoExterno { get; set; }
        public bool lExtractoPagos { get; set; }
        public int idMedioEnvio { get; set; }
        public int idSolAproba { get; set; }
        public int idNivelAprRanOpe { get; set; }
        public int idMotivoDeniega { get; set; }
        public int idUsuRegistro { get; set; }
        public string cPcRegistro { get; set; }
        public int idUsuModifica { get; set; }
        public int nCuotasGracia { get; set; }
        public bool lConTasaNegociable { get; set; }
        public int idTipoCli { get; set; }
        public int idUsuApro { get; set; }
        public int idTipoComiteCred { get; set; }
        public int idEstablecimiento { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public decimal nCuotaAprox { get; set; }
        public decimal nCuotaGraciaAprox { get; set; }
        public int idCreditosPreAprobados { get; set; }
        public int idPeriodoCred { get; set; }
        public int idCanalRegistro { get; set; }
        public int idCanalRegistroAproba { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public string cFechaPrimeraCuota { get; set; }
        public DateTime dFechaPrimeraCuota
        {
            get { 
            return DateTime.ParseExact(this.cFechaPrimeraCuota, "yyyy-MM-dd", CultureInfo.CurrentCulture);
        } }
        public clsWCFRespuesta oResultado;
        public int idDetalle { get; set; }
        public string cNombre { get; set; }						
        public string cWinUser { get; set; }
        public string cGrupoCamp { get; set; }
        public string cDireccion { get; set; }
        public int idGrupoCamp { get; set; }
        public decimal nMonto	{ get; set; }
        public decimal nTasaCampana { get; set; }
        public int idVisita { get; set; }
        public List<clsCreditoCliente> lstCreditos { get; set; }
        public int idScore { get; set; }
    }
}
