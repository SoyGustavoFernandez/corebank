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
using GEN.Funciones;

namespace CRE.ControlBase
{
    public partial class ConEstadosFinancierosAgrico : UserControl
    {
        private List<clsBalGenEval> listBalGenEval = null;
        private List<clsEstResEval> listEstResEval = null;

        private clsCNAlertaVariable objCNAlertaVariable;
        private DataTable dtReemplazos;

        public event EventHandler DeudasClick;
        public event EventHandler ActividadAgricolaClick;
        public event EventHandler BBGGClick;
        public event EventHandler EERRClick;
        public event EventHandler EHZTLClick;

        public event DataGridViewCellEventHandler CellValueChangedEstadosFinancieros;

        private const int nAnioMinimo = 2000;
        private const int nAnioDefault = 2000;

        private List<clsDetEstResEval> listIngresos;
        private List<clsDetEstResEval> listEgresos;
        private clsEvalCred objEvalCred;
        private DateTime dFechaBase;

        private List<clsIndicadorEval> listIndiFinanc;
        private decimal nMontoProp;
        private decimal nCuotaAprox;
        private decimal nTotalMontoPagar;

        private bool lValidacionEnabled;
        private bool lDescripcionReglaEnabled;
        private int idOperacion;
        private int idDestino;

        private int idCliente;
        private int idEvalCred;
        private decimal nTotalPasivoAC;
        public ConEstadosFinancierosAgrico()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.nMontoProp = 0;
            this.nCuotaAprox = 0;
            this.idCliente = 0;
            this.idEvalCred = 0;

            this.lValidacionEnabled = true;
            this.lDescripcionReglaEnabled = true;
        }

        #region "Properties"
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

        public bool UltEvaluacionLimpiarCeldas = true;

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
        public void AsignarDatos(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsIndicadorEval> _listIndiFinanc, List<clsDetBalGenEval> _listInventario,
            decimal _nCapitalPropuesto, decimal nTotalMontoPagar, decimal _nDestinoCapitalTrabajo, decimal _nTotalPasivoAC, decimal _nCapitalParacomercio, int _nCodigoSectorEconomico,
            int idCliente, int idEvalCred , int _idOperacion = 0, int idDestino = 0)
        {
            // -- Eventos
            this.dtgBalGenEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBalGenEval_EditingControlShowing);
            this.dtgBalGenEval.Leave -= new System.EventHandler(this.dtgBalGenEval_Leave);
            this.dtgBalGenEval.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgBalGenEval_DataError);
            //this.chcHabilitado.CheckedChanged -= new System.EventHandler(this.chcHabilitado_CheckedChanged);
            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);


            // -- 
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;

            // --Balance General
            this.bindingBalGenEval.DataSource = this.listBalGenEval;
            this.dtgBalGenEval.DataSource = this.bindingBalGenEval;
            this.FormatearColumnasDataGridViewBBGG();

            // --Estado de Resultados
            //this.bindingEstResEval.DataSource = this.listEstResEval;
            //this.dtgEstResEval.DataSource = this.bindingEstResEval;
            //this.FormatearColumnasDataGridViewEERR();

            // -- Indicadores Financieros
            //this.conIndicadores.AsignarDatos(_listIndiFinanc, _listBalGenEval, _listEstResEval, _listInventario,
            //    _nCapitalPropuesto, _nCuotaAprox, _nDestinoCapitalTrabajo, _nTotalPasivoAC, _nCapitalParacomercio, _nCodigoSectorEconomico);

            #region Indicadores Financieros

            this.listIndiFinanc = _listIndiFinanc;

            this.nMontoProp = _nCapitalPropuesto;
            /*this.nCuotaAprox = _nCuotaAprox;
            this.nDestinoCapitalTrabajo = _nDestinoCapitalTrabajo;*/
            this.nTotalMontoPagar = nTotalMontoPagar;
            this.nTotalPasivoAC = _nTotalPasivoAC;
            /*this.nCapitalParaComercio = _nCapitalParacomercio;
            this.nCodigoSectorEconomico = _nCodigoSectorEconomico;

            this.listIndiFinanc = _listIndiFinanc;
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;
            this.listInventario = _listInventario;

            this.bindingIndiFinanc.DataSource = this.listIndiFinanc;
            this.dtgIndiFinanc.DataSource = this.bindingIndiFinanc;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();*/

            this.dtgIndiFinanc.DataSource = this.listIndiFinanc;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearIndicadoresDGV();

            #endregion

            // --Configuración
            this.tsmBGTitulo.Text = String.Format("Balance General {0}", Evaluacion.MonedaSimbolo);
            //this.tsmERTitulo.Text = String.Format("Estado Resultados {0}", Evaluacion.MonedaSimbolo);

            //this.dtUltEvaluacion.Value = ((Evaluacion.FechaUltimaEval != null) ? (DateTime)(Evaluacion.FechaUltimaEval) : new System.DateTime(nAnioDefault, 1, 1, 0, 0, 0, 0));

            this.tsmBGFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);
            //this.tsmERFechaActualEval.Text = String.Format("{0:dd/MM/yyyy}", Evaluacion.FechaActualEval);

            // --
            /*if (((DateTime)(this.dtUltEvaluacion.Value)).Year >= nAnioMinimo)
            {
                this.chcHabilitado.Checked = true;
                this.tsmBGFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
                this.tsmERFechaUltimaEval.Text = this.dtUltEvaluacion.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                this.chcHabilitado.Checked = false;
            }*/
            //--


            // -- Eventos
            this.dtgBalGenEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBalGenEval_CellValueChanged);
            this.dtgBalGenEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgBalGenEval_DataBindingComplete);
            this.dtgBalGenEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBalGenEval_EditingControlShowing);
            this.dtgBalGenEval.Leave += new System.EventHandler(this.dtgBalGenEval_Leave);
            this.dtgBalGenEval.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgBalGenEval_DataError);
            //this.chcHabilitado.CheckedChanged += new System.EventHandler(this.chcHabilitado_CheckedChanged);
            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
            this.dtgIndiFinanc.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIndiFinanc_CellLeave);

            dtgBalGenEval_DataBindingComplete(null, null);
            //dtgEstResEval_DataBindingComplete(null, null);
            //dtgBalGenEval_CellValueChanged(null, null);
            //dtgEstResEval_CellValueChanged(null, null);

            this.CalcularBBGG();
            this.dtgBalGenEval.Refresh(); //ok
            this.idOperacion = _idOperacion;
            this.idCliente = idCliente;
            this.idEvalCred = idEvalCred;
            this.idDestino = idDestino;
        }

        public void ObtenerDatosDetalleEERR(clsEvalCred _objEvalCred, DateTime _dFechaBase)
        {
            this.dFechaBase = _dFechaBase;
            this.objEvalCred = _objEvalCred;

            this.txtDisponibleInicial.Text = this.objEvalCred.nDisponibleInicial.ToString("n2");

            DataSet ds = (new clsCNEvalAgrico()).RecuperarDetalleEstResultadosEval(this.objEvalCred.idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;

            this.listIngresos = (from p in listDetEstResEval
                                 where p.nOperacion == 1
                                 select p).OrderBy(x => x.nOrden).ToList();

            this.listEgresos = (from p in listDetEstResEval
                                where p.nOperacion == 2
                                select p).OrderBy(x => x.nOrden).ToList();

            this.dtgIngresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresos_EditingControlShowing);
            this.dtgIngresos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgIngresos_DataError);
            this.dtgIngresos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellValueChanged);
            this.dtgIngresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresos_DataBindingComplete);
            this.dtgIngresos.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellLeave);
            this.dtgEgresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEgresos_EditingControlShowing);
            this.dtgEgresos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEgresos_DataError);
            this.dtgEgresos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEgresos_CellValueChanged);
            this.dtgEgresos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEgresos_DataBindingComplete);
            this.dtgEgresos.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEgresos_CellLeave);

            if (this.listIngresos.Count == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    this.listIngresos.Add(new clsDetEstResEval()
                    {
                        //idEEFF = EEFF.OtrosEgresos,
                        idMoneda = this.objEvalCred.idMoneda,
                        idMonedaMA = this.objEvalCred.idMoneda,
                        nTipoCambio = this.objEvalCred.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                        nOperacion = 1,
                        nOrden = i + 1
                    });
                }


                this.listIngresos[0].cDescripcion = "Actividad agrícola";
                this.listIngresos[0].idEEFF = EEFF.VentasNetas;
                this.listIngresos[0].nCodigo = DetalleEstRes.ActividadAgricola;
                this.listIngresos[1].cDescripcion = "Actividad pecuaria";
                this.listIngresos[1].idEEFF = EEFF.OtrosIngresos;
                this.listIngresos[1].nCodigo = DetalleEstRes.ActividadPecuario;
                this.listIngresos[2].cDescripcion = "Actividad comercial";
                this.listIngresos[2].idEEFF = EEFF.OtrosIngresos;
                this.listIngresos[2].nCodigo = DetalleEstRes.ActividadComercial;
                this.listIngresos[3].cDescripcion = "Otros Ingresos";
                this.listIngresos[3].idEEFF = EEFF.OtrosIngresos;
                this.listIngresos[3].nCodigo = DetalleEstRes.OtrosIngresos;
                this.listIngresos[4].cDescripcion = "Aporte propio";
                this.listIngresos[4].idEEFF = 9999;
                this.listIngresos[4].nCodigo = DetalleEstRes.AportePropio;
                this.listIngresos[5].cDescripcion = "Préstamos de CRACLASA";
                this.listIngresos[5].idEEFF = 9999;
                this.listIngresos[5].nCodigo = DetalleEstRes.PrestamoCracLasa;
                this.listIngresos[5].nPUnitario = this.nMontoProp;
            }

            if (this.listEgresos.Count == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    this.listEgresos.Add(new clsDetEstResEval()
                    {
                        //idEEFF = EEFF.OtrosEgresos,
                        idMoneda = this.objEvalCred.idMoneda,
                        idMonedaMA = this.objEvalCred.idMoneda,
                        nTipoCambio = this.objEvalCred.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                        nOperacion = 2,
                        nOrden = i + 1
                    });
                }

                this.listEgresos[0].cDescripcion = "Actividad agrícola";
                this.listEgresos[0].idEEFF = EEFF.CostoVentas;
                this.listEgresos[0].nCodigo = DetalleEstRes.ActividadAgricola;
                this.listEgresos[1].cDescripcion = "Actividad pecuarios";
                this.listEgresos[1].idEEFF = EEFF.OtrosEgresos;
                this.listEgresos[1].nCodigo = DetalleEstRes.ActividadPecuario;
                this.listEgresos[2].cDescripcion = "Actividad comerciales";
                this.listEgresos[2].idEEFF = EEFF.OtrosEgresos;
                this.listEgresos[2].nCodigo = DetalleEstRes.ActividadComercial;
                this.listEgresos[3].cDescripcion = "Otros Costos";
                this.listEgresos[3].idEEFF = EEFF.OtrosEgresos;
                this.listEgresos[3].nCodigo = DetalleEstRes.OtrosCostos;
                this.listEgresos[4].cDescripcion = "Pago crédito CRAC LASA";
                this.listEgresos[4].idEEFF = 9999;
                this.listEgresos[4].nCodigo = DetalleEstRes.PagoCreditoCracLasa; ;
                this.listEgresos[4].nPUnitario = this.nTotalMontoPagar;
                this.listEgresos[5].cDescripcion = "Pago otras deudas";
                this.listEgresos[5].idEEFF = EEFF.GastosFinancieros;
                this.listEgresos[5].nCodigo = DetalleEstRes.PagoOtrasDeudas;
                this.listEgresos[6].cDescripcion = "Gastos familiares";
                this.listEgresos[6].idEEFF = EEFF.GastosFamiliares;
                this.listEgresos[6].nCodigo = DetalleEstRes.GastosFamiliares;
            }

            this.dtgIngresos.DataSource = this.listIngresos;
            this.dtgEgresos.DataSource = this.listEgresos;

            AgregarColumnsDataGridView();
            FormatearColumnsDataGridView();

            this.dtgIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIngresos_EditingControlShowing);
            this.dtgIngresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgIngresos_DataError);
            this.dtgIngresos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellValueChanged);
            this.dtgIngresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresos_DataBindingComplete);
            this.dtgIngresos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIngresos_CellLeave);
            this.dtgEgresos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEgresos_EditingControlShowing);
            this.dtgEgresos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgEgresos_DataError);
            this.dtgEgresos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEgresos_CellValueChanged);
            this.dtgEgresos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEgresos_DataBindingComplete);
            this.dtgEgresos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEgresos_CellLeave);

            CalcularTotales();
            CalcularIndicadores();
        }

        public void ClearSelectionDataGridView()
        {
            this.dtgIngresos.ClearSelection();
            this.dtgEgresos.ClearSelection();
        }

        public string GetXML()
        {
            return DetalleEstResEnXML();
        }

        private string DetalleEstResEnXML()
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

            dt.Columns.Add("nOperacion", typeof(int));
            dt.Columns.Add("nOrden", typeof(int));
            dt.Columns.Add("nCodigo", typeof(int));

            foreach (var detEstRes in this.listIngresos)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
                //row["idEvalCred"] = detBalGen.idEvalCred;
                row["idEEFF"] = detEstRes.idEEFF;
                row["cDescripcion"] = detEstRes.cDescripcion;
                row["idDescripcion"] = detEstRes.idDescripcion;
                row["idMoneda"] = detEstRes.idMoneda;
                row["idUnidMedida"] = detEstRes.idUnidMedida;
                row["nCantidad"] = detEstRes.nCantidad;
                row["nPUnitario"] = detEstRes.nPUnitario;
                row["nTotal"] = detEstRes.nTotal;
                row["idMonedaMA"] = detEstRes.idMonedaMA;
                row["nTotalMA"] = detEstRes.nTotalMA;

                row["nFrecuencia"] = detEstRes.nFrecuencia;
                row["dMesVenta"] = detEstRes.dMesVenta;
                row["nMesVenta"] = detEstRes.nMesVenta;

                row["nOperacion"] = detEstRes.nOperacion;
                row["nOrden"] = detEstRes.nOrden;
                row["nCodigo"] = detEstRes.nCodigo;

                dt.Rows.Add(row);
            }

            foreach (var detEstRes in this.listEgresos)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
                //row["idEvalCred"] = detBalGen.idEvalCred;
                row["idEEFF"] = detEstRes.idEEFF;
                row["cDescripcion"] = detEstRes.cDescripcion;
                row["idDescripcion"] = detEstRes.idDescripcion;
                row["idMoneda"] = detEstRes.idMoneda;
                row["idUnidMedida"] = detEstRes.idUnidMedida;
                row["nCantidad"] = detEstRes.nCantidad;
                row["nPUnitario"] = detEstRes.nPUnitario;
                row["nTotal"] = detEstRes.nTotal;
                row["idMonedaMA"] = detEstRes.idMonedaMA;
                row["nTotalMA"] = detEstRes.nTotalMA;

                row["nFrecuencia"] = detEstRes.nFrecuencia;
                row["dMesVenta"] = detEstRes.dMesVenta;
                row["nMesVenta"] = detEstRes.nMesVenta;

                row["nOperacion"] = detEstRes.nOperacion;
                row["nOrden"] = detEstRes.nOrden;
                row["nCodigo"] = detEstRes.nCodigo;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
        }

        /*public void PuntajeEvalCualitativa(decimal nPuntajeEvalCualitativa)
        {
            conIndicadores.PuntajeEvalCualitativa(nPuntajeEvalCualitativa);
        }*/

        /// <summary>
        /// actualiza los indicadores financieros conforme a los parámestros establecidos
        /// </summary>
        /*public void ActualizarIndicadores()
        {
            conIndicadores.Actualizar();
        }*/

        public void ActualizarPorIndicadores(List<clsIndicadorEval> _listIndiFinanc)
        {
            //this.conIndicadores.ActualizarPorIndicadores(_listIndiFinanc);
            this.listIndiFinanc = _listIndiFinanc;
        }

        /*public void ActualizarPorEstadosFinancieros(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsDetBalGenEval> _listInventario,
            decimal _nTotalPasivoAC, decimal _nCapitalParaComercio)
        {
            this.conIndicadores.ActualizarPorEstadosFinancieros(_listBalGenEval, _listEstResEval, _listInventario, _nTotalPasivoAC, _nCapitalParaComercio);
        }*/

        /*public void ActualizarPorSectorEconomico(int _nCodigoSectorEconomico)
        {
            this.conIndicadores.ActualizarPorSectorEconomico(_nCodigoSectorEconomico);
        }*/

        /*public void ActualizarPorDestinoCapitalTrabajo(decimal nDestinoCapitalTrabajo)
        {
            this.conIndicadores.ActualizarPorDestinoCapitalTrabajo(nDestinoCapitalTrabajo);
        }*/

        /*public void ActualizarPuntajeEvalCualitativa(decimal _nPtjeEvalCualitativa)
        {
            this.conIndicadores.ActualizarPuntajeEvalCualitativa(_nPtjeEvalCualitativa);
        }*/

        public void ActualizarPorIndPorMPropPorMAprox(List<clsIndicadorEval> _listIndiFinanc, decimal _nMontoProp, decimal _nCuotaAprox, decimal nTotalMontoPagar)
        {
            //this.conIndicadores.ActualizarPorIndPorMPropPorMAprox(_listIndiFinanc, _nMontoProp, _nCuotaAprox);

            this.listIndiFinanc = _listIndiFinanc;

            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;
            this.nTotalMontoPagar = nTotalMontoPagar;

            if (this.listIngresos != null && this.listEgresos != null)
            {
                this.dtgIngresos.CellValueChanged -= dtgIngresos_CellValueChanged;
                clsDetEstResEval objPrestamo = this.listIngresos.Find(x => x.nOperacion == 1 && x.nCodigo == DetalleEstRes.PrestamoCracLasa);
                if (objPrestamo != null) objPrestamo.nPUnitario = this.nMontoProp;
                this.dtgIngresos.CellValueChanged += dtgIngresos_CellValueChanged;

                this.dtgEgresos.CellValueChanged -= dtgEgresos_CellValueChanged;
                clsDetEstResEval objPagoCredito = this.listEgresos.Find(x => x.nOperacion == 2 && x.nCodigo == DetalleEstRes.PagoCreditoCracLasa);
                if (objPagoCredito != null) objPagoCredito.nPUnitario = nTotalMontoPagar;
                this.dtgEgresos.CellValueChanged += dtgEgresos_CellValueChanged;
            }

            this.CalcularIndicadores();
            //this.bindingIndiFinanc.ResetBindings(false);

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

        /*public List<clsEstResEval> ListEstadoResultados
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
        }*/

        private void CalcularTotales()
        {
            decimal nTotalIngresos = 0;
            decimal nTotalEgresos = 0;

            decimal nSaldoAcumuladoInicial = 0;
            decimal nDisponibleInicial = 0;
            decimal nSaldoAcumuladoFinal = 0;

            nTotalIngresos = this.listIngresos.Sum(x => x.nTotalMA);
            nTotalEgresos = this.listEgresos.Sum(x => x.nTotalMA);

            nSaldoAcumuladoInicial = nTotalIngresos - nTotalEgresos;
            nDisponibleInicial = String.IsNullOrWhiteSpace(this.txtDisponibleInicial.Text) ? 0 : Convert.ToDecimal(this.txtDisponibleInicial.Text);
            nSaldoAcumuladoFinal = nSaldoAcumuladoInicial + nDisponibleInicial;

            this.txtTotalIngresos.Text = nTotalIngresos.ToString("N2");
            this.txtTotalEgresos.Text = nTotalEgresos.ToString("N2");
            this.txtSaldoAcumuladoInicial.Text = nSaldoAcumuladoInicial.ToString("n2");
            this.txtSaldoAcumuladoFinal.Text = nSaldoAcumuladoFinal.ToString("n2");

            this.objEvalCred.nSaldoAcumuladoInicial = nSaldoAcumuladoInicial;
            this.objEvalCred.nDisponibleInicial = nDisponibleInicial;
            this.objEvalCred.nSaldoAcumuladoFinal = nSaldoAcumuladoFinal;
        }

        public clsMsjError validaIndiFinanc()
        {
            List<clsIndicadorEval> listIndFinanc = (List<clsIndicadorEval>)dtgIndiFinanc.DataSource;
            clsMsjError objError = new clsMsjError();
            foreach (clsIndicadorEval item in listIndFinanc)
            {
                decimal nValorMinimo = item.nValorMinimo;
                decimal nValorMaximo = item.nValorMaximo;
                decimal nRatio = item.nRatio;

                nRatio = (item.nTipoVariable == 2) ? nRatio * 100 : nRatio;
                nRatio = Math.Round(nRatio, 2);
                if (this.lValidacionEnabled)
                {
                    if (!(nRatio >= nValorMinimo && nRatio <= nValorMaximo) && !(nValorMinimo ==0 && nValorMaximo==0))
                    {
                        switch (item.nCodigo) 
                        {
                            /*case 3://Endeudamiento Patrimonial
                            case 10://Endeudamiento Patrimonial
                                if (!this.idOperacion.In(2, 6))
                                {
                                    objError.AddError("Estados Financ.: " + item.cDescripcion + " mayor al 100%");
                                }
                                break;
                            case 13:
                                if (!this.idOperacion.In(2, 6))
                                {
                                    objError.AddError("Estados Financ.: " + item.cDescripcion + " mayor al 80%");
                                }
                                break;*/
                        }
                    }
                }
            }
            return objError;
        }

        public void setTotalIngresos(decimal total)
        {
            //this.listIngresos[0].nPUnitario = total;
            this.dtgIngresos.Rows[0].Cells["nPUnitario"].Value = total;
            this.CalcularTotales();
            this.CalcularIndicadores();
        }

        public void setTotalEgresos(decimal total)
        {
            //this.listEgresos[0].nPUnitario = total;
            this.dtgEgresos.Rows[0].Cells["nPUnitario"].Value = total;
            CalcularTotales();
            CalcularIndicadores();
        }

        public void agregarDeudaIndirecAEgresos(decimal nMonto)
        {
            this.dtgEgresos.Rows[5].Cells["nPUnitario"].Value = nMonto;
            CalcularTotales();
            CalcularIndicadores();
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

                    row.Cells["nTotalUltEvMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    /*if (UltEvaluacionChecked) // Habilitado para edición
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                    }
                    else
                    {
                        row.Cells["nTotalUltEvMA"].Style.BackColor = System.Drawing.Color.White;
                    }*/
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

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            /*if (!EsFechaValido())
                objMsjError.AddError("Ingrese una fecha válida.");*/

            return objMsjError;
        }

        /*private void HabilitarUltEvaluacion(bool lHabilitado)
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
        }*/

        private void AgregarColumnsDataGridView()
        {
            GEN.CapaNegocio.clsCNMoneda ListadoMoneda = new GEN.CapaNegocio.clsCNMoneda();
            DataTable dtMoneda = ListadoMoneda.listarMoneda();

            DataGridViewComboBoxColumn dgcboTipoMoneda1 = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda1.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda1.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda1.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda1.DataPropertyName = "idMoneda";
            dgcboTipoMoneda1.DataSource = dtMoneda;
            dgcboTipoMoneda1.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda1.ValueMember = dtMoneda.Columns["idMoneda"].ToString();

            DataGridViewComboBoxColumn dgcboTipoMoneda2 = dgcboTipoMoneda1.Clone() as DataGridViewComboBoxColumn;

            this.dtgIngresos.Columns.Add(dgcboTipoMoneda1);
            this.dtgEgresos.Columns.Add(dgcboTipoMoneda2);
        }

        private void FormatearColumnsDataGridView()
        {
            // --DataGridView Ingresos
            foreach (DataGridViewColumn column in this.dtgIngresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgIngresos.Columns["cDescripcion"].DisplayIndex = 0;
            dtgIngresos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgIngresos.Columns["nPUnitario"].DisplayIndex = 2;

            dtgIngresos.Columns["cDescripcion"].Visible = true;
            dtgIngresos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgIngresos.Columns["nPUnitario"].Visible = true;

            dtgIngresos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgIngresos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgIngresos.Columns["nPUnitario"].HeaderText = "Total";

            dtgIngresos.Columns["cDescripcion"].FillWeight = 112;
            dtgIngresos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgIngresos.Columns["nPUnitario"].FillWeight = 50;

            dtgIngresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIngresos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgIngresos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgIngresos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            //dtgIngresos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgIngresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgIngresos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgIngresos.Columns["dgcboTipoMoneda"].ReadOnly = true;
            dtgIngresos.Columns["cDescripcion"].ReadOnly = true;
            dtgIngresos.Columns["nPUnitario"].ReadOnly = true;


            // --DataGridView Egresos
            foreach (DataGridViewColumn column in this.dtgEgresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEgresos.Columns["cDescripcion"].DisplayIndex = 0;
            dtgEgresos.Columns["dgcboTipoMoneda"].DisplayIndex = 1;
            dtgEgresos.Columns["nPUnitario"].DisplayIndex = 2;

            dtgEgresos.Columns["cDescripcion"].Visible = true;
            dtgEgresos.Columns["dgcboTipoMoneda"].Visible = true;
            dtgEgresos.Columns["nPUnitario"].Visible = true;

            dtgEgresos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgEgresos.Columns["dgcboTipoMoneda"].HeaderText = "Mon";
            dtgEgresos.Columns["nPUnitario"].HeaderText = "Total";

            dtgEgresos.Columns["cDescripcion"].FillWeight = 112;
            dtgEgresos.Columns["dgcboTipoMoneda"].FillWeight = 23;
            dtgEgresos.Columns["nPUnitario"].FillWeight = 50;

            dtgEgresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEgresos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgEgresos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgEgresos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            //dtgEgresos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            //dtgEgresos.Columns["dgcboTipoMoneda"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgEgresos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;

            dtgEgresos.Columns["dgcboTipoMoneda"].ReadOnly = true;
            dtgEgresos.Columns["cDescripcion"].ReadOnly = true;
            dtgEgresos.Columns["nPUnitario"].ReadOnly = true;
            
        }

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

        private void AgregarComboBoxColumnsDataGridView()
        {
            DataGridViewImageColumn imgValidacion = new DataGridViewImageColumn();
            imgValidacion.Name = "imgValidacion";
            imgValidacion.DataPropertyName = "imgValidacion";
            this.dtgIndiFinanc.Columns.Add(imgValidacion);
        }

        private void DataError(DataGridView dtg, DataGridViewDataErrorEventArgs e)
        {
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

        private void CalcularIndicadores()
        {
            if (this.listBalGenEval == null || this.listIndiFinanc == null) return;
            if (this.listIngresos == null || this.listEgresos == null) return;

            decimal nCapitalTrabajo = 0,
                    nEndeudamientoPatrimonial = 0,
                    nEndeudamientoPatrimonialProy = 0,
                    nDependenciaOtrosIngresos = 0,
                    nCuotaMaximaPropuesta = 0,
                    nCoberturaDeCuota = 0,
                    nPorcentajeFinanciamiento = 0,
                    nSaldoAcumuladoFinal;

            decimal nActivos = 0m,
                    nAcCorriente = 0m,
                    nAcNoCorriente = 0m,
                    nPasivos = 0m,
                    nPaCorriente = 0m,
                    nPaNoCorriente = 0m,
                    nPatrimonio = 0m,
                    nInventario = 0m,
                    nInmuebles = decimal.Zero,
                    nEndeudamientoSinInmueble = decimal.Zero,
                    nUtilidadOperativa = decimal.Zero,
                    nGastosFinancieros = decimal.Zero,
                    nCapacidadPago = decimal.Zero,
                    nUtilidadNeta = decimal.Zero,
                    nRentabilidadInver = decimal.Zero;

            decimal nActAgricolaIn,
                a2,
                nActPecuariaIn,
                nActComercialIn,
                nOtrosIngresos,
                nAportePropio,
                nPrestamoCracLasa;

            decimal nActAricolaEg,
                b2,
                nActPecuariaEg,
                nActComercialEg,
                nOtrosCostos,
                nPagoCreditoCracLasa,
                nPagoOtrasDeudas,
                nGastosFamiliares;

            //---------------- Balance General
            nAcCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalMA);
            nAcNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalMA);
            nActivos = nAcCorriente + nAcNoCorriente;

            nPaCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalMA);
            nPaNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalMA);
            nPasivos = nPaCorriente + nPaNoCorriente;

            nPatrimonio = nActivos - nPasivos;
            nInventario = listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);

            nInmuebles = listBalGenEval.Where(x => x.idEEFF == EEFF.Inmuebles).Sum(x => x.nTotalMA);

            //---------------- Flujo de caja
            nSaldoAcumuladoFinal = String.IsNullOrWhiteSpace(this.txtSaldoAcumuladoFinal.Text) ? 0 : Convert.ToDecimal(this.txtSaldoAcumuladoFinal.Text);

            nActAgricolaIn = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.ActividadAgricola && x.nOperacion == 1).Sum(x => x.nTotalMA);
            //a2 = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.ActividadAgricolaSecu && x.nOperacion == 1).Sum(x => x.nTotalMA);
            nActPecuariaIn = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.ActividadPecuario && x.nOperacion == 1).Sum(x => x.nTotalMA);
            nActComercialIn = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.ActividadComercial && x.nOperacion == 1).Sum(x => x.nTotalMA);
            nOtrosIngresos = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.OtrosIngresos && x.nOperacion == 1).Sum(x => x.nTotalMA);
            nAportePropio = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.AportePropio && x.nOperacion == 1).Sum(x => x.nTotalMA);
            nPrestamoCracLasa = this.listIngresos.Where(x => x.nCodigo == DetalleEstRes.PrestamoCracLasa && x.nOperacion == 1).Sum(x => x.nTotalMA);

            nActAricolaEg = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.ActividadAgricola && x.nOperacion == 2).Sum(x => x.nTotalMA);
            //b1 = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.ActividadAgricolaPrin && x.nOperacion == 2).Sum(x => x.nTotalMA);
            //b2 = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.ActividadAgricolaSecu && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nActPecuariaEg = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.ActividadPecuario && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nActComercialEg = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.ActividadComercial && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nOtrosCostos = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.OtrosCostos && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nPagoCreditoCracLasa = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.PagoCreditoCracLasa && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nPagoOtrasDeudas = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.PagoOtrasDeudas && x.nOperacion == 2).Sum(x => x.nTotalMA);
            nGastosFamiliares = this.listEgresos.Where(x => x.nCodigo == DetalleEstRes.GastosFamiliares && x.nOperacion == 2).Sum(x => x.nTotalMA);

            nGastosFinancieros = nPagoOtrasDeudas;
            nUtilidadOperativa = nActAgricolaIn - nActAricolaEg;
            nUtilidadNeta = nUtilidadOperativa - nGastosFinancieros;

            decimal nNumeradorCP = nPagoCreditoCracLasa + nPagoOtrasDeudas;
            decimal nDenominadorCP = (nActAgricolaIn + nActPecuariaIn + nActComercialIn + nOtrosIngresos + nAportePropio + nPrestamoCracLasa) -
                (nActAricolaEg + nActPecuariaEg + nActComercialEg + nOtrosCostos + nGastosFamiliares);
 

            //---------------- IFinancieros
            nCapitalTrabajo = nAcCorriente - nPaCorriente;
            nEndeudamientoPatrimonial = clsNumerico.Dividir(nPasivos, nPatrimonio);
            nEndeudamientoPatrimonialProy = clsNumerico.Dividir(nPasivos + nPrestamoCracLasa, nPatrimonio);
            //nDependenciaOtrosIngresos = clsNumerico.Dividir(((a2 + a3 + a4 + a5) - (b2 + b3 + b4 + b5)), b6);
            nDependenciaOtrosIngresos = clsNumerico.Dividir(((nActPecuariaIn + nActComercialIn + nOtrosIngresos) - (nActPecuariaEg + nActComercialEg + nOtrosCostos)), nPagoCreditoCracLasa);
            nCuotaMaximaPropuesta = (nPagoCreditoCracLasa + nSaldoAcumuladoFinal) * 0.8m;
            nCoberturaDeCuota = clsNumerico.Dividir(nPagoCreditoCracLasa, (nPagoCreditoCracLasa + nSaldoAcumuladoFinal));
            nPorcentajeFinanciamiento = clsNumerico.Dividir(nPrestamoCracLasa, nActAricolaEg); ;

            nEndeudamientoSinInmueble = clsNumerico.Dividir((nPasivos + this.nMontoProp - this.nTotalPasivoAC), (nPatrimonio - nInmuebles));
            nCapacidadPago = clsNumerico.Dividir(nNumeradorCP, nDenominadorCP);
            nRentabilidadInver = clsNumerico.Dividir(nUtilidadNeta, nActivos);

            //---------------- Actualizar
            foreach (clsIndicadorEval item in listIndiFinanc)
            {
                if (item.nCodigo == IFN.CapitalTrabajo)
                {
                    item.nRatio = nCapitalTrabajo;
                }
                else if (item.nCodigo == IFN.EndeudamientoPatrimonial)
                {
                    item.nRatio = nEndeudamientoPatrimonial;
                }
                else if (item.nCodigo == IFN.EndeudamientoPatrimonialProy)
                {
                    item.nRatio = nEndeudamientoPatrimonialProy;
                }
                else if (item.nCodigo == IFN.DependenciaOtrosIngresos)
                {
                    item.nRatio = nDependenciaOtrosIngresos;
                }
                else if (item.nCodigo == IFN.CuotaMaximaPropuesta)
                {
                    item.nRatio = nCuotaMaximaPropuesta;
                }
                else if (item.nCodigo == IFN.CoberturaDeCuota)
                {
                    item.nRatio = nCoberturaDeCuota;
                }
                else if (item.nCodigo == IFN.PorcentajeFinanciamiento)
                {
                    item.nRatio = nPorcentajeFinanciamiento;
                }
                else if (item.nCodigo == IFN.EndeudamientoSinInmueble)
                {
                    item.nRatio = nEndeudamientoSinInmueble;
                }
                else if (item.nCodigo == IFN.CapacidadPago)
                {
                    item.nRatio = nCapacidadPago;
                }
                else if (item.nCodigo == IFN.RentabilidadInver)
                {
                    item.nRatio = nRentabilidadInver;
                }
            }

            this.dtgIndiFinanc.Refresh();
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

                for (int i = 0; i < vFragmentos.Length; i++)
                {
                    string cCadena = vFragmentos[i].Trim();

                    if (int.TryParse(cCadena, out idEEFF))
                    {
                        decimal nValor = this.buscarValorEEFF(objAlerta.idClaseAnalisis, objAlerta.idTipoAnalisis, idEEFF, objAlerta.idFuncionDinamica);
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
            drFila["cValor"] = this.nMontoProp.ToString();
            dtReemplazos.Rows.Add(drFila);

        }

        public decimal buscarValorEEFF(int idClaseAnalisis, int idTipoAnalisis, int idEEFF, int idFuncionDinamica)
        {

            if (idEEFF == 9999) return this.nCuotaAprox;
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
            else if (idEEFF == 7777) return this.nMontoProp;
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

        #region Eventos
        #region Balance General
        private void dtgBalGenEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridViewBBGG();
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalcularBBGG();
            CalcularIndicadores();
            this.dtgBalGenEval.Refresh(); //ok

            /*if (CellValueChangedEstadosFinancieros != null)
                CellValueChangedEstadosFinancieros(sender, e);
             * */
        }

        private void dtgBalGenEval_Leave(object sender, EventArgs e)
        {
            this.dtgBalGenEval.ClearSelection();
        }

        private void dtgBalGenEval_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataError(sender as DataGridView, e);
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

        #region DGV Ingresos y Egresos
        private void dtgIngresos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotales();
            CalcularIndicadores();
            //this.dtgIngresos.Refresh();
        }

        private void dtgIngresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            // --
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void dtgIngresos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataError(sender as DataGridView, e);
        }

        private void dtgIngresos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgIngresos.ClearSelection();
        }

        private void dtgIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dtgIngresos.ClearSelection();
        }

        private void dtgEgresos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotales();
            CalcularIndicadores();
            //this.dtgEgresos.Refresh();
        }

        private void dtgEgresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            // --
            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPUnitario"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void dtgEgresos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataError(sender as DataGridView, e);
        }

        private void dtgEgresos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgEgresos.ClearSelection();
        }

        private void dtgEgresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dtgEgresos.ClearSelection();
        }
        #endregion

        #region Eventos

        private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescripcion"];
            cell.ToolTipText = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescFormula"].Value.ToString();

            if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("imgValidacion"))
            {

                decimal nValorMinimo = this.listIndiFinanc[e.RowIndex].nValorMinimo;
                decimal nValorMaximo = this.listIndiFinanc[e.RowIndex].nValorMaximo;
                decimal nRatio = this.listIndiFinanc[e.RowIndex].nRatio;

                nRatio = (this.listIndiFinanc[e.RowIndex].nTipoVariable == 2) ? nRatio * 100 : nRatio;
                nRatio = Math.Round(nRatio, 2);

                if (this.lValidacionEnabled)
                {
                    if (nValorMinimo == 0m && nValorMaximo == 0m)
                    {
                        e.Value = imageList.Images[2];
                    }
                    else if (nRatio >= nValorMinimo && nRatio <= nValorMaximo)
                    {
                        // Valido
                        e.Value = imageList.Images[1];
                    }
                    else
                    {
                        // No válido
                        e.Value = imageList.Images[0];
                    }
                }
                else
                {
                    e.Value = imageList.Images[2];
                    e.CellStyle.SelectionBackColor = Color.White;
                }
            }

            if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("cDescRegla"))
            {
                if (!this.lDescripcionReglaEnabled)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.White;
                }

            }
        }

        private void dtgIndiFinanc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridView();
            this.dtgIndiFinanc.ClearSelection();
        }

        private void StyleCellDataGridView()
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

        #region Eventos Estados Financieros




        //private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    int nCodigo = 0, nTipoVariable = 0;
        //    foreach (DataGridViewRow row in this.dtgIndiFinanc.Rows)
        //    {
        //        nCodigo = Convert.ToInt32(row.Cells["nCodigo"].Value);
        //        nTipoVariable = Convert.ToInt32(row.Cells["nTipoVariable"].Value);

        //        if (nTipoVariable == 1) row.DefaultCellStyle.Format = "N2";
        //        else if (nTipoVariable == 2) row.DefaultCellStyle.Format = "P2";
        //    }

        //    if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("cDescRegla"))
        //    {
        //        /*if (!this.lDescripcionReglaEnabled)
        //        {
        //            e.CellStyle.ForeColor = Color.White;
        //            e.CellStyle.SelectionBackColor = Color.White;
        //        }*/

        //    }
        //}

        //private void dtgIndiFinanc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    this.dtgIndiFinanc.ClearSelection();
        //}

        private void dtgIndiFinanc_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgIndiFinanc.ClearSelection();
        }
        #endregion

        #region Botones
        private void txtDisponibleInicial_Leave(object sender, EventArgs e)
        {
            CalcularTotales();
            CalcularIndicadores();
            this.dtgIndiFinanc.Refresh();
        }

        /*private void dtUltimaEval_KeyDown(object sender, KeyEventArgs e)
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
        */

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            if (DeudasClick != null)
                DeudasClick(sender, e);
        }

        private void btnEvalHorizontal_Click(object sender, EventArgs e)
        {
            if (EHZTLClick != null)
                EHZTLClick(sender, e);
        }
        #endregion

        private void lblBaseCustom5_Click(object sender, EventArgs e)
        {

        }

        private void btnActividadAgricola_Click(object sender, EventArgs e)
        {
            if (ActividadAgricolaClick != null)
                ActividadAgricolaClick(sender, e);
        }
        #endregion        


        private void dtgIngresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgEgresos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgIngresos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            
            if (e.RowIndex.In(0,5))
            {
                this.dtgIngresos.Rows[e.RowIndex].Cells["nPUnitario"].ReadOnly = true;
                this.dtgIngresos.Rows[e.RowIndex].Cells["nPUnitario"].Style.BackColor = System.Drawing.Color.White;
            }
            else
            {
                this.dtgIngresos.Rows[e.RowIndex].Cells["nPUnitario"].ReadOnly = false;
                this.dtgIngresos.Rows[e.RowIndex].Cells["nPUnitario"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
            }
        }

        private void dtgEgresos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.RowIndex.In(0,4))
            {
                this.dtgEgresos.Rows[e.RowIndex].Cells["nPUnitario"].ReadOnly = true;
                this.dtgEgresos.Rows[e.RowIndex].Cells["nPUnitario"].Style.BackColor = System.Drawing.Color.White;
            }
            else
            {
                this.dtgEgresos.Rows[e.RowIndex].Cells["nPUnitario"].ReadOnly = false;
                this.dtgEgresos.Rows[e.RowIndex].Cells["nPUnitario"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
            }
        }
    }
}
