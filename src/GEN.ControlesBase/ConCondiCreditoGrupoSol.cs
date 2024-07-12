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
using GEN.CapaNegocio;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConCondiCreditoGrupoSol : UserControl
    {
        private clsCreditoProp objCreditoProp = new clsCreditoProp();
        public event EventHandler ChangeCondiCredito;
        public event EventHandler ChangeProducto;

        private int idTasaValida;
        public int idTipoGrupoSolidario = 0;

        public ConCondiCreditoGrupoSol()
        {
            InitializeComponent();
        }

        #region Métodos
        #region Métodos públicos
        public void AsignarDatos(clsCreditoProp _objCreditoProp)
        {
            this.objCreditoProp = _objCreditoProp;

            this.cboMoneda.SelectedIndexChanged -= new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.txtNroCuotas.Leave -= new System.EventHandler(this.txtNroCuotas_Leave);
            this.cboTipoPeriodo.SelectedIndexChanged -= new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged);
            this.nudPlazoCuota.Leave -= new System.EventHandler(this.nudPlazoCuota_Leave);
            this.nudDiasGracia.Leave -= new System.EventHandler(this.nudDiasGracia_Leave);
            this.txtCuotasGracia.Leave -= new System.EventHandler(this.txtCuotasGracia_Leave);
            this.conNivelesProducto.ChangeProducto -= new System.EventHandler(this.conNivelesProducto_ChangeProducto);
            this.cboTipoTasaCredito.SelectedIndexChanged -= new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            this.dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;

            this.idTasaValida = this.objCreditoProp.idTasa;
            this.cboMoneda.SelectedValue = this.objCreditoProp.idMoneda;
            this.txtNroCuotas.Text = this.objCreditoProp.nCuotas.ToString();
            this.cboTipoPeriodo.SelectedValue = this.objCreditoProp.idTipoPeriodo;

            // ----------------------------------------------------------------------
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                //Fecha fija
                this.lblBase19.Text = "Día de Pago";
                this.lblBase1.Text = "cada/mes";
                //this.nudPlazoCuota.Enabled = false;
                this.nudPlazoCuota.Minimum = 1;
                this.nudPlazoCuota.Maximum = 31;
                this.nudPlazoCuota.Text = this.objCreditoProp.dFechaDesembolso.Day.ToString();
                this.txtCuotasGracia.Enabled = false;
            }
            else
            {
                //Periodo de Pago
                this.lblBase19.Text = "Frecuencia";
                this.lblBase1.Text = "días";
                //this.nudPlazoCuota.Enabled = true;
                this.nudPlazoCuota.Minimum = 30;
                this.nudPlazoCuota.Maximum = 365;
                this.nudPlazoCuota.Text = "30";
                this.txtCuotasGracia.Enabled = true;
            }
            // ----------------------------------------------------------------------

            this.nudPlazoCuota.Text = this.objCreditoProp.nPlazoCuota.ToString();
            this.nudDiasGracia.Text = this.objCreditoProp.nDiasGracia.ToString();
            this.txtCuotasGracia.Text = this.objCreditoProp.nCuotasGracia.ToString();
            this.dtFechaDesembolso.Value = this.objCreditoProp.dFechaDesembolso;

            if (this.objCreditoProp.idProducto != 0)
                this.conNivelesProducto.cargarProductos(1, this.objCreditoProp.idProducto);

            // ----------------------------------------------------------------------
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                //Fecha fija
                DateTime dFecha = this.dtFechaDesembolso.Value.AddMonths(1);
                //this.dtFechaPrimeraCuota.Value = new DateTime(dFecha.Year, dFecha.Month, PlazoCuota()).AddDays(DiasGracia());
                this.dtFechaPrimeraCuota.Value = new DateTime(dFecha.Year, dFecha.Month, 1).AddDays(PlazoCuota() + DiasGracia() - 1);
                //this.dtFechaPrimeraCuota.Value = new DateTime(dFecha.Year, dFecha.Month, 1).AddDays(0);
            }
            else
            {
                //Periodo de Pago
                this.dtFechaPrimeraCuota.Value = this.dtFechaDesembolso.Value.AddDays(PlazoCuota() + DiasGracia());
            }
            // ----------------------------------------------------------------------  

            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            this.txtNroCuotas.Leave += new System.EventHandler(this.txtNroCuotas_Leave);
            this.cboTipoPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged);
            this.nudPlazoCuota.Leave += new System.EventHandler(this.nudPlazoCuota_Leave);
            this.nudDiasGracia.Leave += new System.EventHandler(this.nudDiasGracia_Leave);
            this.txtCuotasGracia.Leave += new System.EventHandler(this.txtCuotasGracia_Leave);
            this.conNivelesProducto.ChangeProducto += new System.EventHandler(this.conNivelesProducto_ChangeProducto);
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            this.dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;

            this.cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
            
        }

        public bool MonedaEnabled
        {
            get { return this.cboMoneda.Enabled; }
            set { this.cboMoneda.Enabled = value; }
        }

        public bool NivelesProductoEnabled
        {
            get { return this.conNivelesProducto.Enabled; }
            set { this.conNivelesProducto.Enabled = value; }
        }

        public bool PeriodoEnabled
        {
            get { return this.cboTipoPeriodo.Enabled; }
            set { this.cboTipoPeriodo.Enabled = value; }
        }
        /// <summary>
        /// Retorna el numero de cuotas del crédito
        /// </summary>
        /// <returns></returns>
        public int NroCuotas()
        {
            return String.IsNullOrWhiteSpace(this.txtNroCuotas.Text) ? 0 : Convert.ToInt32(this.txtNroCuotas.Text);
        }

        /// <summary>
        /// Retorna el tipo de Periodo: Fecha Fija o Periodo Fijo
        /// </summary>
        /// <returns></returns>
        public int TipoPeriodo()
        {
            return Convert.ToInt32(this.cboTipoPeriodo.SelectedValue);
        }

        /// <summary>
        /// Retorna el PlazoCuota del crédito en número de días
        /// </summary>
        /// <returns></returns>
        public int PlazoCuota()
        {
            return String.IsNullOrWhiteSpace(this.nudPlazoCuota.Text) ? 0 : Convert.ToInt32(this.nudPlazoCuota.Text);
        }

        /// <summary>
        /// Retorna los días de gracia
        /// </summary>
        /// <returns></returns>
        public int DiasGracia()
        {
            return String.IsNullOrWhiteSpace(this.nudDiasGracia.Text) ? 0 : Convert.ToInt32(this.nudDiasGracia.Text);
        }

        /// <summary>
        /// Retorna las cuotas de gracia del crédito
        /// </summary>
        /// <returns></returns>
        public int CuotasGracia()
        {
            return String.IsNullOrWhiteSpace(this.txtCuotasGracia.Text) ? 0 : Convert.ToInt32(this.txtCuotasGracia.Text);
        }

        /// <summary>
        /// Retorna el tipo de tasa
        /// </summary>
        /// <returns>INT 32</returns>
        public int TipoTasa()
        {
            return (this.cboTipoTasaCredito.SelectedIndex < 0) ? 0 : Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
        }

        /// <summary>
        /// Retorna el Plazo del crédito
        /// </summary>
        /// <returns></returns>
        public int Plazo()
        {
            int nCuotas = NroCuotas();
            int nTipoPeriodo = TipoPeriodo();
            int nPlazoCuota = PlazoCuota();

            return (nTipoPeriodo == 1) ? nCuotas : (int)Math.Round(((nCuotas * nPlazoCuota) / 30.000), 0);
        }

        /// <summary>
        /// Retorna el total del monto a pagar
        /// </summary>
        /// <returns>Decimal</returns>
        public decimal TotalMontoPagar()
        {
            if (this.objCreditoProp.dtCalendarioPagos != null && this.objCreditoProp.dtCalendarioPagos.Rows.Count > 0)
                return Convert.ToDecimal(this.objCreditoProp.dtCalendarioPagos.Compute("Sum(imp_cuota)", ""));

            return 0;
        }

        /// <summary>
        /// Retorna la tasa de costo efectivo anual - TEA
        /// </summary>
        /// <returns>decimal</returns>
        public decimal TEA()
        {
            return String.IsNullOrWhiteSpace(this.txtTEA.Text) ? 0 : Convert.ToDecimal(this.txtTEA.Text);
        }

        /// <summary>
        /// Retorna la tasa de costo efectivo anual - TEM
        /// </summary>
        /// <returns>decimal</returns>
        public decimal TEM()
        {
            return String.IsNullOrWhiteSpace(this.txtTasaMora.Text) ? 0 : Convert.ToDecimal(this.txtTasaMora.Text);
        }

        public clsMsjError Validar()
        {
            var objMsjError = new clsMsjError();

            if (this.cboMoneda.SelectedIndex < 0)
            {
                objMsjError.AddError("Cond. cred.: Seleccione una moneda");
            }

            if (Convert.ToInt32(this.txtNroCuotas.Text) == 0)
            {
                objMsjError.AddError("Cond. cred.: El número de Cuotas debe ser mayor que 0");
            }

            if (this.cboTipoPeriodo.SelectedIndex < 0)
            {
                objMsjError.AddError("Cond. cred.: Seleccione el periodo");
            }

            if (this.nudPlazoCuota.Value < 0)
            {
                objMsjError.AddError("Cond. cred.: Seleccione el " + this.lblBase19.Text +" debe ser mayo a 0");
            }

            if (this.dtFechaDesembolso.Value < clsVarGlobal.dFecSystem)
            {
                objMsjError.AddError("Cond. cred.: La fecha de desembolso no puede ser menor a la fecha del sistema");
            }

            string cProductosGrupoSolidarios = clsVarApl.dicVarGen["cProductosGrupoSolidarioFiltro"];
            String[] cProdGrupSol = cProductosGrupoSolidarios.Split(',');
            int[] nProdGrupSol = Array.ConvertAll<string, int>(cProdGrupSol, int.Parse);

            if (!this.conNivelesProducto.idSubproducto().In(nProdGrupSol))
            {
                objMsjError.AddError("Cond. Cred.: El producto seleccionado no es para los grupos solidarios.");
            }
            
            objMsjError.addList(this.conNivelesProducto.Validar());

            DataTable dtRes = new CRE.CapaNegocio.clsCNGrupoSolidario().CNValidaProductoTipoGrupoSolidario(idTipoGrupoSolidario, this.conNivelesProducto.idSubproducto());
            if (!Convert.ToBoolean(dtRes.Rows[0]["nRes"]))
            {
                objMsjError.AddError(dtRes.Rows[0]["cMsg"].ToString());
            }
            
            return objMsjError;
        }

        public clsCreditoProp ObtenerCreditoPropuesto()
        {
            this.objCreditoProp.idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
            //this.objCreditoProp.nMonto = Monto();
            this.objCreditoProp.nMonto = 0;
            this.objCreditoProp.nCuotas = NroCuotas();
            this.objCreditoProp.idTipoPeriodo = TipoPeriodo();
            this.objCreditoProp.nPlazoCuota = PlazoCuota();
            this.objCreditoProp.nPlazo = Plazo();
            this.objCreditoProp.nCuotasGracia = CuotasGracia();
            this.objCreditoProp.nDiasGracia = DiasGracia();
            this.objCreditoProp.dFechaDesembolso = this.dtFechaDesembolso.Value;
            this.objCreditoProp.nTasaCompensatoria = TEA();
            //this.objCreditoProp.idTipo = Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
            this.objCreditoProp.dFechaPrimeraCuota = dtFechaPrimeraCuota.Value;
            this.objCreditoProp.idTasa = TipoTasa();
            this.objCreditoProp.idProducto = this.conNivelesProducto.idSubproducto();
            //this.objCreditoProp.nTIM = Convert.ToDecimal(txtTasaMora.Text);
            return this.objCreditoProp;
        }

        public void LimpiarControl()
        {
            this.conNivelesProducto.limpiar();

            clsCreditoProp oCreditoProp = new clsCreditoProp();
            oCreditoProp.idTipoPeriodo = 1;
            oCreditoProp.idAgencia = clsVarGlobal.nIdAgencia;
            oCreditoProp.dFechaDesembolso = clsVarGlobal.dFecSystem;
            //oCreditoProp.nMonto = 5000;
            //oCreditoProp.nTasaCompensatoria = 40;
            //oCreditoProp.nMontoMinimo = 0;
            //oCreditoProp.nMontoMaximo = 5000;
            //oCreditoProp.nPlazoTotalDias = 360;
            idTipoGrupoSolidario = 0;
            AsignarDatos(oCreditoProp);

            this.objCreditoProp = oCreditoProp;

            errorProvider.SetError(this.dtFechaDesembolso, String.Empty);
            errorProvider.SetError(this.nudPlazoCuota, String.Empty);
            errorProvider.SetError(this.txtTEA, String.Empty);

            errorProvider.SetError(this.cboTipoTasaCredito, String.Empty);
            errorProvider.SetError(this.cboMoneda, String.Empty);
            errorProvider.SetError(this.cboTipoPeriodo, String.Empty);
            errorProvider.SetError(this.nudDiasGracia, String.Empty);
        }

        /*public void CalcularPlazoTotalDias()
        {
            this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();
        }*/

        public void ActualizarTasaCredito()
        {
            this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();

            DataTable dtTasa = (new clsCNTasaCredito()).ListaTasaEvalGrupoSol(
                                    this.objCreditoProp.nPlazoTotalDias,
                                    this.objCreditoProp.idSubProducto,
                                    this.objCreditoProp.nMontoMinimo,
                                    this.objCreditoProp.nMontoMaximo,
                                    this.objCreditoProp.idMoneda,
                                    this.objCreditoProp.idAgencia,
                                    this.objCreditoProp.idSolicitud,0);

            if (dtTasa.Rows.Count > 0)
            {
                cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;

                cboTipoTasaCredito.DataSource = null;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                cboTipoTasaCredito.DataSource = dtTasa;

                cboTipoTasaCredito.SelectedIndex = -1;

                if (this.objCreditoProp != null && this.objCreditoProp.idTasa > 0)
                {
                    DataRow row = dtTasa.AsEnumerable().FirstOrDefault(x => x.Field<int>("idTasa") == this.objCreditoProp.idTasa);
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
                        AsignarTEA(row);
                    }
                }

                cboTipoTasaCredito.SelectedIndexChanged += cboTipoTasaCredito_SelectedIndexChanged;

                CalcularCuotaAprox();
            }
            else
            {
                this.objCreditoProp.idTasa = 0;
                txtTasCompensatoriaMin.Text = String.Empty;
                txtTasCompensatoriaMax.Text = String.Empty;
                txtTEA.Text = "0";
                txtTasaMora.Text = "0";

                if (cboTipoTasaCredito.DataSource != null)
                    ((DataTable)cboTipoTasaCredito.DataSource).Clear();

                this.objCreditoProp.nCuotaAprox = 0;
                this.objCreditoProp.nCuotaGraciaAprox = 0;
                this.objCreditoProp.dtCalendarioPagos = new DataTable();

                this.txtCuotaAprox.Text = this.objCreditoProp.nCuotaAprox.ToString("n2");
                this.txtCuotaGraciaAprox.Text = this.objCreditoProp.nCuotaGraciaAprox.ToString("n2");
            }

            if (ChangeCondiCredito != null)
                ChangeCondiCredito(null, null);
        }

        public void bloquearMoneda(bool lEstado)
        {
            cboMoneda.Enabled = lEstado;
        }
        public void bloquearNivelesProducto(bool lEstado)
        {
            conNivelesProducto.Enabled = lEstado;
        }
        public void bloquearDestinoCredito(bool lEstado)
        {
            cboDestinoCredito.Enabled = lEstado;
        }
        public void bloquearTasaCredito(bool lEstado)
        {
            cboTipoTasaCredito.Enabled = lEstado;
            txtTasCompensatoriaMin.Enabled = lEstado;
            txtTasCompensatoriaMax.Enabled = lEstado;
            txtTEA.Enabled = lEstado;
            txtCuotaAprox.Enabled = lEstado;
            txtCuotaGraciaAprox.Enabled = lEstado;
            txtTasaMora.Enabled = lEstado;
        }

        public DateTime dFechaPrimeraCuota() 
        {
            return dtFechaPrimeraCuota.Value;
        }

        public void cargarProductoSol(int idProducto)
        {
            conNivelesProducto.cargarProductosVariable(1, idProducto);
        }

        #endregion

        #region Métodos Privados
        private bool EsValidoComponente(object sender)
        {
            Control objCtrl = sender as Control;

            if (objCtrl.Name.Equals("cboMoneda"))
            {
                if (this.cboMoneda.SelectedIndex < 0)
                {
                    errorProvider.SetError(this.cboMoneda, "Seleccione una opción.");

                    //MessageBox.Show("Seleccione la Moneda");
                    return false;
                }
                else
                    errorProvider.SetError(this.cboMoneda, String.Empty);
            }

            if (objCtrl.Name.Equals("txtNroCuotas"))
            {
                if (String.IsNullOrWhiteSpace(this.txtNroCuotas.Text) || Convert.ToInt32(this.txtNroCuotas.Text) < 1)
                {
                    //MessageBox.Show("Ingrese un valor distitno a cero");
                    errorProvider.SetError(this.txtNroCuotas, "El número de cuotas debe ser mayor a CERO");
                    return false;
                }
                else
                    errorProvider.SetError(this.txtNroCuotas, String.Empty);
            }

            if (objCtrl.Name.Equals("nudPlazoCuota"))
            {
                if (String.IsNullOrWhiteSpace(this.nudPlazoCuota.Text) || Convert.ToInt32(this.nudPlazoCuota.Text) < 1)
                {
                    //MessageBox.Show("Ingrese un valor distitno a cero");
                    errorProvider.SetError(this.nudPlazoCuota, "El plazo debe ser mayor a CERO");
                    return false;
                }
                else
                    errorProvider.SetError(this.nudPlazoCuota, String.Empty);
            }

            if (objCtrl.Name.Equals("txtDiasGracia"))
            {
                if (String.IsNullOrWhiteSpace(this.nudDiasGracia.Text) || Convert.ToInt32(this.nudDiasGracia.Text) < 0)
                {
                    //MessageBox.Show("Ingrese un valor distitno a cero");
                    return false;
                }

            }

            if (objCtrl.Name.Equals("txtCuotasGracia"))
            {
                int nCuotasGracia = CuotasGracia();
                int nNroCuotas = NroCuotas();

                if (nCuotasGracia > 0 && nCuotasGracia >= nNroCuotas)
                {
                    errorProvider.SetError(this.txtCuotasGracia, "Las Cuotas Gracia deben ser menor a Nro. Cuotas.");
                    return false;
                }
                else if (nCuotasGracia >= 12)
                {
                    errorProvider.SetError(this.txtCuotasGracia, "Las Cuotas Gracia deben ser menor que 12.");
                    return false;
                }
                else
                {
                    errorProvider.SetError(this.txtCuotasGracia, String.Empty);
                }
            }

            return true;
        }

        public clsCreditoProp ObtenerCondicionesCreditoGrupoSol(decimal _nMonto)
        {
            this.objCreditoProp.idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
            this.objCreditoProp.nMonto = _nMonto;
            this.objCreditoProp.nCuotas = NroCuotas();
            this.objCreditoProp.idTipoPeriodo = TipoPeriodo();
            this.objCreditoProp.nPlazoCuota = PlazoCuota();
            this.objCreditoProp.nPlazo = Plazo();
            this.objCreditoProp.nCuotasGracia = CuotasGracia();
            this.objCreditoProp.nDiasGracia = DiasGracia();
            this.objCreditoProp.dFechaDesembolso = this.dtFechaDesembolso.Value;
            //this.objCreditoProp.nTasaCompensatoria = TEA();
            //this.objCreditoProp.idTasa = TipoTasa();
            this.objCreditoProp.idProducto = this.conNivelesProducto.idSubproducto();
            this.objCreditoProp.nCuotaAprox = 0;
            this.objCreditoProp.nCuotaGraciaAprox = 0;
            this.objCreditoProp.dFechaPrimeraCuota = dtFechaPrimeraCuota.Value;

            if (this.objCreditoProp.nMonto <= 0 || this.objCreditoProp.nCuotas <= 0 || this.objCreditoProp.nTasaCompensatoria <= 0)
                return this.objCreditoProp;

            DataTable dtCalendarioPagos = new DataTable();
            DataTable dtEmpty = new DataTable();
            decimal nCuotaConstante = 0;
            decimal nCuotaGraciaAprox = 0;

            dtCalendarioPagos = (new clsCNPlanPago()).CalculaPpgCuotasConstantes(
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    0,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.dtFechaPrimeraCuota.Value);

            if (CuotasGracia() > 0)
            {
                dtCalendarioPagos = (new clsCNPlanPago()).CalcularCuotasGracia(
                                    dtCalendarioPagos,
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(this.objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.dtFechaPrimeraCuota.Value,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nCuotasGracia);

                if (dtCalendarioPagos.Rows.Count > 0)
                {
                    var listCuotaConst = (from p in dtCalendarioPagos.AsEnumerable()
                                          where p.Field<decimal>("capital") > 0
                                          select new
                                          {
                                              nCapital = p.Field<decimal>("capital"),
                                              nInteres = p.Field<decimal>("interes"),
                                              nCuota = p.Field<decimal>("imp_cuota")
                                          }).ToList();

                    var listaCuotaPGracia = (from p in dtCalendarioPagos.AsEnumerable()
                                             where p.Field<decimal>("capital") == 0
                                             select new
                                             {
                                                 nCapital = p.Field<decimal>("capital"),
                                                 nInteres = p.Field<decimal>("interes"),
                                                 nCuota = p.Field<decimal>("imp_cuota")
                                             }).ToList();

                    nCuotaConstante = (listCuotaConst.Count > 0) ? listCuotaConst[0].nCuota : 0;
                    nCuotaGraciaAprox = (listaCuotaPGracia.Count > 0) ? listaCuotaPGracia[0].nCuota : 0;
                }
            }
            else
            {
                nCuotaConstante = (dtCalendarioPagos.Rows.Count > 0) ? Convert.ToDecimal(dtCalendarioPagos.Rows[0]["imp_cuota"]) : 0;
                nCuotaGraciaAprox = 0;
            }

            this.txtCuotaAprox.Text = nCuotaConstante.ToString("n2");
            this.txtCuotaGraciaAprox.Text = nCuotaGraciaAprox.ToString("n2");

            this.objCreditoProp.nCuotaAprox = nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = dtCalendarioPagos;
            this.objCreditoProp.nTIM = Convert.ToDecimal(txtTasaMora.Text);
            return this.objCreditoProp;
        }

        private void CalcularCuotaAprox()
        {
            DataTable dtCalendarioPagos = new DataTable();
            DataTable dtEmpty = new DataTable();
            decimal nCuotaConstante = 0;
            decimal nCuotaGraciaAprox = 0;

            dtCalendarioPagos = (new clsCNPlanPago()).CalculaPpgCuotasConstantes(
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    0,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.dtFechaPrimeraCuota.Value);

            if (CuotasGracia() > 0)
            {
                dtCalendarioPagos = (new clsCNPlanPago()).CalcularCuotasGracia(
                                    dtCalendarioPagos,
                                    this.objCreditoProp.nMonto,
                                    this.objCreditoProp.nTea / 100.00m,
                                    this.objCreditoProp.dFechaDesembolso,
                                    this.objCreditoProp.nDiasGracia,
                                    Convert.ToInt16(this.objCreditoProp.idTipoPeriodo),
                                    this.objCreditoProp.nPlazoCuota,
                                    dtEmpty,
                                    this.objCreditoProp.idMoneda,
                                    dtEmpty,
                                    this.dtFechaPrimeraCuota.Value,
                                    this.objCreditoProp.nCuotas,
                                    this.objCreditoProp.nCuotasGracia);

                if (dtCalendarioPagos.Rows.Count > 0)
                {
                    var listCuotaConst = (from p in dtCalendarioPagos.AsEnumerable()
                                          where p.Field<decimal>("capital") > 0
                                          select new
                                          {
                                              nCapital = p.Field<decimal>("capital"),
                                              nInteres = p.Field<decimal>("interes"),
                                              nCuota = p.Field<decimal>("imp_cuota")
                                          }).ToList();

                    var listaCuotaPGracia = (from p in dtCalendarioPagos.AsEnumerable()
                                             where p.Field<decimal>("capital") == 0
                                             select new
                                             {
                                                 nCapital = p.Field<decimal>("capital"),
                                                 nInteres = p.Field<decimal>("interes"),
                                                 nCuota = p.Field<decimal>("imp_cuota")
                                             }).ToList();

                    nCuotaConstante = (listCuotaConst.Count > 0) ? listCuotaConst[0].nCuota : 0;
                    nCuotaGraciaAprox = (listaCuotaPGracia.Count > 0) ? listaCuotaPGracia[0].nCuota : 0;
                }
            }
            else
            {
                nCuotaConstante = (dtCalendarioPagos.Rows.Count > 0) ? Convert.ToDecimal(dtCalendarioPagos.Rows[0]["imp_cuota"]) : 0;
                nCuotaGraciaAprox = 0;
            }

            this.txtCuotaAprox.Text = nCuotaConstante.ToString("n2");
            this.txtCuotaGraciaAprox.Text = nCuotaGraciaAprox.ToString("n2");

            this.objCreditoProp.nCuotaAprox = nCuotaConstante;
            this.objCreditoProp.nCuotaGraciaAprox = nCuotaGraciaAprox;
            this.objCreditoProp.dtCalendarioPagos = dtCalendarioPagos;
        }

        private int ObtenerPlazoTotalDias()
        {
            int nPlazoTotalDias = ((new clsCNSolicitud()).ObtieneTotalDias(
                                            this.dtFechaDesembolso.Value,
                                            NroCuotas(),
                                            DiasGracia(),
                                            TipoPeriodo(),
                                            PlazoCuota()));

            return nPlazoTotalDias;
        }

        private void AsignarTEA(DataRow row)
        {
            decimal nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
            decimal nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
            decimal nTasaMora = Convert.ToDecimal(row["nTasaMoratoria"]);
            decimal nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);
            decimal nTasaMoratoriaAproba = Convert.ToDecimal(row["nTasaMoratoriaAproba"]);

            //int idTasa = Convert.ToInt32(row["idTasa"]);
            txtTasCompensatoriaMin.Text = nTasaMin.ToString("#,0.0000");
            txtTasCompensatoriaMax.Text = nTasaMax.ToString("#,0.0000");
            txtTasaMora.Text = nTasaMora.ToString("#,0.0000");

            if (nTasaMin == nTasaMax)
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
        #endregion
        #endregion

        #region Eventos
        private void txtNroCuotas_Leave(object sender, EventArgs e)
        {
            if (!EsValidoComponente(sender)) return;

            int nValor = Convert.ToInt32(this.txtNroCuotas.Text);
            if (nValor != this.objCreditoProp.nCuotas)
            {
                this.objCreditoProp.nCuotas = nValor;
                //this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();
                //ActualizarTasaCredito();
                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);
            }
        }

        private void nudPlazoCuota_Leave(object sender, EventArgs e)
        {
            if (ChangeCondiCredito != null)
                ChangeCondiCredito(null, null);
        }

        private void nudDiasGracia_Leave(object sender, EventArgs e)
        {
            if (!EsValidoComponente(sender)) return;

            int nValor = DiasGracia();
            if (nValor != this.objCreditoProp.nDiasGracia)
            {
                // ----------------------------------------------------------------------
                if (this.cboTipoPeriodo.SelectedIndex == 0)
                {
                    //Fecha fija
                    DateTime dFecha = this.dtFechaDesembolso.Value.AddMonths(1);
                    this.dtFechaPrimeraCuota.Value = new DateTime(dFecha.Year, dFecha.Month, 1).AddDays(PlazoCuota() + DiasGracia() - 1);
                }
                else
                {
                    //Periodo de Pago
                    this.dtFechaPrimeraCuota.Value = this.dtFechaDesembolso.Value.AddDays(PlazoCuota() + DiasGracia());
                }
                // ----------------------------------------------------------------------                

                this.objCreditoProp.nDiasGracia = nValor;
                //this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();
                
                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);
            }
        }

        private void txtCuotasGracia_Leave(object sender, EventArgs e)
        {
            if (!EsValidoComponente(sender)) return;

            int nValor = CuotasGracia();
            if (nValor != this.objCreditoProp.nCuotasGracia)
            {
                this.objCreditoProp.nCuotasGracia = nValor;
                //this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();
                
                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!EsValidoComponente(sender)) return;

            int nValor = Convert.ToInt32(this.cboMoneda.SelectedValue);
            if (nValor != this.objCreditoProp.idMoneda)
            {
                this.objCreditoProp.idMoneda = nValor;
                
                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);
            }
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ActualizarTipoPeriodo();
            // ----------------------------------------------------------------------
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                //Fecha fija
                this.lblBase19.Text = "Día de Pago";
                this.lblBase1.Text = "cada/mes";
                //this.nudPlazoCuota.Enabled = false;
                this.nudPlazoCuota.Minimum = 1;
                this.nudPlazoCuota.Maximum = 31;
                this.nudPlazoCuota.Text = this.objCreditoProp.dFechaDesembolso.Day.ToString();

                //DateTime dFecha = this.dtFechaDesembolso.Value.AddMonths(1);
                //this.dtFechaPrimeraCuota.Value = new DateTime(dFecha.Year, dFecha.Month, PlazoCuota() + DiasGracia());
                this.txtCuotasGracia.Text = "0";
                this.txtCuotasGracia.Enabled = false;
            }
            else
            {
                //Periodo de Pago
                this.lblBase19.Text = "Frecuencia";
                this.lblBase1.Text = "días";
                //this.nudPlazoCuota.Enabled = true;
                this.nudPlazoCuota.Minimum = 30;
                this.nudPlazoCuota.Maximum = 365;
                this.nudPlazoCuota.Text = "30";

                this.txtCuotasGracia.Text = "0";
                this.txtCuotasGracia.Enabled = true;
                //this.dtFechaPrimeraCuota.Value = this.dtFechaDesembolso.Value.AddDays(PlazoCuota() + DiasGracia());
            }
            // ----------------------------------------------------------------------

            nudPlazoCuota_Leave(this.nudPlazoCuota, new EventArgs());
        }

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoTasaCredito.SelectedIndex < 0 || this.idTasaValida == Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue))
            {
                return;
            }


            if (!EsValidoComponente(sender)) return;

            int nValor = TipoTasa();

            DataTable dtValidacion = (new CRE.CapaNegocio.clsCNGrupoSolidario()).ValidarCambioTasaGrupoSol(
                this.objCreditoProp.idGrupoSolidario, this.objCreditoProp.idSolicitudCredGrupoSol, nValor);

            if (dtValidacion.Rows.Count > 0 && Convert.ToInt32(dtValidacion.Rows[0]["lValido"]) == 0)
            {
                //cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;                
                MessageBox.Show("" + dtValidacion.Rows[0]["cMensaje"], "NO CUMPLE CONDICIONES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoTasaCredito.SelectedValue = this.idTasaValida;
                return;
                //cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;                
            }
            else
            {
                this.idTasaValida = Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
            }

            if (nValor != this.objCreditoProp.idTasa)
            {
                this.objCreditoProp.idTasa = nValor;

                var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;

                if (drvTasa != null)
                {
                    DataRow row = drvTasa.Row;

                    AsignarTEA(row);
                }

                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);
            }
        }

        private void conNivelesProducto_ChangeProducto(object sender, EventArgs e)
        {
            if (!EsValidoComponente(sender)) return;

            int nValor = conNivelesProducto.idSubproducto();
            if (nValor != this.objCreditoProp.idSubProducto)
            {
                this.objCreditoProp.idSubProducto = nValor;

                if (ChangeCondiCredito != null)
                    ChangeCondiCredito(null, null);

                if (ChangeProducto != null)
                    ChangeProducto(null, null);
            }
        }

        #endregion

        private void dtFechaDesembolso_ValueChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                //Fecha fija
                nudPlazoCuota.Text = this.dtFechaDesembolso.Value.Day.ToString();
            }

            nudPlazoCuota_Leave(this.nudPlazoCuota, new EventArgs());
        }

        public void bloqueoGenPlanPagos()
        {
            cboMoneda.Enabled = false;
            txtNroCuotas.Enabled = false;
            cboTipoPeriodo.Enabled = false;
            //nudPlazoCuota.Enabled = false;
            nudDiasGracia.Enabled = false;
            txtCuotasGracia.Enabled = false;
            //dtFechaDesembolso.Enabled = false;
            dtFechaPrimeraCuota.Enabled = false;
            conNivelesProducto.Enabled = false;
        }

        private void nudPlazoCuota_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPeriodo.SelectedValue) == 1)
            {
                DateTime dtpTmp = dtFechaPrimeraCuota.Value;
                dtFechaPrimeraCuota.Value = dtpTmp.AddDays(-dtpTmp.Day+Convert.ToInt32(nudPlazoCuota.Value));
            }
        }
    }
}

