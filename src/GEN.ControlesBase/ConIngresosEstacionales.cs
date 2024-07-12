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
using CRE.ControlBase;
using System.Globalization;

namespace GEN.ControlesBase
{
    public partial class ConIngresosEstacionales : UserControl
    {
        #region Variables

        private List<clsProyeccionIngresos> listProyeccionIngresos;
        private List<clsInversionInsumo> listInsumos;

        private BindingSource bsProyeccionIngresos;
        private DataGridViewRow rowIngresoSeleccionado = null;
        private Guid idIngresoEstacional;

        private string cMsjCaption = "Ingreso y Egreso por Actividades";
        private bool lNuevoRegistro = true;
        private int nIndexEditado = -1;
        private bool lPeriodo = false;
        private bool lEditandoIng = false;

        private DateTime dFechaDesembolso;
        private int nCuotas;

        #endregion


        #region Metodos Publicos

        public ConIngresosEstacionales()
        {
            InitializeComponent();
        }

        public void inicializarControl()
        {
            this.listInsumos = new List<clsInversionInsumo>();
            this.listProyeccionIngresos = new List<clsProyeccionIngresos>();

            InicializarTablaIngresosEstacionales();
            FormatearDataGridView();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;

            HabilitarFormulario(false);
        }

        public void AsignarDatos(List<clsProyeccionIngresos> _listIngresos, List<clsInversionInsumo> _lstInsumos, int _cuotas, DateTime _fechaDesembolso)
        {
            this.nCuotas = _cuotas;
            this.dFechaDesembolso = _fechaDesembolso;
            EstablecerFechaPorCuotas();

            this.listProyeccionIngresos.Clear();
            this.listInsumos.Clear();

            foreach (var item in _listIngresos)
            {
                this.listProyeccionIngresos.Add(item);
            }

            foreach (var item in _lstInsumos)
            {
                this.listInsumos.Add(item);
            }

            this.bsProyeccionIngresos.ResetBindings(false);

            foreach (DataGridViewRow item in this.dtgIngresosEstacionales.Rows)
            {
                decimal montoInversion = Convert.ToDecimal(item.Cells["nMontoInversionTotal"].Value);
                if (montoInversion > 0)
                {
                    item.Cells["ckboxInversionRealizada"].Value = true;
                }
                else
                {
                    item.Cells["ckboxInversionRealizada"].Value = false;
                }
            }

            LimpiarFormulario();
        }

        public bool FrecuenciaFechaInicioEnabled
        {
            get
            {
                return this.lPeriodo;
            }
            set
            {
                this.lPeriodo = value;
            }
        }

        public void HabilitarFormulario(bool lHabilitado)
        {
            this.cboCultivoEval.Enabled = lHabilitado;
            this.cboVariedadCultivoEval.Enabled = lHabilitado;
            this.txtParcela.Enabled = lHabilitado;
            this.cboUnidadMedida.Enabled = lHabilitado;
            this.cboEtapaProduccion.Enabled = lHabilitado;
            this.cboCondicionTenencia.Enabled = lHabilitado;
            this.cboCondicionTerreno.Enabled = lHabilitado;
            this.nudPrecioVenta.Enabled = lHabilitado;
            this.cboFecha.Enabled = lHabilitado;
            this.cboUnidadMedida.Enabled = lHabilitado;
            this.nudRendAnterior.Enabled = lHabilitado;
            this.nudRendMinimo.Enabled = lHabilitado;
            this.nudRendMaximo.Enabled = lHabilitado;
            this.nudExtension.Enabled = lHabilitado;
            this.cboMoneda.Enabled = false;
        }

        public void LimpiarFormulario()
        {
            this.cboCultivoEval.SelectedValue = -1;
            this.cboVariedadCultivoEval.SelectedValue = -1;
            this.txtParcela.Text = string.Empty;
            this.nudExtension.Value = decimal.Zero;
            this.cboMoneda.SelectedValue = -1;
            this.cboUnidadMedida.SelectedValue = -1;
            this.cboEtapaProduccion.SelectedValue = -1;
            this.cboCondicionTerreno.SelectedValue = -1;
            this.cboCondicionTenencia.SelectedValue = -1;
            this.nudPrecioVenta.Value = decimal.Zero;
            this.cboFecha.SelectedValue = -1;
            this.nudRendAnterior.Value = decimal.Zero;
            this.nudRendMinimo.Value = decimal.Zero;
            this.nudRendMaximo.Value = decimal.Zero;
        }

        public List<clsProyeccionIngresos> ExportListaIngresos()
        {
            var listaIngresos = this.listProyeccionIngresos;
            return listaIngresos;
        }

        public List<clsInversionInsumo> ExportListaInversionInsumos()
        {
            List<clsInversionInsumo> listaInsumos = new List<clsInversionInsumo>();

            foreach (var item in this.listProyeccionIngresos)
            {
                if (item.listaInversionInsumo != null)
                {
                    listaInsumos.AddRange(item.listaInversionInsumo);
                }
            }
            return listaInsumos;
        }

        #endregion


        #region Métodos Privados

        private void InicializarTablaIngresosEstacionales()
        {
            this.bsProyeccionIngresos = new BindingSource();
            this.bsProyeccionIngresos.DataSource = this.listProyeccionIngresos;
            this.dtgIngresosEstacionales.DataSource = this.bsProyeccionIngresos;

            this.bsProyeccionIngresos.ResetBindings(false);
            this.dtgIngresosEstacionales.Refresh();

            DataGridViewButtonColumn dgvbtnIngresos = new DataGridViewButtonColumn();
            dgvbtnIngresos.Name = "btnCalcular";
            dgvbtnIngresos.Text = "...";
            dgvbtnIngresos.UseColumnTextForButtonValue = true;
            this.dtgIngresosEstacionales.Columns.Add(dgvbtnIngresos);

            DataGridViewCheckBoxColumn dgvCheckInversion = new DataGridViewCheckBoxColumn();
            dgvCheckInversion.Name = "ckboxInversionRealizada";
            dgvCheckInversion.TrueValue = "1";
            dgvCheckInversion.FalseValue = "0";
            this.dtgIngresosEstacionales.Columns.Add(dgvCheckInversion);

            this.dtgIngresosEstacionales.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgIngresosEstacionales.Columns)
            {
                column.ReadOnly= true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIngresosEstacionales.Columns["cParcela"].DisplayIndex = 0;
            dtgIngresosEstacionales.Columns["nExtension"].DisplayIndex = 1;
            dtgIngresosEstacionales.Columns["cCultivo"].DisplayIndex = 2;
            dtgIngresosEstacionales.Columns["cVariedad"].DisplayIndex = 3;
            dtgIngresosEstacionales.Columns["cEtapaProduccion"].DisplayIndex = 4;
            dtgIngresosEstacionales.Columns["cCondicionTerreno"].DisplayIndex = 5;
            dtgIngresosEstacionales.Columns["cCondicionTenencia"].DisplayIndex = 6;
            dtgIngresosEstacionales.Columns["cUnidad"].DisplayIndex = 7;
            dtgIngresosEstacionales.Columns["nRendAnterior"].DisplayIndex = 8;
            dtgIngresosEstacionales.Columns["nRendMinimo"].DisplayIndex = 9;
            dtgIngresosEstacionales.Columns["nRendMaximo"].DisplayIndex = 10;
            dtgIngresosEstacionales.Columns["nRendPonderado"].DisplayIndex = 11;
            dtgIngresosEstacionales.Columns["nCantidadVenta"].DisplayIndex = 12;
            dtgIngresosEstacionales.Columns["nPrecioVenta"].DisplayIndex = 13;
            dtgIngresosEstacionales.Columns["nIngresos"].DisplayIndex = 14;
            dtgIngresosEstacionales.Columns["cFechaTabla"].DisplayIndex = 15;
            dtgIngresosEstacionales.Columns["ckboxInversionRealizada"].DisplayIndex = 16;
            dtgIngresosEstacionales.Columns["btnCalcular"].DisplayIndex = 17;
            dtgIngresosEstacionales.Columns["nMontoInversionTotal"].DisplayIndex = 18;

            dtgIngresosEstacionales.Columns["cParcela"].Visible = true;
            dtgIngresosEstacionales.Columns["nExtension"].Visible = true;
            dtgIngresosEstacionales.Columns["cCultivo"].Visible = true;
            dtgIngresosEstacionales.Columns["cVariedad"].Visible = true;
            dtgIngresosEstacionales.Columns["cEtapaProduccion"].Visible = true;
            dtgIngresosEstacionales.Columns["cCondicionTerreno"].Visible = true;
            dtgIngresosEstacionales.Columns["cCondicionTenencia"].Visible = true;
            dtgIngresosEstacionales.Columns["cUnidad"].Visible = true;
            dtgIngresosEstacionales.Columns["nRendAnterior"].Visible = true;
            dtgIngresosEstacionales.Columns["nRendMinimo"].Visible = true;
            dtgIngresosEstacionales.Columns["nRendMaximo"].Visible = true;
            dtgIngresosEstacionales.Columns["nRendPonderado"].Visible = true;
            dtgIngresosEstacionales.Columns["nCantidadVenta"].Visible = true;
            dtgIngresosEstacionales.Columns["nPrecioVenta"].Visible = true;
            dtgIngresosEstacionales.Columns["nIngresos"].Visible = true;
            dtgIngresosEstacionales.Columns["cFechaTabla"].Visible = true;
            dtgIngresosEstacionales.Columns["nMontoInversionTotal"].Visible = true;
            dtgIngresosEstacionales.Columns["btnCalcular"].Visible = true;
            dtgIngresosEstacionales.Columns["ckboxInversionRealizada"].Visible = true;

            dtgIngresosEstacionales.Columns["cParcela"].HeaderText = "Parcela";
            dtgIngresosEstacionales.Columns["nExtension"].HeaderText = "Extensión";
            dtgIngresosEstacionales.Columns["cCultivo"].HeaderText = "Cultivo";
            dtgIngresosEstacionales.Columns["cVariedad"].HeaderText = "Variedad";
            dtgIngresosEstacionales.Columns["cEtapaProduccion"].HeaderText = "Eta. Producción";
            dtgIngresosEstacionales.Columns["cCondicionTerreno"].HeaderText = "Con. Terreno";
            dtgIngresosEstacionales.Columns["cCondicionTenencia"].HeaderText = "Con. Tenencia";
            dtgIngresosEstacionales.Columns["cUnidad"].HeaderText = "Unid. Med.";
            dtgIngresosEstacionales.Columns["nRendAnterior"].HeaderText = "";
            dtgIngresosEstacionales.Columns["nRendMinimo"].HeaderText = "";
            dtgIngresosEstacionales.Columns["nRendMaximo"].HeaderText = "";
            dtgIngresosEstacionales.Columns["nRendPonderado"].HeaderText = "Ren. POND/HAS";
            dtgIngresosEstacionales.Columns["nPrecioVenta"].HeaderText = "Pre. Venta";
            dtgIngresosEstacionales.Columns["nCantidadVenta"].HeaderText = "Cant. para Venta";
            dtgIngresosEstacionales.Columns["nIngresos"].HeaderText = "Ingresos";
            dtgIngresosEstacionales.Columns["cFechaTabla"].HeaderText = "Fecha";
            dtgIngresosEstacionales.Columns["nMontoInversionTotal"].HeaderText = "";
            dtgIngresosEstacionales.Columns["btnCalcular"].HeaderText = "";
            dtgIngresosEstacionales.Columns["ckboxInversionRealizada"].HeaderText = "";

            dtgIngresosEstacionales.Columns["cParcela"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["nExtension"].FillWeight = 40;
            dtgIngresosEstacionales.Columns["cCultivo"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["cVariedad"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["cEtapaProduccion"].FillWeight = 50;
            dtgIngresosEstacionales.Columns["cCondicionTerreno"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["cCondicionTenencia"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["cUnidad"].FillWeight = 35;
            dtgIngresosEstacionales.Columns["nRendAnterior"].FillWeight = 40;
            dtgIngresosEstacionales.Columns["nRendMinimo"].FillWeight = 40;
            dtgIngresosEstacionales.Columns["nRendMaximo"].FillWeight = 40;
            dtgIngresosEstacionales.Columns["nRendPonderado"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["nPrecioVenta"].FillWeight = 40;
            dtgIngresosEstacionales.Columns["nCantidadVenta"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["nIngresos"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["cFechaTabla"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["nMontoInversionTotal"].FillWeight = 45;
            dtgIngresosEstacionales.Columns["btnCalcular"].FillWeight = 30;
            dtgIngresosEstacionales.Columns["ckboxInversionRealizada"].FillWeight = 20;

            dtgIngresosEstacionales.Columns["nPrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresosEstacionales.Columns["nCantidadVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresosEstacionales.Columns["nIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgIngresosEstacionales.Columns["nRendAnterior"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nRendMinimo"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nRendMaximo"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nRendPonderado"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nPrecioVenta"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nCantidadVenta"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nIngresos"].DefaultCellStyle.Format = "n2";
            dtgIngresosEstacionales.Columns["nMontoInversionTotal"].DefaultCellStyle.Format = "n2";
        }

        private void FormatearDataGridView()
        {
            this.dtgIngresosEstacionales.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIngresosEstacionales.MultiSelect = false;
            this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIngresosEstacionales.RowHeadersVisible = false;
            this.dtgIngresosEstacionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RegistrarProyeccionIngresos()
        {
            this.listProyeccionIngresos.Add(new clsProyeccionIngresos()
            {
                idIngresoEstacional = Guid.NewGuid(),
                idCultivo = Convert.ToInt32(this.cboCultivoEval.SelectedValue),
                cCultivo = this.cboCultivoEval.Text,
                idVariedad = Convert.ToInt32(this.cboVariedadCultivoEval.SelectedValue),
                cVariedad = this.cboVariedadCultivoEval.Text,
                cParcela = this.txtParcela.Text,
                nExtension = nudExtension.Value,
                idUnidad = Convert.ToInt32(this.cboUnidadMedida.SelectedValue),
                cUnidad = this.cboUnidadMedida.Text,
                idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue),
                idEtapaProduccion = Convert.ToInt32(this.cboEtapaProduccion.SelectedValue),
                cEtapaProduccion = this.cboEtapaProduccion.Text,
                idCondicionTerreno = Convert.ToInt32(this.cboCondicionTerreno.SelectedValue),
                cCondicionTerreno = this.cboCondicionTerreno.Text,
                idCondicionTenencia = Convert.ToInt32(this.cboCondicionTenencia.SelectedValue),
                cCondicionTenencia = this.cboCondicionTenencia.Text,
                nRendAnterior = nudRendAnterior.Value,
                nRendMinimo = nudRendMinimo.Value,
                nRendMaximo = nudRendMaximo.Value,
                nPrecioVenta = nudPrecioVenta.Value,
                nFecha = Convert.ToInt32(this.cboFecha.SelectedValue),
                cFechaTabla = Convert.ToDateTime(DateTime.ParseExact(this.cboFecha.SelectedValue.ToString(), "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None)).ToString("MM - yyyy").ToString(),
                lInversionRealizada = false
            });

            this.bsProyeccionIngresos.ResetBindings(false);
        }

        private void ActualizarProyeccionIngresos()
        {
            var item = this.listProyeccionIngresos.Find(x => x.idIngresoEstacional == this.idIngresoEstacional);

            item.idCultivo = Convert.ToInt32(this.cboCultivoEval.SelectedValue);
            item.cCultivo = this.cboCultivoEval.Text;
            item.idVariedad = Convert.ToInt32(this.cboVariedadCultivoEval.SelectedValue);
            item.cVariedad = this.cboVariedadCultivoEval.Text;
            item.cParcela = this.txtParcela.Text;
            item.nExtension = nudExtension.Value;
            item.idUnidad = Convert.ToInt32(this.cboUnidadMedida.SelectedValue);
            item.cUnidad = this.cboUnidadMedida.Text;
            item.idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
            item.idEtapaProduccion = Convert.ToInt32(this.cboEtapaProduccion.SelectedValue);
            item.cEtapaProduccion = this.cboEtapaProduccion.Text;
            item.idCondicionTerreno = Convert.ToInt32(this.cboCondicionTerreno.SelectedValue);
            item.cCondicionTerreno = this.cboCondicionTerreno.Text;
            item.idCondicionTenencia = Convert.ToInt32(this.cboCondicionTenencia.SelectedValue);
            item.cCondicionTenencia = this.cboCondicionTenencia.Text;
            item.nRendAnterior = nudRendAnterior.Value;
            item.nRendMinimo = nudRendMinimo.Value;
            item.nRendMaximo = nudRendMaximo.Value;
            item.nPrecioVenta = nudPrecioVenta.Value;
            item.nFecha = Convert.ToInt32(this.cboFecha.SelectedValue);
            item.cFechaTabla = Convert.ToDateTime(DateTime.ParseExact(this.cboFecha.SelectedValue.ToString(), "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None)).ToString("MM - yyyy").ToString();

            LimpiarFormulario();
            this.HabilitarFormulario(false);

            this.bsProyeccionIngresos.ResetBindings(false);
        }

        private void QuitarProyeccionIngresos()
        {
            var item = this.listProyeccionIngresos.Find(x => x.idIngresoEstacional == this.idIngresoEstacional);
            this.listProyeccionIngresos.Remove(item);
            this.bsProyeccionIngresos.ResetBindings(false);
        }

        private void EstablecerFechaPorCuotas()
        {
            int nCuotas = Convert.ToInt32(clsVarApl.dicVarGen["nPlazoMaxEvalRural"]);

            clsPeriodoCuotas oPeriodoCuotas = new clsPeriodoCuotas();

            List<clsPeriodoCuotas> listaPeriodos = new List<clsPeriodoCuotas>();

            for (int x = 0; x < nCuotas; x++)
            {
                DateTime dFechaTmp = this.dFechaDesembolso.AddMonths(x);
                oPeriodoCuotas = new clsPeriodoCuotas();
                oPeriodoCuotas.nFecha = Convert.ToInt32(dFechaTmp.ToString("yyyyMM"));
                oPeriodoCuotas.cdescripcion = dFechaTmp.ToString("MMM - yy"); 
                listaPeriodos.Add(oPeriodoCuotas);
            }

            this.cboFecha.DataSource = listaPeriodos;
            this.cboFecha.ValueMember = "nFecha";
            this.cboFecha.DisplayMember = "cdescripcion";
        }

        private bool validarFormulario()
        {
            if (this.cboCultivoEval.SelectedValue == null || Convert.ToInt32(this.cboCultivoEval.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de cultivo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboCultivoEval.Focus();
                return false;
            }
            if (this.cboVariedadCultivoEval.SelectedValue == null || Convert.ToInt32(this.cboVariedadCultivoEval.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la variedad", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboVariedadCultivoEval.Focus();
                return false;
            }
            if (this.txtParcela.Text == string.Empty)
            {
                MessageBox.Show("Debe asignarle un nombre a la parcela", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtParcela.Focus();
                return false;
            }
            if (this.nudExtension.Value <= decimal.Zero)
            {
                MessageBox.Show("La extención debe ser mayor a 0", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudExtension.Focus();
                return false;
            }
            if (this.cboMoneda.SelectedValue == null || Convert.ToInt32(this.cboMoneda.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de moneda", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboMoneda.Focus();
                return false;
            }
            if (this.cboUnidadMedida.SelectedValue == null || Convert.ToInt32(this.cboUnidadMedida.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la unidad de medida", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUnidadMedida.Focus();
                return false;
            }
            if (this.cboEtapaProduccion.SelectedValue == null || Convert.ToInt32(this.cboEtapaProduccion.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la etapa de producción", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEtapaProduccion.Focus();
                return false;
            }
            if (this.cboCondicionTerreno.SelectedValue == null || Convert.ToInt32(this.cboCondicionTerreno.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la condición de terreno", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboCondicionTerreno.Focus();
                return false;
            }
            if (this.cboCondicionTenencia.SelectedValue == null || Convert.ToInt32(this.cboCondicionTenencia.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la condición de tenencia", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboCondicionTenencia.Focus();
                return false;
            }
            if (this.nudPrecioVenta.Value <= decimal.Zero)
            {
                MessageBox.Show("El precio de venta debe ser mayor a 0", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudPrecioVenta.Focus();
                return false;
            }
            if(this.cboFecha.SelectedValue == null || Convert.ToInt32(this.cboFecha.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la fecha", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFecha.Focus();
                return false;
            }
            if (this.nudRendAnterior.Value <= decimal.Zero)
            {
                MessageBox.Show("El rendimiento anterior debe ser mayor a 0", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudRendAnterior.Focus();
                return false;
            }
            if (this.nudRendMinimo.Value <= decimal.Zero)
            {
                MessageBox.Show("El rendimiento minimo debe ser mayor a 0", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudRendMinimo.Focus();
                return false;
            }
            if (this.nudRendMaximo.Value <= decimal.Zero)
            {
                MessageBox.Show("El rendimiento maximo debe ser mayor a 0", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudRendMaximo.Focus();
                return false;
            }
            if (this.nudRendMinimo.Value > this.nudRendMaximo.Value)
            {
                MessageBox.Show("El rendimiento maximo debe ser mayor al rendimiento minimo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudRendAnterior.Focus();
                return false;
            }
            if ((this.nudRendMinimo.Value >= this.nudRendAnterior.Value) && (this.nudRendAnterior.Value >= this.nudRendMaximo.Value))
            {
                MessageBox.Show("El rendimiento anterior debe estar dentro del rango", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.nudRendAnterior.Focus();
                return false;
            }

            return true;
        }

        #endregion


        #region Eventos

        private void cboCultivoEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCultivoEval.SelectedItem == null) return;

            this.cboVariedadCultivoEval.DataSource = null;

            int TipoVariedad = Convert.ToInt32(this.cboCultivoEval.SelectedValue);

            cboVariedadCultivoEval.CargaVariedadPorCultivo(TipoVariedad);
        }

        //Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(true);

            this.cboMoneda.SelectedValue = 1; //SOLES

            this.btnNuevo.Enabled = false;
            this.btnAgregar.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnEditar.Enabled = false;

            this.rowIngresoSeleccionado = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
                return;

            RegistrarProyeccionIngresos();
            this.dtgIngresosEstacionales_DataBindingComplete(null, null);
            LimpiarFormulario();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;

            this.HabilitarFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
                return;

            ActualizarProyeccionIngresos();
            this.dtgIngresosEstacionales_DataBindingComplete(null, null);

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lEditandoIng = false;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea quitar el registo?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                QuitarProyeccionIngresos();
                this.dtgIngresosEstacionales_DataBindingComplete(null, null);

                this.btnNuevo.Enabled = true;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(false);
            LimpiarFormulario();
            this.dtgIngresosEstacionales.ClearSelection();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lEditandoIng = false;
        }

        private void dtgIngresosEstacionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == this.dtgIngresosEstacionales.Columns["btnCalcular"].Index)
            {
                this.btnCalcular_Click(sender, e);
                return;
            }

            if (this.dtgIngresosEstacionales.SelectedRows.Count == 0)
                return;
            

            if (this.lEditandoIng)
                return;

            this.rowIngresoSeleccionado = this.dtgIngresosEstacionales.SelectedRows[0];
            this.idIngresoEstacional = (Guid)this.dtgIngresosEstacionales.SelectedRows[0].Cells["idIngresoEstacional"].Value;

            this.btnQuitar.Enabled = true;
        }

        private void dtgIngresosEstacionales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (this.dtgIngresosEstacionales.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowIngresoSeleccionado = this.dtgIngresosEstacionales.SelectedRows[0];
            this.idIngresoEstacional = (Guid)this.dtgIngresosEstacionales.SelectedRows[0].Cells["idIngresoEstacional"].Value;

            int idCultivo = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idCultivo"].Value);
            int idVariedad = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idVariedad"].Value);
            string cParcela = this.dtgIngresosEstacionales.SelectedRows[0].Cells["cParcela"].Value.ToString();
            decimal nExtension = Convert.ToDecimal(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nExtension"].Value);
            int idMoneda = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idMoneda"].Value);
            int idUnidad = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idUnidad"].Value);
            int idEtapaProduccion = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idEtapaProduccion"].Value);
            int idCondicionTerreno = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idCondicionTerreno"].Value);
            int idCondicionTenencia = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["idCondicionTenencia"].Value);
            int nPrecioVenta = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nPrecioVenta"].Value);
            int nFecha = Convert.ToInt32(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nFecha"].Value);
            decimal nRendAnterior = Convert.ToDecimal(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nRendAnterior"].Value);
            decimal nRendMinimo = Convert.ToDecimal(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nRendMinimo"].Value);
            decimal nRendMaximo = Convert.ToDecimal(this.dtgIngresosEstacionales.SelectedRows[0].Cells["nRendMaximo"].Value);

            this.cboCultivoEval.SelectedValue = idCultivo;
            this.cboVariedadCultivoEval.SelectedValue = idVariedad;
            this.txtParcela.Text = cParcela;
            this.nudExtension.Value = nExtension;
            this.cboMoneda.SelectedValue = idMoneda;
            this.cboUnidadMedida.SelectedValue = idUnidad;
            this.cboEtapaProduccion.SelectedValue = idEtapaProduccion;
            this.cboCondicionTerreno.SelectedValue = idCondicionTerreno;
            this.cboCondicionTenencia.SelectedValue = idCondicionTenencia;
            this.nudPrecioVenta.Value = nPrecioVenta;
            this.cboFecha.SelectedValue = nFecha;
            this.nudRendAnterior.Value = nRendAnterior;
            this.nudRendMinimo.Value = nRendMinimo;
            this.nudRendMaximo.Value = nRendMaximo;

            this.HabilitarFormulario(true);

            this.lEditandoIng = true;
            this.btnNuevo.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        //Calculo de inversión
        private void dtgIngresosEstacionales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in this.dtgIngresosEstacionales.Rows)
            {
                decimal montoInversion = Convert.ToDecimal(item.Cells["nMontoInversionTotal"].Value);
                if (montoInversion > 0)
                {
                    item.Cells["ckboxInversionRealizada"].Value = true;
                }
                else
                {
                    item.Cells["ckboxInversionRealizada"].Value = false;
                }
            }

            this.dtgIngresosEstacionales.Refresh();
        }

        private void btnCalcular_Click(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgIngresosEstacionales.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresosEstacionales_DataBindingComplete);

            List<clsInversionInsumo> listaInsumo = new List<clsInversionInsumo>();

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = this.dtgIngresosEstacionales.Rows[e.RowIndex];

            Guid idIngresoEstacional = (Guid)row.Cells["idIngresoEstacional"].Value;
            string cultivo = row.Cells["cCultivo"].Value.ToString();
            string variedad = row.Cells["cVariedad"].Value.ToString();
            string parcela = row.Cells["cParcela"].Value.ToString();

            listaInsumo = this.listProyeccionIngresos.Find(x => x.idIngresoEstacional.Equals(idIngresoEstacional)).listaInversionInsumo;

            if (listaInsumo == null)
                listaInsumo = this.listInsumos.Where(t => t.idProyeccionIngreso.Equals(idIngresoEstacional)).ToList();

            frmCalculadoraInversionRealizada frmCalculadora = new frmCalculadoraInversionRealizada(listaInsumo, idIngresoEstacional);

            if (listaInsumo.Count == 0)
            {
                frmCalculadora.EstablecerDatosInsumo(cultivo, variedad, parcela);
                frmCalculadora.ShowDialog();
            }
            else
            {
                frmCalculadora.EstablecerDatosInsumo(cultivo, variedad, parcela);
                frmCalculadora.ShowDialog();
            }

            listaInsumo = frmCalculadora.ObtenerInversionInsumos();

            this.listProyeccionIngresos.Find(x => x.idIngresoEstacional.Equals(idIngresoEstacional)).listaInversionInsumo = listaInsumo;

            this.dtgIngresosEstacionales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIngresosEstacionales_DataBindingComplete);
            dtgIngresosEstacionales_DataBindingComplete(null, null);
            this.bsProyeccionIngresos.ResetBindings(false);
        }

        private void dtgIngresosEstacionales_Paint(object sender, PaintEventArgs e)
        {
            //Se valida para evitar quue le diseñador muestre un error de nulos
            if (this.dtgIngresosEstacionales.Columns.Count <= 2) // El 2 hace referencia al checkBox y el boton cargados
                return;

            int c1 = this.dtgIngresosEstacionales.Columns["ckboxInversionRealizada"].Index;
            int c2 = this.dtgIngresosEstacionales.Columns["btnCalcular"].Index;
            int c3 = this.dtgIngresosEstacionales.Columns["nMontoInversionTotal"].Index;
            int c4 = this.dtgIngresosEstacionales.Columns["nRendAnterior"].Index;
            int c5 = this.dtgIngresosEstacionales.Columns["nRendMinimo"].Index;
            int c6 = this.dtgIngresosEstacionales.Columns["nRendMaximo"].Index;
            int altura = this.dtgIngresosEstacionales.Columns["nMontoInversionTotal"].HeaderCell.Size.Height;

            StringFormat formatoTexto = new StringFormat();
            formatoTexto.Alignment = StringAlignment.Center;
            formatoTexto.LineAlignment = StringAlignment.Center;

            Rectangle encabezadoInvRealizada = dtgIngresosEstacionales.GetCellDisplayRectangle(c1, -1, true);
            encabezadoInvRealizada.Width = this.dtgIngresosEstacionales.GetCellDisplayRectangle(c1, -1, true).Width +
                                          this.dtgIngresosEstacionales.GetCellDisplayRectangle(c2, -1, true).Width +
                                          this.dtgIngresosEstacionales.GetCellDisplayRectangle(c3, -1, true).Width;
            encabezadoInvRealizada.Height = altura;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightSlateGray), encabezadoInvRealizada);
            e.Graphics.DrawString("Inversion Realizada", this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(Color.White), encabezadoInvRealizada, formatoTexto);

            Rectangle encabezadoRend = dtgIngresosEstacionales.GetCellDisplayRectangle(c4, -1, true);
            encabezadoRend.Width = this.dtgIngresosEstacionales.GetCellDisplayRectangle(c4, -1, true).Width +
                                          this.dtgIngresosEstacionales.GetCellDisplayRectangle(c5, -1, true).Width +
                                          this.dtgIngresosEstacionales.GetCellDisplayRectangle(c6, -1, true).Width;
            encabezadoRend.Height = altura / 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), encabezadoRend);
            e.Graphics.DrawString("Rendimientos", this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(Color.White), encabezadoRend, formatoTexto);

            Rectangle subRend1 = dtgIngresosEstacionales.GetCellDisplayRectangle(c4, -1, true);
            subRend1.Width = this.dtgIngresosEstacionales.GetCellDisplayRectangle(c4, -1, true).Width;
            subRend1.Height = altura / 2;
            subRend1.Y += altura / 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), subRend1);
            e.Graphics.DrawString("Anterior", this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(Color.Black), subRend1, formatoTexto);

            Rectangle subRend2 = dtgIngresosEstacionales.GetCellDisplayRectangle(c5, -1, true);
            subRend2.Width = this.dtgIngresosEstacionales.GetCellDisplayRectangle(c5, -1, true).Width;
            subRend2.Height = altura / 2;
            subRend2.Y += altura / 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), subRend2);
            e.Graphics.DrawString("Minimo", this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(Color.Black), subRend2, formatoTexto);

            Rectangle subRend3 = dtgIngresosEstacionales.GetCellDisplayRectangle(c6, -1, true);
            subRend3.Width = this.dtgIngresosEstacionales.GetCellDisplayRectangle(c6, -1, true).Width;
            subRend3.Height = altura / 2;
            subRend3.Y += altura / 2;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), subRend3);
            e.Graphics.DrawString("Maximo", this.dtgIngresosEstacionales.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(Color.Black), subRend3, formatoTexto);
        }

        #endregion

    }
}
