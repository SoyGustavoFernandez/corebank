using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System.Diagnostics;


namespace GEN.ControlesBase
{
    public partial class ConOtrosIngEgr : UserControl
    {
        #region Variables

        private List<clsOtrosIngresosEvalRuralM> listOtrosIngresosMaestro;
        private List<clsOtrosEgresosEvalRuralM> listOtrosEgresosMaestro;
        private List<clsOtrosEgresosEvalRuralD> listOtrosEgresosDetalle;
        private List<clsPeriodoCuotas> listaPeriodos;
        private BindingSource bsOtrosIngresosM;
        private BindingSource bsOtrosIngresosD;
        private BindingSource bsOtrosEgresosM;
        private BindingSource bsOtrosEgresosD;
        private int idEvalCred;
        private DateTime dFecActualEval;
        private int nPlazoCredMeses;
        public event EventHandler btnGrabarOtrIngClick;
        public enum Periodo
        {
            diario = 1,
            mensual = 2
        }

        #endregion

        #region Metodos Publicos

        public ConOtrosIngEgr()
        {
            InitializeComponent();
        }

        public void inicializarControl(int plazoCredMeses, DateTime fechaDesembolso)
        {
            this.nPlazoCredMeses = plazoCredMeses;
            this.dFecActualEval = fechaDesembolso;
            var dtTipo = new clsCNEvalCrediRural().CargarTipoOtroIngresosRural();

            this.cboTipo.DisplayMember = "cTipoOtrosIngresosEvalRural";
            this.cboTipo.ValueMember = "idTipoOtrosIngresosEvalRural";
            this.cboTipo.DataSource = dtTipo;

            var dtPeriodo = new clsCNEvalCrediRural().CargarPeriodoOtroIngresosRural();

            this.cboPeriodo.DisplayMember = "cPeriodoOtrosIngresosEvalRural";
            this.cboPeriodo.ValueMember = "idPeriodoOtrosIngresosEvalRural";
            this.cboPeriodo.DataSource = dtPeriodo;

            this.listOtrosIngresosMaestro = new List<clsOtrosIngresosEvalRuralM>();
            this.listOtrosEgresosMaestro = new List<clsOtrosEgresosEvalRuralM>();
            this.listOtrosEgresosDetalle = new List<clsOtrosEgresosEvalRuralD>();
            this.listaPeriodos = new List<clsPeriodoCuotas>();

            ObtenerLisPeriodos();
            AgregarComboBoxFechaDataGridViewEgresosEstacionales();
            inicializarTablaOtrosIngresosMaestro();
            inicializarTablaOtrosEgresosMaestro();
            inicializarTablaOtrosEgresosDetalle();
            FormatearDataGridView();
        }

        public void AsignarDatos(List<clsOtrosIngresosEvalRuralM> listOtrosIngresosM, List<clsOtrosEgresosEvalRuralM> listOtrosEgresosM, 
            List<clsOtrosEgresosEvalRuralD> listOtrosEgresosD, DateTime dFechaDesembolso, clsEvalCred objEvalCred) 
        {
            this.dtgvOtrosEgresosDetalle.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvOtrosEgresosDetalle_EditingControlShowing);
            //this.dtgOtrosIngresosM.SelectionChanged -= new System.EventHandler(this.dtgOtrosIngresosM_SelectionChanged);

            this.dFecActualEval = dFechaDesembolso;
            this.idEvalCred = objEvalCred.idEvalCred;

            this.listOtrosIngresosMaestro.Clear();
            this.listOtrosEgresosMaestro.Clear();
            this.listOtrosEgresosDetalle.Clear();

            foreach (var item in listOtrosIngresosM)
            {
                this.listOtrosIngresosMaestro.Add(item);
            }

            foreach (var item in listOtrosEgresosM)
            {
                this.listOtrosEgresosMaestro.Add(item);
            }

            foreach (var item in listOtrosEgresosD)
            {
                this.listOtrosEgresosDetalle.Add(item);
            }

            this.bsOtrosIngresosM.ResetBindings(false);
            this.bsOtrosEgresosM.ResetBindings(false);
            this.bsOtrosEgresosD.ResetBindings(false);

            this.dtgvOtrosEgresosDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvOtrosEgresosDetalle_EditingControlShowing);
            //this.dtgOtrosIngresosM.SelectionChanged += new System.EventHandler(this.dtgOtrosIngresosM_SelectionChanged);
        }

        public void ActualizaDatosOtrosIngEgr() 
        {
            foreach (var maestro in this.listOtrosIngresosMaestro)
            {
                var objDetalle = maestro.listaDetalle;
                int contador = 0;

                if (nPlazoCredMeses < maestro.nPlazo)
                {
                    foreach (var item in objDetalle.ToList())
                    {
                        if (contador < ((nPlazoCredMeses + 1) * maestro.nCantidadItems))
                            contador++;
                        else
                            objDetalle.Remove(item);
                        
                    }

                    maestro.nPlazo = nPlazoCredMeses;
                }
                else if (nPlazoCredMeses > maestro.nPlazo)
                {
                    int difPlazo = nPlazoCredMeses - maestro.nPlazo;

                    DateTime dFechaActualEval = this.dFecActualEval.AddMonths(maestro.nPlazo);
                    maestro.nPlazo = nPlazoCredMeses;

                    for (int x = 1; x <= difPlazo; x++)
                    {
                        for (int i = 0; i < maestro.nCantidadItems; i++)
                        {
                            var oOtrosIngresos = new clsOtrosIngresosEvalRuralD();
                            oOtrosIngresos.idOtrIngD = Guid.NewGuid();
                            oOtrosIngresos.idOtrIngM = maestro.idOtrIngM;
                            oOtrosIngresos.nItem = i + 1;
                            oOtrosIngresos.dFechaCuota = dFechaActualEval.AddMonths(x).ToString("MMM - yy");
                            oOtrosIngresos.nFechaCuota = Convert.ToInt32(dFechaActualEval.AddMonths(x).ToString("yyyyMM"));
                            oOtrosIngresos.nOrden = i + 1;
                            oOtrosIngresos.nCantidad = 0;
                            oOtrosIngresos.nPrecioUnitario = 0;
                            oOtrosIngresos.nTotal = oOtrosIngresos.nCantidad * oOtrosIngresos.nPrecioUnitario;
                            objDetalle.Add(oOtrosIngresos);
                        }
                    }
                }
            }

            inicializarTablaOtrosIngresosMaestro();
            inicializarTablaOtrosEgresosMaestro();
        }

        public void GrabarOtrosIngresosEgresos()
        {
            List<clsOtrosIngresosEvalRuralM> lstOtrosIngresosMaestro = new List<clsOtrosIngresosEvalRuralM>();
            List<clsOtrosEgresosEvalRuralM> lstOtrosEgresosMaestro = new List<clsOtrosEgresosEvalRuralM>();
            List<clsOtrosEgresosEvalRuralD> lstOtrosEgresosDetalle = new List<clsOtrosEgresosEvalRuralD>();

            foreach (clsOtrosIngresosEvalRuralM item in this.listOtrosIngresosMaestro)
            {
                lstOtrosIngresosMaestro.Add(item);
            }

            foreach (clsOtrosEgresosEvalRuralM item in this.listOtrosEgresosMaestro)
            {
                lstOtrosEgresosMaestro.Add(item);
            }

            foreach (clsOtrosEgresosEvalRuralD item in this.listOtrosEgresosDetalle)
            {
                lstOtrosEgresosDetalle.Add(item);
            }

            string xmlOtrosINgresosRuralM = OtrosIngresosRuralMEnXML(lstOtrosIngresosMaestro);
            string xmlOtrosINgresosRuralD = OtrosIngresosRuralDEnXML(lstOtrosIngresosMaestro);

            string xmlOtrosEgresosRuralM = OtrosEgresosRuralMEnXML(lstOtrosEgresosMaestro);
            string xmlOtrosEgresosRuralD = OtrosEgresosRuralDEnXML(lstOtrosEgresosDetalle);

            (new clsCNEvalCrediRural()).GuardaOtrosIngresosEvalRural
                (this.idEvalCred, xmlOtrosINgresosRuralM, xmlOtrosINgresosRuralD, xmlOtrosEgresosRuralM,xmlOtrosEgresosRuralD);
        }

        #endregion


        #region Metodos Privados

        private void ObtenerLisPeriodos()
        {
            this.listaPeriodos.Clear();

            int nCuotas = Convert.ToInt32(clsVarApl.dicVarGen["nPlazoMaxEvalRural"]);

            clsPeriodoCuotas oMensual = new clsPeriodoCuotas()
            { nFecha = 999999, cdescripcion = "Mensual"};
            this.listaPeriodos.Add(oMensual);

            for (int x = 0; x < nCuotas; x++)
            {
                DateTime dFechaTmp = this.dFecActualEval.AddMonths(x);
                var oPeriodoCuotas = new clsPeriodoCuotas();
                oPeriodoCuotas.nFecha = Convert.ToInt32(dFechaTmp.ToString("yyyyMM"));
                oPeriodoCuotas.cdescripcion = dFechaTmp.ToString("MMM - yy");
                listaPeriodos.Add(oPeriodoCuotas);
            }
        }

        private void AgregarComboBoxFechaDataGridViewEgresosEstacionales()
        {
            DataGridViewComboBoxColumn fechaColumn = new DataGridViewComboBoxColumn();
            fechaColumn.DisplayStyleForCurrentCellOnly = true;
            fechaColumn.FlatStyle = FlatStyle.Popup;
            fechaColumn.Name = "cboFecha";
            fechaColumn.DataPropertyName = "nFecha";
            fechaColumn.DataSource = this.listaPeriodos;
            fechaColumn.DisplayMember = "cdescripcion";
            fechaColumn.ValueMember = "nFecha";
            this.dtgvOtrosEgresosDetalle.Columns.Add(fechaColumn);
        }

        public void inicializarTablaOtrosIngresosMaestro()
        {
            this.bsOtrosIngresosM = new BindingSource();

            this.bsOtrosIngresosM.DataSource = this.listOtrosIngresosMaestro;
            this.dtgOtrosIngresosM.DataSource = this.bsOtrosIngresosM;

            this.bsOtrosIngresosM.ResetBindings(false);
            this.dtgOtrosIngresosM.Refresh();

            dtgOtrosIngresosM.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgOtrosIngresosM.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgOtrosIngresosM.Columns["nIngresoTotal"].DefaultCellStyle.Format = "n2";

            dtgOtrosIngresosM.Columns["cTipoOtrosIngresosEvalRural"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOtrosIngresosM.Columns["cPeriodoOtrosIngresosEvalRural"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOtrosIngresosM.Columns["nCantidadItems"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgOtrosIngresosM.Columns["nIngresoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgOtrosIngresosM.Columns["cTipoOtrosIngresosEvalRural"].HeaderText = "Tipo de Ingreso";
            dtgOtrosIngresosM.Columns["cPeriodoOtrosIngresosEvalRural"].HeaderText = "Periodo";
            dtgOtrosIngresosM.Columns["nCantidadItems"].HeaderText = "Cantidad";
            dtgOtrosIngresosM.Columns["nIngresoTotal"].HeaderText = "Ingreso Total";

            dtgOtrosIngresosM.Columns["cTipoOtrosIngresosEvalRural"].Visible = true;
            dtgOtrosIngresosM.Columns["cPeriodoOtrosIngresosEvalRural"].Visible = true;
            dtgOtrosIngresosM.Columns["nCantidadItems"].Visible = true;
            dtgOtrosIngresosM.Columns["nIngresoTotal"].Visible = true;
            dtgOtrosIngresosM.Columns["idOtrIngM"].Visible = false;
        }

        public void inicializarTablaOtrosEgresosMaestro() 
        {
            this.bsOtrosEgresosM = new BindingSource();

            this.bsOtrosEgresosM.DataSource = this.listOtrosEgresosMaestro;
            this.dtgvOtrosEgresosMaestro.DataSource = this.bsOtrosEgresosM;

            this.bsOtrosEgresosM.ResetBindings(false);
            this.dtgvOtrosEgresosMaestro.Refresh();

            dtgvOtrosEgresosMaestro.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgvOtrosEgresosMaestro.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgvOtrosEgresosMaestro.Columns["cNombreInsumo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosMaestro.Columns["cNombreInsumo"].HeaderText = "Tipo de Egreso";
            dtgvOtrosEgresosMaestro.Columns["cNombreInsumo"].Visible = true;
            dtgvOtrosEgresosMaestro.Columns["cNombreInsumo"].DisplayIndex = 1;

            dtgvOtrosEgresosMaestro.Columns["nPlazo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosMaestro.Columns["nPlazo"].HeaderText = "Plazo en meses";
            dtgvOtrosEgresosMaestro.Columns["nPlazo"].Visible = true;
            dtgvOtrosEgresosMaestro.Columns["nPlazo"].DisplayIndex = 2;

            dtgvOtrosEgresosMaestro.Columns["nEgresoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvOtrosEgresosMaestro.Columns["nEgresoTotal"].HeaderText = "Egreso Total";
            dtgvOtrosEgresosMaestro.Columns["nEgresoTotal"].Visible = true;
            dtgvOtrosEgresosMaestro.Columns["nEgresoTotal"].DefaultCellStyle.Format = "n2";
            dtgvOtrosEgresosMaestro.Columns["nEgresoTotal"].DisplayIndex = 3;

            dtgvOtrosEgresosMaestro.Columns["idOtrEgrM"].Visible = false;
        }

        public void inicializarTablaOtrosEgresosDetalle()
        {
            this.bsOtrosEgresosD = new BindingSource();

            this.bsOtrosEgresosD.DataSource = this.listOtrosEgresosDetalle;
            this.dtgvOtrosEgresosDetalle.DataSource = this.bsOtrosEgresosD;

            this.bsOtrosEgresosD.ResetBindings(false);
            this.dtgvOtrosEgresosDetalle.Refresh();

            dtgvOtrosEgresosDetalle.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgvOtrosEgresosDetalle.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = column.Name == "nGasto" ? true : false;
                column.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            }

            dtgvOtrosEgresosDetalle.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosDetalle.Columns["cDescripcion"].HeaderText = "Descripcion";
            dtgvOtrosEgresosDetalle.Columns["cDescripcion"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["cDescripcion"].DisplayIndex = 1;

            dtgvOtrosEgresosDetalle.Columns["nExtension"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosDetalle.Columns["nExtension"].HeaderText = "Extencion";
            dtgvOtrosEgresosDetalle.Columns["nExtension"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["nExtension"].DisplayIndex = 2;

            dtgvOtrosEgresosDetalle.Columns["nCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosDetalle.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgvOtrosEgresosDetalle.Columns["nCantidad"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["nCantidad"].DisplayIndex = 3;

            dtgvOtrosEgresosDetalle.Columns["nPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvOtrosEgresosDetalle.Columns["nPrecio"].HeaderText = "Precio";
            dtgvOtrosEgresosDetalle.Columns["nPrecio"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["nPrecio"].DisplayIndex = 4;

            dtgvOtrosEgresosDetalle.Columns["nGasto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvOtrosEgresosDetalle.Columns["nGasto"].HeaderText = "Total";
            dtgvOtrosEgresosDetalle.Columns["nGasto"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["nGasto"].DefaultCellStyle.BackColor = SystemColors.Window;
            dtgvOtrosEgresosDetalle.Columns["nGasto"].DefaultCellStyle.BackColor = SystemColors.Window;
            dtgvOtrosEgresosDetalle.Columns["nGasto"].DisplayIndex = 5;

            dtgvOtrosEgresosDetalle.Columns["cboFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOtrosEgresosDetalle.Columns["cboFecha"].HeaderText = "Fecha";
            dtgvOtrosEgresosDetalle.Columns["cboFecha"].Visible = true;
            dtgvOtrosEgresosDetalle.Columns["cboFecha"].DefaultCellStyle.BackColor = SystemColors.Window;
            dtgvOtrosEgresosDetalle.Columns["cboFecha"].DisplayIndex = 6;
        }

        private void FormatearDataGridView()
        {
            this.dtgOtrosIngresosM.Margin = new System.Windows.Forms.Padding(0);
            this.dtgOtrosIngresosM.MultiSelect = false;
            this.dtgOtrosIngresosM.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgOtrosIngresosM.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOtrosIngresosM.RowHeadersVisible = false;
            this.dtgOtrosIngresosM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dtgOtrosIngresosD.Margin = new System.Windows.Forms.Padding(0);
            this.dtgOtrosIngresosD.MultiSelect = false;
            this.dtgOtrosIngresosD.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgOtrosIngresosD.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgOtrosIngresosD.RowHeadersVisible = false;
            this.dtgOtrosIngresosD.SelectionMode = DataGridViewSelectionMode.CellSelect;

            this.dtgvOtrosEgresosMaestro.Margin = new System.Windows.Forms.Padding(0);
            this.dtgvOtrosEgresosMaestro.MultiSelect = false;
            this.dtgvOtrosEgresosMaestro.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvOtrosEgresosMaestro.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvOtrosEgresosMaestro.RowHeadersVisible = false;
            this.dtgvOtrosEgresosMaestro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dtgvOtrosEgresosDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.dtgvOtrosEgresosDetalle.MultiSelect = false;
            this.dtgvOtrosEgresosDetalle.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvOtrosEgresosDetalle.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvOtrosEgresosDetalle.RowHeadersVisible = false;
            this.dtgvOtrosEgresosDetalle.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void inicializarTablaOtrosIngresosDetalle(Guid idOtrIngM)
        {
            this.bsOtrosIngresosD = new BindingSource();

            var oMaestro = this.listOtrosIngresosMaestro.Find(x => x.idOtrIngM == idOtrIngM);

            var dtOtrosIngresos = convertirOtrosIngresos(oMaestro);

            this.bsOtrosIngresosD.DataSource = null;
            this.bsOtrosIngresosD.DataSource = dtOtrosIngresos;
            //Recuperar información del gridview y ponerle en el detalle
            this.dtgOtrosIngresosD.DataSource = null;
            this.dtgOtrosIngresosD.Refresh();
            this.dtgOtrosIngresosD.DataSource = bsOtrosIngresosD;

            dtgOtrosIngresosD.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgOtrosIngresosD.Columns)
            {
                column.Visible = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = column.Name == "nPrecioTotal" ? true : false;
                column.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (this.dtgOtrosIngresosD.Columns.Count > 0)
            {
                dtgOtrosIngresosD.Columns["idOtrIngM"].Visible = false;
                dtgOtrosIngresosD.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "n2";
                dtgOtrosIngresosD.Columns["nPrecioTotal"].DefaultCellStyle.Format = "n2";

                dtgOtrosIngresosD.Columns["nPrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgOtrosIngresosD.Columns["nPrecioTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtgOtrosIngresosD.Columns["dFechaCuota"].HeaderText = "Fecha";
                dtgOtrosIngresosD.Columns["nPrecioUnitario"].HeaderText = "Precio Unitario";
                dtgOtrosIngresosD.Columns["nPrecioTotal"].HeaderText = "Ingreso Total";

                dtgOtrosIngresosD.Columns["dFechaCuota"].DefaultCellStyle.BackColor = SystemColors.Window;
                dtgOtrosIngresosD.Columns["nPrecioTotal"].DefaultCellStyle.BackColor = SystemColors.Window;

                dtgOtrosIngresosD.Columns["dFechaCuota"].ReadOnly = true;
                dtgOtrosIngresosD.Columns["nFechaCuota"].Visible = false;

                dtgOtrosIngresosD.Columns["nPrecioTotal"].ReadOnly = true;
            }
        }

        private DataTable convertirOtrosIngresos(clsOtrosIngresosEvalRuralM oOtrosIngresosM)
        {
            DataTable dtOtrosIngresos = new DataTable();

            #region Generación de columnas
            dtOtrosIngresos.Columns.Add("idOtrIngM");
            dtOtrosIngresos.Columns.Add("dFechaCuota");
            dtOtrosIngresos.Columns.Add("nFechaCuota");


            StringBuilder sbExpresion = new StringBuilder();
            sbExpresion.Append("(");
            for (int i = 1; i <= oOtrosIngresosM.nCantidadItems; i++)
            {
                DataColumn dcItem = new DataColumn();
                string name = "item" + i;

                dcItem.ColumnName = "item" + i;
                dcItem.DataType = typeof(double);
                dcItem.DefaultValue = 0.0;

                dtOtrosIngresos.Columns.Add(dcItem);
                sbExpresion.Append(i == oOtrosIngresosM.nCantidadItems ? name : name + "+");
            }

            if (oOtrosIngresosM.idPeriodo == (int)Periodo.diario)
                sbExpresion.Append(") * nPrecioUnitario * 30");
            else
                sbExpresion.Append(") * nPrecioUnitario");

            DataColumn dcPreUnit = new DataColumn();
            dcPreUnit.ColumnName = "nPrecioUnitario";
            dcPreUnit.DataType = typeof(double);

            double nPrecioUnitario = 0.0;
            double.TryParse(txtPrecio.Text, out nPrecioUnitario);
            dcPreUnit.DefaultValue = nPrecioUnitario;
            dtOtrosIngresos.Columns.Add(dcPreUnit);

            DataColumn dcPrecioTotal = new DataColumn();
            dcPrecioTotal.ColumnName = "nPrecioTotal";
            dcPrecioTotal.Expression = sbExpresion.ToString();
            dcPrecioTotal.ReadOnly = true;
            dtOtrosIngresos.Columns.Add(dcPrecioTotal);
            #endregion

            #region Generación de filas

            var ListPlazo = oOtrosIngresosM.listaDetalle.Select(x => x.nFechaCuota).Distinct().ToList();


            foreach (var item in ListPlazo)
            {
                DataRow _row = dtOtrosIngresos.NewRow();
                var ListItems = oOtrosIngresosM.listaDetalle.FindAll(i => i.nFechaCuota == item);
                _row["idOtrIngM"] = ListItems.First().idOtrIngM;
                _row["dFechaCuota"] = ListItems.First().dFechaCuota;
                _row["nFechaCuota"] = ListItems.First().nFechaCuota;

                for (int x = 1; x <= oOtrosIngresosM.nCantidadItems; x++)
                {
                    var oDetalle = ListItems.Find(i => i.nItem == x);
                    _row["item" + x] = oDetalle.nCantidad;
                }

                _row["nPrecioUnitario"] = ListItems.First().nPrecioUnitario;

                dtOtrosIngresos.Rows.Add(_row);
            }
            #endregion

            return dtOtrosIngresos;
        }

        private void establecerOtrosIngresosD(clsOtrosIngresosEvalRuralM oMaestro)
        {
            //Generar dataTable con el detalle
            DataTable dtOtrosIngresos = convertirOtrosIngresos(oMaestro);

            this.bsOtrosIngresosD = new BindingSource();
            this.bsOtrosIngresosD.DataSource = dtOtrosIngresos;
            //Recuperar información del gridview y ponerle en el detalle
            this.dtgOtrosIngresosD.DataSource = null;
            this.dtgOtrosIngresosD.Refresh();
            this.dtgOtrosIngresosD.DataSource = bsOtrosIngresosD;

            this.bsOtrosIngresosM.ResetBindings(false);
            this.bsOtrosEgresosM.ResetBindings(false);
        }

        private void convertirOtrosIngresosToList(DataTable dtOtrosIngresosD, Guid idOtrIngM)
        {
            var oMaestro = this.listOtrosIngresosMaestro.Find(x => x.idOtrIngM == idOtrIngM);
            var oDetalle = oMaestro.listaDetalle;

            oMaestro.listaDetalle = new List<clsOtrosIngresosEvalRuralD>();
            foreach (DataRow row in dtOtrosIngresosD.Rows)
            {

                for (int i = 1; i <= oMaestro.nCantidadItems; i++)
                {
                    var oOtrosIngresos = new clsOtrosIngresosEvalRuralD();
                    oOtrosIngresos.idOtrIngM = oMaestro.idOtrIngM;
                    oOtrosIngresos.nItem = i;
                    oOtrosIngresos.dFechaCuota = row["dFechaCuota"].ToString();
                    oOtrosIngresos.nFechaCuota = Convert.ToInt32(row["nFechaCuota"]);
                    oOtrosIngresos.nOrden = i;
                    oOtrosIngresos.nCantidad = Convert.ToDecimal(row["item" + i]);
                    oOtrosIngresos.nPrecioUnitario = Convert.ToDecimal(row["nPrecioUnitario"]);
                    oOtrosIngresos.nTotal = oMaestro.idPeriodo == (int)Periodo.mensual ? oOtrosIngresos.nCantidad * oOtrosIngresos.nPrecioUnitario : oOtrosIngresos.nCantidad * oOtrosIngresos.nPrecioUnitario * 30;
                    oOtrosIngresos.idOtrIngD = oDetalle.Find(x => x.nItem == oOtrosIngresos.nItem && x.nFechaCuota == oOtrosIngresos.nFechaCuota).idOtrIngD;
                    oMaestro.listaDetalle.Add(oOtrosIngresos);
                }
            }

            oMaestro.nIngresoTotal = oMaestro.listaDetalle.Sum(x => x.nTotal);

        }

        private string OtrosIngresosRuralMEnXML(List<clsOtrosIngresosEvalRuralM> lstOtrosIngresosMaestro)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idOtrIngM", typeof(Guid));
            dt.Columns.Add("idTipo", typeof(int));
            dt.Columns.Add("idPeriodo", typeof(int));
            dt.Columns.Add("nCantidadItems", typeof(int));
            dt.Columns.Add("nIngresoTotal", typeof(decimal));
            dt.Columns.Add("nPlazo", typeof(int));


            foreach (var item in lstOtrosIngresosMaestro)
            {
                DataRow row = dt.NewRow();
                row["idOtrIngM"] = item.idOtrIngM;
                row["idTipo"] = item.idTipo;
                row["idPeriodo"] = item.idPeriodo;
                row["nCantidadItems"] = item.nCantidadItems;
                row["nIngresoTotal"] = item.nIngresoTotal;
                row["nPlazo"] = item.nPlazo;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "OtrosIngresosRuralM", "Item");
        }

        private string OtrosIngresosRuralDEnXML(List<clsOtrosIngresosEvalRuralM> lstOtrosIngresosMaestro)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idOtrIngD", typeof(Guid));
            dt.Columns.Add("idOtrIngM", typeof(Guid));
            dt.Columns.Add("dFechaCuota", typeof(string));
            dt.Columns.Add("nFechaCuota", typeof(int));
            dt.Columns.Add("nItem", typeof(int));
            dt.Columns.Add("nOrden", typeof(int));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPrecioUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));


            foreach (var maestro in lstOtrosIngresosMaestro)
            {
                foreach (var item in maestro.listaDetalle)
                {
                    DataRow row = dt.NewRow();
                    row["idOtrIngD"] = item.idOtrIngD;
                    row["idOtrIngM"] = item.idOtrIngM;
                    row["dFechaCuota"] = item.dFechaCuota;
                    row["nFechaCuota"] = item.nFechaCuota;
                    row["nItem"] = item.nItem;
                    row["nOrden"] = item.nOrden;
                    row["nCantidad"] = item.nCantidad;
                    row["nPrecioUnitario"] = item.nPrecioUnitario;
                    row["nTotal"] = item.nTotal;
                    dt.Rows.Add(row);
                }
            }

            return clsUtils.ConvertToXML(dt.Copy(), "OtrosIngresosRuralD", "Item");
        }

        private string OtrosEgresosRuralMEnXML(List<clsOtrosEgresosEvalRuralM> lstOtrosEgresosMaestro)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idOtrEgrM", typeof(Guid));
            dt.Columns.Add("idOtrIngM", typeof(Guid));
            dt.Columns.Add("cNombreInsumo", typeof(string));
            dt.Columns.Add("nEgresoTotal", typeof(decimal));
            dt.Columns.Add("nPlazo", typeof(int));


            foreach (var item in lstOtrosEgresosMaestro)
            {
                DataRow row = dt.NewRow();
                row["idOtrEgrM"] = item.idOtrEgrM;
                row["idOtrIngM"] = item.idOtrIngM;
                row["cNombreInsumo"] = item.cNombreInsumo;
                row["nEgresoTotal"] = item.nEgresoTotal;
                row["nPlazo"] = item.nPlazo;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "OtrosEgresosRuralM", "Item");
        }

        private string OtrosEgresosRuralDEnXML(List<clsOtrosEgresosEvalRuralD> lstOtrosEgresosDetalle)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idOtrEgrD", typeof(Guid));
            dt.Columns.Add("idOtrEgrM", typeof(Guid));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("nExtension", typeof(decimal));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPrecio", typeof(decimal));
            dt.Columns.Add("nGasto", typeof(decimal));
            dt.Columns.Add("nFecha", typeof(int));


            foreach (var item in lstOtrosEgresosDetalle)
            {
                DataRow row = dt.NewRow();
                row["idOtrEgrD"] = item.idOtrEgrD;
                row["idOtrEgrM"] = item.idOtrEgrM;
                row["cDescripcion"] = item.cDescripcion;
                row["nExtension"] = item.nExtension;
                row["nCantidad"] = item.nCantidad;
                row["nPrecio"] = item.nPrecio;
                row["nGasto"] = item.nGasto;
                row["nFecha"] = item.nFecha;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "OtrosEgresosRuralD", "Item");
        }

        private void CalcularTotalInsumos(Guid idOtrEgrM)
        {
            var listSumaGastos = this.listOtrosEgresosDetalle.Where(t => t.idOtrEgrM == idOtrEgrM).ToList();
            var nEgresoTotal = listSumaGastos.Sum(t => t.nGasto);
            this.txtTotalEgresos.Text = nEgresoTotal.ToString();
            this.txtTotalEgresos.Refresh();

            //this.listOtrosEgresosMaestro.Find(x => x.idOtrEgrM == idOtrEgrM).nEgresoTotal = nEgresoTotal;
            //this.bsOtrosEgresosM.ResetBindings(false);
        }

        #endregion


        #region Eventos

        private void dtgOtrosIngresosM_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgOtrosIngresosM.RowCount == 0)
            {
                //this.bsOtrosIngresosD.DataSource = null;
                this.dtgOtrosIngresosD.DataSource = null;
                this.dtgOtrosIngresosD.Refresh();
                return;
            }
               
            dtgBase dtg = (dtgBase)sender;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            if (dtg.SelectedRows.Count > 0)
            {
                dataGridViewRow = dtg.SelectedRows[0];

                DataGridViewRow selectedRow = dataGridViewRow;
                var idOtrIngM = Guid.Parse(selectedRow.Cells["idOtrIngM"].Value.ToString());

                inicializarTablaOtrosIngresosDetalle(idOtrIngM);
            }
        }

        private void dtgOtrosIngresosD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            dtgBase dtOtrosIngresos = (dtgBase)sender;
            DataGridViewRow row = dtgOtrosIngresosM.CurrentRow;
            Guid idOtrIngM = Guid.Parse(row.Cells["idOtrIngM"].Value.ToString());

            if (idOtrIngM != null || idOtrIngM != Guid.Empty)
            {
                BindingSource dbOtrosIngresos = new BindingSource();
                dbOtrosIngresos = (BindingSource)dtOtrosIngresos.DataSource;
                convertirOtrosIngresosToList((DataTable)dbOtrosIngresos.DataSource, idOtrIngM);
                dbOtrosIngresos.ResetBindings(false);
                dtgOtrosIngresosM.Refresh();
            }
        }

        private void btnGrabarOtrIng_click(object sender, EventArgs e)
        {
            if (btnGrabarOtrIngClick != null)
            btnGrabarOtrIngClick(sender, e);
        }

        private void btnAgregarOtroIngreso_Click(object sender, EventArgs e)
        {
            Guid idOtrIngM = Guid.NewGuid();
            Guid idOtrEgrM = Guid.NewGuid();

            //Insertar registro en Maestro
            var oOtrosIngresosM = new clsOtrosIngresosEvalRuralM();
            oOtrosIngresosM.idOtrIngM = idOtrIngM;
            oOtrosIngresosM.idEvalCred = this.idEvalCred;
            oOtrosIngresosM.idTipo = Convert.ToInt32(cboTipo.SelectedValue);
            oOtrosIngresosM.cTipoOtrosIngresosEvalRural = cboTipo.Text.ToString();
            oOtrosIngresosM.idPeriodo = Convert.ToInt32(cboPeriodo.SelectedValue);
            oOtrosIngresosM.cPeriodoOtrosIngresosEvalRural = cboPeriodo.Text.ToString();
            oOtrosIngresosM.nCantidadItems = (Convert.ToInt32(nudCantidad.Value.ToString()) != 0) ? Convert.ToInt32(nudCantidad.Value.ToString()) : 1;
            oOtrosIngresosM.nIngresoTotal = 0;
            oOtrosIngresosM.nPlazo = this.nPlazoCredMeses;

            var oOtrosEgresosM = new clsOtrosEgresosEvalRuralM();
            oOtrosEgresosM.idOtrEgrM = idOtrEgrM;
            oOtrosEgresosM.idOtrIngM = idOtrIngM;
            oOtrosEgresosM.idEvalCred = this.idEvalCred;
            oOtrosEgresosM.cNombreInsumo = oOtrosIngresosM.cTipoOtrosIngresosEvalRural;
            oOtrosEgresosM.nEgresoTotal = 0m;
            oOtrosEgresosM.nPlazo = this.nPlazoCredMeses;

            DateTime dFechaActualEval = this.dFecActualEval;

            //Generar registros detalle 
            for (int x = 0; x <= oOtrosIngresosM.nPlazo; x++)
            {
                for (int i = 0; i < oOtrosIngresosM.nCantidadItems; i++)
                {
                    var oOtrosIngresos = new clsOtrosIngresosEvalRuralD();
                    oOtrosIngresos.idOtrIngD = Guid.NewGuid();
                    oOtrosIngresos.idOtrIngM = idOtrIngM;
                    oOtrosIngresos.nItem = i + 1;
                    oOtrosIngresos.dFechaCuota = dFechaActualEval.AddMonths(x).ToString("MMM - yy");
                    oOtrosIngresos.nFechaCuota = Convert.ToInt32(dFechaActualEval.AddMonths(x).ToString("yyyyMM"));
                    oOtrosIngresos.nOrden = i + 1;
                    oOtrosIngresos.nCantidad = 0;
                    oOtrosIngresos.nPrecioUnitario = txtPrecio.nDecValor;
                    oOtrosIngresos.nTotal = oOtrosIngresos.nCantidad * oOtrosIngresos.nPrecioUnitario;
                    oOtrosIngresosM.listaDetalle.Add(oOtrosIngresos);
                }
            }

            this.listOtrosIngresosMaestro.Add(oOtrosIngresosM);
            this.listOtrosEgresosMaestro.Add(oOtrosEgresosM);

            establecerOtrosIngresosD(oOtrosIngresosM);

            if (this.dtgOtrosIngresosM.SelectedCells.Count > 0)
                this.btnQuitarOtroIngreso.Enabled = true;
        }

        private void btnQuitarOtroIngreso_Click(object sender, EventArgs e)
        {
            if (this.dtgOtrosIngresosM.RowCount == 0 || this.dtgOtrosIngresosM.Enabled == false ||
                 this.dtgOtrosIngresosM.SelectedCells.Count <= 0) return;

            int rowIndex = this.dtgOtrosIngresosM.SelectedCells[0].RowIndex;
            this.listOtrosIngresosMaestro.RemoveAt(rowIndex);

            var objEgresoMaestro = new clsOtrosEgresosEvalRuralM();

            foreach (var item in this.listOtrosEgresosMaestro)
            {
                if(this.listOtrosIngresosMaestro.FindAll(x => x.idOtrIngM == item.idOtrIngM).Count() <= 0)
                {
                    this.listOtrosEgresosDetalle.RemoveAll(x => x.idOtrEgrM == item.idOtrEgrM);
                    objEgresoMaestro = item;
                }
            }
            this.listOtrosEgresosMaestro.Remove(objEgresoMaestro);

            this.bsOtrosIngresosM.ResetBindings(false);
            this.bsOtrosEgresosM.ResetBindings(false);
            this.bsOtrosEgresosD.ResetBindings(false);

            this.dtgOtrosIngresosM.Refresh();
            this.dtgvOtrosEgresosMaestro.Refresh();
            this.dtgvOtrosEgresosDetalle.Refresh();

            if (this.dtgOtrosIngresosM.SelectedCells.Count == 0)
                this.btnQuitarOtroIngreso.Enabled = false;
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTipo.GetItemText(cboTipo.SelectedItem).ToString() == "OTROS")
            //{
            //    cboPeriodo.Enabled = false;
            //    txtPrecio.Enabled = false;
            //    nudCantidad.Enabled = false;
            //}
            //else
            //{
            //    cboPeriodo.Enabled = true;
            //    txtPrecio.Enabled = true;
            //    nudCantidad.Enabled = true;
            //}
        }

        private void tsmAgregarOtrosEgresos_Click(object sender, EventArgs e)
        {
            this.dtgvOtrosEgresosMaestro.SelectionChanged -= new System.EventHandler(this.dtgvOtrosEgresosMaestro_SelectionChanged);

            this.listOtrosEgresosDetalle.Add(new clsOtrosEgresosEvalRuralD()
            {
                idOtrEgrD = Guid.NewGuid(),
                idOtrEgrM = (Guid)this.dtgvOtrosEgresosMaestro.SelectedRows[0].Cells["idOtrEgrM"].Value,
                cDescripcion = "",
                nExtension = 0m,
                nCantidad = 0m,
                nPrecio = 0m,
                nFecha = this.listaPeriodos.FirstOrDefault().nFecha
            });

            var idOtrEgrM = (Guid)this.dtgvOtrosEgresosMaestro.SelectedRows[0].Cells["idOtrEgrM"].Value;
            var listOtrosEgresosD = this.listOtrosEgresosDetalle.FindAll(x => x.idOtrEgrM == idOtrEgrM);

            this.bsOtrosEgresosD.DataSource = listOtrosEgresosD;
            this.bsOtrosEgresosD.ResetBindings(false);
            this.dtgvOtrosEgresosDetalle.Refresh();
            this.dtgvOtrosEgresosDetalle.DataSource = this.bsOtrosEgresosD;

            if (listOtrosEgresosD.Count > 0)
                this.tsmQuitarOtrosEgresos.Enabled = true;
            else
                this.tsmQuitarOtrosEgresos.Enabled = false;

            this.dtgvOtrosEgresosMaestro.SelectionChanged += new System.EventHandler(this.dtgvOtrosEgresosMaestro_SelectionChanged);
        }

        private void tsmQuitarOtrosEgresos_Click(object sender, EventArgs e)
        {
            if (this.dtgvOtrosEgresosDetalle.RowCount == 0 || this.dtgvOtrosEgresosDetalle.Enabled == false ||
                this.dtgvOtrosEgresosDetalle.SelectedCells.Count <= 0) return;

            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            int rowIndex = this.dtgvOtrosEgresosDetalle.SelectedCells[0].RowIndex;
            this.listOtrosEgresosDetalle.RemoveAt(rowIndex);

            dataGridViewRow = this.dtgvOtrosEgresosDetalle.Rows[rowIndex];

            var idOtrEgrM = (Guid)this.dtgvOtrosEgresosMaestro.SelectedRows[0].Cells["idOtrEgrM"].Value;
            var listOtrosEgresosD = this.listOtrosEgresosDetalle.FindAll(x => x.idOtrEgrM == idOtrEgrM);

            this.bsOtrosEgresosD.DataSource = listOtrosEgresosD;
            this.bsOtrosEgresosD.ResetBindings(false);
            this.dtgvOtrosEgresosDetalle.Refresh();
            this.dtgvOtrosEgresosDetalle.DataSource = this.bsOtrosEgresosD;

            if (this.dtgvOtrosEgresosDetalle.SelectedCells.Count == 0)
                this.tsmQuitarOtrosEgresos.Enabled = false;
        }

        private void dtgvOtrosEgresosMaestro_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgvOtrosEgresosMaestro.RowCount == 0 || this.dtgvOtrosEgresosMaestro.Enabled == false)
            {
                //this.bsOtrosEgresosD.DataSource = null;
                this.tsmQuitarOtrosEgresos.Enabled = false;
                return;
            }

            dtgBase dtg = (dtgBase)sender;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();

            if (dtg.SelectedCells.Count > 0)
            {
                int rowIndex = this.dtgvOtrosEgresosMaestro.SelectedCells[0].RowIndex;
                dataGridViewRow = this.dtgvOtrosEgresosMaestro.Rows[rowIndex];

                var idOtrEgrM = Guid.Parse(dataGridViewRow.Cells["idOtrEgrM"].Value.ToString());
                var listOtrosEgresosD = this.listOtrosEgresosDetalle.FindAll(x => x.idOtrEgrM == idOtrEgrM);
                this.bsOtrosEgresosD.DataSource = listOtrosEgresosD;
                this.bsOtrosEgresosD.ResetBindings(false);
                this.dtgvOtrosEgresosDetalle.Refresh();
                this.dtgvOtrosEgresosDetalle.DataSource = this.bsOtrosEgresosD;

                CalcularTotalInsumos(idOtrEgrM);
            }
        }

        private void dtgvOtrosEgresosDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.IntegralHeight = false;
                cb.MaxDropDownItems = 12;
            }
        }

        #endregion

    }
}
