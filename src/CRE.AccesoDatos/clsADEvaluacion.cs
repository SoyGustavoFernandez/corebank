using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;

namespace CRE.AccesoDatos
{
    public class clsADEvaluacion
    {
        //public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        IntConexion objEjeSp;

        public clsADEvaluacion()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADEvaluacion(bool lWebService)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        #region Métodos Anteriores
        //Propuesta Crédito Empresarial
        public DataTable ADConsPropuestaCre(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_PropuestaCredito_sp", idSolicitud);
        }
        public DataTable ADInsUpdPropuesta(int idSolicitud, decimal nGarantia, string cNegocio, string cExpCrediticia,
	                                        string cDestinoCredito, string cEntornoFamiliar, string cEvaluacion, string cGarantia,
	                                        string cConclusiones)
        {
            return objEjeSp.EjecSP("CRE_InsUpdPropuesta_sp", idSolicitud, nGarantia, cNegocio, cExpCrediticia,
                                                            cDestinoCredito, cEntornoFamiliar, cEvaluacion, cGarantia,
                                                            cConclusiones);
        }
        public DataTable ADConsPropuesta(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaPropuestaCred_sp", idSolicitud);
        }

        //Propuesta Crédito Consumo
        public DataTable ADConsPropuestaCreConsumo(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_PropuestaCreditoConsumo_sp", idSolicitud);
        }
        public DataTable ADInsUpdPropuestaCreConsumo(int idSolicitud, decimal nGarantia,
                            string cEntornoFamDomicil   , string cVerificLaboral    , string cOtrosIngrAcred,
                            string cAvalGarante         , string cDescrPatrim       , string cDestinoCre    )
        {
            return objEjeSp.EjecSP("CRE_InsUpdPropuestaCreConsumo_sp", idSolicitud, nGarantia,
                                cEntornoFamDomicil  , cVerificLaboral   , cOtrosIngrAcred   ,
                                cAvalGarante        , cDescrPatrim      , cDestinoCre       );
        }
        public DataTable ADConsPropuestaConsumo(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaPropuestaCredConsumo_sp", idSolicitud);
        }

        
        public DataTable ADConsExcepciones(int idsolici)
        {
            return objEjeSp.EjecSP("CRE_ExcepcionesPropuestaCredito_sp", idsolici);
        }

        public DataTable CNValidarRangoRatios(string xmlRatios)
        {
            return objEjeSp.EjecSP("CRE_ValidarRangoRatios_sp", xmlRatios);
        }
        #endregion

        #region Métodos Compartidos de todas las evaluaciones

        public DataTable ListarEvaluacionPorCliente(int idCli, int idUsuario, string cTipEvalCre)
        {
            return objEjeSp.EjecSP("CRE_ListEvalPorCli_Sp", idCli, idUsuario, cTipEvalCre);
        }

        public DataTable ADEnviarAComite(int idEvalCre, int idUsuario, DateTime dFechaSis, string xmlPropuesta, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCre, idUsuario, dFechaSis, xmlPropuesta, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataTable ActualizarDeudasFinancieras(int idEvalCred, decimal nTotalDeudas, string xmlDeudasEval, string xmlDeudasCuotaPago)
        {
            return objEjeSp.EjecSP("CRE_ActualizarDeudasFinan_Sp", idEvalCred, nTotalDeudas, xmlDeudasEval, xmlDeudasCuotaPago);
        }
        public DataSet ADEvalCualitativa(int idEvalCre)
        {
            return this.objEjeSp.DSEjecSP("CRE_EvaluacionCualitativa_SP", idEvalCre);
        }

        public DataTable ADCambiaLVigenteEval(int idEvalCre, Boolean lVigente)
        {
            return objEjeSp.EjecSP("CRE_CambiaLVigenteEval_SP", idEvalCre, lVigente);
        }

        public DataSet ADPropuestaImpEval(int idSolicitud, int idEvalCre)
        {
            return objEjeSp.DSEjecSP("CRE_PropuestaImpEval_SP", idSolicitud, idEvalCre);
        }

        public DataSet ADEstadosFinanEval(int idSolicitud, int idEvalCre)
        {
            return objEjeSp.DSEjecSP("CRE_EstadosFinanEval_SP", idSolicitud, idEvalCre);
        }

        public DataSet ADEstadosFinanEvalAgrico(int idSolicitud, int idEvalCre)
        {
            return objEjeSp.DSEjecSP("CRE_EstadosFinanEvalAgrico_SP", idSolicitud, idEvalCre);
        }

        public DataSet ADEstadosFinanEvalH2000(int idSolicitud, int idEvalCre)
        {
            return objEjeSp.DSEjecSP("CRE_EstadosFinanEvalH2000_SP", idEvalCre);
        }

        public DataSet CNHojaTrabajoEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_HojaTrabajoEval_Sp", idEvalCred);
        }

        public DataSet FlujoCajaEvalPyme(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_FlujoCajaEval_Sp", idEvalCred);
        }

        public DataSet FlujoCajaEvalAgro(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_FlujoCajaEvalAgro_Sp", idEvalCred);
        }

        public DataSet BuscarSolicitudesPorCliente(int idCli, int idUsuario, string cTipoEval, string cSectorEcon, int idPerfil)
        {
            return objEjeSp.DSEjecSP("CRE_BusSolPorCliPyme_Sp", idCli, idUsuario, cTipoEval, cSectorEcon, idPerfil);
        }

        public DataTable GrabarNuevaEvalCred(string xmlEvalCred, string xmlSaldosDeudas, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_NuevaEvalPyme_Sp", xmlEvalCred, xmlSaldosDeudas, idEstablecimiento);
        }

        public DataTable VincularEvalCred(int idEvalCred, string xmlEvalCred, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_VincularEval_Sp", idEvalCred, xmlEvalCred, idEstablecimiento);
        }

        public DataTable ADActualizarSolicitudAEval(int idEvalCre, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ActSolicitudEvaluacion_SP", idEvalCre, idSolicitud);
        }
    
        public DataSet ADPropuestaEvalConvenio(int idEvalCre, int idSolicitud, int nFuente)
        {
            return objEjeSp.DSEjecSP("CRE_PropuestaEvalConvenio_SP", idEvalCre, idSolicitud, nFuente);
        }

        public DataSet ADObtenerEvalAlterna(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ObtenerEvalAlterna_SP", idEvalCred);
        }

        public DataSet ADActualizarEvalAlterna(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_ActualizarEvalAlterna_Sp", idEvalCred);
        }

        public DataTable ADGrabarEvalAlterna(int idEvalCred, int idEvalCredPrinc, string xmlEvalCred, string xmlBalGenEval, string xmlEstResEval, string xmlIndicadorEval, string xmlOtroIngreso)
        {
            return objEjeSp.EjecSP("CRE_GrabarEvalAlterna_SP", idEvalCred, idEvalCredPrinc, xmlEvalCred, xmlBalGenEval, xmlEstResEval, xmlIndicadorEval, xmlOtroIngreso);
        }

        public DataSet ADInicializarEvalAlterna()
        {
            return objEjeSp.DSEjecSP("CRE_InicializarPyme_Sp");
        }
        public DataTable ADValidarPlazoMaxTipCliDestCre(int idEvalCre, int nPlazoCompraDeuda)
        {
            return objEjeSp.EjecSP("CRE_ValidarPlazoMaxTipCliDestCre_SP", idEvalCre, nPlazoCompraDeuda);
        }

        public DataSet RecuperarDetalleGeneralEstResultadosEval(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_DetalleGeneralEstResEval_Sp", idEvalCred);
        }

        public DataTable ListaTasasNegociables(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListaTasasNegociables_Sp", idSolicitud);
        }

        public DataTable ListaEvalPorClienteMonedaTipoEval(int idCli, int idTipEvalCred, int idMoneda, int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ListEvalPorCliMonTipo_Sp", idCli, idTipEvalCred, idMoneda, idEvalCred);
        }

        public DataTable CopiarEvalucionCredito(int idEvalCredActual, int idEvalCredAnterior)
        {
            return objEjeSp.EjecSP("CRE_CopiarEval_Sp", idEvalCredActual, idEvalCredAnterior);
        }

        public DataTable ADValidarPlazoXMonto(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ValidarPlazoXMonto_SP", idEvalCred);
        }

        public DataTable BusEvalsParaHorizontal(int idCli, int idTipEvalCred)
        {
            return objEjeSp.EjecSP("CRE_BusEvalsParaHorizontal_SP",idCli,idTipEvalCred);
        }

        public DataSet RecuEvalParaHorizontal(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_RecuEvalParaHorizontal_SP", idEvalCred);
        }

        public DataTable ActualizarUltimatEval(int idEvalCred, int idUltEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ActualizarUltimatEval_SP",idEvalCred, idUltEvalCred);
        }
        #endregion

        #region Creditos Rapidos
        public DataTable listarSolicitudCreditoCampania(int idCli, int idUsuario, int idTipEvalCred)
        {
            return objEjeSp.EjecSP("CRE_ListarSolicitudCreditoCampania_SP", idCli, idUsuario, idTipEvalCred);
        }
        public DataTable ListarEvaluacionGeneralesPorCliente(int idCli, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListEvalGenericosPorCli_Sp", idCli, idUsuario);
        }

        public DataTable CrearEvalRapiCredito(int idSolicitud, int idTipEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_CrearEvalRapiCredito_Sp", idSolicitud, idTipEvalCred, idUsuario);
        }

        public DataSet BuscarEvalRapiCredito(int idEvalCred)
        {
            return objEjeSp.DSEjecSP("CRE_BusEvalRapiCredito_Sp", idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlBalGenEval, string xmlEstResEval, string xmlIndicadorEval, bool lAgricola, string xmlDatosAgricola, string xmlReferencias, string xmlDestCredProp)
        {
            return objEjeSp.EjecSP("CRE_ActualizarRapiCredito_Sp", idEvalCred, xmlEvalCred, xmlBalGenEval, xmlEstResEval, xmlIndicadorEval, lAgricola, xmlDatosAgricola, xmlReferencias, xmlDestCredProp);
        }

        public DataTable DeterminarCanalAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_DeterminarCanalAprobacion_SP", idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataSet DeterminarCanalesAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return objEjeSp.DSEjecSP("CRE_DeterminarCanalesAprobacion_SP", idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComite_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataSet ImprimirEvalResumida(int idSolicitud, int idEvalCred)
        {
            return objEjeSp.DSEjecSP("RPT_ImpEvalResumida_SP", idSolicitud, idEvalCred);
        }

        public DataTable ADGuardaDeudasEvalResumidas(int idEvalCred, string cDeudas)
        {
            return objEjeSp.EjecSP("CRE_GuardaDeudasEvalResumidas_Sp", idEvalCred, cDeudas);
        }

        public DataTable ADRetornarProducto(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_RetornacProducto_SP", idProducto);
        }

        public DataTable EnviarAComiteCreditosRapid(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable, bool lAsesorAprobaEvalRapida = true, int idPerfilAsesorAproba = 0)
        {
            return objEjeSp.EjecSP("CRE_EnviarAComiteRapid_Sp", idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable, lAsesorAprobaEvalRapida, idPerfilAsesorAproba);
        }

        public DataTable WCFCNListarSolicitudPendienteEvaluacion(int idUsuario)
        {
            return objEjeSp.EjecSP("WCF_ListarSolicitudPendienteEvaluacion_SP", idUsuario);
        }

        public DataTable WCFCNGetBalanceGeneral(int idTipEvalCred, int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_ListarBalanceGeneral_SP", idTipEvalCred, idEvalCred);
        }
        /*

        public DataTable WCFADGuardarEvaluacionBal(int idSolicitud, int idEvalCred, string estRes, decimal nEndeudamiento, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardaEvalAndroid_SP", idSolicitud, idEvalCred, estRes, nEndeudamiento, idUsuario);
        }
         * */

        public DataTable WCFCNGetEstadoResultados(int idTipEvalCred, int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_ListarEstadoResultados_SP", idTipEvalCred, idEvalCred);
        }

        public DataTable WCFADGuardarEvaluacionCred(int idSolicitud, int idEvalCred, string estRes, string lBalance, Decimal nCapacidadPago, Decimal nEndeudamientoTotal, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GuardaEvalAndroid_SP", idSolicitud, idEvalCred, estRes, lBalance, nCapacidadPago, nEndeudamientoTotal, idUsuario);
        }

        public DataTable WCFADGetCondicionesCredito(int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_GetCondicionesCredito_SP", idEvalCred);
        }

        public DataTable WCFADActualizarPropuesta(int idEvalCred, int idPeriodoCred, int nCuotas, int nDiasGracia, string cFechaDesembolso, string cFechaPrimeraCuota, decimal nCapitalPropuesto, int idTasa, decimal nTEA, decimal nTIM, int idProducto, int idTipoPeriodo, int nPlazoCuotaPropuesto, int idSolicitud, decimal nCuotaAprox, decimal nCuotaAproxGracia)
        {
            return objEjeSp.EjecSP("WCF_ActualizarPropuesta_SP", idEvalCred, idPeriodoCred, nCuotas, nDiasGracia, cFechaDesembolso, cFechaPrimeraCuota, nCapitalPropuesto, idTasa, nTEA, nTIM, idProducto, idTipoPeriodo, nPlazoCuotaPropuesto, idSolicitud, nCuotaAprox, nCuotaAproxGracia);
        }

        public DataTable WCFADGuardarReferenciaEvalCred(int idEvalCred, string hdocReferencias)
        {
            return objEjeSp.EjecSP("WCF_GuardarReferenciaEvalCred_SP", idEvalCred, hdocReferencias);
        }

        public DataTable WCFCNObtenerReferecnias(int idEvalCred)
        {
            return objEjeSp.EjecSP("WCF_ObtenerReferencias_SP",  idEvalCred);
        }

        public DataTable WCFSolicitudIdCli(int idCliente)
        {
            return objEjeSp.EjecSP("WCF_SolicitudPorIdCliente_SP", idCliente);
        }

        public DataTable WCFTiposDocumento(int idSolicitud, int idUsuario, bool lChecklist = false)
        {
            return objEjeSp.EjecSP("CRE_ObtenerTipogrupoArchivo_SP", idSolicitud, idUsuario, lChecklist);
        }

        public DataTable ADRetornaValidacionCampania(int idSolicitud, string NombreForm)
        {
            return objEjeSp.EjecSP("CRE_ValidaMontosCampania_SP", idSolicitud,NombreForm);
        }
        #endregion

        #region
        public DataTable WCFCNGetDataFichaCliente(int idCli, int nFicha, int idCuenta)
        {
            return this.objEjeSp.EjecSP("WCF_ListarDataFicha_SP", idCli, nFicha, idCuenta);
        }

        public DataTable WCFCNGetFichaVisita(int idFicha)
        {
            return objEjeSp.EjecSP("WCF_ListarPreguntasFicha_SP", idFicha);
        }

        public DataTable WCFCNGetDatosVisita(int idVisita)
        {
            return objEjeSp.EjecSP("WCF_ListarDatosVisita_SP", idVisita);
        }

        public DataTable WCFCNGetFichaVisitaRespuesta(int idFicha, int idVisita)
        {
            return objEjeSp.EjecSP("WCF_ListarPreguntasFichaRespuesta_SP", idFicha, idVisita);
        }

        public DataTable WCFCNDestinoCreditoEval(int idEvalCred)
        {
            return objEjeSp.EjecSP("CRE_DestinoCreditoEval_SP", idEvalCred);
        }

        public DataTable WCFCNGetVisitasFechaAsesor(int idUsuario, int nUltMeses)
        {
            return objEjeSp.EjecSP("WCF_ListaVisitaFechaAsesor_SP", idUsuario, nUltMeses);
        }

        public DataTable WCFCNGetCreditoRecuperacionesVisita(int idCli)
        {
            return objEjeSp.EjecSP("WCF_CreditoRecuperacionesVisita_SP", idCli);
        }

        public DataTable WCFCNGetPlanPagosPendientes(int nNumCredito)
        {
            return objEjeSp.EjecSP("WCF_PlanPagosPendiente_SP", nNumCredito);
        }

        public DataTable WCFCNGetTiposVisita(int idPerfil)
        {
            return objEjeSp.EjecSP("WCF_TiposVisitaPerfil_SP", idPerfil);
        }

        #endregion

        #region Evaluacion Basica y Aprobacion
        public DataTable grabarEvalCredBasico(int idSolicitud, int idTipEvalCred, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_GrabarEvalCredBasico_SP", idSolicitud, idTipEvalCred, idUsuario);
        }
        public DataTable enviarSolicitudAprobacion(int idSolicitud, int idEvalCred, int idOperacion, int idUsuario, DateTime dFecha, int idCanalAproCred, bool lCanalAproCredEditable)
        {
            return objEjeSp.EjecSP("CRE_EnviarSolicitudAprobacion_SP", idSolicitud, idEvalCred, idOperacion, idUsuario, dFecha, idCanalAproCred, lCanalAproCredEditable);
        }
        public DataTable validarEnvioSolicitudAprobacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidarEnvioSolicitudAprobacion_SP", idSolicitud);
        }
        #endregion

        #region EvalResumida
        public DataSet ADInicializaEvalResumida()
        {
            return objEjeSp.DSEjecSP("CRE_InicializaEvalResumida_SP");
        }
        #endregion
        public DataTable validarTipoSeguroConyugal(int idCli, decimal nMontoSolicitado)
        {
            return objEjeSp.EjecSP("CRE_ValidarSeguroConyugal_SP", idCli, nMontoSolicitado);
        }
    }
}
