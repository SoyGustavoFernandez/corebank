using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.Text.RegularExpressions;
using SPL.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmGenAperturaCta : frmBase
    {
        private int CodPro = 46, x_nTipOpe = 0, p_nPlaAhoPrg=0;
        int nidCliTit = 0,idTasa=0,p_idCta = 0,x_idCliRegla=0, idCuentaRel=0;
        Decimal p_nMonMinSalDis = 0.00m;
        DataTable dtInt = new DataTable();
        DataTable tbCtasCanceladas = new DataTable();
        DataTable dtComision = null, tbAhoPrg = null, tbDepMen=null;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNOperacionDep OpeDeposito = new clsCNOperacionDep();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        bool lEsTrabFin, lEsReqPagInt, lEsDefTipPagInt, lEsReqEmpleador, lIsRequeCert, lEsAhoProg, lEsCtaCTS, lEsCliInterno = false, lEsAfeITF, lIsDepMenEdad, lReqCuentaRel, lIsPlazoProd;
        private string cNomInterv;
        string cMontoLetras;
        clsNumLetras objNumLetras = new clsNumLetras();
        //Variable que se Carga al Inicio
        string pcRucFinanciera = clsVarApl.dicVarGen["cRUC"];
        DataTable tbDatosSolicitud;

        public frmGenAperturaCta()
        {
            InitializeComponent();
        }

        private void frmGenAperturaCta_Load(object sender, EventArgs e)
        {
            dtpFecAhoProg.Value = clsVarGlobal.dFecSystem;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            this.cboTipoDeposito.CargarProducto(CodPro);
            this.cboTipoDeposito.SelectedIndex = 0;
            conSolesDolar.iMagenMoneda(0);
            cargarcolumnas();
            CargarModalidadPago();
            TablaCtasCancel();
            cboTipoApe.SelectedIndex = 0;
            x_nTipOpe = 9;
            conBusCtaAhoTransf.p_idTipOpePrincipal = x_nTipOpe; //Indica la Operación Principal
            cboTipoDeposito.Focus();

            txtDireccionEnvioEstCta.KeyPress -= txtDireccionEnvioEstCta_KeyPress;
            this.cboEnvioEstCta.SelectedValue = -1;
            this.cboOrigenFondos.SelectedIndex = -1;
        }

        //==========================================================
        //--Cargar Tipo de Cuenta por Producto
        //==========================================================
        private void CargarTipCtaProd(int idProd)
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaTipoCtaProd(idProd);
            if (dt.Rows.Count > 0)
            {
                 //Añadido temporalmente *******************************
                    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 2 || Convert.ToInt32(cboTipoPersona.SelectedValue) == 3)
                    {
                        dt.DefaultView.RowFilter = ("idTipoCuenta ='1'");
                        cboTipoCuenta.DataSource = dt.DefaultView;      
                    }
                    else
                    {
                        cboTipoCuenta.DataSource = dt;  
                    }
                    cboTipoCuenta.ValueMember = dt.Columns["idTipoCuenta"].ToString();
                    cboTipoCuenta.DisplayMember = dt.Columns["cTipoCuenta"].ToString();
                //*****************************************************************
            }
            else
            {
                cboTipoCuenta.DataSource = dt;
            }      
        }

        private void TablaCtasCancel()
        {
            tbCtasCanceladas.Columns.Add("lMarca", typeof(string));
            tbCtasCanceladas.Columns.Add("idCuenta", typeof(int));
            tbCtasCanceladas.Columns.Add("cMoneda", typeof(string));
            tbCtasCanceladas.Columns.Add("cProducto", typeof(string));
            tbCtasCanceladas.Columns.Add("cTipoCuenta", typeof(string));
            tbCtasCanceladas.Columns.Add("dFechaCancelacion", typeof(DateTime));
        }

        //==========================================================
        //--Cargar Comisiones pro Producto
        //==========================================================
        private void CargarComisiones(int idProd, int idMon)
        {
            dtComision = null;
            int x_idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            Decimal nMonto = Convert.ToDecimal (txtMonto.Text);
            int nPlazo = 0;
            nPlazo = Convert.ToInt32(txtPlazoAho.Text.ToString());
            if (lEsAhoProg)
            {
                nPlazo = Convert.ToInt32(nudNroDep.Value) * 30;
            }

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, Convert.ToInt32(cboTipoPersona.SelectedValue), idMon,
                                                        0, 1, clsVarGlobal.nIdAgencia, nMonto, nPlazo, x_idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal (dtComision.Compute("SUM(nValorAplica)", ""));
                txtComApe.Text = nTotCom.ToString();
                txtComision.Text = nTotCom.ToString();
                txtComisiones.Text = nTotCom.ToString();
            }
            else
            {
                txtComApe.Text = "0.00";
                txtComision.Text = "0.00";
                txtComisiones.Text = "0.00";
            }
        }

        private void PpgAhoProgramado(Decimal nMonCuota, int nNumCuotas,short nTipPPG)
        {
            tbAhoPrg = null;
            p_nPlaAhoPrg = 0;
            int dia = dtpFecAhoProg.Value.Day;
            clsCNCalculosAho objppg = new clsCNCalculosAho();
            tbAhoPrg = objppg.CalculaPpgDep(nMonCuota, clsVarGlobal.dFecSystem, dtpFecAhoProg.Value, nNumCuotas, 0, nTipPPG, dia, 0);
            if (tbAhoPrg.Rows.Count>0)
            {
                p_nPlaAhoPrg = Convert.ToInt32(tbAhoPrg.Compute("SUM(dias)", ""));
            }
        }


        private void FormatoGrid()
        {
            this.dtgComAho.Columns["idConfigGastComiSeg"].Visible = false;
            this.dtgComAho.Columns["idConcepto"].Visible = false;
            this.dtgComAho.Columns["lAplicaContable"].Visible = false;
            this.dtgComAho.Columns["lAplicaImpreOpe"].Visible = false;
            this.dtgComAho.Columns["cNombreCorto"].HeaderText = "Concepto Comisión";
            this.dtgComAho.Columns["cNombreCorto"].Width = 160;
            this.dtgComAho.Columns["nValorAplica"].HeaderText = "Monto";
        }
        //==========================================================
        //--Cargar Tipos de Renovaciones
        //==========================================================
        private void CargarRenovaciones()
        {
            cboRenovacion.Enabled = true;
            if (chcRenov.Checked)
            {
                clsCNOperacionDep deposito = new clsCNOperacionDep();
                DataTable dt = deposito.ListaTipRenovacionProd(Convert.ToInt32(cboSubProducto.SelectedValue)); //--deposito.ListaTipoRenovacion()
                if (dt.Rows.Count > 0)
                {
                    this.cboRenovacion.DataSource = dt;
                    this.cboRenovacion.ValueMember = dt.Columns["IdRenovacion"].ToString();
                    this.cboRenovacion.DisplayMember = dt.Columns["cDescripcion"].ToString();
                }
                else
                {
                    MessageBox.Show("No Existe Tipos de Renovaciones, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                cboRenovacion.SelectedIndex = -1;
                cboRenovacion.Enabled = false;
            }         
            
        }
        
        //==========================================================
        //--Cargar Modalidades de Pago
        //==========================================================
        private void CargarPagoIntereses()
        {
            cboPagoInt.Enabled = true;
            if (lEsReqPagInt)
            {
                if (lEsDefTipPagInt)
                {
                    clsCNOperacionDep deposito = new clsCNOperacionDep();
                    DataTable dt = deposito.ListaTipPagoInteresProd(Convert.ToInt32(cboSubProducto.SelectedValue));  //deposito.ListaPagoInteresProd(Convert.ToInt32(cboSubProducto.SelectedValue))
                    if (dt.Rows.Count > 0)
                    {                        
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                        this.cboPagoInt.DataSource = dt;
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
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                        this.cboPagoInt.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No Existe Tipos de pago de Intereses, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                
            }
            else
            {
                cboPagoInt.SelectedIndex = -1;
                cboPagoInt.Enabled = false;
            }
        }

        //==========================================================
        //--Cargar Modalidades de Pago--Apertura
        //==========================================================
        private void CargarModalidadPago()
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(9);
            if (dt.Rows.Count > 0)
            {
                this.cboModPago.DataSource = dt;
                this.cboModPago.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboModPago.DisplayMember = dt.Columns["cDescripcion"].ToString();

                this.cboTipoApe.DataSource = dt;
                this.cboTipoApe.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboTipoApe.DisplayMember = dt.Columns["cDescripcion"].ToString();               
            }
            else
            {
                MessageBox.Show("No Existe Modalidades de Pago, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //==========================================================
        //--Recuperar Tasa para el Producto
        //==========================================================
        private bool recuperarTasa(Int32 nPlazo, Int32 idProducto, Decimal nMonto, Int32 idMoneda, Int32 idAgencia,int idTipPe)
        {
            this.txtTasa.Text = "0.00";
            idTasa = 0;
            clsCNAperturaCta TasaAho = new clsCNAperturaCta();
            DataTable dt = TasaAho.RetornaTasaAhorros(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipPe);
            if (dt.Rows.Count > 0)
            {
                this.txtTasa.Text = dt.Rows[0]["nTasaCompensatoria"].ToString();
                idTasa = Convert.ToInt32(dt.Rows[0]["idTasa"].ToString());
                return true;
            }
            else
            {
                MessageBox.Show("No se encontro la tasa para el subproducto", "Validación Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cNomInterv = "";
                return false;
            }

        }
        //==========================================================
        //--Recuperar Parámetros por Producto
        //==========================================================
        private void CargaParamProducto(int idProd, int idMon, int idOpc)
        {
            btnContinuar.Enabled = true;
            txtMonto.Enabled = false;
            txtMonto.Text = "0.00";
            lEsAfeITF = false;
            lReqCuentaRel = false;
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(idProd, idMon, idOpc);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {                
                txtMonMinApe.Text = dt.Rows[0]["nMonMinApe"].ToString();
                txtMonMinOpe.Text = dt.Rows[0]["nMonMinOpe"].ToString();
                lEsAfeITF=Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                lReqCuentaRel = Convert.ToBoolean(dt.Rows[0]["lIsCtaCteRel"].ToString());
                lEsCtaCTS = Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString());
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Enabled = false;
                btnContinuar.Enabled = false;
                cboSubProducto.SelectedValue = 0;
                return;
            }
            txtMonto.Enabled = true;
            txtMonto.Focus();
            txtMonto.Select();

            if (Convert.ToBoolean(dt.Rows[0]["lIsDepAhoProg"].ToString())) //--Validar Si es Ahorro Programado
            {
                grbAhoPrg.Visible = true;
                nudNroDep.Enabled = true;
                nudNroDep.Focus();
                nudNroDep.Select();
            }
            else
            {
                grbAhoPrg.Visible = false;
                nudNroDep.Enabled = false;
            }

            if (Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"].ToString()))
            {
                txtPlazoAho.Enabled = true;
                txtPlazoAho.Text = dt.Rows[0]["nPlaMaxProd"].ToString(); 
                txtPlazoAho.Focus();
                txtPlazoAho.Select();
            }
            else
            {
                txtPlazoAho.Enabled = false;
                txtPlazoAho.Text = "0";
            }

            if (Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString()))//--Validar Si es CTS
            {
                txtMontoIntang.Enabled = true;
            }
            else
            {
                txtMontoIntang.Enabled = false;
            }

            if (idMon == 1)
            {
                cboMonedaDoc.SelectedValue = 1;
                lblTitulo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMonto.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMonMinOpe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMonMinApe.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMonPago.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMoneda.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontoIntang.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                txtMontoTotal.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                lblTotal.Text = "TOTAL A RECIBIR (S/.):";
            }
            else
            {
                cboMonedaDoc.SelectedValue = 2;
                lblTitulo.BackColor = System.Drawing.Color.LightGreen;
                txtMonto.BackColor = System.Drawing.Color.LightGreen;
                txtMonMinOpe.BackColor = System.Drawing.Color.LightGreen;
                txtMonMinApe.BackColor = System.Drawing.Color.LightGreen;
                txtMonPago.BackColor = System.Drawing.Color.LightGreen;
                txtMoneda.BackColor = System.Drawing.Color.LightGreen;
                txtMontoIntang.BackColor = System.Drawing.Color.LightGreen;
                txtMontoTotal.BackColor = System.Drawing.Color.LightGreen;
                lblTotal.Text = "TOTAL A RECIBIR ($.):";
            }
            lblTitulo.Text = "SOLICITUD DE APERTURA DE CUENTAS DE AHORRO: " + cboSubProducto.Text+" ("+cboMoneda.Text+")";
            
        }

        private bool ValidarDatosIniApe()
        {
            //========================================================================
            //--Validar Datos
            //========================================================================
            if (cboTipoDeposito.SelectedIndex <= 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Tipo de Deposito", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDeposito.Focus();
                return false;
            }

            if (cboSubTipoDeposito.SelectedIndex <= 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Sub-Tipo de Deposito", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSubTipoDeposito.Focus();
                return false;
            }

            if (cboProducto.SelectedIndex <= 0)
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

            if (cboTipoCuenta.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Tipo de Cuenta", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCuenta.Focus();
                return false;
            }

            if (cboTipoPersona.SelectedIndex < 0)
            {
                MessageBox.Show("Primero debe Seleccionar el Tipo de Persona", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPersona.Focus();
                return false;
            }
            if (Convert.ToInt16(cboTipoApe.SelectedValue) == 2)
            {
                if (rbtOtrasCuentas.Checked==false && rbtMismaCta.Checked==false)
                {
                    MessageBox.Show("Debe Seleccionar la Modalidad de la Transferencia...", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbtMismaCta.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(this.txtPlazoAho.Text))
            {
                MessageBox.Show("Debe de ingresar el Plazo del Producto", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToInt32(this.txtPlazoAho.Text) < 0)
            {
                MessageBox.Show("El Plazo Ingresado no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("El monto ingresado no es válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                txtMonto.Select();
                return false;
            }
            if (Convert.ToDecimal (this.txtMonto.Text) < Convert.ToDecimal (this.txtMonMinApe.Text))
            {
                MessageBox.Show("El monto a aperturar, debe ser mayor al monto mínimo de apertura", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                txtMonto.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtMontoIntang.Text))
            {
                txtMontoIntang.Text = "0.00";
            }

            if (Convert.ToDecimal (this.txtMonto.Text) < Convert.ToDecimal (this.txtMontoIntang.Text))
            {
                MessageBox.Show("El Monto a aperturar, NO puede ser menor que el monto intangible", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                txtMonto.SelectAll();
                return false;
            }
            return true;
        }

        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            lEsCliInterno = false;

            if (!ValidarDatosIniApe()) //--Validar Ingreso de Datos
            {
                if (tbcApertura.SelectedIndex != 0)
                {
                    tbcApertura.SelectTab(0);
                }
                return;
            }
            
            //--------------------------------------------------------------------------------
            //--Validar Número de Firmas Requeridas
            //--------------------------------------------------------------------------------
            if (Convert.ToInt32(cboTipoPersona.SelectedValue)==1)  // si es Persona Natural
            {
                switch (Convert.ToInt32(cboTipoCuenta.SelectedValue))
                {
                    case 1:  //--Tipo de Cuenta Individual
                        txtNroFir.Text = "1"; //--Requiere siempre solo 1 firma
                        txtNroFir.Enabled = false;
                        break;
                    case 2: //--Tipo de Cuenta Solidaria
                        txtNroFir.Text = "1"; //--Requiere siempre solo 1 firma
                        txtNroFir.Enabled = true;
                        break;
                    default:
                        txtNroFir.Text = "2";
                        txtNroFir.Enabled = true;
                        break;
                }                            
            }
            else
            {
                txtNroFir.Text = "1";
                txtNroFir.Enabled = true;
            }

            chcOrdPago.Enabled = false;
            chcOrdPago.Checked = false;

            //--=====================================================
            //--Cargar parámetros del Producto y Validar
            //--=====================================================
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(Convert.ToInt32(cboSubProducto.SelectedValue.ToString()), Convert.ToInt32(cboMoneda.SelectedValue.ToString()), 2);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                chcITF.Checked = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                chcInactiva.Checked = Convert.ToBoolean(dt.Rows[0]["lIsInactiva"].ToString());
                txtPlaInac.Text = dt.Rows[0]["nPlaInactiva"].ToString();
                chcRenov.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRenovProd"].ToString());
                chcCert.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRequeCert"].ToString());
                //--Asignación de variables Públicas
                lEsTrabFin=Convert.ToBoolean(dt.Rows[0]["lIsTrabFinan"].ToString());
                lEsReqPagInt=Convert.ToBoolean(dt.Rows[0]["lIsReqPagInt"].ToString());
                lEsDefTipPagInt = Convert.ToBoolean(dt.Rows[0]["lIsDefTipPagInt"].ToString());
                lEsReqEmpleador = Convert.ToBoolean(dt.Rows[0]["lIsReqEmpleador"].ToString());
                lEsAhoProg = Convert.ToBoolean(dt.Rows[0]["lIsDepAhoProg"].ToString());
                lEsCtaCTS = Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString());
                p_nMonMinSalDis = Convert.ToDecimal (dt.Rows[0]["nMonMinSalDis"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dt.Rows[0]["lIsDepMenEdad"].ToString());
                lIsPlazoProd = Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"].ToString());
                lIsRequeCert = Convert.ToBoolean(dt.Rows[0]["lIsRequeCert"].ToString());

                //--Tipo Persona sin Fines de Lucro, no Tiene ITF
                if (Convert.ToInt16(cboTipoPersona.SelectedValue)==3)
	            {
		            chcITF.Checked=false;
                    lEsAfeITF=false;
	            }
                
                //--Para Transferencias de las clientes del cliente. no debe afectar el ITF
                //if (Convert.ToInt16(cboTipoApe.SelectedValue)==2 && rbtMismaCta.Checked)  
                //{
                //    chcITF.Checked = false;
                //    lEsAfeITF = false;
                //}
                
                //--Validar si es Cta para Orden de Pago                
                if (Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))
                {
                    chcOrdPago.Enabled = true;
                }

                //--===============================================================
                //--Validar Plazos
                //--===============================================================
                if (!lEsAhoProg)
                {
                    if (Convert.ToInt16(txtPlazoAho.Text) < Convert.ToInt16(dt.Rows[0]["nPlaMinProd"].ToString()))
                    {
                        MessageBox.Show("El plazo es menor al mínimo permitido: Plazo mínimo: " + dt.Rows[0]["nPlaMinProd"].ToString() + " días", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPlazoAho.Focus();
                        txtPlazoAho.Select();

                        if (tbcApertura.SelectedIndex != 0)
                        {
                            tbcApertura.SelectTab(0);
                        }
                        return;
                    }

                    if (Convert.ToInt16(txtPlazoAho.Text) > Convert.ToInt16(dt.Rows[0]["nPlaMaxProd"].ToString()))
                    {
                        MessageBox.Show("El plazo es mayor al máximo permitido: Plazo máximo: " + dt.Rows[0]["nPlaMaxProd"].ToString() + " días", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPlazoAho.Focus();
                        txtPlazoAho.Select();

                        if (tbcApertura.SelectedIndex != 0)
                        {
                            tbcApertura.SelectTab(0);
                        }
                        return;
                    }
                }
                if (lIsDepMenEdad)
                {
                        txtNroFir.Text = "2";
                        txtNroFir.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                if (tbcApertura.SelectedIndex != 0)
                {
                    tbcApertura.SelectTab(0);
                }
                return;
            }

            //===============================================================
            //--Validar De aCuerdo a los parámetros de Retorno
            //===============================================================
            if ( Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"].ToString()))  //--El producto requiere Plazo
            {
                if (string.IsNullOrEmpty(this.txtPlazoAho.Text))
                {
                    MessageBox.Show("Debe de ingresar el PLAZO DEL PRODUCTO", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoAho.Focus();
                    txtPlazoAho.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }

                if (Convert.ToInt32(this.txtPlazoAho.Text) <= 0)
                {
                    MessageBox.Show("El plazo ingresado no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPlazoAho.Focus();
                    txtPlazoAho.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }
            }

            if (Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString()))  //--Validar si el Producto es CTS
            {
                if (string.IsNullOrEmpty(this.txtMontoIntang.Text))
                {
                    MessageBox.Show("Debe de ingresar el Monto Intangible del CTS", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoIntang.Focus();
                    txtMontoIntang.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }

                if (Convert.ToDecimal (this.txtMontoIntang.Text) < 0)
                {
                    MessageBox.Show("El Monto Intangible del CTS Ingresado NO es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoIntang.Focus();
                    txtMontoIntang.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }
                if (Convert.ToDecimal(this.txtMontoIntang.Text) == 0)
                {
                    MessageBox.Show("El Monto Intangible del CTS es Cero, Por favor verificar si es Correcto", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoIntang.Focus();
                    txtMontoIntang.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);

                    }
                }
                txtMonIntCTS.Text = txtMontoIntang.Text;
            }

            if (Convert.ToBoolean(dt.Rows[0]["lIsDepAhoProg"].ToString()))  //--Validar si el Producto es Ahorro Programado
            {
                if (string.IsNullOrEmpty(this.nudNroDep.Value.ToString()))
                {
                    MessageBox.Show("Debe Ingresar el Número de Depositos del Ahorro", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nudNroDep.Focus();
                    nudNroDep.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }

                if (this.nudNroDep.Value <= 0)
                {
                    MessageBox.Show("El Número de Depositos no es Válido, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nudNroDep.Focus();
                    nudNroDep.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }
                if (dtpFecAhoProg.Value<clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("La Fecha del Deposito del Ahorro, No puede Ser menor a la Fecha del Sistema, VERIFICAR", "Validación Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFecAhoProg.Focus();
                    dtpFecAhoProg.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }
                if (this.nudNroDep.Value * 30 <= Convert.ToInt16(dt.Rows[0]["nPlaMinProd"].ToString()))
                {
                    MessageBox.Show("El Plazo es Menor al Mínimo Permitido: PLazo Mínimo: " + dt.Rows[0]["nPlaMinProd"].ToString(), "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nudNroDep.Focus();
                    nudNroDep.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }
                if (this.nudNroDep.Value * 30 >= Convert.ToInt16(dt.Rows[0]["nPlaMaxProd"].ToString()))
                {
                    MessageBox.Show("El Plazo es Mayor al Máximo Permitido: PLazo Máximo: " + dt.Rows[0]["nPlaMaxProd"].ToString(), "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nudNroDep.Focus();
                    nudNroDep.Select();

                    if (tbcApertura.SelectedIndex != 0)
                    {
                        tbcApertura.SelectTab(0);
                    }
                    return;
                }

                PpgAhoProgramado(Convert.ToDecimal (txtMontTotal.Text), Convert.ToInt32(this.nudNroDep.Value)+1, 1);
            }
            else
            {
                PpgAhoProgramado(0.00m, 1, 2);
            }

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglasIni())
            {
                if (tbcApertura.SelectedIndex != 0)
                {
                    tbcApertura.SelectTab(0);
                }
                return;
            }

            //--Validar si Es requerido Empleador de  Acuerdo al Producto
            conBusCli.txtCodInst.Text = "";
            conBusCli.txtCodAge.Text = "";
            conBusCli.txtCodCli.Text = "";            
            conBusCli.txtNroDoc.Text = "";
            conBusCli.txtNombre.Text = "";
            conBusCli.txtDireccion.Text="";
            conBusCli.txtNombre.Enabled = false;
            conBusCli.txtDireccion.Enabled = false;
            txtDescriCta.Clear();
            if (dtgIntervinientes.Rows.Count>0)
            {
                dtInt.Rows.Clear();
            }

            if (lEsReqEmpleador)
            {
                conBusCli.btnBusCliente.Enabled = true;
                conBusCli.txtCodCli.Enabled = true;
            }
            else
            {
                conBusCli.btnBusCliente.Enabled = false;
                conBusCli.txtCodCli.Enabled = false;
            }
            
            //========================================================================
            //--Asignar Parametros de la Cuenta
            //========================================================================
            this.txtProducto.Text = ((DataRowView)cboTipoDeposito.SelectedItem)["cProducto"].ToString() + @"/" +
                             ((DataRowView)cboSubTipoDeposito.SelectedItem)["cProducto"].ToString() + @"/" +
                             ((DataRowView)cboProducto.SelectedItem)["cProducto"].ToString() + @"/" +
                             ((DataRowView)cboSubProducto.SelectedItem)["cProducto"].ToString();

            txtProdCli.Text = this.txtProducto.Text.Trim();
            txtTipCuenta.Text = cboTipoCuenta.Text;
            txtTipPersona.Text = cboTipoPersona.Text;
            txtMoneda.Text = cboMoneda.Text;
            txtMonPago.Text = cboMoneda.Text;
            txtMonApe.Text = this.txtMontTotal.Text;
            txtRedondeoApe.Text = txtRedondeo.Text;
            txtMonApePago.Text = this.txtMonto.Text;
            txtPlaProd.Text = txtPlazoAho.Text;
            
            //====================================
            //Saltar al Siguiente Paso
            //====================================
            conBusCli.txtNroDoc.Visible = true;
            btnEliLista.Enabled = false;

            tabTasa.Enter -= tabTasa_Enter;
            tbcApertura.SelectedIndex = 1;
            tabTasa.Enter += tabTasa_Enter;
            
            btnAgregar.Focus();
        }

        private void btnContinuar2_Click(object sender, EventArgs e)
        {
            tbcApertura.SelectedIndex = 2;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            tbcApertura.SelectedIndex = 0;
        }

        private void cboTipoDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoDeposito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboTipoDeposito.SelectedValue);
                cboSubTipoDeposito.CargarProducto(CodPro);
                cboSubTipoDeposito.SelectedIndex = 1;
            }
            else
            {
                cboSubTipoDeposito.CargarProducto(-1);
            }
        }

        private void cboSubTipoDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoDeposito.SelectedIndex > 0)
            {
                if (cboSubTipoDeposito.Items.Count > 1)
                {
                    CodPro = Convert.ToInt32(cboSubTipoDeposito.SelectedValue);
                    cboProducto.CargarProducto(CodPro);
                    cboProducto.SelectedIndex = 1;
                }
            }
            else
            {
                cboProducto.CargarProducto(-1);
            }
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
                }
               
            }
            else
            {
                cboSubProducto.CargarProducto(-1);
            }
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCalcular.Enabled = false;
            txtMontoIntang.Text="0.00";
            txtPlazoAho.Text = "0";
            txtMonto.Text="0.00";
            txtComision.Text = "0.00";
            txtImpuesto.Text="0.00";
            txtMontoTotal.Text="0.00";
            txtMontTotal.Text = "0.00";
            txtMontEnt.Text="0.00";
            txtITF.Text = "0.00";
            txtComisiones.Text = "0.00";
            txtRedondeo.Text = "0.00";
            nudNroDep.Value = 0;
            if (this.cboSubProducto.SelectedIndex > 0)
            {
                int CodSubPro = Convert.ToInt32(this.cboSubProducto.SelectedValue);
                CargaParamProducto(CodSubPro, Convert.ToInt32(cboMoneda.SelectedValue), 1);              
                CargarTipPerProd(CodSubPro);
                CargarTipCtaProd(CodSubPro);
                conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));
                if (lEsCtaCTS)
                {
                    btnCalcular.Enabled = true;
                   
                }
                AsignarVariableParametrosProducto();
                CargarRenovaciones();
                CargarPagoIntereses();
            }
            else
            {
                conSolesDolar.iMagenMoneda(0);
                cboSubProducto.SelectedIndex = 0;
                cboTipoPersona.SelectedIndex = 0;
            }
        }

        //--Cargar Tipo de Personas por Producto
        private void CargarTipPerProd(int idProd)
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaTipPersonaProd(idProd);
            if (dt.Rows.Count > 0)
            {
                cboTipoPersona.DataSource = dt;
                cboTipoPersona.ValueMember = dt.Columns["idTipoPersona"].ToString();
                cboTipoPersona.DisplayMember = dt.Columns["cTipoPersona"].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            //--Validar Ingreso de datos Necesarios del Empleador
            if (lEsReqEmpleador)
            {
                if (!ValidarDatEmpleador())
                {
                    return;
                }
            }
            //txtNroRuc.Enabled = false;

            if (string.IsNullOrEmpty(this.txtNroFir.Text))
            {
                MessageBox.Show("Debe de Ingresar el Nro de FIRMAS", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroFir.Focus();
                return;
            }

            if (Convert.ToInt32(this.txtNroFir.Text)<=0)
            {
                MessageBox.Show("El Número de Firmas, No Puede ser Menor a Cero(0) ni Cero", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               txtNroFir.Focus();
                return; 
            }
            //=========================================================
            //--En Juridicas No se puede agregar Intervinientes
            //==========================================================
            if (Convert.ToInt32(cboTipoPersona.SelectedValue) > 1) //--Para personas Jurídicas
            {
                if (dtInt.Rows.Count > 0)
                {
                    MessageBox.Show("No puede agregar intervinientes para jurídicas, Verificar en Clientes", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        
            //==========================================
            //--Bucar Clientes
            //==========================================
            FrmBusCli busca = new FrmBusCli();
            busca.ShowDialog();

            if (string.IsNullOrEmpty(busca.pcCodCli))
            {
                return;
            }

            if (busca.pIndicaDatoBasico == true)
            {
                MessageBox.Show("Debe registrar datos completos del cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--===============================================================
            //--Validar que el Mismo Cliente no Puede Realizar Aperturas
            //--===============================================================
            if (Convert.ToInt32(busca.pcCodCli)==clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El mismo usuario no puede aperturar una cuenta a su nombre", "Validación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //=================================================
            //--Validar Tipo de Cliente: Natural, Jurídica
            //=================================================
            if (Convert.ToInt32(busca.pnTipoPersona) != Convert.ToInt32(cboTipoPersona.SelectedValue))
            {
                MessageBox.Show("El tipo de persona a agregar debe ser: " + cboTipoPersona.Text, "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            ////===============================================================
            ////--Validar si el Empleador es la Misma Financiera u Otro
            ////===============================================================
            //if (lEsReqEmpleador)
            //{
            //    //--Si es el RUC de la Fianciera, validar que sea colaborador Activo
            //    if (conBusCli.txtNroDoc.Text.Trim()==pcRucFinanciera)
            //    {
            //        if (!validarColaborador(Convert.ToInt32(busca.pcCodCli)))
            //        {
            //            MessageBox.Show("El cliente no es colaborador o no se encuentra activo", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            return;
            //        }
            //    }   
            //}

            //==============================================
            //--Validar Si ya Registro el Cliente
            //==============================================
            foreach (DataRow item in dtInt.Rows)
            {
                if (item["codigo"].ToString() == busca.pcCodCli)
                {
                    MessageBox.Show("Ya agrego al cliente seleccionado", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            x_idCliRegla = Convert.ToInt32(busca.pcCodCli);
            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglasCli())
            {
                return;
            }

            //==============================================
            //--Agregar Datos el Grid
            //==============================================
            DataRow dr = dtInt.NewRow();
            dr["codigo"] = Convert.ToInt32(busca.pcCodCli);
            dr["nombres"] = busca.pcNomCli;
            dr["tipodoc"] = busca.pcTipoDocumento;
            dr["documento"] = busca.pcNroDoc;
            dr["idTipoInterv"] = "6";
            dr["idCuenta"] = "0";
            dr["direccion"] = busca.pcDireccion;
            dr["lEsAfeItf"] = false;
            dr["idTipoDocumento"] = busca.pnTipoDocumento;
            dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = false;
            dtgIntervinientes.Columns["cmb"].ReadOnly = false;
            if (chcITF.Checked)
            {
                if (Convert.ToInt32(cboTipoCuenta.SelectedValue) == 1)
                {
                    if (dtInt.Rows.Count==0)
                    {
                        dr["lEsAfeItf"] = true;    
                    }                    
                    //dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = true;
                }  
            }
            else
            {
                dr["lEsAfeItf"] = false;
                dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = true;
            }
              
            dtInt.Rows.Add(dr);
            int nReg = dtInt.Rows.Count-1;
            dtgIntervinientes.Rows[nReg].Cells["cmb"].Value = 6;      
            //================================================================
            //--Agregar Registro de Clientes, si es Jurídica
            //================================================================
            if (Convert.ToInt32(busca.pnTipoPersona) > 1)
            {
                //--Buscar Empleador si ya Fue Registrado
                clsCNAperturaCta dtRegApe = new clsCNAperturaCta();
                DataTable tbRegApe = dtRegApe.RetornaRepreJuridica(Convert.ToInt32(busca.pcCodCli));
                if (tbRegApe.Rows.Count>0)
                {
                    for (int i = 0; i < tbRegApe.Rows.Count; i++)
                    {
                        dr=dtInt.NewRow();
                        dr["codigo"] = Convert.ToInt32(tbRegApe.Rows[i]["idCli"].ToString());
                        dr["nombres"] = tbRegApe.Rows[i]["cNombre"].ToString();
                        dr["tipodoc"] = tbRegApe.Rows[i]["cTipoDoc"].ToString(); 
                        dr["documento"] = tbRegApe.Rows[i]["cDocumentoID"].ToString();
                        dr["idTipoInterv"] = "7"; 
                        dr["idCuenta"] = "0";
                        dr["direccion"] = tbRegApe.Rows[i]["cDireccion"].ToString();
                        dr["lEsAfeItf"] = false;
                        dr["idTipoDocumento"] = Convert.ToInt32(tbRegApe.Rows[i]["idTipoDocumento"].ToString());
                        dtInt.Rows.Add(dr);
                        nReg++;
                        dtgIntervinientes.Rows[nReg].Cells["cmb"].Value = 7; 
                    }
                    dtgIntervinientes.Columns["cmb"].ReadOnly = true;
                    dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("La Empresa no Tiene representantes: VERIFICAR", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (dtInt.Rows.Count>1)
            {
                btnEliLista.Enabled = true;
            }

        }

        private bool validarColaborador(int idCliPer)
        {
            clsCNBuscaPersonal lisPer = new clsCNBuscaPersonal();
            DataTable dtDatPer = lisPer.BuscaCliente(idCliPer);
            if (dtDatPer.Rows.Count > 0)
            {
                if (dtDatPer.Rows[0]["idEstado"].ToString() == "1")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private void cargarcolumnas()
        {
            //Estructura de Intervinientes:
            if (dtgIntervinientes.Columns.Count > 0)
            {
                dtgIntervinientes.Columns.Remove("codigo");
                dtgIntervinientes.Columns.Remove("nombres");
                dtgIntervinientes.Columns.Remove("tipodoc");
                dtgIntervinientes.Columns.Remove("documento");
                dtgIntervinientes.Columns.Remove("cmb");
                dtgIntervinientes.Columns.Remove("idTipoInterv");
                dtgIntervinientes.Columns.Remove("direccion");
                dtgIntervinientes.Columns.Remove("lEsAfeItf");
            }

            dtInt.Columns.Add("codigo", typeof(string));
            dtInt.Columns.Add("nombres", typeof(string));
            dtInt.Columns.Add("tipodoc", typeof(string));
            dtInt.Columns.Add("documento", typeof(string));
            dtInt.Columns.Add("idTipoInterv", typeof(string));
            dtInt.Columns.Add("idCuenta", typeof(string));
            dtInt.Columns.Add("direccion", typeof(string));
            dtInt.Columns.Add("lEsAfeItf", typeof(bool));
            dtInt.Columns.Add("idTipoDocumento", typeof(int));
            this.dtgIntervinientes.DataSource = dtInt.DefaultView;

            clsCNInterviniente TipoInterv = new clsCNInterviniente();
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Tipo de Interviniente";
            cmb.Name = "cmb";
            cmb.FillWeight = 50;
            cmb.MaxDropDownItems = 4;
            cmb.DataSource = TipoInterv.CNListaTipoIntervDep();
            cmb.DisplayMember = "CTIPOINTERVENCION";
            cmb.ValueMember = "idtipointerv";

            dtgIntervinientes.Columns.Add(cmb);
            dtgIntervinientes.Columns["codigo"].HeaderText = "Código";
            dtgIntervinientes.Columns["nombres"].HeaderText = "Nombres y Apellidos";
            dtgIntervinientes.Columns["tipodoc"].HeaderText = "Tipo Documento";
            dtgIntervinientes.Columns["documento"].HeaderText = "Nro. de Documento";
            dtgIntervinientes.Columns["lEsAfeItf"].HeaderText = "ITF";
            dtgIntervinientes.Columns["idTipoInterv"].Visible = false;
            dtgIntervinientes.Columns["idCuenta"].Visible = false;
            dtgIntervinientes.Columns["direccion"].Visible = false;
            dtgIntervinientes.Columns["idTipoDocumento"].Visible = false;

            dtgIntervinientes.Columns["cmb"].Width = 110;
            dtgIntervinientes.Columns["codigo"].Width = 70;
            dtgIntervinientes.Columns["nombres"].Width = 270;
            dtgIntervinientes.Columns["tipodoc"].Width = 70;
            dtgIntervinientes.Columns["documento"].Width = 100;
            dtgIntervinientes.Columns["lEsAfeItf"].Width = 40;

            dtgIntervinientes.Columns["cmb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["nombres"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["tipodoc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["documento"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["lEsAfeItf"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgIntervinientes.Columns["cmb"].ReadOnly = false;
            dtgIntervinientes.Columns["codigo"].ReadOnly = true;
            dtgIntervinientes.Columns["nombres"].ReadOnly = true;
            dtgIntervinientes.Columns["tipodoc"].ReadOnly = true;
            dtgIntervinientes.Columns["documento"].ReadOnly = true;
            dtgIntervinientes.Columns["direccion"].ReadOnly = true;
            dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = false;
            //Estructura de Datos Cuenta:
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                this.dtgIntervinientes.Rows.Remove(dtgIntervinientes.CurrentRow);
                this.dtgIntervinientes.Refresh();
            }
            else
            {
                MessageBox.Show("No existe datos a eliminar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAgregar.Focus();
                return;
            }
        }

        private void dtgIntervinientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgIntervinientes.CurrentRow.Index;
            int nFilas = dtgIntervinientes.Rows.Count;

            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value = dtgIntervinientes.Rows[i].Cells["cmb"].Value;
            }
        }

        private void btnRegresar1_Click(object sender, EventArgs e)
        {
            //====================================
            //Saltar al Siguiente y/o Anterior
            //====================================
            int idProd = Convert.ToInt32(this.cboSubProducto.SelectedValue),
                idMon = Convert.ToInt16(this.cboMoneda.SelectedValue);
            lEsAfeITF = false;
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(idProd, idMon, 1);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                lEsAfeITF = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                
            }

            tbcApertura.SelectedIndex = 0;
            cNomInterv = "";
        }

        //--Validar Datos del empleador
        private bool ValidarDatEmpleador()
        {

            if (string.IsNullOrEmpty(this.conBusCli.txtNombre.Text.ToString().Trim()))
            {
                MessageBox.Show("Realice la búsqueda de su empleador", "Validar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(this.conBusCli.txtNroDoc.Text))
            {
                MessageBox.Show("Debe de ingresar el Nro de RUC del empleador", "Validar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            if (conBusCli.txtNroDoc.Text.Trim().Length != 11)
            {
                MessageBox.Show("El RUC del Empleador debe ser de 11 Dígitos", "Validar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.conBusCli.txtNombre.Text))
            {
                MessageBox.Show("Debe de ingresar la razón social del Empleador", "Validar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.conBusCli.txtDireccion.Text))
            {
                MessageBox.Show("Debe de ingresar la direción del empleador", "Validar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarDatosCli()
        {
            if (string.IsNullOrEmpty(this.txtNroFir.Text))
            {
                MessageBox.Show("Debe de Ingresar el Nro de Firmas", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroFir.Focus();
                txtNroFir.Select();
                return false;
            }
            if (Convert.ToInt32(txtNroFir.Text) <= 0)
            {
                MessageBox.Show("El Número de firmas registrados no es válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cNomInterv = "";
                txtNroFir.Focus();
                txtNroFir.Select();
                return false;
            }            
            if (dtgIntervinientes.Rows.Count<=0)
            {
                MessageBox.Show("Debe registrar por los menos un interviniente titular", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(txtNroFir.Text) > dtgIntervinientes.Rows.Count)
            {
                MessageBox.Show("El Número de firmas no puede ser mayor al número de intervinientes", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cNomInterv = "";
                txtNroFir.Focus();
                txtNroFir.Select();
                return false;
            }
            return true;
        }

        //=============================================
        //--Validar Datos del Interviniente
        //=============================================
        private bool validarInterv()
        {
            int nSelInt = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {

                if (dtgIntervinientes.Rows[i].Cells["cmb"].Value == null || dtgIntervinientes.Rows[i].Cells["cmb"].Value.ToString() == "0")
                {
                    nSelInt++;
                }
                cNomInterv = cNomInterv + dtInt.Rows[i]["nombres"].ToString() + "\n";
            }

            if (nSelInt > 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de interviniente", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cNomInterv = "";
                   
                return false;
            }
            else
            {
                int c = 0,nNumTit=0;
                for (int i = 0; i < this.dtInt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dtgIntervinientes.Rows[c].Cells["cmb"].Value)==6)
                    {
                        nidCliTit = Convert.ToInt32(this.dtgIntervinientes.Rows[c].Cells["codigo"].Value);
                        nNumTit++;
                        break;
                    }
                    c++;
                    
                }
                if (nNumTit <= 0)
                {
                    MessageBox.Show("Por lo Menos, uno de los intervinientes debe ser TITULAR", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cNomInterv = "";
                    return false;
                }
            }

            return true;
        }

        private void btnContinuar1_Click_1(object sender, EventArgs e)
        {
            cNomInterv = "";
            //--Validar Datos del Cliente
            if (!ValidarDatosCli())
            {
                if (tbcApertura.SelectedIndex != 1)
                {
                    tbcApertura.SelectTab(1);
                }
                return;
            }

            //--Validar Datos del Interviniente
            if (!validarInterv())
            {
                if (tbcApertura.SelectedIndex != 1)
                {
                    tbcApertura.SelectTab(1);
                }
                return;
            }

            //--Validar Ingreso de datos Necesarios del Empleador
            if (lEsReqEmpleador)
            {                                
                if (!ValidarDatEmpleador())
                {
                    cNomInterv = "";

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }
            }

            if (lIsDepMenEdad)  //Si la apertura es Cuenta Futuro, el ITF afecta al Apoderado
            {
                int nApoMenEdad = 0;
                int nTitMayEdad = 0;

                for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                {
                    if (Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 8 && (dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() == "DNI Menor" || dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() == "Partida Nacimiento"))
                    {
                        nApoMenEdad++;
                    }

                    if (Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 1 && (dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() != "DNI Menor" && dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() != "Partida Nacimiento"))
                    {
                        nTitMayEdad++;
                    }
                }

                if (nApoMenEdad > 0)
                {
                    MessageBox.Show("El apoderado debe ser una persona mayor de Edad, por favor revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cNomInterv = "";

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }

                if (nTitMayEdad > 0)
                {
                    MessageBox.Show("El titular debe ser un menor de edad, por favor revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cNomInterv = "";

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }
            }

            //--Validar que uno de los clientes este seleccionado para reporte de ITF
            if (chcITF.Checked)
            {
                int nNroAfeItf = 0;
                for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["lEsAfeItf"].Value))
                    {
                        nNroAfeItf++;
                    }
                }
                if (nNroAfeItf == 0)
                {
                    MessageBox.Show("Debe seleccionar por lo menos un cliente para reporte de ITF", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cNomInterv = "";

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }
                if (nNroAfeItf > 1)
                {
                    MessageBox.Show("El ITF no se puede aplicar a más de un cliente (Solo se de aplicar a un cliente)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cNomInterv = "";

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }
                
                //--Validar ITF
                nNroAfeItf = 0;

                if (lIsDepMenEdad)  //Si la apertura es Cuenta Futuro, el ITF afecta al Apoderado
                {
                    for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                    {
                      if (dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() != "DNI Menor" && dtgIntervinientes.Rows[i].Cells["tipodoc"].Value.ToString() != "Partida Nacimiento")
                        {
                            if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["lEsAfeItf"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 8)
                            {
                                nNroAfeItf++;
                            }
                        }
                    }

                    if (nNroAfeItf == 0)
                    {
                        MessageBox.Show("El ITF debe afectar al apoderado, por favor revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cNomInterv = "";

                        if (tbcApertura.SelectedIndex != 1)
                        {
                            tbcApertura.SelectTab(1);
                        }
                        return;
                    }
                }
                else //--El ITF solo debe afectar a los Titulares.
                {
                    for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["lEsAfeItf"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 6)
                        {
                            nNroAfeItf++;
                        }
                    }
                    if (nNroAfeItf == 0)
                    {
                        MessageBox.Show("El ITF se debe afectar al titular", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cNomInterv = "";

                        if (tbcApertura.SelectedIndex != 1)
                        {
                            tbcApertura.SelectTab(1);
                        }
                        return;
                    }    
                }
            }
                        
            //--==========================================================
            //--Validar por Tipo Persona y tipo de Cuentas
            //--==========================================================                      
            if (Convert.ToInt16(cboTipoPersona.SelectedValue)==1)  //Personas Naturales
            {
                switch (Convert.ToInt32(cboTipoCuenta.SelectedValue))
                {
                    case 1: //--Cuenta Individual
                        if (lIsDepMenEdad == true)
                        {
                            if (Convert.ToInt32(txtNroFir.Text) != 2)
                            {
                                MessageBox.Show("Para el tipo de cuenta: " + cboTipoCuenta.Text + " El número de firmas debe ser DOS(2)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cNomInterv = "";

                                if (tbcApertura.SelectedIndex != 1)
                                {
                                    tbcApertura.SelectTab(1);
                                }
                                return;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(txtNroFir.Text) != 1)
                            {
                                MessageBox.Show("Para el tipo de cuenta: " + cboTipoCuenta.Text + " El número de firmas debe ser UNO(1)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cNomInterv = "";

                                if (tbcApertura.SelectedIndex != 1)
                                {
                                    tbcApertura.SelectTab(1);
                                }
                                return;
                            }
                        }
                        break;
                    case 2: //--Cuenta Solidaria
                        //if (Convert.ToInt32(txtNroFir.Text) != 1)
                        //{
                        //    MessageBox.Show("Para el Tipo de Cuenta: " + cboTipoCuenta.Text + " El Número de Firmas debe ser UNO(1)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    cNomInterv = "";
                        //    return;
                        //}
                        if (dtgIntervinientes.Rows.Count <= 1)
                        {
                            MessageBox.Show("PARA CUENTAS SOLIDARIAS, El Número de intervinientes debe ser mayor a 1", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cNomInterv = "";

                            if (tbcApertura.SelectedIndex != 1)
                            {
                                tbcApertura.SelectTab(1);
                            }
                            return;
                        }
                        if (Convert.ToInt32(txtNroFir.Text) < 1)
                        {
                            MessageBox.Show("PARA CUENTAS SOLIDARIAS, El número de firmas debe ser mayor o igual a 1", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNroFir.Focus();
                            cNomInterv = "";
                            txtNroFir.Select();

                            if (tbcApertura.SelectedIndex != 1)
                            {
                                tbcApertura.SelectTab(1);
                            }
                            return;
                        }
                        break;
                    case 3: //--Cuenta Mancomunada                        
                        if (dtgIntervinientes.Rows.Count <=1)
                        {
                            MessageBox.Show("PARA CUENTAS MANCOMUNADAS, El número de intervinientes debe ser mayor a 1", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNroFir.Focus();
                            cNomInterv = "";
                            txtNroFir.Select();

                            if (tbcApertura.SelectedIndex != 1)
                            {
                                tbcApertura.SelectTab(1);
                            }
                            return;
                        }
                        if (Convert.ToInt32(txtNroFir.Text) <= 1)
                        {
                            MessageBox.Show("PARA CUENTAS MANCOMUNADAS, El Número de firmas debe ser mayor o igual a 1", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNroFir.Focus();
                            cNomInterv = "";
                            txtNroFir.Select();

                            if (tbcApertura.SelectedIndex != 1)
                            {
                                tbcApertura.SelectTab(1);
                            }
                            return;
                        }
                        break;
                }                
            }
            else  //--Validar para Personas Jurídicas
            {
                if (dtgIntervinientes.Rows.Count==1)
                {
                    MessageBox.Show("La JURIDICA, debe tener como mínimo un Titular y un Representante", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cNomInterv = "";
                    txtNroFir.Focus();
                    txtNroFir.Select();

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;   
                }
                if (Convert.ToInt32(txtNroFir.Text) > dtgIntervinientes.Rows.Count-1)
                {
                    MessageBox.Show("El número de firmas no es válido, no incluir la JURIDICA", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNroFir.Focus();
                    cNomInterv = "";
                    txtNroFir.Select();

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                } 
            }

            //-===============================================================
            //--Validar Reglas
            //-===============================================================
            if (!ValidarReglas())
            {
                if (tbcApertura.SelectedIndex != 1)
                {
                    tbcApertura.SelectTab(1);
                }               
                return;
            }

            //--Cargar Tasa
            int nPlazo = 0;
            nPlazo = Convert.ToInt32(txtPlazoAho.Text.ToString());

            if (lEsAhoProg)
            {
                nPlazo = Convert.ToInt32(nudNroDep.Value) * 30;
            }
            idTasa = 0;
            if (!recuperarTasa(nPlazo, Convert.ToInt32(this.cboSubProducto.SelectedValue), Convert.ToDecimal(this.txtMontTotal.Text),
                                Convert.ToInt32(this.cboMoneda.SelectedValue), clsVarGlobal.nIdAgencia,Convert.ToInt32(cboTipoPersona.SelectedValue)))
            {
                if (tbcApertura.SelectedIndex != 1)
                {
                    tbcApertura.SelectTab(1);
                }
                return;
            }

            txtTasaEfectiva.Text = txtTasa.Text;
            txtTrea.Text = txtTasa.Text;
            //Decimal TasaNominal = Convert.ToDecimal(Math.Pow(Convert.ToDouble (Convert.ToDecimal (txtTasa.Text) / 100) + 1, Convert.ToDouble (1) / 12) - 1) * 1200;
            //Decimal TasaRedondeada = Math.Round(TasaNominal, 2, MidpointRounding.AwayFromZero);
            //txtTrea.Text = Convert.ToString(TasaRedondeada);
                       

            //===================================================================
            //--Para Operaciones con Transferencia
            //===================================================================
            conBusCtaAhoTransf.LimpiarControles();
            if (Convert.ToInt16(cboTipoApe.SelectedValue) == 2)
            {
                conBusCtaAhoTransf.idcli = Convert.ToInt32(dtgIntervinientes.Rows[0].Cells["codigo"].Value);
            }
            conBusCtaAhoTransf.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            conBusCtaAhoTransf.pnIdMon = Convert.ToInt32(cboMoneda.SelectedValue);
            conBusCtaAhoTransf.x_nMontoOpe = Convert.ToDecimal (txtMonto.Text);
            conBusCtaAhoTransf.nTipOpe = 1; //--Cuentas para Transferencia
                        
            //--Confirmar el Nro de Firmas
            if (Convert.ToInt16(cboTipoCuenta.SelectedValue) == 2 || Convert.ToInt16(cboTipoCuenta.SelectedValue) == 3)
            {
                var Msg = MessageBox.Show("Esta seguro del número de firmas?...", "Inicio de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg == DialogResult.No)
                {
                    txtNroFir.Focus();
                    txtNroFir.SelectAll();

                    if (tbcApertura.SelectedIndex != 1)
                    {
                        tbcApertura.SelectTab(1);
                    }
                    return;
                }
            }
            
            //====================================
            //Saltar al Siguiente y/o Anterior
            //====================================
            txtCtaVin.Clear();
            txtNroCuenta.Clear();
            txtEstado.Clear();
            txtProdCtaVin.Clear();
            btnContinuar2.Enabled = true;

            tabPage3.Enter -= tabPage3_Enter;
            tbcApertura.SelectedIndex = 2;
            tabPage3.Enter += tabPage3_Enter;

            this.dtgComAho.DataSource = dtComision;
            FormatoGrid();
            cboModPago.Enabled = false;
        }

        private void btnRegresar2_Click(object sender, EventArgs e)
        {
            //====================================
            //Saltar al Siguiente y/o Anterior
            //====================================
            tabTasa.Enter -= tabTasa_Enter;
            tbcApertura.SelectedIndex = 1;
            tabTasa.Enter += tabTasa_Enter;

            cNomInterv = "";
        }

        private void btnContinuar2_Click_1(object sender, EventArgs e)
        {
            //====================================================
            //---Validar tipos de renovacion y pago de interés
            //====================================================
            if (lIsRequeCert)
            {
                if (cboRenovacion.SelectedIndex == -1 || cboPagoInt.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione los datos del tipo de pagos de interés y/o del tipo de renovación","Validar datos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (cboPagoInt.SelectedIndex > 0)
            {
                if (Convert.ToInt16(cboPagoInt.SelectedValue) == 3)
                {
                        if ((int)cboRenovacion.SelectedValue == 1)
                        {
                            MessageBox.Show("No puede existir pagos de interés mensual si es que se renovará capital e interés", "Validación de registro de solicitud de apertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboRenovacion.SelectedValue = 2;
                        }
                }

            }
            //====================================================
            //---Validar Datos Ingresados
            //====================================================
            this.txtRedondeoInt.Text = "0.00";
            int idProducto = Convert.ToInt32(this.cboSubProducto.SelectedValue);
            int xTipPagIntAde = Convert.ToInt32(this.cboPagoInt.SelectedValue);
            
            //================================================================================
            //--Solo para Pagos Mensuales de sus Intereses de Plazos Fijos
            //================================================================================
            idCuentaRel = 0;
                       
            int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
            switch (nCodModPago)
            {
                case 1: //--Pago En Efectivo
                    break;
                case 2: //--Pago con Transferencia
                    if (string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text))
                    {
                        MessageBox.Show("Debe vincular con la cuenta del cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (Convert.ToInt32(conBusCtaAhoTransf.txtCodCli.Text)==Convert.ToInt32(clsVarGlobal.User.idCli))
                    {
                        MessageBox.Show("El mismo usuario, no puede realizar transferencias hacia sus Cuentas", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    break;
                case 3: //--Pago con Cheque
                    if (cboTipoEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el tipo de entidad financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboTipoEnt.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (cboEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la entidad financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEnt.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe registrar el número de cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe registrar el número del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe registrar la serie del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (dtpFecDoc.Value>clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de emisión del documento no puede ser posterior a la fecha del sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    TimeSpan sDifFec = clsVarGlobal.dFecSystem - dtpFecDoc.Value;
                    if (sDifFec.Days>clsVarApl.dicVarGen["nDiasVigenciaCheque"])
                    {
                        MessageBox.Show("El Documento, ya se encuentra vencido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (clsVarApl.dicVarGen["nDiasVigenciaCheque"]-sDifFec.Days<clsVarApl.dicVarGen["nDiasVcmtoCheque"])
                    {
                        MessageBox.Show("El número de días por vencer no debe ser menor a: " + Convert.ToString(clsVarApl.dicVarGen["nDiasVcmtoCheque"])+ " Días", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe registrar los días de valorización", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los días de valorización no es válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    break;
                case 4: //--Pago con Interbancarios
                    if (cboEnt.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la entidad financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEnt.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (cboCuenta.SelectedIndex==-1)
                    {
                        MessageBox.Show("Debe seleccionar el número de cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboCuenta.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe registrar el número del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe registrar la serie del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de emisión del documento no puede ser posterior a la fecha del sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe registrar los días de valorización", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los días de valorización no es válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    break;
                case 5: //--Pago con Orden de Pago
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe registrar el número de cuenta de la órden de pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        txtNroCta.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe registrar el número del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe registrar la serie del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (dtpFecDoc.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de emisión del documento no puede ser posterior a la fecha del sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    TimeSpan sDifFecOP = clsVarGlobal.dFecSystem - dtpFecDoc.Value;
                    if (sDifFecOP.Days > clsVarApl.dicVarGen["nDiasVigenciaCheque"])
                    {
                        MessageBox.Show("La Orden de Pago, ya se encuentra vencida...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecDoc.Focus();
                        dtpFecDoc.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (string.IsNullOrEmpty(txtFolio.Text))
                    {
                        MessageBox.Show("El número de folio no existe para la Orden de Pago...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFolio.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe registrar los días de valorización", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los días de valorización no es válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    break;
                case 6: //--Apertura con Cheque de Gerencia
                    if (string.IsNullOrEmpty(txtNroCuentaGer.Text))
                    {
                        MessageBox.Show("Número de cuenta no válido para la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtNroCheqGer.Text))
                    {
                        MessageBox.Show("Número de cheque no válido para la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtSerieCheqGer.Text))
                    {
                        MessageBox.Show("Número de serie de cheque no válido para la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }

                    if (cboEntidadCheGer.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe estar seleccionado la entidad financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEntidadCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (string.IsNullOrEmpty(txtMontoCheGer.Text))
                    {
                        MessageBox.Show("Monto de cheque no válido para la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (dtpFecCheqGer.Value > clsVarGlobal.dFecSystem)
                    {
                        MessageBox.Show("La fecha de emisión del cheque no puede ser posterior a la fecha del sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpFecCheqGer.Focus();
                        dtpFecCheqGer.Select();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (Convert.ToDecimal(txtMontoCheGer.Text) <= 0)
                    {
                        MessageBox.Show("El moonto de cheque no puede ser cero (0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    if (Convert.ToDecimal(txtMontoCheGer.Text) != Convert.ToDecimal(txtMonto.Text))
                    {
                        MessageBox.Show("El monto de cheque no puede ser diferente al monto de la apertura", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnBusCheGer.Focus();

                        if (tbcApertura.SelectedIndex != 2)
                        {
                            tbcApertura.SelectTab(2);
                        }
                        return;
                    }
                    break;
                case 7: //--Nota de Abono
                    break;
            }

            //============================================================
            //--Limpiar Datos de los Intereses
            //============================================================
            txtIntAdelantado.Text = "0.00";
            txtMonItfInt.Text = "0.00";
            this.txtRedondeoInt.Text = "0.00";
            txtIntNeto.Text = "0.00";
            txtNumCuenta.Text = "";
            txtTotInteres.Text = "0.00";
                        
            //================================================================
            //--Calcular Total de Interes al Pagar al final de Periodo
            //================================================================
            clsCNCalculosAho nInteres = new clsCNCalculosAho();
            
            Decimal  nMontoDep = Convert.ToDecimal (txtMontTotal.Text),
                    nTEM = Convert.ToDecimal (txtTasa.Text),
                    nMonFavCli = 0, 
                    nItf = 0, 
                    nMonNet=0,
                    nIntAdelantado=0;
            int nPlaTot = Convert.ToInt32(txtPlazoAho.Text),
                idMon = Convert.ToInt32(cboMoneda.SelectedValue);

            switch (Convert.ToInt32(cboPagoInt.SelectedValue))
            {                 
                case 1:  //--Pago de Interes en la Apertura
                    nIntAdelantado = Math.Round(nInteres.CalcularIntAdelantado(nTEM, nPlaTot, nMontoDep), 2);

                   nItf = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nIntAdelantado, 2, idMon);
                   this.txtIntAdelantado.Text = string.Format("{0:#,#0.00}", nIntAdelantado);
                   this.txtMonItfInt.Text = string.Format("{0:#,#0.00}", nItf);

                   nMonNet = FunTruncar.redondearBCR(nIntAdelantado, ref nMonFavCli, idMon, true, false);
                                
                   this.txtRedondeoInt.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));

                   this.txtIntNeto.Text = string.Format("{0:#,#0.00}", nMonNet - nItf);
                    
                   txtTotInteres.Text = nIntAdelantado.ToString();
                   lblTasa.Text = "Total Interes a Pagar:";
                   break;
                case 2: //--Pago de Interes al Cancelar la Cuenta
                   txtTotInteres.Text = Math.Round(Convert.ToDecimal(nInteres.CalcularInteresAho(nTEM, nPlaTot, nMontoDep, 2)), 2).ToString();
                   lblTasa.Text = "Total Interes a Pagar:";
                   break;
                case 3: //--Pago de Interes Mensualmente
                   //txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularInteresAho(nTEM, 30, nMontoDep, 2)), 2).ToString();
                   tbDepMen = nInteres.CalculaPpgDepMensual(nMontoDep, clsVarGlobal.dFecSystem, nPlaTot, nTEM);
                   object sumObject;
                   sumObject = tbDepMen.Compute("Sum(interes)", "");
                   txtTotInteres.Text = Math.Round(Convert.ToDecimal (sumObject), 2).ToString();
                   lblTasa.Text = "Total Interes a Pagar:";
                   if (string.IsNullOrEmpty(txtCtaVin.Text))
                   {
                       MessageBox.Show("Debe vincular con la cuenta para el depósito mensual de los intereses...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       btnVincular.Focus();

                       if (tbcApertura.SelectedIndex != 2)
                       {
                           tbcApertura.SelectTab(2);
                       }
                       return;
                   }
                   else
                   {
                       idCuentaRel = Convert.ToInt32(txtCtaVin.Text);
                   }
                   
                   break;
                default:
                   txtTotInteres.Text = "0.00";
                   lblTasa.Text = "Total Interes a Pagar:";
                    break;
            }

            //====================================
            //Saltar al Siguiente y/o Anterior
            //====================================

            tabPage4.Enter -= tabPage4_Enter;
            tbcApertura.SelectedIndex = 3;
            tabPage4.Enter += tabPage4_Enter;
            if (tbCtasCanceladas.Rows.Count > 0)
            {
                tbCtasCanceladas.Rows.Clear();
            }
            cboEnvioEstCta.SelectedValue = -1;
            btnGrabar.Enabled = true;
            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = true;
            conBusCol.btnConsultar.Focus();
        }

        private void CargarMontos()
        {
            Decimal nMontoOpe = Convert.ToDecimal (txtMonto.Text),nItf=0.00m,nComision=0.00m,nMonFavCli=0.00m;
            nComision = Convert.ToDecimal (txtComApe.Text);
            int nCodMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            if (chcITF.Checked)
            {
                nItf = Math.Round(FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMontoOpe, 8, nCodMoneda), 2);
                this.txtITF.Text = nItf.ToString();
                this.txtComisiones.Text = nComision.ToString();
                this.txtMontoTotal.Text = FunTruncar.redondearBCR(nMontoOpe + nItf + nComision, ref nMonFavCli, nCodMoneda, true, true).ToString();
            }
            else
            {
                nItf = 0.00m;
                this.txtITF.Text = nItf.ToString();
                this.txtComisiones.Text = nComision.ToString();
                this.txtMontoTotal.Text = FunTruncar.redondearBCR(nMontoOpe + nItf + nComision, ref nMonFavCli, nCodMoneda, true, true).ToString();
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            //====================================
            //Saltar al Siguiente y/o Anterior
            //====================================
            tabPage3.Enter -= tabPage3_Enter;
            tbcApertura.SelectedIndex = 2;
            tabPage3.Enter += tabPage3_Enter;
        }

        private void lblBase29_Click(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void chklbComision_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //--Limpiar los Tipos de Pago
        private void LimpiarTiposdePago()
        {
            txtCtaVin.Text = "";
            txtNroCuenta.Clear();
            txtEstado.Text = "";
            txtProdCtaVin.Text = "";
            conBusCtaAhoTransf.LimpiarControles();

            txtNroCta.Text = "";
            txtcNroCuenta.Clear();
            txtNroDocu.Text = "";
            txtSerie.Text = "";
            txtFolio.Text = "";
            txtDiaVal.Text = "0";
        }

        private void cboModPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTipoEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cboTipoEnt.SelectedIndex > 0)
            //{
            //    int nTipEnt = Convert.ToInt32(this.cboTipoEnt.SelectedValue);                
            //    cboEnt.CargarEntidades(nTipEnt);
            //}
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVincular_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {

        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCalculos();
            int idProd = Convert.ToInt32(this.cboSubProducto.SelectedValue);
            if (idProd>0)
            {
                CargaParamProducto(idProd, Convert.ToInt32(cboMoneda.SelectedValue), 1);
                conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMoneda.SelectedValue));

                AsignarVariableParametrosProducto();
                CargarRenovaciones();
                CargarPagoIntereses();
            }
            //else
            //{
            //    MessageBox.Show("Primero debe seleccionar el sub producto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool ValidarDatosGrabar()
        {
            if (string.IsNullOrEmpty(conBusCol.txtCod.Text))
            {
                MessageBox.Show("Debe registrar al promotor...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCol.txtCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCol.txtNom.Text))
            {
                MessageBox.Show("Debe registrar al promotor...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCol.txtCod.Focus();
                return false;
            }
            if (cboEnvioEstCta.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar el tipo de envío de su estado de cuenta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEnvioEstCta.Focus();
                return false;
            }
            if (Convert.ToUInt16(cboEnvioEstCta.SelectedValue) == 1) //--Envio estado de Cuenta a su Domicilio
            {
                if (string.IsNullOrEmpty(txtDireccionEnvioEstCta.Text))
                {
                    MessageBox.Show("Debe ingresar la dirección, para envío de su estado de cuenta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDireccionEnvioEstCta.Focus();
                    return false;
                }
            }
            if (Convert.ToUInt16(cboEnvioEstCta.SelectedValue) == 2) //--Envio estado de Cuenta Por Correo
            {
                if (string.IsNullOrEmpty(txtDireccionEnvioEstCta.Text))
                {
                    MessageBox.Show("Debe ingresar el correo electrónico, para envío de su estado de cuenta...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDireccionEnvioEstCta.Focus();
                    return false;
                }
            }
            if (cboOrigenFondos.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el origen de fondos...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboOrigenFondos.Focus();
                return false;
            }
            if (cboObjetoAhorro.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el objeto del ahorro...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboObjetoAhorro.Focus();
                return false;
            }
            if (Convert.ToInt16(cboOrigenFondos.SelectedValue)==3) //--Cuentas Canceladas
            {
                if (tbCtasCanceladas.Rows.Count<=0)
                {
                    MessageBox.Show("Para el tipo de Origen de Fondos, Debe Seleccionar por lo Menos una Cuenta Cancelada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusCtasCanc.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //---------------------------------------------------------------------------------------------------
            //-- * Validar Datos
            //---------------------------------------------------------------------------------------------------
            if (!ValidarDatosGrabar())
            {
                return;
            }

            //---------------------------------------------------------------------------------------------------
            //-- * REGISTRO DE RASTREO
            //---------------------------------------------------------------------------------------------------
            this.registrarRastreo(Convert.ToInt32(dtInt.Rows[0]["codigo"]), 0, "Inicio- Solicitud de Apertura de Cuenta de Ahorro", btnGrabar);
            
            int idCtaTrans = 0;

            int nPlazo = 0;  
            nPlazo = Convert.ToInt32(txtPlazoAho.Text.ToString());
            
            if (lEsAhoProg)
            {
                nPlazo = p_nPlaAhoPrg;  
            }


            //===================================================================
            //---VALIDACION DE CLIENTE PEP         
            //===================================================================
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                string mensaje = "",
                        x_cNroDni = "";
                int x_idEstApr = 0;
                int CodCliente = Convert.ToInt32(dtInt.Rows[i]["codigo"].ToString());
                int CodidTipoDocumento = Convert.ToInt32(dtInt.Rows[i]["idTipoDocumento"].ToString());

                if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
                {
                    MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (x_idEstApr==1) //--Solicitado
                    {
                        frmPep frmPepx = new frmPep(CodidTipoDocumento,x_cNroDni);
                        frmPepx.ShowDialog();
                    }
                    return;
                }
            }      

            //--==================================================
            //--Si tipo de Pago es por Transferencia
            //--==================================================
            switch (Convert.ToInt32(cboModPago.SelectedValue))  
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
                case 6:  //--Cheque Gerencia
                    idCtaTrans = 0;
                    break;
                default:
                    idCtaTrans = 0;
                    break;
            }

            //============================================================
            //--Retorna Estructura Para depositos
            //============================================================
            clsCNAperturaCta deposito = new clsCNAperturaCta();
            DataTable dtDepos = deposito.ListaCamposDep(1);
            DataRow dr = dtDepos.NewRow();
            //--Asignar Datos Para Registrar la Solicitud de Apertura
            dr["idEstado"] = 4;//--Estado Solicitado
            dr["idProducto"] = cboSubProducto.SelectedValue;
            dr["idTipoCuenta"] = cboTipoCuenta.SelectedValue;
            dr["idTipoTasa"] = cboTipoTasa.SelectedValue;
            dr["idTasa"] = idTasa;
            dr["nMonTasa"] = Convert.ToDecimal (txtTasa.Text);
            dr["idMoneda"] = cboMoneda.SelectedValue;
            dr["idAgencia"] = clsVarGlobal.nIdAgencia;
            dr["idUsuario"] = clsVarGlobal.User.idUsuario;
            dr["nMontoDeposito"] = Convert.ToDecimal (txtMonto.Text); //Debe ir el Monto Total a Recibir
            dr["nInteresGen"] = 0.00;
            dr["nInteresPag"] = Convert.ToDecimal (txtIntAdelantado.Text);
            dr["nMonIntTot"] = Convert.ToDecimal (txtTotInteres.Text);
            dr["dFechaApertura"] = clsVarGlobal.dFecSystem.ToShortDateString(); 
            dr["nNumeroFirmas"] = Convert.ToInt32(txtNroFir.Text);
            dr["idUsuAsig"] = conBusCol.txtCod.Text; 
            dr["nSaldoDis"] = Convert.ToDecimal (txtMontTotal.Text);
            dr["nSaldoCnt"] = Convert.ToDecimal (txtMontTotal.Text);
            if (Convert.ToInt32(cboModPago.SelectedValue) == 3 || Convert.ToInt32(cboModPago.SelectedValue) == 4)  //--Cheques e Interbancarios
            {
                if (Convert.ToInt32(txtDiaVal.Text) > 0)
                {
                    dr["nSaldoDis"] = 0.00;
                }
            }
        
            //--Los Plazos Fijos, saldo disponible y CNT debe ser cero (0)
            if (Convert.ToInt32(txtPlaProd.Text)>0)
            {
                dr["nSaldoDis"] = 0.00;
                dr["nSaldoCnt"] = 0.00;
            }
            dr["dFecUltMov"] = clsVarGlobal.dFecSystem.ToShortDateString();
            dr["lInactiva"] = 0;
            if (chcInactiva.Checked)
            {
                dr["lInactiva"] = 1;
            }

            dr["lIsAfectoITF"] = 0;
            if (chcITF.Checked)
            {
                dr["lIsAfectoITF"] = 1;
            }

            dr["lIsCtaOrdPago"] = 0;
            if (chcOrdPago.Checked)
            {
                dr["lIsCtaOrdPago"] = 1;
            }

            if (cboRenovacion.SelectedIndex<0)
            {
                dr["idRenovacion"] = 0;
            }
            else
            {
                dr["idRenovacion"] = cboRenovacion.SelectedValue;
            }

            if (cboPagoInt.SelectedIndex<0)
            {
                dr["idPagoInt"] = 0;
            }
            else
            {
                dr["idPagoInt"] = cboPagoInt.SelectedValue;                
            }

            dr["nSaldoMinimo"] = p_nMonMinSalDis;        
            dr["idTipoPersona"] = cboTipoPersona.SelectedValue;
            dr["nPlazoCta"] = Convert.ToInt32(txtPlaProd.Text);
            if (lEsAhoProg)
            {
                dr["nPlazoCta"] = p_nPlaAhoPrg;  
            }
            dr["cRucEmpleador"] = conBusCli.txtNroDoc.Text;

            dr["cDescripcionCta"] = txtDescriCta.Text;
            dr["idTipoEnvioEstCta"] = Convert.ToInt16(cboEnvioEstCta.SelectedValue);
            dr["cDireccionEnvioEstCta"] = txtDireccionEnvioEstCta.Text;
            dr["idOrigenFondo"] = Convert.ToInt16(cboOrigenFondos.SelectedValue);
            dr["idObjetoAho"] = Convert.ToInt16(cboObjetoAhorro.SelectedValue);

            dtDepos.Rows.Add(dr);
            
            //============================================================
            //--Retorna Estructura Para Empleador 
            //============================================================
            clsCNAperturaCta Empleador = new clsCNAperturaCta();
            DataTable dtEmp = Empleador.ListaCamposDep(2);
            
            //--Asignar Datos Para Registrar Apertura
            if (lEsReqEmpleador)
            {
                DataRow drEmp = dtEmp.NewRow();
                drEmp["cRucEmpleador"] = conBusCli.txtNroDoc.Text;
                drEmp["cRazonSocial"] = conBusCli.txtNombre.Text.Trim();
                drEmp["cDireccion"] = conBusCli.txtDireccion.Text.Trim();
                dtEmp.Rows.Add(drEmp);
            }
            
            //--Generar XML de Datos Empleador
            DataSet dsEmpleador = new DataSet("dsDeposito");
            dsEmpleador.Tables.Add(dtEmp);
            string xmlEmpleador = clsCNFormatoXML.EncodingXML(dsEmpleador.GetXml());  //dsEmpleador.GetXml();

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();
            ////--Asignar Datos Para Registrar Apertura

            switch (Convert.ToInt32(cboModPago.SelectedValue))  //--Tipos de Pago
            {
                case 1: //Pago en Efectivo
                    drPag["idTipoValorado"] = 1; //--Tipo Pago Efectivo
                    drPag["cNroCuentaDoc"] = "";
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                    drPag["nNroFolio"] = "0";
                    break;
                case 2: //Pago con Transferencia de Cuentas
                    drPag["idTipoValorado"] = 2; //--Tipo Pago Transferencia
                    drPag["cNroCuentaDoc"] = conBusCtaAhoTransf.idcuenta.ToString(); 
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                    drPag["nNroFolio"] = "0";
                    drPag["lisMismaCta"] = 0;
                    if (rbtMismaCta.Checked)
                    {
                        drPag["lisMismaCta"] = 1;
                    }
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
                case 4: //Tipo Interbancario (Voucher)
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

            //--Generar XML de Datos del Tipo de Pago
            DataSet dsTipPago = new DataSet("dsDeposito");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

            //--Variables Adicionales
            int idEntFin = clsVarApl.dicVarGen["idInstFin"];
            if (Convert.ToInt32(cboModPago.SelectedValue) > 2)
            {
                idEntFin = Convert.ToInt32(cboEnt.SelectedValue);
            }

            string cNroDocPag = txtNroDocu.Text.Trim();
            
            //===================================================================
            //--Generar XML de Datos Deposito
            //===================================================================
            DataSet ds = new DataSet("dsDeposito");
            ds.Tables.Add(dtDepos);
            string xmlDeposito = ds.GetXml();
            xmlDeposito = clsCNFormatoXML.EncodingXML(xmlDeposito);
                                    
            ////===================================================================
            ////--Generar XML de Datos Comisiones
            ////===================================================================
            //DataSet dsComision = new DataSet("dsDeposito");
            //dsComision.Tables.Add(dtComision);
            //string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

            //===================================================================
            //--Generar XML de Datos Aho Programado
            //===================================================================
            DataSet dsAhoPrg = new DataSet("dsDeposito");
            dsAhoPrg.Tables.Add(tbAhoPrg);  
            string xmlAhoPrg = clsCNFormatoXML.EncodingXML(dsAhoPrg.GetXml());

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable tbCliIntervi = dtInt.Clone();
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                tbCliIntervi.ImportRow(dtInt.Rows[i]);
            }

            DataSet dsInterv = new DataSet("dsDeposito");
            dsInterv.Tables.Add(tbCliIntervi);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsInterv.GetXml());

            //===================================================================
            //--Generar XML de Datos de las Cuentas Canceladas
            //===================================================================
            DataTable dtCtasCancel = tbCtasCanceladas.Clone();
            for (int i = 0; i < tbCtasCanceladas.Rows.Count; i++)
            {
                dtCtasCancel.ImportRow(tbCtasCanceladas.Rows[i]);
            }

            DataSet dsCtasCancel = new DataSet("dsDeposito");
            dsCtasCancel.Tables.Add(dtCtasCancel);
            string xmlCtasCancel = clsCNFormatoXML.EncodingXML(dsCtasCancel.GetXml());

            //===================================================================
            //--Guardar Apertura Cuenta
            //===================================================================
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue);
            int nCuotas = Convert.ToInt32(nudNroDep.Value);
            //int idCanal = 1;

            Decimal nMonOpe = Convert.ToDecimal (this.txtMontEnt.Text.ToString());
            Decimal nMonCapital = Convert.ToDecimal (txtMonto.Text.ToString()); 

            //===================================================================
            //--Registrar Apertura de Cuenta
            //===================================================================
            clsCNAperturaCta dtRegApe = new clsCNAperturaCta();
            DataTable tbRegApe = dtRegApe.RegistraAperturaCta(xmlDeposito, xmlInterv, xmlTipPago, xmlEmpleador, xmlAhoPrg
                                            ,clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, nCuotas, Convert.ToDecimal (txtMontoIntang.Text),
                                            lEsAhoProg, lIsRequeCert, lEsCtaCTS, idTipPago, idCtaTrans, dtpFecAhoProg.Value, lEsReqEmpleador, cNroDocPag, idEntFin, idCuentaRel,
                                            nMonCapital, xmlCtasCancel);
            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE CUENTA: " + tbRegApe.Rows[0]["idNroCta"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumCuenta.Text = tbRegApe.Rows[0]["idNroCta"].ToString();
                btnGrabar.Enabled = false;
                btnRegresar.Enabled = false;
                btnNuevo.Enabled = true;
                conBusCol.HabilitarControles(false);
                conBusCol.txtCod.Enabled = false;
                conBusCol.btnConsultar.Enabled = false;
                chcOrdPago.Enabled = false;
                cboEnvioEstCta.Enabled = false;
                txtDireccionEnvioEstCta.Enabled = false;
                cboOrigenFondos.Enabled = false;
                cboObjetoAhorro.Enabled = false;
                btnBusCtasCanc.Enabled = false;
                //--Liberar Variables
                dtDepos.Clear();
                dtDepos.Dispose();
                dtEmp.Dispose();
                dtPag.Dispose();
                tbAhoPrg.Dispose();
                dtComision.Dispose();
                dtInt.Dispose();
                dsEmpleador.Dispose();
                dsCtasCancel.Clear();
                dsCtasCancel.Dispose();
                dtCtasCancel.Dispose();
               // dsTipPago.Dispose();
                ds.Dispose();
                dsInterv.Clear();
                dsInterv.Dispose();
               // dsComision.Dispose();
                dsAhoPrg.Dispose();                
                //------------
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(tbRegApe.Rows[0]["idCuentaAho"].ToString()));
            }
            else
            {
                //--Liberar Variables
                dtDepos.Clear();
                dtDepos.Dispose();
                dtEmp.Dispose();
                dtPag.Dispose();
                tbAhoPrg.Dispose();
                dtComision.Dispose();
                dtInt.Dispose();
                dsEmpleador.Dispose();
                // dsTipPago.Dispose();
                dsCtasCancel.Clear();
                dsCtasCancel.Dispose();
                dtCtasCancel.Dispose();
                ds.Dispose();
                dsInterv.Clear();
                dsInterv.Dispose();
                // dsComision.Dispose();
                dsAhoPrg.Dispose();
                //------------

                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //*========================================================================================
            //    * REGISTRO DE RASTREO
            //========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(dtInt.Rows[0]["codigo"]), Convert.ToInt32(tbRegApe.Rows[0]["idCuentaAho"].ToString()), "Fin- Registro Solicitud de Apertura de Cuenta de Ahorro", btnGrabar);            	
			          
        }
      
        private void DeclaracionJuradaCli()
        {
            int idCli = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 6)
                {
                    idCli = Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["codigo"].Value);
                    frmDeclaracionJurada declara = new frmDeclaracionJurada(idCli);
                }
            }
        }

        private void txtNroRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //btnBuscarRuc.PerformClick();
            }
        }

        private void dtgIntervinientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                if (!chcITF.Checked)
                {
                    for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                    {
                        dtgIntervinientes.Rows[i].Cells["lEsAfeItf"].Value = false;
                    }
                    return;
                }

                int index = e.RowIndex;
                if (dtgIntervinientes.Rows.Count == 1)
                {
                    index = 0;
                }

                for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                {
                    dtgIntervinientes.Rows[i].Cells["lEsAfeItf"].Value = false;
                }

                if (dtgIntervinientes.Rows[index].Cells["tipodoc"].Value.ToString() != "DNI Menor" && dtgIntervinientes.Rows[index].Cells["tipodoc"].Value.ToString() != "Partida Nacimiento")
                {
                    if ((lIsDepMenEdad == false && Convert.ToInt32(dtgIntervinientes.Rows[index].Cells["idTipoInterv"].Value) == 6) // TITULAR
                        || (lIsDepMenEdad == true && Convert.ToInt32(dtgIntervinientes.Rows[index].Cells["idTipoInterv"].Value) == 8)) // APODERADO
                    {
                        dtgIntervinientes.Rows[index].Cells["lEsAfeItf"].Value = true;
                    }
                }
            }         
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
            btnNuevo.Enabled = false;
            tbcApertura.SelectedIndex = 0;
        }

        private void nuevo()
        {
            //--============================================
            //--Resumen Apertura
            //--============================================
            txtNumCuenta.Text = "";
            txtMontoTotal.Text = "0.00";
            txtTotInteres.Text = "0.00";
            txtMonIntCTS.Text = "0.00";
            txtComisiones.Text = "0.00";
            txtITF.Text = "0.00";

            txtIntAdelantado.Text = "0.00";
            txtMonItfInt.Text = "0.00";
            this.txtRedondeoInt.Text = "0.00";
            txtIntNeto.Text = "0.00";
            conBusCol.LimpiarDatos();
            cboEnvioEstCta.SelectedValue = 1;
            txtDireccionEnvioEstCta.Text = "";
            cboOrigenFondos.SelectedIndex = -1;
            cboObjetoAhorro.SelectedValue = 1;
            cboEnvioEstCta.Enabled = true;
            txtDireccionEnvioEstCta.Enabled = true;
            cboOrigenFondos.Enabled = true;
            cboObjetoAhorro.Enabled = true;
            txtRedondeoApe.Text = "0.00";
            chcOrdPago.Checked = false;
            chcITF.Checked = false;
            chcCert.Checked = false;
            chcRenov.Checked = false;
            chcInactiva.Checked = false;
            txtPlaInac.Text = "0";

            txtProducto.Text = "";
            txtTipCuenta.Text = "";
            txtTipPersona.Text = "";
            txtMoneda.Text="";
            txtMonApe.Text = "0.00";
            txtPlaProd.Text = "";
            //--============================================
            //--Tasa y Forma de Pago
            //--============================================
            cboTipoTasa.SelectedValue = 1;
            cboRenovacion.SelectedValue = 0;
            cboPagoInt.SelectedValue = 0;
            txtCtaVin.Clear();
            txtNroCuenta.Clear();
            txtEstado.Clear();
            txtProdCtaVin.Clear();
            txtTasa.Text = "0.00";
            txtTasaEfectiva.Text = "0.00";
            txtTrea.Text = "0.00";
            txtMonPago.Text = "0.00";
            txtMonApePago.Text = "0.00";
            txtComApe.Text = "0.00";
            txtNroDocu.Text="";
            txtSerie.Text = "";
            dtgComAho.DataSource = null;
            LimpiarCtrCheqGer();
            conBusCtaAhoTransf.LimpiarControles();
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            //--============================================
            //--Datos del Cliente
            //--============================================
            txtProdCli.Text = "";
            txtDescriCta.Text = "";
            txtNroFir.Text = "0";
            dtInt.Rows.Clear();
            //--============================================
            //--Datos de la Apertura
            //--============================================
            txtMonMinOpe.Text = "0.00";
            txtMonMinApe.Text = "0.00";
            txtPlazoAho.Text = "";
            cboMoneda.SelectedValue = 1;
            cboTipoApe.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            cboTipoPersona.SelectedValue = 1;
            CodPro = 46;
            dtpFecAhoProg.Value = clsVarGlobal.dFecSystem;
            this.cboTipoDeposito.CargarProducto(CodPro);
            this.cboTipoDeposito.SelectedIndex = 1;
            //--============================================
            //--Inicializar Variables
            //--============================================
            tbAhoPrg = null;
            dtComision = null;            
            p_nPlaAhoPrg = 0;
            nidCliTit = 0;
            idTasa = 0;
            p_idCta = 0;
            p_nMonMinSalDis = 0.00m;
            conSolesDolar.iMagenMoneda(0);
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;
            cboTipoDeposito.Focus();

            btnGrabar.Enabled = true;
            btnRegresar.Enabled = true;
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipCtaProd(Convert.ToInt32(cboSubProducto.SelectedValue));
            limpiarCalculos();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcular();
            }
        }

        private void calcular()
        {
            decimal nMonto;
            Decimal nMonFavCli = 0.00m;
            if (string.IsNullOrEmpty(cboSubProducto.SelectedValue.ToString()))
            {
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtMonto.Text))
                {
                    nMonto = 0;
                    this.txtMonto.Text = nMonto.ToString();
                    this.txtComision.Text = "0.00";
                    this.txtImpuesto.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    this.txtITF.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtComisiones.Text = "0.00";
                    this.txtMonto.SelectAll();
                    return;
                }
                else
                {
                    nMonto = Convert.ToDecimal(this.txtMonto.Text.ToString());
                    
                    /*if (Convert.ToInt16(cboTipoApe.SelectedValue) == 1)  //Efectivo
                    {
                        nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                        //nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    }

                    this.txtMonto.KeyPress -= txtMonto_KeyPress;
                    this.txtMonto.Leave -= txtMonto_Leave;
                    this.txtMonto.TextChanged -= txtMonto_TextChanged;
                    
                    this.txtMonto.nDecValor = nMonto;

                    this.txtMonto.KeyPress += txtMonto_KeyPress;
                    this.txtMonto.Leave += txtMonto_Leave;
                    this.txtMonto.TextChanged += txtMonto_TextChanged;
                     * */

                    //--==========================================================
                    //--Calcular Comisiones de la Cuenta
                    //--==========================================================
                    CargarComisiones(Convert.ToInt32(cboSubProducto.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));
                    Decimal nComision = Convert.ToDecimal (txtComision.Text);

                    //--==========================================================
                    //--Validar Monto Ingresado
                    //--==========================================================
                    if ((Decimal)nMonto < nComision)
                    {
                        this.txtMonto.SelectAll();
                        this.txtMonto.Focus();
                        this.txtComision.Text = "0.00";
                        this.txtImpuesto.Text = "0.00";
                        this.txtMontTotal.Text = "0.00";
                        this.txtMontEnt.Text = "0.00";
                        this.txtITF.Text = "0.00";
                        this.txtRedondeo.Text = "0.00";
                        this.txtComisiones.Text = "0.00";
                        return;
                    }
                    
                    
                    //--==========================================================
                    //--Calcular ITF
                    //--==========================================================
                    Decimal nITF;
                    if (!lEsAfeITF)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, (Int32)this.cboMoneda.SelectedValue);
                    }
                    //--Tipo de Persona sin Fines de Lucro no Tiene ITF
                    if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 3)
                    {
                        nITF = 0.00m;
                    }

                    //--Transferencias, entre las mismas Cuentas, no debe calcular Itf
                    if (Convert.ToInt32(cboTipoApe.SelectedValue) == 2 && rbtMismaCta.Checked==true) //--Transferencias
                    {
                        nITF = 0.00m;
                    }

                    this.txtImpuesto.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtITF.Text = string.Format("{0:#,#0.00}", nITF);
                    this.txtComision.Text = string.Format("{0:#,#0.00}",Math.Round(nComision, 2));

                    Decimal nMontoTotal = 0;

                    this.txtMonto.Text = string.Format("{0:#,#0.00}", nMonto);

                    nMontoTotal = (Decimal)nMonto - Math.Round(nITF, 2) - (Decimal)Math.Round(nComision, 2);
                    if (Convert.ToInt16(cboTipoApe.SelectedValue) == 1)  //Efectivo
                    {
                        nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                        //nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    }

                    this.txtMontTotal.Text =  string.Format("{0:#,#0.00}",(nMontoTotal));// + Math.Round(nMonFavCli, 2)));
                    this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((Decimal)nMonto ));//nMonto - nMonFavCli)); 
                    this.txtMontoTotal.Text = string.Format("{0:#,#0.00}", ((Decimal)nMonto)); //- nMonFavCli));
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));

                    //this.txtMonto.Text = string.Format("{0:#,#0.00}", nMonto);
                }
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            frmComisionesCta frmComisCta = new frmComisionesCta();
            frmComisCta.dtCom = dtComision;
            frmComisCta.ShowDialog();
        }

        private void cboBase1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Checked = false;
            
            if (cboTipoApe.SelectedIndex>0)
            {
                if (Convert.ToInt16(cboTipoApe.SelectedValue) == 2)  //--pago con Transferencias
                {
                    if (Convert.ToInt32(cboTipoCuenta.SelectedValue) != 1)
                    {
                        MessageBox.Show("Para pago con transferencia, el tipo de cuenta tiene que ser individual", "Apertura de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboTipoCuenta.SelectedValue = 1;
                        return;
                    }
                    rbtMismaCta.Enabled = true;
                    rbtOtrasCuentas.Enabled = true;
                    rbtMismaCta.Focus();  
                }
                if (cboModPago.Items.Count > 0)
                {
                    int tipoApe =Convert.ToInt32(cboTipoApe.SelectedValue);
                    cboModPago.SelectedValue = tipoApe;  
                }
            }
            limpiarCalculos();
        }

        private void limpiarCalculos()
        {
            this.txtMonto.Text = "0.00";
            this.txtComision.Text = "0.00";
            this.txtImpuesto.Text = "0.00";
            this.txtMontTotal.Text = "0.00";
            this.txtMontEnt.Text = "0.00";
            this.txtITF.Text = "0.00";
            this.txtComisiones.Text = "0.00";
            this.txtRedondeo.Text = "0.00";
            this.txtMonto.Focus();
            this.txtMonto.SelectAll();
        }

        private void cboRenovacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPagoInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVincular.Enabled = false;
            if (cboPagoInt.Items.Count>0)
            {
                if (Convert.ToInt16(cboPagoInt.SelectedValue) == 3)
                {
                    btnVincular.Enabled = true;

                }
                else
                {
                    btnVincular.Enabled = false;
                }
                
            }
        }

        private void cboTipoTasa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chcITF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoApe.SelectedValue = 1;
            if (Convert.ToInt16(cboTipoCuenta.SelectedValue)>1)
            {
                txtDescriCta.Enabled = true;
            }
            else
            {
                txtDescriCta.Enabled = false;
            }
            
        }

        private bool ValidarOP()
        {
            if (string.IsNullOrEmpty(txtNroCta.Text) || Convert.ToInt32(txtNroCta.Text)<=0)
            {
                 MessageBox.Show("Debe ingresar el número cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 txtNroCta.Focus();
                 txtNroCta.SelectAll();
                 return false;
            }
            if (string.IsNullOrEmpty(txtNroDocu.Text) || Convert.ToInt32(txtNroDocu.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar el número del documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocu.Focus();
                txtNroDocu.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text) || Convert.ToInt32(txtSerie.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar la serie del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCta.Focus();
                txtNroCta.SelectAll();
                return false;
            }
            return true;
        }

        private void btnBuscaOP_Click(object sender, EventArgs e)
        {

                }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmGenAperturaCta_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(p_idCta);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonto.Text) || txtMonto.Text == "0")
            {
                this.txtComision.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.txtMontTotal.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontEnt.Text = "0.00";
            }
        }

        private DataTable ArmarTablaParametrosIni()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDeposito";
            drfila[1] = cboTipoDeposito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelValida";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliRegla";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);                      

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = cboTipoPersona.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCuenta";
            drfila[1] = cboTipoCuenta.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = cboTipoApe.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonMinOpe";
            drfila[1] = txtMonMinOpe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonMinApe";
            drfila[1] = txtMonMinApe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoAho";
            //drfila[1] = txtPlazoAho.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);
            
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNroFir.Text;
            dtTablaParametros.Rows.Add(drfila);
                        
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMonto.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoIntangible";
            drfila[1] = txtMontoIntang.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoComision";
            drfila[1] = txtComision.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtImpuesto.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = txtRedondeo.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoApertura";
            drfila[1] = txtMontTotal.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRecibir";
            drfila[1] = txtMontEnt.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idClientes";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idIntervinientes";
            drfila[1] = "0";
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

            return dtTablaParametros;
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDeposito";
            drfila[1] = cboTipoDeposito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelValida";
            drfila[1] = "2";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliRegla";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = cboTipoPersona.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCuenta";
            drfila[1] = cboTipoCuenta.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = cboTipoApe.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonMinOpe";
            drfila[1] = txtMonMinOpe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonMinApe";
            drfila[1] = txtMonMinApe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoAho";
            //drfila[1] = txtPlazoAho.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNroFir.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMonto.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoIntangible";
            drfila[1] = txtMontoIntang.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoComision";
            drfila[1] = txtComision.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtImpuesto.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = txtRedondeo.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoApertura";
            drfila[1] = txtMontTotal.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRecibir";
            drfila[1] = txtMontEnt.Text.Replace(",", "");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEmpresa";
            drfila[1] = conBusCli.txtCodCli.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = dtInt.Rows.Count.ToString();
            dtTablaParametros.Rows.Add(drfila);

            string idClientes = "";
            string idIntervinientes = "";
            for (int i = 0; i < this.dtInt.Rows.Count; i++)
            {
                idClientes = idClientes + this.dtgIntervinientes.Rows[i].Cells["codigo"].Value.ToString()+",";
                idIntervinientes = idIntervinientes + this.dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value.ToString() + ",";
            }                

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idClientes";
            drfila[1] ="'" +idClientes.Substring(0,idClientes.Length-1)+"'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idIntervinientes";
            drfila[1] = "'" + idIntervinientes.Substring(0, idIntervinientes.Length - 1) + "'";
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

            return dtTablaParametros;
        }

        private DataTable ArmarTablaParametrosCli()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDeposito";
            drfila[1] = cboTipoDeposito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelValida";
            drfila[1] = "3";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliRegla";
            drfila[1] = x_idCliRegla;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = cboTipoPersona.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCuenta";
            drfila[1] = cboTipoCuenta.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = cboTipoApe.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

             drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNroFir.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = dtInt.Rows.Count.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idClientes";
            drfila[1] = x_idCliRegla;   //"0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idIntervinientes";
            drfila[1] = "0";
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
                            clsVarGlobal.dFecSystem.Day.ToString()+"'";
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

        private bool ValidarReglasIni()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0,
                idProd = Convert.ToInt16(cboSubProducto.SelectedValue);
            x_idCliente = clsVarGlobal.User.idCli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosIni(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMonto.Text), 0, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0,
                idProd = Convert.ToInt16(cboSubProducto.SelectedValue);
            x_idCliente = clsVarGlobal.User.idCli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMonto.Text), 0, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private bool ValidarReglasCli()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0,
                idProd = Convert.ToInt16(cboSubProducto.SelectedValue);
            x_idCliente = clsVarGlobal.User.idCli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametrosCli(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), idProd,
                                                   Decimal.Parse(txtMonto.Text), 0, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
        }

        private void btnEliLista_Click(object sender, EventArgs e)
        {
            if (dtInt.Rows.Count>0)
            {
                dtInt.Rows.Clear();
                dtgIntervinientes.Refresh();
                btnEliLista.Enabled = false;
            }
        }

        private void lblBase44_Click(object sender, EventArgs e)
        {

        }

        private void grbDatosProducto_Enter(object sender, EventArgs e)
        {

        }

        private void cboModPago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LimpiarCtrCheqGer();
            LimpiarTiposdePago();
            btnBuscaOP.Visible = false;
            btnMiniBusq.Visible = false;
            chcOP.Visible = false;
            cboTipoEnt.Visible = false;
            lblTipEnt.Visible = false;
            lblFolio.Visible = false;
            txtFolio.Visible = false;
            conBusCtaAhoTransf.btnBusCliente.Enabled = false;
            txtDiaVal.Enabled = true;
            txtNroCta.Visible = false;
            txtcNroCuenta.Visible = false;                
            cboCuenta.Visible = true;
            txtNroDocu.MaxLength = 12;
            txtSerie.MaxLength = 8;

            if (cboTipoCuenta.Items.Count==0)
            {
                 MessageBox.Show("No existe tipo de cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
            }

            int idTipoCuenta = (int)cboTipoCuenta.SelectedValue;

            if (this.cboModPago.SelectedIndex > 0)
            {
                //cboModPago.Enabled = true;
                int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
                switch (nCodModPago)
                {
                    case 1: //--Pago En Efectivo
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        break;
                    case 2: //--Pago con Transferencia
                        if (Convert.ToInt32(idTipoCuenta) == 1)
                        {
                            tbcPagos.SelectedIndex = 0;
                            conBusCtaAhoTransf.btnBusCliente.Enabled = true;
                            this.tbcPagos.Controls["tabTrans"].Enabled = true;
                            this.tbcPagos.Controls["tabChe"].Enabled = false;
                            lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                            conBusCtaAhoTransf.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                            conBusCtaAhoTransf.pnIdMon = Convert.ToInt32(cboMoneda.SelectedValue);
                        }
                        else
                        {
                            MessageBox.Show("Pago Con Transferencia es Solo para Tipos de CUENTA INDIVIDUAL", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTrans"].Enabled = false;
                            this.tbcPagos.Controls["tabChe"].Enabled = false;
                            lblTipPago.Text = "MODALIDAD DE APERTURA: EFECTIVO";
                        }
                        break;
                    case 3: //--Pago con Cheques
                        txtNroCta.Visible = true;
                        txtcNroCuenta.Visible = false;
                        cboCuenta.Visible=false;
                        cboTipoEnt.Visible = true;
                        lblTipEnt.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = true;
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
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        break;
                    case 4: //--Pago Interbancario
                        CargarCtasbancos(); //Cargar las Cuentas de Bancos
                        txtNroCta.Visible = false;
                        cboCuenta.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = true;
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        cboEnt.Enabled = true;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;                        
                        lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        break;
                    case 5: //--Pago con OP
                        txtNroCta.Visible = false;
                        txtcNroCuenta.Visible = true;
                        btnMiniBusq.Visible = true;
                        chcOP.Visible = true;
                        cboCuenta.Visible=false;
                        btnBuscaOP.Visible = true;
                        lblFolio.Visible = true;
                        txtFolio.Visible = true;
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = true;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        cboEnt.CargarEntidades(clsVarApl.dicVarGen["idTipoInstFin"]);
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        txtFolio.Enabled = false;
                        cboEnt.Enabled = false;
                        txtNroCta.Enabled = false;
                        txtSerie.Enabled = true;
                        txtNroDocu.Enabled = true;
                        txtDiaVal.Text = "0";
                        txtNroDocu.MaxLength = 9;
                        txtSerie.MaxLength = 3;
                        txtDiaVal.Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        break;
                    case 6://--Deposito con cheque de gerencia
                         CargarCtasbancos(); //Cargar las Cuentas de Bancos
                        tbcPagos.SelectedIndex = 2;                                                
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = true;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        this.btnBusCheGer.Enabled = true;
                        break;
                    default: //---Otros
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTrans"].Enabled = false;
                        this.tbcPagos.Controls["tabChe"].Enabled = false;
                        this.tbcPagos.Controls["tabCheGer"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        break;
                }
            }
            else
            {
                tbcPagos.SelectedIndex = 0;
                this.tbcPagos.Controls["tabTrans"].Enabled = false;
                this.tbcPagos.Controls["tabChe"].Enabled = false;
                lblTipPago.Text = "MODALIDAD DE PAGO: EFECTIVO";
            }
        }

        private void LimpiarCtrCheqGer()
        {
            txtNroCuentaGer.Text = "";
            txtNroCheqGer.Text = "";
            txtSerieCheqGer.Text = "";
            cboEntidadCheGer.SelectedValue = 1;
            cboMonedaCheGer.SelectedValue = cboMoneda.SelectedValue;
            txtMontoCheGer.Text = "";
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
        }

        private void btnBuscaOP_Click_1(object sender, EventArgs e)
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
                if (Convert.ToInt32(dt.Rows[0]["idMoneda"].ToString()) != Convert.ToInt32(cboMonedaDoc.SelectedValue))
                {
                    MessageBox.Show("La moneda de la Orden de Pago, es distinto a la apertura", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToDecimal (dt.Rows[0]["nSaldoDis"].ToString()) < Convert.ToDecimal (txtMonto.Text))
                {
                    MessageBox.Show("El saldo disponible es menor al monto de la operación", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))  //Modificado
                {
                    MessageBox.Show("La cuenta no puede emitir ordenes de pago", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //---------------------------------------------------------------------
                //--Validar Estado de la Orden de Pago
                //---------------------------------------------------------------------
                int x_idEstado = Convert.ToInt16(dt.Rows[0]["idEstado"].ToString());
                switch (x_idEstado)
                {
                    case 1: //--Ingresado
                        MessageBox.Show("Orden de Pago no válido, se encuentra en estado INGRESADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 2: //--Vinculado
                        MessageBox.Show("Orden de Pago no válido, se encuentra en estado VINCULADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 3: //--Impreso
                        MessageBox.Show("Orden de Pago no válido, se encuentra en estado IMPRESO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 4: //--Enviado
                        MessageBox.Show("Orden de Pago no válido, se encuentra en estado ENVIADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    case 5: //--Recepcionado
                        MessageBox.Show("Orden de Pago no válido, se encuentra en estado RECEPCIONADO", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (!clsDatCta.CNValidaOperacionAho(p_idCta, "1", 11, Convert.ToDecimal (txtMonto.Text), ref Mensaje))
                {
                    MessageBox.Show(Mensaje, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                txtFolio.Text = dt.Rows[0]["nNroFolio"].ToString();

                var Msg=MessageBox.Show("Los Datos de la Orden de Pago son válidos" +
                    "\n El Número de Folio del Documento es: (" + txtFolio.Text+") Esta seguro de los datos?...", "Validar Datos de la Orden de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg == DialogResult.Yes)
                {
                txtNroCta.Enabled = false;
                txtNroDocu.Enabled = false;
                txtSerie.Enabled = false;
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

        private void cboTipoEnt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if (cboTipoEnt.SelectedIndex>=0)
            //{
            //    //this.cboEnt.CargarEntidades((int)cboTipoEnt.SelectedValue);
            //    DataRowView dr = (DataRowView)cboEnt.SelectedItem;
            //    cboTipoEnt.SelectedValue = Convert.ToInt16(dr["idTipoEntidad"]);
            //}
            
        }

        private void btnVincular_Click_1(object sender, EventArgs e)
        {
           
        }
        private void ConverNumLetras(Decimal nMontoTotal)
        {
            objNumLetras.LetraCapital = true;
            objNumLetras.MascaraSalidaDecimal = "/100 " + cboMoneda.Text;
            objNumLetras.SeparadorDecimalSalida = "con";
            objNumLetras.Decimales = 2;
            cMontoLetras = objNumLetras.ToCustomCardinal(nMontoTotal);
        }

        private void btnVincular2_Click(object sender, EventArgs e)
        {
            p_idCta = 0;
            //--btnContinuar2.Enabled = false;
            if (!string.IsNullOrEmpty(txtCtaVin.Text))
            {
                if (Convert.ToInt32(txtCtaVin.Text) > 0)
                {
                    clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(txtCtaVin.Text));
                }
            }

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable tbCliInterviVin = dtInt.Clone();
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                tbCliInterviVin.ImportRow(dtInt.Rows[i]);
            }

            DataSet dsIntervVin = new DataSet("dsDepositoVin");
            dsIntervVin.Tables.Add(tbCliInterviVin);
            string xmlIntervVin = clsCNFormatoXML.EncodingXML(dsIntervVin.GetXml());                     

            //==================================================
            //--Llamar al Formulario
            //==================================================
            frmBusCtaAhoVin frmbuscarCta = new frmBusCtaAhoVin();
            frmbuscarCta.pcXMLInterv = xmlIntervVin;
            frmbuscarCta.idCli = nidCliTit;
            frmbuscarCta.pTipBus = 1;
            frmbuscarCta.nTipOpe = 1;  //--Cuentas para Transferencias
            frmbuscarCta.idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            frmbuscarCta.pnTipoPersona = Convert.ToInt16(cboTipoPersona.SelectedValue);
            frmbuscarCta.ShowDialog();
            if (frmbuscarCta.idCli > 0)
            {
                p_idCta = Convert.ToInt32(frmbuscarCta.pnCta);

                //--===================================================================================
                //--ValidarBloqueo de la Cuenta
                //--===================================================================================
                string cMsg = "";
                clsCNOperacionDep clsBloq = new clsCNOperacionDep();
                if (!clsBloq.ValidarBloqueoCta(p_idCta, 11, ref cMsg))
                {
                    MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //--btnContinuar2.Enabled = false;
                    return;
                }

                txtCtaVin.Text = frmbuscarCta.pnCta;
                txtNroCuenta.Text = frmbuscarCta.pcNroCta;
                txtEstado.Text = frmbuscarCta.pcEstdo;
                txtProdCtaVin.Text = frmbuscarCta.pcProd;               
            }
            else
            {
                txtCtaVin.Text = "";
                txtNroCuenta.Clear();
                txtEstado.Text = "";
                txtProdCtaVin.Text = "";
                return;
            }
            //--btnContinuar2.Enabled = true;
            dsIntervVin.Clear();
            dsIntervVin.Dispose();
            clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
        }

        private void cboEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEnt.SelectedIndex == -1 || cboEnt.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            dt = clsDeposito.ListarCuentaXEntidades(Convert.ToInt32(cboEnt.SelectedValue),Convert.ToInt16(cboMoneda.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            if (dt.Rows.Count>0)
            {
                cboCuenta.SelectedIndex = 0;
            }
            
        }

        private void CargarCtasbancos()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheque Externo
            cboEnt.DataSource = dtEntidad;
            cboEnt.ValueMember = "idEntidad";
            cboEnt.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count>0)
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

        private void cboCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoEnt_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (this.cboTipoEnt.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEnt.SelectedValue);
                cboEnt.CargarEntidades(nTipEnt);
            }
        }

        private void btnBusCheGer_Click(object sender, EventArgs e)
        {
            string idClientes = "";
            string idIntervinientes = "";
            for (int i = 0; i < this.dtInt.Rows.Count; i++)
            {
                idClientes = idClientes + this.dtgIntervinientes.Rows[i].Cells["codigo"].Value.ToString() + ",";
                idIntervinientes = idIntervinientes + this.dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value.ToString() + ",";
            } 
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = idClientes;  //--Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
            frmChequeByCli.idMotOpeBco = 0; // Todos
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text = frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text = frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text = frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
        }

        private void cboEnvioEstCta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDireccionEnvioEstCta.Text = "";

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2) //Envio por Correo
            {
                recuperarDatosCorreo();
                this.txtDireccionEnvioEstCta.Enabled = false;
                txtDireccionEnvioEstCta.KeyPress += txtDireccionEnvioEstCta_KeyPress;
            }
            else
            {
                txtDireccionEnvioEstCta.KeyPress -= txtDireccionEnvioEstCta_KeyPress;
                txtDireccionEnvioEstCta.Text = "";
            }

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 3) //Recojo en Oficina de Crac Lasa
            {
                txtDireccionEnvioEstCta.Enabled = false;
            }
            else if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 1)
            {
                txtDireccionEnvioEstCta.Enabled = true;
            }

            txtDireccionEnvioEstCta.Focus();
        }

        private void recuperarDatosCorreo()
        {
            DataTable tbCliIntervinientes = dtInt.Clone();
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                tbCliIntervinientes.ImportRow(dtInt.Rows[i]);
            }
            
            frmBuscarEmailAhorros frmBuscar = new frmBuscarEmailAhorros(tbCliIntervinientes);
            frmBuscar.ShowDialog();
            string cCorreo = frmBuscar.cCorreoAsignadoPrincipal();
            if (!String.IsNullOrEmpty(cCorreo))
            {
                MessageBox.Show("Se ha recuperado el siguiente correo: " + cCorreo + ".", "Solicitud de Apertura de Cuentas de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccionEnvioEstCta.Text = cCorreo;
            }
            
        }

        private void rbtMismaCta_CheckedChanged(object sender, EventArgs e)
        {
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = true;
            limpiarCalculos();
        }

        private void rbtOtrasCuentas_CheckedChanged(object sender, EventArgs e)
        {
            clsVarApl.dicVarGen["nIsTransfOtroCli"] = false;
            limpiarCalculos();
        }

        private void txtNroDocu_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboModPago.SelectedValue)==5)
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
                this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(9, '0');
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            frmCalculoCTS objCalculoCTS = new frmCalculoCTS(this.txtMonto, this.txtMontoIntang);
            objCalculoCTS.p_idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            objCalculoCTS.ShowDialog();
            calcular();
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
            if (frmOP.pnCta>0)
            {
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

        private void txtDireccionEnvioEstCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue)==2)
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

        private void tabTasa_Enter(object sender, EventArgs e)
        {
            btnContinuar.PerformClick();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            btnContinuar1.PerformClick();
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            btnContinuar2.PerformClick();
        }

        private void btnBusCtasCanc_Click(object sender, EventArgs e)
        {
            if (tbCtasCanceladas.Rows.Count > 0)
            {
                tbCtasCanceladas.Rows.Clear();
            }

            string idClientes = "";
            string idIntervinientes = "";
            for (int i = 0; i < this.dtInt.Rows.Count; i++)
            {
                idClientes = idClientes + this.dtgIntervinientes.Rows[i].Cells["codigo"].Value.ToString() + ",";
                idIntervinientes = idIntervinientes + this.dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value.ToString() + ",";
            }

            frmCtasCanceladasCli frmCtasCli = new frmCtasCanceladasCli();
            frmCtasCli.pc_idCli = idClientes;
            frmCtasCli.ShowDialog();
            DataTable dtTmp = frmCtasCli.p_dtCtascanceladas;
            if (dtTmp.Rows.Count<=0)
            {
                return;
            }
            for (int i = 0; i < dtTmp.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtTmp.Rows[i]["lMarca"]))
                {
                    tbCtasCanceladas.ImportRow(dtTmp.Rows[i]);
                }                
            }
        }

        private void cboOrigenFondos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBusCtasCanc.Enabled = false;

            if (cboOrigenFondos.SelectedIndex<0)
            {
                return;
            }
            
            if (Convert.ToInt16(cboOrigenFondos.SelectedValue)==3) //--Cancelacion de Cuentas
            {
                btnBusCtasCanc.Enabled = true;
            }
        }

        private void txtDireccionEnvioEstCta_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue)==2)
            {
                Regex xrEmail = new Regex(@"^[_A-z0-9-]+(.[_A-z0-9-]+)*@[A-z0-9-]+(.[A-z0-9-]+)*(.[A-z]{2,4})$");

                if (!xrEmail.IsMatch(this.txtDireccionEnvioEstCta.Text) && !String.IsNullOrEmpty(this.txtDireccionEnvioEstCta.Text.Trim()))
                {
                    MessageBox.Show("La texto introducido no tiene el formato de un email ", "Validación de Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtDireccionEnvioEstCta.Focus();
                    return;
                }
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

        private void tabProd_Click(object sender, EventArgs e)
        {

        }

        private void AsignarVariableParametrosProducto()
        {
            //--=====================================================
            //--Cargar parámetros del Producto y Validar
            //--=====================================================
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(Convert.ToInt32(cboSubProducto.SelectedValue.ToString()), Convert.ToInt32(cboMoneda.SelectedValue.ToString()), 2);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                chcITF.Checked = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                chcInactiva.Checked = Convert.ToBoolean(dt.Rows[0]["lIsInactiva"].ToString());
                txtPlaInac.Text = dt.Rows[0]["nPlaInactiva"].ToString();
                chcRenov.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRenovProd"].ToString());
                chcCert.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRequeCert"].ToString());
                //--Asignación de variables Públicas
                lEsTrabFin=Convert.ToBoolean(dt.Rows[0]["lIsTrabFinan"].ToString());
                lEsReqPagInt=Convert.ToBoolean(dt.Rows[0]["lIsReqPagInt"].ToString());
                lEsDefTipPagInt = Convert.ToBoolean(dt.Rows[0]["lIsDefTipPagInt"].ToString());
                lEsReqEmpleador = Convert.ToBoolean(dt.Rows[0]["lIsReqEmpleador"].ToString());
                lEsAhoProg = Convert.ToBoolean(dt.Rows[0]["lIsDepAhoProg"].ToString());
                lEsCtaCTS = Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString());
                p_nMonMinSalDis = Convert.ToDecimal (dt.Rows[0]["nMonMinSalDis"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dt.Rows[0]["lIsDepMenEdad"].ToString());
                lIsPlazoProd = Convert.ToBoolean(dt.Rows[0]["lIsPlazoProd"].ToString());
                lIsRequeCert = Convert.ToBoolean(dt.Rows[0]["lIsRequeCert"].ToString());

                //--Tipo Persona sin Fines de Lucro, no Tiene ITF
                if (Convert.ToInt16(cboTipoPersona.SelectedValue)==3)
	            {
		            chcITF.Checked=false;
                    lEsAfeITF=false;
	            }
                
                //--Para Transferencias de las clientes del cliente. no debe afectar el ITF
                //if (Convert.ToInt16(cboTipoApe.SelectedValue)==2 && rbtMismaCta.Checked)  
                //{
                //    chcITF.Checked = false;
                //    lEsAfeITF = false;
                //}
                
                //--Validar si es Cta para Orden de Pago                
                if (Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))
                {
                    chcOrdPago.Enabled = true;
                }

                //--===============================================================
                //--Validar Plazos
                //--===============================================================
                if (!lEsAhoProg)
                {
                    if (Convert.ToInt16(txtPlazoAho.Text) < Convert.ToInt16(dt.Rows[0]["nPlaMinProd"].ToString()))
                    {
                        MessageBox.Show("El plazo es menor al mínimo permitido: Plazo mínimo: " + dt.Rows[0]["nPlaMinProd"].ToString() + " días", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPlazoAho.Focus();
                        txtPlazoAho.Select();

                        if (tbcApertura.SelectedIndex != 0)
                        {
                            tbcApertura.SelectTab(0);
                        }
                        return;
                    }

                    if (Convert.ToInt16(txtPlazoAho.Text) > Convert.ToInt16(dt.Rows[0]["nPlaMaxProd"].ToString()))
                    {
                        MessageBox.Show("El plazo es mayor al máximo permitido: Plazo máximo: " + dt.Rows[0]["nPlaMaxProd"].ToString() + " días", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPlazoAho.Focus();
                        txtPlazoAho.Select();

                        if (tbcApertura.SelectedIndex != 0)
                        {
                            tbcApertura.SelectTab(0);
                        }
                        return;
                    }
                }
                if (lIsDepMenEdad)
                {
                        txtNroFir.Text = "2";
                        txtNroFir.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                if (tbcApertura.SelectedIndex != 0)
                {
                    tbcApertura.SelectTab(0);
                }
                return;
            }
        }
            

                
            }   
        }
    

