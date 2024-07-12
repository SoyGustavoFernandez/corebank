using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityLayer;
using GEN.ControlesBase;
using WCF.CoreBank.Interface;

namespace WCF.CoreBank.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EnvioSMS" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EnvioSMS.svc or EnvioSMS.svc.cs at the Solution Explorer and start debugging.
    public class EnvioSMS : AbstractConexion, IEnvioSMS
    {
        clsEnvioMensajeTexto obj;

        public clsWCFRespuesta EnvioMensajesTexto(string cToken, clsMensajeTexto objMensaje)
        {
            try
            {
                string cPuerto = "COM5";
                clsConexion oConexion = new clsConexion();
                obj = new clsEnvioMensajeTexto(cPuerto);
                oConexion = obj.Conectar();

                objMensaje.idUsuarioRegistra = 1;
                objMensaje.dFechaRegistro = DateTime.Today;
                objMensaje.idUsuarioEnvio = 0;
                objMensaje.dFechaEnvio = DateTime.Today;
                objMensaje.idTipoMensaje = 1;

                obj.setIntentos(12);

                objMensaje = obj.EnviarMensaje(objMensaje);
                clsWCFRespuesta oRes = new clsWCFRespuesta();

                if (objMensaje.idEstadoEnvio == EstadoEnvioSMS.ENVIADO)
                {
                    oRes.idRespuesta = 1;
                    oRes.cMensaje = "El código de verificación ha sido enviada a su celular";
                }
                else
                {
                    oRes.idRespuesta = 0;
                    oRes.cMensaje = objMensaje.cResultado +" : " +oConexion.cMensaje;
                }
               obj.Desconectar();

                return oRes;

            }
            catch (Exception e)
            {
                clsWCFRespuesta oRes = new clsWCFRespuesta();
                oRes.cMensaje = e.Message;
                return oRes;
            }
          
        }
    }
}
