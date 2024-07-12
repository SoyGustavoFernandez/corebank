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
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System.Text.RegularExpressions;

namespace DEP.Presentacion
{
    public partial class frmMantenimientoCuenta : frmBase
    {
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNCalculosAho clsCalculos = new clsCNCalculosAho();

        public DataTable DatosCuenta;
        public DataTable tbIntervTotal;
        public DataTable tbIntervActivos;
        public DataTable dtbTipVinDep;
        public DataTable tbComisiones;
        public DataTable tbCronograma;
        public DataTable dtBloq;
        public int idTipoCuenta;       
        public int CaractCta;
        public int p_idCuenta = 0;
        int nPlaCta, nDiasTrans;
        Decimal nMonApe = 0.00m;
        Decimal nSaldoDis = 0.00m;
        Decimal nIntPagAde = 0.00m;
        bool lCumplePlazo;
        bool lCumplePlazoMin;
        bool lIsAfectoITF;

        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        
        public frmMantenimientoCuenta()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCuenta_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;
            conBusCtaAho.idMoneda = 0;           
            CargarTablaTipVinc();
            CargarComisiones(0,0,0,0);
            CargarDatosBloqueo(0);
            tbcCuentas.SelectedIndex = 1;
            CargarIntervinientes(0); 
            tbcCuentas.SelectedIndex = 2;
            CargarCalendario(0);
            tbcCuentas.SelectedIndex = 0;
            LimpiarControles();
            DeshabilitarControles();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            dtgIntervActivos.AutoGenerateColumns = false;
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta_1(object sender, EventArgs e)
        {
            Buscar();
        }   

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            
            txtSaldoMin.Enabled = true;
            cboEnvioEstCta.Enabled = true;

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2) //Envio por Correo
            {
                txtDireccionEnvioEstCta.KeyPress += txtDireccionEnvioEstCta_KeyPress;
            }
            else
            {
                txtDireccionEnvioEstCta.KeyPress -= txtDireccionEnvioEstCta_KeyPress;
            }

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 3) //Recojo en Oficina de Crac Lasa
            {
                txtDireccionEnvioEstCta.Enabled = false;
            }
            else
            {
                txtDireccionEnvioEstCta.Enabled = true;
            }

            if (Convert.ToBoolean(DatosCuenta.Rows[0]["PatronOrdenPago"]) == true)
            {
                CBOrdenPago.Enabled = true;
            }

            if (Convert.ToInt32(DatosCuenta.Rows[0]["idTipoCuenta"]) == 2) //	SOLIDARIA(Y/O)
            {
                txtNroFirmas.Enabled = true;
            }

            txtSaldoMin.Focus();

            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            p_idCuenta = 0;
            if (pcTipOpe == "A")
            {
                DeshabilitarControles();
                dtgIntervTotal.ReadOnly = true;
                dtgComisiones.ReadOnly = true;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            if (pcTipOpe == "N")
            {
                DeshabilitarControles();
                LimpiarControles();
                btnEditar.Enabled = false;
                
                btnCancelar.Enabled = false;
                cboMoneda1.SelectedValue = 1;
                conBusCtaAho.LimpiarControles();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
            }

            pcTipOpe = "N";
            conBusCtaAho.idcuenta = 0;
            btnGrabar.Enabled = false;
            
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Inicio-Mantenimiento de cuenta", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            decimal SaldoMin = this.txtSaldoMin.nDecValor;
            Boolean OrdenPago = Convert.ToBoolean(CBOrdenPago.Checked);
            int idTipEnvEstCta = Convert.ToInt16(cboEnvioEstCta.SelectedValue);
            string cCorreo = txtDireccionEnvioEstCta.Text;
            int nNroFirmas = Convert.ToInt32(txtNroFirmas.Text);

            DataSet dsComision = new DataSet("dsComisionCuenta");
            dsComision.Tables.Add(tbComisiones);
            string xmlComision = dsComision.GetXml();
            xmlComision = clsCNFormatoXML.EncodingXML(xmlComision);
            dsComision.Tables.Clear();
                       
            clsCNRetDatosCuenta GuardarDatos = new clsCNRetDatosCuenta();
            DataTable tbRegCta = GuardarDatos.GuardarDatosCuenta(p_idCuenta, SaldoMin, OrdenPago, idTipEnvEstCta, cCorreo, nNroFirmas, xmlComision);
            if (Convert.ToInt32(tbRegCta.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegCta.Rows[0]["cMensage"].ToString(), "Mantenimiento de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRegCta.Rows[0]["cMensage"].ToString(), "Mantenimiento de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                                                    
            Buscar();
            pcTipOpe = "N";
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            
            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCtaAho.idcli, this.conBusCtaAho.idcuenta, "Fin-Mantenimiento de cuenta", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        private void CargarTablaTipVinc()
        {
            clsCNCliVinculDep objTipDir = new clsCNCliVinculDep();
            dtbTipVinDep = objTipDir.ListaTipVincDep();
        }

        public void Buscar()
        {
            pcTipOpe = "N";
            if (conBusCtaAho.txtNroCta.Text.Trim() == "")
            {
                LimpiarControles();
                conBusCtaAho.btnBusCliente.Focus();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
                return;
            }

            LimpiarControles();
           
            //========================================================================
            //--Traer los datos de la Cuenta
            //========================================================================
            p_idCuenta = 0;

            //---------------------------------------------------------------------------
            //---Buscar por el Codigo de la Cuenta y Validar
            //---------------------------------------------------------------------------
            string x_cNroCuenta = conBusCtaAho.txtCodIns.Text + conBusCtaAho.txtCodAge.Text + conBusCtaAho.txtCodMod.Text + conBusCtaAho.txtCodMon.Text + conBusCtaAho.txtNroCta.Text;
            DataTable dtRetidCta = new clsCNDeposito().CNRetornaidCuenta(x_cNroCuenta);
            if (dtRetidCta.Rows.Count <= 0)
            {
                MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.txtCodIns.Focus();
                return;
            }
            else
            {
                p_idCuenta = Convert.ToInt32(dtRetidCta.Rows[0]["idCuenta"].ToString());
            }

            clsCNRetDatosCuenta BuscarDatosCuenta = new clsCNRetDatosCuenta();
            DatosCuenta = BuscarDatosCuenta.ListarDatosCuenta(p_idCuenta);

            if (DatosCuenta.Rows.Count<=0)
            {
                MessageBox.Show("No Hay datos de la cuenta búscada...Verificar", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                conBusCtaAho.btnBusCliente.Focus();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
                return;
            }

            //Datos Generales de la Cuenta
            cboMoneda1.SelectedValue = Convert.ToInt32(DatosCuenta.Rows[0]["idMoneda"]);
            txtTipCuenta.Text = Convert.ToString(DatosCuenta.Rows[0]["cTipoCuenta"]);
            txtTipPersona.Text = Convert.ToString(DatosCuenta.Rows[0]["cTipoPersona"]);
            txtCCI.Text = DatosCuenta.Rows[0]["cNumeroCCI"].ToString();
            txtEstCuenta.Text = Convert.ToString(DatosCuenta.Rows[0]["cEstado"]);
            txtTipProducto.Text = Convert.ToString(DatosCuenta.Rows[0]["cProducto"]);
            txtDescriCta.Text = DatosCuenta.Rows[0]["cDescripcionCta"].ToString();
            txtPeriodCap.Text = DatosCuenta.Rows[0]["cDenominacion"].ToString();
            CBExonITF.Checked = !Convert.ToBoolean(DatosCuenta.Rows[0]["lIsAfectoITF"]);

            //Datos Apertura
            txtUsuApertura.Text = DatosCuenta.Rows[0]["cNomUsuApertura"].ToString();
            txtPromotor.Text = DatosCuenta.Rows[0]["cNomPromotor"].ToString();
            dtFecApertura.Value = Convert.ToDateTime(DatosCuenta.Rows[0]["dFechaAperturaIni"]);
            txtMontoApertura.Text = Convert.ToString(DatosCuenta.Rows[0]["nMontoApertura"]);
            txtFecUltRenovacion.Text = DatosCuenta.Rows[0]["dFechaUltRenovacion"].ToString();
            txtTipPagInt.Text = DatosCuenta.Rows[0]["cTipoPagoInteres"].ToString();
            txtTipRenovacion.Text = DatosCuenta.Rows[0]["cTipoRenovacion"].ToString();

            txtTEA.Text = Convert.ToString(DatosCuenta.Rows[0]["nMonTasa"]);
            //Decimal TasaNominal = Convert.ToDecimal(Math.Pow(Convert.ToDouble (Convert.ToDecimal (txtTEA.Text) / 100) + 1, Convert.ToDouble (1) / 12) - 1) * 1200;
            //Decimal TasaRedondeada = Math.Round(TasaNominal, 2, MidpointRounding.AwayFromZero);
            //txtTasaNomAn.Text = Convert.ToString(TasaRedondeada);
            txtTasaNomAn.Text = txtTEA.Text;

            txtNroFirmas.Text = Convert.ToString(DatosCuenta.Rows[0]["nNumeroFirmas"]);
            txtNroTitular.Text = Convert.ToString(DatosCuenta.Rows[0]["CantTitul"]);
            txtPlazo.Text = DatosCuenta.Rows[0]["nPlazoCta"].ToString();
            txtNumCertificado.Text = DatosCuenta.Rows[0]["cNumCertificado"].ToString();

            //Estado Actual
            txtSaldoCap.Text = string.Format("{0:#,#0.00}",Convert.ToDecimal(DatosCuenta.Rows[0]["nMontoDeposito"]));
            txtMonIntDev.Text = Convert.ToString(DatosCuenta.Rows[0]["nMonIntDev"]);
            txtMontoValor.Text = Convert.ToString(DatosCuenta.Rows[0]["MontoValorizar"]);
            cboTipoTasa.SelectedValue = Convert.ToInt32(DatosCuenta.Rows[0]["idTipoTasa"]);
            txtTasaProd.Text = DatosCuenta.Rows[0]["nMonTasa"].ToString();
            dtFecUltCont.Value = Convert.ToDateTime(DatosCuenta.Rows[0]["dFecUltMov"]);

            txtSaldoMin.Text = Convert.ToString(DatosCuenta.Rows[0]["nSaldoMinimo"]);
            CBOrdenPago.Checked = Convert.ToBoolean(DatosCuenta.Rows[0]["lIsCtaOrdPago"]);

            cboEnvioEstCta.SelectedIndexChanged -= cboEnvioEstCta_SelectedIndexChanged; 
            cboEnvioEstCta.SelectedValue = Convert.ToInt16(DatosCuenta.Rows[0]["idTipoEnvioEstCta"]);
            txtDireccionEnvioEstCta.Text = DatosCuenta.Rows[0]["cCorreoEnvioEstado"].ToString();
            cboEnvioEstCta.SelectedIndexChanged += cboEnvioEstCta_SelectedIndexChanged;

            idTipoCuenta = Convert.ToInt32(DatosCuenta.Rows[0]["idTipoCuenta"]);
            CaractCta = Convert.ToInt32(DatosCuenta.Rows[0]["idCaracteristica"]);
            nPlaCta = Convert.ToInt32(DatosCuenta.Rows[0]["nPlazoCta"].ToString());
            nMonApe = Convert.ToDecimal (DatosCuenta.Rows[0]["nMontoApertura"].ToString());
            nSaldoDis = Convert.ToDecimal (DatosCuenta.Rows[0]["nSaldoDispCancel"].ToString());
            nIntPagAde = Convert.ToDecimal (DatosCuenta.Rows[0]["nIntPagAde"].ToString());            
            lIsAfectoITF = Convert.ToBoolean(DatosCuenta.Rows[0]["lIsAfectoITF"]);

            Decimal nMonInt    = 0.00m,
                   nIntPag    = 0.00m,
                   nITF       = 0.00m,
                   nPenalidad = 0.00m,
                   nCapPrecancelacion = 0.00m,
                   nMontoCapital = 0.00m;

            nMontoCapital = Convert.ToDecimal(DatosCuenta.Rows[0]["nMontoCapital"]);
           
            if (nPlaCta != 0)
            {
                txtFinPlazo.Text = Convert.ToDateTime(DatosCuenta.Rows[0]["dFechaApertura"]).AddDays(nPlaCta).ToShortDateString();
                txtNroDiasVencer.Text=(Convert.ToDateTime(txtFinPlazo.Text)-clsVarGlobal.dFecSystem).Days.ToString();
                txtDiasTranscurridos.Text = (clsVarGlobal.dFecSystem-Convert.ToDateTime(DatosCuenta.Rows[0]["dFechaApertura"])).Days.ToString();
                
                nDiasTrans = (clsVarGlobal.dFecSystem - Convert.ToDateTime(DatosCuenta.Rows[0]["dFechaApertura"])).Days;

                lCumplePlazo = (nDiasTrans < nPlaCta ? false : true);
                lCumplePlazoMin = (nDiasTrans < 31 ? false : true);

                if (!recuperarTasa(0, (int)DatosCuenta.Rows[0]["idProdTasCancel"], nMonApe, (int)DatosCuenta.Rows[0]["idMoneda"], (int)DatosCuenta.Rows[0]["idAgencia"], (int)DatosCuenta.Rows[0]["idTipoPersona"]))
                {
                    LimpiarControles();
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.btnBusCliente.Focus();
                    conBusCtaAho.HabDeshabilitarCtrl(true);
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //if (lCumplePlazoMin)
                //{
                //    if (!recuperarTasa(0, (int)DatosCuenta.Rows[0]["idProdTasCancel"], nMonApe, (int)DatosCuenta.Rows[0]["idMoneda"], (int)DatosCuenta.Rows[0]["idAgencia"], (int)DatosCuenta.Rows[0]["idTipoPersona"]))
                //    {
                //        return;
                //    }
                //}
                //else
                //{
                //    this.txtTasaCancelacion.Text = "0.00";
                //}

                //txtMontInt.Text = "0.00";
                txtMontInt.Text = string.Format("{0:#,#0.00}", DatosCuenta.Rows[0]["nMonIntDev"]);
                txtIntPagAde.Text = string.Format("{0:#,#0.00}", nIntPagAde);
            }
            else
            {
                lCumplePlazo = true;
                lCumplePlazoMin = true;
                txtFinPlazo.Text = "";
                txtNroDiasVencer.Text = "";
                txtDiasTranscurridos.Clear();
                txtTasaCancelacion.Text = DatosCuenta.Rows[0]["nMonTasa"].ToString();
                txtMontInt.Text = string.Format("{0:#,#0.00}", DatosCuenta.Rows[0]["nMonIntDev"]);
                txtIntPagAde.Text = "0.00";
            }

            if (nPlaCta != 0)  //--Si es Plazo Fijo
            {
                //--==========================================================
                //--Calcular Intereses a la fecha (Solo para Plazos Fijos)
                //--==========================================================
                if (lCumplePlazo == false)
                {
                    //--nMonInt = CalcularInteresAho(Convert.ToDecimal /*era ToDouble*/(txtTasaCancelacion.Text), nDiasTrans, nMonApe, 1);
                    nMonInt = clsCalculos.CalcularPreCancelacion(conBusCtaAho.idcuenta, clsVarGlobal.dFecSystem, Convert.ToDecimal(txtTasaCancelacion.Text), ref nCapPrecancelacion);
                    nIntPag = nIntPagAde;
                    nSaldoDis = nCapPrecancelacion;
                    nMontoCapital = nCapPrecancelacion;
                    nPenalidad = Convert.ToDecimal(txtSaldoCap.Text) + nIntPag + Convert.ToDecimal(txtMonIntDev.Text) - (nCapPrecancelacion + nMonInt);
                }
                else
                {
                    nMonInt = Convert.ToDecimal(txtMontInt.Text);
                    nIntPag = 0.00m;
                    nPenalidad = 0.00m;
                }
                txtMontInt.Text = string.Format("{0:#,#0.00}", nMonInt);
                txtIntPagAde.Text = string.Format("{0:#,#0.00}", nIntPag);
            }
            else  //--Para Cuentas Corrientes
            {
                nMonInt = Convert.ToDecimal (txtMontInt.Text);
                nIntPag = 0.00m;
                nPenalidad = 0.00m;
            }

            if (!lIsAfectoITF)
            {
                nITF = 0;
            }
            else
            {
                nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (nSaldoDis - nIntPag + nMonInt), 2, (int)DatosCuenta.Rows[0]["idMoneda"]);
            }

            lblFinPlazo.ForeColor = (lCumplePlazo == true ? Color.Navy : Color.Red);

            //Datos Cancelacion
            txtMontCap.Text = string.Format("{0:#,#0.00}", nMontoCapital);
            txtMontInt.Text = string.Format("{0:#,#0.00}", nMonInt);
            txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
            txtIntPagAde.Text = string.Format("{0:#,#0.00}", nIntPag);
            Decimal nMontoTotal = nSaldoDis - nIntPag + nMonInt - nITF;
            txtMontTotal.Text = string.Format("{0:#,#0.00}", nMontoTotal);
            txtPenalidad.Text = string.Format("{0:#,#0.00}", nPenalidad);

            //-------------------------------------
            CargarIntervinientes(p_idCuenta);
            CargarComisiones(p_idCuenta, Convert.ToInt32(DatosCuenta.Rows[0]["idAgencia"]), Convert.ToInt32(DatosCuenta.Rows[0]["idMoneda"]), Convert.ToInt32(DatosCuenta.Rows[0]["idTipoPersona"]));
            CargarDatosBloqueo(p_idCuenta);
            CargarRenovaciones(p_idCuenta);
            CargarDatosCambioTitular(p_idCuenta);

            //========================================================================
            //--Traer los datos de la Cuenta Programada
            //========================================================================
            
            clsCNRetDatosCuenta BuscarDatCuentaProg = new clsCNRetDatosCuenta();
            DataTable DatosCuentaProgr = BuscarDatCuentaProg.ListarDatCuentaProg(p_idCuenta, clsVarGlobal.nIdAgencia);

            if (DatosCuentaProgr.Rows.Count > 0) 
            {
                cboMoneda.SelectedValue = Convert.ToInt32(DatosCuentaProgr.Rows[0]["idMoneda"]);
                txtMontoCuota.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nMontoCuota"]);
                txtCuotDep.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nNumDepPag"]);
                txtCuotPend.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nNroCuotPend"]);
                txtRenovacion.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["CantRenov"]) + " Veces";
                txtTasaCanc.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nTasaCompensatoria"]);
                txtCapDisp.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nSaldoCnt"]);
                txtIntDisp.Text = Convert.ToString(DatosCuentaProgr.Rows[0]["nInteresGen"]);
                txtCapRet.Text = "0";
                txtIntRet.Text = "0";                
                
                CargarCalendario(p_idCuenta);

                cboCaractCta.SelectedValue = Convert.ToInt32(DatosCuenta.Rows[0]["idCaracteristica"]);
            }
                                    
            DeshabilitarControles();
            dtgIntervTotal.ReadOnly = true;
            dtgComisiones.ReadOnly = true;

            conBusCtaAho.HabDeshabilitarCtrl(false);
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
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

        private void LimpiarControles() 
        {
            txtTipCuenta.Text = "";
            txtTipPersona.Text = "";
            txtTipProducto.Text = "";
            txtEstCuenta.Text = "";
            txtDescriCta.Clear();
            txtPeriodCap.Clear();
            txtCCI.Clear();
            txtUsuApertura.Text = "";
            txtPromotor.Text = "";
            dtFecApertura.Value = DateTime.Now;
            txtFecUltRenovacion.Text = "";
            txtMontoApertura.Text = "";
            txtNroFirmas.Text = "";
            txtPlazo.Clear();
            txtFinPlazo.Clear();
            txtTipPagInt.Clear();
            txtTipRenovacion.Clear();
            txtNroDiasVencer.Clear();
            txtDiasTranscurridos.Clear();
            txtNumCertificado.Clear();
            txtTasaProd.Clear();
            txtTasaCancelacion.Clear();
            txtNroTitular.Text = "";
            txtTasaNomAn.Text = "";
            txtTEA.Text = "";
            txtSaldoMin.Text = "";
            CBOrdenPago.Checked = false;
            txtSaldoCap.Text = "";
            txtMonIntDev.Text = "";
            txtMontoValor.Text = "";
            cboTipoTasa.SelectedValue = 1;
            dtFecUltCont.Value = DateTime.Now;
            CBExonITF.Checked = false;
            txtDireccionEnvioEstCta.Clear();
            cboEnvioEstCta.SelectedValue = 0;
            //--------------------------------------
            txtMontCap.Text = "0.00";
            txtMontInt.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtIntPagAde.Text = "0.00";
            txtMontTotal.Text = "0.00";

            cboMoneda.SelectedValue = 0;
            txtMontoCuota.Text = "";
            txtCuotDep.Text = "";
            txtCuotPend.Text = "";
            txtRenovacion.Text = "";
            txtTasaCanc.Text = "";
            dtUltCuota.Value = DateTime.Now;
            dtFinPlazo.Value = DateTime.Now;
            txtCapDisp.Text = "";
            txtIntDisp.Text = "";
            txtCapRet.Text = "";
            txtIntRet.Text = "";
            cboCaractCta.SelectedIndex = -1;
            txtNroRen.Text = "";
            
            tbIntervTotal.Rows.Clear();
            tbIntervActivos.Rows.Clear();
            tbComisiones.Rows.Clear();
            tbCronograma.Rows.Clear();
            dtBloq.Rows.Clear();
            //--Datos de las Renovaciones
            if (dtgRenovaciones.Rows.Count > 0)
            {
                ((DataTable)dtgRenovaciones.DataSource).Rows.Clear();
            }
            dtgRenovaciones.Refresh();

            if (dtgSolTitular.Rows.Count > 0)
            {
                ((DataTable)dtgSolTitular.DataSource).Rows.Clear();
            }
            dtgSolTitular.Refresh();

            txtMotCambio.Clear();
            txtDocRef.Clear();
            txtFecCambioTit.Clear();
            txtAgencia.Clear();
        }

        private void DeshabilitarControles() 
        {
            dtFecApertura.Enabled = false;
            txtFecUltRenovacion.Enabled = false;
            txtMontoApertura.Enabled = false;
            txtNroFirmas.Enabled = false;
            txtNroTitular.Enabled = false;
            txtTasaNomAn.Enabled = false;
            txtTEA.Enabled = false;
            txtSaldoMin.Enabled = false;
            cboEnvioEstCta.Enabled = false;
            txtDireccionEnvioEstCta.Enabled = false;
            CBOrdenPago.Enabled = false;
            txtSaldoCap.Enabled = false;
            txtMonIntDev.Enabled = false;
            txtMontoValor.Enabled = false;
            dtFecUltCont.Enabled = false;
            CBExonITF.Enabled = false;

            cboMoneda.Enabled = false;
            txtMontoCuota.Enabled = false;
            txtCuotDep.Enabled = false;
            txtCuotPend.Enabled = false;
            txtRenovacion.Enabled = false;
            txtTasaCanc.Enabled = false;
            dtUltCuota.Enabled = false;
            dtFinPlazo.Enabled = false;
            txtCapDisp.Enabled = false;
            txtIntDisp.Enabled = false;
            txtCapRet.Enabled = false;
            txtIntRet.Enabled = false;
            cboCaractCta.Enabled = false;
        }

        private string ValidarDatos()
        {                      
            if (txtSaldoMin.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Saldo Mínimo que debe tener como Disponible la cuenta", "Mantenimiento de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCuentas.SelectedIndex = 0;
                txtSaldoMin.Focus();
                return "ERROR";
            }

            if (Convert.ToBoolean(DatosCuenta.Rows[0]["PatronOrdenPago"]) == false && CBOrdenPago.Checked == true)
            {
                MessageBox.Show("Este Producto no permite Aplicar Órdenes de Pago", "Mantenimiento de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCuentas.SelectedIndex = 0;
                CBOrdenPago.Focus();
                return "ERROR";
            }

            if (Convert.ToInt32(DatosCuenta.Rows[0]["idTipoCuenta"]) == 2 && Convert.ToInt32(txtNroFirmas.Text) < 1)
            {
                MessageBox.Show("PARA CUENTAS SOLIDARIAS, El número de firmas debe ser mayor o igual a 1", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroFirmas.Focus();
                txtNroFirmas.Select();
                return "ERROR";
            }

            if (Convert.ToInt32(DatosCuenta.Rows[0]["idTipoCuenta"]) == 2 && Convert.ToInt32(txtNroFirmas.Text) > Convert.ToInt32(txtNroTitular.Text))
            {
                MessageBox.Show("PARA CUENTAS SOLIDARIAS, El número de firmas no puede ser mayor al número de titulares", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroFirmas.Focus();
                txtNroFirmas.Select();
                return "ERROR";
            }

            // Validación para Cuenta Programada

            if (CaractCta == 5 && (Convert.ToInt32(cboCaractCta.SelectedValue) != 5 || Convert.ToInt32(cboCaractCta.SelectedValue) != 1))
            {
                MessageBox.Show("Una Cuenta VENCIDA, sólo puede ser Modificada a Característica NORMAL", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbcCuentas.SelectedIndex = 2;
                cboCaractCta.Focus();
                return "ERROR";
            }

            if (Convert.ToUInt16(cboEnvioEstCta.SelectedValue) == 2) //--Envio estado de Cuenta
            {
                if (string.IsNullOrEmpty(txtDireccionEnvioEstCta.Text))
                {
                    MessageBox.Show("Debe Ingresar el Correo Electrónico, para envió de su estado de Cuenta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboEnvioEstCta.Focus();
                    return "ERROR";
                }
            }
            
            return "OK";
        }

        private void CargarComisiones(int NCuenta, int idAgencia, int idMoneda, int idTipPersona)
        {
            
            clsCNRetDatosCuenta ListaComisiones = new clsCNRetDatosCuenta();
            tbComisiones = ListaComisiones.ListarComisiones(NCuenta, idAgencia, idMoneda, idTipPersona);

            clsCNRetDatosCuenta ListaComEspeciales = new clsCNRetDatosCuenta();
            DataTable tbComespeciales = ListaComEspeciales.ListarComiEspecial(NCuenta);

            if (tbComisiones.Rows.Count > 0 && tbComespeciales.Rows.Count > 0)
            {
                int n = 0;
                foreach (DataRow fila in tbComespeciales.Rows)
                {
                    n += 1;
                    foreach (DataRow fila2 in tbComisiones.Rows)
                    {
                        if (Convert.ToInt32(fila["IdComsion"]) == Convert.ToInt32(fila2["idConfigGastComiSeg"]))
                            fila2["lObligatorio"] = fila["lAplica"];
                    }
                }
            }          

            //if (dtgComisiones.ColumnCount > 0)
            //{
            //    dtgComisiones.Columns.Remove("cNombreCorto");
            //    dtgComisiones.Columns.Remove("nValorAplica");
            //    dtgComisiones.Columns.Remove("lObligatorio");  
            //}
            this.dtgComisiones.DataSource = tbComisiones.DefaultView;

            //Formato de la tabla Comisiones
            dtgComisiones.DefaultCellStyle.Font=new Font("Arial", 7);
            //dtgComisiones.Columns["cNombreCorto"].Width = 50;
            dtgComisiones.Columns["cNombreCorto"].HeaderText = "Comisión";
            dtgComisiones.Columns["cNombreCorto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgComisiones.Columns["cDesTipoPago"].Width = 80;
            
            dtgComisiones.Columns["cDesTipoPago"].HeaderText = "Tipo Pago";
            dtgComisiones.Columns["cDesTipoPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgComisiones.Columns["cTipoOperacion"].Width = 80;
            dtgComisiones.Columns["cTipoOperacion"].HeaderText = "Tipo Operacion";
            dtgComisiones.Columns["cTipoOperacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgComisiones.Columns["cCanal"].Width = 30;
            dtgComisiones.Columns["cCanal"].HeaderText = "Canal";
            dtgComisiones.Columns["cCanal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgComisiones.Columns["idConfigGastComiSeg"].Visible = false;

            //dtgComisiones.Columns["nValorAplica"].Width = 20;
            dtgComisiones.Columns["nValorAplica"].HeaderText = "Monto";
            dtgComisiones.Columns["nValorAplica"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgComisiones.Columns["lObligatorio"].Width = 35;
            dtgComisiones.Columns["lObligatorio"].HeaderText = "Aplic.";
            dtgComisiones.Columns["lObligatorio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarDatosCambioTitular(int idCta)
        {
            clsCNRetDatosCuenta BuscarDatosCuenta = new clsCNRetDatosCuenta();
            DataTable dtCamTit = BuscarDatosCuenta.ListarSolCambioxCuenta(idCta);
            dtgSolTitular.DataSource = dtCamTit;

            dtgSolTitular.Columns["idSolCambio"].Visible = false;
            dtgSolTitular.Columns["idCuenta"].Visible = false;
            dtgSolTitular.Columns["cMotivoCambio"].Visible = false;
            dtgSolTitular.Columns["cDocReferencia"].Visible = false;
            dtgSolTitular.Columns["dFechaAplica"].Visible = false;
            dtgSolTitular.Columns["cNomCorto"].Visible = false;

            dtgSolTitular.Columns["idSolicitud"].HeaderText = "Solicitud";
            dtgSolTitular.Columns["idSolicitud"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolTitular.Columns["idSolicitud"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgSolTitular.Columns["idSolicitud"].Width = 50;
            dtgSolTitular.Columns["cMotivoExt"].HeaderText = "Cambio Titular";
            dtgSolTitular.Columns["cMotivoExt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolTitular.Columns["cMotivoExt"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgSolTitular.Columns["cMotivoExt"].Width = 80;
            dtgSolTitular.Columns["dFecSolici"].HeaderText = "Fec. Solicitud";
            dtgSolTitular.Columns["dFecSolici"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolTitular.Columns["dFecSolici"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgSolTitular.Columns["dFecSolici"].Width = 60;
            dtgSolTitular.Columns["cNombre"].HeaderText = "Usuario que Solicito";
            dtgSolTitular.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolTitular.Columns["cNombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgSolTitular.Columns["cNombre"].Width = 120;
            dtgSolTitular.Columns["cEstadoSol"].HeaderText = "Estado Solicitud";
            dtgSolTitular.Columns["cEstadoSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolTitular.Columns["cEstadoSol"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgSolTitular.Columns["cEstadoSol"].Width = 100;
        }

        private void CargarRenovaciones(int idCta)
        {
            clsCNRetDatosCuenta BuscarDatosCuenta = new clsCNRetDatosCuenta();
            DataTable dtRen = BuscarDatosCuenta.ListarRenovacionesxCuenta(idCta);
            dtgRenovaciones.DataSource = dtRen;
            if (dtRen.Rows.Count>0)
            {
                txtNroRen.Text = dtRen.Rows[0]["nNroRen"].ToString();
            }
            else
            {
                txtNroRen.Text="";
            }
            dtgRenovaciones.Columns["nNroRen"].Visible = false;
            dtgRenovaciones.Columns["idCuenta"].HeaderText = "Cuenta.";
            dtgRenovaciones.Columns["idCuenta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgRenovaciones.Columns["dFechaRen"].HeaderText = "Fecha Renovacion";
            dtgRenovaciones.Columns["dFechaRen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgRenovaciones.Columns["nMontoRen"].HeaderText = "Monto Renovación";
            dtgRenovaciones.Columns["nMontoRen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarDatosBloqueo(int idCta)
        {
            clsCNRetDatosCuenta clsDeposito = new clsCNRetDatosCuenta();
            dtBloq = clsDeposito.RetornaBloqueosxCuenta(idCta);

            dtgBloqueosCta.DataSource = dtBloq;

            CalcularTotal();
        }

        private void CargarIntervinientes(int NCuenta)
        {
            clsCNRetDatosCuenta ListaIntervinientes = new clsCNRetDatosCuenta();
            tbIntervTotal = ListaIntervinientes.ListarInterv(NCuenta);           

            if (dtgIntervTotal.ColumnCount > 0)
            {
                dtgIntervTotal.Columns.Remove("cmb");
                dtgIntervTotal.Columns.Remove("Estado");
                dtgIntervTotal.Columns.Remove("cNombre");
                dtgIntervTotal.Columns.Remove("idTipoInterv");
                dtgIntervTotal.Columns.Remove("cTipoIntervencion");
                dtgIntervTotal.Columns.Remove("dFecIniInterv");
                dtgIntervTotal.Columns.Remove("dFecFinInterv");
                dtgIntervTotal.Columns.Remove("lEstado");                
                dtgIntervTotal.Columns.Remove("idIntervCre");
                dtgIntervTotal.Columns.Remove("idCli");
                dtgIntervTotal.Columns.Remove("lCliAfeITF");
            }            

            //Crear un combobox que se le asigne el tipo de Intervención
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Tipo de Intervención";
            cmb.Name = "cmb";
            cmb.FillWeight = 60;
            cmb.MaxDropDownItems = 5;
            cmb.DataSource = dtbTipVinDep;
            cmb.DisplayMember = dtbTipVinDep.Columns["cTipoIntervencion"].ToString();
            cmb.ValueMember = dtbTipVinDep.Columns["idTipoInterv"].ToString();           

            dtgIntervTotal.Columns.Add(cmb);
            this.dtgIntervTotal.DataSource = tbIntervTotal.DefaultView;
            
            //crear la columna estado, sus valores serán "A" O "N"
            tbIntervTotal.Columns.Add("Estado", typeof(String));
            int nNumFilas = tbIntervTotal.Rows.Count;
            if (nNumFilas > 0)
            {
                for (int i = 0; i < nNumFilas; i++)
                {
                    tbIntervTotal.Rows[i]["Estado"] = "A";
                }
            }            

            FormatoGridIntervTotal();

            //llenar los combos en el DataGriedView
            Int32 nNumRows = tbIntervTotal.Rows.Count;
            if (nNumRows > 0)
            {
                for (int i = 0; i < nNumRows; i++)
                {
                    dtgIntervTotal.Rows[i].Cells["cmb"].Value = Convert.ToInt32(tbIntervTotal.Rows[i]["idTipoInterv"].ToString());
                }
            }
            MostrarIntervinientesActivos(NCuenta);                               
        }

        private void MostrarIntervinientesActivos(int idCta)
        {
            Int32 nNumRowActivos = tbIntervTotal.Rows.Count;

            if (nNumRowActivos > 0)
            {
                for (int i = 0; i < nNumRowActivos; i++)
                {
                    tbIntervTotal.Rows[i]["cTipoIntervencion"] = dtgIntervTotal.Rows[i].Cells["cmb"].FormattedValue;
                    tbIntervTotal.Rows[i]["idTipoInterv"] = dtgIntervTotal.Rows[i].Cells["cmb"].Value;
                    tbIntervTotal.Columns["dFecFinInterv"].ReadOnly = false;
                    if (Convert.ToBoolean(dtgIntervTotal.Rows[i].Cells["lEstado"].Value) == true)                   
                        tbIntervTotal.Rows[i]["dFecFinInterv"] = Convert.ToDateTime("01/01/1900");
                    if (Convert.ToBoolean(dtgIntervTotal.Rows[i].Cells["lEstado"].Value) == false && Convert.ToDateTime(tbIntervTotal.Rows[i]["dFecFinInterv"]).Date == Convert.ToDateTime("01/01/1900").Date)
                        tbIntervTotal.Rows[i]["dFecFinInterv"] = DateTime.Now;
                }
            }

            clsCNDeposito clsDeposito = new clsCNDeposito();
            tbIntervActivos = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
            this.dtgIntervActivos.DataSource = tbIntervActivos;

            //tbIntervActivos = tbIntervTotal.Clone();
            //tbIntervActivos.Rows.Clear();
            //for (int i = 0; i < (tbIntervTotal.Rows.Count); ++i)
            //{
            //    tbIntervActivos.ImportRow(tbIntervTotal.Rows[i]);
            //}
                                 
            //tbIntervActivos.DefaultView.RowFilter = ("lEstado = 'true'");
            
            //this.dtgIntervActivos.DataSource = tbIntervActivos;      
            //FormatoGridIntervActivos();        
        }        

        private void CargarCalendario(int p_idCuenta)
        {
            clsCNRetDatosCuenta BuscarCrongDepos = new clsCNRetDatosCuenta();
            tbCronograma = BuscarCrongDepos.ListarCronogDepos(p_idCuenta);

            dtgCalendDepos.DataSource = tbCronograma;
            if (tbCronograma.Rows.Count > 0)
            {
                dtUltCuota.Value = Convert.ToDateTime(tbCronograma.Rows[(tbCronograma.Rows.Count - 1)]["dFechaProg"]);
                dtFinPlazo.Value = dtUltCuota.Value.AddMonths(1);
            }
            
            //dtgCalendDepos.Columns["idCuota"].Width = 20;
            dtgCalendDepos.Columns["idCuota"].HeaderText = "N°Cuota";
            dtgCalendDepos.Columns["idCuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgCalendDepos.Columns["dFechaProg"].Width = 25;
            dtgCalendDepos.Columns["dFechaProg"].HeaderText = "Fecha de Pago Programada";
            dtgCalendDepos.Columns["dFechaProg"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgCalendDepos.Columns["dFechaPago"].Width = 25;
            dtgCalendDepos.Columns["dFechaPago"].HeaderText = "Fecha de Depósito";
            dtgCalendDepos.Columns["dFechaPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgCalendDepos.Columns["nCapital"].Width = 25;
            dtgCalendDepos.Columns["nCapital"].HeaderText = "Monto Programada";
            dtgCalendDepos.Columns["nCapital"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgCalendDepos.Columns["nCapitalPagado"].Width = 25;
            dtgCalendDepos.Columns["nCapitalPagado"].HeaderText = "Monto Depositado";
            dtgCalendDepos.Columns["nCapitalPagado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgCalendDepos.Columns["EstadoCuota"].Width = 90;
            dtgCalendDepos.Columns["EstadoCuota"].HeaderText = "Estado";
            dtgCalendDepos.Columns["EstadoCuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }           

        //private void FormatoGridIntervActivos()
        //{
        //    //dtgIntervActivos.Columns["cNombre"].Width = 140;
        //    dtgIntervActivos.Columns["cNombre"].HeaderText = "Nombre del Cliente";
        //    dtgIntervActivos.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        
        //    dtgIntervActivos.Columns["idTipoInterv"].Visible = false;

        //    //dtgIntervActivos.Columns["cTipoIntervencion"].Width = 75;
        //    dtgIntervActivos.Columns["cTipoIntervencion"].HeaderText = "Tipo de Vinculo";
        //    dtgIntervActivos.Columns["cTipoIntervencion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //dtgIntervActivos.Columns["dFecIniInterv"].Width = 70;
        //    dtgIntervActivos.Columns["dFecIniInterv"].HeaderText = "Fecha de Inicio";
        //    dtgIntervActivos.Columns["dFecIniInterv"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    dtgIntervActivos.Columns["dFecFinInterv"].Visible = false;
                                           
        //    dtgIntervActivos.Columns["lEstado"].Visible = false;
        //    dtgIntervActivos.Columns["idIntervCre"].Visible = false;
        //    dtgIntervActivos.Columns["idCli"].Visible = false;

        //    //dtgIntervActivos.Columns["lCliAfeITF"].Width = 65;
        //    dtgIntervActivos.Columns["lCliAfeITF"].HeaderText = "Afecta ITF";
        //    dtgIntervActivos.Columns["lCliAfeITF"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        //    dtgIntervActivos.Columns["Estado"].Visible = false;
        //}           

        private void FormatoGridIntervTotal() 
        {

            //dtgIntervTotal.Columns["cNombre"].Width = 140;
            dtgIntervTotal.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            dtgIntervTotal.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgIntervTotal.Columns["cmb"].Width = 60;

            dtgIntervTotal.Columns["idTipoInterv"].Visible = false;
            dtgIntervTotal.Columns["cTipoIntervencion"].Visible = false;

            dtgIntervTotal.Columns["dFecIniInterv"].Visible = false;  
            
            dtgIntervTotal.Columns["dFecFinInterv"].Visible = false;

            //dtgIntervTotal.Columns["lEstado"].Width = 25;            
            dtgIntervTotal.Columns["lEstado"].HeaderText = "Vig.";
            dtgIntervTotal.Columns["lEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgIntervTotal.Columns["idIntervCre"].Visible = false;
            dtgIntervTotal.Columns["idCli"].Visible = false;
            dtgIntervTotal.Columns["Estado"].Visible = false;

            //dtgIntervTotal.Columns["lCliAfeITF"].Width = 65;
            dtgIntervTotal.Columns["lCliAfeITF"].HeaderText = "Afecta ITF";
            dtgIntervTotal.Columns["lCliAfeITF"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgIntervTotal.Columns["cNombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervTotal.Columns["cmb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervTotal.Columns["lEstado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervTotal.Columns["lCliAfeITF"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void CalcularTotal()
        {
            Decimal nTotal = 0.00m;
            dtBloq = null;
            dtBloq = (DataTable)dtgBloqueosCta.DataSource;
            if (dtBloq.Rows.Count > 0)
            {
                foreach (DataRow item in dtBloq.Rows)
                {
                    nTotal = nTotal + Convert.ToDecimal (item["nMonBloqueo"]);
                    txtTotalBloq.Text = String.Format("{0:0.00}", nTotal);
                }
            }
            else
            {
                txtTotalBloq.Text = String.Format("{0:0.00}", 0.00);
            }
        }

        private void cboEnvioEstCta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDireccionEnvioEstCta.Text = "";

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2) //Envio por Correo
            {
                txtDireccionEnvioEstCta.KeyPress += txtDireccionEnvioEstCta_KeyPress;
            }
            else
            {
                txtDireccionEnvioEstCta.KeyPress -= txtDireccionEnvioEstCta_KeyPress;
            }

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 3) //Recojo en Oficina de Crac Lasa
            {
                txtDireccionEnvioEstCta.Enabled = false;
            }
            else
            {
                txtDireccionEnvioEstCta.Enabled = true;
            }

            txtDireccionEnvioEstCta.Focus();
        }

        private void txtDireccionEnvioEstCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 64 && e.KeyChar <= 90)
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 97 && e.KeyChar <= 122)
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == 47 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 95 || e.KeyChar == 64)
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dtgSolTitular_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgSolTitular.Rows.Count>0)
            {
                Int32 fila = Convert.ToInt32(this.dtgSolTitular.CurrentRow.Index);

                txtMotCambio.Text = dtgSolTitular.Rows[fila].Cells["cMotivoCambio"].Value.ToString();
                txtDocRef.Text = dtgSolTitular.Rows[fila].Cells["cDocReferencia"].Value.ToString();
                txtFecCambioTit.Text = dtgSolTitular.Rows[fila].Cells["dFechaAplica"].Value.ToString();
                txtAgencia.Text = dtgSolTitular.Rows[fila].Cells["cNomCorto"].Value.ToString();
            }
            
        }

        private void CBOrdenPago_CheckedChanged(object sender, EventArgs e)
        {
            if (!CBOrdenPago.Checked)
            {
                DataTable dtOP = clsDeposito.CNValidaChequeraCta(p_idCuenta);
                if (dtOP.Rows.Count>0)
                {
                    MessageBox.Show("La cuenta tiene talonarios con Ordenes de Pago Vigentes, Primero debe Anular o Devolver los talonarios", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CBOrdenPago.Checked = true;
                    return;
                }
            }
        }

        private void txtDireccionEnvioEstCta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar >= 64 && e.KeyChar <= 90)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar >= 97 && e.KeyChar <= 122)
                {
                    e.Handled = false;
                }

                else if (e.KeyChar == 45 || e.KeyChar == 95)//guion y subguion
                {
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 64)//arroba
                {
                    int CantArrobas = 0;

                    for (int i = 0; i < this.txtDireccionEnvioEstCta.TextLength; i++)
                    {
                        if (this.txtDireccionEnvioEstCta.Text.Substring(i, 1) == "@")
                        {
                            CantArrobas = 1;
                        }
                    }
                    if (CantArrobas == 1)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else if (e.KeyChar == 46)//punto
                {
                    int CantLetras = this.txtDireccionEnvioEstCta.TextLength;
                    if (CantLetras >= 1)
                    {
                        if (this.txtDireccionEnvioEstCta.Text.Substring((CantLetras - 1), 1) == ".")
                        {
                            e.Handled = true;
                        }
                        else
                            e.Handled = false;
                    }
                }

                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtDireccionEnvioEstCta_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2)
            {
                Regex xrEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                if (!xrEmail.IsMatch(this.txtDireccionEnvioEstCta.Text) && !String.IsNullOrEmpty(this.txtDireccionEnvioEstCta.Text.Trim()))
                {
                    MessageBox.Show("La texto introducido no tiene el formato de un email ", "Validación de Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtDireccionEnvioEstCta.Focus();
                    return;
                }
            }
        }  
    }
}
