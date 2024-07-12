using GEN.ControlesBase;
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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;


namespace CRE.Presentacion
{
    public partial class frmCondiSolCredIntegrante : frmBase
    {

        public decimal nTasaMin = 0;
        public decimal nTasaMax = 0;
        public decimal nTasaNegAprobada = 0;
        public decimal nMonto = 0;
        public int idDetalleGasto = 0;
        public int idDestino = 0;
        public string cDestino = "";
        public int idActividad = 0;
        public int idActividadInterna = 0;
        public string cActividadInterna = "";
        public bool lAcepta = false;
        public decimal nMontoModificado = 0;
        public decimal nMontoMax = 0;
        public int idPaqueteSeguro = -1;
        public clsCreditoProp objCreditoProp;
        private List<clsTasaNegociable> listaTasasNegociables;

        string TITULO_FORM = "Asignar Datos a Cliente";

        private int idOpcionDondeInvoca = 0;
        public frmCondiSolCredIntegrante()
        {
            InitializeComponent();
        }

        public frmCondiSolCredIntegrante(clsCreditoProp obj, int idOpcionDondeInvoca) //decimal nMonto, int idDestino, string cDestino, int idActividad, int idActividadInterna)
        {
            InitializeComponent();
            this.limpiarFormulario();
            this.objCreditoProp = obj;
            this.nMonto = obj.nMonto;
            this.idDetalleGasto = obj.idDetalleGasto;
            this.idDestino = obj.idDestino;
            this.cDestino = obj.cDestino;
            this.idActividad = obj.idActividad;
            this.idActividadInterna = obj.idActividadInterna;
            idPaqueteSeguro = obj.idPaqueteSeguro;
            this.idOpcionDondeInvoca = idOpcionDondeInvoca;
        }

        private void AsignarDatos()
        {
            this.txtNombreGrupo.Text = this.objCreditoProp.cNombreGrupoSol;
            this.txtIdCli.Text = this.objCreditoProp.idCli.ToString();
            this.txtCliente.Text = this.objCreditoProp.cNombreCli;
            this.nudMonto.Text= this.nMonto.ToString();            
            this.cboDestinoCredito.SelectedValue = this.idDestino;
            this.conActividadCIIU.cargarActividadInterna(this.idActividadInterna);
            this.cboDetalleGasto1.SelectedValue = this.idDetalleGasto;
            this.txtTEA.Text= this.objCreditoProp.nTasaCompensatoria.ToString();
        }

        private bool validarSeguroConyugal()
        {
            DataTable dtValidacion = (new clsCNEvaluacion()).validarTipoSeguroConyugal(Convert.ToInt32(txtIdCli.Text), Convert.ToDecimal(nudMonto.Text));

            if (dtValidacion.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(dtValidacion.Rows[0]["lValido"]))
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cMensaje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar validar el Tipo de Seguro Desgravamen", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.nMonto = this.nudMonto.nDecValor;
            DataRowView drAct = (DataRowView)(this.conActividadCIIU.cboActividadInterna1.SelectedItem);

            if (drAct == null)
            {
                MessageBox.Show("No tiene una actividad definida.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.idDetalleGasto = Convert.ToInt32(this.cboDetalleGasto1.SelectedValue);
            this.idDestino = Convert.ToInt32(this.cboDestinoCredito.SelectedValue);
            this.cDestino = this.cboDestinoCredito.Text;
            this.idActividad = Convert.ToInt32(drAct["idActividad"]);
            this.idActividadInterna = Convert.ToInt32(drAct["idActividadInterna"]);
            this.cActividadInterna = this.conActividadCIIU.cboActividadInterna1.Text;
            idPaqueteSeguro = Convert.ToInt32(cboPaqueteSeguro.SelectedValue);

            this.objCreditoProp.nMonto = this.nudMonto.nDecValor;
            this.objCreditoProp.idDestino = Convert.ToInt32(this.cboDestinoCredito.SelectedValue);
            this.objCreditoProp.cDestino = this.cboDestinoCredito.Text;
            this.objCreditoProp.idActividad = this.idActividad;
            this.objCreditoProp.idActividadInterna = this.idActividadInterna;
            this.objCreditoProp.cActividadInterna = this.conActividadCIIU.cboActividadInterna1.Text;
            this.objCreditoProp.idTasa = Convert.ToInt32(cboTipoTasaCredito.SelectedValue);
            this.objCreditoProp.nTasaCompensatoria = this.txtTEA.nDecValor;
            this.objCreditoProp.nTasaMoratoria = Convert.ToDecimal(txtTasaMora.Text);
            this.objCreditoProp.nCuotaAprox = Convert.ToDecimal(txtCuotaAprox.Text);
            this.objCreditoProp.nCuotaGraciaAprox = Convert.ToDecimal(txtCuotaGraciaAprox.Text);

            if (nMontoMax !=0 && nMonto > nMontoMax ) 
            {
                MessageBox.Show("El monto no debe ser mayor al monto máximo",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nMonto < 300)
            {
                MessageBox.Show("El monto no puede ser menor a 300.00",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboTipoTasaCredito.SelectedIndex == -1)
            {
                MessageBox.Show("Se debe seleccionar la Tasa para poder continuar",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!(nTasaNegAprobada > 0))
            {
                if (this.nTasaMax < this.objCreditoProp.nTasaCompensatoria || this.objCreditoProp.nTasaCompensatoria < this.nTasaMin)
                {
                    MessageBox.Show("Debe registrar la TEA según rango de tasas\n",
                            TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (nMontoMax == 0 && idDestino == 0)
            {
                MessageBox.Show("No tiene un destino del crédito definido.",
                       TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nMontoMax == 0 && idActividad == 0)
            {
                MessageBox.Show("No tiene una actividad definida.",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(cboDetalleGasto1.SelectedValue) != 0)
            {
                if (Convert.ToInt32(cboDetalleGasto1.SelectedValue) == 2)
                {
                    if (!validarSeguroConyugal()) return;
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar el Tipo de Seguro de Desgravamen.",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (idPaqueteSeguro == 0)
            {
                MessageBox.Show("Seleccione un plan de seguro.",
                        TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


                lAcepta = true;
                this.Close();
            
        }

        private void frmCondiSolCredIntegrante_Load(object sender, EventArgs e)
        {
            this.cboDetalleGasto1.SelectedIndexChanged -= new System.EventHandler(this.cboDetalleGasto1_SelectedIndexChanged);
            cboDetalleGasto1.listarDetalleGastoEnSolicitud();
            cboDestinoCredito.filtrarGrupoSolidario();
            CargarPaquetesSeguro(true);
            this.AsignarDatos();
            ActualizarTasaCredito();
            conActividadCIIU.cargarActividadInterna(this.objCreditoProp.idActividadInterna);
            this.cboDetalleGasto1.SelectedIndexChanged += new System.EventHandler(this.cboDetalleGasto1_SelectedIndexChanged);
            if (nMontoMax > 0) {
                lblMontoMaximo.Text = "Monto máximo: " + nMontoMax.ToString("N2");
                lblMontoMaximo.Visible = true;
                grbBase1.Visible = false;
                this.Size = new Size(new Point(497, 371));
                btnAceptar.Location = new Point(337, 246);
                btnSalir.Location = new Point(403, 246);
            }
            else
            {
                lblMontoMaximo.Visible = false;
                grbBase1.Visible = true;
                this.Size = new Size(new Point(497, 525));
                btnAceptar.Location = new Point(349, 406);
                btnSalir.Location = new Point(415, 406);
            }
            
            HabilitarControlesGrbBase();
            cargarTasas();

            if(this.objCreditoProp.idSolicitud != 0)
            {
                ObtenerTasasNegociables(this.objCreditoProp.idSolicitud);
            }

            if (this.objCreditoProp.idModalidadCredito == 3) //estaciones
            {
                cboDestinoCredito.SelectedValue = 1;
                cboDestinoCredito.Enabled = false;
            }
            else
            {
                cboDestinoCredito.Enabled = true;
            }
            validarPlanesDeSeguroActivados();
        }

        #region Métodos Públicos

        public void ActualizarTasaCredito()
        {
            this.objCreditoProp.nPlazoTotalDias = ObtenerPlazoTotalDias();
            DataTable dtTasa = new DataTable();
            if (this.objCreditoProp.lConTasaNegociable)
            {
                dtTasa = (new clsCNTasaCredito()).ListaTasaEval(
                                    this.objCreditoProp.nPlazoTotalDias,
                                    this.objCreditoProp.idProducto,
                                    this.objCreditoProp.nMontoMaximo,
                                    this.objCreditoProp.idMoneda,
                                    this.objCreditoProp.idAgencia,
                                    this.objCreditoProp.idSolicitud,
                                    this.objCreditoProp.idClasificacionInterna); // no se considera la clasificacion para grupo solidario///this.objCreditoProp.idClasificacionInterna);
            }
            else
            {
                dtTasa = (new clsCNTasaCredito()).ListaTasaEvalGrupoSol(
                                    this.objCreditoProp.nPlazoTotalDias,
                                    this.objCreditoProp.idProducto,
                                    this.objCreditoProp.nMontoMinimo,
                                    this.objCreditoProp.nMontoMaximo,
                                    this.objCreditoProp.idMoneda,
                                    this.objCreditoProp.idAgencia,
                                    0,
                                    this.objCreditoProp.idClasificacionInterna); // no se considera la clasificacion en grupo solidario
            }

             

            if (dtTasa.Rows.Count > 0)
            {
                cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;
                cboTipoTasaCredito.DataSource = null;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                cboTipoTasaCredito.DataSource = dtTasa;

                cboTipoTasaCredito.SelectedIndex = -1;
                cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;
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
                        this.cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;
                        cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
                        this.cboTipoTasaCredito.SelectedIndexChanged += cboTipoTasaCredito_SelectedIndexChanged;
                        AsignarTEA(row);
                    }
                }

                CalcularCuotaAprox();
            }
            else
            {
                //this.objCreditoProp.idTasa = 0;
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

            this.cboTipoTasaCredito.SelectedIndexChanged -= cboTipoTasaCredito_SelectedIndexChanged;
            this.cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
            this.cboTipoTasaCredito.SelectedIndexChanged += cboTipoTasaCredito_SelectedIndexChanged;
        }


        /// <summary>
        /// Retorna las cuotas de gracia del crédito
        /// </summary>
        /// <returns></returns>
        public int CuotasGracia()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nCuotasGracia.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nCuotasGracia);
        }

        /// <summary>
        /// Retorna el numero de cuotas del crédito
        /// </summary>
        /// <returns></returns>
        public int NroCuotas()
        {
            return this.objCreditoProp.nCuotas;
        }

        /// <summary>
        /// Retorna los días de gracia
        /// </summary>
        /// <returns></returns>
        public int DiasGracia()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nDiasGracia.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nDiasGracia);
        }

        /// <summary>
        /// Retorna el tipo de Periodo: Fecha Fija o Periodo Fijo
        /// </summary>
        /// <returns></returns>
        public int TipoPeriodo()
        {
            return Convert.ToInt32(this.objCreditoProp.idTipoPeriodo);
        }

        /// <summary>
        /// Retorna el PlazoCuota del crédito en número de días
        /// </summary>
        /// <returns></returns>
        public int PlazoCuota()
        {
            return String.IsNullOrWhiteSpace(this.objCreditoProp.nPlazoCuota.ToString()) ? 0 : Convert.ToInt32(this.objCreditoProp.nPlazoCuota);
        }

        /// <summary>
        /// Retorna el tipo de tasa
        /// </summary>
        /// <returns>INT 32</returns>
        public int TipoTasa()
        {
            return (this.cboTipoTasaCredito.SelectedIndex < 0) ? 0 : Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue);
        }

        public void CalcularCuotaAproxIntegrante(bool lActualizaTasa = true)
        {
            CalcularCuotaAprox(lActualizaTasa);
        }
        #endregion

        #region Métodos Privados

        private int ObtenerPlazoTotalDias()
        {
            int nPlazoTotalDias = ((new clsCNSolicitud()).ObtieneTotalDias(
                                            this.objCreditoProp.dFechaDesembolso,
                                            NroCuotas(),
                                            DiasGracia(),
                                            TipoPeriodo(),
                                            PlazoCuota()));

            return nPlazoTotalDias;
        }

        private void CalcularCuotaAprox(bool lActualizaTasa = true)
        {
            DataTable dtCalendarioPagos = new DataTable();
            DataTable dtEmpty = new DataTable();
            decimal nCuotaConstante = 0;
            decimal nCuotaGraciaAprox = 0;
            if (lActualizaTasa)
            {
                objCreditoProp.idTasa = (cboTipoTasaCredito.SelectedValue == DBNull.Value)? 0 : Convert.ToInt32(cboTipoTasaCredito.SelectedValue);
                objCreditoProp.nTasaCompensatoria = Convert.ToDecimal(String.IsNullOrEmpty(txtTEA.Text) ? "0" : txtTEA.Text);
            }

            if (this.objCreditoProp.nMonto == 0)
            {
                return;
            }
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
                                    this.objCreditoProp.dFechaPrimeraCuota);

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
                                    this.objCreditoProp.dFechaPrimeraCuota,
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
                       

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoTasaCredito.SelectedIndex < 0 || this.objCreditoProp.idTasa == Convert.ToInt32(this.cboTipoTasaCredito.SelectedValue))
            {
                return;
            }

            //this.cboTipoTasaCredito.SelectedValue = this.objCreditoProp.idTasa;
            
            int nValor = TipoTasa();

            // Revisar al momento de crear una nueva tasa
            // revisar cuando se edita la tasa
            //// revisar cuando se quiere cambiar la tasa
            if (this.objCreditoProp.idTasa != nValor)
            {
                this.objCreditoProp.idTasa = nValor;

                var drvTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;

                if (drvTasa != null)
                {
                    DataRow row = drvTasa.Row;

                    AsignarTEA(row);
                }
            }

            cargarTasas();
        }
        
        

        private void AsignarTEA(DataRow row)
        {
            decimal nTasaMora = Convert.ToDecimal(row["nTasaMoratoria"]);
            decimal nTasaMoratoriaAproba = Convert.ToDecimal(row["nTasaMoratoriaAproba"]);
            this.nTasaMin = Convert.ToDecimal(row["nTasaCompensatoria"]);
            this.nTasaMax = Convert.ToDecimal(row["nTasaCompensatoriaMax"]);
            this.nTasaNegAprobada = Convert.ToDecimal(row["nTasaNegAprobada"]);

            //int idTasa = Convert.ToInt32(row["idTasa"]);
            this.txtTasCompensatoriaMin.Text = this.nTasaMin.ToString("#,0.0000");
            this.txtTasCompensatoriaMax.Text = this.nTasaMax.ToString("#,0.0000");
            this.txtTasaMora.Text = nTasaMora.ToString("#,0.0000");

            if (this.nTasaMin == this.nTasaMax)
            {
                this.txtTEA.Enabled = false;
                this.txtTEA.Text = this.nTasaMax.ToString();
            }
            else
            {
                this.txtTEA.Enabled = true;
                this.txtTEA.Text = this.nTasaMin.ToString();
            }

            if (this.nTasaNegAprobada > 0)
            {
                this.txtTEA.Enabled = false;
                this.txtTEA.Text = this.nTasaNegAprobada.ToString();
                this.txtTasaMora.Text = nTasaMoratoriaAproba.ToString();
            }
        }

        private void nudMonto_Leave(object sender, EventArgs e)
        {
            if (this.objCreditoProp.idOperacion == (int)OperacionCredito.Ampliacion)
            {
                this.nudMonto.Text = (Math.Floor(this.nudMonto.nDecValor)).ToString("##0.00");
            }
            if (!montoLimiteValido())
            {
                if (this.objCreditoProp.idOperacion == (int)OperacionCredito.Ampliacion)
                {
                    MessageBox.Show(string.Concat("El Monto debe ser Mayor que el Monto de Cancelación ( ", this.objCreditoProp.nMontoCancelacion," )."), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.nudMonto.Text = this.objCreditoProp.nMonto.ToString("##0.00");                    
                }
                else
                {
                    MessageBox.Show(string.Concat("El Monto no debe ser mayor a ", objCreditoProp.nMonto), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.nudMonto.nDecValor = this.objCreditoProp.nMonto;
                }
            }
            cargarTasas();
        }

        private bool montoLimiteValido()
        {
            if (this.objCreditoProp.nMonto > decimal.Zero &&
                this.nudMonto.nDecValor > this.objCreditoProp.nMonto &&
                this.objCreditoProp.idOperacion != (int)OperacionCredito.Ampliacion)
                return false;

            if(this.objCreditoProp.idOperacion == (int)OperacionCredito.Ampliacion
                && this.nudMonto.nDecValor <= this.objCreditoProp.nMontoCancelacion)
            {
                return false;
            }
            return true;
        }
        private void cargarTasas()
        {
            this.objCreditoProp.nMonto = this.nudMonto.nDecValor;
            this.objCreditoProp.nMontoMinimo = this.nudMonto.nDecValor;
            this.objCreditoProp.nMontoMaximo = this.nudMonto.nDecValor;

            ActualizarTasaCredito();
        }

        private void limpiarFormulario()
        {
            txtNombreGrupo.Clear();
            txtIdCli.Clear();
            txtCliente.Clear();
            nudMonto.nDecValor = 0;
            cboTipoTasaCredito.SelectedIndex = -1;
            txtTasCompensatoriaMin.Clear();
            txtTasCompensatoriaMax.Clear();
            txtTEA.Clear();
            txtCuotaAprox.Clear();
            txtTasaMora.Clear();
            txtCuotaGraciaAprox.Clear();
            cboDestinoCredito.SelectedIndex = -1;
            conActividadCIIU.limpiarCombosCIIU();

            this.nMonto = 0;        
            this.idDestino = 0;
            this.cDestino = "";
            this.idActividad = 0;
            this.idActividadInterna = 0;
            this.cActividadInterna = "";
            this.lAcepta = false;
        }

        private void ObtenerTasasNegociables(int idSolicitud)
        {
            clsCNEvaluacion objADEvaluacion = new clsCNEvaluacion();
            DataTable dt = objADEvaluacion.ListaTasasNegociables(idSolicitud);

            this.listaTasasNegociables = DataTableToList.ConvertTo<clsTasaNegociable>(dt) as List<clsTasaNegociable>;

            this.pbxTasaAprob.Visible = false;

            if (this.listaTasasNegociables.Count > 0)
                this.pbxTasaAprob.Visible = true;

        }

        #endregion

        private void pbxTasaAprob_Click(object sender, EventArgs e)
        {
            frmTasasAprobadas frmTasasAprobadas = new frmTasasAprobadas(this.listaTasasNegociables);
            frmTasasAprobadas.ShowDialog();
        }

        private void cboDetalleGasto1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cboDetalleGasto1.SelectedIndex == 2)
            {
                DialogResult drRespuesta = MessageBox.Show(cboDetalleGasto1.cMsjSeguroDevolucion,
                    cboDetalleGasto1.cTituloMsjSegDevolucion,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.No == drRespuesta)
                    cboDetalleGasto1.SelectedIndex = -1;


            }
            if (cboDetalleGasto1.SelectedIndex != -1)
            {
                idDetalleGasto = Convert.ToInt16(cboDetalleGasto1.SelectedValue);
                CargarPaquetesSeguro(false);
            }
        }

        private void CargarPaquetesSeguro(bool cargaInicial)
        {
            if (idDetalleGasto > 0)
            {
                int idAgencia = clsVarGlobal.nIdAgencia;
                int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;

                cboPaqueteSeguro.CargarPaqueteSeguroVenta(idDetalleGasto, idPerfil, idAgencia, idPaqueteSeguro);
                cboPaqueteSeguro.AgregarNinguno();
                cboPaqueteSeguro.SelectedValue = cargaInicial ? idPaqueteSeguro : -1;
            }
            else
            {
                cboPaqueteSeguro.AgregarNinguno();
                cboPaqueteSeguro.SelectedValue = -1;
            }
            cboPaqueteSeguro.DropDownWidth = cboPaqueteSeguro.Items.Count > 1 ? 405 : cboPaqueteSeguro.Width;
        }

        private void HabilitarControlesGrbBase()
        {
            grbBase1.Visible = true;
            this.Size = new Size(new Point(497, 525));
            btnAceptar.Location = new Point(349, 406);
            btnSalir.Location = new Point(415, 406);

            cboDestinoCredito.Visible = false;
            conActividadCIIU.Visible = false;
            cboDetalleGasto1.Visible = false;
            cboPaqueteSeguro.Visible = false;

            lblBase3.Visible = false;
            lblBase38.Visible = false;
            lblPaqueteSeguro.Visible = false;

            // Desde la solicitud
            if (idOpcionDondeInvoca == 1)
            {
                cboDestinoCredito.Visible = true;
                conActividadCIIU.Visible = true;
                cboDetalleGasto1.Visible = true;
                cboPaqueteSeguro.Visible = true;

                lblBase3.Visible = true;
                lblBase38.Visible = true;
                lblPaqueteSeguro.Visible = true;
            }
            // Desde evaluacion
            else if (idOpcionDondeInvoca == 2)
            {
                cboPaqueteSeguro.Visible = true;
                cboDetalleGasto1.Visible = true;
                lblBase38.Visible = true;
                lblPaqueteSeguro.Visible = true;

                cboDetalleGasto1.Enabled = false;

            }
            // Desde aprobacion
            else if (idOpcionDondeInvoca == 3)
            {
                grbBase1.Visible = false;
                this.Size = new Size(new Point(497, 371));
                btnAceptar.Location = new Point(337, 246);
                btnSalir.Location = new Point(403, 246);
            }
        }

        private void validarPlanesDeSeguroActivados()
        {
            //Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (lstPaqueteSeguros.Count == 0)
            {
                lblPaqueteSeguro.Visible = false;
                cboPaqueteSeguro.Visible = false;
            }
        }
    }
}
