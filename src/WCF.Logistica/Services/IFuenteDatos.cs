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
    public interface IFuenteDatos
    {
        [WebInvoke(UriTemplate = "ObtenerConceptosRecibo",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsConceptoRecibo> ObtenerConceptosRecibo(int idTipRec, int idPerfil);

        [WebInvoke(UriTemplate = "ObtenerConfigTipoComprobante",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "GET")]
        IList<clsConfigTipoComprobante> ObtenerConfigTipoComprobante();
    }
}
