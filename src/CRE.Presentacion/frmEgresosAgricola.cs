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

namespace CRE.Presentacion
{
    public partial class frmEgresosAgricola : frmBase
    {
        
        #region atributos

        private List<clsMovimientoEval> lstMovimientosEval;
        private List<clsMovimientoEval> lstEgresosEval;
        private BindingSource bsEgresosEval;
        private int idUnidadProductiva = -1;
        private int idEvaluacionCultivo;

        private DataTable dtMesesCultivo;
        private DataGridViewRow rowSeleccionado = null;

        private clsCNEvalAgrico objCNEvalAgrico = new clsCNEvalAgrico();
        private int nMeses;
        private decimal nUnidadesFinanciadas;

        #endregion

        public frmEgresosAgricola(clsEvaluacionCultivoAgrico objEvaluacionCultivoAgrico, clsEvalCred objEvalCred)
        {
            InitializeComponent();

            this.nMeses = objEvalCred.obtenerNumeroMeses();

            this.lstMovimientosEval = this.objCNEvalAgrico.CNObtenerMovimientosEvalAgri(objEvaluacionCultivoAgrico.idEvaluacionCultivo);
            this.lstEgresosEval = this.lstMovimientosEval.Where(a => a.idTipoMovEvalCultivo == 2).ToList();


            this.idEvaluacionCultivo = objEvaluacionCultivoAgrico.idEvaluacionCultivo;
            this.idUnidadProductiva = objEvaluacionCultivoAgrico.idUnidadProductiva;

            this.nUnidadesFinanciadas = objEvaluacionCultivoAgrico.nUniProdPropiasAct + objEvaluacionCultivoAgrico.nUniProdAlquiladasAct;
            this.txtNUnidadesFinanciadas.Text = Convert.ToString(this.nUnidadesFinanciadas);

            this.calcularTotal();

            inicializarTablaEgresos();
            inicializarMesesCultivo();
        }

        #region metodos
        private void inicializarTablaEgresos()
        {

            this.bsEgresosEval = new BindingSource();
            this.bsEgresosEval.DataSource = this.lstEgresosEval;
            this.dtgEgresos.DataSource = this.bsEgresosEval;

            this.bsEgresosEval.ResetBindings(false);
            this.dtgEgresos.Refresh();


            foreach (DataGridViewColumn column in this.dtgEgresos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            this.dtgEgresos.Columns["cMesMovimiento"].HeaderText = "Mes Egreso";
            this.dtgEgresos.Columns["cEtapaCultivo"].HeaderText = "Etapa Cultivo";
            this.dtgEgresos.Columns["cActividadCultivo"].HeaderText = "Actividad Cultivo";
            this.dtgEgresos.Columns["nUnidadesAFinanciar"].HeaderText = "N° Unidades";
            this.dtgEgresos.Columns["nMonto"].HeaderText = "Monto";
            this.dtgEgresos.Columns["nMontoTotal"].HeaderText = "Monto Total";

            this.dtgEgresos.Columns["nUnidadesAFinanciar"].DefaultCellStyle.Format = "n2";
            this.dtgEgresos.Columns["nMonto"].DefaultCellStyle.Format = "n2";
            this.dtgEgresos.Columns["nMontoTotal"].DefaultCellStyle.Format = "n2";

            this.dtgEgresos.Columns["cMesMovimiento"].FillWeight = 50;
            this.dtgEgresos.Columns["nUnidadesAFinanciar"].FillWeight = 45;
            this.dtgEgresos.Columns["nMonto"].FillWeight = 45;
            this.dtgEgresos.Columns["nMontoTotal"].FillWeight = 45;

            this.dtgEgresos.Columns["cMesMovimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEgresos.Columns["nUnidadesAFinanciar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEgresos.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtgEgresos.Columns["nMontoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgEgresos.Columns["cMesMovimiento"].Visible = true;
            this.dtgEgresos.Columns["cEtapaCultivo"].Visible = true;
            this.dtgEgresos.Columns["cActividadCultivo"].Visible = true;
            this.dtgEgresos.Columns["nUnidadesAFinanciar"].Visible = true;
            this.dtgEgresos.Columns["nMonto"].Visible = true;
            this.dtgEgresos.Columns["nMontoTotal"].Visible = true;


            /**************************/

            this.txtNTotal.TextAlign = HorizontalAlignment.Right;

        }

        private void inicializarMesesCultivo()
        {
            this.dtMesesCultivo = new DataTable();
            this.dtMesesCultivo.Columns.Add("idMes");
            this.dtMesesCultivo.Columns.Add("cMes");

            for (int i = 0; i <= this.nMeses; i++)
            {
                DateTime dHoy = clsVarGlobal.dFecSystem;
                DateTime dMesN = dHoy.AddMonths(i);

                DateTime dDiaPrimero = new DateTime(dMesN.Year, dMesN.Month, 1);

                this.dtMesesCultivo.Rows.Add(dDiaPrimero, dDiaPrimero.Date.ToString("MMM yyyy"));
            }

            this.cboMesesCultivo.DataSource = this.dtMesesCultivo;
            this.cboMesesCultivo.ValueMember = "idMes";
            this.cboMesesCultivo.DisplayMember = "cMes";
        }

        private void habilitarFormulario()
        {
            this.cboMesesCultivo.Enabled = true;
            this.cboUnidadProd.Enabled = false;
            this.cboEtapaCultivoEval.Enabled = true;
            this.cboActividadPorEtapaCultivoEval.Enabled = true;
            this.txtNIngreso.Enabled = true;

            this.ActiveControl = this.cboMesesCultivo;
        }

        private void deshabilitarFormulario()
        {
            this.cboMesesCultivo.Enabled = false;
            this.cboUnidadProd.Enabled = false;
            this.cboEtapaCultivoEval.Enabled = false;
            this.cboActividadPorEtapaCultivoEval.Enabled = false;
            this.txtNIngreso.Enabled = false;
        }

        private void refrescarFormulario()
        {
            this.cboMesesCultivo.SelectedValue = -1;
            this.cboUnidadProd.SelectedValue = this.idUnidadProductiva;
            this.cboEtapaCultivoEval.SelectedValue = -1;
            this.cboActividadPorEtapaCultivoEval.SelectedValue = -1;
            this.txtNIngreso.Text = "";
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (var item in this.lstEgresosEval)
            {
                total = total + item.nMontoTotal;
            }
            this.txtNTotal.Text = total.ToString("N2");
        }

        public List<clsMovimientoEval> obtenerEgresos()
        {
            return this.lstMovimientosEval;
        }
        #endregion

        #region Eventos        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar que el formulario este lleno
            if (string.IsNullOrEmpty(this.cboMesesCultivo.Text))
            {
                MessageBox.Show("Debe seleccionar el Mes del egreso", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboMesesCultivo.Focus();
                return;
            }
            if (Convert.ToInt32(this.cboUnidadProd.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar la unidad productiva", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUnidadProd.Focus();
                return;
            }
            if (Convert.ToInt32(this.cboEtapaCultivoEval.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar la etapa de cultivo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEtapaCultivoEval.Focus();
                return;
            }
            if (Convert.ToInt32(this.cboActividadPorEtapaCultivoEval.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar la actividad de cultivo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboActividadPorEtapaCultivoEval.Focus();
                return;
            }
            if (this.txtNIngreso.Text == "" || Convert.ToDecimal(this.txtNIngreso.Text) == 0 )
            {
                MessageBox.Show("Debe ingresar en monto", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNIngreso.Focus();
                return;
            }
            

            // Comenzar ejecucion
            this.deshabilitarFormulario();
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;

            if (this.rowSeleccionado == null)
            {
                // Caso nuevo
                clsMovimientoEval objMovimientoEval = new clsMovimientoEval();
                objMovimientoEval.dMesMovimiento = Convert.ToDateTime(this.cboMesesCultivo.SelectedValue);
                objMovimientoEval.idEtapaCultivo = Convert.ToInt32(this.cboEtapaCultivoEval.SelectedValue);
                objMovimientoEval.cEtapaCultivo = Convert.ToString(this.cboEtapaCultivoEval.Text);
                objMovimientoEval.idActividadCultivo = Convert.ToInt32(this.cboActividadPorEtapaCultivoEval.SelectedValue);
                objMovimientoEval.cActividadCultivo = Convert.ToString(this.cboActividadPorEtapaCultivoEval.Text);
                objMovimientoEval.nUnidadesAFinanciar = Convert.ToDecimal(this.nUnidadesFinanciadas);
                objMovimientoEval.nMonto = Convert.ToDecimal(this.txtNIngreso.Text);
                objMovimientoEval.nMontoTotal = Convert.ToDecimal(this.txtNTotalEgreso.Text);
                objMovimientoEval.idTipoMovEvalCultivo = 2;

                this.lstEgresosEval.Add(objMovimientoEval);
            }
            else
            {
                // Caso edicion
                foreach (DataGridViewRow row in this.dtgEgresos.Rows)
                {
                    if (row == this.rowSeleccionado)
                    {
                        row.Cells["dMesMovimiento"].Value = this.cboMesesCultivo.SelectedValue;
                        row.Cells["idEtapaCultivo"].Value = this.cboEtapaCultivoEval.SelectedValue;
                        row.Cells["cEtapaCultivo"].Value = this.cboEtapaCultivoEval.Text;
                        row.Cells["idActividadCultivo"].Value = this.cboActividadPorEtapaCultivoEval.SelectedValue;
                        row.Cells["cActividadCultivo"].Value = this.cboActividadPorEtapaCultivoEval.Text;
                        row.Cells["nUnidadesAFinanciar"].Value = this.txtNUnidadesFinanciadas.Text;
                        row.Cells["nMonto"].Value = this.txtNIngreso.Text;
                        row.Cells["nMontoTotal"].Value = this.txtNTotalEgreso.Text;
                        row.Cells["idTipoMovEvalCultivo"].Value = 2;
                    }
                }
            }

            this.bsEgresosEval.ResetBindings(false);
            this.dtgEgresos.Refresh();
            this.calcularTotal();

            this.refrescarFormulario();
            this.btnNuevo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.rowSeleccionado = null;
            this.deshabilitarFormulario();
            this.refrescarFormulario();
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnNuevo.Enabled = true;
        }

        private void dtgEgresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgEgresos.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowSeleccionado = this.dtgEgresos.SelectedRows[0];

            DateTime dMesMovimiento = Convert.ToDateTime(this.dtgEgresos.SelectedRows[0].Cells["dMesMovimiento"].Value);
            int idEtapaCultivo = Convert.ToInt32(this.dtgEgresos.SelectedRows[0].Cells["idEtapaCultivo"].Value);
            int idActividadCultivo = Convert.ToInt32(this.dtgEgresos.SelectedRows[0].Cells["idActividadCultivo"].Value);
            decimal nUnidades = Convert.ToDecimal(this.dtgEgresos.SelectedRows[0].Cells["nUnidadesAFinanciar"].Value);
            decimal nMonto = Convert.ToDecimal(this.dtgEgresos.SelectedRows[0].Cells["nMonto"].Value);
            decimal nMontoTotal = Convert.ToDecimal(this.dtgEgresos.SelectedRows[0].Cells["nMontoTotal"].Value);
            int idTipoMovEvalCultivo = Convert.ToInt32(this.dtgEgresos.SelectedRows[0].Cells["idTipoMovEvalCultivo"].Value);


            // Llenar formulario
            this.cboMesesCultivo.SelectedValue = dMesMovimiento;
            this.cboEtapaCultivoEval.SelectedValue = idEtapaCultivo;
            this.cboActividadPorEtapaCultivoEval.SelectedValue = idActividadCultivo;
            this.txtNIngreso.Text = nMonto.ToString();
            this.deshabilitarFormulario();
            

            // Activar boton editar
            this.btnEditar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.rowSeleccionado = null;

            this.btnNuevo.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnAceptar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.refrescarFormulario();
            this.habilitarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.btnAceptar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.habilitarFormulario();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.deshabilitarFormulario();

            foreach (DataGridViewRow row in this.dtgEgresos.Rows)
            {
                if (row == this.rowSeleccionado)
                {
                    this.dtgEgresos.Rows.RemoveAt(row.Index);
                }
            }
            this.bsEgresosEval.ResetBindings(false);
            this.dtgEgresos.Refresh();
            this.calcularTotal();

            this.rowSeleccionado = null;
            this.refrescarFormulario();
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }        

        private void frmEgresosAgricola_Load(object sender, EventArgs e)
        {
            deshabilitarFormulario();
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;

            dtgEgresos.Refresh();

            this.dtgEgresos.Columns["nMontoTotal"].DefaultCellStyle.Format = "N2";

            this.refrescarFormulario();
            this.dtgEgresos.ClearSelection();
        }

        private void cboEtapaCultivoEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboEtapaCultivoEval.SelectedIndex >= 0)
            {
                this.cboActividadPorEtapaCultivoEval.cargarDatos(Int32.Parse(this.cboEtapaCultivoEval.SelectedValue.ToString()));
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.lstMovimientosEval = this.lstMovimientosEval.Where(a => a.idTipoMovEvalCultivo == 1).ToList();
            this.lstMovimientosEval.AddRange(this.lstEgresosEval);

            this.objCNEvalAgrico.CNRegistrarMovimientoEvalAgri(this.idEvaluacionCultivo, this.lstMovimientosEval);

            this.Close();
        }

        private void txtNIngreso_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNIngreso == null || this.txtNIngreso.Text == "" )
            {
                return;
            }
            decimal nTotalEgregos = this.nUnidadesFinanciadas * Convert.ToDecimal(this.txtNIngreso.Text);
            this.txtNTotalEgreso.Text = nTotalEgregos.ToString();
        }

        #endregion

        

    }
}
