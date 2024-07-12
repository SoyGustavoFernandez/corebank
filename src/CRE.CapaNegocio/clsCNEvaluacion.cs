using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;
using System.Xml.Linq;

namespace CRE.CapaNegocio
{
    public class clsCNEvaluacion
    {
        //public clsADEvaluacion ObjCredito = new clsADEvaluacion();
        
        private clsADEvaluacion ObjCredito;

        public clsCNEvaluacion(bool lWebService)
        {
            ObjCredito = new clsADEvaluacion(lWebService);
        }

        public clsCNEvaluacion()
        {
            ObjCredito = new clsADEvaluacion();   
        }

        #region Métodos Anteriores
        //PROPUESTA DE CRÉDITO EMPRESARIAL
        public DataTable CNConsPropuestaCre(int idSolicitud)
        {
            return ObjCredito.ADConsPropuestaCre(idSolicitud);
        }
        public DataTable CNInsUpdPropuesta(int idSolicitud, decimal nGarantia, string cNegocio, string cExpCrediticia,
                                            string cDestinoCredito, string cEntornoFamiliar, string cEvaluacion, string cGarantia,
                                            string cConclusiones)
        {
            return ObjCredito.ADInsUpdPropuesta(idSolicitud, nGarantia, cNegocio, cExpCrediticia,
                                                cDestinoCredito, cEntornoFamiliar, cEvaluacion, cGarantia,
                                                cConclusiones);
        }
        public DataTable CNConsPropuesta(int idSolicitud)
        {
            return ObjCredito.ADConsPropuesta(idSolicitud);
        }




        //PROPUESTA DE CRÉDITO CONSUMO
        public DataTable CNConsPropuestaCreConsumo(int idSolicitud)
        {
            return ObjCredito.ADConsPropuestaCreConsumo(idSolicitud);
        }
        public DataTable CNInsUpdPropuestaCreConsumo(int idSolicitud, decimal nGarantia,
                            string cEntornoFamDomicil  , string cVerificLaboral, string cOtrosIngrAcred,
                            string cAvalGarante         , string cDescrPatrim   , string cDestinoCre)
        {
            return ObjCredito.ADInsUpdPropuestaCreConsumo(idSolicitud, nGarantia, 
                                cEntornoFamDomicil  , cVerificLaboral   , cOtrosIngrAcred   ,
                                cAvalGarante        , cDescrPatrim      , cDestinoCre);
        }
        public DataTable CNConsPropuestaConsumo(int idSolicitud)
        {
            return ObjCredito.ADConsPropuestaConsumo(idSolicitud);
        }

        

        public DataTable CNConsExcepciones(int idsolici)
        {
            return ObjCredito.ADConsExcepciones(idsolici);
        }

         public DataTable CNValidarRangoRatios(string xmlRatios)
        {
            return ObjCredito.CNValidarRangoRatios(xmlRatios);
        }

        #endregion

        #region Métodos Compartidos de todas las evaluaciones
         public DataTable ListarEvaluacionPorCliente(int idCli, int idUsuario, string cTipEvalCre)
         {
             return this.ObjCredito.ListarEvaluacionPorCliente(idCli, idUsuario, cTipEvalCre);
         }

         public DataTable CNEnviarAComite(int idEvalCre, int idUsuario, DateTime dFechaSis, string xmlPropuesta, int idCanalAproCred, int lCanalAproCredEditable)
         {
             return this.ObjCredito.ADEnviarAComite(idEvalCre, idUsuario, dFechaSis, xmlPropuesta, idCanalAproCred, lCanalAproCredEditable);
         }

         public DataTable ActualizarDeudasFinancieras(int idEvalCred, decimal nTotalDeudas, string xmlDeudasEval, string xmlDeudasCuotaPago)
         {
             return this.ObjCredito.ActualizarDeudasFinancieras(idEvalCred, nTotalDeudas, xmlDeudasEval, xmlDeudasCuotaPago);
         }

        public DataSet CNEvalCualitativa(int idEvalCre)
        {
            return this.ObjCredito.ADEvalCualitativa(idEvalCre);
        }

        public DataTable CNCambiaLVigenteEval(int idEvalCre, Boolean lVigente)
        {
            return this.ObjCredito.ADCambiaLVigenteEval(idEvalCre, lVigente);
        }

        public DataSet CNPropuestaImpEval(int idSolicitud, int idEvalCre)
        {
            return this.ObjCredito.ADPropuestaImpEval(idSolicitud, idEvalCre);
        }

        public DataSet CNEstadosFinanEval(int idSolicitud, int idEvalCre)
        {
            return this.ObjCredito.ADEstadosFinanEval(idSolicitud, idEvalCre);
        }

        public DataSet CNEstadosFinanEvalAgrico(int idSolicitud, int idEvalCre)
        {
            return this.ObjCredito.ADEstadosFinanEvalAgrico(idSolicitud, idEvalCre);
        }

        public DataSet CNEstadosFinanEvalH2000(int idSolicitud, int idEvalCre)
        {
            return this.ObjCredito.ADEstadosFinanEvalH2000(idSolicitud, idEvalCre);
        }

        public DataSet CNHojaTrabajoEval(int idEvalCred)
        {
            return this.ObjCredito.CNHojaTrabajoEval(idEvalCred);
        }

        public DataSet FlujoCajaEvalPyme(int idEvalCred)
        {
            return this.ObjCredito.FlujoCajaEvalPyme(idEvalCred);
        }

        public DataSet FlujoCajaEvalAgro(int idEvalCred)
        {
            return this.ObjCredito.FlujoCajaEvalAgro(idEvalCred);
        }

        public DataSet BuscarSolicitudesPorCliente(int idCli, int idUsuario, string cTipoEval, string cSectorEcon)
        {
            return this.ObjCredito.BuscarSolicitudesPorCliente(idCli, idUsuario, cTipoEval, cSectorEcon, clsVarGlobal.PerfilUsu.idPerfil);
        }

        public DataTable GrabarNuevaEvalCred(string xmlEvalCred, string xmlSaldosDeudas, int idEstablecimiento)
        {
            return this.ObjCredito.GrabarNuevaEvalCred(xmlEvalCred, xmlSaldosDeudas, idEstablecimiento);
        }

        public DataTable VincularEvalCred(int idEvalCred, string xmlEvalCred, int idEstablecimiento)
        {
            return this.ObjCredito.VincularEvalCred(idEvalCred, xmlEvalCred, idEstablecimiento);
        }

        public DataTable CNActualizarSolicitudAEval(int idEvalCre, int idSolicitud)
        {
            return this.ObjCredito.ADActualizarSolicitudAEval(idEvalCre, idSolicitud);
        }

        public DataSet CNPropuestaEvalConvenio(int idEvalCre, int idSolicitud, int nFuente)
        {
            return this.ObjCredito.ADPropuestaEvalConvenio(idEvalCre, idSolicitud, nFuente);
        }

        public DataSet CNObtenerEvalAlterna(int idEvalCred)
        {
            return this.ObjCredito.ADObtenerEvalAlterna(idEvalCred);
        }

        public DataSet CNActualizarEvalAlterna(int idEvalCred)
        {
            return this.ObjCredito.ADActualizarEvalAlterna(idEvalCred);
        }

        public DataTable CNGrabarEvalAlterna(int idEvalCred, int idEvalCredPrinc, string xmlEvalCred, string xmlBalGenEval, string xmlEstResEval, string xmlIndicadorEval, string xmlOtroIngreso)
        {
            return this.ObjCredito.ADGrabarEvalAlterna(idEvalCred, idEvalCredPrinc, xmlEvalCred, xmlBalGenEval, xmlEstResEval, xmlIndicadorEval, xmlOtroIngreso);
        }

        public DataSet CNInicializarEvalAlterna()
        {
            return this.ObjCredito.ADInicializarEvalAlterna();
        }

        public DataTable CNValidarPlazoMaxTipCliDestCre(int idEvalCre, int nPlazoCompraDeuda)
        {
            return this.ObjCredito.ADValidarPlazoMaxTipCliDestCre(idEvalCre, nPlazoCompraDeuda);
        }

        public DataSet RecuperarDetalleGeneralEstResultadosEval(int idEvalCred)
        {
            return this.ObjCredito.RecuperarDetalleGeneralEstResultadosEval(idEvalCred);
        }

        public DataTable ListaTasasNegociables(int idSolicitud)
        {
            return this.ObjCredito.ListaTasasNegociables(idSolicitud);
        }

        public DataTable ListaEvalPorClienteMonedaTipoEval(int idCli, int idTipEvalCred, int idMoneda, int idEvalCred)
        {
            return this.ObjCredito.ListaEvalPorClienteMonedaTipoEval(idCli, idTipEvalCred, idMoneda, idEvalCred);
        }

        public DataTable CopiarEvalucionCredito(int idEvalCredActual, int idEvalCredAnterior)
        {
            return this.ObjCredito.CopiarEvalucionCredito(idEvalCredActual, idEvalCredAnterior);
        }

        public DataTable BuscarEvalsParaHorizontal(int idCli, int idTipEvalCred)
        {
            return this.ObjCredito.BusEvalsParaHorizontal(idCli, idTipEvalCred);
        }

        public DataSet RecuEvalParaHorizontal(int idEvalCred)
        {
            return this.ObjCredito.RecuEvalParaHorizontal(idEvalCred);
        }

        public DataTable ActualizarUltimatEval(int idEvalCred,int idUltEvalCred)
        {
            return this.ObjCredito.ActualizarUltimatEval(idEvalCred, idUltEvalCred);
        }
        #endregion

        #region Creditos Rapidos
        public DataTable listarSolicitudCreditoCampania(int idCli, int idTipEvalCred)
        {
            return this.ObjCredito.listarSolicitudCreditoCampania(idCli, clsVarGlobal.User.idUsuario, idTipEvalCred);
        }
        public DataTable ListarEvaluacionGeneralesPorCliente(int idCli, int idUsuario)
        {
            return this.ObjCredito.ListarEvaluacionGeneralesPorCliente(idCli, idUsuario);
        }

        public DataTable CrearEvalRapiCredito(int idSolicitud, int idTipEvalCred, int idUsuario)
        {
            return this.ObjCredito.CrearEvalRapiCredito(idSolicitud, idTipEvalCred, idUsuario);
        }

        public DataSet BuscarEvalRapiCredito(int idEvalCred)
        {
            return this.ObjCredito.BuscarEvalRapiCredito(idEvalCred);
        }

        public DataTable ActualizarEval(int idEvalCred, string xmlEvalCred, string xmlBalGenEval, string xmlEstResEval, string xmlIndicadorEval, bool lAgricola, string xmlDatosAgricola, string xmlReferencias, string xmlDestCredProp = null)
        {
            if (string.IsNullOrEmpty(xmlDestCredProp))
            {
                xmlDestCredProp = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><root></root>";
            }
            return this.ObjCredito.ActualizarEval(idEvalCred, xmlEvalCred, xmlBalGenEval, xmlEstResEval, xmlIndicadorEval, lAgricola, xmlDatosAgricola, xmlReferencias, xmlDestCredProp);
        }

        public DataTable DeterminarCanalAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return this.ObjCredito.DeterminarCanalAprobacion(idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataSet DeterminarCanalesAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return this.ObjCredito.DeterminarCanalesAprobacion(idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataTable EnviarAComiteCreditos(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable)
        {
            return this.ObjCredito.EnviarAComiteCreditos(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable);
        }

        public DataSet ImprimirEvalResumida(int idSolicitud, int idEvalCred)
        {
            return this.ObjCredito.ImprimirEvalResumida(idSolicitud, idEvalCred);
        }

        public DataTable CNGuardaDeudasEvalResumidas(int idEvalCred, string cDeudas)
        {
            return this.ObjCredito.ADGuardaDeudasEvalResumidas(idEvalCred, cDeudas);
        }

        public DataTable CNRetornarProducto(int idProducto)
        {
            return this.ObjCredito.ADRetornarProducto(idProducto);
        }

        public DataTable EnviarAComiteCreditosRapid(int idEvalCred, int idUsuario, DateTime dFecha, string xmlDestCredProp, int idCanalAproCred, int lCanalAproCredEditable, bool lAsesorAprobaEvalRapida = true, int idPerfilAsesorAproba = 0)
        {
            return this.ObjCredito.EnviarAComiteCreditosRapid(idEvalCred, idUsuario, dFecha, xmlDestCredProp, idCanalAproCred, lCanalAproCredEditable, lAsesorAprobaEvalRapida,  idPerfilAsesorAproba);
        }
        public DataTable CNRetornaValidacionCampania(int idSolicitud,string NombreForm)
        {
            return this.ObjCredito.ADRetornaValidacionCampania(idSolicitud,NombreForm);
        }
        #endregion

        #region Evaluacion
        public DataTable WCFCNListarSolicitudPendienteEvaluacion(int idUsuario)
        {
            return this.ObjCredito.WCFCNListarSolicitudPendienteEvaluacion(idUsuario);
        }

        public DataTable WCFCNGetBalanceGeneral(int idTipEvalCred, int idEvalCred)
        {
            return this.ObjCredito.WCFCNGetBalanceGeneral(idTipEvalCred, idEvalCred);
        }

        public DataTable WCFCNGetEstadoResultados(int idTipEvalCred, int idEvalCred)
        {
            return this.ObjCredito.WCFCNGetEstadoResultados(idTipEvalCred, idEvalCred);
        }

        public DataTable WCFCNGuardarEvaluacionCred(int idSolicitud, int idEvalCred, string estRes, string lbalance, Decimal nCapacidadPago, Decimal nEndeudamientoTotal, int idUsuario)
        {
            return this.ObjCredito.WCFADGuardarEvaluacionCred(idSolicitud, idEvalCred, estRes, lbalance, nCapacidadPago, nEndeudamientoTotal, idUsuario);
        }

        public DataTable WCFCNGetCondicionesCredito(int idEvalCred)
        {
            return this.ObjCredito.WCFADGetCondicionesCredito(idEvalCred);
        }

        public DataTable WCFCNActualizarPropuesta(int idEvalCred, int idPeriodoCred, int nCuotas, int nDiasGracia, string cFechaDesembolso, string cFechaPrimeraCuota, decimal nCapitalPropuesto, int idTasa, decimal nTEA, decimal nTIM, int idProducto, int idTipoPeriodo, int nPlazoCuotaPropuesto, int idSolicitud, decimal nCuotaAprox, decimal nCuotaAproxGracia)
        {
            return this.ObjCredito.WCFADActualizarPropuesta(idEvalCred, idPeriodoCred,  nCuotas,  nDiasGracia, cFechaDesembolso, cFechaPrimeraCuota, nCapitalPropuesto, idTasa, nTEA, nTIM, idProducto, idTipoPeriodo, nPlazoCuotaPropuesto, idSolicitud, nCuotaAprox, nCuotaAproxGracia);
        }

        public DataTable WCFCNGuardarReferenciaEvalCred(int idEvalCred, string hdocReferencias)
        {
            return this.ObjCredito.WCFADGuardarReferenciaEvalCred(idEvalCred, hdocReferencias);
        }

        public DataTable WCFCNGetObtenerReferencias( int idEvalCred)
        {
            return this.ObjCredito.WCFCNObtenerReferecnias(idEvalCred);
        }

        public DataTable WCFSolicitudIdCli(int idCliente)
        {
            return this.ObjCredito.WCFSolicitudIdCli(idCliente);
        }

        public DataTable WCFTiposDocumento(int idSolicitud, int idUsuario)
        {
            return this.ObjCredito.WCFTiposDocumento(idSolicitud, idUsuario);
        }
        #endregion
        
        #region  Ficha

        public DataTable WCFCNGetDataFichaCliente(int idCli, int nFicha, int idCuenta) 
        {
            return this.ObjCredito.WCFCNGetDataFichaCliente(idCli, nFicha, idCuenta);
        }

        public DataTable WCFCNGetFichaVisita(int idFicha)
        {
            return this.ObjCredito.WCFCNGetFichaVisita(idFicha);
        }

        public DataTable WCFCNGetDatosVisita(int idVisita)
        {
            return this.ObjCredito.WCFCNGetDatosVisita(idVisita);
        }
        
        public DataTable WCFCNGetFichaVisitaRespuesta(int idFicha, int idVisita)
        {
            return this.ObjCredito.WCFCNGetFichaVisitaRespuesta(idFicha, idVisita);
        }

        public DataTable WCFCNDestinoCreditoEval(int idEvalCred)
        {
            return this.ObjCredito.WCFCNDestinoCreditoEval(idEvalCred);
        }

        public DataTable WCFCNGetVisitasFechaAsesor(int idUsuario, int nUltMeses)
        {
            return this.ObjCredito.WCFCNGetVisitasFechaAsesor(idUsuario, nUltMeses);
        }

        public DataTable WCFCNGetCreditoRecuperacionesVisita(int idCli)
        {
            return this.ObjCredito.WCFCNGetCreditoRecuperacionesVisita(idCli);
        }

        public DataTable WCFCNGetPlanPagosPendientes(int nNumCredito)
        {
            return this.ObjCredito.WCFCNGetPlanPagosPendientes(nNumCredito);
        }

        public DataTable WCFCNGetTiposVisita(int idPerfil)
        {
            return this.ObjCredito.WCFCNGetTiposVisita(idPerfil);
        }

        #endregion

        #region Evaluacion Basica y Aprobacion
        public DataTable grabarEvalCredBasico(int idSolicitud, int idTipEvalCred, int idUsuario)
        {
            return this.ObjCredito.grabarEvalCredBasico(idSolicitud, idTipEvalCred, idUsuario);
        }

        public DataTable enviarSolicitudAprobacion(int idSolicitud, int idEvalCred, int idOperacion, int idUsuario, DateTime dFecha, int idCanalAproCred, bool lCanalAproCredEditable)
        {
            return this.ObjCredito.enviarSolicitudAprobacion(idSolicitud, idEvalCred, idOperacion, idUsuario, dFecha, idCanalAproCred, lCanalAproCredEditable);
        }
        public DataTable validarEnvioSolicitudAprobacion(int idSolicitud)
        {
            return this.ObjCredito.validarEnvioSolicitudAprobacion(idSolicitud);
        }
        #endregion

        #region EvalResumida
        public DataSet CNInicializaEvalResumida()
        {
            return this.ObjCredito.ADInicializaEvalResumida();
        }
        #endregion
        public DataTable validarTipoSeguroConyugal(int idCli, decimal nMontoSolicitado)
        {
            return this.ObjCredito.validarTipoSeguroConyugal(idCli, nMontoSolicitado);
        }
    }
}