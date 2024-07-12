using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityLayer;
using System.Data;

namespace WCF.CoreBank.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEvaluacionCreditos" in both code and config file together.
    [ServiceContract]
    public interface IEvaluacionCreditos
    {
        /*[OperationContract]
        void DoWork();*/

        [WebInvoke(UriTemplate = "ListarSolicitudPendienteEvaluacion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsSolicitudEvaluacion> ListarSolicitudPendienteEvaluacion(string cToken);

        [WebInvoke(UriTemplate = "GetCapacidadPago",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        double GetCapacidadPago(string cToken, int idSolicitud);

        [WebInvoke(UriTemplate = "GetBalanceGeneral",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsBalanceGeneral> GetBalanceGeneral(string cToken, int idTipEvalCred, int idEvalCred);
                
        [WebInvoke(UriTemplate = "GetEstadoResultados",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsEstadoResultados> GetEstadoResultados(string cToken, int idTipEvalCred, int idEvalCred);

        [WebInvoke(UriTemplate = "GuardarEvaluacionCredito",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta GuardarEvaluacionCredito(string cToken, int idSolicitud, int idEvalCred, List<clsEstResEval> listEstadoResultado, List<clsBalGenEval> listBalance, Decimal nCapacidadPago, Decimal nEndeudamientoTotal);

        [WebInvoke(UriTemplate = "EnviarAAprobacion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta EnviarAAprobacion(string cToken, int idEvalCred, int idSolicitud, int idCli, int idMoneda, decimal nMonto, int idProducto);

        [WebInvoke(UriTemplate = "GetCondicionesCredito",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsCondicionesCredito GetCondicionesCredito(string cToken, int idEvalCred);

        [WebInvoke(UriTemplate = "GuardarPropuestaEval",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta GuardarPropuestaEval(string cToken, int idEvalCred, int idPeriodoCred, int nCuotas, int nDiasGracia, string cFechaDesembolso, string cFechaPrimeraCuota, decimal nCapitalPropuesto, int idTasa, decimal nTEA, decimal nTIM, int idProducto, int idTipoPeriodo, int nPlazoCuotaPropuesto, int idSolicitud);

        [WebInvoke(UriTemplate = "GuardarReferencias",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta GuardarReferencias(string cToken, int idEvalCred, List<clsReferenciaEval> list);

        [WebInvoke(UriTemplate = "ObtenerReferencias",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsReferenciaEval> ObtenerReferencias(string cToken, int idEvalCred);

        [WebInvoke(UriTemplate = "SolicitudTipoDocumentoExpediente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFSolicitudTipoDocumento SolicitudTipoDocumentoExpediente(string cToken, int idCliente);

        [WebInvoke(UriTemplate = "RegistroArchivoEscaneado",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistroArchivoEscaneado(string cToken, int idSolicitud, int idDescTipoDoc, int idTipoArchivo, string cArchivoContent);
    }
}
