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
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmSimuladorAho : frmBase
    {
        private Int32 CodPro = 46;
        clsFunUtiles FunTruncar = new clsFunUtiles();
        bool lEsReqPagInt, lEsDefTipPagInt;
        DataTable dtDatosCtaAho, dtDetalleCtaAho,tbDepMen = null;

        public frmSimuladorAho()
        {
            InitializeComponent();
        }

        private void frmSimuladorAho_Load(object sender, EventArgs e)
        {
            dtpFechaApe.Value = clsVarGlobal.dFecSystem;
            dtpFecCancel.Value = clsVarGlobal.dFecSystem;
            dtpFecVenc.Value = clsVarGlobal.dFecSystem;
            this.cboTipoDeposito.CargarProducto(CodPro);
            this.cboTipoDeposito.SelectedIndex = 1;
            tbDepMen = formatoDepositoMensual();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboTipoDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoDeposito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboTipoDeposito.SelectedValue);
                cboSubTipoDeposito.CargarProducto(CodPro);
                if (cboSubTipoDeposito.Items.Count > 1)
                {
                    cboSubTipoDeposito.SelectedIndex = 1;
                    cboPagoInt.SelectedValue = 0;
                    cboTipoPersona.SelectedValue = 1;
                    cboMoneda.SelectedValue = 1;
                }
                else
                {
                    btnProcesar.Enabled = false;
                }
            }
            else
            {                
                cboSubTipoDeposito.CargarProducto(-1);
            }
            LimpiarControles();
            txtMonto.Text = String.Format("{0:0.00}", 0.00);
            txtPlazo.Text = "0";
        }

        private void cboSubTipoDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoDeposito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboSubTipoDeposito.SelectedValue);
                cboProducto.CargarProducto(CodPro);
                if (cboProducto.Items.Count > 1)
                {
                    cboProducto.SelectedIndex = 1;
                }
                else
                {
                    btnProcesar.Enabled = false;
                }
            }
            else
            {                
                cboProducto.CargarProducto(-1);
            }
            LimpiarControles();
            txtMonto.Text = String.Format("{0:0.00}", 0.00);
            txtPlazo.Text = "0";
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(CodPro);
                if (cboSubProducto.Items.Count > 1)
                {
                    cboSubProducto.SelectedIndex = 1;
                    btnProcesar.Enabled = true;
                }
                else
                {
                    btnProcesar.Enabled = false;
                }
            }
            else
            {             
                cboSubProducto.CargarProducto(-1);
            }
            LimpiarControles();
            txtMonto.Text = String.Format("{0:0.00}", 0.00);
            txtPlazo.Text = "0";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            lblint.Visible = false;
            txtIntEspecial.Visible = false;            
            if (!ValidarDatos())
            {
                return;
            }
            LimpiarControles();
            //--=====================================================
            //--Cargar parámetros del Producto y Validar
            //--=====================================================
            bool lEsAfeItf = false;
            int nTipCalInt = 0;
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(Convert.ToInt32(cboSubProducto.SelectedValue.ToString()), Convert.ToInt32(cboMoneda.SelectedValue.ToString()), 2);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                lEsAfeItf = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                nTipCalInt = Convert.ToInt32(dt.Rows[0]["nTipCalInt"].ToString());
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //===============================================================
            //--Validar De ACuerdo a los parámetros de Retorno
            //===============================================================
            if (Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"].ToString()))  //--El producto requiere Plazo
            {
                if (string.IsNullOrEmpty(this.txtPlazo.Text))
                {
                    MessageBox.Show("Debe de ingresar el PLAZO DEL PRODUCTO", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazo.Focus();
                    txtPlazo.Select();
                    return;
                }

                if (Convert.ToInt32(this.txtPlazo.Text) <= 0)
                {
                    MessageBox.Show("El Plazo Ingresado no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazo.Focus();
                    txtPlazo.Select();
                    return;
                }
            }

            //====================================================
            //--Recuperara Tasa
            //====================================================
            clsCNCalculosAho nInteres = new clsCNCalculosAho();
            int nPlazo=Convert.ToInt32(txtPlazo.Text);
            Decimal nMonto=Convert.ToDecimal (txtMonto.Text),nTasTEA=0.00m;
            Decimal nTasa = RecuperarTasa(nPlazo, Convert.ToInt32(cboSubProducto.SelectedValue), Convert.ToDecimal(nMonto), Convert.ToInt32(cboMoneda.SelectedValue), 
                                        clsVarGlobal.nIdAgencia,Convert.ToInt32(cboTipoPersona.SelectedValue));
            if (nTasa==0.00m)
            {
                return;
            }
            
            nTasTEA = nTasa;
            Decimal nMonInteres = 0.00m, nMonIntEsp = 0.00m, nMonFavCli = 0.00m;

            switch (Convert.ToInt32(cboPagoInt.SelectedValue))
            {
                case 1: //--PAGO EN LA APERTURA
                    
                    nMonIntEsp = nInteres.CalcularIntAdelantado(nTasa, nPlazo, nMonto);
                    lblint.Visible = true;
                    lblint.Text="Interes Adelantado";
                    txtIntEspecial.Visible = true;
                    //nMonIntEsp = FunTruncar.redondearBCR(nMonIntEsp, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    nMonInteres = nMonIntEsp;
                    txtIntEspecial.Text = TipoMoneda() + String.Format("{0:0.00}", nMonIntEsp);
                    tbDepMen.Clear();
                    break;
                case 2: //--AL CANCELAR LA CUENTA                    
                    nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    tbDepMen.Clear();
                    break;
                case 3:  //--MENSUALMENTE
                    tbDepMen = nInteres.CalculaPpgDepMensual(nMonto, dtpFechaApe.Value, nPlazo, nTasa);
                    object sumObject;
                    sumObject = tbDepMen.Compute("Sum(interes)", "");
                    nMonInteres = Math.Round(Convert.ToDecimal (sumObject),2);
                    //nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    nMonIntEsp = nInteres.CalcularInteresAho(nTasa, 30, nMonto, nTipCalInt);
                    lblint.Visible = true;
                    lblint.Text="Interes Mensual (Calculado a 30 Días)";
                    txtIntEspecial.Visible = true;
                    //nMonIntEsp = FunTruncar.redondearBCR(nMonIntEsp, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    txtIntEspecial.Text = TipoMoneda() + String.Format("{0:0.00}", nMonIntEsp);
                    break;
                default: //--Ahorro Corriente y CTS
                    nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    tbDepMen.Clear();
                    lblint.Visible = false;
                    txtIntEspecial.Visible = false;
                    break;

            }
            //--Asignar Valores
            
            //Calculado el saldo Final
            //Decimal nSaldoFinal = FunTruncar.redondearBCR(nMonto + nMonInteres, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
            Decimal nSaldoFinal = nMonto + nMonInteres;
            //--calculando el Monto de Interes Final Redondeado
            //nMonInteres = FunTruncar.redondearBCR(nMonInteres, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
            
            this.txtIntGan.Text = TipoMoneda() + String.Format("{0:0.00}", nMonInteres);
            this.txtMontoFin.Text = TipoMoneda() + String.Format("{0:0.00}", nSaldoFinal);
            this.txtTRA.Text = @"T.R.E.A(%) " + String.Format("{0:0.00}", Math.Round(nTasa, 2));
            this.txtTEA.Text = @"T.E.A(%) " + String.Format("{0:0.00}", Math.Round(nTasTEA, 2));
            this.dtpFecVenc.Value = Convert.ToDateTime(this.dtpFechaApe.Value).AddDays(nPlazo);
            this.dtpFecCancel.Value = Convert.ToDateTime(this.dtpFecVenc.Value).AddDays(1);
            this.txtITF.Text = "0.00" + @" %";
            Decimal nMonApe = 0.00m,nMonITF=0.00m;
            nMonApe = Convert.ToDecimal (this.txtMonto.Text);
            if (lEsAfeItf)
            {
                this.txtITF.Text = clsVarGlobal.nITF.ToString() + @" %";                
                nMonITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * Convert.ToDecimal (this.txtMonto.Text), 2, (Int32)this.cboMoneda.SelectedValue);
            }
            
            nMonApe = nMonApe + nMonITF;
            
            this.txtITFApe.Text = TipoMoneda() + String.Format("{0:0.00}", nMonITF);
            this.txtMonTotalApe.Text = TipoMoneda() + String.Format("{0:0.00}", nMonApe);
            btnImprimir1.Enabled = true;
        }
        private DataTable  formatoDepositoMensual()
        {
            DataTable dtPpg = new DataTable("dtPlanPago");
            dtPpg.Columns.Add("cuota", typeof(int));
            dtPpg.Columns.Add("fecha", typeof(DateTime));
            dtPpg.Columns.Add("dias", typeof(int));
            dtPpg.Columns.Add("concepto", typeof(string));
            dtPpg.Columns.Add("interes", typeof(Decimal));
            dtPpg.Columns.Add("capital", typeof(Decimal));
            dtPpg.Columns.Add("dias_acu", typeof(int));
            dtPpg.Columns.Add("comisiones", typeof(Decimal));
            return dtPpg;
        }
        //==========================================================
        //--Recuperar el Saldo Final de Cuenta Corriente
        //==========================================================
        private Decimal CalcularSaldoFinal(Decimal nTasInt, int nDiasTrans, Decimal nSalCapita)
        {
            Decimal nMonFavCli = 0.00m;
            Decimal nSaldoFinal = 0.00m;
            Decimal nFactor = Convert.ToDecimal(Math.Pow((1 + ((double)nTasInt / 100.00)), (1 / 360.00))) - 1;
            Decimal nInteres = (nFactor * nSalCapita) * nDiasTrans;
            nSaldoFinal = nSalCapita + nInteres;
            return FunTruncar.redondearBCR(nSaldoFinal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
        }

        //==========================================================
        //--Recuperar el Saldo Final de Cuenta Plazo Fijo
        //==========================================================
        private Decimal CalcularSaldoFinalPlazoFijo(Decimal nTasInt, Decimal nDiasTrans, Decimal nSalCapita, Decimal nFrePagoInt)
        {
            Decimal nMonFavCli = 0.00m;
            Decimal nSaldoFinal = 0.00m;
            Decimal nInteres = Convert.ToDecimal(Math.Pow((1 + (double)nTasInt / 100), ((double)nFrePagoInt / 360.00)) - 1) * nSalCapita;
            nSaldoFinal = nSalCapita + (nDiasTrans / nFrePagoInt) * nInteres;
            return FunTruncar.redondearBCR(nSaldoFinal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
        }

        private void LimpiarControles()
        {
            this.txtIntGan.Text = String.Format("{0:0.00}", 0.00);
            this.txtMontoFin.Text = String.Format("{0:0.00}", 0.00);
            this.dtpFecVenc.Value = clsVarGlobal.dFecSystem;
            this.dtpFecCancel.Value = clsVarGlobal.dFecSystem;           
            this.txtTEA.Text = @"T.E.A(%) " + String.Format("{0:0.00}", 0.00);
            this.txtTRA.Text = @"T.R.E.A(%) " + String.Format("{0:0.00}", 0.00);
            this.txtITF.Text = "0.00" + @" %";
            this.txtITFApe.Text = String.Format("{0:0.00}", 0.00);
            this.txtIntEspecial.Text = String.Format("{0:0.00}", 0.00);
            this.txtMonTotalApe.Text = String.Format("{0:0.00}", 0.00);
            btnImprimir1.Enabled = false;
        }

        private string TipoMoneda()
        {
            string lsMoneda;
            if (cboMoneda.SelectedValue.ToString() == "2") 
                lsMoneda = "$. ";
            else 
                lsMoneda = "S/. ";
            return lsMoneda;
        }

        //==========================================================
        //--Recuperar Tasa para el Producto
        //==========================================================
        private Decimal RecuperarTasa(Int32 nPlazo, Int32 idProducto, decimal nMonto, Int32 idMoneda, Int32 idAgencia,int idTipPer)
        {
            clsCNAperturaCta TasaAho = new clsCNAperturaCta();
            DataTable dt = TasaAho.RetornaTasaAhorros(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipPer);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal (dt.Rows[0]["nTasaCompensatoria"].ToString());
            }
            else
            {
                MessageBox.Show("No se encontro la tasa para el subproducto", "Validación Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0.00m;
            }

        }

        //==========================================================
        //--Recuperar Parámetros por Producto
        //==========================================================
        private void CargaParamProducto(int idProd, int idMon, int idOpc)
        {
            txtMonto.Enabled = false;
            btnProcesar.Enabled = true;
            txtMonto.Text = "0.00";
            txtPlazo.Text = "0";
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(idProd, idMon, idOpc);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                lEsReqPagInt = Convert.ToBoolean(dt.Rows[0]["lIsReqPagInt"].ToString());
                lEsDefTipPagInt = Convert.ToBoolean(dt.Rows[0]["lIsDefTipPagInt"].ToString());
                txtPlazo.Text = dt.Rows[0]["nPlaMaxProd"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"]))
                {
                   // txtPlazo.Enabled = false;
                }
                else
                {
                    txtPlazo.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Enabled = false;
                btnProcesar.Enabled = false;
                return;
            }
            txtMonto.Enabled = true;
            txtMonto.Focus();
            txtMonto.Select();
        }

        //==========================================================
        //--Cargar Modalidades de Pago de Intereses
        //==========================================================
        private void CargarPagoIntereses()
        {
            cboPagoInt.Enabled = true;
            if (lEsReqPagInt)
            {
                if (lEsDefTipPagInt)
                {
                    clsCNOperacionDep deposito = new clsCNOperacionDep();
                    DataTable dt = deposito.ListaPagoInteresProd(Convert.ToInt32(cboSubProducto.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        this.cboPagoInt.DataSource = dt;
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Existe Tipos de pago de Interes para el Concepto, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    clsCNOperacionDep deposito = new clsCNOperacionDep();
                    DataTable dt = deposito.LisTiposPagoInteres();
                    if (dt.Rows.Count > 0)
                    {
                        this.cboPagoInt.DataSource = dt;
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Existe Tipos de pago de Intereses, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                this.cboPagoInt.DataSource = this.cboPagoInt.DataSource;
                cboPagoInt.SelectedValue = 0;
                cboPagoInt.Enabled = false;
            }
        }

        private bool ValidarDatos()
        {
            //========================================================================
            //--Validar Datos
            //========================================================================
            if (cboSubTipoDeposito.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el sub Tipo", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSubTipoDeposito.Focus();
                return false;
            }

            if (cboProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Producto", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProducto.Focus();
                return false;
            }

            if (cboSubProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Sub Producto", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSubProducto.Focus();
                return false;
            }

            
            if (cboTipoPersona.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Tipo de Persona", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPersona.Focus();
                return false;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe seleccionar el tipo de moneda", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtMonto.Text))
            {
                MessageBox.Show("Debe de ingresar el MONTO DE APERTURA", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                txtMonto.Select();
                return false;
            }

            if (Convert.ToDecimal (this.txtMonto.Text) < 0)
            {
                MessageBox.Show("El Monto Ingresado no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                txtMonto.Select();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtPlazo.Text))
            {
                MessageBox.Show("Debe de ingresar el Plazo del Producto", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlazo.Focus();
                return false;
            }

            if (Convert.ToInt32(this.txtPlazo.Text) < 0)
            {
                MessageBox.Show("El Plazo Ingresado no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlazo.Focus();
                txtPlazo.Select();
                return false;
            }
            return true;
        }

        private void cboPagoInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoPersona.SelectedValue = 1;
            cboPagoInt.SelectedValue = 0;
            cboTipoPersona.SelectedValue = 1;
            cboMoneda.SelectedValue = 1;
            if (this.cboSubProducto.SelectedIndex > 0)
            {
                int CodSubPro = Convert.ToInt32(this.cboSubProducto.SelectedValue);
                CargaParamProducto(CodSubPro, 1, 2);
                CargarPagoIntereses();
            }
            else
            {
                cboSubProducto.SelectedIndex = 0;
                cboTipoPersona.SelectedIndex = 0;
            }
            LimpiarControles();
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSubProducto.SelectedIndex > 0)
            {
                int CodSubPro = Convert.ToInt32(this.cboSubProducto.SelectedValue);
                CargaParamProducto(CodSubPro, 1, 2);
                CargarPagoIntereses();
            }
            else
            {
                cboSubProducto.SelectedIndex = 0;
                cboTipoPersona.SelectedIndex = 0;
            }
            LimpiarControles();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboSubProducto.SelectedIndex < 0)
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (cboTipoPersona.SelectedIndex < 0)
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (string.IsNullOrEmpty(this.txtMonto.Text))
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (Convert.ToDecimal (this.txtMonto.Text) < 0)
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (string.IsNullOrEmpty(this.txtPlazo.Text))
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (Convert.ToInt32(this.txtPlazo.Text) < 0)
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
            }

            if (string.IsNullOrEmpty(this.txtMontoFin.Text))
            {
                MessageBox.Show("El reporte no tiene datos", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImprimir1.Enabled = false;
                return;
           }           

            btnImprimir1.Enabled = true;

            dtDatosCtaAho = new DataTable("dtDatosCtaAho");
            dtDetalleCtaAho = new DataTable("dtDetalleCtaAho");

            CrearDataTables();

            //INICIO DE CARGA DE DATOS PARA EL REPORTE DE SIMULACION
            DataRow drDatCtaAho = dtDatosCtaAho.NewRow();
            drDatCtaAho["idTipoDeposito"]       = Convert.ToInt32(cboTipoDeposito.SelectedValue);
            drDatCtaAho["cTipoDeposito"]        = cboTipoDeposito.Text;
            drDatCtaAho["idSubTipoDeposito"]    = Convert.ToInt32(cboSubTipoDeposito.SelectedValue);
            drDatCtaAho["cSubTipoDeposito"]     = cboSubTipoDeposito.Text;
            drDatCtaAho["idProducto"]           = Convert.ToInt32(cboProducto.SelectedValue);
            drDatCtaAho["cProducto"]            = cboProducto.Text;
            drDatCtaAho["idSubProducto"]        = Convert.ToInt32(cboSubProducto.SelectedValue);
            drDatCtaAho["cSubProducto"]         = cboSubProducto.Text;
            drDatCtaAho["idTipoPersona"]        = Convert.ToInt32(cboTipoPersona.SelectedValue);
            drDatCtaAho["cTipoPersona"]         = cboTipoPersona.Text;
            drDatCtaAho["idMoneda"]             = Convert.ToInt32(cboMoneda.SelectedValue);
            drDatCtaAho["cMoneda"]              = cboMoneda.Text;
            drDatCtaAho["nMontoDep"]            = Convert.ToDecimal(txtMonto.Text);
            drDatCtaAho["dFechaApert"]          = dtpFechaApe.Value.ToString("dd/MM/yyyy");
            drDatCtaAho["nPlazo"]               = Convert.ToInt32(txtPlazo.Text);
            dtDatosCtaAho.Rows.Add(drDatCtaAho);

            DataRow drDetalleCtaAho = dtDetalleCtaAho.NewRow();
            drDetalleCtaAho["nInteresGanado"]   = txtIntGan.Text.ToString();
            drDetalleCtaAho["nMontoFinalPlazo"] = txtMontoFin.Text.ToString();
            drDetalleCtaAho["dFechaVenc"]       = dtpFecVenc.Value.ToString("dd/MM/yyyy");
            drDetalleCtaAho["dFechaCanc"]       = dtpFecCancel.Value.ToString("dd/MM/yyyy");
            drDetalleCtaAho["nTEA"]             = txtTEA.Text.ToString();
            drDetalleCtaAho["nTREA"]            = txtTRA.Text.ToString();
            drDetalleCtaAho["nPorcITF"]         = txtITF.Text.ToString();
            drDetalleCtaAho["nMontoITF"]        = txtITFApe.Text.ToString();
            dtDetalleCtaAho.Rows.Add(drDetalleCtaAho);


            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtDatosCtaAho", dtDatosCtaAho));
            dtslist.Add(new ReportDataSource("dtsDetalleCtaAho", dtDetalleCtaAho));
            
                dtslist.Add(new ReportDataSource("dtsDepInteresMensual", tbDepMen));
      
            

            string reportpath = "rptSimuladorAhorro.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            //
        }

        private void CrearDataTables()
        {
            //=======================================================================
            //--Crear las columnas del DataTable del Maestro del comprobante 
            //=======================================================================
            dtDatosCtaAho.Columns.Add("idTipoDeposito", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cTipoDeposito", typeof(string));
            dtDatosCtaAho.Columns.Add("idSubTipoDeposito", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cSubTipoDeposito", typeof(string));
            dtDatosCtaAho.Columns.Add("idProducto", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cProducto", typeof(string));
            dtDatosCtaAho.Columns.Add("idSubProducto", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cSubProducto", typeof(string));
            dtDatosCtaAho.Columns.Add("idTipoPersona", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cTipoPersona", typeof(string));
            dtDatosCtaAho.Columns.Add("idMoneda", typeof(Int32));
            dtDatosCtaAho.Columns.Add("cMoneda", typeof(string));
            dtDatosCtaAho.Columns.Add("nMontoDep", typeof(decimal));
            dtDatosCtaAho.Columns.Add("dFechaApert", typeof(string));
            dtDatosCtaAho.Columns.Add("nPlazo", typeof(Int32));


            dtDetalleCtaAho.Columns.Add("nInteresGanado", typeof(string));
            dtDetalleCtaAho.Columns.Add("nMontoFinalPlazo", typeof(string));
            dtDetalleCtaAho.Columns.Add("dFechaVenc", typeof(string));
            dtDetalleCtaAho.Columns.Add("dFechaCanc", typeof(string));
            dtDetalleCtaAho.Columns.Add("nTEA", typeof(string));
            dtDetalleCtaAho.Columns.Add("nTREA", typeof(string));
            dtDetalleCtaAho.Columns.Add("nPorcITF", typeof(string));
            dtDetalleCtaAho.Columns.Add("nMontoITF", typeof(string));
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void txtPlazo_TextChanged(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnDetalle1_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaApe_ValueChanged(object sender, EventArgs e)
        {
            LimpiarControles();
        }          
    }
}
