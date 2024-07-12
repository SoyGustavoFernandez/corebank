using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsADSolicitud
    {
        IntConexion objEjeSp;

        public clsADSolicitud()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADSolicitud(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ExtraeDatosSolicitud(Int32 idsolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatoSolicitudxIDSolicitud_sp", idsolicitud);
        }
        public DataTable obtenerSolicitudCreditoDetalle(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolicitudCreditoDetalle_SP", idSolicitud);
        }
        public DataTable ExtraeDatosSolicitudAprobacion(Int32 idsolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosSolicitud_SP", idsolicitud);
        }

        public DataTable ExtraeDatosSolicitudTNegAproba(Int32 idsolicitud, int idTasaNegociada)
        {
            return objEjeSp.EjecSP("CRE_DatoSolicitudxIDSolicitudTN_SP", idsolicitud, idTasaNegociada);
        }
        public DataTable ExtraeDatosSolicitudCapitalSol(Int32 idsolicitud)
        {
            return objEjeSp.EjecSP("CRE_MostrarImporteSolicitudxIDSolicitudTN_SP", idsolicitud);
        }
        public DataTable ExtraeDatosSolicitudTNegociable(Int32 idsolicitud, int idUsuarioReg)
        {
            return objEjeSp.EjecSP("CRE_DatoSolicitudxIDTNegociable_SP", idsolicitud, idUsuarioReg);
        }

        public DataTable ADRegistraSolicitudTasaNegociable(int idSolicitud, int idTasa, decimal nTasaSolicitada,
                                                    decimal nTasaMoratoriaSol, string cJustificacion, int idUsuReg,
                                                    int idTasaAnt, decimal nTasaAprobadaAnt, int idAgencia, DateTime dFechaSolicitada,
                                                    int nTipCre, int nSubTip, int nProdu, int nSubPro, int idMoneda,
                                                    Decimal nCapitalSolicitado, int nCuotas, int idTipoPeriodo,
                                                    int nPlazoCuota, int nDiasGracia, DateTime dFechaDesembolso, string cNombreEntidadFinanciera, decimal nTasaEntidad,
                                                    string cComentarioEntidad, decimal nMontoEntidad, int idMotivoTasa, string cComenMotivoTasa, int idEntidad, int idTasaNegociada, int ntipoDesembolso, int nTipoOperacion, int idEstablecimiento, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_RegistroSolicitudTasaNegociable_SP", idSolicitud, idTasa, nTasaSolicitada,
                                                                    nTasaMoratoriaSol, cJustificacion, idUsuReg,
                                                                    idTasaAnt, nTasaAprobadaAnt, idAgencia, dFechaSolicitada,
                                                                    nTipCre, nSubTip, nProdu, nSubPro, idMoneda,
                                                                    nCapitalSolicitado, nCuotas, idTipoPeriodo,
                                                                    nPlazoCuota, nDiasGracia, dFechaDesembolso, cNombreEntidadFinanciera, nTasaEntidad,
                                                                    cComentarioEntidad, nMontoEntidad, idMotivoTasa, cComenMotivoTasa, idEntidad, idTasaNegociada, ntipoDesembolso, nTipoOperacion, idEstablecimiento, idPerfil);
        }

        public DataTable ADRegistroAbprobacionTasaNegociable(int idTasaNegociada, int idUsuario, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual, string cJustificacionAprobacion)
        {
            return objEjeSp.EjecSP("CRE_AprobarCambioTasa_SP", idTasaNegociada, idUsuario, nTasaInteres, nTasaMoratoria, nTasaInteresMensual, cJustificacionAprobacion);
        }

        public DataTable ADRegistroPreAprobacionTasaNegociable(int idTasaNegociada, int idUsuario, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual)
        {
            return objEjeSp.EjecSP("CRE_PreAprobacionCambioTasa_SP", idTasaNegociada, idUsuario, nTasaInteres, nTasaMoratoria, nTasaInteresMensual);
        }        

        public DataTable ADDenegarAprobacionTasaNegociable(int idTasaNegociada, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_DenegarCambioTasa_SP", idTasaNegociada, idUsuario);
        }

        public DataTable AnularSolicitudTasaNegociable(int idTasaNegociada, int idEstado, int idUsuario, int idSolAproba)
        {
            return objEjeSp.EjecSP("CRE_AnularCambioTasa_SP", idTasaNegociada, idEstado, idUsuario, idSolAproba);
        }
        public DataTable ADAnularDenegarSolicitudTasaNegociable(int idTasaNegociada, int idEstado, int idUsuario, int idMotivoAnula, string cOtros, string cTipoEvento)
        {
            return objEjeSp.EjecSP("CRE_AnularDenegarCambioTasa_SP", idTasaNegociada, idEstado, idUsuario, idMotivoAnula, cOtros, cTipoEvento);
        }
        public DataTable ADBuscaSolicitudxidTasaNegociable(int idTasaNegociada)
        {
            return objEjeSp.EjecSP("ADM_ListaSolicitudxidTasaNegociada", idTasaNegociada);
        }
        public DataTable ListaSolicitudesTasaNegociable(int idUsuario, int idPerfilUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListaSolicitudTasaNegociable_SP", idUsuario, idPerfilUsuario);
        }
        public DataTable ADListaSolicitudesTasaNegociableUnificado(int idUsuario, int idPerfilUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListaSolicitudTasaNegociableUnificado_SP", idUsuario, idPerfilUsuario);
        }
        public DataTable ListaSolicitudesTasaNegociablePrepAprobacion(int idUsuario, int idPerfilUsuario)
        {
            return objEjeSp.EjecSP("WCF_ListaPreAprobacionTasaNegociablePendiente_SP", idUsuario, idPerfilUsuario);
        }

        public DataTable ADListaSoliciPreTasaNegociable(int idUsuario, int idPerfilUsuario, int idSolAproba, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListaPreSolicitudTasaNegociable_SP", idUsuario, idPerfilUsuario, idSolAproba, idSolicitud);
        }

        public DataTable SeguimientoTasaNegociable(int idSolicitud, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_SeguimientoSolicitudTasaNegociable_SP", idSolicitud, idUsuario);
        }

        public DataTable InsUpdSolicitud(String tSolicitud, string xmlCreditoProp, Int32 nIdAgencia, int idCuenta, int idSoliCambio,
                                        String XmlSolCreAmp, Boolean lBaseNegativa, DateTime dFechaSis, int idUsuario, int idOferta = 0, int idCanalVend = 0, bool lOpinionRiesgos = false)
        {
            return objEjeSp.EjecSP("CRE_InsUpdSolicitud_SP", tSolicitud, (xmlCreditoProp ?? (object)DBNull.Value), nIdAgencia, idCuenta, idSoliCambio,
                                    (XmlSolCreAmp ?? (object)DBNull.Value), lBaseNegativa, dFechaSis, idUsuario, idOferta, idCanalVend, lOpinionRiesgos);
        }

        public DataTable InsertaEvaluacionSolicitudExt(int idSolicitud_INI, int idSolicitud_FIN, String tipo)
        {
            return objEjeSp.EjecSP("CRE_CreaEvalCredCli_SP", idSolicitud_INI, idSolicitud_FIN, tipo);
        }

        public DataTable ExtraeSolicitudesClienteEstado(Int32 nIdCli, Int32 idEstado)
        {
            return objEjeSp.EjecSP("CRE_ListaSolEstadoCliente_sp", nIdCli, idEstado);
        }

        public DataTable ExtraeSolicitudDesembolso(Int32 nIdSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListaDatosDesembolso_sp", nIdSolicitud);
        }
        public DataTable ADEsDesembolsoVirtual(Int32 idCuenta)
        {
            return objEjeSp.EjecSP("GEN_EsDesembolsoVirtual_SP", idCuenta);
        }
        public DataTable ADdtValidaRegSol(Int32 nNumcliente, Int16 nIdProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidaRegSol_SP", nNumcliente, nIdProducto);
        }

        public DataTable ADDesembolsoCliente(Int32 idSol)
        {
            return objEjeSp.EjecSP("CRE_DesemsolsoCliente_sp", idSol);
        }

        public DataTable ADdtLisSolEstSolxTipoEva(Int32 idcliente, int idTipoEvaluac)
        {
            return objEjeSp.EjecSP("CRE_BuscaSolCreClixTipoEva_sp", idcliente, idTipoEvaluac);
        }

        public DataTable ADdtLisSolEstSol(Int32 idcliente)
        {
            return objEjeSp.EjecSP("CRE_BuscaSolCreCli_sp", idcliente);
        }

        public DataTable ADdtRegRelEvaConSol(Int32 IdSolicitud, Int32 IdEvaCons, Int32 IdUsuReg, DateTime dFecReg)
        {
            return objEjeSp.EjecSP("CRE_RelEvaConsCli_SP", IdSolicitud, IdEvaCons, IdUsuReg, dFecReg);
        }

        public DataTable ADdtRegRelEvaEmprSol(Int32 IdSolicitud, Int32 IdEvaCons, Int32 IdUsuReg, DateTime dFecReg)
        {
            return objEjeSp.EjecSP("CRE_RelEvaEmprCli_SP", IdSolicitud, IdEvaCons, IdUsuReg, dFecReg);
        }

        public DataTable ADdtLisEvaConCre(Int32 IdCliente)
        {
            return objEjeSp.EjecSP("Cre_ListEvaConsumoCre_Sp", IdCliente);
        }

        public DataTable ADdtLisEvaEmprCre(Int32 IdCliente)
        {
            return objEjeSp.EjecSP("Cre_ListEvaEmprCre_Sp", IdCliente);
        }

        public DataTable ADUpdTasaSolCre(Int32 idSolicitud, Decimal nTasaCosEfe)
        {
            return objEjeSp.EjecSP("CRE_UpdTasaSolicitud_sp", idSolicitud, nTasaCosEfe);
        }

        public DataTable ADListaEstadoSolCre(Int32 idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_LisEstadoSolCre_sp", idSolicitud);
        }

        public DataTable ADBusAgenciaSolCre(Int32 idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_BusAgenciaSolCre_sp", idSolicitud);
        }

        public DataTable retornaDatSolReprograma(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetDatSolReprograma_SP", idSolicitud);
        }

        public DataTable ADRetCuentasAmpliadas(int idCodSol)
        {
            return objEjeSp.EjecSP("CRE_RetCuentasAmpliadas_sp", idCodSol);
        }

        public DataTable ADRetornaEvalCredito(int idCodSol, int idTipoCredito)
        {
            return objEjeSp.EjecSP("CRE_ListaEvalSolicitud_sp", idCodSol, idTipoCredito);
        }

        public DataTable ADClasificarCredito(string cNumDocuId)
        {
            return objEjeSp.EjecSP("CRE_ValidarTipoCredito_sp", cNumDocuId);
        }

        public DataTable ADBusFamCred(int IdProducto, int IdSubProducto)
        {
            return objEjeSp.EjecSP("Cre_BusFamProd_Sp", IdProducto, IdSubProducto);
        }

        public DataTable retornaDatSolRefinanciacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetDatSolFinanciacion_SP", idSolicitud);
        }

        public DataTable ADdtBuscarPropuestaCreConsumo(int nidCliente)
        {
            return objEjeSp.EjecSP("CRE_PropuestaCreConsumoXIdCli_sp", nidCliente);
        }

        /// <summary>
        /// Retorna los datos de una solicitud de credito empresarial
        /// </summary>
        /// <param name="nidCliente"></param>
        /// <returns></returns>
        public DataTable ADdtBuscarDatosSolCreEmpresarial(int nidCliente)
        {
            return objEjeSp.EjecSP("CRE_DatosSolCreEmpresarialXIdCli_sp", nidCliente);
        }

        public DataTable ValidaGarantiasSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidaGarantiasSolicitud_sp", idSolicitud);
        }

        public DataTable RetornaGravamenSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetGravSol_sp", idSolicitud);
        }

        public DataTable retornaDatosAsesorDeCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_RetornaDatosAsesorDeCliente_SP", idCli);
        }

        public DataTable ADListarSolicitudesSinAsesor(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarSolicitudesSinAsesor_SP", idAgencia);
        }

        public DataTable ADAsignarAsesorSolicitud(int idSolicitud, int idAsesor)
        {
            return objEjeSp.EjecSP("CRE_AsignarAsesorSolicitud_SP", idSolicitud, idAsesor);
        }

        public DataTable ADListarGarantiasxSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ListarGarantiasxSolicitud_SP", idSolicitud);
        }

        public DataTable ADRegDesvinculacionSolGar(int idSolicitud, int idUsuMod, DateTime dFecModReg)
        {
            return objEjeSp.EjecSP("CRE_RegDesvinculacionSolGar_SP", idSolicitud, idUsuMod, dFecModReg);
        }

        public DataTable ADGetDatGenCreSolCre(int idSolicitud)
        {
            return objEjeSp.EjecSP("GEN_GetDatGenCreSolCre_Sp", idSolicitud);
        }

        public clsDBResp ADActualizaEstadoSolCre(int idSolicitud, int idEstado)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizaEstadoSolCre_Sp", idSolicitud, idEstado);
            return new clsDBResp(dtResult);
        }

        public clsDBResp ADAprobacionesCapacitacion(int idSolicitud, int idEstado)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_AprobacionesCapacitacion_Sp", idSolicitud, idEstado);
            return new clsDBResp(dtResult);
        }
        public clsDBResp ADAprobacionesSolicitud(int idSolicitud, int idEstado, int idnivelAprobacion, int idUsuApro, int nIdUsuarioModifica, DateTime dFechaMod, int idPerfil)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_AprobacionSolicitudes_Sp", idSolicitud, idEstado, idnivelAprobacion, idUsuApro, nIdUsuarioModifica, dFechaMod, idPerfil);
            return new clsDBResp(dtResult);
        }
        public clsDBResp ADAprobacionesSolicitudRNC(int idRNC, string cSustento, int idNivelAprobacion, int lAprobDesaprob, int idUsuReg)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_AprobDesaprobReglaNoCont_SP", idRNC, cSustento, idNivelAprobacion, lAprobDesaprob, idUsuReg);
            return new clsDBResp(dtResult);
        }
        public clsDBResp ADDatosReporteRNC(int idSoli, string cActividadPrincial, string cActividadSecundaria, string cInicial, string cDatosAval, string cCuotaNuevoCred, string cUtilidad, string cSuste, string cDesDestino, int idRNC)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsDatosReporteRNC_SP", idSoli, cActividadPrincial, cActividadSecundaria, cInicial, cDatosAval, cCuotaNuevoCred, cUtilidad, cSuste, cDesDestino, idRNC);
            return new clsDBResp(dtResult);
        } 
        public clsDBResp ADEnviaAEvaluacion(string xmlSolicitud, string xmlCreditoProp, int idUsuario, DateTime dFecha)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_EnviaraEvaluacion_SP", xmlSolicitud, xmlCreditoProp, idUsuario, dFecha);
            return new clsDBResp(dtResult);
        }
        public DataTable obtenerDatosReporteRNC(int idSolicitud, int idRNC)
        {
            return objEjeSp.EjecSP("CRE_VerDatosReporteRNC_SP", idSolicitud, idRNC);
        }
        public DataTable obtenerCreditosRefinanciar(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ListarCreditosRefinanciar_SP", idCli);
        }

        public DataTable ValidaProdRefinanciacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ValidaCreditosRefinanciar_SP", idCuenta);
        }
        public DataTable ADExcepcionesGeneradas(int nIdSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ExcepcionesGeneradas_SP", nIdSolicitud);
        }
        public DataTable ADReglasPorFormulario(String cIdsReglas, String cIdOpcion)
        {
            return objEjeSp.EjecSP("CRE_ReglasPorFormulario_SP", cIdsReglas, cIdOpcion);
        }
        public DataTable ADInsertarExcepcionManual(int nIdSolicitud, int nIdAgencia, int nIdCliente, int nIdMoneda, int nIdProducto, decimal nValAproba, int nIdUsuRegist, String xml)
        {
            return objEjeSp.EjecSP("CRE_InsertarExcepcionManual_SP", nIdSolicitud, nIdAgencia, nIdCliente, nIdMoneda, nIdProducto, nValAproba, nIdUsuRegist, xml);
        }

        public DataTable listarCreditosSolEvalAsesor(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ListarCreditosSolEvalAsesor_SP", idUsuario);
        }
        public DataTable insertarSolReglaNoContemplada(int idSolicitud, int idReglaNoContem, int idExcepGen, int idNivelAprob, int idUsuario, string sustento)
        {
            return objEjeSp.EjecSP("CRE_RegSolReglasNoContempladas_SP", idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
        }
        public DataTable consultaSolReglaNoContemplada(int idSolicitud, int idReglaNoContem, int idExcepGen, int idNivelAprob, int idUsuario, string sustento)
        {
            return objEjeSp.EjecSP("CRE_ConsultaReglasNoContempladas_SP", idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
        }
        public DataTable listarReglaSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_listarReglaSolicitud_SP", idSolicitud);
        }

        public DataTable listarBandejaAprobDenegSolicitud(int idUsuario, int idAgencia, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListBandejaAprobDesaprobRNC_SP", idUsuario, idAgencia, idPerfil);
        }

        public DataTable listarBandejaDatosSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaDatosSolicitudRNC_SP", idSolicitud);
        }
        public DataTable cargarSustentoSolicitudRNC(int idRNC, int idNivelAprob)
        {
            return objEjeSp.EjecSP("CRE_ConsultaDatosSolicitudRNCSustento_SP", idRNC, idNivelAprob);
        }
        public DataTable ObtenerReporteRNC(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ReporteRNC_SP", idSolicitud);
        }
        public clsDBResp anularExcepcionNC(int idRNC, DateTime dFechaMod, int idPerfil)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_AnularRNC_SP", idRNC, dFechaMod, idPerfil);
            return new clsDBResp(dtResult);
        }
        public DataTable ObtenerReporteRNC1(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_SaldoEntidad_SP", idSolicitud);
        }
        public DataTable ObtenerReporteRNCIni(int idSolicitud, int idRegla, string sustento)
        {
            return objEjeSp.EjecSP("CRE_ReporteRNCIni_SP", idSolicitud, idRegla, sustento);
        }
        public DataTable cargarLblBtnSolicitudRNC(int idRNC, int idNivelAprob)
        {
            return objEjeSp.EjecSP("CRE_ConsultaDatosSolicitudRNCLblBtn_SP", idRNC, idNivelAprob);
        }
        public DataTable verificarSolOpiRecu(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtieneSolicitudPendOpiRecu_SP", idSolicitud);
        }

        public DataTable actualizarMontosSolRefi(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ActualizarMontosSolRefi_SP", idSolicitud);
        }

        public DataTable verificarSolReaprobacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtieneSolicitudPendReaprobacion_SP", idSolicitud);
        }

        public DataTable obtenerValorActualSoliRefi(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerValorActualSolRef_SP", idSolicitud);
        }

        public DataTable ADBuscaSolicitudesGS(int idGrupo)
        {
            return objEjeSp.EjecSP("CRE_BuscarSolicitudGS_SP", idGrupo);
        }
        #region #WebService

        public DataTable ADEnviarAEvaluacionWS(string clsPropuesta, int idUsuario, int idSolicitud, string cXML)
        {
            return objEjeSp.EjecSP("WCF_EnviarAEvaluacion_SP", clsPropuesta, idUsuario, idSolicitud, cXML);
        } 
        
        #endregion

        public DataTable ADConsultaRegistroGarantias(int idCli, int idProducto, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ConsultaRegistroGarantias_SP", idCli, idProducto, idSolicitud);
        }

        public DataTable ObtenerDatosCampana(int idCliente)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosCampana_SP", idCliente);
        }

        public DataTable ObtenerEstablecimientoEOB()
        {
            return objEjeSp.EjecSP("CRE_ObtenerEstablecimientos_SP");
        }

        public DataTable CargarDatosAprobadorCampana(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_CargarDatosAprobadorCampana_SP", idSolicitud);
        }
        
        public DataTable ObtenerDatosValidacionCampana(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDatosValidacionCampana_SP", idSolicitud);
        }

        public DataTable ObtenerVinculados(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_LisIntervxCre", idSolicitud, 1);
        }

        public DataTable BuscarClientesVincular(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("Gen_BuscarCli_sp", idTipoDocumento, cDocumentoID, 0);
        }

        public DataTable BuscarClienteCriterioExpresion(int idCriterio, string cExpresion)
        {
            return objEjeSp.EjecSP("WCF_BusquedaClienteCriterio_SP", idCriterio, cExpresion);
        }

        public Boolean RegistroInterviniente(int idSolicitud, int idCli, int idTipoInterviniente, int idUsuario, DateTime dFechaSistema)
        {
            try
            {
                objEjeSp.EjecSPAlm("WCF_RegistroIntervinienteCredito_SP", idSolicitud, idCli, idTipoInterviniente, idUsuario, dFechaSistema);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean EliminarInterviniente(int idIntervinienteCredito, int idUsuario, int idAgencia, DateTime dFechaSistema)
        {
            try
            {
                objEjeSp.EjecSPAlm("WCF_EliminiarIntervinienteCredito_SP", idIntervinienteCredito, idUsuario, idAgencia, dFechaSistema);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable ValidaBaseNegativa(string cDocumentoID)
        {
            return objEjeSp.EjecSP("CLI_ValidarCliBaseNegativa_Sp", cDocumentoID, 1);
        }

        public DataTable ValidaPep(String cDocumentoID)
        {
            return objEjeSp.EjecSP("GEN_BuscarPersonaPep", 1, cDocumentoID, 0);
        }

        public DataTable VincularCuentaDepositoCredito(int idSolicitud, int idCuentaDeposito, int idCuentaCredito, bool lPeticionNuevaCuenta)
        {
            return objEjeSp.EjecSP("CRE_VincularCuentaDepositoCredito_SP", idSolicitud, idCuentaDeposito, idCuentaCredito, lPeticionNuevaCuenta, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
        }

        public DataTable ObtenerDestinoCreditoEvaluacion(int idSolicitud, int idTipoDestinoCreditoBusqueda)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDestinoCreditoEvaluacion_SP", idSolicitud, idTipoDestinoCreditoBusqueda);
        }

        public DataTable ADBuscarCuentaAmpliacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_BuscarCuentaAmpliacion_SP", idSolicitud);
        }

        public DataTable ADObtenerEstadoSolicitud(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerEstadoSolicitud_SP", idSolicitud);
        }
        public DataTable ADObtenerIntervinienteSolicitudBiometrico(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerIntervinienteSolicitudBiometrico_SP", idSolicitud);
        }

        public DataTable ADValidarMontoCampanaCliente(int idCliente, int idProducto, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_ValidacionMontoCampana_SP", idCliente, idProducto, idOperacion);
        }

        public DataTable ADValidarSolicitudEAI(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidarSolicitudEAI_SP", idSolicitud);
        }

        public DataTable ADValidarSolicitudAct(int idCli, int nCodigoSol, int idSubProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidarSolicitudActEAI_SP", idCli, nCodigoSol, idSubProducto);
        }

        public DataTable ADValidarBloqueoEAI(int idCli, int idSubProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidarBloqueoEAI_SP", idCli, idSubProducto);
        }

        public DataTable validarAutorizacionDesembolso(int idSolicitud, int idPerfil, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ValidarAutorizacionDesembolso_SP", idSolicitud, idPerfil, idUsuario);
        }

        public DataTable ADObtenerRastreoTasaNegociable(int idSolicitud, int idTasaNegociada, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ObtenerRastreoTasaNegociable_SP", idSolicitud, idTasaNegociada, idUsuario);
        }

        public DataTable ADObtenerRastreoTasaNegociableAPR(int idSolicitud, int idTasaNegociada, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ObtenerAprobacionTasaNegociable_SP", idSolicitud, idTasaNegociada, idUsuario);
        }

        public DataTable ADObtenerRastreoTasaNegociableRepo(int idSolicitud, int idTipoTasa)
        {
            return objEjeSp.EjecSP("CRE_ObtenerAprobacionTasaNegociableRepo_SP", idSolicitud, idTipoTasa);
        }

        public DataTable ADObtenerSolicitudExtornoPendiente(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolicitudExtornoPendienteCuenta_SP", idCuenta);
        }
        public DataTable ADObtenerPlanPagosOrigen(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_LisPlanPagoTot_SP", idCuenta);
        }

        public DataTable ADGuardarExtraPrima(decimal nExtraPrima, string cSustento, int idSolicitud, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_GuardarExtraPrima_SP", nExtraPrima, cSustento, idSolicitud, idUsuario, idPerfil);
        }

        public DataTable ADObtenerExtraPrima(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerExtraPrima_SP", idSolicitud);
        }

        public DataTable ADAutorizacionPoliza(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidarAutorizacionPoliza_SP", idSolicitud);
        }

        public DataTable ADRecuperarBonoClienteCamp(int idCliente, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RecuperarBonoClienteCamp_SP", idCliente, idSolicitud);
        }

        #region Modelo Scoring
        public DataTable ADGuardarModeloScoring(int idEvalCred, int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_GuardarSolicitudModeloScoring_SP", idEvalCred, idSolicitud);
        }

        public DataTable ADGuardarDecisionModeloScoring(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RegistrarDecisionSolicitudModeloScoring_SP", idSolicitud);
        }

        

        #endregion

        #region Solicitud Simplificado
        public DataTable ADRecuperarConfigSolicitudCred(int idTipEvalCred)
        {
            return objEjeSp.EjecSP("CRE_RecuperarConfigSolSimp_SP", idTipEvalCred);
        }
        public DataTable ADRecuperarSectorEconomico(string cSectorEcon = "")
        {
            return objEjeSp.EjecSP("CRE_RecuperarSectorEconomico_SP", cSectorEcon);
        }
        public DataTable ADRecuperarProductoTipEval(string cIDsTipEvalCred)
        {
            return this.objEjeSp.EjecSP("CRE_BuscarProductoTipEvalCred_SP", cIDsTipEvalCred);
        }

        public DataTable ADRecuperarProductoSimpTipEval(string cIDsTipEvalCred)
        {
            return this.objEjeSp.EjecSP("CRE_BuscarProductoCompletoSimp_SP", cIDsTipEvalCred);
        }

        public DataTable ADRecuperarSectorCliente(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_RecuperarSectorCliente_SP", idCliente);
        }

        public DataTable ADRecuperarSaldoRCCCliente(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_RecuperarSaldoRCCCliente_SP", idCliente);
        }

        public DataTable ADRecuperarDatosCreditoCliente(int idCliente)
        {
            return this.objEjeSp.EjecSP("CRE_RecuperarDatosCreditoCliente_SP", idCliente);
        }

        public DataTable ADRecuperarModalidadPago()
        {
            return this.objEjeSp.EjecSP("CRE_RecuperarModalidadPagoCredito_SP");
        }

        public DataTable ADRecuperarTipoCredito()
        {
            return this.objEjeSp.EjecSP("GEN_ListarTipoCredito_SP");
        }

        #endregion

        public DataTable ADObtenerDestinoOpeRefNov(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerDestinoOpeRefNov_SP", idCuenta);
        }

        public DataTable ADObtenerProdCampImpulMyperu(int idCuenta)                                 // Modificaciones rgomez
        {
            return objEjeSp.EjecSP("CRE_ObtenerProdCampImpulsoMyperu_SP", idCuenta);
        }

        public DataTable ADValidaCuentasProgImpulsoMyPeru(int idCli, string cCuentas)               // Modificaciones rgomez
        {
            return objEjeSp.EjecSP("CRE_ValidaCuentasProgImpulsoMyPeru_SP", idCli, cCuentas);
        }

        public DataTable ADVerificaCampImpulsoMyperu(int idGrupoCamp)                               // Modificaciones rgomez
        {
            return objEjeSp.EjecSP("CRE_VerificaCampImpulsoMyPeru_SP", idGrupoCamp);
        }
        
        public DataTable ADVerificarOpinionRiesgosReprogramacion(int idSolicitud, int idOperacion, int idCli, int idTipoPersona)
        {
            return objEjeSp.EjecSP("CRE_VerifOpiRiesgoReprogramacion_SP", idSolicitud, idOperacion, idCli, idTipoPersona);
        }
        public DataTable ADVerificaOpinionRiesgo(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_VerificaOpinionRiesgos_SP", idSolicitud);
        }
        public DataTable ADListaEntidadFinanciera()
        {
            return objEjeSp.EjecSP("ADM_ListaEntidadesFinancieras_SP");
        }
        public DataTable ADListaMotivosolicitudTasa(string cTipo)
        {
            return objEjeSp.EjecSP("ADM_ListaMotivoSolicitudTasa_SP", cTipo);
        }
        public DataTable ADListaMotivoAnulaTasa()
        {
            return objEjeSp.EjecSP("ADM_ListaMotivoAnulaTasa_SP");
        }
        public DataTable ADMostrarEstadoTasaNegociable(int idSolicitud, int idTipoSol)
        {
            return objEjeSp.EjecSP("ADM_ListaEstadoSolicitudTasa_SP", idSolicitud, idTipoSol);
        }
        public DataTable ADMostrarHistoricoTEACliente(int idTipoDocumento, string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_ObtenerHisTEACliente_SP", idTipoDocumento, cDocumento);
        }
        public DataTable ADObtenerZonaUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_ZonaAgencia_SP", idUsuario);
        }
        public DataTable ADMostrarTasaPromedioPonderada(DateTime dFechaSistema, int idAgencia, int idZona, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_SIGTasaPromedioPonderadaCLI_SP", dFechaSistema, idAgencia, idZona, idUsuario);
        }
        public DataTable ADObtenerSolicitudTasaNegociable(int idUsuario, int idSolicitud, int idTipoSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerSolicitudTasaNegociable_SP", idUsuario, idSolicitud, idTipoSolicitud);
        }
        public DataTable ADObtenerMotivoSolicitudTasaNegociable(int idSolicitud, int idTipoSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DevolverMotivoTipoSolTasaNegociable_SP", idSolicitud, idTipoSolicitud);
        }
        public DataTable ADEnviarSolicitudTasaNegociable(int idTasaNegociada, int idEstado, DateTime dFechaSistema)
        {
            return objEjeSp.EjecSP("CRE_EnviarCambioTasa_SP", idTasaNegociada, idEstado, dFechaSistema);
        }
        public DataTable ADDevolverSolicitudTasaNegociable(int idTasaNegociada, int idEstado, string cMotivoAD, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_DevolverCambioTasa_SP", idTasaNegociada, idEstado, cMotivoAD, idUsuario);
        }
        public DataTable ADDevolverSolicitudTasaNegociablePRE(int idTasaNegociada, int idEstado, int idSolTasa, string cMotivoAD, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_DevolverCambioTasaSolApr_SP", idTasaNegociada, idEstado, idSolTasa, cMotivoAD, idUsuario);
        }
        public DataTable ADListaTasa(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia, bool lNegociable, int idOperacion, int idClasificacionInterna)
        {
            return objEjeSp.EjecSP("Cre_ExtraeTasaSolicitud_sp", nPlazo, idProducto, nMonto, idMoneda, idAgencia, lNegociable, idOperacion, idClasificacionInterna);
        }
        public DataTable ADObteneridTasaNegociable()
        {
            return objEjeSp.EjecSP("ADM_ObtenerEstadosTasaNegociable_SP");
        }
        public DataTable ADObtenerEstadosTasaNegociable()
        {
            return objEjeSp.EjecSP("ADM_RetornaEstadosTasaNegociable_SP");
        }
        //--================================================================================
        //--Obtener correos de aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable ADObtenerCuerpoMensajeAprobacionSMS(string cEstado, string cTasa, string cPerfil, string cFechahora)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCuerpoSMSAprobaTasaNegociable_SP", cEstado, cTasa, cPerfil, cFechahora);
        }
        public DataTable ADObtenerCuerpoMensajeAprobacionEMAIL(string cEstadoSol, string cCliente, string cTasa, string cMonto, string cComentario, string cUsuario, string cFechaHora)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCuerpoMensajeAprobaTasaNegociable_SP", cEstadoSol,cCliente, cTasa, cMonto, cComentario, cUsuario, cFechaHora);
        }
        public DataTable ADObtenerCuerpoMensajeSMS(string cUsuario, string cAgencia, string cCliente, string cTasa, string cMonto, string cPerfil)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCuerpoSMSTasaNegociable_SP", cUsuario, cAgencia, cCliente, cTasa, cMonto, cPerfil);
        }
        public DataTable ADObtenerCuerpoMensajeEMAIL(string cUsuario, string cAgencia, string cCliente, string cTasa, string cMonto, string cPerfil, string cTasaPizarra)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCuerpoMensajeTasaNegociable_SP", cUsuario, cAgencia, cCliente, cTasa, cMonto, cPerfil, cTasaPizarra);
        }
        public DataTable ADListarCorreoAprobaSol(string cPerfil, int idZona, int idAgencia, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListarEMAILSolTasaNegociable_SP", cPerfil, idZona, idAgencia, idUsuario, idPerfil);
        }
        public DataTable ADListarCorreoADN(int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListarEmailADNTasaNegociable_SP", idUsuario, idPerfil);
        }
        public DataTable ADListarCorreoPRE(int idUsuarioADN, int idAgencia, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListarEmailPRETasaNegociable_SP", idUsuarioADN, idAgencia, idPerfil);
        }
        public DataTable ADListarCorreoPREGerNegociable(int idUsuarioADN, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListarEmailPerfilNEGPRETasaNegociable_SP", idUsuarioADN, idAgencia);
        }
        //--================================================================================
        //--Obtener celulares de aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable ADListarCelularAprobaSol(string cPerfil, int idZona, int idAgencia, int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListarTELEFONOSolTasaNegociable_SP", cPerfil, idZona, idAgencia, idUsuario, idPerfil);
        }
        public DataTable ADListarCelularPRE(int idUsuarioADN, int idAgencia, int idPerfil)
        {
            return objEjeSp.EjecSP("GEN_ListarSMSPRETasaNegociable_SP", idUsuarioADN, idAgencia, idPerfil);
        }
        public DataTable ADListarCelularPREGerNegociable(int idUsuarioADN, int idAgencia)
        {
            return objEjeSp.EjecSP("GEN_ListarSMSPerfilNEGPRETasaNegociable_SP", idUsuarioADN, idAgencia);
        }
        //--================================================================================
        //--Envío de correos a los aprobadores de Tasa Negociable
        //--================================================================================
        public DataTable ADEnviarCorreoAprobadorTN(string cPerfil, string cDestinatario, string cCuerpo, string cAsunto)
        {
            return objEjeSp.EjecSP("GEN_EnvioCorreoTasaNegociada_SP", cPerfil, cDestinatario, cCuerpo, cAsunto);
        }
        //--================================================================================
        //--Switch de envio EMAIL solicitud Tasa Negociable
        //--================================================================================
        public DataTable ADVerificarParametrosEnvioMail()
        {
            return objEjeSp.EjecSP("GEN_ParametrosenvioEmailSolicitudTasa_SP");
        }
        //--================================================================================
        //--Switch de envio SMS solicitud Tasa Negociable
        //--================================================================================
        public DataTable ADVerificarParametrosEnvioSMS()
        {
            return objEjeSp.EjecSP("GEN_ParametrosenvioSMSSolicitudTasa_SP");
        }
        public DataTable ADGuardaPdfTasaNegociable(int idSolicitud, string cNombreArchivo, byte[] binario, DateTime dFechReg, int idUsuario, bool laproba, string cPerfilUsuario, int idTasaNegociada)
        {
            return objEjeSp.EjecSP("CRE_GuardarArchivoTasaNegociablePDF_SP", idSolicitud, cNombreArchivo, binario, dFechReg, idUsuario, laproba, cPerfilUsuario, idTasaNegociada);
        }
        public DataTable ADGuardaPdfTasaNegociablePost(int idSolicitud, string cNombreArchivo, byte[] binario, DateTime dFechReg, int idUsuario, bool laproba, string cPerfilUsuario, int idTasaNegociada)
        {
            return objEjeSp.EjecSP("CRE_GuardarArchivoTasaNegociablePostPDF_SP", idSolicitud, cNombreArchivo, binario, dFechReg, idUsuario, laproba, cPerfilUsuario, idTasaNegociada);
        }
        //--================================================================================
        //--Bloqueo de Solicitudes
        //--================================================================================
        public DataTable ADVerifEstCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerifEstadoTasaNegociable_sp", idCuenta);
        }
        public DataTable ADBusUsuBlo(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_BusUsuBlo_sp", idUsuario);
        }
        public DataTable ADUpdEstCuenta(int idCuenta, Nullable<int> idUsuario)
        {
            return objEjeSp.EjecSP("CRE_UpdEstadoTasaNegociable_sp", idCuenta, idUsuario);
        }
        public DataTable ADDesbloqueaCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("GEN_DesbloqueaTasaNegociable_sp", idCuenta);
        }
        public DataTable ADAnulaSolaproba(int idSolicitud)
        {
            return objEjeSp.EjecSP("GEN_AnularPRETasaNegociable_sp", idSolicitud);
        }
        public DataTable ADObtenerCuentaXSolicitudAll(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtieneCuentaXSolicitud_SP", idSolicitud);
        }
        public DataTable ADObtenerRepoTasaNegociable(int idSolicitud, bool lRetencion)
        {
            return objEjeSp.EjecSP("ADM_RetornaDatosRepoTasaNegociada_SP", idSolicitud, lRetencion);
        }
        public DataTable ADObtenerClasifInterna(string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_ObtenerClasifInterna_SP", 1, cDocumento);
        }
    }
}
