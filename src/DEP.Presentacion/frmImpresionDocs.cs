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
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using ADM.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmImpresionDocs : frmBase
    {
       
        #region Variable Globales
        private bool lIndValorados = false;
        private int p_idCta=0, idTipOpe, idEstado;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNImpresion clsImpresion = new clsCNImpresion();
        clsCNListaFormatoImp ListaFormato = new clsCNListaFormatoImp();
        DataTable dtValorados= new DataTable();
        clsCNValorados objValorados = new clsCNValorados();
        clsNumLetras objNumLetras = new clsNumLetras();
        private int idTipoImpresion = 0;
        decimal nMontoDeposito = 0;
        DataTable dtFormatos = new DataTable();
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        DataTable tbDepMen = null;
        //private DataTable dtValImp = new DataTable();
        private DataTable dtbNumCuentas;
        string cMontoLetras;
        int nProdAbonoMensualDB = 0;
        DataTable dtProdMensualDB = new DataTable();
        private string cIdCampania;
        private string cFechaFinAhoCre;

        #endregion
        #region Constructor
        public frmImpresionDocs()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmReimpresionCertificado_Load(object sender, EventArgs e)
        {
            idTipOpe = 16;
            conBusCtaAho.nTipOpe = idTipOpe;
            conBusCtaAho.pnIdMon = 0;  //Para Cancelación no es necesario la moneda, debe listar todas las Cuentas.
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.idcuenta = 0;
            llenarTiposDeDocumento();
            dtgIntervinientes.AutoGenerateColumns = false;
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();

            tbDepMen = formatoDepositoMensual();

            dtProdMensualDB = clsDeposito.CNCartillaDPFAbonoM();
            if (dtProdMensualDB.Rows.Count > 0)
            {
                nProdAbonoMensualDB = Convert.ToInt32(dtProdMensualDB.Rows[0]["cValVar"].ToString());
            }
        }
   
        private DataTable formatoDepositoMensual()
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
        private void conBusCtaAho1_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && conBusCtaAho.idcuenta>0)
            {                
                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                if (Convert.ToInt32(p_idCta)>0)
                {
                    this.DatosCuenta();              
                }
            }
            else
            {
                this.conBusCtaAho.txtNroCta.Focus();
            }
        }
        public string CharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private string ImporteInteresTotal(DataTable dtcertificado_)
        {
            string cImporteInteresTotal = "";

            //--=====================================================
            //--Cargar parámetros del Producto y Validar
            //--=====================================================

            Decimal nTasa = Convert.ToDecimal(dtcertificado_.Rows[0]["nMonTasa"].ToString());
            Decimal nMonto = Convert.ToDecimal(dtcertificado_.Rows[0]["nMontoDeposito"].ToString());
            int nPlazo = Convert.ToInt32(dtcertificado_.Rows[0]["nPlazoCta"].ToString());

            DateTime dtpFechaApe = Convert.ToDateTime(dtcertificado_.Rows[0]["dFechaApertura"].ToString());

            bool lEsAfeItf = false;
            int nTipCalInt = 0;
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(Convert.ToInt32(dtcertificado_.Rows[0]["idProducto"].ToString()), Convert.ToInt32(dtcertificado_.Rows[0]["idMoneda"].ToString()), 2);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                lEsAfeItf = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                nTipCalInt = Convert.ToInt32(dt.Rows[0]["nTipCalInt"].ToString());
            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //return;
            }
            clsCNCalculosAho nInteres = new clsCNCalculosAho();

            Decimal nMonInteres = 0.00m, nMonIntEsp = 0.00m, nMonFavCli = 0.00m;

            switch (Convert.ToInt32(dtcertificado_.Rows[0]["idPagoInt"].ToString()))
            {
                case 1: //--PAGO EN LA APERTURA

                    nMonIntEsp = nInteres.CalcularIntAdelantado(nTasa, nPlazo, nMonto);
                    //lblint.Visible = true;
                    //lblint.Text = "Interes Adelantado";
                    //txtIntEspecial.Visible = true;
                    //nMonIntEsp = FunTruncar.redondearBCR(nMonIntEsp, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    nMonInteres = nMonIntEsp;
                    //txtIntEspecial.Text = TipoMoneda() + String.Format("{0:0.00}", nMonIntEsp);
                    tbDepMen.Clear();
                    break;
                case 2: //--AL CANCELAR LA CUENTA                    
                    nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    tbDepMen.Clear();
                    break;
                case 3:  //--MENSUALMENTE
                    tbDepMen = nInteres.CalculaPpgDepMensual(nMonto, dtpFechaApe, nPlazo, nTasa);
                    object sumObject;
                    sumObject = tbDepMen.Compute("Sum(interes)", "");
                    nMonInteres = Math.Round(Convert.ToDecimal(sumObject), 2);
                    //nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    nMonIntEsp = nInteres.CalcularInteresAho(nTasa, 30, nMonto, nTipCalInt);
                    //lblint.Visible = true;
                    //lblint.Text = "Interes Mensual (Calculado a 30 Días)";
                    //txtIntEspecial.Visible = true;
                    //nMonIntEsp = FunTruncar.redondearBCR(nMonIntEsp, ref nMonFavCli, Convert.ToInt32(cboMoneda.SelectedValue), true, true);
                    //txtIntEspecial.Text = TipoMoneda() + String.Format("{0:0.00}", nMonIntEsp);
                    tbDepMen.Clear();
                    break;
                default: //--Ahorro Corriente y CTS
                    nMonInteres = nInteres.CalcularInteresAho(nTasa, nPlazo, nMonto, nTipCalInt);
                    tbDepMen.Clear();
                    //lblint.Visible = false;
                    //txtIntEspecial.Visible = false;
                    break;
            }

            //this.txtIntGan.Text = TipoMoneda() + String.Format("{0:0.00}", nMonInteres);
            string cMonedaC_ = "$ ";
            if (Convert.ToInt32(dtcertificado_.Rows[0]["idmoneda"].ToString()) == 1)
            {
                cMonedaC_ = "S/ ";
            }

            //cImporteInteresTotal = cMonedaC_ + String.Format("{0:0.00}", nMonInteres);
            cImporteInteresTotal = cMonedaC_ + Convert.ToDecimal(String.Format("{0:0.00}", nMonInteres)).ToString("N2");
            //------------------------CAMBIO FIN

            return cImporteInteresTotal; 
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        { 
            /******************** Convierte a partir de si_finVaribale->nIdProdCampania ***************************/
            cIdCampania = clsVarApl.dicVarGen["nIdProdCampania"];
           
            String[] cArrayIdCampania;
           
            int[] nArrayIdCampania;
            cArrayIdCampania = cIdCampania.Split(',');
            nArrayIdCampania = Array.ConvertAll<string, int>(cArrayIdCampania, int.Parse);
            
            DataTable dtResultado = (clsDeposito.CNRetornaFechaFin());
            string cFechaFin = Convert.ToString(dtResultado.Rows[0]["cFechaFin"]);
            cFechaFinAhoCre = cFechaFin;
            
            /****************************************************************************************************/
            
            int fila = 0;
            bool lIndImpre = false;
            
            //Validando
            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtFormatos.Rows[i]["lCheck"]))
                {
                    lIndImpre = true;

                    break;
                }
            } 
            if (!lIndImpre)
            {
                MessageBox.Show("Debe de seleccionar al menos un formato a imprimir","Validación de reimpresión",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                int idTipImpresion = Convert.ToInt32(dtFormatos.Rows[i]["idTipDocImp"]);

                ConverNumLetras(Convert.ToDecimal (nMontoDeposito));

                clsCodigoBarra Funcion = new clsCodigoBarra();
                DataTable dtcertificado = new clsRPTCNDeposito().CNRetornaDatosCerti(p_idCta, true);
                DataTable dtIntervs = new clsRPTCNDeposito().CNRetornaDatosInterv(p_idCta);
                DataTable dtIntervsDetalle = new clsRPTCNDeposito().CNRetornaDatosIntervDetalle(p_idCta);
                DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();

                clsCNProducto cnProducto = new clsCNProducto();
                string cImpPagoIntTotal = "";
                

                switch (idTipImpresion)
                {
                    case 1://Impresion de Certificado

                        if ((bool)dtFormatos.Rows[fila]["lCheck"] == true)
                        {
                            //---------
                            int idProducto = Convert.ToInt32(dtcertificado.Rows[0]["idProducto"]);
                            int idProductoPadre = 0;
                            DataTable dtProductos = cnProducto.CNListaNivelesSupProductos(2, idProducto);

                            idProductoPadre = Convert.ToInt32(dtProductos.Rows[0]["IdProducto"]);

                            //--- Cartilla PDF Abono Mensual ini
                            if (idProductoPadre == 48 && idProducto.In(nArrayIdCampania))
                            {
                                cImpPagoIntTotal = ImporteInteresTotal(dtcertificado);
                                //cInteresC = cImpPagoIntTotal;
                            }
                            //--- Cartilla PDF Abono Mensual fin

                            //---------

                            dtcertificado.Columns["nMontoDeposito"].ReadOnly = false;
                            dtcertificado.Columns["nMontasa"].ReadOnly = false;
                            dtcertificado.Columns["cInteres"].ReadOnly = false;
                            
                            dtcertificado.Columns.Add("bCodBar", typeof(Byte[]));
                            dtcertificado.Columns["bCodBar"].ReadOnly = false;

                            string x_nMontoDeposito = "";
                            string cInteresC = "";
                            if (dtcertificado.Rows.Count > 0)
                            {
                                string cNroCuenta = dtcertificado.Rows[0]["cNroCuenta"].ToString();
                                x_nMontoDeposito = Convert.ToDecimal(dtcertificado.Rows[0]["nMontoDeposito"]).ToString("N2");                                

                                //dtcertificado.Rows[0]["nMontoDeposito"]= cadenaMonto;
                                dtcertificado.Rows[0]["nMonTasa"] = Convert.ToDecimal(dtcertificado.Rows[0]["nMonTasa"]).ToString("N2");

                                string cMonedaC = "$ ";
                                if (Convert.ToInt32(dtcertificado.Rows[0]["idmoneda"].ToString()) == 1)
                                {
                                    cMonedaC = "S/ ";
                                }

                                cInteresC = dtcertificado.Rows[0]["cInteres"].ToString();
                                if (char.IsDigit(cInteresC[0]))
                                {
                                    cInteresC = cMonedaC + Convert.ToDecimal(cInteresC).ToString("N2");
                                }
                                
                                dtcertificado.Rows[0]["cInteres"] = cInteresC;
                                
                                dtcertificado.Rows[0]["bCodBar"] = Funcion.Convert(cNroCuenta);
                            }

                            List<ReportParameter> paramlist = new List<ReportParameter>();
                            paramlist.Clear();
                            paramlist.Add(new ReportParameter("x_idCuenta", p_idCta.ToString(), false));
                            paramlist.Add(new ReportParameter("x_cMontoLetras", CharToUpper(cMontoLetras), false));
                            paramlist.Add(new ReportParameter("x_nMontoDeposito", x_nMontoDeposito, false));

                            //--- Cartilla PDF Abono Mensual ini
                            if (idProductoPadre == 48 && idProducto.In(nArrayIdCampania))
                            {
                                cInteresC = cImpPagoIntTotal;
                            }
                            //--- Cartilla PDF Abono Mensual fin

                            paramlist.Add(new ReportParameter("x_cInteres", cInteresC, false));

                            List<ReportDataSource> dtslist = new List<ReportDataSource>();
                            dtslist.Clear();

                            dtslist.Add(new ReportDataSource("dtsPlazoFIjo", dtcertificado));

                            string reportpath = "rptConstanciaPlazoFijo.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();

                            lIndImpre = true;
                            //--========================================================================================
                            //Registro de la Operacion de reimpresión
                            //--========================================================================================
                            int idKardex = 0;
                            int nNumImpresion = Convert.ToInt32(this.txtNroImpresiones.Text.ToString().Trim()) + 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
                        }

                        fila++;
                        break;

                    case 2://Impresión de la Cartilla
                       
                        if ((bool)dtFormatos.Rows[fila]["lCheck"] == true)
                        {
                            DataTable dtDatosTitulares = new DataTable();
                            //-------------

                            dtcertificado.Columns["nMontoDeposito"].ReadOnly = false;
                            dtcertificado.Columns["nMontasa"].ReadOnly = false;
                            dtcertificado.Columns["cInteres"].ReadOnly = false;

                            dtcertificado.Columns.Add("bCodBar", typeof(Byte[]));
                            dtcertificado.Columns["bCodBar"].ReadOnly = false;

                            string x_nMontoDeposito = "";
                            string cInteresC = "";
                            if (dtcertificado.Rows.Count > 0)
                            {
                                string cNroCuenta = dtcertificado.Rows[0]["cNroCuenta"].ToString();
                                x_nMontoDeposito = Convert.ToDecimal(dtcertificado.Rows[0]["nMontoDeposito"]).ToString("N2");

                                //dtcertificado.Rows[0]["nMontoDeposito"]= cadenaMonto;
                                dtcertificado.Rows[0]["nMonTasa"] = Convert.ToDecimal(dtcertificado.Rows[0]["nMonTasa"]).ToString("N2");

                                string cMonedaC = "$ ";
                                if (Convert.ToInt32(dtcertificado.Rows[0]["idmoneda"].ToString()) == 1)
                                {
                                    cMonedaC = "S/ ";
                                }

                                cInteresC = dtcertificado.Rows[0]["cInteres"].ToString();
                                if (char.IsDigit(cInteresC[0]))
                                {
                                    cInteresC = cMonedaC + Convert.ToDecimal(cInteresC).ToString("N2");
                                }

                                dtcertificado.Rows[0]["cInteres"] = cInteresC;

                                dtcertificado.Rows[0]["bCodBar"] = Funcion.Convert(cNroCuenta);
                            }
                            //--

                            string cTitulares = "";
                                
                            if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString()) == 1)
                            {
                                dtDatosTitulares = clsDeposito.CNRetornaDatosIntervRegFirmas(p_idCta);
                                 for (int c = 0; c < dtDatosTitulares.Rows.Count; c++)
                                {
                                    cTitulares += dtDatosTitulares.Rows[c]["cNombre"].ToString();
                                    if (c != dtDatosTitulares.Rows.Count - 1)
                                    {
                                        cTitulares += " / ";
                                    }
                                }

                            }
                            else
                            {
                                cTitulares = dtcertificado.Rows[0]["cNombrePrincipal"].ToString();
                            }

                            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
                            int idProdAC = Convert.ToInt32(clsVarApl.dicVarGen["nIdProdAhorroCrecer"]);
                            int idProducto = Convert.ToInt32(dtcertificado.Rows[0]["idProducto"]);
                            int idProductoPadre = 0;
                            DataTable dtProductos = cnProducto.CNListaNivelesSupProductos(2, idProducto);

                            idProductoPadre = Convert.ToInt32(dtProductos.Rows[0]["IdProducto"]);
                            
                            //--- Cartilla PDF Abono Mensual ini
                            if (idProductoPadre == 48 && idProducto.In(nArrayIdCampania))
                            {
                                cImpPagoIntTotal = ImporteInteresTotal(dtcertificado);
                                //cInteresC = cImpPagoIntTotal;
                            }
                            //--- Cartilla PDF Abono Mensual fin

                            string cDuplicado = Convert.ToString(dtcertificado.Rows[0]["cDuplicado"]);
                           
                            List<ReportParameter> paramlistCart = new List<ReportParameter>();
                            paramlistCart.Clear();

                            string x_nMonTasa = "";
                            if (dtcertificado.Rows.Count > 0)
                            {
                                x_nMonTasa = Convert.ToDecimal(dtcertificado.Rows[0]["nMonTasa"]).ToString("N2");
                            }
                            
                            paramlistCart.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlistCart.Add(new ReportParameter("x_idCuenta", p_idCta.ToString(), false));
                            paramlistCart.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyy") , false));
                            paramlistCart.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                            paramlistCart.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
                            paramlistCart.Add(new ReportParameter("x_nMonTasa", x_nMonTasa, false));
                            paramlistCart.Add(new ReportParameter("x_cTitulares", cTitulares, false));
                            paramlistCart.Add(new ReportParameter("x_cInteres", cInteresC, false));
                            paramlistCart.Add(new ReportParameter("dFechaSalidaImpContratos", clsVarApl.dicVarGen["dFechaSalidaImpContratos"].ToString(), false));
                            
                            List<ReportDataSource> dtslistCart = new List<ReportDataSource>();
                            dtslistCart.Clear();
                            dtslistCart.Add(new ReportDataSource("dtsCartilla", dtcertificado));
                            dtslistCart.Add(new ReportDataSource("dtVariables", dtVariable));
                            
                            string reportpathCart = "rptCartillaInfor.rdlc";
                            switch (idProductoPadre)
                            {
                                case 49:
                                    paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                    dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                    dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));


                                    reportpathCart = "rptCartillaInforCTS.rdlc";
                                    break;
                                case 48: //Plazo Fijo
                                    if (idProducto.In(nArrayIdCampania)) // Plazo Fijo Abono Mensual
                                    { 
                                        paramlistCart.Add(new ReportParameter("x_cImpPagoInteresAM", cImpPagoIntTotal, false));
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                        dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));
                                        reportpathCart = "rptCartillaInforPlazoFijoAM.rdlc"; 
                                    }
                                    else
                                    {
                                        paramlistCart.Add(new ReportParameter("cNombreProducto", dtcertificado.Rows[0]["cProducto"].ToString(), false));
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                        dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));
                                        reportpathCart = "rptCartillaInforPlazoFijo.rdlc";
                                    }
                                    break;
                                case 47:
                                  
                                    if (idProducto == idProdAC)
                                    
                                    {
                                            paramlistCart.Add(new ReportParameter("x_cFechaFinAhoCre", cFechaFinAhoCre, false));
                                            reportpathCart = "rptCartillaInforNormalCrecer.rdlc";
                                            break;
                                    }
                                   
                                    else
                                    
                                    {
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                        dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));
                                        reportpathCart = "rptCartillaInforNormal.rdlc";
                                        break;
                                    }
                                default:
                                    reportpathCart = "rptCartillaInfor.rdlc";
                                    break;
                            }
                            new frmReporteLocal(dtslistCart, reportpathCart, paramlistCart, false).ShowDialog();
                            lIndImpre = true;

                            int idKardex = 0;
                            int nNumImpresion = Convert.ToInt32(this.txtNroImpresiones.Text.ToString().Trim()) + 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
                        }

                        fila++;
                        break;
                    case 3://--Constancia de CTS    
                        if ((bool)dtFormatos.Rows[fila]["lCheck"] == true)
                        {

                        }
                        fila++;
                        break;

                    case 6://Registro de Firmas

                        if ((bool)dtFormatos.Rows[fila]["lCheck"] == true)
                        {
                            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
                           
                            if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString()) == 1)
                            {
                                
                                DataTable dtDatosCuentaRF = clsDeposito.CNRetornaDatosCuentaRegFirmas(p_idCta);
                                List<ReportParameter> paramlistCart = new List<ReportParameter>();
                                paramlistCart.Clear();
                                
                                paramlistCart.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                                paramlistCart.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                                paramlistCart.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                                paramlistCart.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));

                                paramlistCart.Add(new ReportParameter("cNroCuenta", dtDatosCuentaRF.Rows[0]["cNroCuenta"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("dFechaReg", dtDatosCuentaRF.Rows[0]["dFechaApertura"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("cNombreAgencia", dtDatosCuentaRF.Rows[0]["cNombreAgencia"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("nExpres", "0", false));
                                paramlistCart.Add(new ReportParameter("nDias", dtDatosCuentaRF.Rows[0]["nPlazoCta"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("cNombreProducto", dtDatosCuentaRF.Rows[0]["cProducto"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("idTipoProducto", dtDatosCuentaRF.Rows[0]["idTipoProducto"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("idMoneda", dtDatosCuentaRF.Rows[0]["idMoneda"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("nMontoDeposito", Convert.ToDecimal(dtDatosCuentaRF.Rows[0]["nMontoDeposito"]).ToString("N2"), false));
                                paramlistCart.Add(new ReportParameter("idTipoCuenta", dtDatosCuentaRF.Rows[0]["idTipoCuenta"].ToString(), false));

                                DataTable dtDatosClienteRF = clsDeposito.CNRetornaDatosIntervRegFirmas(p_idCta);
                                
                                List<ReportDataSource> dtslistCart = new List<ReportDataSource>();
                                dtslistCart.Clear();

                                dtDatosClienteRF.Columns["cDepartamento"].ReadOnly = false;
                                dtDatosClienteRF.Columns["cProvincia"].ReadOnly = false;
                                dtDatosClienteRF.Columns["cDistrito"].ReadOnly = false;

                                for (int c = 0; c < dtDatosClienteRF.Rows.Count; c++)
                                {
                                    string[] stArr = dtDatosClienteRF.Rows[c]["cUbigeo"].ToString().Split('/');
                                    
                                    dtDatosClienteRF.Rows[c].SetField("cDepartamento", stArr[1]);
                                    dtDatosClienteRF.Rows[c].SetField("cProvincia", stArr[2]);
                                    dtDatosClienteRF.Rows[c].SetField("cDistrito", stArr[3]);
                                    
                                }
                                    dtslistCart.Add(new ReportDataSource("DatosCliente", dtDatosClienteRF));

                                string reportpathCart = "rptRegistroFirmasPN.rdlc";
                                new frmReporteLocal(dtslistCart, reportpathCart, paramlistCart, false).ShowDialog();
                            }
                            else
                            {
                                //REGISTRO DE FIRMAS PERSONA JURIDICA
                                DataTable dtDatosCuentaRF = clsDeposito.CNRetornaDatosCuentaRegFirmas(p_idCta);
                                List<ReportParameter> paramlistCart = new List<ReportParameter>();
                                paramlistCart.Clear();

                                paramlistCart.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                                paramlistCart.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                                paramlistCart.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                                paramlistCart.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));

                                paramlistCart.Add(new ReportParameter("cNroCuenta", dtDatosCuentaRF.Rows[0]["cNroCuenta"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("dFechaReg", dtDatosCuentaRF.Rows[0]["dFechaApertura"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("cNombreAgencia", dtDatosCuentaRF.Rows[0]["cNombreAgencia"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("nExpres", "0", false));
                                paramlistCart.Add(new ReportParameter("nDias", dtDatosCuentaRF.Rows[0]["nPlazoCta"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("cNombreProducto", dtDatosCuentaRF.Rows[0]["cProducto"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("idTipoProducto", dtDatosCuentaRF.Rows[0]["idTipoProducto"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("idMoneda", dtDatosCuentaRF.Rows[0]["idMoneda"].ToString(), false));
                                paramlistCart.Add(new ReportParameter("nMontoDeposito", Convert.ToDecimal(dtDatosCuentaRF.Rows[0]["nMontoDeposito"]).ToString("N2"), false));
                                paramlistCart.Add(new ReportParameter("idTipoCuenta", dtDatosCuentaRF.Rows[0]["idTipoCuenta"].ToString(), false));


                                //////
                                DataTable dtDatosClientePJRF = clsDeposito.CNRetornaDatosIntervRegFirmasPJ(p_idCta);

                                List<ReportDataSource> dtslistCart = new List<ReportDataSource>();
                                dtslistCart.Clear();

                                dtDatosClientePJRF.Columns["cDepartamento"].ReadOnly = false;
                                dtDatosClientePJRF.Columns["cProvincia"].ReadOnly = false;
                                dtDatosClientePJRF.Columns["cDistrito"].ReadOnly = false;

                                for (int c = 0; c < dtDatosClientePJRF.Rows.Count; c++)
                                {
                                    string[] stArr = dtDatosClientePJRF.Rows[c]["cUbigeo"].ToString().Split('/');

                                    dtDatosClientePJRF.Rows[c].SetField("cDepartamento", stArr[1]);
                                    dtDatosClientePJRF.Rows[c].SetField("cProvincia", stArr[2]);
                                    dtDatosClientePJRF.Rows[c].SetField("cDistrito", stArr[3]);

                                }
                                //////

                                DataTable dtDatosClienteRF = clsDeposito.CNRetornaDatosIntervRegFirmas(p_idCta);

                                dtDatosClienteRF.Columns["cDepartamento"].ReadOnly = false;
                                dtDatosClienteRF.Columns["cProvincia"].ReadOnly = false;
                                dtDatosClienteRF.Columns["cDistrito"].ReadOnly = false;

                                for (int c = 0; c < dtDatosClienteRF.Rows.Count; c++)
                                {
                                    string[] stArr = dtDatosClienteRF.Rows[c]["cUbigeo"].ToString().Split('/');

                                    dtDatosClienteRF.Rows[c].SetField("cDepartamento", stArr[1]);
                                    dtDatosClienteRF.Rows[c].SetField("cProvincia", stArr[2]);
                                    dtDatosClienteRF.Rows[c].SetField("cDistrito", stArr[3]);

                                }
                                dtslistCart.Add(new ReportDataSource("DatoRepresentante", dtDatosClienteRF));
                                dtslistCart.Add(new ReportDataSource("DatoCliente", dtDatosClientePJRF));

                                string reportpathCart = "rptRegistroFirmasPJ.rdlc";
                                new frmReporteLocal(dtslistCart, reportpathCart, paramlistCart, false).ShowDialog();
                            }

                            ///////////////////////////
                            lIndImpre = true;

                            int idKardex = 0;
                            int nNumImpresion = Convert.ToInt32(this.txtNroImpresiones.Text.ToString().Trim()) + 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
                        }

                        fila++;
                        break;
                }
            }

            btnImprimir.Enabled = false;
            btnCancelar.Enabled = true;
        }
 
       
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            this.conBusCtaAho.HabDeshabilitarCtrl(true);
            this.conBusCtaAho.btnBusCliente.Enabled = true;
            this.conBusCtaAho.txtCodAge.Focus();
            txtNroFolio.Enabled = false;
            btnVincular.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnCancelar.Enabled = false;
            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                dtFormatos.Rows[i]["lCheck"] = false;
            }

            conAutorizacionUsuDatos1.limpiar();
        }

               
        #endregion
        #region Metodos
        private void LimpiarControles()
        {
            p_idCta = 0;
            dtValorados.Rows.Clear();
            idTipoImpresion = 0;
            this.conBusCtaAho.LimpiarControles();
            if (dtgIntervinientes.Rows.Count > 0)
            {

                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();

            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                dtFormatos.Rows[i]["lCheck"] = false;
            } 

            this.txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            txtNroImpresiones.Text = "0";
            txtNroMaxFolio.Clear();
            txtCodCertificado.Text = "";
            txtNroFolio.Text="";
            txtEstadoCta.Clear();
        }

        private void llenarTiposDeDocumento()
        {            
            DataTable dt = ListaFormato.CNListaFormato();            

            dtFormatos.Columns.Add("lCheck", typeof(bool));
            dtFormatos.Columns.Add("idTipDocImp", typeof(int));
            dtFormatos.Columns.Add("cDescripcion", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow dr = dtFormatos.NewRow();
                dr["lCheck"] = false;
                dr["idTipDocImp"] = Convert.ToInt32(dt.Rows[i]["idTipDocImp"]);
                dr["cDescripcion"] = dt.Rows[i]["cDescripcion"].ToString();
                dtFormatos.Rows.Add(dr);
            }

            dtgFormatos.DataSource = dtFormatos;


            dtgFormatos.Columns["idTipDocImp"].Visible = false;
            dtgFormatos.Columns["lCheck"].Width = 35;
            dtgFormatos.Columns["lCheck"].HeaderText = "Chk";
            dtgFormatos.Columns["lCheck"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFormatos.Columns["cDescripcion"].HeaderText = "Formatos";
            dtgFormatos.Columns["cDescripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void AsignarValImp(bool lIndCerti, bool lIndCartilla, bool lIndOrdDep, bool lisCtaCTS)
        {
            for (int i = 0; i < dtgFormatos.Rows.Count; i++)
            {
                int idTipDoc = Convert.ToInt32(dtFormatos.Rows[i]["idTipDocImp"].ToString());
                switch (idTipDoc)
                {
                    
                    case 1: //--Certificado de Deposito.

                        if (lIndCerti)
                        {
                            dtFormatos.Rows[i]["lCheck"] = false;
                        }
                        break;


                    case 2: //--Cartilla
                        if (lIndCartilla)
                        {
                            dtFormatos.Rows[i]["lCheck"] = true;
                        }
                        break;



                    case 4: //--Orden de Apertura.
                        if (lIndOrdDep)
                        {
                            dtFormatos.Rows[i]["lCheck"] = true;
                        }
                        break;

                    case 6: //--Registro de Firmas
                        if (true)
                        {
                            dtFormatos.Rows[i]["lCheck"] = false;
                        }
                        break;
                }
            }
        }

        private void ConverNumLetras(Decimal nMontoTotal)
        {
            objNumLetras.LetraCapital = true;
            objNumLetras.MascaraSalidaDecimal = "/100 " + cboMoneda.Text;
            objNumLetras.SeparadorDecimalSalida = "con";
            objNumLetras.Decimales = 2;
            cMontoLetras = objNumLetras.ToCustomCardinal(nMontoTotal);
        }

        private void LimpiarPreliminar()
        {
            txtNroFolio.Enabled = true;
            btnVincular.Enabled = true;
            txtCodCertificado.Text = "";
            txtNroFolio.Text = "";
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();

            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                dtFormatos.Rows[i]["lCheck"] = false;
            } 
        }


        private void DatosCuenta()
        {
            LimpiarPreliminar();
            txtNroFolio.Enabled = true;
            btnVincular.Enabled = true;
            txtCodCertificado.Text = "";
            txtNroFolio.Text = "";
            txtNroMaxFolio.Clear();
            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(p_idCta, "1", idTipOpe);
            if (dtbNumCuentas.Rows.Count >0)
            {
                //---------------------------------------------------------------------------
                //------Validar el Estado de la Cuenta
                //---------------------------------------------------------------------------
                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idEstado"]) == 4)
                {
                    MessageBox.Show("La Cuenta se Encuentra en Estado Pre Solicitado, No puede Imprimir...", "Impresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNroFolio.Enabled = false;
                    btnVincular.Enabled = false;
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--==================================================================================
                //--Datos generales de la Cuenta
                //--==================================================================================
                this.txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                this.cboMoneda.SelectedValue = dtbNumCuentas.Rows[0]["idMoneda"].ToString();
                this.cboTipoCuenta1.SelectedValue = dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString();
                nMontoDeposito = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString());
                this.dtpCorto1.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]);
                this.txtEstadoCta.Text = dtbNumCuentas.Rows[0]["cEstado"].ToString();
                bool lIsRequeCert = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsRequeCert"]);
                bool lisCtaCTS = false; //Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsProdCTS"]);--Solo se debe imprimir la Cartilla en caso de CTS
                AsignarValImp(lIsRequeCert, true, false,lisCtaCTS);

                //--==================================================================================
                //--Retorna Nro de Impresiones
                //--==================================================================================
                DataTable dtNumImpresion = clsImpresion.CNRetornaNumImpresion(p_idCta, clsVarGlobal.idModulo);
                if (string.IsNullOrEmpty(dtNumImpresion.Rows[0]["nNumImpresion"].ToString()))
                {
                    txtNroImpresiones.Text = "0";
                }
                else
                {
                    txtNroImpresiones.Text = dtNumImpresion.Rows[0]["nNumImpresion"].ToString();
                }

                //--==================================================================================
                //--Retorna Nro Folio Máximo de PF en al agencia --ENTREGADO
                //--==================================================================================
                if (lIsRequeCert)
                {
                    DataTable dtNroMaxFolPF = clsImpresion.CNRetornaMaxFolioPFAge(clsVarGlobal.nIdAgencia);
                    if (!string.IsNullOrEmpty(dtNroMaxFolPF.Rows[0]["nMaxFolioEntreg"].ToString()))
                    {
                        txtNroMaxFolio.Text = dtNroMaxFolPF.Rows[0]["nMaxFolioEntreg"].ToString();
                    }
                }
                
                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(p_idCta);
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    ValidarAutrizacionUsoDatos();
                }
                else
                {
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNroFolio.Enabled = false;
                    btnVincular.Enabled = false;
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    clsDeposito.CNUpdNoUsoCuenta(p_idCta);
                    return;
                }
                int lVal = 0;
                //--==================================================================================
                //--Validar si ya Tiene Certificado
                //--==================================================================================
                if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNumeCertificado"])>0)
	            {
                    txtCodCertificado.Text = dtbNumCuentas.Rows[0]["nNumeCertificado"].ToString();
                    if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNroFolio"])>0)
                    {
                        lVal = 1;
                        txtNroFolio.Text = dtbNumCuentas.Rows[0]["nNroFolio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Folio no Existe, Inconsistencia de datos...Por Favor Revisar", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarControles();
                        conBusCtaAho.LimpiarControles();
                        txtNroFolio.Enabled = false;
                        btnVincular.Enabled = false;
                        this.btnImprimir.Enabled = false;
                        this.btnCancelar.Enabled = false;
                        this.conBusCtaAho.btnBusCliente.Enabled = true;
                        conBusCtaAho.HabDeshabilitarCtrl(true);
                        this.conBusCtaAho.txtCodAge.Focus();
                        return;
                    }
	            }
                                                    
                //--==================================================================================
                //--Se debe Definir si se va Imprimir la Constancia o No
                //--==================================================================================
                if (lIsRequeCert)
                {
                    if (lVal == 1)
                    {
                        txtNroFolio.Enabled = false;
                        btnVincular.Enabled = false;
                        if (string.IsNullOrEmpty(dtNumImpresion.Rows[0]["nNumImpresion"].ToString()))
                        {
                            btnImprimir.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Los Documentos ya Fueron Impresos, si requiere otras copias, debe solicitar la Reimpresión", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNroFolio.Enabled = false;
                            btnVincular.Enabled = false;
                            btnImprimir.Enabled = false;
                        }
                    }
                    else
                    {
                        txtNroFolio.Enabled = true;
                        btnVincular.Enabled = true;
                        txtNroFolio.Focus();
                    }
                }
                else
                {
                    txtNroFolio.Enabled = false;
                    btnVincular.Enabled = false;
                    if (string.IsNullOrEmpty(dtNumImpresion.Rows[0]["nNumImpresion"].ToString()))
                    {
                        btnImprimir.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Los Documentos ya Fueron Impresos, si requiere otras copias, debe solicitar la Reimpresión", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroFolio.Enabled = false;
                        btnVincular.Enabled = false;
                        btnImprimir.Enabled = false;
                    }
                }
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Número de Cuenta no Válido para Reimpresión de Formatos", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                txtNroFolio.Enabled = false;
                btnVincular.Enabled = false;
                this.btnImprimir.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
                return;
            }
            conBusCtaAho.HabDeshabilitarCtrl(false);
            AutorizacionUsoDatos(0);
        }
         
        //==========================================================
        //--Establecer valores autorizacion de datos del cliente
        //==========================================================
        private async void AutorizacionUsoDatos(int nNumSolicitud)
        {
            #region Autorizaciones de uso de datos
            /*========================================================================================
            * VALIDACION DE AUTORIZACION DE USO DE DATOS
            ========================================================================================*/
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                var dtbIntervCta = ((DataTable)dtgIntervinientes.DataSource);

                if (conBusCtaAho.nidTipoPersona == 1)
                { 
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.cCodCliente = "";
                        conAutorizacionUsuDatos1.idSolicitud = 0;
                        conAutorizacionUsuDatos1.pcNombre = titular.Field<string>("cNombre");
                        conAutorizacionUsuDatos1.pIdTipoPersona = titular.Field<int>("IdTipoPersona");
                        conAutorizacionUsuDatos1.pcDocumentoID = titular.Field<string>("cDocumentoID");
                        conAutorizacionUsuDatos1.pcDireccion = titular.Field<string>("cDireccion");
                        conAutorizacionUsuDatos1.pcTelefono = titular.Field<string>("cTelefono");

                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
 
                    }
                }
                else
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 7 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.cCodCliente = "";
                        conAutorizacionUsuDatos1.idSolicitud = 0;
                        conAutorizacionUsuDatos1.pcNombre = titular.Field<string>("cNombre");
                        conAutorizacionUsuDatos1.pIdTipoPersona = titular.Field<int>("IdTipoPersona");
                        conAutorizacionUsuDatos1.pcDocumentoID = titular.Field<string>("cDocumentoID");
                        conAutorizacionUsuDatos1.pcDireccion = titular.Field<string>("cDireccion");
                        conAutorizacionUsuDatos1.pcTelefono = titular.Field<string>("cTelefono");

                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
 
                    }
                }

            }

            #endregion
        }

        #endregion
        


        private void rbtnCronograma_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
        }

        private void frmReimpresionDocs_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            btnImprimir.Enabled = false;
            if (string.IsNullOrEmpty(txtNroFolio.Text))
            {
                MessageBox.Show("Debe Ingresar el Número de Folio del Certificado a Vincular", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroFolio.Focus();
                return;
            }
            if (Convert.ToInt32(txtNroFolio.Text)<=0)
            {
                MessageBox.Show("El Número de Folio Ingresasado no es Válido", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroFolio.Focus();
                return;
            }
            var Msg = MessageBox.Show("Esta Seguro de Vincular con dicho Folio del Certificado?...", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            int nNroFolio = Convert.ToInt32(txtNroFolio.Text);
            string cMotivo = "Vinculación Inicial con el Certificado";

            DataTable dtEnviOP = objValorados.CNVinculaCtaCertificado(nNroFolio, p_idCta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, cMotivo,0);
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                txtCodCertificado.Text = dtEnviOP.Rows[0]["nNroCertificado"].ToString();
                txtNroFolio.Enabled = false;
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Vinculación de Certificado con la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnVincular.Enabled = false;
                btnImprimir.Enabled = true;
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Vinculación de Certificado con la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroFolio.Focus();
                txtNroFolio.SelectAll();                
                return;
            }
        }

        private void conAutorizacionUsuDatos1_Load(object sender, EventArgs e)
        {
             
        }

        private void dtgIntervinientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgIntervinientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cNroDocuento = dtgIntervinientes.CurrentRow.Cells["cDocumentoID"].Value.ToString() ;
              
             var dtbIntervCta = ((DataTable)dtgIntervinientes.DataSource);

             var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => x["cDocumentoID"].Equals(cNroDocuento));

             foreach (var titular in lstIntervinientes)
             {
                 if (titular.Field<int>("IdTipoPersona") == 1)
                 {
                     conAutorizacionUsuDatos1.cCodCliente = "";
                     conAutorizacionUsuDatos1.idSolicitud = 0;
                     conAutorizacionUsuDatos1.pcNombre = titular.Field<string>("cNombre");
                     conAutorizacionUsuDatos1.pIdTipoPersona = titular.Field<int>("IdTipoPersona");
                     conAutorizacionUsuDatos1.pcDocumentoID = titular.Field<string>("cDocumentoID");
                     conAutorizacionUsuDatos1.pcDireccion = titular.Field<string>("cDireccion");
                     conAutorizacionUsuDatos1.pcTelefono = titular.Field<string>("cTelefono");
                 }
                 else
                 {
                     conAutorizacionUsuDatos1.pcDocumentoID = "";
                 } 
             } 
              
        }

        private async void ValidarAutrizacionUsoDatos()
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                string cNroDocuento = dtgIntervinientes.CurrentRow.Cells["cDocumentoID"].Value.ToString();

                var dtbIntervCta = ((DataTable)dtgIntervinientes.DataSource);
                if (conBusCtaAho.nidTipoPersona == 1)
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES


                    }
                }
                else
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 7 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES


                    }
                }

            }
        }

    }
}
