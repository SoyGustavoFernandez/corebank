using CRE.CapaNegocio;
using EntityLayer;
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

namespace GEN.ControlesBase
{
    public partial class frmEvalAlterna : frmBase
    {
        private clsCNEvaluacion objCapaNegocio;
        private clsEvalCred objEvalCredAlterna;
        private clsDetEstResEval objOtroIngreso;

        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsDetBalGenEval> listInventario;

        private DataTable dtMoneda;
        private string cMonedaSimbolo;
        private int idMoneda;
        private string cMsjCaption = "Evaluación Alterna";
        private int idEvalCred;

        #region Constructor
        public frmEvalAlterna()
        {
            this.objCapaNegocio = new clsCNEvaluacion();

            InitializeComponent();
            FormatearDataGridView();

            this.txtNroEval.Text = "000001";
            this.txtTipoCambio.Text = "0.0000";
            this.txtActividad.Text = "Actividad de la eval alterna";

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.tabControl1.Enabled = false;
        }

        public frmEvalAlterna(clsDetEstResEval _objOtrosIngreso)
        {
            this.objCapaNegocio = new clsCNEvaluacion();
            this.objEvalCredAlterna = new clsEvalCred();
            this.objOtroIngreso = _objOtrosIngreso;

            this.objEvalCredAlterna.idEvalCred = this.objOtroIngreso.idEvalCredAlterna;

            InitializeComponent();
            FormatearDataGridView();

            this.txtNroEval.Text = (this.objEvalCredAlterna.idEvalCred == 0) ? "" : this.objEvalCredAlterna.idEvalCred.ToString();
            this.txtTipoCambio.Text = this.objOtroIngreso.nTipoCambio.ToString("N4");
            this.txtActividad.Text = this.objOtroIngreso.cDescripcion;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.tabControl1.Enabled = false;

            this.idMoneda = 1;
            this.cMonedaSimbolo = "-";
        }
        #endregion

        #region Públicos
        public clsDetEstResEval OtroIngreso()
        {
            this.objOtroIngreso.nPUnitario = listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

            return this.objOtroIngreso;
        }
        #endregion

        #region Métodos Privados
        private void ObtenerEvalAlterna(int _idEvalCred)
        {
            this.SuspendLayout();
            this.idEvalCred = _idEvalCred;

            #region Recuperar de DataBase
            DataSet dsResult = this.objCapaNegocio.CNObtenerEvalAlterna(_idEvalCred);

            //-- Table[0] : Tipos de Moneda
            this.dtMoneda = dsResult.Tables[0];

            //-- Table[1] : Evaluacion Maestro
            var aEval = DataTableToList.ConvertTo<clsEvalCred>(dsResult.Tables[1]) as List<clsEvalCred>;

            if (aEval.Count > 0)
                this.objEvalCredAlterna = aEval[0];
            else
                this.objEvalCredAlterna = new clsEvalCred();

            //-- Table[2] : Balance General
            this.listBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(dsResult.Tables[2]) as List<clsBalGenEval>;

            //-- Table[3] : Estado de Resultados
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsResult.Tables[3]) as List<clsEstResEval>;

            //-- Table[5] : Indicadores Financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[5]) as List<clsIndicadorEval>;

            //-- El inventario es vacio
            this.listInventario = new List<clsDetBalGenEval>();
            #endregion

            #region Preparar Objetos
            var aMoneda = (from p in this.dtMoneda.AsEnumerable()
                           where p.Field<int>("idMoneda") == this.objOtroIngreso.idMoneda
                           select new
                           {
                               cSimbolo = p.Field<string>("cSimbolo"),
                               idMoneda = p.Field<int>("idMoneda")
                           }).ToList().FirstOrDefault();

            this.idMoneda = aMoneda.idMoneda;
            this.cMonedaSimbolo = aMoneda.cSimbolo;

            #endregion

            AsignarDatos(this.listBalGenEval, this.listEstResEval, this.listIndiFinanc);

            this.ResumeLayout();
        }

        private void ActualizarEvalAlterna()
        {
            DataSet dsResult = this.objCapaNegocio.CNActualizarEvalAlterna(this.objEvalCredAlterna.idEvalCred);

            //-- Table[0] : Balance General
            this.listBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(dsResult.Tables[0]) as List<clsBalGenEval>;

            //-- Table[1] : Estado de Resultados
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsResult.Tables[1]) as List<clsEstResEval>;


            //-- Table[3] : Indicadores financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[3]) as List<clsIndicadorEval>;

            //-- Table[4] : Otro ingreso
            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(dsResult.Tables[4]) as List<clsDetEstResEval>;
            this.objOtroIngreso = listDetEstResEval[0];
            this.objEvalCredAlterna.idEvalCred = this.objOtroIngreso.idEvalCredAlterna;

            //-- Actualizar DataTables
            this.bindingBalGenEval.DataSource = this.listBalGenEval;
            this.bindingEstResEval.DataSource = this.listEstResEval;

            this.CalcularBBGG();
            this.dtgBalGenEval.Refresh();

            this.CalcularEERR();
            this.dtgEstResEval.Refresh();

            this.conIndicadores.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, new List<clsDetBalGenEval>(), 0, 0);
        }

        public void AsignarDatos(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsIndicadorEval> _listIndiFinanc)
        {
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


            // -- 
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;

            // --Balance General
            this.bindingBalGenEval.DataSource = this.listBalGenEval;
            this.dtgBalGenEval.DataSource = this.bindingBalGenEval;
            this.FormatearColumnasDataGridViewBBGG();

            // --Estado de Resultados
            this.bindingEstResEval.DataSource = this.listEstResEval;
            this.dtgEstResEval.DataSource = this.bindingEstResEval;
            this.FormatearColumnasDataGridViewEERR();

            // -- Indicadores Financieros
            decimal _nCapitalPropuesto = 0;
            decimal _nCuotas = 0;
            decimal _nDestinoCapitalTrabajo = 0;
            decimal _nTotalPasivoAC = 0;
            decimal _nCapitalParacomercio = 0;
            int _nCodigoSectorEconomico = 0;

            List<clsDetBalGenEval> _listInventario = new List<clsDetBalGenEval>();

            this.conIndicadores.AsignarDatos(_listIndiFinanc, _listBalGenEval, _listEstResEval, _listInventario,
                _nCapitalPropuesto, _nCuotas, _nDestinoCapitalTrabajo, _nTotalPasivoAC, _nCapitalParacomercio, _nCodigoSectorEconomico, 13, 0, 0, this.idEvalCred);

            // --Configuración
            this.tsmBGTitulo.Text = String.Format("Balance General {0}", this.cMonedaSimbolo);
            this.tsmERTitulo.Text = String.Format("Estado Resultados {0}", this.cMonedaSimbolo);

            this.tsmBGFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
            this.tsmERFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);

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

            dtgBalGenEval_DataBindingComplete(null, null);
            dtgEstResEval_DataBindingComplete(null, null);

            this.CalcularBBGG();
            this.dtgBalGenEval.Refresh(); //ok

            this.CalcularEERR();
            this.dtgEstResEval.Refresh(); //ok

            conIndicadores.Actualizar();
        }

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

        #region Balance General
        private void FormatearColumnasDataGridViewBBGG()
        {
            foreach (DataGridViewColumn column in this.dtgBalGenEval.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgBalGenEval.Columns["cDescripcion"].DisplayIndex = 0;
            dtgBalGenEval.Columns["nTotalMA"].DisplayIndex = 1;
            dtgBalGenEval.Columns["nAnalisisVerti"].DisplayIndex = 2;

            dtgBalGenEval.Columns["cDescripcion"].Visible = true;
            dtgBalGenEval.Columns["nTotalMA"].Visible = true;
            dtgBalGenEval.Columns["nAnalisisVerti"].Visible = true;

            dtgBalGenEval.Columns["cDescripcion"].HeaderText = "";
            dtgBalGenEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgBalGenEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";

            dtgBalGenEval.Columns["nTotalMA"].ToolTipText = "";
            dtgBalGenEval.Columns["nAnalisisVerti"].ToolTipText = "Analisis Vertical";

            dtgBalGenEval.Columns["cDescripcion"].FillWeight = 80;
            dtgBalGenEval.Columns["nTotalMA"].FillWeight = 45;
            dtgBalGenEval.Columns["nAnalisisVerti"].FillWeight = 35;

            dtgBalGenEval.Columns["nTotalMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgBalGenEval.Columns["nTotalMA"].DefaultCellStyle.Format = "n2";
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p1";

            dtgBalGenEval.Columns["cDescripcion"].ReadOnly = true;
            dtgBalGenEval.Columns["nAnalisisVerti"].ReadOnly = true;
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

            //---------------- Actual Evaluación
            nAcCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalMA);
            nAcNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalMA);
            nActivos = nAcCorriente + nAcNoCorriente;

            nPaCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalMA);
            nPaNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalMA);
            nPasivos = nPaCorriente + nPaNoCorriente;

            nPatrimonio = nActivos - nPasivos;

            //---------------
            foreach (clsBalGenEval item in listBalGenEval)
            {
                if (item.idEEFF == EEFF.TotalActivo)
                {
                    item.nTotalMA = nActivos;
                }
                else if (item.idEEFF == EEFF.TotalAcCorriente)
                {
                    item.nTotalMA = nAcCorriente;
                }
                else if (item.idEEFF == EEFF.TotalAcNoCorriente)
                {
                    item.nTotalMA = nAcNoCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPasivo)
                {
                    item.nTotalMA = nPasivos;
                }
                else if (item.idEEFF == EEFF.TotalPaCorriente)
                {
                    item.nTotalMA = nPaCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPaNoCorriente)
                {
                    item.nTotalMA = nPaNoCorriente;
                }
                else if (item.idEEFF == EEFF.TotalPatrimonio)
                {
                    item.nTotalMA = nPatrimonio;
                }
                else if (item.idEEFF == EEFF.TotalPasivoPatrimonio)
                {
                    item.nTotalMA = nActivos;
                }

                item.nTotalActivos = nActivos;
            }
        }
        #endregion

        #region Estado de Resultados
        private void FormatearColumnasDataGridViewEERR()
        {
            foreach (DataGridViewColumn column in this.dtgEstResEval.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEstResEval.Columns["cDescripcion"].DisplayIndex = 0;
            dtgEstResEval.Columns["nTotalMA"].DisplayIndex = 1;
            dtgEstResEval.Columns["nAnalisisVerti"].DisplayIndex = 2;

            dtgEstResEval.Columns["cDescripcion"].Visible = true;
            dtgEstResEval.Columns["nTotalMA"].Visible = true;
            dtgEstResEval.Columns["nAnalisisVerti"].Visible = true;

            dtgEstResEval.Columns["cDescripcion"].HeaderText = "";
            dtgEstResEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgEstResEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";

            dtgEstResEval.Columns["nTotalMA"].ToolTipText = "";
            dtgEstResEval.Columns["nAnalisisVerti"].ToolTipText = "Analisis Vertical";

            dtgEstResEval.Columns["cDescripcion"].FillWeight = 80;
            dtgEstResEval.Columns["nTotalMA"].FillWeight = 45;
            dtgEstResEval.Columns["nAnalisisVerti"].FillWeight = 35;

            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.Format = "n2";
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p1";

            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisVerti"].ReadOnly = true;
        }

        private void StyleCellDataGridViewEERR()
        {
            int idEEFF = 0;
            foreach (DataGridViewRow row in this.dtgEstResEval.Rows)
            {
                idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);

                if (idEEFF == EEFF.UtilidadBruta || idEEFF == EEFF.UtilidadOperativa ||
                    idEEFF == EEFF.UtilidadNeta || idEEFF == EEFF.UtilidadDisponible)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
                    row.DefaultCellStyle.Font = GridViewStyle.GridViewFontTotal;
                }
                else
                {
                    row.Cells["nTotalMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    row.Cells["nTotalMA"].ReadOnly = false;
                }
            }
        }

        private void CalcularEERR()
        {
            if (this.listEstResEval == null) return;

            decimal nVentasNetas = 0m,
                    nCostoVentas = 0m,
                    nUBruta = 0m,
                    nGastoNegocio = 0m,
                    nUOperativa = 0m,
                    nGastosFinancieros = 0m,
                    nUNeta = 0m,
                    nOtrosIngresos = 0m,
                    nOtrosEgresos = 0m,
                    nGastosFamiliares = 0m,
                    nUDisponible = 0m;

            //---------------- Actual Evaluación
            nVentasNetas = listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            nCostoVentas = listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
            nUBruta = nVentasNetas - nCostoVentas;

            nGastoNegocio = listEstResEval.Where(x => x.idEEFF == EEFF.GastosNegocio).Sum(x => x.nTotalMA);
            nUOperativa = nUBruta - nGastoNegocio;

            nGastosFinancieros = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
            nUNeta = nUOperativa - nGastosFinancieros;

            nOtrosIngresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            nOtrosEgresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);
            nGastosFamiliares = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);
            nUDisponible = nUNeta + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares;

            //---------------
            foreach (clsEstResEval item in listEstResEval)
            {
                if (item.idEEFF == EEFF.UtilidadBruta)
                {
                    item.nTotalMA = nUBruta;
                }

                else if (item.idEEFF == EEFF.UtilidadOperativa)
                {
                    item.nTotalMA = nUOperativa;
                }
                else if (item.idEEFF == EEFF.UtilidadNeta)
                {
                    item.nTotalMA = nUNeta;
                }
                else if (item.idEEFF == EEFF.UtilidadDisponible)
                {
                    item.nTotalMA = nUDisponible;
                }

                item.nVentasNetas = nVentasNetas;
            }
        }
        #endregion

        /*public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsFechaValido())
                objMsjError.AddError("Ingrese una fecha válida.");

            return objMsjError;
        }*/

        #region XML
        private string EvalCredToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUsuReg", typeof(int));
            dt.Columns.Add("idUsuMod", typeof(int));
            dt.Columns.Add("idAgencia", typeof(int));
            dt.Columns.Add("idActividadInternaPri", typeof(int));
            dt.Columns.Add("idTipoActividadPri", typeof(int));
            dt.Columns.Add("nActPriAnios", typeof(int));
            dt.Columns.Add("cActPriDireccion", typeof(string));
            dt.Columns.Add("cActPriReferencia", typeof(string));
            dt.Columns.Add("cActPriDescripcion", typeof(string));

            DataRow row = dt.NewRow();

            row["idEvalCred"] = this.objEvalCredAlterna.idEvalCred;
            row["idMoneda"] = this.objOtroIngreso.idMoneda;
            row["idUsuReg"] = clsVarGlobal.User.idUsuario;
            row["idUsuMod"] = clsVarGlobal.User.idUsuario;
            row["idAgencia"] = clsVarGlobal.nIdAgencia;
            row["idActividadInternaPri"] = this.objEvalCredAlterna.idActividadInternaPri;
            row["idTipoActividadPri"] = this.objEvalCredAlterna.idTipoActividadPri;
            row["nActPriAnios"] = this.objEvalCredAlterna.nActPriAnios;
            row["cActPriDireccion"] = this.objEvalCredAlterna.cActPriDireccion;
            row["cActPriReferencia"] = this.objEvalCredAlterna.cActPriReferencia;
            row["cActPriDescripcion"] = this.objOtroIngreso.cDescripcion;

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private string BalGenEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idBalGenEval", typeof(int));
            dt.Columns.Add("idItemBalGen", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));

            foreach (clsBalGenEval bg in listBalGenEval)
            {
                dt.Rows.Add(
                    bg.idBalGenEval,
                    bg.idItemBalGen,
                    bg.nTotalMA,
                    bg.nAnalisisVerti
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "BalGenEval", "Item");
        }

        private string EstResEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEstResEval", typeof(int));
            dt.Columns.Add("idItemEstRes", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));

            foreach (clsEstResEval er in listEstResEval)
            {
                dt.Rows.Add(
                    er.idEstResEval,
                    er.idItemEstRes,
                    er.nTotalMA,
                    er.nAnalisisVerti
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "EstResEval", "Item");
        }

        private string IndicadoresToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idIndicadorEval", typeof(int));
            dt.Columns.Add("idItemIndicador", typeof(int));
            dt.Columns.Add("nRatio", typeof(decimal));

            foreach (clsIndicadorEval rc in this.listIndiFinanc)
            {
                dt.Rows.Add(rc.idIndicadorEval, rc.idItemIndicador, rc.nRatio);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "IndicadorEval", "Item");
        }

        private string DetalleEstResEnXML(clsDetEstResEval objDetalleEstRes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetEstResEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));

            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));
            dt.Columns.Add("nTipoCambio", typeof(decimal));

            DataRow row = dt.NewRow();

            row["idDetEstResEval"] = objDetalleEstRes.idDetEstResEval;
            //row["idEvalCred"] = detBalGen.idEvalCred;
            row["idEEFF"] = objDetalleEstRes.idEEFF;
            row["cDescripcion"] = objDetalleEstRes.cDescripcion;
            row["idDescripcion"] = objDetalleEstRes.idDescripcion;
            row["idMoneda"] = objDetalleEstRes.idMoneda;
            row["idUnidMedida"] = objDetalleEstRes.idUnidMedida;
            row["nCantidad"] = objDetalleEstRes.nCantidad;
            row["nPUnitario"] = objDetalleEstRes.nPUnitario;
            row["nTotal"] = objDetalleEstRes.nTotal;
            row["idMonedaMA"] = objDetalleEstRes.idMonedaMA;
            row["nTotalMA"] = objDetalleEstRes.nTotalMA;

            row["nFrecuencia"] = objDetalleEstRes.nFrecuencia;
            row["dMesVenta"] = objDetalleEstRes.dMesVenta;
            row["nMesVenta"] = objDetalleEstRes.nMesVenta;
            row["nTipoCambio"] = objDetalleEstRes.nTipoCambio;

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Column_KeyPressMayuscula(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        #region Eventos
        private void frmEvalAlterna_Load(object sender, EventArgs e)
        {
            ObtenerEvalAlterna(this.objOtroIngreso.idEvalCredAlterna);
        }

        #region Balance General
        private void dtgBalGenEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewBBGG();
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularBBGG();
            this.dtgBalGenEval.Refresh(); //ok

            this.conIndicadores.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, this.listInventario, 0, 0);
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

        private void dtgEstResEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewEERR();
            this.dtgEstResEval.ClearSelection();
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

        #region Estado de resultados
        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularEERR();
            this.dtgEstResEval.Refresh(); //ok

            this.conIndicadores.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, this.listInventario, 0, 0);
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

        #region Evento de Botones
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.objOtroIngreso.nPUnitario = listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

            this.objEvalCredAlterna.idActividadInternaPri = 0;
            this.objEvalCredAlterna.idTipoActividadPri = 0;
            this.objEvalCredAlterna.nActPriAnios = 0;
            this.objEvalCredAlterna.cActPriDireccion = "";
            this.objEvalCredAlterna.cActPriReferencia = "";
            this.objEvalCredAlterna.cActPriDescripcion = this.objOtroIngreso.cDescripcion;

            // -- Convertir a XML 
            string xmlEvalCred = EvalCredToXML();
            string xmlBalGenEval = BalGenEvalToXML();
            string xmlEstResEval = EstResEvalToXML();
            string xmlIndicadorEval = IndicadoresToXML();
            string xmlOtroIngreso = DetalleEstResEnXML(this.objOtroIngreso);

            int idEvalCredPrinc = this.objOtroIngreso.idEvalCred;

            DataTable td = this.objCapaNegocio.CNGrabarEvalAlterna(this.objEvalCredAlterna.idEvalCred, idEvalCredPrinc,
                        xmlEvalCred,
                        xmlBalGenEval,
                        xmlEstResEval,
                        xmlIndicadorEval,
                        xmlOtroIngreso
            );

            if (td.Rows.Count > 0)
            {
                DataRow drResult = td.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(drResult["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.objEvalCredAlterna.idEvalCred = Convert.ToInt32(drResult["idEvalCred"]);
                    this.txtNroEval.Text = this.objEvalCredAlterna.idEvalCred.ToString();

                    ActualizarEvalAlterna();

                    this.btnEditar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.tabControl1.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.tabControl1.Enabled = false;

            ActualizarEvalAlterna();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.tabControl1.Enabled = true;
        }
        #endregion
        #endregion
    }
}
