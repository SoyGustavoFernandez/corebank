using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
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
    public partial class ConIngresoVentaActivoRural : UserControl
    {
        #region Variables

        private int idEvalCred;
        private List<clsIngresoVentaActivoRural> listIngVtaAtvRural;
        private List<clsUnidadMedida> listUnidadMedida;
        private List<clsFechasIngresoVentaInv> listFechasIngresoVentaInventarios;

        #endregion


        #region Metodos Publicos

        public ConIngresoVentaActivoRural()
        {
            InitializeComponent();
            FormatearDataGridView();
        }

        public void AsignarDatos(int idEvalCred, List<clsIngresoVentaActivoRural> listIngVtaAtvRural, List<clsUnidadMedida> listUnidadesMedida, List<clsFechasIngresoVentaInv> listFechas)
        {
            this.dtgIngresoVentaActivo.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresoVentaActivo_DataBindingComplete);
            this.dtgIngresoVentaActivo.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresoVentaActivo_EditingControlShowing);

            this.idEvalCred = idEvalCred;
            this.listUnidadMedida = listUnidadesMedida;
            this.listFechasIngresoVentaInventarios = listFechas;
            this.listIngVtaAtvRural = listIngVtaAtvRural;

            this.bsIngVtaAtvRural.DataSource = this.listIngVtaAtvRural;
            this.dtgIngresoVentaActivo.DataSource = this.bsIngVtaAtvRural;
            AgregarComboBoxColumnsDataGridViewFechas();
            AgregarComboBoxColumnsDataGridViewUnidadMedida();
            FormatearColumnasDataGridViewIngresoVentaActivo();

            this.dtgIngresoVentaActivo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresoVentaActivo_DataBindingComplete);
            this.dtgIngresoVentaActivo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresoVentaActivo_EditingControlShowing);
            dtgIngresoVentaActivo_DataBindingComplete(null, null);

            if (this.listIngVtaAtvRural.Count > 0) this.tsmQuitar.Enabled = true;
        }

        #endregion


        #region Metodos Privados

        private void FormatearColumnasDataGridViewIngresoVentaActivo()
        {
            foreach (DataGridViewColumn column in this.dtgIngresoVentaActivo.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgIngresoVentaActivo.Columns["cProducto"].DisplayIndex = 0;
            dtgIngresoVentaActivo.Columns["dgcboUnidadMedida"].DisplayIndex = 1;
            dtgIngresoVentaActivo.Columns["nCantidad"].DisplayIndex = 2;
            dtgIngresoVentaActivo.Columns["nKgxGanado"].DisplayIndex = 3;
            dtgIngresoVentaActivo.Columns["nPrecio"].DisplayIndex = 4;
            dtgIngresoVentaActivo.Columns["nTotal"].DisplayIndex = 5;
            dtgIngresoVentaActivo.Columns["dgcboFechas"].DisplayIndex = 6;

            dtgIngresoVentaActivo.Columns["cProducto"].Visible = true;
            dtgIngresoVentaActivo.Columns["dgcboUnidadMedida"].Visible = true;
            dtgIngresoVentaActivo.Columns["nCantidad"].Visible = true;
            dtgIngresoVentaActivo.Columns["nKgxGanado"].Visible = true;
            dtgIngresoVentaActivo.Columns["nPrecio"].Visible = true;
            dtgIngresoVentaActivo.Columns["nTotal"].Visible = true;
            dtgIngresoVentaActivo.Columns["dgcboFechas"].Visible = true;

            dtgIngresoVentaActivo.Columns["cProducto"].HeaderText = "Producto";
            dtgIngresoVentaActivo.Columns["dgcboUnidadMedida"].HeaderText = "Unidad";
            dtgIngresoVentaActivo.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgIngresoVentaActivo.Columns["nKgxGanado"].HeaderText = "Kg/Ganado";
            dtgIngresoVentaActivo.Columns["nPrecio"].HeaderText = "Precio";
            dtgIngresoVentaActivo.Columns["nTotal"].HeaderText = "Total";
            dtgIngresoVentaActivo.Columns["dgcboFechas"].HeaderText = "Fecha de Venta";

            dtgIngresoVentaActivo.Columns["cProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresoVentaActivo.Columns["dgcboUnidadMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresoVentaActivo.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresoVentaActivo.Columns["nKgxGanado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresoVentaActivo.Columns["nPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresoVentaActivo.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresoVentaActivo.Columns["dgcboFechas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgIngresoVentaActivo.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgIngresoVentaActivo.Columns["nPrecio"].DefaultCellStyle.Format = "n2";
            dtgIngresoVentaActivo.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgIngresoVentaActivo.Columns["cProducto"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresoVentaActivo.Columns["idUnidadMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresoVentaActivo.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresoVentaActivo.Columns["nKgxGanado"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresoVentaActivo.Columns["nPrecio"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgIngresoVentaActivo.Columns["nTotal"].ReadOnly = true;
        }

        private void FormatearDataGridView()
        {
            this.dtgIngresoVentaActivo.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIngresoVentaActivo.MultiSelect = false;
            this.dtgIngresoVentaActivo.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgIngresoVentaActivo.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIngresoVentaActivo.RowHeadersVisible = false;
        }

        private void AgregarComboBoxColumnsDataGridViewUnidadMedida()
        {
            DataGridViewComboBoxColumn dgcboUnidadMedida = new DataGridViewComboBoxColumn();
            dgcboUnidadMedida.DisplayStyleForCurrentCellOnly = true;
            dgcboUnidadMedida.FlatStyle = FlatStyle.Popup;
            dgcboUnidadMedida.Name = "dgcboUnidadMedida";
            dgcboUnidadMedida.DataPropertyName = "idUnidadMedida";
            dgcboUnidadMedida.DataSource = this.listUnidadMedida;
            dgcboUnidadMedida.DisplayMember = "cUnidadMedida";
            dgcboUnidadMedida.ValueMember = "idUnidadMedida";
            this.dtgIngresoVentaActivo.Columns.Add(dgcboUnidadMedida);
        }

        private void AgregarComboBoxColumnsDataGridViewFechas()
        {
            DataGridViewComboBoxColumn dgcboFechas = new DataGridViewComboBoxColumn();
            dgcboFechas.DisplayStyleForCurrentCellOnly = true;
            dgcboFechas.FlatStyle = FlatStyle.Popup;
            dgcboFechas.Name = "dgcboFechas";
            dgcboFechas.DataPropertyName = "dFechaVenta";
            dgcboFechas.DataSource = this.listFechasIngresoVentaInventarios;
            dgcboFechas.DisplayMember = "cFecha";
            dgcboFechas.ValueMember = "dFechaVenta";
            this.dtgIngresoVentaActivo.Columns.Add(dgcboFechas);
        }

        private void CalcularTotal()
        {
            this.txtTotal.Text = this.listIngVtaAtvRural.Sum(x => x.nTotal).ToString("N2");
        }

        #endregion


        #region Eventos

        private void dtgIngresoVentaActivo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotal();
        }

        private void dtgIngresoVentaActivo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nKgxGanado"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nCantidad"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPrecio"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 12;
            }

        }

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar)
            //    && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Column_KeyPressEntero(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex. 10
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            this.listIngVtaAtvRural.Add(new clsIngresoVentaActivoRural()
            {
                idUnidadMedida = this.listUnidadMedida.FirstOrDefault().idUnidadMedida,
                nPrecio = 0,
                nKgxGanado = 0,
                nCantidad = 0,
                dFechaVenta = this.listFechasIngresoVentaInventarios.FirstOrDefault().dFechaVenta
            });

            this.bsIngVtaAtvRural.ResetBindings(false);
            this.tsmQuitar.Enabled = true;
        }

        private void tsmQuitar_click(object sender, EventArgs e)
        {
            if (this.dtgIngresoVentaActivo.RowCount == 0 || this.dtgIngresoVentaActivo.Enabled == false ||
                this.dtgIngresoVentaActivo.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgIngresoVentaActivo.SelectedCells[0].RowIndex;

            this.listIngVtaAtvRural.RemoveAt(rowIndex);
            this.bsIngVtaAtvRural.ResetBindings(false);

            if (this.dtgIngresoVentaActivo.SelectedCells.Count == 0)
                this.tsmQuitar.Enabled = false;
        }

        private void dtgIngresoVentaActivo_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        #endregion
    }
}
