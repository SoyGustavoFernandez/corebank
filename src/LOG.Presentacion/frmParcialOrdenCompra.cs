#region Directivas
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using LOG.CapaNegocio;
using CAJ.CapaNegocio;
using CAJ.Presentacion;
#endregion

namespace LOG.Presentacion
{
    public partial class frmParcialOrdenCompra : frmBase
    {
        #region Variables
        private int idOrden = 0;
        public DataTable dtCatalogo;
        #endregion

        #region Metodos
        
        public frmParcialOrdenCompra()
        {
            InitializeComponent();
        }

        public frmParcialOrdenCompra(int idOrden_)
        {
            idOrden = idOrden_;
            InitializeComponent();
        }

        private void formatoGridDetNotEntrada()
        {
            dtgDetalleNotaEntrada.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNotaEntrada.Columns)
            {
                if (column.HeaderText != "lSeleccionado")
                    column.ReadOnly = true;
                else column.ReadOnly = false;
                column.Visible = false;
            }

            dtgDetalleNotaEntrada.Columns["lSeleccionado"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nNum"].Visible = true;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].Visible = true;
            dtgDetalleNotaEntrada.Columns["cProducto"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nCantidad"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].Visible = true;
            dtgDetalleNotaEntrada.Columns["cDesTipoUniMed"].Visible = true;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].Visible = true;

            dtgDetalleNotaEntrada.Columns["lSeleccionado"].HeaderText = "";
            dtgDetalleNotaEntrada.Columns["nNum"].HeaderText = "N°";
            dtgDetalleNotaEntrada.Columns["idCatalogo"].HeaderText = "Cod. Prod.";
            dtgDetalleNotaEntrada.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleNotaEntrada.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].HeaderText = "Prec. Unitario";
            dtgDetalleNotaEntrada.Columns["cDesTipoUniMed"].HeaderText = "Uni. Med.";
            dtgDetalleNotaEntrada.Columns["nSubTotal"].HeaderText = "SubTotal";

            dtgDetalleNotaEntrada.Columns["lSeleccionado"].FillWeight = 3;
            dtgDetalleNotaEntrada.Columns["nNum"].FillWeight = 7;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["cProducto"].FillWeight = 40;
            dtgDetalleNotaEntrada.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["cDesTipoUniMed"].FillWeight = 10;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].FillWeight = 10;

            dtgDetalleNotaEntrada.Columns["lSeleccionado"].DisplayIndex = 0;
            dtgDetalleNotaEntrada.Columns["nNum"].DisplayIndex = 1;
            dtgDetalleNotaEntrada.Columns["idCatalogo"].DisplayIndex = 2;
            dtgDetalleNotaEntrada.Columns["cProducto"].DisplayIndex = 3;
            dtgDetalleNotaEntrada.Columns["cDesTipoUniMed"].DisplayIndex = 4;
            dtgDetalleNotaEntrada.Columns["nCantidad"].DisplayIndex = 5;
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DisplayIndex = 6;
            dtgDetalleNotaEntrada.Columns["nSubTotal"].DisplayIndex = 7;

            dtgDetalleNotaEntrada.Columns["nCantidad"].DefaultCellStyle.Format = "#,0.00";
            dtgDetalleNotaEntrada.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "#,0.00";
            dtgDetalleNotaEntrada.Columns["nSubTotal"].DefaultCellStyle.Format = "#,0.00";
        }
        #endregion

        #region Eventos
        private void frmParcialOrdenCompra_Load(object sender, EventArgs e)
        {
            DataTable dtDetNotaEntrada = new clsCNOrdenCompra().CNListarDetalleOrden(idOrden, true);

            dtgDetalleNotaEntrada.DataSource = dtDetNotaEntrada;
            foreach (DataColumn col in dtDetNotaEntrada.Columns)
                col.ReadOnly = false;
            formatoGridDetNotEntrada();
        }


        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            dtCatalogo = (DataTable)dtgDetalleNotaEntrada.DataSource;
            foreach (DataRow dr in dtCatalogo.Rows)
            {
                if (!Convert.ToBoolean(dr["lSeleccionado"]))
                    dr.Delete();
            }
            dtCatalogo.AcceptChanges();
            this.Dispose();
        }

        private void dtgDetalleNotaEntrada_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgDetalleNotaEntrada.CurrentRow != null)
                {
                    DataGridViewRow fila = dtgDetalleNotaEntrada.CurrentRow;
                    dtgDetalleNotaEntrada.CurrentRow.Cells["lSeleccionado"].Value = !Convert.ToBoolean(fila.Cells["lSeleccionado"].Value);
                }
            }

            decimal nTotal = 0;
            foreach (DataGridViewRow row in dtgDetalleNotaEntrada.Rows)
            {
                if (Convert.ToBoolean(row.Cells["lSeleccionado"].Value))
                    nTotal += Convert.ToDecimal(row.Cells["nSubTotal"].Value);
            }

            txtSubTotal.Text = nTotal.ToString();
        }
        #endregion
    }
}
