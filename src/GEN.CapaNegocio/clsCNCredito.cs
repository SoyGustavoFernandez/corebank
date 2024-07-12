using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNCredito
    {
        public clsADCredito Credito;
        public clsCNCredito()
        { 
            Credito = new clsADCredito();
        }

        public clsCNCredito(bool lWS)
        {
            Credito = new clsADCredito(lWS);
        }


        public DataTable Desembolsa(String tCredito, Int32 idus, DateTime dfec, Int32 nIdAgencia, Decimal /*era double*/nITF, Int32 idCanal, decimal nITFNormal, int idTipoDesembolso, int idPlantillaOrdenPrelacion, string xmlParametrosDesembolso,
                                     int idMoneda, int idTipoTransac, decimal nMontoOpe, bool lModificaSaldoLinea)
        {
            return Credito.Desembolso(tCredito, idus, dfec, nIdAgencia, nITF, idCanal, nITFNormal, idTipoDesembolso, idPlantillaOrdenPrelacion, xmlParametrosDesembolso,
                                                         idMoneda, idTipoTransac, nMontoOpe, lModificaSaldoLinea);
        }
        public DataTable NumeroCreditos(Int32 idCli)
        {
            return Credito.NumeroCreditos(idCli);
        }
        public DataTable BusDesembolso(int nIdKardex)
        {
            return Credito.BusDesembolso(nIdKardex);
        }
        public DataTable CNBuscaAdeudado(int idProducto, int idDestinoCre, decimal nMonto, int idMoneda, int nIdAgencia) 
        {
            return Credito.ADBuscaAdeudadoCre(idProducto, idDestinoCre, nMonto, idMoneda, nIdAgencia);
        }
        public DataTable CNRetornaAdeudado(int idAdeudado)
        {
            return Credito.ADRetornaAdeudado(idAdeudado);
        }
        public DataTable CNRetornSaldoxAseFam(int nIdAsesor, decimal nMontoSol, int idMoneda, int idAgencia)
        {
            return Credito.ADRetornaSaldoxAseFam(nIdAsesor, nMontoSol, idMoneda, idAgencia);
        }
        public DataTable CNRetornSaldoTotalAseFam(int idAgencia, decimal nMontoSol, int idMoneda)
        {
            return Credito.ADRetornaSaldoTotalAseFam(idAgencia, nMontoSol, idMoneda);
        }
        public DataTable CNDesembolsoCreXAmpliacion(string tCredito, int idus, DateTime dfec, int nIdAgencia, int idSolicitud, Decimal nITF, Int32 idCanal, decimal nITFNormal, int idTipoDesembolso, string xmlParametrosDesembolso,
                                    int idMoneda, int idTipoTransac, decimal nMontoOpe, bool lModificaSaldoLinea)
        {
            return Credito.ADDesembolsoCreXAmpliacion(tCredito, idus, dfec, nIdAgencia, idSolicitud, nITF, idCanal, nITFNormal, idTipoDesembolso, xmlParametrosDesembolso,
                                                        idMoneda, idTipoTransac, nMontoOpe, lModificaSaldoLinea);
        }
        public DataTable CNUpdKardexRelDesem(Int32 idKardexCre, Int32 idKardexAho)
        {
            return Credito.ADUpdKardexRelacionalDesem(idKardexCre, idKardexAho);
        }
        public DataTable CNValidaMontoAdeudado(Int32 idSolicitud, Int32 idAgencia)
        {
            return Credito.ADValidaMontoAdeudado(idSolicitud, idAgencia);
        }
        public DataTable CNValidaAprobExtorno(Int32 idCuenta)
        {
            return Credito.ADValidaAprobExt(idCuenta);
        }
        public DataTable CNValidaAplicaSegDes(int idCli, DateTime dFecSis)
        {
            return Credito.ADValidaAplicaSegDes(idCli, dFecSis);
        }
        public DataTable CNCreditosCliente(int idCli)
        {
            return Credito.ADCreditosCliente(idCli);
        }
        public DataTable CNAhorrosCliente(int idCli)
        {
            return Credito.ADAhorrosCliente(idCli);
        }
        public DataTable CNMontoBloqCompraDeuda(int idSolicitud)
        {
            return Credito.ADMontoBloqCompraDeuda(idSolicitud);
        }

        public DataTable CNListarGarantiasxCredito(int idCuenta)
        {
            return Credito.ADListarGarantiasxCredito(idCuenta);
        }

        public DataTable CNActualizaSaldoGarantiaCli(int idCuenta)
        {
            return Credito.ADActualizaSaldoGarantiaCli(idCuenta);
        }

        public DataTable CNValidarEstadoCuentaAhoGarantia(int idCuenta)
        {
            return Credito.ADValidarEstadoCuentaAhoGarantia(idCuenta);
        }

        public DataTable WCFScoringPrimerFiltro(string cNroDocumento)
        {
            return Credito.WCFScoringPrimerFiltro(cNroDocumento);
        }

        public DataTable WCFScoringSegundoFiltro(EntityLayer.clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro)
        {
            return Credito.WCFScoringPrimerFiltro(objWCFEnvSegundoFiltro);
        }

        public DataTable CNRecuperarDatosReprogramacion(int idCuenta)
        {
            return Credito.ADRecuperarDatosReprogramacion(idCuenta);
        }

        public DataTable CNRecuperarSolicitudReprogramacionEspecial(int idSolicitud)
        {
            return Credito.ADRecuperarSolicitudReprogramacionEspecial(idSolicitud);
        }
        public DataTable CNRecuperarGrupoDatosReprogramacion(string xmlCuenta)
        {
            return Credito.ADRecuperarGrupoDatosReprogramacion(xmlCuenta);
        }

        public DataTable CNValidaReglasSolicitudRepro(int idCuenta, int idPerfil, decimal nTasaNueva)
        {
            return Credito.ADValidaReglasSolicitudRepro(idCuenta, idPerfil, nTasaNueva);
        }
        public DataTable CNObtenerTasaMinMaxSolicitudPost()
        {
            return Credito.ADObtenerTasaMinMaxSolicitudPost();
        }
        public DataTable CNObtenerImporteMinSolicitudPost()
        {
            return Credito.ADObtenerImporteMinSolicitudPost();
        }
        public DataTable CNObtieneMinMaxTasaNueva(int idCuenta, decimal nTasaInicial)
        {
            return Credito.ADObtieneMinMaxTasaNueva(idCuenta, nTasaInicial);
        }
        public DataTable CNObtieneSaldoCapitalCuenta(int idCuenta)
        {
            return Credito.ADObtieneSaldoCapitalCuenta(idCuenta);
        }
        public DataTable CNObtenerCreditoReprogramable(int idCuenta)
        {
            return Credito.ADObtenerCreditoReprogramable(idCuenta);
        }

        public DataTable CNGrabarSolicitudReprogramacion(int idCuenta, int diasgracia, int nCuotas, int nDiasPerdon,
            int idTipoPlanPago, DateTime dFechaPrimeraCuota, decimal nTasaNueva, int idGrupoReprog, int nPlazoCuota)
        {
            return Credito.ADGrabarSolicitudReprogramacion(idCuenta, diasgracia, nCuotas, nDiasPerdon,
                idTipoPlanPago, dFechaPrimeraCuota, nTasaNueva, idGrupoReprog, nPlazoCuota);
        }
        public DataTable CNGrabarSolicitudRetencionCambioTasa(int idCuenta, int diasgracia, int nCuotas, int nDiasPerdon,
            int idTipoPlanPago, DateTime dFechaPrimeraCuota, decimal nTasaNueva, int idGrupoReprog, int nPlazoCuota)
        {
            return Credito.ADGrabarSolicitudRetencionCambioTasa(idCuenta, diasgracia, nCuotas, nDiasPerdon,
                idTipoPlanPago, dFechaPrimeraCuota, nTasaNueva, idGrupoReprog, nPlazoCuota);
        }
        public DataTable CNListaPARAMSSolicitudRetencionCambioTasa(int idCuenta)
        {
            return Credito.ADListaPARAMSSolicitudRetencionCambioTasa(idCuenta);
        }
        public DataTable CNListaTipoPlanPago()
        {
            return Credito.ADListaTipoPlanPago();
        }
        public DataTable CNListaTipoPlanPago(int idPerfil)
        {
            return Credito.ADListaTipoPlanPago(idPerfil);
        }
        public DataTable CNBuscarSolicitudCreditos(int idCli)
        {
            return Credito.ADBuscarSolicitudCreditos(idCli);
        }
        public DataTable CNListarCampania(int idUsuario, int idPerfil)
        {
            return Credito.ADListarCampania(idUsuario, idPerfil);
        }
        public DataTable CNReasignarCliente(String cDocumentoID, int idUsuario)
        {
            return Credito.ADReasignarCliente(cDocumentoID, idUsuario);
        }
        public DataTable CNListarRegion(int idUsuario, int idPerfil)
        {
            return Credito.ADListarRegion(idUsuario, idPerfil);
        }
        public DataTable CNListarAgencia(int idUsuario, int idPerfil, int idZona)
        {
            return Credito.ADListarAgencia(idUsuario, idPerfil, idZona);
        }
        public DataTable CNListarEstablecimiento(int idUsuario, int idPerfil, int idAgencia)
        {
            return Credito.ADListarEstablecimiento(idUsuario, idPerfil, idAgencia);
        }
        public DataTable CNBuscarAsesor(int idUsuario, int idPerfil, int idEstablecimiento)
        {
            return Credito.ADBuscarAsesor(idUsuario, idPerfil, idEstablecimiento);
        }
        public DataTable CNBuscarOfertasCre(int idGrupoCamp, int idRegion, int idOficina, int idEstablecimiento, int idUsuario)
        {
            return Credito.ADBuscarofertasCre(idGrupoCamp, idRegion, idOficina, idEstablecimiento, idUsuario);
        }
        public DataTable CNNroCredEAI(DateTime dFechaActual, int idCli)
        {
            return Credito.ADNroCredEAI(dFechaActual, idCli);
        }
        public DataTable CNRecuperaGestionCli(String cDocumentoID, int idOferta)
        {
            return Credito.ADRecuperaGestionCli(cDocumentoID, idOferta);
        }
                public DataTable CNCargarSolicitudCamp(int idCli, int idOferta)
        {
            return Credito.ADCargarSolicitudCamp(idCli, idOferta);
        }
        public DataTable CNListarDestinoEAI(int idProducto)
        {
            return Credito.ADListarDestinoEAI(idProducto);
        }
        public DataTable CNRecuperaSolicitudEAI(int idCli, int idOferta)
        {
            return Credito.ADRecuperaSolicitudEAI(idCli, idOferta);
        }
        public DataTable CNValidarCalificativoEAI(int idCli)
        {
            return Credito.ADValidarCalificativoEAI(idCli);
        }
        public DataTable CNValidarMoraEAI(int idCli)
        {
            return Credito.ADValidarMoraEAI(idCli);
        }
        public DataTable CNValidarBaseNegativa(String cDocumentoID)
        {
            return Credito.ADValidarBaseNegativa(cDocumentoID);
        }
        public DataTable CNValidarNroEntidades(int idCli)
        {
            return Credito.ADValidarNroEntidades(idCli);
        }
        public DataTable CNValidarNroCredAct(int idCli)
        {
            return Credito.ADValidarNroCredAct(idCli);
        }
        public DataTable CNValidarEndeudamiento(int idCli, decimal nMonto)
        {
            return Credito.ADValidarEndeudamiento(idCli, nMonto);
        }
        public DataTable CNValidarSolicitudAct(int idCli, int nCodigoSol, int idSubProducto)
        {
            return Credito.ADValidarSolicitudAct(idCli, nCodigoSol, idSubProducto);
        }
        public DataTable CNValidarBloqueoEAI(int idCli, int idSubProducto)
        {
            return Credito.ADValidarBloqueoEAI(idCli, idSubProducto);
        }
        public DataTable CNValidarDiaPagoEAI(DateTime dFechaPriCuota)
        {
            return Credito.ADValidarDiaPagoEAI(dFechaPriCuota);
        }        
        public DataTable CNRegistrarOfertaEAI(int idSolicitud, decimal nMonto)
        {
            return Credito.ADRegistrarOfertaEAI(idSolicitud, nMonto);
        }
        public DataTable CNCargarCliBloqEAI(int idCli)
        {
            return Credito.ADCargarCliBloqEAI(idCli);
        }
        public DataTable CNListarMotivoBloqEAI()
        {
            return Credito.ADListarMotivoBloqEAI();
        }
        public DataTable CNBloqCliEAI(int idCli, int idMotBloqEAI, string cSustentoBloq, int idUsuBloq, int idPerfilUsuBloq)
        {
            return Credito.ADBloqCliEAI(idCli, idMotBloqEAI, cSustentoBloq, idUsuBloq, idPerfilUsuBloq);
        }
        public DataTable CNDesbloqCliEAI(int idCli, int idUsuDesbloq, int idPerfilUsuDesbloq, string cSustentoDesbloq, int idCliBloqEAI)
        {
            return Credito.ADDesbloqCliEAI(idCli, idUsuDesbloq, idPerfilUsuDesbloq, cSustentoDesbloq, idCliBloqEAI);
        }
        
        public DataTable CNAprobarSolicitudEAI(
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
            int idDetalleGasto
            )
        {
            return Credito.ADAprobarSolicitudEAI(
                 idCli                       ,  idProducto                    ,  idOperacion                   , 
                 idUsuario                   ,  nCuotas                       ,  nPlazoCuota                   ,  nCapitalSolicitado    ,  nTasa        , 
                 nTasaMoratoria              ,                                  dFechaDesembolsoSugerido       ,  tObservacion          ,  idDestino ,
                 idAgencia                   ,  idTasa                        ,  idModalidadDes                ,  ndiasgracia           ,  idActividad  ,
                 nTasaCostoEfectivo          ,  @idTipoPeriodo                ,  idRecurso                     ,  nMontoAmpliado        ,
                 nSaldoCreditos              ,   nTasaEfectivaAnual           ,  nTotalDiasCredito             ,  idModalidadCredito    ,
                                               cComentAproba                 ,  idActividadInterna            ,
           
                 idUsuRegistro ,             
                 idEstablecimiento,
                 dFechaPrimeraCuota,
                 idOferta,
                 idDetalleGasto
                );
        }
        
    }
}
