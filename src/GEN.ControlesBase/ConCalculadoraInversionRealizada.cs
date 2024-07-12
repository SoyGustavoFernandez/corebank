using EntityLayer;
using GEN.CapaNegocio;
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
    public partial class ConCalculadoraInversionRealizada : UserControl
    {
        #region Variables

        private List<clsInversionInsumo> lstInversionInsumo;
        private List<clsUnidadMedida> lstUnidadesMedida;
        private Guid idIngresoEstacional;
        private decimal nMontoTotal = 0;

        #endregion


        #region Metodos Publicos

        public ConCalculadoraInversionRealizada()
        {
            InitializeComponent();
            lstInversionInsumo = new List<clsInversionInsumo>();
            this.dtgvInsumos.ReadOnly = false;

        }

        public void AsignarDatos(List<clsInversionInsumo> _listaInversionInsumo, Guid _idIngresoEstacional)
        {
            this.lstInversionInsumo = _listaInversionInsumo;
            this.idIngresoEstacional = _idIngresoEstacional;

            this.bindingInversionInsumos.DataSource = this.lstInversionInsumo;
            this.dtgvInsumos.DataSource = this.bindingInversionInsumos;
            this.bindingInversionInsumos.ResetBindings(false);

            AgregarComboBoxUnidadMedidaDataGridViewInversionInsumos();
            FormatearColumnasDataGridViewInversionInsumos();

        }

        public List<clsInversionInsumo> ObtenerListaInversionesInsumo()
        {
            this.dtgvInsumos.DataSource = null;
            this.dtgvInsumos.Rows.Clear();
            return this.lstInversionInsumo;
        }

        public void EstablecerListaInsumos(List<clsInversionInsumo> _lstInversionInsumo)
        {
            this.lstInversionInsumo = _lstInversionInsumo;
        }

        #endregion


        #region Metodos Privados

        private void AgregarComboBoxUnidadMedidaDataGridViewInversionInsumos()
        {
            var dtUnidadesMedida = new clsCNAdquisionesLogistica().listaUnidaMedida();
            var listUnidadesMedida = DataTableToList.ConvertTo<clsUnidadMedida>(dtUnidadesMedida) as List<clsUnidadMedida>;

            this.lstUnidadesMedida = listUnidadesMedida;

            DataGridViewComboBoxColumn dgcboUnidadMedida = new DataGridViewComboBoxColumn();
            dgcboUnidadMedida.DisplayStyleForCurrentCellOnly = true;
            dgcboUnidadMedida.FlatStyle = FlatStyle.Popup;
            dgcboUnidadMedida.Name = "cboUnidadMedida";
            dgcboUnidadMedida.DataPropertyName = "idUnidad";
            dgcboUnidadMedida.DataSource = this.lstUnidadesMedida;
            dgcboUnidadMedida.DisplayMember = "cUnidad";
            dgcboUnidadMedida.ValueMember = "idUnidad";
            this.dtgvInsumos.Columns.Add(dgcboUnidadMedida);

        }

        private void FormatearColumnasDataGridViewInversionInsumos()
        {
            this.dtgvInsumos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgvInsumos.MultiSelect = false;
            this.dtgvInsumos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvInsumos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInsumos.RowHeadersVisible = false;
            this.dtgvInsumos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            if (this.lstInversionInsumo.Count > 0)            
                this.tsmQuitar.Enabled = true;
            else
                this.tsmQuitar.Enabled = false;


            foreach (DataGridViewColumn column in this.dtgvInsumos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgvInsumos.Columns["idInversionInsumo"].DisplayIndex = 0;
            dtgvInsumos.Columns["cNombreInsumo"].DisplayIndex = 1;
            dtgvInsumos.Columns["cboUnidadMedida"].DisplayIndex = 2;
            dtgvInsumos.Columns["nExtension"].DisplayIndex = 3;
            dtgvInsumos.Columns["nCantidad"].DisplayIndex = 4;
            dtgvInsumos.Columns["nPrecio"].DisplayIndex = 5;
            dtgvInsumos.Columns["nTotal"].DisplayIndex = 6;
            dtgvInsumos.Columns["idProyeccionIngreso"].DisplayIndex = 7;

            dtgvInsumos.Columns["cNombreInsumo"].Visible = true;            
            dtgvInsumos.Columns["nExtension"].Visible = true;
            dtgvInsumos.Columns["nCantidad"].Visible = true;
            dtgvInsumos.Columns["nPrecio"].Visible = true;
            dtgvInsumos.Columns["nTotal"].Visible = true;
            dtgvInsumos.Columns["cboUnidadMedida"].Visible = true;

            dtgvInsumos.Columns["idInversionInsumo"].FillWeight = 60;
            dtgvInsumos.Columns["cNombreInsumo"].FillWeight = 60;
            dtgvInsumos.Columns["nUnidadMedida"].FillWeight = 60;
            dtgvInsumos.Columns["nExtension"].FillWeight = 60;
            dtgvInsumos.Columns["nCantidad"].FillWeight = 60;
            dtgvInsumos.Columns["nPrecio"].FillWeight = 60;
            dtgvInsumos.Columns["nTotal"].FillWeight = 60;
            dtgvInsumos.Columns["idProyeccionIngreso"].FillWeight = 60;
            dtgvInsumos.Columns["cboUnidadMedida"].FillWeight = 60;

            dtgvInsumos.Columns["idInversionInsumo"].HeaderText = "Id Inversion";
            dtgvInsumos.Columns["cNombreInsumo"].HeaderText = "Insumo";
            dtgvInsumos.Columns["nUnidadMedida"].HeaderText = "Un. Medida";
            dtgvInsumos.Columns["nExtension"].HeaderText = "Extensión";
            dtgvInsumos.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgvInsumos.Columns["nPrecio"].HeaderText = "Precio";
            dtgvInsumos.Columns["nTotal"].HeaderText = "Total";
            dtgvInsumos.Columns["idProyeccionIngreso"].HeaderText = "Id Proyección";
            dtgvInsumos.Columns["cboUnidadMedida"].HeaderText = "Un. Medida";


            dtgvInsumos.Columns["idInversionInsumo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["cNombreInsumo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["nUnidadMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["nExtension"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["nPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvInsumos.Columns["idProyeccionIngreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvInsumos.Columns["nTotal"].ReadOnly = true;

            dtgvInsumos.Columns["cNombreInsumo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;          
            dtgvInsumos.Columns["nExtension"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvInsumos.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgvInsumos.Columns["nPrecio"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;            
            dtgvInsumos.Columns["idProyeccionIngreso"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalInversionInsumo()
        {
            this.txtTotalInsumoInversion.Text = this.lstInversionInsumo.Sum(t => t.nTotal).ToString();
            this.txtTotalInsumoInversion.Refresh();
        }

        #endregion


        #region Eventos

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            this.lstInversionInsumo.Add(new clsInversionInsumo()
            {
                idInversionInsumo = Guid.NewGuid(),
                cNombreInsumo = "",
                idUnidad = this.lstUnidadesMedida.FirstOrDefault().idUnidadMedida,
                nCantidad = 0,
                nPrecio = 0,
                idProyeccionIngreso = this.idIngresoEstacional
            });

            this.bindingInversionInsumos.ResetBindings(false);
            this.tsmQuitar.Enabled = true;
        }

        private void dtgvInsumos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Se ingresó un valor invalido en la celda.\nVer Columna \""
                    + dtg.CurrentCell.OwningColumn.HeaderText + "\" y fila " + (e.RowIndex + 1) + ".",
                    "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if ((e.Exception) is ConstraintException)
            {
                dtg.Rows[e.RowIndex].ErrorText = "an error";
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }

        private void bindingInversionInsumos_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            CalcularTotalInversionInsumo();
            this.nMontoTotal = this.lstInversionInsumo.Sum(t => t.nTotal);
        }

        private void dtgvInsumos_SelectionChanged(object sender, EventArgs e)
        {
            bindingInversionInsumos_BindingComplete(null, null);
        }

        private void tsmQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgvInsumos.RowCount == 0 || this.dtgvInsumos.Enabled == false ||
                this.dtgvInsumos.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgvInsumos.SelectedCells[0].RowIndex;
            this.lstInversionInsumo.RemoveAt(rowIndex);

            this.bindingInversionInsumos.DataSource = this.lstInversionInsumo;
            this.bindingInversionInsumos.ResetBindings(false);
            this.dtgvInsumos.Refresh();

            if (this.dtgvInsumos.SelectedCells.Count == 0)
                this.tsmQuitar.Enabled = false;
        }

        #endregion
    }
}
