using WCFLogistica.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF.Logistica.Services
{    
    [ServiceContract]
    public interface IRendiciones
    {
        [WebInvoke(UriTemplate = "BuscarProveedor",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsProveedor> BuscarProveedor(int idCriterio, string cCriterio);

        #region módulo - entregas a rendir
        [WebInvoke(UriTemplate = "CambiarEstadoEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta CambiarEstadoEntrega(int idEntrega, int idEtapa, int idEstado, int idUsuario, string cComentario);

        [WebInvoke(UriTemplate = "ObtenerResumenEntregas",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEntregaRendir> ObtenerResumenEntregas(int idUsuario, int idTipoEntrega);

        #region etapa - registro
        [WebInvoke(UriTemplate = "RegistrarEntregaRendir",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsEntregaRendir RegistrarEntregaRendir(clsEntregaRendir objEntregaRendir);

        [WebInvoke(UriTemplate = "ObtenerEntregasRendir",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEntregaRendir> ObtenerEntregasRendir(int idUsuario, int idTipo, int idEstado, int idEntrega);

        [WebInvoke(UriTemplate = "ObtenerArchivoEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsArchivoEntrega ObtenerArchivoEntrega(int idArchivo);

        [WebInvoke(UriTemplate = "ObtenerDatosArchivosEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsArchivoEntrega> ObtenerDatosArchivosEntrega(int idEntrega);

        [WebInvoke(UriTemplate = "RegistrarArchivoEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarArchivoEntrega(clsArchivoEntrega objArchivoEntrega);

        [WebInvoke(UriTemplate = "RegistrarArchivosEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarArchivosEntrega(List<clsArchivoEntrega> lstArchivoEntrega);

        [WebInvoke(UriTemplate = "SolicitarEntregaRendir",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta SolicitarEntregaRendir(int idEntrega, int idUsuario);        
        #endregion

        [WebInvoke(UriTemplate = "ObtenerEntregaAprobaciones",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsAprobacionEntrega> ObtenerEntregaAprobaciones(int idEntrega);

        #region etapa - desembolso
        [WebInvoke(UriTemplate = "ObtenerDesembolsoEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsDesembolsoEntrega ObtenerDesembolsoEntrega(int idEntrega);        
        #endregion

        #region etapa - rendición
        [WebInvoke(UriTemplate = "ObtenerRendicionEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsRendicionEntrega ObtenerRendicionEntrega(int idEntrega);

        [WebInvoke(UriTemplate = "ObtenerComprobantesPago",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsComprobantePago> ObtenerComprobantesPago(int idEntrega, int idComprobantePago);

        [WebInvoke(UriTemplate = "ObtenerDetallesComprobante",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsDetalleComprobante> ObtenerDetallesComprobante(int idEntrega, int idComprobantePago);

        [WebInvoke(UriTemplate = "RegistrarComprobantePago",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsComprobantePago RegistrarComprobantePago(int idEntrega, clsComprobantePago objComprobantePago, List<clsDetalleComprobante> lstDetalleComprobante);

        [WebInvoke(UriTemplate = "ObtenerArchivoComprobante",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsArchivoComprobante ObtenerArchivoComprobante(int idComprobantePago);        

        [WebInvoke(UriTemplate = "RegistrarArchivoComprobante",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarArchivoComprobante(clsArchivoComprobante objArchivoComprobante);        

        [WebInvoke(UriTemplate = "EnviarRendicionEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsRendicionEntrega EnviarRendicionEntrega(clsRendicionEntrega objRendicionEntrega);

        [WebInvoke(UriTemplate = "ActualizarRendicionEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsRendicionEntrega ActualizarRendicionEntrega(clsRendicionEntrega objRendicionEntrega);        

        [WebInvoke(UriTemplate = "ObtenerRecibos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsRecibo> ObtenerRecibos(int idEntrega, int idReciboRendicion);

        [WebInvoke(UriTemplate = "RegistrarRecibo",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarRecibo(clsRecibo objRecibo);

        [WebInvoke(UriTemplate = "RegistrarProveedor",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsProveedor RegistrarProveedor(clsProveedor objProveedor);        
        #endregion

        #region etapa - aprobación de rendición
        [WebInvoke(UriTemplate = "ObtenerRendicionAprobaciones",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsAprobacionRendicion> ObtenerRendicionAprobaciones(int idEntrega);
        #endregion

        #region etapa - rendido
        [WebInvoke(UriTemplate = "ObtenerRendidoEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsRendidoEntrega ObtenerRendidoEntrega(int idEntrega);
        #endregion
        #endregion

        #region módulo - viáticos
        [WebInvoke(UriTemplate = "RegistrarViatico",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsEntregaRendir RegistrarViatico(clsEntregaRendir objEntregaRendir, clsViatico objViatico, List<clsDetalleViatico> lstDetalleViatico);

        [WebInvoke(UriTemplate = "ObtenerViatico",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsViatico ObtenerViatico(int idEntrega, int idViatico);

        [WebInvoke(UriTemplate = "ObtenerDetallesViatico",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsDetalleViatico> ObtenerDetallesViatico(int idViatico, int idDetalleViatico);
        #endregion

        #region módulo - aprobaciones
        [WebInvoke(UriTemplate = "ObtenerAprobacionesEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEntregaRendir> ObtenerAprobacionesEntrega(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID);

        [WebInvoke(UriTemplate = "RegistrarAprobacionEntrega",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarAprobacionEntrega(clsAprobacionEntrega objAprobacionEntrega);

        [WebInvoke(UriTemplate = "ObtenerAprobacionesRendicion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEntregaRendir> ObtenerAprobacionesRendicion(int idPerfil, int idUsuario, int idTipoEntrega, string cNombre, string cDocumentoID);

        [WebInvoke(UriTemplate = "RegistrarAprobacionRendicion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistrarAprobacionRendicion(clsAprobacionRendicion objAprobacionRendicion);

        [WebInvoke(UriTemplate = "ObtenerResumenAprobaciones",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsResumenAprobacion> ObtenerResumenAprobaciones(int idPerfil, int idUsuario);

        #region modulo - rendiciones vencidas
        [WebInvoke(UriTemplate = "ObtenerRendicionesVencidas",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsRendicionVencida> ObtenerRendicionesVencidas(string cTipoConsulta, int idUsuario);

        [WebInvoke(UriTemplate = "NotificarRendicionesVencidas",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta NotificarRendicionesVencidas(String cEmailOrigen, String cPassword, int idUsuario);        
        #endregion        
        #endregion
    }
}
