using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNServicioCorreo
    {
        /// <summary>
        /// Método que realiza el envío de correo electrónicos
        /// </summary>
        /// <param name="cMailDestino">Lista de correos de destino</param>
        /// <param name="cAsuntoMensaje">Asunto del mensaje</param>
        /// <param name="cCuerpoMensaje">Contenido del mensaje</param>
        /// <returns>si cumple con el envío retorna true</returns>
        public bool enviarMensaje(List<string> cMailDestino,string cAsuntoMensaje, string cCuerpoMensaje)
        {
            try
            {
                if (cMailDestino.Count > 0)
                {
                    string cSmtpCliente = clsVarApl.dicVarGen["cSmtpCliente"];
                    string cCorreoGen = clsVarApl.dicVarGen["cCorreoGen"];
                    string cCorreoNombre = clsVarApl.dicVarGen["cCorreoNombre"];
                    string cPassCorreo = clsVarApl.dicVarGen["cPassCorreo"];
                    string cConfidencialidadMsg = clsVarApl.dicVarGen["cConfidencialidadMsg"];
                    int nPuertoSmtpCliente = clsVarApl.dicVarGen["nPuertoSmtpCliente"];

                    cCuerpoMensaje = cCuerpoMensaje + "<br> <br>" + cConfidencialidadMsg;

                    SmtpClient smtpcliente = new SmtpClient(cSmtpCliente, nPuertoSmtpCliente);
                    smtpcliente.UseDefaultCredentials = false;
                    NetworkCredential credenciales = new NetworkCredential(cCorreoGen, cPassCorreo);
                    smtpcliente.Credentials = credenciales;

                    MailAddress mensajeDE = new MailAddress(cCorreoGen, cCorreoNombre);
                    MailMessage mensaje = new MailMessage();

                    mensaje.From = mensajeDE;
                    foreach (string item in cMailDestino)
                    {
                        mensaje.To.Add(new MailAddress(item));
                    }
                    mensaje.Priority = MailPriority.High;
                    mensaje.Subject = cAsuntoMensaje;
                    mensaje.SubjectEncoding = Encoding.UTF8;
                    mensaje.Body = cCuerpoMensaje;
                    mensaje.BodyEncoding = Encoding.UTF8;
                    mensaje.IsBodyHtml = true;

                    smtpcliente.Send(mensaje);
                    return true;
                }

                return false;
            }
            catch (SmtpException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que realiza el envío de correo electrónicos con archivos adjuntos
        /// </summary>
        /// <param name="cMailDestino"></param>
        /// <param name="cAsuntoMensaje"></param>
        /// <param name="cCuerpoMensaje"></param>
        /// <param name="cMailCCDestino"></param>
        /// <param name="listAdjuntos"></param>
        /// <returns></returns>
        public bool enviarMensaje(List<string> cMailDestino, string cAsuntoMensaje, string cCuerpoMensaje, List<string> listAdjuntos, List<string> cMailCCDestino = null)
        {
            try
            {
                if (cMailDestino.Count > 0)
                {
                    string cSmtpCliente = clsVarApl.dicVarGen["cSmtpCliente"];
                    string cCorreoGen = clsVarApl.dicVarGen["cCorreoGen"];
                    string cCorreoNombre = clsVarApl.dicVarGen["cCorreoNombre"];
                    string cPassCorreo = clsVarApl.dicVarGen["cPassCorreo"];
                    string cConfidencialidadMsg = clsVarApl.dicVarGen["cConfidencialidadMsg"];
                    int nPuertoSmtpCliente = clsVarApl.dicVarGen["nPuertoSmtpCliente"];

                    cCuerpoMensaje = cCuerpoMensaje + "<br> <br>" + cConfidencialidadMsg;

                    SmtpClient smtpcliente = new SmtpClient(cSmtpCliente, nPuertoSmtpCliente);
                    smtpcliente.Host = cSmtpCliente;
                    smtpcliente.UseDefaultCredentials = false;
                    NetworkCredential credenciales = new NetworkCredential(cCorreoGen, cPassCorreo);
                    smtpcliente.Credentials = credenciales;

                    MailAddress mensajeDE = new MailAddress(cCorreoGen, cCorreoNombre);
                    MailMessage mensaje = new MailMessage
                    {
                        From = mensajeDE
                    };

                    if (cMailDestino != null)
                    {
                    foreach (string item in cMailDestino)
                    {
                        mensaje.To.Add(new MailAddress(item));
                    }
                    }

                    if (cMailCCDestino != null && cMailCCDestino.Count > 0)
                    {
                        foreach (string item in cMailCCDestino)
                        {
                            mensaje.CC.Add(new MailAddress(item));
                        }
                    }

                    if (listAdjuntos != null && listAdjuntos.Count > 0)
                    {
                        foreach (string cAdjunto in listAdjuntos)
                        {
                            if (System.IO.File.Exists(cAdjunto))
                                mensaje.Attachments.Add(new Attachment(cAdjunto));
                        }
                    }
                    
                    mensaje.Priority = MailPriority.High;
                    mensaje.Subject = cAsuntoMensaje;
                    mensaje.SubjectEncoding = Encoding.UTF8;
                    mensaje.Body = cCuerpoMensaje;
                    mensaje.BodyEncoding = Encoding.UTF8;
                    mensaje.IsBodyHtml = true;

                    smtpcliente.EnableSsl = true;

                    smtpcliente.Send(mensaje);
                    smtpcliente.Dispose();
                    return true;
                }

                return false;
            }
            catch (SmtpException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
