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
    public partial class frmSaldoDeudasFinanc : frmBase
    {
        private List<clsDeudasEval> listRCCSaldosDirectos;
        private List<clsDeudasEval> listRCCSaldosIndirectos;
        private List<clsDeudasEval> listCRACSaldos;
        private List<clsDeudasEval> listEFinSaldos;

        private DataTable dtTipMoneda;

        private decimal nTipoCambio = 0;
        private int idMoneda = 0;
        private string cMonedaSimbolo;

        private int idSolicitud = 0;

        public frmSaldoDeudasFinanc()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.listRCCSaldosDirectos = null;
            this.listRCCSaldosIndirectos = null;
            this.listCRACSaldos = null;

            this.nTipoCambio = 0.0m;
            this.idMoneda = 0;
            this.cMonedaSimbolo = "";

            this.listEFinSaldos = new List<clsDeudasEval>();
        }

        #region Métodos Públicos
        public void AsignarDataTable(DataTable _dtTipMoneda)
        {
            this.dtTipMoneda = _dtTipMoneda;
        }

        public void AsignarDatos(string cNroDoc, string cNombre, decimal nTipoCambio, int idMoneda, string cMonedaSimbolo, int idSolicitud)
        {
            if (String.IsNullOrEmpty(cNroDoc)) return;

            this.nTipoCambio = nTipoCambio;
            this.idMoneda = idMoneda;
            this.cMonedaSimbolo = cMonedaSimbolo;
            this.idSolicitud = idSolicitud;

            this.dtgRCCSaldos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSaldoDeudas_CellValueChanged);
            this.dtgEFinSaldos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEFinSaldos_CellValueChanged);
            this.dtgEFinSaldos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEFinSaldos_DataError);

            this.dtgRCCSaldos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgRCCSaldos_DataBindingComplete);
            this.dtgCRACSaldos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCRACSaldos_DataBindingComplete);

            this.dtgRCCSaldos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgEFinSaldos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgEFinSaldos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEFinSaldos_EditingControlShowing);

            this.txtNroDoc.Text = cNroDoc;
            this.txtNombre.Text = cNombre;

            #region Obtener datos DB
            DataSet ds = (new clsCNEvalPyme()).ObtenerSaldosEntFinancieras(cNroDoc, 0, this.idSolicitud);

            //-- Table[0] : Saldos RCC
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[0]) as List<clsDeudasEval>;

            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();

            this.listRCCSaldosDirectos = listSalRCCDirectos;
            this.listRCCSaldosIndirectos = listSalRCCDIndirec;

            //-- Table[1] : Saldos CRAC - LASA
            this.listCRACSaldos = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[1]) as List<clsDeudasEval>;
            #endregion

            #region Configurar Objetos
            if (this.listRCCSaldosDirectos.Count > 0)
            {
                this.lblSaldosRCCTitulo.Text = "Saldos SBS " + this.listRCCSaldosDirectos[0].dFechaConsulta.ToString("dd/MM/yyyy");
            }

            int i, c = this.listRCCSaldosDirectos.Count;
            for (i = 0; i < c; i++)
            {
                this.listRCCSaldosDirectos[i].nTipoCambio = this.nTipoCambio;
                this.listRCCSaldosDirectos[i].idMonedaMA = this.idMoneda;
                this.listRCCSaldosDirectos[i].nSCapCortoPlz = this.listRCCSaldosDirectos[i].nSCapTotalSis;
            }

            c = this.listCRACSaldos.Count;
            for (i = 0; i < c; i++)
            {
                this.listCRACSaldos[i].nTipoCambio = this.nTipoCambio;
                this.listCRACSaldos[i].idMonedaMA = this.idMoneda;
                if (this.listCRACSaldos[i].idTipoDeuda == TipoDeuda.Directo)
                {
                    this.listCRACSaldos[i].nSCapCortoPlz = this.listCRACSaldos[i].nSCapTotalSis;
                }
                else
                {
                    this.listCRACSaldos[i].nSCapLargoPlz = this.listCRACSaldos[i].nSCapTotalSis;
                    this.listCRACSaldos[i].nSCapCortoPlz = decimal.Zero;
                }
            }
            #endregion

            #region Configurar Controles
            this.bindingRCCSaldos.DataSource = this.listRCCSaldosDirectos;
            this.dtgRCCSaldos.DataSource = this.bindingRCCSaldos;
            this.AgregarComboBoxColumnsDataGridViewRCC();
            this.FormatearColumnasDataGridViewRCC();

            this.bindingCRACSaldos.DataSource = this.listCRACSaldos;
            this.dtgCRACSaldos.DataSource = this.bindingCRACSaldos;
            this.AgregarComboBoxColumnsDataGridViewCRAC();
            this.FormatearColumnasDataGridViewCRAC();

            this.bindingEFinSaldos.DataSource = this.listEFinSaldos;
            this.dtgEFinSaldos.DataSource = this.bindingEFinSaldos;
            this.AgregarComboBoxColumnsDataGridViewEFin();
            this.FormatearColumnasDataGridViewEFin();

            this.lblRCCSaldos.Text = "Total Saldo " + this.cMonedaSimbolo;
            this.lblCRACSaldos.Text = "Total Saldo " + this.cMonedaSimbolo;
            this.lblEFinSaldos.Text = "Total Saldo " + this.cMonedaSimbolo;
            this.lblSaldos.Text = "Total Saldo " + this.cMonedaSimbolo;

            this.dtgRCCSaldos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSaldoDeudas_CellValueChanged);
            this.dtgEFinSaldos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEFinSaldos_CellValueChanged);
            this.dtgEFinSaldos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEFinSaldos_DataError);

            this.dtgRCCSaldos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgRCCSaldos_DataBindingComplete);
            this.dtgCRACSaldos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCRACSaldos_DataBindingComplete);

            this.dtgRCCSaldos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgEFinSaldos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtg_EditingControlShowing);
            this.dtgEFinSaldos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEFinSaldos_EditingControlShowing);

            CalcularTotalSaldoRCC();
            CalcularTotalSaldoCRAC();
            CalcularTotalSaldoEFin();
            #endregion
        }

        public decimal ObtenerSaldoTotal()
        {
            decimal nTotal = 0;
            if (this.listRCCSaldosDirectos != null)
                nTotal += this.listRCCSaldosDirectos.Sum(x => x.nSCapTotalMA);

            if (this.listCRACSaldos != null)
                nTotal += this.listCRACSaldos.Sum(x => x.nSCapTotalMA);

            if (this.listEFinSaldos != null)
                nTotal += this.listEFinSaldos.Sum(x => x.nSCapTotalMA);

            return nTotal;
        }

        public List<clsDeudasEval> ObtenerRCCSaldosDirectos()
        {
            return this.listRCCSaldosDirectos;
        }

        public List<clsDeudasEval> ObtenerRCCSaldosIndirectos()
        {
            return this.listRCCSaldosIndirectos;
        }

        public List<clsDeudasEval> ObtenerCRACSaldos()
        {
            return this.listCRACSaldos;
        }

        public List<clsDeudasEval> ObtenerEFinSaldos()
        {
            return this.listEFinSaldos;
        }
        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgRCCSaldos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgRCCSaldos.MultiSelect = false;
            this.dtgRCCSaldos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgRCCSaldos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDestCredProp.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgRCCSaldos.RowHeadersVisible = false;
            //this.dtgSaldoDeudas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgSaldoDeudas.ReadOnly = true;

            this.dtgCRACSaldos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCRACSaldos.MultiSelect = false;
            this.dtgCRACSaldos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgCRACSaldos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDestCredProp.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgCRACSaldos.RowHeadersVisible = false;
            //this.dtgCRACSaldos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgCRACSaldos.ReadOnly = true;



            this.dtgEFinSaldos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEFinSaldos.MultiSelect = false;
            this.dtgEFinSaldos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDestCredProp.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgEFinSaldos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDestCredProp.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgEFinSaldos.RowHeadersVisible = false;
            //this.dtgSaldoDeudas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgSaldoDeudas.ReadOnly = true;
        }

        // -- RCC
        private void FormatearColumnasDataGridViewRCC()
        {
            foreach (DataGridViewColumn column in this.dtgRCCSaldos.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgRCCSaldos.Columns["cNombreEmpresa"].DisplayIndex = 3;
            dtgRCCSaldos.Columns["cboTipoMoneda"].DisplayIndex = 4;
            dtgRCCSaldos.Columns["nSCapTotalSis"].DisplayIndex = 5;
            dtgRCCSaldos.Columns["nSCapCortoPlz"].DisplayIndex = 6;

            dtgRCCSaldos.Columns["cNombreEmpresa"].Visible = true;
            dtgRCCSaldos.Columns["cboTipoMoneda"].Visible = true;
            dtgRCCSaldos.Columns["nSCapTotalSis"].Visible = true;
            dtgRCCSaldos.Columns["nSCapCortoPlz"].Visible = true;

            dtgRCCSaldos.Columns["cNombreEmpresa"].HeaderText = "Institución Financiera";
            dtgRCCSaldos.Columns["cboTipoMoneda"].HeaderText = "Mon";
            dtgRCCSaldos.Columns["nSCapTotalSis"].HeaderText = "Saldo RCC";
            dtgRCCSaldos.Columns["nSCapCortoPlz"].HeaderText = "Saldo";

            dtgRCCSaldos.Columns["cNombreEmpresa"].FillWeight = 90;
            dtgRCCSaldos.Columns["cboTipoMoneda"].FillWeight = 20;
            dtgRCCSaldos.Columns["nSCapTotalSis"].FillWeight = 40;
            dtgRCCSaldos.Columns["nSCapCortoPlz"].FillWeight = 40;

            dtgRCCSaldos.Columns["cboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgRCCSaldos.Columns["nSCapTotalSis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgRCCSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgRCCSaldos.Columns["nSCapCortoPlz"].ReadOnly = false;
            dtgRCCSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgRCCSaldos.Columns["nSCapTotalSis"].DefaultCellStyle.Format = "n2";
            dtgRCCSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Format = "n2";
        }

        private void AgregarComboBoxColumnsDataGridViewRCC()
        {
            DataGridViewComboBoxColumn cboTipoMoneda = new DataGridViewComboBoxColumn();
            cboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            cboTipoMoneda.DataPropertyName = "idMoneda";
            cboTipoMoneda.Name = "cboTipoMoneda";
            cboTipoMoneda.DataSource = dtTipMoneda;
            cboTipoMoneda.DisplayMember = "cSimbolo";
            cboTipoMoneda.ValueMember = "idMoneda";
            this.dtgRCCSaldos.Columns.Add(cboTipoMoneda);
        }

        private void CalcularTotalSaldoRCC()
        {
            decimal nTotal = 0;
            if (this.listRCCSaldosDirectos != null)
                nTotal = this.listRCCSaldosDirectos.Sum(x => x.nSCapTotalMA);

            this.txtSaltoTotalRCC.Text = String.Format("{0:n2}", nTotal);
            this.txtSaltoTotal.Text = ObtenerSaldoTotal().ToString("n2");
        }

        // -- CRAC LASA
        private void FormatearColumnasDataGridViewCRAC()
        {
            foreach (DataGridViewColumn column in this.dtgCRACSaldos.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgCRACSaldos.Columns["idCuenta"].DisplayIndex = 1;
            dtgCRACSaldos.Columns["cEstado"].DisplayIndex = 2;
            dtgCRACSaldos.Columns["cProducto"].DisplayIndex = 3;
            dtgCRACSaldos.Columns["cboTipoMoneda"].DisplayIndex = 4;
            dtgCRACSaldos.Columns["nSCapCortoPlz"].DisplayIndex = 5;

            dtgCRACSaldos.Columns["idCuenta"].Visible = true;
            dtgCRACSaldos.Columns["cEstado"].Visible = true;
            dtgCRACSaldos.Columns["cProducto"].Visible = true;
            dtgCRACSaldos.Columns["cboTipoMoneda"].Visible = true;
            dtgCRACSaldos.Columns["nSCapCortoPlz"].Visible = true;

            dtgCRACSaldos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCRACSaldos.Columns["cEstado"].HeaderText = "Estado";
            dtgCRACSaldos.Columns["cProducto"].HeaderText = "Producto";
            dtgCRACSaldos.Columns["cboTipoMoneda"].HeaderText = "Mon";
            dtgCRACSaldos.Columns["nSCapCortoPlz"].HeaderText = "Saldo Capital";

            dtgCRACSaldos.Columns["idCuenta"].FillWeight = 30;
            dtgCRACSaldos.Columns["cEstado"].FillWeight = 30;
            dtgCRACSaldos.Columns["cProducto"].FillWeight = 70;
            dtgCRACSaldos.Columns["cboTipoMoneda"].FillWeight = 20;
            dtgCRACSaldos.Columns["nSCapCortoPlz"].FillWeight = 40;

            dtgCRACSaldos.Columns["cProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgCRACSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCRACSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Format = "n2";
        }

        private void AgregarComboBoxColumnsDataGridViewCRAC()
        {
            DataGridViewComboBoxColumn cboTipoMoneda = new DataGridViewComboBoxColumn();
            cboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            cboTipoMoneda.DataPropertyName = "idMoneda";
            cboTipoMoneda.Name = "cboTipoMoneda";
            cboTipoMoneda.DataSource = dtTipMoneda;
            cboTipoMoneda.DisplayMember = "cSimbolo";
            cboTipoMoneda.ValueMember = "idMoneda";
            this.dtgCRACSaldos.Columns.Add(cboTipoMoneda);
        }

        private void CalcularTotalSaldoCRAC()
        {
            decimal nTotal = 0;
            if (this.listCRACSaldos != null)
                nTotal = this.listCRACSaldos.Sum(x => x.nSCapTotalMA);

            this.txtSaltoTotalCRAC.Text = String.Format("{0:n2}", nTotal);
            this.txtSaltoTotal.Text = ObtenerSaldoTotal().ToString("n2");
        }

        // -- Entidades Financieras
        private void FormatearColumnasDataGridViewEFin()
        {
            foreach (DataGridViewColumn column in this.dtgEFinSaldos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEFinSaldos.Columns["cNombreEmpresa"].DisplayIndex = 1;
            dtgEFinSaldos.Columns["cboTipoMoneda"].DisplayIndex = 4;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].DisplayIndex = 5;

            dtgEFinSaldos.Columns["cNombreEmpresa"].Visible = true;
            dtgEFinSaldos.Columns["cboTipoMoneda"].Visible = true;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].Visible = true;

            dtgEFinSaldos.Columns["cNombreEmpresa"].HeaderText = "Entidad Financiera";
            dtgEFinSaldos.Columns["cboTipoMoneda"].HeaderText = "Mon";
            dtgEFinSaldos.Columns["nSCapCortoPlz"].HeaderText = "Saldo Capital";

            dtgEFinSaldos.Columns["cNombreEmpresa"].FillWeight = 130;
            dtgEFinSaldos.Columns["cboTipoMoneda"].FillWeight = 20;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].FillWeight = 40;

            dtgEFinSaldos.Columns["cboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.Format = "n2";

            dtgEFinSaldos.Columns["cNombreEmpresa"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgEFinSaldos.Columns["cboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgEFinSaldos.Columns["nSCapCortoPlz"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void AgregarComboBoxColumnsDataGridViewEFin()
        {
            DataGridViewComboBoxColumn cboTipoMoneda = new DataGridViewComboBoxColumn();
            //cboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            cboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            cboTipoMoneda.FlatStyle = FlatStyle.Popup;
            cboTipoMoneda.DataPropertyName = "idMoneda";
            cboTipoMoneda.Name = "cboTipoMoneda";
            cboTipoMoneda.DataSource = dtTipMoneda;
            cboTipoMoneda.DisplayMember = "cSimbolo";
            cboTipoMoneda.ValueMember = "idMoneda";
            this.dtgEFinSaldos.Columns.Add(cboTipoMoneda);
        }

        private void CalcularTotalSaldoEFin()
        {
            decimal nTotal = 0;
            if (this.listEFinSaldos != null)
                nTotal = this.listEFinSaldos.Sum(x => x.nSCapTotalMA);

            this.txtSaltoTotalEFin.Text = String.Format("{0:n2}", nTotal);
            this.txtSaltoTotal.Text = ObtenerSaldoTotal().ToString("n2");
        }

        // -- 
        private void Registrar()
        {
            this.listEFinSaldos.Add(new clsDeudasEval()
            {
                cNombreEmpresa = "",
                idMoneda = 1,
                //nSCapCortoPlz = 0,
                nTipoCambio = this.nTipoCambio,
                idMonedaMA = this.idMoneda
            });

            this.bindingEFinSaldos.ResetBindings(false);
            this.tsmQuitar.Enabled = true;
        }

        #endregion

        #region Eventos
        private void dtgSaldoDeudas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dtgRCCSaldos.Refresh();
            CalcularTotalSaldoRCC();
        }

        private void dtgRCCSaldos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dtgRCCSaldos.ClearSelection();
        }

        private void dtgCRACSaldos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dtgCRACSaldos.ClearSelection();
        }

        private void dtgEFinSaldos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dtgEFinSaldos.Refresh();
            CalcularTotalSaldoEFin();
        }

        private void dtgEFinSaldos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void tsmQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgEFinSaldos.Enabled == false ||
                            this.dtgEFinSaldos.SelectedCells.Count == 0 ||
                            this.dtgEFinSaldos.CurrentCell == null) return;

            int rowIndex = this.dtgEFinSaldos.CurrentCell.RowIndex;
            this.listEFinSaldos.RemoveAt(rowIndex);
            this.bindingEFinSaldos.ResetBindings(false);

            if (this.dtgEFinSaldos.SelectedCells.Count == 0)
                this.tsmQuitar.Enabled = false;

            CalcularTotalSaldoEFin();
        }

        private void dtg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (((DataGridView)sender).CurrentCell.OwningColumn.DataPropertyName.Equals("nSCapCortoPlz"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void dtgEFinSaldos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dText_KeyPress);

            if (((DataGridView)sender).CurrentCell.OwningColumn.DataPropertyName.Equals("cNombreEmpresa"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dText_KeyPress);
                }
            }
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.dtgEFinSaldos.CurrentCell.OwningColumn.DataPropertyName.Equals("cNombreEmpresa"))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowed only numeric value  ex.10
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaldoDeudasFinanc_Load(object sender, EventArgs e)
        {
            this.btnAceptar.Focus();
        }
        #endregion
    }
}

