#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

#endregion

namespace GEN.ControlesBase
{
    public partial class ConReferenciasSimp : UserControl
    {
        #region Variables Globales
        private List<clsReferenciaEval> listReferencia;

        private DataTable dtTipReferEval;
        private DataTable dtTipoEstado;
        private DataTable dtTipVinculoEval;
        public int idEvalCre = 0;

        private int nIndexEditado;

        public string cMsjCaption = "Error en la Validación";
        #endregion

        #region Constructor
        public ConReferenciasSimp()
        {
            InitializeComponent();

            FormatearDataGridView();

            this.nIndexEditado = -1;
        }
        #endregion

        #region Método Públicos

        public void AsignarDataTable(DataTable _dtTipReferEval, DataTable _dtTipVinculoEval)
        {
            //Asignar contenido de las Celdas

            this.dtTipReferEval = _dtTipReferEval;
            this.dtTipVinculoEval = _dtTipVinculoEval;

            this.dtTipoEstado = new DataTable();
            this.dtTipoEstado.Columns.Add("nEstado", typeof(int));
            this.dtTipoEstado.Columns.Add("cDescripcion", typeof(string));
            this.dtTipoEstado.Rows.Add(new object[] { 1, "Positivo" });
            this.dtTipoEstado.Rows.Add(new object[] { 2, "Negativo" });


            DataRow row = this.dtTipVinculoEval.NewRow();
            row["idTipVinculoEval"] = 999;
            row["idTipReferEval"] = 999;
            row["cDescripcion"] = "--Seleccione--";
            this.dtTipVinculoEval.Rows.InsertAt(row, 0);

        }

        public void AsignarDatos(List<clsReferenciaEval> _listReferencia)
        {
            this.listReferencia = _listReferencia;

            this.bindingReferencia.DataSource = listReferencia;
            this.dtgReferencia.DataSource = this.bindingReferencia;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();
        }

        public string Titulo
        {
            set { this.label1.Text = value; }
        }

        public void limpiar()
        {
            if (this.listReferencia != null)
                this.listReferencia.Clear();

            this.bindingReferencia.ResetBindings(false);
        }

        #endregion

        #region Métodos Privados

        private void FormatearDataGridView()
        {
            this.dtgReferencia.Margin = new System.Windows.Forms.Padding(0);
            this.dtgReferencia.MultiSelect = false;
            this.dtgReferencia.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReferencia.RowHeadersVisible = false;
            this.dtgReferencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgReferencia.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgReferencia.Columns["cConcepto"].DisplayIndex = 0;
            this.dtgReferencia.Columns["dgcboTipReferEval"].DisplayIndex = 1;
            this.dtgReferencia.Columns["cDireccion"].DisplayIndex = 2;
            this.dtgReferencia.Columns["cNumeroCelular"].DisplayIndex = 3;
            this.dtgReferencia.Columns["cComentarios"].DisplayIndex = 4;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].DisplayIndex = 5;

            this.dtgReferencia.Columns["cConcepto"].Visible = true;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].Visible = true;
            this.dtgReferencia.Columns["cDireccion"].Visible = true;
            this.dtgReferencia.Columns["cNumeroCelular"].Visible = true;
            this.dtgReferencia.Columns["cComentarios"].Visible = true;
            this.dtgReferencia.Columns["dgcboTipReferEval"].Visible = true;

            this.dtgReferencia.Columns["cConcepto"].HeaderText = "Nombre/Empresa";
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].HeaderText = "Vinculo";
            this.dtgReferencia.Columns["cDireccion"].HeaderText = "Dirección";
            this.dtgReferencia.Columns["cNumeroCelular"].HeaderText = "Teléfono";
            this.dtgReferencia.Columns["cComentarios"].HeaderText = "Comentario";
            this.dtgReferencia.Columns["dgcboTipReferEval"].HeaderText = "Referencia";


            this.dtgReferencia.Columns["cConcepto"].FillWeight = 50;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].FillWeight = 25;
            this.dtgReferencia.Columns["cDireccion"].FillWeight = 45;
            this.dtgReferencia.Columns["cNumeroCelular"].FillWeight = 25;
            this.dtgReferencia.Columns["cComentarios"].FillWeight = 40;
            this.dtgReferencia.Columns["dgcboTipReferEval"].FillWeight = 25;

            this.dtgReferencia.Columns["cConcepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["cDireccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["cNumeroCelular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["cComentarios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["dgcboTipReferEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dtgReferencia.Columns["cConcepto"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            this.dtgReferencia.Columns["cDireccion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            this.dtgReferencia.Columns["cNumeroCelular"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            this.dtgReferencia.Columns["cComentarios"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            this.dtgReferencia.Refresh();
        }

        private void AgregarComboBoxColumnsDataGridView()
        {
            DataGridViewComboBoxColumn dgcboTipReferEval = new DataGridViewComboBoxColumn();
            dgcboTipReferEval.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipReferEval.DataPropertyName = "idTipReferEval";
            dgcboTipReferEval.Name = "dgcboTipReferEval";
            dgcboTipReferEval.DisplayMember = "cDescripcion";
            dgcboTipReferEval.ValueMember = "idTipReferEval";
            dgcboTipReferEval.DataSource = this.dtTipReferEval;
            this.dtgReferencia.Columns.Add(dgcboTipReferEval);

            DataGridViewComboBoxColumn dgcboTipVinculoEval = new DataGridViewComboBoxColumn();
            dgcboTipVinculoEval.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipVinculoEval.DataPropertyName = "idTipVinculoEval";
            dgcboTipVinculoEval.Name = "dgcboTipVinculoEval";
            dgcboTipVinculoEval.DisplayMember = "cDescripcion";
            dgcboTipVinculoEval.ValueMember = "idTipVinculoEval";
            dgcboTipVinculoEval.DataSource = this.dtTipVinculoEval;
            this.dtgReferencia.Columns.Add(dgcboTipVinculoEval);

            DataGridViewComboBoxColumn dgcboTipoEstado = new DataGridViewComboBoxColumn();
            dgcboTipoEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipoEstado.DataPropertyName = "nEstado";
            dgcboTipoEstado.Name = "dgcboTipoEstado";
            dgcboTipoEstado.DisplayMember = "cDescripcion";
            dgcboTipoEstado.ValueMember = "nEstado";
            dgcboTipoEstado.DataSource = this.dtTipoEstado;
            this.dtgReferencia.Columns.Add(dgcboTipoEstado);

        }

        private void RegistrarReferencia()
        {
            this.listReferencia.Add(new clsReferenciaEval()
            {
                idEvalCred = idEvalCre,
                idTipReferEval = 2,
                idTipVinculoEval = 4,
                cConcepto = String.Empty,
                cDireccion = String.Empty,
                cNumeroCelular = String.Empty,
                nEstado = 1,
                cComentarios = String.Empty,
                cVinculo = String.Empty
            });

            this.bindingReferencia.ResetBindings(false);
            this.tsmQuitar.Enabled = true;

        }


        #endregion

        #region Eventos


        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            RegistrarReferencia();
        }

        private void tsmQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgReferencia.Enabled == false || this.dtgReferencia.SelectedRows.Count == 0 || this.dtgReferencia.CurrentRow == null)
                return;

            int rowIndex = this.dtgReferencia.CurrentRow.Index;
            this.listReferencia.RemoveAt(rowIndex);
            this.bindingReferencia.ResetBindings(false);

            if (this.nIndexEditado == rowIndex)
            {
                this.nIndexEditado = -1;
            }

            if (this.dtgReferencia.SelectedRows.Count == 0)
                this.tsmQuitar.Enabled = false;
        }

        private void dtgRefCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitar.Enabled = true;
        }

        private void dtgRefCliente_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
        private void dtgReferencia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dtgReferencia_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cConcepto") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("cDireccion") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("cComentarios"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("cNumeroCelular"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEntero);
                }
            }

            if(dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("idTipReferEval") || dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("idTipVinculoEval"))
            {
                ComboBox cb = e.Control as ComboBox;
                if(cb != null)
                {
                    e.CellStyle.BackColor = this.dtgReferencia.DefaultCellStyle.BackColor;
                }
            }
        }

        private void dtgReferencia_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void Column_KeyPressEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #endregion

        private void dtgReferencia_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dtg = ((DataGridView)sender);

            string cNombreColumna = dtg.CurrentCell.OwningColumn.DataPropertyName;
            if (dtg.IsCurrentCellDirty && (cNombreColumna.In("idTipReferEval")))
            {
                dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgReferencia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dtg = (DataGridView)sender;
            if (dtg.CurrentCell == null)
                return;
            string cNombreColumn = dtg.CurrentCell.OwningColumn.DataPropertyName.ToString();
            int idSeleccion = 0;

            if(cNombreColumn == "idTipReferEval")
            {
                idSeleccion = Convert.ToInt32(dtg.CurrentCell.Value);
                DataGridViewRow current = dtgReferencia.CurrentRow;

                DataGridViewComboBoxCell cbocell = (DataGridViewComboBoxCell)current.Cells["dgcboTipVinculoEval"];
                DataTable dtNew = dtTipVinculoEval.AsEnumerable().Where(item => Convert.ToInt32(item["idTipReferEval"]) == idSeleccion).CopyToDataTable();
                cbocell.DisplayMember = "cDescripcion";
                cbocell.ValueMember = "idTipVinculoEval";
                cbocell.DataSource = dtNew;
            }
            
        }
    }
}
