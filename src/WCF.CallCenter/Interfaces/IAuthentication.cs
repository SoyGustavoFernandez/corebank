using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.CallCenter.Modelo;

namespace WCF.CallCenter.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication" in both code and config file together.
    [ServiceContract]
    public interface IAuthentication
    {
        /*[OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string Authenticate(clsCredencial cred);*/
    }
}
