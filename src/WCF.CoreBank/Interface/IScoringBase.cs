using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityLayer;
using System.ServiceModel.Web;

namespace WCF.CoreBank.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IScoringBase" in both code and config file together.
    [ServiceContract]
    public interface IScoringBase
    {
        //----------------------------------------------------------------------------------------------
        // Envia solicitud a evaluación
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ScoreBase",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsScoreEnt ScoreBase(string cToken, string cDNITitular, string cDNIConyuge);

        [WebInvoke(UriTemplate = "Score",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsScoreEnt Score(string cToken, string cDNITitular, string cDNIConyuge, int idDestino, int idTipoScore, int idSolicitud);

        [WebInvoke(UriTemplate = "ValidarConyugeTitular",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        string ValidarConyugeTitular(string cToken, string cDocumentoID);
    }
}
