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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITipoVisita" in both code and config file together.
    [ServiceContract]
    public interface IVisita
    {
        //Webservice lista de documentos segun tipo de visita
        [WebInvoke(UriTemplate = "ListarTipoDocVisita",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        IList<clsWCFTipoDocVisita> ListarTipoDocVisita(String cToken);

        //Webservice Listado de tipo de visita según perfil
        [WebInvoke(UriTemplate = "ListarTipoVisitaPerfil",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        IList<clsWCFTipoVisitaPerfil> ListarTipoVisitaPerfil(String cToken);

        //Webservice Generación de fichas
        [WebInvoke(UriTemplate = "listarFicha",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        clsWCFFichaVisita ListarFichaTipoVisita(String cToken, int idCli, int nFicha, int idCuenta);

        //Webservice Generación de fichas con respuestas
        [WebInvoke(UriTemplate = "ListarFichaRespuesta",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        IList<clsFVItemsRespuesta> ListarFichaTipoVisitaRespuesta(int idVisita);

        //Webservice visitas de asesor según meses
        [WebInvoke(UriTemplate = "ListarVisitasFechaAsesor",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        IList<clsWCFVisita> ListarVisitasFechaAsesor(String cToken);

        //Lista de creditos retrasados - recuperaciones
        [WebInvoke(UriTemplate = "ListaCreditoRecuperacionesVisita",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            Method = "POST")]
        IList<clsWCFCreditosRecuperaciones> ListaCreditoRecuperacionesVisita(String cToken, int idCli);
    }
}