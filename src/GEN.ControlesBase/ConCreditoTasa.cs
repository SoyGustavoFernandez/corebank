using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;
using RSG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConCreditoTasa : UserControl
    {
        public event EventHandler ChangeMonto;
        public event EventHandler ChangeMoneda;
        public event EventHandler ChangeCuotaAprox;
        public event EventHandler ChangePlazo;
        public event EventHandler ValueChangedDia;

        public int nPlazoTotal;
        private int nPlazoTem;

        private clsCreditoProp objCreditoProp;
        private clsCNPlanPago oCNPlanPago;
        private DataTable dtCalendarioPagos;
        private List<clsDisenioCredito> listDisenioCredito;

        private bool _lMostrarTodosNivCred;
        private char Transaccion = Convert.ToChar("I");

        private int idProducto = 0;
        private int idTasa = 0;

        private int nPlazoTotalEnDiasBck = 0;
        private int idProductoBck = 0;
        //private int idTasaBck = 0;
        private decimal nMontoBck = 0;
        private int idMonedaBck = 0;

        private decimal nCuotaConstante;
        private decimal nCuotaGraciaAprox;

        private List<clsTasaNegociable> listaTasasNegociables;

        //frmEvaluaSobreendeuda frmSobreDeuda;
        DataTable dtResultadosSobreDeuda;

        private decimal nTasaCampana = 0.0000m;
        private string cMensajeTasaCampaña = "";

        private int idEvalCred;

        public ConCreditoTasa()
        {
            InitializeComponent();

            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;

            MonedaEnabled = false;

            this.objCreditoProp = new clsCreditoProp();
            this.oCNPlanPago = new clsCNPlanPago();

            this.dtCalendarioPagos = new DataTable();
            this.nCuotaConstante = 0;
            this.nCuotaGraciaAprox = 0;
            this.nPlazoTotal = 0;
            //this.dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;

            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
        }

        public void getIdEvalCred(int idEvalCred)
        {
            this.idEvalCred = idEvalCred;
        }

        [DefaultValue(true)]
        #region "Properties"
        public bool lMostrarTodosNivCred
        {
            set
            {
                _lMostrarTodosNivCred = value;
                conNivelesProducto.lMostrarTipoCredito = value;
                Invalidate();
            }
            get { return _lMostrarTodosNivCred; }
        }
        public bool MonedaEnabled
        {
            get { return this.cboMoneda.Enabled; }
            set { this.cboMoneda.Enabled = value; }
        }
        public bool MontoEnabled
        {
            get { return this.txtMonto.Enabled; }
            set { this.txtMonto.Enabled = value; }
        }
        public bool CuotasEnabled
        {
            get { return this.nudCuotas.Enabled; }
            set { this.nudCuotas.Enabled = value; }
        }
        public bool PlazoCuotaEnabled
        {
            get { return (this.conCreditoPeriodo.lPeriodoEnabled && this.conCreditoPeriodo.lDiaEnabled ); }
            set
            {
                this.conCreditoPeriodo.lPeriodoEnabled = value;
                this.conCreditoPeriodo.lDiaEnabled = value;
            }
        }
        public bool TipoPeriodoEnabled
        {
            get { return this.conCreditoPeriodo.lTipoPeriodoEnabled; }
            set { this.conCreditoPeriodo.lTipoPeriodoEnabled = value; }
        }
        public bool DiasGraciaEnabled
        {
            get { return this.nudDiasGracia.Enabled; }
            set { this.nudDiasGracia.Enabled = false; }
        }
        public bool FechaDesembolsoEnabled
        {
            get { return this.dtFechaDesembolso.Enabled; }
            set { this.dtFechaDesembolso.Enabled = value; }
        }
        public bool TipoTasaCreditoEnabled
        {
            get { return this.cboTipoTasaCredito.Enabled; }
            set { this.cboTipoTasaCredito.Enabled = value; }
        }
        public bool TEAEnabled
        {
            get { return this.txtTEA.Enabled; }
            set { this.txtTEA.Enabled = value; }
        }
        public bool NivelesProductoEnabled
        {
            get { return this.conNivelesProducto.Enabled; }
            set { this.conNivelesProducto.Enabled = value; }
        }
        public bool CuotasGraciaEnable
        {
            get { return this.nudCuotasGracia.Enabled; }
            set { this.nudCuotasGracia.Enabled = value; }
        }
        public bool SubTipoPeriodoEnable
        {
            get { return this.conCreditoPeriodo.lPeriodoEnabled; }
            set { this.conCreditoPeriodo.lPeriodoEnabled = value; }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDatosObj(clsCreditoProp _objCreditoProp)
        {
            this.objCreditoProp = _objCreditoProp;
        }

        public void AsignarDatos(clsCreditoProp _objCreditoProp)
        {
            this.cMensajeTasaCampaña = "";
            this.nTasaCampana = 0.0000m;

            this.objCreditoProp = _objCreditoProp.Clone();

            this.cboMoneda.SelectedIndexChanged -= new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.cboMoneda.Validating -= new System.ComponentModel.CancelEventHandler(this.cboMoneda_Validating);
            this.txtMonto.Validating -= new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            this.nudCuotas.Validating -= new System.ComponentModel.CancelEventHandler(this.nudCuotas_Validating);

            this.nudCuotasGracia.Validating -= new System.ComponentModel.CancelEventHandler(this.nudPeriodosGracia_Validating);
            this.dtFechaDesembolso.Validating -= new System.ComponentModel.CancelEventHandler(this.dtFechaDesembolso_Validating);
            this.nudDiasGracia.Validating -= new System.ComponentModel.CancelEventHandler(this.nudDiasGracia_Validating);
            this.cboTipoTasaCredito.SelectedIndexChanged -= new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            this.conNivelesProducto.ChangeProducto -= new System.EventHandler(this.conNivelesProducto_ChangeProducto);
            this.txtTEA.TextChanged -= new System.EventHandler(this.txtTEA_TextChanged);
            this.txtTEA.Validating -= new System.ComponentModel.CancelEventHandler(this.txtTEA_Validating);

            this.dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;
            this.conCreditoPrimeraCuota.ValueChangedFecha -= conCreditoPrimeraCuota_ValueChangedFecha;
            this.conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            this.conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;

            this.dtFechaDesembolso.Value = _objCreditoProp.dFechaDesembolso;
            this.nudCuotas.Value = _objCreditoProp.nCuotas;
            if (_objCreditoProp.nCuotas == 1) this.nudCuotas.Enabled = false;
            //this.nudPlazoCuota.Value = _objCreditoProp.nPlazoCuota;
            this.nudCuotasGracia.Value = _objCreditoProp.nCuotasGracia;
            this.nudDiasGracia.Value = _objCreditoProp.nDiasGracia;

            if (_objCreditoProp.idTipoPeriodo == 3) // Cuotas Libres Rural
            {
                this.nudDiasGracia.Value = 0;
                this.nudDiasGracia.Enabled = false;
                this.nudCuotas.Enabled = false;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = false;
            }
            this.conCreditoPeriodo.asignarPeriodoCredito(
                _objCreditoProp.idTipoPeriodo,
                _objCreditoProp.nPlazoCuota,
                _objCreditoProp.idOperacion,
                _objCreditoProp.nCuotas
                );

            conCreditoPrimeraCuota.asignarPrimeraCuota(
                conCreditoPeriodo.idTipoPeriodo,
                conCreditoPeriodo.nPeriodoDia,
                _objCreditoProp.nDiasGracia,
                _objCreditoProp.dFechaDesembolso,
                _objCreditoProp.nCuotas,
                _objCreditoProp.idOperacion,
                idsolicitud: _objCreditoProp.idSolicitud);

            this.cboMoneda.SelectedValue = _objCreditoProp.idMoneda;
            this.txtMonto.Text = _objCreditoProp.nMonto.ToString();
            this.idProducto = _objCreditoProp.idProducto;

            this.conNivelesProducto.cargarProductos(1, _objCreditoProp.idProducto);

            asignarTasa(false);

            if (_objCreditoProp.idOperacion == 5)
            {
                //nudPlazoCuota.Maximum = 9999;
            }

            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.cboMoneda.Validating += new System.ComponentModel.CancelEventHandler(this.cboMoneda_Validating);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            this.nudCuotas.Validating += new System.ComponentModel.CancelEventHandler(this.nudCuotas_Validating);
            this.nudCuotasGracia.Validating += new System.ComponentModel.CancelEventHandler(this.nudPeriodosGracia_Validating);
            this.dtFechaDesembolso.Validating += new System.ComponentModel.CancelEventHandler(this.dtFechaDesembolso_Validating);
            this.dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
            this.nudDiasGracia.Validating += new System.ComponentModel.CancelEventHandler(this.nudDiasGracia_Validating);
            this.conNivelesProducto.ChangeProducto += new System.EventHandler(this.conNivelesProducto_ChangeProducto);

            this.txtTEA.TextChanged += new System.EventHandler(this.txtTEA_TextChanged);
            this.txtTEA.Validating += new System.ComponentModel.CancelEventHandler(this.txtTEA_Validating);
            this.conCreditoPrimeraCuota.ValueChangedFecha += conCreditoPrimeraCuota_ValueChangedFecha;
            this.conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            this.conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;

            this.cboTipoTasaCredito.SelectedIndexChanged -= new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            this.cboTipoTasaCredito.SelectedValue = _objCreditoProp.idTasa;
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            cboTipoTasaCredito_SelectedIndexChanged(this.cboTipoTasaCredito, new EventArgs());
            this.txtTEA.Text = _objCreditoProp.nTasaCompensatoria.ToString("n4");
            txtTEA_TextChanged(this.txtTEA, new EventArgs());

            this.objCreditoProp.nCuotaAprox = this.nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = this.nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = this.dtCalendarioPagos;
            this.objCreditoProp.nTotalMontoPagar = TotalMontoPagar();

            DispararEventoChangeCuotaAprox();
            // DispararEventoChangeCuotaAprox, dispara el evento para asignar los siguiente:
            // nCuotaAprox
            // nCuotaGraciaAprox
            // dtCalendarioPagos
            // nTotalMontoPagar

            ObtenerTasasNegociables(this.objCreditoProp.idSolicitud);

            GestionSobreDeuda();
            this.conCreditoPeriodo.actualizarDia(PlazoCuota());
            
            this.txtMonto.Enabled = !this.objCreditoProp.idOperacion.In(2, 6);
            //this.calcularFechaPrimeraCuota();
            if (this.objCreditoProp.idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha)
                this.lblDesembolso.Text = "Base Reprog";
        }

        public int idMoneda
        {
            get { return Convert.ToInt32(this.cboMoneda.SelectedValue); }
        }

        public DataRowView MonedaItem
        {
            get { return (DataRowView)this.cboMoneda.SelectedItem; }
        }

        public decimal MontoPropuesto
        {
            get { return String.IsNullOrWhiteSpace(this.txtMonto.Text) ? 0 : Convert.ToDecimal(this.txtMonto.Text); }
        }

        /// <summary>
        /// Retorna el Monto del crédito
        /// </summary>
        /// <returns></returns>
        public decimal Monto()
        {
            return MontoPropuesto;
        }

        /// <summary>
        /// Retorna el numero de cuotas del crédito
        /// </summary>
        /// <returns></returns>
        public int Cuotas()
        {
            return String.IsNullOrWhiteSpace(this.nudCuotas.Text) ? 0 : Convert.ToInt32(this.nudCuotas.Text);
        }

        /// <summary>
        /// Retorna la fecha de Desembolso
        /// </summary>
        /// <returns></returns>
        public DateTime FechaDesembolso()
        {
            var fecha = this.dtFechaDesembolso.Value;

            return Convert.ToDateTime(fecha);
        }

        /// <summary>
        /// Retorna la fecha de Primera Cuota
        /// </summary>
        /// <returns></returns>
        public DateTime FechaPrimeraCuota()
        {
            var fecha = this.conCreditoPrimeraCuota.dFechaPriCuota();

            return Convert.ToDateTime(fecha);
        }

        public DateTime fechaMinima()
        {
            return this.conCreditoPrimeraCuota.fechaMinima();
        }

        /// <summary>
        /// Retorna el PlazoCuota del crédito en número de días
        /// </summary>
        /// <returns></returns>
        public int PlazoCuota()
        {
            //return String.IsNullOrWhiteSpace(this.nudPlazoCuota.Text) ? 0 : Convert.ToInt32(this.nudPlazoCuota.Text);
            return this.conCreditoPeriodo.nPeriodoDia;
        }

        /// <summary>
        /// Retorna el tipo de Periodo: Fecha Fija , Periodo Fijo, Cuotas libres
        /// </summary>
        /// <returns></returns>
        public int TipoPeriodo()
        {
            //return Convert.ToInt32(this.cboTipoPeriodo.SelectedValue);
            return this.conCreditoPeriodo.idTipoPeriodo;
        }

        /// <summary>
        /// Retorna el Periodo: Mensual ,Bimestral, Trimestral, UNicuota, etc
        /// </summary>
        /// <returns></returns>
        public int Periodo()
        {
            return this.conCreditoPeriodo.idPeriodo;
        }

        /// <summary>
        /// Retorna el Plazo del crédito
        /// </summary>
        /// <returns></returns>
        public int Plazo()
        {
            int nCuotas = Cuotas();
            int nTipoPeriodo = TipoPeriodo();
            int nPlazoCuota = PlazoCuota();

            return (nTipoPeriodo == 1) ? nCuotas : (int)Math.Round(((nCuotas * nPlazoCuota) / 30.000), 0);
        }

        /// <summary>
        /// Retorna los periodos de gracia del crédito
        /// </summary>
        /// <returns></returns>
        public int CuotasGracia()
        {
            return String.IsNullOrWhiteSpace(this.nudCuotasGracia.Text) ? 0 : Convert.ToInt32(this.nudCuotasGracia.Text);
        }

        public int DiasGracia()
        {
            return String.IsNullOrWhiteSpace(this.nudDiasGracia.Text) ? 0 : Convert.ToInt32(this.nudDiasGracia.Text);
        }

        /// <summary>
        /// Retorna la tasa efectiva anual
        /// </summary>
        /// <returns></returns>
        public decimal TEA()
        {
            return String.IsNullOrWhiteSpace(this.txtTEA.Text) ? 0 : Convert.ToDecimal(this.txtTEA.Text);
        }

        /// <summary>
        /// Retorna la tasa efectiva mensual
        /// </summary>
        /// <returns></returns>
        public decimal TEM()
        {
            return String.IsNullOrWhiteSpace(this.txtTEM.Text) ? 0 : Convert.ToDecimal(this.txtTEM.Text);
        }

        public clsCreditoProp ObtenerCreditoPropuesto()
        {
            this.objCreditoProp.idMoneda = this.idMoneda;
            this.objCreditoProp.nMonto = Monto();
            this.objCreditoProp.nCuotas = Cuotas();
            this.objCreditoProp.idTipoPeriodo = TipoPeriodo();
            this.objCreditoProp.nPlazoCuota = PlazoCuota();
            this.objCreditoProp.nPlazo = Plazo();
            this.objCreditoProp.nCuotasGracia = CuotasGracia();
            this.objCreditoProp.nDiasGracia = DiasGracia();
            this.objCreditoProp.dFechaDesembolso = this.dtFechaDesembolso.Value;
            this.objCreditoProp.nTasaCompensatoria = TEA();
            this.objCreditoProp.idTasa = Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
            this.objCreditoProp.idProducto = this.idProducto;

            this.objCreditoProp.nCuotaAprox = this.nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = this.nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = this.dtCalendarioPagos;
            this.objCreditoProp.cCalendarioPagos = CalendarioPagosXML();
            this.objCreditoProp.nTotalMontoPagar = TotalMontoPagar();

            return this.objCreditoProp;
        }

        public int ObtenerIdProducto()
        {
            return this.idProducto;
        }

        public void LimpiarFormulario()
        {
            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;

            this.objCreditoProp = null;
            this.cboMoneda.SelectedIndex = -1;
            this.txtMonto.Text = "0";
            this.nudCuotas.Value = 0;
            this.conCreditoPeriodo.limpiarControles();
            this.nudDiasGracia.Value = 0;
            this.nudCuotasGracia.Value = 0;
            this.dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;

            this.conNivelesProducto.limpiar();

            this.cboTipoTasaCredito.SelectedIndex = -1;
            this.txtTEA.Text = "0";
            this.txtTEM.Text = "0";
            this.txtTasaMora.Text = "0";

            errorProvider.SetError(this.dtFechaDesembolso, String.Empty);
            errorProvider.SetError(this.nudCuotas, String.Empty);
            errorProvider.SetError(this.txtMonto, String.Empty);
            //errorProvider.SetError(this.nudPlazoCuota, String.Empty);
            errorProvider.SetError(this.txtTEA, String.Empty);

            errorProvider.SetError(this.cboTipoTasaCredito, String.Empty);
            errorProvider.SetError(this.nudCuotasGracia, String.Empty);
            errorProvider.SetError(this.cboMoneda, String.Empty);
            //errorProvider.SetError(this.cboTipoPeriodo, String.Empty);
            errorProvider.SetError(this.nudDiasGracia, String.Empty);

            this.objCreditoProp = new clsCreditoProp();

            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
        }

        /// <summary>
        /// Retorna la cuota aproximada de acuerdo a la condiciones de crédito especificada
        /// </summary>
        /// <returns></returns>
        public decimal CuotaAprox()
        {
            return this.nCuotaConstante;
        }

        /// <summary>
        /// Retorna la cuota aproximada del periodo de gracia de acuerdo a las especificaciones indicadas
        /// </summary>
        /// <returns></returns>
        public decimal CuotaGraciaAprox()
        {
            return this.nCuotaGraciaAprox;
        }

        /// <summary>
        /// Retorna la suma total de cuotas según al número de cuotas indicadas
        /// </summary>
        /// <returns></returns>
        public decimal TotalMontoPagar()
        {
            if (this.dtCalendarioPagos.Rows.Count > 0)
                return Convert.ToDecimal(this.dtCalendarioPagos.Compute("Sum(imp_cuota)", ""));

            return 0;
        }

        public decimal TotalMontoPagarAnualizado()
        {
            int nPlazo = Plazo();
            int nMaximo = (nPlazo >= 12) ? 12 : nPlazo;

            decimal nTotal = 0;
            int nDiasAcu = 0;
            decimal nCuota = 0;
            int nMes = 0;
            var listFlujoCaja = new List<clsFlujoCaja>();

            foreach (DataRow row in this.dtCalendarioPagos.Rows)
            {
                nDiasAcu = Convert.ToInt32(row["dias_acu"]);
                nCuota = Convert.ToDecimal(row["imp_cuota"]);

                nMes = Convert.ToInt32(Math.Round(nDiasAcu / 30.00, 0));

                listFlujoCaja.Add(new clsFlujoCaja { nMes = nMes, nMonto = nCuota });
            }

            if (listFlujoCaja.Count > 0)
            {
                nTotal = listFlujoCaja
                        .Where(x => x.nMes <= nMaximo)
                        .Sum(x => x.nMonto);
            }
            else
            {
                nTotal = 0;
            }

            return nTotal;
        }

        /// <summary>
        /// Retorna el calendario de pagos según las condiciones especificadas
        /// </summary>
        /// <returns></returns>
        public DataTable CalengarioPagos()
        {
            return this.dtCalendarioPagos;
        }

        public string CalendarioPagosXML()
        {
            var listCuotaConst = (from p in this.dtCalendarioPagos.AsEnumerable()
                                  select new
                                  {
                                      nDiasAcu = p.Field<int>("dias_acu"),
                                      nCuota = p.Field<decimal>("imp_cuota")
                                  }).ToList();

            DataTable dt = new DataTable();

            dt.Columns.Add("d", typeof(int));
            dt.Columns.Add("c", typeof(decimal));

            foreach (var bg in listCuotaConst)
            {
                dt.Rows.Add(bg.nDiasAcu, bg.nCuota);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "Pagos", "ct")
                .Replace(">    <", "><")
                .Replace(">  <", "><");
        }

        public bool ValidandoSolicitudCredito()
        {
            if (this.objCreditoProp.nMonto < 1)
            {
                return false;
            }

            //if (objCreditoProp.nTem < 1)
            //{
            //    return false;
            //}

            if (objCreditoProp.nCuotas < 1)
            {
                return false;
            }

            if (objCreditoProp.nPlazoCuota < 1)
            {
                return false;
            }
            if (objCreditoProp.idMoneda < 1)
            {
                return false;
            }
            return true;
        }

        public clsMsjError Validar()
        {
            var objMsjError = new clsMsjError();

            errorProvider.SetError(this.dtFechaDesembolso, String.Empty);
            errorProvider.SetError(this.nudCuotas, String.Empty);
            errorProvider.SetError(this.txtMonto, String.Empty);
            //errorProvider.SetError(this.nudPlazoCuota, String.Empty);
            errorProvider.SetError(this.txtTEA, String.Empty);

            errorProvider.SetError(this.cboTipoTasaCredito, String.Empty);
            errorProvider.SetError(this.nudCuotasGracia, String.Empty);
            errorProvider.SetError(this.cboMoneda, String.Empty);
            //errorProvider.SetError(this.cboTipoPeriodo, String.Empty);
            errorProvider.SetError(this.nudDiasGracia, String.Empty);

            #region
            if (!EsMonedaValido())
            {
                objMsjError.AddError("Moneda no seleccionada.");
                errorProvider.SetError(this.cboMoneda, "Seleccione una opción.");
            }

            if (!EsMontoValido())
            {
                objMsjError.AddError("El Monto, debe ser mayor a CERO.");
                errorProvider.SetError(this.txtMonto, "El Monto debe ser mayor a CERO.");
            }
            else if (!montoLimiteValido())
            {
                objMsjError.AddError(string.Concat("El Monto, no debe ser mayor a ",this.objCreditoProp.nMonto));
                errorProvider.SetError(this.txtMonto, string.Concat("El Monto, no debe ser mayor a ",this.objCreditoProp.nMonto));
            }

            if (!EsCuotasValido())
            {
                objMsjError.AddError("Número de cuotas, debe ser mayor a CERO.");
                errorProvider.SetError(this.nudCuotas, "Número de cuotas debe ser mayor a CERO");
            }

            if (!EsCuotasGraciaValido())
            {
                int nNumCuotas = (EsCuotasValido()) ? this.Cuotas() : 0;
                int nCuotasGracia = this.CuotasGracia();

                if (String.IsNullOrWhiteSpace(this.nudCuotasGracia.Text))
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Ingrese un valor numérico válido.");
                    objMsjError.AddError("Cuotas Gracia inválido");
                }
                else if (nCuotasGracia > 0 && nCuotasGracia >= nNumCuotas)
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Cuotas Gracia es mayor a Num. Cuotas.");
                    objMsjError.AddError("Cuotas Gracia es mayor a Num. Cuotas.");
                }
                else if (nCuotasGracia >= 12)
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Cuotas Gracia es mayor a 12 cuotas.");
                    objMsjError.AddError("Cuotas Gracia es mayor a 12 cuotas");
                }
            }

            /*if (!EsFechaDesembolsoValido())
            {
                objMsjError.AddError("La Fecha de Desembolso, no puede ser menor a la del sistema.");
                errorProvider.SetError(this.dtFechaDesembolso, "La Fecha de Desembolso no puede ser menor a la del sistema.");
            }*/

            if (!EsDiasGraciaValido())
            {
                objMsjError.AddError("Dias de Gracia inválido.");
                errorProvider.SetError(this.nudDiasGracia, "Ingrese un valor numérico.");
            }
            #endregion

            var objProductosMsjError = this.conNivelesProducto.Validar();

            if (objProductosMsjError.HasErrors)
            {
                foreach (var err in objProductosMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            if (!EsTipoTasaCreditoValido())
            {
                objMsjError.AddError("Tipo de Tasa no seleccionada.");
                errorProvider.SetError(this.cboTipoTasaCredito, "Seleccione una opción.");
            }

            if (!EsTEAValido())
            {
                var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;

                if (drvTasa != null)
                {
                    DataRow row = drvTasa.Row;

                    decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
                    decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
                    decimal nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);

                    decimal nTEA = TEA();

                    if (nTEA == 0 || nTEA >= 300)
                    {
                        objMsjError.AddError("TEA no es válido");
                        errorProvider.SetError(this.txtTEA, "Ingrese un TEA válido.");
                    }
                    else if ((nTEA < nTasaMin || nTEA > nTasaMax) && nTasaNegAprobada <= 0)
                    {
                        objMsjError.AddError("TEA fuera de los rangos.");
                        errorProvider.SetError(this.txtTEA, "Ingrese un TEA dentro de los rangos.");
                    }
                }
                else
                {
                    objMsjError.AddError("TEA no es válido");
                    errorProvider.SetError(this.txtTEA, "Ingrese un TEA válido.");
                }
            }

            if (!validaTasaCampana())
            {
                objMsjError.AddError(this.cMensajeTasaCampaña);
            }

            return objMsjError;
        }
        #endregion

        #region Métodos Privados

        #region Metodos Generales
        private void ObtenerTasasNegociables(int idSolicitud)
        {
            clsCNEvaluacion objADEvaluacion = new clsCNEvaluacion();
            DataTable dt =  objADEvaluacion.ListaTasasNegociables(idSolicitud);

            this.listaTasasNegociables = DataTableToList.ConvertTo<clsTasaNegociable>(dt) as List<clsTasaNegociable>;

            this.pbxTasaAprob.Visible = false;

            if (this.listaTasasNegociables.Count>0)
                this.pbxTasaAprob.Visible = true;

        }

        private DataTable CalendarioCuotasConstantes(clsCreditoProp oCreditoProp, DateTime dFecPrimeracuota)
        {
            DataTable dtEmpty = new DataTable();

            return (this.oCNPlanPago.CalculaPpgCuotasConstantes(
                    oCreditoProp.nMonto,
                    oCreditoProp.nTea / 100.00m,
                    oCreditoProp.dFechaDesembolso,
                    oCreditoProp.nCuotas,
                    oCreditoProp.nDiasGracia,
                    Convert.ToInt16(oCreditoProp.idTipoPeriodo),
                    oCreditoProp.nPlazoCuota,
                    0,
                    dtEmpty,
                    oCreditoProp.idMoneda,
                    dtEmpty,
                    dFecPrimeracuota));
        }

        private DataTable CalendarioCuotasPeriodosGracia(DataTable dtCalendarioPagos, clsCreditoProp oCreditoProp, DateTime dFecPrimeracuota)
        {
            DataTable dtEmpty = new DataTable();

            return (this.oCNPlanPago.CalcularCuotasGracia(
                    dtCalendarioPagos,
                    oCreditoProp.nMonto,
                    oCreditoProp.nTea / 100.00m,
                    oCreditoProp.dFechaDesembolso,
                    oCreditoProp.nDiasGracia,
                    Convert.ToInt16(oCreditoProp.idTipoPeriodo),
                    oCreditoProp.nPlazoCuota,
                    dtEmpty,
                    oCreditoProp.idMoneda,
                    dtEmpty,
                    dFecPrimeracuota,
                    oCreditoProp.nCuotas,
                    oCreditoProp.nCuotasGracia));
        }

        public void ActualizarMontoFlujoCaja(decimal nMonto)
        {
            txtMonto.Text = nMonto.ToString();
        }

        public void ActualizarFechaFlujoCaja(DateTime dFechaPriCuota)
        {
            conCreditoPrimeraCuota.SetFechaPriCuota(dFechaPriCuota);
        }

        public void ActualizarFechaPriCuota(DateTime dFechaPriCuota)
        {
            conCreditoPrimeraCuota.SetFechaPriCuota(dFechaPriCuota);
        }

        public void GeneraPlanPagos()
        {
            this.DispararEventoChangeCuotaAprox(true);
        }

        public void ActualizarObjetoCreditoProp(Boolean lExterno = false)
        {
            if (!lExterno)
            {
                this.objCreditoProp.idMoneda = this.idMoneda;
                this.objCreditoProp.nMonto = this.Monto();
                this.objCreditoProp.nCuotas = this.Cuotas();
                this.objCreditoProp.idTipoPeriodo = this.TipoPeriodo();
                this.objCreditoProp.nPlazoCuota = this.PlazoCuota();
                this.objCreditoProp.nPlazo = this.Plazo();
                this.objCreditoProp.nCuotasGracia = this.CuotasGracia();
                this.objCreditoProp.nDiasGracia = this.DiasGracia();
                this.objCreditoProp.dFechaDesembolso = this.dtFechaDesembolso.Value;
                this.objCreditoProp.nTasaCompensatoria = TEA();
                this.objCreditoProp.idTasa = Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
                this.objCreditoProp.idProducto = this.idProducto;
            }
        }

        public void DispararEventoChangeCuotaAprox(Boolean lExterno=false)
        {
            this.dtCalendarioPagos = new DataTable();
            this.nCuotaConstante = 0;
            this.nCuotaGraciaAprox = 0;
            DateTime dFecPrimeracuota;

            // -- Actualiza this.objCreditoProp
            ActualizarObjetoCreditoProp(lExterno);
            if (!lExterno)
            {
                if (this.objCreditoProp.idTipoPeriodo == 1)
                    dFecPrimeracuota = this.objCreditoProp.dFechaDesembolso.AddMonths(1);
                else
                    dFecPrimeracuota = this.objCreditoProp.dFechaDesembolso.AddDays(this.objCreditoProp.nPlazoCuota)
                                                                            .AddDays(this.objCreditoProp.nDiasGracia);
            }
            else
            {
                dFecPrimeracuota = this.objCreditoProp.dFechaPrimeraCuota;
            }

            if (this.objCreditoProp.nCuotas != 0 && this.objCreditoProp.idTipoPeriodo != 0 && this.objCreditoProp.nPlazoCuota != 0)
            {
                this.dtCalendarioPagos = CalendarioCuotasConstantes(this.objCreditoProp, dFecPrimeracuota);

                if (CuotasGracia() > 0)
                {
                    this.dtCalendarioPagos = CalendarioCuotasPeriodosGracia(this.dtCalendarioPagos, this.objCreditoProp, dFecPrimeracuota);

                    if (this.dtCalendarioPagos.Rows.Count > 0)
                    {
                        var listCuotaConst = (from p in this.dtCalendarioPagos.AsEnumerable()
                                              where p.Field<decimal>("capital") > 0
                                              select new
                                              {
                                                  nCapital = p.Field<decimal>("capital"),
                                                  nInteres = p.Field<decimal>("interes"),
                                                  nCuota = p.Field<decimal>("imp_cuota")
                                              }).ToList();

                        var listaCuotaPGracia = (from p in this.dtCalendarioPagos.AsEnumerable()
                                                 where p.Field<decimal>("capital") == 0
                                                 select new
                                                 {
                                                     nCapital = p.Field<decimal>("capital"),
                                                     nInteres = p.Field<decimal>("interes"),
                                                     nCuota = p.Field<decimal>("imp_cuota")
                                                 }).ToList();

                        this.nCuotaConstante = (listCuotaConst.Count > 0) ? listCuotaConst[0].nCuota : 0;
                        this.nCuotaGraciaAprox = (listaCuotaPGracia.Count > 0) ? listaCuotaPGracia[0].nCuota : 0;
                    }
                }
                else
                {
                    this.nCuotaConstante = (this.dtCalendarioPagos.Rows.Count > 0) ? Convert.ToDecimal(this.dtCalendarioPagos.Rows[0]["imp_cuota"]) : 0;
                    this.nCuotaGraciaAprox = 0;
                }
            }

            this.objCreditoProp.nCuotaAprox = this.nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = this.nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = this.dtCalendarioPagos;
            this.objCreditoProp.nTotalMontoPagar = TotalMontoPagar();
            //this.objCreditoProp.cCalendarioPagos = this.listCronograma.GetXml();

            if (ChangeCuotaAprox != null)
                ChangeCuotaAprox(null, null);
        }

        private int obtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return ((new clsCNSolicitud()).ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag));
        }

        private void asignarTasa(bool lDispararEvento = true)
        {
            if (!EsCuotasValido() || !EsDiasGraciaValido()
                || !EsTipoPeriodoValido() || !EsPlazoCuotaValido() || this.idProducto == 0
                || !EsMontoValido() || !montoLimiteValido() || !EsMonedaValido() || !EsCuotasGraciaValido()) return;

            int nPlazoTotalEnDias = obtenerTotalDias(Convert.ToDateTime(dtFechaDesembolso.Value),
                                                    Convert.ToInt32(nudCuotas.Value),
                                                    Convert.ToInt32(nudDiasGracia.Value),
                                                    this.conCreditoPeriodo.idTipoPeriodo,
                                                    this.conCreditoPeriodo.nPeriodoDia);


            this.nPlazoTotal = nPlazoTotalEnDias;

            int idProducto = this.idProducto;
            decimal nMonto = String.IsNullOrEmpty(this.txtMonto.Text) ? 0 : Convert.ToDecimal(this.txtMonto.Text);
            int idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);

            // -- Si no hay variación, entonces no se invoca al método del listado de tasas
            /*if (nPlazoTotalEnDias == nPlazoTotalEnDiasBck && nMonto == nMontoBck) return;
            else
            {
                this.nPlazoTotalEnDiasBck = nPlazoTotalEnDias;
                this.nMontoBck = nMonto;
            }*/

            //DataTable dtTasa = (new clsCNTasaCredito()).ListaTasaEval(nPlazoTotalEnDias, idProducto, nMonto, idMoneda, clsVarGlobal.nIdAgencia, this.objCreditoProp.idSolicitud);
            int idAgencia = (this.objCreditoProp.idAgencia<=0) ? clsVarGlobal.nIdAgencia : this.objCreditoProp.idAgencia;
            DataTable dtTasa = (new clsCNTasaCredito()).ListaTasaEval(nPlazoTotalEnDias, idProducto, nMonto, idMoneda, idAgencia, this.objCreditoProp.idSolicitud, this.objCreditoProp.idClasificacionInterna);

            if (dtTasa.Rows.Count > 0)
            {
                errorProvider.SetError(this.cboTipoTasaCredito, String.Empty);
                errorProvider.SetError(this.txtTEA, String.Empty);

                cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;
                cboTipoTasaCredito.DataSource = null;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                cboTipoTasaCredito.DataSource = dtTasa;

                lblClasifInterna.Text = dtTasa.Rows[0]["cClasificacionInterna"].ToString();

                DataRow row = null;
                if (this.objCreditoProp != null && this.objCreditoProp.idTasa > 0)
                {
                    row = dtTasa.AsEnumerable().FirstOrDefault(x => x.Field<int>("idTasa") == this.objCreditoProp.idTasa);
                    if (row == null)
                    {
                        // --seteamos la opción default
                        cboTipoTasaCredito.SelectedIndex = 0;
                        cboTipoTasaCredito_SelectedIndexChanged(this.cboTipoTasaCredito, new EventArgs());
                    }
                    else
                    {
                        // --Recuperamos la opcion anterior
                        cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
                    }
                }

                cboTipoTasaCredito.SelectedIndexChanged += cboTipoTasaCredito_SelectedIndexChanged;
            }
            else
            {
                txtTasCompensatoriaMin.Text = String.Empty;
                txtTasCompensatoriaMax.Text = String.Empty;
                txtTEA.Text = String.Empty;
                txtTasaMora.Text = String.Empty;
                lblClasifInterna.Text = String.Empty;

                if (cboTipoTasaCredito.DataSource != null)
                    ((DataTable)cboTipoTasaCredito.DataSource).Clear();
            }

            if (lDispararEvento)
                DispararEventoChangeCuotaAprox();
        }

        private void AsignarTEA(DataRow row)
        {
            decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
            decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
            decimal nTasaMora = Convert.ToDecimal(row["nTasaMoratoria"]);
            decimal nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);
            decimal nTasaMoratoriaAproba = Convert.ToDecimal(row["nTasaMoratoriaAproba"]);

            idTasa = Convert.ToInt32(row["idTasa"]);
            txtTasCompensatoriaMin.Text = nTasaMin.ToString("#,0.0000");
            txtTasCompensatoriaMax.Text = nTasaMax.ToString("#,0.0000");
            txtTasaMora.Text = nTasaMora.ToString("#,0.0000");

            cargarTasaCampaña();

            if (nTasaMin == nTasaMax && Transaccion == 'I')
            {
                txtTEA.Enabled = false;
                txtTEA.Text = nTasaMax.ToString();
            }
            else
            {
                txtTEA.Enabled = true;
                txtTEA.Text = nTasaMin.ToString();
            }

            if (nTasaNegAprobada > 0)
            {
                txtTEA.Enabled = false;
                txtTEA.Text = nTasaNegAprobada.ToString();
                txtTasaMora.Text = nTasaMoratoriaAproba.ToString();
            }
        }

        private void ActualizarTipoPeriodo()
        {
            if (this.conCreditoPeriodo.idTipoPeriodo == 1)
            {
                //Fecha fija
                this.nudDiasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = false;
                this.nudCuotasGracia.Value = 0;
            }
            else
            {
                //Periodo de Pago
                this.nudCuotasGracia.Enabled = true;
            }
        }
        private void calcularFechaPrimeraCuota()
        {
            if (this.dtFechaDesembolso.Value.Date < clsVarGlobal.dFecSystem)
            {
                this.dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;
                this.dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
            }
            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                conCreditoPrimeraCuota.calcPrimeraCuota(
                    this.conCreditoPeriodo.idTipoPeriodo,
                    this.conCreditoPeriodo.nPeriodoDia,
                    this.dtFechaDesembolso.Value,
                    this.conCreditoPeriodo.idPeriodo,
                    this.objCreditoProp.idSolicitud);

                this.nudDiasGracia.Value = conCreditoPrimeraCuota.nDiasGracia;
                this.conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.nPeriodoDia);

                if (this.conCreditoPrimeraCuota.lDiaAjustado)
                    this.conCreditoPeriodo.actualizarDia(this.conCreditoPrimeraCuota.nDia);
            }
        }
        #endregion

        #region Métodos de validación
        private bool EsMonedaValido()
        {
            if (this.cboMoneda.SelectedIndex < 0) return false;
            return true;
        }

        private bool montoLimiteValido()
        {
            if (this.objCreditoProp.nMonto > decimal.Zero && Convert.ToDecimal(this.txtMonto.Text) > this.objCreditoProp.nMonto)
            {
                return false;
            }
            return true;
        }

        private bool EsMontoValido()
        {
            bool lValido = true;
            if (string.IsNullOrEmpty(this.txtMonto.Text) || Convert.ToDecimal(this.txtMonto.Text) < 100)
                lValido = false;

            return lValido;
        }

        private bool EsCuotasValido()
        {
            if (String.IsNullOrWhiteSpace(this.nudCuotas.Text) || Convert.ToInt32(this.nudCuotas.Text) < 1) return false;
            return true;
        }

        private bool EsTipoPeriodoValido()
        {
            //if (this.cboTipoPeriodo.SelectedIndex < 0) return false;
            //return true;
            return this.conCreditoPeriodo.lTipoPeriodoValido;
        }

        private bool EsPlazoCuotaValido()
        {
            //if (String.IsNullOrWhiteSpace(this.nudPlazoCuota.Text) || Convert.ToInt32(this.nudPlazoCuota.Text) == 0) return false;
            //return true;
            return this.conCreditoPeriodo.lPeriodoDiaValido;
        }

        private bool EsFechaDesembolsoValido()
        {
            bool lValido = true;
            if (dtFechaDesembolso.Value < clsVarGlobal.dFecSystem) lValido = false;

            return lValido;
        }

        private bool EsTipoTasaCreditoValido()
        {
            if (this.cboTipoTasaCredito.SelectedIndex < 0) return false;
            return true;
        }

        private bool EsTEAValido()
        {
            var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;

            if (drvTasa == null) return false;

            DataRow row = drvTasa.Row;

            decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
            decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
            decimal nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);

            decimal nTEA = TEA();

            if (nTEA == 0 || nTEA >= 300) return false;
            if ((nTEA < nTasaMin || nTEA > nTasaMax) && nTasaNegAprobada <= 0) return false;

            return true;
        }

        private bool EsCuotasGraciaValido()
        {
            if (String.IsNullOrWhiteSpace(this.nudCuotasGracia.Text)) return false;

            int nNumCuotas = (EsCuotasValido()) ? this.Cuotas() : 0;
            int nCuotasGracia = this.CuotasGracia();
            if (nCuotasGracia > 0 && nCuotasGracia >= nNumCuotas) return false;
            if (nCuotasGracia >= 12) return false;

            return true;
        }

        private bool EsDiasGraciaValido()
        {
            if (String.IsNullOrWhiteSpace(this.nudDiasGracia.Text)) return false;
            return true;
        }
        /// <summary>
        /// Verifica sobredeuda que tenga el cliente en solicitud de credito
        /// </summary>
        private void GestionSobreDeuda()
        {
            clsCNSobreendeuda cnSobredeuda = new clsCNSobreendeuda();
            dtResultadosSobreDeuda = cnSobredeuda.listaResultSoliciSobredeuda(objCreditoProp.idCli, objCreditoProp.idSolicitud);
            if (dtResultadosSobreDeuda.Rows.Count > 0)
            {
                this.lblAlertSobredeuda.Visible = true;
                this.lblSobreDeuda.Visible = true;
                //this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            }
            else
            {
                this.lblAlertSobredeuda.Visible = false;
                this.lblSobreDeuda.Visible = false;
            }
        }
        #endregion

        #endregion

        #region Eventos
        #region Evento Enter
        private void cboMoneda_Enter(object sender, EventArgs e)
        {
            //this.idMonedaBck = (EsMonedaValido() ? Convert.ToInt32(this.cboMoneda.SelectedValue) : 0);
        }

        private void txtMonto_Enter(object sender, EventArgs e)
        {
            //this.nMontoBck = (EsMontoValido() ? Convert.ToDecimal(this.txtMonto.Text) : 0);
        }

        private void nudCuotas_Enter(object sender, EventArgs e)
        {
            //ObtenerPlazoTotalEnDiasBck();

            int nLonTex = nudCuotas.Value.ToString().Length;
            nudCuotas.Select(0, nLonTex);
        }

        private void nudDiasGracia_Enter(object sender, EventArgs e)
        {
            //ObtenerPlazoTotalEnDiasBck();

            int nLonTex = nudDiasGracia.Value.ToString().Length;
            nudDiasGracia.Select(0, nLonTex);
        }

        private void dtFechaDesembolso_Enter(object sender, EventArgs e)
        {
            //ObtenerPlazoTotalEnDiasBck();
        }

        private void cboTipoPeriodo_Enter(object sender, EventArgs e)
        {
            //ObtenerPlazoTotalEnDiasBck();
        }

        private void nudPeriodosGracia_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudCuotasGracia.Value.ToString().Length;
            nudCuotasGracia.Select(0, nLonTex);
        }
        #endregion

        #region Leave e SelectedIndexChanged, se dispara evento ChangeCuotaAprox y asignarTasa()
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsMonedaValido()) return;

            asignarTasa();

            if (ChangeMoneda != null)
                ChangeMoneda(sender, e);
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (!montoLimiteValido() || !EsMontoValido()) return;

            asignarTasa();

            if (ChangeMonto != null)
                ChangeMonto(sender, e);
        }

        private void nudCuotas_Leave(object sender, EventArgs e)
        {
            if (!EsCuotasValido()) return;

            asignarTasa();      // Por el cálculo del Plazo(Total días)

            if (ChangePlazo != null)
                ChangePlazo(sender, e);
        }

        public void conCreditoPeriodo_ChangeTipoPeriodo(object sender, EventArgs e)
        {
            int nPerDiaReset = 0;
            this.conCreditoPrimeraCuota.resetearFechaSelec(this.dtFechaDesembolso.Value, this.conCreditoPeriodo.idTipoPeriodo, ref nPerDiaReset);
            if (!EsTipoPeriodoValido()) return;

            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija)
            {
                this.nudDiasGracia.Value = 0;
                this.nudCuotas.Enabled = true;
                if ((int)this.nudCuotas.Value == 1)
                    this.nudCuotas.Value = 2;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = false;
            }
            else if (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.CuotasLibres)
            {
                this.nudDiasGracia.Value = 0;
                this.nudCuotas.Enabled = false;

                int PlazoCuotasLibres = 0;

                DataTable dtDisenioCredito = new clsCNEvalCrediRural().SelectDisenioCrediticio(this.idEvalCred);
                this.listDisenioCredito = new List<clsDisenioCredito>();
                this.listDisenioCredito.Clear();
                this.listDisenioCredito = DataTableToList.ConvertTo<clsDisenioCredito>(dtDisenioCredito) as List<clsDisenioCredito>;

                List<decimal> cuotasLibres = new List<decimal>();
                if (this.listDisenioCredito.Count > 0)
                {
                    foreach (var item in this.listDisenioCredito)
                    {
                        if (item.nMontoCuota > 0)
                            cuotasLibres.Add(item.nMontoCuota);
                    }

                }

                PlazoCuotasLibres = cuotasLibres.Count;

                this.nudCuotas.Value = PlazoCuotasLibres;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = false;
            }
            else
            {
                this.nudDiasGracia.Value = 0;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = true;
                this.nudCuotasGracia.Maximum = 80;
            }

            this.conCreditoPeriodo.actualizarDia(nPerDiaReset);
            this.calcularFechaPrimeraCuota();

            asignarTasa();      // Por el cálculo del Plazo(Total días)

            if (ChangePlazo != null)
                ChangePlazo(sender, e);
        }

        private void conCreditoPeriodo_ChangePeriodo(object sender, EventArgs e)
        {

            if (!EsPlazoCuotaValido()) return;
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.lPeriodoDiaValido && this.conCreditoPeriodo.lTipoPeriodoValido)
            {
                this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
                if (this.conCreditoPeriodo.lUnicuota)
                    this.nudCuotas.Enabled = false;
                else
                    this.nudCuotas.Enabled = true;

                this.nudCuotas.ValueChanged -= nudCuotas_ValueChanged;
                this.nudCuotas.Value = this.conCreditoPeriodo.nCuotas;
                this.nudCuotas.ValueChanged -= nudCuotas_ValueChanged;
            }

            asignarTasa();      // Por el cálculo del Plazo(Total días)

            if (ChangePlazo != null)
                ChangePlazo(sender, e);
        }

        private void conCreditoPeriodo_LeaveDia(object sender, EventArgs e)
        {
        }
        private void conCreditoPeriodo_ValueChangedDia(object sender, EventArgs e)
        {
            if (!EsPlazoCuotaValido()) return;
            asignarTasa();      // Por el cálculo del Plazo(Total días)

            if (ChangePlazo != null)
                ChangePlazo(sender, e);

            if (ValueChangedDia != null)
                ValueChangedDia(sender, e);
        }

        private void conCreditoPrimeraCuota_ValueChangedFecha(object sender, EventArgs e)
        {
            if (conCreditoPrimeraCuota.dFecha == null)
                return;

            this.calcularFechaPrimeraCuota();
            this.DispararEventoChangeCuotaAprox();
        }

        private void nudPeriodosGracia_Leave(object sender, EventArgs e)
        {
            if (!EsCuotasGraciaValido()) return;

            DispararEventoChangeCuotaAprox();
        }

        private void dtFechaDesembolso_Leave(object sender, EventArgs e)
        {
            if (!EsFechaDesembolsoValido()) return;

            asignarTasa();      // Por el cálculo del Plazo(Total días)
        }

        private void nudDiasGracia_Leave(object sender, EventArgs e)
        {
            if (!EsDiasGraciaValido()) return;

            asignarTasa();      // Por el cálculo del Plazo(Total días)
        }

        private void txtTEA_Leave(object sender, EventArgs e)
        {
            if (!EsTEAValido()) return;

            this.txtTEM.Text = clsMathFinanciera.TEM(Convert.ToDouble(this.txtTEA.Text)).ToString("n4");

            DispararEventoChangeCuotaAprox();
        }

        private void txtTEA_TextChanged(object sender, EventArgs e)
        {
            decimal nTEA = TEA();
            this.txtTEM.Text = clsMathFinanciera.TEM(Convert.ToDouble(nTEA)).ToString("n4");
        }

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsTipoTasaCreditoValido()) return;

            errorProvider.SetError(this.txtTEA, String.Empty);

            var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;
            DataRow row = drvTasa.Row;

            AsignarTEA(row);
            DispararEventoChangeCuotaAprox();
        }

        private void conNivelesProducto_ChangeProducto(object sender, EventArgs e)
        {
            this.idProducto = conNivelesProducto.idSubproducto();

            if (objCreditoProp == null || this.idProducto < 0) return;

            asignarTasa();
        }
        #endregion

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (objCreditoProp == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                asignarTasa();

                if (ChangeMonto != null)
                    ChangeMonto(sender, e);

                if (ChangeCuotaAprox != null)
                    ChangeCuotaAprox(sender, e);

                e.Handled = true;
            }*/
        }
        #region Validating
        private void dtFechaDesembolso_Validating(object sender, CancelEventArgs e)
        {
            if (!EsFechaDesembolsoValido())
                errorProvider.SetError(this.dtFechaDesembolso, "La Fecha de Desembolso no puede ser menor a la del sistema.");
            else
                errorProvider.SetError(this.dtFechaDesembolso, String.Empty);
        }

        private void nudCuotas_Validating(object sender, CancelEventArgs e)
        {
            if (!EsCuotasValido())
                errorProvider.SetError(this.nudCuotas, "Número de cuotas debe ser mayor a CERO");
            else
                errorProvider.SetError(this.nudCuotas, String.Empty);
        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            if (!EsMontoValido())
            {
                errorProvider.SetError(this.txtMonto, "El Monto debe ser mayor a CERO.");
            }
            else if (!montoLimiteValido())
            {
                errorProvider.SetError(this.txtMonto, string.Concat("El Monto no debe ser mayor a ", this.objCreditoProp.nMonto));
            }
            else
                errorProvider.SetError(this.txtMonto, String.Empty);
        }

        private void txtTEA_Validating(object sender, CancelEventArgs e)
        {
            var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;

            if (drvTasa != null)
            {
                DataRow row = drvTasa.Row;

                decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
                decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
                decimal nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);

                decimal nTEA = TEA();

                if (nTEA == 0 || nTEA >= 300)
                {
                    errorProvider.SetError(this.txtTEA, "Ingrese un TEA válido.");
                }
                else if ((nTEA < nTasaMin || nTEA > nTasaMax) && nTasaNegAprobada <= 0)
                {
                    errorProvider.SetError(this.txtTEA, "Ingrese un TEA dentro de los rangos.");
                }
                else
                {
                    errorProvider.SetError(this.txtTEA, String.Empty);
                }
            }
            else
            {
                errorProvider.SetError(this.txtTEA, "Ingrese un TEA válido.");
            }
        }

        private void cboTipoTasaCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsTipoTasaCreditoValido())
                errorProvider.SetError(this.cboTipoTasaCredito, "Seleccione una opción");
            else
                errorProvider.SetError(this.cboTipoTasaCredito, String.Empty);
        }

        private void nudPeriodosGracia_Validating(object sender, CancelEventArgs e)
        {
            if (!EsCuotasGraciaValido())
            {
                int nNumCuotas = (EsCuotasValido()) ? this.Cuotas() : 0;
                int nCuotasGracia = this.CuotasGracia();

                if (String.IsNullOrWhiteSpace(this.nudCuotasGracia.Text))
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Ingrese un valor numérico válido.");
                }
                else if (nCuotasGracia > 0 && nCuotasGracia >= nNumCuotas)
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Cuotas Gracia es mayor a Num. Cuotas.");
                }
                else if (nCuotasGracia >= 12)
                {
                    errorProvider.SetError(this.nudCuotasGracia, "Cuotas Gracia es mayor a 12 cuotas.");
                }
            }
            else
                errorProvider.SetError(this.nudCuotasGracia, String.Empty);
        }

        private void cboMoneda_Validating(object sender, CancelEventArgs e)
        {
            if (!EsMonedaValido())
                errorProvider.SetError(this.cboMoneda, "Seleccione una opción");
            else
                errorProvider.SetError(this.cboMoneda, String.Empty);
        }

        private void nudDiasGracia_Validating(object sender, CancelEventArgs e)
        {
            if (!EsDiasGraciaValido())
                errorProvider.SetError(this.nudDiasGracia, "Ingrese dias de gracia");
            else
                errorProvider.SetError(this.nudDiasGracia, String.Empty);
        }
        #endregion

        private void pbxTasaAprob_Click(object sender, EventArgs e)
        {
            frmTasasAprobadas frmTasasAprobadas = new frmTasasAprobadas(this.listaTasasNegociables);
            frmTasasAprobadas.ShowDialog();
        }
        #endregion

        private void lblSobreDeuda_Click(object sender, EventArgs e)
        {
            frmEvaluaSobreendeuda frmSobreDeuda = new frmEvaluaSobreendeuda(objCreditoProp.idCli);
            frmSobreDeuda.cargarEvaluacion(dtResultadosSobreDeuda);
            frmSobreDeuda.ShowDialog();
        }

        private void lblSobreDeuda_MouseHover(object sender, EventArgs e)
        {
            this.lblSobreDeuda.BorderStyle = BorderStyle.FixedSingle;
        }

        private void lblSobreDeuda_MouseLeave(object sender, EventArgs e)
        {
            this.lblSobreDeuda.BorderStyle = BorderStyle.None;
            //Cursor.Current = Cursors.Default;
        }

        private void cargarTasaCampaña()
        {
            //=================================================================================
            // Se esta obteniendo si el cliente tiene registrado una campaña para el producto seleccionado
            //=================================================================================
            DataTable dtRes = new clsCNBuscarCli().CNValidarClienteCreditoTasaCamp(this.objCreditoProp.idCli, this.objCreditoProp.idProducto, objCreditoProp.idOperacion);
            if (dtRes.Rows.Count > 0)
            {
                if (objCreditoProp.idOperacion.In(2))// incluir el reprogramación
                {
                }
                else
                {
                    txtTEA.Text = Convert.ToDecimal(dtRes.Rows[0]["nTasa"]).ToString("0.0000");
                    nTasaCampana = Convert.ToDecimal(dtRes.Rows[0]["nTasa"]);
                    //txtTasaCompensatoria.Enabled = false;
                }
            }
            //=================================================================================
            // Fin
            //=================================================================================
        }

        private bool validaTasaCampana()
        {
            bool lRes = true;

            if (nTasaCampana == 0)
            {
                return lRes;
            }
            else if (nTasaCampana > Convert.ToDecimal(txtTEA.Text))
            {
                this.cMensajeTasaCampaña = "El TEA no puede ser menor a su tasa pre aprobada que es: " + nTasaCampana;
                return false;
            }
            else
            {
                return lRes;
            }

        }

        private void nudCuotas_ValueChanged(object sender, EventArgs e)
        {
            this.conCreditoPeriodo.actualizarCuotas((int)nudCuotas.Value);
        }

        private void dtFechaDesembolso_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtFechaDesembolso.Value < clsVarGlobal.dFecSystem)
            {
                this.dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;
                this.dtFechaDesembolso.MinDate = clsVarGlobal.dFecSystem;
                this.dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
                return;
            }

            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                if (this.conCreditoPeriodo.idTipoPeriodo == (int)EntityLayer.TipoPeriodo.PeriodoFijo
                    && !this.conCreditoPeriodo.lUnicuota
                    && this.objCreditoProp.idOperacion != (int)OperacionCredito.ReprogramacionCambioFecha)
                    this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
            }
            else
            {
                this.conCreditoPrimeraCuota.inicializarFecha(this.dtFechaDesembolso.Value);
            }
        }

        private void ConCreditoTasa_Load(object sender, EventArgs e)
        {

        }
    }
}
