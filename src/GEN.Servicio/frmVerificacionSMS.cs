using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using System.Data;
using GEN.CapaNegocio;
using CLI.Presentacion;
using GEN.ControlesBase;
using System.Xml.Serialization;
using GEN.Funciones;
using System.Text.RegularExpressions;
using CLI.CapaNegocio;

namespace GEN.Servicio
{
    public partial class frmVerificacionSMS : frmBase
    {
        #region Variables Globales
        public clsRegistroTelefono objRegistroTelefono { get; set; }
        public List<clsRegistroTelefono> lstRegistroTelefono { get; set; }
        public clsCNAdministracionEnvioSMS objAdministracionEnvioSMS { get; set; }
        private clsCNCliente objCNCliente { get; set; }
        public int idTipoMensaje { get; set; }
        public int idTipoPlantillaSMS { get; set; }
        public int idRegistro { get; set; }
        public int idCliente { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCliente { get; set; }
        public bool lExcepcion { get; set; }

        public int idModulo { get; set; }
        public decimal nMontoOperacion { get; set; }
        public int idTipoOperacion { get; set; }
        public int idMoneda { get; set; }
        public int idProducto { get; set; }

        private bool lNumeroNuevo { get; set; }
        private bool lEnviado { get; set; }

        #endregion

        public frmVerificacionSMS()
        {
            InitializeComponent();
            cargarComponentes();
        }

        public frmVerificacionSMS(int _idCliente, string _cDocumentoID, string _cNombreCliente, int _idTipoMensaje, int _idTipoPlantillaSMS, int _idRegistro, int _idModulo, int _idMoneda, decimal _nMontoOperacion, int _idProducto)
        {
            InitializeComponent();

            cargarComponentes(_idCliente, _cDocumentoID, _cNombreCliente, _idTipoMensaje, _idTipoPlantillaSMS, _idRegistro, _idModulo, _idMoneda, _nMontoOperacion, _idProducto);
        }

        #region Eventos
        private void frmVerificacionSMS_Load(object sender, EventArgs e)
        {
            cargarDatosContactoTelefono();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroNumerosTelf frmRegistroTelefono = new frmRegistroNumerosTelf(Convert.ToString(idCliente), cDocumentoID, cNombreCliente);
            frmRegistroTelefono.ShowDialog();
            cargarDatosContactoTelefono();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            enviarMensajeTexto();
        }

        private void btnReenviar_Click(object sender, EventArgs e)
        {
            enviarMensajeTexto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<clsNotificacionSMS> lstNotificacionActiva = objAdministracionEnvioSMS.CNObtenerNotificacionActivas(idCliente, idRegistro, idModulo, idTipoPlantillaSMS);

            if(lstNotificacionActiva.Count == 0)
            {
                MessageBox.Show("No se tiene registrado una notificación de SMS pendiente de confirmación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsNotificacionSMS objNotificacionSMS = lstNotificacionActiva.Find(item => item.idEstadoNotificacionSMS == 1);


            if (objNotificacionSMS.cCodigoValidacion != txtCodigoValidacion.Text)
            {
                MessageBox.Show("El código de validación ingresado no coincide con el código enviado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string cCodigoValidacion = txtCodigoValidacion.Text;
            bool lAutorizarPrincipal = true;
            DataTable dtResultado = objAdministracionEnvioSMS.CNActualizarNotificacionSMS(idCliente, cCodigoValidacion, objRegistroTelefono.cNumeroTelefonico, objNotificacionSMS.idNotificacionSMS, lAutorizarPrincipal, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            
            if(dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    activarControles(AccionFormulario.VALIDADO);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    activarControles(AccionFormulario.ENVIADO);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error durante la validación del código de verificación, Por favor intentar de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                activarControles(AccionFormulario.ENVIADO);
                return;
            }
        }

        #endregion

        #region Metodos
        public void cargarComponentes(int _idCliente, string _cDocumentoID, string _cNombreCliente, int _idTipoMensaje, int _idTipoPlantillaSMS, int _idRegistro, int _idModulo, int _idMoneda, decimal _nMontoOperacion, int _idProducto)
        {
            objRegistroTelefono = new clsRegistroTelefono();
            lstRegistroTelefono = new List<clsRegistroTelefono>();
            objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            objCNCliente        = new clsCNCliente();
            idCliente           = _idCliente;
            cDocumentoID        = _cDocumentoID;
            cNombreCliente      = _cNombreCliente;
            idTipoMensaje       = _idTipoMensaje;
            idTipoPlantillaSMS  = _idTipoPlantillaSMS;
            idRegistro          = _idRegistro;
            idModulo            = _idModulo;
            idMoneda            = _idModulo;
            nMontoOperacion     = _nMontoOperacion;
            idProducto          = _idProducto;
            lExcepcion          = false;
            lNumeroNuevo        = false;
            lEnviado            = false;

            DataTable dtTipoOperador = objAdministracionEnvioSMS.CNObtenerTipoOperador();
            cboTipoOperador.DataSource = dtTipoOperador;
            cboTipoOperador.DisplayMember = dtTipoOperador.Columns["cTipoOperador"].ColumnName;
            cboTipoOperador.ValueMember = dtTipoOperador.Columns["idTipoOperador"].ColumnName;
        }

        public void cargarComponentes()
        {
            objRegistroTelefono = new clsRegistroTelefono();
            lstRegistroTelefono = new List<clsRegistroTelefono>();
            objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            objCNCliente        = new clsCNCliente();
            idCliente           = 0;
            cDocumentoID        = String.Empty;
            cNombreCliente      = String.Empty;
            idTipoMensaje       = 0;
            idTipoPlantillaSMS  = 0;
            lExcepcion          = false;

            DataTable dtTipoOperador = objAdministracionEnvioSMS.CNObtenerTipoOperador();
            cboTipoOperador.DataSource = dtTipoOperador;
            cboTipoOperador.DisplayMember = dtTipoOperador.Columns["cTipoOperador"].ColumnName;
            cboTipoOperador.ValueMember = dtTipoOperador.Columns["idTipoOperador"].ColumnName;

        }

        public void recuperarDatosTelefonoCliente()
        {
            lstRegistroTelefono                 = objAdministracionEnvioSMS.CNObtenerTelefonoCliente(idCliente);
            BindingSource bsRegistroTelefono    = new BindingSource();
            bsRegistroTelefono.DataSource       = lstRegistroTelefono;

            cboNumeroEnvioSMS.DataSource        = bsRegistroTelefono.DataSource;
            cboNumeroEnvioSMS.DisplayMember     = "cDetalleNumero";
            cboNumeroEnvioSMS.ValueMember       = "idRegTel";
        }

        public void cargarDatosContactoTelefono()
        {
            objCNCliente.CNPrepararDatosTelefono(idCliente);

            recuperarDatosTelefonoCliente();
            activarControles(AccionFormulario.RECUPERADO);
        }

        private void activarControles(AccionFormulario eAccionformulario)
        {
            if(idTipoMensaje == 4)
            {
                switch (eAccionformulario)
                {
                    case AccionFormulario.DEFECTO:
                        this.chcAutorizarPrincipal.Enabled  = true;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = true;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = true;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        break;
                    case AccionFormulario.RECUPERADO:
                        this.chcAutorizarPrincipal.Enabled  = true;
                        this.grbSeleccionNumero.Enabled     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbRegistrarNumero.Enabled     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = true;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        break;
                    case AccionFormulario.ENVIADO:
                        this.chcAutorizarPrincipal.Enabled  = false;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = true;
                        this.btnSolExcepcion.Visible        = (lExcepcion) ? true : false ;
                        this.btnSolExcepcion.Enabled        = (lExcepcion) ? true : false ;
                        this.btnEnviar.Enabled              = false;
                        this.btnReenviar.Enabled            = true;
                        this.btnAceptar.Enabled             = true;
                        break;
                    case AccionFormulario.VALIDADO:
                        this.chcAutorizarPrincipal.Enabled  = false;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true ;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = false;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        break;
                }
            }
            else if (idTipoMensaje == 5)
            {
                switch (eAccionformulario)
                {
                    case AccionFormulario.DEFECTO:
                        this.chcAutorizarPrincipal.Enabled  = true;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = true;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = false;
                        this.pnlValidacion.Enabled          = false;
                        this.pnlValidacion.Visible          = false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = true;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        this.btnAceptar.Visible             = false;
                        break;
                    case AccionFormulario.RECUPERADO:
                        this.chcAutorizarPrincipal.Enabled  = true;
                        this.grbSeleccionNumero.Enabled     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbRegistrarNumero.Enabled     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.pnlValidacion.Enabled          = false;
                        this.pnlValidacion.Visible          = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = true;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        this.btnAceptar.Visible             = false;
                        break;
                    case AccionFormulario.ENVIADO:
                        this.chcAutorizarPrincipal.Enabled  = false;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = true;
                        this.pnlValidacion.Enabled          = false;
                        this.pnlValidacion.Visible          = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = false;
                        this.btnReenviar.Enabled            = true;
                        this.btnAceptar.Enabled             = false;
                        this.btnAceptar.Visible             = false;
                        break;
                    case AccionFormulario.VALIDADO:
                        this.chcAutorizarPrincipal.Enabled  = false;
                        this.grbSeleccionNumero.Enabled     = false;
                        this.grbSeleccionNumero.Visible     = (chcAutorizarPrincipal.Checked) ? false : true ;
                        this.grbRegistrarNumero.Enabled     = false;
                        this.grbRegistrarNumero.Visible     = (chcAutorizarPrincipal.Checked) ? true : false;
                        this.txtCodigoValidacion.Enabled    = false;
                        this.btnSolExcepcion.Visible        = false;
                        this.btnSolExcepcion.Enabled        = false;
                        this.btnEnviar.Enabled              = false;
                        this.btnReenviar.Enabled            = false;
                        this.btnAceptar.Enabled             = false;
                        break;
                }
            }
            
        }

        private bool validar()
        {
            if(!chcAutorizarPrincipal.Checked)
            {
                if (lstRegistroTelefono.Count == 0)
                {
                    MessageBox.Show("El cliente no tiene un número telefónico de contacto registrado. Actualizar su número telefónico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (cboNumeroEnvioSMS.SelectedIndex == -1)
                {
                    MessageBox.Show("No se seleccionó el número telefónico al cual enviar el mensaje de confirmación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {

                string cCadena = this.txtNumeroTelefonico.Text;
                Regex patronCelular = new Regex("^[9][0-9]{8}$");
                Match matchCel = patronCelular.Match(cCadena);

                if (cboTipoOperador.SelectedIndex == -1)
                {
                    MessageBox.Show("No se seleccionó el tipo de operador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (String.IsNullOrWhiteSpace(txtNumeroTelefonico.Text))
                {
                    MessageBox.Show("No se ha ingresado un número telefónico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (Convert.ToString(cCadena) == "999999999")
                {
                    MessageBox.Show("No es un número válido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (!matchCel.Success)
                {
                    MessageBox.Show("EL número telefónico no tiene el formato correcto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (!lNumeroNuevo && lstRegistroTelefono.Any(item => item.cNumeroTelefonico == txtNumeroTelefonico.Text.Trim() && item.idRegTel != 0))
                {
                    MessageBox.Show("Ya se tiene registrado el número ingresado. Desmarque la opción \"Registrar nuevo número telefónico principal\" y seleccione el número correcto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        public void enviarMensajeTexto()
        {
            if (!validar())
            {
                return;
            }

            clsRegistroTelefono objRegistroTelefonoSeleccionado = new clsRegistroTelefono();
            objRegistroTelefonoSeleccionado = (cboNumeroEnvioSMS.SelectedIndex != -1) ? (clsRegistroTelefono)cboNumeroEnvioSMS.SelectedItem : new clsRegistroTelefono();

            recuperarDatosTelefonoCliente();

            string cNumeroTelefono = txtNumeroTelefonico.Text;
            if (chcAutorizarPrincipal.Checked && !lstRegistroTelefono.Any(item => item.cNumeroTelefonico == cNumeroTelefono))
            {
                objRegistroTelefonoSeleccionado.idRegTel             = 0;
                objRegistroTelefonoSeleccionado.idCli                = idCliente;
                objRegistroTelefonoSeleccionado.cDocumentoID         = cDocumentoID;
                objRegistroTelefonoSeleccionado.cNumeroTelefonico    = cNumeroTelefono;
                objRegistroTelefonoSeleccionado.cDetalleNumero       = String.Empty;
                objRegistroTelefonoSeleccionado.idCodTelFijo         = 0;
                objRegistroTelefonoSeleccionado.idTipoTelefono       = 1;
                objRegistroTelefonoSeleccionado.idCondicionTelf      = 2;
                objRegistroTelefonoSeleccionado.lVigente             = true;
                objRegistroTelefonoSeleccionado.lNumeroValidado      = false;
                objRegistroTelefonoSeleccionado.lSeleccionado        = true;
                objRegistroTelefonoSeleccionado.idTipoOperador       = Convert.ToInt32(cboTipoOperador.SelectedValue);
                objRegistroTelefonoSeleccionado.cTipoOperador        = String.Empty;

                lstRegistroTelefono.Add(objRegistroTelefonoSeleccionado);
                lNumeroNuevo = true;
            }
            else
            {
                cboNumeroEnvioSMS.SelectedValue = objRegistroTelefonoSeleccionado.idRegTel;
            }

            clsClienteNotificacionSMS objClienteNotificacionSMS = new clsClienteNotificacionSMS();
            objClienteNotificacionSMS.idCliente = idCliente;
            objClienteNotificacionSMS.cDocumentoID = cDocumentoID;
            objClienteNotificacionSMS.cNombreCompleto = cNombreCliente;
            objClienteNotificacionSMS.idRegistro = idRegistro;
            objClienteNotificacionSMS.idModulo = idModulo;
            if(chcAutorizarPrincipal.Checked)
            {
                objClienteNotificacionSMS.lstRegistroTelefono = lstRegistroTelefono.Select(item => { item.lSeleccionado = (item.cNumeroTelefonico == cNumeroTelefono) ? true : item.lSeleccionado; return item; }).ToList<clsRegistroTelefono>();
            }
            else
            {
                objClienteNotificacionSMS.lstRegistroTelefono = lstRegistroTelefono.Select(item => { item.lSeleccionado = (item.idRegTel == objRegistroTelefonoSeleccionado.idRegTel) ? true : item.lSeleccionado; return item; }).ToList<clsRegistroTelefono>();
            }
           
            clsNotificacionMensajeSMS objNotificacionSMS = new clsNotificacionMensajeSMS(objClienteNotificacionSMS, idTipoMensaje, idTipoPlantillaSMS, 90, lEnviado);
            bool lEnvioCorrecto = objNotificacionSMS.enviarNotificacionSMSVerificacion();
            if (lEnvioCorrecto)
            {
                lExcepcion = true;
                lEnviado = true;
                activarControles(AccionFormulario.ENVIADO);
            }
            else
            {
                activarControles(AccionFormulario.RECUPERADO);
            }
        }
        #endregion

        #region Enumeradores
        private enum AccionFormulario
        {
            DEFECTO         = 0,
            RECUPERADO      = 1,
            ENVIADO         = 2,
            VALIDADO        = 3
        }
        #endregion

        private void btnSolExcepcion_Click(object sender, EventArgs e)
        {
            List<clsNotificacionSMS> lstNotificacionesActivas = new List<clsNotificacionSMS>();
            clsCNAdministracionEnvioSMS objAdministracionEnvioSMS = new clsCNAdministracionEnvioSMS();
            lstNotificacionesActivas = objAdministracionEnvioSMS.CNObtenerNotificacionActivas(idCliente, idRegistro, 1, idTipoPlantillaSMS);

            clsNotificacionSMS objNotificacionSMS = lstNotificacionesActivas.Find(item => item.idEstadoNotificacionSMS.In(1));
            int idTipoOperacionSMS = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeExcepcionNotificacionSMS"]);

            frmSolicitudExcepcionSMS frmSolExcepcionSMS = new frmSolicitudExcepcionSMS(objNotificacionSMS,idMoneda,nMontoOperacion, idProducto, idTipoOperacionSMS);
            frmSolExcepcionSMS.ShowDialog();
            if(frmSolExcepcionSMS.lAcepta)
            {
                this.Dispose();
            }
        }

        private void chcAutorizarPrincipal_CheckedChanged(object sender, EventArgs e)
        {
            if(chcAutorizarPrincipal.Checked)
            {
                grbSeleccionNumero.Enabled = false;
                grbSeleccionNumero.Visible = false;
                grbRegistrarNumero.Enabled = true;
                grbRegistrarNumero.Visible = true;
            }
            else
            {
                grbSeleccionNumero.Enabled = true;
                grbSeleccionNumero.Visible = true;
                grbRegistrarNumero.Enabled = false;
                grbRegistrarNumero.Visible = false;
            }
        }
    }
}