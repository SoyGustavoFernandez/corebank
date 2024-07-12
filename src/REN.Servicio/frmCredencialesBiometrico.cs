using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using CLI.Servicio;
using EntityLayer;

namespace CLI.Servicio
{
    public partial class frmCredencialesBiometrico : Form
    {

        #region Variables Globales
        clsCNUsuarioSistema Usuario = new clsCNUsuarioSistema();
        public bool lValido = false;
        public string cWinUser = string.Empty;
        private int nNroCar = 6;

        public int idMonedaApro = 0;
        public int idProductoApro = 0;
        public decimal nMontoApro = 0.00m;
        private bool lAutenticacionBiometrica { get; set; }
        public bool lMostrarMensaje { get; set; }
        public string cMensaje { get; set; }
        #endregion

        #region Constructores
        public frmCredencialesBiometrico()
        {
            InitializeComponent();
        }

        public frmCredencialesBiometrico(bool _lAutenticacionBiometrica = false)
        {
            InitializeComponent();
            lAutenticacionBiometrica = _lAutenticacionBiometrica;
            lMostrarMensaje = false;
            cMensaje = String.Empty;
            if (_lAutenticacionBiometrica)
            {
                txtContraseña.Enabled = false;
                btnAceptar.Enabled = false;
                btnHuellDig.Enabled = true;
            }
        }

        #endregion

        #region Eventos
        private void frmCredencialesBiometrico_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = cWinUser;
            if (lAutenticacionBiometrica)
            {
                this.ActiveControl = null;
                btnHuellDig.Focus();
                btnHuellDig.Select();
            }
            else
            {
                txtContraseña.Focus();
                txtContraseña.Select();
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AutenticarUser(new clsAutenticarLogin());
        }

        private void btnHuellDig_Click(object sender, EventArgs e)
        {
            AutenticarUser(new clsAutenticarHuellas());
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (this.txtContraseña.Text.Length >= nNroCar)
            {
                this.btnAceptar.Enabled = true;
                txtContraseña.ForeColor = System.Drawing.Color.Blue;
            }

            else
            {
                this.btnAceptar.Enabled = false;
                txtContraseña.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtContraseña.Text.Trim().Length >= nNroCar && e.KeyCode == Keys.Enter)
            {
                AutenticarUser(new clsAutenticarLogin());
            }
        }
        #endregion

        #region Metodos
        private void ValidarCredenciales(IAutenticable _IAutenticable)
        {
            if (_IAutenticable == null)
                return;

            if (_IAutenticable is clsAutenticarLogin)
            {
                ((clsAutenticarLogin)_IAutenticable).cUser = txtUsuario.Text.Trim();
                ((clsAutenticarLogin)_IAutenticable).cPass = txtContraseña.Text.Trim();
            }

            if (_IAutenticable is clsAutenticarHuellas)
            {
                lValido = AutenticarUserBiometrico();
                if (!lValido)
                {
                    clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("lBioColaboradorAlt"));
                    bool lBioColaboradorAlt = (objVarGen.cValVar == "1") ? true : false;
                    if (lBioColaboradorAlt)
                    {
                        txtContraseña.Enabled = true;
                        btnAceptar.Enabled = true;
                        txtContraseña.Focus();
                    }
                    return;
                }
                else
                {
                    lValido = true;
                    this.Dispose();
                    return;
                }
            }

            if (!_IAutenticable.Autenticar())
            {
                txtContraseña.Text = "";
                txtUsuario.Focus();
                return;
            }
            lValido = true;
            this.Dispose();
        }

        private void AutenticarUser(IAutenticable _IAutenticable)
        {
            if(lMostrarMensaje)
            {
                MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            try
            {
                ValidarCredenciales(_IAutenticable);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Error error = new Error();
                error.cNomForGen = this.Name;
                error.cNomModGen = ex.Source;
                error.cNomObjGen = ex.TargetSite.Name;
                error.cTipErrGen = "02";
                error.nLinGenErr = ex.LineNumber;
                error.cDesErrGen = ex.Message;
                new clsCNError().RegistrarError(error);
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.cNomForGen = this.Name;
                error.cNomModGen = ex.Source;
                error.cNomObjGen = ex.TargetSite.Name;
                error.cTipErrGen = "01";
                error.nLinGenErr = 0;
                error.cDesErrGen = ex.Message;
                new clsCNError().RegistrarError(error);
            }
        }

        private bool AutenticarUserBiometrico()
        {
            clsCNUsuario objUsuario = new clsCNUsuario();
            clsUsuario objUsuarioAutenticado = objUsuario.SeleccionarDatUsu(cWinUser);

            if (clsVarGlobal.User.lAutBiometricaAgencia)
            {
                DataTable dtUsuarioBiometrico = objUsuario.ObtenerDatosClienteBiometrico(objUsuarioAutenticado.idCli);

                var listFirmantes = dtUsuarioBiometrico.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                        .OrderBy(x => Convert.ToInt32(x["idCli"]));

                int idTipoOperacionExcepcion = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoColaborador"]);
                clsBiometrico objBiometrico = new clsBiometrico();
                objBiometrico.lColaborador = true;
                if (!objBiometrico.validacionBiometrica(listFirmantes, idMonedaApro, idProductoApro, nMontoApro, idTipoOperacionExcepcion))
                {
                    MessageBox.Show("No se logró la autenticación biométrica del colaborador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
