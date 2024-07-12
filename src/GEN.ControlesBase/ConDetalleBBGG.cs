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
    public partial class ConDetalleBBGG : UserControl
    {
        private List<clsDetBalGenEval> listMaqEquipos;
        private List<clsDetBalGenEval> listInventario;
        private List<clsDetBalGenEval> listInmuebles;

        private List<clsDescripcionEval> listDescInventario;
        private List<clsDescripcionEval> listDescMaqEquHer;

        private DataTable dtUnidadMedidaInv;
        private DataTable dtTipoInventario;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;
        private string cTipEvaluacion;

        private bool lInventarioAgroEnabled;

        public ConDetalleBBGG()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.nTipoCambio = 1;
            this.idMonedaMA = 1;
            this.cMonedaSimbolo = "S/.";
            this.lInventarioAgroEnabled = false;
        }

        #region "Properties"
        public bool InventarioAgroEnabled
        {
            get { return this.lInventarioAgroEnabled; }
            set { this.lInventarioAgroEnabled = value; }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDataTables(DataTable _dtTipoInventario, List<clsDescripcionEval> _listDescripcionEval)
        {
            this.dtTipoInventario = _dtTipoInventario;

            this.listDescInventario = (from p in _listDescripcionEval
                                       where p.idTipoDescripcion == TipoDescripcion.Inventario
                                       select p).ToList();

            this.listDescMaqEquHer = (from p in _listDescripcionEval
                                      where p.idTipoDescripcion == TipoDescripcion.MaqEquHerramientas
                                      select p).ToList();

            this.dtUnidadMedidaInv = new DataTable();
            this.dtUnidadMedidaInv.Columns.Add("idUnidadMedida", typeof(int));
            this.dtUnidadMedidaInv.Columns.Add("cUnidadMedida", typeof(string));
            this.dtUnidadMedidaInv.Rows.Add(1, "UNIDAD");
            this.dtUnidadMedidaInv.Rows.Add(9999999, "OTROS");
        }

        public void AsignarDatos(List<clsDetBalGenEval> _listMaqEquipos, List<clsDetBalGenEval> _listInventario, List<clsDetBalGenEval> _listInmuebles,
            decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, decimal _nCajaInicial, string cTipEvaluacion = "")
        {
            this.dtgInventario.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInventario_DataBindingComplete);
            this.dtgInventario.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgInventario_EditingControlShowing);
            this.dtgInventario.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgInventario_DataError);
            this.dtgMaqEquipos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaqEquipos_DataBindingComplete);
            this.dtgMaqEquipos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgMaqEquipos_EditingControlShowing);
            this.dtgMaqEquipos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgMaqEquipos_DataError);
            this.dtgInmuebles.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInmuebles_DataBindingComplete);
            this.dtgInmuebles.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgInmuebles_EditingControlShowing);
            this.dtgInmuebles.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgInmuebles_DataError);
            this.nudCajaInicial.DragEnter -= new System.Windows.Forms.DragEventHandler(this.nudCajaInicial_DragEnter);
            this.nudCajaInicial.Validating -= new System.ComponentModel.CancelEventHandler(this.nudCajaInicial_Validating);

            this.listInventario = _listInventario;
            this.listMaqEquipos = _listMaqEquipos;
            this.listInmuebles = _listInmuebles;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;

            this.cTipEvaluacion = cTipEvaluacion;

            PlantillaDefault();

            this.bindingInventario.DataSource = this.listInventario;
            this.dtgInventario.DataSource = this.bindingInventario;
            AgregarComboBoxColumnsDataGridViewInventario();
            FormatearColumnasDataGridViewInventario();

            this.bindingMaqEquipos.DataSource = this.listMaqEquipos;
            this.dtgMaqEquipos.DataSource = this.bindingMaqEquipos;
            AgregarComboBoxColumnsDataGridViewMaqEquipos();
            FormatearColumnasDataGridViewMaqEquipos();

            this.bindingInmuebles.DataSource = this.listInmuebles;
            this.dtgInmuebles.DataSource = this.bindingInmuebles;
            AgregarComboBoxColumnsDataGridViewInmuebles();
            FormatearColumnasDataGridViewInmuebles();

            this.labelTotalInventario.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotalMaqEquipos.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotalInmuebles.Text = "Total " + this.cMonedaSimbolo;
            this.lblBase1.Text = "Valor de Caja Inicial " + this.cMonedaSimbolo;
            this.nudCajaInicial.Value = _nCajaInicial;

            if (cTipEvaluacion == clsVarApl.dicVarGen["cIDsTipEvalCredRural"])
            {
                foreach (DataGridViewRow item in this.dtgInventario.Rows)
                {
                    string descripcion = item.Cells["cDescripcion"].Value != null ? item.Cells["cDescripcion"].Value.ToString() : "";
                    if (descripcion == "INVERSIÓN REALIZADA")
                    {
                        item.ReadOnly = true;
                        item.Cells["cDescripcion"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["dgcboTipoMoneda"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["cUnidMedida"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nCantidad"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nPUnitario"].Style.BackColor = Color.DeepSkyBlue;
                    }
                }

                grbBase1.Visible = false;
            }
                
            this.dtgInventario.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInventario_DataBindingComplete);
            this.dtgInventario.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgInventario_EditingControlShowing);
            this.dtgInventario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgInventario_DataError);
            this.dtgMaqEquipos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMaqEquipos_DataBindingComplete);
            this.dtgMaqEquipos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgMaqEquipos_EditingControlShowing);
            this.dtgMaqEquipos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgMaqEquipos_DataError);
            this.dtgInmuebles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgInmuebles_DataBindingComplete);
            this.dtgInmuebles.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgInmuebles_EditingControlShowing);
            this.dtgInmuebles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgInmuebles_DataError);
            this.nudCajaInicial.DragEnter += new System.Windows.Forms.DragEventHandler(this.nudCajaInicial_DragEnter);
            this.nudCajaInicial.Validating += new System.ComponentModel.CancelEventHandler(this.nudCajaInicial_Validating);

            dtgInventario_DataBindingComplete(null, null);
            dtgMaqEquipos_DataBindingComplete(null, null);
            dtgInmuebles_DataBindingComplete(null, null);

            if (this.listInventario.Count > 0) this.tsmQuitarInv.Enabled = true;
            if (this.listMaqEquipos.Count > 0) this.tsmQuitarMaq.Enabled = true;
            if (this.listInmuebles.Count > 0) this.tsmQuitarInm.Enabled = true;
        }

        public decimal CajaInicial()
        {
            return Convert.ToDecimal(this.nudCajaInicial.Text);
        }
        #endregion

        #region Métodos Privados
        private void PlantillaDefault()
        {
            if (this.listInventario.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.listInventario.Add(new clsDetBalGenEval()
                    {
                        idEEFF = EEFF.Inventario,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCodigoInv = TipoInventario.Otros
                    });
                }
            }

            if (this.listMaqEquipos.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    this.listMaqEquipos.Add(new clsDetBalGenEval()
                    {
                        idEEFF = EEFF.MaqEquipos,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio
                    });
                }
            }

            if (this.listInmuebles.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.listInmuebles.Add(new clsDetBalGenEval()
                    {
                        idEEFF = EEFF.Inmuebles,
                        nCantidad = 1,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio
                    });
                }
            }
        }

        private void FormatearDataGridView()
        {
            this.dtgInventario.Margin = new System.Windows.Forms.Padding(0);
            this.dtgInventario.MultiSelect = false;
            this.dtgInventario.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgIndiFinanc.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgInventario.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgIndiFinanc.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgInventario.RowHeadersVisible = false;
            //this.dtgIndiFinanc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //+this.dtgInventario.ReadOnly = true;
            //this.dtgIndiFinanc.Enabled = false;


            this.dtgMaqEquipos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgMaqEquipos.MultiSelect = false;
            this.dtgMaqEquipos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgMaqEquipos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMaqEquipos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgMaqEquipos.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgMaqEquipos.RowHeadersVisible = false;
            //this.dtgMaqEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgMaqEquipos.ReadOnly = true;
            //this.dtgMaqEquipos.Enabled = false;


            this.dtgInmuebles.Margin = new System.Windows.Forms.Padding(0);
            this.dtgInmuebles.MultiSelect = false;
            this.dtgInmuebles.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgInmuebles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgInmuebles.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgInmuebles.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgInmuebles.RowHeadersVisible = false;
            //this.dtgInmuebles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dtgInmuebles.ReadOnly = true;
            //this.dtgInmuebles.Enabled = false;
        }

        // -- Inventario
        private void AgregarComboBoxColumnsDataGridViewInventario()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = Evaluacion.DataTableMoneda;
            dgcboTipoMoneda.DisplayMember = "cCodSBS";
            dgcboTipoMoneda.ValueMember = "idMoneda";
            this.dtgInventario.Columns.Add(dgcboTipoMoneda);

            DataGridViewComboBoxColumn dgcboTipoInventario = new DataGridViewComboBoxColumn();
            dgcboTipoInventario.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoInventario.FlatStyle = FlatStyle.Popup;
            dgcboTipoInventario.DropDownWidth = 250;
            dgcboTipoInventario.Name = "dgcboTipoInventario";
            dgcboTipoInventario.DataPropertyName = "nCodigoInv";
            dgcboTipoInventario.DataSource = this.dtTipoInventario;
            dgcboTipoInventario.DisplayMember = "cAbreviatura";
            dgcboTipoInventario.ValueMember = "nCodigo";
            this.dtgInventario.Columns.Add(dgcboTipoInventario);
        }

        private void FormatearColumnasDataGridViewInventario()
        {
            foreach (DataGridViewColumn column in this.dtgInventario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgInventario.Columns["dgcboTipoInventario"].DisplayIndex = 0;
            dtgInventario.Columns["cDescripcion"].DisplayIndex = 1;
            dtgInventario.Columns["dgcboTipoMoneda"].DisplayIndex = 2;
            dtgInventario.Columns["cUnidMedida"].DisplayIndex = 3;
            dtgInventario.Columns["nCantidad"].DisplayIndex = 4;
            dtgInventario.Columns["nPUnitario"].DisplayIndex = 5;
            dtgInventario.Columns["nTotal"].DisplayIndex = 6;

            dtgInventario.Columns["dgcboTipoInventario"].Visible = true;
            dtgInventario.Columns["cDescripcion"].Visible = true;
            dtgInventario.Columns["cUnidMedida"].Visible = true;
            dtgInventario.Columns["nPUnitario"].Visible = true;
            dtgInventario.Columns["nCantidad"].Visible = true;
            dtgInventario.Columns["dgcboTipoMoneda"].Visible = true;
            dtgInventario.Columns["nTotal"].Visible = true;

            dtgInventario.Columns["dgcboTipoInventario"].HeaderText = "Codigo";
            dtgInventario.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgInventario.Columns["cUnidMedida"].HeaderText = "Unidad";
            dtgInventario.Columns["nPUnitario"].HeaderText = "P/Unitario";
            dtgInventario.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgInventario.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgInventario.Columns["nTotal"].HeaderText = "Total";

            dtgInventario.Columns["dgcboTipoInventario"].FillWeight = 60;
            dtgInventario.Columns["cDescripcion"].FillWeight = 100;
            dtgInventario.Columns["cUnidMedida"].FillWeight = 40;
            dtgInventario.Columns["nPUnitario"].FillWeight = 40;
            dtgInventario.Columns["nCantidad"].FillWeight = 37;
            dtgInventario.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgInventario.Columns["nTotal"].FillWeight = 50;

            dtgInventario.Columns["cUnidMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInventario.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgInventario.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgInventario.Columns["dgcboTipoInventario"].DefaultCellStyle.ForeColor = Color.Gray;
            dtgInventario.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["cUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInventario.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgInventario.Columns["dgcboTipoInventario"].ReadOnly = true;
            dtgInventario.Columns["nTotal"].ReadOnly = true;

            if (this.lInventarioAgroEnabled == true)
            {
                dtgInventario.Columns["dgcboTipoInventario"].DefaultCellStyle.ForeColor = Color.Black;
                dtgInventario.Columns["dgcboTipoInventario"].ReadOnly = false;
                dtgInventario.Columns["dgcboTipoInventario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            }

        }

        private void CalcularTotalesInventario()
        {
            this.txtTotalInventario.Text = this.listInventario.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Maquinaria y Equipos
        private void AgregarComboBoxColumnsDataGridViewMaqEquipos()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = Evaluacion.DataTableMoneda;
            dgcboTipoMoneda.DisplayMember = "cCodSBS";
            dgcboTipoMoneda.ValueMember = "idMoneda";
            this.dtgMaqEquipos.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewMaqEquipos()
        {
            foreach (DataGridViewColumn column in this.dtgMaqEquipos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgMaqEquipos.Columns["cDescripcion"].DisplayIndex = 0;
            //dtgMaqEquipos.Columns["idUnidMedida"].DisplayIndex = 1;
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgMaqEquipos.Columns["nCantidad"].DisplayIndex = 2;
            dtgMaqEquipos.Columns["nPUnitario"].DisplayIndex = 3;
            dtgMaqEquipos.Columns["nTotal"].DisplayIndex = 4;

            dtgMaqEquipos.Columns["cDescripcion"].Visible = true;
            //dtgMaqEquipos.Columns["idUnidMedida"].Visible = true;
            dtgMaqEquipos.Columns["nPUnitario"].Visible = true;
            dtgMaqEquipos.Columns["nCantidad"].Visible = true;
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgMaqEquipos.Columns["nTotal"].Visible = true;

            dtgMaqEquipos.Columns["cDescripcion"].HeaderText = "Descripción";
            //dtgMaqEquipos.Columns["idUnidMedida"].HeaderText = "Unidad";
            dtgMaqEquipos.Columns["nPUnitario"].HeaderText = "P/Unitario";
            dtgMaqEquipos.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgMaqEquipos.Columns["nTotal"].HeaderText = "Total";

            dtgMaqEquipos.Columns["cDescripcion"].FillWeight = 110;
            //dtgMaqEquipos.Columns["idUnidMedida"].FillWeight = 100;
            dtgMaqEquipos.Columns["nPUnitario"].FillWeight = 40;
            dtgMaqEquipos.Columns["nCantidad"].FillWeight = 37;
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgMaqEquipos.Columns["nTotal"].FillWeight = 50;

            //dtgMaqEquipos.Columns["idUnidMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMaqEquipos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgMaqEquipos.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMaqEquipos.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgMaqEquipos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgMaqEquipos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgMaqEquipos.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgMaqEquipos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgMaqEquipos.Columns["idUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgMaqEquipos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgMaqEquipos.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgMaqEquipos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgMaqEquipos.Columns["nTotal"].ReadOnly = true;
        }

        private void CalcularTotalesMaqEquipos()
        {
            this.txtTotalMaqEquipos.Text = this.listMaqEquipos.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Inmuebles
        private void AgregarComboBoxColumnsDataGridViewInmuebles()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = Evaluacion.DataTableMoneda;
            dgcboTipoMoneda.DisplayMember = "cCodSBS";
            dgcboTipoMoneda.ValueMember = "idMoneda";
            this.dtgInmuebles.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewInmuebles()
        {
            foreach (DataGridViewColumn column in this.dtgInmuebles.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgInmuebles.Columns["cDescripcion"].DisplayIndex = 0;
            //dtgInmuebles.Columns["idUnidMedida"].DisplayIndex = 1;
            //dtgInmuebles.Columns["nPUnitario"].DisplayIndex = 2;
            //dtgInmuebles.Columns["nCantidad"].DisplayIndex = 3;
            dtgInmuebles.Columns["dgcboTipoMoneda"].DisplayIndex = 4;
            dtgInmuebles.Columns["nPUnitario"].DisplayIndex = 5;

            dtgInmuebles.Columns["cDescripcion"].Visible = true;
            //dtgInmuebles.Columns["idUnidMedida"].Visible = true;
            //dtgInmuebles.Columns["nPUnitario"].Visible = true;
            //dtgInmuebles.Columns["nCantidad"].Visible = true;
            dtgInmuebles.Columns["dgcboTipoMoneda"].Visible = true;
            dtgInmuebles.Columns["nPUnitario"].Visible = true;

            dtgInmuebles.Columns["cDescripcion"].HeaderText = "Descripción";
            //dtgMaqEquipos.Columns["idUnidMedida"].HeaderText = "Unidad";
            //dtgInmuebles.Columns["nPUnitario"].HeaderText = "P/Unitario";
            //dtgInmuebles.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgInmuebles.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgInmuebles.Columns["nPUnitario"].HeaderText = "Total";

            dtgInmuebles.Columns["cDescripcion"].FillWeight = 112;
            //dtgInmuebles.Columns["idUnidMedida"].FillWeight = 100;
            //dtgInmuebles.Columns["nPUnitario"].FillWeight = 100;
            //dtgInmuebles.Columns["nCantidad"].FillWeight = 100;
            dtgInmuebles.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgInmuebles.Columns["nPUnitario"].FillWeight = 50;

            //dtgInmuebles.Columns["idUnidMedida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgInmuebles.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgInmuebles.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInmuebles.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgInmuebles.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgInmuebles.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgInmuebles.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            dtgInmuebles.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgInmuebles.Columns["idUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //
            //dtgInmuebles.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInmuebles.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgInmuebles.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesInmuebles()
        {
            this.txtTotalInmuebles.Text = this.listInmuebles.Sum(x => x.nTotalMA).ToString("N2");
        }

        #endregion

        #region Eventos
        private void dtgInventario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //StyleCellDataGridViewCredDirectos();
            CalcularTotalesInventario();
        }

        private void dtgInventario_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
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
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEntero);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion") || dtg.CurrentCell.OwningColumn.Name.Equals("cUnidMedida"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }
        }

        private void dtgInventario_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgMaqEquipos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //StyleCellDataGridViewCredDirectos();
            CalcularTotalesMaqEquipos();
        }

        private void dtgMaqEquipos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
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
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEntero);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }
        }

        private void dtgMaqEquipos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgInmuebles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //StyleCellDataGridViewCredDirectos();
            CalcularTotalesInmuebles();
        }

        private void dtgInmuebles_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }
        }

        private void dtgInmuebles_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void tsmAgregarInv_Click(object sender, EventArgs e)
        {
            this.listInventario.Add(new clsDetBalGenEval()
            {
                idEEFF = EEFF.Inventario,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCodigoInv = TipoInventario.Otros
            });

            this.bindingInventario.ResetBindings(false);
            this.tsmQuitarInv.Enabled = true;

            if (this.cTipEvaluacion == clsVarApl.dicVarGen["cIDsTipEvalCredRural"])
            {
                foreach (DataGridViewRow item in this.dtgInventario.Rows)
                {
                    string descripcion = item.Cells["cDescripcion"].Value != null ? item.Cells["cDescripcion"].Value.ToString() : "";
                    if (descripcion == "INVERSIÓN REALIZADA")
                    {
                        item.ReadOnly = true;
                        item.Cells["cDescripcion"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["dgcboTipoMoneda"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["cUnidMedida"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nCantidad"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nPUnitario"].Style.BackColor = Color.DeepSkyBlue;
                    }
                }
            }

        }

        private void tsmQuitarInv_Click(object sender, EventArgs e)
        {
            if (this.dtgInventario.RowCount == 0 || this.dtgInventario.Enabled == false ||
                this.dtgInventario.SelectedCells.Count <= 0) return;

            string descripcion = this.dtgInventario.CurrentRow.Cells["cDescripcion"].Value != null ? this.dtgInventario.CurrentRow.Cells["cDescripcion"].Value.ToString() : "";

            if (cTipEvaluacion == clsVarApl.dicVarGen["cIDsTipEvalCredRural"] && descripcion == "INVERSIÓN REALIZADA")
            {
                MessageBox.Show("No puede eliminar la Inversión realizada.", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = this.dtgInventario.SelectedCells[0].RowIndex;

            this.listInventario.RemoveAt(rowIndex);
            this.bindingInventario.ResetBindings(false);

            if (this.dtgInventario.SelectedCells.Count == 0)
                this.tsmQuitarInv.Enabled = false;

            if (this.cTipEvaluacion == clsVarApl.dicVarGen["cIDsTipEvalCredRural"])
            {
                foreach (DataGridViewRow item in this.dtgInventario.Rows)
                {
                    string descripcion2 = item.Cells["cDescripcion"].Value != null ? item.Cells["cDescripcion"].Value.ToString() : "";
                    if (descripcion2 == "INVERSIÓN REALIZADA")
                    {
                        item.ReadOnly = true;
                        item.Cells["cDescripcion"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["dgcboTipoMoneda"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["cUnidMedida"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nCantidad"].Style.BackColor = Color.DeepSkyBlue;
                        item.Cells["nPUnitario"].Style.BackColor = Color.DeepSkyBlue;
                    }
                }
            }
        }

        private void tsmAgregarMaq_Click(object sender, EventArgs e)
        {
            this.listMaqEquipos.Add(new clsDetBalGenEval()
            {
                idEEFF = EEFF.MaqEquipos,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio
            });

            this.bindingMaqEquipos.ResetBindings(false);
            this.tsmQuitarMaq.Enabled = true;
        }

        private void tsmQuitarMaq_Click(object sender, EventArgs e)
        {
            if (this.dtgMaqEquipos.RowCount == 0 || this.dtgMaqEquipos.Enabled == false ||
                this.dtgMaqEquipos.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgMaqEquipos.SelectedCells[0].RowIndex;

            this.listMaqEquipos.RemoveAt(rowIndex);
            this.bindingMaqEquipos.ResetBindings(false);

            if (this.dtgMaqEquipos.SelectedCells.Count == 0)
                this.tsmQuitarMaq.Enabled = false;
        }

        private void tsmAgregarInm_Click(object sender, EventArgs e)
        {
            this.listInmuebles.Add(new clsDetBalGenEval()
            {
                idEEFF = EEFF.Inmuebles,
                nCantidad = 1,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio
            });

            this.bindingInmuebles.ResetBindings(false);
            this.tsmQuitarInm.Enabled = true;
        }

        private void tsmQuitarInm_Click(object sender, EventArgs e)
        {
            if (this.dtgInmuebles.RowCount == 0 || this.dtgInmuebles.Enabled == false ||
                this.dtgInmuebles.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgInmuebles.SelectedCells[0].RowIndex;

            this.listInmuebles.RemoveAt(rowIndex);
            this.bindingInmuebles.ResetBindings(false);

            if (this.dtgInmuebles.SelectedCells.Count == 0)
                this.tsmQuitarInm.Enabled = false;
        }

        private void dtgInventario_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboTipoInventario"))
            {
                ComboBox cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    cmbItem.DropDown -= new EventHandler(cboTipoInventario_DropDown);
                    cmbItem.DropDown += new EventHandler(cboTipoInventario_DropDown);

                    cmbItem.DropDownClosed -= new EventHandler(cboTipoInventario_DropDownClosed);
                    cmbItem.DropDownClosed += new EventHandler(cboTipoInventario_DropDownClosed);
                }
            }

        }

        private void cboTipoInventario_DropDown(object sender, EventArgs e)
        {
            // When the drop down list appears, change the DisplayMember property of the ComboBox
            // to 'TypeAndDescription' to show the description
            DataGridViewComboBoxEditingControl cmbBx = sender as DataGridViewComboBoxEditingControl;
            if (cmbBx != null)
                cmbBx.DisplayMember = "cDescripcion";
        }

        private void cboTipoInventario_DropDownClosed(object sender, EventArgs e)
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

        private void nudCajaInicial_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.nudCajaInicial.Text)) this.nudCajaInicial.Text = "0";
        }

        private void nudCajaInicial_DragEnter(object sender, DragEventArgs e)
        {
            int nLonTex = this.nudCajaInicial.Value.ToString().Length;
            this.nudCajaInicial.Select(0, nLonTex);
        }
        #endregion

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
    }
}
