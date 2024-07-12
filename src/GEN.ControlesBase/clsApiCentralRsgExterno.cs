using EntityLayer;
using EntityLayer.SentinelData;
using GEN.CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GEN.ControlesBase
{
    public class clsApiCentralRsgExterno
    {
        public Response ConsultaClienteExterno(int idUsuarioConsulta, string cDocumento, string cTipoDocumento, int ntipoConsulta = 1)
        {
            DataAutenticador objAutenticador = Autenticacion();
            Response oReply = new Response();

            if (objAutenticador.Data == null)
            {
                oReply.Success  = objAutenticador.Success;
                oReply.Message  = objAutenticador.Message;
                oReply.Errors   = objAutenticador.Errors;
                oReply.Data     = new List<DataCentralRiesgosOuput>();   
                oReply.cTicket  = objAutenticador.cTicket;
                return oReply;
            }

            string cToken               = objAutenticador.Data.cToken;
            string cDicto               = String.Empty;
            string cUrlConsultaSentinel = String.Empty;
            String cJson                = String.Empty;
            WebClient webClient         = new WebClient();
            cDicto                      = "{\"credencialesSentinel\":false,\"idUsuario\":" + idUsuarioConsulta + ",\"cUsuarioSentinelEncry\":\"" + "5oNai0bOa+JC/f/glOYlnQ==" + "\",\"cPasswordSentinelEncry\":\"" + "qyveoZoo/hDS54VrZljmEw==" + "\",\"dataCentralRiesgoClientes\":" + "[{\"idTipoDocumentoID\":\"" + cTipoDocumento + "\",\"cDocumentoID\":\"" + cDocumento + "\"}]" + ",\"nTipoConsulta\":" + ntipoConsulta + "}";
            byte[] bBytes               = Encoding.ASCII.GetBytes(cDicto);
            webClient.Encoding          = Encoding.UTF8;
            webClient.Headers[HttpRequestHeader.Authorization] = "Bearer " + cToken;
            webClient.Headers["Content-type"] = "application/json";
            byte[] response;

            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("cUrlConsultaSentinel")))
            {
                clsVarGen objVarTipoPlantilla   = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cUrlConsultaSentinel"));
                cUrlConsultaSentinel            = Convert.ToString(objVarTipoPlantilla.cValVar);
            }
            string cServiceURL = string.Format(cUrlConsultaSentinel, cDicto);

            try
            {
                response                = webClient.UploadData(cServiceURL, "POST", bBytes);
                Stream stream           = new MemoryStream(response);
                StreamReader reader     = new StreamReader(stream);
                cJson                   = reader.ReadToEnd();
                var jsonObject          = JObject.Parse(cJson);
                JToken valorEspecifico  = jsonObject["data"];

                if (valorEspecifico.Type == JTokenType.Null || !valorEspecifico.HasValues)
                {
                    objAutenticador = JsonConvert.DeserializeObject<DataAutenticador>(cJson);

                    oReply.Success  = objAutenticador.Success;
                    oReply.Message  = objAutenticador.Message;
                    oReply.Errors   = objAutenticador.Errors;
                    oReply.Data     = new List<DataCentralRiesgosOuput>();
                    oReply.cTicket  = objAutenticador.cTicket;
                    return oReply;
                }
                else
                {
                    oReply = JsonConvert.DeserializeObject<Response>(cJson);
                    return oReply;
                }
            }
            catch (Exception e)
            {
                Response oRespuestaExcepcion = new Response();
                oRespuestaExcepcion.Success = objAutenticador.Success;
                oRespuestaExcepcion.Message = objAutenticador.Message;
                oRespuestaExcepcion.Errors = objAutenticador.Errors;
                oRespuestaExcepcion.Data = new List<DataCentralRiesgosOuput>();
                oRespuestaExcepcion.cTicket = objAutenticador.cTicket;

                return oRespuestaExcepcion;
            }
        }

        public DataConsultaUsuario ConsultaUsuario(int idTipoDocumento, string cDocumentoID)
        {
            DataConsultaUsuario oReply          = new DataConsultaUsuario();
            DataAutenticador objAutenticador    = Autenticacion();

            if (objAutenticador.Data.cToken == null)
            {
                oReply.Success  = objAutenticador.Success;
                oReply.Message  = objAutenticador.Message;
                oReply.Errors   = objAutenticador.Errors;
                oReply.Data     = new List<DataUsuariosUltimaConsulta>();
                oReply.cTicket  = objAutenticador.cTicket;
                return oReply;
            }

            string cToken = objAutenticador.Data.cToken;
            string cUrlConsultaSentinel = String.Empty;

            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("cUrlConsultaUsuarioSentinel")))
            {
                clsVarGen objVarTipoPlantilla   = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cUrlConsultaUsuarioSentinel"));
                cUrlConsultaSentinel            = Convert.ToString(objVarTipoPlantilla.cValVar);
            }

            string cDicto       = cUrlConsultaSentinel + "?idTipoDocumento=" + idTipoDocumento + "&cDocumentoID=" + cDocumentoID;
            var request         = (HttpWebRequest)WebRequest.Create(cDicto);
            request.Method      = "GET";
            request.ContentType = "application/json";
            request.Accept      = "application/json";
            request.Headers[HttpRequestHeader.Authorization] = "Bearer " + cToken;

            try
            {
                WebResponse response    = request.GetResponse();
                Stream stream           = response.GetResponseStream();
                StreamReader reader     = new StreamReader(stream);
                String cJson            = reader.ReadToEnd();
                var jsonObject          = JObject.Parse(cJson);
                JToken valorEspecifico  = jsonObject["data"];

                if (valorEspecifico.Type == JTokenType.Null || !valorEspecifico.HasValues)
                {
                    objAutenticador = JsonConvert.DeserializeObject<DataAutenticador>(cJson);
                    
                    oReply.Success  = objAutenticador.Success;
                    oReply.Message  = objAutenticador.Message;
                    oReply.Errors   = objAutenticador.Errors;
                    oReply.Data     = new List<DataUsuariosUltimaConsulta>();
                    oReply.cTicket  = objAutenticador.cTicket;
                    return oReply;
                }
                else
                {
                    oReply = JsonConvert.DeserializeObject<DataConsultaUsuario>(cJson);

                    return oReply;
                }

            }
            catch (WebException ex)
            {
                DataConsultaUsuario oRespuestaExcepcion = new DataConsultaUsuario();
                oRespuestaExcepcion.Success = objAutenticador.Success;
                oRespuestaExcepcion.Message = objAutenticador.Message;
                oRespuestaExcepcion.Errors = objAutenticador.Errors;
                oRespuestaExcepcion.Data = new List<DataUsuariosUltimaConsulta>();
                oRespuestaExcepcion.cTicket = objAutenticador.cTicket;
                return oRespuestaExcepcion;
            }
        }

        public DataAutenticador Autenticacion()
        {
            DataAutenticador objAutenticador    = new DataAutenticador();
            string cDicto                       = String.Empty;
            String cJson                        = String.Empty;
            WebClient webClient                 = new WebClient();
            string cUrlLoginSentinel            = String.Empty;
            cDicto                              = "{\"cUserName\":\"" + clsVarGlobal.User.cWinUser + "\",\"cPassword\":\"" + clsVarGlobal.User.cPassword + "\"}";
            byte[] bBytes                       = Encoding.ASCII.GetBytes(cDicto);
            webClient.Encoding                  = Encoding.UTF8;
            webClient.Headers["Content-type"]   = "application/json";
            byte[] response;

            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("cUrlLoginSentinel")))
            {
                clsVarGen objVarTipoPlantilla   = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cUrlLoginSentinel"));
                cUrlLoginSentinel               = Convert.ToString(objVarTipoPlantilla.cValVar);
            }
            string cServiceURL = string.Format(cUrlLoginSentinel, cDicto);

            try
            {
                response            = webClient.UploadData(cServiceURL, "POST", bBytes);
                Stream stream       = new MemoryStream(response);
                StreamReader reader = new StreamReader(stream);
                cJson               = reader.ReadToEnd();
                objAutenticador     = JsonConvert.DeserializeObject<DataAutenticador>(cJson);
            }
            catch (Exception e)
            {
                return new DataAutenticador();
            }

            return objAutenticador;
        }
    }
}
