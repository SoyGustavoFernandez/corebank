#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using GEN.Funciones;
using EntityLayer;
using System.IO;
#endregion


namespace GEN.Servicio
{
    public partial class frmSolicitudExcepcionSMS : frmBase
    {
        #region Variables Globales
        public int idExcepcionNotificacionSMS { get; set; }
        public string cMensaje { get; set; }
        public bool lAcepta { get; set; }
        public int idMotivo { get; set; }
        public string cMotivo { get; set; }
        public clsCNAdministracionEnvioSMS objCNAdminsitracionEnvioSMS { get; set; }
        public clsCNAprobacion objCNAprobacion { get; set; }
        public clsNotificacionSMS objNotificacionSMS { get; set; }

        public int idProducto { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idMoneda { get; set; }
        public int idTipoOperacion { get; set; }
        #endregion
        #region Contructor
        public frmSolicitudExcepcionSMS()
        {
            InitializeComponent();
            cargarComponentes();
        }

        public frmSolicitudExcepcionSMS(int _idExcepcionNotificacionSMS)
        {
            InitializeComponent();
            this.idExcepcionNotificacionSMS = _idExcepcionNotificacionSMS;
            objCNAdminsitracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            objCNAprobacion = new clsCNAprobacion();
            objNotificacionSMS = new clsNotificacionSMS();
            cargarComponentes();
        }

        public frmSolicitudExcepcionSMS(clsNotificacionSMS _objNotificacionSMS, int _idMoneda, decimal _nMontoOperacion, int _idProducto, int _idTipoOperacion)
        {
            InitializeComponent();
            objNotificacionSMS = _objNotificacionSMS;
            objCNAdminsitracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            objCNAprobacion = new clsCNAprobacion();
            this.idProducto = _idProducto;
            this.idMoneda = _idMoneda;
            this.nMontoOperacion = _nMontoOperacion;
            this.idTipoOperacion = _idTipoOperacion;
            cargarComponentes();
        }
        #endregion

        #region Metodo

        private void cargarComponentes()
        {
            DataTable dtMotivoExcepcionSMS = objCNAdminsitracionEnvioSMS.CNObtenerMotivoExcepcionSMS();

            cboMotivoExcepcionSMS.DataSource = dtMotivoExcepcionSMS;
            cboMotivoExcepcionSMS.ValueMember = dtMotivoExcepcionSMS.Columns["idMotivoExcepcionSMS"].ColumnName;
            cboMotivoExcepcionSMS.DisplayMember = dtMotivoExcepcionSMS.Columns["cMotivoExcepcionSMS"].ColumnName;

            cboMotivoExcepcionSMS.SelectedIndex = -1;
        }

        private bool validar()
        {
            if (Convert.ToInt32(this.cboMotivoExcepcionSMS.SelectedIndex) == -1)
            {
                MessageBox.Show("Seleccione un motivo de excepción", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtSustentoExcepcionSMS.Text))
            {
                MessageBox.Show("Ingrese sustento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool validarUsuario()
        {
            frmCredenciales frmCred = new frmCredenciales(clsVarGlobal.User.lAutBiometricaAgencia);
            frmCred.cWinUser = clsVarGlobal.User.cWinUser;
            frmCred.idMonedaApro = idMoneda;
            frmCred.idProductoApro = idProducto;
            frmCred.nMontoApro = nMontoOperacion;
            frmCred.ShowDialog();

            if (!frmCred.lValido)
            {
                MessageBox.Show("No se ha logrado autenticar al usuario", "Autenticación de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Evento

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            if(!validarUsuario())
            {
                return;
            }

            string cExcepcionNotificacionSMS    = Convert.ToString(txtSustentoExcepcionSMS.Text);
            int idCliente                       = objNotificacionSMS.idCliente;
            int idNotificacionSMS               = objNotificacionSMS.idNotificacionSMS;
            int idRegistroTelefonico            = objNotificacionSMS.idNumeroTelefonico;
            string cNumeroTelefonico            = objNotificacionSMS.cNumeroTelefonico;
            int idEstadoSolicitud               = 1;
            int idMotivoExcepcionNotifiacionSMS = Convert.ToInt32(cboMotivoExcepcionSMS.SelectedValue);
            int idUsuario                       = clsVarGlobal.User.idUsuario;
            DateTime dFechaSistema              = clsVarGlobal.dFecSystem;
            int idAgencia                       = clsVarGlobal.User.idAgeCol;

            DataTable dtResultado = objCNAprobacion.CNRegistrarExcepcionNotificacionSMS(cExcepcionNotificacionSMS, idCliente, idNotificacionSMS, idRegistroTelefonico,
                                                                                        cNumeroTelefonico, idEstadoSolicitud, idMotivoExcepcionNotifiacionSMS, idUsuario, dFechaSistema,
                                                                                        idAgencia, idTipoOperacion, this.idMoneda, this.nMontoOperacion,
                                                                                        this.idProducto);

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.lAcepta = true;

            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Está seguro de cancelar la solicitud de excepción de notificación por SMS?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.No)
            {
                return;
            }

            this.Dispose();
        }
        #endregion
    }
}
