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
using GEN.Funciones;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;

#endregion

namespace CRE.Presentacion
{
    public partial class frmDetalleEstResFacilito : frmBase
    {
        #region
        private List<clsDetEstResEval> listGFamiliares;
        private List<clsDetEstResEval> listGOperativos;

        private List<clsDescripcionEval> listDescGastosOperativos;
        private List<clsDescripcionEval> listDescGastosFamiliares;

        private DataTable dtMoneda;
        private DateTime dFechaBase;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;

        private ComboBox cmbItem;
        private ComboBox cmbCategory;

        private int indexCategory = -1;
        private int indexItem = -1;
        private int idEvalCred = -1;
        private int idSolicitud = 0;

        private bool lPeriodoGOperaEnabled;
        private clsEvalCred objEvalCred;
        private string cTipEvaluacion;
        private int idTipEvalCred;

        public bool lGuardado = false;

        public decimal nMontoCMensualNormal = 0;
        public decimal nMontoCMensualPromedio = 0;

        public List<clsEvalSimpCicloDiario> lstEvalSimpCDiario { get; set; }
        public List<clsEvalSimpCicloMensual> lstEvalSimpCMensual { get; set; }
        public List<clsEvalSimpCicloMensualDetalle> lstEvalSimpCDetalleMensual { get; set; }
        private List<clsTipoCicloMensual> lstTipoCicloMensual { get; set; }

        #endregion

        #region Constructores
        public frmDetalleEstResFacilito()
        {
            InitializeComponent();

            FormatearDataGridView();

            this.idEvalCred = 0;
            this.nTipoCambio = 1;
            this.idMonedaMA = 1;
            this.cMonedaSimbolo = "S/.";
            this.lPeriodoGOperaEnabled = false;

            this.lstEvalSimpCDiario = new List<clsEvalSimpCicloDiario>();
            this.lstEvalSimpCMensual = new List<clsEvalSimpCicloMensual>();
            this.lstEvalSimpCDetalleMensual = new List<clsEvalSimpCicloMensualDetalle>();
            this.lstTipoCicloMensual = new List<clsTipoCicloMensual>();
        }

        public frmDetalleEstResFacilito(List<clsDescripcionEval> _listDescripcionEval, int _idEvalCred, decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, string _cTipEvaluacion, int _idTipEvalCred, clsEvalCred _objEvalCred)
        {
            InitializeComponent();

            FormatearDataGridView();

            this.idEvalCred = 0;
            this.nTipoCambio = 1;
            this.idMonedaMA = 1;
            this.cMonedaSimbolo = "S/.";
            this.lPeriodoGOperaEnabled = false;


            this.listGFamiliares = new List<clsDetEstResEval>();
            this.listGOperativos = new List<clsDetEstResEval>();

            this.lstEvalSimpCDiario = new List<clsEvalSimpCicloDiario>();
            this.lstEvalSimpCMensual = new List<clsEvalSimpCicloMensual>();
            this.lstEvalSimpCDetalleMensual = new List<clsEvalSimpCicloMensualDetalle>();
            this.lstTipoCicloMensual = new List<clsTipoCicloMensual>();

            this.idEvalCred = _idEvalCred;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idTipEvalCred = _idTipEvalCred;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;

            this.grbIngresoGastos.Enabled = false;
            this.btnCancelar.Enabled = false;

            AsignarDataTables(Evaluacion.DataTableMoneda, _listDescripcionEval);

            this.cTipEvaluacion = _cTipEvaluacion;
            this.objEvalCred = _objEvalCred;
        }

        #endregion

        #region Métodos Públicos
        public void AsignarDataTables(DataTable _dtMoneda, List<clsDescripcionEval> _listDescGastos)
        {
            this.dtMoneda = _dtMoneda;

            this.listDescGastosOperativos = (from p in _listDescGastos
                                             where p.idTipoDescripcion == TipoDescripcion.GastosOperativos
                                             select p).ToList();

            this.listDescGastosFamiliares = (from p in _listDescGastos
                                             where p.idTipoDescripcion == TipoDescripcion.GastosFamiliares
                                             select p).ToList();


            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);

        }

        public void AsignarDatos(List<clsDetEstResEval> _listGFamiliares, List<clsDetEstResEval> _listGOperativos, List<clsEvalSimpCicloDiario> _listEvalSimpCDiario, List<clsEvalSimpCicloMensual> _listEvalSimpCMensual, List<clsTipoCicloMensual> _listTipoCMensual, List<clsEvalSimpCicloMensualDetalle> _lstEvalSimpCDetalleMensual,
            decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, int _idEvalCred)
        {

            #region Eventos -
            this.dtgGFamiliares.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);

            this.dtgGOperativos.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGOperativos_EditingControlShowing);
            this.dtgGOperativos.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGOperativos_DataError);
            this.dtgGOperativos.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGOperativos_CellLeave);

            this.dtgCicloVentaDiario.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCicloVentaDiario_DataBindingComplete);
            this.dtgCicloVentaDiario.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentaDiario_EditingControlShowing);
            this.dtgCicloVentaDiario.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentaDiario_DataError);
            this.dtgCicloVentaDiario.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(dtgCicloVentaDiario_CellValueChanged);

            this.dtgCicloVentasMensual.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCicloVentasMensual_DataBindingComplete);
            this.dtgCicloVentasMensual.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentasMensual_EditingControlShowing);
            this.dtgCicloVentasMensual.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentasMensual_DataError);
            this.dtgCicloVentasMensual.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCicloVentasMensual_CellValueChanged);

            this.dtgTipVentaMensual.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgTipVentaMensual_DataBindingComplete);
            this.dtgTipVentaMensual.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgTipVentaMensual_EditingControlShowing);
            this.dtgTipVentaMensual.DataError -= new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgTipVentaMensual_DataError);


            #endregion

            this.listGFamiliares = _listGFamiliares;
            this.listGOperativos = _listGOperativos;

            this.lstEvalSimpCDiario = _listEvalSimpCDiario;
            this.lstEvalSimpCMensual = _listEvalSimpCMensual;

            this.lstEvalSimpCDetalleMensual = _lstEvalSimpCDetalleMensual;

            this.lstTipoCicloMensual = _listTipoCMensual;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idEvalCred = _idEvalCred;

            PlantillaDefault();

            #region Asignación de datos
            this.bindingGFamiliares.DataSource = this.listGFamiliares;
            this.dtgGFamiliares.DataSource = this.bindingGFamiliares;
            AgregarComboBoxColumnsDataGridViewGFamiliares();
            FormatearColumnasDataGridViewGFamiliares();

            this.bindingGOperativos.DataSource = this.listGOperativos;
            this.dtgGOperativos.DataSource = this.bindingGOperativos;
            AgregarComboBoxColumnsDataGridViewGOperativos();
            FormatearColumnasDataGridViewGOperativos();

            this.bindingCVentaDiario.DataSource = this.lstEvalSimpCDiario;
            this.dtgCicloVentaDiario.DataSource = this.bindingCVentaDiario;
            AgregarCheckBoxColumnsDataGridViewCVentasDiario();
            FormatearColumnasDataGridViewCVentaDiario();

            this.bindingCicloVentasMensual.DataSource = this.lstEvalSimpCDetalleMensual;
            this.dtgCicloVentasMensual.DataSource = this.bindingCicloVentasMensual;
            AgregarComboBoxColumnsDataGridViewCVentasMensual();
            FormatearColumnasDataGridViewCVentaMensual();

            this.bindingTVentaMensual.DataSource = this.lstTipoCicloMensual;
            this.dtgTipVentaMensual.DataSource = this.bindingTVentaMensual;
            FormatearColumnasDataGridViewTipoCicloMensual();



            this.labelTotaldtgGFamiliares.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgGOperativos.Text = "Total " + this.cMonedaSimbolo;
            this.labelTotaldtgCVentaDiario.Text = "Total " + this.cMonedaSimbolo;
            #endregion

            #region Eventos +
            this.dtgGFamiliares.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGFamiliares_DataBindingComplete);
            this.dtgGFamiliares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGFamiliares_EditingControlShowing);
            this.dtgGFamiliares.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGFamiliares_DataError);

            this.dtgGOperativos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgGOperativos_DataBindingComplete);
            this.dtgGOperativos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGOperativos_EditingControlShowing);
            this.dtgGOperativos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgGOperativos_DataError);
            this.dtgGOperativos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGOperativos_CellLeave);

            this.dtgCicloVentaDiario.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCicloVentaDiario_DataBindingComplete);
            this.dtgCicloVentaDiario.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentaDiario_EditingControlShowing);
            this.dtgCicloVentaDiario.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentaDiario_DataError);
            this.dtgCicloVentaDiario.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dtgCicloVentaDiario_CellValueChanged);

            this.dtgCicloVentasMensual.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCicloVentasMensual_DataBindingComplete);
            this.dtgCicloVentasMensual.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCicloVentasMensual_EditingControlShowing);
            this.dtgCicloVentasMensual.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgCicloVentasMensual_DataError);
            this.dtgCicloVentasMensual.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCicloVentasMensual_CellValueChanged);

            this.dtgTipVentaMensual.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgTipVentaMensual_DataBindingComplete);
            this.dtgTipVentaMensual.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgTipVentaMensual_EditingControlShowing);
            this.dtgTipVentaMensual.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgTipVentaMensual_DataError);

            #endregion

            if (this.listGFamiliares.Count > 0) this.tsmQuitarGFam.Enabled = true;
            if (this.listGOperativos.Count > 0) this.tsmQuitarGOpe.Enabled = true;

            dtgGFamiliares_DataBindingComplete(null, null);
            dtgGOperativos_DataBindingComplete(null, null);
            dtgCicloVentaDiario_DataBindingComplete(null, null);
            dtgCicloVentasMensual_DataBindingComplete(null, null);
            dtgTipVentaMensual_DataBindingComplete(null, null);

        }

        public void LimpiarSelecciones()
        {
            this.dtgGFamiliares.CurrentCell = null;
            this.dtgGFamiliares.ClearSelection();

            this.dtgGOperativos.CurrentCell = null;
            this.dtgGOperativos.ClearSelection();

            this.dtgCicloVentaDiario.CurrentCell = null;
            this.dtgCicloVentaDiario.ClearSelection();

            this.dtgTipVentaMensual.CurrentCell = null;
            this.dtgTipVentaMensual.ClearSelection();

            this.dtgCicloVentasMensual.CurrentCell = null;
            this.dtgCicloVentasMensual.ClearSelection();

        }


        public List<clsDetEstResEval> GFamiliares()
        {
            return this.listGFamiliares;
        }

        public List<clsDetEstResEval> GOperativos()
        {
            return this.listGOperativos;
        }

        public List<clsEvalSimpCicloDiario> EvalCVentaDiario()
        {
            return this.lstEvalSimpCDiario;
        }
        public List<clsEvalSimpCicloMensual> EvalCVentaMensual()
        {
            return this.lstEvalSimpCMensual;
        }
        public decimal EvalCVentaNormal()
        {
            return this.lstEvalSimpCDiario.Sum(item => item.nMontoTotal) * 4;
        }
        public List<clsTipoCicloMensual> TCicloMensual()
        {
            return this.lstTipoCicloMensual;
        }

        #endregion

        #region Métodos Privados
        private void PlantillaDefault()
        {

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
                        idEEFF = EEFF.GastosNegocio,
                        idMonedaMA = this.idMonedaMA,
                        nTipoCambio = this.nTipoCambio,
                        nCantidad = 1,

                        nFrecuencia = 1,
                        dFechaInicio = this.dFechaBase,
                    });
                }
            }

            if (this.lstEvalSimpCDiario.Count == 0)
            {
                clsEvalSimpCicloDiario objCDiarioAlto = new clsEvalSimpCicloDiario();
                objCDiarioAlto.idEvalCred = idEvalCred;
                objCDiarioAlto.idTipoCicloDiario = 1;
                objCDiarioAlto.cTipoCicloDiario = "VENTAS ALTAS";
                clsEvalSimpCicloDiario objCDiarioNormal = new clsEvalSimpCicloDiario();
                objCDiarioNormal.idEvalCred = idEvalCred;
                objCDiarioNormal.idTipoCicloDiario = 2;
                objCDiarioNormal.cTipoCicloDiario = "VENTAS NORMALES";

                clsEvalSimpCicloDiario objCDiarioBajo = new clsEvalSimpCicloDiario();
                objCDiarioBajo.idEvalCred = idEvalCred;
                objCDiarioBajo.idTipoCicloDiario = 3;
                objCDiarioBajo.cTipoCicloDiario = "VENTAS BAJAS";

                this.lstEvalSimpCDiario.Add(objCDiarioAlto);
                this.lstEvalSimpCDiario.Add(objCDiarioNormal);
                this.lstEvalSimpCDiario.Add(objCDiarioBajo);

            }

            if (this.lstTipoCicloMensual.Count == 0)
            {
                clsTipoCicloMensual objTCicloMenAlto = new clsTipoCicloMensual()
                {
                    idTipoCicloMensual = 1,
                    cTipoCicloMensual = "MES ALTO",
                    nPorcentaje = 105
                };

                clsTipoCicloMensual objTCicloMenNormal = new clsTipoCicloMensual()
                {
                    idTipoCicloMensual = 2,
                    cTipoCicloMensual = "MES NORMAL",
                    nPorcentaje = 100
                };
                clsTipoCicloMensual objTCicloMenBajo = new clsTipoCicloMensual()
                {
                    idTipoCicloMensual = 3,
                    cTipoCicloMensual = "MES BAJO",
                    nPorcentaje = 95
                };
                lstTipoCicloMensual.Add(objTCicloMenAlto);
                lstTipoCicloMensual.Add(objTCicloMenNormal);
                lstTipoCicloMensual.Add(objTCicloMenBajo);

                FormatearCeldaTipoCicloMensual();
            }
            if(lstEvalSimpCMensual.Count == 0)
            {
                clsEvalSimpCicloMensual objCicloMensualA = new clsEvalSimpCicloMensual();
                objCicloMensualA.idEvalCred = idEvalCred;
                objCicloMensualA.idSolicitud = idSolicitud;
                objCicloMensualA.idTipoCicloMensual = 1;
                objCicloMensualA.lVigente = true;
                clsEvalSimpCicloMensual objCicloMensualN = new clsEvalSimpCicloMensual();
                objCicloMensualN.idEvalCred = idEvalCred;
                objCicloMensualN.idSolicitud = idSolicitud;
                objCicloMensualN.idTipoCicloMensual = 2;
                objCicloMensualN.lVigente = true;
                clsEvalSimpCicloMensual objCicloMensualB = new clsEvalSimpCicloMensual();
                objCicloMensualB.idEvalCred = idEvalCred;
                objCicloMensualB.idSolicitud = idSolicitud;
                objCicloMensualB.idTipoCicloMensual = 3;
                objCicloMensualB.lVigente = true;

                lstEvalSimpCMensual.Add(objCicloMensualA);
                lstEvalSimpCMensual.Add(objCicloMensualB);
                lstEvalSimpCMensual.Add(objCicloMensualN);
            }

            if(lstEvalSimpCDetalleMensual.Count == 0)
            {
                clsEvalSimpCicloMensualDetalle objMes1 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 1,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 1) ? true : false,
                };
                clsEvalSimpCicloMensualDetalle objMes2 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 2,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 2) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes3 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 3,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 3) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes4 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 4,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 4) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes5 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 5,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 5) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes6 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 6,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 6) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes7 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 7,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 7) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes8 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 8,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 8) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes9 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 9,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 9) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes10 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 10,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 10) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes11 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 11,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 11) ? true : false
                };
                clsEvalSimpCicloMensualDetalle objMes12 = new clsEvalSimpCicloMensualDetalle()
                {
                    idMes = 12,
                    idTipoCicloMensual = 2,
                    nPorcentaje = 100,
                    nMontoIngreso = 0,
                    lMesEvaluado = (clsVarGlobal.dFecSystem.Month == 12) ? true : false
                };

                lstEvalSimpCDetalleMensual.Add(objMes1);
                lstEvalSimpCDetalleMensual.Add(objMes2);
                lstEvalSimpCDetalleMensual.Add(objMes3);
                lstEvalSimpCDetalleMensual.Add(objMes4);
                lstEvalSimpCDetalleMensual.Add(objMes5);
                lstEvalSimpCDetalleMensual.Add(objMes6);
                lstEvalSimpCDetalleMensual.Add(objMes7);
                lstEvalSimpCDetalleMensual.Add(objMes8);
                lstEvalSimpCDetalleMensual.Add(objMes9);
                lstEvalSimpCDetalleMensual.Add(objMes10);
                lstEvalSimpCDetalleMensual.Add(objMes11);
                lstEvalSimpCDetalleMensual.Add(objMes12);

                FormatearCeldaCicloMensual();
            }
        }

        private void FormatearDataGridView()
        {
            this.dtgGFamiliares.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGFamiliares.MultiSelect = false;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGFamiliares.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGFamiliares.RowHeadersVisible = false;

            this.dtgGOperativos.Margin = new System.Windows.Forms.Padding(0);
            this.dtgGOperativos.MultiSelect = false;
            this.dtgGOperativos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgGOperativos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGOperativos.RowHeadersVisible = false;

            this.dtgCicloVentasMensual.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCicloVentasMensual.MultiSelect = false;
            this.dtgCicloVentasMensual.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgCicloVentasMensual.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCicloVentasMensual.RowHeadersVisible = false;

            this.dtgCicloVentaDiario.Margin = new System.Windows.Forms.Padding(0);
            this.dtgCicloVentaDiario.MultiSelect = false;
            this.dtgCicloVentaDiario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgCicloVentaDiario.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgCicloVentaDiario.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCicloVentaDiario.RowHeadersVisible = false;

            this.dtgTipVentaMensual.Margin = new System.Windows.Forms.Padding(0);
            this.dtgTipVentaMensual.MultiSelect = false;
            this.dtgTipVentaMensual.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgTipVentaMensual.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTipVentaMensual.RowHeadersVisible = false;
        }

        private void AgregarComboBoxColumnsDataGridViewGFamiliares()
        {
            List<clsDescripcionEval> listGastosFamiliares = new List<clsDescripcionEval>();
            listGastosFamiliares.Add(new clsDescripcionEval() { idDescripcionEval = 9990999, cDescripcion = "Descripción" });

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

        private void FormatearColumnasDataGridViewGFamiliares()
        {
            foreach (DataGridViewColumn column in this.dtgGFamiliares.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGFamiliares.Columns["cDescripcion"].DisplayIndex = 0;
            dtgGFamiliares.Columns["nPUnitario"].DisplayIndex = 1;

            dtgGFamiliares.Columns["cDescripcion"].Visible = true;
            dtgGFamiliares.Columns["nPUnitario"].Visible = true;

            dtgGFamiliares.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgGFamiliares.Columns["nPUnitario"].HeaderText = "Total";

            dtgGFamiliares.Columns["cDescripcion"].FillWeight = 112;
            dtgGFamiliares.Columns["nPUnitario"].FillWeight = 50;

            dtgGFamiliares.Columns["dgcboTipoMoneda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGFamiliares.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";

            dtgGFamiliares.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGFamiliares.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesGFamiliares()
        {
            this.txtTotalGFamiliares.Text = this.listGFamiliares.Sum(x => x.nTotalMA).ToString("N2");
        }

        private void AgregarComboBoxColumnsDataGridViewGOperativos()
        {
            DataGridViewComboBoxColumn dgcboTipoMoneda = new DataGridViewComboBoxColumn();
            dgcboTipoMoneda.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoMoneda.FlatStyle = FlatStyle.Popup;
            dgcboTipoMoneda.Name = "dgcboTipoMoneda";
            dgcboTipoMoneda.DataPropertyName = "idMoneda";
            dgcboTipoMoneda.DataSource = dtMoneda;
            dgcboTipoMoneda.DisplayMember = dtMoneda.Columns["cCodSBS"].ToString();
            dgcboTipoMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgGOperativos.Columns.Add(dgcboTipoMoneda);

            DataGridViewComboBoxColumn dgcboTipoFrecuencia = new DataGridViewComboBoxColumn();
            dgcboTipoFrecuencia.DisplayStyleForCurrentCellOnly = true;
            dgcboTipoFrecuencia.FlatStyle = FlatStyle.Popup;
            dgcboTipoFrecuencia.Name = "dgcboTipoFrecuencia";
            dgcboTipoFrecuencia.DataPropertyName = "nFrecuencia";
            dgcboTipoFrecuencia.DataSource = Evaluacion.DataTipoFrecuencia;
            dgcboTipoFrecuencia.DisplayMember = "cAbreviatura";
            dgcboTipoFrecuencia.ValueMember = "idFrecuencia";
            this.dtgGOperativos.Columns.Add(dgcboTipoFrecuencia);

            DataGridViewComboBoxColumn dgcboMesVenta = new DataGridViewComboBoxColumn();
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
            dtgGOperativos.Columns["nPUnitario"].DisplayIndex = 1;
            
            dtgGOperativos.Columns["cDescripcion"].Visible = true;
            dtgGOperativos.Columns["nPUnitario"].Visible = true;
            
            dtgGOperativos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgGOperativos.Columns["nPUnitario"].HeaderText = "Total";
            
            dtgGOperativos.Columns["cDescripcion"].FillWeight = 110;
            dtgGOperativos.Columns["nPUnitario"].FillWeight = 50;
            
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dtgGOperativos.Columns["nCantidad"].DefaultCellStyle.Format = "n0";
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.Format = "n2";
            dtgGOperativos.Columns["dgcboTipoFrecuencia"].DefaultCellStyle.Format = "n0";
            dtgGOperativos.Columns["dgcboMesVenta"].DefaultCellStyle.Format = "MMM/yy";

            dtgGOperativos.Columns["cDescripcion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgGOperativos.Columns["nPUnitario"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            
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

        private void FormatearColumnasDataGridViewTipoCicloMensual()
        {
            foreach (DataGridViewColumn column in this.dtgTipVentaMensual.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].DisplayIndex = 0;
            dtgTipVentaMensual.Columns["nPorcentaje"].DisplayIndex = 1;

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].Visible = true;
            dtgTipVentaMensual.Columns["nPorcentaje"].Visible = true;

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].HeaderText = "Ciclo Mensual";
            dtgTipVentaMensual.Columns["nPorcentaje"].HeaderText = "Porcentaje (%)";

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].FillWeight = 80;
            dtgTipVentaMensual.Columns["nPorcentaje"].FillWeight = 40;

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgTipVentaMensual.Columns["nPorcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgTipVentaMensual.Columns["nPorcentaje"].DefaultCellStyle.Format = "F2";

            dtgTipVentaMensual.Columns["cTipoCicloMensual"].ReadOnly = true;
            dtgTipVentaMensual.Columns["nPorcentaje"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
        }

        private void CalcularTotalesCicloVentaDiario()
        {
            this.txtTotalCicloVentaDiario.Text = this.lstEvalSimpCDiario.Sum(x => x.nMontoTotal).ToString("N2");
        }

        private void AgregarCheckBoxColumnsDataGridViewCVentasDiario()
        {
            DataGridViewCheckBoxColumn dgchkLunes = new DataGridViewCheckBoxColumn();
            dgchkLunes.HeaderText = "Lunes";
            dgchkLunes.Name = "dgchkLunes";
            dgchkLunes.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkLunes.FlatStyle = FlatStyle.Standard;
            dgchkLunes.ThreeState = true;
            dgchkLunes.DataPropertyName = "lLunes";
            dgchkLunes.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkLunes.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkMartes = new DataGridViewCheckBoxColumn();
            dgchkMartes.HeaderText = "Martes";
            dgchkMartes.Name = "dgchkMartes";
            dgchkMartes.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkMartes.FlatStyle = FlatStyle.Standard;
            dgchkMartes.ThreeState = true;
            dgchkMartes.DataPropertyName = "lMartes";
            dgchkMartes.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkMartes.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkMiercoles = new DataGridViewCheckBoxColumn();
            dgchkMiercoles.HeaderText = "Miércoles";
            dgchkMiercoles.Name = "dgchkMiercoles";
            dgchkMiercoles.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkMiercoles.FlatStyle = FlatStyle.Standard;
            dgchkMiercoles.ThreeState = true;
            dgchkMiercoles.DataPropertyName = "lMiercoles";
            dgchkMiercoles.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkMiercoles.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkJueves = new DataGridViewCheckBoxColumn();
            dgchkJueves.HeaderText = "Jueves";
            dgchkJueves.Name = "dgchkJueves";
            dgchkJueves.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkJueves.FlatStyle = FlatStyle.Standard;
            dgchkJueves.ThreeState = true;
            dgchkJueves.DataPropertyName = "lJueves";
            dgchkJueves.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkJueves.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkViernes = new DataGridViewCheckBoxColumn();
            dgchkViernes.HeaderText = "Viernes";
            dgchkViernes.Name = "dgchkViernes";
            dgchkViernes.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkViernes.FlatStyle = FlatStyle.Standard;
            dgchkViernes.ThreeState = true;
            dgchkViernes.DataPropertyName = "lViernes";
            dgchkViernes.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkViernes.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkSabado = new DataGridViewCheckBoxColumn();
            dgchkSabado.HeaderText = "Sábado";
            dgchkSabado.Name = "dgchkSabado";
            dgchkSabado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkSabado.FlatStyle = FlatStyle.Standard;
            dgchkSabado.ThreeState = true;
            dgchkSabado.DataPropertyName = "lSabado";
            dgchkSabado.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkSabado.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            DataGridViewCheckBoxColumn dgchkDomingo = new DataGridViewCheckBoxColumn();
            dgchkDomingo.HeaderText = "Domingo";
            dgchkDomingo.Name = "dgchkDomingo";
            dgchkDomingo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgchkDomingo.FlatStyle = FlatStyle.Standard;
            dgchkDomingo.ThreeState = true;
            dgchkDomingo.DataPropertyName = "lDomingo";
            dgchkDomingo.CellTemplate = new DataGridViewCheckBoxCell();
            dgchkDomingo.CellTemplate.Style.BackColor = GridViewStyle.GridViewBackColorEditable;

            this.dtgCicloVentaDiario.Columns.Add(dgchkLunes);
            this.dtgCicloVentaDiario.Columns.Add(dgchkMartes);
            this.dtgCicloVentaDiario.Columns.Add(dgchkMiercoles);
            this.dtgCicloVentaDiario.Columns.Add(dgchkJueves);
            this.dtgCicloVentaDiario.Columns.Add(dgchkViernes);
            this.dtgCicloVentaDiario.Columns.Add(dgchkSabado);
            this.dtgCicloVentaDiario.Columns.Add(dgchkDomingo);

        }

        private void FormatearColumnasDataGridViewCVentaDiario()
        {
            foreach (DataGridViewColumn column in this.dtgCicloVentaDiario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].HeaderText = "Ciclo Diario de Ventas";
            dtgCicloVentaDiario.Columns["nMontoPromedio"].HeaderText = "S/";
            dtgCicloVentaDiario.Columns["dgchkLunes"].HeaderText = "Lunes";
            dtgCicloVentaDiario.Columns["dgchkMartes"].HeaderText = "Martes";
            dtgCicloVentaDiario.Columns["dgchkMiercoles"].HeaderText = "Miércoles";
            dtgCicloVentaDiario.Columns["dgchkJueves"].HeaderText = "Jueves";
            dtgCicloVentaDiario.Columns["dgchkViernes"].HeaderText = "Viernes";
            dtgCicloVentaDiario.Columns["dgchkSabado"].HeaderText = "Sábado";
            dtgCicloVentaDiario.Columns["dgchkDomingo"].HeaderText = "Domingo";
            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].HeaderText = "Nro. x Semana";
            dtgCicloVentaDiario.Columns["nMontoTotal"].HeaderText = "Total";

            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].DisplayIndex = 0;
            dtgCicloVentaDiario.Columns["nMontoPromedio"].DisplayIndex = 1;
            dtgCicloVentaDiario.Columns["dgchkLunes"].DisplayIndex = 2;
            dtgCicloVentaDiario.Columns["dgchkMartes"].DisplayIndex = 3;
            dtgCicloVentaDiario.Columns["dgchkMiercoles"].DisplayIndex = 4;
            dtgCicloVentaDiario.Columns["dgchkJueves"].DisplayIndex = 5;
            dtgCicloVentaDiario.Columns["dgchkViernes"].DisplayIndex = 6;
            dtgCicloVentaDiario.Columns["dgchkSabado"].DisplayIndex = 7;
            dtgCicloVentaDiario.Columns["dgchkDomingo"].DisplayIndex = 8;
            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].DisplayIndex = 9;
            dtgCicloVentaDiario.Columns["nMontoTotal"].DisplayIndex = 10;

            dtgCicloVentaDiario.Columns["idEvalSimpCicloDiario"].DisplayIndex = 11;
            dtgCicloVentaDiario.Columns["idEvalCred"].DisplayIndex = 12;
            dtgCicloVentaDiario.Columns["idSolicitud"].DisplayIndex = 13;
            dtgCicloVentaDiario.Columns["idTipoCicloDiario"].DisplayIndex = 14;
            dtgCicloVentaDiario.Columns["lLunes"].DisplayIndex = 15;
            dtgCicloVentaDiario.Columns["lMartes"].DisplayIndex = 16;
            dtgCicloVentaDiario.Columns["lMiercoles"].DisplayIndex = 17;
            dtgCicloVentaDiario.Columns["lJueves"].DisplayIndex = 18;
            dtgCicloVentaDiario.Columns["lViernes"].DisplayIndex = 19;
            dtgCicloVentaDiario.Columns["lSabado"].DisplayIndex = 20;
            dtgCicloVentaDiario.Columns["lDomingo"].DisplayIndex = 21;

            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkLunes"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkMartes"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkMiercoles"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkJueves"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkViernes"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkSabado"].Visible = true;
            dtgCicloVentaDiario.Columns["dgchkDomingo"].Visible = true;
            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].Visible = true;
            dtgCicloVentaDiario.Columns["nMontoPromedio"].Visible = true;
            dtgCicloVentaDiario.Columns["nMontoTotal"].Visible = true;

            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].FillWeight = 90;
            dtgCicloVentaDiario.Columns["dgchkLunes"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkMartes"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkMiercoles"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkJueves"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkViernes"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkSabado"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["dgchkDomingo"].FillWeight = 30;
            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].FillWeight = 70;
            dtgCicloVentaDiario.Columns["nMontoPromedio"].FillWeight = 70;
            dtgCicloVentaDiario.Columns["nMontoTotal"].FillWeight = 70;

            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].DefaultCellStyle.Format = "N0";
            dtgCicloVentaDiario.Columns["nMontoPromedio"].DefaultCellStyle.Format = "F2";
            dtgCicloVentaDiario.Columns["nMontoTotal"].DefaultCellStyle.Format = "F2";

            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].ReadOnly = true;
            dtgCicloVentaDiario.Columns["nTotalDiasActivos"].ReadOnly = true;
            dtgCicloVentaDiario.Columns["nMontoTotal"].ReadOnly = true;

            dtgCicloVentaDiario.Columns["nMontoPromedio"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCicloVentaDiario.Columns["cTipoCicloDiario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void AgregarComboBoxColumnsDataGridViewCVentasMensual()
        {
            DataTable dtMes = (new clsCNEvalCredSimp()).CNRecuperaMes();
            DataGridViewComboBoxColumn dgcboMes = new DataGridViewComboBoxColumn();
            dgcboMes.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgcboMes.FlatStyle = FlatStyle.Popup;
            dgcboMes.Name = "dgcboMes";
            dgcboMes.DataPropertyName = "idMes";
            dgcboMes.DataSource = dtMes;
            dgcboMes.DisplayMember = "cMes";
            dgcboMes.ValueMember = "idMeses";
            this.dtgCicloVentasMensual.Columns.Add(dgcboMes);

            DataTable dtTCicloMensual = (new clsCNEvalCredSimp()).CNRecuperarTipoCicloMensual();
            DataGridViewComboBoxColumn dgcboTipoCicloMes = new DataGridViewComboBoxColumn();
            dgcboMes.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgcboTipoCicloMes.Name = "dgcboTipoCicloMes";
            dgcboTipoCicloMes.DataPropertyName = "idTipoCicloMensual";
            dgcboTipoCicloMes.DataSource = dtTCicloMensual;
            dgcboTipoCicloMes.DisplayMember = "cTipoCicloMensual";
            dgcboTipoCicloMes.ValueMember = "idTipoCicloMensual";
            this.dtgCicloVentasMensual.Columns.Add(dgcboTipoCicloMes);
        }

        private void FormatearColumnasDataGridViewCVentaMensual()
        {
            foreach (DataGridViewColumn column in this.dtgCicloVentasMensual.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCicloVentasMensual.Columns["dgcboMes"].DisplayIndex = 0;
            dtgCicloVentasMensual.Columns["dgcboTipoCicloMes"].DisplayIndex = 1;
            dtgCicloVentasMensual.Columns["nMontoIngreso"].DisplayIndex = 2;

            dtgCicloVentasMensual.Columns["dgcboMes"].HeaderText = "Mes";
            dtgCicloVentasMensual.Columns["dgcboTipoCicloMes"].HeaderText = "Venta Mensual";
            dtgCicloVentasMensual.Columns["nMontoIngreso"].HeaderText = "Monto Ingreso";

            dtgCicloVentasMensual.Columns["dgcboMes"].Visible = true;
            dtgCicloVentasMensual.Columns["dgcboTipoCicloMes"].Visible = true;
            dtgCicloVentasMensual.Columns["nMontoIngreso"].Visible = true;

            dtgCicloVentasMensual.Columns["dgcboMes"].FillWeight = 60;
            dtgCicloVentasMensual.Columns["dgcboTipoCicloMes"].FillWeight = 80;
            dtgCicloVentasMensual.Columns["nMontoIngreso"].FillWeight = 60;

            dtgCicloVentasMensual.Columns["nMontoIngreso"].DefaultCellStyle.Format = "F2";

            dtgCicloVentasMensual.Columns["dgcboMes"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dtgCicloVentasMensual.Columns["dgcboMes"].ReadOnly = true;
            dtgCicloVentasMensual.Columns["nMontoIngreso"].ReadOnly = true;
        }

        private void RecuperarDetalleEstResultados()
        {
            DataSet ds = (new clsCNEvalCredSimp()).CNRecuperarDetalleEstResultadosEvalFacilito(this.idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;

            var listEvalCDiario = DataTableToList.ConvertTo<clsEvalSimpCicloDiario>(ds.Tables[1]) as List<clsEvalSimpCicloDiario>;
            var listEvalCDiarioDetalle = DataTableToList.ConvertTo<clsEvalSimpCicloDiarioDetalle>(ds.Tables[2]) as List<clsEvalSimpCicloDiarioDetalle>;

            var listEvalCMensual = DataTableToList.ConvertTo<clsEvalSimpCicloMensual>(ds.Tables[4]) as List<clsEvalSimpCicloMensual>;
            var listEvalCMensualDetalle = DataTableToList.ConvertTo<clsEvalSimpCicloMensualDetalle>(ds.Tables[5]) as List<clsEvalSimpCicloMensualDetalle>;

            var listTipoCMensual = DataTableToList.ConvertTo<clsTipoCicloMensual>(ds.Tables[3]) as List<clsTipoCicloMensual>;

            #region Detalle de los Estado Resultados
            this.listGFamiliares = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosFamiliares
                                    select p).ToList();


            this.listGOperativos = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosNegocio
                                    select p).ToList();
            #endregion

            #region Detalle de Ingresos Estado de Resultados
            foreach (clsEvalSimpCicloDiario oCDiario in listEvalCDiario)
                oCDiario.lstDetalleDiario = listEvalCDiarioDetalle.Where(item => item.idEvalSimpCicloDiario == oCDiario.idEvalSimpCicloDiario).ToList();

            foreach (clsEvalSimpCicloMensual oCMensual in listEvalCMensual)
            {
                oCMensual.lstDetalleMensual = listEvalCMensualDetalle.Where(item => item.idEvalSimpCicloMensual == oCMensual.idEvalSimpCicloMensual).ToList();
            }

            this.lstEvalSimpCDetalleMensual = listEvalCMensualDetalle;

            this.lstEvalSimpCDiario = listEvalCDiario;
            this.lstEvalSimpCMensual = listEvalCMensual;
            this.lstTipoCicloMensual = listTipoCMensual;

            #endregion

            this.AsignarDatos(this.listGFamiliares, this.listGOperativos, this.lstEvalSimpCDiario, this.lstEvalSimpCMensual, lstTipoCicloMensual, lstEvalSimpCDetalleMensual,
                this.nTipoCambio, this.idMonedaMA, this.cMonedaSimbolo, this.idEvalCred);

            this.LimpiarSelecciones();
        }

        private string DetalleEstResEnXML(List<clsDetEstResEval> listDetalleEstRes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetEstResEval", typeof(int));
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

            foreach (var detEstRes in listDetalleEstRes)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
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

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
        }

        private void FormatearCeldaTipoCicloMensual()
        {
            foreach (DataGridViewRow dgRow in dtgTipVentaMensual.Rows)
            {
                if (Convert.ToInt32(dgRow.Cells["idTipoCicloMensual"].Value) == 2)
                {
                    dgRow.Cells["nPorcentaje"].Style.BackColor = Color.White;
                    dgRow.Cells["nPorcentaje"].ReadOnly = true;
                }
            }
        }
        private void FormatearCeldaCicloMensual()
        {
            foreach(DataGridViewRow dgRow in dtgCicloVentasMensual.Rows)
            {
                if(Convert.ToInt32(dgRow.Cells["idMes"].Value) == clsVarGlobal.dFecSystem.Month)
                {
                    dgRow.Cells["dgcboTipoCicloMes"].Style.BackColor = Color.White;
                    dgRow.Cells["dgcboTipoCicloMes"].ReadOnly = true;
                }
            }
        }

        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<clsDetEstResEval> listDetalleEstRes = new List<clsDetEstResEval>();
            List<clsEvalSimpCicloDiario> listCDiarioDetalle = new List<clsEvalSimpCicloDiario>();
            List<clsEvalSimpCicloMensual> listCMensualDetalle = new List<clsEvalSimpCicloMensual>();


            #region Detalle de los Estados Resultados
            foreach (clsDetEstResEval detBG in this.listGFamiliares)
                listDetalleEstRes.Add(detBG);

            foreach (clsDetEstResEval detBG in this.listGOperativos)
                listDetalleEstRes.Add(detBG);
            #endregion

            #region Detalle de Ingresos
            listCDiarioDetalle.AddRange(this.lstEvalSimpCDiario);
            listCMensualDetalle.AddRange(this.lstEvalSimpCMensual);
            #endregion

            string xmlDetalleEstRes = DetalleEstResEnXML(listDetalleEstRes);
            string xmlEvalCDiario = listCDiarioDetalle.GetXml();
            string xmlEvalCMensual = listCMensualDetalle.GetXml();

            (new clsCNEvalCredSimp()).CNActDetalleEstadosResultadoslEvalFacilito(this.idEvalCred, xmlDetalleEstRes, xmlEvalCDiario, xmlEvalCMensual, clsVarGlobal.User.idUsuario);

            this.grbIngresoGastos.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;

            RecuperarDetalleEstResultados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.grbIngresoGastos.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.grbIngresoGastos.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            RecuperarDetalleEstResultados();
        }

        private void frmDetalleEstResFacilito_Load(object sender, EventArgs e)
        {
            RecuperarDetalleEstResultados();
        }

        private void dtgCicloVentaDiario_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dtgCicloVentaDiario.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(dtgCicloVentaDiario_CellValueChanged);
            var dtg = ((DataGridView)sender);

            string cColumnaSel = dtg.CurrentCell.OwningColumn.DataPropertyName;
            clsEvalSimpCicloDiario objCDiarioCamb = (clsEvalSimpCicloDiario)dtg.CurrentRow.DataBoundItem;
            if (cColumnaSel.In("lLunes", "lMartes", "lMiercoles", "lJueves", "lViernes", "lSabado", "lDomingo"))
            {
                lstEvalSimpCDiario = lstEvalSimpCDiario.Select(item =>
                {
                    item.lLunes = (cColumnaSel == "lLunes") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)          ? item.lLunes       : false : item.lLunes;
                    item.lMartes = (cColumnaSel == "lMartes") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)        ? item.lMartes      : false : item.lMartes;
                    item.lMiercoles = (cColumnaSel == "lMiercoles") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)  ? item.lMiercoles   : false : item.lMiercoles;
                    item.lJueves = (cColumnaSel == "lJueves") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)        ? item.lJueves      : false : item.lJueves;
                    item.lViernes = (cColumnaSel == "lViernes") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)      ? item.lViernes     : false : item.lViernes;
                    item.lSabado = (cColumnaSel == "lSabado") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)        ? item.lSabado      : false : item.lSabado;
                    item.lDomingo = (cColumnaSel == "lDomingo") ? (objCDiarioCamb.idTipoCicloDiario == item.idTipoCicloDiario)      ? item.lDomingo     : false : item.lDomingo;
                    return item;
                }).ToList();
            }

            foreach (clsEvalSimpCicloDiario objCDiario in lstEvalSimpCDiario)
            {
                objCDiario.lstDetalleDiario = objCDiario.lstDetalleDiario.Select(
                                                    item =>
                                                    {
                                                        item.nMontoIngreso = objCDiario.nMontoPromedio;
                                                        item.idTipoCicloDiario = objCDiario.idTipoCicloDiario;
                                                        if (item.idDiaSemana == 2)
                                                        {
                                                            item.lDiaActivo = objCDiario.lLunes;
                                                            item.nMontoIngreso = (objCDiario.lLunes) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 3)
                                                        {
                                                            item.lDiaActivo = objCDiario.lMartes;
                                                            item.nMontoIngreso = (objCDiario.lMartes) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 4)
                                                        {
                                                            item.lDiaActivo = objCDiario.lMiercoles;
                                                            item.nMontoIngreso = (objCDiario.lMiercoles) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 5)
                                                        {
                                                            item.lDiaActivo = objCDiario.lJueves;
                                                            item.nMontoIngreso = (objCDiario.lJueves) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 6)
                                                        {
                                                            item.lDiaActivo = objCDiario.lViernes;
                                                            item.nMontoIngreso = (objCDiario.lViernes) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 7)
                                                        {
                                                            item.lDiaActivo = objCDiario.lSabado;
                                                            item.nMontoIngreso = (objCDiario.lSabado) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        if (item.idDiaSemana == 1)
                                                        {
                                                            item.lDiaActivo = objCDiario.lDomingo;
                                                            item.nMontoIngreso = (objCDiario.lDomingo) ? objCDiario.nMontoPromedio : 0;
                                                        }
                                                        return item;
                                                    }
                                                ).ToList();
                objCDiario.nTotalDiasActivos = objCDiario.lstDetalleDiario.Where(item => item.lDiaActivo).Count();
                objCDiario.nMontoTotal = objCDiario.nMontoPromedio * objCDiario.lstDetalleDiario.Where(item => item.lDiaActivo).Count();

            }

            

            this.bindingCVentaDiario.ResetBindings(false);
            dtgCicloVentaDiario.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dtgCicloVentaDiario_CellValueChanged);
        }

        private void dtgCicloVentaDiario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dtg = ((DataGridView)sender);

            string cNombreColumna = dtg.CurrentCell.OwningColumn.DataPropertyName;
            if (dtgCicloVentaDiario.IsCurrentCellDirty && (cNombreColumna.In("lLunes", "lMartes", "lMiercoles", "lJueves", "lViernes", "lSabado", "lDomingo")))
            {
                dtgCicloVentaDiario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgCicloVentaDiario_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

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

            if (dtg.CurrentCell.OwningColumn.Name.Equals("cDescripcion"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressMayuscula);
                }
            }

            if (dtg.CurrentCell.OwningColumn.Name.Equals("dgcboMesVenta"))
            {
                cmbItem = e.Control as ComboBox;
                if (cmbItem != null)
                {
                    cmbItem.DropDown += new EventHandler(cboMesVenta_DropDown);
                }
            }

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

        #region Ciclo de Venta

        private void dtgCicloVentaDiario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CalcularTotalesCicloVentaDiario();
            ActualizarCicloMensual();
        }

        private void dtgCicloVentaDiario_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nMontoPromedio"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }
        }

        private void dtgCicloVentaDiario_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgCicloVentasMensual_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            nMontoCMensualPromedio = lstEvalSimpCMensual.Sum(x => x.nMontoTotal) / 12;
            FormatearCeldaCicloMensual();
        }

        private void dtgCicloVentasMensual_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

        }

        private void dtgCicloVentasMensual_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dtgTipVentaMensual_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatearCeldaTipoCicloMensual();
            ActualizarCicloMensual();
        }

        private void dtgTipVentaMensual_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressDecimal);
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPressMayuscula);

            if (dtg.CurrentCell.OwningColumn.DataPropertyName.Equals("nPorcentaje"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPressDecimal);
                }
            }

        }

        private void dtgTipVentaMensual_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

            if (this.dtgGFamiliares.SelectedCells.Count == 0)
                this.tsmQuitarGFam.Enabled = false;
        }

        private void tsmAgregarGOpe_Click(object sender, EventArgs e)
        {
            this.listGOperativos.Add(new clsDetEstResEval()
            {
                idEEFF = EEFF.GastosNegocio,
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

            if (this.dtgGOperativos.SelectedCells.Count == 0)
                this.tsmQuitarGOpe.Enabled = false;
        }

        #endregion

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

        #endregion

        private void dtgCicloVentasMensual_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarCicloMensual();
        }

        private void ActualizarCicloMensual()
        {
            this.dtgCicloVentasMensual.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCicloVentasMensual_CellValueChanged);

            decimal nTotalDiario = (!String.IsNullOrWhiteSpace(this.txtTotalCicloVentaDiario.Text)) ? Convert.ToDecimal(this.txtTotalCicloVentaDiario.Text): 0;
            nMontoCMensualNormal = nTotalDiario * 4;

            this.lstEvalSimpCDetalleMensual = this.lstEvalSimpCDetalleMensual.Select(item => {
                item.idEvalSimpCicloMensual = lstEvalSimpCMensual.Where(item2 => item.idTipoCicloMensual == item2.idTipoCicloMensual).ToList()[0].idEvalSimpCicloMensual;
                item.nPorcentaje = lstTipoCicloMensual.Where(item2 => item2.idTipoCicloMensual == item.idTipoCicloMensual).ToList()[0].nPorcentaje;
                item.nMontoIngreso = nMontoCMensualNormal * lstTipoCicloMensual.FirstOrDefault(y => y.idTipoCicloMensual == item.idTipoCicloMensual).nPorcentaje / 100;
                return item;
            }).ToList();

            this.lstEvalSimpCMensual = this.lstEvalSimpCMensual.Select(item => {
                item.lstDetalleMensual.Clear();
                item.lstDetalleMensual.AddRange(lstEvalSimpCDetalleMensual.Where(x => item.idTipoCicloMensual == x.idTipoCicloMensual).ToList());
                item.nMontoTotal = item.lstDetalleMensual.Sum(x => x.nMontoIngreso);
                item.nPorcentaje = lstTipoCicloMensual.FirstOrDefault(y => y.idTipoCicloMensual == item.idTipoCicloMensual).nPorcentaje;
                item.nTotalMesActivos = item.lstDetalleMensual.Count();
                return item;
            }).ToList();

            this.bindingCicloVentasMensual.ResetBindings(false);
            this.dtgCicloVentasMensual.Refresh();
            this.dtgCicloVentasMensual.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCicloVentasMensual_CellValueChanged);

        }

        private void dtgCicloVentasMensual_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var dtg = ((DataGridView)sender);

            string cNombreColumna = dtg.CurrentCell.OwningColumn.DataPropertyName;
            if (dtg.IsCurrentCellDirty && (cNombreColumna.In("idTipoCicloMensual")))
            {
                dtg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
