using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.KasNet.Modelo;

namespace WCF.KasNet.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IKasNet" in both code and config file together.
    [ServiceContract]
    public interface IKasNet
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/api/v1/kasnet/auth", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResAuth auth(ReqAuth jsonRequest);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/api/v1/kasnet/debtconsult?nroSumin={nroSumin}&traceConsulta={traceConsulta}&fechaConsulta={fechaConsulta}&horaConsulta={horaConsulta}&codEmpresa={codEmpresa}&codServicio={codServicio}&codAgencia={codAgencia}&codCanal={codCanal}&terminal={terminal}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResDebtConsult debtconsult(string nroSumin, string traceConsulta, string fechaConsulta, string horaConsulta, string codEmpresa, string codServicio, string codAgencia, string codCanal, string terminal);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/api/v1/kasnet/payment/create", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResCreate create(ReqCreate jsonRequest);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/api/v1/kasnet/payment/cancel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResCancel cancel(ReqCancel jsonRequest);
    }
}
