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
using System.Globalization;

namespace GEN.ControlesBase
{
    public partial class ConEvalCualitativa : UserControl
    {
        private List<clsEvalCualitativa> listEvalCualitativa;
        private Color EditableBackColor;
        public event EventHandler ActualizarClick;

        public event DataGridViewCellEventHandler EvalCualitativaCellValueChanged;

        public ConEvalCualitativa()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.EditableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        }

        #region Métodos Públicos
        public void AsignarDatos(List<clsEvalCualitativa> _listEvalCualitativa)
        {
            this.listEvalCualitativa = _listEvalCualitativa;

            int i = 0;
            foreach (var ec in this.listEvalCualitativa)
            {
                if ((ec.nPuntaje % 1) * 10 > 1)
                    ec.oPuntaje = Convert.ToDecimal(ec.nPuntaje);
                else
                    ec.oPuntaje = Convert.ToInt32(ec.nPuntaje);

                this.listEvalCualitativa[i++].oPuntaje = ec.oPuntaje;
            }

            this.bindingEvalCualit.DataSource = this.listEvalCualitativa;
            this.dtgEvalCualit.DataSource = this.bindingEvalCualit;
            this.FormatearColumnasDataGridView();

            this.dtgEvalCualit.ClearSelection();
            this.CalcularPuntajeTotales();
        }

        public decimal TotalPuntaje()
        {
            return this.listEvalCualitativa.Sum(x => Convert.ToDecimal(x.oPuntaje));
        }

        public List<clsEvalCualitativa> EvaluacionCualitativa()
        {
            int i = 0;
            foreach (var ec in this.listEvalCualitativa)
            {
                this.listEvalCualitativa[i++].nPuntaje = Convert.ToDecimal(ec.oPuntaje);
            }

            return this.listEvalCualitativa;
        }

        public void limpiar()
        {
            this.listEvalCualitativa = null;
            dtgEvalCualit.DataSource = null;
        }

        public void ActualizarDataGridView()
        {
            if (listEvalCualitativa == null) return;

            this.dtgEvalCualit.Refresh();
            this.CalcularPuntajeTotales();
        }

        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgEvalCualit.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvalCualit.MultiSelect = false;
            this.dtgEvalCualit.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgEvalCualit.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgEvalCualit.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgEvalCualit.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgEvalCualit.RowHeadersVisible = false;
            this.dtgEvalCualit.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.dtgEvalCualit.ReadOnly = true;
            this.dtgEvalCualit.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgEvalCualit.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEvalCualit.Columns["cDescripcion"].DisplayIndex = 0;
            dtgEvalCualit.Columns["cCriterios"].DisplayIndex = 1;
            dtgEvalCualit.Columns["cPuntajes"].DisplayIndex = 2;
            dtgEvalCualit.Columns["oPuntaje"].DisplayIndex = 5;

            dtgEvalCualit.Columns["cDescripcion"].Visible = true;
            dtgEvalCualit.Columns["cCriterios"].Visible = true;
            dtgEvalCualit.Columns["cPuntajes"].Visible = true;
            dtgEvalCualit.Columns["oPuntaje"].Visible = true;

            dtgEvalCualit.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgEvalCualit.Columns["cCriterios"].HeaderText = "Criterios";
            dtgEvalCualit.Columns["cPuntajes"].HeaderText = "Puntajes";
            dtgEvalCualit.Columns["oPuntaje"].HeaderText = "Puntaje Asesor";

            dtgEvalCualit.Columns["cDescripcion"].FillWeight = 160;  //200
            dtgEvalCualit.Columns["cCriterios"].FillWeight = 100;    //110
            dtgEvalCualit.Columns["cPuntajes"].FillWeight = 45;
            dtgEvalCualit.Columns["oPuntaje"].FillWeight = 45;

            dtgEvalCualit.Columns["cCriterios"].DefaultCellStyle.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtgEvalCualit.Columns["cPuntajes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEvalCualit.Columns["oPuntaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEvalCualit.Columns["oPuntaje"].DefaultCellStyle.Format = "0.#";
            dtgEvalCualit.Columns["oPuntaje"].ReadOnly = false;

            bool lAutomatico;
            foreach (DataGridViewRow row in this.dtgEvalCualit.Rows)
            {
                lAutomatico = Convert.ToBoolean(row.Cells["lAutomatico"].Value);
                if (lAutomatico == true)
                {
                    row.Cells["oPuntaje"].ReadOnly = true;
                    row.Cells["cCriterios"].Style.ForeColor = System.Drawing.SystemColors.GrayText;
                    row.Cells["cPuntajes"].Style.ForeColor = System.Drawing.SystemColors.GrayText;
                }
                else
                {
                    row.Cells["oPuntaje"].Style.BackColor = EditableBackColor;
                    row.Cells["oPuntaje"].ReadOnly = false;
                }
            }
        }

        private void CalcularPuntajeTotales()
        {
            this.txtTotalPuntaje.Text = this.listEvalCualitativa.Sum(x => Convert.ToDecimal(x.oPuntaje)).ToString("n1");
        }

        private bool ContienePuntaje(string[] aRangoPuntajes, string cPuntaje)
        {
            foreach (string cPtje in aRangoPuntajes)
            {
                if (Convert.ToDecimal(cPtje) == Convert.ToDecimal(cPuntaje))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Eventos
        private void dtgEvalCualit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgEvalCualit.Refresh();
            this.CalcularPuntajeTotales();

            if (EvalCualitativaCellValueChanged != null)
                EvalCualitativaCellValueChanged(sender, e);
        }

        private void dtgEvalCualit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (((DataGridView)sender).CurrentCell.OwningColumn.DataPropertyName.Equals("oPuntaje"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtgEvalCualit_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //validar la existencia de datos
            if (this.listEvalCualitativa == null)
                return;

            if (((DataGridView)sender).CurrentCell.OwningColumn.DataPropertyName.Equals("oPuntaje"))
            {
                if (this.dtgEvalCualit.IsCurrentCellDirty)
                    this.dtgEvalCualit.CommitEdit(DataGridViewDataErrorContexts.Commit);

                string cRangoPuntajes = this.listEvalCualitativa[e.RowIndex].cPuntajes;
                string[] aRangoPuntajes = cRangoPuntajes.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);

                if (this.dtgEvalCualit.CurrentCell.Value != null)
                {
                    string cPuntaje = this.dtgEvalCualit.CurrentCell.Value.ToString();
                    if (!ContienePuntaje(aRangoPuntajes, cPuntaje))
                    {
                        var min = aRangoPuntajes.Min(x => Convert.ToDecimal(x));
                        this.dtgEvalCualit.CurrentCell.Value = min;

                        MessageBox.Show("El Puntaje \"" + cPuntaje + "\" no está dentro del rango de puntajes definido. \n", 
                            "Mensaje de Validación", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var min = aRangoPuntajes.Min(x => Convert.ToDecimal(x));
                    this.dtgEvalCualit.CurrentCell.Value = min;

                }
            }
        }

        private void dtgEvalCualit_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            /*string newLine = Environment.NewLine;
            if (e.RowIndex > -1)
            {
                if (dtgEvalCualit.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.DataPropertyName.Equals("nPuntajeSis"))
                {
                    var cCriterioSis = this.dtgEvalCualit.Rows[e.RowIndex].Cells["cCriterioSis"].Value;

                    Rectangle cellRect = dtgEvalCualit.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    ttpCriteriosSis.Show("" + cCriterioSis,
                                  this,
                                  dtgEvalCualit.Location.X + cellRect.X + cellRect.Size.Width,
                                  dtgEvalCualit.Location.Y + cellRect.Y + cellRect.Size.Height,
                                  5000);    // Duration: 5 seconds.
                }
                else
                {
                    ttpCriteriosSis.Hide(this);
                }

            }*/
        }

        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            if (ActualizarClick != null)
                ActualizarClick(sender, e);
        }
        #endregion
    }
}
