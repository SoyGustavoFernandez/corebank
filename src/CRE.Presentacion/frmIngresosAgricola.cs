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
using System.Text.RegularExpressions;

namespace CRE.Presentacion
{
    public partial class frmIngresosAgricola : frmBase
    {
        #region atributos
        
        private List<clsMovimientoEval> lstMovimientosEval;
        private List<clsMovimientoEval> lstIngresosEval;
        private BindingSource bsIngresosEval;
        private int idUnidadProductiva = -1;
        private int idUnidadMedida = -1;
        private int idEvaluacionCultivo;

        private DataTable dtMesesCultivo;
        private DataGridViewRow rowSeleccionado = null;

        private clsCNEvalAgrico objCNEvalAgrico = new clsCNEvalAgrico();
        private int nMeses;
        private decimal nTotalUnidProd;

        private clsMatrizAgricola objMatrizAgricola;

        #endregion

        public frmIngresosAgricola(clsEvaluacionCultivoAgrico objEvaluacionCultivoAgrico, clsEvalCred objEvalCred)
        {
            InitializeComponent();

            this.nMeses = objEvalCred.obtenerNumeroMeses();

            this.lstMovimientosEval = this.objCNEvalAgrico.CNObtenerMovimientosEvalAgri(objEvaluacionCultivoAgrico.idEvaluacionCultivo);
            this.lstIngresosEval = this.lstMovimientosEval.Where(a => a.idTipoMovEvalCultivo == 1).ToList();


            this.idEvaluacionCultivo = objEvaluacionCultivoAgrico.idEvaluacionCultivo;
            this.idUnidadProductiva = objEvaluacionCultivoAgrico.idUnidadProductiva;
            this.idUnidadMedida = objEvaluacionCultivoAgrico.idUnidadMedida;
            this.nTotalUnidProd = objEvaluacionCultivoAgrico.nUniProdAlquiladasAct + objEvaluacionCultivoAgrico.nUniProdPropiasAct;

            this.calcularTotal();

            inicializarTablaIngresos();
            inicializarMesesCultivo();

            this.objMatrizAgricola = objEvaluacionCultivoAgrico.objMatrizAgricola;
        }

        #region metodos

        private void inicializarTablaIngresos()
        {
            this.bsIngresosEval = new BindingSource();
            this.bsIngresosEval.DataSource = this.lstIngresosEval;
            this.dtgIngresos.DataSource = this.bsIngresosEval;

            this.bsIngresosEval.ResetBindings(false);
            this.dtgIngresos.Refresh();


            dtgIngresos.Columns["idMovimientoEval"].HeaderText = "ID";
            dtgIngresos.Columns["cMesMovimiento"].HeaderText = "Mes";
            dtgIngresos.Columns["nUnidadesAFinanciar"].HeaderText = "N° Unidad Productivas";
            dtgIngresos.Columns["nRendimiento"].HeaderText = "Rendimiento";
            dtgIngresos.Columns["cUnidadMedida"].HeaderText = "Unidad de Medida";
            dtgIngresos.Columns["nMonto"].HeaderText = "Precio";
            dtgIngresos.Columns["nMontoTotal"].HeaderText = "Monto Ingreso";
            dtgIngresos.Columns["idTipoMovEvalCultivo"].HeaderText = "Movimiento";

            dtgIngresos.Columns["idMovimientoEval"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["dMesMovimiento"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["nUnidadesAFinanciar"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["nRendimiento"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["cUnidadMedida"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["nMonto"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["nMontoTotal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIngresos.Columns["idTipoMovEvalCultivo"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgIngresos.Columns["nUnidadesAFinanciar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["nRendimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["nMontoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgIngresos.Columns["dMesMovimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgIngresos.Columns["dMesMovimiento"].FillWeight = 30;
            dtgIngresos.Columns["nUnidadesAFinanciar"].FillWeight = 40;
            dtgIngresos.Columns["nRendimiento"].FillWeight = 40;
            dtgIngresos.Columns["nMonto"].FillWeight = 40;
            dtgIngresos.Columns["nMontoTotal"].FillWeight = 50;

            dtgIngresos.Columns["idMovimientoEval"].Visible = false;
            dtgIngresos.Columns["idEvaluacionCultivo"].Visible = false;
            dtgIngresos.Columns["dMesMovimiento"].Visible = false;
            dtgIngresos.Columns["idUnidadMedida"].Visible = false;
            dtgIngresos.Columns["idEtapaCultivo"].Visible = false;
            dtgIngresos.Columns["cEtapaCultivo"].Visible = false;
            dtgIngresos.Columns["idActividadCultivo"].Visible = false;
            dtgIngresos.Columns["cActividadCultivo"].Visible = false;
            dtgIngresos.Columns["idTipoMovEvalCultivo"].Visible = false;
            dtgIngresos.Columns["idPadre"].Visible = false;
            dtgIngresos.Columns["nMesMovimientoPadre"].Visible = false;

            this.dtgIngresos.ClearSelection();
        }

        private void inicializarMesesCultivo(int nNumeroMeses = 0)
        {
            this.dtMesesCultivo = new DataTable();
            this.dtMesesCultivo.Columns.Add("idMes");
            this.dtMesesCultivo.Columns.Add("cMes");

            for (int i = 1; i <= this.nMeses; i++)
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
            this.cboUnidadProductivaEval.Enabled = false;
            this.txtCantidad.Enabled = true;
            this.txtNRendimiento.Enabled = true;
            this.txtNRendimientoTotal.Enabled = false;
            this.txtNPrecio.Enabled = true;
            this.txtNIngreso.Enabled = false;

            this.ActiveControl = this.cboMesesCultivo;
        }

        private void deshabilitarFormulario()
        {
            this.cboMesesCultivo.Enabled = false;
            this.cboUnidadProductivaEval.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtNRendimiento.Enabled = false;
            this.txtNRendimientoTotal.Enabled = false;
            this.txtNPrecio.Enabled = false;
            this.txtNIngreso.Enabled = false;
        }

        private void refrescarFormulario()
        {
            this.cboMesesCultivo.SelectedValue = -1;
            this.cboUnidadProductivaEval.SelectedValue = this.idUnidadProductiva;
            this.cboUnidadMedidaEval.SelectedValue = this.idUnidadMedida;
            this.txtCantidad.Text = "";
            this.txtNRendimientoTotal.Text = "";
            this.txtNIngreso.Text = "";

            if (this.objMatrizAgricola == null)
                this.txtNRendimiento.Text = "";
            else
                this.txtNRendimiento.Text = this.objMatrizAgricola.nRendimientoEquivalente.ToString("N2");

            if (this.objMatrizAgricola == null)
                this.txtNPrecio.Text = "";
            else
                this.txtNPrecio.Text = (this.objMatrizAgricola.nPrecioUnidadMN ?? 0).ToString("N2");
        }

        private void calcularRendimientoTotal()
        {
            if (this.txtCantidad.Text.Trim() == "" || this.txtNRendimiento.Text.Trim() == "")
            {
                return;
            }

            decimal nCantidad = Convert.ToDecimal(this.txtCantidad.Text);
            decimal nRendimiento = Convert.ToDecimal(this.txtNRendimiento.Text);

            decimal nRendTotal = nCantidad * nRendimiento;

            this.txtNRendimientoTotal.Text = nRendTotal.ToString();
        }

        private void calcularIngreso()
        {
            if (this.txtNRendimientoTotal.Text.Trim() == "" || this.txtNPrecio.Text.Trim() == "")
            {
                return;
            }

            decimal nRendimientoTotal = Convert.ToDecimal(this.txtNRendimientoTotal.Text);
            decimal nPrecio = Convert.ToDecimal(this.txtNPrecio.Text);

            decimal nIngresos = nRendimientoTotal * nPrecio;

            this.txtNIngreso.Text = nIngresos.ToString();
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (var item in this.lstIngresosEval)
            {
                total = total + item.nMontoTotal;
            }
            this.txtNTotal.Text = total.ToString("N2");
        }

        public List<clsMovimientoEval> obtenerIngresos()
        {
            return this.lstMovimientosEval;
        }

        private void verificarRendimiento()
        {
            if (this.objMatrizAgricola == null)
                return;

            decimal nRendimiento = 0M;
            decimal.TryParse(txtNRendimiento.Text, out nRendimiento);

            if (this.objMatrizAgricola.nRendimientoEquivalente > 0 && nRendimiento > this.objMatrizAgricola.nRendimientoEquivalente)
                this.txtNRendimiento.BackColor = Color.Orange;
            else
                this.txtNRendimiento.BackColor = Color.White;
        }

        private void verificarPrecio()
        {
            if (this.objMatrizAgricola == null)
                return;

            decimal nPrecio = 0M;
            decimal.TryParse(txtNPrecio.Text, out nPrecio);

            if (this.objMatrizAgricola.nPrecioUnidadMN > 0 && nPrecio > this.objMatrizAgricola.nPrecioUnidadMN)
                this.txtNPrecio.BackColor = Color.Orange;
            else
                this.txtNPrecio.BackColor = Color.White;
        }
        #endregion

        #region Eventos

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar que el formulario este lleno
            if (string.IsNullOrEmpty(this.cboMesesCultivo.Text))
            {
                MessageBox.Show("Debe seleccionar el Mes del ingreso", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboMesesCultivo.Focus();
                return;
            }
            if (Convert.ToInt32(this.cboUnidadProductivaEval.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar la unidad productiva", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUnidadProductivaEval.Focus();
                return;
            }
            if (this.txtCantidad.Text == "" || Convert.ToDecimal(this.txtCantidad.Text) == 0)
            {
                MessageBox.Show("Debe registrar las unidades productivas", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCantidad.Focus();
                return;
            }
            if (Convert.ToDecimal(this.txtCantidad.Text) > this.nTotalUnidProd)
            {
                MessageBox.Show("El número de unidades productivas máxima es: " + this.nTotalUnidProd, "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCantidad.Focus();
                return;
            }
            if (this.txtNRendimiento.Text == "" || Convert.ToDecimal(this.txtNRendimiento.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar el rendimiento", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNRendimiento.Focus();
                return;
            }
            if (Convert.ToInt32(this.cboUnidadMedidaEval.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe la unidad de medida", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUnidadMedidaEval.Focus();
                return;
            }
            if (this.txtNPrecio.Text == "" || Convert.ToDecimal(this.txtNPrecio.Text) == 0 )
            {
                MessageBox.Show("Debe registrar el precio", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNPrecio.Focus();
                return;
            }

            decimal nSumUniProd = 0;
            this.lstIngresosEval.ForEach(ing => nSumUniProd += ing.nUnidadesAFinanciar);
            nSumUniProd += Convert.ToDecimal(this.txtCantidad.Text);

            if (this.rowSeleccionado == null)
            {
                // Caso nuevo
                clsMovimientoEval objMovimientoEval = new clsMovimientoEval();
                objMovimientoEval.dMesMovimiento = Convert.ToDateTime(this.cboMesesCultivo.SelectedValue);
                objMovimientoEval.nRendimiento = Convert.ToDecimal(this.txtNRendimiento.Text);
                objMovimientoEval.nUnidadesAFinanciar = Convert.ToDecimal(this.txtCantidad.Text);
                objMovimientoEval.nMonto = Convert.ToDecimal(this.txtNPrecio.Text);
                objMovimientoEval.nMontoTotal = Convert.ToDecimal(this.txtNIngreso.Text);
                objMovimientoEval.idUnidadMedida = Convert.ToInt32(this.cboUnidadMedidaEval.SelectedValue);
                objMovimientoEval.cUnidadMedida = Convert.ToString(this.cboUnidadMedidaEval.Text);
                objMovimientoEval.idTipoMovEvalCultivo = 1;

                if (nSumUniProd > this.nTotalUnidProd)
                {
                    MessageBox.Show("El número de unidades productivas máxima es: " + this.nTotalUnidProd, "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtCantidad.Focus();
                    return;
                }

                this.lstIngresosEval.Add(objMovimientoEval);
            }
            else
            {
                // Caso edicion
                foreach (DataGridViewRow row in this.dtgIngresos.Rows)
                {
                    if (row == this.rowSeleccionado)
                    {
                        nSumUniProd -= Convert.ToDecimal(row.Cells["nUnidadesAFinanciar"].Value);

                        if (nSumUniProd > this.nTotalUnidProd)
                        {
                            MessageBox.Show("El número de unidades productivas máxima es: " + this.nTotalUnidProd, "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtCantidad.Focus();
                            return;
                        }

                        row.Cells["dMesMovimiento"].Value = this.cboMesesCultivo.SelectedValue;
                        row.Cells["nUnidadesAFinanciar"].Value = this.txtCantidad.Text;
                        row.Cells["nRendimiento"].Value = this.txtNRendimiento.Text;
                        row.Cells["idUnidadMedida"].Value = this.cboUnidadMedidaEval.SelectedValue;
                        row.Cells["cUnidadMedida"].Value = this.cboUnidadMedidaEval.Text;
                        row.Cells["nMonto"].Value = this.txtNPrecio.Text;
                        row.Cells["nMontoTotal"].Value = this.txtNIngreso.Text;
                        row.Cells["idTipoMovEvalCultivo"].Value = 1;   
                    }
                }
            }

            // Comenzar ejecucion
            this.deshabilitarFormulario();
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;

            this.bsIngresosEval.ResetBindings(false);
            this.dtgIngresos.Refresh();
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

            foreach (DataGridViewRow row in this.dtgIngresos.Rows)
            {
                if (row == this.rowSeleccionado)
                {
                    this.dtgIngresos.Rows.RemoveAt(row.Index);
                }
            }

            this.bsIngresosEval.ResetBindings(false);
            this.dtgIngresos.Refresh();
            this.calcularTotal();

            this.rowSeleccionado = null;
            this.refrescarFormulario();
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void dtgIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgIngresos.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowSeleccionado = this.dtgIngresos.SelectedRows[0];

            DateTime dMesMovimiento = Convert.ToDateTime(this.dtgIngresos.SelectedRows[0].Cells["dMesMovimiento"].Value);
            decimal nUnidadesAFinanciar = Convert.ToDecimal(this.dtgIngresos.SelectedRows[0].Cells["nUnidadesAFinanciar"].Value);
            decimal nRendimiento = Convert.ToDecimal(this.dtgIngresos.SelectedRows[0].Cells["nRendimiento"].Value);
            decimal nMonto = Convert.ToDecimal(this.dtgIngresos.SelectedRows[0].Cells["nMonto"].Value);
            decimal nMontoTotal = Convert.ToDecimal(this.dtgIngresos.SelectedRows[0].Cells["nMontoTotal"].Value);
            int idTipoMovEvalCultivo = Convert.ToInt32(this.dtgIngresos.SelectedRows[0].Cells["idTipoMovEvalCultivo"].Value);


            // Llenar formulario
            this.cboMesesCultivo.SelectedValue = dMesMovimiento;
            this.txtCantidad.Text = nUnidadesAFinanciar.ToString();
            this.txtNRendimiento.Text = nRendimiento.ToString();
            this.txtNRendimientoTotal.Text = (nRendimiento * nUnidadesAFinanciar).ToString();
            this.txtNPrecio.Text = nMonto.ToString();
            this.txtNIngreso.Text = nMontoTotal.ToString();
            this.deshabilitarFormulario();

            // Activar boton editar
            this.btnEditar.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void frmIngresosAgricola_Load(object sender, EventArgs e)
        {
            deshabilitarFormulario();
            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;

            dtgIngresos.Refresh();

            this.dtgIngresos.Columns["nMontoTotal"].DefaultCellStyle.Format = "N2";

            this.refrescarFormulario();
            this.txtNUPMax.Text = this.nTotalUnidProd.ToString();
            this.dtgIngresos.ClearSelection();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            this.calcularRendimientoTotal();
            this.calcularIngreso();
        }

        private void txtNRendimiento_Leave(object sender, EventArgs e)
        {
            this.calcularRendimientoTotal();
            this.calcularIngreso();
        }

        private void txtNPrecio_Leave(object sender, EventArgs e)
        {
            this.calcularIngreso();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            // ahora aqui
            this.lstMovimientosEval = this.lstMovimientosEval.Where(a => a.idTipoMovEvalCultivo == 2).ToList();
            this.lstMovimientosEval.AddRange(this.lstIngresosEval);

            this.objCNEvalAgrico.CNRegistrarMovimientoEvalAgri(this.idEvaluacionCultivo, this.lstMovimientosEval);

            this.Close();
        }

        private void txtNPrecio_TextChanged(object sender, EventArgs e)
        {
            this.verificarPrecio();
        }

        private void txtNRendimientoTotal_TextChanged(object sender, EventArgs e)
        {
            this.verificarRendimiento();
        }
        #endregion        
    }
}
