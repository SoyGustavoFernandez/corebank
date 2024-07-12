using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using clsWCFUsuario_R = WCFLogistica.EntityLayer.clsWCFUsuario;

namespace WCF.Logistica.Services
{
    [ServiceContract]
    public interface IAutenticacion
    {
        [WebInvoke(UriTemplate = "IdentificarUsuario",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFUsuario_R IdentificarUsuario(clsWCFUsuario_R objWCFUsuario);

        [WebInvoke(UriTemplate = "IniciarSesion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFUsuario_R IniciarSesion(clsWCFUsuario_R objWCFUsuario);

        [WebInvoke(UriTemplate = "ValidarToken",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "GET")]
        bool ValidarToken();

        [WebInvoke(UriTemplate = "ObtenerDatosUsuario",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "GET")]
        clsWCFUsuario_R ObtenerDatosUsuario();
    }
}
