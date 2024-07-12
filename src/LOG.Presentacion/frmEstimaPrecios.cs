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
using GEN.Funciones;

namespace LOG.Presentacion
{
    public partial class frmEstimaPrecios : frmBase
    {

        #region Variables

        public int idNotaPedido;
        public string cUserWin;
        public string cMoneda;
        public DateTime dtFechaReg;
        public bool lIndicaConsolidado;
        public List<clsDetalleNotaPedido> pLstDetNot = new List<clsDetalleNotaPedido>();
        private List<clsDetalleNotaPedido> tmpLstDetNotPed;

        #endregion

        #region Eventos

        private void frmEstimaPrecios_Load(object sender, EventArgs e)
        {
            tmpLstDetNotPed = pLstDetNot.Clone<clsDetalleNotaPedido>().ToList();

            txtUsuario.Text = cUserWin;
            txtMoneda.Text = cMoneda;
            dtpFechaNP.Value = dtFechaReg;

            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = tmpLstDetNotPed.Where(x => x.lVigente == true).ToList();
            FormatoGridViewNP();

            txtTotal.Text = tmpLstDetNotPed.Sum(x => x.nSubTotal).ToString();
            if (lIndicaConsolidado)
            {
                btnAceptar.Enabled = false;
                btnAgrProveedor.Enabled = false;
                btnQuitProveedor.Enabled = false;
                dtgDetalleNP.ReadOnly = true;
            }
        }

        private void btnAgrProveedor_Click(object sender, EventArgs e)
        {
            if (dtgProveedores.RowCount > 0)
            {
                MessageBox.Show("No puede agregar más proveedores para este producto.", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
            frmBusProveedor.ShowDialog();
            if (frmBusProveedor.objProveedor == null)
            {
                MessageBox.Show("No se selecciono ningun proveedor", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
            objDetNP.idProveedor = frmBusProveedor.objProveedor.idProveedor;

            dtgDetalleNP_SelectionChanged(sender, e);
        }

        private void btnQuitProveedor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de quitar el proveedor?", "Quitar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ( result == DialogResult.Yes)
            {
                if (dtgProveedores.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione el proveedore que desea quitar.", "Quitar Proveedor ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var objDetNP = (clsDetalleNotaPedido)this.dtgDetalleNP.CurrentRow.DataBoundItem;
                objDetNP.idProveedor = 0;

                dtgDetalleNP_SelectionChanged(sender, e);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pLstDetNot = tmpLstDetNotPed.Clone<clsDetalleNotaPedido>().ToList();
            this.Dispose();
        }

        private void dtgDetalleNP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgDetalleNP.CurrentRow != null)
                {
                    clsDetalleNotaPedido objDetNotPedido = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
                    objDetNotPedido.nSubTotal = objDetNotPedido.nPrecioUnit * objDetNotPedido.nCantidad;
                    txtTotal.Text = tmpLstDetNotPed.Sum(x => x.nSubTotal).ToString();
                }
            }
        }

        private void dtgDetalleNP_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNP.CurrentRow.DataBoundItem != null)
            {
                var objDetNP = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
                dtgProveedores.DataSource = typeof(List<clsProveedores>);
                if (objDetNP.idProveedor != 0)
                {
                    List<clsProveedores> LstProveedores = new clsCNProveedor().CNBusProveedor("4", objDetNP.idProveedor.ToString());
                    dtgProveedores.DataSource = LstProveedores;
                    FormatoGridViewProveedor();
                }
            }
        }

        private void dtgDetalleNP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '-') && (txt.Text.Length > 0))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Metodos

        public frmEstimaPrecios()
        {
            InitializeComponent();
        }

        private void FormatoGridViewProveedor()
        {
            dtgProveedores.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgProveedores.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgProveedores.Columns["idProveedor"].Visible = true;
            dtgProveedores.Columns["cNombre"].Visible = true;
            dtgProveedores.Columns["cDocumentoID"].Visible = true;

            dtgProveedores.Columns["idProveedor"].HeaderText = "Código";
            dtgProveedores.Columns["cNombre"].HeaderText = "Proveedor";
            dtgProveedores.Columns["cDocumentoID"].HeaderText = "Nro. Documento";

            dtgProveedores.Columns["idProveedor"].DisplayIndex = 0;
            dtgProveedores.Columns["cNombre"].DisplayIndex = 1;
            dtgProveedores.Columns["cDocumentoID"].DisplayIndex = 2;

            dtgProveedores.Columns["idProveedor"].FillWeight = 15;
            dtgProveedores.Columns["cNombre"].FillWeight = 55;
            dtgProveedores.Columns["cDocumentoID"].FillWeight = 30;
        }

        private void FormatoGridViewNP()
        {
            dtgDetalleNP.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNP.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgDetalleNP.Columns["nItem"].Visible = true;
            dtgDetalleNP.Columns["idCatalogo"].Visible = true;
            dtgDetalleNP.Columns["cProducto"].Visible = true;
            dtgDetalleNP.Columns["cUnidad"].Visible = true;
            dtgDetalleNP.Columns["nCantidad"].Visible = true;
            dtgDetalleNP.Columns["nPrecioUnit"].Visible = true;

            dtgDetalleNP.Columns["nItem"].HeaderText = "Item";
            dtgDetalleNP.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNP.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleNP.Columns["cUnidad"].HeaderText = "UM";
            dtgDetalleNP.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNP.Columns["nPrecioUnit"].HeaderText = "Pre.Uni";

            dtgDetalleNP.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleNP.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleNP.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleNP.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetalleNP.Columns["nCantidad"].DisplayIndex = 4;
            dtgDetalleNP.Columns["nPrecioUnit"].DisplayIndex = 5;

            dtgDetalleNP.Columns["nItem"].FillWeight = 5;
            dtgDetalleNP.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleNP.Columns["cProducto"].FillWeight = 35;
            dtgDetalleNP.Columns["cUnidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nPrecioUnit"].FillWeight = 10;

            dtgDetalleNP.Columns["nPrecioUnit"].ReadOnly = false;
        }

        #endregion

        private void frmEstimaPrecios_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgDetalleNP.EditingControlShowing -= dtgDetalleNP_EditingControlShowing;
            dtgDetalleNP.SelectionChanged -= dtgDetalleNP_SelectionChanged;
            dtgDetalleNP.SelectionChanged -= dtgDetalleNP_SelectionChanged;
            dtgDetalleNP.CellValueChanged -= dtgDetalleNP_CellValueChanged;
            dtgDetalleNP.DataSource = null;
            dtgDetalleNP.CancelEdit();
        }

        private void dtgDetalleNP_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleNP.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgDetalleNP.CurrentRow.Cells["nPrecioUnit"].EditedFormattedValue.ToString()))
                {
                    dtgDetalleNP.EditingControl.Text = "0";
                    return;
                }
            }
        }
    }
}
