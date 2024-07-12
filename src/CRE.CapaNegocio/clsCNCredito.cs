using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNCredito
    {
        public clsADCredito ObjCredito = new clsADCredito();
        public DataTable CNdtDataCreditoCobro(int nNumCredito)
        {
            return ObjCredito.ADdtDataCreditoCobro(nNumCredito);
        }
        /// <summary>
        /// retorna los datos de una cuanta de credito
        /// </summary>
        /// <param name="idCuenta">id de la cuenta a consultar</param>
        /// <returns></returns>
        public clsCredito retornaDatosCredito(int idCuenta)
        {
            clsCredito credito = new clsCredito();
            DataTable dt = ObjCredito.ADdtDataCreditoCobro(idCuenta);
            if (dt.Rows.Count > 0)
            {
                credito.idCuenta = (int)dt.Rows[0]["idCuenta"];
                credito.idSolicitud = (int)dt.Rows[0]["idSolicitud"];
                credito.idCli = (int)dt.Rows[0]["idCli"];
                credito.idProducto = (int)dt.Rows[0]["idProducto"];
                credito.idEstado = (int)dt.Rows[0]["idEstado"];
                credito.idCalificacion = (int)dt.Rows[0]["idCalificacion"];
                credito.idRecurso = (int)dt.Rows[0]["idRecurso"];
                credito.IdMoneda = (int)dt.Rows[0]["IdMoneda"];
                credito.idUsuario = dt.Rows[0]["idUsuario"] != DBNull.Value ? (int)dt.Rows[0]["idUsuario"] : 0;
                credito.nCuotas = (int)dt.Rows[0]["nCuotas"];
                credito.nCapitalDesembolso = (decimal)dt.Rows[0]["nCapitalDesembolso"];
                credito.nCapitalPagado = (decimal)dt.Rows[0]["nCapitalPagado"];
                credito.nInteresPactado = (decimal)dt.Rows[0]["nInteresPactado"];
                credito.nInteresDia = (decimal)dt.Rows[0]["nInteresDia"];
                credito.nInteresPagado = (decimal)dt.Rows[0]["nInteresPagado"];
                credito.nInteresComp = Convert.ToDecimal(dt.Rows[0]["nInteresComp"]);
                credito.nInteresCompPago = Convert.ToDecimal(dt.Rows[0]["nInteresCompPago"]);
                credito.nMoraGenerado = (decimal)dt.Rows[0]["nMoraGenerado"];
                credito.nMoraPagada = (decimal)dt.Rows[0]["nMoraPagada"];
                credito.nOtrosGenerado = (decimal)dt.Rows[0]["nOtrosGenerado"];
                credito.nOtrosPagado = (decimal)dt.Rows[0]["nOtrosPagado"];
                credito.nTasaCompensatoria = (decimal)dt.Rows[0]["nTasaCompensatoria"];
                credito.nTasaCostoEfectivo = (decimal)dt.Rows[0]["nTasaCostoEfectivo"];
                credito.nTasaMoratoria = (decimal)dt.Rows[0]["nTasaMoratoria"];
                credito.nAtraso = (int)dt.Rows[0]["nAtraso"];
                credito.dFechaCancelacion = dt.Rows[0]["dFechaCancelacion"];
                credito.dFechaRegistro = (DateTime)dt.Rows[0]["dFechaRegistro"];
                credito.dFechaDesembolso = (DateTime)dt.Rows[0]["dFechaDesembolso"];
                credito.idAgencia = (int)dt.Rows[0]["idAgencia"];
                credito.idPlanPagos = (int)dt.Rows[0]["idPlanPagos"];
                credito.nNumCre = (int)dt.Rows[0]["nNumCre"];
                credito.idCalificSist = (int)dt.Rows[0]["idCalificSist"];
                credito.nSaldoCapitalNormal = (decimal)dt.Rows[0]["nSaldoCapitalNormal"];
                credito.nSaldoCapitalVenc = (decimal)dt.Rows[0]["nSaldoCapitalNormal"];
                credito.idCondContableNormal = (int)dt.Rows[0]["idCondContableNormal"];
                credito.idCondContableVenc = (int)dt.Rows[0]["idCondContableVenc"];
                credito.idAdeudado = (int)dt.Rows[0]["idAdeudado"];
                credito.dFechaCulminacion = dt.Rows[0]["dFechaCulminacion"];
                credito.nNumReprogra = (int)dt.Rows[0]["nNumReprogra"];
                credito.nMontoCuota = (decimal) dt.Rows[0]["nMontoCuota"];
                credito.lUnicuota = (bool)dt.Rows[0]["lUnicuota"];
            }

            return credito;
        }

        public clsCredito retornaDatosCreditoAmpliacion(int idCuenta)
        {
            return ObjCredito.ADDataCreditoCobroAmpliacion(idCuenta);
        }


        public decimal nSaldoCredito(DataTable dtCredito)
        {
            decimal /*era double*/nMonSalCre = 0.0m;

            if (dtCredito.Rows.Count>0)
            {
                nMonSalCre = Math.Round(
                         (Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nInteresPactado"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nInteresComp"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nMoraGenerado"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nOtrosGenerado"])
                         )
                            -
                         (
                            Convert.ToDecimal(dtCredito.Rows[0]["nCapitalPagado"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nInteresPagado"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nInteresCompPago"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nOtrosPagado"]) +
                            Convert.ToDecimal(dtCredito.Rows[0]["nMoraPagada"])
                           ), 2);
            }

            return nMonSalCre;
        }

        public DataTable LisCrexAna(Int32 nIdAsesor, int idUsu)
        {
            try
            {
                clsADCredito CNcredito = new clsADCredito();
                DataTable dtCNLisCrexAna = CNcredito.LisCrexAna(nIdAsesor, idUsu);
                return dtCNLisCrexAna;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CNdtLisSolDesemCampo(Int32 nIdAsesor, Int32 idAge)
        {
            try
            {
                clsADCredito CNcredito = new clsADCredito();
                DataTable dtCNLisDescampo = CNcredito.ADdtLisSolDesemCampo(nIdAsesor, idAge);
                return dtCNLisDescampo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetCancConDeuda(int idCuenta)
        {
            try
            {
                return new clsADCredito().GetCancConDeuda(idCuenta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CNSaldoCredito(int idCuenta)
        {
            try
            {
                return new clsADCredito().ADSaldoCredito(idCuenta);
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
                return new clsADCredito().CancConDeuda(idCuenta, idAgencia, dFechaCanc, idTipoMotCanc, idUsu,
                                                    cDescMotivo, MontoTotal, idProducto, idMotivoOperacion, idSolicitudAproba);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CNPerdonaDeuda(int idCuenta, int idAgencia, string dFechaCanc, int idTipoMotCanc, int idUsu,
                                        string cDescMotivo, decimal nCap, decimal nInt,decimal nIntComp, decimal nOtr,
                                        decimal nMora, int idMotivoOperacion, int idSolicitudAproba)
        {
            try
            {
                return new clsADCredito().ADPerdonaDeuda(idCuenta, idAgencia, dFechaCanc, idTipoMotCanc, idUsu,
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
                return new clsADCredito().LisMotCanc();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable CNdtLisCrexCli(int nNumCliente)
        {
            return ObjCredito.ADdtLisCrexCli(nNumCliente);
        }

        public DataTable CNdtLisKardexCre(int nNumCredito)
        {
            return ObjCredito.ADdtLisKardexCre(nNumCredito);
        }

        public DataTable LisCreByAna(Int32 nIdAsesor)
        {
            try
            {
                clsADCredito CNcredito = new clsADCredito();
                DataTable dtCNLisCrexAna = CNcredito.LisCreByAna(nIdAsesor);
                return dtCNLisCrexAna;
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
                clsADCredito CNcredito = new clsADCredito();
                
                DataTable dtCNLisCrexAna = CNcredito.LisCreByAnaEst(nIdAsesor, nIdEstadoContable);
                return dtCNLisCrexAna;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Filtra la lista de creditos por analista y ubigeo
        /// </summary>
        /// <param name="nIdAsesor"></param>
        /// <param name="nIdUbigeo"></param>
        /// <returns></returns>
        public DataTable LisCreByAnaUbi(Int32 nIdAsesor, int nIdUbigeo)
        {
            try
            {
                clsADCredito CNcredito = new clsADCredito();
                DataTable dtCNLisCrexAna = CNcredito.LisCreByAnaUbi(nIdAsesor, nIdUbigeo);
                return dtCNLisCrexAna;
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
                clsADCredito CNcredito = new clsADCredito();
                //DataTable dtCNLisCrexAna = CNcredito.LisCreByAnaUbi(nIdAsesor, nIdUbigeo);
                DataTable dtCNLisCrexAna = CNcredito.LisCreByAnaUbiEst(nIdAsesor, nIdUbigeo, nIdEstadoContable);
                return dtCNLisCrexAna;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Se agrego los campos cSustento y iTotalCreditosSeleccionados, donde registra el sustento de la reasignacion y el nro de creditos reasignados
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nIdAsesor"></param>
        /// <param name="idAgeDes"></param>
        /// <param name="idUsuOpera"></param>
        /// <param name="dFecOpera"></param>
        /// <param name="cSustento"></param>
        /// <param name="iTotalCreditosSeleccionados"></param>
        /// <returns></returns>
        public DataTable UpdCreByAse(string xml, Int32 nIdAsesor, int idAgeDes, int idUsuOpera, DateTime dFecOpera, string cSustento, int iTotalCreditosSeleccionados)
        {
            try
            {
                return ObjCredito.UpdCreByAse(xml, nIdAsesor, idAgeDes, idUsuOpera, dFecOpera, cSustento, iTotalCreditosSeleccionados);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Obtiene la lista de creditos reasignados
        /// </summary>
        /// <param name="nidReasignacionCartera">el codigo de reasignacion</param>
        /// <returns></returns>
        public DataTable ListCredReasignados(int nidReasignacionCartera)
        {
            return ObjCredito.ListCredReasignados(nidReasignacionCartera);
        }

        public DataTable DesbMasByAse(Int32 nIdAsesor, int idUsu)
        {
            try
            {
                return new clsADCredito().DesbMasByAse(nIdAsesor, idUsu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CNdtSumMorCli(int idCli)
        {
            try
            {
                return new clsADCredito().ADdtSumSalMorCli(idCli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public DataTable InsSolicitudCapturaCredito(string XmlSoli, int idUsuarioSistema, DateTime dFecSystem, int idCliente)
        {
            return ObjCredito.InsSolicitudCapturaCredito(XmlSoli, idUsuarioSistema, dFecSystem, idCliente);
        }


        public DataTable BuscarCreditosCliente(int idDocCli)
        {
            return ObjCredito.BuscarCreditosCliente(idDocCli);
        }

        public DataTable BuscarCreditosAceptadosParaCaptura(int idDocCli)
        {
            return ObjCredito.BuscarCreditosAceptadosParaCaptura(idDocCli);
        }

        public DataTable ConsultarEstadoSolicitudApruebaCaptura(int idSolCapturaCre)
        {
            return ObjCredito.ConsultarEstadoSolicitudApruebaCaptura(idSolCapturaCre);
        }

        public DataTable ListarSolicitudesDeCapturaAprobadas()
        {
            return ObjCredito.ListarSolicitudesDeCapturaAprobadas();
        }

        public DataTable InsCapturaAJudiciales(int nIdcuenta, int nIdplanpagos, decimal nNuevaTasaInteres, decimal nNuevaTasaMoratoria, DateTime dFechaDelSistema, int nUsuarioDelSistema, int nIdAgencia, int nIdSolAproba)
        {
            return ObjCredito.InsCapturaAJudiciales(nIdcuenta, nIdplanpagos, nNuevaTasaInteres, nNuevaTasaMoratoria, dFechaDelSistema, nUsuarioDelSistema, nIdAgencia, nIdSolAproba);
        }
        public DataTable InsCancelacionAnticipada(string xmlPagador, DateTime dFechaDelSistema, int nUsuarioDelSistema, int nAgencia,
                                                    int nNumCredito, Decimal /*era double*/nImpuestos, Decimal /*era double*/nRedondeo, Decimal /*era double*/nTotalAPagar, int idCanal,
                                                    int idTipoPago, int idEntidad, int idCtaEntidad, string cNroTrx, int idMotivoOperacion, string cCobs,
                                                    bool lModificaSaldoLinea, int idMoneda, int idTipoTransac)
        {
            return ObjCredito.InsCancelacionAnticipada(xmlPagador, dFechaDelSistema, nUsuarioDelSistema, nAgencia, nNumCredito,
                                                        nImpuestos, nRedondeo, nTotalAPagar, idCanal, idTipoPago,
                                                        idEntidad, idCtaEntidad, cNroTrx, idMotivoOperacion, cCobs,
                                                        lModificaSaldoLinea, idMoneda, idTipoTransac);

        }
        public DataTable ListaDocsSustentatoriosCapturaCredito()
        {
            return ObjCredito.ListaDocsSustentatoriosCapturaCredito();
        }

        //Listar Créditos aprobados para Captura -- MODULO CARTAS
        public DataTable ListarCreditosAprobadasParaCaptura(int nIdCliente)
        {
            return ObjCredito.ListaDocsSustentatoriosCapturaCredito(nIdCliente);
        }
        public DataTable InsRefinanciacion(int idSolicitud, DateTime dFecdesemb, decimal nTcea, decimal nTEA, int nSumaDias, DateTime dFechaUltimoPagoCredito, DateTime dFechaSistema, int idUsuario, int nIdAgencia)
        {

            return ObjCredito.InsRefinanciacion(idSolicitud, dFecdesemb, nTcea, nTEA, nSumaDias, dFechaUltimoPagoCredito, dFechaSistema, idUsuario, nIdAgencia);
        }

        public DataTable CNListarCreditosDctoPlanilla(DateTime dFechaProceso, bool lEstEmpleado)
        {
            return ObjCredito.ADListarCreditosDctoPlanilla(dFechaProceso, lEstEmpleado);
        }

        public DataTable CNListarPagoDctoPlanilla(DateTime dFechaSistema, string xmlDsctoPlanilla, int idUsuario, int idConvenio)
        {
            return ObjCredito.ADListarPagoDctoPlanilla(dFechaSistema, xmlDsctoPlanilla, idUsuario, idConvenio);
        }

        public DataTable CNdtLisCrexCliVig(int nNumCliente)
        {
            return ObjCredito.ADdtLisCrexCliVig(nNumCliente);
        }
        public DataTable CNValidaClienteEsNuevo(int idCli)
        {
            return ObjCredito.ADValidaClienteEsNuevo(idCli);
        }
        #region Mantenimiento de Docuentos de desembolso

        public DataTable ListarDocumentoDesembolso()
        {
            return ObjCredito.ListarDocumentoDesembolso();
        }

        public DataTable InsertarDocumentoDesembolso(string cDocumentoDes, bool lVigente)
        {
            return ObjCredito.InsertarDocumentoDesembolso(cDocumentoDes, lVigente);
        }

        public DataTable ActualizarDocumentoDesembolso(string cDocumentoDes, bool lVigente, int idDocumentoDes)
        {
            return ObjCredito.ActualizarDocumentoDesembolso(cDocumentoDes, lVigente, idDocumentoDes);
        }

        public DataTable EliminarDocumentoDesembolso(int idDocumentoDes)
        {
            return ObjCredito.EliminarDocumentoDesembolso(idDocumentoDes);
        }
        #endregion

        #region Impresion documentos desembolso

        public DataTable DatosImpContratoJur(int idSolicitud)
        {
            return ObjCredito.DatosImpContratoJur(idSolicitud);
        }

        public DataTable DatosImpContratoNat(int idSolicitud)
        {
            return ObjCredito.DatosImpContratoNat(idSolicitud);
        }

        public DataTable DatosImpPagare(int idSolicitud)
        {
            return ObjCredito.DatosImpPagare(idSolicitud);
        }

        public DataTable DetalleImpPagare(int idSolicitud)
        {
            return ObjCredito.DetalleImpPagare(idSolicitud);
        }

        public DataTable DatosSolicitudImpPPG(int idSolicitud)
        {
            return ObjCredito.DatosSolicitudImpPPG(idSolicitud);
        }

        public DataTable ListaRepresentanteJur(int idCli)
        {
            return ObjCredito.ListaRepresentanteJur(idCli);
        }
        #endregion

        public DataTable CNEnviarEmailAsesor(int idAsesor, int idCuenta,decimal nMontoCanc)
        {
            return ObjCredito.ADEnviarEmailAsesor(idAsesor, idCuenta, nMontoCanc);
        }

        #region CategoriaAsesorRangosSaldoCarteraTopesTransferencias
        public DataTable CNRetornaCategoriaAsesorPoIdCatPersonal(int idCategoriaPersonal)
        {
            return ObjCredito.ADRetornaCategoriaAsesorPoIdCatPersonal(idCategoriaPersonal);
        }
        #endregion

        public DataTable obtenerCreditoParaCongelarTasa(int idCuenta)
        {
            return ObjCredito.obtenerCreditoParaCongelarTasa(idCuenta);
        }

        public DataTable congelarTasaInteres(int idCuenta, int idSolAproba, decimal nTEA, decimal nTasaCompensatoria, decimal nTasaMoratoria, decimal nTCEA, DateTime dFechaSistema, int idUsuReg)
        {
            return ObjCredito.congelarTasaInteres(idCuenta,idSolAproba, nTEA, nTasaCompensatoria, nTasaMoratoria, nTCEA, dFechaSistema, idUsuReg);
        }

        public DataTable listarCreditosCongelados(DateTime dInicio, DateTime dFin, bool lConPagos)
        {
            return ObjCredito.listarCreditosCongelados(dInicio, dFin, lConPagos);
        }

        public DataTable consolidarPlanPagos(int idCuenta, int idPlanPagos, DateTime dFechaSistema, int idUsuario, bool lInteresFecha)
        {
            return ObjCredito.consolidarPlanPagos(idCuenta, idPlanPagos, dFechaSistema, idUsuario, lInteresFecha);
        }

        public DataTable CNBuscarComisionBN(int idTipoComision, int idTipoOperacion, int idMoneda)
        {
            return ObjCredito.ADBuscarComisionBN(idTipoComision, idTipoOperacion, idMoneda);
        }

        public DataTable CNGuardarComisionBN(int idTipoComision, int idTipoOperacion, int idMoneda, string cComisionBN, double nComisionMin, double nPorcomision, bool lVigente)
        {
            return ObjCredito.ADGuardarComisionBN(idTipoComision, idTipoOperacion, idMoneda, cComisionBN, nComisionMin, nPorcomision, lVigente);
        }
        public DataTable obtenerCreditoCambioOrdenPrelacion(int idCuenta)
        {
            return ObjCredito.obtenerCreditoCambioOrdenPrelacion(idCuenta);
        }

        public DataTable ObtenerOrdenPrelacion(int idCuenta, int idOrdenPrelacion)
        {
            return ObjCredito.ObtenerOrdenPrelacion(idCuenta, idOrdenPrelacion);
        }

        public DataTable grabarNuevoOrdenPrelacion(int idCuenta, int idOrdenPrelacion, string xmlOrdenPrelacion, int idUsuReg)
        {
            return ObjCredito.grabarNuevoOrdenPrelacion(idCuenta, idOrdenPrelacion, xmlOrdenPrelacion, idUsuReg);
        }

        public DataTable ValidaPrimerPagoJudicial(int idCuenta)
        {
            return ObjCredito.ValidaPrimerPagoJudicial(idCuenta);
        }

        public DataTable obtenerListaMora()
        {
            return ObjCredito.obtenerListaMora();
        }

        public DataTable obtenerListaMoraN(string cUsuarios, int nDesde, int nHasta)
        {
            return ObjCredito.obtenerListaMoraN(cUsuarios, nDesde, nHasta);
        }

        public DataTable obtenerListaMoraHistorico(DateTime dFecha)
        {
            return ObjCredito.obtenerListaMoraHistorico(dFecha);
        }

        public DataTable obtenerListaCastigos()
        {
            return ObjCredito.obtenerListaCastigos();
        }

        public DataTable DeterminarCanalAprobacion(int idEstablecimiento, int idTipoEstablec, int idSolicitud, int idCli, decimal nMonto, int idProducto, int idOperacion)
        {
            return ObjCredito.DeterminarCanalAprobacion(idEstablecimiento, idTipoEstablec, idSolicitud, idCli, nMonto, idProducto, idOperacion);
        }

        public DataTable obtenerPreventivoMora(int idAgencia)
        {
            return ObjCredito.obtenerPreventivoMora(idAgencia);
        }

        public DataTable CNObtieneDetalleCondonacion(int idSolicitudAproba)
        {
            return ObjCredito.ADObtieneDetalleCondonacion(idSolicitudAproba);
        }

        public DataTable CNlistarSolicitudesCondonacion(int idAgencia)
        {
            return ObjCredito.ListarSolicitudesCondonacion(idAgencia);
        }

        public DataTable CNCobrosCreditos(int idAgencia)
        {
            return ObjCredito.ListarCobrosCreditos(idAgencia);
        }
        public DataTable CNBuscarDatosDocumentacion(int idSolicitud)
        {
            return ObjCredito.BuscarDatosDocumentacion(idSolicitud);
        }
        public DataTable CNDatosGrupoSol(int idCuenta)
        {
            return ObjCredito.ADDatosGrupoSol(idCuenta);
        }

        public DataTable CNAlertaCreditosVinculados(int idCli)
        {
            return ObjCredito.ADAlertaCreditosVinculados(idCli);
        }

        public DataTable CNAlertaCreditos50000(int idSolicitud)
        {
            return ObjCredito.ADAlertaCreditos50000(idSolicitud);
        }

        public DataTable ADBuscarSolicitudAmpliacion(int idCuenta)
        {
            return ObjCredito.ADBuscarSolicitudAmpliacion(idCuenta);
        }

        #region Mantenimiento de Configuración Tasas Negociadas 
        public DataTable CNListarTipoTasaNegociable()
        {
            return ObjCredito.ADListarTipoTasaNegociable();
        }

        public List<clsTasaNegociadaPerfil> CNObtenerTasaNegociadaPerfil()
        {
            List<clsTasaNegociadaPerfil> lstTasaNegociada = new List<clsTasaNegociadaPerfil>();
            DataTable dtResultado = ObjCredito.ADObtenerTasaNegociadaPerfil();
            lstTasaNegociada = dtResultado.ToList<clsTasaNegociadaPerfil>() as List<clsTasaNegociadaPerfil>;

            return lstTasaNegociada;
        }

        public List<clsParametroAprobTasaNegociable> CNObtenerParametroTasaNegociable()
        {
            List<clsParametroAprobTasaNegociable> lstParametroTasaNegociada = new List<clsParametroAprobTasaNegociable>();
            DataTable dtResultado = ObjCredito.ADObtenerParametroTasaNegociable();
            lstParametroTasaNegociada = dtResultado.ToList<clsParametroAprobTasaNegociable>() as List<clsParametroAprobTasaNegociable>;

            return lstParametroTasaNegociada;
        }

        public DataTable CNRegistrarTasaNegociadaPerfil(string xmlTasaNegociadaPerfil, DateTime dFechaSistema, int idUsuario)
        {
            return ObjCredito.ADRegistrarTasaNegociadaPerfil(xmlTasaNegociadaPerfil, dFechaSistema, idUsuario);
        }

        public DataTable CNRegistrarParametroAprobTasaNegociable(string xmlParametroTasaNegociada, DateTime dFechaSistema, int idUsuario)
        {
            return ObjCredito.ADRegistrarParametroAprobTasaNegociable(xmlParametroTasaNegociada, dFechaSistema, idUsuario);
        }
        
        #endregion

        #region Bloque de Pagos Masivos
        public DataTable CNValidacionCuentasPagoMasivo(string xmlCreditos, int idMoneda)
        {
            return ObjCredito.ADValidacionCuentasPagoMasivo(xmlCreditos, idMoneda);
        }

        public DataSet CNProcesarPagoMasivo(string xmlCreditos, int idTipoPagoMasivo, int idUsuarioOrden, int idAgencia, int idUsuarioReg, DateTime dFechaSistema, byte[] bExcel, int idEntidad, int idCuenta, string cNroOperacion)
        {
            return ObjCredito.ADProcesarPagoMasivo(xmlCreditos, idTipoPagoMasivo, idUsuarioOrden, idAgencia, idUsuarioReg, dFechaSistema, bExcel, idEntidad, idCuenta, cNroOperacion);
        }

        public DataTable CNReportePagoMasivo(int idPagoMasivo)
        {
            return ObjCredito.ADReportePagoMasivo(idPagoMasivo);
        }

        public DataTable CNListaPagoMasivo(DateTime dFechaIni, DateTime dFechaFin)
        {
            return ObjCredito.ADListaPagoMasivo(dFechaIni, dFechaFin);
        }

        #endregion

        public DataTable CNValidaImpresionPendienteCalendario(int idCuenta)
        {
            return ObjCredito.ADValidaImpresionPendienteCalendario(idCuenta);
        }        
		public DataTable CNBuscarEstablecimiento(int idUsuario, int idPerfil)
        {
            return ObjCredito.ADBuscarEstablecimiento( idUsuario,  idPerfil);
        }
        public DataTable CNDevolverSolicitud(int idSolicitud, int idMotivoDev, string cComentarioDev, int idUsuReg, DateTime dFechaReg)
        {
            return ObjCredito.ADDevolverSolicitud(idSolicitud, idMotivoDev, cComentarioDev, idUsuReg, dFechaReg);
        }

        public DataTable CNListarMotivosDevolucion()
        {
            return ObjCredito.ADListarMotivosDevolucion();
        }
        public DataTable CNObtenerMotivoDevSol(int idSolicitud)
        {
            return ObjCredito.ADObtenerMotivoDevSol(idSolicitud);
        }

        public DataTable CNEstClieCreditosNoActivos(int idCli, string cDocumentoID = "")
        {
            return ObjCredito.ADEstClieCreditosNoActivos(idCli, cDocumentoID);
        }        
    }
}
