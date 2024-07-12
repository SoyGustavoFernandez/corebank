using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer;

namespace WCF.CoreBank.Interface
{
    [ServiceContract]
    public interface IAprobacionTasasNegociables
    {
        [WebInvoke(UriTemplate = "ListaSolicitudesTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFTasaNegociable> ListaSolicitudesTasaNegociable(string cToken);

        [WebInvoke(UriTemplate = "DetalleSolicitudTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFDetalleTasaNegociable> DetalleSolicitudTasaNegociable(string cToken, int idSolicitud, int idTasaNegociada);

        [WebInvoke(UriTemplate = "TasaCreditoNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFTasaCreditoNegociable> TasaCreditoNegociable(string cToken, int idTasa);

        [WebInvoke(UriTemplate = "AprobarTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFAprobacionTasaNegociable AprobarTasaNegociable(string cToken, int idTasaNegociada, decimal nTasaInteres, decimal nTasaMoratoria, decimal nTasaInteresMensual, string cJustificacionAprobacion, int idSolAproba, int idNivelAprRanOpe);

        [WebInvoke(UriTemplate = "DenegarTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFAprobacionTasaNegociable DenegarTasaNegociable(string cToken, int idTasaNegociada, string cJustificacionAprobacion, int idSolAproba, int idNivelAprRanOpe);

        [WebInvoke(UriTemplate = "AnularTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFAprobacionTasaNegociable AnularTasaNegociable(string cToken, int idTasaNegociable, int idEstado, int idSolAproba);

        [WebInvoke(UriTemplate = "ObtenerTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFDatosTasaNegociable ObtenerTasaNegociable(string cToken, int idSolicitud);

        [WebInvoke(UriTemplate = "RegistroSolicitudTasaNegociable",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFDatosTasaNegociable RegistroSolicitudTasaNegociable(string cToken, clsWCFDatosTasaNegociable oDetalle);
    }
}
