using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;

namespace SolIntEls
{
    public partial class frmTipoCambio : frmBase
    {
        public frmTipoCambio()
        {
            InitializeComponent();
        }

        private void frmTipoCambio_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            dtpFecTipCam.Value = clsVarGlobal.dFecSystem;
            HabDesControles(false);
            TiposDeCambio();
        }

        private void TiposDeCambio()
        {
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RetornaTiposCambio(clsVarGlobal.dFecSystem);
            if (tbTipCam.Rows.Count>0)
            {
                txtTipCamFij.Text = tbTipCam.Rows[0]["nTipCamFij"].ToString();
                txtTipCamCom.Text = tbTipCam.Rows[0]["nTipCamCom"].ToString();
                txtTipCamVen.Text = tbTipCam.Rows[0]["nTipCamVen"].ToString();
                txtTipCamProCom.Text = tbTipCam.Rows[0]["nTipCamProCom"].ToString();
                txtTipCamProVen.Text = tbTipCam.Rows[0]["nTipCamProVen"].ToString();   
            }
            else
            {
                MessageBox.Show("No Existe Tipos de Cambio", "Validar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            
        }

        private void HabDesControles(bool val)
        {
            txtTipCamCom.Enabled = val;
            txtTipCamVen.Enabled = val;
            txtTipCamProCom.Enabled = val;
            txtTipCamProVen.Enabled = val;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTipCamFij.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Fijo", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamFij.Focus();
                this.txtTipCamFij.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamFij.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Fijo Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamFij.Focus();
                this.txtTipCamFij.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamCom.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Compra", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamCom.Focus();
                this.txtTipCamCom.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamCom.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Compra Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamCom.Focus();
                this.txtTipCamCom.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamVen.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Venta", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamVen.Focus();
                this.txtTipCamVen.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamVen.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Venta Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamVen.Focus();
                this.txtTipCamVen.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamProCom.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Compra", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProCom.Focus();
                this.txtTipCamProCom.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamProCom.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Compra Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProCom.Focus();
                this.txtTipCamProCom.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamProVen.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Venta", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProVen.Focus();
                this.txtTipCamProVen.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamProVen.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Venta Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProVen.Focus();
                this.txtTipCamProVen.Select();
                return;
            }

            //======================================================================
            //--------Datos para Guardar Tipos de Cambio
            //======================================================================
            Decimal nTipCamFij = Convert.ToDecimal(this.txtTipCamFij.Text);
            Decimal nTipCamCom = Convert.ToDecimal(this.txtTipCamCom.Text);
            Decimal nTipCamVen = Convert.ToDecimal(this.txtTipCamVen.Text);
            Decimal nTipCamProCom = Convert.ToDecimal(this.txtTipCamProCom.Text);
            Decimal nTipCamPromVen = Convert.ToDecimal(this.txtTipCamProVen.Text);
            int nOpc=0;
            if (chcTipFijo.Checked)
            {
                nOpc = 1;
            }

            var Msg = MessageBox.Show("Esta Seguro de Actualizar los Tipos de Cambio?...", "Actualizar Tipos de Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //======================================================================
            //--------Guardar Tipos de Cambio
            //======================================================================
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.ActualizarTipoCambio(clsVarGlobal.dFecSystem, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamProCom, nTipCamPromVen, nOpc, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(tbTipCam.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbTipCam.Rows[0]["cMensage"].ToString(), "Actualizar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipCamFij.Enabled = false;
                txtTipCamCom.Enabled = false;
                txtTipCamVen.Enabled = false;
                txtTipCamProCom.Enabled = false;
                txtTipCamProVen.Enabled = false;
            }
            else
            {
                MessageBox.Show(tbTipCam.Rows[0]["cMensage"].ToString(), "Actualizar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTipCamCom.Focus();
                return;
            }
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            HabDesControles(true);
            txtTipCamCom.Focus();
            txtTipCamCom.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabDesControles(false);
            TiposDeCambio();
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void chcTipFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTipFijo.Checked)
            {
                var Msg = MessageBox.Show("Esta Seguro de Modificar el Tipo de Cambio Fijo?...", "Actualizar Tipo de Cambio Fijo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    txtTipCamFij.Enabled = false;
                    chcTipFijo.Checked = false;
                    return;
                }
                txtTipCamFij.Enabled = true;
                txtTipCamFij.Focus();
                txtTipCamFij.Select();
            }
            else
            {
                txtTipCamFij.Enabled = false;
            }
        }
    }
}
