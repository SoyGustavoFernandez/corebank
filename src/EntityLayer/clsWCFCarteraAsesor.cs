using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsWCFCarteraAsesor
    {
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public int idActividad { get; set; }
        public int idActivEcoInterna { get; set; }
        public int nIdActivEco { get; set; }
        public int idActivEcoAdicional { get; set; }
        public int idTipoPersona { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cApellidoCasada { get; set; }
        public string cNombre { get; set; }
        public string cRazonSocial { get; set; }
        public int idSexo { get; set; }
        public int nNumPerDepend { get; set; }
        public int idUbigeo { get; set; }
        public int idUbigeoNacimiento { get; set; }
        public int idDireccion { get; set; }
        public int idCargo { get; set; }
        public int idTipoDireccion { get; set; }
        public string cDireccion { get; set; }
        public int idCodTelFijo { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cNumeroTelefono2 { get; set; }
        public string cCorreoCli { get; set; }
        public double nLatitude { get; set; }
        public double nLongitude { get; set; }
        public int nAtraso { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public int idCuenta { get; set; }
        public decimal nSaldoCapital { get; set; }
        public string dFechaDesembolso { get; set; }
        public int nDigitoVerificador { get; set; }
        public int idEstadoCivil { get; set; }
        public string dFechaNacimiento { get; set; }
        public string cFotografia { get; set; }
    }

    public class clsWCFCarteraRecuperador
    {
        public int idCli { get; set; }
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public int idActividad { get; set; }
        public int idActivEcoInterna { get; set; }
        public int nIdActivEco { get; set; }
        public int idActivEcoAdicional { get; set; }
        public int idTipoPersona { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cApellidoCasada { get; set; }
        public string cNombre { get; set; }
        public string cRazonSocial { get; set; }
        public int idSexo { get; set; }
        public int nNumPerDepend { get; set; }
        public int idUbigeo { get; set; }
        public int idUbigeoNacimiento { get; set; }
        public int idDireccion { get; set; }
        public int idCargo { get; set; }
        public int idTipoDireccion { get; set; }
        public string cDireccion { get; set; }
        public int idCodTelFijo { get; set; }
        public string nNumeroTelefono { get; set; }
        public string cNumeroTelefono2 { get; set; }
        public string cCorreoCli { get; set; }
        public double nLatitude { get; set; }
        public double nLongitude { get; set; }
        public int nAtraso { get; set; }
        public decimal nCapitalDesembolso { get; set; }
        public int idCuenta { get; set; }
        public decimal nSaldoCapital { get; set; }
        public int nUltContacto { get; set; }
        public int nVisitas { get; set; }
        public string dFechaPromesa { get; set; }
        public decimal nMontoPromesa { get; set; }
        public string dFechaDesembolso { get; set; }
        public string cAgencia { get; set; }
        public string cProducto { get; set; }
        public int nDigitoVerificador { get; set; }
        public int idEstadoCivil { get; set; }
        public string dFechaNacimiento { get; set; }
        public string cFotografia { get; set; }
    }

    public class clsWCFGestionCliente
    {
        public string cCargo { get; set; }
        public int idCli { get; set; }
        public string dtFechaGestion { get; set; }
    }

    public class clsCampana 
    { 
        public int idGrupoCamp { get; set; }
        public string cGrupoCamp { get; set; }
        public bool lVigente { get; set; }
    }

    public class clsClienteCampana 
    { 
        public string cNombre{ get; set; }	
        public string cDocumentoID	{ get; set; }
        public decimal nMonto	{ get; set; }
        public decimal nTasa	{ get; set; }
        public decimal nMontoPreAprobado	{ get; set; }
        public string cGrupoCamp{ get; set; }
        public int idGrupoCamp { get; set; }

    }

    public class clsSolicitudEvaluacion
    {
        public int idSolicitud  { get; set; }
        public string cGrupoCamp  { get; set; }
        public string cTipoGrupoCamp { get; set; }
        public string cDestino { get; set; }
        public int idDestino { get; set; }


        public int idCliente { get; set; }
        public int idTipoGrupoCamp { get; set;}
        public int idTipoPersona { get; set; }
        public int idSexo { get; set; }
        public string cNombres { get; set; }
        public string cDocumentoID { get; set; }
        public decimal nMonto { get; set; }
        public int idMoneda { get; set; }
        public string cSimbolo { get; set; }
        public decimal nTasa { get; set; }
        public int nPlazo { get; set; }
        public int idProducto { get; set; }

        public string cComentario { get; set; }
        public int idUsuario { get; set; }
        public int idEstado { get; set; }
        public int idTipEvalCred { get; set; }
        public int idEvalCred { get; set; }
        public string cNivelAprobacion { get; set; }
        public decimal nCuotaAprox { get; set; }
        public int idEtapaEvalCred { get; set; }
        public int idEstadoEvalCred { get; set; }
        public int idOperacion { get; set; }
        public int idGrupoCamp { get; set; }
    }

    public class clsEstadoResultados
    {
        public int idItemEstRes { get; set; }
        public int idEstResEval { get; set; }
		public int nTipoTrans { get; set; }
		public int nOrden { get; set; }
		public string cDescripcion { get; set; }
		public int idEEFF { get; set; }
	    public decimal nTotalMA { get; set; }
        public decimal nAnalisisVertiAndy { get; set; }
    }

    public class clsBalanceGeneral
    {
        public int idTipEvalCred { get; set; }
        public int idItemBalGen { get; set; }
        public int idBalGenEval { get; set; }
        public int nNivel { get; set; }
        public int nOrden { get; set; }
        public string cDescripcion { get; set; }
        public int idEEFF { get; set; }
        public decimal nTotalMA { get; set; }
        public decimal nAnalisisVertical { get; set; }
    }

    public class clsCondicionesCredito
    {
        public int nCuotas  { get; set; }
        public int nDiasGracia { get; set; }
        public int idPeriodoCred { get; set; }
        public string cFechaDesembolso { get; set; }
        public string cFechaPrimeraCuota { get; set; }
        public decimal nCapitalPropuesto { get; set; }
        public int idTasa { get; set; }
        public decimal nTEA { get; set; }
        public decimal nTIM { get; set; }
        public int idProducto { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuotaPropuesto { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public decimal nTasaCampana { get; set; }
        public decimal nMontoCampana { get; set; }
        public clsWCFRespuesta oRes { get; set; }
        public decimal nMontoAmpliado { get; set; }
        public bool lConsumo { get; set; }
        public decimal nCuotaAprox { get; set; }
    }
}
