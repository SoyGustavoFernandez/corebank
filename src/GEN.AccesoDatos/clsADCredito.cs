using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADCredito
    {
        IntConexion objEjeSp;

        public clsADCredito()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADCredito(bool lWS)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable Desembolso(String tCredito, Int32 idUs, DateTime dFec, Int32 nIdAgencia, Decimal nITF, Int32 idCanal, decimal nITFNormal, int idTipoDesembolso, int idPlantillaOrdenPrelacion, string xmlParametrosDesembolso,
                                     int idMoneda, int idTipoTransac, decimal nMontoOpe, bool lModificaSaldoLinea)
        {
            return objEjeSp.EjecSP("CRE_Desembolso_sp", tCredito, idUs, dFec, nIdAgencia, nITF, idCanal, nITFNormal, idTipoDesembolso, idPlantillaOrdenPrelacion, xmlParametrosDesembolso,
                                                         idMoneda, idTipoTransac, nMontoOpe, lModificaSaldoLinea);
        }
        public DataTable NumeroCreditos(Int32 idcli)
        {
            return objEjeSp.EjecSP("CRE_NumeroCreditosxCliente_sp", idcli);
        }

        public DataTable BusDesembolso(int nIdKardex)
        {
            return objEjeSp.EjecSP("CRE_GetCobro_sp", nIdKardex);
        }
        public DataTable ADBuscaAdeudadoCre(int idProducto, int idDestinoCre, decimal nMonto, int idMoneda, int nIdAgencia)
        {
            return objEjeSp.EjecSP("CRE_BuscaAdeudado_sp", idProducto, idDestinoCre, nMonto, idMoneda, nIdAgencia);
        }
        public DataTable ADRetornaAdeudado(int idAdeudado)
        {
            return objEjeSp.EjecSP("CRE_RetornaAdeudado_sp", idAdeudado);
        }
        public DataTable ADRetornaSaldoxAseFam(int nIdAsesor, decimal nMontoSol, int idMoneda, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_RetSaldoAsesoryFamilia_sp", nIdAsesor, nMontoSol, idMoneda, idAgencia);
        }
        public DataTable ADRetornaSaldoTotalAseFam(int idAgencia, decimal nMontoSol, int idMoneda)
        {
            return objEjeSp.EjecSP("CRE_RetSaldoTotalAsesoryFamilia_sp", idAgencia, nMontoSol, idMoneda);
        }
        public DataTable ADDesembolsoCreXAmpliacion(string tCredito, int idUs, DateTime dFec, int nIdAgencia, int idSolicitud, Decimal nITF, Int32 idCanal, decimal nITFNormal, int idTipoDesembolso, string xmlParametrosDesembolso,
                                    int idMoneda, int idTipoTransac, decimal nMontoOpe, bool lModificaSaldoLinea)
        {
            return objEjeSp.EjecSP("CRE_DesembolsoCreXAmpliacion_sp", tCredito, idUs, dFec, nIdAgencia, idSolicitud, nITF, idCanal, nITFNormal, idTipoDesembolso, xmlParametrosDesembolso,
                                                        idMoneda, idTipoTransac, nMontoOpe, lModificaSaldoLinea);
        }
        public DataTable ADUpdKardexRelacionalDesem(Int32 idKardexCre, Int32 idKardexAho)
        {
            return objEjeSp.EjecSP("CRE_UpdKardexRelDesemb_sp", idKardexCre, idKardexAho);
        }
        public DataTable ADValidaMontoAdeudado(Int32 idSolicitud, Int32 idAgencia)
        {
            return objEjeSp.EjecSP("CRE_VerifAdeudadoDesembolso_sp", idSolicitud, idAgencia);
        }
        public DataTable ADValidaAprobExt(Int32 idCuenta )
        {
            return objEjeSp.EjecSP("CRE_ValidaAprobExtDesemb_sp", idCuenta);
        }
        public DataTable ADValidaAplicaSegDes(int idCli, DateTime dFechaSis)
        {
            return objEjeSp.EjecSP("CRE_DepValidaAplicaSegDes_sp", idCli, dFechaSis);
        }
        public DataTable ADCreditosCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_CreditosIdCliente_SP", idCli);
        }
        public DataTable ADAhorrosCliente(int idCli)
        {
            return objEjeSp.EjecSP("DEP_AhorrosCliente_SP", idCli);
        }
        public DataTable ADMontoBloqCompraDeuda(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RetornaBloqueoCompraDeuda_Sp", idSolicitud);
        }

        public DataTable ADListarGarantiasxCredito(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListarGarantiasxCredito_SP", idCuenta);
        
        }

        public DataTable ADActualizaSaldoGarantiaCli(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ActualizaSaldoGarantiaCli_SP", idCuenta);
        }

        public DataTable ADValidarEstadoCuentaAhoGarantia(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ValidarEstadoCuentaAhoGarantia_SP", idCuenta);
        }

        public DataTable WCFScoringPrimerFiltro(string cNroDocumento)
        {
            return new clsWCFEjeSP().EjecSP("RCP_WCFScoringPrimerFiltro_SP", cNroDocumento);
        }

        public DataTable WCFScoringPrimerFiltro(EntityLayer.clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro)
        {
            return new clsWCFEjeSP().EjecSP("RCP_WCFScoringSegundoFiltro_SP", objWCFEnvSegundoFiltro.cNroDocumento, objWCFEnvSegundoFiltro.lClienteRecurrente, objWCFEnvSegundoFiltro.nExperienciaNegocio, objWCFEnvSegundoFiltro.cUbigeoNacimiento
                                                                           , objWCFEnvSegundoFiltro.lFormalizado, objWCFEnvSegundoFiltro.nEdad, objWCFEnvSegundoFiltro.idEstadoCivil, objWCFEnvSegundoFiltro.idDestino
                                                                           , objWCFEnvSegundoFiltro.nMontoSolicitado, objWCFEnvSegundoFiltro.nPlazo, objWCFEnvSegundoFiltro.nExcedente, objWCFEnvSegundoFiltro.nDeudaFinanciera);
        }

        public DataTable ADRecuperarDatosReprogramacion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_RecuperarDatosReprogramacion_SP", idCuenta);
        }

        public DataTable ADRecuperarSolicitudReprogramacionEspecial(int idSolicitud)
        {
            return objEjeSp.EjecSP("CRE_RecuperaSolicitudReprogramacionEspecial_SP", idSolicitud);
        }
        public DataTable ADValidaReglasSolicitudRepro(int idCuenta, int idPerfil, decimal nTasaNueva)
        {
            return objEjeSp.EjecSP("CRE_ValidaReglasSolicitudReproEspecial_SP", idCuenta, idPerfil, nTasaNueva);
        }
        public DataTable ADObtenerTasaMinMaxSolicitudPost()
        {
            return objEjeSp.EjecSP("ADM_ObtenerMinMaxTasaNegociable_SP");
        }
        public DataTable ADObtenerImporteMinSolicitudPost()
        {
            return objEjeSp.EjecSP("ADM_ObtenerImporteMinTasaNegociable_SP");
        }

        public DataTable ADObtieneMinMaxTasaNueva(int idCuenta, decimal nTasaInicial)
        {
            return objEjeSp.EjecSP("CRE_ObtieneMinMaxTasaNuevaRepro_SP", idCuenta, nTasaInicial);
        }
        public DataTable ADObtieneSaldoCapitalCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("ADM_ObtenerSaldoCapitalxIdcuenta_SP", idCuenta);
        }
        public DataTable ADRecuperarGrupoDatosReprogramacion(string xmlCuenta)
        {
            return objEjeSp.EjecSP("CRE_RecuperarGrupoDatosReprogramacion_SP", xmlCuenta);
        }

        public DataTable ADObtenerCreditoReprogramable(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCreditoReprogramable_SP", idCuenta);
        }
        public DataTable ADObtenerCreditoRetencion(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ObtenerCreditoRetencion_SP", idCuenta);
        }

        public DataTable ADGrabarSolicitudReprogramacion(int idCuenta, int diasgracia, int nCuotas, int nDiasPerdon,
            int idTipoPlanPago, DateTime dFechaPrimeraCuota, decimal nTasaNueva, int idGrupoReprog, int nPlazoCuota)
        {
            return objEjeSp.EjecSP("CRE_GrabarSolicitudReprogramacion_SP", idCuenta, diasgracia, nCuotas, nDiasPerdon, idTipoPlanPago,
                dFechaPrimeraCuota, nTasaNueva, idGrupoReprog, nPlazoCuota);
        }
        public DataTable ADGrabarSolicitudRetencionCambioTasa(int idCuenta, int diasgracia, int nCuotas, int nDiasPerdon,
            int idTipoPlanPago, DateTime dFechaPrimeraCuota, decimal nTasaNueva, int idGrupoReprog, int nPlazoCuota)
        {
            return objEjeSp.EjecSP("CRE_GrabarSolicitudRetencionCambioTasa_SP", idCuenta, diasgracia, nCuotas, nDiasPerdon, idTipoPlanPago,
                dFechaPrimeraCuota, nTasaNueva, idGrupoReprog, nPlazoCuota);
        }
        public DataTable ADGrabarPARAMSSolicitudRetencionCambioTasa(int idCuenta, int diasgracia, int nCuotas, int nDiasPerdon,
        int idTipoPlanPago, DateTime dFechaPrimeraCuota, decimal nTasaNueva)
        {
            return objEjeSp.EjecSP("CRE_GrabarParamsSolicitudRetencionCambioTasa_SP", idCuenta, diasgracia, nCuotas, nDiasPerdon, idTipoPlanPago,
                dFechaPrimeraCuota, nTasaNueva);
        }
        public DataTable ADListaPARAMSSolicitudRetencionCambioTasa(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListarParamsSolicitudRetencionCambioTasa_SP", idCuenta);
        }
        public DataTable ADListaTipoPlanPago()
        {
            return objEjeSp.EjecSP("CRE_ListaTipoPlanPago_sp");
        }

        public DataTable ADListaTipoPlanPago(int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListaTipoPlanPagoPerfil_sp", idPerfil);
        }

        public DataTable ADBuscarSolicitudCreditos(int idCli)
        {
            return objEjeSp.EjecSP("CRE_BuscarSolicitudCreditos_sp", idCli);
        }

        public DataTable ADListarCampania(int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListarCampaniaEAI_SP", idUsuario, idPerfil);
        }

        public DataTable ADReasignarCliente(String cDocumentoID, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ReasignarClienteEAI_SP", cDocumentoID, idUsuario);
        }
        public DataTable ADListarRegion(int idUsuario, int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ListarZonaEAI_SP", idUsuario, idPerfil);
        }
        public DataTable ADListarAgencia(int idUsuario, int idPerfil, int idZona)
        {
            return objEjeSp.EjecSP("CRE_ListarAgenciaEAI_SP", idUsuario, idPerfil, idZona);
        }
        public DataTable ADListarEstablecimiento(int idUsuario, int idPerfil, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarEstablecimientoEAI_SP", idUsuario, idPerfil, idAgencia);
        }
        
        public DataTable ADBuscarAsesor(int idUsuario, int idPerfil, int idEstablecimiento)
        {
            return objEjeSp.EjecSP("CRE_BuscarAsesor_SP", idUsuario, idPerfil, idEstablecimiento);
        }
        public DataTable ADBuscarofertasCre(int idGrupoCamp, int idRegion, int idOficina, int idEstablecimiento, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_BuscarOfertasCre_SP", idGrupoCamp, idRegion, idOficina, idEstablecimiento, idUsuario);
        }
        public DataTable ADNroCredEAI(DateTime dFechaActual, int idcli)
        {
            return objEjeSp.EjecSP("CRE_RetornarNroCredEAI_SP", dFechaActual, idcli);
        }
        public DataTable ADRecuperaGestionCli(String cDocumentoID, int idOferta)
        {
            return objEjeSp.EjecSP("CRE_RecuperaGestionCliente_SP", cDocumentoID, idOferta);
        }
        public DataTable ADCargarSolicitudCamp(int idCli, int idOferta)
        {
            return objEjeSp.EjecSP("CRE_CargarSolicitudCamp_SP", idCli, idOferta);
        }
        public DataTable ADListarDestinoEAI(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ListarDestinoEAI_SP", idProducto);
        }
        public DataTable ADRecuperaSolicitudEAI(int idCli, int idOferta)
        {
            return objEjeSp.EjecSP("CRE_RecuperaSolicitudEAI_SP", idCli, idOferta);
        }
        public DataTable ADValidarCalificativoEAI(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidarCalificativoEAI_SP", idCli);
        }
        public DataTable ADValidarMoraEAI(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidarMoraEAI_SP", idCli);
        }
        public DataTable ADValidarBaseNegativa(String cDocumentoID)
        {
            return objEjeSp.EjecSP("CLI_ValidarCliBaseNegativa_Sp", cDocumentoID, 1);
        }
        public DataTable ADValidarNroEntidades(int idCli)
        {
            return objEjeSp.EjecSP("CRE_NroEntidadesEAI_SP", idCli);
        }
        public DataTable ADValidarNroCredAct(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ValidarNroCredActEAI_SP", idCli);
        }
        public DataTable ADValidarEndeudamiento(int idCli, decimal nMonto)
        {
            return objEjeSp.EjecSP("CRE_ValidarEndeudamiento_SP", idCli, nMonto);
        }
        public DataTable ADValidarSolicitudAct(int idCli, int nCodigoSol, int idSubProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidarSolicitudActEAI_SP", idCli, nCodigoSol, idSubProducto);
        }
        public DataTable ADValidarBloqueoEAI(int idCli, int idSubProducto)
        {
            return objEjeSp.EjecSP("CRE_ValidarBloqueoEAI_SP", idCli, idSubProducto);
        }
        public DataTable ADValidarDiaPagoEAI(DateTime dFechaPriCuota)
        {
            return objEjeSp.EjecSP("CRE_ValidarDiaPagoEAI_SP", dFechaPriCuota);
        }        
        public DataTable ADRegistrarOfertaEAI(int idSolicitud, decimal nMonto)
        {
            return objEjeSp.EjecSP("CRE_RegistrarOfertaEAI_SP", idSolicitud, nMonto);
        }
        public DataTable ADCargarCliBloqEAI(int idCli)
        {
            return objEjeSp.EjecSP("CRE_CargarCliBloqEAI_SP", idCli);
        }
        public DataTable ADListarMotivoBloqEAI()
        {
            return objEjeSp.EjecSP("CRE_ListarMotivoBloqEAI_SP");
        }
        public DataTable ADBloqCliEAI(int idCli, int idMotBloqEAI, string cSustentoBloq, int idUsuBloq, int idPerfilUsuBloq)
        {
            return objEjeSp.EjecSP("CRE_BloqCliEAI_SP", idCli, idMotBloqEAI, cSustentoBloq, idUsuBloq, idPerfilUsuBloq);
        }
        public DataTable ADDesbloqCliEAI(int idCli, int idUsuDesbloq, int idPerfilUsuDesbloq, string cSustentoDesbloq, int idCliBloqEAI)
        {
            return objEjeSp.EjecSP("CRE_DesbloqCliEAI_SP", idCli, idUsuDesbloq, idPerfilUsuDesbloq, cSustentoDesbloq, idCliBloqEAI);
        }
        
        public DataTable ADAprobarSolicitudEAI(
            int idCli                       , int idProducto                    , int idOperacion                   , 
            int idUsuario                   , int nCuotas                       , int nPlazoCuota                   , decimal nCapitalSolicitado    , decimal nTasa        , 
            decimal nTasaMoratoria          ,                             DateTime dFechaDesembolsoSugerido         , String tObservacion       , int idDestino ,
            int idAgencia                   , int idTasa                        , int idModalidadDes                , int ndiasgracia           , int idActividad  ,
            decimal nTasaCostoEfectivo      , int @idTipoPeriodo                , int idRecurso                     , decimal nMontoAmpliado   ,
            decimal nSaldoCreditos         ,  decimal nTasaEfectivaAnual        , int nTotalDiasCredito             , int idModalidadCredito    ,
                                             String cComentAproba              , int idActividadInterna            ,
            
            int idUsuRegistro ,             
            int idEstablecimiento,
            DateTime dFechaPrimeraCuota,
            int idOferta,
            int idDetalleGasto)
        {
            return objEjeSp.EjecSP("CRE_GrabarSolicitudEAI_SP", 
                 idCli                       ,  idProducto                    ,  idOperacion                   , 
                 idUsuario                   ,  nCuotas                       ,  nPlazoCuota                   ,  nCapitalSolicitado    ,  nTasa        , 
                 nTasaMoratoria              ,                              dFechaDesembolsoSugerido           ,  tObservacion          ,  idDestino ,
                 idAgencia                   ,  idTasa                        ,  idModalidadDes                ,  ndiasgracia           ,  idActividad  ,
                 nTasaCostoEfectivo          ,  @idTipoPeriodo                ,  idRecurso                     ,  nMontoAmpliado   ,
                 nSaldoCreditos              ,   nTasaEfectivaAnual           ,  nTotalDiasCredito             ,  idModalidadCredito    ,
                                               cComentAproba                 ,  idActividadInterna            ,
            
                 idUsuRegistro ,             
                 idEstablecimiento,
                 dFechaPrimeraCuota,
                 idOferta,
                 idDetalleGasto);
        }
                       
                        
    }
}
