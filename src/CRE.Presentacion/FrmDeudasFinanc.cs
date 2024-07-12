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
using System.Xml.Linq;

namespace CRE.Presentacion
{
    public partial class FrmDeudasFinanc : frmBase
    {
        private DataTable dtMoneda;
        private DataTable dtTipoCreRCD;

        private List<clsDeudasEval> listCredDirectos;
        private List<clsDeudasEval> listCredIndirect;

        private clsCNEvaluacion objCNEvaluacion;

        private decimal nTipoCambio = 0;
        private int idMoneda = 0;
        private string cMonedaSimbolo;
        private decimal nSaldoTotalDeudasDirectas;

        private int idEvalCred;

        public bool lGuardado = false;
        private int indexCategory = -1;
        private ComboBox cmbItem;
        private DataTable dtDeudaCA;
        private string cCodigoCracLasa = "00169";

        private DataTable dtUtilizada;
        private DataTable dtTipoInterv;

        public FrmDeudasFinanc()
        {
            InitializeComponent();
        }

        public FrmDeudasFinanc(int _idEvalCred, decimal nTipoCambio, int idMoneda, string cMonedaSimbolo)
        {
            InitializeComponent();
            FormatearDataGridView();

            this.listCredDirectos = null;
            this.listCredIndirect = null;

            this.idEvalCred = _idEvalCred;

            this.nTipoCambio = nTipoCambio;
            this.idMoneda = idMoneda;
            this.cMonedaSimbolo = cMonedaSimbolo;
            this.nSaldoTotalDeudasDirectas = 0;

            this.lblTotalCredDir.Text = "Total " + this.cMonedaSimbolo;
            this.lblTotalCredInd.Text = "Total " + this.cMonedaSimbolo;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.tabPage1.Enabled = false;

            this.objCNEvaluacion = new clsCNEvaluacion();
        }

        #region Métodos Públicos
        public List<clsDeudasEval> CredDirectos()
        {
            return this.listCredDirectos;
        }

        public List<clsDeudasEval> CredIndirect()
        {
            return this.listCredIndirect;
        }
        #endregion

        #region Métodos Privados

        private void AsignarDataTable(DataTable _dtTipoCreRCD)
        {
            this.dtTipoCreRCD = _dtTipoCreRCD;

            this.dtDeudaCA = new DataTable();
            this.dtDeudaCA.Columns.Add("idDeudaCA", typeof(int));
            this.dtDeudaCA.Columns.Add("cDeudaCA", typeof(string));
            this.dtDeudaCA.Columns.Add("cAbreviatura", typeof(string));
            this.dtDeudaCA.Rows.Add(1, "Normal", "NR");
            this.dtDeudaCA.Rows.Add(2, "Compra Deuda", "CD");
            this.dtDeudaCA.Rows.Add(3, "Ampliación", "AM");
            this.dtDeudaCA.Rows.Add(4, "Reprogramación", "RE");
            this.dtDeudaCA.Rows.Add(5, "Refinanciamiento", "RF");

            this.dtUtilizada = new DataTable();
            this.dtUtilizada.Columns.Add("lUtilizada",typeof(bool));
            this.dtUtilizada.Columns.Add("cUtilizada", typeof(string));
            this.dtUtilizada.Columns.Add("cAbreviatura",typeof(string));
            this.dtUtilizada.Rows.Add(1, "Utilizada", "U");
            this.dtUtilizada.Rows.Add(0, "No Utilizada", "NU");

            this.dtTipoInterv = new DataTable();
            this.dtTipoInterv.Columns.Add("idTipoInterv", typeof(int));
            this.dtTipoInterv.Columns.Add("cTipoInterv", typeof(string));
            this.dtTipoInterv.Columns.Add("cAbreviatura", typeof(string));
            this.dtTipoInterv.Rows.Add(1, "TITULAR", "TI");
            this.dtTipoInterv.Rows.Add(2, "CONYUGE TITULAR", "CTI");
            this.dtTipoInterv.Rows.Add(3, "FIADOR SOLIDARIO", "FS");
            this.dtTipoInterv.Rows.Add(4, "CONYUGE DE FIADOR SOLIDARIO", "CFS");
            this.dtTipoInterv.Rows.Add(5, "CODEUDOR", "CO");
            this.dtTipoInterv.Rows.Add(9, "REPRESENTANTE LEGAL", "RL");
            this.dtTipoInterv.Rows.Add(11, "CONSORCIO", "CN");
            this.dtTipoInterv.Rows.Add(12, "CONYUGE DE CODEUDOR", "CCO");
            this.dtTipoInterv.Rows.Add(0, "...Seleccione...", "--");
        }

        private void AsignarDatos(List<clsDeudasEval> _listCredDirectos, List<clsDeudasEval> _listCredIndirect)
        {
            this.dtgCredDirectos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCredDirectos_DataBindingComplete);
            this.dtgCredDirectos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCredDirectos_EditingControlShowing);
            this.dtgCredDirectos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCredDirectos_DataError);
            this.dtgCredIndirect.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCredIndirect_DataBindingComplete);
            this.dtgCredIndirect.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCredIndirect_EditingControlShowing);
            this.dtgCredIndirect.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCredIndirect_DataError);

            this.listCredDirectos = _listCredDirectos;
            this.listCredIndirect = _listCredIndirect;

            this.bindingCredDirectos.DataSource = listCredDirectos;
            this.dtgCredDirectos.DataSource = this.bindingCredDirectos;
            this.AgregarComboBoxColumnsDataGridViewCredDirectos();
            this.FormatearColumnasDataGridViewCredDirectos();
            this.dtgCredDirectos.ClearSelection();

            this.bindingCredIndirect.DataSource = listCredIndirect;
            this.dtgCredIndirect.DataSource = this.bindingCredIndirect;
            this.AgregarComboBoxColumnsDataGridViewCredIndirect();
            this.FormatearColumnasDataGridViewCredIndirect();
            this.dtgCredIndirect.ClearSelection();

            StyleCellDataGridViewCredDirectos();
            StyleCellDataGridViewCredIndirect();

            CalcularTotales();

            this.dtgCredDirectos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCredDirectos_DataBindingComplete);
            this.dtgCredDirectos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCredDirectos_EditingControlShowing);
            this.dtgCredDirectos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCredDirectos_DataError);
            this.dtgCredIndirect.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCredIndirect_DataBindingComplete);
            this.dtgCredIndirect.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCredIndirect_EditingControlShowing);
            this.dtgCredIndirect.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCredIndirect_DataError);
        }

        private void FormatearDataGridView()
        {
            this.dtMoneda = Evaluacion.DataTableMoneda;

            this.dtgCredDirectos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCredDirectos.MultiSelect = false;
            this.dtgCredDirectos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDeudasCredDir.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgCredDirectos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDeudasCredDir.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgCredDirectos.RowHeadersVisible = false;
            //this.dtgDeudasCredDir.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgDeudasCredDir.ReadOnly = true;
            //this.dtgDeudasCredDir.Enabled = false;

            this.dtgCredIndirect.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCredIndirect.MultiSelect = false;
            this.dtgCredIndirect.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgDeudasCredDir.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgCredIndirect.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgDeudasCredDir.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgCredIndirect.RowHeadersVisible = false;
            //this.dtgDeudasCredDir.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgDeudasCredDir.ReadOnly = true;
            //this.dtgDeudasCredDir.Enabled = false;
        }

        // -- Créditos Directos
        private void FormatearColumnasDataGridViewCredDirectos()
        {
            foreach (DataGridViewColumn column in this.dtgCredDirectos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dtgCredDirectos.Columns["dgcboDeudaCA"].DisplayIndex = 1;
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].DisplayIndex = 1;
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].DisplayIndex = 2;
            dtgCredDirectos.Columns["cNombreEmpresa"].DisplayIndex = 3;
            dtgCredDirectos.Columns["dgcboTipoMoneda"].DisplayIndex = 4;
            dtgCredDirectos.Columns["nMontoAprobado"].DisplayIndex = 5;
            dtgCredDirectos.Columns["nSCapTotalSis"].DisplayIndex = 6;
            dtgCredDirectos.Columns["nSCapTotal"].DisplayIndex = 7;
            dtgCredDirectos.Columns["nSCapCortoPlz"].DisplayIndex = 8;
            dtgCredDirectos.Columns["nSCapLargoPlz"].DisplayIndex = 9;
            dtgCredDirectos.Columns["nCuotasPag"].DisplayIndex = 10;
            dtgCredDirectos.Columns["nCuotasPen"].DisplayIndex = 11;
            dtgCredDirectos.Columns["nCuotasTotal"].DisplayIndex = 12;
            dtgCredDirectos.Columns["nMontoCuota"].DisplayIndex = 13;
            dtgCredDirectos.Columns["dgbtnCronograma"].DisplayIndex = 14;

            dtgCredDirectos.Columns["dgcboUtilizada"].DisplayIndex = 15;
            dtgCredDirectos.Columns["dgcboTipoInterv"].DisplayIndex = 16;

            dtgCredDirectos.Columns["dgcboDeudaCA"].Visible = true;
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].Visible = true;
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].Visible = true;
            dtgCredDirectos.Columns["cNombreEmpresa"].Visible = true;
            dtgCredDirectos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgCredDirectos.Columns["nSCapTotalSis"].Visible = true;
            dtgCredDirectos.Columns["nSCapTotal"].Visible = true;
            dtgCredDirectos.Columns["nSCapCortoPlz"].Visible = true;
            dtgCredDirectos.Columns["nSCapLargoPlz"].Visible = true;
            dtgCredDirectos.Columns["nMontoAprobado"].Visible = true;
            dtgCredDirectos.Columns["nMontoCuota"].Visible = true;
            dtgCredDirectos.Columns["dgbtnCronograma"].Visible = true;
            dtgCredDirectos.Columns["nCuotasPag"].Visible = true;
            dtgCredDirectos.Columns["nCuotasPen"].Visible = true;
            dtgCredDirectos.Columns["nCuotasTotal"].Visible = true;

            dtgCredDirectos.Columns["dgcboUtilizada"].Visible = true;
            dtgCredDirectos.Columns["dgcboTipoInterv"].Visible = true;


            dtgCredDirectos.Columns["dgcboDeudaCA"].HeaderText = "C/A";
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].HeaderText = "C.D.";
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].HeaderText = "Tipo de Crédito";
            dtgCredDirectos.Columns["cNombreEmpresa"].HeaderText = "Entidad Financiera";
            dtgCredDirectos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgCredDirectos.Columns["nSCapTotalSis"].HeaderText = "Saldo Obtenido";
            dtgCredDirectos.Columns["nSCapTotal"].HeaderText = "Saldo Actual";
            dtgCredDirectos.Columns["nSCapCortoPlz"].HeaderText = "Saldo C/P";
            dtgCredDirectos.Columns["nSCapLargoPlz"].HeaderText = "Saldo L/P";
            dtgCredDirectos.Columns["nMontoAprobado"].HeaderText = "Monto";
            dtgCredDirectos.Columns["nMontoCuota"].HeaderText = "Cuota";
            dtgCredDirectos.Columns["dgbtnCronograma"].HeaderText = " ";
            dtgCredDirectos.Columns["nCuotasPag"].HeaderText = "C. Pag.";
            dtgCredDirectos.Columns["nCuotasPen"].HeaderText = "C. Pen.";
            dtgCredDirectos.Columns["nCuotasTotal"].HeaderText = "C. Tot.";

            dtgCredDirectos.Columns["dgcboUtilizada"].HeaderText = "Línea";
            dtgCredDirectos.Columns["dgcboTipoInterv"].HeaderText = "Tp.Interv.";

            dtgCredDirectos.Columns["dgcboDeudaCA"].ToolTipText = "Crédito para Compra de Deuda/Ampliación";
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].ToolTipText = "¿Crédito para Compra de Deuda?";
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].ToolTipText = "Tipo de Crédito";
            dtgCredDirectos.Columns["cNombreEmpresa"].ToolTipText = "";
            dtgCredDirectos.Columns["dgcboTipoMoneda"].ToolTipText = "Moneda";
            dtgCredDirectos.Columns["nSCapTotalSis"].ToolTipText = "Saldo Capital Obtenido";
            dtgCredDirectos.Columns["nSCapTotal"].ToolTipText = "Saldo Capital Actual";
            dtgCredDirectos.Columns["nSCapCortoPlz"].ToolTipText = "Saldo Capital Corto/Plazo";
            dtgCredDirectos.Columns["nSCapLargoPlz"].ToolTipText = "Saldo Capital Largo/Plazo";
            dtgCredDirectos.Columns["nMontoAprobado"].ToolTipText = "Monto Prestado/Aprobado";
            dtgCredDirectos.Columns["nMontoCuota"].ToolTipText = "Cuota";
            dtgCredDirectos.Columns["dgbtnCronograma"].ToolTipText = "Cronograma de Pagos";
            dtgCredDirectos.Columns["nCuotasPag"].ToolTipText = "Cuotas Pagadas";
            dtgCredDirectos.Columns["nCuotasPen"].ToolTipText = "Cuotas Pendientes";
            dtgCredDirectos.Columns["nCuotasTotal"].ToolTipText = "Total Cuotas";

            dtgCredDirectos.Columns["dgcboUtilizada"].ToolTipText = "Línea de Crédito Utilizada/No Utilizada";
            dtgCredDirectos.Columns["dgcboTipoInterv"].ToolTipText = "Tipo de Interviniente";

            dtgCredDirectos.Columns["dgcboDeudaCA"].FillWeight = 30;
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].FillWeight = 30;
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].FillWeight = 160;
            dtgCredDirectos.Columns["cNombreEmpresa"].FillWeight = 130;
            dtgCredDirectos.Columns["dgcboTipoMoneda"].FillWeight = 30;
            dtgCredDirectos.Columns["nSCapTotalSis"].FillWeight = 60;
            dtgCredDirectos.Columns["nSCapTotal"].FillWeight = 60;
            dtgCredDirectos.Columns["nSCapCortoPlz"].FillWeight = 60;
            dtgCredDirectos.Columns["nSCapLargoPlz"].FillWeight = 60;
            dtgCredDirectos.Columns["nMontoAprobado"].FillWeight = 60;
            dtgCredDirectos.Columns["nMontoCuota"].FillWeight = 60;
            dtgCredDirectos.Columns["dgbtnCronograma"].FillWeight = 16;
            dtgCredDirectos.Columns["nCuotasPag"].FillWeight = 30;
            dtgCredDirectos.Columns["nCuotasPen"].FillWeight = 30;
            dtgCredDirectos.Columns["nCuotasTotal"].FillWeight = 30;

            dtgCredDirectos.Columns["dgcboUtilizada"].FillWeight = 60;
            dtgCredDirectos.Columns["dgcboTipoInterv"].FillWeight = 60;

            dtgCredDirectos.Columns["dgcboTipoCreRCD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgCredDirectos.Columns["cNombreEmpresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgCredDirectos.Columns["nSCapTotalSis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCredDirectos.Columns["nSCapTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCredDirectos.Columns["nSCapCortoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCredDirectos.Columns["nSCapLargoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCredDirectos.Columns["nMontoAprobado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCredDirectos.Columns["nSCapTotalSis"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nSCapTotal"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nSCapCortoPlz"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nSCapLargoPlz"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nMontoAprobado"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nMontoCuota"].DefaultCellStyle.Format = "n2";
            dtgCredDirectos.Columns["nCuotasPag"].DefaultCellStyle.Format = "n0";
            dtgCredDirectos.Columns["nCuotasPen"].DefaultCellStyle.Format = "n0";
            dtgCredDirectos.Columns["nCuotasTotal"].DefaultCellStyle.Format = "n0";

            dtgCredDirectos.Columns["dgcboDeudaCA"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgCredDirectos.Columns["dgcboCompraDeuda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["dgcboTipoCreRCD"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["cNombreEmpresa"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgCredDirectos.Columns["nSCapTotalSis"].FillWeight = 60;
            //dtgCredDirectos.Columns["nSCapTotal"].FillWeight = 60;
            dtgCredDirectos.Columns["nSCapCortoPlz"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["nSCapLargoPlz"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["nMontoAprobado"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["nMontoCuota"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["nCuotasPag"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["nCuotasPen"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgCredDirectos.Columns["nCuotasTotal"].FillWeight = 30;
            dtgCredDirectos.Columns["dgcboUtilizada"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredDirectos.Columns["dgcboTipoInterv"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;


            dtgCredDirectos.Columns["nSCapTotalSis"].ReadOnly = true;
            dtgCredDirectos.Columns["nSCapTotal"].ReadOnly = true;
            dtgCredDirectos.Columns["nCuotasTotal"].ReadOnly = true;
            dtgCredDirectos.Columns["dgbtnCronograma"].ReadOnly = true;

            this.indexCategory = dtgCredDirectos.Columns.IndexOf(dtgCredDirectos.Columns["dgcboDeudaCA"]);
        }

        private void AgregarComboBoxColumnsDataGridViewCredDirectos()
        {
            DataGridViewComboBoxColumn dgcboDeudaCA = new DataGridViewComboBoxColumn();
            //dgcboCompraDeuda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboDeudaCA.DisplayStyleForCurrentCellOnly = true;
            dgcboDeudaCA.FlatStyle = FlatStyle.Popup;
            dgcboDeudaCA.DropDownWidth = 100;
            dgcboDeudaCA.Name = "dgcboDeudaCA";
            dgcboDeudaCA.DataPropertyName = "idDeudaCA";
            dgcboDeudaCA.DataSource = this.dtDeudaCA;
            dgcboDeudaCA.DisplayMember = dtDeudaCA.Columns["cAbreviatura"].ToString();
            dgcboDeudaCA.ValueMember = dtDeudaCA.Columns["idDeudaCA"].ToString();
            this.dtgCredDirectos.Columns.Add(dgcboDeudaCA);

            DataGridViewComboBoxColumn dgcboTipoCreRCD = new DataGridViewComboBoxColumn();
            //dgcboTipoCreRCD.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipoCreRCD.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoCreRCD.FlatStyle = FlatStyle.Popup;
            dgcboTipoCreRCD.DropDownWidth = 300;
            dgcboTipoCreRCD.DataPropertyName = "idTipoCredito";
            dgcboTipoCreRCD.Name = "dgcboTipoCreRCD";
            dgcboTipoCreRCD.DisplayMember = "cDescripcion";
            dgcboTipoCreRCD.ValueMember = "idTipoCredito";
            dgcboTipoCreRCD.DataSource = this.dtTipoCreRCD;
            this.dtgCredDirectos.Columns.Add(dgcboTipoCreRCD);

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgCredDirectos.Columns.Add(dgcboTipoMoneda);

            DataGridViewButtonColumn dgbtnCronograma = new DataGridViewButtonColumn();
            dgbtnCronograma.Name = "dgbtnCronograma";
            dgbtnCronograma.Text = "...";
            dgbtnCronograma.UseColumnTextForButtonValue = true;
            this.dtgCredDirectos.Columns.Add(dgbtnCronograma);

            DataGridViewComboBoxColumn dgcboUtilizada = new DataGridViewComboBoxColumn();
            dgcboUtilizada.DisplayStyleForCurrentCellOnly = true;
            dgcboUtilizada.FlatStyle = FlatStyle.Popup;
            dgcboUtilizada.Name = "dgcboUtilizada";
            dgcboUtilizada.DataPropertyName = "lUtilizada";
            dgcboUtilizada.DataSource = this.dtUtilizada;
            dgcboUtilizada.DisplayMember = this.dtUtilizada.Columns["cAbreviatura"].ToString();
            dgcboUtilizada.ValueMember = this.dtUtilizada.Columns["lUtilizada"].ToString();
            this.dtgCredDirectos.Columns.Add(dgcboUtilizada);

            DataGridViewComboBoxColumn dgcboTipoInterv = new DataGridViewComboBoxColumn();
            dgcboTipoInterv.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoInterv.FlatStyle = FlatStyle.Popup;
            dgcboTipoInterv.Name = "dgcboTipoInterv";
            dgcboTipoInterv.DataPropertyName = "idTipoInterv";
            dgcboTipoInterv.DataSource = this.dtTipoInterv;
            dgcboTipoInterv.DisplayMember = this.dtTipoInterv.Columns["cTipoInterv"].ToString();
            dgcboTipoInterv.ValueMember = this.dtTipoInterv.Columns["idTipoInterv"].ToString();
            this.dtgCredDirectos.Columns.Add(dgcboTipoInterv);
        }

        private void StyleCellDataGridViewCredDirectos()
        {
            string cCodigoEmpresa = "";
            bool lAutomatico = false;
            int idDeudaCA = 1;

            foreach (DataGridViewRow row in this.dtgCredDirectos.Rows)
            {
                lAutomatico = Convert.ToBoolean(row.Cells["lAutomatico"].Value);
                cCodigoEmpresa = row.Cells["cCodigoEmpresa"].Value.ToString();

                if (lAutomatico)
                {
                    row.Cells["dgcboTipoCreRCD"].ReadOnly = true;
                    row.Cells["cNombreEmpresa"].ReadOnly = true;
                    row.Cells["dgcboTipoMoneda"].ReadOnly = true;
                    row.Cells["dgcboUtilizada"].ReadOnly = true;
                    row.Cells["dgcboTipoInterv"].ReadOnly = true;

                    row.Cells["dgcboTipoCreRCD"].Style.BackColor = Color.White;
                    row.Cells["cNombreEmpresa"].Style.BackColor = Color.White;
                    row.Cells["dgcboTipoMoneda"].Style.BackColor = Color.White;
                    row.Cells["dgcboUtilizada"].Style.BackColor = Color.White;
                    row.Cells["dgcboTipoInterv"].Style.BackColor = Color.White;
                }

                idDeudaCA = Convert.ToInt32(row.Cells["dgcboDeudaCA"].Value);

                if (idDeudaCA == 2 || idDeudaCA == 3 || idDeudaCA == 4 || idDeudaCA == 5)
                {
                    row.Cells["nMontoCuota"].Style.BackColor = Color.White;
                    row.Cells["nMontoCuota"].ReadOnly = true;
                }
                else
                {
                    row.Cells["nMontoCuota"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    row.Cells["nMontoCuota"].ReadOnly = false;
                }

                /*if (cCodigoEmpresa.Equals(this.cCodigoCracLasa))
                {
                    row.Cells["nMontoCuota"].Style.BackColor = Color.White;
                    row.Cells["nMontoCuota"].ReadOnly = true;
                };*/
            }
        }

        // -- Créditos Indirectos
        private void FormatearColumnasDataGridViewCredIndirect()
        {
            foreach (DataGridViewColumn column in this.dtgCredIndirect.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].DisplayIndex = 1;
            dtgCredIndirect.Columns["cNombreEmpresa"].DisplayIndex = 2;
            dtgCredIndirect.Columns["dgcboTipoMoneda"].DisplayIndex = 3;
            dtgCredIndirect.Columns["nSCapTotalSis"].DisplayIndex = 4;
            dtgCredIndirect.Columns["nSCapLargoPlz"].DisplayIndex = 5;

            dtgCredIndirect.Columns["dgcboUtilizada"].DisplayIndex = 6;
            dtgCredIndirect.Columns["dgcboTipoInterv"].DisplayIndex = 7;

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].Visible = true;
            dtgCredIndirect.Columns["cNombreEmpresa"].Visible = true;
            dtgCredIndirect.Columns["dgcboTipoMoneda"].Visible = true;
            dtgCredIndirect.Columns["nSCapTotalSis"].Visible = true;
            dtgCredIndirect.Columns["nSCapLargoPlz"].Visible = true;

            dtgCredIndirect.Columns["dgcboUtilizada"].Visible = true;
            dtgCredIndirect.Columns["dgcboTipoInterv"].Visible = true;

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].HeaderText = "Tipo de Crédito";
            dtgCredIndirect.Columns["cNombreEmpresa"].HeaderText = "Entidad Financiera";
            dtgCredIndirect.Columns["dgcboTipoMoneda"].HeaderText = "Mon.";
            dtgCredIndirect.Columns["nSCapTotalSis"].HeaderText = "Saldo Obtenido";
            dtgCredIndirect.Columns["nSCapLargoPlz"].HeaderText = "Saldo Actual";

            dtgCredIndirect.Columns["dgcboUtilizada"].HeaderText = "Línea";
            dtgCredIndirect.Columns["dgcboTipoInterv"].HeaderText = "Tp.Interv.";

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].ToolTipText = "Tipo de Crédito";
            dtgCredIndirect.Columns["dgcboTipoMoneda"].ToolTipText = "Moneda";
            dtgCredIndirect.Columns["nSCapTotalSis"].ToolTipText = "Saldo Capital Obtenido";
            dtgCredIndirect.Columns["nSCapLargoPlz"].ToolTipText = "Saldo Capital Actual";

            dtgCredIndirect.Columns["dgcboUtilizada"].ToolTipText = "Línea de Crédito Utilizada/No Utilizada";
            dtgCredIndirect.Columns["dgcboTipoInterv"].ToolTipText = "Tipo de Interviniente";

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].FillWeight = 160;
            dtgCredIndirect.Columns["cNombreEmpresa"].FillWeight = 130;
            dtgCredIndirect.Columns["dgcboTipoMoneda"].FillWeight = 30;
            dtgCredIndirect.Columns["nSCapTotalSis"].FillWeight = 60;
            dtgCredIndirect.Columns["nSCapLargoPlz"].FillWeight = 60;

            dtgCredIndirect.Columns["dgcboUtilizada"].FillWeight = 30;
            dtgCredIndirect.Columns["dgcboTipoInterv"].FillWeight = 60;

            dtgCredIndirect.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCredIndirect.Columns["nSCapTotalSis"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCredIndirect.Columns["nSCapLargoPlz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCredIndirect.Columns["nSCapTotalSis"].DefaultCellStyle.Format = "N2";
            dtgCredIndirect.Columns["nSCapLargoPlz"].DefaultCellStyle.Format = "N2";

            dtgCredIndirect.Columns["dgcboTipoCreRCD"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredIndirect.Columns["cNombreEmpresa"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredIndirect.Columns["nSCapLargoPlz"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredIndirect.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredIndirect.Columns["dgcboUtilizada"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCredIndirect.Columns["dgcboTipoInterv"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            //dtgCredIndirect.Columns["dgcboTipoCreRCD"].ReadOnly = true;
            //dtgCredIndirect.Columns["cNombreEmpresa"].ReadOnly = true;
            //dtgCredIndirect.Columns["dgcboTipoMoneda"].ReadOnly = true;
            dtgCredIndirect.Columns["nSCapTotalSis"].ReadOnly = true;
        }

        private void AgregarComboBoxColumnsDataGridViewCredIndirect()
        {
            DataGridViewComboBoxColumn dgcboTipoCreRCD = new DataGridViewComboBoxColumn();
            //dgcboTipoCreRCD.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipoCreRCD.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoCreRCD.FlatStyle = FlatStyle.Popup;
            dgcboTipoCreRCD.DropDownWidth = 300;
            dgcboTipoCreRCD.DataPropertyName = "idTipoCredito";
            dgcboTipoCreRCD.Name = "dgcboTipoCreRCD";
            dgcboTipoCreRCD.DisplayMember = "cDescripcion";
            dgcboTipoCreRCD.ValueMember = "idTipoCredito";
            dgcboTipoCreRCD.DataSource = this.dtTipoCreRCD;
            this.dtgCredIndirect.Columns.Add(dgcboTipoCreRCD);

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgCredIndirect.Columns.Add(dgcboTipoMoneda);

            DataGridViewComboBoxColumn dgcboUtilizada = new DataGridViewComboBoxColumn();
            dgcboUtilizada.DisplayStyleForCurrentCellOnly = true;
            dgcboUtilizada.FlatStyle = FlatStyle.Popup;
            dgcboUtilizada.Name = "dgcboUtilizada";
            dgcboUtilizada.DataPropertyName = "lUtilizada";
            dgcboUtilizada.DataSource = this.dtUtilizada;
            dgcboUtilizada.DisplayMember = this.dtUtilizada.Columns["cAbreviatura"].ToString();
            dgcboUtilizada.ValueMember = this.dtUtilizada.Columns["lUtilizada"].ToString();
            this.dtgCredIndirect.Columns.Add(dgcboUtilizada);

            DataGridViewComboBoxColumn dgcboTipoInterv = new DataGridViewComboBoxColumn();
            dgcboTipoInterv.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoInterv.FlatStyle = FlatStyle.Popup;
            dgcboTipoInterv.Name = "dgcboTipoInterv";
            dgcboTipoInterv.DataPropertyName = "idTipoInterv";
            dgcboTipoInterv.DataSource = this.dtTipoInterv;
            dgcboTipoInterv.DisplayMember = this.dtTipoInterv.Columns["cTipoInterv"].ToString();
            dgcboTipoInterv.ValueMember = this.dtTipoInterv.Columns["idTipoInterv"].ToString();
            this.dtgCredIndirect.Columns.Add(dgcboTipoInterv);
        }

        private void StyleCellDataGridViewCredIndirect()
        {
            bool lAutomatico = false;
            foreach (DataGridViewRow row in this.dtgCredIndirect.Rows)
            {
                lAutomatico = Convert.ToBoolean(row.Cells["lAutomatico"].Value);

                if (lAutomatico)
                {
                    row.Cells["dgcboTipoCreRCD"].ReadOnly = true;
                    row.Cells["cNombreEmpresa"].ReadOnly = true;
                    row.Cells["dgcboTipoMoneda"].ReadOnly = true;
                    row.Cells["dgcboUtilizada"].ReadOnly = true;
                    row.Cells["dgcboTipoInterv"].ReadOnly = true;

                    row.Cells["dgcboTipoCreRCD"].Style.BackColor = Color.White;
                    row.Cells["cNombreEmpresa"].Style.BackColor = Color.White;
                    row.Cells["dgcboTipoMoneda"].Style.BackColor = Color.White;
                    row.Cells["dgcboUtilizada"].Style.BackColor = Color.White;
                    row.Cells["dgcboTipoInterv"].Style.BackColor = Color.White;
                }
            }
        }

        // -- 
        private void CalcularTotales()
        {
            foreach (clsDeudasEval oCredDir in this.listCredDirectos)
            {
                if (oCredDir.idDeudaCA == 2 || oCredDir.idDeudaCA == 3 || oCredDir.idDeudaCA == 4 || oCredDir.idDeudaCA == 5)
                {
                    oCredDir.nMontoCuota = 0;
                }
            }

            this.txtTotalSCapCPlazo.Text = this.listCredDirectos.Sum(x => x.nSCapCortoPlzMA).ToString("N2");
            this.txtTotalSCapLPlazo.Text = this.listCredDirectos.Sum(x => x.nSCapLargoPlzMA).ToString("N2");
            this.txtTotalMontoCuota.Text = this.listCredDirectos.Sum(x => x.nMontoCuotaMA).ToString("N2");

            this.txtTotalSaldo.Text = this.listCredIndirect.Sum(x => x.nSCapLargoPlzMA).ToString("N2");
        }

        private string SaldosEnXML(List<clsDeudasEval> listDeudas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDeudasEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idTipoDeuda", typeof(int));
            dt.Columns.Add("idDeudaCA", typeof(int));
            dt.Columns.Add("cCodigoEmpresa", typeof(string));
            dt.Columns.Add("cNombreEmpresa", typeof(string));
            dt.Columns.Add("idCuenta", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nMontoAprobado", typeof(decimal));
            dt.Columns.Add("nCuotasPag", typeof(int));
            dt.Columns.Add("nCuotasPen", typeof(int));
            dt.Columns.Add("nCuotasTotal", typeof(int));
            dt.Columns.Add("nSCapTotalSis", typeof(decimal));
            dt.Columns.Add("nSCapTotal", typeof(decimal));
            dt.Columns.Add("nSCapCortoPlz", typeof(decimal));
            dt.Columns.Add("nSCapLargoPlz", typeof(decimal));
            dt.Columns.Add("nMontoCuota", typeof(decimal));
            //dt.Columns.Add("cCronograma", typeof(string));
            dt.Columns.Add("dFechaConsulta", typeof(DateTime));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("lAutomatico", typeof(bool));
            dt.Columns.Add("idTipoCredito", typeof(int));
            dt.Columns.Add("cGUID", typeof(string));

            dt.Columns.Add("lUtilizada", typeof(bool));
            dt.Columns.Add("idTipoInterv", typeof(int));

            foreach (var deuda in listDeudas)
            {
                DataRow row = dt.NewRow();

                row["idDeudasEval"] = deuda.idDeudasEval;
                //newCustomersRow["idEvalCred"] = rcc.idEvalCred;
                row["idTipoDeuda"] = deuda.idTipoDeuda;
                row["idDeudaCA"] = deuda.idDeudaCA;
                row["cCodigoEmpresa"] = deuda.cCodigoEmpresa;
                row["cNombreEmpresa"] = deuda.cNombreEmpresa;
                row["idCuenta"] = deuda.idCuenta;
                row["idProducto"] = deuda.idProducto;
                row["idMoneda"] = deuda.idMoneda;
                row["nMontoAprobado"] = deuda.nMontoAprobado;
                row["nCuotasPag"] = deuda.nCuotasPag;
                row["nCuotasPen"] = deuda.nCuotasPen;
                row["nCuotasTotal"] = deuda.nCuotasTotal;
                row["nSCapTotalSis"] = deuda.nSCapTotalSis;
                row["nSCapTotal"] = deuda.nSCapTotal;
                row["nSCapCortoPlz"] = deuda.nSCapCortoPlz;
                row["nSCapLargoPlz"] = deuda.nSCapLargoPlz;
                row["nMontoCuota"] = deuda.nMontoCuota;
                //row["cCronograma"] = deuda.cCronograma;
                row["dFechaConsulta"] = deuda.dFechaConsulta;
                row["idMonedaMA"] = Evaluacion.idMoneda;
                row["lAutomatico"] = deuda.lAutomatico;
                row["idTipoCredito"] = deuda.idTipoCredito;
                row["cGUID"] = deuda.cGUID;


                row["lUtilizada"] = deuda.lUtilizada;
                row["idTipoInterv"] = deuda.idTipoInterv;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DeudasEval", "Item");
        }

        private void RecuperarDeudas()
        {
            DataSet ds = (new clsCNEvalPyme()).DeudasEntFinancieras(this.idEvalCred);
            DataTable _dtTipoCreRCD = ds.Tables[0];

            DataRow row = _dtTipoCreRCD.NewRow();
            row["idTipoCredito"] = 0;
            row["cDescripcion"] = "--Seleccione--";
            _dtTipoCreRCD.Rows.InsertAt(row, 0);

            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[1]) as List<clsDeudasEval>;
            var listDeudaCuotaPago = DataTableToList.ConvertTo<clsCuotaPago>(ds.Tables[2]) as List<clsCuotaPago>;

            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();

            foreach (clsDeudasEval oDeudasEval in listSalRCCDirectos)
            {
                var listDCPago = (from p in listDeudaCuotaPago
                                  where p.idDeudasEval == oDeudasEval.idDeudasEval
                                  select p).ToList();

                oDeudasEval.listCuotaPago = (listDCPago.Count > 0) ? listDCPago : new List<clsCuotaPago>();
            }

            AsignarDataTable(_dtTipoCreRCD);
            AsignarDatos(listSalRCCDirectos, listSalRCCDIndirec);
        }

        #endregion

        #region Eventos
        private void FrmDeudasFinanc_Load(object sender, EventArgs e)
        {
            RecuperarDeudas();
        }

        private void dtgCredDirectos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            // --
            if (dtg.CurrentCell.OwningColumn.Name.Equals("nMontoAprobado") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("nSCapCortoPlz") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("nSCapLargoPlz") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("nMontoCuota")
            )
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
            else if (dtg.CurrentCell.OwningColumn.Name.Equals("nCuotasPag") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("nCuotasPen"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEntero);
                }
            }

            // --
            if (dtg.CurrentCell.OwningColumn.Name.Equals("cNombreEmpresa"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }

            // -- 
            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboDeudaCA"))
            {
                cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    //cmbItem.DropDown -= new EventHandler(cboDeudaCA_DropDown);
                    cmbItem.DropDown += new EventHandler(cboDeudaCA_DropDown);

                    cmbItem.DropDownClosed -= new EventHandler(cboDeudaCA_DropDownClosed);
                    cmbItem.DropDownClosed += new EventHandler(cboDeudaCA_DropDownClosed);
                }
            }
        }

        private void dtgCredDirectos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            StyleCellDataGridViewCredDirectos();
            CalcularTotales();
        }

        private void dtgCredDirectos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgCredIndirect_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            // --
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nSCapLargoPlz"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            // --
            if (dtg.CurrentCell.OwningColumn.Name.Equals("cNombreEmpresa"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }
        }

        private void dtgCredIndirect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            StyleCellDataGridViewCredIndirect();
            CalcularTotales();
        }

        private void dtgCredIndirect_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void tsmAgregarCredInd_Click(object sender, EventArgs e)
        {
            this.listCredIndirect.Add(new clsDeudasEval()
            {
                idTipoDeuda = 2,
                idDeudaCA = 1,
                lAutomatico = false,
                idTipoCredito = 0,
                idMoneda = 1,
                idMonedaMA = Evaluacion.idMoneda,
                nTipoCambio = Evaluacion.TipoCambio,
                lUtilizada = true,
                idTipoInterv = 1
            });

            this.bindingCredIndirect.ResetBindings(false);
            this.tsmQuitarCredInd.Enabled = true;
        }

        private void tsmQuitarCredInd_Click(object sender, EventArgs e)
        {
            if (this.dtgCredIndirect.RowCount == 0 || this.dtgCredIndirect.Enabled == false ||
                this.dtgCredIndirect.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgCredIndirect.SelectedCells[0].RowIndex;

            if (this.listCredIndirect[rowIndex].lAutomatico) return;

            this.listCredIndirect.RemoveAt(rowIndex);
            this.bindingCredIndirect.ResetBindings(false);

            if (this.dtgCredIndirect.SelectedCells.Count == 0)
                this.tsmQuitarCredInd.Enabled = false;
        }

        private void tsmAgregarCredDir_Click(object sender, EventArgs e)
        {
            this.listCredDirectos.Add(new clsDeudasEval()
            {
                idTipoDeuda = 1,
                idDeudaCA = 1,
                lAutomatico = false,
                idTipoCredito = 0,
                idMoneda = 1,
                idMonedaMA = Evaluacion.idMoneda,
                nTipoCambio = Evaluacion.TipoCambio,
                lUtilizada = true,
                idTipoInterv = 1
            });

            this.bindingCredDirectos.ResetBindings(false);
            this.tsmQuitarCredDir.Enabled = true;
        }

        private void tsmQuitarCredDir_Click(object sender, EventArgs e)
        {
            if (this.dtgCredDirectos.RowCount == 0 || this.dtgCredDirectos.Enabled == false ||
                this.dtgCredDirectos.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgCredDirectos.SelectedCells[0].RowIndex;

            if (this.listCredDirectos[rowIndex].lAutomatico) return;

            this.listCredDirectos.RemoveAt(rowIndex);
            this.bindingCredDirectos.ResetBindings(false);

            if (this.dtgCredDirectos.SelectedCells.Count == 0)
                this.tsmQuitarCredDir.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<clsDeudasEval> deudasFinancieras = new List<clsDeudasEval>();
            List<clsCuotaPago> deudasCuotasPago = new List<clsCuotaPago>();

            foreach (clsDeudasEval deuda in this.listCredDirectos)
            {
                deudasFinancieras.Add(deuda);
                foreach (clsCuotaPago oCuota in deuda.listCuotaPago)
                {
                    oCuota.idDeudasEval = deuda.idDeudasEval;
                    oCuota.cGUID = deuda.cGUID;

                    deudasCuotasPago.Add(oCuota);
                }
            }

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            DateTime dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);
            int nNroMesesEvalPyme = 1;
            decimal nCIndirectosTotalSaldoMN = 0;
            decimal nCIndirectosTotalSaldoME = 0;
            int nNroMesesEvalPymeVar1 = Convert.ToInt32(clsVarApl.dicVarGen["nNroMesesEvalPymeVar1"]);
            int nNroMesesEvalPymeVar2 = Convert.ToInt32(clsVarApl.dicVarGen["nNroMesesEvalPymeVar2"]);
            decimal nMontoTopEvalPymeVar1 = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopEvalPymeVar1"]);
            decimal nMontoTopEvalPymeVar2 = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoTopEvalPymeVar2"]);
            decimal nProvEstResultadosEvalPyme = Convert.ToDecimal(clsVarApl.dicVarGen["nProvEstResultadosEvalPyme"]);

            nCIndirectosTotalSaldoMN = this.listCredIndirect.Where(x => x.idMoneda == 1).Sum(x => x.nSCapLargoPlz);
            nCIndirectosTotalSaldoME = this.listCredIndirect.Where(x => x.idMoneda == 2).Sum(x => x.nSCapLargoPlz);

            nCIndirectosTotalSaldoMN += clsMathFinanciera.Convertir(2,1,nCIndirectosTotalSaldoME,this.nTipoCambio);

            if (nCIndirectosTotalSaldoMN <= nMontoTopEvalPymeVar1) nNroMesesEvalPyme = nNroMesesEvalPymeVar1;
            else if (nCIndirectosTotalSaldoMN <= nMontoTopEvalPymeVar2) nNroMesesEvalPyme = nNroMesesEvalPymeVar2;

            decimal nProvicion = clsNumerico.Dividir(nCIndirectosTotalSaldoMN * nProvEstResultadosEvalPyme, nNroMesesEvalPyme);

            foreach (clsDeudasEval deuda in this.listCredIndirect)
            {
                deudasFinancieras.Add(deuda);
                decimal nMontoMN = deuda.idMoneda == 1 ? deuda.nSCapLargoPlz : clsMathFinanciera.Convertir(2, 1, deuda.nSCapLargoPlz, this.nTipoCambio);
                decimal nProvicionDeuda = clsNumerico.Dividir(nMontoMN * nProvEstResultadosEvalPyme, nNroMesesEvalPyme);
                for (int i = 0; i < nNroMesesEvalPyme; i++)
                {
                    var objCuotaPago = new clsCuotaPago();
                    objCuotaPago.idDeudasEval = deuda.idDeudasEval;
                    objCuotaPago.cGUID = deuda.cGUID;
                    objCuotaPago.nContador = i + 1;
                    objCuotaPago.nMes = i + 1;
                    objCuotaPago.nMonto = nProvicionDeuda;
                    objCuotaPago.nFrecuencia = 1;
                    objCuotaPago.dFechaInicio = dFechaBase;
                    objCuotaPago.idMoneda = 0;
                    objCuotaPago.idMonedaMA = 0;
                    objCuotaPago.nMontoMA = nProvicionDeuda;

                    deudasCuotasPago.Add(objCuotaPago);
                }
            }

            this.nSaldoTotalDeudasDirectas = this.listCredDirectos.Sum(x => x.nSCapTotalMA);

            string xmlDeudasEval = SaldosEnXML(deudasFinancieras);
            string xmlDeudasCuotaPago = deudasCuotasPago.GetXml();
            this.objCNEvaluacion.ActualizarDeudasFinancieras(this.idEvalCred, this.nSaldoTotalDeudasDirectas, xmlDeudasEval, xmlDeudasCuotaPago);

            this.tabPage1.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;
        }

        private void cboDeudaCA_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtgCredDirectos.CurrentRow.Cells[this.indexCategory].FormattedValue.ToString()))
                return;

            if (!dtgCredDirectos.CurrentRow.Cells["cCodigoEmpresa"].Value.ToString().Equals(this.cCodigoCracLasa))
            {
                DataTable dtDeudaCA = new DataTable();
                dtDeudaCA.Columns.Add("idDeudaCA", typeof(int));
                dtDeudaCA.Columns.Add("cDeudaCA", typeof(string));
                dtDeudaCA.Columns.Add("cAbreviatura", typeof(string));
                dtDeudaCA.Rows.Add(1, "Normal", "NR");
                dtDeudaCA.Rows.Add(2, "Compra Deuda", "CD");

                cmbItem.DisplayMember = "cAbreviatura";
                cmbItem.ValueMember = "idDeudaCA";
                cmbItem.DataSource = dtDeudaCA;
            }
            else
            {
                cmbItem.DisplayMember = "cAbreviatura";
                cmbItem.ValueMember = "idDeudaCA";
                cmbItem.DataSource = this.dtDeudaCA;
            }

            int categoryID = Convert.ToInt32(dtgCredDirectos.CurrentRow.Cells[this.indexCategory].Value);

            // When the drop down list appears, change the DisplayMember property of the ComboBox
            // to 'TypeAndDescription' to show the description
            DataGridViewComboBoxEditingControl cmbBx = sender as DataGridViewComboBoxEditingControl;
            if (cmbBx != null)
                cmbBx.DisplayMember = "cDeudaCA";
        }

        private void cboDeudaCA_DropDownClosed(object sender, EventArgs e)
        {
            // When the drop down list is closed, change the DisplayMember property of the ComboBox
            // back to 'Type' to hide the description
            DataGridViewComboBoxEditingControl cmbBx = sender as DataGridViewComboBoxEditingControl;
            if (cmbBx != null)
            {
                int index = cmbBx.SelectedIndex;
                cmbBx.DisplayMember = "cAbreviatura";
                cmbBx.SelectedIndex = index;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.tabPage1.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            //this.btnAceptar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.tabPage1.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            RecuperarDeudas();
        }

        private void dtgCredDirectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dtg = ((DataGridView)sender);

            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgbtnCronograma"))
            {
                // if (this.listCredDirectos[e.RowIndex].cCodigoEmpresa.Equals(this.cCodigoCracLasa)) return;
                if (this.listCredDirectos[e.RowIndex].nCuotasPen == 0)
                {
                    MessageBox.Show("Las Cuotas Pendientes esta en CERO.", "Cronograma Pagos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                frmCronogramaDeudas frmCronogramaDeudas = new frmCronogramaDeudas(this.listCredDirectos[e.RowIndex].GetObject());
                frmCronogramaDeudas.ShowDialog();

                this.listCredDirectos[e.RowIndex].listCuotaPago = frmCronogramaDeudas.ListCuotaPago();
                this.listCredDirectos[e.RowIndex].cCronograma = "";
                this.listCredDirectos[e.RowIndex].nMontoCuota = frmCronogramaDeudas.PromedioCuota();

                frmCronogramaDeudas.Dispose();

                this.bindingCredDirectos.ResetBindings(false);
            }
        }

        private void dtgCredDirectos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbItem != null)
            {
                cmbItem.DropDown -= new EventHandler(cboDeudaCA_DropDown);
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

        public void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion
    }
}
