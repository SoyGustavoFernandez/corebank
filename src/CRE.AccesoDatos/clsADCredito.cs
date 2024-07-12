using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADCredito
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP
        public DataTable ADdtDataCreditoCobro(int nNumCredito)
        {
            //objEjeSp.CargaParametroSP("", 1);
            return objEjeSp.EjecSP("CRE_BusCreditoCobro_SP", nNumCredito);
        }

        public clsCredito ADDataCreditoCobroAmpliacion(int idCuenta)
        {
            return objEjeSp.OEjecutar<clsCredito>("CRE_BusCreditoCobroAmpliacion_SP", idCuenta);
        }

        public DataTable LisCrexAna(Int32 nIdAsesor, int idUsu)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisCrexAnaPagoMasivo_SP", nIdAsesor, idUsu);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ADdtLisSolDesemCampo(Int32 nIdAsesor, Int32 nIdAge)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisSolDesembCampo_SP", nIdAsesor, nIdAge);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Obtiene la cancelación con deuda.
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        public DataTable GetCancConDeuda(int idCuenta)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_GetCancConDeuda_sp", idCuenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ADSaldoCredito(int idCuenta)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_SaldoDeudaCredito_sp", idCuenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CancConDeuda(int idCuenta, int idAgencia, string dFechaCanc, int idTipoMotCanc, int idUsu,
                                    string cDescMotivo, decimal MontoTotal, int idProducto, int idMotivoOperacion, int idSolicitudAproba)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_CancConDeuda_sp", idCuenta, idAgencia, dFechaCanc, idTipoMotCanc, idUsu,
                                                        cDescMotivo, MontoTotal, idProducto, idMotivoOperacion, idSolicitudAproba);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ADPerdonaDeuda(int idCuenta, int idAgencia, string dFechaCanc, int idTipoMotCanc, int idUsu,
                                        string cDescMotivo, decimal nCap, decimal nInt, decimal nIntComp, decimal nOtr,
                                        decimal nMora, int idMotivoOperacion, int idSolicitudAproba)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_PerdonDeuda_sp", idCuenta, idAgencia, dFechaCanc, idTipoMotCanc, idUsu,
                                        cDescMotivo, nCap, nInt, nIntComp, nOtr,
                                        nMora, idMotivoOperacion, idSolicitudAproba);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LisMotCanc()
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisMotCanc_sp");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtLisCrexCli(int nidCliente)
        {
            return objEjeSp.EjecSP("CRE_LisCreCli_sp", nidCliente);
        }

        public DataTable ADdtLisKardexCre(int nNumCredito)
        {
            return objEjeSp.EjecSP("CRE_LisKardexPagoCre_SP", nNumCredito);
        }

        public DataTable LisCreByAna(Int32 nIdAsesor)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisCreByAna_SP", nIdAsesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable LisCreByAnaEst(Int32 nIdAsesor, int nIdEstadoContable)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisCreByAnaEst_SP", nIdAsesor, nIdEstadoContable);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista los creditos de un determinado asesor con el filtro de ubigeo
        /// </summary>
        /// <param name="nIdAsesor">codigo del asesor</param>
        /// <param name="nIdUbigeo">id del ubigeo</param>
        /// <returns>datos de creditos</returns>
        public DataTable LisCreByAnaUbi(Int32 nIdAsesor, int nIdUbigeo)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisCreByAnaUbi_SP", nIdAsesor, nIdUbigeo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable LisCreByAnaUbiEst(Int32 nIdAsesor, int nIdUbigeo, int nIdEstadoContable)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_LisCreByAnaUbiEst_SP", nIdAsesor, nIdUbigeo, nIdEstadoContable);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable UpdCreByAse(string xml, Int32 nIdAsesor, int idAgeDes, int idUsuOpera, DateTime dFecOpera, string cSustento, int iTotalCreditosSeleccionados)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_SolicitudReasignacionCartera_SP", xml, nIdAsesor, idAgeDes, idUsuOpera, dFecOpera, cSustento, iTotalCreditosSeleccionados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DesbMasByAse(Int32 nIdAsesor, int idUsu)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_DesbMasByAse_sp", nIdAsesor, idUsu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ADdtSumSalMorCli(int idCli)
        {
            try
            {
                return objEjeSp.EjecSP("CRE_SumSalMorCli_SP", idCli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //
        public DataTable InsSolicitudCapturaCredito(string XmlSoli, int idUsuarioSistema, DateTime dFecSystem, int idCliente)
        {
            return objEjeSp.EjecSP("CRE_InsSolCapturaCre_SP", XmlSoli, idUsuarioSistema, dFecSystem, idCliente);
        }


        public DataTable BuscarCreditosCliente(Int32 idDocCli)
        {
            return objEjeSp.EjecSP("CRE_BusCreditosCliente_SP", idDocCli);
        }

        public DataTable BuscarCreditosAceptadosParaCaptura(int idDocCli)
        {
            return objEjeSp.EjecSP("CRE_BusCreditosAprobadosCaptura_SP", idDocCli);
        }

        public DataTable ConsultarEstadoSolicitudApruebaCaptura(int idSolCapturaCre)
        {
            return objEjeSp.EjecSP("CRE_EstadoSolCapturaAproba_SP", idSolCapturaCre);
        }

        public DataTable ListarSolicitudesDeCapturaAprobadas()
        {
            return objEjeSp.EjecSP("CRE_SolCapturaAprobadas_SP");
        }

        //Modificado
        public DataTable InsCapturaAJudiciales(int nIdcuenta, int nIdplanpagos, decimal nNuevaTasaInteres, decimal nNuevaTasaMoratoria, DateTime dFechaDelSistema, int nUsuarioDelSistema, int nIdAgencia, int nIdSolAproba)
        {
            return objEjeSp.EjecSP("CRE_InsCapturaAJudiciales_SP", nIdcuenta, nIdplanpagos, nNuevaTasaInteres, nNuevaTasaMoratoria, dFechaDelSistema, nUsuarioDelSistema, nIdAgencia, nIdSolAproba);
        }

        public DataTable InsCancelacionAnticipada(string xmlPagador, DateTime dFechaDelSistema, int nUsuarioDelSistema, int nAgencia,
                                                    int nNumCredito, Decimal nImpuestos, Decimal nRedondeo, Decimal nTotalAPagar, int idCanal,
                                                    int idTipoPago, int idEntidad, int idCtaEntidad, string cNroTrx, int idMotivoOperacion, string cCobs,
                                                    bool lModificaSaldoLinea, int idMoneda, int idTipoTransac)
        {
            return objEjeSp.EjecSP("CRE_RegCancelAnticipada_SP", xmlPagador, dFechaDelSistema, nUsuarioDelSistema, nAgencia, nNumCredito,
                                nImpuestos, nRedondeo, nTotalAPagar, idCanal, idTipoPago,
                                idEntidad, idCtaEntidad, cNroTrx, idMotivoOperacion, cCobs,
                                lModificaSaldoLinea, idMoneda, idTipoTransac);
        }

        public DataTable ListaDocsSustentatoriosCapturaCredito()
        {
            return objEjeSp.EjecSP("CRE_ListDocsSustenCapturaCre_SP");
        }

        public DataTable ListaDocsSustentatoriosCapturaCredito(int nIdCliente)
        {
            return objEjeSp.EjecSP("CRE_ListCreditosAprobadosCaptura_SP", nIdCliente);
        }

        public DataTable InsRefinanciacion(int idSolicitud, DateTime dFecdesemb, decimal nTcea, decimal nTEA, int nSumaDias, DateTime dFechaUltimoPagoCredito, DateTime dFechaSistema, int idUsuario, int nIdAgencia)
        {
            return objEjeSp.EjecSP("CRE_InsRefinanciacion_sp",idSolicitud , dFecdesemb, nTcea, nTEA, nSumaDias, dFechaUltimoPagoCredito, dFechaSistema, idUsuario, nIdAgencia);
        }

        public DataTable ADListarCreditosDctoPlanilla(DateTime dFechaProceso, bool lEstEmpleado)
        {
            return objEjeSp.EjecSP("CRE_ListarCreditosDctoPlanilla_SP", dFechaProceso, lEstEmpleado);
        }

        public DataTable ADListarPagoDctoPlanilla(DateTime dFechaSistema, string xmlDsctoPlanilla, int idUsuario, int idConvenio)
        {
            return objEjeSp.EjecSP("CRE_ListarPagoDctoPlanilla_SP", dFechaSistema, xmlDsctoPlanilla, idUsuario, idConvenio);
        }

        public DataTable ADdtLisCrexCliVig(int nidCliente)
        {
            return objEjeSp.EjecSP("CRE_LisCreCliVig_sp", nidCliente);
        }

        #region Mantenimiento de Docuentos de desembolso

        public DataTable ListarDocumentoDesembolso()
        {
            return objEjeSp.EjecSP("CRE_ListarDocumentoDesembolso_SP");
        }

        public DataTable InsertarDocumentoDesembolso(string cDocumentoDes, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_InsertarDocumentoDesembolso_SP", cDocumentoDes, lVigente);
        }

        public DataTable ActualizarDocumentoDesembolso(string cDocumentoDes, bool lVigente, int idDocumentoDes)
        {
            return objEjeSp.EjecSP("CRE_ActualizarDocumentoDesembolso_SP", cDocumentoDes, lVigente, idDocumentoDes);
        }

        public DataTable EliminarDocumentoDesembolso(int idDocumentoDes)
        {
            return objEjeSp.EjecSP("CRE_EliminarDocumentoDesembolso_SP", idDocumentoDes);
        }
        #endregion

        #region Impresion documentos desembolso

        public DataTable DatosImpContratoJur(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatosImpContratoJur_sp", idSolicitud);
        }

        public DataTable DatosImpContratoNat(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatosImpContratoNat_sp", idSolicitud);
        }

        public DataTable DatosImpPagare(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatosImpPagare_sp", idSolicitud);
        }

        public DataTable DetalleImpPagare(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DetalleImpPagare_sp", idSolicitud);
        }

        public DataTable DatosSolicitudImpPPG(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_DatosSolicitudImpPPG_sp", idSolicitud);
        }

        public DataTable ListaRepresentanteJur(int idCli)
        {
            return objEjeSp.EjecSP("GEN_ListaRepresentanteJur_sp", idCli);
        }
        #endregion

        /// <summary>
        /// Lista los creditos reasignados deacuerdo a el codigo de reasignacion.
        /// </summary>
        /// <param name="nidReasignacionCartera">codigo de reasignacion</param>
        /// <returns>lista de creditos reasignados</returns>
        public DataTable ListCredReasignados(int nidReasignacionCartera)
        {
            return objEjeSp.EjecSP("CRE_LisCreReasignados_SP", nidReasignacionCartera);
        }

        public DataTable ADEnviarEmailAsesor(int idAsesor, int idCuenta, decimal nMontoCanc)
        {
            return objEjeSp.EjecSP("CRE_EnviarEmailAsesor_Sp", idAsesor, idCuenta,nMontoCanc);
        }
        public DataTable ADValidaClienteEsNuevo(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidaClienteEsNuevo_SP", idCli);
        }
        #region CategoriaAsesorRangosSaldoCarteraTopesTransferencias
        public DataTable ADRetornaCategoriaAsesorPoIdCatPersonal(int idCategoriaPersonal)
        {
            return objEjeSp.EjecSP("CRE_RetornaCategoriaAsesorPoIdCatPersonal_SP",idCategoriaPersonal);
        }
        #endregion

        public DataTable obtenerCreditoParaCongelarTasa(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCredCongelarTasa_SP", idCuenta);
        }

        public DataTable congelarTasaInteres(int idCuenta, int idSolAproba, decimal nTEA, decimal nTasaCompensatoria, decimal nTasaMoratoria, decimal nTCEA, DateTime dFechaSistema, int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_CongelarTasaInteres_SP", idCuenta, idSolAproba, nTEA, nTasaCompensatoria, nTasaMoratoria, nTCEA, dFechaSistema, idUsuReg);
        }

        public DataTable listarCreditosCongelados(DateTime dInicio, DateTime dFin, bool lConPagos)
        {
            return objEjeSp.EjecSP("CRE_ListarCreditosCongelados_SP", dInicio, dFin, lConPagos);
        }

        public DataTable consolidarPlanPagos(int idCuenta, int idPlanPagos, DateTime dFechaSistema, int idUsuario, bool lInteresFecha)
        {
            return objEjeSp.EjecSP("CRE_ConsolidaPlanPagos_SP", idCuenta, idPlanPagos, dFechaSistema, idUsuario, lInteresFecha);
        }

        public DataTable ADGuardarComisionBN(int idTipoComision, int idTipoOperacion, int idMoneda, string cComisionBN, double nComisionMin, double nPorcomision, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_GuardarComisionBN_SP", idTipoComision, idTipoOperacion, idMoneda, cComisionBN, nComisionMin, nPorcomision, lVigente);
        }
        public DataTable ADBuscarComisionBN(int idTipoComision, int idTipoOperacion, int idMoneda)
        {
            return objEjeSp.EjecSP("CRE_BuscarComisionBN_SP",idTipoComision, idTipoOperacion, idMoneda);
        }
        public DataTable obtenerCreditoCambioOrdenPrelacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCredCambioOrdenPrelacion_SP", idCuenta);
        }

        public DataTable ObtenerOrdenPrelacion(int idCuenta, int idOrdenPrelacion)
        {
            return objEjeSp.EjecSP("CRE_ObtenerOrdenPrelacion_SP", idCuenta, idOrdenPrelacion);
        }

        public DataTable grabarNuevoOrdenPrelacion(int idCuenta,int idOrdenPrelacion, string xmlOrdenPrelacion, int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_GrabarOrdenPrelacion_SP", idCuenta, idOrdenPrelacion, xmlOrdenPrelacion, idUsuReg);
        }

        public DataTable ValidaPrimerPagoJudicial(int idCuenta)
        {
            return objEjeSp.EjecSP("Cre_ValidaPrimerPagoJudicial_sp", idCuenta);
        }

        public DataTable obtenerListaMora()
        {
            return objEjeSp.EjecSP("CRE_ListarMoraCreditos_SP");
        }

        public DataTable obtenerListaMoraN(string cUsuarios, int nDesde, int nHasta)
        {
            return objEjeSp.EjecSP("CRE_ReporteMora1N_sp", cUsuarios, nDesde.ToString(), nHasta.ToString());
        }

        public DataTable obtenerListaMoraHistorico(DateTime dFecha)
        {
            return objEjeSp.EjecSP("CRE_HistoricoMoraCreditos_SP", dFecha);
        }

        public DataTable obtenerListaCastigos()
        {
            return objEjeSp.EjecSP("CRE_ListarCreditosCastigados_SP");
        }

        public DataTable DeterminarCanalAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_DeterminarCanalAprobacion_SP", idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataTable obtenerPreventivoMora(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_RptReporteMoraPreventiva_SP", idAgencia);
        }

        public DataTable ADObtieneDetalleCondonacion(int idSolicitudAproba)
        {
            return objEjeSp.EjecSP("CRE_BuscaDetalleCondonacion_SP", idSolicitudAproba);
        }

        public DataTable ListarSolicitudesCondonacion(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarSolitidVoBo_SP", idAgencia);
        }

        public DataTable ListarCobrosCreditos(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarSolicitudesEjecutadas_SP", idAgencia);
        }
        public DataTable BuscarDatosDocumentacion(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_BuscarDatosCredito_SP", idSolicitud);
        }
        public DataTable ADDatosGrupoSol(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_RetornaNroGrupo_SP", idCuenta);
        }
        public DataTable ADAlertaCreditosVinculados(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidacionCreditosVinculados_SP", idCli);
        }

        public DataTable ADAlertaCreditos50000(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ValidacionCreditos50000_SP", idSolicitud);
        }

        public DataTable ADBuscarSolicitudAmpliacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_BuscarSolicitudAmpliacion_SP", idCuenta);
        }

        #region Mantenimiento de Configuración Tasas Negociadas 

        public DataTable ADListarTipoTasaNegociable()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoTasaNegociable_SP");
        }

        public DataTable ADObtenerTasaNegociadaPerfil()
        {
            return objEjeSp.EjecSP("CRE_ObtenerTasaNegociadaPerfil_SP");
        }

        public DataTable ADObtenerParametroTasaNegociable()
        {
            return objEjeSp.EjecSP("CRE_ObtenerParametroTasaNegociable_SP");
        }

        public DataTable ADRegistrarTasaNegociadaPerfil(string xmlTasaNegociadaPerfil, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_RegistrarTasaNegociablePerfil_SP", xmlTasaNegociadaPerfil, dFechaSistema, idUsuario);
        }

        public DataTable ADRegistrarParametroAprobTasaNegociable(string xmlParametroTasaNegociada, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_RegistrarParametroTasaNegociable_SP", xmlParametroTasaNegociada, dFechaSistema, idUsuario);
        }
        #endregion
        #region Bloque de Pagos Masivos
        public DataTable ADValidacionCuentasPagoMasivo(string xmlCreditos, int idMoneda)
        {
            return objEjeSp.EjecSP("CRE_ValidacionCuentasPagoMasivo_SP", xmlCreditos, idMoneda);
        }
        public DataSet ADProcesarPagoMasivo(string xmlCreditos, int idTipoPagoMasivo, int idUsuarioOrden, int idAgencia, int idUsuarioReg, DateTime dFechaSistema, byte[] bExcel, int idEntidad, int idCuenta, string cNroOperacion)
        {
            return objEjeSp.DSEjecSP("CRE_ProcesarPagoMasivos_SP", xmlCreditos, idTipoPagoMasivo, idUsuarioOrden, idAgencia, idUsuarioReg, dFechaSistema, bExcel, idEntidad, idCuenta, cNroOperacion);
        }
        public DataTable ADReportePagoMasivo(int idPagoMasivo)
        {
            return objEjeSp.EjecSP("CRE_ReportePagoMasivo_SP", idPagoMasivo);
        }
        public DataTable ADListaPagoMasivo(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEjeSp.EjecSP("CRE_ListaPagoMasivo_SP", dFechaIni, dFechaFin);
        }

        #endregion

        public DataTable ADValidaImpresionPendienteCalendario(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ValidarImpresionPendienteCronogramaPagos_SP", idCuenta);
        }

		public DataTable ADBuscarEstablecimiento(int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_BuscarEstablecimiento_SP", idUsuario, idPerfil);
        }
        public DataTable ADDevolverSolicitud(int idSolicitud, int idMotivoDev,string cComentarioDev,int idUsuReg,DateTime dFechaReg)
        {
            return objEjeSp.EjecSP("CRE_DevolverSolicitudCredito_SP", idSolicitud, idMotivoDev, cComentarioDev, idUsuReg, dFechaReg);
        }

        public DataTable ADListarMotivosDevolucion()
        {
            return objEjeSp.EjecSP("CRE_ListarMotivosDevolucion_SP");
        }

        public DataTable ADObtenerMotivoDevSol(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_ObtenerMotivoDevSol_SP", idSolicitud);
        }

        public DataTable ADEstClieCreditosNoActivos(int idCli, string cDocumentoID = "")
        {
            return objEjeSp.EjecSP("CRE_EstClieCreditosNoActivos_SP", idCli, cDocumentoID);
        }
    }
}
