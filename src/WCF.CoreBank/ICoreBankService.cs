using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntityLayer;

namespace WCF.CoreBank
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICoreBankService" in both code and config file together.
    [ServiceContract]
    
    public interface ICoreBankService
    {
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "IdentificarUsuario",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFUsuario IdentificarUsuario(clsWCFUsuario objWCFUsuario);

        [WebInvoke(UriTemplate = "AgenciaPerfilUsuario",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFUsuario AgenciaPerfilUsuario(clsWCFUsuario objWCFUsuario);

        [WebInvoke(UriTemplate = "ValidarToken",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFToken ValidarToken(string cToken);

        [WebInvoke(UriTemplate = "ListarHojasRutaPendientes",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFHojaRuta> ListarHojasRutaPendientes(string cToken);

        [WebInvoke(UriTemplate = "ListarCarteraAsesor",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCarteraAsesor> ListarCarteraAsesor(string cToken);

        [WebInvoke(UriTemplate = "ListarCarteraRecuperador",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCarteraAsesor> ListarCarteraRecuperador(string cToken);

        [WebInvoke(UriTemplate = "ListarCarteraRecuperadorDet",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCarteraRecuperador> ListarCarteraRecuperadorDet(string cToken);

        [WebInvoke(UriTemplate = "FiltrarCarteraRecuperador",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCarteraRecuperador> FiltrarCarteraRecuperador(string cToken, int idUsuario, int nDiasProximos);

        [WebInvoke(UriTemplate = "ListarGestionCliente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFGestionCliente> ListarGestionCliente(string cToken, int idCli);

        [WebInvoke(UriTemplate = "ListarTipoDocumento",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFTipoDocumento> ListarTipoDocumento(string cToken);

        [WebInvoke(UriTemplate = "ListarDireccionesCliente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWFCDireccionCliente> ListarDireccionesCliente(string cToken, int idCli);

        [WebInvoke(UriTemplate = "ListarClienteVinculo",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWFCClienteVinculo> ListarVinculosCliente(string cToken, int idCli);

        [WebInvoke(UriTemplate = "ListarCreditosHojaRuta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFDetalleHojaRuta> ListarCreditosHojaRuta(clsWCFParametroInt objWCFParametroInt);

        [WebInvoke(UriTemplate = "RegistraGestionHojaRuta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistraGestionHojaRuta(clsWCFResultadoGestion objWCFResultadoGestion);

        [WebInvoke(UriTemplate = "FinalizaHojaRuta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta FinalizaHojaRuta(clsWCFResultadoHojaRuta objWCFResultadoHojaRuta);

        [WebInvoke(UriTemplate = "ListarPromesasPago",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFPromesaPago> ListarPromesasPago(string cToken);


        [WebInvoke(UriTemplate = "BuscarClientes",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFClienteBasico> BuscarClientes(clsWCFBusquedaCliente objWCFBusquedaCliente);

        [WebInvoke(UriTemplate = "AgregarCreditoHojaRuta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta AgregarCreditoHojaRuta(clsWCFClienteHojaRuta objWCFClienteHojaRuta);

        [WebInvoke(UriTemplate = "ScoringPrimerFiltro",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFScoringPrimerFiltro ScoringPrimerFiltro(clsWCFParametroString objWCFParametroString);

        [WebInvoke(UriTemplate = "ScoringSegundoFiltro",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFResSegundoFiltro ScoringSegundoFiltro(clsWCFEnvSegundoFiltro objWCFEnvSegundoFiltro);

        [WebInvoke(UriTemplate = "RegistraVisitaGeoPosImgs",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistraVisitaGeoPosImgs(clsWCFRegistroGeoPos objWCFResultadoGeoPosImgs);

        [WebInvoke(UriTemplate = "TipoVisita",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsTipoVisita> TipoVisita(string cToken);

        [WebInvoke(UriTemplate = "EstadoVisita",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEstadoVisita> EstadoVisita(string cToken);

        [WebInvoke(UriTemplate = "ListarVisita",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsVisita> ListarVisita(string cToken, int idCliente);

        [WebInvoke(UriTemplate = "RegistroVisita",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsVisita RegistroVisita(string cToken, clsVisita objVisita);

        #region recibo_provicional

        [WebInvoke(UriTemplate = "ListarRecibosProvisionales",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFReciboProvicional> ListarRecibosProvisionales(string cToken, int nEstado, int idHojaRuta);

        [WebInvoke(UriTemplate = "RegistroReciboProvisional",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFResponseReciboProvisional RegistroReciboProvisional(
                string cToken,
                int idCuenta,
                int idCli,   
                int idReciboProvisional,
                int idHojaRuta,
                int idMoneda,
                int idTipoPersona,                  
                string cDocumentoID,
                string cNombres, 
                string cNumeroCelular,
                decimal nMonto,
                int idTipoVinculo,
                int nEstado,
                string cCodigoConfirmacion,
                string cSustento,
                string cAction           
            );
        #endregion

        [WebInvoke(UriTemplate = "CargaDeArchivos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsDetalleVisita CargaDeArchivos(string cToken, clsDetalleVisita objDetalleVisita);

        [WebInvoke(UriTemplate = "RegistroCliente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsClienteWFC RegistroCliente(string cToken, clsClienteWFC objCli);

        [WebInvoke(UriTemplate = "BuscarCredCliente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCarteraAsesor> BuscarCredCliente(string cToken, int idTipoDocumento, string cDocumentoID, bool nonReniec);


        [WebInvoke(UriTemplate = "ListarCampanaVigente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsCampana> ListarCampanaVigente(string cToken);

        [WebInvoke(UriTemplate = "ListarClienteXCampanaAsesor",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsClienteCampana> ListarClienteXCampanaAsesor(string cToken, int idGrupoCamp);

        [WebInvoke(UriTemplate = "MonitorVisitas",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFMonitorVisitaRespuesta MonitorVisitas(string cToken, string idZona, string idAgencia, string idPersonal, string dtFechaIni, string dtFechaFin, int idClasificacion, int fMora);

        [WebInvoke(UriTemplate = "MonitorDetalleVisita",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFMonitorVisita MonitorDetalleVisita(string cAccessKey);

        [WebInvoke(UriTemplate = "MonitorVisitasBusqueda",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFMonitorVisitaRespuesta MonitorVisitasBusqueda(string cToken, int nTipoBusqueda, string cCriterio, string dtFechaIni, string dtFechaFin);

        [WebInvoke(UriTemplate = "MonitorCreditos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorCredito> MonitorCreditos(string cToken, int idCli);

        [WebInvoke(UriTemplate = "MonitorListaAgencia",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorListaAgencia> MonitorListaAgencia(string cToken);

        [WebInvoke(UriTemplate = "MonitorListaAgenciaZona",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorListaAgencia> MonitorListaAgenciaZona(string cToken, int idZona);

        [WebInvoke(UriTemplate = "MonitorListaPersonalAgencia",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorPersonal> MonitorListaPersonalAgencia(string cToken, int idAgencia);

        [WebInvoke(UriTemplate = "MonitorListaZona",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorListaZona> MonitorListaZona();

        [WebInvoke(UriTemplate = "MonitorListaArchivos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFMonitorListaArchivo> MonitorListaArchivos(int idVisita);

        [WebInvoke(UriTemplate = "MonitorArchivo",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFMonitorArchivo MonitorArchivo(int idArchivo);

        [WebInvoke(UriTemplate = "VincularVisitaSolicitud",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta VincularVisitaSolicitud(string cToken, int idSolicitud, int idVisita);

        [WebInvoke(UriTemplate = "ConsultaAdmisionInterna",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
         clsWCFConsultaAdmisionInterna consultaAdmisionInterna(string cToken, string cDocumentoID, int idTipoDocumento);

        [WebInvoke(UriTemplate = "RegistroEncuestaRespuesta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistroEncuestaRespuesta(string cToken, string cDni, string cNombreApellido, int nEdad, string cSexo, string cEstadoCivil, string cNumeroCelular, string cRespuesta, string cUsuario, string cCodEncuesta, int idFeria, string dFechaRegistro);

        [WebInvoke(UriTemplate = "ReporteEncuesta",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFReporteEncuesta> ReporteEncuesta(string cToken, int page, int pageSize, string fechaInicio, string fechaFinal, int idFeria);

        [WebInvoke(UriTemplate = "ListaEncuestaFeria",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFReporteEncuestaFeria> ListaEncuestaFeria(string cToken, int page, int pageSize);

        [WebInvoke(UriTemplate = "ListaEncuestaEstablecimiento",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFReporteEncuestaEstablecimiento> ListaEncuestaEstablecimiento(string cToken);

        [WebInvoke(UriTemplate = "RegistroEdicionEncuestaFeria",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFEncuestaFeria RegistroEdicionEncuestaFeria(string cToken, int idRegistroFeria, int idEstablecimiento, string cNombre, string cLugar, string cDias, string cHorarioInicio, string cHorarioFinal, bool lVigente);

        [WebInvoke(UriTemplate = "ListarCampanias",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCampaniaCliente> ListarCampanias(string cToken, string cDni);
    }
}
