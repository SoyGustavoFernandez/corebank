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
using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioEmisionBono : frmBase
    {
        #region Variables Globales
        private CRE.CapaNegocio.clsCNGrupoSolidario objCNGrupoSolidario; 
        private List<clsGrupoSolidarioBono> lstGrupoSolidarioBono;
        private clsGrupoSolidarioBono objGrupoSolidarioBono;
        private clsGrupoSolidarioIntegrante objGrupoSolidarioIntegrante;
        private BindingSource bsGrupoSolidarioBono;

        private int idGrupoSolidario;
        private int idCliente;
        private decimal nBonoTotal;
        private decimal nMaxAtraso;
        private decimal nPromedioAtraso;
        private decimal nPromedioMeses;

        private int nIndAfecITF = 0;
        private DataTable tbConcep;
        private int idTipoOperacion = 0;
        private int idReciboProvisional = 0;
        clsFunUtiles FunTruncar = new clsFunUtiles();

        public bool lBonoEntregado { get; set; }
        public ResultadoServidor idResultado { get; set; }
        #endregion
        public frmGrupoSolidarioEmisionBono()
        {
            InitializeComponent();
        }
        public frmGrupoSolidarioEmisionBono(clsGrupoSolidarioIntegrante objGrupoSolidarioIntegrante, List<clsGrupoSolidarioBono> lstGrupoSolidarioBono)
        {
            InitializeComponent();
            this.objGrupoSolidarioIntegrante = objGrupoSolidarioIntegrante;
            this.lstGrupoSolidarioBono = lstGrupoSolidarioBono;
            this.idGrupoSolidario = this.objGrupoSolidarioIntegrante.idGrupoSolidario;
            this.idCliente = this.objGrupoSolidarioIntegrante.idCli;

            this.txtGrupo.Text = this.objGrupoSolidarioIntegrante.cGrupoSolidario;
            this.txtCiclo.Text = this.objGrupoSolidarioIntegrante.cCiclo;
            this.txtCargo.Text = this.objGrupoSolidarioIntegrante.cCargo;
            this.txtCodigo.Text = this.idCliente.ToString();
            this.txtCliente.Text = this.objGrupoSolidarioIntegrante.cNombreCliente;
            this.txtDocumento.Text = this.objGrupoSolidarioIntegrante.cNumDocumento;
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.objCNGrupoSolidario = new CRE.CapaNegocio.clsCNGrupoSolidario();
            this.objGrupoSolidarioBono = new clsGrupoSolidarioBono();
            this.bsGrupoSolidarioBono = new BindingSource();

            this.nBonoTotal = decimal.Zero;
            this.nMaxAtraso = decimal.Zero;
            this.nPromedioAtraso = decimal.Zero;
            this.nPromedioMeses = decimal.Zero;
            this.lBonoEntregado = false;
            this.idResultado = ResultadoServidor.Correcto;

            this.bsGrupoSolidarioBono.DataSource = this.lstGrupoSolidarioBono;
            this.dtgBonoEstimado.DataSource = this.bsGrupoSolidarioBono;

            this.formatearAprobacionSolicitud();
            this.objFrmSemaforo = new Semaforo();
            this.habilitarControles(clsAcciones.DEFECTO);
        }
        private void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.tbcEmisionBono.SelectTab("tbpGrupoSolidario");
                    this.btnContinuar.Visible = true;
                    this.lblSustento.Visible = false;
                    this.txtSustento.Visible = false;
                    this.btnEjecutar.Visible = false;
                    this.btnSalir.Visible = false;
                    break;
                case clsAcciones.CONTINUAR:
                    this.tbcEmisionBono.SelectTab("tbpEmisionRecibo");
                    this.btnContinuar.Visible = false;
                    this.lblSustento.Visible = true;
                    this.txtSustento.Visible = true;
                    this.btnEjecutar.Visible = true;
                    this.btnSalir.Visible = false;
                    break;
                case clsAcciones.FINALIZAR:
                    this.tbcEmisionBono.SelectTab("tbpEmisionRecibo");
                    this.btnContinuar.Visible = false;
                    this.lblSustento.Visible = true;
                    this.txtSustento.Visible = true;
                    this.txtSustento.Enabled = false;

                    this.btnEjecutar.Visible = true;
                    this.btnEjecutar.Enabled = false;

                    this.btnSalir.Visible = true;
                    break;
            }
        }
        private void limpiarControles()
        {
        }
        private void formatearAprobacionSolicitud()
        {
            foreach (DataGridViewColumn dgvColumn in this.dtgBonoEstimado.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dtgBonoEstimado.Columns["idCuenta"].Visible = true;
            this.dtgBonoEstimado.Columns["idSolicitud"].Visible = true;
            this.dtgBonoEstimado.Columns["cEstado"].Visible = true;
            this.dtgBonoEstimado.Columns["cCliente"].Visible = true;
            this.dtgBonoEstimado.Columns["cDocumento"].Visible = true;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].Visible = true;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].Visible = true;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].Visible = true;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].Visible = true;
            this.dtgBonoEstimado.Columns["nBono"].Visible = true;
            this.dtgBonoEstimado.Columns["cObservacion"].Visible = true;

            int i = 0;
            this.dtgBonoEstimado.Columns["idCuenta"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["idSolicitud"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cEstado"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cCliente"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cDocumento"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["nBono"].DisplayIndex = i++;
            this.dtgBonoEstimado.Columns["cObservacion"].DisplayIndex = i++;

            this.dtgBonoEstimado.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgBonoEstimado.Columns["idSolicitud"].HeaderText = "Solicitud";
            this.dtgBonoEstimado.Columns["cEstado"].HeaderText = "Estado";
            this.dtgBonoEstimado.Columns["cCliente"].HeaderText = "Cliente";
            this.dtgBonoEstimado.Columns["cDocumento"].HeaderText = "Documento";
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].HeaderText = "Monto Desembolso";
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].HeaderText = "Meses";
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].HeaderText = "Atraso Max.";
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].HeaderText = "Factor";
            this.dtgBonoEstimado.Columns["nBono"].HeaderText = "Monto Bono";
            this.dtgBonoEstimado.Columns["cObservacion"].HeaderText = "Observación";

            this.dtgBonoEstimado.Columns["idCuenta"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["idSolicitud"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["cEstado"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["cCliente"].FillWeight = 150;
            this.dtgBonoEstimado.Columns["cDocumento"].FillWeight = 40;
            this.dtgBonoEstimado.Columns["nCapitalDesembolso"].FillWeight = 50;
            this.dtgBonoEstimado.Columns["nMesesCancelacion"].FillWeight = 20;
            this.dtgBonoEstimado.Columns["nAtrasoMaximo"].FillWeight = 20;
            this.dtgBonoEstimado.Columns["nFactorCapDesembolso"].FillWeight = 30;
            this.dtgBonoEstimado.Columns["nBono"].FillWeight = 50;
            this.dtgBonoEstimado.Columns["cObservacion"].FillWeight = 50;
        }
        private void gestionarGrupoSolidarioBonoEstimado()
        {
            if (this.lstGrupoSolidarioBono.Count > 0)
            {
                this.habilitarControles(clsAcciones.BUSCAR);
                this.calcularIndicadores();
                this.txtBono.Text = this.lstGrupoSolidarioBono.Find(x => x.idCli == this.idCliente).nBono.ToString("###,###,##0.00");
            }
            else
            {
                this.lBonoEntregado = false;
                this.idResultado = ResultadoServidor.Correcto;
                this.Close();
            }
            this.bsGrupoSolidarioBono.ResetBindings(false);
            this.dtgBonoEstimado.Refresh();
            this.dtgBonoEstimado.ClearSelection();
            this.colorearGrupoSolidarioBono();
        }
        public void colorearGrupoSolidarioBono()
        {
            foreach (DataGridViewRow dtgRow in this.dtgBonoEstimado.Rows)
            {
                clsGrupoSolidarioBono objBono = (clsGrupoSolidarioBono)dtgRow.DataBoundItem;

                if (objBono.idCli == this.idCliente)
                {
                    dtgRow.DefaultCellStyle.BackColor = Color.DarkGreen;
                    dtgRow.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void calcularIndicadores()
        {
            decimal nLimiteAtraso = 3.0M;
            decimal nLimiteMeses = 6.0M;


            this.nBonoTotal = this.lstGrupoSolidarioBono.Sum(x => x.nBono);
            this.nMaxAtraso = this.lstGrupoSolidarioBono.Max(x => x.nAtrasoMaximo);
            this.nPromedioAtraso = (decimal)this.lstGrupoSolidarioBono.Average(x => x.nAtrasoMaximo);
            this.nPromedioMeses = (decimal)this.lstGrupoSolidarioBono.Average(x => x.nMesesCancelacion);

            this.nudBonoTotal.Value = this.nBonoTotal;
            this.nudMaxAtraso.Value = this.nMaxAtraso;
            this.nudPromedioAtraso.Value = this.nPromedioAtraso;
            this.nudPromedioMeses.Value = this.nPromedioMeses;

            this.nPromedioAtraso = (this.nPromedioAtraso > 3) ? 3.0M : this.nPromedioAtraso;
            this.nPromedioMeses = (this.nPromedioMeses > 6) ? 6.0M : this.nPromedioMeses;

            this.nPromedioAtraso = this.nPromedioAtraso / nLimiteAtraso;
            this.nPromedioMeses = this.nPromedioMeses / nLimiteMeses;

            this.nPromedioAtraso = (this.nMaxAtraso > 3) ? this.nudPromedioAtraso.Value : this.nPromedioAtraso;
            decimal nProbabilidaBono = 100M * (this.nPromedioMeses / ((this.nPromedioAtraso == decimal.Zero) ? 1 : this.nPromedioAtraso));
            nProbabilidaBono = (nProbabilidaBono > 100M) ? 100M : ((nProbabilidaBono < decimal.Zero) ? decimal.Zero : nProbabilidaBono);
            this.nudProbabilidadBono.Value = nProbabilidaBono;
            this.pgbProbabilidadBono.Value = (int)nProbabilidaBono;
            this.pgbProbabilidadBono.Refresh();

            this.lblMensaje.Text = (this.nMaxAtraso > 3 || this.lstGrupoSolidarioBono.Min(x => x.nMesesCancelacion) < 6) ?
                "*Las filas marcadas en ROJO o NARANJA requieren excepción" :
                string.Empty;
        }
        private void configurarEmisionRecibo()
        {
            this.habilitarControles(clsAcciones.CONTINUAR);
            this.cboMoneda.SelectedValue = EntityLayer.Monedas.Soles;
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.cboTipoRecibo.SelectedValue = TipoRecibo.ReciboEgreso;
            this.cboConcepto.SelectedValue = 478;
            this.txtMontoRecibido.Text = this.lstGrupoSolidarioBono.Find(x=>x.idCli == this.idCliente).nBono.ToString();
            this.txtSustento.Text = "Bono automático de grupo solidario";
            this.btnEjecutar.Focus();
        }

        #region Basado en frmEmisionRecibos
        private string validarDatosIngresados()
        {
            if (string.IsNullOrEmpty(txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("Debe existir un código de usuario para registrar el recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodUsu.Select();
                txtCodUsu.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboTipoRecibo.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe elegir un tipo de recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoRecibo.Select();
                cboTipoRecibo.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboConcepto.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe elegir un concepto para el recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboConcepto.Select();
                cboConcepto.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(cboMoneda.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe elegir la moneda para el recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Select();
                cboMoneda.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtMontoRecibido.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el monto del recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Select();
                txtMontoRecibido.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal(txtMontoRecibido.Text) <= 0)
            {
                MessageBox.Show("El monto del recibo no debe ser cero (0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Select();
                txtMontoRecibido.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtTotRec.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el monto del recibo", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Select();
                txtMontoRecibido.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal(txtTotRec.Text) <= 0)
            {
                MessageBox.Show("El monto total del recibo no debe ser cero (0)...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Select();
                txtMontoRecibido.Focus();
                return "ERROR";
            }
            if (true)
            {

            }
            if (string.IsNullOrEmpty(txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el sustento del recibo.", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSustento.Select();
                txtSustento.Focus();
                return "ERROR";
            }


            //===========================================================
            //--Valida Monto Maximo de Operacion del concepto de operacion
            //===========================================================
            clsCNControlOpe LisMonto = new clsCNControlOpe();
            DataTable tbMontoConcep = LisMonto.LisMonConcep(clsVarGlobal.nIdAgencia, Convert.ToInt32(this.cboConcepto.SelectedValue));

            if (tbMontoConcep.Rows.Count <= 0)
            {
                MessageBox.Show("No existe monto de validación para el concepto registrado", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboConcepto.Select();
                return "ERROR";
            }

            if (Convert.ToDecimal(txtMontoRecibido.Text.Trim()) > Convert.ToDecimal(tbMontoConcep.Rows[0]["nMontoMax"].ToString()))
            {
                MessageBox.Show("El monto máximo permitido es:  " + tbMontoConcep.Rows[0]["nMontoMax"].ToString() + " .Verique ", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Select();
                txtMontoRecibido.Focus();
            }

            if (cboAgencias.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una agencia destino", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Select();
                cboAgencias.Focus();
                return "ERROR";
            }
            return "OK";
        }
        private void cargarTipoRecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipoRecibo.DataSource = tbTipRec;
            cboTipoRecibo.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipoRecibo.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipoRecibo.SelectedValue = 1;
        }
        private void cargarConceptos(int idTipoRecibo)
        {
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            tbConcep = LisConcep.ListaConceptosPer(idTipoRecibo, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            if (tbConcep.Rows.Count > 1)
            {
                cboConcepto.SelectedIndex = 1;
            }
            else
            {
                cboConcepto.SelectedIndex = 0;
            }
        }
        private int nValidarNivelAutorizacion()
        {
            clsCNControlOpe ValNivAuto = new clsCNControlOpe();
            return ValNivAuto.RetNivelAutorizacion(1, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
        }
        private string validaInicioOperaciones()
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpe(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada            
            return cEstCie;
        }
        private void mostrarDatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }
        private void emitirRecibo()
        {
            if (validarDatosIngresados() == "ERROR")
            {
                this.idResultado = ResultadoServidor.Error;
                return;
            }
            if (Convert.ToDecimal(txtMontoRecibido.Text) <= 0)
            {
                MessageBox.Show("El monto de recibo debe ser mayor a cero...", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoRecibido.Focus();
                this.idResultado = ResultadoServidor.Error;
                return;
            }
            int TipRec = Convert.ToInt32(this.cboTipoRecibo.SelectedValue.ToString());
            int TipCon = Convert.ToInt32(this.cboConcepto.SelectedValue.ToString());
            int idCol;
            int idCli;

            idCli = 0;
            idCol = 0;


            if (!validarReglas())
            {
                this.idResultado = ResultadoServidor.Error;
                return;
            }

            int TipMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMonRec = Convert.ToDecimal(this.txtMontoRecibido.Text);
            Decimal nMonItf = Convert.ToDecimal(this.txtMonItf.Text);
            Decimal nMonTot = Convert.ToDecimal(this.txtTotRec.Text);
            string cSust = this.txtSustento.Text.Trim();
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text.Trim());

            int idAgeOri = clsVarGlobal.nIdAgencia;
            int idAgeDest = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());

            DataTable dtRec = (DataTable)cboConcepto.DataSource;
            bool lAfecCaja = true;

            lAfecCaja = Convert.ToBoolean(dtRec.Rows[cboConcepto.SelectedIndex][6].ToString());
            if (lAfecCaja)
            {
                if (ValidaSaldoLinea(idUsu, idAgeOri, TipMon, TipRec, nMonTot))
                {
                    this.idResultado = ResultadoServidor.Error;
                    return;
                }
            }

            string msg = "";
            clsCNImpresion Imprimir = new clsCNImpresion();
            clsCNControlOpe GuardarRec = new clsCNControlOpe();

            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(idCli, 0, "Inicio  - Emitir Recibos", this.btnEjecutar);
            //==============================================================================

            DataTable dtResul = new DataTable();

            bool lModificaSaldoLinea = lAfecCaja;

            dtResul = GuardarRec.GuardarRecibo(TipRec, TipCon, idCol, this.idCliente, TipMon, nMonRec, nMonItf, nMonTot, cSust, dtpFechaSis.Value, idUsu, idAgeOri, idAgeDest, 0, ref msg, 0, lModificaSaldoLinea, this.idReciboProvisional);

            if (dtResul.Rows.Count > 0)
            {
                this.txtNroRec.Text = dtResul.Rows[0]["cCodRec"].ToString();

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show("El recibo se registró correctamente, NRO RECIBO: " + dtResul.Rows[0]["cCodRec"].ToString(), "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //--Imprimir Voucher 
                int idKardex = Convert.ToInt32(dtResul.Rows[0]["idKardex"]);
                ImpresionVoucher(idKardex, 3, idTipoOperacion, 1, decimal.Zero, decimal.Zero, 0, 1);
                /////////////////////////////////////////////////////////////////////
                clsRespuestaServidor objRespuestaServidor = this.objCNGrupoSolidario.grabarGrupoSolidarioBono(
                    this.lstGrupoSolidarioBono.Find(x=>x.idCli == this.idCliente)
                    );

                this.idResultado = objRespuestaServidor.idResultado;
                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    this.lBonoEntregado = true;
                    MessageBox.Show(objRespuestaServidor.cMensaje, "GRABADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.habilitarControles(clsAcciones.FINALIZAR);
                }
                else
                {
                    this.lBonoEntregado = false;
                    MessageBox.Show(objRespuestaServidor.cMensaje, "ERROR DE GRABADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.idResultado = ResultadoServidor.Error;
                MessageBox.Show(msg, "Error al Registrar el Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(idCli, 0, "Fin - Emitir Recibos", this.btnEjecutar);
            //============================================================================   

        }
        private void formatoMonto()
        {
            if (!string.IsNullOrEmpty(this.txtMontoRecibido.Text.Trim()))
            {
                this.txtMonItf.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal(this.txtMonItf.Text));
                this.txtMontoRecibido.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal(this.txtMontoRecibido.Text));
                this.txtTotRec.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal(this.txtTotRec.Text));
            }
            else
            {
                this.txtMonItf.Text = "0.00";
                this.txtMontoRecibido.Text = "0.00";
                this.txtTotRec.Text = "0.00";
            }

        }
        private void calcularITF()
        {
            if (!string.IsNullOrEmpty(this.txtMontoRecibido.Text.Trim()))
            {
                if (this.txtMontoRecibido.Text.Trim() == ".")
                {
                    this.txtTotRec.Text = "0.00";
                    return;
                }
                Decimal nITF;
                if (nIndAfecITF == 1)
                {
                    nITF = nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * Convert.ToDecimal(this.txtMontoRecibido.Text.ToString().Trim()), 2, (Int32)this.cboMoneda.SelectedValue);
                }
                else
                {
                    nITF = 0;
                }
                this.txtMonItf.Text = string.Format("{0:#,#0.00}", nITF);
                Decimal nSuma = Convert.ToDecimal(this.txtMontoRecibido.Text) + Convert.ToDecimal(this.txtMonItf.Text);
                this.txtMontoRecibido.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal(this.txtMontoRecibido.Text));
                this.txtTotRec.Text = string.Format("{0:#,#0.00}", nSuma);


            }
            else
            {
                this.txtTotRec.Text = "0.00";
                this.txtMontoRecibido.SelectAll();
                this.txtMontoRecibido.Focus();
            }
        }
        private bool validarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = clsVarGlobal.User.idCli;

            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(armarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), 121,
                                                   Decimal.Parse(txtMontoRecibido.Text), x_idCliente, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            if (cCumpleReglas.Equals("ExcepcionRechazada"))
            {
                DataTable dtActVigSolAprobada = ValidaReglasDinamicas.CNUpdVigSolicitudAprob(x_idCliente);
                return false;
            }
            return true;
        }
        private DataTable armarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            string dni = this.txtDocumento.Text;
            string idCli = this.idCliente.ToString();

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = dni == "" ? "0" : dni;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli == "" ? "0" : idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idColaborador";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipRecibo";
            drfila[1] = cboTipoRecibo.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgeDestino";
            drfila[1] = cboAgencias.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idConcepto";
            drfila[1] = cboConcepto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRec";
            drfila[1] = txtMontoRecibido.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtMonItf.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoTotal";
            drfila[1] = txtTotRec.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cSustento";
            drfila[1] = txtSustento.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMontoRecibido.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        #endregion
        
        #endregion      


        #region Eventos
        private void frmGrupoSolidarioEmisionBono_Shown(object sender, EventArgs e)
        {
            this.gestionarGrupoSolidarioBonoEstimado();

            mostrarDatosUsuario();
            idTipoOperacion = 5;
            if (this.ValidarInicioOpeSoloCaja() != "A")
            {
                this.Dispose();
                return;
            }

            cargarTipoRecibos();
            if (this.cboTipoRecibo.SelectedIndex < 0)
            {
                cargarConceptos(0);
            }
            else
            {
                cargarConceptos(Convert.ToInt32(cboTipoRecibo.SelectedValue.ToString().Trim()));
            }

            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
        }
        private void cboTipoRecibo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoRecibo.SelectedValue.ToString() == "1")
            {
                cargarConceptos(1);
                lblAge.Text = "Ag. Origen:";

            }
            else
            {
                cargarConceptos(2);
                lblAge.Text = "Ag. Destino:";
            }
        }
        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtMontoRecibido.Clear();
            this.txtMonItf.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            chcAfectaCaja.Checked = false;
            if (cboConcepto.SelectedIndex > 0)
            {
                chcAfectaCaja.Checked = (bool)tbConcep.Rows[this.cboConcepto.SelectedIndex]["lAfectaCaja"];

                if (Convert.ToDecimal(tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"]) > 0)
                {
                    this.txtMontoRecibido.Enabled = false;
                    this.txtMontoRecibido.BackColor = Color.FromName("Control");
                    this.txtMontoRecibido.Text = tbConcep.Rows[this.cboConcepto.SelectedIndex]["nMontoCon"].ToString();
                    this.calcularITF();
                }
                else
                {
                    this.txtMontoRecibido.Enabled = true;
                    this.txtMontoRecibido.BackColor = Color.White;
                }

            }
            else
            {
            }

            if (this.cboConcepto.SelectedValue.ToString() == "5")
            {
                lblAge.Text = "Ag. Origen:";
            }
            else
            {
                lblAge.Text = "Ag. Destino:";
                this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            }
        }
        private void txtMontoRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.calcularITF();
            }
        }
        private void txtMontoRecibido_Validated(object sender, EventArgs e)
        {
            this.calcularITF();
        }
        private void txtSustento_TextChanged(object sender, EventArgs e)
        {
            txtSustento.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.configurarEmisionRecibo();
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.emitirRecibo();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmGrupoSolidarioEmisionBono_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lBonoEntregado)
            {
                MessageBox.Show("1.- No se ha ejecutado la emisión del Bono.\n" +
                    "2.- Si cierra este formulario no podrá volver a ingresar.\n" +
                    "3.- El bono no podrá ser emitido de ninguna otra forma.\n\n" +
                    "** En caso de que se haya visualizado algún error consulte con el Departamento de Gestión de Sistemas antes de Cerrar este formulario.",
                    "NO ENTREGADO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult idConsulta = MessageBox.Show("¿Usted ha leído el mensaje de advertencia anterior y a pesar de ello desea cerrar este formulario?",
                    "CIERRE FORZADO DE FORMULARIO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (idConsulta == DialogResult.Yes)
                {
                    DialogResult idDecision = MessageBox.Show(
                        "USTED ASUMIRA LA RESPONSABILIDAD DE LOS SIGUIENTES TERMINOS:\n\n" +
                        "1.- No se ha ejecutado la emisión del Bono.\n" +
                        "2.- Al cerrar este formulario no podrá volver a ingresar.\n" +
                        "3.- El bono no podrá ser emitido de ninguna otra forma.\n\n" +
                        "¿Está COMPLETAMENTE de ACUERDO en asumir la RESPONSABILIDAD descrita?"
                        , "ACEPTACION DE RESPONSABILIDAD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (idDecision == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
    }
}
