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
using DEP.CapaNegocio;
using EntityLayer;
namespace DEP.Presentacion
{
    public partial class frmVincCertificado : frmBase
    {
        #region Variables globales
        public int idCuenta=0;
        public int idkardex=0;
        public  int ncertificado=0;
        public int idMoneda = 0;
        public bool lIndVinculacion = false;
        private DataTable dtGenCerti;

        private clsCNValorados clsValorado = new clsCNValorados();
        #endregion
        public frmVincCertificado()
        {
            InitializeComponent();
        }
        #region Eventos

        private void frmVincCertificado_Load(object sender, EventArgs e)
        {
            this.txtNroCuenta.Text = idCuenta.ToString();
        }

        private void txtCBNumCerti_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
            {
                cValor = "0";
            }
            else
                cValor = this.txtCBNumCerti.Text.ToString().Trim();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
                this.btnMiniAceptar1.PerformClick();

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
            }

        }

        private void txtCBNumCerti_Validating(object sender, CancelEventArgs e)
        {
            string cValor = this.txtCBNumCerti.Text.ToString().Trim();
            this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
        }
        #endregion
        #region Metodos
        public void Validar()
        {
            ncertificado = Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim());
            DataTable dtValCerti = clsValorado.CNValidaVincuCerti(ncertificado, idMoneda, clsVarGlobal.nIdAgencia);
            if (dtValCerti.Rows.Count>0)
            {
                MessageBox.Show("El Nro de Certificado se encuentra vinculada a la Cuenta: " + dtValCerti.Rows[0]["idCuenta"].ToString(), "Vinculacion de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnContinuar1.Enabled = false;
                this.txtCBNumCerti.Focus();
                this.txtCBNumCerti.SelectAll();
                //this.btnAceptar1.Enabled = false;
                return;
            }
            else
            {
              
                dtGenCerti = clsValorado.CNValidaGenCerti(ncertificado, idMoneda, 2,clsVarGlobal.nIdAgencia);
                if (dtGenCerti.Rows.Count>0)
                {

                    if (Convert.ToInt32(dtGenCerti.Rows[0]["nNumCertiSerie"]) == ncertificado)
                    {
                        this.btnContinuar1.Enabled = true;
                        this.txtCBNumCerti.Enabled = false;
                        this.btnMiniCancelar1.Enabled = true;
                        this.btnMiniAceptar1.Enabled = false;
                    }
                    else
	                {
                        MessageBox.Show("EL Nro de Certificado Pendiente de Vinculacion es:  " + dtGenCerti.Rows[0]["nNumCertiSerie"].ToString(), "Vinculacion de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnContinuar1.Enabled = false;
                        this.txtCBNumCerti.Text = dtGenCerti.Rows[0]["nNumCertiSerie"].ToString();
                        this.txtCBNumCerti.Focus();
                        this.txtCBNumCerti.SelectAll();
                        this.btnMiniCancelar1.Enabled = false;
                        this.btnMiniAceptar1.Enabled = true;
	                }
                }
                else
                {
                    MessageBox.Show("El Numero de Certificado no ha sido Generado. Verifique", "Vinculacion de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnContinuar1.Enabled = false;
                    this.txtCBNumCerti.Focus();
                    this.txtCBNumCerti.SelectAll();
                    //this.btnAceptar1.Enabled = false;
                    return;
                }
            }
            
        }
        #endregion

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
            {
                MessageBox.Show("Número No Válido de Vinculación", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBNumCerti.Focus();
                this.txtCBNumCerti.SelectAll();
                return;
            }
            if (Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim()) == 0)
            {
                MessageBox.Show("Número No Válido de Vinculación", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBNumCerti.Focus();
                this.txtCBNumCerti.SelectAll();
                return;
            }
            int idValorado = (int)dtGenCerti.Rows[0]["idValorado"];
            int nSerie = (int)dtGenCerti.Rows[0]["nSerie"];
            DataTable dtRspta = clsValorado.CNGuardaVinculacionCerti(ncertificado, idValorado, nSerie, idCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, idkardex);
            if ((int)dtRspta.Rows[0]["Resultado"] == 0)
            {
                MessageBox.Show("Error al Vincular el Número de Cuenta con el Certificado", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                //Imprimir certificado
                lIndVinculacion = true;
            }
            this.Dispose();
        }

        private void btnMiniAceptar1_Click(object sender, EventArgs e)
        {
            string cValor;
            if (string.IsNullOrEmpty(this.txtCBNumCerti.Text.ToString().Trim()))
            {
                MessageBox.Show("Ingrese un Número Válido de Certificado", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (Convert.ToInt32(this.txtCBNumCerti.Text.ToString().Trim())==0)
                {
                    MessageBox.Show("Ingrese un Número Válido de Certificado", "Vinculación de Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cValor = this.txtCBNumCerti.Text.ToString().Trim();
                    this.txtCBNumCerti.Text = cValor.PadLeft(7, '0');
                    this.Validar();
                }
                
            }
        }

        private void btnMiniCancelar1_Click(object sender, EventArgs e)
        {
            this.btnMiniAceptar1.Enabled = true;
            this.btnContinuar1.Enabled = false;
            this.txtCBNumCerti.Enabled = true;
            this.txtCBNumCerti.Focus();
            this.txtCBNumCerti.SelectAll();
            this.btnMiniCancelar1.Enabled = false;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

    }
}
