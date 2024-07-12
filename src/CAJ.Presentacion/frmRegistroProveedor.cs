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
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmRegistroProveedor : frmBase
    {
        clsCNComprobantes objCaja = new clsCNComprobantes();

        public frmRegistroProveedor()
        {
            InitializeComponent();
        }

        private void frmRegistroProveedor_Load(object sender, EventArgs e)
        {

        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            txtNumeroCuenta.Enabled = false;
            conBusCli.btnBusCliente.Enabled = true;
            LimpiarCtrls();
        }

        private void LimpiarCtrls()
        {
            txtNumeroCuenta.Clear();
            conBusCli.txtCodInst.Clear();
            conBusCli.txtCodAge.Clear();
            conBusCli.txtCodCli.Clear();
            conBusCli.txtNombre.Clear();
            conBusCli.txtNroDoc.Clear();
            conBusCli.txtDireccion.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //--=====================================================================================
            //--Validar Datos del Proveedor
            //--=====================================================================================
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text.ToString()))
            {
                MessageBox.Show("Primero debe Buscar el Proveedor", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;      
            }
            if (string.IsNullOrEmpty(txtNumeroCuenta.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Numero de Cta de Detracciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int x_idCli = Convert.ToInt32(conBusCli.txtCodCli.Text.ToString());
            if (x_idCli <= 0)
            {
                MessageBox.Show("Debe Buscar un Proveedor Valido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string x_cCtaDetrac = txtNumeroCuenta.Text.Trim();

            //--=====================================================================================
            //--Registrar Datos del Proveedor
            //--=====================================================================================
            DataTable tbRegCta = objCaja.CNRegistrarCtaDetracProveedor(x_idCli, x_cCtaDetrac);
            if (Convert.ToInt16(tbRegCta.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegCta.Rows[0]["cMensaje"].ToString(), "Guardar Cta Detracción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRegCta.Rows[0]["cMensaje"].ToString(), "Guardar Cta Detracción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            txtNumeroCuenta.Enabled = false;
        }

        private void conBusCli_ClicBuscar_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text.ToString()))
            {
                return;
            }
            int x_idCli = Convert.ToInt32(conBusCli.txtCodCli.Text.ToString());
            if (x_idCli <= 0)
            {
                MessageBox.Show("Debe Buscar un Proveedor Valido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtNumeroCuenta.Clear();
            DataTable tbDetracc = objCaja.CNBuscarCtaDetracProveedor(x_idCli);
            if (tbDetracc.Rows.Count > 0)
            {
                txtNumeroCuenta.Text = tbDetracc.Rows[0]["cCtaDetraccion"].ToString();
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                txtNumeroCuenta.Enabled = false;
            }
            else
            {
                txtNumeroCuenta.Text = "";
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                txtNumeroCuenta.Enabled = true;
                txtNumeroCuenta.Focus();
            }
            btnCancelar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = true;
            btnEditar.Enabled = true;
            txtNumeroCuenta.Enabled = true;
            txtNumeroCuenta.Focus();
        }
    }
}
