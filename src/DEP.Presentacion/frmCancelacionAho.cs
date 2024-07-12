using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using CLI.CapaNegocio;
using System.Drawing.Drawing2D;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using SPL.Presentacion;
using CLI.Servicio;
using CLI.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmCancelacionAho : frmBase
    {
        int idTipOpe = 12; //Cancelación
        int p_idCta = 0, idSolApr = 0, p_idCtaTranf = 0;
        
        int idProd, nPlaCta, nDiasTrans;
        Decimal nMontoApe = 0.00m;
        Decimal nSaldoDis = 0.00m;
        Decimal nIntPagAde = 0.00m;
        bool lCumplePlazo, lisCtaCTS = false, lIsDepMenEdad;
        bool lCumplePlazoMin;
        bool lIsAfectoITF;
        bool lIsDepAhoProg;
        
        DataTable dtComision;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNFirmas cnFirma = new clsCNFirmas();
        clsCNCalculosAho clsCalculos = new clsCNCalculosAho();

        private const int idTipoOpeRegimenReforzado = 176;

        clsBiometrico oBiometrico = new clsBiometrico();

        public frmCancelacionAho()
        {
            InitializeComponent();
        }

        //==========================================================
        //--Cargar Modalidades de Pago
        //==========================================================
    private void CargarModalidadPago(int idTipOpe)
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(idTipOpe);
            if (dt.Rows.Count > 0)
            {
                this.cboModPago.DataSource = dt;
                this.cboModPago.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboModPago.DisplayMember = dt.Columns["cDescripcion"].ToString();
            }
            else
            {
                MessageBox.Show("No Existe Modalidades de Pago, VERIFICAR", "Validar Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarCtrl()
        {
            //--Datos de la Cuenta
            txtProducto.Text = "";
            cboMoneda.SelectedIndex = 1;
            cboTipoCuenta.SelectedIndex = 1;
            cboTipoPersona.SelectedIndex = 1;
            txtFecRenov.Text = "";
            txtFinPlazo.Text = "";
            txtTasaProd.Text = "";
            txtTasaCancelacion.Text = "";
            txtNumFirmas.Text = "";
            txtPlazo.Clear();
            
            //--Datos de Montos
            txtMontCap.Text = "0.00";
            txtMontInt.Text = "0.00";
            txtIntPagAde.Text = "0.00";
            txtComision.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtMontTotal.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtMontEnt.Text = "0.00";
            ptbFirma.Image = null;

            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();
        }

        private void LimpiarConBusCtaAho()
        {
            conBusCtaAho.txtCodAge.Text = "";
            conBusCtaAho.txtCodMod.Text = "";
            conBusCtaAho.txtCodMon.Text = "";
            conBusCtaAho.txtNroCta.Text = "";
            conBusCtaAho.txtCodCli.Text = "";
            conBusCtaAho.txtNroDoc.Text = "";
            conBusCtaAho.txtNombre.Text = "";
        }

        //==========================================================
        //--Recuperar Tasa para el Producto
        //==========================================================
        private bool recuperarTasa(int nPlazo, int idProducto, Decimal nSalCapital, int idMoneda, int idAgencia, int idTipPer)
        {
            this.txtTasaCancelacion.Text = "0.00";

            clsCNAperturaCta TasaAho = new clsCNAperturaCta();
            DataTable dtTasa = TasaAho.RetornaTasaAhorros(nPlazo, idProducto, (decimal)nSalCapital, idMoneda, idAgencia, idTipPer);

            if (dtTasa.Rows.Count > 0)
            {
                this.txtTasaCancelacion.Text = dtTasa.Rows[0]["nTasaCompensatoria"].ToString();
                return true;
            }
            else
            {
                MessageBox.Show("No se encontro la tasa para el subproducto", "Validación Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        //==========================================================
        //--Calculo de Interes generados
        //==========================================================
        public Decimal CalcularInteresAho(Decimal nTasInt, int nDiasTrans, Decimal nSalCapital, int nTipCta)
        {
            clsCNCalculosAho CalculosAhorro = new clsCNCalculosAho();
            return CalculosAhorro.CalcularInteresAho(nTasInt, nDiasTrans, nSalCapital, nTipCta);
        }

        //--====================================================================================
        //--Calcular Itf, Comisiones
        //--====================================================================================
        private void calcular()
        {
            Decimal nMonInt = 0.00m, nIntPag = 0.00m, nMonFavCli = 0.00m, nCapPrecancelacion = 0.00m;

            if (string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text.ToString()))
            {
                MessageBox.Show("Primero debe Buscar la Cuenta para realizar Cancelación", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtMontCap.Text))
                {
                    this.txtMontCap.Text = "0.00";
                    this.txtMontInt.Text = "0.00";
                    this.txtIntPagAde.Text = "0.00";
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    dtComision = null;
                    dtComision = new DataTable("dtComision");
                    return;
                }
                else
                {
                    if (nPlaCta != 0)  //--Si es Plazo Fijo
                    {
                        //--==========================================================
                        //--Calcular Intereses a la fecha (Solo para Plazos Fijos)
                        //--==========================================================
                        if (lCumplePlazo == false)
                        {
                            //nMonInt = CalcularInteresAho(Convert.ToDecimal (txtTasaCancelacion.Text), nDiasTrans, nMontoApe, 1);
                            nMonInt = clsCalculos.CalcularPreCancelacion(conBusCtaAho.idcuenta, clsVarGlobal.dFecSystem, Convert.ToDecimal(txtTasaCancelacion.Text), ref nCapPrecancelacion);
                            txtMontCap.Text = string.Format("{0:#,#0.00}", nCapPrecancelacion);
                            nSaldoDis = nCapPrecancelacion;
                            nIntPag = nIntPagAde;
                        }
                        else
                        {
                            //nMonInt = 0.00m;
                            nMonInt = Convert.ToDecimal(txtMontInt.Text);
                            nIntPag = 0.00m;
                        }
                        txtMontInt.Text = string.Format("{0:#,#0.00}", nMonInt);
                        txtIntPagAde.Text = string.Format("{0:#,#0.00}", nIntPag);
                    }
                    else  //--Para Cuentas Corrientes
                    {
                        nMonInt = Convert.ToDecimal (txtMontInt.Text); 
                        nIntPag = 0.00m;
                    }
                    
                    //--==========================================================
                    //--Calcular Comisiones de la Cuenta
                    //--==========================================================
                    Decimal nComision = 0.00m;

                    dtComision = null;
                    clsCNOperacionDep clsOperaccionAho = new clsCNOperacionDep();
                    int idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                    int x_idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);

                    dtComision = clsOperaccionAho.RetornaComisionesCtaOpe(idProd, idTipOpe, Convert.ToInt32(cboTipoPersona.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue),
                                                                          idCta, 1, clsVarGlobal.nIdAgencia, nSaldoDis - nIntPag + nMonInt, nPlaCta, x_idTipoPago);
                    if (dtComision.Rows.Count > 0)
                    {
                        Decimal nTotCom = Convert.ToDecimal (dtComision.Compute("SUM(nValorAplica)", ""));
                        nComision = nTotCom;
                        btnComision.Enabled = true;
                    }
                    else
                    {
                        nComision = 0.00m;
                        btnComision.Enabled = false;
                    }
                    nComision = Math.Round(nComision, 2);
                    txtComision.Text = nComision.ToString();

                    //--==========================================================
                    //--Calcular ITF
                    //--==========================================================
                    Decimal nITF = 0.00m;

                    if (!lIsAfectoITF)
                    {
                        nITF = 0;
                    }
                    else
                    {
                        nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (nSaldoDis - nIntPag + nMonInt - nComision), 2, (Int32)this.cboMoneda.SelectedValue);
                    }

                    //--Transferencias, entre las mismas Cuentas, no debe calcular Itf
                    if (Convert.ToInt32(cboModPago.SelectedValue) == 2 && rbtMismaCta.Checked == true) //--Transferencias
                    {
                        nITF = 0.00m;
                    }

                    this.txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
                    
                    Decimal nMontoTotal = 0.00m;
                    nMontoTotal = nSaldoDis - nIntPag + nMonInt - nComision - nITF;
                    this.txtMontTotal.Text = string.Format("{0:#,#0.00}",nMontoTotal);
					
                    if (Convert.ToInt32(cboModPago.SelectedValue)==1) //TIPO DE PAGO EN EFECTIVO
                    {
                        nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                    } 
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}",nMontoTotal);
                }
            }
        }

        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private bool DatosCuenta(int idCta)
        {
            btnGrabar.Enabled = false;

            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, idTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarConBusCtaAho();
                conBusCtaAho.txtCodAge.Focus();
                return false;
            }

            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", idTipOpe);
            
            if (dtbNumCuentas.Rows.Count == 1)
            {
                bool lisBloCta = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisBloqCta"].ToString());

                if (lisBloCta)
                {
                    MessageBox.Show(cMsg + "BLOQUEO PARCIAL POR UN MONTO TOTAL DE: " + dtbNumCuentas.Rows[0]["cSimboloMoneda"].ToString() + " " + dtbNumCuentas.Rows[0]["nMonTotBloq"].ToString().Trim(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarConBusCtaAho();
                    conBusCtaAho.txtCodAge.Focus();
                    return false;
                }
                
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    p_idCta = 0;
                    LimpiarConBusCtaAho();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return false;
                }

                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()) == 4)
                {
                    MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarConBusCtaAho();
                    btnGrabar.Enabled = false;
                    conBusCtaAho.txtCodAge.Focus();
                    return false;
                }

                if (Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsCtaOrdPago"].ToString()))  //--Si emite Orden de Pago
                {
                    DataTable dtOP = clsDeposito.CNValidaChequeraCta(idCta);
                    if (dtOP.Rows.Count>0)
                    {
                        MessageBox.Show("La cuenta tiene talonarios con Ordenes de Pago Vigentes, Primero debe Anular o Devolver los talonarios", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarConBusCtaAho();
                        btnGrabar.Enabled = false;
                        conBusCtaAho.txtCodAge.Focus();
                        return false;
                    }
                }
                
                idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nDiasTrans = (clsVarGlobal.dFecSystem - Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"])).Days;
                nMontoApe = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMontoApertura"].ToString());
                nSaldoDis = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                nIntPagAde = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nIntPagAde"].ToString());
                lIsAfectoITF = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                lisCtaCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                cboTipoPersona.SelectedValue = Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString());
                dtpFecApe.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]);
                txtPlazo.Text = dtbNumCuentas.Rows[0]["nPlazoCta"].ToString();

                if (!RevisionDocumentosCTSPendientes())
                {
                    return false;
                }              
                if (nPlaCta != 0)
                {
                    txtFinPlazo.Text = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]).AddDays(nPlaCta).ToShortDateString();
                    txtFecRenov.Text = dtbNumCuentas.Rows[0]["dFechaRen"].ToString();
                    int nDiasExecPenCuenta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nDiasExecPenCuenta"]);

                    if (nDiasExecPenCuenta > 0)
                        lCumplePlazo = (nDiasTrans < (nPlaCta - nDiasExecPenCuenta) ? false : true);
                    else
                        lCumplePlazo = (nDiasTrans < nPlaCta ? false : true);

                    lCumplePlazoMin = (nDiasTrans < 31 ? false : true);

                    if (!recuperarTasa(0, (int)dtbNumCuentas.Rows[0]["idProdTasCancel"], nMontoApe, (int)dtbNumCuentas.Rows[0]["idMoneda"], (int)dtbNumCuentas.Rows[0]["idAgencia"], (int)dtbNumCuentas.Rows[0]["idTipoPersona"]))
                    {
                        return false;
                    }

                    //if (lCumplePlazoMin)
                    //{
                    //    if (!recuperarTasa(0, (int)dtbNumCuentas.Rows[0]["idProdTasCancel"], nMontoApe, (int)dtbNumCuentas.Rows[0]["idMoneda"], (int)dtbNumCuentas.Rows[0]["idAgencia"], (int)dtbNumCuentas.Rows[0]["idTipoPersona"]))
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else
                    //{
                    //    this.txtTasaCancelacion.Text = "0.00";
                    //}
                    if ( lCumplePlazo )
                        this.txtTasaCancelacion.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();

                    txtMontInt.Text = string.Format("{0:#,#0.00}", dtbNumCuentas.Rows[0]["nMonIntDev"]);
                    txtIntPagAde.Text = string.Format("{0:#,#0.00}", nIntPagAde);
                }
                else
                {
                    lCumplePlazo = true;
                    lCumplePlazoMin = true;
                    txtFecRenov.Text = "";
                    txtFinPlazo.Text = "";
                    txtTasaCancelacion.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();
                    txtMontInt.Text = string.Format("{0:#,#0.00}", dtbNumCuentas.Rows[0]["nMonIntDev"]);
                    txtIntPagAde.Text = "0.00";
                }

                lblFinPlazo.ForeColor = (lCumplePlazo == true ? Color.Black : Color.Red);

                txtTasaProd.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();
                txtNumFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                txtNumCertificado.Text = dtbNumCuentas.Rows[0]["cNumCertificado"].ToString();

                txtMontCap.Text = string.Format("{0:#,#0.00}", dtbNumCuentas.Rows[0]["nSaldoDis"]);
                conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));
                cboModPago.Enabled = true;
                btnGrabar.Enabled = true;
            }
            else
            {
                return false;
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
            }
            else
            {
                MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarCtrl();
                btnGrabar.Enabled = false;
                return false;
            }

            //--===================================================================================
            //--Calcular Interes / Comisiones / Itf
            //--===================================================================================
            calcular();

            //--===================================================================================
            //--Bloqueo Logico de Cuenta
            //--===================================================================================
            clsDeposito.CNUpdUsoCuenta(idCta, clsVarGlobal.User.idUsuario);
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            cboMotivoOperacion.Enabled = true;
            cboModPago.Focus();
            return true;
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

        private void frmCancelacionAho_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            CargarModalidadPago(idTipOpe);
            //---------------------------------------------------
            //--Validar si se va a Trabajar con Tarjetas o NO.
            //---------------------------------------------------
            if (clsVarApl.dicVarGen["nIndTrabTarj"] == 1)
            {
                this.Text = "Cancelación de Ahorros (Presione F5 para Trabajar con Tarjetas)";
            }
            else
            {
                this.Text = "Cancelación de Ahorros";
            }

            conBusCtaAho.nTipOpe = idTipOpe;
            conBusCtaAho.lBloqueaBusquedaNombre = this.lBloqueaBusquedaNombre;
            conBusCtaAhoTransf.p_idTipOpePrincipal = idTipOpe; //Indica la Operación Principal
            conBusCtaAhoTransf.lBloqueaBusquedaNombre = this.lBloqueaBusquedaNombre;
            conBusCtaAho.pnIdMon = 0;  //Para Cancelación no es necesario la moneda, debe listar todas las Cuentas.
            conSolesDolar.iMagenMoneda(0);
            conBusCtaAhoTransf.btnBusCliente.Enabled = false;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            dtpFecApe.Value = clsVarGlobal.dFecSystem;
            CargarCtasbancos();
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            this.cboMotivoOperacion.ListarMotivoOperacion(idTipOpe, clsVarGlobal.PerfilUsu.idPerfil);
            conBusCtaAho.txtCodAge.Focus();
            btnGrabar.Enabled = false;
            cboTipoEntDestino.SelectedValue = 4;
            //dtgIntervinientes.AutoGenerateColumns = false;

        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            this.cargaCuentaConValidacionAhorroWeb();
        }

        private void cargaCuentaConValidacionAhorroWeb()
        {
            LimpiarCtrl();
            p_idCta = 0;
            if (conBusCtaAho.idcuenta>0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                if (!DatosCuenta(p_idCta))
                { 
                    return;
                }
            }
        }
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
            if (lisCtaCTS == true && dtListaRegDocCTS.Rows.Count == 0)
            {
                MessageBox.Show("No existen documentos registrados para la cuenta. Regístrelos", "Revisión de documentos pendientes CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        //--==================================================
        //--Listar Cuentas de la Financiera desde Bancos
        //--==================================================
        private void CargarCtasbancos()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheque de gerencia
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
        private void btnComision_Click(object sender, EventArgs e)
        {
            frmComisionesCta frmComisCta = new frmComisionesCta();
            frmComisCta.dtCom = dtComision;
            frmComisCta.ShowDialog();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                 MessageBox.Show("Debe Buscar Primero la cuenta a Cancelar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (conBusCtaAho.idcuenta<=0)
            {
                MessageBox.Show("Debe Buscar Primero la cuenta a Cancelar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text))
            {
                MessageBox.Show("Debe Buscar Primero la cuenta del Cliente...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMotivoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo de la Operación...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return;
            }

            /*Validación de Deposito como garantía a credito activo*/
            DataTable dtValidacion = clsDeposito.CNValidarCtaGarantiaVinculadoCredito(
                this.conBusCtaAho.txtCodIns.Text.ToString() + this.conBusCtaAho.txtCodAge.Text.ToString() + this.conBusCtaAho.txtCodMod.Text.ToString() + this.conBusCtaAho.txtCodMon.Text.ToString() + this.conBusCtaAho.txtNroCta.Text.ToString()
                );
            if (Convert.ToInt32(dtValidacion.Rows[0]["idresp"]) == 1)
            {
                MessageBox.Show(dtValidacion.Rows[0]["cMensaje"].ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            /*========================================================================================
               * REGISTRO DE RASTREO
			========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Cancelacion de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            if (!ValidarFirmasReqOpe())  //--Validar Firmas Requeridas
            {
                return;
            }
            if (!ValidarDatosTipPago())
            {
                return;
            }

            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            int idCuenta = Convert.ToInt32(conBusCtaAho.idcuenta);
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            Decimal nTasCancelacion = Convert.ToDecimal (txtTasaCancelacion.Text);
            Decimal nMonOperacion = Convert.ToDecimal (txtMontEnt.Text);
            Decimal nMonCapital = Convert.ToDecimal (txtMontCap.Text);
            Decimal nMonInteres = Convert.ToDecimal (txtMontInt.Text);
            Decimal nMonIntPagAde = Convert.ToDecimal (txtIntPagAde.Text);
            Decimal nMonComis = Convert.ToDecimal (txtComision.Text);
            Decimal nMonITF = Convert.ToDecimal (txtImpuesto.Text);
            Decimal nMonRedondeo = Convert.ToDecimal (txtRedondeo.Text);
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue);
            int x_idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasNivelApr())
            {
                return;
            }                          

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable dtInterv = (DataTable)dtgIntervinientes.DataSource;
            DataSet dsIntervin = new DataSet("dsCancelacion");
            dsIntervin.Tables.Add(dtInterv);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());

            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            int idCliValid = 0;
            DataRow row = dtInterv.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                    .OrderBy(x => Convert.ToInt32(x["idCli"]))
                                                    .FirstOrDefault();
            idCliValid = row != null ? Convert.ToInt32(row["idCli"]) : 0;
            var lstTitulares = dtInterv.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(idCliValid, "", clsVarGlobal.nIdAgencia, idTipOpe, idCliValid);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

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
                        dsIntervin.Tables.Clear();
                        dsIntervin.Dispose();
                        return;
                    }
                }
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            int nNumSolAprobRegimen = 0;
            foreach (var titular in lstTitulares)
            {
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(titular.Field<int>("idCli"),
                                                                               idMoneda,
                                                                               idProd,
                                                                               idCuenta,
                                                                               nMonOperacion);
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                    nNumSolAprobRegimen++;
            }

            if (nNumSolAprobRegimen > 0)
            {
                return;
            }

            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dsComision = new DataSet("dsCancelacion");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

            //--id Cliente Afe ITF
            int idCliItf = RetornaIdCli(),
                idCanal = 1;

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();

            if (Convert.ToInt32(cboModPago.SelectedValue) >= 2)  //Pago con documentos, Cheque, interbancario, ordpag, etc
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

            //--===============================================================
            //--Cliente que Realiza la Operación
            //--===============================================================
            string cDniCliOpe = "", cNomCliOpe = "", cDirCliOpe = "";

            cDniCliOpe = conBusCtaAho.txtNroDoc.Text;
            DataTable dtPerson = new clsCNBuscarCli().ListarClientes("1", cDniCliOpe);

            if (dtPerson.Rows.Count > 0)
            {
                cNomCliOpe = Convert.ToString(dtPerson.Rows[0]["cNombre"]);
                cDirCliOpe = Convert.ToString(dtPerson.Rows[0]["cDireccion"]);
            }

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
            //--valida Saldo en linea
            //--===============================================================
            if (Convert.ToInt16(cboModPago.SelectedValue) == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMoneda, 2, nMonOperacion))
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
                DataTable dtIntervinientes = dtgIntervinientes.DataSource as DataTable;

                if (clsVarGlobal.User.lAutBiometricaAgencia)
                {
                    var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                            .OrderBy(x => Convert.ToInt32(x["idCli"]));
                    if (!oBiometrico.validacionBiometrica(
                            listFirmantes
                            , Convert.ToInt32(cboMoneda.SelectedValue)
                            , idProd
                            , Convert.ToDecimal(this.txtMontEnt.Text.ToString())
                            , Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoCancelDep"])))
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

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 2; //EGRESO
            int nMotPagoId = Convert.ToInt16(cboModPago.SelectedValue);

            int[] nMotPagoSaldoCaja = new int[2];
            nMotPagoSaldoCaja[0] = 1;
            nMotPagoSaldoCaja[1] = 5;
            if (nMotPagoId.In(nMotPagoSaldoCaja))
                lModificaSaldoLinea = true;

            //--===============================================================
            //--Registrar Operación de Cancelación
            //--===============================================================
            DataTable dtRegCanCta = clsDeposito.CNRegistraCancelacionCta(idCanal, idCuenta, idProd, idMoneda, lCumplePlazo, nTasCancelacion,
                                                                         nMonOperacion, nMonCapital, nMonInteres, nMonIntPagAde, nMonComis,
                                                                         nMonITF, nMonRedondeo, xmlComision, idCliItf, cDniCliOpe,
                                                                         cNomCliOpe, cDirCliOpe, clsVarGlobal.nIdAgencia,
                                                                         clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlInterv,
                                                                         xmlTipPago, Convert.ToInt32(cboModPago.SelectedValue), x_idMotivoOpe,
                                                                         lModificaSaldoLinea, idTipoTransac);

            if (Convert.ToInt32(dtRegCanCta.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(dtRegCanCta.Rows[0]["cMensage"].ToString() + ", NRO DE OPERACIÓN: " + dtRegCanCta.Rows[0]["idNroOpe"].ToString(), "Cancelacion de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(clsVarGlobal.User.lAutBiometricaAgencia)
                {
                    oBiometrico.registrarOperacionKardexExcepcion(Convert.ToInt32(dtRegCanCta.Rows[0]["idNroOpe"]));
                }
            }
            else
            {
                MessageBox.Show(dtRegCanCta.Rows[0]["cMensage"].ToString(), "Cancelacion de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsIntervin.Tables.Clear();
                dsIntervin.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }
            cboModPago.Enabled = false;
            btnBusCheGer.Enabled = false;

            int idkardex = Convert.ToInt32(dtRegCanCta.Rows[0]["idNroOpe"].ToString());

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
                ImpresionVoucher(idkardex, clsVarGlobal.idModulo, idTipOpe, 1, 0, 0, 0, 1);//Parámetros que se requieren kardex,Modulo,TipoOperacion,MOntoRecibido, MontoDVuelto, KardexEgreso caso Habilitacion
            }

            //-----------------------------------------------------------------------
            //Validacion de Declaracion Jurada de Sujetos Obligados
            //-----------------------------------------------------------------------
            DeclaracionJuradaCli();

            ActualizarNivelApr(idSolApr);
            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            dtgIntervinientes.Enabled = false;
            btnComision.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            cboMotivoOperacion.Enabled = false;
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;

            clsDeposito.CNUpdNoUsoCuenta(idCuenta);
            conBusCtaAho.btnBusCliente.Enabled = false;
            DeclaracionJuradaCli();
			/*========================================================================================
               * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Fin-Cancelacion de Cuenta de ahorro", btnGrabar);
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

        public void EmitirVoucherOpe(DataTable dtDatosCobro, int idKardex)
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
                                                   Decimal.Parse(txtMontEnt.Text), int.Parse(conBusCtaAho.idcuenta.ToString()), clsVarGlobal.dFecSystem,
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
            //--idTipoDocumento
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

            }

            if (nNroFirmas > 0)
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
            if (nNroFirmas != nNroFirReq)
            {
                MessageBox.Show("El Número de Firmas Requeridos, no es igual a lo Establecido para la Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
            if (!string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoTransf.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoTransf.idcuenta));
            }
            lisCtaCTS = false;
            LimpiarCtrl();
            LimpiarCtrCheqGer();
            LimpiarConBusCtaAho();
            conBusCtaAhoTransf.idcuenta = 0;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            dtpFecApe.Value = clsVarGlobal.dFecSystem;
            conBusCtaAhoTransf.LimpiarControles();
            btnBusCheGer.Enabled = false;
            dtgIntervinientes.Enabled = false;
            btnComision.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCtaAho.btnBusCliente.Enabled = true;
            conSolesDolar.iMagenMoneda(1);
            conBusCtaAho.btnBusCliente.Enabled = true;
            cboModPago.SelectedValue = 1;
            cboMotivoOperacion.SelectedValue = 4;
            cboModPago.Enabled = false;
            this.cboMotivoOperacion.Enabled = false;
            conBusCtaAho.txtCodAge.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();
        }

        private void frmCancelacionAho_FormClosed(object sender, FormClosedEventArgs e)
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
            var objFirma = cnFirma.retornaFirma(idCliente);
            if (objFirma != null)
            {
                ptbFirma.Image = objFirma.imgFirma;
                ptbFirma.Refresh();
            }

        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
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
                                                   Decimal.Parse(txtMontEnt.Text), int.Parse(conBusCtaAho.idcuenta.ToString()), clsVarGlobal.dFecSystem,
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
            drfila[0] = "idTipCuenta";
            drfila[1] = cboTipoCuenta.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonSalDis";
            drfila[1] = txtMontCap.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = idTipOpe.ToString();
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
            drfila[0] = "nTasaProduto";
            drfila[1] = txtTasaProd.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroCertificado";
            drfila[1] = txtNumCertificado.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTasaCancel";
            drfila[1] = txtTasaCancelacion.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = cboModPago.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoCapital";
            drfila[1] = txtMontCap.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoInteres";
            drfila[1] = txtMontInt.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoComision";
            drfila[1] = txtComision.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtImpuesto.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonInteresAde";
            drfila[1] = txtIntPagAde.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoTotal";
            drfila[1] = txtMontTotal.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = txtRedondeo.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMontEnt.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoCancelacion";
            drfila[1] = txtMontEnt.Text.Replace(",", "");
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
            drfila[1] = conBusCtaAho.txtCodCli.Text;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }


        //-----------------------------------------------------------
        //--Cargar Datos del Cliente
        //----------------------------------------------------------
        private void DatosCtaCli(int idCli)
        {
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(idCli, 1, 0, idTipOpe);
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
                    frmbuscarCta.nTipOpe = idTipOpe;  //--Tipo de Operación: 11 Retiro, 10 Deposito
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

        public void EmitirVoucher(int idKardex, DataTable dtOper)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsOper", dtOper));
            string reportpath = "rptVoucherCancelAho.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void btnBusCheGer_Click(object sender, EventArgs e)
        {
            string cNroDNI = conBusCtaAho.txtNroDoc.Text.Trim();
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = conBusCtaAho.txtCodCli.Text;
            if (lisCtaCTS)
            {
                frmChequeByCli.idMotOpeBco = 6; // CANCELACION DE CUENTA
            }
            else
            {
                frmChequeByCli.idMotOpeBco = 0; // Todos
            }
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.cNroDNI = cNroDNI;
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text = frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text = frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text = frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
        }

        private void btnBusCheGer_Click_1(object sender, EventArgs e)
        {
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = conBusCtaAho.txtCodCli.Text;
            if (lisCtaCTS)
            {
                frmChequeByCli.idMotOpeBco = 6; // CANCELACION DE CUENTA
            }
            else
            {
                frmChequeByCli.idMotOpeBco = 0; // Todos
            }
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text = frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text = frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text = frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
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
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        cboTipoEnt.SelectedValue = 4;
                        cboEnt.Enabled = true;
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
                        cboTipoEntDestino.Enabled = true;
                        cboEntidadDestino.Enabled = true;
                        txtCtaDestino.Enabled = true;
                        btnGrabar.Enabled = true;
                        txtNroDocu.Focus();
                        break;
                    case 5: //--Retiro con OP
                        txtNroCta.Visible = true;
                        cboCuenta.Visible = false;
                        lblFolio.Visible = true;
                        txtFolio.Visible = true;
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
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        txtNroDocu.MaxLength = 9;
                        txtSerie.MaxLength = 3;
                        txtNroCta.Focus();
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

        //==========================================================
        //--Limpiar los Tipos de Pago
        //==========================================================
        private void LimpiarTiposdePago()
        {
            conBusCtaAhoTransf.LimpiarControles();
            txtNroCta.Text = "";
            txtNroDocu.Text = "";
            txtSerie.Text = "";
            txtDiaVal.Text = "0";
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

        //====================================================
        //---Validar Datos Tipos de Pago
        //====================================================
        private bool ValidarDatosTipPago()
        {
            int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
            switch (nCodModPago)
            {
                case 1: //--Cancelación En Efectivo
                    if (string.IsNullOrEmpty(txtMontCap.Text))
                    {
                        MessageBox.Show("El Monto a Cancelar no es valido...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontCap.Focus();
                        txtMontCap.SelectAll();
                        return false;
                    }
                    break;
                case 2: //--Cancelación con Transferencia
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
                case 3: //--Cancelación Con Cheque
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
                    if (cboEntidadDestino.SelectedIndex == -1)
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
                case 4: //--Deposito Interbancario
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
                case 6:  //--Cheque Gerencia
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
                default: //--Otros Tipos de Cancelación
                    if (string.IsNullOrEmpty(txtMontCap.Text))
                    {
                        MessageBox.Show("El Monto a Cancelar no es valido...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontCap.Focus();
                        txtMontCap.SelectAll();
                        return false;
                    }
                    break;
            }
            return true;
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

        private void cboTipoEnt_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
