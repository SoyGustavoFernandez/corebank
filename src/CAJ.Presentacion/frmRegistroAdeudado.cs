using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{

    public partial class frmRegistroAdeudado : frmBase
    {
        DataTable dtAdeudo_;
        int opcGrabar = 0;
        DataTable dtDesembolsoAdeudo;
        DataTable dtPlanPagos = null;
        decimal nmontoCapAcumulado;
        clsCNControlOpe Adeudo = new clsCNControlOpe();
        DataTable dtTipoProducto = new DataTable("dtTipoProducto");
        DataTable dtDestino = new DataTable("dtDestino");
        private int pidDesembolso;
        private DateTime dFecIniPlanHist;
        private DateTime dFecIniPlan;
        enum Modo { Nuevo, Editar, Agregar, Cancelar, Quitar };
        //DataTable dtQuitarAde = new DataTable();

        private int modoAccion;

        public frmRegistroAdeudado()
        {
            InitializeComponent();
            txtCodigoAdeudo.Text = "0";
        }

        private void frmRegistroAdeudado_Load(object sender, EventArgs e)
        {
            txtMontoFinanciado.Clear();
            //cboTipoEntidad.cargarTipoDeEntidad("1");
            CargarCombosIniciales();
            CargaDatosAdeudado();

            cboTipoOperac_SelectedIndexChanged(sender, e);
            habilitarControles(grbDetalleAdeudado, false);
            habilitarControles(grbPactado, false);
            habilitarControles(grbPagado, false);
            habilitarControles(grbAdeudado, false);
            habilitarBotones(0);
            dtgTipoProducto.ReadOnly = true;
            dtgDestinoAde.ReadOnly = true;

            if (dtgListaAdeudados.RowCount <= 0)
            {
                btnMiniAgregar1.Enabled = false;
                btnQuitar1.Enabled = false;
                btnEditar.Enabled = false;
            }
            CalcularMontosLinea();
            dtgListaAdeudados.EnableHeadersVisualStyles = false;
        }

        private void CargarCombosIniciales()
        {
            clsCNControlOpe Adeudo = new clsCNControlOpe();

            // quitar el evento handler
            cboTipoOperac.SelectedIndexChanged -= new
        EventHandler(cboTipoOperac_SelectedIndexChanged);

            //cargando Tipo de operacion-linea adeudado
            DataTable dtTipoLineaAde = Adeudo.listarLineaAdeudado(0);

            cboTipoOperac.ValueMember = "idTipoLineaAde";
            cboTipoOperac.DisplayMember = "cDescripcion";
            cboTipoOperac.DataSource = dtTipoLineaAde;


            // agregar el evento handler
            cboTipoOperac.SelectedIndexChanged += new
            EventHandler(cboTipoOperac_SelectedIndexChanged);

            //cargando tipos de deudas            
            DataTable dtTipoTasa = Adeudo.listarTipoTasa();
            cboTipoTasa.ValueMember = "idTipoTasaAde";
            cboTipoTasa.DisplayMember = "cDescripcion";
            cboTipoTasa.DataSource = dtTipoTasa;



            //cargando tipos de deudas            
            DataTable dtAdeudo = Adeudo.listarTipoDeuda(1);
            cboTipoDeuda.ValueMember = "idTipoDeuda";
            cboTipoDeuda.DisplayMember = "cDescripcion";
            cboTipoDeuda.DataSource = dtAdeudo;


            //cargando estado de adeudados
            DataTable dtListarEstadiAdeudo = Adeudo.listarEstadoAdeudado();
            cboEstado.ValueMember = "idEstado";
            cboEstado.DisplayMember = "cDescripcion";
            cboEstado.DataSource = dtListarEstadiAdeudo;


            //forma de desembolso
            DataTable dtFormaDesembolso = Adeudo.ListarTipoDesembolso(1);
            cboFormaDesembolso.ValueMember = "idFormaDesembolso";
            cboFormaDesembolso.DisplayMember = "cDescripcion";
            cboFormaDesembolso.DataSource = dtFormaDesembolso;

            //modo reembolso
            DataTable dtFormaReembolso = Adeudo.ListarTipoDesembolso(5);
            cboModoReembolso.ValueMember = "idFormaDesembolso";
            cboModoReembolso.DisplayMember = "cDescripcion";
            cboModoReembolso.DataSource = dtFormaReembolso;
            //lista Año Base
            DataTable dtAñoBase = Adeudo.ListarAñoBase();
            cboAñoBase.ValueMember = "idFechaBase";
            cboAñoBase.DisplayMember = "cDescripcion";
            cboAñoBase.DataSource = dtAñoBase;


            //lista Mes Base
            DataTable dtMesBase = Adeudo.ListarMesBase();
            cboMesBase.ValueMember = "idFechaBase";
            cboMesBase.DisplayMember = "cDescripcion";
            cboMesBase.DataSource = dtMesBase;


            //Lista las frecuencias de pago
            DataTable dtFrecuenciaPago = Adeudo.ListarFrecuenciaPagoAdeudado();
            cboFrecuenciaPago.DisplayMember = "cDescripcion";
            cboFrecuenciaPago.ValueMember = "idFrecuenciaPago";
            cboFrecuenciaPago.DataSource = dtFrecuenciaPago;

            AsignarDatosDesembolso();

        }
        private void CargaDatosAdeudado()
        {
            DataTable dtAdeudo = Adeudo.CNConsultaAdeudado(-1, "%", "%", "1", "%");
            dtAdeudo_ = dtAdeudo;
            dtgListaAdeudados.SelectionChanged -= new EventHandler(dtgListaAdeudados_SelectionChanged);
            dtgListaAdeudados.CellClick -= new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);

            dtgListaAdeudados.DataSource = dtAdeudo;
            dtgListaAdeudados.SelectionChanged += new EventHandler(dtgListaAdeudados_SelectionChanged);
            dtgListaAdeudados.CellClick += new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);
            AsignarDatosAdeudado();
            FormatoAdeudados();
            ListarDesembolso(Convert.ToInt32(txtCodigoAdeudo.Text));
            listarTipoProducto(Convert.ToInt32(txtCodigoAdeudo.Text));
            ListarDestinoAdeudado(Convert.ToInt32(txtCodigoAdeudo.Text));
            if (dtAdeudo.Rows.Count <= 0)
            {
                limpiarDatosAdeudado();
            }
        }
        void ListarDesembolso(int codigoAdeudado)
        {
            //listar Desembolos de adeudado
            DataTable dtDesembolso = Adeudo.ListarDesembolsoAdeudado(codigoAdeudado, "%");
            dtDesembolsoAdeudo = dtDesembolso;
            dtgListaDesembolso.DataSource = dtDesembolso;
            if (dtDesembolso.Rows.Count > 0)
            {
                nmontoCapAcumulado = Convert.ToDecimal(dtDesembolso.Compute("Sum(nCapitalPactado)", "").ToString());
            }
            else
            {
                nmontoCapAcumulado = 0;
            }

            //establecer datos Desembolso
            AsignarDatosDesembolso();
            //establece formato de grid
            FormatoDesembolso();

            ListarPlanPagosAdeudado(pidDesembolso);

        }
        void ListarPlanPagosAdeudado(int codigoDesemAdeudado)
        {
            // Listar destino de Producto credito
            dtPlanPagos = Adeudo.listarPlanPagoAdeudado(codigoDesemAdeudado, "%");
            dtgPlanPagos.DataSource = dtPlanPagos;
            formatoPlanPagos();

        }
        void formatoPlanPagos()
        {
            dtgPlanPagos.Columns["Chk"].Visible = false;
            dtgPlanPagos.Columns["idPlanPagosAde"].Visible = false;
            dtgPlanPagos.Columns["idDesembolso"].Visible = false;
            dtgPlanPagos.Columns["idFromaPagoPlaAde"].Visible = false;
            dtgPlanPagos.Columns["idDocPagoPlaAde"].Visible = false;
            dtgPlanPagos.Columns["cNroDocumento"].Visible = false;
            dtgPlanPagos.Columns["idAdeudado"].Visible = false;
            dtgPlanPagos.Columns["idEstPlaPago"].Visible = false;
            dtgPlanPagos.Columns["idTipoPlazo"].Visible = false;
            dtgPlanPagos.Columns["nNroCuota"].HeaderText = "Nº Cuota";
            dtgPlanPagos.Columns["nNroCuota"].Width = 36;

            dtgPlanPagos.Columns["cTipoCuota"].HeaderText = "Tipo Cuota";
            dtgPlanPagos.Columns["cTipoCuota"].Width = 36;

            dtgPlanPagos.Columns["dFechaVenc"].HeaderText = "Fecha Programado";
            dtgPlanPagos.Columns["dFechaVenc"].Width = 64;

            dtgPlanPagos.Columns["dFechaPago"].HeaderText = "Fecha de Pago";
            dtgPlanPagos.Columns["dFechaPago"].Width = 64;

            dtgPlanPagos.Columns["nCapital"].HeaderText = "Capital Pactado";
            dtgPlanPagos.Columns["nCapital"].Width = 70;

            dtgPlanPagos.Columns["nInteres"].HeaderText = "Interes Pactado";
            dtgPlanPagos.Columns["nInteres"].Width = 70;

            dtgPlanPagos.Columns["nComision"].HeaderText = "Comision Pactado";
            dtgPlanPagos.Columns["nComision"].Width = 68;

            dtgPlanPagos.Columns["nOtros"].HeaderText = "Otros Pactado";
            dtgPlanPagos.Columns["nOtros"].Width = 65;

            dtgPlanPagos.Columns["nCapitalPagado"].HeaderText = "Capital Pagado";
            dtgPlanPagos.Columns["nCapitalPagado"].Width = 70;

            dtgPlanPagos.Columns["nInteresPagado"].HeaderText = "Interes Pagado";
            dtgPlanPagos.Columns["nInteresPagado"].Width = 70;

            dtgPlanPagos.Columns["nComisionPagado"].HeaderText = "Comision Pagado";
            dtgPlanPagos.Columns["nComisionPagado"].Width = 68;

            dtgPlanPagos.Columns["nOtrosPagado"].HeaderText = "Otros Pagado";
            dtgPlanPagos.Columns["nOtrosPagado"].Width = 65;

            dtgPlanPagos.Columns["nMoraPagado"].HeaderText = "Mora Pagado";
            dtgPlanPagos.Columns["nMoraPagado"].Width = 65;


            dtgPlanPagos.Columns["Estado"].HeaderText = "Estado";
            dtgPlanPagos.Columns["Estado"].Width = 67;

            dtgPlanPagos.Columns["cTipPlaCorto"].HeaderText = "Tipo Plazo";
            dtgPlanPagos.Columns["cTipPlaCorto"].Width = 36;

        }
        void listarTipoProducto(int codigoAdeudado)
        {
            // Listar destino de Producto credito
            dtTipoProducto = Adeudo.ListarProductoAdeudado(codigoAdeudado);
            dtTipoProducto.Columns["Chk"].ReadOnly = false;

            dtgTipoProducto.Columns.Clear();
            dtgTipoProducto.DataSource = dtTipoProducto;
            dtgTipoProducto.Enabled = true;
            dtgTipoProducto.Columns["IdProducto"].Visible = false;
            dtgTipoProducto.Columns["idProductoAdeudado"].Visible = false;
            dtgTipoProducto.Columns["idAdeudado"].Visible = false;

            dtgTipoProducto.ColumnHeadersVisible = false;
            dtgTipoProducto.Columns["Chk"].Width = 30;
        }
        void ListarDestinoAdeudado(int codigoAdeudado)
        {
            //Destino del adeudado
            dtDestino = Adeudo.ListarDestinoAdeudado(codigoAdeudado);
            dtDestino.Columns["Chk"].ReadOnly = false;
            dtgDestinoAde.Columns.Clear();
            dtgDestinoAde.DataSource = dtDestino;

            formatoDestinoGrid();
        }
        void formatoDestinoGrid()
        {
            //configurando            	
            dtgDestinoAde.Columns["idDestinoAdeudado"].Visible = false;
            dtgDestinoAde.Columns["idAdeudado"].Visible = false;
            dtgDestinoAde.Columns["idDestino"].Visible = false;
            dtgDestinoAde.Columns["Chk"].Width = 22;
            dtgDestinoAde.ColumnHeadersVisible = false;
            dtgDestinoAde.Enabled = true;
            dtgDestinoAde.ReadOnly = false;
        }
        void AsignarDatosAdeudado()
        {
            if (dtgListaAdeudados.RowCount > 0)
            {
                cboTipoEntidad.cargarTipoDeEntidad("%");
                cboTipoEntidad.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idTipoEntidad"].Value);
                cboEntidad.CargarEntidades(Convert.ToInt32(cboTipoEntidad.SelectedValue));
                cboEntidad.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idEntidad"].Value);
                cboTipoOperac.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idTipoOperacion"].Value);
                cboTipoLinea.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idTipoLinea"].Value);


                dtpFechaContrato.Value = Convert.ToDateTime(dtgListaAdeudados.CurrentRow.Cells["dFechaContrato"].Value.ToString());
                cboTipoDeuda.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idTipoDeuda"].Value);
                cboEstado.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idEstado"].Value);
                txtLinea.Text = dtgListaAdeudados.CurrentRow.Cells["cDescripcionLinea"].Value.ToString();
                dtpFechaCancelacion.Value = Convert.ToDateTime(dtgListaAdeudados.CurrentRow.Cells["dFechaCancelacion"].Value.ToString());
                txtMontoFinanciado.Text = dtgListaAdeudados.Rows[dtgListaAdeudados.SelectedCells[0].RowIndex].Cells["nMonFinanciado"].Value.ToString();
                cboMoneda.SelectedValue = Convert.ToInt32(dtgListaAdeudados.CurrentRow.Cells["idMoneda"].Value);
                txtCodigoAdeudo.Text = dtgListaAdeudados.CurrentRow.Cells["idAdeudado"].Value.ToString();
                txtSaldoAdeudado.Text = dtgListaAdeudados.CurrentRow.Cells["nSaldo"].Value.ToString();
                txtCodAdeudado1.Text = txtCodigoAdeudo.Text;
            }
        }
        void AsignarDatosDesembolso()
        {
            if (dtgListaDesembolso.Rows.Count > 0)
            {
                pidDesembolso = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idDesembolso"].Value.ToString());
                cboFormaDesembolso.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idFormaDesembolso"].Value.ToString());
                cboAñoBase.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idAñoBase"].Value.ToString());
                cboMesBase.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idMesBase"].Value.ToString());
                cboFrecuenciaPago.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idMesBase"].Value.ToString());
                cboTipoTasa.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idTipoTasa"].Value.ToString());
                txtValTasa.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nValorTasa"].Value.ToString();
                cboModoReembolso.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idModoReembolso"].Value.ToString());
                cboFrecuenciaPago.SelectedValue = Convert.ToInt32(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["idFrecuenciaPago"].Value.ToString());

                txtNroPagare.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["cNroPagre"].Value.ToString();
                txtNroPagare1.Text = txtNroPagare.Text;

                dtpFechaDes.Value = Convert.ToDateTime(dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["dFechaDesembolso"].Value);
                txtNroCuotas.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nCuotas"].Value.ToString();
                txtCuotasAmortiza.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nCuotasAmortizadas"].Value.ToString();
                txtSecuencia.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nSecuencia"].Value.ToString();

                txtCapitalPactado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nCapitalPactado"].Value.ToString();
                txtInteresPactado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nInteresPactado"].Value.ToString();
                txtComisionesPactado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nComisionPactado"].Value.ToString();
                txtOtrosPactado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nOtrosPactado"].Value.ToString();

                txtCapitalPagado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nCapitalPagado"].Value.ToString();
                txtInteresPagado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nInteresPagado"].Value.ToString();
                txtComisionPagado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nComisionPagado"].Value.ToString();
                txtOtrosPagado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nOtrosPagado"].Value.ToString();
                txtMoraPagado.Text = dtgListaDesembolso.Rows[dtgListaDesembolso.SelectedCells[0].RowIndex].Cells["nMoraPagado"].Value.ToString();
                ListarPlanPagosAdeudado(pidDesembolso);
            }
            else
            {
                limpiarDatosDesembolso();
            }
        }
        private Boolean valida()
        {

            if (String.IsNullOrEmpty(this.txtNroPagare.Text))
            {
                MessageBox.Show("Ingrese Nro de Pagaré", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroPagare.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboTipoEntidad.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Entidad", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoEntidad.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboEntidad.Text.ToString()))
            {
                MessageBox.Show("Seleccione la Entidad", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEntidad.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboTipoOperac.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Operación", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoOperac.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboTipoLinea.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Linea", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoLinea.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboTipoDeuda.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Deuda", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDeuda.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboMoneda.Text.ToString()))
            {
                MessageBox.Show("Seleccione Tipo de Moneda", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }
            else if (this.dtpFechaCancelacion.Value.Date <= this.dtpFechaContrato.Value.Date)
            {
                MessageBox.Show("La fecha de cancelación debe ser mayor que la fecha de contrato, Registre Correctamente su Plan de Pagos", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaContrato.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtLinea.Text) || txtLinea.Text.Length < 6)
            {
                MessageBox.Show("Ingrese una Descripción Correcta", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLinea.Focus();
                return false;
            }
            else if (this.dtpFechaDes.Value.Date < this.dtpFechaContrato.Value.Date)
            {
                MessageBox.Show("La fecha de Desembolso debe ser mayor que la fecha de contrato", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (String.IsNullOrEmpty(cboFormaDesembolso.Text.ToString()))
            {
                MessageBox.Show("Seleccione la forma de Desembolso", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFormaDesembolso.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboAñoBase.Text.ToString()))
            {
                MessageBox.Show("Seleccione Año Base", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAñoBase.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboMesBase.Text.ToString()))
            {
                MessageBox.Show("Seleccione Mes Base", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMesBase.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboTipoTasa.Text.ToString()))
            {
                MessageBox.Show("Seleccione tipo de Tasa", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoTasa.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtValTasa.Text.ToString()) || Convert.ToDecimal (txtValTasa.Text) > 100)
            {
                MessageBox.Show("El Valor de la tasa debe estar entre 0% y 100% ", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValTasa.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboModoReembolso.Text.ToString()))
            {
                MessageBox.Show("Seleccione Modo de Reembolso", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboModoReembolso.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cboFrecuenciaPago.Text.ToString()))
            {
                MessageBox.Show("Seleccione Frecuencia de Pago", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFrecuenciaPago.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtNroCuotas.Text) || Convert.ToInt32(this.txtNroCuotas.Text) == 0)
            {
                MessageBox.Show("El Nro de Cuotas debe ser mayor a CERO, Ingrese su Plan de Pagos", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCuotas.Focus();
                return false;
            }
            if (this.dtpFechaDes.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de desembolso no puede ser mayor a la del sistema", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaDes.Focus();
                return false;
            }
            else if (Convert.ToDecimal(this.txtCapitalPactado.Text) == 0)
            {
                MessageBox.Show("Capital Pactado debe ser mayor a CERO, Ingrese su Plan de Pagos ", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (Convert.ToDecimal(this.txtInteresPactado.Text) == 0)
            {
                MessageBox.Show("Interes debe ser mayor a CERO, Ingese su Plan de Pagos", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //else if (Convert.ToDecimal(this.txtComisionesPactado.Text) == 0)
            //{
            //    MessageBox.Show("Comisión debe ser mayor a CERO, Ingrese su Plan de Pagos", "Registro Adeudado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            else if (string.IsNullOrEmpty(this.txtOtrosPagado.Text))
            {
                this.txtOtrosPagado.Text = "0";
            }
            if (modoAccion == (int)Modo.Agregar)
            {
                if (nmontoCapAcumulado + Convert.ToDecimal(txtMontoTotal.Text) > Convert.ToDecimal(txtMontoFinanciado.Text))
                {
                    MessageBox.Show("El Monto del Desembolso Excede al Monto Financiado", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (Convert.ToDecimal(txtMontoTotal.Text) == 0)
            {
                MessageBox.Show("El Monto Financiado debe ser Mayor a Cero", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToDecimal(txtValTasa.Text) == 0)
            {
                MessageBox.Show("El Valor de la Tasa debe ser Mayor a Cero", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int count = 0;
            foreach (DataGridViewRow item in dtgDestinoAde.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Chk"].Value) == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Debe Seleccionar Por lo Menos un Destino", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtgDestinoAde.Focus();
                return false;
            }
            count = 0;
            foreach (DataGridViewRow item in dtgTipoProducto.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Chk"].Value) == true)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Debe Seleccionar Por lo Menos un Tipo de Producto", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtgTipoProducto.Focus();
                return false;
            }
            if (dtgPlanPagos.RowCount <= 0)
            {
                MessageBox.Show("Ingrese plan de Pagos", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (modoAccion == (int)Modo.Editar)
            {
                if (dFecIniPlanHist <= dtpFechaContrato.Value)
                {
                    MessageBox.Show("la primera cuota debe ser mayor a la fecha del contrato", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               string nMontoAcu= dtDesembolsoAdeudo.Compute("Sum(nCapitalPactado)", "idDesembolso <> " + pidDesembolso).ToString();
               if (string.IsNullOrEmpty(nMontoAcu))
               {
                   nMontoAcu = "0";
               }
               if (Convert.ToDecimal(txtMontoFinanciado.Text)< Convert.ToDecimal(nMontoAcu) + Convert.ToDecimal(txtMontoTotal.Text))
               {
                   MessageBox.Show("El Monto Financiado debe ser mayor a la suma de montos desembolsados", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return false;
               }
               dFecIniPlan = Convert.ToDateTime(dtPlanPagos.Compute("Min(dFechaVenc)", "idDesembolso = " + pidDesembolso));
            }

            if (dFecIniPlan <= dtpFechaDes.Value)
            {
                MessageBox.Show("la primera cuota debe ser mayor a la fecha del desembolso", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }

        void FormatoDesembolso()
        {
            dtgListaDesembolso.Columns["idAdeudado"].Visible = false;
            dtgListaDesembolso.Columns["idDesembolso"].Visible = false;
            dtgListaDesembolso.Columns["idFormaDesembolso"].Visible = false;
            dtgListaDesembolso.Columns["idAñoBase"].Visible = false;
            dtgListaDesembolso.Columns["idMesBase"].Visible = false;
            dtgListaDesembolso.Columns["idTipoTasa"].Visible = false;
            dtgListaDesembolso.Columns["nValorTasa"].Visible = false;
            dtgListaDesembolso.Columns["idModoReembolso"].Visible = false;
            dtgListaDesembolso.Columns["idFrecuenciaPago"].Visible = false;
            dtgListaDesembolso.Columns["dFechaDesembolso"].Visible = false;
            dtgListaDesembolso.Columns["nCuotas"].Visible = false;
            dtgListaDesembolso.Columns["nCuotasAmortizadas"].Visible = false;
            dtgListaDesembolso.Columns["nCapitalPactado"].Visible = false;
            dtgListaDesembolso.Columns["nInteresPactado"].Visible = false;
            dtgListaDesembolso.Columns["nComisionPactado"].Visible = false;
            dtgListaDesembolso.Columns["nOtrosPactado"].Visible = false;
            dtgListaDesembolso.Columns["nCapitalPagado"].Visible = false;
            dtgListaDesembolso.Columns["nInteresPagado"].Visible = false;
            dtgListaDesembolso.Columns["nComisionPagado"].Visible = false;
            dtgListaDesembolso.Columns["nOtrosPagado"].Visible = false;
            dtgListaDesembolso.Columns["nMoraPagado"].Visible = false;
            dtgListaDesembolso.Columns["idEstadoAde"].Visible = false;
            dtgListaDesembolso.Columns["nFecMinPlanPag"].Visible = false;
            //configurando
            dtgListaDesembolso.Columns["nSecuencia"].HeaderText = "Secuencia";
            dtgListaDesembolso.Columns["cDescripcion"].HeaderText = "Descripcion";
            dtgListaDesembolso.Columns["cNroPagre"].HeaderText = "Nº de Pagaré";
            dtgListaDesembolso.Columns["cEstado"].HeaderText = "Estado";

            dtgListaDesembolso.Columns["nSecuencia"].Width = 55;
            dtgListaDesembolso.Columns["cDescripcion"].Width = 100;
            dtgListaDesembolso.Columns["cNroPagre"].Width = 80;
            dtgListaDesembolso.Columns["cEstado"].Width = 70;




        }
        void FormatoAdeudados()
        {
            dtgListaAdeudados.Columns["idAdeudado"].HeaderText = "Código";
            dtgListaAdeudados.Columns["cDescripcionLinea"].HeaderText = "Descripción";
            dtgListaAdeudados.Columns["nMonFinanciado"].HeaderText = "Monto línea";
            dtgListaAdeudados.Columns["nMonFinanciado"].DefaultCellStyle.Format = "N2";
            dtgListaAdeudados.Columns["cNombreCorto"].HeaderText = "Entidad";
            dtgListaAdeudados.Columns["dFechaContrato"].Visible = false;
            dtgListaAdeudados.Columns["cMoneda"].Visible = false;
            dtgListaAdeudados.Columns["dFechaCancelacion"].Visible = false;
            dtgListaAdeudados.Columns["idMoneda"].Visible = false;
            dtgListaAdeudados.Columns["idEntidad"].Visible = false;
            dtgListaAdeudados.Columns["idTipoOperacion"].Visible = false;
            dtgListaAdeudados.Columns["idTipoLinea"].Visible = false;
            dtgListaAdeudados.Columns["idTipoDeuda"].Visible = false;
            dtgListaAdeudados.Columns["idTipoEntidad"].Visible = false;
            dtgListaAdeudados.Columns["idEstado"].Visible = false;


            dtgListaAdeudados.Columns["nSaldo"].Visible = false;

            dtgListaAdeudados.Columns["idAdeudado"].Width = 45;
            dtgListaAdeudados.Columns["nMonFinanciado"].Width = 90;
        }

        void habilitarBotones(int nOpcion)
        {
            switch (nOpcion)
            {
                case 1://nuevo
                    this.btnGrabar.Enabled = true;
                    this.btnCancelar1.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnNuevo1.Enabled = false;
                    this.btnMiniAgregar1.Enabled = false;
                    this.btnQuitar1.Enabled = false;
                    this.btnAgregarPlan.Enabled = true;
                    this.btnQuitarPlan.Enabled = true;
                    break;
                case 2://Editar
                    this.btnGrabar.Enabled = true;
                    this.btnCancelar1.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnNuevo1.Enabled = false;
                    this.btnMiniAgregar1.Enabled = false;
                    this.btnQuitar1.Enabled = false;
                    this.btnAgregarPlan.Enabled = true;
                    this.btnQuitarPlan.Enabled = true;
                    break;
                default:
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnNuevo1.Enabled = true;
                    this.btnMiniAgregar1.Enabled = true;
                    this.btnQuitar1.Enabled = true;
                    this.btnAgregarPlan.Enabled = false;
                    this.btnQuitarPlan.Enabled = false;
                    break;
            }
        }

        void limpiarDatosDesembolso()
        {
            cboFormaDesembolso.SelectedValue = -1;
            cboAñoBase.SelectedValue = -1;
            cboMesBase.SelectedValue = -1;
            cboTipoTasa.SelectedValue = -1;
            txtValTasa.Text = "0.00";
            cboModoReembolso.SelectedValue = -1;
            cboFrecuenciaPago.SelectedValue = -1;
            txtCapitalPactado.Text = "0.00";
            txtComisionesPactado.Text = "0.00";
            txtInteresPactado.Text = "0.00";
            txtOtrosPactado.Text = "0.00";

            txtCapitalPagado.Text = "0.00";
            txtComisionPagado.Text = "0.00";
            txtInteresPagado.Text = "0.00";
            txtOtrosPagado.Text = "0.00";
            txtMontoTotal.Text = "0.00";
            txtMoraPagado.Text = "0.00";
            txtNroCuotas.Clear();
            txtCuotasAmortiza.Text = "0";
            txtNroPagare.Clear();
            txtNroPagare1.Clear();
            txtSaldoAdeudado.Text = "0.00";
        }


        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgListaAdeudados.RowCount <= 0)
            {
                MessageBox.Show("Seleccione un Adeudado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            habilitarControles(grbDetalleAdeudado, true);
            habilitarControles(grbAdeudado, true);
            habilitarBotones(1);
            txtMontoTotal.Enabled = false;
            dtgListaDesembolso.Enabled = false;
            dtgListaAdeudados.Enabled = false;
            txtCuotasAmortiza.Enabled = false;
            txtNroCuotas.Enabled = false;
            txtSecuencia.Enabled = false;
            txtSaldoAdeudado.Enabled = false;
            cboEstado.Enabled = false;
            dtgTipoProducto.ReadOnly = false;
            dtgTipoProducto.Columns["Chk"].ReadOnly = false;
            dtgTipoProducto.Columns["cProducto"].ReadOnly = true;

            dtgDestinoAde.ReadOnly = false;
            dtgDestinoAde.Columns["Chk"].ReadOnly = false;
            dtgDestinoAde.Columns["cDestino"].ReadOnly = true;

            txtCodigoAdeudo.ReadOnly = true;
            dtpFechaCancelacion.Enabled = false;
            btnBusqueda1.Enabled = false;
            nmontoCapAcumulado = 0;
            btnAgregarPlan.Enabled = false;
            btnQuitarPlan.Enabled = false;
            cboMoneda.Enabled = false;
            modoAccion = (int)Modo.Editar;
            txtMonLineaUsada.Enabled = false;
            txtMonLineaDisponible.Enabled = false;
            if (Convert.ToInt32(dtPlanPagos.Compute("count(idEstPlaPago)", "idEstPlaPago=2")) >= 1)
            {
                btnAgregarPlan.Enabled = false;
                btnQuitarPlan.Enabled = false;
            }
            else
            {
                btnAgregarPlan.Enabled = true;
                btnQuitarPlan.Enabled = true;
            }
            dFecIniPlanHist = Convert.ToDateTime(dtDesembolsoAdeudo.Rows[0]["nFecMinPlanPag"].ToString());
           
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDetalleAdeudado, true);
            habilitarControles(grbAdeudado, true);
            cboTipoEntidad.cargarTipoDeEntidad("1");
            habilitarBotones(1);
            txtMontoTotal.Enabled = false;
            dtgListaDesembolso.Enabled = false;
            dtgListaAdeudados.Enabled = false;
            txtCuotasAmortiza.Enabled = false;
            txtNroCuotas.Enabled = false;
            txtSecuencia.Enabled = false;
            txtSaldoAdeudado.Enabled = false;

            btnAgregarPlan.Enabled = true;
            btnQuitarPlan.Enabled = true;

            dtPlanPagos.Rows.Clear();
            dtDesembolsoAdeudo.Rows.Clear();
            limpiarDatosDesembolso();
            pidDesembolso = 0;
            this.txtCodigoAdeudo.Text = "0";
            this.txtSecuencia.Text = "1";

            dtgTipoProducto.ReadOnly = false;
            dtgTipoProducto.Columns["Chk"].ReadOnly = false;
            dtgTipoProducto.Columns["cProducto"].ReadOnly = true;

            dtgDestinoAde.ReadOnly = false;
            dtgDestinoAde.Columns["Chk"].ReadOnly = false;
            dtgDestinoAde.Columns["cDestino"].ReadOnly = true;

            foreach (DataRow dtRow in dtTipoProducto.Rows)
            {
                dtRow["chk"] = 0;
            }
            foreach (DataRow dtRow in dtDestino.Rows)
            {
                dtRow["Chk"] = 0;
            }
            dtgDestinoAde.Refresh();
            dtgTipoProducto.Refresh();
            limpiarDatosAdeudado();
            txtCodigoAdeudo.ReadOnly = true;
            dtpFechaCancelacion.Enabled = false;
            cboEstado.Enabled = false;
            txtCodAdeudado1.Clear();
            txtNroPagare1.Clear();
            btnBusqueda1.Enabled = false;
            nmontoCapAcumulado = 0;
            cboTipoEntidad.Focus();
            cboMoneda.Enabled = true;
            txtMonLineaUsada.Clear();
            txtMonLineaDisponible.Clear();

            txtMonLineaUsada.Enabled = false;
            txtMonLineaDisponible.Enabled = false;

            modoAccion = (int)Modo.Nuevo;
        }
        void limpiarDatosAdeudado()
        {

            txtNroPagare.Clear();
            cboTipoEntidad.SelectedValue = -1;
            cboTipoOperac.SelectedValue = -1;
            cboTipoLinea.SelectedValue = -1;
            txtLinea.Clear();
            txtMontoFinanciado.Clear();
            cboTipoDeuda.SelectedValue = -1;
            cboMoneda.SelectedValue = -1;
            cboEstado.SelectedValue = 1;
            dtpFechaContrato.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechaDes.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechaCancelacion.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            txtMontoFinanciado.Clear();
            habilitarControles(grbDetalleAdeudado, false);
            habilitarControles(grbAdeudado, false);


            habilitarBotones(0);

            AsignarDatosAdeudado();
            AsignarDatosDesembolso();

            ListarDesembolso(Convert.ToInt32(txtCodigoAdeudo.Text));
            listarTipoProducto(Convert.ToInt32(txtCodigoAdeudo.Text));
            ListarDestinoAdeudado(Convert.ToInt32(txtCodigoAdeudo.Text));

            dtgListaDesembolso.Enabled = true;
            dtgListaAdeudados.Enabled = true;
            txtCuotasAmortiza.Enabled = false;

            dtgTipoProducto.ReadOnly = true;
            dtgDestinoAde.ReadOnly = true;
            btnBusqueda1.Enabled = true;
            if (dtgListaAdeudados.RowCount <= 0)
            {
                btnMiniAgregar1.Enabled = false;
                btnQuitar1.Enabled = false;
                btnEditar.Enabled = false;

            }
            modoAccion = (int)Modo.Cancelar;
            CalcularMontosLinea();
        }

        private void txtCapitalPactado_TextChanged(object sender, EventArgs e)
        {
            calcularMontototal();

        }

        private void txtInteresPactado_TextChanged(object sender, EventArgs e)
        {
            calcularMontototal();
        }

        private void txtComisionesPactado_TextChanged(object sender, EventArgs e)
        {
            calcularMontototal();
        }

        private void txtOtrosPactado_TextChanged(object sender, EventArgs e)
        {
            calcularMontototal();
        }


        void calcularMontototal()
        {
            try
            {
                txtMontoTotal.Text = txtCapitalPactado.Text;
            }
            catch (Exception)
            {


            }
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEntidad.CargarEntidadesFondeo(Convert.ToInt32(cboTipoEntidad.SelectedValue), "1");
        }

        private void dtgListaDesembolso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarDatosDesembolso();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgListaAdeudados.RowCount <= 0)
            {
                MessageBox.Show("Seleccione un Adeudado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            habilitarControles(grbDetalleAdeudado, true);
            habilitarBotones(1);
            txtMontoTotal.Enabled = false;
            dtgListaDesembolso.Enabled = false;
            dtgListaAdeudados.Enabled = false;
            txtCuotasAmortiza.Enabled = false;
            txtSaldoAdeudado.Enabled = false;
            //limpiarDatosDesembolso();
            txtNroCuotas.Enabled = false;
            txtSecuencia.Enabled = false;
            dtPlanPagos.Rows.Clear();

            txtCapitalPactado.Text = "0.00";
            txtComisionesPactado.Text = "0.00";
            txtInteresPactado.Text = "0.00";
            txtOtrosPactado.Text = "0.00";

            txtCapitalPagado.Text = "0.00";
            txtComisionPagado.Text = "0.00";
            txtInteresPagado.Text = "0.00";
            txtOtrosPagado.Text = "0.00";
            txtMontoTotal.Text = "0.00";
            txtMoraPagado.Text = "0.00";
            txtNroCuotas.Clear();
            txtCuotasAmortiza.Text = "0";
            txtNroPagare.Clear();
            txtNroPagare1.Clear();
            txtSaldoAdeudado.Text = "0.00";

            txtSecuencia.Text = dtDesembolsoAdeudo.Compute("Max(nSecuencia)+1", "").ToString();
            nmontoCapAcumulado = Convert.ToDecimal(dtDesembolsoAdeudo.Compute("Sum(nCapitalPactado)", "").ToString());
            modoAccion = (int)Modo.Agregar;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de Quitar el Desembolso?", "Consulta: Desembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("El Desembolso se Quito Satisfactoriamente", "Mensaje Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            opcGrabar = 1;
            clsCNControlOpe InsertaActualizaAdeudo = new clsCNControlOpe();
            dtgListaAdeudados.CellClick -= new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);
            dtgListaAdeudados.SelectionChanged -= new EventHandler(dtgListaAdeudados_SelectionChanged);
            #region QuitarPagare
            if (modoAccion == (int)Modo.Quitar)
            {
                //=================  Registro Inicio Rastreo ===================================
                this.registrarRastreo(0, 0, "Inicio - Quitar Pagaré de Adeudado", btnGrabar);
                //==============================================================================

                int idAdeudado = Convert.ToInt32(txtCodigoAdeudo.Text);
                decimal nMontoPagare = Convert.ToDecimal(txtMontoTotal.Text);
                DataTable QuitaAde = InsertaActualizaAdeudo.CNQuitarPagareAdeudado(idAdeudado, pidDesembolso, nMontoPagare, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario);

                //=================   Registro Fin Rastreo    ================================
                this.registrarRastreo(0, 0, "Fin - Quitar Pagaré de Adeudado", btnGrabar);
                //============================================================================

                MessageBox.Show(QuitaAde.Rows[0]["mResp"].ToString() + " N° " + txtNroPagare.Text + " \n del  adeudado N° " + txtCodigoAdeudo.Text, @"Quitar pagaré del adeudado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }
            #endregion

            #region Agregar Pagare Editar adeudado

            if (modoAccion != (int)Modo.Quitar)
            {
                string msg = "";
                if (!valida())
                {
                    return;
                }
                msg = "Se registro el Adeudado Nro. ";
                if (this.txtCodigoAdeudo.Text != "0")
                {
                    msg = "Se actualizo el Adeudado Nro. ";
                }
                //en el caso que se agrege nuevo pagare
                if ((int)Modo.Agregar == modoAccion)
                {
                    int ValidaExistencia = InsertaActualizaAdeudo.CNValidarExistenciaAdeudado(txtNroPagare.Text.Trim(), dtDesembolsoAdeudo, -1);
                    if (ValidaExistencia >= 1)
                    {
                        MessageBox.Show("Ya existe el número de pagaré", "Registro Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //en el caso que se agrege nuevo pagare
                if ((int)Modo.Editar == modoAccion)
                {
                    int index = dtgListaDesembolso.SelectedCells[0].RowIndex + 1;
                    int ValidaExistencia = InsertaActualizaAdeudo.CNValidarExistenciaAdeudado(txtNroPagare.Text.Trim(), dtDesembolsoAdeudo, index);
                    if (ValidaExistencia >= 1)
                    {
                        MessageBox.Show("Ya existe el número de pagaré", "Registro Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                dtAdeudo_.Clear();
                DataRow drAdeudo = dtAdeudo_.NewRow();
                drAdeudo["idAdeudado"] = this.txtCodigoAdeudo.Text;
                drAdeudo["idEntidad"] = this.cboEntidad.SelectedValue;
                drAdeudo["idTipoOperacion"] = this.cboTipoOperac.SelectedValue;
                drAdeudo["idTipoLinea"] = this.cboTipoLinea.SelectedValue;
                drAdeudo["cDescripcionLinea"] = this.txtLinea.Text;
                drAdeudo["dFechaContrato"] = this.dtpFechaContrato.Value;
                drAdeudo["idTipoDeuda"] = this.cboTipoDeuda.SelectedValue;
                drAdeudo["nMonFinanciado"] = this.txtMontoFinanciado.Text;
                drAdeudo["idMoneda"] = this.cboMoneda.SelectedValue;
                drAdeudo["dFechaCancelacion"] = this.dtpFechaCancelacion.Value;
                drAdeudo["idEstado"] = this.cboEstado.SelectedValue;

                dtAdeudo_.Rows.Add(drAdeudo);

                dtDesembolsoAdeudo.Clear();
                DataRow drDesembolsoAdeudo = dtDesembolsoAdeudo.NewRow();
                drDesembolsoAdeudo["idDesembolso"] = pidDesembolso;
                drDesembolsoAdeudo["idAdeudado"] = this.txtCodigoAdeudo.Text;
                drDesembolsoAdeudo["cNroPagre"] = this.txtNroPagare.Text;
                drDesembolsoAdeudo["nSecuencia"] = this.txtSecuencia.Text;
                drDesembolsoAdeudo["idFormaDesembolso"] = this.cboFormaDesembolso.SelectedValue;
                drDesembolsoAdeudo["idAñoBase"] = this.cboAñoBase.SelectedValue;
                drDesembolsoAdeudo["idMesBase"] = this.cboMesBase.SelectedValue;
                drDesembolsoAdeudo["idTipoTasa"] = this.cboTipoTasa.SelectedValue;
                drDesembolsoAdeudo["nValorTasa"] = this.txtValTasa.Text;
                drDesembolsoAdeudo["idModoReembolso"] = this.cboModoReembolso.SelectedValue;
                drDesembolsoAdeudo["idFrecuenciaPago"] = this.cboFrecuenciaPago.SelectedValue;
                drDesembolsoAdeudo["dFechaDesembolso"] = this.dtpFechaDes.Value;
                drDesembolsoAdeudo["nCuotas"] = this.txtNroCuotas.Text;
                drDesembolsoAdeudo["nCuotasAmortizadas"] = this.txtCuotasAmortiza.Text;
                drDesembolsoAdeudo["nCapitalPactado"] = this.txtCapitalPactado.Text;
                drDesembolsoAdeudo["nInteresPactado"] = this.txtInteresPactado.Text;
                drDesembolsoAdeudo["nComisionPactado"] = this.txtComisionesPactado.Text;
                drDesembolsoAdeudo["nOtrosPactado"] = this.txtOtrosPactado.Text;
                drDesembolsoAdeudo["idEstadoAde"] = this.cboEstado.SelectedValue;

                drDesembolsoAdeudo["nCapitalPagado"] = this.txtCapitalPagado.Text;
                drDesembolsoAdeudo["nInteresPagado"] = this.txtInteresPagado.Text;
                drDesembolsoAdeudo["nComisionPagado"] = this.txtComisionPagado.Text;
                drDesembolsoAdeudo["nOtrosPagado"] = this.txtOtrosPagado.Text;
                drDesembolsoAdeudo["nMoraPagado"] = this.txtMoraPagado.Text;

                dtDesembolsoAdeudo.Rows.Add(drDesembolsoAdeudo);

                DataSet ds = new DataSet("dsAdeudo");
                ds.Tables.Add(dtAdeudo_);
                String XmlSoli = ds.GetXml();
                XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);

                DataSet dsDesembolso = new DataSet("dsDesembolsoAdeudado");
                dsDesembolso.Tables.Add(dtDesembolsoAdeudo);
                String XmlDesembolso = dsDesembolso.GetXml();
                XmlDesembolso = clsCNFormatoXML.EncodingXML(XmlDesembolso);


                //xml tipo de producto 

                dtTipoProducto.Columns["idAdeudado"].Expression = this.txtCodigoAdeudo.Text;

                DataSet dsTipoProd = new DataSet("dsTipoProdAdeudado");
                dsTipoProd.Tables.Add(dtTipoProducto);
                String XmlTipoProd = dsTipoProd.GetXml();

                //xml tipo de producto 

                dtDestino.Columns["idAdeudado"].Expression = this.txtCodigoAdeudo.Text;
                DataSet dsDestinoAde = new DataSet("dsDestinoAdeudado");
                dsDestinoAde.Tables.Add(dtDestino);
                String XmldsDestinoAde = dsDestinoAde.GetXml();

                DataSet dsPlanPagoAdeudado = new DataSet("dsPlanPagoAdeudado");
                dsPlanPagoAdeudado.Tables.Add(dtPlanPagos);
                String XmlPlanPagoAdeudado = dsPlanPagoAdeudado.GetXml();



                //=================  Registro Inicio Rastreo ===================================
                this.registrarRastreo(0, 0, "Inicio - Registro de Adeudado", btnGrabar);
                //==============================================================================

                DataTable InsAde = InsertaActualizaAdeudo.CNInsUpAdeudado(XmlSoli, XmlDesembolso, XmlTipoProd, XmldsDestinoAde, XmlPlanPagoAdeudado, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario);

                //=================   Registro Fin Rastreo    ================================
                this.registrarRastreo(0, 0, "Fin - Registro de Adeudado", btnGrabar);
                //============================================================================

                MessageBox.Show(msg + InsAde.Rows[0]["idCodAde"].ToString(), "Registro Adeudados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds.Dispose();
                dtAdeudo_.Dispose();
            }
            #endregion

            btnGrabar.Enabled = false;
            habilitarControles(grbDetalleAdeudado, false);
            CargaDatosAdeudado();
            btnCancelar1_Click(sender, e);
            dtgListaAdeudados.SelectionChanged += new EventHandler(dtgListaAdeudados_SelectionChanged);
            dtgListaAdeudados.CellClick += new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);
            CalcularMontosLinea();
            opcGrabar = 0;
        }

        private void cboTipoOperac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsCNControlOpe tipoOperac = new clsCNControlOpe();
                //cargando Tipo de operacion-linea adeudado
                DataTable dtTipoLineaAde = tipoOperac.listarLineaAdeudado(Convert.ToInt32(cboTipoOperac.SelectedValue.ToString()));
                cboTipoLinea.ValueMember = "idTipoLineaAde";
                cboTipoLinea.DisplayMember = "cDescripcion";
                cboTipoLinea.DataSource = dtTipoLineaAde;
            }
            catch (Exception)
            {


            }

        }

        private void btnAgregarPlan_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelHandler excel = new ExcelHandler();
                DataTable dtTmpPlanPagos;
                dtTmpPlanPagos = excel.ImportExcelToDataTable(openFileDialog1.FileName);

                DateTime dFechaIni = clsVarGlobal.dFecSystem;//corregir esto es por temas de pruebas
                DateTime dFechaVen;


                dtPlanPagos.Clear();
                for (int i = 0; i <= dtTmpPlanPagos.Rows.Count - 1; i++)
                {
                    try
                    {
                        DataRow drPlanPagoAdeudo = dtPlanPagos.NewRow();
                        drPlanPagoAdeudo["idPlanPagosAde"] = 0;
                        drPlanPagoAdeudo["idDesembolso"] = pidDesembolso;
                        string nNroCuota = dtTmpPlanPagos.Rows[i][0].ToString();
                        string cTipoCuota = dtTmpPlanPagos.Rows[i][1].ToString();
                        string nCapital = dtTmpPlanPagos.Rows[i][2].ToString();
                        if (nNroCuota.Equals("") && cTipoCuota.Equals("") && nCapital.Equals(""))
                        {
                            MessageBox.Show("Verifique que la plantilla Excel este correcto...", "Advertencia: Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        drPlanPagoAdeudo["nNroCuota"] = nNroCuota; //Nro Cuota
                        drPlanPagoAdeudo["cTipoCuota"] = cTipoCuota;//Tipo Cuota                    
                        drPlanPagoAdeudo["nCapital"] = nCapital;//Capital Pactado
                        drPlanPagoAdeudo["nInteres"] = dtTmpPlanPagos.Rows[i][3].ToString();//Interes Pactado
                        drPlanPagoAdeudo["nComision"] = dtTmpPlanPagos.Rows[i][4].ToString();//Comision Pactado
                        drPlanPagoAdeudo["nOtros"] = dtTmpPlanPagos.Rows[i][5].ToString();//Otros Pactado
                        drPlanPagoAdeudo["dFechaVenc"] = dtTmpPlanPagos.Rows[i][6].ToString();//fecha Vencimiento

                        dFechaVen = Convert.ToDateTime(drPlanPagoAdeudo["dFechaVenc"]);
                        drPlanPagoAdeudo["idTipoPlazo"] = (dFechaVen - dFechaIni).TotalDays <= 360 ? 1 : 2;//id Tipo plazo
                        drPlanPagoAdeudo["cTipPlaCorto"] = (dFechaVen - dFechaIni).TotalDays <= 360 ? "CP" : "LP";//nombre corto del tipo de plazo
                        dtPlanPagos.Rows.Add(drPlanPagoAdeudo);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Verifique que la plantilla Excel este correcto...", "Advertencia: Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnGrabar.Enabled = false;
                        return;
                    }

                }
                if (dtPlanPagos.Compute("Max(nNroCuota)", "").ToString() == (dtPlanPagos.Rows.Count).ToString())
                {
                    dtgPlanPagos.DataSource = dtPlanPagos;
                    txtCapitalPactado.Text = dtPlanPagos.Compute("Sum(nCapital)", "").ToString();
                    txtInteresPactado.Text = dtPlanPagos.Compute("Sum(nInteres)", "").ToString();
                    txtComisionesPactado.Text = dtPlanPagos.Compute("Sum(nComision)", "").ToString();
                    txtOtrosPactado.Text = dtPlanPagos.Compute("Sum(nOtros)", "").ToString();
                    txtNroCuotas.Text = dtPlanPagos.Compute("Max(nNroCuota)", "").ToString();

                    dtpFechaCancelacion.Value = Convert.ToDateTime(dtPlanPagos.Compute("Max(dFechaVenc)", "nNroCuota=" + txtNroCuotas.Text));
                    dFecIniPlan = Convert.ToDateTime(dtPlanPagos.Compute("Min(dFechaVenc)", "nNroCuota=1"));

                    btnGrabar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El Nro de Cuotas no Coincide con el Nro de  Registros... ", "Advertencia: Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                formatoPlanPagos();

            }
        }

        private void dtgListaAdeudados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (opcGrabar == 0)
            {
                AsignarDatosAdeudado();
                ListarDesembolso(Convert.ToInt32(txtCodigoAdeudo.Text));
                listarTipoProducto(Convert.ToInt32(txtCodigoAdeudo.Text));
                ListarDestinoAdeudado(Convert.ToInt32(txtCodigoAdeudo.Text));
                dtgTipoProducto.ReadOnly = true;
                dtgDestinoAde.ReadOnly = true;
                //calcular la linea disponible y linea usada
                CalcularMontosLinea();
            }
        }


        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            btnBusqueda1.Enabled = false;
            frmBuscarAdeudado buscarAdeudado = new frmBuscarAdeudado();
            buscarAdeudado.ShowDialog();
            if (buscarAdeudado.dtExternoAdeudado != null)
            {
                dtAdeudo_ = buscarAdeudado.dtExternoAdeudado;
                dtgListaAdeudados.SelectionChanged -= new EventHandler(dtgListaAdeudados_SelectionChanged);
                dtgListaAdeudados.CellClick -= new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);

                dtgListaAdeudados.DataSource = buscarAdeudado.dtExternoAdeudado;
                dtgListaAdeudados.SelectionChanged += new EventHandler(dtgListaAdeudados_SelectionChanged);
                dtgListaAdeudados.CellClick += new DataGridViewCellEventHandler(dtgListaAdeudados_CellClick);
                AsignarDatosAdeudado();
                FormatoAdeudados();
                ListarDesembolso(Convert.ToInt32(txtCodigoAdeudo.Text));
                listarTipoProducto(Convert.ToInt32(txtCodigoAdeudo.Text));
                ListarDestinoAdeudado(Convert.ToInt32(txtCodigoAdeudo.Text));
                //calcular la linea disponible y linea usada
                CalcularMontosLinea();
            }

            btnBusqueda1.Enabled = true;
        }

        private void CalcularMontosLinea()
        {
            if (dtDesembolsoAdeudo.Rows.Count>0)
            {
                txtMonLineaDisponible.Text = (Convert.ToDecimal(txtMontoFinanciado.Text) - Convert.ToDecimal(dtDesembolsoAdeudo.Compute("Sum(nCapitalPactado)", "")) + Convert.ToDecimal(dtDesembolsoAdeudo.Compute("Sum(nCapitalPagado)", ""))).ToString();
                txtMonLineaUsada.Text = (Convert.ToDecimal(dtDesembolsoAdeudo.Compute("Sum(nCapitalPactado)", "")) - Convert.ToDecimal(dtDesembolsoAdeudo.Compute("Sum(nCapitalPagado)", ""))).ToString();
            }
            
        }
        private void btnQuitarPlan_Click(object sender, EventArgs e)
        {
            dtPlanPagos.Clear();
            txtCapitalPactado.Text = "0.00";
            txtInteresPactado.Text = "0.00";
            txtComisionesPactado.Text = "0.00";
            txtOtrosPactado.Text = "0.00";
            txtNroCuotas.Text = "0";
            dtpFechaCancelacion.Value = clsVarGlobal.dFecSystem;

        }

        private void dtgListaAdeudados_SelectionChanged(object sender, EventArgs e)
        {
            if (opcGrabar == 0)
            {
                AsignarDatosAdeudado();
                ListarDesembolso(Convert.ToInt32(txtCodigoAdeudo.Text));
                listarTipoProducto(Convert.ToInt32(txtCodigoAdeudo.Text));
                ListarDestinoAdeudado(Convert.ToInt32(txtCodigoAdeudo.Text));
                dtgTipoProducto.ReadOnly = true;
                dtgDestinoAde.ReadOnly = true;
                //calcular la linea disponible y linea usada
                CalcularMontosLinea();
            }

        }

        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            txtLinea.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtNroPagare_TextChanged(object sender, EventArgs e)
        {
            txtNroPagare.CharacterCasing = CharacterCasing.Upper;
            txtNroPagare1.Text = txtNroPagare.Text;
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgListaAdeudados.RowCount <= 0)
            {
                MessageBox.Show("Seleccione un Adeudado", "Advertencia: Anular pagaré", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgListaDesembolso.Rows.Count == 1)
            {
                MessageBox.Show(@"No puede anular el pagaré, debido a que una linea necesita por lo menos un pagaré", "Advertencia: Anular pagaré", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(@"¿Está seguro de anular el pagaré?", "Advertencia: Anular pagaré", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (Convert.ToInt32(dtPlanPagos.Compute("count(idEstPlaPago)", "idEstPlaPago=2")) >= 1)
            {
                MessageBox.Show(@"No puede anular el pagaré, ya se realizó el pago de cuotas del plan de pagos ... ", "Advertencia: Anular pagaré", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            habilitarBotones(1);
            modoAccion = (int)Modo.Quitar;
            int indiceAnular = dtgListaDesembolso.SelectedCells[0].RowIndex;
            pidDesembolso = Convert.ToInt32(dtgListaDesembolso.Rows[indiceAnular].Cells["idDesembolso"].Value.ToString());
            dtDesembolsoAdeudo.Rows[indiceAnular]["cEstado"] = "Anular";
            dtgListaDesembolso.Refresh();
            dtgListaDesembolso.Enabled = false;
        }

        private void dtgListaAdeudados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }

}
