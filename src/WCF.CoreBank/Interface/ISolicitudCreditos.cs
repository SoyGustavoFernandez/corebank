using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntityLayer;

namespace WCF.CoreBank.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISolicitudCreditos" in both code and config file together.
    [ServiceContract]
    public interface ISolicitudCreditos
    {
        //----------------------------------------------------------------------------------------------
        // Registra la solicitud de crédito
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "RegistrarSolicitudCredito",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsSolicitudCreditos RegistrarSolicitudCredito(string cToken, clsSolicitudCreditos objSolicitud);

        //----------------------------------------------------------------------------------------------
        // Lista evaluaciones para aprobar, por el Perfil, agencia y usuario
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ObtenerTasa",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsTasa> ObtenerTasa(string cToken, int nPlazo, int idProducto, decimal nMonto, int idSolicitud);

        //----------------------------------------------------------------------------------------------
        // Busca si cliente tiene campañas vigentes registradas
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "TieneCampanaVigente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsClienteCampanaVigente> TieneCampanaVigente(string cToken, int idTipoDocumento, string cDocumentoId);

        //----------------------------------------------------------------------------------------------
        // Lista productpos por campaña
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ProductoXCampana",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsProducto> ProductoXCampana(string cToken, int idGrupoCamp);

        //----------------------------------------------------------------------------------------------
        // Lista SubProductos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ObtenerSubProductos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsSubProducto> ObtenerSubProductos(string cToken);

        //----------------------------------------------------------------------------------------------
        // Lista de vinculados al creditos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ObtenerVinculados",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsVinculadoCredito> ObtenerVinculados(string cToken, int idSolicitud);

        //----------------------------------------------------------------------------------------------
        // registro de vinculado al creditos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "RegistroInterviniente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistroInterviniente(string cToken, int idSolicitud, int idCli, int idTipoInterviniente, int idProducto);

        //----------------------------------------------------------------------------------------------
        // Busqueda de cliente mediante DNI, ID Cliente y Nombres Apellidos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "BusquedaClienteCriterioExpresion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsWCFClienteCriterioExpresion> BusquedaClienteCriterioExpresion(string cToken, int idCriterio, string cExpresion, bool lReniec);

        //----------------------------------------------------------------------------------------------
        // Eliminar vinculado al creditos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "EliminarInterviniente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta EliminarInterviniente(string cToken, int idIntervinienteCredito);

        //----------------------------------------------------------------------------------------------
        // Busca clientes a vincular
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "BurcarClienteVincular",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsClienteVincular> BurcarClienteVincular(string cToken, int idTipoDocumento, string cDocumentoID);

        //----------------------------------------------------------------------------------------------
        // Comprobar Base Negativa
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ComprobarBaseNegativa",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta ComprobarBaseNegativa(string cToken, string cDocumentoID);

        //----------------------------------------------------------------------------------------------
        // Envia solicitud a evaluación
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "EnviarSolicitud",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta EnviarSolicitud(string cToken, int idSolicitud);

        //----------------------------------------------------------------------------------------------
        // Busca si cliente tiene campañas vigentes registradas
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "TieneSolicitudCreditos",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsSolicitudCreditos TieneSolicitudCreditos(string cToken, int idTipoDocumento, string cDocumentoId);

        //----------------------------------------------------------------------------------------------
        // Lista productpos por campaña
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ProductosVigentes",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsProducto> ProductosVigentes(string cToken);

        //----------------------------------------------------------------------------------------------
        // Lista creditos cliente
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ListaCreditosCliente",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsCreditoCliente> ListaCreditosCliente(string cToken, int idCli);

        //----------------------------------------------------------------------------------------------
        // Lista cultivos
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ListaProductoAgricolaCultivo",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsProductoAgricolaCultivo> ListaProductoAgricolaCultivo(string cToken);

        //----------------------------------------------------------------------------------------------
        // Lista cultivos / variedad
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ListaProductoAgricolaCultivoVariedad",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        IList<clsProductoAgricolaCultivoVariedad> ListaProductoAgricolaCultivoVariedad(string cToken, int idCultivoEval);

        //----------------------------------------------------------------------------------------------
        // Lista cultivos / variedad
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "RegistroCultivoVariedadEvaluacion",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsWCFRespuesta RegistroCultivoVariedadEvaluacion(string cToken, int idEvalCred, int idCultivoEval, int idVariedadCultivoEval);

        //----------------------------------------------------------------------------------------------
        // Obtiene cultivos / variedad seleccionados
        //----------------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "ProductoAgricolaCultivoVariedad",
         BodyStyle = WebMessageBodyStyle.WrappedRequest,
         ResponseFormat = WebMessageFormat.Json,
         RequestFormat = WebMessageFormat.Json,
         Method = "POST")]
        clsProductoAgricolaCultivoVariedadSeleccionado ProductoAgricolaCultivoVariedad(string cToken, int idCultivoEval, int idSubProducto);
    }
}
