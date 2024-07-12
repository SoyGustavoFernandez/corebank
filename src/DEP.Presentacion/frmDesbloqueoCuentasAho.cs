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
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmDesbloqueoCuentasAho : frmBase
    {
        #region Varibales Globales
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        #endregion
        #region Constructor
        public frmDesbloqueoCuentasAho()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.conBusCtaCliSinBloq.HabDeshabilitarCtrl(true);
            this.conBusCtaCliSinBloq.txtCodAge.Focus();
            this.btnLiberar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.conBusCtaCliSinBloq.btnBusCliente.Enabled = true;

        }
        private void frmDesbloqueoCuentasAho_Load(object sender, EventArgs e)
        {
            this.conBusCtaCliSinBloq.cTipoBusqueda = "D"; 
            this.conBusCtaCliSinBloq.cEstado = "[1]"; 
            this.conBusCtaCliSinBloq.idmodulo = 2;
            conBusCtaCliSinBloq.txtCodAge.BackColor = Color.White;
            conBusCtaCliSinBloq.txtCodMod.BackColor = Color.White;
            conBusCtaCliSinBloq.txtCodMon.BackColor = Color.White;
            conBusCtaCliSinBloq.HabDeshabilitarCtrl(true);
            conBusCtaCliSinBloq.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaCliSinBloq.txtCodAge.Focus();
        }
        private void conBusCtaCliSinBloq1_MyClic(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void conBusCtaCliSinBloq1_MyKey(object sender, KeyPressEventArgs e)
        {
            this.CargarDatos();
        }
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(Convert.ToInt32(this.conBusCtaCliSinBloq.nIdCliente), conBusCtaCliSinBloq.nValBusqueda, "Inicio-Desbloqueo de cuenta", btnLiberar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            RetornaNumCuenta.CNDesbloqueaCuenta(conBusCtaCliSinBloq.nValBusqueda, 2);
            MessageBox.Show("Cuenta liberada.", "Desbloqueo de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
  

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(Convert.ToInt32(this.conBusCtaCliSinBloq.nIdCliente), conBusCtaCliSinBloq.nValBusqueda, "Fin-Desbloqueo de cuenta", btnLiberar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            this.LimpiarControles();
            this.btnLiberar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.conBusCtaCliSinBloq.HabDeshabilitarCtrl(true);
            this.conBusCtaCliSinBloq.btnBusCliente.Enabled = true;
        }
        #endregion

        #region Metodos
        private void LimpiarControles()
        {
            //this.conBusCtaCliSinBloq.txtCodIns.Clear();
            this.conBusCtaCliSinBloq.txtCodAge.Clear();
            this.conBusCtaCliSinBloq.txtCodMod.Clear();
            this.conBusCtaCliSinBloq.txtCodMon.Clear();
            this.conBusCtaCliSinBloq.txtNroCta.Clear();
            this.conBusCtaCliSinBloq.txtCodCli.Clear();
            this.conBusCtaCliSinBloq.txtNroDoc.Clear();
            this.conBusCtaCliSinBloq.txtNombre.Clear();
            this.txtAgeBlo.Clear();
            this.txtUsuarioBlo.Clear();
        }
        private void CargarDatos()
        {

            if (conBusCtaCliSinBloq.nValBusqueda == -1)
            {
                this.txtUsuarioBlo.Text = "";
                this.txtAgeBlo.Text = "";
                this.conBusCtaCliSinBloq.LimpiarControles();
                this.conBusCtaCliSinBloq.HabDeshabilitarCtrl(true);
                this.conBusCtaCliSinBloq.txtCodAge.Focus();
                this.btnCancelar.Enabled = false;
                this.btnLiberar.Enabled = false;
            }
            else if (conBusCtaCliSinBloq.nValBusqueda>0)
            {
                txtUsuarioBlo.Text = conBusCtaCliSinBloq.cUserBloqueo;
                this.txtAgeBlo.Text = conBusCtaCliSinBloq.cAgeBloquea;
                this.btnLiberar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.conBusCtaCliSinBloq.HabDeshabilitarCtrl(false);
            }

        }
        #endregion

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

    

     

    }
}
