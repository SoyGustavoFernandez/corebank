using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Authorization.Modelo;

namespace WCF.Authorization.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication" in both code and config file together.
    [ServiceContract]
    public interface ICRAndes
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResAuth Authenticate(ReqAuth objReqAuth);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResOnOffServicio EncenderServicio(ReqOnOffServicio objReqOnOffServicio);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResOnOffServicio ApagarServicio(ReqOnOffServicio objReqOnOffServicio);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResObtenerEstServ ObtenerEstServ(ReqObtenerEstServ objReqObtenerEstServ);
    }
}
