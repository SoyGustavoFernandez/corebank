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
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conEstadosFinancierosAgricola : UserControl
    {
        private List<clsBalGenEval> lstBalGenEval;
        private List<clsEstResEval> lstEstResEval;
        private List<clsIndicadorEval> lstIndicadorEval;
        private clsEvalCred objEvalCred;
        private clsCreditoProp objCreditoProp = new clsCreditoProp();

        private BindingSource bindingIndicadorEval;

        public event EventHandler eventDeudasClick;
        public event EventHandler eventBBGGClick;
        public event EventHandler eventEERRClick;
        public event EventHandler eventActividadAgricolaClick;
        public event EventHandler EHZTLClick;

        public event DataGridViewCellEventHandler CellValueChangedEstadosFinancieros;

        private const int nAnioMinimo = 2000;
        private const int nAnioDefault = 2000;

        private clsCNAlertaVariable objCNAlertaVariable = new clsCNAlertaVariable();

        #region propiedades
        public List<clsBalGenEval> _lstBalGenEval
        {
            get
            {
                return this.lstBalGenEval;
            }
            set
            {
                this.lstBalGenEval = value;
                this.calcularBBGG();
            }
        }

        public List<clsEstResEval> _lstEstResEval
        {
            get
            {
                return this.lstEstResEval;
            }
            set
            {
                this.lstEstResEval = value;
                this.calcularEERR();
            }
        }

        public clsCreditoProp CreditoPropuesto
        {
            get
            {
                return this.objCreditoProp.Clone();
            }
            set
            {
                foreach (clsIndicadorEval oInd in this.lstIndicadorEval)
                {
                    if (oInd.nCodigo == 4) oInd.nValorMinimo = value.nTea;
                }
                this.objCreditoProp = value.Clone();
            }
        }

        public bool UltEvaluacionEnabled
        {
            get
            {
                return this.chcHabilitado.Enabled;
            }
            set
            {
                this.chcHabilitado.Enabled = value;
                this.grbUltimaEvaluacion.Enabled = value;
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

        public bool lEditable
        {
            get
            {
                return this.plBBGG.Enabled;
            }
            set
            {
                this.plBBGG.Enabled = value;
                this.plEERR.Enabled = value;
                this.plIIFF.Enabled = value;
                this.grbBotonesEEFF.Enabled = value;
                this.grbUltimaEvaluacion.Enabled = value;
            }
        }

        public bool UltEvaluacionLimpiarCeldas = true;
        #endregion

        public conEstadosFinancierosAgricola()
        {
            InitializeComponent();
            this.formatearDataGridView();

            this.bindingBalGenEval = new BindingSource();
            this.bindingEstResEval = new BindingSource();
            this.bindingIndicadorEval = new BindingSource();
        }

        #region métodos públicos
        public void calcularIIFF()
        {
            if (this.lstBalGenEval == null || this.lstIndicadorEval == null) return;

            decimal nActivoCorriente = this.lstBalGenEval.Find(x => x.idEEFF == EEFF.TotalAcCorriente).nTotalMA;
            decimal nPasivoCorriente = this.lstBalGenEval.Find(x => x.idEEFF == EEFF.TotalPaCorriente).nTotalMA;
            decimal nCapitalTrabajo = nActivoCorriente - nPasivoCorriente;

            decimal nCuotaCreditoPropuesto = this.objCreditoProp.nCuotaAprox;
            decimal nGastosFinancieros = this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosFinancieros).nTotalMA;
            decimal nUtilidadOperativa = this.lstEstResEval.Find(x => x.idEEFF == EEFF.UtilidadOperativa).nTotalMA;
            decimal nOtrosIngresos = this.lstEstResEval.Find(x => x.idEEFF == EEFF.OtrosIngresos).nTotalMA;
            decimal nGastosFamiliares = this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosFamiliares).nTotalMA;
            decimal nOtrosEgresos = this.lstEstResEval.Find(x => x.idEEFF == EEFF.OtrosEgresos).nTotalMA;
            decimal nCapacidadPago = clsNumerico.Dividir(nCuotaCreditoPropuesto + nGastosFinancieros, nUtilidadOperativa + nOtrosIngresos - nGastosFamiliares - nOtrosEgresos);

            decimal nUtilidadNeta = this.lstEstResEval.Find(x => x.idEEFF == EEFF.UtilidadNeta).nTotalMA;
            decimal nActivos = this.lstBalGenEval.Find(x => x.idEEFF == EEFF.TotalActivo).nTotalMA;
            decimal nRentabilidadInversion = clsNumerico.Dividir(nUtilidadNeta, nActivos);

            decimal nPasivos = this.lstBalGenEval.Find(x => x.idEEFF == EEFF.TotalPasivo).nTotalMA;
            decimal nPrestamoCRACLASA = this.objCreditoProp.nTotalMontoPagar;
            decimal nPatrimonio = this.lstBalGenEval.Find(x => x.idEEFF == EEFF.TotalPatrimonio).nTotalMA;
            decimal nEndeudamientoTotal = clsNumerico.Dividir(nPasivos + nPrestamoCRACLASA, nPatrimonio);

            decimal nCostoProduccion = this.lstEstResEval.Find(x => x.idEEFF == EEFF.CostoVentas).nTotalMA;
            decimal nPorcentajeFinanciamiento = clsNumerico.Dividir(nPrestamoCRACLASA, nCostoProduccion);

            foreach (clsIndicadorEval item in this.lstIndicadorEval)
            {
                if (item.nCodigo == IFN.CapitalTrabajo)
                {
                    item.nRatio = nCapitalTrabajo;
                }
                else if (item.nCodigo == IFN.CapacidadPago)
                {
                    item.nRatio = nCapacidadPago;
                }
                else if (item.nCodigo == IFN.RentabilidadInver)
                {
                    item.nRatio = nRentabilidadInversion;
                }
                else if (item.nCodigo == IFN.EndeudamientoTotal)
                {
                    item.nRatio = nEndeudamientoTotal;
                }
                else if (item.nCodigo == IFN.PorcentajeFinanciamiento)
                {
                    item.nRatio = nPorcentajeFinanciamiento;
                }
            }

            this.dtgIndiFinanc.Refresh();
        }
        #endregion

        #region métodos privados
        public void asignarDatos(
            List<clsBalGenEval> lstBalGenEval,
            List<clsEstResEval> lstEstResEval,
            List<clsIndicadorEval> lstIndicadorEval,
            List<clsDetBalGenEval> lstDetBalGenEval,
            clsEvalCred objEvalCred
        )
        {
            this.quitarEventos();

            this.lstBalGenEval = lstBalGenEval;
            this.bindingBalGenEval.DataSource = this.lstBalGenEval;
            this.dtgBalGenEval.DataSource = this.bindingBalGenEval;
            this.formatearBBGG();
            this.estilosBBGG();

            this.lstEstResEval = lstEstResEval;
            this.bindingEstResEval.DataSource = this.lstEstResEval;
            this.dtgEstResEval.DataSource = this.bindingEstResEval;
            this.formatearEERR();
            this.estilosEERR();

            this.lstIndicadorEval = lstIndicadorEval;
            this.bindingIndicadorEval.DataSource = this.lstIndicadorEval;
            this.dtgIndiFinanc.DataSource = this.bindingIndicadorEval;
            this.formatearIIFF();

            this.objEvalCred = objEvalCred;

            this.asignarComponentes();
            this.agregarEventos();
        }

        private void quitarEventos()
        {
            this.dtgBalGenEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCell_EditingControlShowing);
            this.dtgBalGenEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.Leave -= new System.EventHandler(this.dtgBalGenEval_Leave);

            this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCell_EditingControlShowing);
            this.dtgEstResEval.Leave -= new System.EventHandler(this.dtgEstResEval_Leave);

            this.dtgIndiFinanc.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
        }

        private void agregarEventos()
        {
            this.dtgBalGenEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCell_EditingControlShowing);
            this.dtgBalGenEval.Leave += new System.EventHandler(this.dtgBalGenEval_Leave);

            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCell_EditingControlShowing);
            this.dtgEstResEval.Leave += new System.EventHandler(this.dtgEstResEval_Leave);

            this.dtgIndiFinanc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
        }

        private void asignarComponentes()
        {
            this.tsmBGTitulo.Text = String.Format("Balance General {0}", Evaluacion.MonedaSimbolo);
            this.tsmERTitulo.Text = String.Format("Estado Resultados {0}", Evaluacion.MonedaSimbolo);

            this.tsmBGFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
            this.tsmERFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
        }

        private void formatearDataGridView()
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

        public decimal buscarValorEEFF(int idClaseAnalisis, int idTipoAnalisis, int idEEFF, int idFuncionDinamica, decimal nMontoProp, decimal nCuotaAprox, int idDestino, DataTable dtReemplazos)
        {

            if (idEEFF == 9999) return nCuotaAprox;
            else if (idEEFF == 8888)
            {
                clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.ejecutarFuncionDinamica(idFuncionDinamica, dtReemplazos);
                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    return Convert.ToDecimal(objRespuestaServidor.objDatos);
                }
                else
                {
                    return decimal.Zero;
                }

            }
            else if (idEEFF == 7777) return nMontoProp;
            else if (idEEFF == 6666) return idDestino;

            decimal nValor = decimal.Zero;
            if (idClaseAnalisis == 1)
            {
                clsEstResEval objEstResEval = this.lstEstResEval.Find(x => x.idEEFF == idEEFF);
                if (objEstResEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objEstResEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objEstResEval.nTotalUltEvMA != decimal.Zero) ?
                                (objEstResEval.nTotalMA - objEstResEval.nTotalUltEvMA) / objEstResEval.nTotalUltEvMA :
                                decimal.Zero;
                            break;
                        case 3:
                            nValor = objEstResEval.nTotalMA;
                            break;
                    }
                }
            }
            else if (idClaseAnalisis == 2)
            {
                clsBalGenEval objBalGenEval = this.lstBalGenEval.Find(x => x.idEEFF == idEEFF);
                if (objBalGenEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objBalGenEval.nTotalUltEvMA != decimal.Zero) ?
                                (objBalGenEval.nTotalMA - objBalGenEval.nTotalUltEvMA) / objBalGenEval.nTotalUltEvMA :
                                decimal.Zero;
                            break;
                        case 3:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                    }
                }
            }
            else if (idClaseAnalisis == 3)
            {
                clsBalGenEval objBalGenEval = this.lstBalGenEval.Find(x => x.idEEFF == idEEFF);
                if (objBalGenEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objBalGenEval.nTotalUltEvMA != decimal.Zero) ?
                                (objBalGenEval.nTotalMA - objBalGenEval.nTotalUltEvMA) / objBalGenEval.nTotalUltEvMA :
                                decimal.Zero;
                            break;
                        case 3:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                    }
                }
            }
            else if (idClaseAnalisis == 7)
            {
                clsBalGenEval objBalGenEval = this.lstBalGenEval.Find(x => x.idEEFF == idEEFF);
                if (objBalGenEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objBalGenEval.nTotalUltEvMA != decimal.Zero) ?
                                (objBalGenEval.nTotalMA - objBalGenEval.nTotalUltEvMA) / objBalGenEval.nTotalUltEvMA :
                                decimal.Zero;
                            break;
                        case 3:
                            nValor = objBalGenEval.nTotalMA;
                            break;
                    }
                }
            }

            return nValor;

        }

        public List<clsEvalCredAlertaVariable> lstAlertaVariable(int idSolicitud, int idSectorEcon, decimal nMontoProp, decimal nCuotaAprox, int idDestino)
        {
            #region generar reemplazos
            DataTable dtReemplazos = new DataTable();
            dtReemplazos.Columns.Add("cNombre", typeof(string));
            dtReemplazos.Columns.Add("cValor", typeof(string));

            DataRow drFila = dtReemplazos.NewRow();
            drFila["cNombre"] = "idCliente";
            drFila["cValor"] = this.objEvalCred.idCli.ToString();
            dtReemplazos.Rows.Add(drFila);

            drFila = dtReemplazos.NewRow();
            drFila["cNombre"] = "nMonto";
            drFila["cValor"] = nMontoProp.ToString();
            dtReemplazos.Rows.Add(drFila);
            #endregion

            this.objCNAlertaVariable = new clsCNAlertaVariable();
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = new List<clsEvalCredAlertaVariable>();

            List<clsAlertaVariable> lstAlertaVariable = this.objCNAlertaVariable.listarAlertaVariable(idSolicitud, idSectorEcon);
            Dictionary<string, decimal> dcValorEEFF = new Dictionary<string, decimal>();
            DataTable dtEvaluador = new DataTable();

            foreach (clsAlertaVariable objAlerta in lstAlertaVariable)
            {
                string cCondicion = objAlerta.cCondicion;

                int idEEFF = 0;
                string[] vFragmentos = cCondicion.Split('[', ']');
                string cCondReemplazado = string.Empty;

                for (int i = 0; i < vFragmentos.Length; i++)
                {
                    string cCadena = vFragmentos[i].Trim();

                    if (int.TryParse(cCadena, out idEEFF))
                    {
                        decimal nValor = this.buscarValorEEFF(objAlerta.idClaseAnalisis, objAlerta.idTipoAnalisis, idEEFF, objAlerta.idFuncionDinamica, nMontoProp, nCuotaAprox, idDestino, dtReemplazos);
                        vFragmentos[i] = nValor.ToString("##0.0000");
                    }
                    cCondReemplazado = string.Concat(cCondReemplazado, vFragmentos[i]);
                }

                bool lEvaluacion = false;
                try
                {
                    lEvaluacion = Convert.ToBoolean(dtEvaluador.Compute(cCondReemplazado, ""));
                }
                catch
                {
                    lEvaluacion = false;
                }

                if (lEvaluacion)
                {
                    clsEvalCredAlertaVariable objEvalCredAlerta = new clsEvalCredAlertaVariable();

                    objEvalCredAlerta.idClaseAnalisis = objAlerta.idClaseAnalisis;
                    objEvalCredAlerta.cClaseAnalisis = objAlerta.cClaseAnalisis;
                    objEvalCredAlerta.idTipoAnalisis = objAlerta.idTipoAnalisis;
                    objEvalCredAlerta.cTipoAnalisis = objAlerta.cTipoAnalisis;
                    objEvalCredAlerta.idFuncionDinamica = objAlerta.idFuncionDinamica;
                    objEvalCredAlerta.cIdsSectorEcon = objAlerta.cIdsSectorEcon;
                    objEvalCredAlerta.cAlertaVariable = objAlerta.cAlertaVariable;
                    objEvalCredAlerta.lReqVistoBueno = objAlerta.lReqVistoBueno;

                    objEvalCredAlerta.idAlertaVariable = objAlerta.idAlertaVariable;
                    objEvalCredAlerta.cValor = cCondReemplazado;
                    objEvalCredAlerta.idEvalCred = this.objEvalCred.idEvalCred;
                    objEvalCredAlerta.idSolicitud = idSolicitud;

                    lstEvalCredAlerta.Add(objEvalCredAlerta);
                }
            }

            return lstEvalCredAlerta;
        }
        #endregion

        #region métodos privados - BBGG
        private void formatearBBGG()
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
            dtgBalGenEval.Columns["nTotalUltEvMA"].HeaderText = "Última Ev.";
            dtgBalGenEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgBalGenEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";
            dtgBalGenEval.Columns["nAnalisisHoriz"].HeaderText = "A. Horiz.";

            dtgBalGenEval.Columns["nTotalUltEvMA"].ToolTipText = "Última Evaluación";
            dtgBalGenEval.Columns["nTotalMA"].ToolTipText = "";
            dtgBalGenEval.Columns["nAnalisisVerti"].ToolTipText = "Análisis Vertical";
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
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p2";
            dtgBalGenEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p2";

            dtgBalGenEval.Columns["cDescripcion"].ReadOnly = true;
            dtgBalGenEval.Columns["nAnalisisVerti"].ReadOnly = true;
            dtgBalGenEval.Columns["nAnalisisHoriz"].ReadOnly = true;
        }

        private void estilosBBGG()
        {
            int idEEFF = 0;
            foreach (DataGridViewRow row in this.dtgBalGenEval.Rows)
            {
                idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);

                if (idEEFF == EEFF.TotalActivo || idEEFF == EEFF.TotalAcCorriente || idEEFF == EEFF.TotalAcNoCorriente ||
                    idEEFF == EEFF.TotalPasivo || idEEFF == EEFF.TotalPaCorriente || idEEFF == EEFF.TotalPaNoCorriente ||
                    idEEFF == EEFF.TotalPatrimonio || idEEFF == EEFF.TotalPasivoPatrimonio || idEEFF == EEFF.PatrimonioFamiempresa)
                {
                    row.ReadOnly = true;
                    if (idEEFF == EEFF.TotalActivo || idEEFF == EEFF.TotalPasivo || idEEFF == EEFF.TotalPatrimonio || idEEFF == EEFF.TotalPasivoPatrimonio || idEEFF == EEFF.PatrimonioFamiempresa)
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

        private void calcularBBGG()
        {
            if (this.lstBalGenEval == null) return;

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

            lstBalGenEval.Find(x => x.idEEFF == EEFF.Caja).nTotalMA = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.Caja).Sum(x => x.nTotalMA);
            lstBalGenEval.Find(x => x.idEEFF == EEFF.Caja).nTotalUltEvMA = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.Caja).Sum(x => x.nTotalUltEvMA);
            lstBalGenEval.Find(x => x.idEEFF == EEFF.Inventario).nTotalMA = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.Inventario).Sum(x => x.nTotalMA);
            lstBalGenEval.Find(x => x.idEEFF == EEFF.Inventario).nTotalUltEvMA = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.Inventario).Sum(x => x.nTotalUltEvMA);
            nAcCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalMA);
            nAcNoCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalMA);
            nActivos = nAcCorriente + nAcNoCorriente;
            nPaCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalMA);
            nPaNoCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalMA);
            nPasivos = nPaCorriente + nPaNoCorriente;
            nPatrimonio = nActivos - nPasivos;

            nUlEvAcCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvAcNoCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvActivos = nUlEvAcCorriente + nUlEvAcNoCorriente;
            nUlEvPaCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvPaNoCorriente = lstBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalUltEvMA);
            nUlEvPasivos = nUlEvPaCorriente + nUlEvPaNoCorriente;
            nUlEvPatrimonio = nUlEvActivos - nUlEvPasivos;

            foreach (clsBalGenEval item in lstBalGenEval)
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

            this.bindingBalGenEval.ResetBindings(false);
            this.calcularIIFF();
        }
        #endregion

        #region métodos privados - EERR
        private void formatearEERR()
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
            dtgEstResEval.Columns["nAnalisisVerti"].Visible = true;
            dtgEstResEval.Columns["nAnalisisHoriz"].Visible = true;

            dtgEstResEval.Columns["cDescripcion"].HeaderText = "";
            dtgEstResEval.Columns["nTotalUltEvMA"].HeaderText = "Última Ev.";
            dtgEstResEval.Columns["nTotalMA"].HeaderText = "Ev. Actual";
            dtgEstResEval.Columns["nAnalisisVerti"].HeaderText = "A. Vert.";
            dtgEstResEval.Columns["nAnalisisHoriz"].HeaderText = "A. Horiz.";

            dtgEstResEval.Columns["nTotalUltEvMA"].ToolTipText = "Última Evaluación";
            dtgEstResEval.Columns["nTotalMA"].ToolTipText = "";
            dtgEstResEval.Columns["nAnalisisVerti"].ToolTipText = "Análisis Vertical";
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
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p2";
            dtgEstResEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p2";

            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
            dtgEstResEval.Columns["nTotalMA"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisVerti"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisHoriz"].ReadOnly = true;
        }

        private void estilosEERR()
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

        private void calcularEERR()
        {
            if (this.lstEstResEval == null) return;

            decimal nVentas = lstEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            decimal nCostos = lstEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
            decimal nUtilidadBruta = nVentas - nCostos;
            decimal nGastosOperativos = lstEstResEval.Where(x => x.idEEFF == EEFF.GastosOperativos).Sum(x => x.nTotalMA);
            decimal nUtilidadOperativa = nUtilidadBruta - nGastosOperativos;
            decimal nGastosFinancieros = lstEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
            decimal nUtilidadNeta = nUtilidadOperativa - nGastosFinancieros;
            decimal nOtrosIngresos = lstEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            decimal nOtrosEgresos = lstEstResEval.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);
            decimal nGastosFamiliares = lstEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);
            decimal nUtilidadDisponible = nUtilidadNeta + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares;

            foreach (clsEstResEval item in lstEstResEval)
            {
                if (item.idEEFF == EEFF.UtilidadBruta)
                {
                    item.nTotalMA = nUtilidadBruta;
                    //item.nTotalUltEvMA = nUlEvUBruta;
                }

                else if (item.idEEFF == EEFF.UtilidadOperativa)
                {
                    item.nTotalMA = nUtilidadOperativa;
                    //item.nTotalUltEvMA = nUlEvUOperativa;
                }
                else if (item.idEEFF == EEFF.UtilidadNeta)
                {
                    item.nTotalMA = nUtilidadNeta;
                    //item.nTotalUltEvMA = nUlEvUNeta;
                }
                else if (item.idEEFF == EEFF.UtilidadDisponible)
                {
                    item.nTotalMA = nUtilidadDisponible;
                    //item.nTotalUltEvMA = nUlEvUDisponible;
                }
                //item.nVentasNetas = nVentasNetas;
            }

            this.bindingEstResEval.ResetBindings(false);
            this.calcularIIFF();
        }
        #endregion

        #region métodos privados - IIFF
        private void formatearIIFF()
        {
            DataGridViewImageColumn imgValidacion = new DataGridViewImageColumn();
            imgValidacion.Name = "imgValidacion";
            imgValidacion.DataPropertyName = "imgValidacion";
            this.dtgIndiFinanc.Columns.Add(imgValidacion);

            foreach (DataGridViewColumn column in this.dtgIndiFinanc.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIndiFinanc.Columns["cDescripcion"].DisplayIndex = 0;
            dtgIndiFinanc.Columns["nRatio"].DisplayIndex = 1;
            dtgIndiFinanc.Columns["imgValidacion"].DisplayIndex = 2;
            dtgIndiFinanc.Columns["cDescRegla"].DisplayIndex = 3;

            dtgIndiFinanc.Columns["cDescripcion"].Visible = true;
            dtgIndiFinanc.Columns["nRatio"].Visible = true;
            dtgIndiFinanc.Columns["imgValidacion"].Visible = true;
            dtgIndiFinanc.Columns["cDescRegla"].Visible = true;

            dtgIndiFinanc.Columns["cDescripcion"].FillWeight = 90;
            dtgIndiFinanc.Columns["nRatio"].FillWeight = 35;
            dtgIndiFinanc.Columns["imgValidacion"].FillWeight = 10;
            dtgIndiFinanc.Columns["cDescRegla"].FillWeight = 25;

            dtgIndiFinanc.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void estilosIIFF()
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
        #endregion

        #region eventos
        private void dtgCell_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dtgCell_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            e.Control.KeyPress -= new KeyPressEventHandler(dtgCell_KeyPress);
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalUltEvMA") || dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nTotalMA"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dtgCell_KeyPress);
                }
            }
        }

        private void btnBalGeneral_Click(object sender, EventArgs e)
        {
            if (this.eventBBGGClick != null)
                this.eventBBGGClick(sender, e);
        }

        private void btnActividadAgricola_Click(object sender, EventArgs e)
        {
            if (this.eventActividadAgricolaClick != null)
                this.eventActividadAgricolaClick(sender, e);
        }

        private void btnEstResultados_Click(object sender, EventArgs e)
        {
            if (this.eventEERRClick != null)
                this.eventEERRClick(sender, e);
        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            if (this.eventDeudasClick != null)
                this.eventDeudasClick(sender, e);
        }

        private void chcHabilitado_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        #region eventos - BBGG
        private void dtgBalGenEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.estilosBBGG();
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.calcularBBGG();
            this.dtgBalGenEval.Refresh();
        }

        private void dtgBalGenEval_Leave(object sender, EventArgs e)
        {
            this.dtgBalGenEval.ClearSelection();
        }
        #endregion

        #region eventos - EERR
        private void dtgEstResEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.estilosEERR();
            this.dtgEstResEval.ClearSelection();
        }

        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.calcularEERR();
            this.dtgEstResEval.Refresh();
        }

        private void dtgEstResEval_Leave(object sender, EventArgs e)
        {
            this.dtgEstResEval.ClearSelection();
        }
        #endregion

        #region eventos - IIFF
        private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewCell cell = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescripcion"];
                cell.ToolTipText = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescFormula"].Value.ToString();

                if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("imgValidacion"))
                {
                    decimal nValorMinimo = this.lstIndicadorEval[e.RowIndex].nValorMinimo;
                    decimal nValorMaximo = this.lstIndicadorEval[e.RowIndex].nValorMaximo;
                    decimal nRatio = this.lstIndicadorEval[e.RowIndex].nRatio;

                    nRatio = (this.lstIndicadorEval[e.RowIndex].nTipoVariable == 2) ? nRatio * 100 : nRatio;
                    nRatio = Math.Round(nRatio, 2);

                    if (nValorMinimo == 0m && nValorMaximo == 0m)
                    {
                        e.Value = imageList.Images[2];
                    }
                    else if (nRatio >= nValorMinimo && nRatio <= nValorMaximo)
                    {
                        e.Value = imageList.Images[1]; // Valido
                    }
                    else
                    {
                        e.Value = imageList.Images[0]; // No válido
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void dtgIndiFinanc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.estilosIIFF();
            this.dtgIndiFinanc.ClearSelection();
        }
        #endregion
    }
}
