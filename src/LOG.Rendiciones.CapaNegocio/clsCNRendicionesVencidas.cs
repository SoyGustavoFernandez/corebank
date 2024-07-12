using LOG.Rendiciones.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFLogistica.EntityLayer;
using GEN.Funciones;
using System.Net.Mail;
using System.Net;

namespace LOG.Rendiciones.CapaNegocio
{
    public class clsCNRendicionesVencidas
    {
        #region propiedades privadas
        private clsADRendicionesVencidas adRendicionesvencidas;        
        #endregion

        #region constructores
        public clsCNRendicionesVencidas()
        {
            this.adRendicionesvencidas = new clsADRendicionesVencidas();
        }
        #endregion

        #region métodos públicos
        public IList<clsRendicionVencida> obtenerRendicionesVencidas(string cTipoConsulta, int idUsuario)
        {
            DataTable dtRendicionesVencidas = this.adRendicionesvencidas.obtenerRendicionesVencidas(cTipoConsulta, idUsuario);
            return dtRendicionesVencidas.SoftToList<clsRendicionVencida>();
        }

        public clsWCFRespuesta notificarRendicionesVencidas(String cEmailOrigen, String cPassword, int idUsuario)
        {
            clsWCFRespuesta objWCFRespuesta = new clsWCFRespuesta();
            try
            {
                DataTable dtRendicionesVencidas = adRendicionesvencidas.obtenerRendicionesVencidas("detallado", idUsuario);
                if (dtRendicionesVencidas.Rows.Count > 0)
                {
                    DataTable dtNotificaciones = obtenerNotificaciones(dtRendicionesVencidas);

                    foreach (DataRow row in dtNotificaciones.Rows)
                    {
                        enviarCorreo(cEmailOrigen, cPassword, row["cEmailInst"].ToString(), "Notificación de Rendición Pendiente", row["cMensaje"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                objWCFRespuesta.cError = e.Message;
            }
            return objWCFRespuesta;
        }
        #endregion

        #region métodos privados
        private void enviarCorreo(String cEmailOrigen, String cPassword, String cEmailDestino, String cTitle, String cBody)
        {
            MailMessage mail = new MailMessage(cEmailOrigen, cEmailDestino);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;            
            client.Host = "mail.cajalosandes.pe";
            //client.UseDefaultCredentials = true; //Desarrollo
            client.UseDefaultCredentials = false; //Producción
            client.Credentials = new NetworkCredential(cEmailOrigen, cPassword); //Producción
            mail.Subject = cTitle;
            mail.Body = cBody;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        private DataTable agruparDataTable(string cGroupByColumn, string cAggregateColumn, DataTable i_dSourceTable)
        {
            DataView dvGroup = new DataView(i_dSourceTable);
            DataTable dtGroup = dvGroup.ToTable(true, new string[] { cGroupByColumn });
            dtGroup.Columns.Add("nCount", typeof(int));
            dtGroup.Columns.Add("cEmailInst", typeof(string));
            dtGroup.Columns.Add("cMensaje", typeof(string));
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["nCount"] = i_dSourceTable.Compute("Count(" + cAggregateColumn + ")", cGroupByColumn + " = '" + dr[cGroupByColumn] + "'");
            }
            return dtGroup;
        }

        private string obtenerTemplateEmail(String cNombre, String cEntregas)
        {
            return "<html>"
                        + "<head>"
                            + "<title></title>"
                        + "</head>"
                        + "<body style=\"background:#ffffff; font-family:Arial, 'Comic Sans MS',sans-serif; color:#333\">"
                            + "<p>Estimado(a) <b>" + cNombre + "</b></p>"
                            + "<p>La Presente es para indicarle que tiene rendiciones pendientes de:</p>"
                                + "<ul>" + cEntregas + "</ul>"
                            + "<p>Favor de realizar la rendición a la brevedad, de lo contrario se procederá con el descuento respectivo</p>"
                        + "</body>"
                    + "</html>";
        }

        private DataTable obtenerNotificaciones(DataTable dtRendicionesVencidas)
        {
            DataTable dtColaboradores = agruparDataTable("cNombre", "cEmailInst", dtRendicionesVencidas);

            foreach (DataRow rowCol in dtColaboradores.Rows)
            {
                string cEntregas = "";
                foreach (DataRow rowRend in dtRendicionesVencidas.Rows)
                {
                    if (rowRend["cNombre"].ToString() == rowCol["cNombre"].ToString())
                    {
                        cEntregas += "<li>"
                                        + rowRend["cTipoEntrega"].ToString() + " de "
                                        + rowRend["cSimbolo"].ToString() + " "
                                        + rowRend["nMonto"].ToString() + " con "
                                        + rowRend["nDiasAtraso"].ToString() + " días de atraso."
                                    + "</li>";
                        if (rowCol["cEmailInst"].ToString() == "")
                        {
                            rowCol["cEmailInst"] = rowRend["cEmailInst"].ToString();
                        }
                    }

                }
                rowCol["cMensaje"] = obtenerTemplateEmail(rowCol["cNombre"].ToString(), cEntregas);
            }
            return dtColaboradores;
        }      
        #endregion
    }
}
