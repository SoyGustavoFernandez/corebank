using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmEstimacionPrecios : frmBase
    {

        public int idNotaPedido;
        public string cUserWin;
        public string cMoneda;
        public DateTime dtFechaReg;

        public DataTable dtItmes = new DataTable();
        public frmEstimacionPrecios()
        {
            InitializeComponent();
        }

        private void frmEstimacionPrecios_Load(object sender, EventArgs e)
        {
            this.dtgDetalleNP.DataSource = dtItmes;
            this.formatoGrid();
            this.txtNumNP.Text =idNotaPedido.ToString();
            this.txtUsuario.Text =cUserWin;
            this.txtMoneda.Text = cMoneda;
            this.dtpFechaNP.Value = dtFechaReg;
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
            frmBusProveedor.ShowDialog();
        }
        private void formatoGrid()
        {
            dtgDetalleNP.Columns["idVinculoProveedor"].Visible = false;
            dtgDetalleNP.Columns["nDese"].Visible = false;
            dtgDetalleNP.Columns["nValorRef"].Visible = false;
            dtgDetalleNP.Columns["idGrupo"].Visible = false;
            dtgDetalleNP.Columns["idUnidadAlmacenaje"].Visible = false;
            dtgDetalleNP.Columns["cEstado"].Visible = false;
            dtgDetalleNP.Columns["idNotaPedido"].Visible = false;

            dtgDetalleNP.Columns["nItem"].HeaderText = "Item";
            dtgDetalleNP.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNP.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleNP.Columns["cDesGrupo"].HeaderText = "Detalle";
            dtgDetalleNP.Columns["cNomCorto"].HeaderText = "UM";
            dtgDetalleNP.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNP.Columns["nPrecioUnit"].HeaderText = "Pre.Uni";
            dtgDetalleNP.Columns["nsubTotal"].HeaderText = "Sub Total";

            dtgDetalleNP.Columns["nItem"].Width = 30;
            dtgDetalleNP.Columns["idCatalogo"].Width = 50;
            dtgDetalleNP.Columns["cProducto"].Width = 180;
            dtgDetalleNP.Columns["cDesGrupo"].Width = 150;
            dtgDetalleNP.Columns["cNomCorto"].Width = 30;
            dtgDetalleNP.Columns["nCantidad"].Width = 55;
            dtgDetalleNP.Columns["nPrecioUnit"].Width = 55;
            dtgDetalleNP.Columns["nCantidad"].Width = 55;
            dtgDetalleNP.Columns["nsubTotal"].Width = 80;

        }

        private void dtgDetalleNP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNP.IsCurrentCellDirty)
            {
                dtgDetalleNP.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgDetalleNP_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
