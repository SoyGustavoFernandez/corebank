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
//using CRW.Helper;
using GEN.CapaNegocio;
//using GEN.Funciones;
using CLI.CapaNegocio;
using CRE.CapaNegocio;
using GEN.ControlesBase;

namespace CRE.ControlBase
{
    public partial class ConCondiCredito : UserControl
    {
        private clsEvalCred objEvalCred = null;
        private clsCreditoProp objCredSolicitado = null;

        private DataTable dtTipMoneda;
        private DataTable dtTipPeriodo;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private DataTable dtSectorEconomico;

        public event EventHandler ActividadInternaSelectedIndexChanged;
        public event EventHandler ActualizarPorDestinoCapitalTrabajoChanged;
        public event EventHandler CuotaAproximadaChanged;
        public event EventHandler PlazoChanged;
        public event EventHandler SectorEconSelectedIndexChanged;

        public event EventHandler btnPropDesembolsoClick;

        public ConCondiCredito()
        {
            InitializeComponent();
            this.tbcCredito.SelectedTab = this.tbpCredProp;

            lMostrarCondicionesCredito = true;
            lMostrarDestinoCredito = true;
            lMostrarRCC = false;

            lHabilitarCondicionesCredito = true;
            lHabilitarDestinoCredito = true;
            lHabilitarRCC = true;

        }

        #region "Properties"
        public bool lMostrarBtnPropDesembolsos
        {
            set
            {
                this.btnPropDesembolsos.Visible = value;
            }
            get { return this.btnPropDesembolsos.Visible; }
        }
        public bool lMostrarCondicionesCredito
        {
            get
            {
                return this.pnlCondicionesCred.Visible;

            }
            set
            {
                this.pnlCondicionesCred.Visible = value;
                Invalidate();
            }
        }

        public bool lMostrarDestinoCredito
        {
            get
            {
                return this.pnlDestinoCredito.Visible;
            }
            set
            {
                this.pnlDestinoCredito.Visible = value;
                Invalidate();
            }
        }
        public bool lMostrarRCC
        {
            get
            {
                return this.pnlRcc.Visible;
            }
            set
            {
                this.pnlRcc.Visible = value;
                Invalidate();
            }
        }

        public bool lHabilitarCondicionesCredito
        {
            get
            {
                return this.pnlCondicionesCred.Enabled;
            }
            set
            {
                this.pnlCondicionesCred.Enabled = value;
                Invalidate();
            }
        }
        public bool lHabilitarDestinoCredito
        {
            get
            {
                return pnlDestinoCredito.Enabled;
            }
            set
            {
                pnlDestinoCredito.Enabled = value;
                Invalidate();
            }
        }
        public bool lHabilitarRCC
        {
            get
            {
                return this.pnlRcc.Enabled;
            }
            set
            {
                this.pnlRcc.Enabled = value;
                Invalidate();
            }
        }
        public bool lHabilitarActividad
        {
            get
            {
                return grbEvalCred.Enabled;
            }
            set
            {
                grbEvalCred.Enabled = value;
            }
        }

        #endregion

        #region Métodos Públicos
        public void AsignarDataTable(DataTable _dtTipMoneda, DataTable _dtTipPeriodo, DataTable _dtTipDestCred,
            DataTable _dtTipDestCredDetalle, DataTable _dtSectorEconomico)
        {
            this.dtTipMoneda = _dtTipMoneda;
            this.dtTipPeriodo = _dtTipPeriodo;
            this.dtTipDestCred = _dtTipDestCred;
            this.dtTipDestCredDetalle = _dtTipDestCredDetalle;
            this.dtSectorEconomico = _dtSectorEconomico;

            this.cboSectorEcon.DisplayMember = "cDescripcion";
            this.cboSectorEcon.ValueMember = "idSectorEcon";
            this.cboSectorEcon.DataSource = this.dtSectorEconomico;

            this.cboMoneda.DisplayMember = "cMoneda";
            this.cboMoneda.ValueMember = "idMoneda";
            this.cboMoneda.DataSource = dtTipMoneda;

            this.cboTipoPeriodo.DisplayMember = "cDescripTipoPeriodo";
            this.cboTipoPeriodo.ValueMember = "idTipoPeriodo";
            this.cboTipoPeriodo.DataSource = dtTipPeriodo;
        }

        public void AsignarDatos(clsEvalCred _objEvalCred, clsCreditoProp _objCredSolicitado, List<clsDestCredProp> _listDestCredProp,
                    List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval)
        {
            this.conCreditoTasa.ChangeCuotaAprox -= new System.EventHandler(this.conCreditoTasa_ChangeCuotaAprox);
            this.conDestinoCredito.ChangeCapitalTrabajo -= new System.EventHandler(this.conDestinoCredito_ChangeCapitalTrabajo);
            this.cboActividadInterna.SelectedIndexChanged -= new System.EventHandler(this.cboActividadInterna_SelectedIndexChanged);
            this.cboSectorEcon.SelectedIndexChanged -= new System.EventHandler(this.cboSectorEcon_SelectedIndexChanged);
            this.conCreditoTasa.ChangePlazo -= new System.EventHandler(this.conCreditoTasa_ChangePlazo);

            this.objEvalCred = _objEvalCred;
            this.objCredSolicitado = _objCredSolicitado;

            // -- Crédito Propuesto
            this.conCreditoTasa.AsignarDatos(new clsCreditoProp()
            {
                idSolicitud = this.objEvalCred.idSolicitud,
                idMoneda = this.objEvalCred.idMoneda,
                nMonto = this.objEvalCred.nCapitalPropuesto,
                nCuotas = this.objEvalCred.nCuotas,
                idTipoPeriodo = this.objEvalCred.idTipoPeriodo,
                nPlazoCuota = this.objEvalCred.nPlazoCuota,
                nDiasGracia = this.objEvalCred.nDiasGracia,
                dFechaDesembolso = this.objEvalCred.dFechaDesembolso,
                idProducto = this.objEvalCred.idProducto,
                cTipoCredito = this.objEvalCred.cTipoProducto,
                cSubProducto = this.objEvalCred.cSubProducto,
                idTasa = this.objEvalCred.idTasa,
                nTasaCompensatoria = this.objEvalCred.nTEA,
                idCli = this.objEvalCred.idCli,
                nCuotasGracia = this.objEvalCred.nCuotasGracia,
                idOperacion = this.objCredSolicitado.idOperacion,
                idAgencia = this.objCredSolicitado.idAgencia,
                idClasificacionInterna = this.objEvalCred.idClasificacionInterna
                //No se pasan como parámetros por que son resultados de las condiciones anteriores
                //nPlazo = this.objEvalCred.nPlazo,
                //nCuotaAprox = this.objEvalCred.nCuotaAprox,
                //nCuotaGraciaAprox = this.objEvalCred.nCuotaGraciaAprox,
                //dtCalendarioPagos = this.objEvalCred.dtCalendarioPagos,
                //nTotalMontoPagar = this.objEvalCred.nTotalMontoPagar
            });

            // -- Crédito Solicitado
            this.cboMoneda.SelectedValue = this.objCredSolicitado.idMoneda;
            this.txtMonto.Text = this.objCredSolicitado.nMonto.ToString("n2");
            this.nudCuotas.Value = this.objCredSolicitado.nCuotas;
            this.cboTipoPeriodo.SelectedValue = this.objCredSolicitado.idTipoPeriodo;
            this.nudPlazoCuota.Value = this.objCredSolicitado.nPlazoCuota;
            this.nudDiasGracia.Value = this.objCredSolicitado.nDiasGracia;
            this.dtFechaDesembolso.Value = this.objCredSolicitado.dFechaDesembolso;
            this.txtTEA.Text = this.objCredSolicitado.nTea.ToString("n4");

            if (this.cboTipoPeriodo.SelectedIndex == 0)
            {
                this.lblBase19.Text = "Día de Pago";
                this.lblBase1.Text = "";
            }
            else
            {
                this.lblBase19.Text = "Frecuencia";
                this.lblBase1.Text = "días";
            }

            // -- Destino del Crédito
            this.conDestinoCredito.AsignarDataTable(this.dtTipDestCred, this.dtTipDestCredDetalle);
            this.conDestinoCredito.AsignarDatos(this.objEvalCred.nCapitalPropuesto, _listDestCredProp);
            this.conDestinoCredito.EstablacerActivoAdquirir(this.objEvalCred.nActivoAdquirir);
            decimal nDestinoCapitalTrabajo = this.conDestinoCredito.MontoCapitalTrabajo();

            // -- Actividad Interna y Sector economico
            if (this.objEvalCred.idActividadInternaPri > 0)
            {
                this.cboActividadInterna.SelectedValue = this.objEvalCred.idActividadInternaPri;
                this.cboActividadInterna.Enabled = false;
            }
            else
            {
                this.cboActividadInterna.Enabled = true;
            }

            if (this.objEvalCred.idSectorEcon > 0)
            {
                this.cboSectorEcon.SelectedValue = this.objEvalCred.idSectorEcon;
                this.cboSectorEcon.Enabled = false;
            }
            else
            {
                this.cboSectorEcon.Enabled = true;
            }

            // -- Eventos
            this.conCreditoTasa.ChangeCuotaAprox += new System.EventHandler(this.conCreditoTasa_ChangeCuotaAprox);
            this.conDestinoCredito.ChangeCapitalTrabajo += new System.EventHandler(this.conDestinoCredito_ChangeCapitalTrabajo);
            this.cboActividadInterna.SelectedIndexChanged += new System.EventHandler(this.cboActividadInterna_SelectedIndexChanged);
            this.cboSectorEcon.SelectedIndexChanged += new System.EventHandler(this.cboSectorEcon_SelectedIndexChanged);
            this.conCreditoTasa.ChangePlazo += new System.EventHandler(this.conCreditoTasa_ChangePlazo);

            ActividadCIIU(null, null);
            EstablecerCuotaAprox();
            //conCreditoTasa_ChangeCuotaAprox(null, null);
            //this.txtCuotaAprox.Text = this.objEvalCred.nCuotaAprox;
        }

        public void ActualizarRcc(decimal nIngresosMN, decimal nIngresosME, decimal nEgresosMN, decimal nEgresosME, decimal nCuotaAprox, decimal nDeudasEntFinan)
        {
            // -- Riesgo Cambiario Crediticio
            DataTable dtIngresos = new DataTable();
            dtIngresos.Columns.Add("idMoneda", typeof(int));
            dtIngresos.Columns.Add("nMonto", typeof(decimal));
            dtIngresos.Rows.Add(1, nIngresosMN);
            dtIngresos.Rows.Add(2, nIngresosME);

            DataTable dtEgresos = new DataTable();
            dtEgresos.Columns.Add("idMoneda", typeof(int));
            dtEgresos.Columns.Add("nMonto", typeof(decimal));
            dtEgresos.Rows.Add(1, nEgresosMN);
            dtEgresos.Rows.Add(2, nEgresosME);

            this.conRcc1.cargarParametros(dtIngresos, dtEgresos, this.objEvalCred.nTipoCambio, nDeudasEntFinan, nCuotaAprox, this.objEvalCred.idMoneda);
        }

        public void ActualizarDatos(decimal nCapitalPropuesto, List<clsDestCredProp> _listDestCredProp)
        {
            this.conDestinoCredito.AsignarDatos(nCapitalPropuesto, _listDestCredProp);
        }

        public clsEvalCred CondicionesCreditoYDestino()
        {
            clsCreditoProp credProp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            //idMoneda
            this.objEvalCred.nCapitalPropuesto = credProp.nMonto;
            this.objEvalCred.nCuotas = credProp.nCuotas;
            this.objEvalCred.idTipoPeriodo = credProp.idTipoPeriodo;
            this.objEvalCred.nPlazoCuota = credProp.nPlazoCuota;
            this.objEvalCred.dFechaDesembolso = credProp.dFechaDesembolso;
            this.objEvalCred.nDiasGracia = credProp.nDiasGracia;
            this.objEvalCred.idTasa = credProp.idTasa;
            this.objEvalCred.nTEA = credProp.nTea;
            this.objEvalCred.nTEM = credProp.nTem;
            //idProducto
            this.objEvalCred.nCuotasGracia = credProp.nCuotasGracia;
            this.objEvalCred.nPlazo = credProp.nPlazo;
            this.objEvalCred.nCuotaAprox = credProp.nCuotaAprox;
            this.objEvalCred.nCuotaGraciaAprox = credProp.nCuotaGraciaAprox;
            this.objEvalCred.dtCalendarioPagos = credProp.dtCalendarioPagos;
            this.objEvalCred.cCalendarioPagos = credProp.cCalendarioPagos;
            this.objEvalCred.nTotalMontoPagar = credProp.nTotalMontoPagar;

            this.objEvalCred.idActividadInternaPri = Convert.ToInt32(cboActividadInterna.SelectedValue);
            this.objEvalCred.idActividad = Convert.ToInt32(cboCIIU.SelectedValue);
            this.objEvalCred.idSectorEcon = Convert.ToInt32(this.cboSectorEcon.SelectedValue);
            this.objEvalCred.nActivoAdquirir = conDestinoCredito.ObtenerActivoAdquirir();

            return objEvalCred;
        }

        public clsCreditoProp CondicionesCreditoPropuesto()
        {
            return this.conCreditoTasa.ObtenerCreditoPropuesto();
        }

        public int ObtenerIdActividadInterna()
        {
            return this.objEvalCred.idActividadInternaPri;
        }

        public clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            var objCreditoTasaMsjError = this.conCreditoTasa.Validar();

            if (objCreditoTasaMsjError.HasErrors)
            {
                foreach (var err in objCreditoTasaMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            decimal nMontoSolicitado = (String.IsNullOrWhiteSpace(this.txtMonto.Text)) ? 0 : Convert.ToDecimal(this.txtMonto.Text);

            if (this.conCreditoTasa.MontoPropuesto > nMontoSolicitado)
            {
                objMsjError.AddError("El monto propuesto es mayor a lo solicitado.");
            }

            return objMsjError;
        }

        public string RccToXML(int idEvalCred)
        {
            DataTable dtRcc = this.conRcc1.obtenerRCC(idEvalCred);
            DataSet dsRcc = new DataSet("dsRcc");
            if (dtRcc.DataSet == null)
            {
                dsRcc.Tables.Add(dtRcc);

            }

            return dsRcc.GetXml();
        }

        public decimal ObtenerActivoAdquirir()
        {
            return conDestinoCredito.ObtenerActivoAdquirir();
        }

        #region Médotos: condiciones del crédito propuesto
        /// <summary>
        /// retorna monto asignado para capital de trabajo en los destino de crédito
        /// </summary>
        /// <returns></returns>
        public decimal MontoDestinadoParaCapitalTrabajo()
        {
            return this.conDestinoCredito.MontoCapitalTrabajo();
        }

        /// <summary>
        /// Retorna la cuota aproximadade forma mensual
        /// </summary>
        /// <returns></returns>
        public decimal CuotaAprox()
        {
            return this.conCreditoTasa.CuotaAprox();
        }

        /// <summary>
        /// Retorna la cuota aprox del periodo de gracia
        /// </summary>
        /// <returns></returns>
        public decimal CuotaGraciaAprox()
        {
            return this.conCreditoTasa.CuotaGraciaAprox();
        }

        /// <summary>
        /// Retorna el monto total a pagar
        /// </summary>
        /// <returns></returns>
        public decimal TotalMontoPagar()
        {
            return this.conCreditoTasa.TotalMontoPagar();
        }

        /// <summary>
        /// Retorna el monto Anualizado
        /// </summary>
        /// <returns></returns>
        public decimal TotalMontoPagarAnualizado()
        {
            return this.conCreditoTasa.TotalMontoPagarAnualizado();
        }

        /// <summary>
        /// Retorna el calendario de pagos
        /// </summary>
        /// <returns></returns>
        public DataTable CalengarioPagos()
        {
            return this.conCreditoTasa.CalengarioPagos();
        }

        /// <summary>
        /// Retorna el Monto del crédito
        /// </summary>
        /// <returns></returns>
        public decimal Monto()
        {
            return this.conCreditoTasa.Monto();
        }

        /// <summary>
        /// Retorna el numero de cuotas del crédito
        /// </summary>
        /// <returns></returns>
        public int Cuotas()
        {
            return this.conCreditoTasa.Cuotas();
        }

        /// <summary>
        /// Retorna el Plazo del crédito
        /// </summary>
        /// <returns></returns>
        public int Plazo()
        {
            return this.conCreditoTasa.Plazo();
        }

        /// <summary>
        /// Retorna los periodos de gracia del crédito
        /// </summary>
        /// <returns></returns>
        public int PeriodosGracia()
        {
            return this.conCreditoTasa.CuotasGracia();
        }

        /// <summary>
        /// Retorna la tasa efectiva anual
        /// </summary>
        /// <returns></returns>
        public decimal TEA()
        {
            return this.conCreditoTasa.TEA();
        }

        /// <summary>
        /// Retorna la tasa efectiva mensual
        /// </summary>
        /// <returns></returns>
        public decimal TEM()
        {
            return this.conCreditoTasa.TEM();
        }
        #endregion
        #endregion

        #region Método Privados
        private void ActividadCIIU(object sender, EventArgs e)
        {
            if (cboActividadInterna.SelectedIndex > -1)
            {
                if (this.cboActividadInterna.Items.Count > 0)
                {
                    var drActividadInterna = (DataRowView)cboActividadInterna.SelectedItem;
                    int idActividad = Convert.ToInt32(drActividadInterna["idActividad"]);
                    int idActividadInterna = Convert.ToInt32(drActividadInterna["idActividadInterna"]);

                    clsCNListaActivEco cnactividad = new clsCNListaActivEco();
                    DataTable dtActividad = cnactividad.CNListaActividadEspecifica(idActividad);

                    if (dtActividad.Rows.Count > 0)
                    {
                        int idPadreActividad = Convert.ToInt32(dtActividad.Rows[0]["idPadreActividad"]);

                        this.cboCIIU.CargarActivEconomica(idPadreActividad);
                        this.objEvalCred.idActividadInternaPri = idActividadInterna;
                        this.objEvalCred.idActividad = idActividad;

                        if (ActividadInternaSelectedIndexChanged != null)
                            ActividadInternaSelectedIndexChanged(sender, e);
                    }
                }
            }
        }

        private void EstablecerCuotaAprox()
        {
            this.txtCuotaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaAprox());
            this.txtCuotaGraciaAprox.Text = String.Format("{0:n2}", this.conCreditoTasa.CuotaGraciaAprox());
        }
        #endregion

        #region Eventos
        private void cboActividadInterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActividadCIIU(sender, e);
        }

        private void conDestinoCredito_ChangeCapitalTrabajo(object sender, EventArgs e)
        {
            if (ActualizarPorDestinoCapitalTrabajoChanged != null)
                ActualizarPorDestinoCapitalTrabajoChanged(sender, e);
        }

        private void conCreditoTasa_ChangeCuotaAprox(object sender, EventArgs e)
        {
            EstablecerCuotaAprox();

            if (CuotaAproximadaChanged != null)
                CuotaAproximadaChanged(sender, e);
        }

        private void cboSectorEcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectorEconSelectedIndexChanged != null)
                SectorEconSelectedIndexChanged(sender, e);
        }
        #endregion

        private void conCreditoTasa_ChangePlazo(object sender, EventArgs e)
        {
            if (PlazoChanged != null)
                PlazoChanged(sender, e);
        }

        private void btnPropDesembolsos_Click(object sender, EventArgs e)
        {
            if (btnPropDesembolsoClick != null)
                btnPropDesembolsoClick(sender, e);
        }

        public clsCreditoProp ObtenerCreditoPropuesto()
        {
            return this.conCreditoTasa.ObtenerCreditoPropuesto();
        }

        public int PlazoTotal()
        {
            return conCreditoTasa.nPlazoTotal;
        }

        public int DiasGracia()
        {
            var nCuotasGracia = this.conCreditoTasa.CuotasGracia();
            var nDiasGracia = this.conCreditoTasa.DiasGracia();
            var nFrecuencia = this.conCreditoTasa.conCreditoPeriodo.nPeriodoDia;

            if (nDiasGracia > 0)
                return nDiasGracia;
            else
                return nCuotasGracia * nFrecuencia;
        }

        public int TipoPeriodo()
        {
            return this.conCreditoTasa.TipoPeriodo();
        }

    }
}
