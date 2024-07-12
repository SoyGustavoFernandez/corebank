using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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
    public partial class frmDetalleActividadPecuaria : frmBase
    {
        #region atributos
        
        private clsCNEvalAgrop objCapaNegocio;
        private int idEvaluacionPecuaria;

        private List<clsActividadPecuaria> lstMovimientosPecuario = new List<clsActividadPecuaria>();
        public List<clsActividadPecuaria> lstVentasPecuario = new List<clsActividadPecuaria>();
        public List<clsActividadPecuaria> lstCostosPecuario = new List<clsActividadPecuaria>();
        private BindingSource bsVentasPecuario;
        private BindingSource bsCostosPecuario;
        
        private DataTable dtFrecuenciaVentas;
        private DataTable dtFrecuenciaCostos;
        private DataTable dtEtapas;
        private DataTable dtSubEtapas;
        private DataTable dtMesesVentas;
        private DataTable dtMesesCostos;

        private int nMeses;
        private DateTime dFechaRegSolicitud;

        private DataGridViewRow rowVentaSeleccionado = null;
        private bool lEditandoVentas = false;

        private DataGridViewRow rowCostoSeleccionado = null;
        private bool lEditandoCostos = false;

        private int idTipoCrianza;
        public bool lEditado = false;

        #endregion

        public frmDetalleActividadPecuaria()
        {
            InitializeComponent();
        }

        #region metodos

        private void obtenerRegistroMovimientos()
        {
            DataSet ds = this.objCapaNegocio.ObtenerMovimientosEvalPecuario(this.idEvaluacionPecuaria);
            this.lstMovimientosPecuario = DataTableToList.ConvertTo<clsActividadPecuaria>(ds.Tables[0]) as List<clsActividadPecuaria>;

            this.lstVentasPecuario = new List<clsActividadPecuaria>();
            this.lstCostosPecuario = new List<clsActividadPecuaria>();
            int i = 1;
            foreach (var objVenta in this.lstMovimientosPecuario)
            {
                if (objVenta.idTipMovEvalPecuario == 1)
                {
                    objVenta.nNumeroVenta = i;
                    this.lstVentasPecuario.Add(objVenta);
                    i = i + 1;
                }
            }
            foreach (var objCosto in this.lstMovimientosPecuario)
            {
                if (objCosto.idTipMovEvalPecuario == 2)
                {
                    foreach (var objVenta in this.lstVentasPecuario)
                    {
                        if (objCosto.idPadre == objVenta.idMovimientoEvalPecuario)
                        {
                            objCosto.nNumeroVenta = objVenta.nNumeroVenta;
                            this.lstCostosPecuario.Add(objCosto);
                            break;
                        }
                    }
                }
            }


            this.dtFrecuenciaVentas = ds.Tables[2];
            this.dtFrecuenciaCostos = ds.Tables[2].Copy();
            this.dtEtapas = ds.Tables[3].AsEnumerable().Where(item => item.Field<int>("idPadre") == 0).CopyToDataTable();
            this.dtSubEtapas = ds.Tables[3].Copy();

            this.inicializarDtgVentas();
            this.inicializarDtgCostos();

            this.inicializarCbos();

            this.limpiarFormularioVentas();
            this.limpiarFormularioCostos();

            this.deshabilitarFormularioVentas();
            this.deshabilitarFormularioCostos();

            this.btnNuevoVenta.Enabled = true;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = false;

            this.btnNuevoCosto.Enabled = true;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = false;
        }

        public void inicializarDtgVentas()
        {
            this.bsVentasPecuario = new BindingSource();
            this.bsVentasPecuario.DataSource = this.lstVentasPecuario;
            this.dtgVentasPecuario.DataSource = this.bsVentasPecuario;

            this.bsVentasPecuario.ResetBindings(false);
            this.dtgVentasPecuario.Refresh();

            foreach (DataGridViewColumn column in this.dtgVentasPecuario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dtgVentasPecuario.Columns["nNumeroVenta"].DisplayIndex = 1;
            this.dtgVentasPecuario.Columns["cPeriodoCred"].DisplayIndex = 2;
            this.dtgVentasPecuario.Columns["cMesInicio"].DisplayIndex = 3;
            this.dtgVentasPecuario.Columns["nRendimientoUni"].DisplayIndex = 4;
            this.dtgVentasPecuario.Columns["nPrecioUni"].DisplayIndex = 5;
            this.dtgVentasPecuario.Columns["nCantidad"].DisplayIndex = 6;
            this.dtgVentasPecuario.Columns["nMontoTotal"].DisplayIndex = 7;

            this.dtgVentasPecuario.Columns["nNumeroVenta"].HeaderText = "ID Venta";
            this.dtgVentasPecuario.Columns["nRendimientoUni"].HeaderText = "Rendimiento Uni";
            this.dtgVentasPecuario.Columns["nPrecioUni"].HeaderText = "Precio Uni";
            this.dtgVentasPecuario.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgVentasPecuario.Columns["nMontoTotal"].HeaderText = "Monto Total";
            this.dtgVentasPecuario.Columns["cPeriodoCred"].HeaderText = "Periodo Cred";
            this.dtgVentasPecuario.Columns["cMesInicio"].HeaderText = "Mes Inicio";

            this.dtgVentasPecuario.Columns["nRendimientoUni"].DefaultCellStyle.Format = "n2";
            this.dtgVentasPecuario.Columns["nPrecioUni"].DefaultCellStyle.Format = "n2";
            this.dtgVentasPecuario.Columns["nCantidad"].DefaultCellStyle.Format = "n2";
            this.dtgVentasPecuario.Columns["nMontoTotal"].DefaultCellStyle.Format = "n2";

            this.dtgVentasPecuario.Columns["nNumeroVenta"].Visible = true;
            this.dtgVentasPecuario.Columns["nRendimientoUni"].Visible = true;
            this.dtgVentasPecuario.Columns["nPrecioUni"].Visible = true;
            this.dtgVentasPecuario.Columns["nCantidad"].Visible = true;
            this.dtgVentasPecuario.Columns["nMontoTotal"].Visible = true;
            this.dtgVentasPecuario.Columns["cPeriodoCred"].Visible = true;
            this.dtgVentasPecuario.Columns["cMesInicio"].Visible = true;

            this.dtgVentasPecuario.Columns["nNumeroVenta"].FillWeight = 50;

            this.dtgVentasPecuario.ReadOnly = true;
        }
        public void inicializarDtgCostos()
        {
            this.bsCostosPecuario = new BindingSource();
            this.bsCostosPecuario.DataSource = this.lstCostosPecuario;
            this.dtgCostosPecuario.DataSource = this.bsCostosPecuario;

            this.bsCostosPecuario.ResetBindings(false);
            this.dtgCostosPecuario.Refresh();


            foreach (DataGridViewColumn column in this.dtgCostosPecuario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.dtgCostosPecuario.Columns["nNumeroVenta"].DisplayIndex = 1;
            this.dtgCostosPecuario.Columns["cEtapaPecuario"].DisplayIndex = 2;
            this.dtgCostosPecuario.Columns["cSubEtapaPecuario"].DisplayIndex = 3;
            this.dtgCostosPecuario.Columns["nCantidad"].DisplayIndex = 4;
            this.dtgCostosPecuario.Columns["cPeriodoCred"].DisplayIndex = 5;
            this.dtgCostosPecuario.Columns["cMesInicio"].DisplayIndex = 6;
            this.dtgCostosPecuario.Columns["nPrecioUni"].DisplayIndex = 7;
            this.dtgCostosPecuario.Columns["nCantidad"].DisplayIndex = 8;
            this.dtgCostosPecuario.Columns["nMontoTotal"].DisplayIndex = 9;

            this.dtgCostosPecuario.Columns["nNumeroVenta"].HeaderText = "ID Venta";
            this.dtgCostosPecuario.Columns["cPeriodoCred"].HeaderText = "Periodo Cred";
            this.dtgCostosPecuario.Columns["cMesInicio"].HeaderText = "Mes Inicio";
            this.dtgCostosPecuario.Columns["cEtapaPecuario"].HeaderText = "Etapa";
            this.dtgCostosPecuario.Columns["cSubEtapaPecuario"].HeaderText = "Sub Etapa";
            this.dtgCostosPecuario.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgCostosPecuario.Columns["nPrecioUni"].HeaderText = "Costo Uni";
            this.dtgCostosPecuario.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgCostosPecuario.Columns["nMontoTotal"].HeaderText = "Costo";

            this.dtgCostosPecuario.Columns["nPrecioUni"].DefaultCellStyle.Format = "n2";
            this.dtgCostosPecuario.Columns["nCantidad"].DefaultCellStyle.Format = "n2";
            this.dtgCostosPecuario.Columns["nMontoTotal"].DefaultCellStyle.Format = "n2";

            this.dtgCostosPecuario.Columns["nNumeroVenta"].FillWeight = 50;
            this.dtgCostosPecuario.Columns["nPrecioUni"].FillWeight = 50;
            this.dtgCostosPecuario.Columns["nCantidad"].FillWeight = 50;
            this.dtgCostosPecuario.Columns["nMontoTotal"].FillWeight = 50;
            this.dtgCostosPecuario.Columns["cMesInicio"].FillWeight = 50;

            this.dtgCostosPecuario.Columns["nNumeroVenta"].Visible = true;
            this.dtgCostosPecuario.Columns["cPeriodoCred"].Visible = true;
            this.dtgCostosPecuario.Columns["cMesInicio"].Visible = true;
            this.dtgCostosPecuario.Columns["cEtapaPecuario"].Visible = true;
            this.dtgCostosPecuario.Columns["cSubEtapaPecuario"].Visible = true;
            this.dtgCostosPecuario.Columns["nCantidad"].Visible = true;
            this.dtgCostosPecuario.Columns["nPrecioUni"].Visible = true;
            this.dtgCostosPecuario.Columns["nCantidad"].Visible = true;
            this.dtgCostosPecuario.Columns["nMontoTotal"].Visible = true;


            this.dtgCostosPecuario.ReadOnly = true;
        }
        public void inicializarCbos()
        {
            #region cboFrecuenciaVentas

            DataTable dtFrecuenciaVentasLocal = new DataTable();
            dtFrecuenciaVentasLocal.Columns.Add("idPeriodoCred");
            dtFrecuenciaVentasLocal.Columns.Add("cPeriodoCred");

            if (this.idTipoCrianza == 3)
            {
                dtFrecuenciaVentasLocal.Rows.Add(1, "Mensual");
            }
            else
            {
                dtFrecuenciaVentasLocal.Rows.Add(1, "Mensual");
                dtFrecuenciaVentasLocal.Rows.Add(2, "Bimensual");
                dtFrecuenciaVentasLocal.Rows.Add(3, "Trimensual");
                dtFrecuenciaVentasLocal.Rows.Add(4, "Cuatrimestral");
                dtFrecuenciaVentasLocal.Rows.Add(5, "Quinquemestral");
                dtFrecuenciaVentasLocal.Rows.Add(6, "Semestral");
                dtFrecuenciaVentasLocal.Rows.Add(8, "Octomestral");
                dtFrecuenciaVentasLocal.Rows.Add(9, "Nonamestral");
                dtFrecuenciaVentasLocal.Rows.Add(12, "Anual");
                dtFrecuenciaVentasLocal.Rows.Add(100, "Unica");
            }


            this.cboFrecuenciaVentas.DisplayMember = "cPeriodoCred";
            this.cboFrecuenciaVentas.ValueMember = "idPeriodoCred";
            this.cboFrecuenciaVentas.DataSource = dtFrecuenciaVentasLocal;

            #endregion


            this.cboEtapa.SelectedIndexChanged -= new EventHandler(this.cboEtapa_SelectedIndexChanged);
            this.cboEtapa.DisplayMember = "cEtapaPecuario";
            this.cboEtapa.ValueMember = "idEtapaPecuario";
            this.cboEtapa.DataSource = this.dtEtapas;

            this.cboEtapa.SelectedIndex = -1;
            this.cboEtapa.SelectedIndexChanged += new EventHandler(this.cboEtapa_SelectedIndexChanged);

            #region cboFrecuenciaCostos

            DataTable dtFrecuenciaCostosLocal = new DataTable();
            dtFrecuenciaCostosLocal.Columns.Add("idPeriodoCred");
            dtFrecuenciaCostosLocal.Columns.Add("cPeriodoCred");

            if (this.idTipoCrianza == 3)
            {
                dtFrecuenciaCostosLocal.Rows.Add(1, "Mensual");
            }
            else
            {
                dtFrecuenciaCostosLocal.Rows.Add(1, "Mensual");
                dtFrecuenciaCostosLocal.Rows.Add(2, "Bimensual");
                dtFrecuenciaCostosLocal.Rows.Add(3, "Trimestral");
                dtFrecuenciaCostosLocal.Rows.Add(4, "Cuatrimestral");
                dtFrecuenciaCostosLocal.Rows.Add(5, "Quinquemestral");
                dtFrecuenciaCostosLocal.Rows.Add(6, "Semestral");
                dtFrecuenciaCostosLocal.Rows.Add(8, "Octomestral");
                dtFrecuenciaCostosLocal.Rows.Add(9, "Nonamestral");
                dtFrecuenciaCostosLocal.Rows.Add(12, "Anual");
                dtFrecuenciaCostosLocal.Rows.Add(100, "Unica");
            }


            this.cboFrecuenciaCostos.DisplayMember = "cPeriodoCred";
            this.cboFrecuenciaCostos.ValueMember = "idPeriodoCred";
            this.cboFrecuenciaCostos.DataSource = dtFrecuenciaCostosLocal;

            #endregion

            #region Meses ventas
            this.dtMesesVentas = new DataTable();
            this.dtMesesVentas.Columns.Add("idMes");
            this.dtMesesVentas.Columns.Add("cMes");
            int nLimite;
            if (this.idTipoCrianza == 3)
            {
                nLimite = 1;
            }
            else
            {
                nLimite = this.nMeses;
            }

            for (int i = 1; i <= nLimite; i++)
            {
                DateTime dHoy = this.dFechaRegSolicitud;
                DateTime dMesN = dHoy.AddMonths(i);

                DateTime dDiaPrimero = new DateTime(dMesN.Year, dMesN.Month, 1);

                this.dtMesesVentas.Rows.Add(dDiaPrimero, dDiaPrimero.Date.ToString("MMM yyyy"));
            }

            this.cboMesIniVentas.DataSource = this.dtMesesVentas;
            this.cboMesIniVentas.ValueMember = "idMes";
            this.cboMesIniVentas.DisplayMember = "cMes";
            #endregion
            #region Meses costos
            this.dtMesesCostos = new DataTable();
            this.dtMesesCostos.Columns.Add("idMes");
            this.dtMesesCostos.Columns.Add("cMes");

            for (int i = 1; i <= nLimite; i++)
            {
                DateTime dHoy = this.dFechaRegSolicitud;
                DateTime dMesN = dHoy.AddMonths(i);

                DateTime dDiaPrimero = new DateTime(dMesN.Year, dMesN.Month, 1);

                this.dtMesesCostos.Rows.Add(dDiaPrimero, dDiaPrimero.Date.ToString("MMM yyyy"));
            }

            this.cboMesIniCostos.DataSource = this.dtMesesCostos;
            this.cboMesIniCostos.ValueMember = "idMes";
            this.cboMesIniCostos.DisplayMember = "cMes";
            #endregion

            #region cbo IDs Ventas
            this.cboIDsVenta.DisplayMember = "nNumeroVenta";
            this.cboIDsVenta.ValueMember = "idMovimientoEvalPecuario";
            this.cboIDsVenta.DataSource = this.lstVentasPecuario;
            #endregion
        }
        private void limpiarFormularioVentas()
        {
            this.cboFrecuenciaVentas.SelectedValue = -1;
            this.cboMesIniVentas.SelectedValue = -1;
            this.txtRendimientoUni.Text = "0";
            this.txtPrecioUniVentas.Text = "0";
            this.txtCantidadVentas.Text = "0";
        }
        private void deshabilitarFormularioVentas()
        {
            this.txtRendimientoUni.Enabled = false;
            this.txtPrecioUniVentas.Enabled = false;
            this.txtCantidadVentas.Enabled = false;
            this.cboFrecuenciaVentas.Enabled = false;
            this.cboMesIniVentas.Enabled = false;
        }
        private void habilitarFormularioVentas()
        {
            this.txtRendimientoUni.Enabled = true;
            this.txtPrecioUniVentas.Enabled = true;
            this.txtCantidadVentas.Enabled = true;
            this.cboFrecuenciaVentas.Enabled = true;
            this.cboMesIniVentas.Enabled = true;
        }
        private void limpiarFormularioCostos()
        {
            this.cboIDsVenta.SelectedValue = -1;
            this.cboEtapa.SelectedValue = -1;
            this.cboSubEtapa.SelectedValue = -1;
            this.cboFrecuenciaCostos.SelectedValue = -1;
            this.cboMesIniCostos.SelectedValue = -1;
            this.txtPrecioUniCostos.Text = "0";
            this.txtCantidadCostos.Text = "0";
        }
        private void deshabilitarFormularioCostos()
        {
            this.cboIDsVenta.Enabled = false;
            this.cboEtapa.Enabled = false;
            this.cboSubEtapa.Enabled = false;
            this.cboFrecuenciaCostos.Enabled = false;
            this.cboMesIniCostos.Enabled = false;
            this.txtPrecioUniCostos.Enabled = false;
            this.txtCantidadCostos.Enabled = false;
        }
        private void habilitarFormularioCostos()
        {
            this.cboIDsVenta.Enabled = true;
            this.cboEtapa.Enabled = true;
            this.cboSubEtapa.Enabled = true;
            this.cboFrecuenciaCostos.Enabled = true;
            this.cboMesIniCostos.Enabled = true;
            this.txtPrecioUniCostos.Enabled = true;
            // this.txtCantidadCostos.Enabled = true;
        }
        private bool validarFormularioVentas()
        {
            if (this.txtRendimientoUni.Text == null || string.IsNullOrEmpty(this.txtRendimientoUni.Text))
            {
                MessageBox.Show("Debe ingresar el rendimiento por unidad", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtRendimientoUni.Focus();
                return false;
            }
            if (this.txtPrecioUniVentas.Text == null || string.IsNullOrEmpty(this.txtPrecioUniVentas.Text))
            {
                MessageBox.Show("Debe ingresar el precio por unidad", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrecioUniVentas.Focus();
                return false;
            }
            if (this.txtCantidadVentas.Text == null || string.IsNullOrEmpty(this.txtCantidadVentas.Text))
            {
                MessageBox.Show("Debe ingresar la cantidad", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCantidadVentas.Focus();
                return false;
            }
            if (this.cboFrecuenciaVentas.SelectedValue == null || Convert.ToInt32(this.cboFrecuenciaVentas.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la la frecuencia", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFrecuenciaVentas.Focus();
                return false;
            }

            return true;
        }
        private bool validarFormularioCostos()
        {
            if (this.cboIDsVenta.SelectedValue == null || Convert.ToInt32(this.cboIDsVenta.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la venta a la que pertenece el costo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboIDsVenta.Focus();
                return false;
            }
            if (this.cboEtapa.SelectedValue == null || Convert.ToInt32(this.cboEtapa.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la etapa", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEtapa.Focus();
                return false;
            }
            if (this.cboSubEtapa.SelectedValue == null || Convert.ToInt32(this.cboSubEtapa.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la subetapa", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboSubEtapa.Focus();
                return false;
            }
            if (this.cboFrecuenciaCostos.SelectedValue == null || Convert.ToInt32(this.cboFrecuenciaCostos.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la frecuencia", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboFrecuenciaCostos.Focus();
                return false;
            }
            if (this.txtPrecioUniCostos.Text == null || string.IsNullOrEmpty(this.txtPrecioUniCostos.Text))
            {
                MessageBox.Show("Debe ingresar el costo", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrecioUniCostos.Focus();
                return false;
            }
            if (this.txtCantidadCostos.Text == null || string.IsNullOrEmpty(this.txtCantidadCostos.Text))
            {
                MessageBox.Show("Debe la cantidad", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtCantidadCostos.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region eventos

        private void txtRendimientoUni_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotalVentas();
        }

        private void txtPrecioUniVentas_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotalVentas();
        }

        private void txtCantidadVentas_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotalVentas();
        }

        private void calcularTotalVentas()
        {
            if (
                this.txtRendimientoUni.Text == null || string.IsNullOrEmpty(this.txtRendimientoUni.Text) ||
                this.txtPrecioUniVentas.Text == null || string.IsNullOrEmpty(this.txtPrecioUniVentas.Text) ||
                this.txtCantidadVentas.Text == null || string.IsNullOrEmpty(this.txtCantidadVentas.Text)
            )
            {
                this.txtTotalVentas.Text = "0.00";
            }
            else
            {
                decimal nRendimineto = Convert.ToDecimal(this.txtRendimientoUni.Text);
                decimal nPrecio = Convert.ToDecimal(this.txtPrecioUniVentas.Text);
                decimal nCantidad = Convert.ToDecimal(this.txtCantidadVentas.Text);

                decimal nTotal = nRendimineto * nPrecio * nCantidad;
                this.txtTotalVentas.Text = nTotal.ToString("n2");
            }
        }



        private void txtPrecioUniCostos_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotalCostos();
        }

        private void txtCantidadCostos_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotalCostos();
        }

        private void calcularTotalCostos()
        {
            if (
                this.txtPrecioUniCostos.Text == null || string.IsNullOrEmpty(this.txtPrecioUniCostos.Text) ||
                this.txtCantidadCostos.Text == null || string.IsNullOrEmpty(this.txtCantidadCostos.Text)
            )
            {
                this.txtTotalCostos.Text = "0.00";
            }
            else
            {
                decimal nPrecio = Convert.ToDecimal(this.txtPrecioUniCostos.Text);
                decimal nCantidad = Convert.ToDecimal(this.txtCantidadCostos.Text);

                decimal nTotal = nPrecio * nCantidad;
                this.txtTotalCostos.Text = nTotal.ToString("n2");
            }
        }

        private void cboEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboEtapa.SelectedIndex) != -1)
            {
                DataTable dtSubEtapasFiltrado = this.dtSubEtapas.AsEnumerable().Where(item => item.Field<int>("idPadre") == Convert.ToInt32(cboEtapa.SelectedValue)).CopyToDataTable();

                this.cboSubEtapa.DataSource = dtSubEtapasFiltrado;
                this.cboSubEtapa.DisplayMember = "cEtapaPecuario";
                this.cboSubEtapa.ValueMember = "idEtapaPecuario";
            }
        }

        #region ventas

        private void btnNuevoVenta_Click(object sender, EventArgs e)
        {
            this.habilitarFormularioVentas();
            this.btnNuevoVenta.Enabled = false;
            this.btnAgregarVenta.Enabled = true;
            this.btnQuitarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = true;
            this.btnEditarVenta.Enabled = false;

            this.rowVentaSeleccionado = null;
        }
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if (!this.validarFormularioVentas())
            {
                return;
            }

            if (this.lstVentasPecuario.Count > 0)
            {
                MessageBox.Show("No se permite registrar más de una venta", "Registro de Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsActividadPecuaria objVentaPecuario = new clsActividadPecuaria();

            objVentaPecuario.idMovimientoEvalPecuario = 0;
            objVentaPecuario.idEvaluacionPecuaria = this.idEvaluacionPecuaria;
            objVentaPecuario.nRendimientoUni = Convert.ToDecimal(this.txtRendimientoUni.Text);
            objVentaPecuario.nPrecioUni = Convert.ToDecimal(this.txtPrecioUniVentas.Text);
            objVentaPecuario.nCantidad = Convert.ToDecimal(this.txtCantidadVentas.Text);
            objVentaPecuario.nMontoTotal = (Convert.ToDecimal(this.txtRendimientoUni.Text))*(Convert.ToDecimal(this.txtPrecioUniVentas.Text) )*( Convert.ToDecimal(this.txtCantidadVentas.Text));
            objVentaPecuario.idPeriodoCred = Convert.ToInt32(this.cboFrecuenciaVentas.SelectedValue);
            objVentaPecuario.cPeriodoCred = Convert.ToString(this.cboFrecuenciaVentas.Text);
            objVentaPecuario.dMesInicio = Convert.ToDateTime(this.cboMesIniVentas.SelectedValue);
            objVentaPecuario.idTipMovEvalPecuario = 1;

            this.lstVentasPecuario.Add(objVentaPecuario);
            this.bsVentasPecuario.ResetBindings(false);

            this.btnNuevoVenta.Enabled = true;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = false;

            this.deshabilitarFormularioVentas();
            this.limpiarFormularioVentas();
            this.dtgVentasPecuario.ClearSelection();

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnQuitarVenta_Click(object sender, EventArgs e)
        {
            if (this.rowVentaSeleccionado == null)
            {
                return;
            }

            foreach (DataGridViewRow row in this.dtgVentasPecuario.Rows)
            {
                if (row == this.rowVentaSeleccionado)
                {
                    int idMovimientoEvalPecuario = Convert.ToInt32(row.Cells["idMovimientoEvalPecuario"].Value);
                    this.dtgVentasPecuario.Rows.RemoveAt(row.Index);
                    this.lstCostosPecuario = this.lstCostosPecuario.Where(x => x.idPadre != idMovimientoEvalPecuario).ToList();
                }
            }
            this.bsVentasPecuario.ResetBindings(false);

            this.btnNuevoVenta.Enabled = true;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = false;

            this.dtgVentasPecuario.ClearSelection();

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnEditarVenta_Click(object sender, EventArgs e)
        {
            if (!this.validarFormularioVentas())
            {
                return;
            }

            foreach (DataGridViewRow row in this.dtgVentasPecuario.Rows)
            {
                if (row == this.rowVentaSeleccionado)
                {
                    row.Cells["nRendimientoUni"].Value = Convert.ToDecimal(this.txtRendimientoUni.Text);
                    row.Cells["nPrecioUni"].Value = Convert.ToDecimal(this.txtPrecioUniVentas.Text);
                    row.Cells["nCantidad"].Value = Convert.ToDecimal(this.txtCantidadVentas.Text);
                    row.Cells["nMontoTotal"].Value = (Convert.ToDecimal(this.txtRendimientoUni.Text)) * (Convert.ToDecimal(this.txtPrecioUniVentas.Text)) * (Convert.ToDecimal(this.txtCantidadVentas.Text));

                    row.Cells["idPeriodoCred"].Value = Convert.ToInt32(this.cboFrecuenciaVentas.SelectedValue);
                    row.Cells["cPeriodoCred"].Value = Convert.ToString(this.cboFrecuenciaVentas.Text);
                    row.Cells["dMesInicio"].Value = Convert.ToDateTime(this.cboMesIniVentas.SelectedValue);

                    int idMovimientoEvalEditado = Convert.ToInt32(row.Cells["idMovimientoEvalPecuario"].Value);

                    foreach (var objCosto in this.lstCostosPecuario)
                    {
                        if (objCosto.idTipMovEvalPecuario == 2 && objCosto.idPadre == idMovimientoEvalEditado)
                        {
                            objCosto.nCantidad = Convert.ToDecimal(this.txtCantidadVentas.Text);
                            objCosto.nMontoTotal = objCosto.nPrecioUni * Convert.ToDecimal(this.txtCantidadVentas.Text);
                        }
                    }
                }
            }

            this.bsVentasPecuario.ResetBindings(false);

            this.btnNuevoVenta.Enabled = true;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = false;

            this.limpiarFormularioVentas();
            this.deshabilitarFormularioVentas();

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            this.limpiarFormularioVentas();
            this.deshabilitarFormularioVentas();
            this.dtgVentasPecuario.ClearSelection();

            this.btnNuevoVenta.Enabled = true;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = false;
            this.btnCancelarVenta.Enabled = false;

            this.lEditandoVentas = false;
        }

        private void dtgVentasPecuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgVentasPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            if (this.lEditandoVentas)
            {
                return;
            }
            this.btnQuitarVenta.Enabled = true;

            this.rowVentaSeleccionado = this.dtgVentasPecuario.SelectedRows[0];
        }
        
        private void dtgVentasPecuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgVentasPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowVentaSeleccionado = this.dtgVentasPecuario.SelectedRows[0];

            decimal nRendimientoUnidad = Convert.ToDecimal(this.dtgVentasPecuario.SelectedRows[0].Cells["nRendimientoUni"].Value);
            decimal nPrecioUnidad = Convert.ToDecimal(this.dtgVentasPecuario.SelectedRows[0].Cells["nPrecioUni"].Value);
            decimal nCantidad = Convert.ToDecimal(this.dtgVentasPecuario.SelectedRows[0].Cells["nCantidad"].Value);
            int idFrecuencia = Convert.ToInt32(this.dtgVentasPecuario.SelectedRows[0].Cells["idPeriodoCred"].Value);
            DateTime dMesInicio = Convert.ToDateTime(this.dtgVentasPecuario.SelectedRows[0].Cells["dMesInicio"].Value);

            // Llenar formulario
            this.txtRendimientoUni.Text = Convert.ToString(nRendimientoUnidad);
            this.txtPrecioUniVentas.Text = Convert.ToString(nPrecioUnidad);
            this.txtCantidadVentas.Text = Convert.ToString(nCantidad);
            this.cboFrecuenciaVentas.SelectedValue = idFrecuencia;
            this.cboMesIniVentas.SelectedValue = dMesInicio;

            this.habilitarFormularioVentas();

            // Activar boton editar
            this.lEditandoVentas = true;
            this.btnNuevoVenta.Enabled = false;
            this.btnAgregarVenta.Enabled = false;
            this.btnQuitarVenta.Enabled = false;
            this.btnEditarVenta.Enabled = true;
            this.btnCancelarVenta.Enabled = true;
        }

        #endregion




        #region costos

        private void btnNuevoCosto_Click(object sender, EventArgs e)
        {
            this.habilitarFormularioCostos();
            this.btnNuevoCosto.Enabled = false;
            this.btnAgregarCosto.Enabled = true;
            this.btnQuitarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = true;
            this.btnEditarCosto.Enabled = false;

            this.rowCostoSeleccionado = null;
        }
        private void btnAgregarCosto_Click(object sender, EventArgs e)
        {
            if (!this.validarFormularioCostos())
            {
                return;
            }

            clsActividadPecuaria objCostosPecuario = new clsActividadPecuaria();
            
            objCostosPecuario.idMovimientoEvalPecuario = 0;
            objCostosPecuario.idEvaluacionPecuaria = this.idEvaluacionPecuaria;
            objCostosPecuario.idPadre = Convert.ToInt32(this.cboIDsVenta.SelectedValue);
            objCostosPecuario.nPrecioUni = Convert.ToDecimal(this.txtPrecioUniCostos.Text);
            objCostosPecuario.nCantidad = Convert.ToDecimal(this.txtCantidadCostos.Text);
            objCostosPecuario.nMontoTotal = Convert.ToDecimal(this.txtPrecioUniCostos.Text) * Convert.ToDecimal(this.txtCantidadCostos.Text);
            objCostosPecuario.idPeriodoCred = Convert.ToInt32(this.cboFrecuenciaCostos.SelectedValue);
            objCostosPecuario.cPeriodoCred = Convert.ToString(this.cboFrecuenciaCostos.Text);
            objCostosPecuario.dMesInicio = Convert.ToDateTime(this.cboMesIniCostos.SelectedValue);
            objCostosPecuario.idEtapaPecuario = Convert.ToInt32(this.cboEtapa.SelectedValue);
            objCostosPecuario.cEtapaPecuario = Convert.ToString(this.cboEtapa.Text);
            objCostosPecuario.idSubEtapaPecuario = Convert.ToInt32(this.cboSubEtapa.SelectedValue);
            objCostosPecuario.cSubEtapaPecuario = Convert.ToString(this.cboSubEtapa.Text);
            objCostosPecuario.idTipMovEvalPecuario = 2;

            this.lstCostosPecuario.Add(objCostosPecuario);
            this.bsCostosPecuario.ResetBindings(false);

            this.btnNuevoCosto.Enabled = true;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = false;

            this.deshabilitarFormularioCostos();
            this.limpiarFormularioCostos();

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnQuitarCosto_Click(object sender, EventArgs e)
        {
            if (this.rowCostoSeleccionado == null)
            {
                return;
            }

            foreach (DataGridViewRow row in this.dtgCostosPecuario.Rows)
            {
                if (row == this.rowCostoSeleccionado)
                {
                    this.dtgCostosPecuario.Rows.RemoveAt(row.Index);
                }
            }
            this.bsCostosPecuario.ResetBindings(false);
            this.dtgCostosPecuario.ClearSelection();

            this.btnNuevoCosto.Enabled = true;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = false;

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnEditarCosto_Click(object sender, EventArgs e)
        {
            if (!this.validarFormularioCostos())
            {
                return;
            }

            foreach (DataGridViewRow row in this.dtgCostosPecuario.Rows)
            {
                if (row == this.rowCostoSeleccionado)
                {
                    row.Cells["idPadre"].Value = Convert.ToInt32(this.cboIDsVenta.SelectedValue);
                    row.Cells["idEtapaPecuario"].Value = Convert.ToInt32(this.cboEtapa.SelectedValue);
                    row.Cells["cEtapaPecuario"].Value = Convert.ToString(this.cboEtapa.Text);
                    row.Cells["idSubEtapaPecuario"].Value = Convert.ToInt32(this.cboSubEtapa.SelectedValue);
                    row.Cells["cSubEtapaPecuario"].Value = Convert.ToString(this.cboSubEtapa.Text);
                    row.Cells["idPeriodoCred"].Value = Convert.ToInt32(this.cboFrecuenciaCostos.SelectedValue);
                    row.Cells["cPeriodoCred"].Value = Convert.ToString(this.cboFrecuenciaCostos.Text);
                    row.Cells["dMesInicio"].Value = Convert.ToDateTime(this.cboMesIniCostos.SelectedValue);
                    row.Cells["nPrecioUni"].Value = Convert.ToDecimal(this.txtPrecioUniCostos.Text);
                    row.Cells["nCantidad"].Value = Convert.ToDecimal(this.txtCantidadCostos.Text);
                    row.Cells["nMontoTotal"].Value = Convert.ToDecimal(this.txtPrecioUniCostos.Text) * Convert.ToDecimal(this.txtCantidadCostos.Text);
                }
            }

            this.bsCostosPecuario.ResetBindings(false);
            this.limpiarFormularioCostos();
            this.deshabilitarFormularioCostos();

            this.btnNuevoCosto.Enabled = true;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = false;
            this.lEditandoCostos = false;

            this.GrabarRegistro();
            this.obtenerRegistroMovimientos();
        }
        private void btnCancelarCosto_Click(object sender, EventArgs e)
        {
            this.limpiarFormularioCostos();
            this.deshabilitarFormularioCostos();
            this.dtgCostosPecuario.ClearSelection();

            this.btnNuevoCosto.Enabled = true;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = false;
            this.btnCancelarCosto.Enabled = false;

            this.lEditandoCostos = false;
        }

        private void dtgCostosPecuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCostosPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            if (this.lEditandoCostos)
            {
                return;
            }
            this.btnQuitarCosto.Enabled = true;

            this.rowCostoSeleccionado = this.dtgCostosPecuario.SelectedRows[0];
        }
        private void dtgCostosPecuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCostosPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowCostoSeleccionado = this.dtgCostosPecuario.SelectedRows[0];

            int idPadre = Convert.ToInt32(this.dtgCostosPecuario.SelectedRows[0].Cells["idPadre"].Value);
            int idEtapaCrianza = Convert.ToInt32(this.dtgCostosPecuario.SelectedRows[0].Cells["idEtapaPecuario"].Value);
            int idSubEtapaCrianza = Convert.ToInt32(this.dtgCostosPecuario.SelectedRows[0].Cells["idSubEtapaPecuario"].Value);
            int idFrecuencia = Convert.ToInt32(this.dtgCostosPecuario.SelectedRows[0].Cells["idPeriodoCred"].Value);
            DateTime dMesInicio = Convert.ToDateTime(this.dtgCostosPecuario.SelectedRows[0].Cells["dMesInicio"].Value);
            decimal nCostoUni = Convert.ToDecimal(this.dtgCostosPecuario.SelectedRows[0].Cells["nPrecioUni"].Value);
            decimal nCantidad = Convert.ToDecimal(this.dtgCostosPecuario.SelectedRows[0].Cells["nCantidad"].Value);


            // Llenar formulario
            this.cboIDsVenta.SelectedValue = idPadre;
            this.cboEtapa.SelectedValue = idEtapaCrianza;
            this.cboSubEtapa.SelectedValue = idSubEtapaCrianza;
            this.cboFrecuenciaCostos.SelectedValue = idFrecuencia;
            this.cboMesIniCostos.SelectedValue = dMesInicio;
            this.txtPrecioUniCostos.Text = Convert.ToString(nCostoUni);
            this.txtCantidadCostos.Text = Convert.ToString(nCantidad);

            this.habilitarFormularioCostos();

            // Activar boton editar
            this.lEditandoCostos = true;
            this.btnNuevoCosto.Enabled = false;
            this.btnAgregarCosto.Enabled = false;
            this.btnQuitarCosto.Enabled = false;
            this.btnEditarCosto.Enabled = true;
            this.btnCancelarCosto.Enabled = true;
        }

        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.GrabarRegistro();
            this.lEditado = true;
            this.Close();
        }

        private void GrabarRegistro()
        {
            this.lstMovimientosPecuario.Clear();
            decimal nTotalVentas = 0;
            decimal nTotalCostos = 0;
            this.lEditado = true;

            foreach (var item in lstVentasPecuario)
            {
                this.lstMovimientosPecuario.Add(item);

                int nMesInicio = ((item.dMesInicio.Year - this.dFechaRegSolicitud.Year) * 12) + item.dMesInicio.Month - this.dFechaRegSolicitud.Month;
                int nLimite = this.nMeses > 12 ? 12 : this.nMeses;

                while (nMesInicio <= nLimite)
                {
                    nTotalVentas = nTotalVentas + item.nMontoTotal;
                    nMesInicio = nMesInicio + item.idPeriodoCred;
                }
            }



            foreach (var item in lstCostosPecuario)
            {
                this.lstMovimientosPecuario.Add(item);

                int nMesInicio = ((item.dMesInicio.Year - this.dFechaRegSolicitud.Year) * 12) + item.dMesInicio.Month - this.dFechaRegSolicitud.Month;
                int nLimite = this.nMeses > 12 ? 12 : this.nMeses;

                while (nMesInicio <= nLimite)
                {
                    nTotalCostos = nTotalCostos + item.nMontoTotal;
                    nMesInicio = nMesInicio + item.idPeriodoCred;
                }
            }

            string xml = lstMovimientosPecuario.ListObjectToXml<clsActividadPecuaria>("dtTabla", "dsTabla");

            DataTable ds = this.objCapaNegocio.InsActMovimientosEvalPecuario(xml, idEvaluacionPecuaria);
        }

        #endregion

        private void frmDetalleActividadPecuaria_Load(object sender, EventArgs e)
        {
            this.objCapaNegocio = new clsCNEvalAgrop();
            this.obtenerRegistroMovimientos();
        }

        public void EstablecerDetalleInventario(int _idEvalPecuario, int _nMeses, DateTime _dFechaRegSoli, string _cTipoInventario, string _cEspecie, string _cRaza, string _cAnimal, string _cProducto, string _cUniMed, int _idTipoCrianza)
        {
            this.idEvaluacionPecuaria = _idEvalPecuario;
            this.nMeses = _nMeses;
            this.dFechaRegSolicitud = _dFechaRegSoli;

            this.lblTipoInventario.Text = _cTipoInventario;
            this.lblEspecie.Text = _cEspecie;
            this.lblRaza.Text = _cRaza;
            this.lblAnimal.Text = _cAnimal;
            this.lblProductoDerivado.Text = _cProducto;
            this.lblUnidadMedida.Text = _cUniMed;

            this.idTipoCrianza = _idTipoCrianza;
        }

        private void cboIDsVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboIDsVenta.SelectedIndex == -1)
            {
                return;
            }
            int idVenta = Convert.ToInt32(this.cboIDsVenta.SelectedValue);
            decimal nCantidad = 0;

            foreach (var venta in this.lstVentasPecuario)
            {
                if (venta.idMovimientoEvalPecuario == idVenta)
                {
                    nCantidad = venta.nCantidad;
                    break;
                }
            }
            this.txtCantidadCostos.Text = Convert.ToString(nCantidad);
        }
        
    }
}
