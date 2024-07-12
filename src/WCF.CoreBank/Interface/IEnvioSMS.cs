using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using EntityLayer;
using GEN.ControlesBase;

namespace WCF.CoreBank.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEnvioSMS" in both code and config file together.
    [ServiceContract]
    public interface IEnvioSMS
    {
        [WebInvoke(UriTemplate = "EnvioMensajesTexto",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta EnvioMensajesTexto(string cToken, clsMensajeTexto objMensaje);
    }
}
