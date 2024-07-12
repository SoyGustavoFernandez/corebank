using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmSolicitudReprogramacion : frmBase
    {
        #region Atributos
        clsSolReproEspecial objSolRepro;
        int nDiasTolerancia { get; set; }
        DateTime dFechaMargen { get; set; }
        DataTable dtTipoPlanPagoCompleto { get; set; }
        decimal nTasaInicial;
        #endregion
        #region Constructor
        public frmSolicitudReprogramacion()
        {
            InitializeComponent();
            this.limpiarFormulario();
            this.conBusCuentaCli1.cTipoBusqueda = "C";
            this.conBusCuentaCli1.cEstado = "[5]";
            GEN.CapaNegocio.clsCNCredito objCredito = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtTipoPlanPago = objCredito.CNListaTipoPlanPago(clsVarGlobal.PerfilUsu.idPerfil);
            dtTipoPlanPagoCompleto = objCredito.CNListaTipoPlanPago();

            this.nTasaInicial = decimal.Zero;

            cboTipoPlanPago.ValueMember = "idTipoPlanPago";
            cboTipoPlanPago.DisplayMember= "cTipoPlanPago";
            cboTipoPlanPago.DataSource = dtTipoPlanPago;

            nDiasTolerancia = Convert.ToInt32(clsVarApl.dicVarGen["nDiasMargenRepro"]);
            dFechaMargen = clsVarGlobal.dFecSystem.AddDays(-1 * nDiasTolerancia);
            
            this.controlFormulario(EventoFormulario.INICIO);
        }
        #endregion

        #region Métodos Públicos
        #endregion

        #region Métodos Privados

        private bool buscarCuenta()
        {
            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNroDoc.Text.Trim()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                return false;
            }

            objSolRepro = new clsSolReproEspecial();
            objSolRepro.idCuenta = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim());
            objSolRepro.idCli = conBusCuentaCli1.nIdCliente;
            //Obtener datos de credito
            //obtener estado de Repro

            GEN.CapaNegocio.clsCNCredito objCredito = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtCredito = objCredito.CNRecuperarDatosReprogramacion(objSolRepro.idCuenta);
            if (dtCredito.Rows.Count > 0)
            {
                this.objSolRepro.cEstadoRepro = dtCredito.Rows[0]["cEstadoReprogramacion"].ToString();
                this.objSolRepro.cTipoPlanPago = dtCredito.Rows[0]["cTipoPlanPago"].ToString();
                this.objSolRepro.idTipoPlanPagoActual = Convert.ToInt32(dtCredito.Rows[0]["idTipoPlanPago"]);
            }

            DataTable dtSolicitud = objCredito.CNBuscarSolicitudCreditos(objSolRepro.idCli);
            DataTable dtCreRepro = objCredito.CNObtenerCreditoReprogramable(objSolRepro.idCuenta);
            
            GEN.CapaNegocio.clsCNCredito objCredito2 = new GEN.CapaNegocio.clsCNCredito();
            if (dtSolicitud.Rows.Count > 0)
            {
                this.objSolRepro.idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]);

                DataTable dtSolRepro = objCredito2.CNRecuperarSolicitudReprogramacionEspecial(objSolRepro.idSolicitud);

                if (Int32.Parse(dtSolRepro.Rows[0]["idEstado"].ToString()) == 2)
                {
                    MessageBox.Show("El cliente tiene una solicitud aprobada.", "Solicitud Aprobada!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Visible = false;
                    btnEditar1.Visible = false;
                    btnCargaArchivos.Visible = false;

                    return false;

                }
                if (Int32.Parse(dtSolRepro.Rows[0]["idOperacion"].ToString()) == 1 || Int32.Parse(dtSolRepro.Rows[0]["idOperacion"].ToString()) == 2 || Int32.Parse(dtSolRepro.Rows[0]["idOperacion"].ToString()) == 4)
                {
                    MessageBox.Show("La solicitud del cliente no es de reprogramación.", "Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Visible = false;
                    btnEditar1.Visible = false;
                    btnCargaArchivos.Visible = false;

                    return false;

                }
                if (Int32.Parse(dtSolRepro.Rows[0]["idTipoPlanPago"].ToString()) == 0)
                {
                    MessageBox.Show("El cliente tiene una solicitud de reprogramación normal.", "Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnCancelar1.Enabled = true;
                    btnGrabar1.Visible = false;
                    btnEditar1.Visible = false;
                    btnCargaArchivos.Visible = false;

                    return false;
                }
            }

            if (dtSolicitud.Rows.Count > 0)
            {
                // cliente tiene registrado una solicitud.
                DataTable dtSolRepro = objCredito2.CNRecuperarSolicitudReprogramacionEspecial(objSolRepro.idSolicitud);
                MessageBox.Show("El cliente tiene registrado una solicitud", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.objSolRepro.idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
                this.objSolRepro.nTasa = Convert.ToDecimal(dtSolicitud.Rows[0]["nTasaEfectivaAnual"]);
                this.objSolRepro.nMontoDesembolso = Convert.ToInt32(dtSolicitud.Rows[0]["nCapitalDesembolso"]);
                this.objSolRepro.nSaldo = Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalSolicitado"]);
                this.objSolRepro.idTipoPeriodo = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPeriodo"]);
                this.objSolRepro.nFrecuencia = Convert.ToInt32(dtSolicitud.Rows[0]["nPlazoCuota"]);
                this.objSolRepro.nNroCuotas = Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]);
                this.objSolRepro.nNroCuotaAmpliar = Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]);
                this.objSolRepro.nDiasGracia = Convert.ToInt32(dtSolicitud.Rows[0]["ndiasgracia"]);
                //this.objSolRepro.dFechaUltimoPago = Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaUltimoPago"]);
                if (Convert.ToInt32(dtCreRepro.Rows[0]["nCuotasPagadas"]) == 0 )
                {
                    this.objSolRepro.dFechaUltimoPago = Convert.ToDateTime(dtCreRepro.Rows[0]["dFechaDesembolso"]);
                }
                else
                {
                    this.objSolRepro.dFechaUltimoPago = Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaUltimoPago"]);
                }
                this.objSolRepro.idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]);
                this.objSolRepro.idEstado = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);
                this.objSolRepro.nTasaNueva = this.objSolRepro.nTasa;

                this.objSolRepro.dFechaProxVenc = Convert.ToDateTime(dtCreRepro.Rows[0]["dFechaProxVenc"]);
                this.objSolRepro.nCuotaInicial = Convert.ToDecimal(dtCreRepro.Rows[0]["nCuotaInicial"]);
                this.objSolRepro.nCuotasPagadas = Convert.ToInt32(dtCreRepro.Rows[0]["nCuotasPagadas"]);

                this.txtNroCuotas.Text = this.objSolRepro.nNroCuotas.ToString();

                cargarSolicitudRepro();

                return true;
            }

            if (dtCreRepro.Rows.Count > 0)
            {
                //this.objSolRepro.idCuenta 
                this.objSolRepro.idMoneda = Convert.ToInt32(dtCreRepro.Rows[0]["IdMoneda"]);
                this.objSolRepro.nTasa = Convert.ToDecimal(dtCreRepro.Rows[0]["nTasaCompensatoria"]);
                this.objSolRepro.nMontoDesembolso = Convert.ToDecimal(dtCreRepro.Rows[0]["nCapitalDesembolso"]);
                this.objSolRepro.nSaldo = Convert.ToDecimal(dtCreRepro.Rows[0]["nSaldoCapitalProg"]);
                this.objSolRepro.idTipoPeriodo = Convert.ToInt32(dtCreRepro.Rows[0]["idTipoPeriodo"]);
                this.objSolRepro.nFrecuencia = Convert.ToInt32(dtCreRepro.Rows[0]["nPlazoCuota"]);
                this.objSolRepro.nNroCuotas = Convert.ToInt32(dtCreRepro.Rows[0]["nCuotasPactadas"]);
                this.objSolRepro.nDiasGracia = Convert.ToInt32(dtCreRepro.Rows[0]["ndiasgracia"]);
                this.objSolRepro.nDiasPerdonMax = Convert.ToInt32(dtCreRepro.Rows[0]["nDiasPerdonMax"]);
                this.objSolRepro.dFechaUltimoPago = Convert.ToDateTime(dtCreRepro.Rows[0]["dFechaUltimoPago"]);
                this.objSolRepro.nCuotasPagadas = Convert.ToInt32(dtCreRepro.Rows[0]["nCuotasPagadas"]);
                this.objSolRepro.dFechaProxVenc = Convert.ToDateTime(dtCreRepro.Rows[0]["dFechaProxVenc"]);
                this.objSolRepro.nCuotaInicial = Convert.ToDecimal(dtCreRepro.Rows[0]["nCuotaInicial"]);
                this.objSolRepro.nNroCuotaAmpliar = Convert.ToInt32(dtCreRepro.Rows[0]["nCuotasPactadas"]);
                this.objSolRepro.lUnicuota = Convert.ToBoolean(dtCreRepro.Rows[0]["lUnicuota"]);
                this.objSolRepro.nPrepagado = Convert.ToInt32(dtCreRepro.Rows[0]["nPrepagado"]);
                this.objSolRepro.nNumDiaCuotaMin = Convert.ToInt32(dtCreRepro.Rows[0]["nNumDiaCuotaMin"]);
                this.objSolRepro.nDiasGraciaOriginal = Convert.ToInt32(dtCreRepro.Rows[0]["nDiasGraciaOriginal"]);
                this.objSolRepro.nNroReproEspecial = Convert.ToInt32(dtCreRepro.Rows[0]["nNroReproEspecial"]);
                this.objSolRepro.lReprogramacion = Convert.ToBoolean(dtCreRepro.Rows[0]["lReprogramacion"]);
                this.objSolRepro.nTasaNueva = this.objSolRepro.nTasa;
                this.nTasaInicial = this.objSolRepro.nTasa;

                this.cargarConfiguracionesDeGasto();
                              
            }
            

            return true;
        }

        private void cargarCredito()
        {
            this.cboMoneda1.SelectedValue = this.objSolRepro.idMoneda;
            this.txtMontoDesombolso.Text = this.objSolRepro.nMontoDesembolso.ToString();
            this.txtSaldoCredito.Text = this.objSolRepro.nSaldo.ToString();
            this.txtTEA.Text = this.objSolRepro.nTasa.ToString();
            this.cboTipoPeriodo.SelectedValue = this.objSolRepro.idTipoPeriodo;
            this.txtFrecuenciaPago.Text = this.objSolRepro.nFrecuencia.ToString();
            this.txtNroCuotas.Text = this.objSolRepro.nNroCuotas.ToString();
            //this.nudCuotasAmpliar.Value = 0;
            this.nudDiasGracia.Value = this.objSolRepro.nDiasGracia;
            //this.nudPerdon.Value = 0;
            this.lblEstadoRepro.Text = this.objSolRepro.cEstadoRepro;
            this.lblTipoRepro.Text = this.objSolRepro.cTipoPlanPago;
            this.lblNroSolicitud.Text = this.objSolRepro.idSolicitud.ToString();
            this.lblFechaUltimoPago.Text = this.objSolRepro.dFechaUltimoPago.ToString("d");
            this.lblProxVenc.Text = this.objSolRepro.dFechaProxVenc.ToString("d");
            this.lblCuotaInicial.Text = this.objSolRepro.nCuotaInicial.ToString("N2");
            this.lblCuotasPendientes.Text = this.objSolRepro.nCuotasFaltantes.ToString();

            if (this.objSolRepro.idSolicitud == 0)
            {
                this.grbBase2.Visible = true;
                this.lblCuotaAproximada.Text = "...";
                this.dtpFechaProxPago.Value = this.objSolRepro.dFechaProxVenc;
                this.nudTEANueva.Value = this.objSolRepro.nTasaNueva;
                }
            else
            {
                this.grbBase2.Visible = true;
            }
        }

        private void cargarSolicitudRepro()
        {
            nudTEANueva.Visible = true;
            lblTEANueva.Visible = true;

            GEN.CapaNegocio.clsCNCredito objCredito2 = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtSolRepro = objCredito2.CNRecuperarSolicitudReprogramacionEspecial(objSolRepro.idSolicitud);

            this.dtpFechaProxPago.MinDate = DatePicker.MinimumDateTime;
            this.dtpFechaProxPago.MaxDate = DatePicker.MaximumDateTime;

            this.objSolRepro.dFechaProxVenc = DateTime.Parse(dtSolRepro.Rows[0]["dFecProxVencimiento"].ToString());
            this.nudTEANueva.Value = this.objSolRepro.nTasa;
            this.nTasaInicial = this.objSolRepro.nTasa;
            this.cboTipoPlanPago.SelectedValue = Int32.Parse(dtSolRepro.Rows[0]["idTipoPlanPago"].ToString());         
            this.dtpFechaProxPago.Value = DateTime.Parse(dtSolRepro.Rows[0]["dFechaProximoPago"].ToString());
            this.nudCuotasAmpliar.Value = Convert.ToInt32(dtSolRepro.Rows[0]["nCuotasAmpliar"].ToString());
            this.nudTEANueva.Value = Convert.ToDecimal(dtSolRepro.Rows[0]["nNuevaTEA"].ToString());
            this.objSolRepro.nCuotasPagadas = Int32.Parse(dtSolRepro.Rows[0]["nCuotasPagadas"].ToString());
            this.lblProxVenc.Text = Convert.ToDateTime(dtSolRepro.Rows[0]["dFecProxVencimiento"]).ToString("d");
            this.lblCuotaInicial.Text = dtSolRepro.Rows[0]["nCuotaInicial"].ToString();
            this.lblCuotasPendientes.Text = dtSolRepro.Rows[0]["nCuotasPend"].ToString();

            cboTipoPlanPago.Enabled = false;
            dtpFechaProxPago.Enabled = false;
            nudCuotasAmpliar.Enabled = false;
            nudTEANueva.Enabled = false;
            btnProcesar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnCargaArchivos.Enabled = true;

        }

        private void limpiarFormulario()
        {
            this.nudCuotasAmpliar.ValueChanged -= new System.EventHandler(nudCuotasAmpliar_ValueChanged);
            this.dtpFechaProxPago.MinDate = DatePicker.MinimumDateTime;
            this.dtpFechaProxPago.MaxDate = DatePicker.MaximumDateTime;
            this.conBusCuentaCli1.LiberarCuenta();
            this.conBusCuentaCli1.limpiarControles();
            this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli1.txtCodIns.Enabled = true;
            this.cboMoneda1.SelectedIndex = -1;
            this.txtMontoDesombolso.Clear();
            this.txtSaldoCredito.Clear();
            this.txtTEA.Clear();
            this.nudTEANueva.Value = decimal.Zero;
            this.cboTipoPeriodo.SelectedIndex = -1;
            this.txtFrecuenciaPago.Clear();
            this.txtNroCuotas.Clear();
            this.nudCuotasAmpliar.Value = 0;
            this.nudDiasGracia.Value = 0;
            this.nudPerdon.Value = 0;
            this.lblEstadoRepro.Text = "";
            this.lblTipoRepro.Text = "";
            this.lblCuotaAproximada.Text = "";
            this.lblProxVenc.Text = "";
            this.lblCuotaInicial.Text = "";
            this.lblNroSolicitud.Text = "";
            this.objSolRepro = null;
            this.lblFechaUltimoPago.Text = "";
            this.dtpFechaProxPago.Value = clsVarGlobal.dFecSystem;
            this.dtgPlanPagos.DataSource = null;
            this.lblCuotasPendientes.Text = "";
            this.txtTotCuota.Clear();
            this.txtTotInteres.Clear();
            this.txtTotCapital.Clear();
            this.txtTotDias.Clear();
            this.txtTotComi.Clear();
            this.txtTotItf.Clear();
            this.cboTipoPlanPago.SelectedIndex = -1;
            this.nudCuotasAmpliar.ValueChanged += new System.EventHandler(nudCuotasAmpliar_ValueChanged);
            this.nudNroCuotasTotal.Value = 0;
        }

        private void obtenerDatosFormulario()
        {
            this.objSolRepro.nDiasGracia = Convert.ToInt32(nudDiasGracia.Value);
            this.objSolRepro.idTipoPlanPago = Convert.ToInt32(cboTipoPlanPago.SelectedValue);
            this.objSolRepro.nDiasPerdon = Convert.ToInt32(nudPerdon.Value);
            this.objSolRepro.nNroCuotaAmpliar = this.objSolRepro.nNroCuotas + Convert.ToInt32(nudCuotasAmpliar.Value);
            this.objSolRepro.dFechaPrimeraCuota = this.dtpFechaProxPago.Value;
            this.objSolRepro.nTasaNueva = this.nudTEANueva.Value;

        }

        private void calcularCuota()
        {
            this.obtenerDatosFormulario();

            if (this.objSolRepro.idTipoPeriodo == 1) //fecha Fija
            { 
             //   DateTime
            }
        }

        private bool validarParaCalculoCuota()
        {
            this.obtenerDatosFormulario();

            if (this.objSolRepro.idCuenta == 0)
            {
                MessageBox.Show("No se encontro un cuenta de crédito seleccionada", "Solicitud Reprogramación especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboTipoPlanPago.SelectedIndex == -1)
            {
                MessageBox.Show("Se debe seleccionar el tipo plan de pagos", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboTipoPlanPago.Focus();
                return false;
            }

            return true;
        }

        private void procesarCalculoCuota()
        {
            clsCNPlanPago objPlanPagos = new clsCNPlanPago();
            DataTable dtPlanPagos = objPlanPagos.CalculaPpgCuotasConstantes2(this.objSolRepro.nSaldo, this.objSolRepro.nTasaNueva/ 100.00m, this.objSolRepro.dFechaRepro, this.objSolRepro.nCuotasFaltantes
                , this.objSolRepro.nDiasGracia - this.objSolRepro.nDiasPerdon, short.Parse(this.objSolRepro.idTipoPeriodo.ToString())
                , (this.objSolRepro.lUnicuota && this.objSolRepro.nPrepagado>0)? this.objSolRepro.nNumDiaCuotaMin : this.objSolRepro.nFrecuencia
                , 0, this.objSolRepro.dtConfigGastos, this.objSolRepro.idMoneda
                , new DataTable(), this.objSolRepro.dFechaPrimeraCuota, 0, this.objSolRepro.nCapitalMaxCobSeg, 0, true);


            objPlanPagos.ObtenerGastos(0);
            lblCuotaAproximada.Text = "S/ " + Convert.ToDecimal(dtPlanPagos.Rows[0]["imp_cuota"]).ToString("N2");
         
            objPlanPagos.calcularInteresCompReprog(dtPlanPagos, this.objSolRepro.nTasaNueva);
            
            this.cargarPlanPagos(dtPlanPagos);

            int nCuenta = dtPlanPagos.Rows.Count; //imp_cuota
            


            DataTable dtPpgTotalizado = objPlanPagos.TotalizaPpg(dtPlanPagos);
            this.txtTotCuota.Text = dtPpgTotalizado.Rows[0]["nTotImportePpg"].ToString();
            this.txtTotCuota.TextAlign = HorizontalAlignment.Right;
            this.txtTotInteres.Text = dtPpgTotalizado.Rows[0]["nTotInteresPpg"].ToString();
            this.txtTotCapital.Text = dtPpgTotalizado.Rows[0]["nTotCapitalPpg"].ToString();
            this.txtTotDias.Text = dtPpgTotalizado.Rows[0]["nTotdias"].ToString();
            this.txtTotComi.Text = dtPpgTotalizado.Rows[0]["nTotComi"].ToString();
            this.txtTotItf.Text = dtPpgTotalizado.Rows[0]["nTotItf"].ToString();

        }

        private void cargarPlanPagos(DataTable _dtPlanPagos)
        {
            dtgPlanPagos.DataSource = null;
            dtgPlanPagos.DataSource = _dtPlanPagos;
            this.formatoPlanPagos();
        }

        private void formatoPlanPagos()
        {
            foreach (DataGridViewColumn column in dtgPlanPagos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgPlanPagos.Columns["cuota"].Visible = true;
            dtgPlanPagos.Columns["fecha"].Visible = true;
            dtgPlanPagos.Columns["dias"].Visible = true;
            dtgPlanPagos.Columns["sal_cap"].Visible = true;
            dtgPlanPagos.Columns["capital"].Visible = true;
            dtgPlanPagos.Columns["interes"].Visible = true;
            dtgPlanPagos.Columns["comisiones"].Visible = true;
            dtgPlanPagos.Columns["imp_cuota"].Visible = true;

            dtgPlanPagos.Columns["nAtrasoCuota"].Visible = true;
            dtgPlanPagos.Columns["nInteresComp"].Visible = true;

            dtgPlanPagos.Columns["cuota"].DisplayIndex = 0;
            dtgPlanPagos.Columns["fecha"].DisplayIndex = 1;
            dtgPlanPagos.Columns["dias"].DisplayIndex = 2;
            dtgPlanPagos.Columns["sal_cap"].DisplayIndex = 3;
            dtgPlanPagos.Columns["capital"].DisplayIndex = 4;
            dtgPlanPagos.Columns["interes"].DisplayIndex = 5;
            dtgPlanPagos.Columns["comisiones"].DisplayIndex = 6;
            dtgPlanPagos.Columns["imp_cuota"].DisplayIndex = 9;

            dtgPlanPagos.Columns["nAtrasoCuota"].DisplayIndex = 7;
            dtgPlanPagos.Columns["nInteresComp"].DisplayIndex = 8;

            dtgPlanPagos.Columns["cuota"].HeaderText = "Cuota";
            dtgPlanPagos.Columns["cuota"].Width = 40;
            dtgPlanPagos.Columns["cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            dtgPlanPagos.Columns["fecha"].Width = 83;
            dtgPlanPagos.Columns["fecha"].HeaderText = "Fecha Pago";
            dtgPlanPagos.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            dtgPlanPagos.Columns["dias"].Width = 75;
            dtgPlanPagos.Columns["dias"].HeaderText = "Frecuencia";
            dtgPlanPagos.Columns["dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            dtgPlanPagos.Columns["sal_cap"].Width = 73;
            dtgPlanPagos.Columns["sal_cap"].HeaderText = "Sal. Cap.";
            dtgPlanPagos.Columns["sal_cap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["sal_cap"].DefaultCellStyle.Format = "#,0.00";

            dtgPlanPagos.Columns["capital"].Width = 73;
            dtgPlanPagos.Columns["capital"].HeaderText = "Capital";
            dtgPlanPagos.Columns["capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["capital"].DefaultCellStyle.Format = "#,0.00";

            dtgPlanPagos.Columns["interes"].Width = 74;
            dtgPlanPagos.Columns["interes"].HeaderText = "Interés";
            dtgPlanPagos.Columns["interes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["interes"].DefaultCellStyle.Format = "#,0.00";

            dtgPlanPagos.Columns["comisiones"].Width = 74;
            dtgPlanPagos.Columns["comisiones"].HeaderText = "Seg. | Comi.";
            dtgPlanPagos.Columns["comisiones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["comisiones"].DefaultCellStyle.Format = "#,0.00";

            dtgPlanPagos.Columns["nAtrasoCuota"].Width = 73;
            dtgPlanPagos.Columns["nAtrasoCuota"].HeaderText = "Atraso";
            dtgPlanPagos.Columns["nAtrasoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dtgPlanPagos.Columns["nAtrasoCuota"].DefaultCellStyle.Format = "n0";

            dtgPlanPagos.Columns["nInteresComp"].Width = 75;
            dtgPlanPagos.Columns["nInteresComp"].HeaderText = "Interes Comp.";
            dtgPlanPagos.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";

            dtgPlanPagos.Columns["imp_cuota"].Width = 75;
            dtgPlanPagos.Columns["imp_cuota"].HeaderText = "Monto Cuota";
            dtgPlanPagos.Columns["imp_cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgPlanPagos.Columns["imp_cuota"].DefaultCellStyle.Format = "#,0.00";
        }

        private void cargarConfiguracionesDeGasto()
        {
            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            objSegDes.validarAplicaSeguroDesgravamen(0, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal, 0, this.objSolRepro.idCuenta);
            this.objSolRepro.nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            this.objSolRepro.lAplicaSeguro = objSegDes.obternerNAplicaSeguro();

            this.objSolRepro.dtConfigGastos = new clsCNConfigGastComiSeg().CNGetConfigGastosCuenta(this.objSolRepro.idCuenta);

            //dtgConfigGasto.DataSource = dtConfigGastos;
            //formatearGastos();
        }
        private void calcularFechaProxPago()
        {
            if (this.objSolRepro == null) return;

            DateTime dFechaUltimoPago = this.objSolRepro.dFechaUltimoPago;
            int nPlazoCuota = this.objSolRepro.nFrecuencia;

            if (this.objSolRepro.idTipoPeriodo == 1)
            {
                int nAnio = this.objSolRepro.dFechaUltimoPago.Year;
                int nMes = this.objSolRepro.dFechaUltimoPago.Month;
                DateTime dFecSiguienteCuota;

                nMes++;
                if (nMes > 12)
                {
                    nAnio++;
                    nMes = 1;
                }

                while (!DateTime.TryParse(string.Concat(nAnio.ToString(), "-",
                    nMes.ToString(), "-", nPlazoCuota.ToString()), out dFecSiguienteCuota))
                {
                    nPlazoCuota--;
                }

                if (this.objSolRepro.nCuotasPagadas == 0)
                {
                    dFecSiguienteCuota = dFecSiguienteCuota.AddDays(this.objSolRepro.nDiasGraciaOriginal);
                }

                this.dtpFechaProxPago.Value = dFecSiguienteCuota;
            }
            else
            {
                int nDiasGracia = (this.objSolRepro.nCuotasPagadas == 0)? this.objSolRepro.nDiasGraciaOriginal : 0;
                this.dtpFechaProxPago.Value = dFechaUltimoPago.AddDays(nPlazoCuota + nDiasGracia);
            }
        }

        private void controlFormulario(EventoFormulario oEvento)
        {
            switch (oEvento)
            {
                case EventoFormulario.INICIO:
                case EventoFormulario.CANCELAR:
                    cboTipoPlanPago.Enabled = false;
                    dtpFechaProxPago.Enabled = false;
                    nudDiasGracia.Enabled = false;
                    nudCuotasAmpliar.Enabled = false;
                    btnProcesar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    nudTEANueva.Enabled = false;

                    btnGrabar1.Visible = true;
                    btnEditar1.Visible = true;
                    btnCargaArchivos.Visible = true;
                    btnEditar1.Enabled = false;
                    btnCargaArchivos.Enabled = false;
                    nudTEANueva.Visible = false;
                    lblTEANueva.Visible = false;
                    nudCuotasAmpliar.Visible = true;
                    lblCuotasAmpliar.Visible = true;
                    nudNroCuotasTotal.Visible = true;
                    lblCuotasTotal.Visible = true;
                    break;
                case EventoFormulario.NUEVO:
                    cboTipoPlanPago.Enabled = true;
                    dtpFechaProxPago.Enabled = true;
                    nudDiasGracia.Enabled = false;
                    nudCuotasAmpliar.Enabled = true;
                    btnProcesar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    nudTEANueva.Enabled = true;
                    break;
                case EventoFormulario.IMPRIMIR:
                case EventoFormulario.GRABAR:
                    cboTipoPlanPago.Enabled = false;
                    dtpFechaProxPago.Enabled = false;
                    nudDiasGracia.Enabled = false;
                    nudCuotasAmpliar.Enabled = false;
                    btnProcesar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    nudTEANueva.Enabled = false;

                    btnEditar1.Enabled = true;
                    btnCargaArchivos.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void LiberarCuenta()
        {
            this.conBusCuentaCli1.LiberarCuenta();
            this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli1.txtNroBusqueda.Focus();
            this.conBusCuentaCli1.nValBusqueda = 0;
        }

        private void CalcularTotalCuotas()
        {
            if (this.objSolRepro != null)
            {
                nudNroCuotasTotal.Value = Convert.ToInt32(txtNroCuotas.Text) + Convert.ToInt32(nudCuotasAmpliar.Value);
            }
        }

        private void BloquearRegistroSolicitud(int idTipoPlanPago)
        { 
            // no permitir registro de solicitud
            controlFormulario(EventoFormulario.IMPRIMIR);
        }

        private void CambioTipoPlanPago(int _idTipoPlanPago)
        {
            bool lFechaSistema = (Convert.ToInt32(clsVarApl.dicVarGen["lReproEspecialFechaSistema"])== 1)? true : false;

            DataRow drTipoPlanPago = dtTipoPlanPagoCompleto.AsEnumerable().FirstOrDefault(item => Convert.ToInt32(item["idTipoPlanPago"]) == _idTipoPlanPago);
            bool lAplicaDiasTolerancia = Convert.ToBoolean(drTipoPlanPago["lAplicaDiasTolerancia"]);

            if (lFechaSistema)
            {
                if (this.objSolRepro.dFechaProxVenc < dFechaMargen && lAplicaDiasTolerancia)
                {
                    string cMensaje =   "Este crédito tiene una cuota vencida" +
                                        ((nDiasTolerancia > 0) ? " con " + nDiasTolerancia + ((nDiasTolerancia == 1) ? " día" : " días") + " de atraso" : String.Empty) +
                                        ", no puede realizar la Reprogramación Especial";
                    MessageBox.Show(cMensaje, "Solicitud Reprogramación especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearRegistroSolicitud(this.objSolRepro.idTipoPlanPago);
                    return;
                }

                if(this.objSolRepro.dFechaProxVenc < clsVarGlobal.dFecSystem)
                {
                    this.objSolRepro.dFechaProxVenc = clsVarGlobal.dFecSystem;
                }
            }

            switch (_idTipoPlanPago)
            {
                case 3: // perdon de días
                    // primera regla
                    dtpFechaProxPago.MinDate = (lFechaSistema)? clsVarGlobal.dFecSystem: this.objSolRepro.dFechaUltimoPago.AddDays(1);
                    dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc;
                    
                    break;
                case 4: // cuota constante
                    dtpFechaProxPago.MinDate = (lFechaSistema) ? clsVarGlobal.dFecSystem : this.objSolRepro.dFechaUltimoPago.AddDays(1);
                    dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc;
                    // validaciones
                    if (!this.objSolRepro.lReprogramacion)
                    {
                        MessageBox.Show("La reprogramación de CUOTA CONSTANTE no permite Créditos que no fueron Reprogramados anteriormente.", "Solicitud Reprogramación especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BloquearRegistroSolicitud(this.objSolRepro.idTipoPlanPago);
                    }

                    break;
                case 5: // modificación de Calendarío
                    dtpFechaProxPago.MinDate = (lFechaSistema)? clsVarGlobal.dFecSystem: this.objSolRepro.dFechaUltimoPago.AddDays(1);
                    dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc.AddMonths(3);
                    nudCuotasAmpliar.Maximum = CalcularMaxCuotasAmpliar();
                    
                    break;
                case 6: // calendario con interes compensatorio
                    dtpFechaProxPago.MinDate = this.objSolRepro.dFechaUltimoPago.AddDays(1);
                    dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc;
                    if (!this.objSolRepro.lReprogramacion)
                    {
                        MessageBox.Show("La reprogramación de CALENDARIO CON INTERES COMPENSATORIO no permite Créditos que no fueron Reprogramados anteriormente.", "Solicitud Reprogramación especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BloquearRegistroSolicitud(this.objSolRepro.idTipoPlanPago);
                        btnEditar1.Enabled = false;
                    }

                    break;
                case 7: //Cambio de Tasa
                    if(dtpFechaProxPago.MaxDate <= clsVarGlobal.dFecSystem)
                    {
                        dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc.AddMonths(3);
                        dtpFechaProxPago.MinDate = (lFechaSistema) ? clsVarGlobal.dFecSystem : this.objSolRepro.dFechaUltimoPago.AddDays(1);
                    }
                    else
                    {
                        dtpFechaProxPago.MinDate = (lFechaSistema) ? clsVarGlobal.dFecSystem : this.objSolRepro.dFechaUltimoPago.AddDays(1);
                        dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc.AddMonths(3);
                    }
                    
                    nudCuotasAmpliar.Maximum = CalcularMaxCuotasAmpliar();
                    break;
                default:
                    dtpFechaProxPago.Enabled = false;
                    break;
            }
        }

        private int CalcularMaxCuotasAmpliar()
        { 
            int nMesesMaxAmpliar = 24;

            if (this.objSolRepro.idTipoPeriodo == 1)
            {
                return nMesesMaxAmpliar;
            }
            else if (this.objSolRepro.idTipoPeriodo == 2)
            {
                return nMesesMaxAmpliar/(this.objSolRepro.nFrecuencia/30);
            }
            else
            {
                return 0;
            }
        }

        private void verificarCuenta()
        {
            if (buscarCuenta())
            {
                int nMaximoReproEspPermitido = Convert.ToInt32(clsVarApl.dicVarGen["nNroMaxReprogramacionEsp"]);
                cargarCredito();
                if (this.objSolRepro.idSolicitud != 0)
                {
                    this.controlFormulario(EventoFormulario.IMPRIMIR);
                    return;
                }
                else if (this.objSolRepro.nNroReproEspecial >= nMaximoReproEspPermitido) 
                {
                    MessageBox.Show("El crédito ya realizó " + this.objSolRepro.nNroReproEspecial + ((this.objSolRepro.nNroReproEspecial == 1) ? " reprogramación especial.\n" : " reprogramaciones especiales.\n" )+ "El número maximo permitido es de: "+ nMaximoReproEspPermitido + ((nMaximoReproEspPermitido == 1) ? " vez." : " veces.") , "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.controlFormulario(EventoFormulario.IMPRIMIR);
                    return;
                }
                this.controlFormulario(EventoFormulario.NUEVO);
            }
        }

        private bool validarCondiciones()
        {
            DataTable dtValidaReglasSolicitudRepro;
            GEN.CapaNegocio.clsCNCredito objValidacion = new GEN.CapaNegocio.clsCNCredito();

            dtValidaReglasSolicitudRepro = objValidacion.CNValidaReglasSolicitudRepro(Convert.ToInt32(objSolRepro.idCuenta), Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil), Convert.ToInt32(this.objSolRepro.nTasaNueva));
            if (dtValidaReglasSolicitudRepro.Rows[0]["cRespuesta"].ToString() != "0")
            {
                MessageBox.Show(dtValidaReglasSolicitudRepro.Rows[0]["cRespuesta"].ToString(), "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        #endregion

        #region Eventos

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            verificarCuenta();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            verificarCuenta();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            limpiarFormulario();
            this.controlFormulario(EventoFormulario.CANCELAR);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            obtenerDatosFormulario();

            if (!validarCondiciones())
            {
                return;
            }
           
            GEN.CapaNegocio.clsCNCredito objCredito2 = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtSolRepro = objCredito2.CNRecuperarSolicitudReprogramacionEspecial(objSolRepro.idSolicitud);

            if(dtSolRepro.Rows.Count > 0)
            {
                if (Int32.Parse(dtSolRepro.Rows[0]["idEstado"].ToString()) == 2 )
                {
                    MessageBox.Show("La solicitud del cliente ya fue aprobada.", "Solicitud Aprobada!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnCancelar1.Enabled = true;
                    btnGrabar1.Visible = false;
                    btnEditar1.Visible = false;
                    btnCargaArchivos.Visible = false;

                    return;
                }
            }
           
            if (this.objSolRepro.idTipoPlanPago == 0)
            {
                MessageBox.Show("Se debe seleccionar el tipo plan de pagos", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboTipoPlanPago.Focus();
                return;
            }

            //grabando la solicitud de reprogramación
            GEN.CapaNegocio.clsCNCredito objCredito = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtResultGrabado = objCredito.CNGrabarSolicitudReprogramacion(
                    this.objSolRepro.idCuenta
                    , this.objSolRepro.nDiasGracia
                    , this.objSolRepro.nCuotasFaltantes
                    , this.objSolRepro.nDiasPerdon
                    , this.objSolRepro.idTipoPlanPago
                    , this.dtpFechaProxPago.Value
                    , this.objSolRepro.nTasaNueva
                    , this.objSolRepro.idGrupoReprog
                    , this.objSolRepro.nFrecuencia);
            if (dtResultGrabado.Rows.Count == 0)
            {
                MessageBox.Show("Ha Ocurrido un error al registra la solicitud de reprogramación", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.controlFormulario(EventoFormulario.GRABAR);
                this.objSolRepro.idSolicitud = Convert.ToInt32(dtResultGrabado.Rows[0]["idRegistro"]);
                cargarCredito();
                MessageBox.Show("Se ha registrado la solicitud nro.: " + this.objSolRepro.idSolicitud.ToString()  + " de reprogramación exitosamente", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (validarParaCalculoCuota())
            {
                obtenerDatosFormulario();
                procesarCalculoCuota();
                cboTipoPlanPago.Enabled = false;
                btnGrabar1.Enabled = true;
            }            
        }
        #endregion

        private void cboTipoPlanPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idTipoPlanPago = Convert.ToInt32(cboTipoPlanPago.SelectedValue);
            
            switch (idTipoPlanPago)
            {
                case 3: //REPROGRAMACIÓN CON PERDÓN DÍAS
                    nudCuotasAmpliar.Value = 0;
                    nudCuotasAmpliar.Visible = false;
                    lblCuotasAmpliar.Visible = false;
                    nudDiasGracia.Visible = true;
                    lblDiasGracia.Visible = true;
                    nudPerdon.Maximum = 0;
                    nudPerdon.Visible = true;
                    lblDiasPerdon.Visible = true;
                    lblCuotasTotal.Visible = false;
                    nudNroCuotasTotal.Visible = false;
                    dtpFechaProxPago.Enabled = true;
                    lblTEANueva.Visible = false;
                    nudTEANueva.Visible = false;
                    CalcularTotalCuotas();
                    break;
                case 4: // REPROGRAMACIÓN CON CUOTA CONSTANTE
                    nudCuotasAmpliar.Value = 0;
                    nudCuotasAmpliar.Visible = false;
                    lblCuotasAmpliar.Visible = false;
                    nudDiasGracia.Visible = true;
                    lblDiasGracia.Visible = true;
                    nudPerdon.Maximum = 0;
                    nudPerdon.Value = 0;
                    nudPerdon.Visible = false;
                    lblDiasPerdon.Visible = false;
                    lblCuotasTotal.Visible = false;
                    nudNroCuotasTotal.Visible = false;
                    dtpFechaProxPago.Enabled = true;
                    lblTEANueva.Visible = false;
                    nudTEANueva.Visible = false;
                    CalcularTotalCuotas();
                    break;
                case 5: // REPROGRAMACIÓN CON MODIFICACIÓN DE CALENDARIO
                    nudCuotasAmpliar.Visible = true;
                    lblCuotasAmpliar.Visible = true;
                    nudDiasGracia.Visible = true;
                    lblDiasGracia.Visible = true;
                    nudPerdon.Maximum = 0;
                    nudPerdon.Value = 0;
                    nudPerdon.Visible = false;
                    lblDiasPerdon.Visible = false;
                    lblCuotasTotal.Visible = true;
                    nudNroCuotasTotal.Visible = true;
                    dtpFechaProxPago.Enabled = true;
                    lblTEANueva.Visible = false;
                    nudTEANueva.Visible = false;
                    CalcularTotalCuotas();
                    break;
                case 6://CALENDARIO CON INTERES COMPENSATORIO
                    nudCuotasAmpliar.Value = 0;
                    nudCuotasAmpliar.Visible = false;
                    lblCuotasAmpliar.Visible = false;
                    nudDiasGracia.Visible = true;
                    lblDiasGracia.Visible = true;
                    nudPerdon.Maximum = 0;
                    nudPerdon.Value = 0;
                    nudPerdon.Visible = false;
                    lblDiasPerdon.Visible = false;
                    lblCuotasTotal.Visible = false;
                    nudNroCuotasTotal.Visible = false;
                    dtpFechaProxPago.Enabled = false;
                    lblTEANueva.Visible = false;
                    nudTEANueva.Visible = false;
                    CalcularTotalCuotas();
                    this.dtpFechaProxPago.MinDate = this.objSolRepro.dFechaUltimoPago;
                    this.dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc;
                    this.calcularFechaProxPago();
                    break;
                case 7://CAMBIO DE TASA
                    nudCuotasAmpliar.Value = 0;
                    nudCuotasAmpliar.Visible = true;
                    lblCuotasAmpliar.Visible = true;
                    nudDiasGracia.Visible = false;
                    lblDiasGracia.Visible = false;
                    nudPerdon.Maximum = 0;
                    nudPerdon.Value = 0;
                    nudPerdon.Visible = false;
                    lblDiasPerdon.Visible = false;
                    lblCuotasTotal.Visible = true;
                    nudNroCuotasTotal.Visible = true;
                    dtpFechaProxPago.Enabled = true;
                    lblTEANueva.Visible = true;
                    nudTEANueva.Visible = true;
                    CalcularTotalCuotas();
                    this.dtpFechaProxPago.MinDate = this.objSolRepro.dFechaUltimoPago;
                    this.dtpFechaProxPago.MaxDate = this.objSolRepro.dFechaProxVenc;
                    this.calcularFechaProxPago();
                    break;
                default:
                    break;
            }

            if(this.objSolRepro != null)
                CambioTipoPlanPago(idTipoPlanPago);
            
        }
        private DateTime crearFecha(int nAnio, int nMes, int nDia)
        {
            DateTime dFechaCreada;
            if (nMes > 12)
            {
                nMes = 1;
                nAnio = nAnio + 1;
            }

            while (!DateTime.TryParse(string.Concat(nAnio.ToString(), "-",
               nMes.ToString(), "-", nDia.ToString()), out dFechaCreada))
            {
                nDia--;
            }
            return dFechaCreada;
        }
        private void dtpCorto1_ValueChanged(object sender, EventArgs e)
        {
            int nDiasGracia = 0;
            bool lAplicaDiasPerdon = true;

            if (this.objSolRepro == null)
            {
                return;
            }

            if (this.dtpFechaProxPago.Value <= this.objSolRepro.dFechaUltimoPago)
            {
                MessageBox.Show("¡La fecha de próximo pago debe ser mayor a la fecha de inicio de la reprogramación (Fecha de última cuota pagada)!",
                    "FECHA NO VALIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.cboTipoPlanPago.SelectedIndex = -1;
                this.dtpFechaProxPago.ValueChanged -= dtpCorto1_ValueChanged;
                this.dtpFechaProxPago.Value = this.objSolRepro.dFechaProxVenc;
                this.dtpFechaProxPago.ValueChanged += dtpCorto1_ValueChanged;
                return;
            }

            if (this.objSolRepro.idTipoPeriodo == 1)
            {
                DateTime dFecPrimeraCuota = this.dtpFechaProxPago.Value;
                DateTime dFecSiguienteCuota;
                int nDiasSiguienteCuota = 0;
                int i = 1;
                do
                {
                    dFecSiguienteCuota = this.crearFecha(
                    this.objSolRepro.dFechaUltimoPago.Year,
                    this.objSolRepro.dFechaUltimoPago.Month + i,
                    this.objSolRepro.nFrecuencia);

                    nDiasSiguienteCuota = (int)(dFecSiguienteCuota - this.objSolRepro.dFechaUltimoPago).TotalDays;
                    i++;
                }
                while (nDiasSiguienteCuota < 20);

                nDiasGracia = (int)(this.dtpFechaProxPago.Value - this.objSolRepro.dFechaUltimoPago).TotalDays;

                if (nDiasGracia >= nDiasSiguienteCuota)
                {
                    nDiasGracia = nDiasGracia - nDiasSiguienteCuota;
                }
                else
                {
                    DateTime dFecCuotaCero = new DateTime();
                    int nPlazoCuotaCero = this.objSolRepro.nFrecuencia;
                    int nMesCero = this.objSolRepro.dFechaUltimoPago.Month;
                    int nAnioCero = this.objSolRepro.dFechaUltimoPago.Year;

                    dFecCuotaCero = this.crearFecha(nAnioCero, nMesCero, nPlazoCuotaCero);

                    if (dFecCuotaCero > this.objSolRepro.dFechaUltimoPago)
                    {
                        nDiasGracia = (int)(this.objSolRepro.dFechaUltimoPago - dFecCuotaCero).TotalDays;
                    }
                    else
                    {
                        nDiasGracia = nDiasGracia - nDiasSiguienteCuota;
                        lAplicaDiasPerdon = false;
                    }
                }
            }
            else
            {
                int nDiasPrimeraCuota = 0;
                nDiasPrimeraCuota = (int)(this.dtpFechaProxPago.Value - this.objSolRepro.dFechaUltimoPago).TotalDays;
                nDiasGracia = nDiasPrimeraCuota - this.objSolRepro.nFrecuencia;

            }
            this.objSolRepro.nDiasGracia = nDiasGracia;
            this.nudDiasGracia.Value = nDiasGracia;
            //cambio dias de perdón
            this.nudPerdon.Maximum = (lAplicaDiasPerdon) ? nDiasGracia : 0;
            if (nDiasGracia < 0 && lAplicaDiasPerdon)
            {
                this.nudPerdon.Value = nDiasGracia;
            }
            else
            {
                this.nudPerdon.Value = 0;
            }
        
        }

        private void nudCuotasAmpliar_ValueChanged(object sender, EventArgs e)
        {
            this.CalcularTotalCuotas();
        }

        private void frmSolicitudReprogramacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            this.Dispose();
        }

        private void frmSolicitudReprogramacion_Load(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void btnCargaArchivos_Click(object sender, EventArgs e)
        {
            if (this.objSolRepro.idSolicitud != 0)
            {
                if (this.objSolRepro.idSolicitud > 0)
                {
                    frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objSolRepro.idSolicitud, this.objSolRepro.idEstado == 2 ? true : false);
                    frmCargaArchivo.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No se encontró una Solicitud.", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nudTEANueva_Leave(object sender, EventArgs e)
        {
            DataTable dtMinMaxTasa;
            GEN.CapaNegocio.clsCNCredito objMinMaxTasa = new GEN.CapaNegocio.clsCNCredito();

            dtMinMaxTasa = objMinMaxTasa.CNObtieneMinMaxTasaNueva(Convert.ToInt32(objSolRepro.idCuenta), Convert.ToDecimal(this.objSolRepro.nTasaNueva));

            decimal nTEANuevaMin = Convert.ToDecimal(dtMinMaxTasa.Rows[0]["nTasaMin"]);
            decimal nTEANuevaMax = Convert.ToDecimal(dtMinMaxTasa.Rows[0]["nTasaMax"]);

            if (this.nudTEANueva.Value < nTEANuevaMin || this.nudTEANueva.Value > nTEANuevaMax)
            {
                MessageBox.Show("El valor de la NUEVA TASA debe estar en el intervalo de " +
                    nTEANuevaMin.ToString("#00.0000") +
                    " hasta " + nTEANuevaMax.ToString("#00.0000"),
                    "TASA NUEVA INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nudTEANueva.Value = this.objSolRepro.nTasa;
            }
            else
            {
                this.objSolRepro.nTasaNueva = this.nudTEANueva.Value;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.objSolRepro.idSolicitud != 0)
            {
                if (this.objSolRepro.idSolicitud > 0)
                {
                    GEN.CapaNegocio.clsCNCredito objCredito2 = new GEN.CapaNegocio.clsCNCredito();
                    DataTable dtSolRepro = objCredito2.CNRecuperarSolicitudReprogramacionEspecial(objSolRepro.idSolicitud);

                    if (Int32.Parse(dtSolRepro.Rows[0]["idEstado"].ToString()) == 2)
                    {
                        MessageBox.Show("La solicitud del cliente ya fue aprobada.", "Solicitud Aprobada!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnCancelar1.Enabled = true;
                        btnGrabar1.Visible = false;
                        btnEditar1.Visible = false;
                        btnCargaArchivos.Visible = false;

                        return;
                    }
                              
                    this.cargarConfiguracionesDeGasto();
          
                    if (Int32.Parse(dtSolRepro.Rows[0]["idTipoPlanPago"].ToString()) == 4)
                    {
                        dtpFechaProxPago.Enabled = true;
                        btnProcesar1.Enabled = true;
                        btnGrabar1.Enabled = true;
                    }
                    if (Int32.Parse(dtSolRepro.Rows[0]["idTipoPlanPago"].ToString()) == 5)
                    {
                        dtpFechaProxPago.Enabled = true;
                        nudCuotasAmpliar.Enabled = true;
                        btnProcesar1.Enabled = true;
                        btnGrabar1.Enabled = true;
                    }
                    if (Int32.Parse(dtSolRepro.Rows[0]["idTipoPlanPago"].ToString()) == 7)
                    {
                        dtpFechaProxPago.Enabled = true;
                        nudCuotasAmpliar.Enabled = true;
                        nudTEANueva.Enabled = true;
                        btnProcesar1.Enabled = true;
                        btnGrabar1.Enabled = true;
                    }
                    btnGrabar1.Enabled = false;
                    btnEditar1.Enabled = false;
                                        
                    this.objSolRepro.nNroCuotaAmpliar = Int32.Parse(dtSolRepro.Rows[0]["nCuotasPend"].ToString()) + Int32.Parse(dtSolRepro.Rows[0]["nCuotasPagadas"].ToString());
                    this.objSolRepro.nCuotasPagadas = Int32.Parse(dtSolRepro.Rows[0]["nCuotasPagadas"].ToString());
                    this.lblCuotasPendientes.Text = this.objSolRepro.nCuotasFaltantes.ToString();

                }
            }
            else
            {
                MessageBox.Show("No se encontró una Solicitud.", "Solicitud de Reprogramación Especial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
