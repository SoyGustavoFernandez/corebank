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
using  GEN.ControlesBase;
using DEP.CapaNegocio;
using GEN.Funciones;
using CLI.CapaNegocio;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmTransferenciasCtas : frmBase
    {
        bool lIsAfectoITFDep, lIsAfectoITFRep, lIsDepAhoProg, lisBloCta, lisCtaOP, lIsDepMenEdad;
        private DataTable dtPlanPago = new DataTable("dtPlanPago");
        Decimal nMonMinOpeOri = 0.00m, nMonMinOpeDest=0.00m, nMonMinSalDisOrigen = 0.00m, nMonMinSalDisDest = 0.00m, nSaldoDisp = 0.00m, nMonBloqCta = 0.00m;
        int idProd = 0, nPlaCta = 0, x_nTipOpe = 11, p_idCta = 0, p_idCta1 = 0, idSolApr = 0, IdMonedaCre = 0, idCliOrigen, idCliDestino,
                        idTipoPersonaOrigen, idProductoOrigen, nPlaCtaOrigen, idMonedaAporte, idKardexRet, TbSelec = 0,
                        p_idCtaRetiro=0, p_idCtaDeposito=0, p_idCtaCredito = 0;
        DataTable dtComisionDep= new DataTable(), dtComisionRet=new DataTable(), dtbAhoPrg= new DataTable(),dtbIntervCtaRet= new DataTable();
        DataTable p_dtAporte, p_dtFondo;
        decimal nMonto = 0, nMontoOpeRet=0, nITFNormal = 0,nmonAportePac = 0, nmonFondoPac = 0;
        clsSocio objsocio = null;
        clsCNSocio cnsocio = new clsCNSocio();
        clsCNAporte cnaporte = new clsCNAporte();
        clsCNFondoMortuorio cnfondo = new clsCNFondoMortuorio();
        clsCNBeneficiario cnbeneficiario = new clsCNBeneficiario();
        clsFunUtiles objFunciones = new clsFunUtiles();
        string cDniCliOpe, cNomCliOpe, xmlPpg;
        clsCNCliente cnCliente = new clsCNCliente();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNFirmas cnFirma = new clsCNFirmas();

        private DataTable dtCredito = new DataTable("dtCredito");
        int idTipoAporte = 0;
        public frmTransferenciasCtas()
        {
            InitializeComponent();
        }

        private void frmTransferenciasCtas_Load(object sender, EventArgs e)
        {            
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            conSolesDolar.iMagenMoneda(0);
            txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            conBusCtaAhoOrigen.nTipOpe = x_nTipOpe;  //--Operación de Retiro
            conBusCtaAhoOrigen.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            txtMontOpeTraDep.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCtaAhoOrigen.txtNroCta.Focus();
    
            conBusCtaAhoDestino.nTipOpe = 10;  //--Operación de Deposito
            conBusCtaAhoDestino.pnIdMon = 0;
            this.conBusCuentaCreDestino.cTipoBusqueda = "C";
            this.conBusCuentaCreDestino.cEstado = "[5]";
            conBusCtaAhoDestino.Enabled = false;
            conBusCuentaCreDestino.Enabled = false;
            conBusCliAporteDestino.Enabled = false;
            p_dtAporte = clsDeposito.CNRetDetalleAportes(0, 0);
            p_dtFondo = clsDeposito.CNRetDetalleFondos(0, 0);
            chcCreditos.Enabled = false;
            chcDeposito.Enabled = false;
            chcAporte.Enabled = false;
            //------- cargar tipo de seguro ---------------->
            DataTable dtTipoFondoSeguro = new clsCNSocio().listarTipoFondoSeguro();

            dtTipoFondoSeguro.Rows.Add(0, "Sin Fondo");
            cboTipoFondoSeguro.DataSource = dtTipoFondoSeguro;
            cboTipoFondoSeguro.ValueMember = dtTipoFondoSeguro.Columns["idTipoFondoSeguro"].ToString();
            cboTipoFondoSeguro.DisplayMember = dtTipoFondoSeguro.Columns["cTipoFondoSeguro"].ToString();
            cboTipoFondoSeguro.SelectedIndex = -1;
            this.tbcBase1.TabPages[2].Dispose();
        }

        private void conBusCtaAhoOrigen_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarCtrl();
            chcCreditos.Enabled = false;
            chcDeposito.Enabled = false;
            chcAporte.Enabled = false;
            p_idCta = 0;
            p_idCtaRetiro = 0;
            btnComision.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCtaAhoOrigen.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text) > 0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text);
                p_idCtaRetiro = p_idCta;
                idCliOrigen = conBusCtaAhoOrigen.idcli;
                DatosCuenta(p_idCta);
            }
        }
        public void LimpiarCtrl()
        {
            p_idCta = 0;
            txtProductoOrigen.Text="";
            txtNumFirOri.Text="0";
            cboMonedaOrigen.SelectedValue=1;
            txtSaldoDisp.Text = "0.00";
            cboTipoCuentaOrigen.SelectedValue=1;
            txtITFRet.Text="0.00";
            txtComisionRetiro.Text ="0.00";
            txtTotalOpeTrans.Text = "0.00";
            txtTotPagar.Text = "0.00";
            nPlaCtaOrigen = 0;
            dtComisionRet.Dispose();
            nMontoOpeRet = 0;
            lIsAfectoITFRep=false;
            lisCtaOP = false;
            lIsDepMenEdad = false;
            idKardexRet = 0;
            nMonMinOpeOri = 0.00m;
            nMonMinSalDisOrigen = 0.00m;
            txtTotAporte.Text = "0.00";
            txtTotFondo.Text = "0.00";
            nSaldoDisp = 0.00m;
            nMonBloqCta = 0.00m;
            idTipoPersonaOrigen=0;
            idProductoOrigen=0; 
            idCliOrigen=0;
            idSolApr = 0;
            lisBloCta = false;
            chcCreditos.Checked = false;
            chcDeposito.Checked = false;
            chcAporte.Checked = false;
        }
        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private void DatosCuenta(int idCta)
        { 
            btnGrabar.Enabled = false;
            txtMontOpeTraDep.Enabled = false;
            conSolesDolar.iMagenMoneda(0);
            txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGray;
            txtMontEnt.BackColor = System.Drawing.Color.LightGray;
            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, x_nTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                p_idCta = 0;
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
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_idCta = 0;
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()) == 4)
                {
                    MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                txtProductoOrigen.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                idTipoPersonaOrigen = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString());
                idProductoOrigen = Convert.ToInt16(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                cboMonedaOrigen.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuentaOrigen.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtNumFirOri.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                txtSaldoDisp.Text = dtbNumCuentas.Rows[0]["nSaldoDis"].ToString();
                lIsAfectoITFRep = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpeOri = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                nMonMinSalDisOrigen = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoMinimo"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                nSaldoDisp = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                nPlaCtaOrigen = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonBloqCta = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonTotBloq"].ToString());
                lisBloCta = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisBloqCta"].ToString());
                lisCtaOP = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsCtaOrdPago"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                if (nMonBloqCta >= nSaldoDisp)
                {
                    MessageBox.Show("La Cuenta no Tiene Saldo, porque Tiene Bloqueo por Monto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinOpeOri + nMonMinSalDisOrigen)
                {
                    MessageBox.Show("El Saldo Disponible, es Menor a Monto Mínimo Permitido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinSalDisOrigen)
                {
                    MessageBox.Show("El Saldo de la Cuenta, es Menor al Saldo Mínimo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

            }
            else
            {
                txtMontOpeTraDep.Enabled = false;
                LimpiarOtrosCtrl();
                return;
            }
            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            dtbIntervCtaRet = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
            if (dtbIntervCtaRet.Rows.Count == 0)
            {
                MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCtrl();
                LimpiarOtrosCtrl();
                txtMontOpeTraDep.Enabled = false;
                btnGrabar.Enabled = false;
                return;
            }
            conBusCtaAhoOrigen.btnBusCliente.Enabled = false;
            conBusCtaAhoOrigen.txtNroCta.Enabled = false;
            clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontEnt.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
            else
            {
                txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGreen;
                txtMontEnt.BackColor = System.Drawing.Color.LightGreen;
            }
            conSolesDolar1.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));
            tbcBase1.SelectedIndex = 0;
            conBusCuentaCreDestino.Enabled = true;
            conBusCuentaCreDestino.txtNroBusqueda.Focus();
            chcCreditos.Checked = true;
            btnCancelar1.Enabled = true;
            chcCreditos.Enabled = true;
            chcDeposito.Enabled = true;
            chcAporte.Enabled = true;

        }
        private void LimpiarOtrosCtrl()
        {
            conBusCtaAhoOrigen.txtCodIns.Text = "";
            conBusCtaAhoOrigen.txtCodAge.Text = "";
            conBusCtaAhoOrigen.txtCodMod.Text = "";
            conBusCtaAhoOrigen.txtCodMon.Text = "";
            conBusCtaAhoOrigen.txtNroCta.Text = "";
            conBusCtaAhoOrigen.txtCodCli.Text = "";
            conBusCtaAhoOrigen.txtNroDoc.Text = "";
            conBusCtaAhoOrigen.txtNombre.Text = "";
            p_idCtaRetiro = 0;
        }
        private void LimpiarOtrosCtrlDep()
        {
            conBusCtaAhoDestino.txtCodIns.Text = "";
            conBusCtaAhoDestino.txtCodAge.Text = "";
            conBusCtaAhoDestino.txtCodMod.Text = "";
            conBusCtaAhoDestino.txtCodMon.Text = "";
            conBusCtaAhoDestino.txtNroCta.Text = "";
            conBusCtaAhoDestino.txtCodCli.Text = "";
            conBusCtaAhoDestino.txtNroDoc.Text = "";
            conBusCtaAhoDestino.txtNombre.Text = "";
            p_idCtaDeposito = 0;
        }
        //--====================================================================================
        //--Calcular Itf, Comisiones
        //--====================================================================================
        private void calcularRet()
        {
            
            if (string.IsNullOrEmpty(this.conBusCtaAhoOrigen.txtNroCta.Text.ToString()))
            {
                return;
            }
            else
            {
                nMonto = Convert.ToDecimal(txtMCTotalPago.Text) + Convert.ToDecimal(txtMontOpeTraDep.Text) + Convert.ToDecimal(txtTotPagar.Text);
                    
                    if (nMonto == 0)
                    {
                        btnGrabar.Enabled = false;
                        this.txtMontOpeTraDep.SelectAll();
                        this.txtMontOpeTraDep.Focus();
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
                    ComisionRetiro();
                    Decimal nComision = Convert.ToDecimal (txtComision.Text);

                    Decimal nITF;
                    if (!lIsAfectoITFRep)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        if (idCliOrigen==idCliDestino)
                        {
                            nITF = 0;
                        }
                        else
                        {
                            nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, (Int32)this.cboMoneda.SelectedValue);
                        }
                        
                    }

                    this.txtITFRet.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtComisionRetiro.Text = string.Format("{0:#,#0.00}", Math.Round(nComision, 2));
                    this.txtTotalOpeTrans.Text = string.Format("{0:#,#0.00}", (nMonto + Convert.ToDecimal(txtImpuesto.Text) + Convert.ToDecimal(txtComision.Text)) );
                    if (Convert.ToDecimal(txtTotalOpeTrans.Text)>Convert.ToDecimal(txtSaldoDisp.Text))
                    {
                        MessageBox.Show("El Monto Total de la operación supera el Monto disponible de la cuenta","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }       
         
                    btnGrabar.Enabled = true;
                
            }
        }
        //--================================================================
        //--Cargar Comisiones de la Cuenta
        //--================================================================
        private void ComisionDep()
        {
            dtComisionDep = null;
            int x_idTipoPago = 2;
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            int idCta = Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text);
            Decimal nMonto = Convert.ToDecimal (txtMontOpeTraDep.Text);

            dtComisionDep = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, Convert.ToInt32(cboTipoPersona.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue),
                                                        idCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCta, x_idTipoPago);
            if (dtComisionDep.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal (dtComisionDep.Compute("SUM(nValorAplica)", ""));
                txtComision.Text = nTotCom.ToString();
                btnComision.Enabled = true;
            }
            else
            {
                txtComision.Text = "0.00";
                btnComision.Enabled = false;
            }
        }
        //--================================================================
        //--Cargar Comisiones de la Cuenta
        //--================================================================
        private void ComisionRetiro()
        {
            dtComisionRet = null;
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            int idCta = Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text);
            Decimal nMonto =0;
            switch (TbSelec)
            {
                case 0://CREDITOS
                    nMonto = Convert.ToDecimal (txtMCTotalPago.Text);
                    break;
                case 1://AHORROS
                    nMonto = Convert.ToDecimal (txtMontEnt.Text);
                    break;
                case 2://APORTE
                    nMonto = Convert.ToDecimal (txtTotPagar.Text);
                    break;
                default:
                    break;
            }
            
            dtComisionRet = clsBloq.RetornaComisionesCtaOpe(idProductoOrigen, x_nTipOpe, idTipoPersonaOrigen,Convert.ToInt32(cboMonedaOrigen.SelectedValue),
                                                        p_idCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCtaOrigen,2);
            if (dtComisionRet.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal (dtComisionRet.Compute("SUM(nValorAplica)", ""));
                txtComisionRetiro.Text = nTotCom.ToString();
                txtComisionRetiro.Enabled = true;
            }
            else
            {
                txtComisionRetiro.Text = "0.00";
                txtComisionRetiro.Enabled = false;
            }
        }
        private void LimpiarDatosCreditos()
        {
            this.lblTextMoneda.Text = "";

            this.txtTotalCuotas.Text = "";
            this.txtDiasAtrasoVencido.Text = "";
            this.txtNumCuotasVencidas.Text = "";
            this.txtNumCuotasPendientes.Text = "";
            this.txtCPCapital.Text = "";
            this.txtCPInteres.Text = "";
            this.txtCPMoraCredito.Text = "";
            this.txtCPOtros.Text = "";
            this.txtCPTotalPendiente.Text = "";
            this.txtMCMontoNeto.Text = "0.00";
            this.txtMCTotalPago.Text = "0.00";
            this.txtImpuestos.Text = "0.00";
            this.chcBase2.Checked = false;
            this.nudBase1.Value = 0;
            txtMCMora.Text = "0.00";

            //Datos del cliente
            this.conBusCuentaCreDestino.txtCodIns.Text = "";
            this.conBusCuentaCreDestino.txtCodAge.Text = "";
            this.conBusCuentaCreDestino.txtCodMod.Text = "";
            this.conBusCuentaCreDestino.txtCodMon.Text = "";
            this.conBusCuentaCreDestino.txtNroBusqueda.Text = "";

            this.conBusCuentaCreDestino.txtCodCli.Text = "";

            this.conBusCuentaCreDestino.txtNroDoc.Text = "";
            this.conBusCuentaCreDestino.txtEstado.Text = "";

            this.conBusCuentaCreDestino.txtNombreCli.Text = "";

            this.txtMCOtros.Text = "";
            //this.txtBase13.Text   = "";
            this.txtMCInteres.Text = "";
            this.txtMCCapital.Text = "";
            nITFNormal = 0;
            IdMonedaCre = 0;
            this.nudBase1.Enabled = false;
            p_idCtaCredito = 0;
        
        }

        private void conBusCuentaCreDestino_MyClic(object sender, EventArgs e)
        {
            this.cargadatosCreditos();
        }
        private void cargadatosCreditos()
        {
            int nNumCredito = this.conBusCuentaCreDestino.nValBusqueda;
            chcBase2.Enabled = false;
            p_idCtaCredito = 0;
            if (nNumCredito <= 0)
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatosCreditos();
                return;
            }

            if (this.conBusCuentaCreDestino.txtNroBusqueda.Text.Trim() == "")
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatosCreditos();
                return;
            }
            p_idCtaCredito = nNumCredito;

            idCliDestino = conBusCuentaCreDestino.nIdCliente;
            //DataTable dtCredito = new DataTable("dtCredito");
            CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);
            IdMonedaCre = Convert.ToInt32(dtCredito.Rows[0]["idMoneda"].ToString());
            if ((int)cboMonedaOrigen.SelectedValue != IdMonedaCre)
            {
                MessageBox.Show("No se puede Realizar Transferencias de Cuentas de Diferentes tipos de Moneda","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.LimpiarDatosCreditos();
                return;
            }

            this.lblTextMoneda.Text = ((int)dtCredito.Rows[0]["idMoneda"]) == 1 ? "S/." : "$";
            this.lblTextMoneda.Visible = true;

            this.txtTotalCuotas.Text = dtCredito.Rows[0]["nCuotas"].ToString();
            this.txtDiasAtrasoVencido.Text = dtCredito.Rows[0]["nAtraso"].ToString();

            //DataTable dtPlanPago = new DataTable("dtPlanPago");
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();

            DataTable dtDeudaPendiente = new DataTable("dtDeudaPendiente");
            if (dtPlanPago.Rows.Count > 0)
            {
                dtDeudaPendiente = PlanPago.dtCNDeudaPendiente(dtPlanPago, Convert.ToInt32(dtCredito.Rows[0]["nAtraso"]));
                this.txtCPCapital.Text = dtDeudaPendiente.Rows[0]["nCapitalPen"].ToString();
                this.txtCPInteres.Text = dtDeudaPendiente.Rows[0]["nInteresPen"].ToString();
                this.txtCPMoraCredito.Text = dtDeudaPendiente.Rows[0]["nMoraPen"].ToString();
                this.txtCPOtros.Text = dtDeudaPendiente.Rows[0]["nOtrosPen"].ToString();
                this.txtCPTotalPendiente.Text = dtDeudaPendiente.Rows[0]["nTotalPen"].ToString();
                //this.txtNumRea1.Text = dtDeudaPendiente.Rows[0]["nTotalPen"].ToString();
                this.txtMCMontoNeto.Enabled = true;
                FormatoDeuda();
            }
            else
            {
                this.txtCPCapital.Text = "0.00";
                this.txtCPInteres.Text = "0.00";
                this.txtCPOtros.Text = "0.00";
                this.txtCPTotalPendiente.Text = "0.00";
                this.txtMCMontoNeto.Enabled = false;
            }
            txtMCMontoNeto.Enabled = true;
            chcBase2.Enabled = true;
            this.txtMCMontoNeto.Focus();
        }

        private void conBusCuentaCreDestino_MyKey(object sender, KeyPressEventArgs e)
        {
            this.cargadatosCreditos();
        }
        private void FormatoDeuda()
        {
            this.txtCPCapital.Text      = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtCPCapital.Text));
            this.txtCPInteres.Text      = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtCPInteres.Text));
            this.txtCPMoraCredito.Text  = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtCPMoraCredito.Text));
            this.txtCPOtros.Text        = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtCPOtros.Text));
            //this.txtBase10.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtBase10.Text));
        }

        private void conBusCtaAhoDestino_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarCtrlDep();
            p_idCta1 = 0;
            p_idCtaDeposito = 0;
            btnComision.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCtaAhoDestino.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text) > 0)
            {
                p_idCta1 = Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text);
                idCliDestino = Convert.ToInt32(conBusCtaAhoDestino.txtCodCli.Text);
                if (p_idCta == p_idCta1)
                {
                    MessageBox.Show("No se puede realizar Transferencia entre la misma Cuenta","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    LimpiarOtrosCtrlDep();
                    return;
                }
                p_idCtaDeposito = p_idCta1;
                DatosCuentaDep(p_idCta1);
            }
        }
        private void LimpiarCtrlDep()
        {
            //--Datos de la Cuenta
            txtProducto.Text = "";
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            cboTipoPersona.SelectedValue = 1;
            txtNumFirmas.Text = "0";
            //--Datos de Montos
            txtMontOpeTraDep.Text = "0.00";
            txtComision.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtMontTotal.Text = "0.00";
            txtMontEnt.Text = "0.00";
            dtComisionDep.Dispose();
            dtbAhoPrg.Dispose();
            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();             
            }
            
            //--Ahorro Programado
            txtNumTotCuo.Text="0";
            txtSaldoDep.Text = "0.00";
            txtNumCuoVen.Text = "0";
            txtNumCuoPen.Text = "0";
            txtAtraso.Text = "0";
            txtMonCuota.Text = "0.00";
            nMonMinOpeDest = 0.00m;
            nMonMinSalDisDest = 0;
            idProd = 0;
            nPlaCta = 0;
            lIsAfectoITFDep=false;
            lIsDepAhoProg = false;

            if (dtgPlanDeposito.Rows.Count > 0)
            {
                ((DataTable)dtgPlanDeposito.DataSource).Rows.Clear(); 
            }
            
        }
        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private void DatosCuentaDep(int idCta)
        { 
            btnGrabar.Enabled = false;
            txtMontOpeTraDep.Enabled = false;
            conSolesDolar.iMagenMoneda(0);
            txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGray;
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
                LimpiarOtrosCtrlDep();
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
                    LimpiarOtrosCtrlDep();
                    btnGrabar.Enabled = false;
                    return;
                }
                switch (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()))
                {
                    case 4:
                        MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrlDep();
                        btnGrabar.Enabled = false;
                        return;
                    case 5:
                        MessageBox.Show("La Cuenta se Encuentra Vencida, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarOtrosCtrlDep();
                        btnGrabar.Enabled = false;
                        return;
                }
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                lIsAfectoITFDep = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpeDest = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonMinSalDisDest = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoMinimo"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                txtMontOpeTraDep.Enabled = true;
              //  btnGrabar.Enabled = true;
                txtMontOpeTraDep.Select();
                txtMontOpeTraDep.Focus();
                if ((int)cboMonedaOrigen.SelectedValue != (int)cboMoneda.SelectedValue)
                {
                    MessageBox.Show("No se puede Realizar Transferencias de Cuentas de Diferentes Tipos de Moneda", "Validación de transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrlDep();
                    LimpiarOtrosCtrlDep();
                    return;
                }
            }
            else
            {
                txtMontOpeTraDep.Enabled = false;
                LimpiarOtrosCtrlDep();
                return;
            }
            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            DataTable dtbIntervCta;
            dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
            if (dtbIntervCta.Rows.Count>0)
            {
                dtgIntervinientes.DataSource = dtbIntervCta;
            }
            else
            {
                MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarCtrlDep();
                LimpiarOtrosCtrlDep();
                txtMontOpeTraDep.Enabled = false;
                btnGrabar.Enabled = false;
                return;
            }

            //--===================================================================================
            //--Cargar Datos si es Ahorro Programado
            //--===================================================================================
            if (lIsDepAhoProg)
            {
                dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(idCta,1);
                dtgPlanDeposito.DataSource = dtbAhoPrg;
                if (dtbAhoPrg.Rows.Count>0)
                {
                    txtNumTotCuo.Text=dtbAhoPrg.Rows[0]["nNroDepos"].ToString();                    
                    txtNumCuoVen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()) + 1);
                    txtNumCuoPen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNroDepos"].ToString()) - Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()));
                    txtAtraso.Text = dtbAhoPrg.Rows[0]["nDiasAtrazo"].ToString();                                     
                    txtSaldoDep.Text = dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString();
                    txtMonCuota.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    txtMontOpeTraDep.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                //    btnGrabar.Enabled = true;
                    txtMontOpeTraDep.Select();
                    txtMontOpeTraDep.Focus();
                }
                else
                {
                    MessageBox.Show("El Cuenta no Tiene Cronograma de Depositos..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrlDep();
                    LimpiarOtrosCtrlDep();
                    txtMontOpeTraDep.Enabled = false;
                    btnGrabar.Enabled = false;
                    return;
                }
            }
            clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontEnt.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            }
            else
            {
                txtMontOpeTraDep.BackColor = System.Drawing.Color.LightGreen;
                txtMontEnt.BackColor = System.Drawing.Color.LightGreen;
            }
            conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));
            conBusCtaAhoDestino.btnBusCliente.Enabled = false;
            conBusCtaAhoDestino.txtNroCta.Enabled = false;
        }

        private void conBusCliAporteDestino_ClicBuscar(object sender, EventArgs e)
        {

            if (conBusCliAporteDestino.idCli == 0)
            {
                btnCancelar1_Click(sender, e);
                conBusCliAporteDestino.txtCodCli.Enabled = true;
                conBusCliAporteDestino.txtCodCli.Focus();
                dtgAportes.DataSource = null;
                dtgDetalleFondo.DataSource = null;
                return;
            }
            cargarDatosAporte(conBusCliAporteDestino.idCli);
         //===================================================================================>

            if (conBusCliAporteDestino.nidTipoPersona == 1)//PERSONA NATURAL
            {
                txtTotFondo.Enabled = true;
                dtgDetalleFondo.Enabled = true;

                int nEdadCli = 0;
                //======================== Habilitar Apoderado ==========================================>
                nEdadCli = cnCliente.CalcularEdad(conBusCliAporteDestino.idCli, clsVarGlobal.dFecSystem);
                txtTotFondo.ReadOnly = (nEdadCli < 18) ? true : false;
            }
            else //PERSONA JURÍDICA
            {
                txtTotFondo.Enabled = false;
                dtgDetalleFondo.Enabled = false;
              
            } 
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            LimpiarCtrl();
            limpiarControlesBusAporte();
            LimpiarCtrlDep();
            LimpiarDatosCreditos();
            LimpiarOtrosCtrl();
            LimpiarOtrosCtrlDep();
            LimpiarOtroCtrlAporte();
            btnGrabar.Enabled = false;
            btnCancelar1.Enabled = false;
            conBusCtaAhoOrigen.Enabled = true;
            conBusCtaAhoOrigen.btnBusCliente.Enabled = true;
            tbcBase1.SelectedIndex = 0;
            TbSelec = 0;
            conBusCtaAhoOrigen.txtNroCta.Enabled = true;
            conBusCtaAhoOrigen.txtNroCta.Focus();
            conBusCliAporteDestino.Enabled = false;
            conBusCtaAhoDestino.Enabled = false;
            conBusCuentaCreDestino.Enabled = false;
            txtMCMontoNeto.Enabled = false;
            txtTotAporte.Enabled = false;
            txtTotFondo.Enabled = false;
            txtMontOpeTraDep.Enabled = false;
            chcCreditos.Enabled = false;
            chcDeposito.Enabled = false;
            chcAporte.Enabled = false;
            chcBase2.Enabled = false;
            p_idCta=0;
            p_idCta1 = 0;
            p_idCtaRetiro = 0;
            p_idCtaDeposito = 0;
            p_idCtaCredito = 0;
        }
        private void cargarDatosAporte(int idCli)
        {
            objsocio = cnsocio.retornardatossocio(idCli);

            if (objsocio == null)
            {
                limpiarControlesBusAporte();
                MessageBox.Show("Persona seleccionada no es un socio activo", "Validación Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCliAporteDestino.txtCodCli.Enabled = true;
                conBusCliAporteDestino.txtCodCli.Focus();
                dtgAportes.DataSource = null;
                dtgDetalleFondo.DataSource = null;
    
                return;
            }
            else
            {
                Boolean lInscripcionPagado = cnsocio.EstaPagadoInscripcion(objsocio.idInscripcion);
                if (lInscripcionPagado)
                {
                    txtInscripcion.Text = "0.00";
                }
                else
                {
                    txtInscripcion.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal (objsocio.nInscripcion.ToString()));
                }
                
                cboTipoFondoSeguro.SelectedValue = objsocio.idTipoFondoSeguro;
                ////dtgDetalleFondo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dtgDetalleFondo.Columns[3].Width = 80;
                dtgDetalleFondo.Columns[4].Width = 80;
                dtgDetalleFondo.Columns[5].Width = 80;
                dtgDetalleFondo.Columns[6].Width = 80;
                dtgDetalleFondo.Columns[7].Width = 80;

                RetornarAportes(objsocio.idAporte);
                RetornarFondoMortuorio(objsocio.idFondo);
                formatoGrids();
                txtTotAporte.Enabled = true;
                txtTotFondo.Enabled = true;
                txtTotAporte.Focus();
              
            }
        }
        private void RetornarAportes(int idAporte)
        {
            var datAporte = cnaporte.retornardatosaporte(idAporte);

            //txtTotAporte.Text = string.Format("{0:0.00}", 0);
            dtpFecIniAporte.Value = datAporte.dFechaAporte;
            nmonAportePac = datAporte.nMonAporte;

            var lisdetaporte = datAporte.objDetalleAportes.Where(x => x.idEstado == 1).OrderBy(y => y.dFecVenApo).ToList();
            lisdetaporte.ForEach(p => p.lPago = false);

            dtgAportes.DataSource = null;

            dtgAportes.DataSource = lisdetaporte;
            idMonedaAporte = datAporte.idMoneda;
            if ((int)cboMonedaOrigen.SelectedValue!=idMonedaAporte)
            {
                MessageBox.Show("La transferencia no se puede realiza entre cuentas de diferentes tipos de moneda","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                limpiarControlesBusAporte();
                LimpiarOtroCtrlAporte();
                return;
            }
        }
   
        private void RetornarFondoMortuorio(int idAporte)
        {
            var datFondo = cnfondo.retornardatosfondo(objsocio.idFondo);
            nmonFondoPac = datFondo.nMonFondo;
            dtpIniFondo.Value = datFondo.dFechaPago;

            var lisdetfondo = datFondo.objDetalleFondo.Where(x => x.idEstado == 1).OrderBy(y => y.dFecVenApo).ToList();
            lisdetfondo.ForEach(p => p.lPago = false);

            dtgDetalleFondo.DataSource = null;
            dtgDetalleFondo.DataSource = lisdetfondo;

        }
        private void limpiarControlesBusAporte()
        {

            foreach (Control item in conBusCliAporteDestino.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            idMonedaAporte = 0;
            nmonAportePac = 0; 
            nmonFondoPac = 0;
        }
        private void formatoGrids()
        {
            dtgAportes.ReadOnly = false;
            dtgDetalleFondo.ReadOnly = false;


            foreach (DataGridViewColumn item in dtgAportes.Columns)
            {
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.HeaderText == "Sel.")
                {
                    item.ReadOnly = false;
                }
            }
            foreach (DataGridViewColumn item in dtgDetalleFondo.Columns)
            {
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.HeaderText == "Sel.")
                {
                    item.ReadOnly = false;
                }
            }

        }

        private void txtMCMontoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                if (!string.IsNullOrEmpty(this.txtMCMontoNeto.Text))
                {
                    CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
                    Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
                    nMonSalCre = Convert.ToDecimal (string.Format("{0:#,##0.##}", Convert.ToDecimal (nMonSalCre.ToString())));
                    if (Math.Round(nMonSalCre, 2) < Convert.ToDecimal (this.txtMCMontoNeto.Text))
                    {
                        MessageBox.Show("Monto a Pagar no puede exceder al Saldo del Crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    cargadatosCreditos();
                    Decimal nMontoaPagar = Convert.ToDecimal (this.txtMCMontoNeto.Text);
                    clsCNPlanPago PlanPago = new clsCNPlanPago();
                    DataTable dtPlanPagado = new DataTable("dtPlanPagado");
                    dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
                    this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
                    this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
                    //this.txtBase13.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    //this.txtNumRea3.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();

                    this.txtMCTotalPago.Text = calcularTotalCre();
                    
                    FormatoMonto();
                    if (Convert.ToDecimal (txtMCTotalPago.Text) > Convert.ToDecimal (txtSaldoDisp.Text))
                    {
                        MessageBox.Show("Monto a Pagar no puede exceder al Saldo de Ahorro disponible: " + txtSaldoDisp.Text, "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMCCapital.Text = "0.00";
                        txtMCInteres.Text = "0.00";
                        txtMCMora.Text = "0.00";
                        txtMCOtros.Text = "0.00";
                        txtImpuestos.Text="0.00";
                        txtRedondeo.Text ="0.00";
                        txtMCTotalPago.Text = "0.00";
                        this.txtMCMontoNeto.Focus();
                        this.txtMCMontoNeto.SelectAll();
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    this.btnGrabar.Enabled = true;

                    //==========================================
                    //CALCULOS POR EL RETIRO DE LA CUENTA
                    //==========================================
                    calcularRet();
                }
                else
                {
                    this.btnGrabar.Enabled = false;
                    return;
                }
              
            }
        }
        private void FormatoMonto()
        {
            this.txtMCCapital.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtMCCapital.Text));
            this.txtMCInteres.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtMCInteres.Text));
            this.txtMCOtros.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtMCOtros.Text));
            this.txtMCTotalPago.Text = string.Format("{0:#,##0.##}", Convert.ToDecimal (txtMCTotalPago.Text));
        }
        string calcularTotalCre()
        {
            Decimal nMonPago = (Convert.ToDecimal (this.txtMCMontoNeto.Text));

            Decimal nITF;
            if (idCliDestino==idCliOrigen)
            {
                nITF = 0;
            }
            else
            {
                nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, IdMonedaCre);
            }
            //Asignando el ItfNormal (Sin redondeo)
            nITFNormal = clsVarGlobal.nITF / 100.00m * (decimal)nMonPago;
            nITFNormal = objFunciones.truncarNumero(nITFNormal, 2);

            Decimal nMonFavCli = 0.00m;

            //PARA TRANSFERENCIAS NO APLICA REDONDEO

            //////Decimal nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, IdMonedaCre, true, true);
            //////this.txtRedondeo.Text = Math.Round(nMonFavCli, 2).ToString();

            Decimal nMonRedBcr = nMonPago + nITF;
            this.txtRedondeo.Text = Math.Round(nMonFavCli, 2).ToString();

            this.txtImpuestos.Text = Math.Round(nITF, 2).ToString();
            return (nMonRedBcr).ToString();
        }

        private void nudBase1_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudBase1.Value > Convert.ToInt32(this.txtNumCuotasPendientes.Text))
            {
                MessageBox.Show("El Número de cuotas a pagar NO puede exeder las cuotas a pagar ", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar.Enabled = false;
                return;
            }

            clsCNPlanPago PlanPago = new clsCNPlanPago();
            int nNumCredito = this.conBusCuentaCreDestino.nValBusqueda;
            dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();

            this.txtMCMontoNeto.Text = PlanPago.nDeuDaCuotas(dtPlanPago, Convert.ToInt32(this.nudBase1.Value)).ToString();

            Decimal nMontoaPagar = Convert.ToDecimal (this.txtMCMontoNeto.Text);
            if (Convert.ToDecimal (txtMCTotalPago.Text)> Convert.ToDecimal (txtSaldoDisp.Text))
            {
                MessageBox.Show("","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                btnGrabar.Enabled = false;
                txtMCMontoNeto.Focus();
                txtMCMontoNeto.SelectAll();
                return;
            }
            //clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
            this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
            this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
            //this.txtBase13.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            //this.txtNumRea3.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();
            this.txtMCTotalPago.Text = calcularTotalCre();// (Convert.ToDecimal (this.txtNumRea1.Text) + Convert.ToDecimal /*era ToDouble*/(this.txtNumRea3.Text)).ToString();

            FormatoMonto();

            this.btnGrabar.Enabled = true;

            calcularRet();
        }

        private void chcBase2_CheckedChanged(object sender, EventArgs e)
        {
            this.nudBase1.Enabled = this.chcBase2.Checked;
            this.txtMCMontoNeto.Enabled = !this.chcBase2.Checked;
            this.nudBase1.Focus();
        }

        private void txtMontOpe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcularDep();
            }
        }
        private void calcularDep()
        {
            decimal nMonto;
            Decimal nMonFavCli = 0.00m;
            if (string.IsNullOrEmpty(this.conBusCtaAhoDestino.txtNroCta.Text.ToString()))
            {
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtMontOpeTraDep.Text))
                {
                    nMonto = 0;
                    this.txtMontOpeTraDep.Text = nMonto.ToString();
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtNumRea1.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    txtITFRet.Text = "0.00";
                    txtComisionRetiro.Text = "0.00";
                    txtTotalOpeTrans.Text = "0.00";
                    this.txtMontOpeTraDep.SelectAll();
                    return;
                }
                else
                {
                    nMonto = Convert.ToDecimal(this.txtMontOpeTraDep.Text.ToString());
                    if (nMonto == 0)
                    {
                        this.txtMontOpeTraDep.SelectAll();
                        this.txtMontOpeTraDep.Focus();
                        this.txtComision.Text = "0.00";
                        this.txtImpuesto.Text = "0.00";
                        this.txtNumRea1.Text = "0.00";
                        this.txtMontTotal.Text = "0.00";
                        this.txtMontEnt.Text = "0.00";
                        txtITFRet.Text = "0.00";
                        txtComisionRetiro.Text = "0.00";
                        txtTotalOpeTrans.Text = "0.00";
                        return;
                    }

                    if (Convert.ToDecimal(txtMontEnt.Text) > Convert.ToDecimal(txtSaldoDisp.Text))
                    {
                        MessageBox.Show("El monto de depósito no puede ser mayor al monto de disponible de la cuenta de ahorro","Validación de transferencias",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        this.btnGrabar.Enabled = false;
                         this.txtComision.Text = "0.00";
                        this.txtImpuesto.Text = "0.00";
                        this.txtNumRea1.Text = "0.00";
                        this.txtMontTotal.Text = "0.00";
                        this.txtMontEnt.Text = "0.00";
                        txtITFRet.Text = "0.00"; 
                        txtComisionRetiro.Text = "0.00";
                        txtTotalOpeTrans.Text = "0.00";
                        txtMontOpeTraDep.Focus();
                        txtMontOpeTraDep.SelectAll();
                        return;
                    }
                    //--==========================================================
                    //--Calcular Comisiones de la Cuenta
                    //--==========================================================
                    ComisionDep();
                    Decimal nComision = Convert.ToDecimal (txtComision.Text);

                    Decimal nITF;
                    if (!lIsAfectoITFDep)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, (Int32)this.cboMoneda.SelectedValue);
                    }

                    this.txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtComision.Text = string.Format("{0:#,#0.00}", Math.Round(nComision, 2));
                    Decimal nMontoTotal = 0;

                    nMontoTotal = (Decimal)nMonto - Math.Round(nITF, 2) - (Decimal)Math.Round(nComision, 2);


                    this.txtMontTotal.Text = string.Format("{0:#,#0.00}", (nMontoTotal + Math.Round(nMonFavCli, 2)));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((Decimal)nMonto - nMonFavCli));
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));
                    this.txtMontOpeTraDep.Text = string.Format("{0:#,#0.00}", nMonto);
                    btnGrabar.Enabled = true;
                    CalcularTotalTrx();
                }
            }
            calcularRet();

        }

        private void CalcularTotalTrx()
        {
            this.txtTotalOpeTrans.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (txtMCMontoNeto.Text) + Convert.ToDecimal (txtMontEnt.Text) + Convert.ToDecimal (txtTotPagar.Text));
        }

        private void dtgAportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAportes.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgAportes.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;

                var detalleSele = ((clsDetalleAporte)dtgAportes.CurrentRow.DataBoundItem);
                var listadetalleaporte = (List<clsDetalleAporte>)dtgAportes.DataSource;

                var validaorden = listadetalleaporte.Where(x => x.dFecVenApo < detalleSele.dFecVenApo && x.lPago == false).Count();
                var validaorden2 = listadetalleaporte.Where(x => x.lPago == true
                                                            && isChecked == false
                                                            && x.dFecVenApo > detalleSele.dFecVenApo).Count();

                if (validaorden <= 0 && validaorden2 <= 0)
                {
                    detalleSele.lPago = isChecked;
                    sumarTotal();
                }
                else
                {
                    MessageBox.Show("Existe pagos pendientes al seleccionado", "Validación pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgAportes.CancelEdit();
                }
            }
        }

        private void dtgDetalleFondo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDetalleFondo.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox1 = (DataGridViewCheckBoxCell)dtgDetalleFondo.CurrentCell;

                bool isChecked = (bool)checkbox1.EditedFormattedValue;

                var detallefondo = ((clsDetalleFondo)dtgDetalleFondo.CurrentRow.DataBoundItem);
                var listadetallefondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;

                var validaorden = listadetallefondo.Where(x => x.dFecVenApo < detallefondo.dFecVenApo && x.lPago == false).Count();

                var validaorden2 = listadetallefondo.Where(x => x.lPago == true
                                                          && isChecked == false
                                                          && x.dFecVenApo > detallefondo.dFecVenApo).Count();

                if (validaorden <= 0 && validaorden2 <= 0)
                {
                    detallefondo.lPago = isChecked;
                    sumarTotal();
                }
                else
                {
                    MessageBox.Show("Existe pagos pendientes al seleccionado", "Validación pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgDetalleFondo.CancelEdit();
                }
            }
        }
        private void sumarTotal()
        {
            txtTotPagar.ReadOnly = false;
            var aportes = (List<clsDetalleAporte>)dtgAportes.DataSource;
            var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;

            decimal totPagar = aportes.Where(x => x.lPago == true).Sum(p => p.nMonApoPac) +
                                fondo.Where(x => x.lPago == true).Sum(p => p.nMontoPac);

            decimal Aporte = aportes.Where(x => x.lPago == true).Sum(p => p.nMonApoPac);
            decimal Fondo = fondo.Where(x => x.lPago == true).Sum(p => p.nMontoPac);
            txtTotAporte.Text = string.Format("{0:#,##0.##}", Aporte);
            txtTotFondo.Text = string.Format("{0:#,##0.##}", Fondo);
            txtTotPagar.Text = string.Format("{0:#,##0.##}", totPagar);
            txtTotPagar.ReadOnly = true;
            if (totPagar> Convert.ToDecimal(txtSaldoDisp.Text))
            {
                MessageBox.Show("El monto de Operación no puede ser mayor al monto disponible en el cuenta","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtTotAporte.Focus();
                txtTotAporte.SelectAll();
                return;
            }
            CalcularTotalTrx();
            //calcularRet();
        }
        private void LimpiarOtroCtrlAporte()
        {
            dtgAportes.DataSource = null;
            dtgDetalleFondo.DataSource = null;
            txtTotAporte.Text="0.00";
            txtTotFondo.Text = "0.00";
            txtTotPagar.Text = "0.00";
        }

        private void tbcBase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void frmTransferenciasCtas_FormClosed(object sender, FormClosedEventArgs e)
        {
             LiberarCuenta();
        }
        private void LiberarCuenta()
        {
            if (p_idCtaRetiro>0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCtaRetiro);
            }
            if (p_idCtaDeposito > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCtaDeposito);
            }
            if (p_idCtaCredito>0)
            {
                this.conBusCuentaCreDestino.LiberarCuenta();
            }
            
        }
        private void CalcularAporte()
        {
           
            
            idTipoAporte = Convert.ToInt32(cboTipoAporte1.SelectedValue);
            if (string.IsNullOrEmpty(txtTotAporte.Text.Trim()) || Convert.ToDecimal(txtTotAporte.Text.Trim()) <= 0)
            {
                MessageBox.Show("El Monto de Aporte debe ser mayor que 0.00", "Registro de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
            }
            RetornarAportes(objsocio.idAporte);
            decimal nmonto = (decimal)txtTotAporte.nDecValor;
            decimal nmontoFondo = (decimal)txtTotFondo.nDecValor;
            txtTotAporte.Text = nmonto.ToString();
            dtgAportes.DataSource = listardetalleaporte(nmonto, idTipoAporte);
           // sumarTotal();
            dtgAportes.Enabled = true;
            dtgAportes.ReadOnly = false;
            dtgDetalleFondo.Enabled = true;
            dtgDetalleFondo.ReadOnly = false;

            if (dtgAportes.RowCount > 0)
            {
                dtgAportes.Rows[dtgAportes.RowCount - 1].Selected = true;
                dtgAportes.FirstDisplayedScrollingRowIndex = dtgAportes.RowCount - 1;
            }
            txtTotPagar.Text = string.Format("{0:#,##0.##}", nmonto + nmontoFondo);
            

        }
        public clslisDetalleAporte listardetalleaporte(decimal nmonto, int idTipoAporte)
        {
            decimal nAportePactado = 0.00M;

            DateTime dfecMinCalculo;
            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            decimal nmonTotalAprt = nmonto;

            clslisDetalleAporte lista = new clslisDetalleAporte();
            int i = 0, j = 1;

            if (dtgAportes.Rows.Count > 0)
            {
                if (idTipoAporte == 1)
                {
                    var aportes = (List<clsDetalleAporte>)dtgAportes.DataSource;
                    dfecMinCalculo = Convert.ToDateTime(aportes.Min(p => p.dFecVenApo)).AddDays(-1);

                    int nReg = 0;
                    while (nmonTotalAprt > 0.00M && nReg < dtgAportes.Rows.Count)
                    {
                        dfecUltimo = Convert.ToDateTime(aportes.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.dFecVenApo));
                        nAportePactado = Convert.ToDecimal(aportes.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.nMonApoPac));

                        lista.Add(new clsDetalleAporte()
                        {
                            idAporte = aportes.Min(p => p.idAporte),
                            idDetAporte = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idDetAporte),
                            cPeriodo = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.cPeriodo),

                            dFecVenApo = dfecUltimo,
                            idEstado = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idEstado),
                            nMonApoPac = nmonTotalAprt < nAportePactado ? nmonTotalAprt : nAportePactado,
                            nMonApoPag = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.nMonApoPag),
                            nMonApoPac1 = nmonAportePac,
                            lPago = nmonTotalAprt > 0.00M ? true : false
                        });
                        nmonTotalAprt = nmonTotalAprt - (nmonTotalAprt < nAportePactado ? nmonTotalAprt : nAportePactado);
                        dfecMinCalculo = dfecUltimo;
                        nReg += 1;
                    }
                    i += 1;
                    j += 1;
                }
                else
                {
                    //  dtgAportes.DataSource = null;
                    dfecUltimo = clsVarGlobal.dFecSystem;
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte = objsocio.idAporte,
                        idDetAporte = -j,
                        cPeriodo = dfecUltimo.Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo,
                        idEstado = 2,
                        nMonApoPac = nmonTotalAprt,
                        nMonApoPag = 0.00M,
                        nMonApoPac1 = nmonTotalAprt,
                        lPago = true
                    });
                }

            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(objsocio.idAporte, -1, 1);
                if (idTipoAporte == 2)
                {
                    dfecUltimo = clsVarGlobal.dFecSystem;
                }
                else
                {
                    dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(1);
                }

            }

            if (idTipoAporte == 2 && dtgAportes.Rows.Count == 0)
            {
                lista.Add(new clsDetalleAporte()
                {
                    idAporte = objsocio.idAporte,
                    idDetAporte = -j,
                    cPeriodo = dfecUltimo.Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo,
                    idEstado = 2,
                    nMonApoPac = nmonTotalAprt,
                    nMonApoPag = 0.00M,
                    nMonApoPac1 = nmonTotalAprt,
                    lPago = true
                });
            }
            else if (idTipoAporte == 1)
            {
                while (nmonAportePac <= nmonTotalAprt)
                {
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte = objsocio.idAporte,
                        idDetAporte = -j,
                        cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo.AddMonths(i),
                        idEstado = 1,
                        nMonApoPac = nmonAportePac,
                        nMonApoPag = 0.00M,
                        nMonApoPac1 = nmonAportePac,
                        lPago = true
                    });
                    nmonTotalAprt = nmonTotalAprt - nmonAportePac;
                    i += 1;
                    j += 1;
                }

                if (nmonTotalAprt > 0)
                {
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte = objsocio.idAporte,
                        idDetAporte = -j,
                        cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo.AddMonths(i),
                        idEstado = 1,
                        nMonApoPac = nmonTotalAprt,
                        nMonApoPag = 0.00M,
                        nMonApoPac1 = nmonAportePac,
                        lPago = true
                    });
                }
            }

            return lista;
        }

        private void CalcularFondo()
        {

            if (string.IsNullOrEmpty(txtTotFondo.Text.Trim()) || Convert.ToDecimal(txtTotFondo.Text.Trim()) <= 0)
            {
                MessageBox.Show("El Monto de Fondo de Seguro debe ser mayor que 0.00", "Registro de Fondo de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotFondo.Focus();
            }

            RetornarFondoMortuorio(objsocio.idFondo);

            decimal nmonto = txtTotFondo.nDecValor;
            decimal nmontoAporte = txtTotAporte.nDecValor;
            txtTotFondo.Text = nmonto.ToString();

            dtgDetalleFondo.DataSource = listarFondoMortuorio(nmonto);
            sumarTotal();
            dtgAportes.Enabled = true;
            dtgAportes.ReadOnly = false;
            dtgDetalleFondo.Enabled = true;
            dtgDetalleFondo.ReadOnly = false;

            if (dtgDetalleFondo.RowCount > 0)
            {
                dtgDetalleFondo.Rows[dtgDetalleFondo.RowCount - 1].Selected = true;
                dtgDetalleFondo.FirstDisplayedScrollingRowIndex = dtgDetalleFondo.RowCount - 1;
            }
            txtTotPagar.Text = string.Format("{0:#,##0.##}", nmonto + nmontoAporte);
            
        }
        private bool validaMontoPagoAporte()
        {
            decimal suma = 0;
            bool validar = true;
            if (Convert.ToDecimal(txtTotAporte.Text.Trim()) >= 9100000)
            {
                MessageBox.Show("El Monto Total de Aporte Es Demasiado Grande", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            var Aporte = (List<clsDetalleAporte>)dtgAportes.DataSource;
            suma = Aporte.Where(p => Convert.ToDateTime(p.cPeriodo) <= clsVarGlobal.dFecSystem).Sum(y => y.nMonApoPac);
            if (Convert.ToDecimal(txtTotAporte.Text.Trim()) == 0.00M)
            {
                MessageBox.Show("El Monto del Aporte Ingresado debe ser diferente a 0.00", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            return validar;
        }
        private bool validaMontoPagoFondo()
        {
            decimal suma = 0;
            bool validar = true;
            if (Convert.ToDecimal(txtTotFondo.Text.Trim()) >= 9100000)
            {
                MessageBox.Show("El Monto Total del Fondo Es Demasiado Grande", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;
            suma = fondo.Where(p => Convert.ToDateTime(p.cPeriodo) <= clsVarGlobal.dFecSystem).Sum(y => y.nMontoPac);
            if (suma > Convert.ToDecimal(txtTotFondo.Text.Trim()))
            {
                MessageBox.Show("El Monto del Fondo Ingresado es Menor al Pactado", "Validar Fondo Mortuorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotFondo.Focus();
                validar = false;
            }
            return validar;
        }
        public clslisDetalleAporte listardetalleaporte(decimal nmonto)
        {
            decimal nAportePactado = 0.00M;

            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            decimal nmonTotalAprt = nmonto;
            clslisDetalleAporte lista = new clslisDetalleAporte();
            int i = 0, j = 1;

            if (dtgAportes.Rows.Count > 0)
            {
                var aportes = (List<clsDetalleAporte>)dtgAportes.DataSource;
                dfecUltimo = Convert.ToDateTime(aportes.Min(p => p.dFecVenApo));
                nAportePactado = Convert.ToDecimal(aportes.Max(p => p.nMonApoPac));

                lista.Add(new clsDetalleAporte()
                {
                    idAporte = aportes.Min(p => p.idAporte),
                    idDetAporte = aportes.Where(x => x.dFecVenApo == dfecUltimo).Sum(p => p.idDetAporte),
                    cPeriodo = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.cPeriodo),

                    dFecVenApo = dfecUltimo,
                    idEstado = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idEstado),
                    nMonApoPac = nmonTotalAprt < nAportePactado ? nmonTotalAprt : aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.nMonApoPac),
                    nMonApoPag = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.nMonApoPag),
                    lPago = true
                    //lPago      = nmonTotalAprt < nAportePactado ? false : true
                });
                nmonTotalAprt = nmonTotalAprt - aportes.Min(p => p.nMonApoPac);
                i += 1;
                j += 1;
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(objsocio.idAporte, -1, 1);
                dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(1);
            }

            while (nmonAportePac <= nmonTotalAprt)
            {
                lista.Add(new clsDetalleAporte()
                {
                    idAporte = objsocio.idAporte,
                    idDetAporte = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMonApoPac = nmonAportePac,
                    nMonApoPag = 0.00M,
                    lPago = true
                });
                nmonTotalAprt = nmonTotalAprt - nmonAportePac;
                i += 1;
                j += 1;
            }
            if (nmonTotalAprt > 0)
            {
                lista.Add(new clsDetalleAporte()
                {
                    idAporte = objsocio.idAporte,
                    idDetAporte = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMonApoPac = nmonTotalAprt,
                    nMonApoPag = 0.00M,
                    lPago = true
                });
            }
            return lista;
        }
        public clslisDetalleFondo listarFondoMortuorio(decimal nmonto)
        {

            decimal nmonTotalFondo = nmonto;
            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            clsCNGenVariables RetVar = new clsCNGenVariables();
            int nVerSis = Convert.ToInt32(RetVar.RetornaVariable("nFrecFondMor", 0));

            clslisDetalleFondo listaFondoMort = new clslisDetalleFondo();
            int i = 0, j = 1;
            if (dtgDetalleFondo.Rows.Count > 0)
            {
                var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;
                dfecUltimo = Convert.ToDateTime(fondo.Min(p => p.dFecVenApo));

                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo = fondo.Min(p => p.idFondo),
                    idDetFondo = fondo.Min(p => p.idDetFondo),
                    cPeriodo = fondo.Min(p => p.cPeriodo),
                    dFecVenApo = fondo.Min(p => p.dFecVenApo),
                    idEstado = fondo.Min(p => p.idEstado),
                    nMontoPac = fondo.Min(p => p.nMontoPac),
                    nMontoPag = fondo.Min(p => p.nMontoPag),
                    lPago = true
                });
                nmonTotalFondo = nmonTotalFondo - fondo.Min(p => p.nMontoPac);
                i += nVerSis;
                j += 1;
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(-1, objsocio.idFondo, 2);
                dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(nVerSis);
            }

            while (nmonFondoPac <= nmonTotalFondo)
            {
                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo = objsocio.idFondo,
                    idDetFondo = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMontoPac = nmonFondoPac,
                    nMontoPag = 0.00M,
                    lPago = true
                });
                nmonTotalFondo = nmonTotalFondo - nmonFondoPac;
                i += nVerSis;
                j += 1;
            }

            if (nmonTotalFondo > 0)
            {
                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo = objsocio.idFondo,
                    idDetFondo = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMontoPac = nmonTotalFondo,
                    nMontoPag = 0.00M,
                    lPago = true
                });
            }
            return listaFondoMort;
        }

        private void txtTotAporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {                
                CalcularAporte();
                calcularRet();
                CalcularTotalTrx();

            }
            
        }

        private void txtTotAporte_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotAporte.Text))
            {
                if (Convert.ToDecimal (txtTotAporte.Text) > 0)
                {
                    CalcularAporte();
                    calcularRet();
                    CalcularTotalTrx();
                }
            }
           
           // CalcularAporte();
        }

        private void txtTotFondo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {                
                CalcularFondo();
                calcularRet();
                CalcularTotalTrx();
            }
            
        }

        private void txtTotFondo_Leave(object sender, EventArgs e)
        {
            //CalcularFondo();

            if (!string.IsNullOrEmpty(txtTotFondo.Text))
            {
                if (Convert.ToDecimal (txtTotFondo.Text) > 0)
                {
                    CalcularFondo();
                    calcularRet();
                    CalcularTotalTrx();
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
                * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCtaAhoOrigen.idcli, this.conBusCtaAhoOrigen.idcuenta, "Inicio de Transferencia de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            //--===============================================================
            //--Cliente que Realiza la Operación
            //--===============================================================
             cDniCliOpe = conBusCtaAhoOrigen.txtNroDoc.Text.Trim();
             cNomCliOpe = conBusCtaAhoOrigen.txtNombre.Text.Trim();
             if(!ValidarRetiroCuenta()) return;

            //--===============================================================
            //--Validar Pago de Créditos
            //--===============================================================             
             if (chcCreditos.Checked)
             {
                 if(!ValidarPagoCredito()) return;
                 GrabarPagoCredito();
             }

             //--===============================================================
             //--Validar Trasferencia Deposito
             //--===============================================================
             if (chcDeposito.Checked)
             {
                 if(!ValidarDepositoCuenta()) return;
             }

             //--===============================================================
             //--Validar Trasferencia Deposito
             //--===============================================================
             if (chcAporte.Checked)
             {
                 if (CamposSonValidos() == false) return;
             }
             
            //-------------------------------------------------------------
             //-----Grabar Operación Múltiple
             //-------------------------------------------------------------
             GrabarTrxMultiple();
                       
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCtaAhoOrigen.idcli, this.conBusCtaAhoOrigen.idcuenta, "Fin-Transferencia de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }
        private bool ValidarRetiroCuenta()
        {
            if (Convert.ToDecimal (txtTotalOpeTrans.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (!ValidarFirmasReqOpe())  //--Validar Firmas Requeridas
            //{
            //    return false;
            //}

            Decimal nMonOpeVal = Convert.ToDecimal (this.txtTotalOpeTrans.Text.ToString());
            if (nMonOpeVal < nMonMinOpeOri)
            {
                MessageBox.Show("El Monto Mínimo de Operación debe Ser: " + nMonMinOpeOri.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (lisBloCta)
            {
                //--Validar Monto Máximo a Retirar
                if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...(Cuenta Tiene Bloqueo por Monto)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                //--Validar Monto Máximo a Retirar
                if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }
            if (nSaldoDisp - nMonBloqCta - nMonOpeVal < nMonMinSalDisDest)
            {
                MessageBox.Show("El Saldo Mínimo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        private void GrabarTrxMultiple()
        {

             nMontoOpeRet = Convert.ToDecimal(this.txtTotalOpeTrans.Text.ToString());
             Decimal nMonRedondeo = 0.00m;
                   
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            Decimal nMonComis = Convert.ToDecimal (txtComisionRetiro.Text);
            Decimal nMonITF = Convert.ToDecimal (txtITFRet.Text);
            int idTipPago = 2;

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasNivelAprRet())
            {
                return;
            }

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();

            //--Generar XML de Datos del Tipo de Pago
            DataSet dsTipPago = new DataSet("dsRetiro");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());
            
            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dsComision = new DataSet("dsRetiro");
            dsComision.Tables.Add(dtComisionRet);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());
           
            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable dtInterv = dtbIntervCtaRet;
            DataSet dsIntervin = new DataSet("dsRetiro");
            dsIntervin.Tables.Add(dtInterv);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());
            
            //--====================================================
            //--Variables Adicionales
            //--===================================================
            int idCliITF = RetornaIdCliRet();
            int idCanal = 1;

            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglasRet())
            {
                return;
            }

            //-===============================================================
            //--Validar Datos
            //-===============================================================
            bool lisOpeCre = false,
                 lisOpeDep = false,
                 lisOpeApo = false;
            if (chcCreditos.Checked)
            {
                lisOpeCre = true;
            }

            if (chcDeposito.Checked)
            {
                lisOpeDep = true;
            }

            if (chcAporte.Checked)
            {
                lisOpeApo = true;
            }

            //------------------------------------------------------------------------------
            //---------------OPERACIÓN DE DEPOSITO----------------------------------------
            //------------------------------------------------------------------------------
            
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            Decimal nMonOpeDep = Convert.ToDecimal (this.txtMontEnt.Text.ToString()),
                   nMonRedondeoDep = Convert.ToDecimal (this.txtNumRea1.Text.ToString()),
                   nMonComisDep = Convert.ToDecimal (txtComision.Text),
                   nMonITFDep = Convert.ToDecimal (txtImpuesto.Text);
            int nidCtaDep = 0;
            if (!string.IsNullOrEmpty(conBusCtaAhoDestino.txtNroCta.Text))
            {
                nidCtaDep = Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text);
            }
            
            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dsComisionDep = new DataSet("dsDeposito");
            dsComision.Tables.Add(dtComisionDep);
            string xmlComisionDep = clsCNFormatoXML.EncodingXML(dsComision.GetXml());
            dsComision.Tables.Remove(dtComisionDep);
            
            //--==================================================
            //--id Cliente Afe ITF
            //--==================================================
            int idCliITFDep = RetornaIdCli();
                 //nCuota = Convert.ToInt32(txtNumCuoVen.Text);
            
            
            //------------------------------------------------------------------------------
            //---------------OPERACIÓN DE COBRANZA----------------------------------------
            //------------------------------------------------------------------------------   
            if (!chcCreditos.Checked)
            {         
                DataSet ds = new DataSet("dsPlanPagos");
                ds.Tables.Add(dtPlanPago);
                xmlPpg = ds.GetXml();//Solo Plan Pagos
                xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);
                ds.Tables.Remove(dtPlanPago);
                ds.Dispose();                
            }            
            Decimal nMoraPagada = Convert.ToDecimal (this.txtMCMora.Text);
            int nNumCredito = this.conBusCuentaCreDestino.nValBusqueda;
            Decimal nMonRedondeoCre = Convert.ToDecimal (this.txtRedondeo.Text);
            Decimal nImpuestoCre = Convert.ToDecimal (this.txtImpuestos.Text);
            Decimal nMontoCre = Convert.ToDecimal (this.txtMCMontoNeto.Text);  

            //------------------------------------------------------------------------------
            //---------------OPERACIÓN DE PAGO DE FONDO------------------------------------
            //------------------------------------------------------------------------------  
            clslisDetalleAporte detalleaporte = new clslisDetalleAporte();
            clslisDetalleFondo detallefondo = new clslisDetalleFondo();
            if (dtgAportes.Rows.Count > 0)
            {
                detalleaporte.AddRange(((List<clsDetalleAporte>)dtgAportes.DataSource).Where(x => x.lPago == true).ToList());
            }
            if (dtgDetalleFondo.Rows.Count > 0)
            {
                detallefondo.AddRange(((List<clsDetalleFondo>)dtgDetalleFondo.DataSource).Where(x => x.lPago == true).ToList());      
            }
            
            int x_idCli = 0;
            x_idCli = conBusCliAporteDestino.idCli;
            
            ////--===============================================================
            ////--Registrar Operación de RETIRO
            ////--===============================================================
            ////VALIDA CLIENTE PEP
            //if (!conSplaf1.GenerarSolicitudAprobacion(conBusCtaAhoOrigen.idcli, (int)cboMonedaOrigen.SelectedValue, Convert.ToDecimal (txtTotalOpeTrans.Text)))
            //{
            //    return;
            //}
            //
            DataTable tbRegApe = clsDeposito.CNRegistraOpeTransferencias(xmlTipPago, xmlComision, xmlInterv, p_idCta, (Decimal)nMontoOpeRet, (int)cboMonedaOrigen.SelectedValue, nMonComis, nMonITF, nMonRedondeo, Convert.ToDecimal (nMonto), clsVarGlobal.User.idUsuario,
                                                                clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, idProductoOrigen, "",
                                                                idTipPago, idCliITF, cDniCliOpe, cNomCliOpe, "", idCanal,
                                                                //---Parametros Deposito------------------
                                                                nidCtaDep, nMonITFDep, xmlComisionDep, nMonComisDep, nMonOpeDep,
                                                                //----Parametros Pago Crédito-------------
                                                                xmlPpg,nMoraPagada,nNumCredito,nMonRedondeoCre,nImpuestoCre,0.00m,nMontoCre,
                                                                //----Parámetros de Aportes---------------
                                                                detalleaporte, detallefondo, x_idCli, (Decimal)txtTotAporte.nDecValor, (Decimal)txtTotFondo.nDecValor, (int)cboTipoAporte1.SelectedValue,
                                                                //------Variables Adicionales------------------
                                                                lisOpeCre,lisOpeDep,lisOpeApo);

            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Operación de Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //imprime unico voucher de todas las operaciones
                ImprimirVoucherTotal(tbRegApe);
                
                idKardexRet = Convert.ToInt32(tbRegApe.Rows[0]["idKardexDep"].ToString());
                btnGrabar.Enabled = false;
                conBusCtaAhoOrigen.Enabled = false;
                conBusCtaAhoDestino.Enabled = false;
                conBusCuentaCreDestino.Enabled = false;
                conBusCliAporteDestino.Enabled = false;
                txtMCMontoNeto.Enabled = false;
                chcBase2.Enabled = false;
                txtMontOpeTraDep.Enabled = false;
                txtTotAporte.Enabled = false;
                txtTotFondo.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar1.Enabled = true;   
                dsTipPago.Dispose();
                dtPag.Dispose();
                dsComision.Dispose();
                dtComisionRet.Dispose();
                dtInterv.Dispose();
                dsIntervin.Dispose();
                dsComisionDep.Dispose();
                dtComisionDep.Dispose();
              //  dsAporte.Dispose();
                p_dtAporte.Dispose();
               // dsFondo.Dispose();
                p_dtFondo.Dispose();
                dtPlanPago.Dispose();
                xmlPpg = null;
            }
            else
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Operación de Transferencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtgIntervinientes.Enabled = false;
            btnComision.Enabled = false;
            conBusCtaAhoOrigen.btnBusCliente.Enabled = false;
            chcCreditos.Enabled = false;
            chcDeposito.Enabled = false;
            chcAporte.Enabled = false;
            ActualizarNivelApr(idSolApr);           
        }


        private void ImprimirVoucherTotal(DataTable dtListaKardexOpe)
        {            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            var idKardexDep = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexDep"]);
            var idKardexCre = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexCre"]);
            var idKardexAporte = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexAporte"]);
            var idKardexFondo = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexFondo"]);
            var idKardexRetCre = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexRetCre"]);
            var idKardexRetDep = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexRetDep"]);
            var idKardexRetApo = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexRetApo"]);
            var idKardexRetFon = Convert.ToInt32(dtListaKardexOpe.Rows[0]["idKardexRetFon"]);


            var dtDatosVoucher = clsDeposito.rptVoucherTransferencia(idKardexRetCre, idKardexRetDep, idKardexRetApo, idKardexRetFon,
                                                                    idKardexCre, idKardexDep, idKardexAporte, idKardexFondo);

            paramlist.Add(new ReportParameter("idKarRetPag", idKardexRetCre.ToString(), false));
            paramlist.Add(new ReportParameter("idKarRetDep", idKardexRetDep.ToString(), false));
            paramlist.Add(new ReportParameter("idKarRetApo", idKardexRetApo.ToString(), false));
            paramlist.Add(new ReportParameter("idKarRetFon", idKardexRetFon.ToString(), false));
            paramlist.Add(new ReportParameter("idKarPagCre", idKardexCre.ToString(), false));
            paramlist.Add(new ReportParameter("idKarDepCta", idKardexDep.ToString(), false));
            paramlist.Add(new ReportParameter("idKarPagApo", idKardexAporte.ToString(), false));
            paramlist.Add(new ReportParameter("idKarPagFon", idKardexFondo.ToString(), false));
            
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosVoucher));

            string reportpath = "RptVoucherTransferencia.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private bool ValidarReglasNivelAprRet()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = Convert.ToInt32(conBusCtaAhoOrigen.txtCodCli.Text);
            idSolApr = 0;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosRet(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProductoOrigen,
                                                   Decimal.Parse(txtTotalOpeTrans.Text), int.Parse(conBusCtaAhoOrigen.txtNroCta.Text), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref idSolApr);
            if (cCumpleReglas.Equals("NoCumple"))
            {

                return false;
            }
            return true;
        }
        private bool ValidarDepositoCuenta()
        {

            if (Convert.ToDecimal (txtTotalOpeTrans.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontOpeTraDep.Focus();

                return false;
            }

            Decimal nMonOpeVal = Convert.ToDecimal (this.txtMontEnt.Text.ToString());
            if (nMonOpeVal < nMonMinOpeDest)
            {
                MessageBox.Show("El Monto Mínimo de Operación Debe Ser: " + nMonMinOpeDest.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMCMontoNeto.SelectAll();
                this.txtMCMontoNeto.Focus();

                return false;
            }

            if (lIsDepAhoProg)
            {
                if (nMonOpeVal > (Convert.ToDecimal (txtMonCuota.Text) * Convert.ToDecimal (txtNumCuoPen.Text)))
                {
                    MessageBox.Show("El Monto a Depositar No Puede ser Mayor al Saldo Pendiente", "Validar Datos Ahorro Programado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtMCMontoNeto.SelectAll();
                    this.txtMCMontoNeto.Focus();
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    return false;
                }
            }

            return true;

        }
        private void GrabarDeposito()
        {
            Decimal nMonOpe = Convert.ToDecimal (this.txtMontEnt.Text.ToString()),
            nMonRedondeo = Convert.ToDecimal (txtRedondeo.Text.ToString()),
            nMonCapital = Convert.ToDecimal (txtMontTotal.Text.ToString());
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================

            int nidCta = Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text);
            Decimal nMonComis = Convert.ToDecimal (txtComision.Text);
            Decimal nMonITF = Convert.ToDecimal (txtImpuesto.Text);
            int idTipPago = 2;

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasNivelAprDep())
            {
                return;
            }
        }

        Boolean CamposSonValidos()
        {
            if (string.IsNullOrEmpty(this.conBusCliAporteDestino.txtCodCli.Text))
            {
                MessageBox.Show("Debe Buscar Primero al Cliente, para pagar sus Aportes", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.conBusCliAporteDestino.txtCodCli.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtTotPagar.Text))
            {
                MessageBox.Show("Seleccione los aportes a cobrar(checks) o ingrese el monto de aporte", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotPagar.Focus();
                return false;
            }

            if ((this.txtTotPagar.nvalor) <= 0.00)
            {
                MessageBox.Show("Seleccione los aportes a cobrar", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotPagar.Focus();
                return false;
            }
            return true;
        }

        private void GrabarPagoAporte()
        {


            clslisDetalleAporte detalleaporte = new clslisDetalleAporte();
            clslisDetalleFondo detallefondo = new clslisDetalleFondo();

            detalleaporte.AddRange(((List<clsDetalleAporte>)dtgAportes.DataSource).Where(x => x.lPago == true).ToList());
            detallefondo.AddRange(((List<clsDetalleFondo>)dtgDetalleFondo.DataSource).Where(x => x.lPago == true).ToList());

            string cxmlAporte = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                         new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                         new XElement("dsdetalleaporte",
                                         from item in detalleaporte
                                         select new XElement("dtdetalleaporte",
                                                             new XAttribute("idDetAporte", item.idDetAporte),
                                                             new XAttribute("idAporte", item.idAporte),
                                                             new XAttribute("cPeriodo", item.cPeriodo),
                                                             new XAttribute("nMonApoPac", item.nMonApoPac),
                                                             new XAttribute("nMonApoPag", item.nMonApoPag),
                                                             new XAttribute("dFecVenApo", item.dFecVenApo),
                                                             new XAttribute("idEstado", item.idEstado)
                                                             ))).ToString();


            string cxmlFondo = @"<?xml version=""1.0"" encoding=""utf-8"" ?>" +
                          new XDocument(new XDeclaration("1.0", "ISO-8859-1", "yes"),
                          new XElement("dsdetallefondo",
                                          from item in detallefondo
                                          select new XElement("dtdetallefondo",
                                                              new XAttribute("idDetFondo", item.idDetFondo),
                                                              new XAttribute("idFondo", item.idFondo),
                                                              new XAttribute("cPeriodo", item.cPeriodo),
                                                              new XAttribute("dFecVenApo", item.dFecVenApo),
                                                              new XAttribute("nMontoPac", item.nMontoPac),
                                                              new XAttribute("nMontoPag", item.nMontoPag),
                                                              new XAttribute("idEstado", item.idEstado)
                                                              ))).ToString();



            Boolean lPagarInscripcion = Convert.ToDecimal(txtInscripcion.Text) > 0.00M ? true : false;

            DataSet dsUsuarioPagador = ObtenerDatosPagador();
            dsUsuarioPagador.DataSetName = "dsUsuarioPagador";

            String xmlUsuarioPagador = dsUsuarioPagador.GetXml();
            xmlUsuarioPagador = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlUsuarioPagador);

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0;
            int idMoneda_Saldo = 0;
            decimal nMontoOpe = 0;

            DataTable dtRpta = cnsocio.registrarPagoAporteFondo(detalleaporte, detallefondo, lPagarInscripcion, objsocio.idInscripcion, xmlUsuarioPagador, (int)cboTipoAporte1.SelectedValue, lModificaSaldoLinea, idTipoTransac, nMontoOpe, idMoneda_Saldo);

            if (dtRpta.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtRpta.Rows[0]["idRpta"]) == 1)//CORRECTO 
                {
                    MessageBox.Show("La transferencia se realizó con éxito-Pago de Aporte", "Pago de aporte y fondo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar.Enabled = false;
                    dtgDetalleFondo.Enabled = false;
                    dtgAportes.Enabled = false;

                }
                else//CON ERROR
                {
                    ExtornoOpe(idKardexRet, p_idCta, (Decimal)nMontoOpeRet);
                    MessageBox.Show(dtRpta.Rows[0]["msg"].ToString(), "Pago de aporte y fondo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            

        }
        private DataSet ObtenerDatosPagador()
        {
            DataTable dtUsuarioPagador = new DataTable("dtUsuarioPagador");
            dtUsuarioPagador.Columns.Add("idCli", typeof(int));
            dtUsuarioPagador.Columns.Add("cNombre", typeof(string));
            dtUsuarioPagador.Columns.Add("cDocumentoID", typeof(string));
            dtUsuarioPagador.Columns.Add("cDireccion", typeof(string));
            dtUsuarioPagador.Columns.Add("idModPagoAporteFondoSeg", typeof(int));
            dtUsuarioPagador.Columns.Add("idTipoPersona", typeof(int));
            dtUsuarioPagador.Columns.Add("idSocio", typeof(int));
            dtUsuarioPagador.Columns.Add("idCuenta", typeof(int));

            DataRow fila = dtUsuarioPagador.NewRow();

            fila["idCli"] = conBusCtaAhoOrigen.idcli;
            fila["cNombre"] = conBusCtaAhoOrigen.txtNombre.Text;
            fila["cDocumentoID"] = conBusCtaAhoOrigen.txtNroDoc.Text;
            fila["cDireccion"] = "";
            fila["idModPagoAporteFondoSeg"] = 2;
            fila["idTipoPersona"] = conBusCtaAhoOrigen.nidTipoPersona;
            fila["idSocio"] = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
            fila["idCuenta"] = Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text.Trim());

            dtUsuarioPagador.Rows.Add(fila);

            DataSet dsUsuarioPagador = new DataSet("dsUsuarioPagador");
            dsUsuarioPagador.Tables.Add(dtUsuarioPagador);

            return dsUsuarioPagador;
        }
        private bool ValidarPagoCredito()
        {
            if (this.txtNumCuotasPendientes.Text == "")
            {
                MessageBox.Show("El cobro debe corresponder a algún crédito. " + Convert.ToChar(13) +
                                "Busque un crédito e ingrese el monto a pagar", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.conBusCuentaCreDestino.txtNroBusqueda.Text.Trim() == "")
            {
                this.conBusCuentaCreDestino.txtNroBusqueda.Focus();
                return false;
            }

            if (this.txtMCMontoNeto.Text.Trim() == "")
            {
                this.txtMCMontoNeto.Focus();
                return false;
            }

            if (Convert.ToDecimal (this.txtMCMontoNeto.Text) > 0)
            {
                Decimal nSumMonDistrib = 0;
                if (!string.IsNullOrEmpty(this.txtMCCapital.Text.Trim()))
                    nSumMonDistrib = nSumMonDistrib + Convert.ToDecimal (this.txtMCCapital.Text.Trim());

                if (!string.IsNullOrEmpty(this.txtMCInteres.Text.Trim()))
                    nSumMonDistrib = nSumMonDistrib + Convert.ToDecimal (this.txtMCInteres.Text.Trim());

                if (!string.IsNullOrEmpty(this.txtMCOtros.Text.Trim()))
                    nSumMonDistrib = Math.Round(nSumMonDistrib + Convert.ToDecimal (this.txtMCOtros.Text.Trim()), 2);

                if (!string.IsNullOrEmpty(this.txtMCMora.Text.Trim()))
                    nSumMonDistrib = Math.Round(nSumMonDistrib + Convert.ToDecimal (this.txtMCMora.Text.Trim()), 2);


                if (Convert.ToDecimal (this.txtMCMontoNeto.Text) != nSumMonDistrib)
                {
                    this.txtMCMontoNeto.Focus();
                    MessageBox.Show("El Monto Distribuido no es igual al monto cobrado. Debe presionar ENTER para distribuir el pago " + nSumMonDistrib.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            Decimal nMonPagado = Convert.ToDecimal (this.txtMCTotalPago.Text);
            if (nMonPagado <= 0)
            {
                MessageBox.Show("El Monto a Pagar debe ser mayor a 0", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;

        }
        private void GrabarPagoCredito()
        {
            //APLICAR REGLA DINAMICA: EL usurio actual del sistema, no puede ser el mismo que pague su crédito 
            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            String cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCreDestino.txtNroBusqueda.Text),
                                                   1, Convert.ToInt32(IdMonedaCre), 0,
                                                   0, int.Parse(conBusCuentaCreDestino.txtNroBusqueda.Text), clsVarGlobal.dFecSystem,
                                                   2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);

            if (!cCumpleReglas.Equals("Cumple"))
            {
                return;
            }

            DataSet ds = new DataSet("dsPlanPagos");
            ds.Tables.Add(dtPlanPago);
            xmlPpg = ds.GetXml();//Solo Plan Pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();

            DataTable dtDetalleCargaGasto = PlanPago.DistribuirGastosPagados(dtPlanPago);
            dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtDetalleCargaGasto);

            //Guardar los Datos de la persona que está pagando la cuota
            {
                DataTable dtPagador = new DataTable("TablaDatosPagador");

                dtPagador.Columns.Add("cNroDNI", typeof(string));
                dtPagador.Columns.Add("cNomCliente", typeof(string));
                dtPagador.Columns.Add("cDireccion", typeof(string));

                DataRow drfila = dtPagador.NewRow();
                drfila["cNroDNI"] = cDniCliOpe;
                drfila["cNomCliente"] = cNomCliOpe;
                drfila["cDireccion"] = "";
                dtPagador.Rows.Add(drfila);

                ds.Tables.Add(dtPagador);
            }

            xmlPpg = ds.GetXml();//Plan Pagos y DetalleCargaGastos en caso se haya realizado pagos
            xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);
            
            ds.Tables.Clear();
        }
        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = conBusCuentaCreDestino.txtNroBusqueda.Text;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        private bool ValidarReglasNivelAprDep()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = Convert.ToInt32(conBusCtaAhoDestino.txtCodCli.Text);
            idSolApr = 0;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosDep(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMontOpeTraDep.Text), int.Parse(conBusCtaAhoDestino.txtNroCta.Text), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref idSolApr);
            if (cCumpleReglas.Equals("NoCumple"))
            {

                return false;
            }
            return true;
        }
        private bool ValidarReglasRet()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = conBusCtaAhoOrigen.idcli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosRet(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMonedaOrigen.SelectedValue), idProductoOrigen,
                                                   Decimal.Parse(txtMontOpeTraDep.Text), int.Parse(conBusCtaAhoOrigen.txtNroCta.Text), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private int RetornaIdCliRet()
        {
            int idCli = 0;
            for (int i = 0; i < dtbIntervCtaRet.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbIntervCtaRet.Rows[i]["lCliAfeITF"]))
                {
                    idCli = Convert.ToInt32(dtbIntervCtaRet.Rows[i]["idCli"]);
                    break;
                }
            }
            return idCli;
        }
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

        private void ActualizarNivelApr(int idSolApr)
        {
            if (idSolApr > 0)
            {
                clsCNValidaReglasDinamicas ActNivelApr = new clsCNValidaReglasDinamicas();
                ActNivelApr.ActualizaSolicitudApr(idSolApr, 3);
            }
        }
       

        private Boolean ValidarFirmasReqOpe()
        {
            int nNroFirmas = 0;

            for (int i = 0; i < dtbIntervCtaRet.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtbIntervCtaRet.Rows[i]["isReqFirma"]))
                {
                    nNroFirmas++;
                }
            }
            Int16 nNroFirReq = Convert.ToInt16(txtNumFirOri.Text);
            if (nNroFirmas != nNroFirReq)
            {
                MessageBox.Show("El Número de Firmas Requeridos, no es igual a los que Firman la Operación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           return true;
        }

        private DataTable ArmarTablaParametrosDep()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = conBusCtaAhoDestino.txtNroDoc.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dniCliOpe";
            drfila[1] = cDniCliOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = conBusCtaAhoDestino.txtNroCta.Text;
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
            drfila[1] = nMonMinSalDisDest.ToString();
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
            drfila[1] = 2;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMontOpeTraDep.nDecValor.ToString();
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
            drfila[1] = txtNumRea1.Text.Replace(",", "");
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

            return dtTablaParametros;
        }
        private bool ValidarReglasDep()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            x_idCliente = conBusCtaAhoDestino.idcli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosDep(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMontOpeTraDep.Text), int.Parse(conBusCtaAhoDestino.txtNroCta.Text), clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }
        private DataTable ArmarTablaParametrosRet()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = conBusCtaAhoOrigen.txtNroDoc.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dniCliOpe";
            drfila[1] = cDniCliOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = conBusCtaAhoOrigen.txtNroCta.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";

            drfila[1] = idProductoOrigen.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = dtbIntervCtaRet.Rows.Count.ToString();
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
            drfila[1] = cboTipoCuentaOrigen.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonSalDis";
            drfila[1] = txtSaldoDisp.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNumFirOri.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = idTipoPersonaOrigen.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = 2;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtTotalOpeTrans.nDecValor.ToString();
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
            drfila[1] = nMonto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoEntregar";
            drfila[1] = txtTotalOpeTrans.Text.Replace(",", "");
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

            return dtTablaParametros;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            //LiberarCuenta();
        }
        private void ExtornoOpe(int idKardex, int idcuenta, Decimal nMontoOpe)
        {
            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0;
            int idMon = 1;

            clsCNOperacionDep dtExt = new clsCNOperacionDep();
            DataTable tbExt = dtExt.RegistraExtornoOpe(idKardex, idcuenta, 0, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem,
                                                        nMontoOpe, 11, 2, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }

        private void chcCreditos_CheckedChanged(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(conBusCuentaCreDestino.txtNroBusqueda.Text) && Convert.ToInt32(conBusCuentaCreDestino.txtNroBusqueda.Text) > 0)
            {
                this.conBusCuentaCreDestino.LiberarCuenta();
            }
            btnGrabar.Enabled = true;
            if (!chcCreditos.Checked && !chcDeposito.Checked && !chcAporte.Checked)
            {
                btnGrabar.Enabled = false;
            }
            LimpiarDatosCreditos();
            conBusCuentaCreDestino.Enabled = false;
            if (chcCreditos.Checked)
            {
                conBusCuentaCreDestino.Enabled = true;
                conBusCuentaCreDestino.txtNroBusqueda.Enabled = true;
                conBusCuentaCreDestino.btnBusCliente1.Enabled = true;
                conBusCuentaCreDestino.txtNroBusqueda.Focus();
            }
            
        }

        private void chcDeposito_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAhoDestino.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoDestino.txtNroCta.Text));
            }
            btnGrabar.Enabled = true;
            if (!chcCreditos.Checked && !chcDeposito.Checked && !chcAporte.Checked)
            {
                btnGrabar.Enabled = false;
            }
            LimpiarCtrlDep();
            LimpiarOtrosCtrlDep();
            conBusCtaAhoDestino.Enabled = false;
            if (chcDeposito.Checked)
            {
                conBusCtaAhoDestino.Enabled = true;
                conBusCtaAhoDestino.btnBusCliente.Enabled = true;
                conBusCtaAhoDestino.txtNroCta.Enabled = true;
                conBusCtaAhoDestino.txtNroCta.Focus();
            }
            
        }

        private void chcAporte_CheckedChanged(object sender, EventArgs e)
        {
            limpiarControlesBusAporte();
            LimpiarOtroCtrlAporte();
            btnGrabar.Enabled = true;
            if (!chcCreditos.Checked && !chcDeposito.Checked && !chcAporte.Checked)
            {
                btnGrabar.Enabled = false;
            }
            conBusCliAporteDestino.Enabled = false;
            if (chcAporte.Checked)
            {
                conBusCliAporteDestino.Enabled = true;
                conBusCliAporteDestino.btnBusCliente.Enabled = true;
                conBusCliAporteDestino.txtCodCli.Enabled = true;
                conBusCliAporteDestino.txtCodCli.Focus();
            }
    
        }

        private void txtTotAporte_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMCMontoNeto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotFondo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTipoAporte1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotAporte.Text))
            {
                if (Convert.ToDecimal (txtTotAporte.Text) > 0)
                {
                    CalcularAporte();
                    calcularRet();
                }

            }
        }

        private void conBusCliAporteDestino_Load(object sender, EventArgs e)
        {

        }

        private void dtgAportes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //evita error 
        }

        private void txtMCMontoNeto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMCMontoNeto.Text))
            {
                if (Convert.ToDecimal (txtMCMontoNeto.Text) > 0)
                {
                    CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
                    Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
                    nMonSalCre = Convert.ToDecimal (string.Format("{0:#,##0.##}", Convert.ToDecimal (nMonSalCre.ToString())));
                    if (Math.Round(nMonSalCre, 2) < Convert.ToDecimal (this.txtMCMontoNeto.Text))
                    {
                        MessageBox.Show("Monto a Pagar no puede exceder al Saldo del Crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    cargadatosCreditos();
                    Decimal nMontoaPagar = Convert.ToDecimal (this.txtMCMontoNeto.Text);
                    clsCNPlanPago PlanPago = new clsCNPlanPago();
                    DataTable dtPlanPagado = new DataTable("dtPlanPagado");
                    dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
                    this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
                    this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
                    //this.txtBase13.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    //this.txtNumRea3.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                    this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();

                    this.txtMCTotalPago.Text = calcularTotalCre();

                    FormatoMonto();
                    if (Convert.ToDecimal (txtMCTotalPago.Text) > Convert.ToDecimal (txtSaldoDisp.Text))
                    {
                        MessageBox.Show("Monto a Pagar no puede exceder al Saldo de Ahorro disponible: " + txtSaldoDisp.Text, "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMCCapital.Text = "0.00";
                        txtMCInteres.Text = "0.00";
                        txtMCMora.Text = "0.00";
                        txtMCOtros.Text = "0.00";
                        txtImpuestos.Text = "0.00";
                        txtRedondeo.Text = "0.00";
                        txtMCTotalPago.Text = "0.00";
                        this.txtMCMontoNeto.Focus();
                        this.txtMCMontoNeto.SelectAll();
                        this.btnGrabar.Enabled = false;
                        return;
                    }
                    this.btnGrabar.Enabled = true;

                    //==========================================
                    //CALCULOS POR EL RETIRO DE LA CUENTA
                    //==========================================
                    calcularRet();
                }
            }
        }

        private void txtMontOpeTraDep_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMontOpeTraDep.Text))
            {
                calcularDep();
            }
        }

    }
}
