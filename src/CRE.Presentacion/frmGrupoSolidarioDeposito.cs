using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmGrupoSolidarioDeposito : frmBase
    {
        #region Variables Globales
        private bool lIsAfectoITF;
        private bool lIsDepAhoProg;
        private bool lIsDepMenEdad;
        private bool lisCtaCTS;
        private decimal nMonMinOpe;
        private decimal nMonMinSalDis;
        private int idProducto;
        private int idTipoOperacion;
        private int nPlaCta;
        private int idCuenta;
        private int idCuentaTransferencia;
        private int idSolApr;
        private DataTable dtComision;
        private DataTable dtbAhoPrg;
        private clsCNDeposito clsDeposito;
        private clsFunUtiles FunTruncar;
        private clsCNImpresion clsImpresion;
        private List<clsIntervinienteCuenta> lstIntervinientesCuenta;
        private BindingSource bsIntervinientesCuenta;

        private const int idTipoOpeRegimenReforzado = 175;
        private bool lClienteTitular = true;

        private string cDocumento;
        private int idCliente;
        private int idMoneda;
        private int idTipoPersona;
        private int idTipoCuenta;
        private int idTipoPago;
        private int idMotivoOperacion;
        private decimal nMontoPendiente;
        #endregion

        public frmGrupoSolidarioDeposito()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        public frmGrupoSolidarioDeposito(int idCuentaAhorro, int idCliente, string cDocumento, string cCliente, decimal nMontoPendiente)
        {
            InitializeComponent();
            this.idCuenta = idCuentaAhorro;
            this.idCliente = idCliente;
            this.cDocumento = cDocumento;
            this.lblCliente.Text = cCliente;
            this.nMontoPendiente = nMontoPendiente;
            this.txtMontOpe.Text = nMontoPendiente.ToString("##0.00");            
            this.inicializarDatos();
        }
        #region Metodos
        private void inicializarDatos()
        {
            this.clsDeposito = new clsCNDeposito();
            this.FunTruncar = new clsFunUtiles();
            this.clsImpresion = new clsCNImpresion();
            this.lstIntervinientesCuenta = new List<clsIntervinienteCuenta>();
            this.bsIntervinientesCuenta = new BindingSource();

            this.bsIntervinientesCuenta.DataSource = this.lstIntervinientesCuenta;
            this.dtgIntervinientes.DataSource = this.bsIntervinientesCuenta;

            this.lisCtaCTS = false;
            this.nMonMinOpe = decimal.Zero;
            this.nMonMinSalDis = decimal.Zero;
            this.idProducto = 0;
            this.nPlaCta = 0;
            this.idCuentaTransferencia = 0;
            this.idSolApr = 0;

            this.idTipoPersona = (int)TipoPersona.Natural;
            this.idTipoOperacion = (int)TipoOperacion.Deposito;
            this.idTipoPago = (int)TipoPago.Efectivo;
            this.idMotivoOperacion = (int)MotivoOperacion.DepositoNormal;
            this.idMoneda = (int)Monedas.Soles;

            this.cboMoneda.SelectedValue = this.idMoneda;
            cargarModalidadDeposito();
            this.cboTipoPago.SelectedValue = this.idTipoPago;
            this.cboMotivoOperacion.SelectedIndexChanged -= new EventHandler(cboMotivoOperacion_SelectedIndexChanged);
            this.cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            this.cboMotivoOperacion.SelectedIndexChanged += new EventHandler(cboMotivoOperacion_SelectedIndexChanged);
            this.cboMotivoOperacion.SelectedValue = this.idMotivoOperacion;
            
            conSolesDolar.iMagenMoneda(this.idMoneda);
            this.formatearIntervinientes();
        }
        private void formatearIntervinientes()
        {
            foreach (DataGridViewColumn dgvColumn in this.dtgIntervinientes.Columns)
            {
                dgvColumn.Visible = false;
                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            this.dtgIntervinientes.Columns["cTipoDocumento"].Visible = true;
            this.dtgIntervinientes.Columns["cDocumentoID"].Visible = true;
            this.dtgIntervinientes.Columns["cNombre"].Visible = true;
            this.dtgIntervinientes.Columns["lCliAfeITF"].Visible = true;
            this.dtgIntervinientes.Columns["isReqFirma"].Visible = true;

            this.dtgIntervinientes.Columns["cTipoDocumento"].HeaderText = "Tipo Doc.";
            this.dtgIntervinientes.Columns["cDocumentoID"].HeaderText = "Documento";
            this.dtgIntervinientes.Columns["cNombre"].HeaderText = "Nombre Cliente";
            this.dtgIntervinientes.Columns["lCliAfeITF"].HeaderText = "ITF";
            this.dtgIntervinientes.Columns["isReqFirma"].HeaderText = "Firma";

            int i = 0;
            this.dtgIntervinientes.Columns["cTipoDocumento"].DisplayIndex = i++;
            this.dtgIntervinientes.Columns["cDocumentoID"].DisplayIndex = i++;
            this.dtgIntervinientes.Columns["cNombre"].DisplayIndex = i++;
            this.dtgIntervinientes.Columns["lCliAfeITF"].DisplayIndex = i++;
            this.dtgIntervinientes.Columns["isReqFirma"].DisplayIndex = i++;
        }
        private void habilitarControles(int idAccion)
        {
            conDatPerReaOperac.Enabled = false;
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    conDatPerReaOperac.txtDocIdePerson.Enabled = false;
                    txtMontOpe.Enabled = false;
                    cboTipoPago.Enabled = false;
                    conCalcVuelto.Enabled = false;
                    btnGrabar.Enabled = false;
                    dtgIntervinientes.AutoGenerateColumns = false;
                    break;
                case clsAcciones.GRABAR:
                    txtMontOpe.Enabled = false;
                    cboTipoPago.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnComision.Enabled = false;
                    conCalcVuelto.Enabled = false;
                    conDatPerReaOperac.txtDocIdePerson.Enabled = false;
                    cboMotivoOperacion.Enabled = false;
                    break;
                case clsAcciones.RECUPERAR:
                    txtMontOpe.Enabled = true;
                    cboTipoPago.Enabled = false;
                    cboMotivoOperacion.Enabled = false;
                    btnGrabar.Enabled = true;
                    txtMontOpe.Select();
                    txtMontOpe.Focus();
                    break;
                case clsAcciones.CANCELAR:
                    txtMontOpe.Enabled = false;
                    btnComision.Enabled = false;
                    btnGrabar.Enabled = false;
                    conCalcVuelto.Enabled = false;
                    cboTipoPago.Enabled = false;
                    cboMotivoOperacion.Enabled = false;
                    break;
            }
        }
        private void cargarModalidadDeposito()
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(idTipoOperacion);
            if (dt.Rows.Count > 0)
            {
                this.cboTipoPago.SelectedIndexChanged -= new EventHandler(cboTipoPago_SelectedIndexChanged);
                this.cboTipoPago.DataSource = dt;
                this.cboTipoPago.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboTipoPago.DisplayMember = dt.Columns["cDescripcion"].ToString();
                this.cboTipoPago.SelectedIndexChanged += new EventHandler(cboTipoPago_SelectedIndexChanged);
            }
            else
            {
                MessageBox.Show("No existen modalidades de pago, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool validarDatosDeposito()
        {
            int idModalidadPago = this.idTipoPago;
            switch (idModalidadPago)
            {
                case 1: //--Pago En Efectivo
                    if (string.IsNullOrEmpty(txtMontOpe.Text))
                    {
                        MessageBox.Show("Debe ingresar el monto a depositar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El monto a depositar no puede ser menor o igual cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    break;
                default: //--Otros Tipos de Pago
                    if (string.IsNullOrEmpty(txtMontOpe.Text))
                    {
                        MessageBox.Show("Debe ingresar el monto a depositar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El monto de la operación no puede ser menor o igual cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    break;
            }
            return true;
        }
        private void calcularItfComisionImpuesto()
        {
            decimal nMonto;
            decimal nMonFavCli = 0.00m;
            if (this.idCuenta <= 0)
            {
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtMontOpe.Text))
                {
                    nMonto = 0;
                    this.txtMontOpe.Text = nMonto.ToString();
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    this.txtMontOpe.SelectAll();
                    return;
                }
                else
                {
                    nMonto = Convert.ToDecimal(this.txtMontOpe.Text);
                    if (nMonto == 0)
                    {
                        this.txtMontOpe.SelectAll();
                        this.txtMontOpe.Focus();
                        this.txtComision.Text = "0.00";
                        this.txtImpuesto.Text = "0.00";
                        this.txtRedondeo.Text = "0.00";
                        this.txtMontTotal.Text = "0.00";
                        this.txtMontEnt.Text = "0.00";
                        return;
                    }

                    //--==========================================================
                    //--Calcular Comisiones de la Cuenta
                    //--==========================================================
                    cargarComisionesCuenta();
                    decimal nComision = Convert.ToDecimal(txtComision.Text);

                    decimal nITF;
                    if (!lIsAfectoITF)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        nITF = FunTruncar.truncar((decimal)clsVarGlobal.nITF / 100.00m * (decimal)nMonto, 2, this.idMoneda);
                    }

                    this.txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtComision.Text = string.Format("{0:#,#0.00}", Math.Round(nComision, 2));
                    decimal nMontoTotal = 0;

                    nMontoTotal = (decimal)nMonto - Math.Round(nITF, 2) - (decimal)Math.Round(nComision, 2);
                    if (this.idTipoPago == 1)  //Modalidad en Efectivo
                    {
                        nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, this.idMoneda, true, true);
                    }

                    this.txtMontTotal.Text = string.Format("{0:#,#0.00}", (nMontoTotal + Math.Round(nMonFavCli, 2)));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((decimal)nMonto - nMonFavCli));
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));

                    this.txtMontOpe.Text = string.Format("{0:#,#0.00}", nMonto);

                    if (this.idTipoPago == 1)
                    {
                        if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMontEnt.Text.Trim()))
                        {
                            conCalcVuelto.limpiar();
                        }
                        conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMontEnt.Text.Trim());
                        conCalcVuelto.Enabled = true;
                        conCalcVuelto.CalculoDirecto(Convert.ToDecimal(txtMontEnt.Text.Trim()));
                        conCalcVuelto.txtMonEfectivo.Focus();
                        conCalcVuelto.txtMonEfectivo.SelectAll();
                    }
                }
            }

        }
        private int obtenerIdClienteITF()
        {
            clsIntervinienteCuenta objIntervinienteCuenta = this.lstIntervinientesCuenta.Find(x=>x.lCliAfeITF == true);
            return (objIntervinienteCuenta != null) ? objIntervinienteCuenta.idCli : 0;
        }
        private void obtenerDatosCuenta(int idCuenta)
        {
            //--===================================================================================
            //--Validar Bloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCuenta, idTipoOperacion, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                limpiarOtrosCtrl();
                return;
            }

            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCuenta, "1", idTipoOperacion);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"]);
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La cuenta está siendo consultada por otro usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    limpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                switch (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"]))
                {
                    case 4:
                        MessageBox.Show("La cuenta se encuentra inmovilizada, no puede realizar operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                        limpiarOtrosCtrl();
                        this.habilitarControles(clsAcciones.DEFECTO);
                        return;
                    case 5:
                        MessageBox.Show("La cuenta se encuentra vencida, no puede realizar operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                        limpiarOtrosCtrl();
                        this.habilitarControles(clsAcciones.DEFECTO);
                        return;
                }

                this.idProducto = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"]);
                this.idMoneda = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"]);
                this.idTipoCuenta = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"]);
                this.idTipoPersona = Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoPersona"]);

                this.txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                this.txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                this.lIsAfectoITF = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"]);
                this.nMonMinOpe = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nMonMinOpe"]);
                this.lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"]);
                this.lisCtaCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"]);
                this.nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"]);
                this.nMonMinSalDis = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nSaldoDis"]);
                this.lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"]);

                this.cboMoneda.SelectedValue = this.idMoneda;
                this.cboTipoCuenta.SelectedValue = this.idTipoCuenta;
                this.cboTipoPersona.SelectedValue = this.idTipoPersona;

                this.habilitarControles(clsAcciones.RECUPERAR);
            }
            else
            {
                this.habilitarControles(clsAcciones.DEFECTO);
                clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                limpiarOtrosCtrl();
                MessageBox.Show("Inconsistencias en sus datos, por favor revisar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            this.lstIntervinientesCuenta.Clear();
            this.lstIntervinientesCuenta.AddRange(this.clsDeposito.listarIntervinientesCuenta(idCuenta));
            this.bsIntervinientesCuenta.ResetBindings(false);
            this.dtgIntervinientes.Refresh();

            if (this.lstIntervinientesCuenta.Count > 0)
            {
                
            }
            else
            {
                MessageBox.Show("La cuenta no tiene intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                limpiarCtrl();
                limpiarOtrosCtrl();
                this.habilitarControles(clsAcciones.DEFECTO);
                return;
            }

            //--===================================================================================
            //--Cargar Datos si es Ahorro Programado
            //--===================================================================================
            if (lIsDepAhoProg)
            {
                dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(idCuenta, 1);
                if (dtbAhoPrg.Rows.Count > 0)
                {
                    txtMontOpe.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    this.habilitarControles(clsAcciones.RECUPERAR);
                    txtMontOpe.Select();
                    txtMontOpe.Focus();
                }
                else
                {
                    MessageBox.Show("La cuenta no tiene cronograma de depósitos...VERIFICAR...", "VALIDAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCuenta);
                    limpiarCtrl();
                    limpiarOtrosCtrl();
                    this.habilitarControles(clsAcciones.DEFECTO);
                    return;
                }
            }

            if (this.idMoneda == 1)
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontEnt.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
            else
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGreen;
                txtMontEnt.BackColor = System.Drawing.Color.LightGreen;
            }
            conSolesDolar.iMagenMoneda(this.idMoneda);

            if (this.idTipoPersona == (int)TipoPersona.Natural && this.lClienteTitular) //--Solo si es persona natural
            {
                conDatPerReaOperac.txtDocIdePerson.Text = this.cDocumento;
            }
            conDatPerReaOperac.txtDocIdePerson.Enabled = true;

        }
        private void cargarComisionesCuenta()
        {
            dtComision = null;
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            decimal nMonto = Convert.ToDecimal(txtMontOpe.Text);

            dtComision = clsBloq.RetornaComisionesCtaOpe(this.idProducto, idTipoOperacion, this.idTipoPersona, this.idMoneda,
                                                        this.idCuenta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCta, this.idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                decimal nTotCom = Convert.ToDecimal(dtComision.Compute("SUM(nValorAplica)", ""));
                txtComision.Text = nTotCom.ToString();
                btnComision.Enabled = true;
            }
            else
            {
                txtComision.Text = "0.00";
                btnComision.Enabled = false;
            }
        }
        private void limpiarCtrl()
        {
            //--Datos de la Cuenta
            this.idCuenta = 0;
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            cboTipoPersona.SelectedValue = 1;
            txtNumFirmas.Text = "0";
            //--Datos de Montos
            txtMontOpe.Text = "0.00";
            txtComision.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtMontTotal.Text = "0.00";
            txtMontEnt.Text = "0.00";

            //--Datos de Tipos de pago
            cboTipoPago.SelectedValue = 1;

            //--Datos del Cliente
            this.lstIntervinientesCuenta.Clear();
            this.dtgIntervinientes.Refresh();

            //Limpiar Datos Cli Ope
            conDatPerReaOperac.txtDocIdePerson.Text = "";
            conDatPerReaOperac.txtNombrePerson.Text = "";
            conDatPerReaOperac.txtDireccPerson.Text = "";
            //Limpiar Datos Ope Transferencia
        }
        private void limpiarOtrosCtrl()
        {
            this.idCuenta = 0;
            this.idCliente = 0;
            conCalcVuelto.limpiar();
        }
        private bool validarReglas()
        {
            String cCumpleReglas = "";
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(armarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, this.idCliente,
                                                   1, this.idMoneda, this.idProducto,
                                                   decimal.Parse(txtMontOpe.Text), this.idCuenta, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }
        private bool validarDatCliOpe()
        {
            if (conDatPerReaOperac.txtDocIdePerson.Text.Trim().Length != 8)
            {
                MessageBox.Show("Debe registrar el DNI de forma correcta (8 dígitos)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
            {
                MessageBox.Show("Debe registrar el nombre del cliente que realiza la operación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtNombrePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
            {
                MessageBox.Show("Debe registrar la dirección del cliente que realiza la operación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDireccPerson.Focus();
                return false;
            }
            if (conDatPerReaOperac.idCli == clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El Cliente que realiza la operación, no puede ser el mismo Usuario", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            return true;
        }
        private bool validarReglasNivelApr()
        {
            string cCumpleReglas = "";
            idSolApr = 0;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(armarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, this.idCliente,
                                                   1, this.idMoneda, this.idProducto,
                                                   decimal.Parse(txtMontOpe.Text), this.idCuenta, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref idSolApr);
            if (cCumpleReglas.Equals("NoCumple"))
            {

                return false;
            }
            return true;
        }
        private void actualizarNivelApr(int idSolApr)
        {
            if (idSolApr > 0)
            {
                clsCNValidaReglasDinamicas ActNivelApr = new clsCNValidaReglasDinamicas();
                ActNivelApr.ActualizaSolicitudApr(idSolApr, 3);
            }
        }
        private DataTable armarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = this.cDocumento;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dniCliOpe";
            drfila[1] = conDatPerReaOperac.txtDocIdePerson.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = this.idCuenta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = this.idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = this.idMoneda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lReqAutorizacion";
            drfila[1] = ((DataRowView)cboMotivoOperacion.SelectedItem)["lReqAutorizacion"].ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMotivoOperacion";
            drfila[1] = cboMotivoOperacion.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lisCtaCTS";
            drfila[1] = lisCtaCTS.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = dtgIntervinientes.Rows.Count.ToString();
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
            drfila[0] = "idTipCuenta";
            drfila[1] = this.idTipoCuenta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonSalDis";
            drfila[1] = nMonMinSalDis.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = idTipoOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNumFirmas.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = cboTipoPersona.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = this.idTipoPago.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMontOpe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoComision";
            drfila[1] = txtComision.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtImpuesto.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = txtRedondeo.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoDeposito";
            drfila[1] = txtMontTotal.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRecibir";
            drfila[1] = txtMontEnt.Text.Replace(",", "");
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
            drfila[0] = "idCli";
            drfila[1] = Convert.ToString(this.idCliente);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        public void emitirVoucher(DataTable dtDatosCobro, int idKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        #endregion

        #region Eventos
        private void frmGrupoSolidarioDeposito_Shown(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            //---------------------------------------------------
            //--Validar si se va a Trabajar con Tarjetas o NO.
            //---------------------------------------------------
            if (clsVarApl.dicVarGen["nIndTrabTarj"] == 1)
            {
                this.Text = "Deposito de Ahorros (Presione F5 para Trabajar con Tarjetas)";
            }
            else
            {
                this.Text = "Deposito de Ahorros";
            }


            /*========================================================================================
            * INICO - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
            ========================================================================================*/
            DataTable dtResValidacionCuenta = clsDeposito.CNAWValidarCuentaAperturada(this.idCuenta);
            if (dtResValidacionCuenta.Rows.Count == 1)
            {
                frmAWValidarCuenta frmAWValidarCuenta = new frmAWValidarCuenta(this.idCuenta, (int)Modulo.AHORROS, this.cDocumento, dtResValidacionCuenta);

                if (!frmAWValidarCuenta.validarCuentaAperturada())
                {
                    DialogResult drResult = MessageBox.Show("¿El cliente es titular de la cuenta?", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (drResult == DialogResult.Yes)
                    {
                        frmAWValidarCuenta.ShowDialog();
                        if (frmAWValidarCuenta.lCancelado)
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cuenta aperturada en línea. El cliente titular aún no ha efectuado la firma de los documentos contractuales.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            /*========================================================================================
            * FIN - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
            ========================================================================================*/

            if (this.idCuenta > 0)
            {
                this.obtenerDatosCuenta(this.idCuenta);
            }
        }

        private void txtMontOpe_TextChanged(object sender, EventArgs e)
        {
            double nMontoLimite = Math.Ceiling(Convert.ToDouble(this.nMontoPendiente * 1.50M));
            if (string.IsNullOrEmpty(txtMontOpe.Text) || txtMontOpe.Text == "0")
            {
                this.txtComision.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.txtMontTotal.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontEnt.Text = "0.00";                
            }
            else if (this.nMontoPendiente > decimal.Zero && this.txtMontOpe.nvalor > nMontoLimite)
            {
                MessageBox.Show("¡El MONTO máximo permitido para este depósito es de " + nMontoLimite.ToString("###,###,##0.00") + " !",
                    "MONTO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMontOpe.TextChanged -= this.txtMontOpe_TextChanged;
                this.txtMontOpe.KeyPress -= this.txtMontOpe_KeyPress;
                this.txtMontOpe.Leave -= this.txtMontOpe_Leave;
                this.txtMontOpe.Text = this.nMontoPendiente.ToString();
                this.txtMontOpe.Focus();
                this.txtMontOpe.KeyPress += this.txtMontOpe_KeyPress;
                this.txtMontOpe.Leave += this.txtMontOpe_Leave;
                this.txtMontOpe.TextChanged += this.txtMontOpe_TextChanged;
            }
        }
        private void txtMontOpe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcularItfComisionImpuesto();
            }
        }
        private void txtMontOpe_Leave(object sender, EventArgs e)
        {
            calcularItfComisionImpuesto();
        }
        private void btnComision_Click(object sender, EventArgs e)
        {
            
        }
        private void frmDepositoAho_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (idCuenta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(idCuenta);
            }
            if (idCuentaTransferencia > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(idCuentaTransferencia);
            }
        }
        /*private void txtMontOpe_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontOpe.Text) || txtMontOpe.Text == "0")
            {
                this.txtComision.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.txtMontTotal.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontEnt.Text = "0.00";
            }
        }
        private void txtMontOpe_Leave_1(object sender, EventArgs e)
        {
            calcularItfComisionImpuesto();
        }
        private void txtMontOpe_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcularItfComisionImpuesto();
            }
        }*/
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNroDocu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.idTipoPago == 5)
            {
                if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.idTipoPago == 5)
            {
                if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }


        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPago.SelectedIndex == -1)
            {
                this.idTipoPago = 0;
                return;
            }
            else
            {
                this.idTipoPago = Convert.ToInt32(this.cboTipoPago.SelectedValue);
            }

            btnGrabar.Enabled = true;

            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;

            if (this.idTipoPago > 0)
            {
                cboTipoPago.Enabled = true;
                decimal nMontoDoc = Convert.ToDecimal(txtMontOpe.Text);
                switch (this.idTipoPago)
                {
                    case 1: //--Pago En Efectivo

                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                }
            }

            if (this.idCuenta > 0)
            {
                calcularItfComisionImpuesto();
            }
        }
        private void cboMotivoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboMotivoOperacion.SelectedIndex == -1)
            {
                this.idMotivoOperacion = 0;
            }
            else
            {
                this.idMotivoOperacion = Convert.ToInt32(this.cboMotivoOperacion.SelectedValue);
            }
        }
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboMoneda.SelectedIndex == -1)
            {
                this.idMoneda = 0;
            }
            else
            {
                this.idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue);
            }

        }
        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoPersona.SelectedIndex == -1)
            {
                this.idTipoPersona = 0;
            }
            else
            {
                this.idTipoPersona = Convert.ToInt32(this.cboTipoPersona.SelectedValue);
            }
        }
        private void cboTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoCuenta.SelectedIndex == -1)
            {
                this.idTipoCuenta = 0;
            }
            else
            {
                this.idTipoCuenta = Convert.ToInt32(this.cboTipoCuenta.SelectedValue);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.idMotivoOperacion == 0)
            {
                MessageBox.Show("Debe Seleccionar el Motivo de la Operación...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return;
            }
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            int idCliValid = 0;
            clsIntervinienteCuenta objIntervinienteCuenta = this.lstIntervinientesCuenta.Where(x => x.isReqFirma).OrderBy(x => x.idCli).FirstOrDefault();
            idCliValid = (objIntervinienteCuenta != null) ? objIntervinienteCuenta.idCli : 0;

            List<clsIntervinienteCuenta> lstTitulares = this.lstIntervinientesCuenta.Where(x => x.idTipoInterv == 6).ToList();
            clsValidacionPreviaOpe objValidaciones = new clsValidacionPreviaOpe(idCliValid, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, this.idTipoOperacion, idCliValid);


            if (objValidaciones.verificPararOperacion())
            {
                return;
            }


            /*========================================================================================
                * REGISTRO DE RASTREO
            ========================================================================================*/

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (Convert.ToDecimal(txtMontOpe.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontOpe.Focus();
                return;
            }
            if (!this.validarDatosDeposito())
            {
                return;
            }
            if (!validarDatCliOpe())
            {
                return;
            }
            decimal nMonOpeVal = Convert.ToDecimal(this.txtMontOpe.Text);
            if (nMonOpeVal < nMonMinOpe)
            {
                MessageBox.Show("El Monto Mínimo de Operación Debe Ser: " + nMonMinOpe.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMontOpe.SelectAll();
                this.txtMontOpe.Focus();
                this.txtComision.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontTotal.Text = "0.00";
                this.txtMontEnt.Text = "0.00";
                return;
            }


            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            int nNumSolAprobRegimen = 0;
            foreach (clsIntervinienteCuenta objTitular in lstTitulares)
            {
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(objTitular.idCli,
                                                                               this.idMoneda,
                                                                               this.idProducto,
                                                                               this.idCuenta,
                                                                               Convert.ToDecimal(txtMontEnt.Text));
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                    nNumSolAprobRegimen++;
            }

            if (nNumSolAprobRegimen > 0)
            {
                return;
            }


            decimal nMonOpe = Convert.ToDecimal(this.txtMontEnt.Text),
                    nMonRedondeo = Convert.ToDecimal(txtRedondeo.Text),
                    nMonCapital = Convert.ToDecimal(txtMontTotal.Text);
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            decimal nMonComis = Convert.ToDecimal(txtComision.Text);
            decimal nMonITF = Convert.ToDecimal(txtImpuesto.Text);

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!validarReglasNivelApr())
            {
                return;
            }

            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = nMonOpe;
            int idMonedaUm = this.idMoneda;
            int idMotivoOpe = this.idMotivoOperacion;
            int idSubProducto = this.idProducto;
            int idTipoPago = this.idTipoPago;
            int idTipoOperacion = 10;

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion
            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();
            //--Asignar Datos Para Registrar Apertura

            if (this.idTipoPago >= 2)  //Pago con documentos, Cheque, interbancario, ordpag, etc
            {
                switch (this.idTipoPago)
                {

                    default:
                        drPag["idTipoValorado"] = this.idTipoPago; //--Otros Tipos de Pago
                        drPag["cNroDocumento"] = "000";
                        drPag["cSerieDocumento"] = "0";
                        drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = 0;
                        drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                        drPag["nNroFolio"] = "0";
                        break;
                }

                dtPag.Rows.Add(drPag);
            }
            //--Generar XML de Datos del Tipo de Pago
            DataSet dsTipPago = new DataSet("dsDeposito");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dsComision = new DataSet("dsDeposito");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

            //--====================================================
            //--Variables Adicionales
            //--====================================================
            int idEntFin = clsVarApl.dicVarGen["idInstFin"];


            //--==================================================
            //--Si tipo de Pago es por Transferencia
            //--==================================================
            int idCtaTrans = 0;
            switch (this.idTipoPago)  //--Modificado
            {
                default:
                    idCtaTrans = 0;
                    break;
            }

            //--==================================================
            //--id Cliente Afe ITF
            //--==================================================
            int idCliITF = obtenerIdClienteITF(),
                idCanal = 1;


            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!validarReglas())
            {
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }

            //----------------------------------------------------------------------------------
            //--valida Saldos de Caja
            //----------------------------------------------------------------------------------
            if (Convert.ToInt16(cboTipoPago.SelectedValue) == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, this.idMoneda, 1, nMonOpe))
                {
                    dsComision.Tables.Clear();
                    dsComision.Dispose();
                    dsTipPago.Tables.Clear();
                    dsTipPago.Dispose();
                    return;
                }
            }

            //--===============================================================
            //--Cliente que Realiza la Operación
            //--===============================================================
            string cCdniCliOpe = conDatPerReaOperac.txtDocIdePerson.Text.Trim(),
                    cNomCliOpe = conDatPerReaOperac.txtNombrePerson.Text.Trim(),
                    cDirCliOpe = conDatPerReaOperac.txtDireccPerson.Text.Trim();

            int idKardex = 0;

            //--===============================================================
            //--Registrar Operación de Deposito
            //--===============================================================
            int nCuota = 0;
            string cNroDocPag = "0";

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 1; //INGRESO

            if (this.idTipoPago.In(1, 5))
                lModificaSaldoLinea = true;

            DataTable tbRegApe = clsDeposito.CNRegistraDepositoAHO(xmlTipPago, xmlComision, this.idCuenta, nMonOpe, this.idMoneda, nMonComis, nMonITF, nMonRedondeo, nMonCapital, clsVarGlobal.User.idUsuario,
                                                                clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nCuota, this.idProducto, lIsDepAhoProg, cNroDocPag,
                                                                idEntFin, idCtaTrans, this.idTipoPago, idCliITF, cCdniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, this.idMotivoOperacion,
                                                                idTipoTransac, lModificaSaldoLinea);
            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"]) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE OPERACIÓN: " + tbRegApe.Rows[0]["idNroOpe"].ToString(), "Deposito a Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idKardex = Convert.ToInt32(tbRegApe.Rows[0]["idNroOpe"].ToString());
            }
            else
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Deposito Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }


            conDatPerReaOperac.DesabilitarCtrls();
            dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(this.idCuenta, 1);

            if (dtbAhoPrg.Rows.Count > 0)
            {
                txtMontOpe.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                btnGrabar.Enabled = true;
                txtMontOpe.Select();
                txtMontOpe.Focus();
            }

            actualizarNivelApr(idSolApr);
            this.habilitarControles(clsAcciones.GRABAR);
            clsDeposito.CNUpdNoUsoCuenta(idCuenta);

            if (this.idTipoPago.In(1, 2, 5, 4))
            {
                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);
            }

            //--------------------------------------------------------------------
            //Impresion del voucher
            //--------------------------------------------------------------------
            if (idKardex > 0)
            {
                ImpresionVoucher(idKardex, clsVarGlobal.idModulo, idTipoOperacion, 1, Convert.ToDecimal(conCalcVuelto.txtMonEfectivo.Text), Convert.ToDecimal(conCalcVuelto.txtMonDiferencia.Text), 0, 1);
            }

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            dsComision.Tables.Clear();
            dsComision.Dispose();
            dsTipPago.Tables.Clear();
            dsTipPago.Dispose();
        }
        #endregion

    }
}
