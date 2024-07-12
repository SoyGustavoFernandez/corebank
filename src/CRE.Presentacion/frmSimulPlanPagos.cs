using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using ADM.CapaNegocio;
using System.Collections;
using GEN.Funciones;
using GEN.Servicio;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmSimulPlanPagos : frmBase
    {
        #region Variables Globales

        /// <summary>
        /// Plan de pagos generado por los parámetros ingresados en el formulario
        /// </summary>
        public DataTable dtCalendarioPagos = new DataTable("dtPlanPago");
        private DataTable dtModificaciones;
        private DataTable dtCargaGastos = new DataTable("dtCargaGastos");
        private DataTable dtCuotasDobles;

        private clsCNConfigGastComiSeg cnconfiguragasto = new clsCNConfigGastComiSeg();
        private clsCNPlanPago cnplanpago = new clsCNPlanPago();
        private clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        private clsCNPaqueteSeguro objPaqueteSeguroCN = new clsCNPaqueteSeguro();
        private clsCNDetalleGasto objDetalleGasto = new clsCNDetalleGasto();

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private List<clsMantenimientoPaqueteSeguro> lstPaqueteSegurosTmp = new List<clsMantenimientoPaqueteSeguro>();

        private decimal nCapitalMaxCobSeg;

        private bool lEnabledGastos = true;
        private bool lVerificarError;

        private int idProducto;

        #endregion

        public frmSimulPlanPagos()
        {
            InitializeComponent();
            InitForm();
        }

        #region Eventos

        private void frmPlanPagos_Load(object sender, EventArgs e)
        {
            conCreditoPrimeraCuota.ValueChangedFecha -= conCreditoPrimeraCuota_ValueChangedFecha;
            dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;

            activarControlObjetos(this, EventoFormulario.INICIO);
            dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
            cboTipoValor_SelectedIndexChanged(sender, e);
            cboGrupoGasto_SelectedIndexChanged(sender, e);            

            conPlanPagos1.asignarMaxMinAnios();

            conCreditoPeriodo.asignarPeriodoCredito(
                (int)TipoPeriodo.FechaFija,
                clsVarGlobal.dFecSystem.Day,
                (int)OperacionCredito.Otorgamiento,
                (int)nudNumCuota.Value);

            conCreditoPrimeraCuota.asignarPrimeraCuota(
                (int)TipoPeriodo.FechaFija,
                clsVarGlobal.dFecSystem.Day,
                (int)this.nudDiasGracia.Value,
                clsVarGlobal.dFecSystem,
                (int)nudNumCuota.Value,
                (int)OperacionCredito.Otorgamiento);

            CargarConfiguracionesDeGasto();

            int nFormaCalculoTasa = clsVarApl.dicVarGen["nFormaCalculoTasa"];
            nCapitalMaxCobSeg = clsVarApl.dicVarGen["nMaxSaldoAseguradoSoles"];
            switch (nFormaCalculoTasa)
            {
                case 1:
                    lblTasaInteres.Text = "Tasa Efectiva Anual:";
                    break;
                case 2:
                    lblTasaInteres.Text = "Tasa Efectiva Mensual:";
                    break;
            }
            chcMantenerCuotasCtes.Checked = true;

            conCreditoPrimeraCuota.ValueChangedFecha += conCreditoPrimeraCuota_ValueChangedFecha;
            dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (conPlanPagos1.dtgCalendario.Rows.Count == 0)
            {
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            bool existeColumna = false;
            bool existeColumnaPaquete = false;
            if (!conPlanPagos1.dtCalendarioPagos.Columns.Contains("seguro"))
            {
                existeColumna = true;
                DataColumn segurosColumn = new DataColumn("seguro", typeof(decimal));
                segurosColumn.DefaultValue = 0;
                conPlanPagos1.dtCalendarioPagos.Columns.Add(segurosColumn);
            }
            if (!conPlanPagos1.dtCalendarioPagos.Columns.Contains("paquete"))
            {
                existeColumnaPaquete = true;
                DataColumn segurosColumn = new DataColumn("paquete", typeof(decimal));
                segurosColumn.DefaultValue = 0;
                conPlanPagos1.dtCalendarioPagos.Columns.Add(segurosColumn);
            }

            conPlanPagos1.dtgCalendario.Columns["seguro"].Visible = false;
            conPlanPagos1.dtgCalendario.Columns["paquete"].Visible = false;

            if (conPlanPagos1.dtCalendarioPagos.Rows[0]["seguro"] == DBNull.Value)
            {
                foreach (DataRow row in conPlanPagos1.dtCalendarioPagos.Rows)
                {
                    row["seguro"] = 0;
                }
            }

            if (conPlanPagos1.dtCalendarioPagos.Rows[0]["paquete"] == DBNull.Value)
            {
                foreach (DataRow row in conPlanPagos1.dtCalendarioPagos.Rows)
                {
                    row["paquete"] = 0;
                }
            }
            paramlist.Add(new ReportParameter("nMontoAprobado", txtMonAprobado.Text.Trim(), false));
            paramlist.Add(new ReportParameter("nNumCuotas", nudNumCuota.Value.ToString().Trim(), false));
            paramlist.Add(new ReportParameter("dFecDesembolso", dtpFecDesembolso.Value.ToString("dd/MMM/yyyy").ToUpper(), false));
            paramlist.Add(new ReportParameter("nDiasGracia", nudDiasGracia.Value.ToString().Trim(), false));
            paramlist.Add(new ReportParameter("cTipoPeriodo", conCreditoPeriodo.cTipoPeriodo, false));
            paramlist.Add(new ReportParameter("nTem", (conPlanPagos1.txtTEM.nvalor / 100.00).ToString().Trim(), false));
            paramlist.Add(new ReportParameter("nTea", (conPlanPagos1.txtTEA.nvalor / 100.00).ToString().Trim(), false));
            paramlist.Add(new ReportParameter("nTcea", (conPlanPagos1.txtTCEA.nvalor / 100.00).ToString().Trim(), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.Trim(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dtsCalendario", conPlanPagos1.dtCalendarioPagos));
            string reportpath = "rptCalendarioSimulador.rdlc";
            frmReporteLocal reportelocal= new frmReporteLocal(dtslist, reportpath, paramlist);
            reportelocal.rpvReporteLocal.ZoomPercent = 120;
            reportelocal.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            reportelocal.ShowDialog();
            if (existeColumna) conPlanPagos1.dtCalendarioPagos.Columns.Remove("seguro");
            if (existeColumnaPaquete) conPlanPagos1.dtCalendarioPagos.Columns.Remove("Paquete");
        }

        private void btnProcesar1_Click_1(object sender, EventArgs e)
        {
            if (conPlanPagos1.dtgModificaciones.DataSource != null)
            {
                ((DataTable)conPlanPagos1.dtgModificaciones.DataSource).Clear();
            }

            if (!Validaingresodatos())
                return;

            if (!validarPaqueteDeSeguros(true)) return;

            CalcularPlanpagos();
            
        }

        private void cboGrupoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdGrupoGasto = Convert.ToInt32(cboGrupoGasto.SelectedValue.ToString());
            cboTipoGasto.DataSource = cnconfiguragasto.CargarConcepto(nIdGrupoGasto);
            cboTipoGasto.DisplayMember = "cConcepto";
            cboTipoGasto.ValueMember = "idConcepto";
            cboTipoGasto.Enabled = nIdGrupoGasto > 0;
        }

        private void cboTipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cTipoValor = cboTipoValor.GetItemText(cboTipoValor.SelectedItem);
            lblPorcentaje.Visible = !cTipoValor.Equals("FIJO");
            cboAplicaConcepto.Enabled = !cTipoValor.Equals("FIJO");
            txtValorCarga.MaxLength = cTipoValor.Equals("FIJO") ? 14 : 8;
            txtValorCarga.nNumDecimales = cTipoValor.Equals("FIJO") ? 2 : 4;
            txtValorCarga.Text = cTipoValor.Equals("FIJO") ? "0.00" : "0.0000";
            txtValorCarga.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validar que los campos a gregar contengan un valor
            if (string.IsNullOrEmpty(txtValorCarga.Text))
            {
                txtValorCarga.Focus();
                MessageBox.Show("Debe ingresar el Monto del Gasto a Cargar", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValorCarga.Focus();
                return;
            }
            if (Convert.ToDecimal(txtValorCarga.Text) <= 0)
            {
                MessageBox.Show("El monto GASTO A CARGAR debe ser mayor a CERO", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValorCarga.Focus();
                return;
            }

            var idMonedaGasto = Convert.ToInt32(cboMoneda.SelectedValue);
            var nIdTipoGasto = Convert.ToInt32(cboTipoGasto.SelectedValue);
            var nIdTipoValor = Convert.ToInt32(cboTipoValor.SelectedValue);
            var nIdCuota = Convert.ToInt32(cboAplicaCuota.SelectedValue);
            var nExisteGasto = dtCargaGastos.AsEnumerable().Count(x => (int)x["nIdMoneda"] == idMonedaGasto
                                                                && (int)x["nIdTipoGasto"] == nIdTipoGasto
                                                                && (int)x["nIdTipoValor"] == nIdTipoValor
                                                                && (int)x["nIdCuota"] == nIdCuota);

            if (nExisteGasto > 0)
            {
                MessageBox.Show("Ya se agregó un gastos con esas características", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValorCarga.Focus();
                return;
            }

            //Validar los gastos que se encuentran en la lista -- para el caso cuando se desee CUOTAS CONSTANTES
            if (chcMantenerCuotasCtes.Checked)
            {
                VerificarConsistenciaTasasParaCuotasConstantes();//Para los gastos que ya se encuentren en la lista para aplicar ala SIMULACION 
                if (lVerificarError)//Se ha encontrado errores al verificar tasas para CUOTAS CONSTNTES
                {
                    return;
                }
            }

            //agregar los campos de acuerdo al tipo da valor
            if (cboTipoValor.Text.Equals("FIJO"))
            {
                if (Convert.ToDecimal(txtValorCarga.Text) > 9999)
                {
                    MessageBox.Show("El VALOR FIJO no debe ser mayor a 9999", "Simulador de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValorCarga.Focus();
                    return;
                }
                if (!validarPaqueteDeSeguros()) return; //REQ 401
                AgregarGasto(Convert.ToInt32(cboMoneda.SelectedValue), cboMoneda.Text, Convert.ToInt32(cboAplicaCuota.SelectedValue), cboAplicaCuota.Text, Convert.ToDecimal(txtValorCarga.Text), Convert.ToInt32(cboTipoGasto.SelectedValue), cboTipoGasto.Text, Convert.ToInt32(cboTipoValor.SelectedValue), cboTipoValor.Text, Convert.ToInt32(cboAplicaConcepto.SelectedValue), String.Empty);
            }
            else
            {
                if (Convert.ToDecimal(txtValorCarga.Text) > 100)
                {
                    MessageBox.Show("El VALOR PORCENTUAL no puede ser mayor que 100%", "Simulador de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValorCarga.Focus();
                    return;
                }
                if (!validarPaqueteDeSeguros()) return; //REQ 401
                AgregarGasto(Convert.ToInt32(cboMoneda.SelectedValue), cboMoneda.Text, Convert.ToInt32(cboAplicaCuota.SelectedValue), cboAplicaCuota.Text, Convert.ToDecimal(txtValorCarga.Text), Convert.ToInt32(cboTipoGasto.SelectedValue), cboTipoGasto.Text, Convert.ToInt32(cboTipoValor.SelectedValue), cboTipoValor.Text, Convert.ToInt32(cboAplicaConcepto.SelectedValue), cboAplicaConcepto.Text);
            }

            dtgConfigGasto.ClearSelection();
        }

        /// <summary>
        /// Este es un método que valida que el seguro de desgravamen individual se haya seleccionado previamente para poder escoger un paquete de seguros
        /// </summary>
        /// <param name="isValidar">valida si estoy en la accion de agregar o procesar</param>
        /// <returns>boleano evaluando si previamente se agregó el seguro desgravamen individual</returns>
        private bool validarPaqueteDeSeguros(bool isValidar = false)
        {
            DataTableToList objDataTableConfig = new DataTableToList();

            // Obtiene la lista de detalles de gasto correspondientes al tipo de gasto seleccionado.
            var lstDetalleGasto = objDetalleGasto.CNListarDetalleTipoGasto(Convert.ToInt32(cboTipoGasto.SelectedValue.ToString()));

            // Obtiene el objeto de paquete de seguros según el ID del concepto de gasto seleccionado.
            clsMantenimientoPaqueteSeguro objPaqueteSeguros = DataTableToList.ConvertToObject<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.ADObtenerPaqueteSeguroPorIDConcepto(Convert.ToInt32(cboTipoGasto.SelectedValue.ToString())));// new clsMantenimientoPaqueteSeguro { idDetalleGasto = 1, dFechaRegistro = DateTime.Now, dFechaFinRegistro = DateTime.Now, cEstado = true };

            //Si no selecciono un paquete, salgo de la validación
            //if (objPaqueteSeguros.idPaqueteSeguro == 0) return true;

            // Obtiene la lista de todos los paquetes de seguros.
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            lstPaqueteSegurosTmp = lstPaqueteSeguros;

            // Verifica si existe el seguro de desgravamen individual en los gastos cargados.
            if (lstPaqueteSeguros.Count > 0)
            {
                bool existeDesgravamenIndividual = dtCargaGastos.AsEnumerable().Any(fila => fila.Field<object>("nIdTipoGasto") != null && fila.Field<object>("nIdTipoGasto").ToString() == lstPaqueteSeguros.FirstOrDefault().idConceptoDetalleGasto.ToString());
                if (!existeDesgravamenIndividual && lstPaqueteSeguros.Any(x => x.idConcepto.ToString() == cboTipoGasto.SelectedValue.ToString()))
                {
                    MessageBox.Show("Para seleccionar un plan de seguro, debe haber seleccionado el seguro Desgravamen Individual", "Simulador de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (dtCargaGastos.Rows.Count > 0 && !validarDuplicidadPaqueteSeguros(isValidar))
            {
                MessageBox.Show("Solo puede seleccionar un máximo de "+ clsVarApl.dicVarGen["nMaximoPlanesSeguro"] +" Plan de Seguro", "Simulador de Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Este es un método que valida que se seleccione el monto máximo de paquetes de seguro permitidos
        /// </summary>
        /// <param name="isValidar">valida si estoy en la accion de agregar o procesar</param>
        /// <returns>boleano evaluando si los seguros agregados son mayores a los permitidos</returns>
        private bool validarDuplicidadPaqueteSeguros(bool isValidar)
        {
            if (lstPaqueteSegurosTmp.Count == 0) return true;
            int nmaximoPaqueteSeguros = clsVarApl.dicVarGen["nMaximoPlanesSeguro"];
            int nTotalSegurosAgregados = dtCargaGastos.AsEnumerable().Count(row => row["nIdTipoGasto"] != null && lstPaqueteSegurosTmp.Any(objeto => objeto.idConcepto.ToString() == row["nIdTipoGasto"].ToString())) - Convert.ToInt32(isValidar);
            return nTotalSegurosAgregados < nmaximoPaqueteSeguros;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(dtgConfigGasto.SelectedRows.Count == 0)
                return;

            int nfilaseleccionadaCargaGasto = Convert.ToInt32(dtgConfigGasto.SelectedRows[0].Index);

            ((DataTable)dtgConfigGasto.DataSource).Rows.RemoveAt(nfilaseleccionadaCargaGasto);

            btnQuitar.Enabled = dtgConfigGasto.RowCount > 0;
            dtgConfigGasto.ClearSelection();
        }

        private void chcMantenerCuotasCtes_CheckedChanged(object sender, EventArgs e)
        {
            //Hasta aqui ya se ha validado que los gastos con que afecten a SALDO CAPITAL, se apliquen a TODAS LAS CUOTAS
            //if (chcMantenerCuotasCtes.Checked == true)//Verificar que en la lista de gastos que afecten a SALDO CAPITAL, se tenga PORCENTUAL SIMPLE ó COMPUESTO (no ambos)
            //{
            //    VerificarConsistenciaTasasParaCuotasConstantes();//Para los gastos que ya se encuentren en la lista para aplicar ala SIMULACION               
            //}
            //else
            //{
            //    ConvertirTasasParaCuotasNoConstantes();
            //}
        }
        
        private void conCreditoPeriodo_ChangeTipoPeriodo(object sender, EventArgs e)
        {
            int nPerDiaReset = 0;
            this.conCreditoPrimeraCuota.resetearFechaSelec(this.dtpFecDesembolso.Value, this.conCreditoPeriodo.idTipoPeriodo, ref nPerDiaReset);
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija)
            {
                this.nudDiasGracia.Value = 0;
                this.nudNumCuota.Enabled = true;
                if ((int)this.nudNumCuota.Value == 1)
                    this.nudNumCuota.Value = 2;
            }
            else
            {

                this.nudDiasGracia.Value = 0;
            }
            this.conCreditoPeriodo.actualizarDia(nPerDiaReset);
            this.calcularFechaPrimeraCuota();

            this.conPlanPagos1.asignarMaxMinAnios();
            this.conPlanPagos1.dtgModificaciones.DataSource = null;
            dtModificaciones.Rows.Clear();
        }
               
        private void tabParametros_Enter(object sender, EventArgs e)
        {
            conPlanPagos1.dtgCalendario.DataSource = null;
            conPlanPagos1.dtgModificaciones.DataSource = null;
            conPlanPagos1.dtModificaciones.Clear();
            conPlanPagos1.cboAccionCuota1.SelectedIndex = -1;
            conPlanPagos1.limpiarControlesTotales();
            txtMonAprobado.Focus();
            txtMonAprobado.SelectAll();
        }


        #region Productos

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                idProducto = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(idProducto);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
                cboSubTipoCredito.DataSource = null;
            }
            cboProducto.DataSource = null;
            cboSubProducto.DataSource = null;
            AsignarTasa();
        }

        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                idProducto = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(idProducto);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
                cboProducto.DataSource = null;
            }
            cboSubProducto.DataSource = null;
            AsignarTasa();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                idProducto = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(idProducto);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
                cboSubProducto.DataSource = null;
            }
            AsignarTasa();
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubProducto.SelectedIndex >= 0)
            {
                AsignarTasa();
            }
        }

        #endregion
        

        private void txtMonAprobado_Leave(object sender, EventArgs e)
        {
            AsignarTasa();
        }

        private void cboMoneda2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex >= 0)
            {
                AsignarTasa();
            }
        }

        private void nudNumCuota_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudNumCuota.Value.ToString().Length;
            nudNumCuota.Select(0, nLonTex);
        }

        private void nudPeriodo_Enter(object sender, EventArgs e)
        {
            //int nLonTex = nudPeriodo.Value.ToString().Length;
            //nudPeriodo.Select(0, nLonTex);
        }

        private void nudDiasGracia_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudDiasGracia.Value.ToString().Length;
            nudDiasGracia.Select(0, nLonTex);
        }

        private void dtpFecDesembolso_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFecDesembolso.Value < clsVarGlobal.dFecSystem)
            {
                this.dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
                this.dtpFecDesembolso.MinDate = clsVarGlobal.dFecSystem;
                this.dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
                return;
            }

            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                if (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.PeriodoFijo
                    && !this.conCreditoPeriodo.lUnicuota)
                    this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
            }
            else
            {
                this.conCreditoPrimeraCuota.inicializarFecha(this.dtpFecDesembolso.Value);
            }
        }

        private void nudPeriodo_ValueChanged(object sender, EventArgs e)
        {
            this.calcularFecPrimeraCuota();
        }

        private void dtgCalendario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 1)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("dd/MMM/yyyy").ToUpper();
                    e.FormattingApplied = true;
                }
            }
        }

        private void nudPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            this.calcularFecPrimeraCuota();
        }

        private void nudDiasGracia_ValueChanged(object sender, EventArgs e)
        {
            AsignarTasa();
        }

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTasaCredito.SelectedIndex < 0) 
                return;

            var drTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;
            decimal nTasaMin = Convert.ToDecimal(drTasa["nTasaCompensatoria"]);
            decimal nTasaMax = Convert.ToDecimal(drTasa["nTasaCompensatoriaMax"]);
            decimal nTasaInt = nTasaMax;

            txtTasCompensatoriaMin.Text = nTasaMin.ToString("#,0.0000");
            txtTasCompensatoriaMax.Text = nTasaMax.ToString("#,0.0000");
            txtTasaInteres.Text = nTasaInt.ToString("#,0.0000");

            txtTasaInteres.Focus();
            txtTasaInteres.SelectAll();
        }

        private void nudNumCuota_ValueChanged(object sender, EventArgs e)
        {
            conPlanPagos1.asignarMaxMinAnios();
            AsignarTasa();
        }


        private void cboClasificacionInterna1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClasificacionInterna1.SelectedIndex != -1)
            {
                AsignarTasa();
            }
        }

        private void CargarConfiguracionSeguro()
        {
            objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
            objSolicitudCreditoCargaSeguro.nEsSimulador         = 1;
            objSolicitudCreditoCargaSeguro.idProducto           = Convert.ToInt32(cboSubProducto.SelectedValue);
            objSolicitudCreditoCargaSeguro.nMontoSolicitado     = (!String.IsNullOrEmpty(txtMonAprobado.Text)) ? Convert.ToDecimal(txtMonAprobado.Text) : 0;
            objSolicitudCreditoCargaSeguro.nCuotas              = Convert.ToInt32(nudNumCuota.Value);
            objSolicitudCreditoCargaSeguro.idTipoPlazo          = this.conCreditoPeriodo.idTipoPeriodo;
            objSolicitudCreditoCargaSeguro.nPlazo               = this.conCreditoPeriodo.nPeriodoDia;
            objSolicitudCreditoCargaSeguro.idMoneda             = Convert.ToInt32(cboMoneda.SelectedValue);
            objSolicitudCreditoCargaSeguro.cMoneda              = cboMoneda.Text;
            objSolicitudCreditoCargaSeguro.dFechaDesembolso     = dtpFecDesembolso.Value;
            objSolicitudCreditoCargaSeguro.dFechaCancelacion    = clsVarGlobal.dFecSystem;
            objSolicitudCreditoCargaSeguro.nDiasGracia          = Convert.ToInt32(nudDiasGracia.Value);
            objSolicitudCreditoCargaSeguro.nCuotaGracia         = Convert.ToInt32(nudDiasGracia.Value);
            objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota = conCreditoPrimeraCuota.dFechaPriCuota();

            frmSolicitudCreditoCargaSeguro frmCreditoCargaSeguro = new frmSolicitudCreditoCargaSeguro(objSolicitudCreditoCargaSeguro, true, validarSeleccionPreviaDesgravamen());
            frmCreditoCargaSeguro.ShowDialog();
            objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = frmCreditoCargaSeguro.objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro;

            if ((objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro) || (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0 && !item.lSeleccionado)))
            {
                decimal nMontoActual = (!String.IsNullOrEmpty(txtMonAprobado.Text)) ? Convert.ToDecimal(txtMonAprobado.Text) : 0;
                if (objSolicitudCreditoCargaSeguro.lAceptacionInclusionCapital)
                {
                    decimal nMontoSolicitadoSeguro = nMontoActual + objSolicitudCreditoCargaSeguro.nMontoPrimaTotal;
                    txtMonAprobado.Text = Convert.ToString(nMontoSolicitadoSeguro);
                }
                else
                {
                    txtMonAprobado.Text = Convert.ToString(nMontoActual);
                }
                
                if (nMontoActual != objSolicitudCreditoCargaSeguro.nMontoSolicitado)
                {
                    MessageBox.Show("Verifique las condiciones del crédito, estos cambiaron debido a la inclusión de los seguros.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

        }

        private bool validarSeleccionPreviaDesgravamen()
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (lstPaqueteSeguros.Count == 0) return true;
            bool existeDesgravamenIndividual = dtCargaGastos.AsEnumerable().Any(fila => fila.Field<object>("nIdTipoGasto") != null && fila.Field<object>("nIdTipoGasto").ToString() == lstPaqueteSeguros.FirstOrDefault().idConceptoDetalleGasto.ToString());
            return existeDesgravamenIndividual;
        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            if (txtMonAprobado.Text.Trim() == "" || Convert.ToDecimal(txtMonAprobado.Text) <= 0.00m)
            {
                MessageBox.Show("El Monto debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CargarConfiguracionSeguro();
            }
        }
        #endregion

        #region Metodos
        private void calcularFecPrimeraCuota()
        {
            if (this.conCreditoPeriodo.lPeriodoDiaValido)
            {
                conCreditoPrimeraCuota.calcularFecha(
                    this.conCreditoPeriodo.idTipoPeriodo,
                    this.conCreditoPeriodo.nPeriodoDia,
                    (int)this.nudDiasGracia.Value,
                    this.dtpFecDesembolso.Value);
            }
            else
            {
                conCreditoPrimeraCuota.calcularFecha(
                (int)TipoPeriodo.FechaFija,
                (clsVarGlobal.dFecSystem.Day + 1),
                (int)this.nudDiasGracia.Value,
                clsVarGlobal.dFecSystem);
            }
        }

        private int ObtieneTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }

        private void CargarConfiguracionesDeGasto()
        {
            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            #region Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            DataTable dtTodosConfigGastos = objSegDes.validarAplicaSeguroDesgravamen(0, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal, txtMonAprobado.nDecValor);
            nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            conPlanPagos1.nCapitalMaxCobSeg = nCapitalMaxCobSeg;

            #endregion

            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 
            dtCargaGastos = SeleccionarTipoTasaEnConfiguracion(dtTodosConfigGastos);
            dtgConfigGasto.DataSource = dtCargaGastos;
            FormatGastos();
        }

        /// <summary>
        /// Aplica estilo a Grid de Configuraciones de Gasto Aplicables
        /// </summary>
        private void FormatGastos()
        {
            dtgConfigGasto.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgConfigGasto.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgConfigGasto.Columns["lObligatorio"].Visible = true;
            dtgConfigGasto.Columns["cIdCuota"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoGasto"].Visible = true;
            dtgConfigGasto.Columns["nValor"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoValor"].Visible = true;
            dtgConfigGasto.Columns["cMoneda"].Visible = true;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].Visible = true;

            dtgConfigGasto.Columns["lObligatorio"].HeaderText = "Aplicar ";
            dtgConfigGasto.Columns["cIdCuota"].HeaderText = "Cuota";
            dtgConfigGasto.Columns["cIdTipoGasto"].HeaderText = "Tipo de Gasto";
            dtgConfigGasto.Columns["nValor"].HeaderText = "Valor";
            dtgConfigGasto.Columns["cIdTipoValor"].HeaderText = "Tipo de Valor";
            dtgConfigGasto.Columns["cMoneda"].HeaderText = "Moneda";
            dtgConfigGasto.Columns["cIdAplicaConcepto"].HeaderText = "Aplicar al concepto";

            dtgConfigGasto.Columns["lObligatorio"].FillWeight = 5;
            dtgConfigGasto.Columns["cIdCuota"].FillWeight = 15;
            dtgConfigGasto.Columns["cIdTipoGasto"].FillWeight = 20;
            dtgConfigGasto.Columns["nValor"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdTipoValor"].FillWeight = 15;
            dtgConfigGasto.Columns["cMoneda"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].FillWeight = 25;

            dtCargaGastos.Columns["lObligatorio"].ReadOnly = false;
            dtgConfigGasto.Columns["lObligatorio"].ReadOnly = false;

            //for (int i = 0; i < dtgConfigGasto.Rows.Count; i++)
            //{
            //    var dgcCampoObligatorio = dtgConfigGasto.Rows[i].Cells["lObligatorio"];
            //    dgcCampoObligatorio.ReadOnly = Convert.ToBoolean(dgcCampoObligatorio.Value);
            //}
        }

        private DataTable SeleccionarTipoTasaEnConfiguracion(DataTable dtTodosConfigGastos)
        {
            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 

            Boolean lUsaPorcentualSimple = false;
            Boolean lUsaPorcentualCompuesto = false;

            DataTable dtConfigGasto = dtTodosConfigGastos.Clone();  //Contedrá los Gastos PORCENTUALES SIMPLES ó COMPUESTOS
            //independiente de los FIJOS
            // Identificar  La existencia de Tasa Porcentuales
            for (int i = 0; i < dtTodosConfigGastos.Rows.Count; i++)
            {
                if (dtTodosConfigGastos.Rows[i]["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL SIMPLE"))
                {
                    lUsaPorcentualSimple = true;
                }
                if (dtTodosConfigGastos.Rows[i]["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL COMPUESTO"))
                {
                    lUsaPorcentualCompuesto = true;
                }
            }

            //Validar el uso de sólo un tipo de TASA PORCENTUAL
            if (lUsaPorcentualSimple == true && lUsaPorcentualCompuesto == true)//Existen en la configuración las 2 Tasas, entonces elegir uno de ellos
            {
                if (VentanaPregunta("Elección de tipo de Tasa:.") == DialogResult.OK)//PORCENTUAL SIMPLE
                {
                    for (int j = 0; j < dtTodosConfigGastos.Rows.Count; j++)
                    {
                        if (dtTodosConfigGastos.Rows[j]["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL COMPUESTO"))
                        {   //No se tiene en cuenta                         
                        }
                        else
                        {
                            DataRow drfila = dtConfigGasto.NewRow();
                            drfila["lObligatorio"] = dtTodosConfigGastos.Rows[j]["lObligatorio"];
                            drfila["nIdCuota"] = dtTodosConfigGastos.Rows[j]["nIdCuota"];
                            drfila["nIdTipoGasto"] = dtTodosConfigGastos.Rows[j]["nIdTipoGasto"];
                            drfila["nIdTipoValor"] = dtTodosConfigGastos.Rows[j]["nIdTipoValor"];
                            drfila["nIdMoneda"] = dtTodosConfigGastos.Rows[j]["nIdMoneda"];
                            drfila["nIdAplicaConcepto"] = dtTodosConfigGastos.Rows[j]["nIdAplicaConcepto"];
                            drfila["cIdCuota"] = dtTodosConfigGastos.Rows[j]["cIdCuota"];
                            drfila["cIdTipoGasto"] = dtTodosConfigGastos.Rows[j]["cIdTipoGasto"];
                            drfila["nValor"] = dtTodosConfigGastos.Rows[j]["nValor"];
                            drfila["cIdTipoValor"] = dtTodosConfigGastos.Rows[j]["cIdTipoValor"];
                            drfila["cMoneda"] = dtTodosConfigGastos.Rows[j]["cMoneda"];
                            drfila["cIdAplicaConcepto"] = dtTodosConfigGastos.Rows[j]["cIdAplicaConcepto"];
                            drfila["nClasificTipoGasto"] = dtTodosConfigGastos.Rows[j]["nClasificTipoGasto"];
                            drfila["nTasaEfectivaDiaria"] = dtTodosConfigGastos.Rows[j]["nTasaEfectivaDiaria"];
                            drfila["nGasto"] = dtTodosConfigGastos.Rows[j]["nGasto"];
                            dtConfigGasto.Rows.Add(drfila);
                        }
                    }
                }
                else// PORCENTUAL COMPUESTO
                {
                    for (int j = 0; j < dtTodosConfigGastos.Rows.Count; j++)
                    {
                        if (dtTodosConfigGastos.Rows[j]["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL SIMPLE"))
                        {   //No se tiene en cuenta                         
                        }
                        else
                        {
                            DataRow drfila = dtConfigGasto.NewRow();
                            drfila["lObligatorio"] = dtTodosConfigGastos.Rows[j]["lObligatorio"];
                            drfila["nIdCuota"] = dtTodosConfigGastos.Rows[j]["nIdCuota"];
                            drfila["nIdTipoGasto"] = dtTodosConfigGastos.Rows[j]["nIdTipoGasto"];
                            drfila["nIdTipoValor"] = dtTodosConfigGastos.Rows[j]["nIdTipoValor"];
                            drfila["nIdMoneda"] = dtTodosConfigGastos.Rows[j]["nIdMoneda"];
                            drfila["nIdAplicaConcepto"] = dtTodosConfigGastos.Rows[j]["nIdAplicaConcepto"];
                            drfila["cIdCuota"] = dtTodosConfigGastos.Rows[j]["cIdCuota"];
                            drfila["cIdTipoGasto"] = dtTodosConfigGastos.Rows[j]["cIdTipoGasto"];
                            drfila["nValor"] = dtTodosConfigGastos.Rows[j]["nValor"];
                            drfila["cIdTipoValor"] = dtTodosConfigGastos.Rows[j]["cIdTipoValor"];
                            drfila["cMoneda"] = dtTodosConfigGastos.Rows[j]["cMoneda"];
                            drfila["cIdAplicaConcepto"] = dtTodosConfigGastos.Rows[j]["cIdAplicaConcepto"];
                            drfila["nClasificTipoGasto"] = dtTodosConfigGastos.Rows[j]["nClasificTipoGasto"];
                            drfila["nTasaEfectivaDiaria"] = dtTodosConfigGastos.Rows[j]["nTasaEfectivaDiaria"];
                            drfila["nGasto"] = dtTodosConfigGastos.Rows[j]["nGasto"];
                            dtConfigGasto.Rows.Add(drfila);
                        }
                    }
                }//Fin Porcentual Compuesto
            }
            else//En la configuración sólo existe un tipo de tasa porcentual (SIMLE ó COMPUESTO)
            {
                dtConfigGasto = dtTodosConfigGastos;
            }
            return dtConfigGasto;
        }

        private DialogResult VentanaPregunta(string cTituloVentana)
        {
            frmBase frmDecision = new frmBase();

            lblBase lblTexto = new lblBase();

            PictureBox pictureBox = new PictureBox();

            Button btnPorcentualSimple = new Button();
            Button btnPorcentualCompuesto = new Button();

            frmDecision.Text = cTituloVentana;
            lblTexto.Text = "Existen 2 tipos de tasas (PORCENTUAL SIMPLE y PORCENTUAL COMPUESTO) en las configuraciones para ésta solicitud. Elija un tipo de Tasa.";
            lblTexto.AutoSize = false;

            btnPorcentualSimple.Text = "SIMPLE";
            btnPorcentualCompuesto.Text = "COMPUESTO";

            btnPorcentualSimple.DialogResult = DialogResult.OK;//Para la elección de Tasa Porcentual Simple
            btnPorcentualCompuesto.DialogResult = DialogResult.Cancel;//Para la elección de Tasa Porcentual Compuesta

            Icon Icono = SystemIcons.Question;
            pictureBox.Image = Icono.ToBitmap();

            lblTexto.SetBounds(65, 20, 400, 32);
            btnPorcentualSimple.SetBounds(68, 75, 135, 23);
            btnPorcentualCompuesto.SetBounds(288, 75, 165, 23);
            pictureBox.SetBounds(15, 20, 73, 50);

            frmDecision.Height = 180;
            frmDecision.Width = 500;
            frmDecision.Controls.AddRange(new Control[] { lblTexto, btnPorcentualSimple, btnPorcentualCompuesto, pictureBox });

            frmDecision.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmDecision.StartPosition = FormStartPosition.CenterScreen;
            frmDecision.MinimizeBox = false;
            frmDecision.MaximizeBox = false;
            frmDecision.ControlBox = false;//deshabilitar el boton X del formulario            
            frmDecision.CancelButton = btnPorcentualCompuesto;

            DialogResult dialogResult = frmDecision.ShowDialog();
            return dialogResult;
        }

        private void IniEstructuradtModifica()
        {
            dtModificaciones = new DataTable("dtModificaciones");

            dtModificaciones.Columns.Add("cTipoAccion", typeof(string));
            dtModificaciones.Columns.Add("idTipoAccion", typeof(int));
            dtModificaciones.Columns.Add("nCuota", typeof(int));
            dtModificaciones.Columns.Add("nOtraCuota", typeof(int));
            dtModificaciones.Columns.Add("nMes", typeof(int));
            dtModificaciones.Columns.Add("cMes", typeof(string));
            dtModificaciones.Columns.Add("nAnio", typeof(int));
            dtModificaciones.Columns.Add("cAnio", typeof(string));
            dtModificaciones.Columns.Add("nMonto", typeof(decimal));
            dtModificaciones.Columns.Add("lIndTodAnios", typeof(bool));
            dtModificaciones.Columns.Add("idCuotalibre", typeof(int));
            dtModificaciones.Columns.Add("nDia", typeof(int));
        }
            
        private void VerificarConsistenciaTasasParaCuotasConstantes()
        {
            Int32 nAuxIdTipoValor = 0;
            Boolean nSwitch = false;
            for (int i = 0; i < dtCargaGastos.Rows.Count; i++)
            {
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))//Hasta aqui ya se ha validado el ingreso de Gastos con tasa PORCENTUAL COMPUESTA que sólo afecten a SALDO CAPITAL
                {
                    if (nSwitch == false)
                    {
                        nAuxIdTipoValor = Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]);
                        //Modificar el tipo  Valor como 1, para que se obtenga CUOTAS CONSTANTES
                        dtCargaGastos.Columns["nClasificTipoGasto"].ReadOnly = false;
                        dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "1";
                        nSwitch = true;
                        lVerificarError = false;
                    }
                    else//Ya existe un gasto que afecte a SALDO CAPITAL con tasa PORCENTUAL COMPUESTA verificar que los demás gastos que afecten a saldo capital tambien tengan éste mismo tipo de Tasa
                    {
                        if (nAuxIdTipoValor != Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]))
                        {
                            MessageBox.Show("PARA QUE LAS CUOTAS SEAN CONSTANTES:" + Environment.NewLine + "Se debe usar sólo TASA PORCENTUAL SIMPLE ó COMPUESTA (No ambos a la vez) en los Gastos que afecten a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lVerificarError = true;
                            return;
                        }
                        else
                        {
                            lVerificarError = false;
                        }
                    }
                }
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                {
                    if (nSwitch == false)
                    {
                        nAuxIdTipoValor = Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]);
                        //Modificar el tipo  Valor como 1, para que se obtenga CUOTAS CONSTANTES
                        dtCargaGastos.Columns["nClasificTipoGasto"].ReadOnly = false;
                        dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "1";
                        nSwitch = true;
                        lVerificarError = false;
                    }
                    else//Ya existe un gasto que afecte a SALDO CAPITAL con tasa PORCENTUAL SIMPLE verificar que los demás gastos que afecten a saldo capital tambien tengan éste mismo tipo de Tasa
                    {
                        if (nAuxIdTipoValor != Convert.ToInt32(dtCargaGastos.Rows[i]["nIdTipoValor"]))
                        {
                            MessageBox.Show("PARA QUE LAS CUOTAS SEAN CONSTANTES:" + Environment.NewLine + "Se debe usar sólo TASA PORCENTUAL SIMPLE ó COMPUESTA (No ambos a la vez) en los Gastos que afecten a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lVerificarError = true;
                            return;
                        }
                        else
                        {
                            lVerificarError = false;
                        }
                    }
                }
            }//Fin de recorrer la lista de Gastos a cargar a la SIMULACIÓN
        }

        private void ConvertirTasasParaCuotasNoConstantes()
        {
            dtCargaGastos.Columns["nClasificTipoGasto"].ReadOnly = false; ;
            for (int i = 0; i < dtCargaGastos.Rows.Count; i++)
            {
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                {
                    dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "2";
                }
                if (dtCargaGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE") && dtCargaGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                {
                    dtCargaGastos.Rows[i]["nClasificTipoGasto"] = "2";
                }
            }//Fin de recorrer la lista de Gastos a cargar a la SIMULACIÓN
        }

        private void AgregarGasto(int nIdTipoMoneda, string cIdTipoMoneda, int nIdAplicaCuota, string cIdAplicaCuota, decimal nValor,
                                  int nIdTipoGasto, string cIdTipoGasto, int nIdTipoValor, string cIdTipoValor, int nIdAplicaConcepto,
                                  string cIdAplicaConcepto)
        {
            DataRow drfila = dtCargaGastos.NewRow();

            //Verificar que se carguen del mismo tipo de moneda
            if (dtCargaGastos.Rows.Count > 0)
            {
                int nAuxTipoMoneda = Convert.ToInt32(dtCargaGastos.Rows[0]["nIdMoneda"]);
                if (nAuxTipoMoneda != nIdTipoMoneda)//PARA SOLES
                {
                    MessageBox.Show(string.Format("Se está utilizando {0} como tipo de moneda, No puede elegir un gasto con DIFERENTE MONEDA", dtCargaGastos.Rows[0]["cIdMoneda"]), "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //Validar todas las posibles combinaciones permitidas de los gastos que se quieran cargar a la Simulación de Plan Pagos

            /******************************************** IMPORTANTE ******************************************************            
            Los Gastos que se desea aplicar sobre las cuotas
            sólo puedes tener las 
            Posibles Combinaciones:
             
             ----------------------------------------------------------------
             |  TipoValor   |   Aplicar A           |   Cuota               |
             ----------------------------------------------------------------
             |  %COMPUESTO  |   SALDO CAPITAL       |   Obligatorio TODAS   | 
             ----------------------------------------------------------------       
             |  %SIMPLE     |   SALDO CAPITAL       |   Obligatorio TODAS   |
             |              |   MONTO PRESTAMO      |   Cualquier cuota     |
             |              |   CAPITAL + INTERÉS   |   Obligatorio TODAS   |
             |              |   CAPITAL             |   Obligatorio TODAS   | 
             ----------------------------------------------------------------
             |   FIJO       |                       |   Cualquier cuota     |
              ---------------------------------------------------------------
                         
            ****************************************************************************************************************/
            if (cIdTipoValor.Equals("PORCENTUAL COMPUESTO") && cIdAplicaConcepto.Equals("SALDO CAPITAL") &&
                !cIdAplicaCuota.Equals("TODAS LAS CUOTAS"))
            {
                MessageBox.Show("Los Gastos con tasa PORCENTUAL COMPUESTO que afecten a SALDO CAPITAL tienen que aplicarse a TODAS LAS CUOTAS", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cIdTipoValor.Equals("PORCENTUAL COMPUESTO") && !cIdAplicaConcepto.Equals("SALDO CAPITAL"))
            {
                MessageBox.Show("Los Gastos con tasa PORCENTUAL COMPUESTO sólo pueden afectar a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cIdTipoValor.Equals("PORCENTUAL SIMPLE") && cIdAplicaConcepto.Equals("SALDO CAPITAL") &&
                !cIdAplicaCuota.Equals("TODAS LAS CUOTAS"))
            {
                MessageBox.Show("Los Gastos con tasa PORCENTUAL SIMPLE que afecten a SALDO CAPITAL tienen que aplicarse a TODAS LAS CUOTAS", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cIdTipoValor.Equals("PORCENTUAL SIMPLE") &&
                (!cIdAplicaConcepto.Equals("SALDO CAPITAL") && !cIdAplicaConcepto.Equals("MONTO PRESTAMO") &&
                        !cIdAplicaConcepto.Equals("CUOTA (CAPITAL + INTERÉS)") && !cIdAplicaConcepto.Equals("CAPITAL")))
            {
                MessageBox.Show("PARA MANTENER CUOTAS CONSTANTES:" + Environment.NewLine + "los Gastos con tasa PORCENTUAL SIMPLE sólo pueden afectar a:" +
                Environment.NewLine + "SALDO CAPITAL" +
                Environment.NewLine + "MONTO PRESTAMO" +
                Environment.NewLine + "CUOTA (CAPITAL + INTERÉS)" +
                Environment.NewLine + "CAPITAL"
                , "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cIdTipoValor.Equals("PORCENTUAL SIMPLE") &&
                (cIdAplicaConcepto.Equals("CUOTA (CAPITAL + INTERÉS)") ||
                             cIdAplicaConcepto.Equals("CAPITAL"))
                            && !cIdAplicaCuota.Equals("TODAS LAS CUOTAS"))
            {
                MessageBox.Show("Los Gastos con tasa PORCENTUAL SIMPLE que afecten a " + cIdAplicaConcepto + " tienen que aplicarse a TODAS LAS CUOTAS", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (chcMantenerCuotasCtes.Checked &&
                (cIdTipoValor.Equals("PORCENTUAL COMPUESTO") || cIdTipoValor.Equals("PORCENTUAL SIMPLE")) &&
                cIdAplicaConcepto.Equals("SALDO CAPITAL") &&
                cIdAplicaCuota.Equals("TODAS LAS CUOTAS"))
            {
                if (dtCargaGastos.AsEnumerable().Any(x => x.Field<string>("cIdTipoValor").Equals("PORCENTUAL COMPUESTO"))
                            && dtCargaGastos.AsEnumerable().Any(x => x.Field<string>("cIdTipoValor").Equals("PORCENTUAL SIMPLE")))
                {
                    MessageBox.Show("PARA QUE LAS CUOTAS SEAN CONSTANTES:" + Environment.NewLine + "Se debe usar sólo TASA PORCENTUAL SIMPLE ó COMPUESTA (No ambos ala vez) en los Gastos que afecten a SALDO CAPITAL", "Simulación Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if ((cIdTipoValor.Equals("PORCENTUAL COMPUESTO") && cIdAplicaConcepto.Equals("SALDO CAPITAL") && cIdAplicaCuota.Equals("TODAS LAS CUOTAS"))
                || (cIdTipoValor.Equals("PORCENTUAL SIMPLE") &&
                    (cIdAplicaConcepto.Equals("SALDO CAPITAL") || cIdAplicaConcepto.Equals("MONTO PRESTAMO") ||
                    cIdAplicaConcepto.Equals("CUOTA (CAPITAL + INTERÉS)") || cIdAplicaConcepto.Equals("CAPITAL")))
                || cIdTipoValor.Equals("FIJO"))
            {
                drfila["nIdCuota"] = nIdAplicaCuota;
                drfila["nIdTipoGasto"] = nIdTipoGasto;
                drfila["nIdTipoValor"] = nIdTipoValor;
                drfila["nIdMoneda"] = nIdTipoMoneda;
                drfila["nIdAplicaConcepto"] = nIdAplicaConcepto;
                drfila["cIdCuota"] = cIdAplicaCuota;
                drfila["cIdTipoGasto"] = cIdTipoGasto;
                drfila["nGasto"] = 0.00;
                drfila["nValor"] = nValor;
                drfila["cIdTipoValor"] = cIdTipoValor;
                drfila["cMoneda"] = cIdTipoMoneda;
                drfila["cIdAplicaConcepto"] = cIdAplicaConcepto;
                drfila["nClasificTipoGasto"] = chcMantenerCuotasCtes.Checked ? "1" : "2";
                drfila["nTasaEfectivaDiaria"] = nIdTipoValor == 1 ? 0 : nValor;
                drfila["lObligatorio"] = true;
                
                dtCargaGastos.Rows.Add(drfila);
                
            }

            dtCargaGastos.AcceptChanges();
            dtgConfigGasto.DataSource = dtCargaGastos;
            FormatGastos();
            dtgConfigGasto.Focus();
            dtgConfigGasto.Rows[0].Selected = true;
            btnQuitar.Enabled = dtCargaGastos.Rows.Count > 0;
        }
       
        private bool Validaingresodatos()
        {
            const string cTituloMsjes = "Simulador de Plan de Pagos";
            if (txtMonAprobado.Text.Trim() == "" || Convert.ToDecimal(txtMonAprobado.Text) <= 0.00m)
            {
                MessageBox.Show("El Monto a desembolsar debe ser mayor a cero.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonAprobado.Focus();
                txtMonAprobado.SelectAll();
                return false;
            }
            
            if (nudNumCuota.Text.Trim() == "" || Convert.ToDecimal(nudNumCuota.Text) <= 0.00m)
            {
                MessageBox.Show("El número de cuotas debe ser mayor a cero.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudNumCuota.Focus();
                return false;
            }

            //if (Convert.ToDecimal(this.txtTasaInteres.Text) > 100.00)
            //{
            //    MessageBox.Show("La tasa efectiva mensual no puede ser mayor que 100.00%", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtTasaInteres.Focus();
            //    txtTasaInteres.SelectAll();
            //    lvalidatos = false;
            //    return lvalidatos;
            //}
            if (nudDiasGracia.Text.Trim() == "" || Convert.ToDecimal(nudDiasGracia.Text) < 0.00m)
            {
                MessageBox.Show("Los días de gracias deben ser mayor o iguales a cero.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudDiasGracia.Focus();
                return false;
            }
            if (!conCreditoPeriodo.lPeriodoDiaValido)
            {
                MessageBox.Show("La frecuencia en días debe ser mayor a cero.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //nudPeriodo.Focus();
                return false;
            }

            if (cboFuenteRecurso.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de recurso.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFuenteRecurso.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtTasaInteres.Text) || txtTasaInteres.nDecValor <= 0M)
            {
                MessageBox.Show("Debe ingresar la tasa de interes.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaInteres.Focus();
                txtTasaInteres.SelectAll();
                return false;
            }

            return true;
        }

        private void CargarCombos()
        {
            cboTipoCredito.CargarProducto(1);
            cboTipoCredito.SelectedValue = 1;

            cboFuenteRecurso.CargarItems();

            //cargar combo Grupo Gasto
            //quitar evento al cargar combo
            cboGrupoGasto.SelectedIndexChanged -= new EventHandler(cboGrupoGasto_SelectedIndexChanged);

            cboGrupoGasto.DisplayMember = "cGrupoConcepto";
            cboGrupoGasto.ValueMember = "idGrupoConcepto";
            cboGrupoGasto.DataSource = cnconfiguragasto.CargarGrupoGasto();
            
            cboGrupoGasto.DropDownStyle = ComboBoxStyle.DropDownList;

            //añadir evento al cargar combo
            cboGrupoGasto.SelectedIndexChanged += new EventHandler(cboGrupoGasto_SelectedIndexChanged);

            //Cargar combo Aplica Cuota
            cboAplicaCuota.ValueMember = "idAplicaCuota";
            cboAplicaCuota.DisplayMember = "cAplicaCuota";
            cboAplicaCuota.DataSource = cnconfiguragasto.CargarAplicarCuota();            
            cboAplicaCuota.DropDownStyle = ComboBoxStyle.DropDownList;

            //cargar combo Tipo Gasto
            cboTipoGasto.DisplayMember = "cConcepto";
            cboTipoGasto.ValueMember = "idConcepto";
            cboTipoGasto.DataSource = cnconfiguragasto.CargarConcepto(0);            
            cboTipoGasto.DropDownStyle = ComboBoxStyle.DropDownList;

            //cargar combo Aplica Concepto
            cboAplicaConcepto.ValueMember = "idAplicaConc";
            cboAplicaConcepto.DisplayMember = "cAplicaConc";
            cboAplicaConcepto.DataSource = cnconfiguragasto.CargarAplicaConcepto();            
            cboAplicaConcepto.DropDownStyle = ComboBoxStyle.DropDownList;

            cboTipoValor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AsignarTasa()
        {
            if (cboSubProducto.SelectedIndex < 0 || cboSubProducto.SelectedValue == null ||
                cboSubProducto.SelectedValue is DataRowView || cboClasificacionInterna1.SelectedIndex<0) 
                return;

            if (Convert.ToInt32(nudNumCuota.Value) != 0 && conCreditoPeriodo.idTipoPeriodo != 0 &&
                conCreditoPeriodo.nPeriodoDia != 0)
            {
                cboTipoTasaCredito.DataSource = null;
                int nPlazo = ObtenerTotalDias(dtpFecDesembolso.Value.Date, Convert.ToInt32(nudNumCuota.Value),
                    Convert.ToInt32(nudDiasGracia.Value), conCreditoPeriodo.idTipoPeriodo,
                    conCreditoPeriodo.nPeriodoDia);
                int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
                decimal nMonto =
                    Convert.ToDecimal(string.IsNullOrEmpty(txtMonAprobado.Text) ? "0.00" : txtMonAprobado.Text);
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                int idClasificacion = Convert.ToInt32(cboClasificacionInterna1.SelectedValue);
                var dtTasa = new clsCNTasaCredito().ListaTasaCredito(nPlazo, idProducto, nMonto, idMoneda,
                                                                        clsVarGlobal.nIdAgencia, 1, idClasificacion);
                if (dtTasa.Rows.Count > 0)
                {
                    DataRow row = dtTasa.Rows[0];
                    decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
                    decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);

                    cboTipoTasaCredito.DisplayMember = "cDescripcion";
                    cboTipoTasaCredito.ValueMember = "idTasa";
                    cboTipoTasaCredito.DataSource = dtTasa;

                    txtTasCompensatoriaMin.Text = nTasaMin.ToString("#,0.0000");
                    txtTasCompensatoriaMax.Text = nTasaMax.ToString("#,0.0000");
                    txtTasaInteres.Text = nTasaMax.ToString("#,0.0000");
                    cboFuenteRecurso.Focus();
                }
                else
                {
                    txtTasCompensatoriaMin.Text = string.Empty;
                    txtTasCompensatoriaMax.Text = string.Empty;
                    txtTasaInteres.Text = string.Empty;
                }
            }
            CargarConfiguracionesDeGasto();
        }

        private int ObtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }

        private void CalcularPlanpagos(decimal nCuotaSugerida = 0M)
        {
            #region SETEO DE PARÁMETROS PARA EL CÁLCULO DE PLAN DE PAGOS

            var nMonDesemb = decimal.Parse(txtMonAprobado.Text);                           // Monto Desembolsado
            var nTasaEfectiva = decimal.Parse(txtTasaInteres.Text) / 100.00m;                 // Tasa de Interes
            var dFecDesemb = dtpFecDesembolso.Value;                                       // Fecha de Desembolso
            var nNumCuoCta = int.Parse(nudNumCuota.Text);                                  // Número de Cuotas del Crédito
            var nDiaGraCta = int.Parse(nudDiasGracia.Text);                                // Días de Gracia
            var nTipPerPag = conCreditoPeriodo.idTipoPeriodo;        // Tipo de periodo de pago (Fecha o Periodo Fijo)
            var nDiaFecPag = conCreditoPeriodo.nPeriodoDia;                                   // Día o Periodo fijo de pago
            var idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            var dFecPriCuota = this.conCreditoPrimeraCuota.dFecha;
            var idSolicitud = 0;

            #endregion

            //if (CargarValidarGastos())
            //{
            //    return;
            //}

            dtCuotasDobles = cnplanpago.retornarCuotasDobles(dtModificaciones, dFecDesemb, nNumCuoCta);

            //reiniciando el data table de gastos
            cnplanpago.iniciarDTGastos();

            this.conPlanPagos1.AsignaObjetoSeguroOptativo(this.objSolicitudCreditoCargaSeguro);

            dtCalendarioPagos = cnplanpago.CalculaPpgCuotasConstantes2(nMonDesemb, nTasaEfectiva, dFecDesemb, nNumCuoCta, nDiaGraCta, (short)conCreditoPeriodo.idTipoPeriodo,
                                                                      nDiaFecPag, idSolicitud, dtCargaGastos, idMoneda, dtCuotasDobles, dFecPriCuota,
                                                                      nCuotaSugerida, nCapitalMaxCobSeg, 0, chcMantenerCuotasCtes.Checked
                                                                      , 0, objSolicitudCreditoCargaSeguro); //RQ400

            if (dtCalendarioPagos != null)
            {
                tbcPlnaPagos.SelectedIndex = 1; 

                conPlanPagos1.dtCalendarioPagos = dtCalendarioPagos;
                conPlanPagos1.dtCargaGastos = dtCargaGastos;
                conPlanPagos1.dtGastosPP = cnplanpago.ObtenerGastos(idSolicitud);
                conPlanPagos1.nTipPeriodo = (short)nTipPerPag;
                conPlanPagos1.nNumCuotas = nNumCuoCta;
                conPlanPagos1.dFechaDesembolso = dFecDesemb;
                conPlanPagos1.nMonto = nMonDesemb;
                conPlanPagos1.nPlazo = nDiaFecPag;
                conPlanPagos1.nDiasGracia = nDiaGraCta;
                conPlanPagos1.nTasaInteres = txtTasaInteres.nDecValor;
                conPlanPagos1.idMoneda = idMoneda;
                conPlanPagos1.lCuotaCte = chcMantenerCuotasCtes.Checked;
                conPlanPagos1.dFecPriCuota = dFecPriCuota;
                conPlanPagos1.cnplanpago = cnplanpago;
                conPlanPagos1.IdSolicitud = idSolicitud;
                conPlanPagos1.cargarDatos();

                btnImprimir1.Enabled = true;
            }
            else
            {
                conPlanPagos1.limpiarControlesTotales();
            }
        }

        /// <summary>
        /// Los Gastos que se desea aplicar sobre las cuotas sólo puedes tener las 
        ///	Posibles Combinaciones:
        ///	 
        ///	 ----------------------------------------------------------------
        ///	 |  TipoValor   |   Aplicar A           |   Cuota               |
        ///	 ----------------------------------------------------------------
        ///	 |  %COMPUESTO  |   SALDO CAPITAL       |   Obligatorio TODAS   | 
        ///	 ----------------------------------------------------------------       
        ///	 |  %SIMPLE     |   SALDO CAPITAL       |   Obligatorio TODAS   |
        ///	 |              |   MONTO PRESTAMO      |   Cualquier cuota     |
        ///	 |              |   CAPITAL + INTERÉS   |   Obligatorio TODAS   |
        ///	 |              |   CAPITAL             |   Obligatorio TODAS   | 
        ///	 ----------------------------------------------------------------
        ///	 |   FIJO       |                       |   Cualquier cuota     |
        ///	  ---------------------------------------------------------------
        /// 
        /// </summary>
        /// <returns>
        /// true: existe errores
        /// false: no existe errores
        /// </returns>
        private bool CargarValidarGastos()
        {
            //llamando a la función que calcula el plan de pagos en la capa de negocios          
            DataTable dtConfig = dtgConfigGasto.DataSource as DataTable;//Se utiliza sólo para mostrar al Usuario en Pantalla

            //DataTable con el que se trabajará los 'Gastos Seleccionados' (check) que afectarán al Plan de Pagos
            var dtAuxConfigGastos = dtConfig.Clone();//copiar la estructura del DataTable
            StringBuilder sbMensajesError = new StringBuilder();//Definir cadena en la que se acumluará los errores a mostrar
            bool lSwitchError = false;//permitirá verificar si hay algún error en la combinación de Asignación de Gastos al Plan de Pagos

            #region Carga de Gastos

            for (int i = 0; i < dtConfig.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtConfig.Rows[i]["lObligatorio"].ToString()))
                //Trabajar solo con los Configuración de Gastos que tienen check
                {
                    DataRow dr = dtAuxConfigGastos.NewRow();
                    dr["lObligatorio"] = dtConfig.Rows[i]["lObligatorio"];
                    dr["nIdCuota"] = dtConfig.Rows[i]["nIdCuota"];
                    dr["nIdTipoGasto"] = dtConfig.Rows[i]["nIdTipoGasto"];
                    dr["nIdTipoValor"] = dtConfig.Rows[i]["nIdTipoValor"];
                    dr["nIdAplicaConcepto"] = dtConfig.Rows[i]["nIdAplicaConcepto"];
                    dr["cIdCuota"] = dtConfig.Rows[i]["cIdCuota"];
                    dr["cIdTipoGasto"] = dtConfig.Rows[i]["cIdTipoGasto"];
                    dr["nGasto"] = dtConfig.Rows[i]["nGasto"];
                    dr["nValor"] = dtConfig.Rows[i]["nValor"];
                    dr["cIdTipoValor"] = dtConfig.Rows[i]["cIdTipoValor"];
                    dr["cMoneda"] = dtConfig.Rows[i]["cMoneda"];
                    dr["cIdAplicaConcepto"] = dtConfig.Rows[i]["cIdAplicaConcepto"];
                    dr["nTasaEfectivaDiaria"] = dtConfig.Rows[i]["nTasaEfectivaDiaria"];

                    if (chcMantenerCuotasCtes.Checked) //Mantener cuotas constantes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] +
                                                       " - " + dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine +
                                                       dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }

                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                    if (chcMantenerCuotasCtes.Checked == false) //cuotas no constntes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                }
            }

            //Verificar si la elección de la combinación de asignación de Gastos al Plan de Pagos es correcta
            if (lSwitchError)
            {
                MessageBox.Show(string.Format("No se permite la siguiente Combinación de Asignación de Gastos:{0}", sbMensajesError), "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que los Gastos que afecten a SALDO CAPITAL sean sólo PORCENTUAL SIMPLE ó PROCENTUAL COMPUESTO (no ambos) sólo para que las CUOTAS sean CONSTANTES
            string cTipoValor = string.Empty;
            string cMensajeError = string.Empty;
            int nContador = 0;
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") && Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nClasificTipoGasto"]) == 1)
                {
                    if (nContador == 0)
                    {
                        cTipoValor = dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString();
                        nContador++;
                    }
                    else
                    {
                        if (!cTipoValor.Equals(dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString()))
                        {
                            cMensajeError = Environment.NewLine + "Para que las CUOTAS sean CONSTANTES" +
                                            Environment.NewLine + "Los gastos que afecten a SALDO CAPITAL deben ser" +
                                            Environment.NewLine +
                                            "PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO (no ambos a la vez)";
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show(sbMensajesError + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que se cumpla con la asignación a cuotas determinadas
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show("No está permitido aplicar a:" + Environment.NewLine + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            #endregion

            return false;
        }

        private void InitForm()
        {
            CargarCombos();
            IniEstructuradtModifica();
            //Habilitar o deshabilitar los gastos, de acuerdo a la variable local lEnabledGastos
            grbGastos.Enabled = lEnabledGastos;
            dtgConfigGasto.Enabled = lEnabledGastos;
            btnAgregar.Enabled = lEnabledGastos;
            btnQuitar.Enabled = lEnabledGastos;
        }
        private void calcularFechaPrimeraCuota()
        {
            if (this.dtpFecDesembolso.Value.Date < clsVarGlobal.dFecSystem)
            {
                this.dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
                this.dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
            }
            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                conCreditoPrimeraCuota.calcPrimeraCuota(
                    this.conCreditoPeriodo.idTipoPeriodo,
                this.conCreditoPeriodo.nPeriodoDia,
                this.dtpFecDesembolso.Value,
                this.conCreditoPeriodo.idPeriodo);

                this.nudDiasGracia.Value = conCreditoPrimeraCuota.nDiasGracia;
                this.conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.nPeriodoDia);

                if (this.conCreditoPrimeraCuota.lDiaAjustado)
                    this.conCreditoPeriodo.actualizarDia(this.conCreditoPrimeraCuota.nDia);
            }
        }
        private void conCreditoPeriodo_ChangePeriodo(object sender, EventArgs e)
        {
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.lPeriodoDiaValido && this.conCreditoPeriodo.lTipoPeriodoValido)
            {
                this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
                if (this.conCreditoPeriodo.lUnicuota)
                    this.nudNumCuota.Enabled = false;
                else
                    this.nudNumCuota.Enabled = true;
                this.nudNumCuota.ValueChanged -= nudNumCuota_ValueChanged;
                this.nudNumCuota.Value = this.conCreditoPeriodo.nCuotas;
                this.nudNumCuota.ValueChanged -= nudNumCuota_ValueChanged;
            }
        }

        private void conCreditoPeriodo_ValueChangedDia(object sender, EventArgs e)
        {
        }
        private void conCreditoPrimeraCuota_ValueChangedFecha(object sender, EventArgs e)
        {
            if (conCreditoPrimeraCuota.dFecha == null)
                return;

            this.calcularFechaPrimeraCuota();
        }
        #endregion

        
    }
}
