#region Referencias
using System;
using System.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using ADM.CapaNegocio;
using EntityLayer;
using EntityLayer.Bus.Response;
using Newtonsoft.Json;
#endregion

namespace REN.Servicio
{
    public class clsConsultaCliente
    {
        #region Variable Globales
        private string cUrlLogin;
        private string cUrlConsulta;
        private string cToken;
        private string cUsuario;
        private string cClave;
        private int nTiempoCaducidad;
        private DateTime dCaducidad;
        private clsCNMantenimiento objVariable;
        #endregion

        #region Metodos
        public clsConsultaCliente()
        {
            this.cUrlLogin = clsVarApl.dicVarGen["cUrlBusLogin"];
            this.cUrlConsulta = clsVarApl.dicVarGen["cUrlBusConsultaCliente"];
            this.cUsuario = clsVarApl.dicVarGen["cBusUsuario"];
            this.cClave = clsVarApl.dicVarGen["cBusClave"];
            this.nTiempoCaducidad = Convert.ToInt32(clsVarApl.dicVarGen["nBusTiempoCaducidad"]);
            this.objVariable = new clsCNMantenimiento();
            this.dCaducidad = DateTime.Now.AddSeconds(-this.nTiempoCaducidad);
        }
        public int Autenticacion()
        {
            DataTable dtVariable = this.objVariable.CNRecuperarVariable("cBusToken");
            string cTokenVal = "";
            if (dtVariable.Rows.Count > 0)
            {
                cTokenVal = dtVariable.Rows[0]["cValVar"].ToString();
            }
            string[] cParametro = cTokenVal.Split(';');
            if(cParametro.Length == 2)
            {
                cToken = cParametro[1];
                if (DateTime.TryParse(cParametro[0], out DateTime dCaducidadVal))
                {
                    this.dCaducidad = dCaducidadVal;
                }
            }
            DateTime dActual = DateTime.Now;
            if ((dActual.Year == this.dCaducidad.Year && dActual.Month == this.dCaducidad.Month && dActual.Day == this.dCaducidad.Day))
            {
                double tmp1 = dActual.Subtract(this.dCaducidad).TotalMinutes;
                double tmp2 = this.dCaducidad.Subtract(dActual).TotalMinutes;
                if (this.dCaducidad.Subtract(dActual).TotalMinutes > 0)
                {
                    return 1;
                }
            }
            using (WebClient objWebClient = new WebClient())
            {
                objWebClient.Credentials = new NetworkCredential(this.cUsuario, this.cClave);
                objWebClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                string cPostData = "grant_type=password";
                byte[] bPost = Encoding.UTF8.GetBytes(cPostData);
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                try
                {
                    byte[] bResponse = objWebClient.UploadData(this.cUrlLogin + "?grant_type=client_credentials", "POST", bPost);
                    string cResponse = Encoding.UTF8.GetString(bResponse);

                    clsBusLogin objRespBus = JsonConvert.DeserializeObject<clsBusLogin>(cResponse);
                    if(string.IsNullOrEmpty(objRespBus.error))
                    {
                        this.cToken = objRespBus.access_token;
                        this.objVariable.CNActualizarValorVariables("cBusToken", $"{dActual.AddSeconds(nTiempoCaducidad)};{cToken}");
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public clsBusConsultaCliente Consulta(string idTipoDoc, string cDocumentoID, string idUsuario)
        {
            using (WebClient objWebClient = new WebClient())
            {
                objWebClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                objWebClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + this.cToken);
                string cData = $"?tipoIdentificacion={idTipoDoc}&numeroDocumento={cDocumentoID}&usuario={idUsuario}";
                System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                try
                {
                    byte[] bResponse = objWebClient.DownloadData(this.cUrlConsulta+cData);
                    string cResponse = Encoding.UTF8.GetString(bResponse);

                    clsBusConsultaCliente objRespBus = JsonConvert.DeserializeObject<clsBusConsultaCliente>(cResponse);
                    if (objRespBus.success == 1)
                    {
                        return objRespBus;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (WebException ex)
                {
                    if(ex.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.Unauthorized)
                        this.objVariable.CNActualizarValorVariables("cBusToken", "");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        #endregion
    }
}
