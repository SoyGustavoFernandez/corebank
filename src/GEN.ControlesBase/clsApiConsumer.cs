using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
namespace GEN.ControlesBase
{
    public class clsApiConsumer
    {
        private static HttpMethod CreateHttpMethod(methodHttp method)
        {
            switch (method)
            {
                case methodHttp.GET:
                    return HttpMethod.Get;
                case methodHttp.POST:
                    return HttpMethod.Post;
                case methodHttp.PUT:
                    return HttpMethod.Put;
                case methodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Método http no implementado");
            }
        }

        public static async Task<clsApiRespuesta> Execute<T>(string url, methodHttp method, object objectRequest)
        {
            clsApiRespuesta oReply = new clsApiRespuesta();
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var myContent = JsonConvert.SerializeObject(objectRequest);
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var request = new HttpRequestMessage(CreateHttpMethod(method), url)
                    {
                        Content = (method != methodHttp.GET) ? method != methodHttp.DELETE ? bytecontent : null : null
                    };

                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                                oReply.Data = JsonConvert.DeserializeObject<T>(data);

                            oReply.StatusCode = res.StatusCode.ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                oReply.StatusCode = "ServerError";
                var response = (HttpWebResponse)ex.Response;
                if (response != null)
                    oReply.StatusCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                oReply.StatusCode = "AppError";
            }
            return oReply;
        }
    }
}
