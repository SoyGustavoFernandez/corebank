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
using EntityLayer;
using GEN.CapaNegocio;
#endregion

namespace GEN.Servicio
{
    public partial class frmRegistroCodigoVerificacion : frmBase
    {
        #region Variables Globales
        private clsNotificacionSMS objNotificacionSMS { get; set; }
        private clsCNAdministracionEnvioSMS objAdministracionEnvioSMS { get; set; }
        public bool lNotificacionValida { get; set; }
        public bool lExcepcion { get; set; }

        public int idMoneda { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idProducto { get; set; }
        #endregion
        public frmRegistroCodigoVerificacion()
        {
            InitializeComponent();
        }

        public frmRegistroCodigoVerificacion(clsNotificacionSMS _objNotificacionSMS, int _idMoneda, decimal _nMontoOperacion, int _idProducto)
        {
            InitializeComponent();
            cargarComponente(_objNotificacionSMS, _idMoneda, _nMontoOperacion, _idProducto );
        }

        #region Metodos
        public void cargarComponente(clsNotificacionSMS _objNotificacionSMS, int _idMoneda, decimal _nMontoOperacion, int _idProducto )
        {
            objNotificacionSMS          = _objNotificacionSMS;
            objAdministracionEnvioSMS   = new clsCNAdministracionEnvioSMS();
            lNotificacionValida         = false;
            lExcepcion                  = true;
            idMoneda                    = _idMoneda;
            nMontoOperacion             = _nMontoOperacion;
            idProducto                  = _idProducto;
        }

        public void cargarDatosNotificacion()
        {
            lblNumeroTelefono.Text = objNotificacionSMS.cNumeroTelefonico;
        }

        public bool validar()
        {
            if(String.IsNullOrWhiteSpace(txtCodigoValidacion.Text))
            {
                MessageBox.Show("El código de validación no puede estar vacío.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToString(txtCodigoValidacion.Text).Length != 6)
            {
                MessageBox.Show("El código de validación es de 6 dígitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtCodigoValidacion.Text != objNotificacionSMS.cCodigoValidacion)
            {
                MessageBox.Show("El código de validación ingresado no coincide con el código enviado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Eventos
        private void frmRegistroCodigoVerificacion_Load(object sender, EventArgs e)
        {
            cargarDatosNotificacion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            string cCodigoValidacion = Convert.ToString(txtCodigoValidacion.Text);
            bool lAtualizarPrincipal = true;
            DataTable dtResultado = objAdministracionEnvioSMS.CNActualizarNotificacionSMS(objNotificacionSMS.idCliente, cCodigoValidacion, objNotificacionSMS.cNumeroTelefonico, objNotificacionSMS.idNotificacionSMS, lAtualizarPrincipal, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                {
                    lNotificacionValida = true;
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    lNotificacionValida = false;
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            else
            {
                lNotificacionValida = false;
                MessageBox.Show("Ocurrió un error durante la validación del código de verificación, Por favor intentar de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void btnSolExcepcion_Click(object sender, EventArgs e)
        {
            int idTipoOperacionSMS = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeExcepcionNotificacionSMS"]);

            frmSolicitudExcepcionSMS frmSolExcepcionSMS = new frmSolicitudExcepcionSMS(objNotificacionSMS, idMoneda, nMontoOperacion, idProducto, idTipoOperacionSMS);
            frmSolExcepcionSMS.ShowDialog();
            if (frmSolExcepcionSMS.lAcepta)
            {
                lNotificacionValida = true;
                this.Close();
            }
        }
        #endregion


    }
}
