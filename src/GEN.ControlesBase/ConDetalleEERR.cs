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
    public partial class ConDetalleEERR : UserControl
    {
        private List<clsDetEstResEval> listGFamiliares;
        private List<clsDetEstResEval> listGPersonales;
        private List<clsDetEstResEval> listGOperativos;
        private List<clsDetEstResEval> listOtrosEgresos;
        private List<clsDetEstResEval> listOtrosIngresos;
        private List<clsVarFlujoCajaEval> listCicloVentas;
        private List<clsVarFlujoCajaEval> listReinversiones;
        private List<clsVarFlujoCajaEval> listVarGastosFam;

        private List<clsDescripcionEval> listDescGastosPersonal;
        private List<clsDescripcionEval> listDescGastosOperativos;
        private List<clsDescripcionEval> listDescGastosFamiliares;
        private List<clsDescripcionEval> listDescOtrosEgresos;

        private DataTable dtMoneda;
        private DateTime dFechaBase;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;

        private int indiceGastosPersonal = 999999999;
        private int indiceGastosOperativos = 999999999;
        private int indiceGastosFamiliares = 999999999;

        private ComboBox cmbItem;
        private ComboBox cmbCategory;

        private int indexCategory = -1;
        private int indexItem = -1;
        private int idEvalCred = -1;

        private bool lPeriodoGOperaEnabled;
        private bool lGPersonalesVisible;

        public ConDetalleEERR()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.idEvalCred = 0;
            this.nTipoCambio = 1;
            this.idMonedaMA = 1;
            this.cMonedaSimbolo = "S/.";
            this.lPeriodoGOperaEnabled = false;
            this.lGPersonalesVisible = true;
        }

        #region "Properties"
        public bool FrecuenciaMesVentaEnabled
        {
            get { return this.lPeriodoGOperaEnabled; }
            set { this.lPeriodoGOperaEnabled = value; }
        }

        public bool GastosPersonalVisible
        {
            get { return this.lGPersonalesVisible; }
            set
            {
                this.lGPersonalesVisible = value;

                if (!this.lGPersonalesVisible)
                {
                    this.panelGPersonales.Visible = false;
                    this.panelGPersonales.Location = new System.Drawing.Point(3, 2000);
                    this.panelOtrosIngresos.Location = new System.Drawing.Point(2, 195);
                    this.panelOtrosEgresos.Location = new System.Drawing.Point(3, 312);
                }
                else
                {
                    this.panelGPersonales.Visible = true;
                }
            }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDataTables(DataTable _dtMoneda, List<clsDescripcionEval> _listDescGastos)
        {
            this.dtMoneda = _dtMoneda;

            this.listDescGastosPersonal = (from p in _listDescGastos
                                           where p.idTipoDescripcion == TipoDescripcion.GastosPersonal
                                           select p).ToList();

            this.listDescGastosOperativos = (from p in _listDescGastos
                                             where p.idTipoDescripcion == TipoDescripcion.GastosOperativos
                                             select p).ToList();

            this.listDescGastosFamiliares = (from p in _listDescGastos
                                             where p.idTipoDescripcion == TipoDescripcion.GastosFamiliares
                                             select p).ToList();

            this.listDescOtrosEgresos = (from p in _listDescGastos
                                         where p.idTipoDescripcion == TipoDescripcion.OtrosEgresos
                                         select p).ToList();

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);
        }

        public void AsignarDatos(List<clsDetEstResEval> _listGFamiliares, List<clsDetEstResEval> _listGPersonal, List<clsDetEstResEval> _listGOperativos, List<clsDetEstResEval> _listOtrosIngresos, List<clsDetEstResEval> _listOtrosEgresos,
            List<clsVarFlujoCajaEval> _listCicloVentas, List<clsVarFlujoCajaEval> _listVarGastosFam, List<clsVarFlujoCajaEval> _listReinversiones,
            decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, int _idEvalCred)
        {

            #region Eventos -
            this.dtgGFamiliares.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);
            this.dtgGPersonales.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGPersonales_DataBindingComplete);
            this.dtgGPersonales.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGPersonales_EditingControlShowing);
            this.dtgGPersonales.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGPersonales_DataError);
            this.dtgGOperativos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGOperativos_EditingControlShowing);
            this.dtgGOperativos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGOperativos_DataError);
            this.dtgGOperativos.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGOperativos_CellLeave);
            this.dtgOtrosIngresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosIngresos_DataBindingComplete);
            this.dtgOtrosIngresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgOtrosIngresos_EditingControlShowing);
            this.dtgOtrosIngresos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgOtrosIngresos_DataError);
            this.dtgOtrosEgresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosEgresos_DataBindingComplete);
            this.dtgOtrosEgresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgOtrosEgresos_EditingControlShowing);
            this.dtgOtrosEgresos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgOtrosEgresos_DataError);
            this.dtgCicloVentas.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentas_EditingControlShowing);
            this.dtgCicloVentas.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentas_DataError);
            this.dtgVarGastosFam.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgVarGastosFam_EditingControlShowing);
            this.dtgVarGastosFam.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgVarGastosFam_DataError);
            this.dtgReinversiones.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgReinversiones_EditingControlShowing);
            this.dtgReinversiones.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgReinversiones_DataError);
            #endregion

            this.listGFamiliares = _listGFamiliares;
            this.listGPersonales = _listGPersonal;
            this.listGOperativos = _listGOperativos;
            this.listOtrosEgresos = _listOtrosEgresos;
            this.listOtrosIngresos = _listOtrosIngresos;
            this.listCicloVentas = _listCicloVentas;
            this.listVarGastosFam = _listVarGastosFam;
            this.listReinversiones = _listReinversiones;


            foreach (clsVarFlujoCajaEval oCiVtn in this.listCicloVentas)
                oCiVtn.nPorcentaje = oCiVtn.nMonto * 100;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idEvalCred = _idEvalCred;

            PlantillaDefault();

            #region Asignacion de datos
            this.bindingGFamiliares.DataSource = this.listGFamiliares;
            this.dtgGFamiliares.DataSource = this.bindingGFamiliares;
            AgregarComboBoxColumnsDataGridViewGFamiliares();
            FormatearColumnasDataGridViewGFamiliares();

            this.bindingGPersonales.DataSource = this.listGPersonales;
            this.dtgGPersonales.DataSource = this.bindingGPersonales;
            AgregarComboBoxColumnsDataGridViewGPersonales();
            FormatearColumnasDataGridViewGPersonales();

            this.bindingGOperativos.DataSource = this.listGOperativos;
            this.dtgGOperativos.DataSource = this.bindingGOperativos;
            AgregarComboBoxColumnsDataGridViewGOperativos();
            FormatearColumnasDataGridViewGOperativos();

            this.bindingCicloVentas.DataSource = this.listCicloVentas;
            this.dtgCicloVentas.DataSource = this.bindingCicloVentas;
            AgregarComboBoxColumnsDataGridViewCicloVentas();
            FormatearColumnasDataGridViewCicloVentas();

            this.bindingOtrosEgresos.DataSource = this.listOtrosEgresos;
            this.dtgOtrosEgresos.DataSource = this.bindingOtrosEgresos;
            AgregarComboBoxColumnsDataGridViewOtrosEgresos();
            FormatearColumnasDataGridViewOtrosEgresos();

            this.bindingOtrosIngresos.DataSource = this.listOtrosIngresos;
            this.dtgOtrosIngresos.DataSource = this.bindingOtrosIngresos;
            AgregarComboBoxColumnsDataGridViewOtrosIngresos();
            FormatearColumnasDataGridViewOtrosIngresos();

            this.bindingReinversiones.DataSource = this.listReinversiones;
            this.dtgReinversiones.DataSource = this.bindingReinversiones;
            AgregarComboBoxColumnsDataGridViewReinversiones();
            FormatearColumnasDataGridViewReinversiones();

            this.bindingVarGastosFam.DataSource = this.listVarGastosFam;
            this.dtgVarGastosFam.DataSource = this.bindingVarGastosFam;
            AgregarComboBoxColumnsDataGridViewVariacionVentas();
            FormatearColumnasDataGridViewVariacionVentas();

            this.labelTotaldtgGFamiliares.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgGPersonal.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgGOperativos.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgOtrosIngresos.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgOtrosEgresos.Text = "Total " + this.cMonedaSimbolo;
            this.grbBase.Text = "Ciclo de Ventas y Variaciones " + this.cMonedaSimbolo;
            #endregion

            #region Eventos +
            this.dtgGFamiliares.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);
            this.dtgGPersonales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGPersonales_DataBindingComplete);
            this.dtgGPersonales.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGPersonales_EditingControlShowing);
            this.dtgGPersonales.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGPersonales_DataError);
            this.dtgGOperativos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGOperativos_EditingControlShowing);
            this.dtgGOperativos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGOperativos_DataError);
            this.dtgGOperativos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGOperativos_CellLeave);
            this.dtgOtrosIngresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosIngresos_DataBindingComplete);
            this.dtgOtrosIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgOtrosIngresos_EditingControlShowing);
            this.dtgOtrosIngresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgOtrosIngresos_DataError);
            this.dtgOtrosEgresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgOtrosEgresos_DataBindingComplete);
            this.dtgOtrosEgresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgOtrosEgresos_EditingControlShowing);
            this.dtgOtrosEgresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgOtrosEgresos_DataError);
            this.dtgCicloVentas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentas_EditingControlShowing);
            this.dtgCicloVentas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentas_DataError);
            this.dtgVarGastosFam.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgVarGastosFam_EditingControlShowing);
            this.dtgVarGastosFam.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgVarGastosFam_DataError);
            this.dtgReinversiones.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgReinversiones_EditingControlShowing);
            this.dtgReinversiones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgReinversiones_DataError);
            #endregion

            if (this.listGFamiliares.Count > 0) this.tsmQuitarGFam.Enabled = true;
            if (this.listGPersonales.Count > 0) this.tsmQuitarGPer.Enabled = true;
            if (this.listGOperativos.Count > 0) this.tsmQuitarGOpe.Enabled = true;
            if (this.listOtrosIngresos.Count > 0) this.tsmQuitarOIng.Enabled = true;
            if (this.listOtrosEgresos.Count > 0) this.tsmQuitarOEgr.Enabled = true;
            if (this.listVarGastosFam.Count > 0) this.tsmQuitarVVen.Enabled = true;
            if (this.listReinversiones.Count > 0) this.tsmQuitarReinv.Enabled = true;

            dtgGFamiliares_DataBindingComplete(null, null);
            dtgGPersonales_DataBindingComplete(null, null);
            dtgGOperativos_DataBindingComplete(null, null);
            dtgOtrosIngresos_DataBindingComplete(null, null);
            dtgOtrosEgresos_DataBindingComplete(null, null);
        }

        public void LimpiarSelecciones()
        {
            this.dtgGFamiliares.CurrentCell = null;
            this.dtgGFamiliares.ClearSelection();

            this.dtgGPersonales.CurrentCell = null;
            this.dtgGPersonales.ClearSelection();

            this.dtgGOperativos.CurrentCell = null;
            this.dtgGOperativos.ClearSelection();

            this.dtgOtrosIngresos.CurrentCell = null;
            this.dtgOtrosIngresos.ClearSelection();

            this.dtgOtrosEgresos.CurrentCell = null;
            this.dtgOtrosEgresos.ClearSelection();

            this.dtgCicloVentas.CurrentCell = null;
            this.dtgCicloVentas.ClearSelection();

            this.dtgVarGastosFam.CurrentCell = null;
            this.dtgVarGastosFam.ClearSelection();

            this.dtgReinversiones.CurrentCell = null;
            this.dtgReinversiones.ClearSelection();
        }
        #endregion

        #region Métodos Privados
        private void PlantillaDefault()
        {
            if (this.listGPersonales.Count == 0 && this.lPeriodoGOperaEnabled == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.listGPersonales.Add(new clsDetEstResEval()
                    {
                        idEEFF = EEFF.GastosPersonales,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }

            if (this.listGFamiliares.Count == 0)
            {
                foreach (clsDescripcionEval oDescEval in this.listDescGastosFamiliares)
                {
                    this.listGFamiliares.Add(new clsDetEstResEval()
                    {
                        cDescripcion = oDescEval.cDescripcion,
                        idEEFF = EEFF.GastosFamiliares,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }

            if (this.listGOperativos.Count == 0)
            {
                foreach (clsDescripcionEval oDescEval in this.listDescGastosOperativos)
                {
                    this.listGOperativos.Add(new clsDetEstResEval()
                    {
                        cDescripcion = oDescEval.cDescripcion,
                        idEEFF = EEFF.GastosOperativos,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }

            if (this.listOtrosIngresos.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.listOtrosIngresos.Add(new clsDetEstResEval()
                    {
                        idEEFF = EEFF.OtrosIngresos,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }

            if (this.listOtrosEgresos.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.listOtrosEgresos.Add(new clsDetEstResEval()
                    {
                        idEEFF = EEFF.OtrosEgresos,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }
        }

        private void FormatearDataGridView()
        {
            this.dtgGFamiliares.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGFamiliares.MultiSelect = false;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGFamiliares.RowHeadersVisible = false;

            this.dtgGPersonales.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGPersonales.MultiSelect = false;
            this.dtgGPersonales.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGPersonales.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGPersonales.RowHeadersVisible = false;

            this.dtgGOperativos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGOperativos.MultiSelect = false;
            this.dtgGOperativos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGOperativos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGOperativos.RowHeadersVisible = false;

            this.dtgCicloVentas.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCicloVentas.MultiSelect = false;
            this.dtgCicloVentas.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgCicloVentas.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCicloVentas.RowHeadersVisible = false;

            this.dtgReinversiones.Margin = new System.Windows.Forms.Padding(0);
            this.dtgReinversiones.MultiSelect = false;
            this.dtgReinversiones.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgReinversiones.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgReinversiones.RowHeadersVisible = false;

            this.dtgVarGastosFam.Margin = new System.Windows.Forms.Padding(0);
            this.dtgVarGastosFam.MultiSelect = false;
            this.dtgVarGastosFam.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgVarGastosFam.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgVarGastosFam.RowHeadersVisible = false;

            this.dtgOtrosIngresos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgOtrosIngresos.MultiSelect = false;
            this.dtgOtrosIngresos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgOtrosIngresos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOtrosIngresos.RowHeadersVisible = false;

            this.dtgOtrosEgresos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgOtrosEgresos.MultiSelect = false;
            this.dtgOtrosEgresos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgOtrosEgresos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOtrosEgresos.RowHeadersVisible = false;
        }

        // -- Gastos Familiares
        private void AgregarComboBoxColumnsDataGridViewGFamiliares()
        {
            List<clsDescripcionEval> listGastosFamiliares = new List<clsDescripcionEval>();
            listGastosFamiliares.Add(new clsDescripcionEval() { idDescripcionEval = 9990999, cDescripcion = "holamundo" });

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgGFamiliares.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewGFamiliares()
        {
            foreach (DataGridViewColumn column in this.dtgGFamiliares.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGFamiliares.Columns["cDescripcion"].DisplayIndex = 0;
            dtgGFamiliares.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgGFamiliares.Columns["nPUnitario"].DisplayIndex = 2;

            dtgGFamiliares.Columns["cDescripcion"].Visible = true;
            dtgGFamiliares.Columns["dgcboTipoMoneda"].Visible = true;
            dtgGFamiliares.Columns["nPUnitario"].Visible = true;

            dtgGFamiliares.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgGFamiliares.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgGFamiliares.Columns["nPUnitario"].HeaderText = "Total";

            dtgGFamiliares.Columns["cDescripcion"].FillWeight = 112;
            dtgGFamiliares.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgGFamiliares.Columns["nPUnitario"].FillWeight = 50;

            dtgGFamiliares.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGFamiliares.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            dtgGFamiliares.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGFamiliares.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesGFamiliares()
        {
            this.txtTotalGFamiliares.Text = this.listGFamiliares.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Gastos Personales
        private void AgregarComboBoxColumnsDataGridViewGPersonales()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgGPersonales.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewGPersonales()
        {
            foreach (DataGridViewColumn column in this.dtgGPersonales.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGPersonales.Columns["cDescripcion"].DisplayIndex = 0;
            dtgGPersonales.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgGPersonales.Columns["nCantidad"].DisplayIndex = 2;
            dtgGPersonales.Columns["nPUnitario"].DisplayIndex = 3;
            dtgGPersonales.Columns["nTotal"].DisplayIndex = 4;

            dtgGPersonales.Columns["cDescripcion"].Visible = true;
            dtgGPersonales.Columns["dgcboTipoMoneda"].Visible = true;
            dtgGPersonales.Columns["nCantidad"].Visible = true;
            dtgGPersonales.Columns["nPUnitario"].Visible = true;
            dtgGPersonales.Columns["nTotal"].Visible = true;

            dtgGPersonales.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgGPersonales.Columns["nPUnitario"].HeaderText = "Sueldo";
            dtgGPersonales.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgGPersonales.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgGPersonales.Columns["nTotal"].HeaderText = "Total";

            dtgGPersonales.Columns["cDescripcion"].FillWeight = 110;
            dtgGPersonales.Columns["nPUnitario"].FillWeight = 40;
            dtgGPersonales.Columns["nCantidad"].FillWeight = 37;
            dtgGPersonales.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgGPersonales.Columns["nTotal"].FillWeight = 50;

            dtgGPersonales.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGPersonales.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGPersonales.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGPersonales.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGPersonales.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgGPersonales.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgGPersonales.Columns["nTotal"].DefaultCellStyle.Format = "n2";

            dtgGPersonales.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgGPersonal.Columns["idUnidMedida"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGPersonales.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGPersonales.Columns["nCantidad"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGPersonales.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGPersonales.Columns["nTotal"].ReadOnly = true;
        }

        private void CalcularTotalesGPersonales()
        {
            this.txtTotalGPersonales.Text = this.listGPersonales.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Gastos Operativos
        private void AgregarComboBoxColumnsDataGridViewGOperativos()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgGOperativos.Columns.Add(dgcboTipoMoneda);

            DataGridViewComboBoxColumn dgcboTipoFrecuencia = new DataGridViewComboBoxColumn();
            //dgcboTipoFrecuencia.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboTipoFrecuencia.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoFrecuencia.FlatStyle = FlatStyle.Popup;
            dgcboTipoFrecuencia.Name = "dgcboTipoFrecuencia";
            dgcboTipoFrecuencia.DataPropertyName = "nFrecuencia";
            dgcboTipoFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            dgcboTipoFrecuencia.DisplayMember = "cAbreviatura";
            dgcboTipoFrecuencia.ValueMember = "idFrecuencia";
            this.dtgGOperativos.Columns.Add(dgcboTipoFrecuencia);

            DataGridViewComboBoxColumn dgcboMesVenta = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboMesVenta.DisplayStyleForCurrentCellOnly = true;
            dgcboMesVenta.FlatStyle = FlatStyle.Popup;
            dgcboMesVenta.Name = "dgcboMesVenta";
            dgcboMesVenta.DataPropertyName = "nMesVenta";
            dgcboMesVenta.DataSource = Evaluacion.listMesFechasEval;
            dgcboMesVenta.DisplayMember = "cFechaCorto";
            dgcboMesVenta.ValueMember = "nMes";
            this.dtgGOperativos.Columns.Add(dgcboMesVenta);
        }

        private void FormatearColumnasDataGridViewGOperativos()
        {
            foreach (DataGridViewColumn column in this.dtgGOperativos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGOperativos.Columns["cDescripcion"].DisplayIndex = 0;
            dtgGOperativos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgGOperativos.Columns["nPUnitario"].DisplayIndex = 2;
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].DisplayIndex = 3;
            dtgGOperativos.Columns["dgcboMesVenta"].DisplayIndex = 4;

            dtgGOperativos.Columns["cDescripcion"].Visible = true;
            dtgGOperativos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgGOperativos.Columns["nPUnitario"].Visible = true;
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].Visible = true;
            dtgGOperativos.Columns["dgcboMesVenta"].Visible = true;

            dtgGOperativos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgGOperativos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgGOperativos.Columns["nPUnitario"].HeaderText = "Total";
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].HeaderText = "Fr";
            dtgGOperativos.Columns["dgcboMesVenta"].HeaderText = "MV";

            dtgGOperativos.Columns["cDescripcion"].FillWeight = 110;
            dtgGOperativos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgGOperativos.Columns["nPUnitario"].FillWeight = 50;
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].FillWeight = 35;
            dtgGOperativos.Columns["dgcboMesVenta"].FillWeight = 35;

            dtgGOperativos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGOperativos.Columns["dgcboMesVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgGOperativos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.Format = "n0";
            dtgGOperativos.Columns["dgcboMesVenta"].DefaultCellStyle.Format = "MMM/yy";

            dtgGOperativos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGOperativos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGOperativos.Columns["dgcboMesVenta"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            this.indexCategory = dtgGOperativos.Columns.IndexOf(dtgGOperativos.Columns["dgcboTipoFrecuencia"]);
            this.indexItem = dtgGOperativos.Columns.IndexOf(dtgGOperativos.Columns["dgcboMesVenta"]);

            if (this.lPeriodoGOperaEnabled == false)
            {
                dtgGOperativos.Columns["dgcboTipoFrecuencia"].ReadOnly = true;
                dtgGOperativos.Columns["dgcboMesVenta"].ReadOnly = true;

                dtgGOperativos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.BackColor = Color.White;
                dtgGOperativos.Columns["dgcboMesVenta"].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void CalcularTotalesGOperativos()
        {
            this.txtTotalGOperativos.Text = this.listGOperativos.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Otros Egresos
        private void AgregarComboBoxColumnsDataGridViewOtrosEgresos()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgOtrosEgresos.Columns.Add(dgcboTipoMoneda);
        }

        private void FormatearColumnasDataGridViewOtrosEgresos()
        {
            foreach (DataGridViewColumn column in this.dtgOtrosEgresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgOtrosEgresos.Columns["cDescripcion"].DisplayIndex = 0;
            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgOtrosEgresos.Columns["nPUnitario"].DisplayIndex = 2;

            dtgOtrosEgresos.Columns["cDescripcion"].Visible = true;
            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgOtrosEgresos.Columns["nPUnitario"].Visible = true;

            dtgOtrosEgresos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgOtrosEgresos.Columns["nPUnitario"].HeaderText = "Total";

            dtgOtrosEgresos.Columns["cDescripcion"].FillWeight = 112;
            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgOtrosEgresos.Columns["nPUnitario"].FillWeight = 50;

            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOtrosEgresos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgOtrosEgresos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgOtrosEgresos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            dtgOtrosEgresos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgOtrosEgresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgOtrosEgresos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesOtrosEgresos()
        {
            this.txtOtrosEgresos.Text = this.listOtrosEgresos.Sum(x => x.nTotalMA).ToString("N2");
        }

        // -- Otros Ingresos
        private void AgregarComboBoxColumnsDataGridViewOtrosIngresos()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            //dgcboTipoMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgOtrosIngresos.Columns.Add(dgcboTipoMoneda);

            DataGridViewButtonColumn dgbtnEvalAlterna = new DataGridViewButtonColumn();
            dgbtnEvalAlterna.Name = "dgbtnEvalAlterna";
            dgbtnEvalAlterna.Text = "...";
            dgbtnEvalAlterna.UseColumnTextForButtonValue = true;
            this.dtgOtrosIngresos.Columns.Add(dgbtnEvalAlterna);
        }

        private void FormatearColumnasDataGridViewOtrosIngresos()
        {
            foreach (DataGridViewColumn column in this.dtgOtrosIngresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgOtrosIngresos.Columns["cDescripcion"].DisplayIndex = 0;
            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgOtrosIngresos.Columns["nPUnitario"].DisplayIndex = 2;
            dtgOtrosIngresos.Columns["dgbtnEvalAlterna"].DisplayIndex = 3;

            dtgOtrosIngresos.Columns["cDescripcion"].Visible = true;
            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgOtrosIngresos.Columns["nPUnitario"].Visible = true;
            dtgOtrosIngresos.Columns["dgbtnEvalAlterna"].Visible = true;

            dtgOtrosIngresos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgOtrosIngresos.Columns["nPUnitario"].HeaderText = "Total";
            dtgOtrosIngresos.Columns["dgbtnEvalAlterna"].HeaderText = "...";

            dtgOtrosIngresos.Columns["cDescripcion"].FillWeight = 112;
            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgOtrosIngresos.Columns["nPUnitario"].FillWeight = 50;
            dtgOtrosIngresos.Columns["dgbtnEvalAlterna"].FillWeight = 16;

            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOtrosIngresos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgOtrosIngresos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgOtrosIngresos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            dtgOtrosIngresos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgOtrosIngresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgOtrosIngresos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesOtrosIngresos()
        {
            this.txtOtrosIngresos.Text = this.listOtrosIngresos.Sum(x => x.nTotalMA).ToString("N2");
        }

        private void StyleCellDataGridViewOtrosIngresos()
        {
            int idEvalCredAlterna = 0;
            foreach (DataGridViewRow row in this.dtgOtrosIngresos.Rows)
            {
                idEvalCredAlterna = Convert.ToInt32(row.Cells["idEvalCredAlterna"].Value);

                if (idEvalCredAlterna > 0)
                {
                    row.Cells["nPUnitario"].Style.BackColor = System.Drawing.Color.White;
                    row.Cells["nPUnitario"].ReadOnly = true;
                }
                else
                {
                    row.Cells["nPUnitario"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    row.Cells["nPUnitario"].ReadOnly = false;
                }
            }
        }

        // -- Reinversiones
        private void AgregarComboBoxColumnsDataGridViewReinversiones()
        {
            DataGridViewComboBoxColumn dgcboMes = new DataGridViewComboBoxColumn();
            dgcboMes.DisplayStyleForCurrentCellOnly = true;
            dgcboMes.FlatStyle = FlatStyle.Popup;
            dgcboMes.Name = "dgcboMes";
            dgcboMes.DataPropertyName = "nMes";
            dgcboMes.DataSource = Evaluacion.listMesFechasEval.Where(x => x.nMes <= Evaluacion.PlazoEval).ToList();
            dgcboMes.DisplayMember = "cFechaCorto";
            dgcboMes.ValueMember = "nMes";
            this.dtgReinversiones.Columns.Add(dgcboMes);
        }

        private void FormatearColumnasDataGridViewReinversiones()
        {
            foreach (DataGridViewColumn column in this.dtgReinversiones.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgReinversiones.Columns["dgcboMes"].DisplayIndex = 0;
            dtgReinversiones.Columns["nMonto"].DisplayIndex = 1;

            dtgReinversiones.Columns["dgcboMes"].Visible = true;
            dtgReinversiones.Columns["nMonto"].Visible = true;

            dtgReinversiones.Columns["dgcboMes"].FillWeight = 90;
            dtgReinversiones.Columns["nMonto"].FillWeight = 100;

            //dtgReinversiones.Columns["dgcboMes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgReinversiones.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgReinversiones.Columns["dgcboMes"].DefaultCellStyle.Format = "MMM.yy";
            dtgReinversiones.Columns["nMonto"].DefaultCellStyle.Format = "N2";

            dtgReinversiones.Columns["dgcboMes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgReinversiones.Columns["nMonto"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        // -- Ciclo de Ventas
        private void AgregarComboBoxColumnsDataGridViewCicloVentas()
        {
            DataGridViewComboBoxColumn dgcboMes = new DataGridViewComboBoxColumn();
            //dgcboMes.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboMes.DisplayStyleForCurrentCellOnly = true;
            dgcboMes.FlatStyle = FlatStyle.Popup;
            dgcboMes.Name = "dgcboMes";
            dgcboMes.DataPropertyName = "nMes";
            dgcboMes.DataSource = Evaluacion.listMesFechasEval;
            dgcboMes.DisplayMember = "cFechaCorto";
            dgcboMes.ValueMember = "nMes";
            this.dtgCicloVentas.Columns.Add(dgcboMes);
        }

        private void FormatearColumnasDataGridViewCicloVentas()
        {
            foreach (DataGridViewColumn column in this.dtgCicloVentas.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgCicloVentas.Columns["dgcboMes"].DisplayIndex = 0;
            dtgCicloVentas.Columns["nPorcentaje"].DisplayIndex = 1;
            dtgCicloVentas.Columns["cPorcentaje"].DisplayIndex = 2;

            dtgCicloVentas.Columns["dgcboMes"].Visible = true;
            dtgCicloVentas.Columns["nPorcentaje"].Visible = true;
            dtgCicloVentas.Columns["cPorcentaje"].Visible = true;

            dtgCicloVentas.Columns["dgcboMes"].FillWeight = 90;
            dtgCicloVentas.Columns["nPorcentaje"].FillWeight = 70;
            dtgCicloVentas.Columns["cPorcentaje"].FillWeight = 30;

            dtgCicloVentas.Columns["dgcboMes"].DefaultCellStyle.Format = "MMM.yy";
            dtgCicloVentas.Columns["nPorcentaje"].DefaultCellStyle.Format = "N0";

            dtgCicloVentas.Columns["nPorcentaje"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCicloVentas.Columns["dgcboMes"].ReadOnly = true;
            dtgCicloVentas.Columns["cPorcentaje"].ReadOnly = true;
        }

        // -- Variacion de Gastos Familiares
        private void AgregarComboBoxColumnsDataGridViewVariacionVentas()
        {
            DataGridViewComboBoxColumn dgcboMes = new DataGridViewComboBoxColumn();
            dgcboMes.DisplayStyleForCurrentCellOnly = true;
            dgcboMes.FlatStyle = FlatStyle.Popup;
            dgcboMes.Name = "dgcboMes";
            dgcboMes.DataPropertyName = "nMes";
            dgcboMes.DataSource = Evaluacion.listMesFechasEval.Where(x => x.nMes <= Evaluacion.PlazoEval).ToList();
            dgcboMes.DisplayMember = "cFechaCorto";
            dgcboMes.ValueMember = "nMes";
            this.dtgVarGastosFam.Columns.Add(dgcboMes);
        }

        private void FormatearColumnasDataGridViewVariacionVentas()
        {
            foreach (DataGridViewColumn column in this.dtgVarGastosFam.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgVarGastosFam.Columns["dgcboMes"].DisplayIndex = 0;
            dtgVarGastosFam.Columns["nMonto"].DisplayIndex = 1;

            dtgVarGastosFam.Columns["dgcboMes"].Visible = true;
            dtgVarGastosFam.Columns["nMonto"].Visible = true;

            dtgVarGastosFam.Columns["dgcboMes"].FillWeight = 90;
            dtgVarGastosFam.Columns["nMonto"].FillWeight = 100;

            dtgVarGastosFam.Columns["dgcboMes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgVarGastosFam.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgVarGastosFam.Columns["dgcboMes"].DefaultCellStyle.Format = "MMM.yy";
            dtgVarGastosFam.Columns["nMonto"].DefaultCellStyle.Format = "N2";

            dtgVarGastosFam.Columns["dgcboMes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgVarGastosFam.Columns["nMonto"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }
        #endregion

        #region Eventos
        #region Gastos Familiares
        private void dtgGFamiliares_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesGFamiliares();
        }

        private void dtgGFamiliares_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dtgGFamiliares_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        #endregion

        #region Gastos del Personales
        private void dtgGPersonales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesGPersonales();
        }

        private void dtgGPersonales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dtgGPersonales_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        #endregion

        #region Gastos Operativos
        private void dtgGOperativos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesGOperativos();
        }

        private void dtgGOperativos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            // --
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            // --
            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }

            // -- 
            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboMesVenta"))
            {
                cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    cmbItem.DropDown += new EventHandler(cboMesVenta_DropDown);
                }
            }

            // --
            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboTipoFrecuencia"))
            {
                cmbCategory = e.Control as ComboBox;
                if (cmbCategory != null)
                {
                    cmbCategory.SelectedValueChanged += new EventHandler(cboTipoFrecuencia_SelectedValueChanged);
                }
            }
        }

        private void dtgGOperativos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgGOperativos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbItem != null)
            {
                cmbItem.DropDown -= new EventHandler(cboMesVenta_DropDown);
            }
            if (cmbCategory != null)
            {
                cmbCategory.SelectedValueChanged -= new EventHandler(cboTipoFrecuencia_SelectedValueChanged);
            }
        }

        private void cboTipoFrecuencia_SelectedValueChanged(object sender, EventArgs e)
        {
            //this.dtgGOperativos.CurrentRow.Cells[indexItem].Value = new DateTime(2016, 1, 1);
            //this.listGOperativos[this.dtgGOperativos.CurrentRow.Index].dMesVenta = new DateTime(2016, 1, 1);
        }

        private void cboMesVenta_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtgGOperativos.CurrentRow.Cells[indexCategory].FormattedValue.ToString()))
                return;

            int categoryID = Convert.ToInt32(dtgGOperativos.CurrentRow.Cells[indexCategory].Value);

            cmbItem.DisplayMember = "cFechaCorto";
            cmbItem.ValueMember = "dFecha";
            cmbItem.DataSource = Evaluacion.listMesFechasEval.Where(x => x.nMes <= categoryID).ToList();
        }
        #endregion

        #region Otros Ingresos
        private void dtgOtrosIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dtgOtrosIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            StyleCellDataGridViewOtrosIngresos();
            CalcularTotalesOtrosIngresos();
        }

        private void dtgOtrosIngresos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgOtrosIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dtg = ((DataGridView)sender);

            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgbtnEvalAlterna"))
            {
                if (String.IsNullOrWhiteSpace(this.listOtrosIngresos[e.RowIndex].cDescripcion))
                {
                    MessageBox.Show("Ingrese una descripción", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmEvalAlterna frmCronogramaDeudas = new frmEvalAlterna(this.listOtrosIngresos[e.RowIndex]);
                frmCronogramaDeudas.ShowDialog();

                clsDetEstResEval objDetEstResEval = frmCronogramaDeudas.OtroIngreso();

                this.listOtrosIngresos[e.RowIndex].idDetEstResEval = objDetEstResEval.idDetEstResEval;
                this.listOtrosIngresos[e.RowIndex].nPUnitario = objDetEstResEval.nPUnitario;
                this.listOtrosIngresos[e.RowIndex].idEvalCredAlterna = objDetEstResEval.idEvalCredAlterna;

                frmCronogramaDeudas.Dispose();

                this.bindingOtrosIngresos.ResetBindings(false);
            }
        }
        #endregion

        #region Otros egresos
        private void dtgOtrosEgresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dtgOtrosEgresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesOtrosEgresos();
        }

        private void dtgOtrosEgresos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        #endregion

        #region Ciclos y Variaciones
        private void dtgCicloVentas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMonto"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void dtgCicloVentas_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgVarGastosFam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMonto"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMes"))
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.IntegralHeight = false;
                    cb.MaxDropDownItems = 10;
                }
            }
        }

        private void dtgVarGastosFam_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgReinversiones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMonto"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMes"))
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.IntegralHeight = false;
                    cb.MaxDropDownItems = 10;
                }
            }
        }

        private void dtgReinversiones_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        #endregion

        #region Eventos toolStripMenu
        private void tsmAgregarGFam_Click(object sender, EventArgs e)
        {
            this.listGFamiliares.Add(new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosFamiliares,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCantidad = 1,

                nFrecuencia = 1,
                dFechaInicio = this.dFechaBase,
            });

            this.bindingGFamiliares.ResetBindings(false);
            this.tsmQuitarGFam.Enabled = true;
        }

        private void tsmQuitarGFam_Click(object sender, EventArgs e)
        {
            if (this.dtgGFamiliares.RowCount == 0 || this.dtgGFamiliares.Enabled == false ||
                this.dtgGFamiliares.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgGFamiliares.SelectedCells[0].RowIndex;

            this.listGFamiliares.RemoveAt(rowIndex);
            this.bindingGFamiliares.ResetBindings(false);

            /*if (this.dtgGFamiliares.SelectedCells.Count == 0)
                this.tsmQuitarGFam.Enabled = false;*/
        }

        private void tsmAgregarGPer_Click(object sender, EventArgs e)
        {
            this.listGPersonales.Add(new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosPersonales,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCantidad = 1,

                nFrecuencia = 1,
                dFechaInicio = this.dFechaBase,
            });

            this.bindingGPersonales.ResetBindings(false);
            this.tsmQuitarGPer.Enabled = true;
        }

        private void tsmQuitarGPer_Click(object sender, EventArgs e)
        {
            if (this.dtgGPersonales.RowCount == 0 || this.dtgGPersonales.Enabled == false ||
                this.dtgGPersonales.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgGPersonales.SelectedCells[0].RowIndex;

            this.listGPersonales.RemoveAt(rowIndex);
            this.bindingGPersonales.ResetBindings(false);

            /*if (this.dtgGPersonales.SelectedCells.Count == 0)
                this.tsmQuitarGPer.Enabled = false;*/
        }

        private void tsmAgregarGOpe_Click(object sender, EventArgs e)
        {
            this.listGOperativos.Add(new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosOperativos,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCantidad = 1,

                nFrecuencia = 1,
                dFechaInicio = this.dFechaBase,
            });

            this.bindingGOperativos.ResetBindings(false);
            this.tsmQuitarGOpe.Enabled = true;
        }

        private void tsmQuitarGOpe_Click(object sender, EventArgs e)
        {
            if (this.dtgGOperativos.RowCount == 0 || this.dtgGOperativos.Enabled == false ||
                this.dtgGOperativos.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgGOperativos.SelectedCells[0].RowIndex;

            this.listGOperativos.RemoveAt(rowIndex);
            this.bindingGOperativos.ResetBindings(false);

            /*if (this.dtgGOperativos.SelectedCells.Count == 0)
                this.tsmQuitarGOpe.Enabled = false;*/
        }

        private void tsmAgregarOIng_Click(object sender, EventArgs e)
        {
            this.listOtrosIngresos.Add(new clsDetEstResEval()
            {
                idEvalCred = this.idEvalCred,
                idEEFF = EEFF.OtrosIngresos,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCantidad = 1,

                nFrecuencia = 1,
                dFechaInicio = this.dFechaBase,
            });

            this.bindingOtrosIngresos.ResetBindings(false);
            this.tsmQuitarOIng.Enabled = true;
        }

        private void tsmQuitarOIng_Click(object sender, EventArgs e)
        {
            if (this.dtgOtrosIngresos.RowCount == 0 || this.dtgOtrosIngresos.Enabled == false ||
                this.dtgOtrosIngresos.SelectedCells.Count <= 0)
                return;

            int rowIndex = this.dtgOtrosIngresos.SelectedCells[0].RowIndex;

            this.listOtrosIngresos.RemoveAt(rowIndex);
            this.bindingOtrosIngresos.ResetBindings(false);

            /*if (this.dtgOtrosEgresos.SelectedCells.Count == 0)
                this.tsmQuitarOEgr.Enabled = false;*/
        }

        private void tsmAgregarOEgr_Click(object sender, EventArgs e)
        {
            this.listOtrosEgresos.Add(new clsDetEstResEval()
            {
                idEEFF = EEFF.OtrosEgresos,
                idMonedaMA = this.idMonedaMA,
                nTipoCambio = this.nTipoCambio,
                nCantidad = 1,

                nFrecuencia = 1,
                dFechaInicio = this.dFechaBase,
            });

            this.bindingOtrosEgresos.ResetBindings(false);
            this.tsmQuitarOEgr.Enabled = true;
        }

        private void tsmQuitarOEgr_Click(object sender, EventArgs e)
        {
            if (this.dtgOtrosEgresos.RowCount == 0 || this.dtgOtrosEgresos.Enabled == false ||
                this.dtgOtrosEgresos.SelectedCells.Count <= 0)
                return;

            int rowIndex = this.dtgOtrosEgresos.SelectedCells[0].RowIndex;

            this.listOtrosEgresos.RemoveAt(rowIndex);
            this.bindingOtrosEgresos.ResetBindings(false);

            /*if (this.dtgOtrosEgresos.SelectedCells.Count == 0)
                this.tsmQuitarOEgr.Enabled = false;*/
        }

        private void tsmAgregarVarGFam_Click(object sender, EventArgs e)
        {
            this.listVarGastosFam.Add(new clsVarFlujoCajaEval()
            {
                idVarFlujoCajaEval = 0,
                idEEFF = EEFF.VariacionGFamiliares,
                dFechaInicio = this.dFechaBase,
                nMonto = 0
            });

            this.bindingVarGastosFam.ResetBindings(false);
            this.tsmQuitarVVen.Enabled = true;
        }

        private void tsmQuitarVarGFam_Click(object sender, EventArgs e)
        {
            if (this.dtgVarGastosFam.RowCount == 0 || this.dtgVarGastosFam.Enabled == false ||
                this.dtgVarGastosFam.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgVarGastosFam.SelectedCells[0].RowIndex;

            this.listVarGastosFam.RemoveAt(rowIndex);
            this.bindingVarGastosFam.ResetBindings(false);

            /*if (this.dtgVarGastosFam.SelectedCells.Count == 0)
                this.tsmQuitarVVen.Enabled = false;*/
        }

        private void tsmAgregarReinv_Click(object sender, EventArgs e)
        {
            this.listReinversiones.Add(new clsVarFlujoCajaEval()
            {
                idVarFlujoCajaEval = 0,
                idEEFF = EEFF.Reinversiones,
                dFechaInicio = this.dFechaBase,
                nMonto = 0
            });

            this.bindingReinversiones.ResetBindings(false);
            this.tsmQuitarReinv.Enabled = true;
        }

        private void tsmQuitarReinv_Click(object sender, EventArgs e)
        {
            if (this.dtgReinversiones.RowCount == 0 || this.dtgReinversiones.Enabled == false ||
                this.dtgReinversiones.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgReinversiones.SelectedCells[0].RowIndex;

            this.listReinversiones.RemoveAt(rowIndex);
            this.bindingReinversiones.ResetBindings(false);

            /*if (this.dtgVarGastosFam.SelectedCells.Count == 0)
                this.tsmQuitarReinv.Enabled = false;*/
        }
        #endregion
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
