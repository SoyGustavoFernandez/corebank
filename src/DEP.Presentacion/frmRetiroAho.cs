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
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CAJ.CapaNegocio;
using SPL.Presentacion;
using CLI.Servicio;
using CLI.Presentacion;
using CLI.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRetiroAho : frmBase
    {
        bool lIsAfectoITF, lIsDepAhoProg, lisBloCta, lisCtaOP, lIsDepMenEdad,lisCtaCTS=false,lTieneAutCTS=false;
        Decimal nMonMinOpe = 0.00m, nMonMinSalDis = 0.00m,nSaldoDisp=0.00m,nMonBloqCta=0.00m,nMonTotAho=0.00m;
        int idProd = 0, nPlaCta = 0, x_nTipOpe = 0, p_idCta = 0,p_idCtaTranf=0, p_idCta1 = 0, idSolApr = 0;
        DataTable dtComision;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNFirmas cnFirma = new clsCNFirmas();
        private const int idTipoOpeRegimenReforzado = 174;
        int idTipoIntervBeneficiario = 0;
        int idCliBeneficiario = 0;

        clsBiometrico oBiometrico = new clsBiometrico();
        clsCNCliente cliente = new clsCNCliente();

        public frmRetiroAho()
        {
            InitializeComponent();
        }

        private void frmRetiroAho_Load(object sender, EventArgs e)
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
                this.Text = "Retiro de Ahorros (Presione F5 para Trabajar con Tarjetas)";
            }
            else
            {
                this.Text = "Retiro de Ahorros";
            }

            conSolesDolar.iMagenMoneda(0);
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            x_nTipOpe = 11;  //--Operación de Retiro
            CargarModalidadPago();
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            txtMontOpe.Enabled = false;
            cboModPago.Enabled = false;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            conBusCtaAho.nTipOpe = x_nTipOpe;  //--Operación de Retiro
            conBusCtaAho.lBloqueaBusquedaNombre = this.lBloqueaBusquedaNombre;
            conBusCtaAhoTransf.p_idTipOpePrincipal = x_nTipOpe; //Indica la Operación Principal
            conBusCtaAhoTransf.lBloqueaBusquedaNombre = this.lBloqueaBusquedaNombre;
            conBusCtaAho.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            btnGrabar.Enabled = false;
            CargarCtasbancos();
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            this.cboMotivoOperacion.ListarMotivoOperacion(x_nTipOpe,clsVarGlobal.PerfilUsu.idPerfil);
            conBusCtaAho.txtCodAge.Focus();
            conBusCtaAho.txtCodAge.SelectAll();
            cboTipoEntDestino.SelectedValue =4;
            lblSegmento.Text = string.Empty;
        }

        //==========================================================
        //--Cargar Modalidades de Pago--> Retiro
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
            txtNroCta.Text = "";
            txtNroDocu.Text = "";
            txtSerie.Text = "";
            txtDiaVal.Text = "0";
            txtFolio.Clear();
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
                        MessageBox.Show("Debe Ingresar el Monto a Retirar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El Monto a Retirar no puede ser menor o Igual Cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    break;
                case 2: //--Retiro con Transferencia
                    if (string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Buscar la Cuenta del Cliente a Transferir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }
                    if (conBusCtaAhoTransf.idcuenta<=0)
                    {
                        MessageBox.Show("Debe Buscar la Cuenta del Cliente a Transferir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                case 3: //--Retiro Con Cheque
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

                    if (dtpFecDoc.Value>clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La Fecha de Emisión del Documento no Puede ser Posterior a la Fecha del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }

                    TimeSpan sDifFec = clsVarGlobal.dFecSystem - dtpFecDoc.Value;
                    if (sDifFec.Days>clsVarApl.dicVarGen["nDiasVigenciaCheque"])
                    {
                        MessageBox.Show("El Documento, ya se encuentra Vencido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();
                        return false;
                    }
                    if (clsVarApl.dicVarGen["nDiasVigenciaCheque"]-sDifFec.Days<clsVarApl.dicVarGen["nDiasVcmtoCheque"])
                    {
                        MessageBox.Show("El Número de Días por Vencer no debe ser menor a: " + Convert.ToString(clsVarApl.dicVarGen["nDiasVcmtoCheque"])+ " Días", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (cboEntidadDestino.SelectedIndex==-1)
                    {
                        MessageBox.Show("Debe Seleccionar la Entidad Destino", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEntidadDestino.Focus();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtCtaDestino.Text))
                    {
                        MessageBox.Show("Debe registrar la cuenta destino", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCtaDestino.Focus();
                        txtCtaDestino.Select();
                        return false;
                    }
                    break;
                case 4: //--Retiro Interbancario
                    if (cboCuenta.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe Seleccionar una Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCuenta.Focus();
                        return false;
                    }
                    //if (string.IsNullOrEmpty(txtNroDocu.Text))
                    //{
                    //    MessageBox.Show("Debe Registrar el Número del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    txtNroDocu.Focus();
                    //    txtNroDocu.Select();
                    //    return false;
                    //}
                    //if (string.IsNullOrEmpty(txtSerie.Text))
                    //{
                    //    MessageBox.Show("Debe Registrar la Serie del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    txtSerie.Focus();
                    //    txtSerie.Select();
                    //    return false;
                    //}
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

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
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

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
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

                    if (cboEntidadCheGer.SelectedIndex==-1)
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
                    if (Convert.ToDecimal(txtMontoCheGer.Text)<=0)
                    {
                        MessageBox.Show("El Monto de Cheque no Puede ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();
                        return false;
                    }
                    if (Convert.ToDecimal(txtMontoCheGer.Text)!= Convert.ToDecimal(txtMontEnt.Text))
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
                        MessageBox.Show("Debe Ingresar el Monto a Retirar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontOpe.Focus();
                        txtMontOpe.SelectAll();
                        return false;
                    }
                    if (txtMontOpe.nDecValor <= 0)
                    {
                        MessageBox.Show("El Monto a Retirar no puede ser Menor o Igual Cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    if (nMonto == 0)
                    {
                        btnGrabar.Enabled = false;
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
                    //--Comisiones de la Cuenta
                    //--==========================================================
                    Comision();
                    Decimal nComision = Convert.ToDecimal (txtComision.Text);

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
                    this.txtComision.Text = string.Format("{0:#,#0.00}",Math.Round(nComision, 2));
                    Decimal nMontoTotal = 0;
                    Decimal nMontoSolCli = 0;
                    nMontoTotal = (Decimal)nMonto + Math.Round(nITF, 2) + (Decimal)Math.Round(nComision, 2);
                    nMontoSolCli = nMonto;
                    if (Convert.ToInt32(cboModPago.SelectedValue)==1) // Pago en EFECTIVO
                    {
                        //nMontoTotal = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                        nMontoSolCli = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                    }

                    this.txtMontTotal.Text = string.Format("{0:#,#0.00}",(nMontoTotal));// - Math.Round(nMonFavCli, 2)));
                    //this.txtMontEnt.Text = string.Format("{0:#,#0.00}",((Decimal)nMonto + nMonFavCli));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((Decimal)nMontoSolCli)); //+ nMonFavCli));
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));

                    this.txtMontOpe.Text = string.Format("{0:#,#0.00}", nMonto);

                    conBusCtaAhoTransf.x_nMontoOpe = Convert.ToDecimal(txtMontEnt.Text);

                    btnGrabar.Enabled = true;
                }
            }
        }

        private void cboModPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conBusCtaAhoTransf.idcuenta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(conBusCtaAhoTransf.idcuenta);
            }
            LimpiarCtrCheqGer();
            LimpiarTiposdePago();
            conBusCtaAhoTransf.LimpiarControles();
            conBusCtaAhoTransf.btnBusCliente.Enabled = false;
            txtNroCta.Visible = false;
            cboCuenta.Visible = true;
            chcOP.Visible = false;
            btnBuscaOP.Visible = false;
            lblFolio.Visible = false;
            txtFolio.Visible = false;
            txtFolio.Enabled = false;
            txtDiaVal.Enabled = true;
            btnGrabar.Enabled = true;
            btnBusCheGer.Enabled = false;
            cboTipoEntDestino.Enabled = false;
            cboEntidadDestino.Enabled = false;
            txtCtaDestino.Enabled = false;
            txtCtaDestino.Text = "";
            txtNroDocu.MaxLength = 12;
            txtSerie.MaxLength = 8;
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
                cboModPago.Enabled = true;
                int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
                switch (nCodModPago)
                {
                    case 1: //--Retiro En Efectivo
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        break;
                    case 2: //--Retiro con Transferencia
                        conBusCtaAhoTransf.btnBusCliente.Enabled = true;
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = true;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        conBusCtaAhoTransf.idcli = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
                        conBusCtaAhoTransf.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                        conBusCtaAhoTransf.pnIdMon = Convert.ToInt32(cboMoneda.SelectedValue);
                        conBusCtaAhoTransf.x_nMontoOpe = Convert.ToDecimal(txtMontEnt.Text);
                        conBusCtaAhoTransf.nTipOpe = 1; //--Cuentas para Transferencia
                        btnGrabar.Enabled = false;
                        //----------------------------------------
                        rbtMismaCta.Enabled = true;
                        rbtOtrasCuentas.Enabled = true;
                        rbtMismaCta.Focus();
                        //----------------------------------------
                        break;
                    case 3: //--Retiro con Cheques
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
                        cboTipoEnt.Focus();
                        break;
                    case 4: //--Retiro Interbancario
                        CargarCtasbancos(); //Cargar las Cuentas de Bancos
                        txtNroCta.Visible = false;
                        cboCuenta.Visible = true;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        cboEnt.Enabled = true;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        cboTipoEntDestino.Enabled = true;
                        cboEntidadDestino.Enabled = true;
                        txtCtaDestino.Enabled = true;
                        btnGrabar.Enabled = true;
                        txtNroDocu.Focus();
                        break;
                    case 5: //--Retiro con OP
                        if (!lisCtaOP)
                        {
                            MessageBox.Show("La Cuenta NO puede Emitir Orden de Pago...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.cboModPago.SelectedValue = 1;
                            return;
                        }
                        txtNroCta.Visible = true;
                        cboCuenta.Visible = false;
                        lblFolio.Visible = true;
                        txtFolio.Visible = true;
                        chcOP.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        cboTipoEnt.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                        cboEnt.CargarEntidades(clsVarApl.dicVarGen["idTipoInstFin"]);
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        txtFolio.Enabled = false;
                        cboTipoEnt.Enabled = false;
                        cboEnt.Enabled = false;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = false;
                        btnBuscaOP.Visible = true;
                        txtNroCta.Text = conBusCtaAho.idcuenta.ToString();
                        txtNroCta.Enabled = false;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        txtNroDocu.MaxLength = 9;
                        txtSerie.MaxLength = 3;
                        txtNroDocu.Focus();
                        btnGrabar.Enabled = false;
                        break;
                    case 6://--Retiro con cheque de gerencia
                        tbcPagos.SelectedIndex = 2;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = true;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        btnBusCheGer.Enabled = true;
                        btnBusCheGer.Focus();
                        break;
                    case 7: //--Retiro Con Nota de Cargo
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        break;
                    default: //----otros
                        MessageBox.Show("El Tipo de Pago no Esta Definido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
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

        //--==================================================
        //--Listar Cuentas de la Financiera desde Bancos
        //--==================================================
        private void CargarCtasbancos()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheque de Gerencia
            cboEntidadCheGer.DataSource = dtEntidad;
            cboEntidadCheGer.ValueMember = "idEntidad";
            cboEntidadCheGer.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count > 0)
            {
                cboEntidadCheGer.SelectedIndex = 0;
            }
            //--Cheques
            cboEnt.DataSource = dtEntidad;
            cboEnt.ValueMember = "idEntidad";
            cboEnt.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count > 0)
            {
                cboEnt.SelectedIndex = 0;
            }
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
            LimpiarCtrl();
            LimpiarTiposdePago();
            p_idCta = 0;
            btnComision.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta)>0)
            {

                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);

                /*========================================================================================
                *INICIO - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
                ========================================================================================*/

                DataTable dtResValidacionCuenta = clsDeposito.CNAWValidarCuentaAperturada(conBusCtaAho.idcuenta);
                if (dtResValidacionCuenta.Rows.Count == 1)
                {
                    frmAWValidarCuenta frmAWValidarCuenta = new frmAWValidarCuenta(conBusCtaAho.idcuenta, 2, conBusCtaAho.txtNroDoc.Text, dtResValidacionCuenta);

                    if (!frmAWValidarCuenta.validarCuentaAperturada())
                    {
                        frmAWValidarCuenta.ShowDialog();
                        if (frmAWValidarCuenta.lCancelado)
                        {
                            btnCancelar_Click(sender, e);
                            return;
                        }
                    }
                }

                /*========================================================================================
                * FIN - VALIDACIONES CUENTA APERTURADA EN PLATAFORMA WEB
                ========================================================================================*/

                DatosCuenta(p_idCta);

                //Segmento
                if (!string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text)) { ObtenerSegmentoCliente(Convert.ToInt32(conBusCtaAho.txtCodCli.Text)); }            
            }
        }

        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private void DatosCuenta(int idCta)
        {
            btnGrabar.Enabled = false;
            txtMontOpe.Enabled = false;
            lTieneAutCTS = false;
            conSolesDolar.iMagenMoneda(0);
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg="";
            clsCNOperacionDep clsBloq=new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, x_nTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarOtrosCtrl();
                conBusCtaAho.txtCodAge.Focus();
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
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_idCta = 0;
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString())==4)
                {
                    MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboMonedaDoc.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                lisCtaCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"].ToString());
                cboTipoPersona.SelectedValue = Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString());
                lIsAfectoITF = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpe = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                nMonMinSalDis = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoMinimo"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                nSaldoDisp = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonBloqCta = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonTotBloq"].ToString());
                lisBloCta = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisBloqCta"].ToString());
                lisCtaOP = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsCtaOrdPago"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                nMonTotAho = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString());
                txtNumBloq.Text = nMonBloqCta.ToString();
                if ( !RevisionDocumentosCTSPendientes())
                {
                    return;
                }
                //----------------------------------------------------------------------------
                //--Validar para Retiro Especial de CTS.
                //----------------------------------------------------------------------------
                if (lisCtaCTS)
                {
                    DataTable dtCts = clsDeposito.CNValidaSolicitudCTS(idCta, clsVarGlobal.dFecSystem, idProd);
                    if (dtCts.Rows.Count > 0)
                    {
                        var Msg = MessageBox.Show("Tiene una Solicitud Aprobada, desea realizar la Operación?...", "Valida Retiro CTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Msg == DialogResult.No)
                        {
                            clsDeposito.CNUpdNoUsoCuenta(idCta);
                            LimpiarCtrl();
                            LimpiarOtrosCtrl();
                            txtMontOpe.Enabled = false;
                            btnGrabar.Enabled = false;
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                        }

                        int x_idSolicitud = Convert.ToInt32(dtCts.Rows[0]["idSolAproba"].ToString());
                        int x_idMotivo = Convert.ToInt32(dtCts.Rows[0]["idMotivo"].ToString());
                        Decimal x_nMontoApr = Convert.ToDecimal (dtCts.Rows[0]["nValAproba"].ToString());

                        clsCNControlOpe ListaMotOperacion = new clsCNControlOpe();
                        DataTable dt = ListaMotOperacion.CNListaMotivoOperacion(x_nTipOpe, clsVarGlobal.PerfilUsu.idPerfil);

                        int nExiste = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToInt16(dt.Rows[i]["idMotivoOperacion"]) == x_idMotivo)
                            {
                                nExiste = 1;
                                break;
                            }
                        }

                        if (nExiste == 0)
                        {
                            MessageBox.Show("El Perfil del usuario no tienen acceso para realizar este Tipo de Operación (Retiro de CTS para Compra de Vivienda o Construcción)...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            clsDeposito.CNUpdNoUsoCuenta(idCta);
                            LimpiarCtrl();
                            LimpiarOtrosCtrl();
                            btnGrabar.Enabled = false;
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                        }

                        frmConfirmarRetiroCTS frmCts = new frmConfirmarRetiroCTS();
                        frmCts.p_idSolicitud = x_idSolicitud;
                        frmCts.ShowDialog();
                        if (frmCts.p_idSolicitud > 0)
                        {
                            txtMontOpe.Text = x_nMontoApr.ToString();
                            cboMotivoOperacion.SelectedValue = x_idMotivo;

                        }

                        lTieneAutCTS = true;
                        txtMontOpe.Enabled = false;
                        cboMotivoOperacion.Enabled = false;
                        cboModPago.Enabled = true;
                        calcular();
                        cboModPago.Focus();
                    }
                    else
                    {
                        cboMotivoOperacion.Enabled = true;
                        cboModPago.Enabled = true;
                        if (cboMotivoOperacion.Items.Count > 0)
                        {
                            cboMotivoOperacion.SelectedIndex = 0;
                        }
                        txtMontOpe.Enabled = true;
                        cboModPago.Enabled = true;
                        btnGrabar.Enabled = true;
                        txtMontOpe.Select();
                        txtMontOpe.Focus();
                    }
                    //return;
                }//--Fin Validación CTS
                else
                {
                    cboMotivoOperacion.Enabled = true;
                    if (cboMotivoOperacion.Items.Count > 0)
                    {
                        cboMotivoOperacion.SelectedIndex = 0;
                    }
                    txtMontOpe.Enabled = true;
                    cboModPago.Enabled = true;
                    btnGrabar.Enabled = true;
                    txtMontOpe.Select();
                    txtMontOpe.Focus();
                }

                if (nSaldoDisp <= 0)
                {
                    MessageBox.Show("La Cuenta no Tiene Saldo, no puedes Realizar Retiros", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                if (nMonBloqCta>=nSaldoDisp)
                {
                    MessageBox.Show(cMsg+"***Saldo Insuficiente, porque Tiene Bloqueos por Montos***", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinOpe + nMonMinSalDis)
                {
                    MessageBox.Show("El Saldo Disponible, es Menor a Monto Mínimo Permitido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinSalDis)
                {
                    MessageBox.Show("El Saldo de la Cuenta, es Menor al Saldo Mínimo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
                dtgIntervinientes.Enabled = true;
                dtgIntervinientes.ReadOnly = false;
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    if (dtbIntervCta.Rows.Count > 1)
                    {
                        dtgIntervinientes.Columns["cDocumentoID"].ReadOnly = true;
                        dtgIntervinientes.Columns["cNombre"].ReadOnly = true;
                        dtgIntervinientes.Columns["cTipoIntervencion"].ReadOnly = true;
                        dtbIntervCta.Columns["isReqFirma"].ReadOnly = false;
                        dtgIntervinientes.Columns["isReqFirma"].ReadOnly = false;
                    }
                    else
                    {
                        dtgIntervinientes.ReadOnly = true;
                    }

                    idTipoIntervBeneficiario = 0;
                    idCliBeneficiario = 0;

                    try
                    {
                        var eList = from p in dtbIntervCta.AsEnumerable()
                                      where p.Field<int>("idTipoInterv") == Convert.ToInt32(clsVarApl.dicVarGen["idTipoIntervBeneficiario"])
                                      select new
                                      {
                                          idTipoInterv = p.Field<int>("idTipoInterv"),
                                          idCli = p.Field<int>("idCli")
                                      };

                        foreach (var obj in eList)
                        {
                            idTipoIntervBeneficiario = obj.idTipoInterv;
                            idCliBeneficiario = obj.idCli;
                        }
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    txtMontOpe.Enabled = false;
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
            }
            else
            {
                txtMontOpe.Enabled = false;
                LimpiarOtrosCtrl();
                MessageBox.Show("Inconsistencias en sus datos, por favor revisar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(cboMoneda.SelectedValue)==1)
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontEnt.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
            else
            {
                txtMontOpe.BackColor = System.Drawing.Color.LightGreen;
                txtMontEnt.BackColor = System.Drawing.Color.LightGreen;
            }

            if (Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString())==1) //--Solo si es persona natural
            {
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCtaAho.txtNroDoc.Text;
            }
            conDatPerReaOperac.txtDocIdePerson.Enabled = true;

            conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));

            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
        }

        //--================================================================
        //--Revisión de documentos pendientes CTS
        //--================================================================
        private bool RevisionDocumentosCTSPendientes()
        {
            int idCuenta = this.conBusCtaAho.idcuenta;
            DataTable dtListaRegDocCTS = new clsCNRegDocumentoCTS().CNListarRegDocumentosCTSByCuenta(idCuenta);

            if (dtListaRegDocCTS.Rows.Count != 0)
            {
                string cMsg = "La cuenta tiene los siguientes documentos por regularizar: \n\n";
                bool bMsg = false;

                foreach (DataRow item in dtListaRegDocCTS.Rows)
                {
                    if (Convert.ToBoolean(item["bEnviado"]) == false)
                    {
                        cMsg += "\t- " + item["cDenominacion"] + " [No enviado]\n";
                        bMsg = true;
                    }

                    if (Convert.ToBoolean(item["bFirmado"]) == false)
                    {
                        cMsg += "\t- " + item["cDenominacion"] + " [No firmado]\n";
                        bMsg = true;
                    }
                }

                if (bMsg)
                {
                    MessageBox.Show(cMsg, "Revisión de documentos pendientes CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            if (lisCtaCTS==true && dtListaRegDocCTS.Rows.Count==0)
            {
                MessageBox.Show("No existen documentos registrados para la cuenta. Regístrelos", "Revisión de documentos pendientes CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

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
            Decimal nMonto = Convert.ToDecimal (txtMontOpe.Text);

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, Convert.ToInt32(cboTipoPersona.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue),
                                                        idCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCta, x_idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal (dtComision.Compute("SUM(nValorAplica)", ""));
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
            txtNumFirmas.Text = "0";
            //--Datos de Montos
            txtMontOpe.Text = "0.00";
            txtComision.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtMontTotal.Text = "0.00";
            txtMontEnt.Text = "0.00";
            ptbFirma.Image=null;

            //--Datos de Tipos de pago
            cboModPago.SelectedValue = 1;
            cboTipoPersona.SelectedValue = 1;
            if (cboMotivoOperacion.Items.Count > 0)
            {
                cboMotivoOperacion.SelectedIndex = 0;
            }
            LimpiarTiposdePago();

            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();

            //Limpiar Datos Cli Ope
            conDatPerReaOperac.txtDocIdePerson.Text = "";
            conDatPerReaOperac.txtNombrePerson.Text = "";
            conDatPerReaOperac.txtDireccPerson.Text = "";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }

            if (!string.IsNullOrEmpty(txtNroCta.Text) && Convert.ToInt32(txtNroCta.Text) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(txtNroCta.Text));
            }
            if (!string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoTransf.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoTransf.idcuenta));
            }
            lisCtaCTS = false;
            LimpiarCtrl();
            LimpiarOtrosCtrl();
            LimpiarCtrCheqGer();
            conBusCtaAhoTransf.LimpiarControles();
            conSolesDolar.iMagenMoneda(1);
            conBusCtaAho.idcuenta = 0;
            conBusCtaAhoTransf.idcuenta = 0;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            txtMontOpe.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            dtgIntervinientes.Enabled = false;
            txtMontOpe.Enabled = false;
            btnComision.Enabled = false;
            btnGrabar.Enabled = false;
            conDatPerReaOperac.DesabilitarCtrls();
            conBusCtaAho.btnBusCliente.Enabled = true;
            cboModPago.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.txtCodAge.Focus();

            idTipoIntervBeneficiario = 0;
            idCliBeneficiario = 0;
            lblSegmento.Text = string.Empty;
        }
        private void LimpiarOtrosCtrl()
        {
            conBusCtaAho.LimpiarControles();
            ptbFirma.Image = null;
        }

        private bool ValidarDatosOpe()
        {
            if (cboMotivoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo de la Operación...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return false;
            }
            if (!lTieneAutCTS)
            {
                if (Convert.ToInt16(cboMotivoOperacion.SelectedValue)==9 || Convert.ToInt16(cboMotivoOperacion.SelectedValue)==10)
                {
                    MessageBox.Show("Dicho Motivo de Operación, requiere Autorización...Seleccionar otro Motivo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMotivoOperacion.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosOpe())
            {
                return;
            }

            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            int idCliValid = 0;
            DataTable dtIntervinientes = dtgIntervinientes.DataSource as DataTable;
            if (dtIntervinientes != null)
            {
                DataRow row = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                        .OrderBy(x => Convert.ToInt32(x["idCli"]))
                                                        .FirstOrDefault();
                idCliValid = row != null ? Convert.ToInt32(row["idCli"]) : 0;
            }
            var lstTitulares = dtIntervinientes.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(idCliValid, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, this.x_nTipOpe, Convert.ToInt32(this.conBusCtaAho.txtCodCli.Text));
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            /*========================================================================================
               * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Retiro de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (Convert.ToDecimal (txtMontOpe.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontOpe.Focus();
                return;
            }
            if (!ValidarDatosTipPago())
            {
                return;
            }
            if (!ValidarDatCliOpe())  //--Validar Datos del Cliente que realiza la Operación
            {
                return;
            }
            if (!ValidarFirmasReqOpe())  //--Validar Firmas Requeridas
            {
                return;
            }

            Decimal nMonOpeVal = Convert.ToDecimal (this.txtMontOpe.Text.ToString());
            if (nMonOpeVal < nMonMinOpe)
            {
                MessageBox.Show("El Monto Mínimo de Operación debe Ser: " + nMonMinOpe.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMontOpe.SelectAll();
                this.txtMontOpe.Focus();
                this.txtComision.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontTotal.Text = "0.00";
                this.txtMontEnt.Text = "0.00";
                return;
            }

            if (lisBloCta)
            {
                //--Validar Monto Máximo a Retirar
                if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...(Cuenta Tiene Bloqueo por Monto)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            else
            {
                //--Validar Monto Máximo a Retirar
                if (lisCtaCTS && (Convert.ToInt16(cboMotivoOperacion.SelectedValue)==9 || Convert.ToInt16(cboMotivoOperacion.SelectedValue)==10))
                {
                    if (nMonTotAho < nMonOpeVal)
                    {
                        MessageBox.Show("El Saldo total de la Cuenta es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                else
                {
                    if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                    {
                        MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            }

            if (!lisCtaCTS && (Convert.ToInt16(cboMotivoOperacion.SelectedValue)!=9 || Convert.ToInt16(cboMotivoOperacion.SelectedValue)!=10))
            {
                if (nSaldoDisp - nMonBloqCta - nMonOpeVal < nMonMinSalDis)
                {
                    MessageBox.Show("El Saldo Mínimo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            Decimal nMonComis = Convert.ToDecimal (txtComision.Text);
            Decimal nMonITF = Convert.ToDecimal (txtImpuesto.Text);
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue),
                idMon = Convert.ToInt16(cboMoneda.SelectedValue);
            int x_idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasNivelApr())
            {
                return;
            }

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();

            if (Convert.ToInt32(cboModPago.SelectedValue) >= 2 )  //Pago con documentos, Cheque, interbancario, ordpag, etc
            {
                switch (Convert.ToInt32(cboModPago.SelectedValue))
                {
                    case 2: //Retiro con Transferencia de Cuentas
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
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["idTipoValorado"] = 3;
                        drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                        drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                        drPag["nNroFolio"] = "0";
                        break;
                    case 4: //Tipo Interbancario
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["idTipoValorado"] = 4;
                        drPag["cNroCuentaDoc"] = cboCuenta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                        drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                        drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                        drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                        drPag["nNroFolio"] = "0";
                        drPag["idEntidadDestino"] = cboEntidadDestino.SelectedIndex == -1 ? 0 : Convert.ToInt32(cboEntidadDestino.SelectedValue);
                        drPag["cNroCtaDestino"] = txtCtaDestino.Text;
                        break;
                    case 5:  //Tipo OP
                        drPag["idEntidad"] = cboEnt.SelectedValue;
                        drPag["idTipoValorado"] = 5;
                        drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                        drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                        drPag["cSerieDocumento"] = txtSerie.Text.Trim();
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
            DataSet dsTipPago = new DataSet("dsRetiro");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dsComision = new DataSet("dsRetiro");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable dtInterv = (DataTable)dtgIntervinientes.DataSource;
            DataSet dsIntervin = new DataSet("dsRetiro");
            dsIntervin.Tables.Add(dtInterv);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());


            //--====================================================
            //--Variables Adicionales
            //--====================================================
            string cNroDocPag = txtNroDocu.Text.Trim();

            //--id Cliente Afe ITF
            int idCliITF = RetornaIdCli();
            int idCanal = 1;

            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglas())
            {
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsIntervin.Tables.Clear();
                dsIntervin.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }

            //--===============================================================
            //--Cliente que Realiza la Operación
            //--===============================================================
            string cDniCliOpe = conDatPerReaOperac.txtDocIdePerson.Text.Trim(),
                    cNomCliOpe = conDatPerReaOperac.txtNombrePerson.Text.Trim(),
                    cDirCliOpe = conDatPerReaOperac.txtDireccPerson.Text.Trim();

            //===================================================================
            //---VALIDACION DE CLIENTE PEP         
            //===================================================================
            for (int i = 0; i < dtInterv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtInterv.Rows[i]["isReqFirma"].ToString()))
                {
                    string mensaje = "",
                        x_cNroDni = "";
                    int x_idEstApr = 0;
                    int CodCliente = Convert.ToInt32(dtInterv.Rows[i]["idCli"].ToString());
                    int CodidTipoDocumento = Convert.ToInt32(dtInterv.Rows[i]["idTipoDocumento"].ToString());

                    if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
                    {
                        MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (x_idEstApr == 1) //--Solicitado
                        {
                            frmPep frmPepx = new frmPep(CodidTipoDocumento,x_cNroDni);
                            frmPepx.ShowDialog();
                        }
                        dsComision.Tables.Clear();
                        dsComision.Dispose();
                        dsIntervin.Tables.Clear();
                        dsIntervin.Dispose();
                        dsTipPago.Tables.Clear();
                        dsTipPago.Dispose();
                        return;
                    }
                }
            }

            //-----------------------------------------------------------------------------
            //--valida Saldos de Caja
            //-----------------------------------------------------------------------------

            if (Convert.ToInt16(cboModPago.SelectedValue) == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 2, nMonOpe))
                {
                    dsComision.Tables.Clear();
                    dsComision.Dispose();
                    dsIntervin.Tables.Clear();
                    dsIntervin.Dispose();
                    dsTipPago.Tables.Clear();
                    dsTipPago.Dispose();
                    return;
                }

                #region Huellas
                if (clsVarGlobal.User.lAutBiometricaAgencia)
                {
                    var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                            .OrderBy(x => Convert.ToInt32(x["idCli"]));
                    if (!oBiometrico.validacionBiometrica(
                            listFirmantes
                            , Convert.ToInt32(cboMoneda.SelectedValue)
                            , idProd
                            , Convert.ToDecimal(this.txtMontEnt.Text.ToString())
                            , Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoRetiro"])))
                    {
                        dsComision.Tables.Clear();
                        dsComision.Dispose();
                        dsIntervin.Tables.Clear();
                        dsIntervin.Dispose();
                        dsTipPago.Tables.Clear();
                        dsTipPago.Dispose();
                        return;
                    }
                }
                #endregion
            }

            

            //--===============================================================
            //--Registrar Operación de RETIRO
            //--===============================================================
            int idkardex = 0;
            int nMotPagoId = Convert.ToInt16(cboModPago.SelectedValue);

            int[] nMotPagoSaldoCaja = new int[2];
            nMotPagoSaldoCaja[0] = 1;
            nMotPagoSaldoCaja[1] = 5;

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 2; //EGRESO

            if (nMotPagoId.In(nMotPagoSaldoCaja))
                lModificaSaldoLinea = true;

            DataTable tbRegApe = clsDeposito.CNRegistraRetiroAHO(xmlTipPago, xmlComision, xmlInterv, nidCta, nMonOpe, idMon, nMonComis, nMonITF, nMonRedondeo, nMonCapital, clsVarGlobal.User.idUsuario,
                                                                clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, idProd, cNroDocPag,
                                                                idTipPago, idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, x_idMotivoOpe,
                                                                idTipoTransac, lModificaSaldoLinea);

            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE OPERACIÓN: " + tbRegApe.Rows[0]["idNroOpe"].ToString(), "Retiro de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idkardex = Convert.ToInt32(tbRegApe.Rows[0]["idNroOpe"].ToString());
                if(clsVarGlobal.User.lAutBiometricaAgencia)
                {
                    oBiometrico.registrarOperacionKardexExcepcion(idkardex);
                }
                
            }
            else
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Retiro de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsIntervin.Tables.Clear();
                dsIntervin.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }
            this.tbcPagos.Controls["tabTransf"].Enabled = false;
            this.tbcPagos.Controls["tabCheq"].Enabled = false;
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            dtgIntervinientes.Enabled = false;
            txtMontOpe.Enabled = false;
            btnComision.Enabled = false;
            cboModPago.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnCancelar.Enabled = true;
            conDatPerReaOperac.txtDocIdePerson.Enabled = false;
            conDatPerReaOperac.DesabilitarCtrls();
            if (!string.IsNullOrEmpty(txtNroCta.Text) && Convert.ToInt32(txtNroCta.Text) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(txtNroCta.Text));
            }
            clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            ActualizarNivelApr(idSolApr);

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
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idkardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idkardex);
            }

            //--------------------------------------------------------------------------------
            //Impresion del voucher
            //--------------------------------------------------------------------------------
            if (idkardex > 0)
            {
                ImpresionVoucher(idkardex, clsVarGlobal.idModulo, x_nTipOpe, 1, 0, 0, 0, 1);//Parámetros que se requieren kardex,Modulo,TipoOperacion,MOntoRecibido, MontoDVuelto, KardexEgreso caso Habilitacion                
            }

            //-----------------------------------------------------------------------
            //Validacion de Declaracion Jurada de Sujetos Obligados
            //-----------------------------------------------------------------------
            DeclaracionJuradaCli();

            //this.objFrmSemaforo.ValidarSaldoSemaforo();

            /*========================================================================================
               * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Fin-Retiro de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            dsComision.Tables.Clear();
            dsComision.Dispose();
            dsIntervin.Tables.Clear();
            dsIntervin.Dispose();
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

        private void DeclaracionJuradaCli()
        {
            int idCli = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 6 && Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value))
                {
                    idCli = Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idCli"].Value);
                    frmDeclaracionJurada declara = new frmDeclaracionJurada(idCli);
                }
            }
        }

        private Boolean ValidarFirmasReqOpe()
        {
            //--idTipoDocumento --
            int nNroFirmas = 0;
            //-----------------------------------------------------------------
            //--Validamos que una Jurídica no puede Firmar
            //-----------------------------------------------------------------
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoPersona"].Value) >= 2)
                {
                    nNroFirmas++;
                    MessageBox.Show("La Persona Jurídica no pede Firmar para la Operación...Por Favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                if (!lIsDepMenEdad)
                {
                    if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoPersona"].Value) == 1 && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["nEdadCli"].Value) < 18)
                    {
                        nNroFirmas++;
                        MessageBox.Show("El Cliente es menor de Edad, No puede firmar para la operación...Por Favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                else if (Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == Convert.ToInt32(clsVarApl.dicVarGen["idTipoIntervBeneficiario"]))
                {
                    if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoPersona"].Value) == 1 && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["nEdadCli"].Value) < 18)
                    {
                        nNroFirmas++;
                        MessageBox.Show("El Cliente BENEFICIARIO menor de Edad, No puede firmar para la operación...Por Favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }

            }

            if (nNroFirmas>0)
            {
                return false;
            }

            //-----------------------------------------------------------------
            //--Validamos la cantidad de firmas Requeridas
            //-----------------------------------------------------------------
            nNroFirmas = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value))
                {
                    nNroFirmas++;
                }
            }
            Int16 nNroFirReq = Convert.ToInt16(txtNumFirmas.Text);
            if (nNroFirmas!=nNroFirReq)
            {
                MessageBox.Show("El Número de Firmas Requeridos, no es igual a lo Establecido para la Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarDatCliOpe()
        {
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
                MessageBox.Show("Debe Registrar el Nro Oficial de Identificación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }

            if (conDatPerReaOperac.txtDocIdePerson.Text.Trim().Length < 4)
            {
                MessageBox.Show("El Nro de Documento nos es Válido...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cboTipoEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEnt.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEnt.SelectedValue);
                cboEnt.CargarEntidades(nTipEnt);
            }
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            frmComisionesCta frmComisCta = new frmComisionesCta();
            frmComisCta.dtCom = dtComision;
            frmComisCta.ShowDialog();
        }

        private void txtMontOpe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                calcular();
            }
        }

        private void txtMontOpe_Leave(object sender, EventArgs e)
        {
            calcular();
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
            if (!ValidarOP())
            {
                return;
            }
            int idCuenta = Convert.ToInt32(txtNroCta.Text),
                nNumero = Convert.ToInt32(txtNroDocu.Text),
                nSerie = Convert.ToInt32(txtSerie.Text),
                idMoneda = Convert.ToInt32(cboMoneda.SelectedValue),
                nTipValorado = 1; //--Orden de Pago
            p_idCtaTranf = idCuenta;

            btnGrabar.Enabled = false;

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

                if (Convert.ToDecimal (dt.Rows[0]["nSaldoDis"].ToString()) < Convert.ToDecimal (txtMontOpe.Text))
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
            }
            else
            {
                MessageBox.Show("Los Datos de la Orden de Pago no son Validos...Verificar", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void frmRetiroAho_FormClosed(object sender, FormClosedEventArgs e)
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

        private void MostrarFirma(int idCliente)
        {
            ptbFirma.Image = null;
            var objFirma=cnFirma.retornaFirma(idCliente);
            if (objFirma != null)
            {
                ptbFirma.Image = objFirma.imgFirma;
                ptbFirma.Refresh();
            }

        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count>0)
            {
                MostrarFirma(Convert.ToInt32(dtgIntervinientes.CurrentRow.Cells["idCli"].Value));
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
            //---
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
            drfila[1] = nSaldoDisp.ToString();
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
            drfila[0] = "nMontoRetiro";
            drfila[1] = txtMontTotal.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoEntregar";
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
            drfila[0] = "idCliBeneficiario";
            drfila[1] = idCliBeneficiario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoPorRetirar";
            drfila[1] = Convert.ToDecimal(this.txtMontEnt.Text.ToString());
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
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
                    conBusCtaAho.txtCodIns.Text = "";
                    conBusCtaAho.txtCodAge.Text = "";
                    conBusCtaAho.txtCodMod.Text = "";
                    conBusCtaAho.txtCodMon.Text = "";
                    conBusCtaAho.txtNroCta.Text = "";
                    conBusCtaAho.txtCodCli.Text = "";
                    conBusCtaAho.txtNroDoc.Text = "";
                    conBusCtaAho.txtNombre.Text = "";
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

        private void btnBusCheGer_Click(object sender, EventArgs e)
        {
            string cNroDNI = conBusCtaAho.txtNroDoc.Text.Trim();
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = conBusCtaAho.txtCodCli.Text;
            frmChequeByCli.idMotOpeBco = 0; // Todos
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.cNroDNI = cNroDNI;
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text=frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text=frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text=frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
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

        private void cboTipoEntDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntDestino.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntDestino.SelectedValue);
                cboEntidadDestino.CargarEntidades(nTipEnt);
            }
        }

        private void rbtMismaCta_CheckedChanged(object sender, EventArgs e)
        {
            if (conBusCtaAhoTransf.idcuenta>0)
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

        private void txtNroCta_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue) == 5)
            {
                this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
            }
        }

        private void chcOP_CheckedChanged(object sender, EventArgs e)
        {
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
