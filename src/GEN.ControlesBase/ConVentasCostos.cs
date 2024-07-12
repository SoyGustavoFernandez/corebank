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
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class ConVentasCostos : UserControl
    {
        private List<clsVentasCostos> listVentasCostos;
        private List<clsCosteo> listCosteo;
        private List<clsDescripcionEval> listDescVentasCostos;
        private List<clsDescripcionEval> listDescUnidadMedida;

        private DataTable dtMoneda;
        private DataTable dtTipoActividad;
        private DataTable dtTipoCosteo;
        private DateTime dFechaBase;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;

        private string cMsjCaption;

        private bool lNuevoRegistro;
        private int nIndexEditado;
        private int indiceDescripcion = 999999999;
        private int indiceUnidMedida = 999999999;
        private int idVentasCostos = 999999999;
        private string cFormatDate = "MMMM/yyyy";
        private bool lPeriodo;

        private int idMonedaCosteo;

        public ConVentasCostos()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.nTipoCambio = 1;
            this.idMonedaMA = 1;
            this.cMonedaSimbolo = "S/.";

            this.cMsjCaption = "Ingreso y Egreso por Actividades";
            this.lblCosteo.Text = "";

            this.lNuevoRegistro = true;
            this.nIndexEditado = -1;
            this.dtgCosteo.Visible = false;
            this.idMonedaCosteo = 1;
            this.lPeriodo = false;

            HabilitarFormulario(false);
        }

        #region "Properties"
        public bool FrecuenciaFechaInicioEnabled
        {
            get
            {
                return this.lPeriodo;
            }
            set
            {
                this.lPeriodo = value;
                //this.cboTipoFrecuencia.Enabled = value;
                //this.cboFechaInicio.Enabled = value;
            }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDataTables(DataTable _dtMoneda, List<clsDescripcionEval> _listDescVentasCostos)
        {
            #region Frecuencias de Pago y Fechas
            // -- CBO
            this.cboTipoFrecuencia.DisplayMember = "cFrecuencia";
            this.cboTipoFrecuencia.ValueMember = "idFrecuencia";
            this.cboTipoFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            this.cboTipoFrecuencia.SelectedIndex = -1;

            this.cboFechaInicio.DisplayMember = "cFechaCorto";
            this.cboFechaInicio.ValueMember = "nMes";
            this.cboFechaInicio.DataSource = Evaluacion.listMesFechasEval;
            this.cboFechaInicio.SelectedIndex = -1;
            #endregion

            #region Global
            this.dtMoneda = _dtMoneda;

            this.dtTipoActividad = new DataTable();
            this.dtTipoActividad.Columns.Add("idTipoActividad", typeof(int));
            this.dtTipoActividad.Columns.Add("cTipoActividad", typeof(string));
            this.dtTipoActividad.Columns.Add("cAbreviatura", typeof(string));
            this.dtTipoActividad.Rows.Add(1, "COMERCIO", "COM");
            this.dtTipoActividad.Rows.Add(2, "PRODUCCIÓN", "PRO");
            this.dtTipoActividad.Rows.Add(3, "SERVICIO", "SER");

            this.cboTipoActividad.DataSource = dtTipoActividad;
            this.cboTipoActividad.DisplayMember = "cTipoActividad";
            this.cboTipoActividad.ValueMember = "idTipoActividad";

            this.listDescUnidadMedida = new List<clsDescripcionEval>();
            this.listDescUnidadMedida.Add(new clsDescripcionEval() { idDescripcionEval = 1, cDescripcion = "UNIDAD" });

            this.bindingUnidadMedida.DataSource = this.listDescUnidadMedida;
            this.cboUnidadMedida.DataSource = this.bindingUnidadMedida;
            this.cboUnidadMedida.DisplayMember = "cDescripcion";
            this.cboUnidadMedida.ValueMember = "idDescripcionEval";

            listDescVentasCostos = _listDescVentasCostos;

            this.bindingDescripcion.DataSource = listDescVentasCostos;
            this.cboDescripcion.DataSource = this.bindingDescripcion;
            this.cboDescripcion.DisplayMember = "cDescripcion";
            this.cboDescripcion.ValueMember = "idDescripcionEval";

            this.dtTipoCosteo = new DataTable();
            this.dtTipoCosteo.Columns.Add("idTipoCosteo", typeof(int));
            this.dtTipoCosteo.Columns.Add("cTipoCosteo", typeof(string));
            //this.dtTipoCosteo.Columns.Add("cAbreviatura", typeof(string));
            this.dtTipoCosteo.Rows.Add(1, "Mat. Prima");
            this.dtTipoCosteo.Rows.Add(2, "Mano Obra");
            this.dtTipoCosteo.Rows.Add(3, "Otros");

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);
            #endregion
        }

        public void AsignarDatos(List<clsVentasCostos> _listVentasCostos, decimal nTipoCambio, int idMonedaMA, string cMonedaSimbolo)
        {
            this.dtgVentasCostos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgVentasCostos_DataBindingComplete);
            this.dtgVentasCostos.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVentasCostos_CellDoubleClick);
            this.cboTipoActividad.SelectedIndexChanged -= new System.EventHandler(this.cboTipoActividad_SelectedIndexChanged);
            this.cboTipoFrecuencia.SelectedIndexChanged -= new System.EventHandler(this.cboTipoFrecuencia_SelectedIndexChanged);
            this.cboMoneda.SelectedIndexChanged -= new System.EventHandler(this.cboMoneda_SelectedIndexChanged);

            this.listVentasCostos = _listVentasCostos;

            this.bindingVentasCostos.DataSource = this.listVentasCostos;
            this.dtgVentasCostos.DataSource = this.bindingVentasCostos;
            AgregarComboBoxColumnsDataGridViewVentasCostos();
            FormatearColumnasDataGridViewVentasCostos();

            this.nTipoCambio = nTipoCambio;
            this.idMonedaMA = idMonedaMA;
            this.cMonedaSimbolo = cMonedaSimbolo;

            this.lblTotalCosteo.Text = "";

            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.cboTipoFrecuencia.SelectedIndexChanged += new System.EventHandler(this.cboTipoFrecuencia_SelectedIndexChanged);
            this.dtgVentasCostos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgVentasCostos_DataBindingComplete);
            this.dtgVentasCostos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVentasCostos_CellDoubleClick);
            this.cboTipoActividad.SelectedIndexChanged += new System.EventHandler(this.cboTipoActividad_SelectedIndexChanged);

            dtgVentasCostos_DataBindingComplete(null, null);

            this.cboTipoFrecuencia.SelectedIndex = 0;
        }

        public List<clsVentasCostos> ListVentasCostos() { return this.listVentasCostos; }
        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgVentasCostos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgVentasCostos.MultiSelect = false;
            this.dtgVentasCostos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgVentasCostos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgVentasCostos.RowHeadersVisible = false;
            this.dtgVentasCostos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgVentasCostos.ReadOnly = true;

            this.dtgCosteo.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCosteo.MultiSelect = false;
            this.dtgCosteo.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgCosteo.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCosteo.RowHeadersVisible = false;
        }

        #region Ventas y Costos
        private void AgregarComboBoxColumnsDataGridViewVentasCostos()
        {
            DataGridViewComboBoxColumn dgcboTipoActividad = new DataGridViewComboBoxColumn();
            dgcboTipoActividad.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            //dgcboTipoActividad.DisplayStyleForCurrentCellOnly = true;
            //dgcboTipoActividad.FlatStyle = FlatStyle.Popup;
            dgcboTipoActividad.Name = "dgcboTipoActividad";
            dgcboTipoActividad.DataPropertyName = "idTipoActividad";
            dgcboTipoActividad.DataSource = this.dtTipoActividad;
            dgcboTipoActividad.DisplayMember = "cAbreviatura";
            dgcboTipoActividad.ValueMember = "idTipoActividad";
            this.dtgVentasCostos.Columns.Add(dgcboTipoActividad);

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            //dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            //dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = this.dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgVentasCostos.Columns.Add(dgcboTipoMoneda);

            DataGridViewComboBoxColumn dgcboTipoFrecuencia = new DataGridViewComboBoxColumn();
            dgcboTipoFrecuencia.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboTipoFrecuencia.Name = "dgcboTipoFrecuencia";
            dgcboTipoFrecuencia.DataPropertyName = "nFrecuencia";
            dgcboTipoFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            dgcboTipoFrecuencia.DisplayMember = "cAbreviatura";
            dgcboTipoFrecuencia.ValueMember = "idFrecuencia";
            this.dtgVentasCostos.Columns.Add(dgcboTipoFrecuencia);

            DataGridViewComboBoxColumn dgcboMesVenta = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboMesVenta.DisplayStyleForCurrentCellOnly = true;
            dgcboMesVenta.FlatStyle = FlatStyle.Popup;
            dgcboMesVenta.Name = "dgcboMesVenta";
            dgcboMesVenta.DataPropertyName = "nMesVenta";
            dgcboMesVenta.DataSource = Evaluacion.listMesFechasEval;
            dgcboMesVenta.DisplayMember = "cFechaCorto";
            dgcboMesVenta.ValueMember = "nMes";
            this.dtgVentasCostos.Columns.Add(dgcboMesVenta);
        }

        private void FormatearColumnasDataGridViewVentasCostos()
        {
            foreach (DataGridViewColumn column in this.dtgVentasCostos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgVentasCostos.Columns["dgcboTipoActividad"].DisplayIndex = 0;
            dtgVentasCostos.Columns["cDescripcion"].DisplayIndex = 1;
            dtgVentasCostos.Columns["dgcboTipoMoneda"].DisplayIndex = 3;
            dtgVentasCostos.Columns["cUnidMedida"].DisplayIndex = 4;
            dtgVentasCostos.Columns["nCantidad"].DisplayIndex = 5;
            dtgVentasCostos.Columns["nPUnitVenta"].DisplayIndex = 6;
            dtgVentasCostos.Columns["nPUnitCosto"].DisplayIndex = 7;
            dtgVentasCostos.Columns["nTotalVentas"].DisplayIndex = 8;
            dtgVentasCostos.Columns["nTotalCostos"].DisplayIndex = 9;
            dtgVentasCostos.Columns["nUtilidadBruta"].DisplayIndex = 10;
            dtgVentasCostos.Columns["nMargenVentas"].DisplayIndex = 11;
            dtgVentasCostos.Columns["dgcboTipoFrecuencia"].DisplayIndex = 12;
            dtgVentasCostos.Columns["dgcboMesVenta"].DisplayIndex = 13;

            dtgVentasCostos.Columns["dgcboTipoActividad"].Visible = true;
            dtgVentasCostos.Columns["cDescripcion"].Visible = true;
            dtgVentasCostos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgVentasCostos.Columns["cUnidMedida"].Visible = true;
            dtgVentasCostos.Columns["nCantidad"].Visible = true;
            dtgVentasCostos.Columns["nPUnitVenta"].Visible = true;
            dtgVentasCostos.Columns["nPUnitCosto"].Visible = true;
            dtgVentasCostos.Columns["nTotalVentas"].Visible = true;
            dtgVentasCostos.Columns["nTotalCostos"].Visible = true;
            dtgVentasCostos.Columns["nUtilidadBruta"].Visible = true;
            dtgVentasCostos.Columns["nMargenVentas"].Visible = true;
            dtgVentasCostos.Columns["dgcboTipoFrecuencia"].Visible = true;
            dtgVentasCostos.Columns["dgcboMesVenta"].Visible = true;

            dtgVentasCostos.Columns["dgcboTipoActividad"].HeaderText = "Act.";
            dtgVentasCostos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgVentasCostos.Columns["dgcboTipoMoneda"].HeaderText = "Mon.";
            dtgVentasCostos.Columns["cUnidMedida"].HeaderText = "Unid. Med.";
            dtgVentasCostos.Columns["nCantidad"].HeaderText = "Cant.";
            dtgVentasCostos.Columns["nPUnitVenta"].HeaderText = "P/Venta Unitario";
            dtgVentasCostos.Columns["nPUnitCosto"].HeaderText = "P/Costo Unitario";
            dtgVentasCostos.Columns["nTotalVentas"].HeaderText = "T/Ventas";
            dtgVentasCostos.Columns["nTotalCostos"].HeaderText = "T/Costos";
            dtgVentasCostos.Columns["nUtilidadBruta"].HeaderText = "Utilidad Bruta";
            dtgVentasCostos.Columns["nMargenVentas"].HeaderText = "Margen Ventas";
            dtgVentasCostos.Columns["dgcboTipoFrecuencia"].HeaderText = "Fr";
            dtgVentasCostos.Columns["dgcboMesVenta"].HeaderText = "MV";
            //dtgVentasCostos.Columns["nMesVenta"].HeaderText = "";

            dtgVentasCostos.Columns["dgcboTipoActividad"].FillWeight = 45;
            dtgVentasCostos.Columns["cDescripcion"].FillWeight = 170; //30 20 
            //dtgVentasCostos.Columns["idDescripcion"].FillWeight = 100;
            dtgVentasCostos.Columns["dgcboTipoMoneda"].FillWeight = 40;
            dtgVentasCostos.Columns["cUnidMedida"].FillWeight = 100;
            dtgVentasCostos.Columns["nCantidad"].FillWeight = 80;
            dtgVentasCostos.Columns["nPUnitVenta"].FillWeight = 100;
            dtgVentasCostos.Columns["nPUnitCosto"].FillWeight = 100;
            dtgVentasCostos.Columns["nTotalVentas"].FillWeight = 110;
            dtgVentasCostos.Columns["nTotalCostos"].FillWeight = 110;
            dtgVentasCostos.Columns["nUtilidadBruta"].FillWeight = 80;     //100
            dtgVentasCostos.Columns["nMargenVentas"].FillWeight = 50;       //60
            dtgVentasCostos.Columns["dgcboTipoFrecuencia"].FillWeight = 50;
            dtgVentasCostos.Columns["dgcboMesVenta"].FillWeight = 70;       //60

            dtgVentasCostos.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgVentasCostos.Columns["nPUnitVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgVentasCostos.Columns["nPUnitCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgVentasCostos.Columns["nTotalVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgVentasCostos.Columns["nTotalCostos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgVentasCostos.Columns["nCantidad"].DefaultCellStyle.Format = "n2";
            dtgVentasCostos.Columns["nPUnitVenta"].DefaultCellStyle.Format = "n2";
            dtgVentasCostos.Columns["nPUnitCosto"].DefaultCellStyle.Format = "n2";
            dtgVentasCostos.Columns["nTotalVentas"].DefaultCellStyle.Format = "n2";
            dtgVentasCostos.Columns["nTotalCostos"].DefaultCellStyle.Format = "n2";
            dtgVentasCostos.Columns["nUtilidadBruta"].DefaultCellStyle.Format = "n0";
            dtgVentasCostos.Columns["nMargenVentas"].DefaultCellStyle.Format = "p0";
            dtgVentasCostos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.Format = "n0";
        }

        private void CalcularTotalesVentasCostos()
        {
            //this.txtTotalInventario.Text = this.listInventario.Sum(x => x.nTotalMA).ToString("N2");
        }
        #endregion

        #region Costeo
        private void AgregarComboBoxColumnsDataGridViewCosteo()
        {
            DataGridViewComboBoxColumn dgcboTipoCosteo = new DataGridViewComboBoxColumn();
            dgcboTipoCosteo.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoCosteo.FlatStyle = FlatStyle.Popup;
            dgcboTipoCosteo.Name = "dgcboTipoCosteo";
            dgcboTipoCosteo.DataPropertyName = "idTipoCosteo";
            dgcboTipoCosteo.DataSource = this.dtTipoCosteo;
            dgcboTipoCosteo.DisplayMember = "cTipoCosteo";
            dgcboTipoCosteo.ValueMember = "idTipoCosteo";
            this.dtgCosteo.Columns.Add(dgcboTipoCosteo);

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = this.dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgCosteo.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewCosteo()
        {
            foreach (DataGridViewColumn column in this.dtgCosteo.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgCosteo.Columns["dgcboTipoCosteo"].DisplayIndex = 1;
            dtgCosteo.Columns["cDescripcion"].DisplayIndex = 2;
            dtgCosteo.Columns["dgcboTipoMoneda"].DisplayIndex = 3;
            //dtgCosteo.Columns["idUnidMedida"].DisplayIndex = 4;
            dtgCosteo.Columns["nCantidad"].DisplayIndex = 5;
            dtgCosteo.Columns["nPUnitario"].DisplayIndex = 6;
            dtgCosteo.Columns["nTotal"].DisplayIndex = 7;

            dtgCosteo.Columns["dgcboTipoCosteo"].Visible = true;
            dtgCosteo.Columns["cDescripcion"].Visible = true;
            dtgCosteo.Columns["dgcboTipoMoneda"].Visible = true;
            //dtgCosteo.Columns["idUnidMedida"].Visible = true;
            dtgCosteo.Columns["nCantidad"].Visible = true;
            dtgCosteo.Columns["nPUnitario"].Visible = true;
            dtgCosteo.Columns["nTotal"].Visible = true;

            dtgCosteo.Columns["dgcboTipoCosteo"].HeaderText = "Tipo";
            dtgCosteo.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgCosteo.Columns["dgcboTipoMoneda"].HeaderText = "Mon.";
            //dtgCosteo.Columns["idUnidMedida"].HeaderText = "Unid. Med.";
            dtgCosteo.Columns["nCantidad"].HeaderText = "Cant.";
            dtgCosteo.Columns["nPUnitario"].HeaderText = "P/Unitario";
            dtgCosteo.Columns["nTotal"].HeaderText = "Total";

            dtgCosteo.Columns["dgcboTipoCosteo"].FillWeight = 45;
            dtgCosteo.Columns["cDescripcion"].FillWeight = 100;
            dtgCosteo.Columns["dgcboTipoMoneda"].FillWeight = 25;
            //dtgCosteo.Columns["idUnidMedida"].FillWeight = 100;
            dtgCosteo.Columns["nCantidad"].FillWeight = 35;
            dtgCosteo.Columns["nPUnitario"].FillWeight = 50;
            dtgCosteo.Columns["nTotal"].FillWeight = 50;

            dtgCosteo.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgCosteo.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCosteo.Columns["nCantidad"].DefaultCellStyle.Format = "n2";
            dtgCosteo.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgCosteo.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgCosteo.Columns["dgcboTipoCosteo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCosteo.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCosteo.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgCosteo.Columns["idUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCosteo.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCosteo.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgCosteo.Columns["nTotal"].ReadOnly = true;
        }

        private void CalcularTotalesCosteo()
        {
            decimal nTotalCosteo = this.listCosteo.Sum(x => x.nTotalMA);

            this.txtTotalCosteo.Text = nTotalCosteo.ToString("N2");

            if (Convert.ToInt32(this.cboTipoActividad.SelectedValue) != TipoIngresoPorActividad.Comercio)
            {
                this.nudPCostoUnitario.Value = nTotalCosteo;
            }
        }
        #endregion

        #region Metodos Generales
        private decimal Cantidad()
        {
            return String.IsNullOrWhiteSpace(this.nudCantidad.Text) ? 0 : Convert.ToDecimal(this.nudCantidad.Text);
        }

        private bool EsDescripcionValido()
        {
            bool lValido = true;
            if (this.cboDescripcion.Enabled == true)
            {
                if (String.IsNullOrEmpty(this.cboDescripcion.Text))
                    lValido = false;
            }
            return lValido;
        }

        private bool EsUnidadMedidaValido()
        {
            bool lValido = true;
            if (this.cboUnidadMedida.Enabled == true)
            {
                if (String.IsNullOrEmpty(this.cboUnidadMedida.Text))
                    lValido = false;
            }
            return lValido;
        }

        private bool EsPVentaUnitarioValido()
        {
            bool lValido = true;
            if (this.nudPVentaUnitario.Enabled == true)
            {
                if (this.nudPVentaUnitario.Value == 0)
                    lValido = false;
            }
            return lValido;
        }

        private bool EsPCostoUnitarioValido()
        {
            bool lValido = true;
            int index = Convert.ToInt32(cboTipoActividad.SelectedValue);

            if (index == TipoIngresoPorActividad.Produccion || index == TipoIngresoPorActividad.Servicio)
            {
                if (this.nudPCostoUnitario.Value == 0)
                    lValido = false;
            }

            return lValido;
        }

        private bool EsCantidadValido()
        {
            bool lValido = true;
            if (this.nudCantidad.Enabled == true)
            {
                if (Cantidad() == 0)
                    lValido = false;
            }

            return lValido;
        }

        public void HabilitarFormulario(bool lHabilitado)
        {
            this.cboTipoActividad.Enabled = lHabilitado;
            this.cboDescripcion.Enabled = lHabilitado;
            this.cboMoneda.Enabled = lHabilitado;
            this.cboUnidadMedida.Enabled = lHabilitado;
            this.nudPVentaUnitario.Enabled = lHabilitado;
            this.nudPCostoUnitario.Enabled = lHabilitado;
            this.nudCantidad.Enabled = lHabilitado;

            this.tsmAgregar.Enabled = lHabilitado;
            this.btnCancelar.Enabled = lHabilitado;

            if (lHabilitado)
                this.cboTipoActividad.Focus();
            else
                this.btnNuevo.Focus();

            this.panelCosteo.Enabled = lHabilitado;

            this.cboTipoFrecuencia.Enabled = (this.lPeriodo == true) ? lHabilitado : false;
            this.cboFechaInicio.Enabled = (this.lPeriodo == true) ? lHabilitado : false; ;

            /*if (this.lPeriodo)
            {
                this.cboTipoFrecuencia.Enabled = lHabilitado;
                this.cboFechaInicio.Enabled = lHabilitado;
            }
            else
            {
            }*/
        }

        public void LimpiarFormulario()
        {
            this.cboTipoActividad.SelectedIndex = -1;
            this.cboDescripcion.Text = "";
            this.cboDescripcion.SelectedIndex = -1;
            this.cboMoneda.SelectedIndex = -1;
            this.cboUnidadMedida.SelectedIndex = -1;
            this.nudPVentaUnitario.Value = 0;
            this.nudPCostoUnitario.Value = 0;
            this.nudCantidad.Text = "0";

            errorProvider.SetError(this.cboDescripcion, String.Empty);
            errorProvider.SetError(this.nudPVentaUnitario, String.Empty);
            errorProvider.SetError(this.nudCantidad, String.Empty);
            errorProvider.SetError(this.nudPCostoUnitario, String.Empty);

            this.lNuevoRegistro = false;
            this.nIndexEditado = -1;

            //---
            this.dtgCosteo.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCosteo_DataBindingComplete);
            this.dtgCosteo.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCosteo_EditingControlShowing);
            this.dtgCosteo.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCosteo_DataError);

            this.listCosteo = null;
            this.listCosteo = new List<clsCosteo>();

            this.bindingCosteo.DataSource = this.listCosteo;
            this.dtgCosteo.DataSource = this.bindingCosteo;
            this.dtgCosteo.Visible = false;
            AgregarComboBoxColumnsDataGridViewCosteo();
            FormatearColumnasDataGridViewCosteo();

            this.lblCosteo.Text = "";

            this.dtgCosteo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCosteo_DataBindingComplete);
            this.dtgCosteo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCosteo_EditingControlShowing);
            this.dtgCosteo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCosteo_DataError);

            dtgCosteo_DataBindingComplete(null, null);
        }

        private clsMsjError ValidarFormulario()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsDescripcionValido())
            {
                objMsjError.AddError("La Descripción esta VACIO o en BLANCO.");
                errorProvider.SetError(this.cboDescripcion, "Es campo es importante.");
            }

            if (!EsPVentaUnitarioValido())
            {
                objMsjError.AddError("El Precio de Venta Unitario es CERO.");
                errorProvider.SetError(this.nudPVentaUnitario, "Ingrese un valor mayor a cero.");
            }

            if (!EsPCostoUnitarioValido())
            {
                objMsjError.AddError("El Precio de Costo Unitario es CERO.");
                errorProvider.SetError(this.nudPCostoUnitario, "Ingrese un valor mayor a cero.");
            }

            if (!EsCantidadValido())
            {
                objMsjError.AddError("La Cantidad es CERO.");
                errorProvider.SetError(this.nudCantidad, "Ingrese un valor mayor a cero.");
            }
            return objMsjError;
        }

        private void RegistrarVentasCostos()
        {
            int indiceDescrip = 0, indiceUnid = 0;
            clsMsjError objMsjError = ValidarFormulario();

            if (objMsjError.HasErrors)
            {
                MessageBox.Show("Corriga los siguientes errores :\n" + objMsjError.GetErrors(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.nIndexEditado != -1)
                this.dtgVentasCostos.CurrentCell = this.dtgVentasCostos.Rows[this.nIndexEditado].Cells["cDescripcion"];

            if (this.cboDescripcion.SelectedItem == null)
            {
                indiceDescrip = indiceDescripcion--;
                this.listDescVentasCostos.Add(new clsDescripcionEval() { idDescripcionEval = indiceDescrip, cDescripcion = this.cboDescripcion.Text });

                this.bindingDescripcion.ResetBindings(false);
                this.cboDescripcion.SelectedValue = indiceDescrip;
            }

            if (this.cboUnidadMedida.SelectedItem == null)
            {
                indiceUnid = indiceUnidMedida--;
                this.listDescUnidadMedida.Add(new clsDescripcionEval() { idDescripcionEval = indiceUnid, cDescripcion = this.cboUnidadMedida.Text });

                this.bindingUnidadMedida.ResetBindings(false);
                this.cboUnidadMedida.SelectedValue = indiceUnid;
            }

            int nfrecuencia = Convert.ToInt32(this.cboTipoFrecuencia.SelectedValue);
            int nMesVenta = Convert.ToInt32(this.cboFechaInicio.SelectedValue);

            clsVentasCostos objVentasCostos = new clsVentasCostos();
            objVentasCostos.idVentasCostos = (this.lNuevoRegistro == true) ? idVentasCostos-- : this.listVentasCostos[this.nIndexEditado].idVentasCostos;
            objVentasCostos.idEvalCred = 0;
            objVentasCostos.idTipoActividad = Convert.ToInt32(this.cboTipoActividad.SelectedValue);
            objVentasCostos.cDescripcion = this.cboDescripcion.Text;
            objVentasCostos.idDescripcion = Convert.ToInt32(this.cboDescripcion.SelectedValue);
            objVentasCostos.idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
            objVentasCostos.cUnidMedida = this.cboUnidadMedida.Text;
            objVentasCostos.idUnidMedida = Convert.ToInt32(this.cboUnidadMedida.SelectedValue);
            objVentasCostos.nCantidad = Cantidad();
            objVentasCostos.nPUnitVenta = this.nudPVentaUnitario.Value;
            objVentasCostos.nPUnitCosto = this.nudPCostoUnitario.Value;
            objVentasCostos.idMonedaMA = this.idMonedaMA;
            objVentasCostos.nFrecuencia = nfrecuencia;
            objVentasCostos.nMesVenta = nMesVenta;
            objVentasCostos.dFechaInicio = this.dFechaBase;
            objVentasCostos.nTipoCambio = this.nTipoCambio;
            objVentasCostos.listCosteo = (objVentasCostos.idTipoActividad == TipoIngresoPorActividad.Comercio) ? new List<clsCosteo>() : this.listCosteo.Select(x => x.GetObject()).ToList();

            if (this.lNuevoRegistro)
            {
                this.listVentasCostos.Add(new clsVentasCostos()
                {
                    idVentasCostos = objVentasCostos.idVentasCostos,
                    idEvalCred = objVentasCostos.idEvalCred,
                    idTipoActividad = objVentasCostos.idTipoActividad,
                    cDescripcion = objVentasCostos.cDescripcion,
                    idDescripcion = objVentasCostos.idDescripcion,
                    idMoneda = objVentasCostos.idMoneda,
                    cUnidMedida = objVentasCostos.cUnidMedida,
                    idUnidMedida = objVentasCostos.idUnidMedida,
                    nCantidad = objVentasCostos.nCantidad,
                    nPUnitVenta = objVentasCostos.nPUnitVenta,
                    nPUnitCosto = objVentasCostos.nPUnitCosto,
                    idMonedaMA = objVentasCostos.idMonedaMA,
                    nFrecuencia = objVentasCostos.nFrecuencia,
                    nMesVenta = objVentasCostos.nMesVenta,
                    dFechaInicio = objVentasCostos.dFechaInicio,
                    listCosteo = objVentasCostos.listCosteo
                });
            }
            else
            {
                int rowIndex = this.dtgVentasCostos.CurrentRow.Index;

                this.listVentasCostos[rowIndex].idVentasCostos = objVentasCostos.idVentasCostos;
                this.listVentasCostos[rowIndex].idEvalCred = objVentasCostos.idEvalCred;
                this.listVentasCostos[rowIndex].idTipoActividad = objVentasCostos.idTipoActividad;
                this.listVentasCostos[rowIndex].cDescripcion = objVentasCostos.cDescripcion;
                this.listVentasCostos[rowIndex].idDescripcion = objVentasCostos.idDescripcion;
                this.listVentasCostos[rowIndex].idMoneda = objVentasCostos.idMoneda;
                this.listVentasCostos[rowIndex].cUnidMedida = objVentasCostos.cUnidMedida;
                this.listVentasCostos[rowIndex].idUnidMedida = objVentasCostos.idUnidMedida;
                this.listVentasCostos[rowIndex].nCantidad = objVentasCostos.nCantidad;
                this.listVentasCostos[rowIndex].nPUnitVenta = objVentasCostos.nPUnitVenta;
                this.listVentasCostos[rowIndex].nPUnitCosto = objVentasCostos.nPUnitCosto;
                this.listVentasCostos[rowIndex].idMonedaMA = objVentasCostos.idMonedaMA;
                this.listVentasCostos[rowIndex].nFrecuencia = objVentasCostos.nFrecuencia;
                this.listVentasCostos[rowIndex].nMesVenta = objVentasCostos.nMesVenta;
                this.listVentasCostos[rowIndex].dFechaInicio = objVentasCostos.dFechaInicio;
                this.listVentasCostos[rowIndex].listCosteo = objVentasCostos.listCosteo;
            }

            CalcularTotalesVentasCostos();
            this.bindingVentasCostos.ResetBindings(false);

            //-----
            if (this.lNuevoRegistro == true && this.dtgVentasCostos.Rows.Count > 1)
            {
                int rows = this.dtgVentasCostos.Rows.Count;
                this.dtgVentasCostos.CurrentCell = this.dtgVentasCostos.Rows[rows - 1].Cells["cDescripcion"];
            }

            LimpiarFormulario();
            HabilitarFormulario(false);
            this.tsmQuitar.Enabled = true;
        }

        private void CambiarTituloCosteo()
        {
            string cDescrip = "";
            string cUnidad = "";

            if (this.panelCosteo.Enabled == true)
            {
                cDescrip = (this.cboDescripcion.Text.Length > 30) ? this.cboDescripcion.Text.Substring(0, 30) + "..." : this.cboDescripcion.Text;
                cUnidad = (this.cboUnidadMedida.Text.Length > 15) ? this.cboUnidadMedida.Text.Substring(0, 15) + "..." : this.cboUnidadMedida.Text;

                this.lblCosteo.Text = String.Format("Costo de \"{0}\" por \"{1}\"", cDescrip, cUnidad);
            }

            this.lblPVentaUnit.Text = "por " + this.cboUnidadMedida.Text;
            this.lblPCostoUnit.Text = "por " + this.cboUnidadMedida.Text;
        }

        private void CambiarMonedaCosteo()
        {
            DataRowView row = ((DataRowView)(this.cboMoneda.SelectedItem));

            if (row != null)
            {
                this.idMonedaCosteo = Convert.ToInt32(row["idMoneda"]);
                this.lblTotalCosteo.Text = "Total " + row["cSimbolo"];

                foreach (clsCosteo objCos in this.listCosteo)
                {
                    objCos.idMonedaMA = this.idMonedaCosteo;
                }

                CalcularTotalesCosteo();
            }
        }
        #endregion
        #endregion

        #region Eventos
        private void dtgVentasCostos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesVentasCostos();
        }

        private void dtgCosteo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
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

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nCantidad"))
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

        private void dtgCosteo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesCosteo();
        }

        private void dtgCosteo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            clsFunUtiles clsfunutiles = new clsFunUtiles();
            clsfunutiles.validarCeldas(dtg, e);
            
            

            //if (e.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Se ingresó un valor invalido en la celda.\nVer Columna \""
            //        + dtg.CurrentCell.OwningColumn.HeaderText + "\" y fila " + (e.RowIndex + 1) + ".",
            //        "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //if ((e.Exception) is ConstraintException)
            //{
            //    dtg.Rows[e.RowIndex].ErrorText = "an error";
            //    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

            //    e.ThrowException = false;
            //}
        }

        private void dtgVentasCostos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            LimpiarFormulario();
            HabilitarFormulario(true);

            this.listCosteo.AddRange(this.listVentasCostos[e.RowIndex].listCosteo.ToList());

            this.cboTipoActividad.SelectedValue = this.listVentasCostos[e.RowIndex].idTipoActividad;
            //this.cboDescripcion.SelectedValue = this.listVentasCostos[e.RowIndex].idDescripcion;
            this.cboDescripcion.Text = this.listVentasCostos[e.RowIndex].cDescripcion;
            this.cboMoneda.SelectedValue = this.listVentasCostos[e.RowIndex].idMoneda;
            //this.cboUnidadMedida.SelectedValue = this.listVentasCostos[e.RowIndex].idUnidMedida;
            this.cboUnidadMedida.Text = this.listVentasCostos[e.RowIndex].cUnidMedida;
            this.nudPVentaUnitario.Value = this.listVentasCostos[e.RowIndex].nPUnitVenta;
            this.nudPCostoUnitario.Value = this.listVentasCostos[e.RowIndex].nPUnitCosto;
            //this.nudCantidad.Value = this.listVentasCostos[e.RowIndex].nCantidad;
            this.nudCantidad.Text = this.listVentasCostos[e.RowIndex].nCantidad.ToString();
            this.cboTipoFrecuencia.SelectedValue = this.listVentasCostos[e.RowIndex].nFrecuencia;
            this.cboFechaInicio.SelectedValue = this.listVentasCostos[e.RowIndex].nMesVenta;

            if (this.cboDescripcion.SelectedItem == null)
                this.cboDescripcion.Text = this.listVentasCostos[e.RowIndex].cDescripcion;

            if (this.cboUnidadMedida.SelectedItem == null)
                this.cboUnidadMedida.Text = this.listVentasCostos[e.RowIndex].cUnidMedida;

            this.nIndexEditado = e.RowIndex;
            this.lNuevoRegistro = false;

            this.bindingCosteo.ResetBindings(false);
        }

        private void cboUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(true);

            this.cboTipoActividad.SelectedIndex = 0;
            this.cboMoneda.SelectedIndex = 0;
            this.cboUnidadMedida.SelectedIndex = 0;

            this.lNuevoRegistro = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistrarVentasCostos();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgVentasCostos.Enabled == false ||
                                        this.dtgVentasCostos.SelectedRows.Count == 0 ||
                                        this.dtgVentasCostos.CurrentRow == null) return;

            int rowIndex = this.dtgVentasCostos.CurrentRow.Index;
            this.listVentasCostos.RemoveAt(rowIndex);
            this.bindingVentasCostos.ResetBindings(false);

            if (this.nIndexEditado == rowIndex)
            {
                this.nIndexEditado = -1;
                this.lNuevoRegistro = true;
            }

            if (this.dtgVentasCostos.SelectedRows.Count == 0)
                this.tsmQuitar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarFormulario(false);
        }

        private void cboDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDescripcionValido())
                errorProvider.SetError(this.cboDescripcion, "Es campo es importante.");
            else
                errorProvider.SetError(this.cboDescripcion, String.Empty);
        }

        private void cboUnidadMedida_Validating(object sender, CancelEventArgs e)
        {
            if (!EsUnidadMedidaValido())
                errorProvider.SetError(this.cboUnidadMedida, "Es campo es importante.");
            else
                errorProvider.SetError(this.cboUnidadMedida, String.Empty);
        }

        private void nudPVentaUnitario_Validating(object sender, CancelEventArgs e)
        {
            if (!EsPVentaUnitarioValido())
                errorProvider.SetError(this.nudPVentaUnitario, "Ingrese un valor mayor a cero.");
            else
                errorProvider.SetError(this.nudPVentaUnitario, String.Empty);
        }

        private void nudPCostoUnitario_Validating(object sender, CancelEventArgs e)
        {
            if (!EsPCostoUnitarioValido())
                errorProvider.SetError(this.nudPCostoUnitario, "Ingrese un valor mayor a cero.");
            else
                errorProvider.SetError(this.nudPCostoUnitario, String.Empty);
        }

        private void nudCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!EsCantidadValido())
                errorProvider.SetError(this.nudCantidad, "Ingrese un valor mayor a cero.");
            else
                errorProvider.SetError(this.nudCantidad, String.Empty);
        }

        private void nudPVentaUnitario_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudPVentaUnitario.Value.ToString("n2").Length;
            nudPVentaUnitario.Select(0, nLonTex);
        }

        private void nudPCostoUnitario_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudPCostoUnitario.Value.ToString("n2").Length;
            nudPCostoUnitario.Select(0, nLonTex);
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            //int nLonTex = nudCantidad.Value.ToString().Length;
            //nudCantidad.Select(0, nLonTex);
        }

        private void cboTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo.SelectedValue != null)
            {
                int index = Convert.ToInt32(cbo.SelectedValue);

                if (index == TipoIngresoPorActividad.Produccion || index == TipoIngresoPorActividad.Servicio)
                {
                    this.panelCosteo.Enabled = true;
                    this.nudPCostoUnitario.Enabled = false;
                    this.dtgCosteo.Visible = true;

                    CambiarTituloCosteo();
                    CambiarMonedaCosteo();

                    #region Plantilla Costeo
                    if (this.lNuevoRegistro == true)
                    {
                        int i = 0;
                        this.listCosteo.Clear();

                        for (i = 0; i < 4; i++)
                        {
                            this.listCosteo.Add(new clsCosteo()
                            {
                                idVentasCostos = idVentasCostos,
                                idTipoCosteo = 1,
                                idMonedaMA = this.idMonedaCosteo,
                                nFrecuencia = 1,
                                dMesVenta = this.dFechaBase.AddMonths(1),
                                nMesVenta = this.dFechaBase.AddMonths(1).Month,
                                nTipoCambio = this.nTipoCambio,
                            });
                        }

                        for (i = 0; i < 2; i++)
                        {
                            this.listCosteo.Add(new clsCosteo()
                            {
                                idVentasCostos = idVentasCostos,
                                idTipoCosteo = 2,
                                idMonedaMA = this.idMonedaCosteo,
                                nFrecuencia = 1,
                                dMesVenta = this.dFechaBase.AddMonths(1),
                                nMesVenta = this.dFechaBase.AddMonths(1).Month,
                                nTipoCambio = this.nTipoCambio,
                            });
                        }

                        for (i = 0; i < 2; i++)
                        {
                            this.listCosteo.Add(new clsCosteo()
                            {
                                idVentasCostos = idVentasCostos,
                                idTipoCosteo = 3,
                                idMonedaMA = this.idMonedaCosteo,
                                nFrecuencia = 1,
                                dMesVenta = this.dFechaBase.AddMonths(1),
                                nMesVenta = this.dFechaBase.AddMonths(1).Month,
                                nTipoCambio = this.nTipoCambio,
                            });
                        }
                        this.bindingCosteo.ResetBindings(false);
                    }
                    #endregion
                }
                else
                {
                    this.panelCosteo.Enabled = false;
                    this.nudPCostoUnitario.Enabled = true;
                    this.lblCosteo.Text = "";
                    this.dtgCosteo.Visible = false;
                }

                //CalcularTotalesCosteo();
            }
        }

        private void stmAgregarCosteo_Click(object sender, EventArgs e)
        {
            CambiarTituloCosteo();

            this.listCosteo.Add(new clsCosteo()
            {
                idCosteo = 0,
                idEvalCred = 0,
                idVentasCostos = (this.lNuevoRegistro == true) ? idVentasCostos : this.listVentasCostos[this.nIndexEditado].idVentasCostos,
                idTipoCosteo = 1,
                idMoneda = 1,
                nCantidad = 0,
                nPUnitario = 0,
                idMonedaMA = this.idMonedaCosteo,
                nFrecuencia = 1,
                dMesVenta = this.dFechaBase.AddMonths(1),
                nMesVenta = this.dFechaBase.AddMonths(1).Month,
                nTipoCambio = this.nTipoCambio,
            });

            this.bindingCosteo.ResetBindings(false);
        }

        private void stmQuitarCosteo_Click(object sender, EventArgs e)
        {
            if (this.dtgCosteo.Enabled == false ||
                                        this.dtgCosteo.SelectedCells.Count == 0 ||
                                        this.dtgCosteo.CurrentCell == null) return;

            int rowIndex = this.dtgCosteo.CurrentRow.Index;
            this.listCosteo.RemoveAt(rowIndex);
            this.bindingCosteo.ResetBindings(false);

            if (this.dtgCosteo.SelectedCells.Count == 0)
                this.stmQuitarCosteo.Enabled = false;
        }

        private void cboDescripcion_TextChanged(object sender, EventArgs e)
        {
            CambiarTituloCosteo();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarMonedaCosteo();
        }

        private void cboUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarTituloCosteo();
        }

        private void cboUnidadMedida_TextChanged(object sender, EventArgs e)
        {
            CambiarTituloCosteo();
        }

        private void cboTipoFrecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoFrecuencia.SelectedItem == null) return;

            this.cboFechaInicio.DataSource = null;

            int nFrecuencia = Convert.ToInt32(this.cboTipoFrecuencia.SelectedValue);

            this.cboFechaInicio.DisplayMember = "cFechaCorto";
            this.cboFechaInicio.ValueMember = "nMes";
            this.cboFechaInicio.DataSource = Evaluacion.listMesFechasEval.Where(x => x.nMes <= nFrecuencia).ToList(); ;
            this.cboFechaInicio.SelectedIndex = 0;

            this.lblCantidad.Text = this.cboTipoFrecuencia.Text;
        }

        private void cboDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
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

        private void ConVentasCostos_Load(object sender, EventArgs e)
        {
            this.cboUnidadMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboUnidadMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDescripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDescripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
    }
}
