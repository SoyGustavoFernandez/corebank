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
using LOG.CapaNegocio;
using EntityLayer;
namespace LOG.Presentacion
{
    public partial class frmBuscarProveedor : frmBase
    {
        clsListaProveedores lstProveedor = new clsListaProveedores();
        public clsProveedores Proveedor = new clsProveedores();
        public int Aceptar=0;
        clsCNNotaPedido clsBscProve = new clsCNNotaPedido();
        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            this.cboTipDocumento.CargarDocumentos("O");
            rbtBase1_CheckedChanged(sender,e);
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (rbtBase1.Checked==true && txtNroDoc.Text.Trim().Length<=0)
            {
                MessageBox.Show("Ingrese Nro de Documento","Validar Busqueda de Proveedor",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtNroDoc.Focus();
                dtgProveedor.DataSource = "";
                return;
            }
            if (rbtBase2.Checked == true && txtProveedor.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Ingrese al Proveedor", "Validar Busqueda de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProveedor.Focus();
                dtgProveedor.DataSource = "";
                return;
            }
            lstProveedor=new clsCNProveedor().buscaProveedores(txtNroDoc.Text,txtProveedor.Text);
            dtgProveedor.DataSource = null;
            dtgProveedor.DataSource = lstProveedor;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgProveedor.RowCount <= 0)
            {
                return;
            }
            var itemSelc=(clsProveedores)dtgProveedor.CurrentRow.DataBoundItem;
            Proveedor = itemSelc;
            Aceptar = 1;
            this.Dispose();

        }

        private void cboTipDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNroDoc.Clear();
            this.txtNroDoc.ValidarTipoDoc(Convert.ToString(this.cboTipDocumento.SelectedValue));
            if (cboTipDocumento.Text != "")
                lblNroDoc.Text = cboTipDocumento.Text + ":";
            else
                lblNroDoc.Text = "Nro Documento:";
        }

        private void rbtBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBase1.Checked )
            {
                cboTipDocumento.Enabled = true;
                txtNroDoc.Enabled = true;
                txtProveedor.Enabled = false;
                txtNroDoc.Clear();
                txtNroDoc.Focus();
                txtProveedor.Clear();
            }
        }

        private void rbtBase2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBase2.Checked)
            {
                txtProveedor.Enabled = true;
                cboTipDocumento.Enabled =false;
                txtNroDoc.Enabled = false;
                txtNroDoc.Clear();
                txtProveedor.Clear();
                txtProveedor.Focus();
            }
            
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(this.txtProveedor.Text.ToString()))
                {
                    btnBusqueda_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("Valor de Búsqueda No Válido", "Búsqueda de Proveedor.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(this.txtNroDoc.Text.ToString()))
                {
                    btnBusqueda_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Valor de Búsqueda No Válido", "Búsqueda de Proveedor.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
    }
}
