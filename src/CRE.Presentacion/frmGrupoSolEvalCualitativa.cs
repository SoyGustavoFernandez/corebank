using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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

namespace CRE.Presentacion
{
    public partial class frmGrupoSolEvalCualitativa : frmBase
    {
        private int idEvalCredGrupoSol;
        private List<clsEvalCualitativaGrupoSol> listEvalCualitativa;
        //public event DataGridViewCellEventHandler EvalCualitativaCellValueChanged;
        private const string TITULO_FORM = "Grupo Solidario - Evaluación Cualitativa";
        public bool lGuardado;
        public decimal nPuntaje = 0;

        public frmGrupoSolEvalCualitativa()
        {
            InitializeComponent();
        }

        public frmGrupoSolEvalCualitativa(int _idEvalCredGrupoSol)
        {
            this.idEvalCredGrupoSol = _idEvalCredGrupoSol;
            this.listEvalCualitativa = new List<clsEvalCualitativaGrupoSol>();
            this.lGuardado = false;

            InitializeComponent();
            FormatearDataGridView();
            HabilitarFormulario(EventoFormulario.CANCELAR);
        }

        public List<clsEvalCualitativaGrupoSol> ObtenerEvalCualitativaGrupoSolidario()
        {
            return this.listEvalCualitativa;
        }

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgEvalCualit.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvalCualit.MultiSelect = false;
            this.dtgEvalCualit.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvalCualit.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvalCualit.RowHeadersVisible = false;
            this.dtgEvalCualit.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.dtgEvalCualit.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private bool ContienePuntaje(string[] aRangoPuntajes, string cPuntaje)
        {
            foreach (string cPtje in aRangoPuntajes)
            {
                if (Convert.ToDecimal(cPtje) == Convert.ToDecimal(cPuntaje))
                    return true;
            }

            return false;
        }

        private void RecuperarEvalCredito()
        {
            DataTable dt = (new clsCNGrupoSolidario()).ObtenerEvalCualitativa(this.idEvalCredGrupoSol);

            var listEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativaGrupoSol>(dt) as List<clsEvalCualitativaGrupoSol>;
            AsignarDatos(listEvalCualitativa);
        }

        private void AsignarDatos(List<clsEvalCualitativaGrupoSol> _listEvalCualitativa)
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

            dtgEvalCualit.Columns["cDescripcion"].FillWeight = 140;  //160
            dtgEvalCualit.Columns["cCriterios"].FillWeight = 200;    //100
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
                    row.Cells["oPuntaje"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    row.Cells["oPuntaje"].ReadOnly = false;
                }

            }
        }

        private void CalcularPuntajeTotales()
        {
            this.txtTotalPuntaje.Text = this.listEvalCualitativa.Sum(x => Convert.ToDecimal(x.oPuntaje)).ToString("n1");
            this.nPuntaje = Convert.ToDecimal(this.txtTotalPuntaje.Text);
        }

        private string EvalCualitativaCredToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCualitativaGrupoSol", typeof(int));
            dt.Columns.Add("idItemCualit", typeof(int));
            dt.Columns.Add("nPuntaje", typeof(decimal));
            dt.Columns.Add("nComputado", typeof(decimal));
            dt.Columns.Add("lAutomatico", typeof(bool));

            foreach (clsEvalCualitativaGrupoSol ev in this.listEvalCualitativa)
            {
                dt.Rows.Add(
                    ev.idEvalCualitativaGrupoSol,
                    ev.idItemCualit,
                    Convert.ToDecimal(ev.oPuntaje),
                    ev.nComputado,
                    ev.lAutomatico
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCualitativa", "Item");
        }

        private void HabilitarFormulario(EventoFormulario eButton)
        {
            switch (eButton)
            {
                case EventoFormulario.EDITAR:
                    this.btnGrabar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.dtgEvalCualit.Enabled = true;
                    break;

                case EventoFormulario.GRABAR:
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.dtgEvalCualit.Enabled = false;

                    this.dtgEvalCualit.ClearSelection();

                    break;

                case EventoFormulario.CANCELAR:
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.dtgEvalCualit.Enabled = false;

                    this.dtgEvalCualit.ClearSelection();
                    break;
            }
        }
        #endregion

        #region Eventos
        private void frmGrupoSolEvalCualitativa_Load(object sender, EventArgs e)
        {
            RecuperarEvalCredito();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.EDITAR);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dtVars = (new clsCNGrupoSolidario()).BusVariablesSegunNombre("<lstVariables><clsVariable><cVariable>nMinPtjeEvalCualitGrupoSol</cVariable><idAgencia>0</idAgencia></clsVariable></lstVariables>");
            if (dtVars.Rows.Count > 0 && this.nPuntaje < Convert.ToInt32(dtVars.Rows[0]["cValVar"]))
            {
                MessageBox.Show("El puntaje minimo permitido es: " + dtVars.Rows[0]["cValVar"].ToString() + ", no podra guardar los cambios con el puntaje actual", "PUNTAJE DEFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string xmlEvalCualit = this.EvalCualitativaCredToXML();

            DataTable dt = (new clsCNGrupoSolidario()).GuardarEvalCualitativa(this.idEvalCredGrupoSol, xmlEvalCualit);

            if (dt.Rows.Count > 0)
            {
                DataRow drResult = dt.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    this.lGuardado = true;

                    MessageBox.Show(drResult["cMsje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RecuperarEvalCredito();
                    HabilitarFormulario(EventoFormulario.GRABAR);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.CANCELAR);
        }

        private void dtgEvalCualit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgEvalCualit.Refresh();
            this.CalcularPuntajeTotales();

            //if (EvalCualitativaCellValueChanged != null)
            //    EvalCualitativaCellValueChanged(sender, e);
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

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // allowed numeric and one dot  ex. 10.23
            /*if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }*/
        }
        #endregion
    }
}
