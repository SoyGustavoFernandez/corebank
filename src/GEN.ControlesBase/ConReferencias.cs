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

namespace GEN.ControlesBase
{
    public partial class ConReferencias : UserControl
    {
        private List<clsReferenciaEval> listReferencia;

        private DataTable dtTipReferEval;
        private DataTable dtTipoEstado;
        private DataTable dtTipVinculoEval;
        public int idEvalCre = 0;

        private bool lNuevoRegistro;
        private int nIndexEditado;

        public string cMsjCaption = "Error en la Validación";

        public ConReferencias()
        {
            InitializeComponent();
            FormatearDataGridView();

            HabilitarFormulario(false);

            this.lNuevoRegistro = true;
            this.nIndexEditado = -1;
        }

        #region Método Públicos
        
        public void AsignarDataTable(DataTable _dtTipReferEval, DataTable _dtTipVinculoEval)
        {
            this.dtTipReferEval = _dtTipReferEval;
            this.dtTipVinculoEval = _dtTipVinculoEval;

            this.cboTipReferEval.DisplayMember = "cDescripcion";
            this.cboTipReferEval.ValueMember = "idTipReferEval";
            this.cboTipReferEval.DataSource = this.dtTipReferEval;

            this.dtTipoEstado = new DataTable();
            this.dtTipoEstado.Columns.Add("nEstado", typeof(int));
            this.dtTipoEstado.Columns.Add("cDescripcion", typeof(string));
            this.dtTipoEstado.Rows.Add(new object[] { 1, "Positivo" });
            this.dtTipoEstado.Rows.Add(new object[] { 2, "Negativo" });

            this.cboEstado.DisplayMember = "cDescripcion";
            this.cboEstado.ValueMember = "nEstado";
            this.cboEstado.DataSource = this.dtTipoEstado;

            DataRow row = this.dtTipVinculoEval.NewRow();
            row["idTipVinculoEval"] = 999;
            row["idTipReferEval"] = 999;
            row["cDescripcion"] = "--Seleccione--";
            this.dtTipVinculoEval.Rows.InsertAt(row, 0);

            this.cboTipVinculoEval.DisplayMember = "cDescripcion";
            this.cboTipVinculoEval.ValueMember = "idTipVinculoEval";
            this.cboTipVinculoEval.DataSource = this.dtTipVinculoEval;
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
            //this.dtgRefCliente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgReferencia.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgRefCliente.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgReferencia.RowHeadersVisible = false;
            this.dtgReferencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgReferencia.ReadOnly = true;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgReferencia.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgReferencia.Columns["dgcboTipReferEval"].DisplayIndex = 0;
            this.dtgReferencia.Columns["cConcepto"].DisplayIndex = 1;
            this.dtgReferencia.Columns["cNumeroCelular"].DisplayIndex = 2;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].DisplayIndex = 3;
            this.dtgReferencia.Columns["dgcboTipoEstado"].DisplayIndex = 4;

            this.dtgReferencia.Columns["dgcboTipReferEval"].Visible = true;
            this.dtgReferencia.Columns["cConcepto"].Visible = true;
            this.dtgReferencia.Columns["cNumeroCelular"].Visible = true;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].Visible = true;
            this.dtgReferencia.Columns["dgcboTipoEstado"].Visible = true;

            this.dtgReferencia.Columns["dgcboTipReferEval"].HeaderText = "Tipo";
            this.dtgReferencia.Columns["cConcepto"].HeaderText = "Nombre/Empresa";
            this.dtgReferencia.Columns["cNumeroCelular"].HeaderText = "Celular";
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].HeaderText = "Vinculo";
            this.dtgReferencia.Columns["dgcboTipoEstado"].HeaderText = "Estado";

            this.dtgReferencia.Columns["dgcboTipReferEval"].FillWeight = 20;
            this.dtgReferencia.Columns["cConcepto"].FillWeight = 70;
            this.dtgReferencia.Columns["cNumeroCelular"].FillWeight = 20;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].FillWeight = 20;
            this.dtgReferencia.Columns["dgcboTipoEstado"].FillWeight = 18;

            this.dtgReferencia.Columns["dgcboTipReferEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["cNumeroCelular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["dgcboTipVinculoEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgReferencia.Columns["dgcboTipoEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void AgregarComboBoxColumnsDataGridView()
        {
            DataGridViewComboBoxColumn dgcboTipReferEval = new DataGridViewComboBoxColumn();
            dgcboTipReferEval.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboTipReferEval.DataPropertyName = "idTipReferEval";
            dgcboTipReferEval.Name = "dgcboTipReferEval";
            dgcboTipReferEval.DisplayMember = "cDescripcion";
            dgcboTipReferEval.ValueMember = "idTipReferEval";
            dgcboTipReferEval.DataSource = this.dtTipReferEval;
            this.dtgReferencia.Columns.Add(dgcboTipReferEval);

            DataGridViewComboBoxColumn dgcboTipVinculoEval = new DataGridViewComboBoxColumn();
            dgcboTipVinculoEval.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboTipVinculoEval.DataPropertyName = "idTipVinculoEval";
            dgcboTipVinculoEval.Name = "dgcboTipVinculoEval";
            dgcboTipVinculoEval.DisplayMember = "cDescripcion";
            dgcboTipVinculoEval.ValueMember = "idTipVinculoEval";
            dgcboTipVinculoEval.DataSource = this.dtTipVinculoEval;
            this.dtgReferencia.Columns.Add(dgcboTipVinculoEval);

            DataGridViewComboBoxColumn dgcboTipoEstado = new DataGridViewComboBoxColumn();
            dgcboTipoEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboTipoEstado.DataPropertyName = "nEstado";
            dgcboTipoEstado.Name = "dgcboTipoEstado";
            dgcboTipoEstado.DisplayMember = "cDescripcion";
            dgcboTipoEstado.ValueMember = "nEstado";
            dgcboTipoEstado.DataSource = this.dtTipoEstado;
            this.dtgReferencia.Columns.Add(dgcboTipoEstado);


        }

        //private void AgregarBinding()
        //{
        //    this.cboTiposRefCli.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingRefCliente, "idTipoRefCli", true));
        //    this.txtEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRefCliente, "cConcepto", true));
        //    this.txtDireccion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRefCliente, "cDireccion", true));
        //    this.txtVinculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRefCliente, "cVinculo", true));
        //    this.txtTelefono.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingRefCliente, "cNumeroCelular", true));
        //    this.cboEstado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingRefCliente, "nEstado", true));
        //}

        private void HabilitarFormulario(bool lHabilitado)
        {
            this.cboTipReferEval.Enabled = lHabilitado;
            this.txtEmpresa.Enabled = lHabilitado;
            this.txtDireccion.Enabled = lHabilitado;
            this.cboTipVinculoEval.Enabled = lHabilitado;
            this.txtTelefono.Enabled = lHabilitado;
            this.cboEstado.Enabled = lHabilitado;
            this.txtComentarios.Enabled = lHabilitado;


            this.tsmAgregar.Enabled = lHabilitado;
            this.tsmCancelar.Enabled = lHabilitado;

            if (lHabilitado)
                this.cboTipReferEval.Focus();
            else
                this.btnNuevo.Focus();
        }

        private void LimpiarFormulario()
        {
            this.cboTipReferEval.SelectedIndex = -1;
            this.cboTipVinculoEval.SelectedIndex = -1;
            this.txtEmpresa.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.txtTelefono.Text = String.Empty;
            this.cboEstado.SelectedIndex = -1;
            this.txtComentarios.Text = String.Empty;

            this.errorProvider.SetError(this.txtEmpresa, String.Empty);
            this.errorProvider.SetError(this.cboTipVinculoEval, String.Empty);

            this.nIndexEditado = -1;
        }

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            errorProvider.SetError(this.txtEmpresa, String.Empty);
            //errorProvider.SetError(this.txtDireccion, String.Empty);
            //errorProvider.SetError(this.txtTelefono, String.Empty);
            errorProvider.SetError(this.cboTipVinculoEval, String.Empty);

            if (this.txtEmpresa.Enabled == true && !EsEmpresaValido())
            {
                objMsjError.AddError("Nombre/Empresa: Éste campo es importante.");
                this.errorProvider.SetError(this.txtEmpresa, "Éste campo es importante.");
            }

            if (this.cboTipVinculoEval.Enabled == true && !EsVinculoValido())
            {
                objMsjError.AddError("Vínculo: Éste campo es importante.");
                this.errorProvider.SetError(this.cboTipVinculoEval, "Éste campo es importante.");
            }

            return objMsjError;
        }

        private bool EsEmpresaValido()
        {
            if (String.IsNullOrEmpty(this.txtEmpresa.Text.ToString().Trim())) return false;
            return true;
        }

        private bool EsVinculoValido()
        {
            if (this.cboTipVinculoEval.Enabled == true && (int)(this.cboTipVinculoEval.SelectedValue) == 999) return false;
            return true;
        }

        private void RegistrarReferencia()
        {
            clsMsjError objMsjError = Validar();

            if (objMsjError.HasErrors)
            {
                MessageBox.Show(objMsjError.GetErrors(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.nIndexEditado != -1)
                this.dtgReferencia.CurrentCell = this.dtgReferencia.Rows[this.nIndexEditado].Cells["cConcepto"];

            if (this.lNuevoRegistro)
            {
                this.listReferencia.Add(new clsReferenciaEval()
                {
                    idTipReferEval = Convert.ToInt32(this.cboTipReferEval.SelectedValue),
                    cConcepto = this.txtEmpresa.Text,
                    cDireccion = this.txtDireccion.Text,
                    idTipVinculoEval = Convert.ToInt32(this.cboTipVinculoEval.SelectedValue),
                    cNumeroCelular = this.txtTelefono.Text,
                    nEstado = Convert.ToInt32(this.cboEstado.SelectedValue),
                    idEvalCred = idEvalCre,
                    cComentarios = this.txtComentarios.Text
                });
            }
            else
            {
                //if (this.dtgRefCliente.SelectedRows.Count == 0 || this.dtgRefCliente.CurrentRow == null) return;
                int rowIndex = this.dtgReferencia.CurrentRow.Index;
                this.listReferencia[rowIndex].idTipReferEval = Convert.ToInt32(this.cboTipReferEval.SelectedValue);
                this.listReferencia[rowIndex].cConcepto = this.txtEmpresa.Text;
                this.listReferencia[rowIndex].cDireccion = this.txtDireccion.Text;
                this.listReferencia[rowIndex].idTipVinculoEval = Convert.ToInt32(this.cboTipVinculoEval.SelectedValue);
                this.listReferencia[rowIndex].cNumeroCelular = this.txtTelefono.Text;
                this.listReferencia[rowIndex].nEstado = Convert.ToInt32(this.cboEstado.SelectedValue);
                this.listReferencia[rowIndex].idEvalCred = idEvalCre;
                this.listReferencia[rowIndex].cComentarios = this.txtComentarios.Text; 

            }
            
            this.bindingReferencia.ResetBindings(false);

            //-----
            LimpiarFormulario();
            HabilitarFormulario(false);

            if (this.lNuevoRegistro == true)
            {
                if (this.dtgReferencia.Rows.Count > 1)
                {
                    int rows = this.dtgReferencia.Rows.Count;
                    this.dtgReferencia.CurrentCell = this.dtgReferencia.Rows[rows - 1].Cells["cConcepto"];
                }
            }
        }

        public clsMsjError validarReferencias(int idTipoEval)
        {
            Boolean lResult = true;
            clsMsjError obj = new clsMsjError();

            int nRefLabConsumo = 2;
            int nRefPerConsumo = 2;

            int nRefPersonalEval = 1;
            int nRefComercialEval = 1;


            int nRefLaboral = 0,
                nRefPersonal = 0,
                nRefComercial = 0;

            switch (idTipoEval)
            { 
                case 1:
                    foreach (clsReferenciaEval item in this.listReferencia)
                    {
                        if (item.idTipReferEval == TipRefEval.RefLaboral)
                        {
                            nRefLaboral++;
                        }
                        else if (item.idTipReferEval == TipRefEval.RefPersonal)
                        {
                            nRefPersonal++;
                        }
                    }
                    if (nRefLaboral != nRefLabConsumo && nRefPersonal != nRefPerConsumo)
                    {
                        obj.AddError("El nro mínimo de referencias laborales es: " + nRefLabConsumo + ", y personales es: " + nRefPerConsumo);
                    }
                    break;
                case 0: // Evaluaciones resumidas
                    
                    foreach (clsReferenciaEval item in this.listReferencia)
                    {
                        if (item.idTipReferEval == TipRefEval.RefComercial)
                        {
                            nRefComercial++;
                        }
                        else if (item.idTipReferEval == TipRefEval.RefPersonal)
                        {
                            nRefPersonal++;
                        }
                    }
                    if (nRefComercial < nRefComercialEval)
                    {
                        obj.AddError("REFERENCIAS: El mínimo de comerciales es: " + nRefComercialEval);
                    }

                    if(nRefPersonal < nRefPersonalEval)
                    {
                        obj.AddError("REFERENCIAS: El mínimo de personales es: " + nRefPersonalEval);
                    }
                    break;

            }

            return obj;
        }
        #endregion

        #region Eventos
        private void cboTiposRefCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTipVinculoEval.DataSource = null;
            //this.cboTipVinculoEval.Enabled = false;

            int idTipDestCred = Convert.ToInt32(this.cboTipReferEval.SelectedValue);
            if (idTipDestCred != 999 && this.cboTipReferEval.SelectedValue != null)
            {
                var tipVinculo = from vin in this.dtTipVinculoEval.AsEnumerable()
                                 where vin.Field<int>("idTipReferEval") == idTipDestCred
                                 select vin;

                DataTable dtTipVincEval = tipVinculo.CopyToDataTable();


                if (dtTipVincEval.Rows.Count > 0)
                {
                    DataRow row = dtTipVincEval.NewRow();
                    row["idTipVinculoEval"] = 999;
                    row["idTipReferEval"] = 999;
                    row["cDescripcion"] = "--Seleccione--";

                    dtTipVincEval.Rows.InsertAt(row, 0);

                    this.cboTipVinculoEval.DisplayMember = "cDescripcion";
                    this.cboTipVinculoEval.ValueMember = "idTipVinculoEval";
                    this.cboTipVinculoEval.DataSource = dtTipVincEval;
                    this.cboTipVinculoEval.SelectedIndex = 0;

                    //this.cboTipVinculoEval.Enabled = true;
                }
            }
        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            RegistrarReferencia();
        }

        private void tsmQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgReferencia.Enabled == false ||
                this.dtgReferencia.SelectedRows.Count == 0 ||
                this.dtgReferencia.CurrentRow == null) return;

            int rowIndex = this.dtgReferencia.CurrentRow.Index;
            this.listReferencia.RemoveAt(rowIndex);
            this.bindingReferencia.ResetBindings(false);

            if (this.nIndexEditado == rowIndex)
            {
                this.nIndexEditado = -1;
                this.lNuevoRegistro = true;
            }

            if (this.dtgReferencia.SelectedRows.Count == 0)
                this.tsmQuitar.Enabled = false;
        }

        private void tsmCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(true);

            this.cboTipReferEval.SelectedIndex = 0;
            this.cboEstado.SelectedIndex = 0;

            this.lNuevoRegistro = true;
        }

        private void dtgRefCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            HabilitarFormulario(true);

            this.cboTipReferEval.SelectedValue = this.listReferencia[e.RowIndex].idTipReferEval;
            this.txtEmpresa.Text = this.listReferencia[e.RowIndex].cConcepto;
            this.txtDireccion.Text = this.listReferencia[e.RowIndex].cDireccion;
            this.cboTipVinculoEval.SelectedValue = this.listReferencia[e.RowIndex].idTipVinculoEval;
            this.txtTelefono.Text = this.listReferencia[e.RowIndex].cNumeroCelular;
            this.cboEstado.SelectedValue = this.listReferencia[e.RowIndex].nEstado;
            this.txtComentarios.Text = this.listReferencia[e.RowIndex].cComentarios;

            this.nIndexEditado = e.RowIndex;
            this.lNuevoRegistro = false;
        }

        private void dtgRefCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tsmQuitar.Enabled = true;
        }

        private void dtgRefCliente_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void cboTipVinculoEval_Validating(object sender, CancelEventArgs e)
        {
            if (this.cboTipVinculoEval.Enabled == true && !EsVinculoValido())
            {
                this.errorProvider.SetError(this.cboTipVinculoEval, "Éste campo es importante.");
            }
            else
            {
                this.errorProvider.SetError(this.cboTipVinculoEval, String.Empty);
            }
        }

        private void txtEmpresa_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtEmpresa.Enabled == true && !EsEmpresaValido())
            {
                this.errorProvider.SetError(this.txtEmpresa, "Éste campo es importante.");
            }
            else
            {
                this.errorProvider.SetError(this.txtEmpresa, String.Empty);
            }
        }

        /*private void txtVinculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tsmAgregar.Select();

                RegistrarReferencia();
                e.Handled = true;
            }
        }*/
        #endregion

        
    }
}
