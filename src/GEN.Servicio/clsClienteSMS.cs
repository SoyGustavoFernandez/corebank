using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using System.Web.Script.Serialization;
using EntityLayer;
using Newtonsoft.Json;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using System.Data;

namespace GEN.Servicio
{
    public class clsServicioSMS
    {
        public const int COLA = 0;
        public const int PROCESANDO = 1;
        public const int ENVIADO = 2;
        public const int ERROR = 3;

        private string cCodigo;
        public string cNumero { get; set; }
        public string cMensaje { get; set; }
        public string cObservacion { get; set; }
        public int nPrioridad { get; set; }
        private int nEstado { get; set; }
        private string cDireccionServicio { get; set; }

        public clsServicioSMS()
        {
            this.cCodigo = "";
            clsVarGen objVarDireccionServicio = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cServicioSMSInfobip"));
            this.cDireccionServicio = Convert.ToString(objVarDireccionServicio.cValVar);
        }

        public clsServicioSMS(string cNumero, string cMensaje, int nPrioridad, string cObservacion = "")
        {
            this.cCodigo = "";
            this.cNumero = cNumero;
            this.cMensaje = cMensaje;
            this.nPrioridad = nPrioridad;
            this.cObservacion = cObservacion;
            clsVarGen objVarDireccionServicio = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cServicioSMSInfobip"));
            this.cDireccionServicio = Convert.ToString(objVarDireccionServicio.cValVar);
        }

        public clsServicioSMS(string cCodigo)
        {
            this.cCodigo = cCodigo;
            clsVarGen objVarDireccionServicio = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cServicioSMSInfobip"));
            this.cDireccionServicio = Convert.ToString(objVarDireccionServicio.cValVar);
            this.obtener();
        }

        private void poner()
        {
            if (this.cCodigo == "")
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["phone"] = this.cNumero;
                    data["content"] = this.cMensaje;
                    data["observation"] = this.cObservacion;
                    data["priority"] = this.nPrioridad.ToString();
                    var response = wb.UploadValues(this.cDireccionServicio, "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    dynamic dobj = jsonSerializer.Deserialize<dynamic>(responseInString);
                    this.cCodigo = dobj["id"].ToString();
                }
            }
        }

        private void obtener()
        {
            if (this.cCodigo == "")
                throw new SmsException("Código SMS vacio");
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                string responseInString = wb.DownloadString(String.Format(this.cDireccionServicio + "{0}", this.cCodigo));
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                dynamic dobj = jsonSerializer.Deserialize<dynamic>(responseInString);
                this.cCodigo = dobj["id"].ToString();
                this.cNumero = dobj["phone"];
                this.cMensaje = dobj["content"];
                this.cObservacion = dobj["observation"];
            }
        }

        public string enviar()
        {
            this.poner();
            return this.cCodigo;
        }

        public int estado()
        {
            if (this.nEstado != ENVIADO && this.nEstado != ERROR)
                this.obtener();
            return this.nEstado;
        }

        /// <summary>
        /// Envía una solicitud de SMS al endpoint especificado y devuelve la respuesta.
        /// </summary>
        /// <param name="clsSmsRequest">Objeto de solicitud de SMS.</param>
        /// <returns>Objeto de respuesta de SMS.</returns>
        public clsSmsResponse EnviarSMS(clsSmsRequest clsSmsRequest)
        {
            clsSmsResponse objResponseSMS = new clsSmsResponse();

            // URL del endpoint
            string endPoint = this.cDireccionServicio;

            // Convertir el objeto de solicitud a JSON
            string jsonRequest = new JavaScriptSerializer().Serialize(clsSmsRequest);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    // Realizar la solicitud POST y obtener la respuesta como bytes
                    byte[] responseBytes = client.UploadData(endPoint, "POST", Encoding.UTF8.GetBytes(jsonRequest));

                    // Convertir los bytes de respuesta a una cadena JSON
                    string jsonResponse = Encoding.UTF8.GetString(responseBytes);

                    // Deserializar la respuesta JSON en un objeto clsSmsResponse
                    objResponseSMS = new JavaScriptSerializer().Deserialize<clsSmsResponse>(jsonResponse);

                }
                catch (Exception ex)
                {
                    objResponseSMS.id = "0";
                    objResponseSMS.phone = clsSmsRequest.phone;
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return objResponseSMS;
        }
        public void GuardarTramaSMS(clsSmsRequest requestSMS, clsSmsResponse responseSMS, int idCli)
        {
            clsNotificacionSMS objNotificacionSMS = new clsNotificacionSMS();

            //TRAER EL ID DEL TELEFONO AL QUE SE ENVIÓ EL SMS
            clsClienteRegistros lstTelefonos = (DataTableToList.ConvertTo<clsClienteRegistros>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(idCli)) as List<clsClienteRegistros>).FirstOrDefault(x => x.cNumeroTelefonico == requestSMS.phone);

            objNotificacionSMS.idCliente = idCli;
            objNotificacionSMS.idTipoMensaje = 5;//NOTIFICACION
            objNotificacionSMS.idRegistro = Convert.ToInt32(responseSMS.id);
            objNotificacionSMS.idModulo = clsVarGlobal.idModulo;
            objNotificacionSMS.idAgencia = clsVarGlobal.nIdAgencia;
            objNotificacionSMS.idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            objNotificacionSMS.cCodigoValidacion = string.Empty;
            objNotificacionSMS.cNumeroTelefonico = responseSMS.phone;
            objNotificacionSMS.idNumeroTelefonico = lstTelefonos.idRegTel;
            objNotificacionSMS.cIDMensajeTexto = responseSMS.id;
            objNotificacionSMS.cMensajeSMS = requestSMS.content;
            objNotificacionSMS.idTipoPlantillaSMS = 0;
            objNotificacionSMS.objRegistroTelefono = new clsRegistroTelefono();

            string xmlNotificacionSMS = objNotificacionSMS.GetXml();

            clsCNAdministracionEnvioSMS objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            DataTable dtResultado = objAdministracionEnvioSMS.CNRegistrarNotificacionIndividualSMS(xmlNotificacionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, true);

        }
    }

    [Serializable]
    public class SmsException : Exception
    {
        public SmsException()
        {
        }

        public SmsException(string cError): base(String.Format("Sms Service Exception: {}", cError))
        {
        }
    }
}
