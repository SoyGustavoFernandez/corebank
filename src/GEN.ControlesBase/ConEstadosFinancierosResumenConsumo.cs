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
//using CRW.Helper;
using System.Globalization;
using GEN.ControlesBase;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace CRE.ControlBase
{
    public partial class ConEstadosFinancierosResumenConsumo : UserControl
    {
        #region Variables
        private List<clsBalGenEval> listBalGenEval = null;
        private List<clsEstResEval> listEstResEval = null;
        private List<clsIndicadorEval> listIndiFinanc = null;
        //private List<clsDeudasEval> listCredDirectos = null;
        //private List<clsDeudasEval> listCredIndirect = null;

        public event EventHandler DeudasClick;
        public event EventHandler BBGGClick;
        public event EventHandler EERRClick;
        public event EventHandler EHZTLClick;

        public event DataGridViewCellEventHandler CellValueChangedEstadosFinancieros;

        private const int nAnioMinimo = 2000;
        private const int nAnioDefault = 2000;

        private decimal nMontoProp = 0;
        private decimal nCuotaAprox = 0;

        private decimal nIngresosBrutos = 0M;

        #endregion

        public ConEstadosFinancierosResumenConsumo()
        {
            InitializeComponent();
            FormatearDataGridView();
        }

        #region "Properties"
        public bool UltEvaluacionEnabled
        {
            get
            {
                return this.chcHabilitado.Enabled;
            }
            set
            {
                this.chcHabilitado.Enabled = value;
                this.grbUltEvaluacion.Enabled = value;
            }
        }

        public bool UltEvaluacionChecked
        {
            get
            {
                return this.chcHabilitado.Checked;
            }
            set
            {
                this.chcHabilitado.Checked = value;
            }
        }

        public bool BalanceGeneralEnabled
        {
            get
            {
                return this.plBalanceGeneral.Enabled;
            }
            set
            {
                this.plBalanceGeneral.Enabled = value;
                this.dtgBalGenEval.Visible = value;
            }
        }

        public bool UltEvaluacionLimpiarCeldas = true;

        public bool VisibleButtonEvalHorizontal
        {
            get
            {
                return this.btnEvalHorizontal.Visible;
            }
            set
            {
                this.btnEvalHorizontal.Visible = value;
            }
        }

        public bool VisibleButtonDeudas
        {
            get
            {
                return this.btnDeudas.Visible;
            }
            set
            {
                this.btnDeudas.Visible = value;
            }
        }
        #endregion

        #region Métodos Públicos
        public void ActualizarDatos(decimal _nMontoProp, decimal _nCuotaAprox)
        {
            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;
        }

        public void AsignarDatos(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsIndicadorEval> _listIndiFinanc, bool lConsumoBG = false, decimal nMontoBruto = 0M)
        {
            this.dtgBalGenEval.Visible = !lConsumoBG;
            this.panel2.Visible = !lConsumoBG;

            // -- Eventos
            this.dtgBalGenEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBalGenEval_EditingControlShowing);
            this.dtgBalGenEval.Leave -= new System.EventHandler(this.dtgBalGenEval_Leave);
            this.dtgBalGenEval.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgBalGenEval_DataError);
            this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);
            this.dtgEstResEval.Leave -= new System.EventHandler(this.dtgEstResEval_Leave);
            this.dtgEstResEval.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEstResEval_DataError);
            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);

            this.chcHabilitado.CheckedChanged -= new System.EventHandler(this.chcHabilitado_CheckedChanged);

            // -- 
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;
            this.listIndiFinanc = _listIndiFinanc;

            // --Balance General
            this.bindingBalGenEval.DataSource = this.listBalGenEval;
            this.dtgBalGenEval.DataSource = this.bindingBalGenEval;
            this.FormatearColumnasDataGridViewBBGG();

            // --Estado de Resultados
            this.bindingEstResEval.DataSource = this.listEstResEval;
            this.dtgEstResEval.DataSource = this.bindingEstResEval;
            this.FormatearColumnasDataGridViewEERR();

            // --Indicadores financieros
            this.dtgIndiFinanc.DataSource = this.listIndiFinanc;
            this.FormatearIndicadoresDGV();

            // --Configuración
            this.tsmBGTitulo.Text = String.Format("Balance General {0}", Evaluacion.MonedaSimbolo);
            this.tsmERTitulo.Text = String.Format("Estado Resultados {0}", Evaluacion.MonedaSimbolo);

            this.dtUltEvaluacion.Value = ((Evaluacion.FechaUltimaEval != null) ? (DateTime)(Evaluacion.FechaUltimaEval) : new System.DateTime(nAnioDefault, 1, 1, 0, 0, 0, 0));

            this.tsmBGFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
            this.tsmERFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);

            if (((DateTime)(this.dtUltEvaluacion.Value)).Year >= nAnioMinimo)
            {
                this.chcHabilitado.Checked = true;
                this.tsmBGFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
                this.tsmERFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                this.chcHabilitado.Checked = false;
            }

            // -- Eventos
            this.dtgBalGenEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBalGenEval_EditingControlShowing);
            this.dtgBalGenEval.Leave += new System.EventHandler(this.dtgBalGenEval_Leave);
            this.dtgBalGenEval.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgBalGenEval_DataError);
            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);
            this.dtgEstResEval.Leave += new System.EventHandler(this.dtgEstResEval_Leave);
            this.dtgEstResEval.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEstResEval_DataError);
            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);

            this.chcHabilitado.CheckedChanged += new System.EventHandler(this.chcHabilitado_CheckedChanged);

            dtgBalGenEval_DataBindingComplete(null, null);
            dtgEstResEval_DataBindingComplete(null, null);

            this.CalcularBBGG();
            this.CalcularEERR();

            this.dtgBalGenEval.Refresh(); //ok
            this.dtgEstResEval.Refresh(); //ok
            this.dtgIndiFinanc.Refresh(); //ok

            nIngresosBrutos = nMontoBruto;
            txtIngreBrutos.Text = nIngresosBrutos.ToString("N2");
        }

        public void ActualizarIndicadores()
        {
            this.CalcularIndicadores();
            this.dtgIndiFinanc.Refresh(); //ok
        }

        public void ActualizarPorIndPorMPropPorMAprox(List<clsIndicadorEval> _listIndiFinanc, decimal _nMontoProp, decimal _nCuotaAprox)
        {
            this.listIndiFinanc = _listIndiFinanc;

            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;

            this.CalcularIndicadores();
            this.dtgIndiFinanc.Refresh();
        }

        public List<clsBalGenEval> ListBalanceGeneral
        {
            get
            {
                return this.listBalGenEval;
            }
            set
            {
                this.listBalGenEval = value;

                this.CalcularBBGG();
                this.bindingBalGenEval.ResetBindings(false);
                dtgBalGenEval_CellValueChanged(null, null);
            }
        }

        public List<clsEstResEval> ListEstadoResultados
        {
            get
            {
                return this.listEstResEval;
            }
            set
            {
                this.listEstResEval = value;

                this.CalcularEERR();
                this.bindingEstResEval.ResetBindings(false);
                dtgEstResEval_CellValueChanged(null, null);
            }
        }

        public DateTime UltimaFechaEvaluacion()
        {
            DateTime dUltEval = new System.DateTime(nAnioDefault, 1, 1, 0, 0, 0, 0);

            if (this.chcHabilitado.Checked == true && !String.IsNullOrEmpty(this.tsmERFechaUltimaEval.Text))
            {
                dUltEval = this.dtUltEvaluacion.Value;
            }

            return dUltEval;
        }

        public void ActualizarFechaUltEval(DateTime dFechaUltEval)
        {
            this.dtUltEvaluacion.Value = ((dFechaUltEval != null) ? (DateTime)(dFechaUltEval) : new System.DateTime(nAnioDefault, 1, 1, 0, 0, 0, 0));
        }

        public decimal obtenernIngresosBrutos()
        {
            return nIngresosBrutos;
        }

        public clsMsjError validarIndiFinanc()
        {
            clsMsjError objError = new clsMsjError();
            List<clsIndicadorEval> listaInd = (List<clsIndicadorEval>)dtgIndiFinanc.DataSource;
            foreach (clsIndicadorEval item in listaInd)
            {
                decimal nValorMinimo = item.nValorMinimo;
                decimal nValorMaximo = item.nValorMaximo;
                decimal nRatio = item.nRatio;

                nRatio = (item.nTipoVariable == 2) ? nRatio * 100 : nRatio;
                nRatio = Math.Round(nRatio, 2);

                if (!(nRatio >= nValorMinimo && nRatio <= nValorMaximo) && !(nValorMinimo == 0 && nValorMaximo == 0))
                {
                    switch (item.nCodigo)
                    {
                        case 6:// Capacidad de pago
                            objError.AddError("Estados Financ.: " + item.cDescripcion + " mayor al " + (nValorMaximo / 100m).ToString("P2"));
                            break;
                        case 3:// Capacidad de pago
                            objError.AddError("Estados Financ.: " + item.cDescripcion + " mayor al " + (nValorMaximo / 100m).ToString("P2"));
                            break;
                    }
                }

            }
            return objError;
        }

        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgBalGenEval.Margin = new System.Windows.Forms.Padding(0);
            this.dtgBalGenEval.MultiSelect = false;
            this.dtgBalGenEval.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgBalGenEval.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBalGenEval.RowHeadersVisible = false;
            this.dtgBalGenEval.SelectionMode = DataGridViewSelectionMode.CellSelect;

            this.dtgEstResEval.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEstResEval.MultiSelect = false;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEstResEval.RowHeadersVisible = false;
            this.dtgEstResEval.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        #region BBGG
        private void FormatearColumnasDataGridViewBBGG()
        {
            foreach (DataGridViewColumn column in this.dtgBalGenEval.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgBalGenEval.Columns["cDescripcion"].DisplayIndex = 0;
            dtgBalGenEval.Columns["nTotalUltEvMA"].DisplayIndex = 1;
            dtgBalGenEval.Columns["nTotalMA"].DisplayIndex = 2;
            dtgBalGenEval.Columns["nAnalisisVerti"].DisplayIndex = 3;
            dtgBalGenEval.Columns["nAnalisisHoriz"].DisplayIndex = 4;

            dtgBalGenEval.Columns["cDescripcion"].Visible = true;
            dtgBalGenEval.Columns["nTotalUltEvMA"].Visible = true;
            dtgBalGenEval.Columns["nTotalMA"].Visible = true;
            dtgBalGenEval.Columns["nAnalisisVerti"].Visible = true;
            dtgBalGenEval.Columns["nAnalisisHoriz"].Visible = true;

            dtgBalGenEval.Columns["cDescripcion"].HeaderText = "";
            dtgBalGenEval.Columns["nTotalUltEvMA"].HeaderText = "Ultima Ev.";
            dtgBalGenEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgBalGenEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";
            dtgBalGenEval.Columns["nAnalisisHoriz"].HeaderText = "A. Horiz.";

            dtgBalGenEval.Columns["nTotalUltEvMA"].ToolTipText = "Ultima Evaluación";
            dtgBalGenEval.Columns["nTotalMA"].ToolTipText = "";
            dtgBalGenEval.Columns["nAnalisisVerti"].ToolTipText = "Analisis Vertical";
            dtgBalGenEval.Columns["nAnalisisHoriz"].ToolTipText = "Análisis Horizontal";

            dtgBalGenEval.Columns["cDescripcion"].FillWeight = 80;
            dtgBalGenEval.Columns["nTotalUltEvMA"].FillWeight = 45;
            dtgBalGenEval.Columns["nTotalMA"].FillWeight = 45;
            dtgBalGenEval.Columns["nAnalisisVerti"].FillWeight = 35;
            dtgBalGenEval.Columns["nAnalisisHoriz"].FillWeight = 35;

            dtgBalGenEval.Columns["nTotalUltEvMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBalGenEval.Columns["nTotalMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBalGenEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBalGenEval.Columns["nTotalUltEvMA"].DefaultCellStyle.Format = "n2";
            dtgBalGenEval.Columns["nTotalMA"].DefaultCellStyle.Format = "n2";
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p1";
            dtgBalGenEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p1";

            dtgBalGenEval.Columns["cDescripcion"].ReadOnly = true;
            dtgBalGenEval.Columns["nAnalisisVerti"].ReadOnly = true;
            dtgBalGenEval.Columns["nAnalisisHoriz"].ReadOnly = true;

            //dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            //dtgBalGenEval.Columns["nAnalisisHoriz"].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
        }

        private void StyleCellDataGridViewBBGG()
        {
            int idEEFF = 0;
            foreach (DataGridViewRow row in this.dtgBalGenEval.Rows)
            {
                idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);

                if (idEEFF == EEFF.TotalActivo || idEEFF == EEFF.TotalAcCorriente || idEEFF == EEFF.TotalAcNoCorriente ||
                    idEEFF == EEFF.TotalPasivo || idEEFF == EEFF.TotalPaCorriente || idEEFF == EEFF.TotalPaNoCorriente ||
                    idEEFF == EEFF.TotalPatrimonio || idEEFF == EEFF.TotalPasivoPatrimonio)
                {
                    row.ReadOnly = true;

                    if (idEEFF == EEFF.TotalActivo || idEEFF == EEFF.TotalPasivo || idEEFF == EEFF.TotalPatrimonio || idEEFF == EEFF.TotalPasivoPatrimonio)
                    {
                        row.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
                        row.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                    }
                }
                else
                {
                    if (Convert.ToBoolean(row.Cells["lEditable"].Value) == true)
                    {
                        row.Cells["nTotalMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                        row.Cells["nTotalMA"].ReadOnly = false;
                    }
                    else
                    {
                        row.Cells["nTotalMA"].ReadOnly = true;
                    }


                    if (UltEvaluacionChecked) // Habilitado para edición
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    }
                    else
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private void CalcularBBGG()
        {
            if (this.listBalGenEval == null) return;

            decimal nActivos = 0m,
                    nAcCorriente = 0m,
                    nAcNoCorriente = 0m,
                    nPasivos = 0m,
                    nPaCorriente = 0m,
                    nPaNoCorriente = 0m,
                    nPatrimonio = 0m;

            decimal nUlEvActivos = 0m,
                    nUlEvAcCorriente = 0m,
                    nUlEvAcNoCorriente = 0m,
                    nUlEvPasivos = 0m,
                    nUlEvPaCorriente = 0m,
                    nUlEvPaNoCorriente = 0m,
                    nUlEvPatrimonio = 0m;

            //---------------- Actual Evaluación
            nAcCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalMA);
            nAcNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalMA);
            nActivos = nAcCorriente + nAcNoCorriente;
            //nActivos = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalActivo).Sum(x => x.nTotalMA);

            nPaCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalMA);
            nPaNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalMA);
            nPasivos = nPaCorriente + nPaNoCorriente;
            //nPasivos = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPasivo).Sum(x => x.nTotalMA);

            nPatrimonio = nActivos - nPasivos;

            //---------------- Ultima Evaluación
            nUlEvAcCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvAcNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvActivos = nUlEvAcCorriente + nUlEvAcNoCorriente;
            //nActivos = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalActivo).Sum(x => x.nTotalMA);

            nUlEvPaCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvPaNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvPasivos = nUlEvPaCorriente + nUlEvPaNoCorriente;
            //nPasivos = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPasivo).Sum(x => x.nTotalMA);

            nUlEvPatrimonio = nUlEvActivos - nUlEvPasivos;

            //---------------
            foreach (clsBalGenEval item in listBalGenEval)
            {
                if (item.idEEFF == EEFF.TotalActivo)
                {
                    item.nTotalMA = nActivos;
                    item.nTotalUltEvMA = nUlEvActivos;
                }
                else if (item.idEEFF == EEFF.TotalAcCorriente)
                {
                    item.nTotalMA = nAcCorriente;
                    item.nTotalUltEvMA = nUlEvAcCorriente;
                }
                else if (item.idEEFF == EEFF.TotalAcNoCorriente)
                {
                    item.nTotalMA = nAcNoCorriente;
                    item.nTotalUltEvMA = nUlEvAcNoCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPasivo)
                {
                    item.nTotalMA = nPasivos;
                    item.nTotalUltEvMA = nUlEvPasivos;
                }
                else if (item.idEEFF == EEFF.TotalPaCorriente)
                {
                    item.nTotalMA = nPaCorriente;
                    item.nTotalUltEvMA = nUlEvPaCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPaNoCorriente)
                {
                    item.nTotalMA = nPaNoCorriente;
                    item.nTotalUltEvMA = nUlEvPaNoCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPatrimonio)
                {
                    item.nTotalMA = nPatrimonio;
                    item.nTotalUltEvMA = nUlEvPatrimonio;
                }
                else if (item.idEEFF == EEFF.TotalPasivoPatrimonio)
                {
                    item.nTotalMA = nActivos;
                    item.nTotalUltEvMA = nUlEvActivos;
                }

                item.nTotalActivos = nActivos;
            }
        }
        #endregion

        #region EERR
        private void FormatearColumnasDataGridViewEERR()
        {
            foreach (DataGridViewColumn column in this.dtgEstResEval.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEstResEval.Columns["cDescripcion"].DisplayIndex = 0;
            dtgEstResEval.Columns["nTotalUltEvMA"].DisplayIndex = 1;
            dtgEstResEval.Columns["nTotalMA"].DisplayIndex = 2;
            dtgEstResEval.Columns["nAnalisisVerti"].DisplayIndex = 3;
            dtgEstResEval.Columns["nAnalisisHoriz"].DisplayIndex = 4;

            dtgEstResEval.Columns["cDescripcion"].Visible = true;
            dtgEstResEval.Columns["nTotalUltEvMA"].Visible = true;
            dtgEstResEval.Columns["nTotalMA"].Visible = true;
            dtgEstResEval.Columns["nAnalisisHoriz"].Visible = true;

            dtgEstResEval.Columns["cDescripcion"].HeaderText = "";
            dtgEstResEval.Columns["nTotalUltEvMA"].HeaderText = "Ultima Ev.";
            dtgEstResEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgEstResEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";
            dtgEstResEval.Columns["nAnalisisHoriz"].HeaderText = "A. Horiz.";

            dtgEstResEval.Columns["nTotalUltEvMA"].ToolTipText = "Ultima Evaluación";
            dtgEstResEval.Columns["nTotalMA"].ToolTipText = "";
            dtgEstResEval.Columns["nAnalisisVerti"].ToolTipText = "Analisis Vertical";
            dtgEstResEval.Columns["nAnalisisHoriz"].ToolTipText = "Análisis Horizontal";

            dtgEstResEval.Columns["cDescripcion"].FillWeight = 80;
            dtgEstResEval.Columns["nTotalUltEvMA"].FillWeight = 45;
            dtgEstResEval.Columns["nTotalMA"].FillWeight = 45;
            dtgEstResEval.Columns["nAnalisisVerti"].FillWeight = 35;
            dtgEstResEval.Columns["nAnalisisHoriz"].FillWeight = 35;

            dtgEstResEval.Columns["nTotalUltEvMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstResEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgEstResEval.Columns["nTotalUltEvMA"].DefaultCellStyle.Format = "n2";
            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Format = "n2";
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p1";
            dtgEstResEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p1";

            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisVerti"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisHoriz"].ReadOnly = true;


        }

        private void StyleCellDataGridViewEERR()
        {
            int idEEFF = 0;
            int[] nEstadosNoEditables = new int[3];
            nEstadosNoEditables[0] = EEFF.CuotaMaxEndeudaConsumo;
            nEstadosNoEditables[1] = EEFF.CuotaCredDir;
            nEstadosNoEditables[2] = EEFF.ProvCredIndir;

            foreach (DataGridViewRow row in this.dtgEstResEval.Rows)
            {
                idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);

                if (idEEFF == EEFF.UtilidadBruta || idEEFF == EEFF.UtilidadOperativa ||
                    idEEFF == EEFF.UtilidadNeta || idEEFF == EEFF.UtilidadDisponible ||
                    idEEFF == EEFF.TotalIngNetos || idEEFF == EEFF.SaldoDisponible  ||
                    idEEFF == EEFF.IngresoDisponible)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
                    row.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                }
                else
                {

                    if (idEEFF.In(nEstadosNoEditables))
                    {
                        row.Cells["nTotalMA"].Style.BackColor = System.Drawing.Color.White;
                        row.Cells["nTotalMA"].ReadOnly = true;
                        
                    }
                    else
                    {
                        row.Cells["nTotalMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    }

                    if (UltEvaluacionChecked) // Habilitado para edición
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    }
                    else
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private void CalcularEERR()
        {
            if (this.listEstResEval == null) return;

            decimal nVentasNetas = 0m,
                    nUNeta = 0m,
                    nUDisponible = 0m,
                    nTotalIngNetos = 0m,
                    nSaldoDisponible = 0m;

            decimal nUlEvUNeta = 0m,
                    nUlEvUDisponible = 0m,
                    nUlEvnTotalIngNetos = 0m,
                    nUlEvnSaldoDisponible = 0m;

            decimal nTemp1 = 0m, nTemp2 = 0m, nTemp3 = 0m, nCuotaMaxEndeuda = 0M, nUltEvCuotaMaxEndeuda = 0m;

            //---------------- Actual Evaluación
            nTemp1 = listEstResEval.Where(x => x.idEEFF == EEFF.IngNetTitular).Sum(x => x.nTotalMA);
            nTemp2 = listEstResEval.Where(x => x.idEEFF == EEFF.IngNetConyuge).Sum(x => x.nTotalMA);
            nTotalIngNetos = nTemp1 + nTemp2;

            nTemp2 = listEstResEval.Where(x => x.idEEFF == EEFF.CuotaCredDir).Sum(x => x.nTotalMA);
            nTemp3 = listEstResEval.Where(x => x.idEEFF == EEFF.ProvCredIndir).Sum(x => x.nTotalMA);
            nUDisponible = nTotalIngNetos - (nTemp2 + nTemp3);
            

            //---------------- Ultima Evaluación
            nTemp1 = listEstResEval.Where(x => x.idEEFF == EEFF.IngNetTitular).Sum(x => x.nTotalUltEvMA);
            nTemp2 = listEstResEval.Where(x => x.idEEFF == EEFF.IngNetConyuge).Sum(x => x.nTotalUltEvMA);
            nUlEvnTotalIngNetos = nTemp1 + nTemp2;

           
            nTemp2 = listEstResEval.Where(x => x.idEEFF == EEFF.CuotaCredDir).Sum(x => x.nTotalUltEvMA);
            nTemp3 = listEstResEval.Where(x => x.idEEFF == EEFF.ProvCredIndir).Sum(x => x.nTotalUltEvMA);
            nUlEvUDisponible = nUlEvnTotalIngNetos - (nTemp2 + nTemp3);
            

            //---------------
            foreach (clsEstResEval item in listEstResEval)
            {
                if (item.idEEFF == EEFF.TotalIngNetos)
                {
                    item.nTotalMA = nTotalIngNetos;
                    item.nTotalUltEvMA = nUlEvnTotalIngNetos;
                }
                else if (item.idEEFF == EEFF.UtilidadNeta)
                {
                    item.nTotalMA = nUNeta;
                    item.nTotalUltEvMA = nUlEvUNeta;
                }
                else if (item.idEEFF == EEFF.SaldoDisponible)
                {
                    item.nTotalMA = nSaldoDisponible;
                    item.nTotalUltEvMA = nUlEvnSaldoDisponible;
                }
                else if (item.idEEFF == EEFF.UtilidadDisponible)
                {
                    item.nTotalMA = nUDisponible;
                    item.nTotalUltEvMA = nUlEvUDisponible;
                }
                else if (item.idEEFF == EEFF.CuotaMaxEndeudaConsumo)
                {
                    item.nTotalMA = nCuotaMaxEndeuda;
                    item.nTotalUltEvMA = nUltEvCuotaMaxEndeuda;
                }
                else if(item.idEEFF == EEFF.IngresoDisponible)
                {
                    item.nTotalMA = nUDisponible;
                    item.nTotalUltEvMA = nUlEvUDisponible;
                }

                item.nVentasNetas = nVentasNetas;
            }
        }
        #endregion

        #region Indicadores Financieros
        private void FormatearIndicadoresDGV()
        {
            foreach (DataGridViewColumn column in this.dtgIndiFinanc.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIndiFinanc.Columns["cDescripcion"].DisplayIndex = 0;
            dtgIndiFinanc.Columns["nRatio"].DisplayIndex = 1;

            dtgIndiFinanc.Columns["cDescripcion"].Visible = true;
            dtgIndiFinanc.Columns["nRatio"].Visible = true;

            dtgIndiFinanc.Columns["cDescripcion"].FillWeight = 90;
            dtgIndiFinanc.Columns["nRatio"].FillWeight = 35;

            dtgIndiFinanc.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void CalcularIndicadores()
        {
            decimal nCapitalTrabajo = 0,
                    nCapacidadPago = 0;

            decimal nAcCorriente = 0m,
                    nPaCorriente = 0m;

            decimal nUDisponible = 0m;

            //---------------- Estado de Resultados
            nUDisponible = listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA); ;

            //---------------- IFinancieros
            nCapitalTrabajo = nAcCorriente - nPaCorriente;
            nCapacidadPago = clsNumerico.Dividir(
                this.nCuotaAprox +
                this.listEstResEval.First(x => x.idEEFF == EEFF.CuotaCredDir).nTotalMA +
                this.listEstResEval.First(x => x.idEEFF == EEFF.ProvCredIndir).nTotalMA
                , this.listEstResEval.First(x => x.idEEFF == EEFF.TotalIngNetos).nTotalMA);

            //---------------- Actualizar
            foreach (clsIndicadorEval item in listIndiFinanc)
            {
                if (item.nCodigo == IFN.CapacidadPago)
                {
                    item.nRatio = nCapacidadPago;
                }
            }
        }
        #endregion

        #region Otros
        private bool EsFechaValido()
        {
            if (((DateTime)(this.dtUltEvaluacion.Value)).Year >= nAnioMinimo) return true;
            return false;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsFechaValido())
                objMsjError.AddError("Ingrese una fecha válida.");

            return objMsjError;
        }

        private void HabilitarUltEvaluacion(bool lHabilitado)
        {
            this.dtUltEvaluacion.Enabled = lHabilitado;

            this.dtgBalGenEval.Columns["nTotalUltEvMA"].ReadOnly = !lHabilitado;
            this.dtgEstResEval.Columns["nTotalUltEvMA"].ReadOnly = !lHabilitado;

            StyleCellDataGridViewBBGG();
            StyleCellDataGridViewEERR();

            if (UltEvaluacionLimpiarCeldas)
            {
                int i, c = this.listBalGenEval.Count;
                for (i = 0; i < c; i++)
                    this.listBalGenEval[i].nTotalUltEvMA = 0;

                c = this.listEstResEval.Count;
                for (i = 0; i < c; i++)
                    this.listEstResEval[i].nTotalUltEvMA = 0;
            }

            if (!lHabilitado)
            {
                this.dtUltEvaluacion.Value = new System.DateTime(nAnioMinimo, 1, 1, 0, 0, 0, 0);

                this.tsmBGFechaUltimaEval.Text = String.Empty;
                this.tsmERFechaUltimaEval.Text = String.Empty;
            }
        }

        private void Column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        #endregion
        #endregion

        #region Eventos
        #region Balance General
        private void dtgBalGenEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewBBGG();
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.listBalGenEval == null) return;
            
            CalcularBBGG();
            CalcularIndicadores();

            this.dtgBalGenEval.Refresh();
            this.dtgIndiFinanc.Refresh();
        }

        private void dtgBalGenEval_Leave(object sender, EventArgs e)
        {
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgBalGenEval_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalUltEvMA") || dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalMA"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }
        #endregion

        #region Estado de Resultados
        private void dtgEstResEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewEERR();
            this.dtgEstResEval.ClearSelection();
        }

        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.listEstResEval == null) return;

            CalcularEERR();
            CalcularIndicadores();
            
            this.dtgEstResEval.Refresh();
            this.dtgIndiFinanc.Refresh();
        }

        private void dtgEstResEval_Leave(object sender, EventArgs e)
        {
            this.dtgEstResEval.ClearSelection();
        }

        private void dtgEstResEval_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgEstResEval_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalUltEvMA") || dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalMA"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }
        #endregion

        #region Eventos Indicadores Financieros
        private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int nCodigo = 0, nTipoVariable = 0;
            foreach (DataGridViewRow row in this.dtgIndiFinanc.Rows)
            {
                nCodigo = Convert.ToInt32(row.Cells["nCodigo"].Value);
                nTipoVariable = Convert.ToInt32(row.Cells["nTipoVariable"].Value);

                if (nTipoVariable == 1) row.DefaultCellStyle.Format = "N2";
                else if (nTipoVariable == 2) row.DefaultCellStyle.Format = "P2";
            }
        }

        private void dtgIndiFinanc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dtgIndiFinanc.ClearSelection();
        }

        private void dtgIndiFinanc_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgIndiFinanc.ClearSelection();
        }
        #endregion

        #region Otros eventos
        private void dtUltimaEval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (EsFechaValido())
                {
                    this.tsmBGFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
                    this.tsmERFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
                }
            }

            e.Handled = true;
        }

        private void dtUltimaEval_Leave(object sender, EventArgs e)
        {
            if (EsFechaValido())
            {
                this.tsmBGFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
                this.tsmERFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
            }
        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            if (DeudasClick != null)
                DeudasClick(sender, e);
        }

        private void chcHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarUltEvaluacion(this.chcHabilitado.Checked);
        }

        private void btnEvalHorizontal_Click(object sender, EventArgs e)
        {

            if (EHZTLClick != null)
                EHZTLClick(sender, e);
        }

        private void txtIngreBrutos_TextChanged(object sender, EventArgs e)
        {
            nIngresosBrutos = txtIngreBrutos.nDecValor;
        }
        #endregion

        
        #endregion
    }
}
