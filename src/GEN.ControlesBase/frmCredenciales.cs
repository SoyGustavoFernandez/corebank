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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GEN.CapaNegocio;
using CLI.Servicio;

namespace GEN.ControlesBase
{
    public partial class frmCredenciales : frmBase
    {

        #region Variables Globales

        clsCNUsuarioSistema Usuario = new clsCNUsuarioSistema();
        public bool lValido = false;
        public string cWinUser = string.Empty;
        private int nNroCar = 6;

        public int idMonedaApro = 0;
        public int idProductoApro = 0;
        public decimal nMontoApro = 0.00m;

        private bool lAutenticacionBiometrica = false;
        private bool lAutenticacionComite = false;

        public bool lUsuAutBiometrico = false;

        private string cNombreOficina;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = cWinUser;
            txtContraseña.Focus();
            txtContraseña.Select();
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

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmCredenciales()
        {
            InitializeComponent();
        }

        public frmCredenciales(bool _lAutenticacionBiometrica = false)
        {
            InitializeComponent();
            if(_lAutenticacionBiometrica)
            {
                lAutenticacionBiometrica = _lAutenticacionBiometrica;
                txtContraseña.Enabled = false;
                btnAceptar.Enabled = false;
                btnHuellDig.Enabled = true;
            }
        }

        public frmCredenciales(bool _lAutenticacionBiometrica = false, bool _lAutenticacionComite = false)
        {
            InitializeComponent();
            this.pnlMensajeInvitacion.Visible = false;
            if (_lAutenticacionComite)
            {
                lAutenticacionBiometrica = _lAutenticacionBiometrica;
                lAutenticacionComite = _lAutenticacionComite;
                txtContraseña.Enabled = false;
                btnAceptar.Enabled = false;
                btnHuellDig.Enabled = true;
            }
        }

        public frmCredenciales(string cNombreOficina, bool _lAutenticacionBiometrica = false, bool _lAutenticacionComite = false, bool lValidaMensaje = true)
        {
            InitializeComponent();
            this.cNombreOficina = cNombreOficina;
            this.txtMensajeInvitacion.Text = cNombreOficina;
            this.pnlMensajeInvitacion.Visible = lValidaMensaje;
            if (_lAutenticacionComite)
            {
                lAutenticacionBiometrica = _lAutenticacionBiometrica;
                lAutenticacionComite = _lAutenticacionComite;
                txtContraseña.Enabled = false;
                btnAceptar.Enabled = false;
                btnHuellDig.Enabled = true;
            }
        }

        private void ValidarCredenciales(IAutenticable _IAutenticable)
        {
            if(_IAutenticable == null)
                return;

            if (_IAutenticable is clsAutenticarLogin)
            {
                ((clsAutenticarLogin)_IAutenticable).cUser = txtUsuario.Text.Trim();
                ((clsAutenticarLogin)_IAutenticable).cPass = txtContraseña.Text.Trim();
            }

            if (_IAutenticable is clsAutenticarHuellas)
            {
                lValido = AutenticarUserBiometrico();
                if(!lValido)
                {
                    clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("lBioColaboradorAltSMS"));
                    bool lBioColaboradorAlt = (objVarGen.cValVar == "1") ? true : false;

                    objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Equals("lBioColaboradorAltComite"));
                    bool lBioColaboradorCom = (objVarGen.cValVar == "1") ? true : false;

                    if ((lAutenticacionBiometrica && lBioColaboradorAlt) || (lAutenticacionComite && lBioColaboradorCom))
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
                    lUsuAutBiometrico = true;
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

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtContraseña.Text.Trim().Length >= nNroCar && e.KeyCode == Keys.Enter)
            {
                AutenticarUser(new clsAutenticarLogin());
            }
        }

        private void AutenticarUser(IAutenticable _IAutenticable)
        {
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

            if(clsVarGlobal.User.lAutBiometricaAgencia)
            {
                DataTable dtUsuarioBiometrico = objUsuario.ObtenerDatosClienteBiometrico(objUsuarioAutenticado.idCli);

                var listFirmantes = dtUsuarioBiometrico.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                        .OrderBy(x => Convert.ToInt32(x["idCli"]));

                int idTipoOperacionExcepcion = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoColaborador"]);
                clsBiometrico objBiometrico = new clsBiometrico();
                objBiometrico.lColaborador = true;
                if (!objBiometrico.validacionBiometrica(listFirmantes, idMonedaApro,idProductoApro,nMontoApro,idTipoOperacionExcepcion))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
