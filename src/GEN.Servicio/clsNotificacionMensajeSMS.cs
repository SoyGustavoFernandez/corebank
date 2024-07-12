using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Windows.Forms;
using System.Data;
using GEN.CapaNegocio;
using System.Xml.Serialization;
using GEN.Funciones;

namespace GEN.Servicio
{
    public class clsNotificacionMensajeSMS
    {
        private clsCNAdministracionEnvioSMS objAdministracionEnvioSMS { get; set; }
        private clsNotificacionSMS objNotificacionSMS { get; set; }
        private List<clsClienteNotificacionSMS> lstClienteNotificacionSMS { get; set; }
        private int idTipoPlantillaSMS { get; set; }
        private int idTipoMensaje { get; set; }
        private int nPrioridad { get; set; }
        private bool lEnviado { get; set; }

        public clsNotificacionMensajeSMS()
        {
            lstClienteNotificacionSMS = new List<clsClienteNotificacionSMS>();
            idTipoMensaje = 0;
            idTipoPlantillaSMS = 0;
            nPrioridad = 0;
            lEnviado = false;
        }

        public clsNotificacionMensajeSMS(List<clsClienteNotificacionSMS> _lstClienteNotificacionSMS, int _idTipoMensaje, int _idTipoPlantillaSMS, int _nPrioridad, bool _lEnviado = false)
        {
            objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            lstClienteNotificacionSMS = _lstClienteNotificacionSMS;
            idTipoMensaje = _idTipoMensaje;
            idTipoPlantillaSMS = _idTipoPlantillaSMS;
            nPrioridad = _nPrioridad;
        }
        public clsNotificacionMensajeSMS(clsClienteNotificacionSMS _objClienteNotificacionSMS, int _idTipoMensaje, int _idTipoPlantillaSMS, int _nPrioridad, bool _lEnviado = false)
        {
            objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            List<clsClienteNotificacionSMS> lstNotificacion = new List<clsClienteNotificacionSMS>();
            lstNotificacion.Add(_objClienteNotificacionSMS);
            lstClienteNotificacionSMS = lstNotificacion;
            idTipoMensaje = _idTipoMensaje;
            idTipoPlantillaSMS = _idTipoPlantillaSMS;
            nPrioridad = _nPrioridad;
            lEnviado = _lEnviado;
        }

        public bool enviarNotificacionSMSVerificacion()
        {
            foreach(clsClienteNotificacionSMS objNotificacionClienteSMS in lstClienteNotificacionSMS)
            {
                clsRegistroTelefono objRegistroTelefono = objNotificacionClienteSMS.lstRegistroTelefono.Find(item => item.lSeleccionado == true);
                clsServicioSMS objServicioSMS = new clsServicioSMS();

                clsPlantillaSMS objPlantillaSMS = objAdministracionEnvioSMS.CNObtenerDatosPlantillaSMS(clsVarGlobal.User.idAgeCol, clsVarGlobal.User.idEstablecimiento, idTipoPlantillaSMS, objNotificacionClienteSMS.idCliente, objRegistroTelefono.idRegTel);
                if(objPlantillaSMS.idPlantillaSMS == 0)
                {
                    MessageBox.Show("No se tiene registrado una plantilla para el tipo de envio.", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                clsNotificacionSMS objNotificacionSMS = new clsNotificacionSMS();

                objNotificacionSMS.idCliente            = objNotificacionClienteSMS.idCliente;
                objNotificacionSMS.idTipoMensaje        = idTipoMensaje;
                objNotificacionSMS.idRegistro           = objNotificacionClienteSMS.idRegistro;
                objNotificacionSMS.idModulo             = objNotificacionClienteSMS.idModulo;
                objNotificacionSMS.idAgencia            = clsVarGlobal.nIdAgencia;
                objNotificacionSMS.idEstablecimiento    = clsVarGlobal.User.idEstablecimiento;
                objNotificacionSMS.cCodigoValidacion    = objPlantillaSMS.cCodigoValidacion;
                objNotificacionSMS.cNumeroTelefonico    = objRegistroTelefono.cNumeroTelefonico;
                objNotificacionSMS.idNumeroTelefonico   = objRegistroTelefono.idRegTel;
                objNotificacionSMS.cIDMensajeTexto      = String.Empty;
                objNotificacionSMS.cMensajeSMS          = String.Empty;
                objNotificacionSMS.idTipoPlantillaSMS   = idTipoPlantillaSMS;
                objNotificacionSMS.objRegistroTelefono  = objRegistroTelefono;

                string xmlNotificacionSMS = objNotificacionSMS.GetXml();

                DataTable dtResultado = objAdministracionEnvioSMS.CNRegistrarNotificacionIndividualSMS(xmlNotificacionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, lEnviado);

                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != 0)
                    {
                        int idNotificacionSMS = Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]);

                        objPlantillaSMS = objAdministracionEnvioSMS.CNObtenerDatosNotificacionPlantillaSMS(objPlantillaSMS.idPlantillaSMS, idTipoPlantillaSMS, idNotificacionSMS, objNotificacionClienteSMS.idCliente, objRegistroTelefono.idRegTel, objNotificacionClienteSMS.idRegistro);

                        //=================================================================================================
                        objServicioSMS.cMensaje     = objPlantillaSMS.cMensajeTexto;
                        objServicioSMS.cNumero      = objRegistroTelefono.cNumeroTelefonico;
                        objServicioSMS.nPrioridad   = nPrioridad;
                        string cIDCodigoMensaje     = objServicioSMS.enviar();

                        DataTable dtResultadoDetalle = objAdministracionEnvioSMS.CNActualizarDetallesNotificacionSMS(idNotificacionSMS, cIDCodigoMensaje, objPlantillaSMS.cMensajeTexto);
                        //=================================================================================================

                        if (dtResultadoDetalle.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtResultadoDetalle.Rows[0]["idRegistro"]) != 0)
                            {
                                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(Convert.ToString(dtResultadoDetalle.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error durante el registro de los detalles de la notificación, Por favor intentar de nuevo", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante el registro de la notificación, Por favor intentar de nuevo", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
    }
}
