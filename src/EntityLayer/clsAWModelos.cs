using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class clsAWModelos
    {
    }

    public class clsAWCliente
    {        
        public int idCli { get; set; }
        public string cNombre { get; set; }    
        public int idTipoDocumento { get; set; }
        public int IdTipoPersona { get; set; }
        public int nIdActivEco { get; set; }    
        public string cDocumentoID { get; set; }
        public string cDocumentoAdicional { get; set; }    
        public string nNumeroTelefono { get; set; }
        public string cNumeroTelefono2 { get; set; }
        public string cCorreoCli { get; set; }    
        //cCodigoExped             VARCHAR(15),      
        public int? IdtipoDocAdicional { get; set; }
        public int idResiddencia { get; set; }    
        //IdClasificaDeudor        INT,
        //idVinculacionInst        INT,
        //idRelacLaboral           INT,    
        public int idPaisResidencia { get; set; }    
        //idTipoClienteEmpresarial INT,   
        public int? idMagnitudEmpresarial { get; set; }    
        //idIndRiesgoCambiario     INT,
        //idModeloRating           INT,
        //idCalifiConOverride      INT,
        //idCalifiSinOverride      INT,
        //idCalifRiesgoExterno     INT,
        //dFechaCalificaRating     DATETIME,
        //dfechaIngreso            DATETIME,
        //dfechaUltimaMod          DATETIME,
        //idUsuarioMod             INT,
        //idUsuarioReg             INT,
        //idAgenciaReg             INT,    
        public int idNacionalidad { get; set; }
        public int? idTipoPerClasifica { get; set; }    
        //cCodCliente              VARCHAR(13),
        //cCodigoSBS               VARCHAR(10),
        //lAccionista              BIT,
        //cIndAtrasoDeudor         CHAR(1),
        //lVigente                 BIT,    
        public bool lIndDatosBasic { get; set; }    
        public string cNumeroTelefono3 { get; set; }
        public int idCodTelFijo { get; set; }    
        public string cCorreoCliAdicional { get; set; }    
        public int idEstadoCli { get; set; }
        public int idActivEcoInterna { get; set; }
        public int? idActivEcoAdicional { get; set; }    
        //idClasifInterna          INT,    
        public int? idEstadoContribuyente { get; set; }
        public int? idCondDomicilio { get; set; }
        public DateTime? dFechaEstadoCont { get; set; }    
        //dFechaHoraReg            DATETIME DEFAULT getdate(),
        public char cDigitoVerificador { get; set; }
        //idCalifRiesgoScoring     INT,
        //nPuntajeEvalScoring      DECIMAL(14, 2),
        //idRegimen                INT,
        public int idTipoCliente { get; set; }
        //idCanalRegistro          INT
    }

    public class clsAWClienteNatural
    {
        //    idCli               INT ,
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cNombre { get; set; }
        public string cApellidoCasada { get; set; }
        public DateTime? dFechaNacimiento { get; set; }    
        public int idUbigeoNacimiento { get; set; }
        public int idSexo { get; set; }    
        public int idEstadoCivil { get; set; }
        public int idProfesion { get; set; }       
        public int idNivelInstruccion { get; set; }
        public int? idOcupacion { get; set; }
        public int? nNumHijos { get; set; }
        public int? nNumPerDepend { get; set; }        
        public int? idEstadoCivilSBS { get; set; }
        public int? idCargo { get; set; }        
        public string cDescCargo { get; set; }
        public string CNombreSeg { get; set; }
        public string cNombreOtros { get; set; }
        public DateTime? dFechaIniActEco { get; set; }
        public string cDescProfesion { get; set; }
        public int? idRolHogar { get; set; }
        public int? idSegmentoSocioEc { get; set; }    
        //dFechaFallecimiento DATETIME,
        //lFacta              BIT,
        //lAceptaResidenciaUS BIT
    }

    public class clsAWDireccion
    {
        public int idDireccion { get; set; }
        public int idCli { get; set; }
        public int idUbigeo { get; set; }        
        public string cDireccion { get; set; }
        //cReferenciaDireccion VARCHAR(50),
        //lVigente             BIT,        
        public int idTipoDireccion { get; set; }
        public int idTipoZona { get; set; }
        public string cDesZona { get; set; }
        public int idTipoVia { get; set; }
        public string cDesVia { get; set; }
        //cDepartamento        VARCHAR(4),
        public string cInterior { get; set; }
        public string cManzana { get; set; }
        public string cLote { get; set; }
        //cKilometro           VARCHAR(4),
        public string cBlock { get; set; }
        public string cEtapa { get; set; }
        public string cNumero { get; set; }

        public int idTipoVivienda { get; set; }
        //cdescOtros           VARCHAR(50),
        //cNombrePropietario   VARCHAR(150),
        public bool lDirPrincipal { get; set; }    
        public int idSector { get; set; }
        //cCodSuministro       VARCHAR(10),    
        public int idTipoConstruccion { get; set; }    
        public int nAñoReside { get; set; }
        //dFecHorReg           DATETIME DEFAULT getdate(),
        //idSuministro         INT,
        //ggPosicion           GEOGRAPHY DEFAULT [GEOGRAPHY] ::Parse('POINT EMPTY') NOT NULL
        public char Estado { get; set; }
    }

    public class clsAWVinculado
    {
    }

    public class clsAWDeposito
    {        
        public int idCuenta { get; set; }
        public int idEstado { get; set; }
        public int idProducto { get; set; }
        public int idTipoCuenta { get; set; }
        public int idTipoTasa { get; set; }
        public int idTasa { get; set; }
        public decimal nMonTasa { get; set; }
        public int idMoneda { get; set; }
        public int idAgencia { get; set; }
        public int idUsuario { get; set; }
        public int idUsuarioqBlo { get; set; }
        public int nPlazoCta { get; set; }
        public decimal nMontoDeposito { get; set; }
        public decimal nInteresGen { get; set; }
        public decimal nInteresPag { get; set; }
        public decimal nMonIntDev { get; set; }
        public decimal nSaldoDis { get; set; }
        public decimal nSaldoCnt { get; set; }
        public decimal nMonIntTot { get; set; }
        public DateTime? dFechaApertura { get; set; }
        public DateTime? dFechaCancelacion { get; set; }
        public int nNumeroFirmas { get; set; }
        public int idCaracteristica { get; set; }
        public int idUsuAsig { get; set; }
        public bool lisBloqCta { get; set; }
        public decimal nMonTotBloq { get; set; }
        public decimal nTasaCancelacion { get; set; }
        public DateTime? dFecUltMov { get; set; }
        public string cRucEmpleador { get; set; }
        public bool lInactiva { get; set; }
        public bool lIsAfectoITF { get; set; }
        public bool lIsCtaOrdPago { get; set; }
        public int idRenovacion { get; set; }
        public int idPagoInt { get; set; }
        public int idTipoPersona { get; set; }
        public DateTime? dFecCapitalizacion { get; set; }
        public string cNroCuenta { get; set; }
        public int idCuentaRel { get; set; }
        public decimal nSaldoMinimo { get; set; }
        public int nNumeCertificado { get; set; }
        public bool lIndGarantia { get; set; }
        public DateTime? dFechaAperturaIni { get; set; }
        public DateTime? dFechaAtencion { get; set; }
        public int idUsuAtiende { get; set; }
        public int nDiaPagoInt { get; set; }
        public string cDescripcionCta { get; set; }
        public int idTipoEnvioEstCta { get; set; }
        public string cDireccionEnvioEstCta { get; set; }
        public int idOrigenFondo { get; set; }
        public int idObjetoAho { get; set; }
        public string cNumeroCCI { get; set; }
        public decimal nMontoApertura { get; set; }
        public int nNroImpresionExtCta { get; set; }
        public decimal nMontoApeIni { get; set; }
        public DateTime? dFechaDevengado { get; set; }
        public decimal nIntDevTmp { get; set; }
        public int idCuentaCreditoApertura { get; set; }
        public int lCuentaDepositoAutomatico { get; set; }
        public int idCanalRegistro { get; set; }

        public clsAWDeposito()
        {            
        }
    }

    public class clsAWInterviniente
    {
        public int idIntervCre { get; set; }
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int codigo { get; set; } //idCli
        public int idTipoInterv { get; set; }
        public DateTime? dFecIniInterv { get; set; }
        public DateTime? dFecFinInterv { get; set; }
        public bool lEstado { get; set; }
        public string cCodUsuReg { get; set; }
        public int cCodUsuMod { get; set; }
        public int idModulo { get; set; }
        public bool lCliAfeITF { get; set; }        
        public int idAgenciaMod { get; set; }
        public DateTime? dFechaMod { get; set; }
        public bool lFirmante { get; set; }
        public bool lParticipa { get; set; }

        public bool lEsAfeItf { get; set; }
        public bool isReqFirma { get; set; }
    }

    public class clsAWParametrosProducto
    {
        public int IdProducto { get; set; }
        public int IdMoneda { get; set; }
        public bool lIsInactiva { get; set; }
        public int nPlaInactiva { get; set; }
        public int nPlaCancInac { get; set; }
        public decimal nMonMinApe { get; set; }
        public decimal nMonMinSalDis { get; set; }
        public decimal nMonMinOpe { get; set; }
        public int nPlaMinProd { get; set; }
        public int nPlaMaxProd { get; set; }
        public bool lIsPlazoProd { get; set; }
        public bool lIsRenovProd { get; set; }
        public bool lIsRequeCert { get; set; }
        public bool lIsAfectoITF { get; set; }
        public bool lIsTrabFinan { get; set; }
        public bool lIsReqPagInt { get; set; }
        public bool lIsDefTipPagInt { get; set; }
        public bool lIsReqEmpleador { get; set; }
        public bool lIsProdTransf { get; set; }
        public bool lIsProdCTS { get; set; }
        public bool lIsDepAhoProg { get; set; }
        public bool lVigente { get; set; }
        public int nTipCalInt { get; set; }
        public int nPeriodoCap { get; set; }
        public bool lIsOpeRetiro { get; set; }
        public bool lIsOpeDeposito { get; set; }
        public bool lIsCtaCteRel { get; set; }
        public int idProdTasCancel { get; set; }
        public bool lIsCtaOrdPago { get; set; }
        public int idClasifProdDep { get; set; }
        public bool lIsDepMenEdad { get; set; }
        public int idTipoCapDep { get; set; }
        public bool lIsGarantia { get; set; }
        public bool lActualizaTasaRen { get; set; }
    }

    public class clsAWTasa
    {
        public int idTasa { get; set; }
    //idPlazo               INT,
    //idProducto            INT,
    //idMonto               INT,
    //idMoneda              INT,
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }            
    //lVigente              BIT,
    //idAgencia             INT,
    //idTipoPersona         INT,
    //nTasaCompensatoriaMax DECIMAL(14, 4),
    //EnUso                 BIT,
    //idTipoTasa            INT,
    //lNegociable           BIT
    }

    public class clsAWDatosTipoPago
    {
        //idkardex          INT NOT NULL,
        public int idTipoValorado { get; set; }
        //idCuenta          INT NOT NULL,
        public string cNroCuentaDoc { get; set; }
        public string cNroDocumento { get; set; }
        public string cSerieDocumento { get; set; }
        public int idEntidad { get; set; }
        public DateTime? dFechaReg { get; set; }
        public int nDiasValoriz { get; set; }
        //nEstadoValoriz    INT NOT NULL,
        //idAgencia         INT,
        //idUsuarioVal      INT,
        //dFechaVal         DATE,
        //cMotivo           VARCHAR(200),
        //lVigente          BIT,
        //idCuentaRel       INT,
        //idMoneda          INT,
        //nMontoDoc         DECIMAL(14, 2),
        public DateTime? dFechaEmiDoc { get; set; }
        public int nNroFolio { get; set; }
        //idEntidadDestino  INT,
        //cNroCtaDestino    VARCHAR(50),
        //lisMismaCta       BIT,
        //dFecHorReg        DATETIME DEFAULT getdate(),
        //idUsuActDatos     INT,
        //dFechaActualiza   DATE,
        //dFecHoraActualiza DATETIME,
        //lIndicaActDatos   BIT      DEFAULT 0,
    }

    public class clsAWEmpleador
    {
    }

    public class clsAWAhorroProgramado
    {
    }

    public class clsAWCuentaCancelada
    {
    }

    public class clsAWClienteReniec
    {
    }    

    public class clsAWBaseNegativa
    {
        public int idBaseNegativaClientes { get; set; }        
        public string cDocumentoID { get; set; }
    }

    public class clsAWPersonaReniec
    {
        public string cErrorF { get; set; }
        public string cDniF { get; set; }
        public string cDigitoVerif { get; set; }
        public string cApellidoPater { get; set; }
        public string cApellidoMater { get; set; }
        public string cApellidoCasada { get; set; }
        public string cNombres { get; set; }
        public string cUbigeoDep { get; set; }
        public string cUbigeoProv { get; set; }
        public string cUbigeoDist { get; set; }
        public string cNomDep { get; set; }
        public string cNomProv { get; set; }
        public string cNomDist { get; set; }
        public string cEstadoCivil { get; set; }
        public string cGradoInstr { get; set; }
        public string cEstatura { get; set; }
        public string cSexo { get; set; }
        public string cDocSustTipo { get; set; }
        public string cDocSustNumero { get; set; }
        public string cUbigeoDepNac { get; set; }
        public string cUbigeoProvNac { get; set; }
        public string cUbigeoDistNac { get; set; }
        public string cNomDepNac { get; set; }
        public string cNomProvNac { get; set; }
        public string cNomDistNac { get; set; }
        public string cFechaNac { get; set; }
        public string cNomPadre { get; set; }
        public string cNomMadre { get; set; }
        public string cFechaInsc { get; set; }
        public string cFechaExpe { get; set; }
        public string cConstanciaVota { get; set; }
        public string cRestrccion { get; set; }
        public string cPrefijoDireccion { get; set; }
        public string cDireccion { get; set; }
        public string cNumDireccion { get; set; }
        public string cBlock { get; set; }
        public string cInterior { get; set; }
        public string cUrbanizacion { get; set; }
        public string cEtapa { get; set; }
        public string cManzana { get; set; }
        public string cLote { get; set; }
        public string cPrefiBlock { get; set; }
        public string cPrefiDep { get; set; }
        public string cPrefiUrba { get; set; }
        public string cReservadoF { get; set; }
        public string cLongFoto { get; set; }
        public string cLongFirma { get; set; }
        public string cReservConCeros { get; set; }
        public string cReservConEspacios { get; set; }
        public string cFotoF { get; set; }
        public string cFirmaF { get; set; }

        public bool lNombrePadre { get; set; }
		public bool lNombreMadre { get; set; }
		public bool lDepartamentoNacimiento { get; set; }
		public bool lProvinciaNacimiento { get; set; }
        public bool lDistritoNacimiento { get; set; }
    }

    public class clsAWLog
    {
        public int? idLogAhorroWeb { get; set; }
        public string cAgenteUsuario { get; set; }
        public string cDireccionIP { get; set; }
        public string cPlataformaSoftware { get; set; }
        public string cPlataformaHardware { get; set; }
        public string cNavegador { get; set; }
        public string cDocumentoID { get; set; }
        public int? idCli { get; set; }
        public int? idTipoCliente { get; set; }
        public int? idCuenta { get; set; }
        public string cNumeroCelular { get; set; }
        public string cOperadorCelular { get; set; }
        public string cEstado { get; set; }
        public string cCodigoValidacion { get; set; }
        public DateTime? dFechaCreacion { get; set; }
        public DateTime? dFechaActualizacion { get; set; }
        public bool? lVigente { get; set; }
    }

    public class clsAWTramite
    {
        public int idTramiteAhorroWeb { get; set; }
        
        public string cDocumentoID { get; set; }
        public char nDigitoVerificador { get; set; }
        public DateTime? dFechaInscripcion { get; set; }
        public DateTime dFechaEmision { get; set; }
        public string cCorreoElectronico1 { get; set; }
        public string cNumeroCelular1 { get; set; }
        public string cOperadorCelular1 { get; set; }        
        public bool? lAutorizaDatos { get; set; }
        
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public string cObjetivoAhorro { get; set; }
        public decimal? nMontoObjetivo { get; set; }
        
        public bool? lDireccionActual { get; set; }

        public int idProfesion { get; set; }
        public int idActivEcoInterna { get; set; }
        public string cLugarTrabajo { get; set; }
        public decimal? nIngresoMensualNeto { get; set; }
        
        public bool? lNacioPeru { get; set; }
        public string cDepNacimiento { get; set; }
        public string cProNacimiento { get; set; }
        public string cDisNacimiento { get; set; }
        public string cNombrePadre { get; set; }
        public string cNombreMadre { get; set; }
        public bool? lOtraNacionalidad { get; set; }
        public bool? lPep { get; set; }
        
        public string cCorreoElectronico2 { get; set; }
        public string cCodigoValidacion { get; set; }
        public string cNumeroCelular2 { get; set; }
        public string cOperadorCelular2 { get; set; }
        public bool? lAceptaTermCond { get; set; }
        public bool? lUsuarioConfirma { get; set; }

        public int? idLogAhorroWeb { get; set; }
        public int idCuenta { get; set; }

        public DateTime? dFechaRegistro { get; set; }
        public bool? lMensajeConfirmacion { get; set; }
        public bool? lCorreoConfirmacion { get; set; }

        public int? idRegionRegulariza { get; set; }
        public int? idAgenciaRegulariza { get; set; }
        public int? idUsuarioRegulariza { get; set; }
        public DateTime? dFechaRegulariza { get; set; }
        public bool? lIdentidadConfirmada { get; set; }
        public bool? lDatosRegularizados { get; set; }
        public bool? lDocumentosRegularizados { get; set; }        

        public bool lVigente { get; set; }        

        /*otras propiedades*/
        public string cCaptcha { get; set; }
        public string cToken { get; set; }
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public int idAgencia { get; set; }
        public DateTime dFechaSistema { get; set; }
        public int idTipoPago { get; set; }
        public int idCanal { get; set; }
        public int idObjetoAho { get; set; }

        public clsAWTramite()
        {            
        }
    }

    public class clsAWProducto
    {
        public int IdProducto { get; set; }
        public string cProducto { get; set; }
    }

    public class clsAWMoneda
    {
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
    }

    public class clsAWProfesion
    {
        public int idProfesion { get; set; }
        public string cProfesion { get; set; }
    }

    public class clsAWActividadInterna
    {
        public int idActividadInterna { get; set; }
        public string cActividadInterna{ get; set; }
    }

    public class clsAWRespuesta
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }
        public string cCodigo { get; set; }
        public string idCodigo { get; set; }
        public dynamic datos { get; set; }

        public clsAWRespuesta()
        {
            this.idRespuesta = 1;
            this.cRespuesta = "success";
        }

        public void respuestaFallida(string cCodigo)
        {            
            this.idRespuesta = 0;
            this.cRespuesta = "failed";
            this.cCodigo = cCodigo;
        }
    }

    public class clsAWPersonaPEP
    {
    }

    public class clsAWCuenta
    {
    }

    public class clsAWRegistrarCliente
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }

        public int idCli { get; set; }
        public int idTipoCliente { get; set; }
        public string cCodCliente { get; set; }
        public string cPrimerNombre { get; set; }
        public string cNombre { get; set; }

        public clsAWRegistrarCliente()
        {
            this.idRespuesta = 1;
            this.cRespuesta = "success";
        }
    }

    public class clsAWRegistrarSolicitud
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }

        public int idRpta { get; set; }
        public string idNroCta { get; set; }
        public string cMensage { get; set; }
        public int idCuentaAho { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }

        public clsAWRegistrarSolicitud()
        {
            this.idRespuesta = 1;
            this.cRespuesta = "success";
        }
    }

    public class clsAWRegistrarApertura
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }

        public clsAWRegistrarApertura()
        {
            this.idRespuesta = 1;
            this.cRespuesta = "success";
        }
    }

    public class clsAWObtenerCuenta
    {
        public int nIntPagAde { get; set; }
        public int idProducto { get; set; }
        public int idTipoPersona { get; set; }
        public int idMoneda { get; set; }
        public int idAgencia { get; set; }
    }

    //public class clsAWObtenerInterviniente
    //{
    //    public bool isReqFirma { get; set; }
    //    public int idCli { get; set; }
    //    public int idTipoInterv { get; set; }        
    //}

    public class clsAWComision
    {

    }

    public class clsAWConsultaReniec: clsAWRespuesta
    {
        public clsAWPersonaReniec objAWPersonaReniec { get; set; }
    }

    public class clsAWEnvioSMS
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }

        public clsAWEnvioSMS()
        {
            this.idRespuesta = 1;
            this.cRespuesta = "success";
        }
    }

    public class clsAWDatosCorreo
    {
        public string cCorreoDestino { get; set; }
        public string cPrimerNombre { get; set; }
        public string cNombreCompleto { get; set; }
        public string cCuenta { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public string cArchivoTermCond { get; set; }
        public int nVigenciaCuenta { get; set; }
    }

    public class clsAWRegistroLog
    {
        public int idRespuesta { get; set; }
        public string cRespuesta { get; set; }
    }

    public class clsAWVariable
    {
        public string cValVar { get; set; }
    }

    public class clsAWUsuario
    {
        public string cWinUser { get; set; }
        public string cPassword { get; set; }
        public string cImei { get; set; }
        public string cNombreEquipo { get; set; }
        public string cCaracteristicas { get; set; }
        public int idPerfil { get; set; }
        public int idAgencia { get; set; }

        //---------------------------------------------

        public string cNombre { get; set; }
        public string cPerfil { get; set; }
        public string cToken { get; set; }

        //---------------------------------------------

        public bool lIdentificado { get; set; }
        public string cMensaje { get; set; }
        public string dFechaSistema { get; set; }
        public string cVersion { get; set; }

        public bool lPerfilValido { get; set; }
        //---------------------------------------------

        public IList<clsAWAgencia> lstAgencias { get; set; }
        public IList<clsAWPerfil> lstPerfiles { get; set; }
    }

    public class clsAWRespuestaLogin
    {
        public bool lIdentificado { get; set; }
        public bool lPerfilValido { get; set; }
        public string cMensaje { get; set; }
        public string cNombre { get; set; }        
        public string cToken { get; set; }
        public IList<clsAWAgencia> lstAgencias { get; set; }
        public IList<clsAWPerfil> lstPerfiles { get; set; }
    }

    public class clsAWAgencia
    {
        public int idAgencia { get; set; }
        public string cNombreAge { get; set; }
    }

    public class clsAWPerfil
    {
        public int idPerfil { get; set; }
        public string cPerfil { get; set; }
    }

    public class clsAWToken
    {
        public string cEstado { get; set; }
        public string cMensaje { get; set; }
        public string cNivel { get; set; }
    }

    public class clsAWRegistrarOperacion: clsAWRespuesta
    {
        public string cCuenta { get; set; }
        public string cProducto { get; set; }
        public string cPrimerNombre { get; set; }
        public string cFechaHora { get; set; }
    }

    public class clsAWRestriccionPersona
    {
        public string idCodigo { get; set; }
        public bool lRestringido { get; set; }
    }

    public class clsAWParametrosTramite
    {
        public int idCanal { get; set; }
        public int idTipoPago { get; set; }
    }

    public class clsAWObjetivoAhorro
    {
        public int idObjetoAho { get; set; }
        public string cDescripcion{ get; set; }
    }
}
