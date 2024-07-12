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
using CRE.CapaNegocio;

namespace CRE.ControlBase
{
    public partial class ConEstadosFinancierosRural : UserControl
    {
        private List<clsBalGenEval> listBalGenEval = null;
        private List<clsEstResEval> listEstResEval = null;

        private clsCNAlertaVariable objCNAlertaVariable;
        private DataTable dtReemplazos;

        public event EventHandler DeudasClick;
        public event EventHandler BBGGClick;
        public event EventHandler EERRClick;
        public event EventHandler EHZTLClick;
        public event EventHandler ProyeccionEstacionalClick;
        public event EventHandler GarantiasRuralClick;

        public event DataGridViewCellEventHandler CellValueChangedEstadosFinancieros;

        private const int nAnioMinimo = 2000;
        private const int nAnioDefault = 2000;
        private int idTipEvalCred;
        private decimal nTotalPlantel;
        private decimal nTotalSaca;
        private int idEvalCred;
        private int idCliente;
        private int idDestino;

        private decimal nCapitalPropuesto;
        private decimal nCuotaAproximada;

        //private bool lOtrosIngresosHabilitado

        public ConEstadosFinancierosRural()
        {
            InitializeComponent();

            lMostrarBalanceGeneral = true;
            lMostrarBotones = true;
            lMostrarEtadosResultados = true;

            lHabilitarBalanceGeneral = true;
            lHabilitarBotones = true;
            lHabilitarEtadosResultados = true;

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

        public bool ButtonDeudas
        {
            get
            {
                return this.btnDeudas.Enabled;
            }
            set
            {
                this.btnDeudas.Enabled = value;
            }
        }

        public bool ButtonBalanceGeneral
        {
            get
            {
                return this.btnBalGeneral.Enabled;
            }
            set
            {
                this.btnBalGeneral.Enabled = value;
            }
        }

        public bool ButtonEstadosResultados
        {
            get
            {
                return this.btnEstResultados.Enabled;
            }
            set
            {
                this.btnEstResultados.Enabled = value;
            }
        }

        public bool ButtonIngresoEgresoEstacional
        {
            get
            {
                return this.btnProyeccionEstacional.Enabled;
            }
            set
            {
                this.btnProyeccionEstacional.Enabled = value;
            }
        }

        public bool UltEvaluacionLimpiarCeldas = true;

        public bool lMostrarBalanceGeneral
        {
            get
            {
                return this.plBalance.Visible;
            }
            set
            {
                this.plBalance.Visible = value;
                Invalidate();
            }
        }
        public bool lMostrarBotones
        {
            get
            {
                return this.plBotones.Visible;
            }
            set
            {
                this.plBotones.Visible = value;
                Invalidate();
            }
        }
        public bool lMostrarEtadosResultados
        {
            get
            {
                return this.plEstadoResultados.Visible;
            }
            set
            {
                this.plEstadoResultados.Visible = value;
                Invalidate();
            }
        }

        public bool lHabilitarBalanceGeneral
        {
            get
            {
                return this.plBalance.Enabled;
            }
            set
            {
                this.plBalance.Enabled = value;
                Invalidate();
            }
        }
        public bool lHabilitarBotones
        {
            get
            {
                return this.plBotones.Enabled;
            }
            set
            {
                this.plBotones.Enabled = value;
                Invalidate();
            }
        }
        public bool lHabilitarEtadosResultados
        {
            get
            {
                return this.plEstadoResultados.Enabled;
            }
            set
            {
                this.plEstadoResultados.Enabled = value;
                Invalidate();
            }
        }

        #endregion

        #region Métodos Públicos
        public void AsignarDatos(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsIndicadorEval> _listIndiFinanc, List<clsDetBalGenEval> _listInventario,
            decimal _nCapitalPropuesto, decimal _nCuotaAprox, decimal _nDestinoCapitalTrabajo, decimal _nTotalPasivoAC, decimal _nCapitalParacomercio, int _nCodigoSectorEconomico,
            int _idTipEvalCred, decimal _nTotalPlantel, decimal _nTotalSaca, int _idEvalCred, int idCliente, int idDestino)
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
            this.chcHabilitado.CheckedChanged -= new System.EventHandler(this.chcHabilitado_CheckedChanged);

            // -- 
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;
            this.idTipEvalCred = _idTipEvalCred;
            this.nTotalPlantel = _nTotalPlantel;
            this.nTotalSaca = _nTotalSaca;
            this.idEvalCred = _idEvalCred;

            this.idCliente = idCliente;
            this.idDestino = idDestino;

            this.nCuotaAproximada = _nCuotaAprox;
            this.nCapitalPropuesto = _nCapitalPropuesto;

            // --Balance General
            this.bindingBalGenEval.DataSource = this.listBalGenEval;
            this.dtgBalGenEval.DataSource = this.bindingBalGenEval;
            this.FormatearColumnasDataGridViewBBGG();

            // --Estado de Resultados
            this.bindingEstResEval.DataSource = this.listEstResEval;
            this.dtgEstResEval.DataSource = this.bindingEstResEval;
            this.FormatearColumnasDataGridViewEERR();

            // -- Indicadores Financieros
            this.conIndicadores.AsignarDatos(_listIndiFinanc, _listBalGenEval, _listEstResEval, _listInventario,
                _nCapitalPropuesto, _nCuotaAprox, _nDestinoCapitalTrabajo, _nTotalPasivoAC, _nCapitalParacomercio, _nCodigoSectorEconomico, 
                this.idTipEvalCred, this.nTotalPlantel, this.nTotalSaca, this.idEvalCred);

            // --Configuración
            this.tsmBGTitulo.Text = String.Format("Balance General {0}", Evaluacion.MonedaSimbolo);
            this.tsmERTitulo.Text = String.Format("Estado Resultados {0}", Evaluacion.MonedaSimbolo);

            this.dtUltEvaluacion.Value = ((Evaluacion.FechaUltimaEval != null) ? (DateTime)(Evaluacion.FechaUltimaEval) : new System.DateTime(nAnioDefault, 1, 1, 0, 0, 0, 0));

            this.tsmBGFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
            this.tsmERFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);

            // --
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
            //--


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
            this.chcHabilitado.CheckedChanged += new System.EventHandler(this.chcHabilitado_CheckedChanged);

            dtgBalGenEval_DataBindingComplete(null, null);
            dtgEstResEval_DataBindingComplete(null, null);
            //dtgBalGenEval_CellValueChanged(null, null);
            //dtgEstResEval_CellValueChanged(null, null);

            this.CalcularBBGG();
            this.dtgBalGenEval.Refresh(); //ok

            this.CalcularEERR();
            this.dtgEstResEval.Refresh(); //ok
        }

        public void PuntajeEvalCualitativa(decimal nPuntajeEvalCualitativa)
        {
            conIndicadores.PuntajeEvalCualitativa(nPuntajeEvalCualitativa);
        }

        public void setCuotasMensuales(int nCuotasMensuales)
        {
            this.conIndicadores.setCuotasMensuales(nCuotasMensuales);
        }

        public void setIdTipoPeriodo(int idTipoPeriodo)
        {
            this.conIndicadores.setIdTipoPeriodo(idTipoPeriodo);
        }

        public void setIdPeriodo(int idPeriodo)
        {
            this.conIndicadores.setIdPeriodo(idPeriodo);
        }

        /// <summary>
        /// actualiza los indicadores financieros conforme a los parámestros establecidos
        /// </summary>
        public void ActualizarIndicadores()
        {
            conIndicadores.Actualizar();
        }

        public void ActualizarPorIndicadores(List<clsIndicadorEval> _listIndiFinanc)
        {
            this.conIndicadores.ActualizarPorIndicadores(_listIndiFinanc);
        }

        public void ActualizarPorEstadosFinancieros(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsDetBalGenEval> _listInventario,
            decimal _nTotalPasivoAC, decimal _nCapitalParaComercio)
        {
            this.conIndicadores.ActualizarPorEstadosFinancieros(_listBalGenEval, _listEstResEval, _listInventario, _nTotalPasivoAC, _nCapitalParaComercio);
        }

        public void ActualizarPorSectorEconomico(int _nCodigoSectorEconomico)
        {
            this.conIndicadores.ActualizarPorSectorEconomico(_nCodigoSectorEconomico);
        }

        public void ActualizarPorDestinoCapitalTrabajo(decimal nDestinoCapitalTrabajo)
        {
            this.conIndicadores.ActualizarPorDestinoCapitalTrabajo(nDestinoCapitalTrabajo);
        }

        public void ActualizarPuntajeEvalCualitativa(decimal _nPtjeEvalCualitativa)
        {
            this.conIndicadores.ActualizarPuntajeEvalCualitativa(_nPtjeEvalCualitativa);
        }

        public void ActualizarPorIndPorMPropPorMAprox(List<clsIndicadorEval> _listIndiFinanc, decimal _nMontoProp, decimal _nCuotaAprox)
        {
            this.conIndicadores.ActualizarPorIndPorMPropPorMAprox(_listIndiFinanc, _nMontoProp, _nCuotaAprox);
            this.nCuotaAproximada = _nCuotaAprox;
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

        public List<clsEvalCredAlertaVariable> listarAlertaVariable(int idSolicitud, int idSectorEcon)
        {
            this.generarReemplazos();
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

                for (int i = 0; i < vFragmentos.Length; i++ )
                {
                    string cCadena = vFragmentos[i].Trim();

                    if (int.TryParse(cCadena, out idEEFF))
                    {
                        decimal nValor = this.buscarValorEEFF(objAlerta.idClaseAnalisis, objAlerta.idTipoAnalisis, idEEFF, objAlerta.idFuncionDinamica);
                        vFragmentos[i] = nValor.ToString("##0.0000");
                    }
                    cCondReemplazado = string.Concat(cCondReemplazado,vFragmentos[i]);
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
                    objEvalCredAlerta.idEvalCred = this.idEvalCred;
                    objEvalCredAlerta.idSolicitud = idSolicitud;

                    lstEvalCredAlerta.Add(objEvalCredAlerta);
                }
            }
           
            return lstEvalCredAlerta;
        }
        public void generarReemplazos()
        {
            this.dtReemplazos = new DataTable();
            this.dtReemplazos.Columns.Add("cNombre", typeof(string));
            this.dtReemplazos.Columns.Add("cValor", typeof(string));

            DataRow drFila = this.dtReemplazos.NewRow();
            drFila["cNombre"] = "idCliente";
            drFila["cValor"] = this.idCliente.ToString();
            dtReemplazos.Rows.Add(drFila);

            drFila = this.dtReemplazos.NewRow();
            drFila["cNombre"] = "nMonto";
            drFila["cValor"] = this.nCapitalPropuesto.ToString();
            dtReemplazos.Rows.Add(drFila);

        }
        public decimal buscarValorEEFF(int idClaseAnalisis, int idTipoAnalisis, int idEEFF, int idFuncionDinamica)
        {

            if (idEEFF == 9999) return this.nCuotaAproximada;
            else if (idEEFF == 8888)
            {
                clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.ejecutarFuncionDinamica(idFuncionDinamica, this.dtReemplazos);
                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    return Convert.ToDecimal(objRespuestaServidor.objDatos);
                }
                else
                {
                    return decimal.Zero;
                }

            }
            else if (idEEFF == 7777) return this.nCapitalPropuesto;
            else if (idEEFF == 6666) return this.idDestino;

            decimal nValor = decimal.Zero;
            if (idClaseAnalisis == 1)
            {
                clsEstResEval objEstResEval = this.listEstResEval.Find(x => x.idEEFF == idEEFF);
                if (objEstResEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objEstResEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objEstResEval.nTotalUltEvMA != decimal.Zero)?
                                (objEstResEval.nTotalMA - objEstResEval.nTotalUltEvMA) / objEstResEval.nTotalUltEvMA:
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
                clsBalGenEval objBalGenEval = this.listBalGenEval.Find(x => x.idEEFF == idEEFF);
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
                clsBalGenEval objBalGenEval = this.listBalGenEval.Find(x => x.idEEFF == idEEFF);
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
                clsBalGenEval objBalGenEval = this.listBalGenEval.Find(x => x.idEEFF == idEEFF);
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
        
        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgBalGenEval.Margin = new System.Windows.Forms.Padding(0);
            this.dtgBalGenEval.MultiSelect = false;
            this.dtgBalGenEval.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgBalGenEval.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBalGenEval.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgBalGenEval.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgBalGenEval.RowHeadersVisible = false;
            this.dtgBalGenEval.SelectionMode = DataGridViewSelectionMode.CellSelect;


            this.dtgEstResEval.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEstResEval.MultiSelect = false;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.dtgEstResEval.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dtgEstResEval.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
            this.dtgEstResEval.RowHeadersVisible = false;
            this.dtgEstResEval.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //this.dtgEstResEval.ReadOnly = true;
        }

        // --BBGG
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
            dtgBalGenEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p2";
            dtgBalGenEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p2";

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

        // --EERR
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
            dtgEstResEval.Columns["nAnalisisVerti"].Visible = true;
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
            dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.Format = "p2";
            dtgEstResEval.Columns["nAnalisisHoriz"].DefaultCellStyle.Format = "p2";

            dtgEstResEval.Columns["cDescripcion"].ReadOnly = true;
            dtgEstResEval.Columns["nTotalMA"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisVerti"].ReadOnly = true;
            dtgEstResEval.Columns["nAnalisisHoriz"].ReadOnly = true;

            //dtgEstResEval.Columns["nAnalisisVerti"].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            //dtgEstResEval.Columns["nTotalMA"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

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

            decimal nUlEvVentasNetas = 0m,
                    nUlEvCostoVentas = 0m,
                    nUlEvUBruta = 0m,
                    nUlEvGastoNegocio = 0m,
                    nUlEvUOperativa = 0m,
                    nUlEvGastosFinancieros = 0m,
                    nUlEvUNeta = 0m,
                    nUlEvOtrosIngresos = 0m,
                    nUlEvOtrosEgresos = 0m,
                    nUlEvGastosFamiliares = 0m,
                    nUlEvUDisponible = 0m;
            decimal nVentasNetasExtra = 0m;
            decimal nVentasNetasExtraUlt = 0m;


            //---------------- Actual Evaluación
            nVentasNetas = listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            nCostoVentas = listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
            nVentasNetasExtra = listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlTitular).Sum(x => x.nTotalMA);
            nVentasNetasExtra = nVentasNetasExtra + listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlCónyuge).Sum(x => x.nTotalMA);
            nUBruta = nVentasNetas + nVentasNetasExtra - nCostoVentas;

            nGastoNegocio = listEstResEval.Where(x => x.idEEFF == EEFF.GastosNegocio).Sum(x => x.nTotalMA);
            nUOperativa = nUBruta - nGastoNegocio;

            nGastosFinancieros = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
            nUNeta = nUOperativa - nGastosFinancieros;

            nOtrosIngresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            nOtrosEgresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);
            nGastosFamiliares = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);
            nUDisponible = nUNeta + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares;

            //---------------- Ultima Evaluación
            nUlEvVentasNetas = listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalUltEvMA);
            nUlEvCostoVentas = listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalUltEvMA);
            nVentasNetasExtraUlt = listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlTitular).Sum(x => x.nTotalUltEvMA);
            nVentasNetasExtraUlt = nVentasNetasExtraUlt + listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlCónyuge).Sum(x => x.nTotalUltEvMA);
            nUlEvUBruta = nUlEvVentasNetas + nVentasNetasExtraUlt - nUlEvCostoVentas;

            nUlEvGastoNegocio = listEstResEval.Where(x => x.idEEFF == EEFF.GastosNegocio).Sum(x => x.nTotalUltEvMA);
            nUlEvUOperativa = nUlEvUBruta - nUlEvGastoNegocio;

            nUlEvGastosFinancieros = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalUltEvMA);
            nUlEvUNeta = nUlEvUOperativa - nUlEvGastosFinancieros;

            nUlEvOtrosIngresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalUltEvMA);
            nUlEvOtrosEgresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalUltEvMA);
            nUlEvGastosFamiliares = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalUltEvMA);
            nUlEvUDisponible = nUlEvUNeta + nUlEvOtrosIngresos - nUlEvOtrosEgresos - nUlEvGastosFamiliares;

            //---------------
            foreach (clsEstResEval item in listEstResEval)
            {
                if (item.idEEFF == EEFF.UtilidadBruta)
                {
                    item.nTotalMA = nUBruta;
                    item.nTotalUltEvMA = nUlEvUBruta;
                }

                else if (item.idEEFF == EEFF.UtilidadOperativa)
                {
                    item.nTotalMA = nUOperativa;
                    item.nTotalUltEvMA = nUlEvUOperativa;
                }
                else if (item.idEEFF == EEFF.UtilidadNeta)
                {
                    item.nTotalMA = nUNeta;
                    item.nTotalUltEvMA = nUlEvUNeta;
                }
                else if (item.idEEFF == EEFF.UtilidadDisponible)
                {
                    item.nTotalMA = nUDisponible;
                    item.nTotalUltEvMA = nUlEvUDisponible;
                }

                item.nVentasNetas = nVentasNetas;
            }
        }

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
            //this.lblUltEvaluacion.Enabled = lHabilitado;
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

        
        #endregion

        #region Eventos
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
        private void dtgBalGenEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewBBGG();
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularBBGG();
            //this.bindingBalGenEval.ResetBindings(false);
            this.dtgBalGenEval.Refresh(); //ok

            if (CellValueChangedEstadosFinancieros != null)
                CellValueChangedEstadosFinancieros(sender, e);
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

        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularEERR();
            //this.bindingEstResEval.ResetBindings(false);
            this.dtgEstResEval.Refresh(); //ok

            if (CellValueChangedEstadosFinancieros != null)
                CellValueChangedEstadosFinancieros(sender, e);

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

        private void btnBalGeneral_Click(object sender, EventArgs e)
        {
            if (BBGGClick != null)
                BBGGClick(sender, e);
        }

        private void btnEstResultados_Click(object sender, EventArgs e)
        {
            if (EERRClick != null)
                EERRClick(sender, e);
        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            if (DeudasClick != null)
                DeudasClick(sender, e);
        }

        private void btnProyeccionEstacional_Click(object sender, EventArgs e)
        {
            if (ProyeccionEstacionalClick != null)
                ProyeccionEstacionalClick(sender, e);
        }

        private void chcHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarUltEvaluacion(this.chcHabilitado.Checked);
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
        
        private void btnEvalHorizontal_Click(object sender, EventArgs e)
        {

            if (EHZTLClick != null)
                EHZTLClick(sender, e);
        }

        private void btnGarantias_Click(object sender, EventArgs e)
        {
            if (GarantiasRuralClick != null)
                GarantiasRuralClick(sender, e);
        }

        #endregion
    }
}
