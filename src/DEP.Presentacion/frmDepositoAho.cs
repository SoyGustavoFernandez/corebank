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
using CLI.Presentacion;
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmDepositoAho : frmBase
    {
        bool lIsAfectoITF, lIsDepAhoProg, lIsDepMenEdad, lisCtaCTS = false;
        Decimal nMonMinOpe = 0.00m, nMonMinSalDis = 0.00m;
        int idProd = 0, x_nTipOpe = 0, nPlaCta = 0, p_idCta = 0, p_idCtaTranf = 0, p_idCta1 = 0, idSolApr = 0;
        DataTable dtComision;
        DataTable dtbIntervCta;
        DataTable dtbAhoPrg;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNImpresion clsImpresion = new clsCNImpresion();
        clsCNCliente cliente = new clsCNCliente();

        private const int idTipoOpeRegimenReforzado = 175;

        int nCodModPago = 1;

        private bool lClienteTitular = true;
        public frmDepositoAho()
        {
            InitializeComponent();
        }

        private void frmDepositoAho_Load(object sender, EventArgs e)
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

            x_nTipOpe = 10;  //--Operación de Deposito
            CargarModalidadPago();
            conSolesDolar.iMagenMoneda(0);
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            txtMontOpe.Enabled = false;
            cboModPago.Enabled = false;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            conBusCtaAho.nTipOpe = x_nTipOpe;  //--Operación de Deposito
            conBusCtaAhoTransf.p_idTipOpePrincipal = x_nTipOpe; //Indica la Operación Principal
            conBusCtaAho.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            conCalcVuelto.Enabled = false;
            this.cboMotivoOperacion.ListarMotivoOperacion(x_nTipOpe, clsVarGlobal.PerfilUsu.idPerfil);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
            btnGrabar.Enabled = false;
            dtgIntervinientes.AutoGenerateColumns = false;
            lblSegmento.Text = string.Empty;
        }

        //==========================================================
        //--Cargar Modalidades de Pago--> Deposito
        //==========================================================
        private void CargarModalidadPago()
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(x_nTipOpe);
            if (dt.Rows.Count > 0)
            {
                this.cboModPago.DataSource = dt;
                this.cboModPago.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboModPago.DisplayMember = dt.Columns["cDescripcion"].ToString();
            }
            else
            {
                MessageBox.Show("No Existe Modalidades de Pago, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //==========================================================
        //--Limpiar los Tipos de Pago
        //==========================================================
        private void LimpiarTiposdePago()
        {
            conBusCtaAhoTransf.LimpiarControles();
            txtNroCta.Text = "";
            txtcNroCuenta.Clear();
            txtNroDocu.Text = "";
            txtSerie.Text = "";
            txtDiaVal.Text = "0";
        }

        //====================================================
        //---Validar Datos Tipos de Pago
        //====================================================
        private bool ValidarDatosTipPago()
        {
            int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
            switch (nCodModPago)
            {
                case 1: //--Pago En Efectivo
                    if (string.IsNullOrEmpty(txtMontOpe.Text))
                    {
                        MessageBox.Show("Debe Ingresar el Monto a Depositar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El Monto a Depositar no puede ser menor o Igual Cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    break;
                case 2: //--Pago con Transferencia
                    if (string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Vincular con la Cuenta del Cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }
                    if (conBusCtaAhoTransf.idcuenta <= 0)
                    {
                        MessageBox.Show("Debe Vincular con la Cuenta del Cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }
                    if (Convert.ToInt32(conBusCtaAhoTransf.txtCodCli.Text) == Convert.ToInt32(clsVarGlobal.User.idCli))
                    {
                        MessageBox.Show("El mismo Usuario, No puede realizar Transferencias hacia sus Cuentas", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }
                    break;
                case 3: //--Deposito Con Cheque
                    if (cboTipoEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar el Tipo de Entidad Financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboTipoEnt.Focus();
                        return false;
                    }
                    if (cboEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar la Entidad Financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEnt.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe Registrar la Serie del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();
                        return false;
                    }

                    if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La Fecha de Emisión del Documento no Puede ser Posterior a la Fecha del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    TimeSpan sDifFec = clsVarGlobal.dFecSystem - dtpFecDoc.Value;
                    if (sDifFec.Days > clsVarApl.dicVarGen["nDiasVigenciaCheque"])
                    {
                        MessageBox.Show("El Documento, ya se encuentra Vencido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }
                    if (clsVarApl.dicVarGen["nDiasVigenciaCheque"] - sDifFec.Days < clsVarApl.dicVarGen["nDiasVcmtoCheque"])
                    {
                        MessageBox.Show("El Número de Días por Vencer no debe ser menor a: " + Convert.ToString(clsVarApl.dicVarGen["nDiasVcmtoCheque"]) + " Días", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDiaVal.Focus();
                        txtDiaVal.Select();
                        return false;
                    }

                    if (Convert.ToDecimal(txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 4: //--Deposito Interbancario
                    if (cboEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar la Entidad Financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEnt.Focus();
                        return false;
                    }
                    if (cboCuenta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar una Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCuenta.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe Registrar la Serie del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();
                        return false;
                    }
                    if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La Fecha de Emisión del Documento no Puede ser Posterior a la Fecha del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (Convert.ToDecimal(txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 5: //--Orden de Pago
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de Cuenta de la Orden de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        txtNroCta.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe Registrar la Serie de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();
                        return false;
                    }

                    if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La Fecha de Emisión del Documento no Puede ser Posterior a la Fecha del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    TimeSpan sDifFecOP = clsVarGlobal.dFecSystem - dtpFecDoc.Value;
                    if (sDifFecOP.Days > clsVarApl.dicVarGen["nDiasVigenciaCheque"])
                    {
                        MessageBox.Show("La Orden de Pago, ya se encuentra Vencido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtFolio.Text))
                    {
                        MessageBox.Show("El número de Folio no Existe para la Orden de Pago...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFolio.Focus();
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDiaVal.Focus();
                        txtDiaVal.Select();
                        return false;
                    }

                    if (Convert.ToDecimal(txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 6: //--Retiro con Cheque de Gerencia
                    if (string.IsNullOrEmpty(txtNroCuentaGer.Text))
                    {
                        MessageBox.Show("Número de Cuenta no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroCheqGer.Text))
                    {
                        MessageBox.Show("Número de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerieCheqGer.Text))
                    {
                        MessageBox.Show("Número de Serie de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }

                    if (cboEntidadCheGer.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe estar Seleccionado la Entidad Financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEntidadCheGer.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMontoCheGer.Text))
                    {
                        MessageBox.Show("Monto de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (Convert.ToDecimal(txtMontoCheGer.Text) <= 0)
                    {
                        MessageBox.Show("El Monto de Cheque no Puede ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (Convert.ToDecimal(txtMontoCheGer.Text) != Convert.ToDecimal(txtMontEnt.Text))
                    {
                        MessageBox.Show("El Monto de Cheque no Puede ser Diferente al Monto del Retiro", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (dtpFecCheqGer.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La Fecha de Emisión del Documento no Puede ser Posterior a la Fecha del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecCheqGer.Focus();
                        dtpFecCheqGer.Select();
                        return false;
                    }
                    break;
                default: //--Otros Tipos de Pago
                    if (string.IsNullOrEmpty(txtMontOpe.Text))
                    {
                        MessageBox.Show("Debe Ingresar el Monto a Depositar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El Monto de la Operación no puede ser Menor o Igual Cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    break;
            }
            return true;
        }

        //--====================================================================================
        //--Calcular Itf, Comisiones
        //--====================================================================================
        private void calcular()
        {
            decimal nMonto;
            Decimal nMonFavCli = 0.00m;
            if (string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text.ToString()))
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
                    nMonto = Convert.ToDecimal(this.txtMontOpe.Text.ToString());

                    /*
                    if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad en Efectivo
                    {
                        nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                        //nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    }

                    this.txtMontOpe.KeyPress -= txtMontOpe_KeyPress_1;
                    this.txtMontOpe.Leave -= txtMontOpe_Leave_1;
                    this.txtMontOpe.TextChanged -= txtMontOpe_TextChanged_1;

                    this.txtMontOpe.nDecValor = nMonto;

                    this.txtMontOpe.KeyPress += txtMontOpe_KeyPress_1;
                    this.txtMontOpe.Leave += txtMontOpe_Leave_1;
                    this.txtMontOpe.TextChanged += txtMontOpe_TextChanged_1;
                     * */

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
                    Comision();
                    Decimal nComision = Convert.ToDecimal(txtComision.Text);

                    Decimal nITF;
                    if (!lIsAfectoITF)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, (Int32)this.cboMoneda.SelectedValue);
                    }

                    //--Transferencias, entre las mismas Cuentas, no debe calcular Itf
                    if (Convert.ToInt32(cboModPago.SelectedValue) == 2 && rbtMismaCta.Checked == true) //--Transferencias
                    {
                        nITF = 0.00m;
                    }

                    this.txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtComision.Text = string.Format("{0:#,#0.00}", Math.Round(nComision, 2));
                    Decimal nMontoTotal = 0;

                    nMontoTotal = (Decimal)nMonto - Math.Round(nITF, 2) - (Decimal)Math.Round(nComision, 2);
                    if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad en Efectivo
                    {
                        nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                        //nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    }

                    this.txtMontTotal.Text = string.Format("{0:#,#0.00}", (nMontoTotal));// + Math.Round(nMonFavCli, 2)));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((Decimal)nMonto));
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));

                    //this.txtMontOpe.Text = string.Format("{0:#,#0.00}", nMonto);

                    conBusCtaAhoTransf.x_nMontoOpe = Convert.ToDecimal(txtMontOpe.Text);

                    if ((int)cboModPago.SelectedValue == 1)
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

        //--=========================================================
        //--Modalidad de Pago
        //--=========================================================
        private void cboModPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_idCta1 > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta1);
            }
            LimpiarCtrCheqGer();
            LimpiarTiposdePago();
            conBusCtaAhoTransf.LimpiarControles();
            btnBuscaOP.Visible = false;
            btnMiniBusq.Visible = false;
            chcOP.Visible = false;
            txtDiaVal.Enabled = true;
            btnGrabar.Enabled = true;
            txtNroCta.Visible = false;
            txtcNroCuenta.Visible = false;
            txtNroCta.MaxLength = 12;
            txtSerie.MaxLength = 8;
            cboCuenta.Visible = true;
            lblFolio.Visible = false;
            txtFolio.Visible = false;
            txtFolio.Enabled = false;
            btnBusCheGer.Enabled = false;
            //------------------------------------------------
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Checked = false;
            //------------------------------------------------

            if (this.cboModPago.SelectedIndex > 0)
            {
                cboModPago.Enabled = true;
                cboTipoEnt.Visible = false;
                lblTipEnt.Visible = false;
                txtNroDocu.MaxLength = 14;
                Decimal nMontoDoc = Convert.ToDecimal(txtMontOpe.Text);
                nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
                switch (nCodModPago)
                {
                    case 1: //--Pago En Efectivo
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                    case 2: //--Pago con Transferencia
                        if (Convert.ToInt32(cboTipoCuenta.SelectedValue) == 1)
                        {
                            conBusCtaAhoTransf.btnBusCliente.Enabled = true;
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTransf"].Enabled = true;
                            this.tbcPagos.Controls["tabCheq"].Enabled = false;
                            this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                            lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                            conBusCtaAhoTransf.idcli = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
                            conBusCtaAhoTransf.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                            conBusCtaAhoTransf.pnIdMon = Convert.ToInt32(cboMoneda.SelectedValue);
                            conBusCtaAhoTransf.x_nMontoOpe = Convert.ToDecimal(txtMontOpe.Text);
                            conBusCtaAhoTransf.nTipOpe = 1; //--Cuentas para Transferencia
                            btnGrabar.Enabled = false;
                            //----------------------------------------
                            rbtMismaCta.Enabled = true;
                            rbtOtrasCuentas.Enabled = true;
                            rbtMismaCta.Focus();
                            //----------------------------------------
                        }
                        else
                        {
                            MessageBox.Show("Pago Con Transferencia es Solo para Tipos de CUENTA INDIVIDUAL", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTransf"].Enabled = false;
                            this.tbcPagos.Controls["tabCheq"].Enabled = false;
                            lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text; ;
                        }
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        break;
                    case 3: //--Pago con Cheques
                        txtNroCta.Visible = true;
                        cboCuenta.Visible = false;
                        cboTipoEnt.Visible = true;
                        lblTipEnt.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        if (clsVarApl.dicVarGen["idTipoInstFin"] > 0)
                        {
                            cboTipoEnt.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                        }
                        cboEnt.CargarEntidades(clsVarApl.dicVarGen["idTipoInstFin"]);
                        //cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        cboTipoEnt.SelectedValue = 4; //--Bancos
                        cboEnt.Enabled = true;
                        txtNroCta.Enabled = true;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        txtDiaVal.Text = "3";
                        txtDiaVal.Enabled = true;
                        btnBuscaOP.Visible = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        txtNroCta.Focus();
                        break;

                    case 4: //--Pago Interbancario
                        CargarCtasbancos(); //Cargar las Cuentas de Bancos
                        txtNroCta.Visible = false;
                        cboCuenta.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = true;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        cboEnt.Enabled = true;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        btnGrabar.Enabled = true;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        cboCuenta.Focus();
                        break;
                    case 5: //--Pago con OP
                        txtNroCta.Visible = false;
                        txtcNroCuenta.Visible = true;
                        cboCuenta.Visible = false;
                        btnMiniBusq.Visible = true;
                        chcOP.Visible = true;
                        lblFolio.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        cboEnt.CargarEntidades(clsVarApl.dicVarGen["idTipoInstFin"]);
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        txtNroCta.Enabled = false;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        txtFolio.Visible = true;
                        cboEnt.Enabled = false;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = false;
                        btnBuscaOP.Visible = true;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text; ;
                        btnGrabar.Enabled = false;
                        txtNroCta.MaxLength = 9;
                        txtSerie.MaxLength = 3;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        txtNroCta.Focus();
                        break;
                    case 6://--Deposito con cheque de gerencia
                        CargarCtasbancos();
                        tbcPagos.SelectedIndex = 2;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = true;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        btnBusCheGer.Enabled = true;
                        break;
                    case 7: //--Deposito con Nota de Abono
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                    default: //---Otros pagos
                        MessageBox.Show("El Tipo de Pago no Esta Definido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text; ;
                        tbcPagos.SelectedIndex = 0;
                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                }
            }
            else
            {
                tbcPagos.SelectedIndex = 0;
                this.tbcPagos.Controls["tabTransf"].Enabled = false;
                this.tbcPagos.Controls["tabCheq"].Enabled = false;
                lblTipPago.Text = "MODALIDAD DE PAGO: EFECTIVO";
            }
            if (!string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text.ToString()))
            {
                calcular();
            }
        }

        private void LimpiarCtrCheqGer()
        {
            txtNroCuentaGer.Text = "";
            txtNroCheqGer.Text = "";
            txtSerieCheqGer.Text = "";
            cboEntidadCheGer.SelectedValue = 1;
            cboMonedaCheGer.SelectedValue = 1;
            txtMontoCheGer.Text = "";
        }




        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cboMotivoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo de la Operación...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return;
            }
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            int idCliValid = 0;
            DataRow row = dtbIntervCta.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                    .OrderBy(x => Convert.ToInt32(x["idCli"]))
                                                    .FirstOrDefault();
            idCliValid = row != null ? Convert.ToInt32(row["idCli"]) : 0;

            var lstTitulares = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(idCliValid, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, this.x_nTipOpe, idCliValid);


            if (validaciones.verificPararOperacion())
            {
                return;
            }


            /*========================================================================================
                * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Deposito de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (Convert.ToDecimal(txtMontOpe.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontOpe.Focus();
                return;
            }
            if (!ValidarDatosTipPago())
            {
                return;
            }
            if (!ValidarDatCliOpe())
            {
                return;
            }
            Decimal nMonOpeVal = Convert.ToDecimal(this.txtMontOpe.Text.ToString());
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

            if (lIsDepAhoProg)
            {
                if (nMonOpeVal > Convert.ToDecimal(txtSaldoPen.Text))
                {
                    MessageBox.Show("El Monto a Depositar No Puede ser Mayor al Saldo Pendiente", "Validar Datos Ahorro Programado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtMontOpe.SelectAll();
                    this.txtMontOpe.Focus();
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    return;
                }
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            int nNumSolAprobRegimen = 0;
            foreach (var titular in lstTitulares)
            {
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(titular.Field<int>("idCli"),
                                                                               Convert.ToInt16(cboMoneda.SelectedValue),
                                                                               idProd,
                                                                               conBusCtaAho.idcuenta,
                                                                               Convert.ToDecimal(txtMontEnt.Text.ToString()));
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                    nNumSolAprobRegimen++;
            }

            if (nNumSolAprobRegimen > 0)
            {
                return;
            }


            Decimal nMonOpe = Convert.ToDecimal(this.txtMontEnt.Text.ToString()),
                    nMonRedondeo = Convert.ToDecimal(txtRedondeo.Text.ToString()),
                    nMonCapital = Convert.ToDecimal(txtMontTotal.Text.ToString());
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            int nidCta = Convert.ToInt32(conBusCtaAho.idcuenta);
            Decimal nMonComis = Convert.ToDecimal(txtComision.Text);
            Decimal nMonITF = Convert.ToDecimal(txtImpuesto.Text);
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue),
                idMon = Convert.ToInt16(cboMoneda.SelectedValue);

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasNivelApr())
            {
                return;
            }

            int x_idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = nMonOpe;
            int idMonedaUm = idMon;
            int idMotivoOpe = x_idMotivoOpe;
            int idSubProducto = idProd;
            int idTipoPago = idTipPago;
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

            if (Convert.ToInt32(cboModPago.SelectedValue) >= 2)  //Pago con documentos, Cheque, interbancario, ordpag, etc
            {
                switch (Convert.ToInt32(cboModPago.SelectedValue))
                {
                    case 2: //Pago con Transferencia de Cuentas
                        drPag["idTipoValorado"] = 2;
                        drPag["cNroCuentaDoc"] = conBusCtaAhoTransf.idcuenta.ToString();
                        drPag["cNroDocumento"] = "000";
                        drPag["cSerieDocumento"] = "0";
                        drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = 0;
                        drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                        drPag["nNroFolio"] = "0";
                        break;
                    case 3: //Tipo Cheque
                        drPag["idTipoValorado"] = 3;
                        drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                        drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                        drPag["nNroFolio"] = "0";
                        break;
                    case 4: //Tipo Interbancario
                        drPag["idTipoValorado"] = 4;
                        drPag["cNroCuentaDoc"] = cboCuenta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                        drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                        drPag["nNroFolio"] = "0";
                        break;
                    case 5:  //Tipo OP
                        drPag["idTipoValorado"] = 5;
                        drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                        drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                        drPag["nNroFolio"] = txtFolio.Text;
                        break;
                    case 6:  //Cheque de gerencia
                        drPag["idTipoValorado"] = 6;
                        drPag["idEntidad"] = cboEntidadCheGer.SelectedValue;
                        drPag["cNroCuentaDoc"] = txtNroCuentaGer.Text.Trim();
                        drPag["cNroDocumento"] = txtNroCheqGer.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerieCheqGer.Text.Trim();
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = 0;
                        drPag["dFechaEmiDoc"] = dtpFecCheqGer.Value;
                        drPag["nNroFolio"] = "0";
                        break;
                    default:
                        drPag["idTipoValorado"] = Convert.ToInt32(cboModPago.SelectedValue); //--Otros Tipos de Pago
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
            if (Convert.ToInt32(cboModPago.SelectedValue) > 2)
            {
                idEntFin = Convert.ToInt32(cboEnt.SelectedValue);
            }

            string cNroDocPag = txtNroDocu.Text.Trim();

            //--==================================================
            //--Si tipo de Pago es por Transferencia
            //--==================================================
            int idCtaTrans = 0;
            switch (Convert.ToInt32(cboModPago.SelectedValue))  //--Modificado
            {
                case 2:  //--Pago con Transferencia
                    idCtaTrans = Convert.ToInt32(conBusCtaAhoTransf.idcuenta);
                    break;
                case 3: //--Cheques
                    idCtaTrans = 0;
                    break;
                case 4: //--Interbancario
                    idCtaTrans = 0;
                    break;
                case 5:  //--Ordenes de Pago
                    idCtaTrans = Convert.ToInt32(txtNroCta.Text);
                    break;
                default:
                    idCtaTrans = 0;
                    break;
            }

            //--==================================================
            //--id Cliente Afe ITF
            //--==================================================
            int idCliITF = RetornaIdCli(),
                nCuota = Convert.ToInt32(txtNumCuoVen.Text),
                idCanal = 1;


            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglas())
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
            if (Convert.ToInt16(cboModPago.SelectedValue) == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 1, nMonOpe))
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

            int[] nMotPagoSaldoCaja = new int[2];
            nMotPagoSaldoCaja[0] = 1;
            nMotPagoSaldoCaja[1] = 5;
            int nMotPagoId = Convert.ToInt16(cboModPago.SelectedValue);

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 1; //INGRESO

            if (nMotPagoId.In(nMotPagoSaldoCaja))
                lModificaSaldoLinea = true;

            DataTable tbRegApe = clsDeposito.CNRegistraDepositoAHO(xmlTipPago, xmlComision, nidCta, nMonOpe, idMon, nMonComis, nMonITF, nMonRedondeo, nMonCapital, clsVarGlobal.User.idUsuario,
                                                                clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nCuota, idProd, lIsDepAhoProg, cNroDocPag,
                                                                idEntFin, idCtaTrans, idTipPago, idCliITF, cCdniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe,
                                                                idTipoTransac, lModificaSaldoLinea);

            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
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

            this.tbcPagos.Controls["tabTransf"].Enabled = false;
            this.tbcPagos.Controls["tabCheq"].Enabled = false;
            conDatPerReaOperac.DesabilitarCtrls();
            dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(Convert.ToInt32(conBusCtaAho.idcuenta), 1);
            dtgPlanDeposito.DataSource = dtbAhoPrg;
            if (dtbAhoPrg.Rows.Count > 0)
            {
                txtNumTotCuo.Text = dtbAhoPrg.Rows[0]["nNroDepos"].ToString();
                txtNumCuoVen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()) + 1);
                txtNumCuoPen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNroDepos"].ToString()) - Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()));
                txtAtraso.Text = dtbAhoPrg.Rows[0]["nDiasAtrazo"].ToString();
                txtSaldoPen.Text = Convert.ToString(Convert.ToDecimal(dtbAhoPrg.Rows[0]["nMonTotProg"].ToString()) - Convert.ToDecimal(dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString()));

                txtSaldoDep.Text = dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString();
                txtMonCuota.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                txtMonAdel.Text = dtbAhoPrg.Rows[0]["nMonAdelantado"].ToString();
                txtMontOpe.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                btnGrabar.Enabled = true;
                txtMontOpe.Select();
                txtMontOpe.Focus();
            }

            ActualizarNivelApr(idSolApr);
            txtMontOpe.Enabled = false;
            cboModPago.Enabled = false;
            btnGrabar.Enabled = false;
            btnComision.Enabled = false;
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnCancelar.Enabled = true;
            conCalcVuelto.Enabled = false;
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;

            clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            clsDeposito.CNUpdNoUsoCuenta(p_idCta1);

            int[] nMotPago = new int[4];
            nMotPago[0] = 1;
            nMotPago[1] = 2;
            nMotPago[2] = 5;
            nMotPago[3] = 4;

            if (nMotPagoId.In(nMotPago))
            {
                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);
            }

            //--------------------------------------------------------------------
            //Impresion del voucher
            //--------------------------------------------------------------------
            if (idKardex > 0)
            {
                ImpresionVoucher(idKardex, clsVarGlobal.idModulo, x_nTipOpe, 1, Convert.ToDecimal(conCalcVuelto.txtMonEfectivo.Text), Convert.ToDecimal(conCalcVuelto.txtMonDiferencia.Text), 0, 1);
            }

            //this.objFrmSemaforo.ValidarSaldoSemaforo();

            /*========================================================================================
               * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Fin-Deposito de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            dsComision.Tables.Clear();
            dsComision.Dispose();
            dsTipPago.Tables.Clear();
            dsTipPago.Dispose();
        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMontOpe.Text), int.Parse(conBusCtaAho.idcuenta.ToString()), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private bool ValidarDatCliOpe()
        {
            if (conDatPerReaOperac.txtDocIdePerson.Text.Trim().Length != 8)
            {
                MessageBox.Show("Debe Registrar el DNI de Forma Correcta (8 Dígitos)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar el Nombre del Cliente que Realiza la Operación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtNombrePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar la Dirección del Cliente que Realiza la Operación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDireccPerson.Focus();
                return false;
            }
            if (conDatPerReaOperac.idCli == clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El Cliente que Realiza la Operación, No puede ser el Mismo Usuario", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            return true;
        }

        private void btnVincular_Click_1(object sender, EventArgs e)
        {

        }

        //--==================================================
        //--Retorna ID CLI
        //--==================================================
        private int RetornaIdCli()
        {
            int idCli = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["lCliAfeITF"].Value))
                {
                    idCli = Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idCli"].Value);
                    break;
                }
            }
            return idCli;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            this.cargaCuentaConValidacionAhorroWeb();
        }

        private void cargaCuentaConValidacionAhorroWeb()
        {
            /*========================================================================================
            * INICO - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
            ========================================================================================*/
            DataTable dtResValidacionCuenta = clsDeposito.CNAWValidarCuentaAperturada(conBusCtaAho.idcuenta);
            if (dtResValidacionCuenta.Rows.Count == 1)
            {
                frmAWValidarCuenta frmAWValidarCuenta = new frmAWValidarCuenta(conBusCtaAho.idcuenta, 2, conBusCtaAho.txtNroDoc.Text, dtResValidacionCuenta);

                if (!frmAWValidarCuenta.validarCuentaAperturada())
                {
                    DialogResult drResult = MessageBox.Show("¿El cliente es titular de la cuenta?", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (drResult == DialogResult.Yes)
                    {
                        frmAWValidarCuenta.ShowDialog();
                        if (frmAWValidarCuenta.lCancelado)
                        {
                            cancelarOperacion();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cuenta aperturada en línea. El cliente titular aún no ha efectuado la firma de los documentos contractuales.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cancelarOperacion();
                        return;
                    }
                }
            }

            /*========================================================================================
            * FIN - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
            ========================================================================================*/

            LimpiarCtrl();
            LimpiarTiposdePago();
            p_idCta = 0;
            btnComision.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                DatosCuenta(p_idCta);
            }

            //Segmento
            if (!string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text)) { ObtenerSegmentoCliente(Convert.ToInt32(conBusCtaAho.txtCodCli.Text)); }            
            
        }

        /*CANCELAR OPERACION*/
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarOperacion();
        }

        private void cancelarOperacion()
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }

            if (!string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoTransf.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoTransf.idcuenta));
            }
            LimpiarCtrl();
            LimpiarOtrosCtrl();
            LimpiarCtrCheqGer();
            conBusCtaAhoTransf.LimpiarControles();
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAhoTransf.idcuenta = 0;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            txtMontOpe.Enabled = false;
            btnComision.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCtaAho.btnBusCliente.Enabled = true;
            conDatPerReaOperac.DesabilitarCtrls();
            conSolesDolar.iMagenMoneda(1);
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            if (dtgIntervinientes.Rows.Count > 0)
                dtbIntervCta.Clear();
            if (dtgPlanDeposito.Rows.Count > 0)
                dtbAhoPrg.Clear();
            conCalcVuelto.Enabled = false;
            cboModPago.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            lblSegmento.Text = string.Empty;
            //------------------------------------------------
            rbtMismaCta.Enabled = false;
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Enabled = false;
            rbtOtrasCuentas.Checked = false;
            //------------------------------------------------
            conBusCtaAho.txtCodAge.Focus();
        }
        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private void DatosCuenta(int idCta)
        {
            btnGrabar.Enabled = false;
            txtMontOpe.Enabled = false;
            conSolesDolar.iMagenMoneda(0);
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            //--===================================================================================
            //--Validar Bloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, x_nTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarOtrosCtrl();
                return;
            }

            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", x_nTipOpe);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    p_idCta = 0;
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                switch (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()))
                {
                    case 4:
                        MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrl();
                        btnGrabar.Enabled = false;
                        return;
                    case 5:
                        MessageBox.Show("La Cuenta se Encuentra Vencida, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrl();
                        btnGrabar.Enabled = false;
                        return;
                }
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboMonedaDoc.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                lIsAfectoITF = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpe = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                lisCtaCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"].ToString());
                idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonMinSalDis = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                txtMontOpe.Enabled = true;
                cboModPago.Enabled = true;
                btnGrabar.Enabled = true;
                txtMontOpe.Select();
                txtMontOpe.Focus();
            }
            else
            {
                txtMontOpe.Enabled = false;
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarOtrosCtrl();
                MessageBox.Show("Inconsistencias en sus datos, por favor revisar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
            if (dtbIntervCta.Rows.Count > 0)
            {
                dtgIntervinientes.DataSource = dtbIntervCta;
            }
            else
            {
                MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarCtrl();
                LimpiarOtrosCtrl();
                txtMontOpe.Enabled = false;
                btnGrabar.Enabled = false;
                return;
            }

            //--===================================================================================
            //--Cargar Datos si es Ahorro Programado
            //--===================================================================================
            if (lIsDepAhoProg)
            {
                dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(idCta, 1);
                dtgPlanDeposito.DataSource = dtbAhoPrg;
                if (dtbAhoPrg.Rows.Count > 0)
                {
                    txtNumTotCuo.Text = dtbAhoPrg.Rows[0]["nNroDepos"].ToString();
                    txtNumCuoVen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()) + 1);
                    txtNumCuoPen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNroDepos"].ToString()) - Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()));
                    txtAtraso.Text = dtbAhoPrg.Rows[0]["nDiasAtrazo"].ToString();
                    txtSaldoPen.Text = Convert.ToString(Convert.ToDecimal(dtbAhoPrg.Rows[0]["nMonTotProg"].ToString()) - Convert.ToDecimal(dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString()));

                    txtSaldoDep.Text = dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString();
                    txtMonCuota.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    txtMonAdel.Text = dtbAhoPrg.Rows[0]["nMonAdelantado"].ToString();
                    txtMontOpe.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    btnGrabar.Enabled = true;
                    txtMontOpe.Select();
                    txtMontOpe.Focus();
                }
                else
                {
                    MessageBox.Show("El Cuenta no Tiene Cronograma de Depositos..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    txtMontOpe.Enabled = false;
                    btnGrabar.Enabled = false;
                    return;
                }
            }

            if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontEnt.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
            else
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGreen;
                txtMontEnt.BackColor = System.Drawing.Color.LightGreen;
            }
            conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            cboMotivoOperacion.Enabled = true;
            if (cboMotivoOperacion.Items.Count > 0)
            {
                cboMotivoOperacion.SelectedIndex = 0;
            }

            if (Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString()) == 1 && this.lClienteTitular) //--Solo si es persona natural
            {
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCtaAho.txtNroDoc.Text;
            }
            conDatPerReaOperac.txtDocIdePerson.Enabled = true;

        }

        //--================================================================
        //--Cargar Comisiones de la Cuenta
        //--================================================================
        private void Comision()
        {
            dtComision = null;
            int x_idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            int idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
            Decimal nMonto = Convert.ToDecimal(txtMontOpe.Text);

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, Convert.ToInt32(cboTipoPersona.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue),
                                                        idCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCta, x_idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal(dtComision.Compute("SUM(nValorAplica)", ""));
                txtComision.Text = nTotCom.ToString();
                btnComision.Enabled = true;
            }
            else
            {
                txtComision.Text = "0.00";
                btnComision.Enabled = false;
            }
        }
        private void LimpiarCtrl()
        {
            //--Datos de la Cuenta
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
            cboModPago.SelectedValue = 1;
            LimpiarTiposdePago();

            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }

            //--Ahorro Programado
            txtNumTotCuo.Text = "0";
            txtSaldoDep.Text = "0.00";
            txtNumCuoVen.Text = "0";
            txtNumCuoPen.Text = "0";
            txtAtraso.Text = "0";
            txtSaldoPen.Text = "0,00";
            txtMonCuota.Text = "0.00";
            txtMonAdel.Text = "0.00";

            if (dtgPlanDeposito.Rows.Count > 0)
            {
                ((DataTable)dtgPlanDeposito.DataSource).Rows.Clear();
            }

            //Limpiar Datos Cli Ope
            conDatPerReaOperac.txtDocIdePerson.Text = "";
            conDatPerReaOperac.txtNombrePerson.Text = "";
            conDatPerReaOperac.txtDireccPerson.Text = "";
            //Limpiar Datos Ope Transferencia
            conBusCtaAhoTransf.LimpiarControles();
        }
        private void txtMontOpe_TextChanged(object sender, EventArgs e)
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

        private void txtMontOpe_Validating(object sender, CancelEventArgs e)
        {
            //calcular();
        }

        private void LimpiarOtrosCtrl()
        {
            conBusCtaAho.LimpiarControles();
            conCalcVuelto.limpiar();
        }

        private void cboTipoEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cboTipoEnt.SelectedIndex > 0)
            //{
            //    int nTipEnt = Convert.ToInt32(this.cboTipoEnt.SelectedValue);
            //    cboEnt.CargarEntidades(nTipEnt);
            //}
            //if (cboTipoEnt.SelectedIndex >= 0)
            //{
            //    DataRowView dr = (DataRowView)cboEnt.SelectedItem;
            //    cboTipoEnt.SelectedValue = Convert.ToInt16(dr["idTipoEntidad"]);
            //}
        }

        private void txtMontOpe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcular();
            }
        }

        private void txtMontOpe_Leave(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            frmComisionesCta frmComisCta = new frmComisionesCta();
            frmComisCta.dtCom = dtComision;
            frmComisCta.ShowDialog();
        }

        private bool ValidarOP()
        {
            if (string.IsNullOrEmpty(txtNroCta.Text) || Convert.ToInt32(txtNroCta.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Numero Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCta.Focus();
                txtNroCta.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtNroDocu.Text) || Convert.ToInt32(txtNroDocu.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Numero del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocu.Focus();
                txtNroDocu.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text) || Convert.ToInt32(txtSerie.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar la Serie del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCta.Focus();
                txtNroCta.SelectAll();
                return false;
            }
            return true;
        }

        private void btnBuscaOP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFolio.Text))
            {
                if (Convert.ToInt32(txtFolio.Text) > 0)
                {
                    MessageBox.Show("La Orden de Pago ya fue buscada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            p_idCta = 0;
            txtFolio.Text = "";

            if (!ValidarOP())
            {
                return;
            }

            int idCuenta = Convert.ToInt32(txtNroCta.Text),
                nNumero = Convert.ToInt32(txtNroDocu.Text),
                nSerie = Convert.ToInt32(txtSerie.Text),
                nTipValorado = 1;  //--Orden de Pago

            p_idCta = idCuenta;
            int idMoneda = (int)cboMonedaDoc.SelectedValue;
            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(p_idCta, 11, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--===================================================================================
            //--Validaciones de la Cuenta
            //--===================================================================================
            clsCNAperturaCta objAho = new clsCNAperturaCta();
            DataTable dt = objAho.RetornaDatosOrdenPago(nSerie, nNumero, idCuenta, nTipValorado, idMoneda);
            if (dt.Rows.Count > 0)
            {
                //---------------------------------------------------------------------
                //--Validaciones genéricas
                //---------------------------------------------------------------------
                if (Convert.ToInt32(dt.Rows[0]["idMoneda"].ToString()) != Convert.ToInt32(cboMonedaDoc.SelectedValue))
                {
                    MessageBox.Show("La Moneda de la Orden de Pago, es Distinto a la Operacion", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToDecimal(dt.Rows[0]["nSaldoDis"].ToString()) < Convert.ToDecimal(txtMontOpe.Text))
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto de la Operación", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))  //Modificado
                {
                    MessageBox.Show("La Cuenta no Puede Emitir Ordenes de Pago", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //---------------------------------------------------------------------
                //--Validar Estado de la Orden de Pago
                //---------------------------------------------------------------------
                int x_idEstado = Convert.ToInt16(dt.Rows[0]["idEstado"].ToString());
                switch (x_idEstado)
                {
                    case 1: //--Ingresado
                        MessageBox.Show("Orden de Pago no Válido, se encuentra en estado INGRESADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 2: //--Vinculado
                        MessageBox.Show("Orden de Pago no Válido, se encuentra en estado VINCULADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 3: //--Impreso
                        MessageBox.Show("Orden de Pago no Válido, se encuentra en estado IMPRESO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 4: //--Enviado
                        MessageBox.Show("Orden de Pago no Válido, se encuentra en estado ENVIADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 5: //--Recepcionado
                        MessageBox.Show("Orden de Pago no Válido, se encuentra en estado RECEPCIONADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 6: //--Activo OK
                        break;
                    case 7: //--Entregado
                        MessageBox.Show("La Orden de Pago ya fue USADO...Revisar", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 8: //--Mal Estado
                        MessageBox.Show("Orden de Pagó no Válido, fue ANULADO por estar en MAL ESTADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 9: //--Mal Impreso
                        MessageBox.Show("Orden de Pagó no Válido, fue ANULADO por estar MAL IMPRESO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 10: //--Anulado
                        MessageBox.Show("La Orden de Pago esta ANULADO...Revisar", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                }

                //--===================================================================================
                //--Validar Datos para el Retiro
                //--===================================================================================
                string Mensaje = "";
                clsCNDeposito clsDatCta = new clsCNDeposito();
                if (!clsDatCta.CNValidaOperacionAho(p_idCta, "1", 11, Convert.ToDecimal(txtMontOpe.Text), ref Mensaje))
                {
                    MessageBox.Show(Mensaje, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                txtFolio.Text = dt.Rows[0]["nNroFolio"].ToString();

                var Msg = MessageBox.Show("Los Datos de la Orden de Pago son Válidos" +
                    "\n El Número de Folio del Documento es: (" + txtFolio.Text + ") Esta seguro de los datos?...", "Validar Datos de la Orden de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg == DialogResult.Yes)
                {
                    txtNroCta.Enabled = false;
                    txtNroDocu.Enabled = false;
                    txtSerie.Enabled = false;
                    btnGrabar.Enabled = true;
                }
                else
                {
                    txtFolio.Text = "";
                    txtNroCta.Focus();
                    txtNroCta.SelectAll();
                    return;
                }

                clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            }
            else
            {
                MessageBox.Show("Los Datos de la Orden de Pago no son Validos...Verificar", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void frmDepositoAho_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_idCta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            }
            if (p_idCtaTranf > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCtaTranf);
            }
        }

        private void txtMontOpe_TextChanged_1(object sender, EventArgs e)
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
            calcular();
        }

        private void txtMontOpe_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcular();
            }
        }

        private bool ValidarReglasNivelApr()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
            idSolApr = 0;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMontOpe.Text), int.Parse(conBusCtaAho.idcuenta.ToString()), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref idSolApr);
            if (cCumpleReglas.Equals("NoCumple"))
            {

                return false;
            }
            return true;
        }

        private void ActualizarNivelApr(int idSolApr)
        {
            if (idSolApr > 0)
            {
                clsCNValidaReglasDinamicas ActNivelApr = new clsCNValidaReglasDinamicas();
                ActNivelApr.ActualizaSolicitudApr(idSolApr, 3);
            }
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = conBusCtaAho.txtNroDoc.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dniCliOpe";
            drfila[1] = conDatPerReaOperac.txtDocIdePerson.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = conBusCtaAho.idcuenta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = idProd.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
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
            drfila[1] = cboTipoCuenta.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonSalDis";
            drfila[1] = nMonMinSalDis.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
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
            drfila[1] = cboModPago.SelectedValue.ToString();
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
            drfila[1] = Convert.ToString(this.conBusCtaAho.txtCodCli.Text);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        //-----------------------------------------------------------
        //--Cargar Datos del Cliente
        //----------------------------------------------------------
        private void DatosCtaCli(int idCli)
        {
            txtNroCta.Text = "";
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(idCli, 1, 0, x_nTipOpe);
            switch (dtbNumCuentas.Rows.Count)
            {
                case 0:  //--No existe Cuentas
                    conBusCtaAho.LimpiarControles();
                    MessageBox.Show("No se Encontró Datos", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 1: //--El cliente solo tiene una cuenta
                    conBusCtaAho.txtCodIns.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                    conBusCtaAho.txtCodAge.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                    conBusCtaAho.txtCodMod.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                    conBusCtaAho.txtCodMon.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                    conBusCtaAho.txtNroCta.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                    conBusCtaAho.txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                    conBusCtaAho.txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                    conBusCtaAho.txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                    break;
                default: //--El Cliente tiene mas de Una Cuenta
                    //==================================================
                    //--Llamar al Formulario
                    //==================================================
                    frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                    frmbuscarCta.idCli = idCli;
                    frmbuscarCta.pTipBus = 2;
                    frmbuscarCta.nTipOpe = x_nTipOpe;  //--Tipo de Operación: 11 Retiro, 10 Deposito
                    frmbuscarCta.idMon = 0;  //--Se Enviará Moneda en Caso sea Necesario
                    frmbuscarCta.ShowDialog();
                    if (!string.IsNullOrEmpty(frmbuscarCta.pnCta))
                    {
                        conBusCtaAho.txtCodIns.Text = frmbuscarCta.pcNroCta.Substring(0, 3);
                        conBusCtaAho.txtCodAge.Text = frmbuscarCta.pcNroCta.Substring(3, 3);
                        conBusCtaAho.txtCodMod.Text = frmbuscarCta.pcNroCta.Substring(6, 3);
                        conBusCtaAho.txtCodMon.Text = frmbuscarCta.pcNroCta.Substring(9, 1);
                        conBusCtaAho.txtNroCta.Text = frmbuscarCta.pcNroCta.Substring(10, 12);
                        conBusCtaAho.txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                        conBusCtaAho.txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                        conBusCtaAho.txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                    }

                    break;
            }
        }

        private void conDatPerReaOperac_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void conBusCtaAhoTransf_ClicBusCta(object sender, EventArgs e)
        {
            p_idCtaTranf = conBusCtaAhoTransf.idcuenta;
            if (string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text.Trim()))
            {
                btnGrabar.Enabled = false;
            }
            else
            {
                btnGrabar.Enabled = true;
            }
            if (p_idCtaTranf == Convert.ToInt32(conBusCtaAho.idcuenta))
            {
                MessageBox.Show("No puede Realizar la Transferencia a la Misma Cuenta", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAhoTransf.LimpiarControles();
                return;
            }
        }

        private void cboEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEnt.SelectedIndex == -1 || cboEnt.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            dt = clsDeposito.ListarCuentaXEntidades(Convert.ToInt32(cboEnt.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            if (dt.Rows.Count > 0)
            {
                cboCuenta.SelectedIndex = 0;
            }
        }

        private void CargarCtasbancos()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheques Externos
            cboEnt.DataSource = dtEntidad;
            cboEnt.ValueMember = "idEntidad";
            cboEnt.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count > 0)
            {
                cboEnt.SelectedIndex = 0;
            }
            //--Cheque de Gerencia
            cboEntidadCheGer.DataSource = dtEntidad;
            cboEntidadCheGer.ValueMember = "idEntidad";
            cboEntidadCheGer.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count > 0)
            {
                cboEntidadCheGer.SelectedIndex = 0;
            }
        }

        public void EmitirVoucher(DataTable dtDatosCobro, int idKardex)
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

            //  List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void cboTipoEnt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cboTipoEnt.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEnt.SelectedValue);
                cboEnt.CargarEntidades(nTipEnt);
            }
        }

        private void cboCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBusCheGer_Click(object sender, EventArgs e)
        {
            string cNroDNI = conBusCtaAho.txtNroDoc.Text.Trim();
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = conBusCtaAho.txtCodCli.Text;
            frmChequeByCli.idMotOpeBco = 0; // Todos
            frmChequeByCli.cNroDNI = cNroDNI;
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text = frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text = frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text = frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
        }

        private void cboMotivoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbtMismaCta_CheckedChanged(object sender, EventArgs e)
        {
            if (conBusCtaAhoTransf.idcuenta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(conBusCtaAhoTransf.idcuenta);
            }
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = true;
            calcular();
            conBusCtaAhoTransf.LimpiarControles();
            conBusCtaAhoTransf.idcuenta = 0;
        }

        private void rbtOtrasCuentas_CheckedChanged(object sender, EventArgs e)
        {
            if (conBusCtaAhoTransf.idcuenta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(conBusCtaAhoTransf.idcuenta);
            }
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;
            calcular();
            conBusCtaAhoTransf.LimpiarControles();
            conBusCtaAhoTransf.idcuenta = 0;
        }

        private void txtNroCta_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
            }
        }

        private void txtNroDocu_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                this.txtNroDocu.Text = this.txtNroDocu.Text.ToString().PadLeft(9, '0');
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                this.txtSerie.Text = this.txtSerie.Text.ToString().PadLeft(3, '0');
            }
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroCta.Text) && Convert.ToInt32(txtNroCta.Text) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(txtNroCta.Text));
            }
            txtNroCta.Clear();
            txtcNroCuenta.Clear();
            txtNroDocu.Clear();
            txtSerie.Clear();
            txtFolio.Clear();

            frmBusCtaOP frmOP = new frmBusCtaOP();
            frmOP.pcidMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            frmOP.ShowDialog();
            if (frmOP.pnCta > 0)
            {
                if (frmOP.pnCta == conBusCtaAho.idcuenta)
                {
                    MessageBox.Show("La cuenta de la OP, tiene que ser distinto a la cuenta a depositar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                txtNroCta.Text = frmOP.pnCta.ToString();
                txtcNroCuenta.Text = frmOP.pcNroCuenta.ToString();
                txtNroDocu.Enabled = true;
                txtSerie.Enabled = true;
                txtNroDocu.Focus();
            }
        }

        private void chcOP_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNroCta.Text) && Convert.ToInt32(txtNroCta.Text) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(txtNroCta.Text));
            }
            if (chcOP.Checked)
            {
                txtNroDocu.Clear();
                txtSerie.Clear();
                txtFolio.Clear();
                txtNroDocu.Enabled = true;
                txtSerie.Enabled = true;
                txtNroDocu.Focus();
                chcOP.Checked = false;
            }
        }

        private void txtNroDocu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void conBusCtaAho_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCtaAho.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCtaAho.txtNroDoc.Text);
            }
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCtaAho.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private void ObtenerSegmentoCliente(int idCliente)
        {
            string cSegmento = cliente.CNObtenerSegmentoCliente(idCliente);
            lblSegmento.ForeColor = Color.Navy;
            lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Regular);
            lblSegmento.Text = cSegmento;

            //Valida si existe la variable
            bool lExiste = clsVarApl.dicVarGen.ContainsKey("cSegmentoColorVerde");
            if (lExiste)
            {
                //Obtiene el segmento con letra verde
                string cSegmentoColorVerde = clsVarApl.dicVarGen["cSegmentoColorVerde"];
                if (cSegmentoColorVerde.ToUpper() == cSegmento.ToUpper())
                {
                    lblSegmento.ForeColor = Color.Green;
                    lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Bold);
                }
            }
        }
    }
}
