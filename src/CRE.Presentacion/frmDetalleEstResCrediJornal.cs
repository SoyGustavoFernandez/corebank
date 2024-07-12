#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Funciones;
#endregion



namespace CRE.Presentacion
{
    public partial class frmDetalleEstResCrediJornal : frmBase
    {
        #region Variables Globales
        private int idEvalCred;
        private clsEvalCred objEvalCred;

        private List<clsJornalResumenIng> listJornalIngreso;
        private List<clsDetEstResEval> listGFamiliares;

        private List<clsDescripcionEval> listDescGastoFamiliares;

        private string cTipEvaluacion;
        private int idTipEvalCred;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;
        private DataTable dtMoneda;

        public bool lGuardado = false;

        private DateTime dFechaBase;
        #endregion

        #region Constructores
        public frmDetalleEstResCrediJornal(List<clsDescripcionEval> _listDescripcionEval,
            int _idEvalCred, decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, string _cTipEvaluacion, int _idTipEvalCred, clsEvalCred _objEvalCred)
        {
            InitializeComponent();

            this.listGFamiliares = new List<clsDetEstResEval>();
            this.listJornalIngreso = new List<clsJornalResumenIng>();
            this.idEvalCred = _idEvalCred;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idTipEvalCred = _idTipEvalCred;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;

            this.pnlGastosFamiliares.Enabled = false;
            this.pnlIngresos.Enabled = false;
            this.btnCancelar.Enabled = false;

            AsignarDataTables(Evaluacion.DataTableMoneda, _listDescripcionEval);

            this.cTipEvaluacion = _cTipEvaluacion;
            this.objEvalCred = _objEvalCred;
        }

        #endregion

        #region Metodos

        public void LimpiarSelecciones()
        {
            this.dtgGFamiliares.CurrentCell = null;
            this.dtgGFamiliares.ClearSelection();

            this.dtgIngresos.CurrentCell = null;
            this.dtgIngresos.ClearSelection();

        }

        public void AsignarDataTables(DataTable _dtMoneda, List<clsDescripcionEval> _listDescGastos)
        {
            this.dtMoneda = _dtMoneda;


            this.listDescGastoFamiliares = (from p in _listDescGastos
                                            where p.idTipoDescripcion == TipoDescripcion.GastosFamiliares
                                            select p).ToList();

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);
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

        private void FormatearColumnasDataGridViewJornalIngreso()
        {
            foreach (DataGridViewColumn column in this.dtgIngresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgIngresos.Columns["cTipoInterviniente"].DisplayIndex = 0;
            dtgIngresos.Columns["nMontoPromedio"].DisplayIndex = 1;
            dtgIngresos.Columns["lLunes"].DisplayIndex = 2;
            dtgIngresos.Columns["lMartes"].DisplayIndex = 3;
            dtgIngresos.Columns["lMiercoles"].DisplayIndex = 4;
            dtgIngresos.Columns["lJueves"].DisplayIndex = 5;
            dtgIngresos.Columns["lViernes"].DisplayIndex = 6;
            dtgIngresos.Columns["lSabado"].DisplayIndex = 7;
            dtgIngresos.Columns["lDomingo"].DisplayIndex = 8;
            dtgIngresos.Columns["nTotalDiasActivos"].DisplayIndex = 9;
            dtgIngresos.Columns["nMontoTotalSemana"].DisplayIndex = 10;

            dtgIngresos.Columns["cTipoInterviniente"].Visible = true;
            dtgIngresos.Columns["nMontoPromedio"].Visible = true;
            dtgIngresos.Columns["lLunes"].Visible = true;
            dtgIngresos.Columns["lMartes"].Visible = true;
            dtgIngresos.Columns["lMiercoles"].Visible = true;
            dtgIngresos.Columns["lJueves"].Visible = true;
            dtgIngresos.Columns["lViernes"].Visible = true;
            dtgIngresos.Columns["lSabado"].Visible = true;
            dtgIngresos.Columns["lDomingo"].Visible = true;
            dtgIngresos.Columns["nTotalDiasActivos"].Visible = true;
            dtgIngresos.Columns["nMontoTotalSemana"].Visible = true;

            dtgIngresos.Columns["cTipoInterviniente"].HeaderText = "Ingreso Diario";
            dtgIngresos.Columns["nMontoPromedio"].HeaderText = "S/";
            dtgIngresos.Columns["lLunes"].HeaderText = "Lunes";
            dtgIngresos.Columns["lMartes"].HeaderText = "Martes";
            dtgIngresos.Columns["lMiercoles"].HeaderText = "Miércoles";
            dtgIngresos.Columns["lJueves"].HeaderText = "Jueves";
            dtgIngresos.Columns["lViernes"].HeaderText = "Viernes";
            dtgIngresos.Columns["lSabado"].HeaderText = "Sábado";
            dtgIngresos.Columns["lDomingo"].HeaderText = "Domingo";
            dtgIngresos.Columns["nTotalDiasActivos"].HeaderText = "Nro X Semana";
            dtgIngresos.Columns["nMontoTotalSemana"].HeaderText = "Total";

            dtgIngresos.Columns["cTipoInterviniente"].FillWeight = 150;
            dtgIngresos.Columns["nMontoPromedio"].FillWeight = 100;
            dtgIngresos.Columns["lLunes"].FillWeight = 100;
            dtgIngresos.Columns["lMartes"].FillWeight = 100;
            dtgIngresos.Columns["lMiercoles"].FillWeight = 100;
            dtgIngresos.Columns["lJueves"].FillWeight = 100;
            dtgIngresos.Columns["lViernes"].FillWeight = 100;
            dtgIngresos.Columns["lSabado"].FillWeight = 100;
            dtgIngresos.Columns["lDomingo"].FillWeight = 100;
            dtgIngresos.Columns["nTotalDiasActivos"].FillWeight = 100;
            dtgIngresos.Columns["nMontoTotalSemana"].FillWeight = 100;

            dtgIngresos.Columns["nMontoPromedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["nMontoTotalSemana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["lLunes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lMartes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lMiercoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lJueves"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lViernes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lSabado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["lDomingo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["nTotalDiasActivos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgIngresos.Columns["nMontoPromedio"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lLunes"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lMartes"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lMiercoles"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lJueves"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lViernes"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lSabado"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["lDomingo"].DefaultCellStyle.Format = "n2";
            dtgIngresos.Columns["nTotalDiasActivos"].DefaultCellStyle.Format = "n0";
            dtgIngresos.Columns["nMontoTotalSemana"].DefaultCellStyle.Format = "n2";

            dtgIngresos.Columns["nMontoPromedio"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgIngresos.Columns["lLunes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lMartes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lMiercoles"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lJueves"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lViernes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lSabado"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["lDomingo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgIngresos.Columns["nMontoTotalSemana"].ReadOnly = true;
            dtgIngresos.Columns["cTipoInterviniente"].ReadOnly = true;
            dtgIngresos.Columns["nTotalDiasActivos"].ReadOnly = true;
            

        }

        private void CalcularTotalesIngresoJornal()
        {
            this.txtTotalIngresos.Text = (this.listJornalIngreso.Sum(x => x.nMontoTotalSemana)).ToString("N2");
        }

        private void PlantillaDefault()
        {
            if (this.listGFamiliares.Count == 0)
            {
                foreach (clsDescripcionEval oDescEval in this.listDescGastoFamiliares)
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

            if (this.listJornalIngreso.Count == 0)
            {
                clsJornalResumenIng objTitularNuevo = new clsJornalResumenIng();
                objTitularNuevo.cTipoInterviniente = "TITULAR";
                objTitularNuevo.idEvalCred = idEvalCred;
                objTitularNuevo.idTipoInterviniente = 1;
                listJornalIngreso.Add(objTitularNuevo);

                clsJornalResumenIng objConyugeNuevo = new clsJornalResumenIng();
                objConyugeNuevo.cTipoInterviniente = "CONYUGE TITULAR";
                objConyugeNuevo.idEvalCred = idEvalCred;
                objConyugeNuevo.idTipoInterviniente = 2;
                listJornalIngreso.Add(objConyugeNuevo);
            }
        }

        public void AsignarDatos(List<clsJornalResumenIng> _listJornalResumen, List<clsDetEstResEval> _listGFamiliares, decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, int _idEvalCred)
        {
            #region Eventos -
            this.dtgGFamiliares.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);
            this.dtgIngresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresos_DataBindingComplete);
            this.dtgIngresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresos_EditingControlShowing);
            this.dtgIngresos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgIngresos_DataError);
            this.dtgIngresos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellValueChanged);
            this.dtgIngresos.CellContentClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellContentClick);

            #endregion

            this.listGFamiliares = _listGFamiliares;
            this.listJornalIngreso = _listJornalResumen;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idEvalCred = _idEvalCred;

            PlantillaDefault();

            #region Asignacion de datos
            this.bindingGFamiliares.DataSource = this.listGFamiliares;
            this.dtgGFamiliares.DataSource = this.bindingGFamiliares;
            AgregarComboBoxColumnsDataGridViewGFamiliares();
            FormatearDataGridView();
            FormatearColumnasDataGridViewGFamiliares();

            this.bindingIngresos.DataSource = this.listJornalIngreso;
            this.dtgIngresos.DataSource = this.bindingIngresos;
            AgregarComboBoxColumnsDataGridViewJornalIngreso();
            FormatearColumnasDataGridViewJornalIngreso();

            this.labelTotaldtgGFamiliares.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgIngresos.Text = "Total " + this.cMonedaSimbolo;
            #endregion

            #region Eventos +
            this.dtgGFamiliares.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);
            this.dtgIngresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresos_DataBindingComplete);
            this.dtgIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresos_EditingControlShowing);
            this.dtgIngresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgIngresos_DataError);
            this.dtgIngresos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellValueChanged);
            this.dtgIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellContentClick);

            #endregion

            if (this.listGFamiliares.Count > 0) this.tsmQuitarGFam.Enabled = true;


            dtgGFamiliares_DataBindingComplete(null, null);
            dtgIngresos_DataBindingComplete(null, null);

        }

        private void FormatearDataGridView()
        {
            this.dtgGFamiliares.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGFamiliares.MultiSelect = false;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGFamiliares.RowHeadersVisible = false;

            this.dtgIngresos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIngresos.MultiSelect = false;
            this.dtgIngresos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgIngresos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIngresos.RowHeadersVisible = false;

        }

        private void AgregarComboBoxColumnsDataGridViewJornalIngreso()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgIngresos.Columns.Add(dgcboTipoMoneda);
        }

        private void RecuperarDetalleEstResultados()
        {
            DataSet ds = (new clsCNEvalCrediJornal()).RecuperarDetalleEstResultadosEval(this.idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listResumenJornalIngreso = DataTableToList.ConvertTo<clsJornalResumenIng>(ds.Tables[1]) as List<clsJornalResumenIng>;
            var listDetalleJornalIngreso = DataTableToList.ConvertTo<clsJornalDetalleIng>(ds.Tables[2]) as List<clsJornalDetalleIng>;

            // -- Organizar listas

            #region Detalle de los Estado Resultados
            this.listGFamiliares = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosFamiliares
                                    select p).ToList();

            #endregion

            #region Detalle de las ventas y costos
            foreach (clsJornalResumenIng oJornalResumen in listResumenJornalIngreso)
            {
                oJornalResumen.lstDetalleIng = (from p in listDetalleJornalIngreso
                                                where p.idEvalJornalResumenIng == oJornalResumen.idEvalJornalResumenIng
                                                select p).ToList();
            }

            this.listJornalIngreso = listResumenJornalIngreso;
            #endregion

            this.AsignarDatos(listResumenJornalIngreso, listGFamiliares, this.nTipoCambio, this.idMonedaMA, this.cMonedaSimbolo, this.idEvalCred);

            LimpiarSelecciones();
        }

        private void LimpiarFormulario()
        {
            dtgIngresos.CurrentCell = null;
            dtgIngresos.Rows.Clear();
            dtgGFamiliares.CurrentCell = null;
            dtgGFamiliares.Rows.Clear();
        }

        public List<clsJornalResumenIng> IngresoJornal()
        {
            return this.listJornalIngreso;
        }

        public List<clsDetEstResEval> GFamiliares()
        {
            return this.listGFamiliares;
        }
        #endregion

        #region Eventos
        private void frmDetalleEstResCrediJornal_Load(object sender, EventArgs e)
        {
            RecuperarDetalleEstResultados();
        }
        private void AgregarComboBoxColumnsDataGridViewGFamiliares()
        {
            List<clsDescripcionEval> listGastosFamiliares = new List<clsDescripcionEval>();
            listGastosFamiliares.Add(new clsDescripcionEval() { idDescripcionEval = 9990999, cDescripcion = "holamundo" });

            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();

            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgGFamiliares.Columns.Add(dgcboTipoMoneda);
        }
        
        private void dtgIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesIngresoJornal();
        }
        private void dtgIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEntero);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressEspacio);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMontoPromedio"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("lLunes") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lMartes") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lMiercoles") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lJueves") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lViernes") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lSabado") ||
                dtg.CurrentCell.OwningColumn.Name.Equals("lDomingo")
                )
            {
                CheckBox tb = e.Control as CheckBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressEspacio);
                }
            }

        }

        private void dtgIngresos_DataError(object sender, DataGridViewDataErrorEventArgs e)
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


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<clsDetEstResEval> listDetalleEstRes = new List<clsDetEstResEval>();
            List<clsJornalResumenIng> listJornalResumenIng = new List<clsJornalResumenIng>();

            #region Detalle de los Estados Resultados
            listDetalleEstRes.AddRange(this.listGFamiliares);
            #endregion

            #region Detalle de las Ventas y Costos
            listJornalResumenIng.AddRange(this.listJornalIngreso);
            #endregion

            // -- Preparación de datos
            string xmlDetalleEstRes = listDetalleEstRes.GetXml();
            string xmlDetalleJornalIngreso = listJornalResumenIng.GetXml();

            (new clsCNEvalCrediJornal()).ActDetalleEstadosResultadoslEval(this.idEvalCred, xmlDetalleEstRes, xmlDetalleJornalIngreso, clsVarGlobal.User.idUsuario);

            this.pnlGastosFamiliares.Enabled = false;
            this.pnlIngresos.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;

            RecuperarDetalleEstResultados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.pnlIngresos.Enabled = true;
            this.pnlGastosFamiliares.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.pnlIngresos.Enabled = false;
            this.pnlGastosFamiliares.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            LimpiarFormulario();
            RecuperarDetalleEstResultados();
        }

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

        private void Column_KeyPressEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void Column_KeyPressEspacio(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void dtgIngresos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (clsJornalResumenIng objResumen in this.listJornalIngreso)
            {
                objResumen.lstDetalleIng = objResumen.lstDetalleIng.Select(
                                                                item => {
                                                                    item.nMontoJornada = objResumen.nMontoPromedio;
                                                                    if (item.idDiaSemana == 2)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lLunes;
                                                                        item.nMontoJornada = (objResumen.lLunes) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 3)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lMartes;
                                                                        item.nMontoJornada = (objResumen.lMartes) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 4)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lMiercoles;
                                                                        item.nMontoJornada = (objResumen.lMiercoles) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 5)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lJueves;
                                                                        item.nMontoJornada = (objResumen.lJueves) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 6)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lViernes;
                                                                        item.nMontoJornada = (objResumen.lViernes) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 7)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lSabado;
                                                                        item.nMontoJornada = (objResumen.lSabado) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    if (item.idDiaSemana == 1)
                                                                    {
                                                                        item.lIngresoActivo = objResumen.lDomingo;
                                                                        item.nMontoJornada = (objResumen.lDomingo) ? objResumen.nMontoPromedio : 0;
                                                                    }
                                                                    return item;
                                                                }).ToList();

                objResumen.nTotalDiasActivos = objResumen.lstDetalleIng.Where(item => item.lIngresoActivo).Count();
                objResumen.nMontoTotalSemana = objResumen.nMontoPromedio * objResumen.lstDetalleIng.Where(item => item.lIngresoActivo).Count();
            }
            bindingIngresos.ResetBindings(false);
        }

        private void dtgIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgIngresos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dtgIngresos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            

             if (dtgIngresos.IsCurrentCellDirty && (dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lLunes") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lMartes") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lMiercoles") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lJueves") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lViernes") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lSabado") ||
                   dtgIngresos.CurrentCell.OwningColumn.Name.Equals("lDomingo")
                   ))
            {
                dtgIngresos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        #endregion
    }
}

