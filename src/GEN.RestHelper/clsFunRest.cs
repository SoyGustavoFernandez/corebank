using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GEN.RestHelper
{
    public class clsFunRest<TRequest, TResponse>
        where TRequest : class
        where TResponse : class, new()
    {
        private string urlAPI;

        public clsFunRest(string urlApi)
        {
            this.urlAPI = urlApi;
        }

        public TResponse Execute(string cMetodo, HttpMethod method, Dictionary<string, string> ListParametros, TRequest Body, MultipartFormDataContent file)
        {
            TResponse result = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.urlAPI);
                    var request = new HttpRequestMessage(method, cMetodo);

                    // Agregar los parámetros de la URL si es necesario
                    if (ListParametros != null)
                    {
                        var queryParams = new List<string>();
                        foreach (var param in ListParametros)
                        {
                            queryParams.Add(string.Format("{0}={1}", param.Key, param.Value));
                        }
                        var queryString = string.Join("&", queryParams);
                        request = new HttpRequestMessage(method, cMetodo + "?" + queryString);
                    }

                    // Agregar el cuerpo de la solicitud si es necesario
                    if (Body != null)
                    {
                        var json = JsonConvert.SerializeObject(Body);
                        request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    }

                    // Agregar los archivos adjuntos si es necesario
                    if (file != null)
                    {
                        request.Content = file;
                    }

                    var response = client.SendAsync(request).Result;

                    string StatusCode = string.Empty;
                    string Response = string.Empty;
                    string updatedResponse = string.Empty;
                    dynamic jsonObject = null;

                    if(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        Response = response.Content.ReadAsStringAsync().Result;
                        jsonObject = JsonConvert.DeserializeObject(Response);
                        jsonObject.StatusCode = (int)response.StatusCode;
                        updatedResponse = JsonConvert.SerializeObject(jsonObject);
                        result = JsonConvert.DeserializeObject<TResponse>(updatedResponse);
                    }
                    else
                    {
                        MessageBox.Show("La peticion al servidor a fallado: " + response.ReasonPhrase, 
                            "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "API Conciliacion Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return result;
        }
    }
}
