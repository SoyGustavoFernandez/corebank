using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace WCF.Reniec
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioReniec
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaIndInfPerReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        clsProcesaDatosRen ConsultaIndInfPerReniec(string cNroDni, string cDocAutorizado, string cCodEmp, string cIdUsu);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaIndInfPerReniecDirecta",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        clsProcesaDatosRen ConsultaIndInfPerReniecDirecta(string cNroDni, string cDocAutorizado, string cCodEmp, string cIdUsu, string cIdConsultaDirecta);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaIndInfPerFirmReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaIndInfPerFirmReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaIndInfPerFotoReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaIndInfPerFotoReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaIndInfPerFirmFotoReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaIndInfPerFirmFotoReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaDirInfPerReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaDirInfPerReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaDirInfPerFirmReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaDirInfPerFirmReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaDirInfPerFotoReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaDirInfPerFotoReniec(string cNroDni);

        [OperationContract]
        [WebInvoke(UriTemplate = "ConsultaDirInfPerFirmFotoReniec",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, Method = "POST")]
        Persona ConsultaDirInfPerFirmFotoReniec(string cNroDni);

        /*[OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ListadoPersonas")]
        List<Persona_> ListadoPersonas();

        //Buscar por ID

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Filtroid/{id}")]
        List<Persona_> FiltradoPorid(string id);

        //Guardar un registro

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CrearUsuario")]
        wsSQLResult CrearUsuario(Stream JSONdataStream);*/
    }
}
