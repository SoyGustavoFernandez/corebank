using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    #region Evaluación WEB / 
    public class clsWCFEvaluacionWeb
    {
        public int idSolicitud { get; set; }
        public string cEstado { get; set; }
        public string cNombre { get; set; }
        public int idCli { get; set; }
        public string cProducto { get; set; }
        public string dFechaRegistro { get; set; }
        public string nCapitalSolicitado { get; set; }
    }
    public class clsClienteDatos
    {
        public string cDocumentoID { get; set; }
        public string cNomCli { get; set; }
        public DateTime dFechaNacimiento { get; set; }
        public int idSexo { get; set; }
        public string cCodigoSBS { get; set; }
    }

    public class clsDetallesCliente
    {
        public IList<clsWCFEvaluacionWeb> solicitudes { get; set; }
        public IList<clsClienteDatos> cliente { get; set; }
    }

    public class clsSolicitudBasica
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombre { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public string nCapitalSolicitado { get; set; }
        public string cEstado { get; set; }
        public string dFechaRegistro { get; set; }
    }

    /**/
    public class clsProductoCredito
    {
        public int IdProducto { get; set; }
        public string cProducto { get; set; }
        public string cTipoProducto { get; set; }
    }

    public class clsOperacion
    {
        public int idOperacion { get; set; }
        public string cOperacion { get; set; }
    }

    public class clsMoneda
    {
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public string cSimbolo { get; set; }
    }

    public class clsDestinoCredito
    {
        public int idDestino { get; set; }
        public string cDestino { get; set; }
    }

    public class clsModalidadDesembolso
    {
        public int idModalidadDes { get; set; }
        public string cModalidadDes { get; set; }
    }

    public class clsActividad
    {
        public int idActividadInterna { get; set; }
        public string cActividadInterna { get; set; }
        public int idActividad { get; set; }
        public string cActividad { get; set; }
    }

    public class clsTipoPeriodo 
    {
        public int idTipoPeriodo { get; set; }
        public string cDescripTipoPeriodo { get; set; }
    }

    public class clsModalidadCredito
    {
        public int idModalidadCredito { get; set; }
        public string cModalidadCredito { get; set; }
    }

    public class clsAsesorPromotor
    {
        public int idUsuVin { get; set; }
        public int idAsesor { get; set; }
        public int idPromotor { get; set; }
    }

    public class clsTipoCuotaGracia
    {
        public int idTipoCuotaGracia { get; set; }
        public string cTipoCuotaGracia { get; set; }
    }

    public class clsPeriodoCredito
    {
        public int idPeriodoCred { get; set; }
        public string cPeriodoCred { get; set; }
        public int nMeses { get; set; }
    }

    public class clsTipoTasaCredito
    {
        public int idTasa { get; set; }
        public int idPlazo { get; set; }
        public string cPlazo { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public int idMonto { get; set; }
        public string cMonto { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public int idAgencia { get; set; }
        public int idTipoPersona { get; set; }
        public string cTipoPersona { get; set; }
        public int idTipoTasa { get; set; }
        public string cTipoTasa { get; set; }
        public decimal min { get; set; }
        public decimal max { get; set; }
        public decimal mora { get; set; }
    }
    /**/

    /**/
    public class clsSolicitudOtorgamiento
    {
        public int idSolicitud { get; set; }
        public int idProducto { get; set; }
        public int idOperacion { get; set; }
        public int idMoneda { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public DateTime dFechaDesembolsoSugerido { get; set; }
        public int idDestino { get; set; }
        public int idModalidadDes { get; set; }
        public int nDiasGracia { get; set; }
        public int idActividad { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idModalidadCredito { get; set; }
        public int idPromotor { get; set; }
        public int idActividadInterna { get; set; }
        public int nCuotasGracia { get; set; }
        public DateTime dFechaPrimeraCuota { get; set; }
        public int idTipoCuotaGracia { get; set; }
        public int idTipoTasa { get; set; } 
    }

    public class clsSolicitudCreditoGeneral
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int idEstado { get; set; }
        public int idOperacion { get; set; }
        public int idMoneda { get; set; }
        public int idUsuario { get; set; }
        public int nCuotas { get; set; }
        public int nPlazoCuota { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public string cNombre { get; set; }
        public int idTipoPeriodo { get; set; }
        public int idAgencia { get; set; }
        public int idTasa { get; set; }
        public int ndiasgracia { get; set; }
        public DateTime dFechaDesembolsoSugerido { get; set; }
    }

    public class clsTasaGeneral
    {
        public int idTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
        public decimal nTasaCompensatoriaMax { get; set; }
        public int idTipoTasaCredito { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsExcepcionNoContemplada {
        public int idExcepGen { get; set; }
        public int idSolicitud { get; set; }
        public int nIdRegla { get; set; }
        public string cMensajeError { get; set; }
        public string cSustento { get; set; }
        public int idEstadoExcepcion { get; set; }
        public int idReglaNoContemplada { get; set; }

        public string cActividadPrin { get; set; }
        public string cActividadSec { get; set; }
        public string cDatosAval { get; set; }
        public string cDestino { get; set; }
        public string cInicial { get; set; }
        public string cUtilidad { get; set; }
        public string cCuotaNuevoCred { get; set; }
    }

    public class clsDatosReporteRNC {
        public int idDatosReporteRNC { get; set; }
        public int idSolicitud { get; set; }
        public string cActividadPrin { get; set; }
        public string cActividadSec { get; set; }
        public string cInicial { get; set; }
        public string cDatosAval { get; set; }
        public string cCuotaNuevoCred { get; set; }
        public string cUtilidad { get; set; }
        public string cSustento { get; set; }
        public string cDestino { get; set; }
    }

    public class clsSolicitudCredito
    {
        public int idSolicitud {get; set;}
        public int idProducto {get; set;}
        public string cProducto {get; set;}
        public string cProductoPadre {get; set;}
        public string cSubTipoProducto {get; set;}
        public string cTipoProducto {get; set;}
        public int idOperacion {get; set;}
        public string cOperacion {get; set;}
        public int idModalidadCredito {get; set;}
        public string cModalidadCredito {get; set;}
        public int idDestino {get; set;}
        public string cDestino {get; set;}
        public int idModalidadDes {get; set;}
        public string cModalidadDes {get; set;}
        public int IdMoneda {get; set;}
        public string cMoneda {get; set;}
        public decimal nCapitalSolicitado {get; set;}
        public int idTipoPeriodo {get; set;}
        public string cTipoPeriodo {get; set;}
        public int idPeriodoCred {get; set;}
        public string cPeriodoCred {get; set;}
        public int nPlazo {get; set;}
        public int nCuotas {get; set;}
        public int idTipoCuotaGracia {get; set;}
        public string cTipoCuotaGracia {get; set;}
        public int nCuotasGracia {get; set;}
        public string cFechaDesembolsoSugerido {get; set;}
        public string cFechaPrimeraCuota {get; set;}
        public int ndiasgracia {get; set;}
        public int nPlazoCuota {get; set;}
        public int idTasa {get; set;}
        public string cTasa {get; set;}
        public decimal nTasaCompensatoria {get; set;}
        public decimal nTasaMoratoria {get; set;}
        public string tObservacion {get; set;}

        public int idEstado {get; set;}
        public string cEstado {get; set;}
        public int idCli {get; set;}
        public string cCliente {get; set;}
        public int idUsuario {get; set;}
        public string cUsuario {get; set;}
        public int idAgencia {get; set;}
        public string cAgencia {get; set;}
        public string cFechaRegistro {get; set;}
    }

    public class clsHistorialTasas
    {
        public int idTasaNegociada { get; set; }
        public int idTasa { get; set; }
        public int nSolicitud { get; set; }
        public string cFechaReg { get; set; }
        public int idCli { get; set; }
        public string cNombreCliente { get; set; }
        public string nTasaPreAprobada { get; set; }
        public string nTasaAprobada { get; set; }
        public string nTasaMoratoriaSol { get; set; }
        public int idEstado { get; set; }
        public string cDescEstado { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public decimal nCapitalSolicitado { get; set; }
        public int nCuotas { get; set; }
        public string cDescripTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        
        public string dFechaReg { get; set; }
        public string nTasaSolicitada { get; set; }
        public string cComentarioReg { get; set; }
        public string cUsuReg { get; set; }

        public string cFechaPre { get; set; }
        public string nTasaPre { get; set; }
        public string cComentarioPre { get; set; }
        public string cUsuPre { get; set; }
        public int idEstadoPre { get; set; }

        public string cFechaAprob { get; set; }
        public string nTasaAprob { get; set; }
        public string cComentarioAprob { get; set; }
        public string cUsuAprob { get; set; }
        public int idSolAproba { get; set; }
    }

    public class clsCreditosVigentesCliente
    {
        public int IdNum { get; set; }
        public int idCuenta { get; set; }
        public string cEstado { get; set; }
        public string cNombre { get; set; }
        public int idCli { get; set; }
        //public int Fecha_Desembolso { get; set; }
        public int Frecuencia { get; set; }
        public decimal nMonto { get; set; }
        public int nCuotas { get; set; }
        public int IdMoneda { get; set; }
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public decimal Monto_Cuota { get; set; }
        public int nAtraso { get; set; }
        public string cDocumentoID { get; set; }
        public string cDireccion { get; set; }
        public string cCodCliente { get; set; }
        public string cMoneda { get; set; }
        public int idTipoDocumento { get; set; }
        public bool lGarantia { get; set; }
        public bool lCoberSegDesg { get; set; }
    }

    public class clsValidarClienteId
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int IdTipoPersona { get; set; }
        public IList<clsCreditosVigentesCliente> creditosVigentes { get; set; }
    }
    #endregion

    #region Evaluación WEB / General

    public class clsEWMoneda
    {
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public string codigoISO { get; set; }
        public string cCodSBS { get; set; }
        public string cSimbolo { get; set; }
        public string cContable { get; set; }
    }

    public class clsEWActividadInterna
    {
        public int idActividadInterna { get; set; }
        public string cActividadInterna { get; set; }
        public int idActividad { get; set; }
        public bool lVigente { get; set; }
        public int idCategoria { get; set; }
    }

    #endregion


    #region Evaluación WEB / Créditos

    public class clsEWCreTipoPeriodo
    {
        public int idTipoPeriodo { get; set; }
        public string cDescripTipoPeriodo { get; set; }
    }

    #endregion


    #region Evaluación WEB / Créditos / Solicitud



    #endregion

    #region Evaluacion WEB / Excepciones Contempladas

    public class clsExcepcionContemplada
    {
        public int idExcepGen { get; set; }
        public int nIdRegla { get; set; }
        public int idSolicitud { get; set; }
        public string cProducto { get; set; }
        public string cMensajeError { get; set; }
        public string cSustento { get; set; }
        public string cAutomatico { get; set; }
        public int nIdOpcion { get; set; }
        public int idTipoOperacion { get; set; }
    }

    public class clsExcepcionContempladaManual
    {
        public int nIdRegla { get; set; }
        public string cMensajeError { get; set; }
        public int idTipoOperacion { get; set; }
    }

    #endregion

    #region Evaluacion WEB / Excepciones No contempladas

    public class clsSustentoRNC
    {
        public int idSustentoReglaNoCont { get; set; }
        public int idReglaNoContemplada { get; set; }
        public string cSustento { get; set; }
        public int idNivelAprobDesaprob { get; set; }
        public int lAprobDesaprob { get; set; }
        public string cFecha { get; set; }
    }

    #endregion

    #region Evaluación WEB - Creditos / Solicitud / Registro de Intervinientes

    public class clsEWCreTipoInterviniente
    {
        public int idTipoInterv { get; set; }
        public string cTipoIntervencion { get; set; }
        public bool lEstado { get; set; }
        public int idModulo { get; set; }
    }    

    public class clsEWCreInterviniente
    {
        public int idIntervCre { get; set; }
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idTipoInterv { get; set; }
        public string cTipoModif { get; set; }
        public string cNombre { get; set; }
        public string cTipoIntervencion { get; set; }
        public string cDocumentoID { get; set; }
        public int idTipoDocumento { get; set; }
        public int? idSexo { get; set; }
        public int? nEdad { get; set; }
    }

    #endregion


    #region Evaluación WEB - Creditos / Solicitud / Evaluación

    public class clsEWCreEvaluacion : clsEvalCred
    {
    }

    public class clsEWCreEvalSectorEconomico
    {
        public int idSectorEcon { get; set; }
        public string cDescripcion { get; set; }
        public int nCodigo { get; set; }
    }

    public class clsEWCreEvalTipoReferencia
    {
        public int idTipReferEval { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsEWCreEvalTipoVinculo
    {
        public int idTipVinculoEval { get; set; }
        public int idTipReferEval { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsEWCreEvalDatosInicio
    {
        public IList<clsEWMoneda> lstMonedas;
        public IList<clsEWCreTipoPeriodo> lstTiposPeriodo;
        public IList<clsEWCreEvalSectorEconomico> lstSectoresEconomicos;
        public IList<clsEWCreEvalTipoReferencia> lstTiposReferencia;
        public IList<clsEWCreEvalTipoVinculo> lstTiposVinculo;
    }
    
    public class clsEWCreEvalCualitativa : clsEvalCualitativa
    {
    }

    public class clsEWCreEvalReferencia : clsReferenciaEval
    {
    }

    public class clsEWCreEvalItemBalanceGeneral : clsBalGenEval
    {
        public int nNivel { get; set; }
    }

    public class clsEWCreEvalEstadoResultado : clsEstResEval
    {
    }

    public class clsEWCreEvalIndicadorFinanciero : clsIndicadorEval
    {
    }

    public class clsEWCreEvalTipoDestino
    {
        public int idTipDestCred { get; set; }
        public int nNivel { get; set; }
        public string cDestino { get; set; }
        public int idPadre { get; set; }
        public int nCodigo { get; set; }
    }

    public class clsEWCreEvalDetalleDestino
    {
        public int idTipDestCred { get; set; }
        public int nNivel { get; set; }
        public string cDestino { get; set; }
        public int idPadre { get; set; }
    }

    public class clsEWCreEvalDestinoPropuesto : clsDestCredProp
    {
    }

    public class clsEWCreEvalElementoDeshabilitado : clsElemEvalCred
    {
    }

    public class clsEWCreEvalDescripcion : clsDescripcionEval
    {
    }

    public class clsEWCreEvalDetalleBalanceGeneral : clsDetBalGenEval
    {
    }

    public class clsEWCreEvalDatos
    {
        public clsEWCreEvaluacion objEvaluacion;
        public clsSolicitudCredito objSolicitud;
        public IList<clsEWCreEvalCualitativa> lstEvaluacionesCualitativas;
        public IList<clsEWCreEvalReferencia> lstReferencias;
        public IList<clsEWCreEvalItemBalanceGeneral> lstBalanceGeneral;
        public IList<clsEWCreEvalEstadoResultado> lstEstadoResultados;
        public IList<clsEWCreEvalIndicadorFinanciero> lstIndicadoresFinancieros;

        public IList<clsEWCreEvalTipoDestino> lstTiposDestino;
        public IList<clsEWCreEvalDetalleDestino> lstDetallesDestino;
        public IList<clsEWCreEvalDestinoPropuesto> lstDestinosPropuestos;

        public IList<clsEWCreEvalElementoDeshabilitado> lstElementosDeshabilitados;
        public IList<clsEWCreEvalDescripcion> lstDescripciones;
        public IList<clsEWCreEvalDetalleBalanceGeneral> lstDetallesBalanceGeneral;
    }

    #endregion

    #region Evaluacion WEB - Creditos / Solicitud / Evaluacion / Evaluacion Convenio

    public class clsEvaluacionConvenio
    {
        public int idEvalCred { get; set; }
        public int idTipEvalCred { get; set; }
        public int idCli { get; set; }
        public int idSolicitud { get; set; }
        public int idUsuReg { get; set; }
        public int idUsuMod { get; set; }
        public int idAgencia { get; set; }
        public int idProducto { get; set; }
        public decimal nTipoCambio { get; set; }
        public decimal nMonPropuesto { get; set; }
        public decimal nCapitalPropuesto { get; set; }
        public int idMoneda { get; set; }
        public int nCuotas { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }
        public string cFechaDesembolso { get; set; }
        public int idTasa { get; set; }
        public decimal nTEA { get; set; }
        public decimal nTEM { get; set; }
        public int nCuotaAprox { get; set; }
        public int nActPriAnios { get; set; }
        public string cComEntFamiliar { get; set; }
        public string cComDestCreditos { get; set; }
        public string cComGarantias { get; set; }
        public string cComAnalisisFinan { get; set; }
        public int idCatLab { get; set; }
        public int nTipIngreso { get; set; }
        public bool lCargoRcc { get; set; }
        public bool lExpuestoRCC { get; set; }
        public decimal nTotalDeudas { get; set; }
        public decimal nRCCPc1 { get; set; }
        public decimal nRCCPc2 { get; set; }
        public decimal nRCCPc3 { get; set; }
        public int idTipoPersona { get; set; }
        public bool lEstado { get; set; }
        public bool lEditar { get; set; }
        public decimal nRatCapacPago { get; set; }
        public int idMonedaRemBruta { get; set; }
        public decimal nRemBruta { get; set; }
        public int idEmpresaConvenio { get; set; }
        public int idCanalAprobCred { get; set; }
        public int idEstablecimiento { get; set; }
        public int idTipoEstablecimiento { get; set; }
    }

    public class clsDeudaEval
    {
        public int idDeudasEval { get; set; }
        public int idTipoDeuda { get; set; }
        public int idDeudaCA { get; set; }
        public int idTipoCredito { get; set; }
        public string cCodigoEmpresa { get; set; }
        public string cNombreEmpresa { get; set; }
        public int idCuenta { get; set; }
        public int idProducto { get; set; }
        public int idMoneda { get; set; }
        public decimal nMontoAprobado { get; set; }
        public int nCuotasPag { get; set; }
        public int nCuotasPen { get; set; }
        public int nCuotasTot { get; set; }
        public decimal nSCapTotalSis { get; set; }
        public decimal nSCapCortoPlz { get; set; }
        public decimal nSCapLargoPlz { get; set; }
        public decimal nMontoCuota { get; set; }
        public string cCronograma { get; set; }
        public DateTime dFechaConsulta { get; set; }
        public int idMonedaMA { get; set; }
        public bool lAutomatico { get; set; }
        public decimal nTipoCambio { get; set; }
    }

    public class clsEstadoResultadosConvenio
    {
        public int idEstResEval { get; set; }
        public int idItemEstRes { get; set; }
        public string cDescripcion { get; set; }
        public int idMonedaMA { get; set; }
        public decimal nTotalMA { get; set; }
        public int nOrden { get; set; }
        public int nTipoTrans { get; set; }
        public int idEEFF { get; set; }
    }

    public class clsCreditoSolicitado
    {
        public int idSolicitud { get; set; }
        public int idCli { get; set; }
        public int idProducto { get; set; }
        public int IdMoneda { get; set; }
        public int nCuotas { get; set; }
        public int idTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int nDiasGracia { get; set; }
        public DateTime dFechaDesembolsoSugerido { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public string cOperacion { get; set; }
        public string cModalidadCredito { get; set; }
        public decimal nMonto { get; set; }
        public int idOperacion { get; set; }
    }

    public class clsIngresoEgresoConvenio
    {
        public int IdDetalleEvalCon { get; set; }
        public int idEvalCre { get; set; }
        public int IdTipIngEgr { get; set; }
        public int IdMoneda { get; set; }
        public decimal nMontoFlujo { get; set; }
        public decimal nPorcPartFlujo { get; set; }
        public int idDetalle { get; set; }
    }

    public class clsTipIngEgrEval
    {
        public int idDetalle { get; set; }
        public string cDetalle { get; set; }
        public int idTipIngEgre { get; set; }
    }

    public class clsDestinoCreditoConvenio
    {
        public int idTipDestCred { get; set; }
        public int nNivel { get; set; }
        public string cDestino { get; set; }
        public int idPadre { get; set; }
    }

    public class clsDetalleDestinoCreditoConvenio
    {
        public int idTipDestCred { get; set; }
        public int nNivel { get; set; }
        public string cDestino { get; set; }
        public int idPadre { get; set; }
    }

    public class clsDetalleDestinoCreditoPropuestoConvenio
    {
        public int idDestCredProp { get; set; }
        public int idTipDestCred { get; set; }
        public int idDetalle { get; set; }
        public decimal nPorcentaje { get; set; }
        public decimal nMontoProp { get; set; }
        public string cDestinoCredito { get; set; }
        public string cDetalle { get; set; }
        public int idEvalCred { get; set; }
    }

    public class clsTipoReferenciaConvenio
    {
        public int idTipReferEval { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsTipoVinculoConvenio
    {
        public int idTipVinculoEval { get; set; }
        public int idTipReferEval { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsEvaluacionConvenioRespuesta
    {
        public clsEvaluacionConvenio evaluacion { get; set; }
        public IList<clsEstadoResultadosConvenio> estadoResultados { get; set; }
        public clsCreditoSolicitado creditoSolicitado { get; set; }
        public IList<clsIngresoEgresoConvenio> ingresos { get; set; }
        public IList<clsIngresoEgresoConvenio> egresos { get; set; }
        public IList<clsDestinoCreditoConvenio> destinos { get; set; }
        public IList<clsDetalleDestinoCreditoConvenio> detalleDestinos { get; set; }
        public IList<clsDetalleDestinoCreditoPropuestoConvenio> detalleDestinosPropuesto { get; set; }
        public IList<clsTipoReferenciaConvenio> tiposReferencia { get; set; }
        public IList<clsTipoVinculoConvenio> tiposVinculo { get; set; }
    }

    public class clsTipoCredito
    {
        public int idTipoCredito { get; set; }
        public string cDescripcion { get; set; }
    }

    public class clsDeudaCuotaPago
    {
        public int idDeudasEval { get; set; }
        public int idEvalCred { get; set; }
        public int nContador { get; set; }
        public int nMes { get; set; }
        public decimal nMonto { get; set; }
        public int nFrecuencia { get; set; }
        public DateTime dFechaInicio { get; set; }
    }

    public class clsDeudasRespuesta
    {
        public IList<clsTipoCredito> tiposCredito { get; set; }
        public IList<clsDeudaEval> deudasDirectas { get; set; }
        public IList<clsDeudaEval> deudasIndirectas { get; set; }
        public IList<clsDeudaCuotaPago> deudasCuotaPago { get; set; }
    }

    public class clsEmpresaConvenio
    {
        public int idEmpresaConv { get; set; }
        public string cRazSocCorto { get; set; }
        public string cRazonSocial { get; set; }
        public string cNroDocumento { get; set; }
        public string cDireccion { get; set; }
        public int idCli { get; set; }
        public int idSectorEmp { get; set; }
        public string cSectorEmp { get; set; }
        public int idCatLab { get; set; }
        public string cCatLab { get; set; }
        public int nTipIngreso { get; set; }
        public string cTipIngreso { get; set; }
        public int idTipoContrato { get; set; }
        public string cTipoContrato { get; set; }
    }

    public class clsCreditoPropuesto
    {
        public int idEvalCred { get; set; }
        public int idProducto { get; set; }
        public int idMoneda { get; set; }
        public string cMoneda { get; set; }
        public decimal nCapitalPropuesto { get; set; }
        public int idTipoPeriodo { get; set; }
        public string cTipoPeriodo { get; set; }
        public int nPlazoCuota { get; set; }
        public int idPeriodoCred { get; set; }
        public string cPeriodoCred { get; set; }
        public int nCuotas { get; set; }
        public int nTotalDiasCredito { get; set; }
        public int idTipoCuotaGracia { get; set; }
        public string cTipoCuotaGracia { get; set; }
        public int nCuotasGracia { get; set; }
        public string cFechaDesembolso { get; set; }
        public string cFechaPrimeraCuota { get; set; }
        public int nDiasGracia { get; set; }
        public int idTasa { get; set; }
        public string cTasa { get; set; }
        public decimal nTasaCompensatoria { get; set; }
        public decimal nTasaMoratoria { get; set; }
    }

    public class clsTipoContrato
    {
        public int idTipoContrato { get; set; }
        public string cTipoContrato { get; set; }
    }

    #endregion

    #region Evaluacion WEB - Creditos / Generar Evaluacion

    public class clsEWNuevaEvaluacion
    {
        public int idEvalCred { get; set; }
        public string cMensaje { get; set; }
    }

    #endregion

    public class clsActividadCliente
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public int idActividadInterna { get; set; }
        public string cActividadInterna { get; set; }
        public int idActividad { get; set; }
        public string cActividad { get; set; }
        public int idActividadInternaConyuge { get; set; }
        public string cActividadInternaConyuge { get; set; }
        public int idActividadConyuge { get; set; }
        public string cActividadConyuge { get; set; }
    }

    public class clsClienteCredito
    {
        public int idCli { get; set; }
        public string cNombre { get; set; }
        public string cDocumentoID { get; set; }
        public string cCodCliente { get; set; }
        public int IdTipoPersona { get; set; }
        public string cDireccion { get; set; }
        public bool lDirPrincipal { get; set; }
        public int idClasifInterna { get; set; }
        public string cClasifInterna { get; set; }
        public int idTipoCliente { get; set; }
        public string cTipoCliente { get; set; }
        public string cEstadoCivil { get; set; }
        public string cTipoDocumento { get; set; }
    }

    public class clsSYRespuesta
    {
        public int idRespuesta { get; set; }
        public string cMensaje { get; set; }
        public clsWCFConsultaAdmisionInterna objDatosCliente { get; set; }
    }

}
