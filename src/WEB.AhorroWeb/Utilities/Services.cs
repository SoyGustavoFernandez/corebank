using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using WEB.AhorroWeb.Models;
using System.Web.Script.Serialization;
using ADM.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio.AhorroWeb;

namespace WEB.AhorroWeb.Utilities
{
    public class Services
    {
        #region Variables Privadas
        private clsCNMantenimiento objCNMantenimiento;
        private clsCNAWPreApertura objCNAWPreApertura;
        private clsCNAWApertura objCNAWApertura;
        private clsCNAWGeneral objCNAWGeneral;
        #endregion

        #region Constructores
        public Services(bool lConexion)
        {
            this.objCNMantenimiento = new clsCNMantenimiento();
            this.objCNAWGeneral = new clsCNAWGeneral(true);
        }
        #endregion

        #region Métodos Públicos
        public clsAWConsultaReniec consultarReniec(string cNroDni, int idUsuario)
        {
            clsAWConsultaReniec objAWConsultaReniec = new clsAWConsultaReniec();
            clsAWPersonaReniec objAWPersonaReniec = null;                                    
            try
            {
                clsAWVariable objAWVariable = this.objCNAWGeneral.obtenerVariable("cServicioWCFRen");
                string cServicio = objAWVariable.cValVar;
                string cDocAutorizado = this.objCNAWGeneral.obtenerDocumentoAutorizado(1);
                string cIdUsu = idUsuario.ToString();
                string cCodEmp = "LD2089";
                string cIdConsultaDirecta = "1";
                string dicto = "{\"cNroDni\":\"" + cNroDni + "\",\"cDocAutorizado\":\"" + cDocAutorizado + "\",\"cCodEmp\":\"" + cCodEmp + "\",\"cIdUsu\":\"" + cIdUsu + "\",\"cIdConsultaDirecta\":\"" + cIdConsultaDirecta + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;                            

                string serviceURL = string.Format(cServicio + "/ConsultaIndInfPerReniec");
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                Stream stream = new MemoryStream(response);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(clsAWPersonaReniec));
                obj = new DataContractJsonSerializer(typeof(clsAWPersonaReniec));
                objAWPersonaReniec = obj.ReadObject(stream) as clsAWPersonaReniec;
                objAWConsultaReniec.objAWPersonaReniec = objAWPersonaReniec;
            }
            catch (Exception e)
            {
                objAWConsultaReniec.idRespuesta = 0;
                objAWConsultaReniec.cRespuesta = "Excepción Consulta Reniec: " + e.ToString();                
            }
            return objAWConsultaReniec;
        }

        public clsAWRespuesta consultarPersona(clsAWTramite objAWTramite)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);

            this.objCNAWPreApertura.objAWLog = this.objCNAWGeneral.obtenerLog(objAWTramite.cDocumentoID);
            try
            {
                clsAWConsultaReniec objAWConsultaReniec = this.consultarReniec(objAWTramite.cDocumentoID, objAWTramite.idUsuario);
                if (objAWConsultaReniec.idRespuesta == 0)
                {
                    objAWRespuesta.respuestaFallida("reniec");
                    this.objCNAWPreApertura.registrarFallo("Consulta Reniec: " + objAWConsultaReniec.cRespuesta);
                    return objAWRespuesta;
                }
                objAWRespuesta.datos = objAWConsultaReniec.objAWPersonaReniec;
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("reniec");
                this.objCNAWPreApertura.registrarFallo("Excepción Consultar Persona Reniec: " + e.ToString());
            }
            return objAWRespuesta;
        }  

        public clsAWEnvioSMS envioSMS(Double numero, string mensaje)
        {
            clsAWEnvioSMS objAWEnvioSMS = new clsAWEnvioSMS();
            try
            {
                clsAWVariable objAWVariable = this.objCNAWGeneral.obtenerVariable("cServicioSMSInfobip");
                string cServicio = objAWVariable.cValVar;
                string dicto = "{\"phone\":" + numero + ",\"content\":\"" + mensaje + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto); //Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                
                response = webClient.UploadData(cServicio, "POST", bBytes);
                Stream stream = new MemoryStream(response);
                DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(RespuestaSMS));
                obj = new DataContractJsonSerializer(typeof(RespuestaSMS));
                var resService = obj.ReadObject(stream) as RespuestaSMS;
                if (String.IsNullOrEmpty(resService.id))
                {
                    objAWEnvioSMS.idRespuesta = 0;                    
                }
            }
            catch (Exception e)
            {
                objAWEnvioSMS.idRespuesta = 0;
                objAWEnvioSMS.cRespuesta = e.ToString();
            }
            return objAWEnvioSMS;
        }

        public clsAWRespuesta enviarCodigoValidacion(clsAWTramite objAWTramite)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWPreApertura = new clsCNAWPreApertura(true, objAWTramite);            

            clsAWLog objAWLog = this.objCNAWGeneral.obtenerLog(objAWTramite.cDocumentoID);
            string dFechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string cMensajeSMS = "Caja Los Andes S.A. - Apertura de Cuenta en Linea - " + dFechaHora + " - CODIGO DE VALIDACION: " + objAWLog.cCodigoValidacion;
            clsAWEnvioSMS objAWEnvioSMS = this.envioSMS(Double.Parse(objAWTramite.cNumeroCelular1), cMensajeSMS);
            if (objAWEnvioSMS.idRespuesta == 0)
            {                
                objAWRespuesta.respuestaFallida("sms");
                objCNAWPreApertura.objAWLog = objAWLog;
                objCNAWPreApertura.registrarFallo("Enviar Código de Validación: " + objAWEnvioSMS.cRespuesta);
                return objAWRespuesta;
            }
            return objAWRespuesta;
        }

        public clsAWRespuesta enviarMensajeConfirmacion(clsAWTramite objAWTramite, clsAWRegistrarOperacion objAWRegistrarOperacion)
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            this.objCNAWApertura = new clsCNAWApertura(true, objAWTramite);             
            try
            {
                clsAWLog objAWLog = this.objCNAWGeneral.obtenerLog(objAWTramite.cDocumentoID);
                this.objCNAWApertura.objAWLog = objAWLog;
                string dFechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                string cMensajeSMS = objAWRegistrarOperacion.cPrimerNombre + ", bienvenid@ a Caja Los Andes!, recuerda que antes de utilizar tu cuenta " + objAWTramite.cProducto + " deberas regularizar la documentacion en nuestras oficinas.";
                clsAWEnvioSMS objAWEnvioSMS = this.envioSMS(Double.Parse(objAWTramite.cNumeroCelular1), cMensajeSMS);
                if (objAWEnvioSMS.idRespuesta == 0)
                {
                    objAWRespuesta.respuestaFallida("smsconfirmacion");                    
                    this.objCNAWApertura.registrarFallo("Enviar Mensaje de Confirmación: " + objAWEnvioSMS.cRespuesta);                    
                }
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("smsconfirmacion");
                this.objCNAWApertura.registrarFallo("Excepción Contratar Cuenta (Enviar Mensaje Confirmación): " + e.ToString());                
            }
            return objAWRespuesta;
        }
        #endregion
    }
}