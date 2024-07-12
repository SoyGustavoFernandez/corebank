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
    public interface IAprobacionCreditos
    {
        //----------------------------------------------------------------------------------------------
        // Lista evaluaciones para aprobar, por el Perfil, agencia y usuario
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ListarEvaluacionesParaAprobar",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFCredito> ListarEvaluacionesParaAprobar(string cToken);

        [WebInvoke(UriTemplate = "ObtenerEvaluacion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFDatosCliente ObtenerEvaluacion(string cToken, int idEvalCred, int idSolicitud);

        //----------------------------------------------------------------------------------------------
        // Guardar Desición
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "GuardarDesicion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFGestionAprobacion GuardarDesicion(string cToken, int idSolicitud, int idAprobacion, int idEvalCred, decimal nMonto, string cComentario, int idMotRechazo);

    }
}
