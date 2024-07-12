using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmDesbCtas : frmBase
    {
        #region Variabless= Globales
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        #endregion
        #region Constructor
        public frmDesbCtas()
        {
            InitializeComponent();
            this.conBusCtaCliSinBloq1.txtNroCta.Focus();
        }
        #endregion
        #region Eventos
        private void frmDesbCtas_Load(object sender, EventArgs e)
        {
            this.conBusCtaCliSinBloq1.cTipoBusqueda = "C"; ;
            this.conBusCtaCliSinBloq1.cEstado = "[2,5]"; ;
            this.conBusCtaCliSinBloq1.idmodulo = 1;           
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            CleanData();
            this.conBusCtaCliSinBloq1.txtNroCta.Enabled = true;
            this.conBusCtaCliSinBloq1.txtNroCta.Focus();
            this.btnLiberar.Enabled = false;
            this.btnCancelar1.Enabled = false;
            this.conBusCtaCliSinBloq1.btnBusCliente.Enabled = true;
        }
        private void conBusCtaCliSinBloq1_MyClic(object sender, EventArgs e)
        {
            LoadData();
        }

        private void conBusCtaCliSinBloq1_MyKey(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (conBusCtaCliSinBloq1.nidUserBloqueo == clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("El Usuario no puede desbloquear la cuenta que él mismo bloqueó.", "Desbloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RetornaNumCuenta.CNDesbloqueaCuenta(conBusCtaCliSinBloq1.nValBusqueda, 1);
                MessageBox.Show("Cuenta liberada.", "Desbloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CleanData();
                this.btnLiberar.Enabled = false;
                this.btnCancelar1.Enabled = false;
                this.conBusCtaCliSinBloq1.txtNroCta.Enabled = true;
                this.conBusCtaCliSinBloq1.btnBusCliente.Enabled = true;
                this.conBusCtaCliSinBloq1.txtNroCta.Focus();

        }
        #endregion 
        #region Metodos
        private void CleanData()
        {
            
            this.conBusCtaCliSinBloq1.txtCodIns.Clear();
            this.conBusCtaCliSinBloq1.txtCodAge.Clear();
            this.conBusCtaCliSinBloq1.txtCodMod.Clear();
            this.conBusCtaCliSinBloq1.txtCodMon.Clear();
            this.conBusCtaCliSinBloq1.txtNroCta.Clear();
            this.conBusCtaCliSinBloq1.txtCodCli.Clear();
            this.conBusCtaCliSinBloq1.txtNroDoc.Clear();
            this.conBusCtaCliSinBloq1.txtNombre.Clear();
            this.txtAgeBlo.Clear();
            this.txtUsuarioBlo.Clear();

        }

        private void LoadData()
        {
            if (conBusCtaCliSinBloq1.nValBusqueda == -1)
            {
                this.txtUsuarioBlo.Text = "";
                this.txtAgeBlo.Text = "";
                this.conBusCtaCliSinBloq1.txtNroCta.Enabled = true;
                this.conBusCtaCliSinBloq1.txtNroCta.Clear();
                this.conBusCtaCliSinBloq1.txtNroCta.Focus();
                this.btnCancelar1.Enabled = false;
                this.btnLiberar.Enabled = false;
            }
            else if (conBusCtaCliSinBloq1.nValBusqueda > 0)
            {
                txtUsuarioBlo.Text = conBusCtaCliSinBloq1.cUserBloqueo;
                this.txtAgeBlo.Text = conBusCtaCliSinBloq1.cAgeBloquea;
                this.btnLiberar.Enabled = true;
                this.btnCancelar1.Enabled = true;
                this.conBusCtaCliSinBloq1.txtNroCta.Enabled = false;
            }

        }
        #endregion

      
    }
}
