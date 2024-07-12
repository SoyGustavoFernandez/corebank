using CLI.CapaNegocio;
using CLI.Servicio;
using EntityLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConBusPersonaConServicios : UserControl
    {
        #region Variables
        public event EventHandler ehEncontrado;
        public event EventHandler ehCancelar;
        private int _idRegistro = 0;
        private bool _lEncontrado = false;
        private clsCNCliente objCNCliente = new clsCNCliente();
        private FuenteDatos fuenteDatos = FuenteDatos.Manual;
        #endregion
        #region Propiedades 
        public bool lModoEdicion { get; set; } = false;
        public bool lConsiderarRUC { get; set; } = true;
        public bool lCliente
        {
            get { return !chcNoCliente.Checked; }
        }
        public bool lEncontrado
        {
            get { return _lEncontrado; }
        }
        public int idRegistro
        {
            get { return _idRegistro; }
        }
        public int idCliente
        {
            get { return (lCliente) ? _idRegistro : 0; }
        }
        public int idTipoDocumento
        {
            get { return Convert.ToInt32(cboTipoDocumento.SelectedValue); }
        }
        public int idTipoPersonaBusqueda
        {
            get { return cboTipoDocumento.idTipoPersonaBusqueda; }
        }
        public string cNumeroDocumento
        {
            get { return txtNumeroDocumento.Text.Trim(); }
        }
        public string cNombre
        {
            get { return txtNombre.Text.Trim(); }
        }
        public string cDireccion
        {
            get { return txtDireccion.Text.Trim(); }
        }
        public string cCelular
        {
            get { return txtCelular.Text.Trim(); }
        }
        #endregion
        #region Constructor
        public ConBusPersonaConServicios()
        {
            InitializeComponent();
        }
        #endregion
        #region Métodos privados
        private void Limpiar()
        {
            _lEncontrado = false;
            _idRegistro = 0;
            cboTipoDocumento.SelectedValue = 1;
            chcNoCliente.Checked = false;
            txtCelular.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumeroDocumento.Text = string.Empty;
            txtNumeroDocumento.Focus();
        }
        private bool validarDocumento()
        {
            return (cboTipoDocumento.nTamanoMinimo <= txtNumeroDocumento.TextLength &&
                cboTipoDocumento.nTamanoMaximo >= txtNumeroDocumento.TextLength);
        }
        private bool buscarCliente()
        {
            DataTable dt = objCNCliente.CNBuscarCliente(idTipoDocumento, txtNumeroDocumento.Text);
            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = dt.Rows[0]["cNombre"].ToString();
                txtDireccion.Text = dt.Rows[0]["cDireccion"].ToString();
                _idRegistro = Convert.ToInt32(dt.Rows[0]["idCli"].ToString());
                chcNoCliente.Checked = false;
                if (dt.Rows[0]["cNumeroTelefono1"].ToString().Length > 0)
                    txtCelular.Text = dt.Rows[0]["cNumeroTelefono1"].ToString();
                else if (dt.Rows[0]["cNumeroTelefono2"].ToString().Length > 0)
                    txtCelular.Text = dt.Rows[0]["cNumeroTelefono2"].ToString();
                else
                    txtCelular.Text = dt.Rows[0]["cNumeroTelefono3"].ToString();
                fuenteDatos = FuenteDatos.Si_FinCliente;
                txtDireccion.Focus();
                return true;
            }
            else
                return false;
        }
        private bool buscarNoCliente()
        {
            DataTable dt = objCNCliente.CNBuscarNoCliente(idTipoDocumento, txtNumeroDocumento.Text);
            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = dt.Rows[0]["cNombres"].ToString();
                txtDireccion.Text = dt.Rows[0]["cDireccion"].ToString();
                txtCelular.Text = dt.Rows[0]["cTelefono"].ToString();
                _idRegistro = Convert.ToInt32(dt.Rows[0]["idNoCliente"].ToString());
                fuenteDatos = FuenteDatos.Si_FinNoCliente;
                chcNoCliente.Checked = true;
                txtDireccion.Focus();
                return true;
            }
            else
                return false;
        }
        private bool buscarReniec()
        {
            clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(txtNumeroDocumento.Text, clsVarGlobal.User.idUsuario, 1);
            clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);

            clsReniec obj = new clsReniec(objParam, objReniec);

            var objCliente = obj.GetReniec();
            if (objCliente != null)
            {
                if(objCliente.cErrorF == "0000")
                {
                    txtNombre.Text = objCliente.cApellidoPater.Trim() + " " + objCliente.cApellidoMater.Trim() + " " + objCliente.cNombres.Trim();
                    txtDireccion.Text = objCliente.cDireccion.Trim();
                    txtCelular.Text = "";
                    _idRegistro = 0;
                    fuenteDatos = FuenteDatos.Reniec;
                    chcNoCliente.Checked = true;
                    return true;
                }
                else
                {
                    MessageBox.Show("La persona no logró ser encontrada, ingrese de forma manual sus nombres, dirección y celular", "Busqueda en Reniec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chcNoCliente.Checked = true;
                    return false;
                }                
            }
            else
            {
                MessageBox.Show("La persona no logró ser encontrada, ingrese de forma manual sus nombres, dirección y celular", "Busqueda en Reniec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chcNoCliente.Checked = true;
                return false;
            }
        }
        private bool buscarSunat()
        {
            try
            {
                DataTable dt = new clsCNCliente().CNBuscarTablaSunat(txtNumeroDocumento.Text);
                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0]["cNombre"].ToString();
                    txtDireccion.Text = dt.Rows[0]["cDireccion"].ToString();
                    chcNoCliente.Checked = true;
                    _idRegistro = 0;
                    if (dt.Rows[0]["cTelefono1"].ToString().Length > 0)
                        txtCelular.Text = dt.Rows[0]["cTelefono1"].ToString();
                    else if (dt.Rows[0]["cTelefono2"].ToString().Length > 0)
                        txtCelular.Text = dt.Rows[0]["cTelefono2"].ToString();
                    else
                        txtCelular.Text = dt.Rows[0]["cTelefono3"].ToString();
                    fuenteDatos = FuenteDatos.Sunat;
                    txtDireccion.Focus();
                    return true;
                }
                else
                {
                    MessageBox.Show("La persona no logró ser encontrada, ingrese de forma manual su razón social, dirección y celular", "Busqueda en Sunat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chcNoCliente.Checked = true;
                    return false;
                }
            }
            catch {
                MessageBox.Show("La persona no logró ser encontrada, ingrese de forma manual su razón social, dirección y celular", "Busqueda en Sunat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chcNoCliente.Checked = true;
                return false;
            }
            
        }
        private void habilitar(int idTipoHabilitacion)
        {
            if (lModoEdicion)
                switch (idTipoHabilitacion)
                {
                    case 0://Default
                        cboTipoDocumento.Enabled = false;
                        txtNumeroDocumento.Enabled = false;
                        txtNombre.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDireccion.Enabled = false;
                        btnMiniCancelar.Enabled = false;
                        btnBusqueda.Enabled = false;
                        break;
                    case 1://inicio
                        cboTipoDocumento.Enabled = true;
                        txtNumeroDocumento.Enabled = true;
                        txtNombre.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDireccion.Enabled = false;
                        btnMiniCancelar.Enabled = false;
                        btnBusqueda.Enabled = true;
                        break;
                    case 2://encontrado
                        cboTipoDocumento.Enabled = false;
                        txtNumeroDocumento.Enabled = false;
                        txtNombre.Enabled = !(txtNombre.Text.Trim().Length > 0);
                        txtCelular.Enabled = true;
                        txtDireccion.Enabled = true;
                        btnMiniCancelar.Enabled = true;
                        btnBusqueda.Enabled = false;
                        break;
                }
            else
                switch (idTipoHabilitacion)
                {
                    case 0://Default
                        cboTipoDocumento.Enabled = false;
                        txtNumeroDocumento.Enabled = false;
                        txtNombre.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDireccion.Enabled = false;
                        btnMiniCancelar.Enabled = false;
                        btnBusqueda.Enabled = false;
                        break;
                    case 1://inicio
                        cboTipoDocumento.Enabled = true;
                        txtNumeroDocumento.Enabled = true;
                        txtNombre.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDireccion.Enabled = false;
                        btnMiniCancelar.Enabled = false;
                        btnBusqueda.Enabled = true;
                        break;
                    case 2://encontrado
                        cboTipoDocumento.Enabled = false;
                        txtNumeroDocumento.Enabled = false;
                        txtNombre.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDireccion.Enabled = false;
                        btnMiniCancelar.Enabled = false;
                        btnBusqueda.Enabled = false;
                        break;
                }
        }
        private void buscarPersona()
        {
            if(lModoEdicion)
            {
                if (!buscarCliente())
                    if (!buscarNoCliente())
                    {
                        if (idTipoDocumento == 1)
                            buscarReniec();
                        else if (idTipoDocumento == 4)
                            buscarSunat();
                        else
                        {
                            MessageBox.Show("La persona no logró ser encontrada, ingrese de forma manual sus nombres, dirección y celular", "Busqueda de persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chcNoCliente.Checked = true;
                        }
                    }
                _lEncontrado = true;
                habilitar(2);
            }
            else
            {
                _lEncontrado = true;
                if (!buscarCliente())
                    if (!buscarNoCliente())
                    {
                        MessageBox.Show("La persona no logró ser encontrada, intentelo nuevamente", "Busqueda de persona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reiniciar();
                        txtNumeroDocumento.Focus();
                        _lEncontrado = false;
                    }                
            }
            
        }
        #endregion
        #region Métodos públicos
        public void Reiniciar()
        {
            Limpiar();
            habilitar(1);
        }
        public void setDireccion(string _cDireccion)
        {
            txtDireccion.Text = _cDireccion;
        }
        public void setCelular(string _cCelular)
        {
            txtCelular.Text = _cCelular;
        }
        public void FocusDireccion()
        {
            txtDireccion.Focus();
        }
        public void FocusNombre()
        {
            txtNombre.Focus();
        }
        public void FocusCelular()
        {
            txtCelular.Focus();
        }
        public void FocusNumeroDocumento()
        {
            txtCelular.Focus();
        }
        public bool ActualizarNoCliente()
        {
            if (lModoEdicion)
                if (!lCliente)
                {
                    clsNoCliente objNoCliente = new clsNoCliente
                    {
                        idNoCliente = _idRegistro,
                        idTipoDocumento = idTipoDocumento,
                        cNroDocumento = cNumeroDocumento,
                        cNombres = cNombre,
                        cDireccion = cDireccion,
                        cCelular = cCelular
                    };
                    DataTable dtResultado = objCNCliente.CNRegistroActualizacionNoCliente(objNoCliente);
                    if (dtResultado.Rows.Count > 0)
                    {
                        int _idNoCliente = Convert.ToInt32(dtResultado.Rows[0]["idNoCliente"]);
                        if (_idNoCliente > 0)
                        {
                            _idRegistro = _idNoCliente;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show(dtResultado.Rows[0]["cMensage"].ToString(), "Actualización de no cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            return false;
                        }

                    }
                    return false;
                }
                else
                    return true;
            else
            {
                MessageBox.Show("El control no se encuentra en modo edición", "Actualización de no cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion
        #region Eventos
        private void ConBusPersonaConServicios_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.cargarParaFiltroNumerado(lConsiderarRUC);
            habilitar(1);
            txtNumeroDocumento.Focus();
            Limpiar();
            chcNoCliente.Enabled = false;
        }
        private void cboTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (cboTipoDocumento.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar elemento válido");
                    this.Focus();
                }
                else
                {
                    txtNumeroDocumento.MaxLength = cboTipoDocumento.nTamanoMaximo;
                    txtNumeroDocumento.Focus();
                    cboTipoDocumento.SelectionLength = 0;
                }
            }

        }
        private void cboTipoDocumento_Leave(object sender, EventArgs e)
        {
            cboTipoDocumento.SelectionLength = 0;
        }
        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (validarDocumento())
                {
                    buscarPersona();
                    if (ehEncontrado != null)
                        ehEncontrado(sender, e);
                }
            }
        }
        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento.SelectedValue == null)
            {
                MessageBox.Show("Debe ingresar un número de documento válido");
                this.Focus();
            }
            else
            {
                txtNumeroDocumento.MaxLength = cboTipoDocumento.nTamanoMaximo;
                txtNumeroDocumento.Focus();
            }
        }
        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cboTipoDocumento.lAlfanumerico)
            {
                if (e.KeyChar == 8)
                    e.Handled = false;
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar == 8)
                    e.Handled = false;
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar >= 65 && e.KeyChar <= 90)
                    e.Handled = false;
                else if (e.KeyChar >= 97 && e.KeyChar <= 122)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (validarDocumento())
            {
                buscarPersona();
                if (ehEncontrado != null)
                    ehEncontrado(sender, e);
            }
        }
        private void btnMiniCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            habilitar(1);
            if (ehCancelar != null)
                ehCancelar(sender, e);
        }
        #endregion
        #region Enums
        private enum FuenteDatos
        {
            Si_FinCliente = 1,
            Si_FinNoCliente = 2,
            Reniec = 3,
            Sunat = 4,
            Manual = 5
        }
        #endregion
    }
}
