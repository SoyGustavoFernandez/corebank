using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using System.Windows.Forms;

namespace GEN.Servicio
{
    public class clsAdministracionEnvioSMS
    {
        private clsCNAdministracionEnvioSMS objCNAdministracionEnvioSMS { get; set; }
        private List<clsClienteNotificacionSMS> lstClienteNotificacionSMS { get; set; }
        private List<clsNotificacionSMS> lstNotificacionesActivas { get; set; }
        private clsNotificacionMensajeSMS objNotificacionMensajeSMS { get; set; }
        private clsCNAprobacion objCNAprobacion { get; set; }

        public int idTipoPlantillaSMS { get; set; }
        public int idTipoMensaje { get; set; }
        public int nPrioridad { get; set; }

        public int idRegistro { get; set; }
        public int idTipoOperacion { get; set; }

        public int idMoneda { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idProducto { get; set; }
        public int idModulo { get; set; }

        public bool lTipoPlantillaActiva { get; set; }
        public bool lTipoOperacionCargado { get; set; }
        public bool lExcepcionEjecutada { get; set; }

        public clsAdministracionEnvioSMS()
        {
            objCNAdministracionEnvioSMS     = new clsCNAdministracionEnvioSMS();
            objNotificacionMensajeSMS       = new clsNotificacionMensajeSMS();
            lstClienteNotificacionSMS       = new List<clsClienteNotificacionSMS>();
            lstNotificacionesActivas        = new List<clsNotificacionSMS>();
            objCNAprobacion                 = new clsCNAprobacion();

            idTipoPlantillaSMS      = 0;
            idTipoMensaje           = 0;
            nPrioridad              = 0;
            idRegistro              = 0;
            idMoneda                = 0;
            nMontoOperacion         = 0;
            idProducto              = 0;
            idTipoOperacion         = 0;
            idModulo                = 0;
            lTipoPlantillaActiva    = false;
            lTipoOperacionCargado   = false;
            lExcepcionEjecutada     = false;
            cargarDatosGenerales();
        }

        public void cargarDatosGenerales()
        {
            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("idTipoOpeExcepcionNotificacionSMS")))
            {
                clsVarGen objVarTipoOperacion = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("idTipoOpeExcepcionNotificacionSMS"));
                idTipoOperacion = Convert.ToInt32(objVarTipoOperacion.cValVar);

                lTipoOperacionCargado = (clsVarGlobal.lisVars.Any(item => item.cVariable == "idTipoOpeExcepcionNotificacionSMS")) ? true : false;
            }
            else
            {
                lTipoOperacionCargado = false; 
            }
        }

        public void cargarPlantillaPlanPagos()
        {
            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("idTipoPSMSPlanPagos")))
            {
                clsVarGen objVarTipoPlantilla = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("idTipoPSMSPlanPagos"));
                idTipoPlantillaSMS = Convert.ToInt32(objVarTipoPlantilla.cValVar);

                DataTable dtTipoPlantillaSMS = objCNAdministracionEnvioSMS.CNObtenerTipoPlantillaSMS(idTipoPlantillaSMS);
                lTipoPlantillaActiva = (dtTipoPlantillaSMS.Rows.Count > 0) ? Convert.ToBoolean(dtTipoPlantillaSMS.Rows[0]["lVigente"]) : false;
                idTipoMensaje = (dtTipoPlantillaSMS.Rows.Count > 0) ? Convert.ToInt32(dtTipoPlantillaSMS.Rows[0]["idTipoMensaje"]) : 4;
            }
            else
            {
                lTipoPlantillaActiva = false;
                idTipoPlantillaSMS = 0;
            }
        }

        public void cargarDatosPlantilla(int _idTipoPlantilla)
        {
            if (_idTipoPlantilla != 0)
            {
                idTipoPlantillaSMS = _idTipoPlantilla;

                DataTable dtTipoPlantillaSMS = objCNAdministracionEnvioSMS.CNObtenerTipoPlantillaSMS(idTipoPlantillaSMS);
                lTipoPlantillaActiva = (dtTipoPlantillaSMS.Rows.Count > 0) ? Convert.ToBoolean(dtTipoPlantillaSMS.Rows[0]["lVigente"]) : false;
                idTipoMensaje = (dtTipoPlantillaSMS.Rows.Count > 0) ? Convert.ToInt32(dtTipoPlantillaSMS.Rows[0]["idTipoMensaje"]) : 4;
            }
            else
            {
                lTipoPlantillaActiva = false;
                idTipoPlantillaSMS = 0;
                idTipoMensaje = 0;
            }
        }
        public void cargarDatosOperacion(int _idRegistro, int _idMoneda, decimal _nMontoOperacion, int _idProducto, int _idModulo)
        {
            this.idRegistro                     = _idRegistro;
            this.idMoneda                       = _idMoneda;
            this.nMontoOperacion                = _nMontoOperacion;
            this.idProducto                     = _idProducto;
            this.idModulo                       = _idModulo;
            this.lstClienteNotificacionSMS      = objCNAdministracionEnvioSMS.CNObtenerIntervinientesNotificacionSMS(idRegistro, idModulo);
        }

        public bool validarNotificacionSMS()
        {
            if (!(clsVarGlobal.User.lVerificacionSMS && lTipoPlantillaActiva))
                return true;

            lstNotificacionesActivas.Clear();
            lstNotificacionesActivas = objCNAdministracionEnvioSMS.CNObtenerNotificacionActivas(0, idRegistro, idModulo, idTipoPlantillaSMS);
            int nTotalNotificaciones = lstNotificacionesActivas.Count;


            #region Verificacion de Numero Telefonico
            if (!lstNotificacionesActivas.Any(item => item.idEstadoNotificacionSMS.In(1, 3)) || lstNotificacionesActivas.Count == 0)
            {
                MessageBox.Show("VERIFICAR: Número de Contacto Cliente \"Celular\".", "Validar Contacto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            #endregion

            if (lstNotificacionesActivas.Any(item => item.idEstadoNotificacionSMS.In(3)))
            {
                return true;
            }
            else if (lstNotificacionesActivas.Any(item => item.idEstadoNotificacionSMS.In(1)))
            {
                List<clsNotificacionSMS> lstNotificacionActivaPendientes = lstNotificacionesActivas.Where(item => item.idEstadoNotificacionSMS.In(1)).ToList<clsNotificacionSMS>();

                foreach(clsNotificacionSMS objNotificacionSMS in lstNotificacionActivaPendientes)
                {
                    DataTable dtSolicitudExcepcion = objCNAprobacion.CNConsultarSolicitudExcepNotificacionSMS(objNotificacionSMS.idCliente, objNotificacionSMS.idNotificacionSMS, idTipoOperacion);

                    if (dtSolicitudExcepcion.Rows.Count > 0)
                    {
                        int idEstadoSolExcepcionSMS = Convert.ToInt32(dtSolicitudExcepcion.Rows[0]["idEstadoSol"]);

                        if (idEstadoSolExcepcionSMS == 2)
                        {
                            int idSolAproba = Convert.ToInt32(dtSolicitudExcepcion.Rows[0]["idSolAproba"]);
                            int idExcepcionNotificacionSMS = Convert.ToInt32(dtSolicitudExcepcion.Rows[0]["idExcepcionNotificacionSMS"]);
                            DataTable dtResultadoEjecucion = objCNAprobacion.CNEjecutarSolicitudExcepNotificacionSMS(idSolAproba, idExcepcionNotificacionSMS, objNotificacionSMS.idNotificacionSMS, idEstadoSolExcepcionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                            if (dtResultadoEjecucion.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtResultadoEjecucion.Rows[0]["idRegistro"]) != 1)
                                {
                                    MessageBox.Show(Convert.ToString(dtResultadoEjecucion.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    lExcepcionEjecutada = false;
                                }
                                else
                                {
                                    MessageBox.Show(Convert.ToString(dtResultadoEjecucion.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lstNotificacionesActivas = lstNotificacionesActivas.Select(item => { item.idEstadoNotificacionSMS = 3; return item; }).ToList();
                                    lExcepcionEjecutada = true;
                                    return true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ocurrío un error al ejecutar la excepción de Notificación por SMS", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lExcepcionEjecutada = false;
                            }
                            
                        }
                        else if (idEstadoSolExcepcionSMS == 1)
                        {
                            MessageBox.Show("Se tiene una solicitud de Excepción de Notificacion por SMS pendiente de aprobación", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lExcepcionEjecutada = false;
                        }
                        else if (idEstadoSolExcepcionSMS == 4)
                        {
                            int idSolAproba = Convert.ToInt32(dtSolicitudExcepcion.Rows[0]["idSolAproba"]);
                            int idExcepcionNotificacionSMS = Convert.ToInt32(dtSolicitudExcepcion.Rows[0]["idExcepcionNotificacionSMS"]);
                            DataTable dtResultadoEjecucion = objCNAprobacion.CNEjecutarSolicitudExcepNotificacionSMS(idSolAproba, idExcepcionNotificacionSMS, objNotificacionSMS.idNotificacionSMS, idEstadoSolExcepcionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                            if(dtResultadoEjecucion.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtResultadoEjecucion.Rows[0]["idRegistro"]) != 1)
                                {
                                    MessageBox.Show(Convert.ToString(dtResultadoEjecucion.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    lExcepcionEjecutada = false;
                                }
                                else
                                {
                                    MessageBox.Show("La solicitud de excepción fue rechazada solicite una notificación por SMS nuevamente.", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    lExcepcionEjecutada = false;
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ocurrío un error al ejecutar la excepción de Notificación por SMS", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                lExcepcionEjecutada = true;
                            }
                        }
                    }
                    else
                    {
                        lExcepcionEjecutada = false;
                    }

                    if (!lExcepcionEjecutada)
                    {
                        frmRegistroCodigoVerificacion frmCodigoVerificacion = new frmRegistroCodigoVerificacion(objNotificacionSMS, idMoneda, nMontoOperacion, idProducto);
                        frmCodigoVerificacion.ShowDialog();

                        bool lCodigoVerificacionValidado = frmCodigoVerificacion.lNotificacionValida;

                        if (!lCodigoVerificacionValidado)
                        {
                            MessageBox.Show("Se tiene un mensaje de verificación de SMS pendiente de confirmación.", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        else
                        {
                            lstNotificacionesActivas = lstNotificacionesActivas.Select(item => { item.idEstadoNotificacionSMS = 3; return item; }).ToList();
                            return true;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public void ejecutarNotificacionSMS()
        {
            #region Verificacion SMS
            if (!(clsVarGlobal.User.lVerificacionSMS && lTipoPlantillaActiva))
                return;

            if (lstNotificacionesActivas.Any(item => item.idEstadoNotificacionSMS.In(3)))
            {
                clsNotificacionSMS objNotificacionConfirmada = lstNotificacionesActivas.Find(item => item.idEstadoNotificacionSMS.In(3));
                DataTable dtEjecucion = objCNAdministracionEnvioSMS.CNRegistrarEjecucionNotificacionSMS(objNotificacionConfirmada.idNotificacionSMS, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                if (dtEjecucion.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtEjecucion.Rows[0]["idRegistro"]) != 0)
                    {
                        MessageBox.Show(Convert.ToString(dtEjecucion.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtEjecucion.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la confirmación de la operación", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            #endregion
        }

        public void asociarNotificacionKardex(int idKardex, bool lNotificacion = true)
        {
            if (!(clsVarGlobal.User.lVerificacionSMS && lTipoPlantillaActiva))
                return;

            DataTable dtResultado = objCNAdministracionEnvioSMS.CNActualizacionNotificacionKardexSMS(this.idRegistro, this.idModulo, this.idTipoPlantillaSMS, idKardex, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != 0)
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error en la asociación de la notificación de SMS con la operación", "Notificación por SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void registrarNotificacion()
        {
            foreach (clsClienteNotificacionSMS objClienteSMS in lstClienteNotificacionSMS)
            {
                frmVerificacionSMS frmVerificacionSMS = new frmVerificacionSMS(objClienteSMS.idCliente, objClienteSMS.cDocumentoID, objClienteSMS.cNombreCompleto, idTipoMensaje, idTipoPlantillaSMS, objClienteSMS.idRegistro, idModulo, idMoneda, nMontoOperacion, idProducto);
                frmVerificacionSMS.ShowDialog();
            }
        }

        public void limpiarCompleto()
        {
            objCNAdministracionEnvioSMS     = new clsCNAdministracionEnvioSMS();
            objNotificacionMensajeSMS       = new clsNotificacionMensajeSMS();
            lstClienteNotificacionSMS       = new List<clsClienteNotificacionSMS>();
            lstNotificacionesActivas        = new List<clsNotificacionSMS>();
            objCNAprobacion                 = new clsCNAprobacion();

            idTipoPlantillaSMS      = 0;
            idTipoMensaje           = 0;
            nPrioridad              = 0;
            idRegistro              = 0;
            idMoneda                = 0;
            nMontoOperacion         = 0;
            idProducto              = 0;
            idTipoOperacion         = 0;
            idModulo                = 0;
            lTipoPlantillaActiva    = false;
            lTipoOperacionCargado   = false;
            lExcepcionEjecutada     = false;
        }

        public void limpiarOperacion()
        {
            idRegistro              = 0;
            idMoneda                = 0;
            nMontoOperacion         = 0;
            idProducto              = 0;
            lExcepcionEjecutada     = false;
        }
    }
}
