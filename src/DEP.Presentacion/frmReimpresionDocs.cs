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
    public partial class frmReimpresionDocs : frmBase
    {
       
        #region Variable Globales
        private bool lIndValorados = true;
        private int p_idCta = 0, idTipOpe, idEstado, p_idSolicitud;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNImpresion clsImpresion = new clsCNImpresion();
        DataTable dtValorados= new DataTable();
        clsCNValorados objValorados = new clsCNValorados();
        clsNumLetras objNumLetras = new clsNumLetras();
        private int idTipoImpresion = 0;
        decimal nMontoDeposito = 0;
        clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
        private DataTable dtValImp = new DataTable();

        DataTable tbDepMen = null;
        private DataTable dtbNumCuentas;
        string cMontoLetras;

        //Cartilla DPF Abono Periodico Mensual
        int nProdAbonoMensualDB = 0;
        DataTable dtProdMensualDB = new DataTable();
        private string cIdCampania;
        private string cFechaFinAhoCre;
        #endregion
        #region Constructor
        public frmReimpresionDocs()
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
            conBusCtaAho.HabDeshabilitarCtrl(false);
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnSolAprobadas.Focus();

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
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                
                p_idCta = Convert.ToInt32(conBusCtaAho.txtNroCta.Text);
                if (Convert.ToInt32(p_idCta)>0)
                {
                    this.conBusCtaAho.txtNroCta.Enabled = false;
                    this.conBusCtaAho.btnBusCliente.Enabled = false;
                    this.DatosCuenta();
                }
            }
            else
            {
                this.conBusCtaAho.txtNroCta.Focus();
            }
        }

        private bool ValidarDatosIngresados()
        {
            int nVal = 0;
            DataTable dtDocs = (DataTable)dtgFormatos.DataSource;
            for (int i = 0; i < dtDocs.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtDocs.Rows[i]["lIsImpresion"].ToString()))
                {
                    nVal = nVal + 1;
                }
            }

            if ( dtDocs.Rows.Count<=0)
            {
                MessageBox.Show("No hay Formatos a Reimprimir...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgFormatos.Focus();
                return false;
            }

            if (nVal == 0)
            {
                MessageBox.Show("Debe estar seleccionado por lo menos un Documento a Reimprimir...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgFormatos.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtMotivo.Text.ToString().Trim()))
            {
                MessageBox.Show("Ingrese Sustento de la Reimpresion", "Reimpresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMotivo.Focus();
                this.txtMotivo.SelectAll();
                return false;
            }
            
            return true;
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

            bool lIndImpre = false;

            if (!ValidarDatosIngresados())
            {
                return;
            }
            ConverNumLetras(Convert.ToDecimal (nMontoDeposito));
            DataTable dtDocs = (DataTable)dtgFormatos.DataSource;

            for (int i = 0; i < dtDocs.Rows.Count; i++)
            {
                int idTiTransfer = Convert.ToInt32(dtDocs.Rows[i]["idTipDocImp"].ToString());

                clsCodigoBarra Funcion = new clsCodigoBarra();
                DataTable dtcertificado = new clsRPTCNDeposito().CNRetornaDatosCerti(p_idCta, false);
                DataTable dtIntervs = new clsRPTCNDeposito().CNRetornaDatosInterv(p_idCta);
                DataTable dtIntervsDetalle = new clsRPTCNDeposito().CNRetornaDatosIntervDetalle(p_idCta);
                DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();

                clsCNProducto cnProducto = new clsCNProducto();
                string cImpPagoIntTotal = "";

                switch (idTiTransfer)
                {
                    case 1://Impresion de Certificado

                        if ((bool)dtDocs.Rows[i]["lIsImpresion"] == true)
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
                            int nNumImpresion = Convert.ToInt32(dtDocs.Rows[i]["nNroImpresiones"].ToString()) + 1;
                            string cMotivo = txtMotivo.Text;
                            bool lIndExoner = true;
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTiTransfer, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, p_idSolicitud);
                        }
                        break;

                    case 2://Impresión de la Cartilla

                        if ((bool)dtDocs.Rows[i]["lIsImpresion"] == true)
                        {
                            DataTable dtDatosTitulares = new DataTable();
                            //-----------

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
                            int idProdAC = Convert.ToInt32(clsVarApl.dicVarGen["nIdProdAhorroCrecer"]);

                            List<ReportParameter> paramlistCart = new List<ReportParameter>();
                            paramlistCart.Clear();
                           
                            string x_nMonTasa = "";
                            if (dtcertificado.Rows.Count > 0)
                            {
                                x_nMonTasa = Convert.ToDecimal(dtcertificado.Rows[0]["nMonTasa"]).ToString("N2");
                            }

                            paramlistCart.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlistCart.Add(new ReportParameter("x_idCuenta", p_idCta.ToString(), false));
                            paramlistCart.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyy"), false));
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
                                    paramlistCart.Add(new ReportParameter("x_lOriginal", "0", false));
                                    dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                    dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));
                                    reportpathCart = "rptCartillaInforCTS.rdlc";
                                    break;
                                case 48: // Plazo Fijo
                                    if (idProducto.In(nArrayIdCampania))
                                    {
                                        paramlistCart.Add(new ReportParameter("x_cImpPagoInteresAM", cImpPagoIntTotal, false));
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "0", false));
                                        dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));
                                        reportpathCart = "rptCartillaInforPlazoFijoAM.rdlc"; } // Plazo Fijo Abono Mensual
                                    else
                                    {
                                        paramlistCart.Add(new ReportParameter("cNombreProducto", dtcertificado.Rows[0]["cProducto"].ToString(), false));
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "0", false));
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
                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "0", false));
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
                            int nNumImpresion = Convert.ToInt32(dtDocs.Rows[i]["nNroImpresiones"].ToString()) + 1;
                            string cMotivo = txtMotivo.Text;
                            bool lIndExoner = true;
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTiTransfer, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, p_idSolicitud);
                        }
                        break;
                    case 3://--Constancia de CTS    
                        if ((bool)dtDocs.Rows[i]["lCheck"] == true)
                        {

                        }
                        break;
                    case 6://Registro de Firmas

                        if ((bool)dtDocs.Rows[i]["lIsImpresion"] == true)
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
                            DataTable dtResp = clsImpresion.CNGuardaImpresion(p_idCta, clsVarGlobal.idModulo, nNumImpresion, idKardex, clsVarGlobal.User.idUsuario, idTiTransfer, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, p_idSolicitud);
                        }

                        break;
                }

            }
            if (lIndImpre == true)
            {
                RetornaNumCuenta.CNDesbloqueaCuenta(p_idCta, clsVarGlobal.idModulo);
                MessageBox.Show("El Formato se ha impreso correctamente", "Reimpresión de Formatos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
            }

        }
        
           
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            RetornaNumCuenta.CNDesbloqueaCuenta(p_idCta, clsVarGlobal.idModulo);
            this.LimpiarControles();
            this.chcExoner.Checked = false;
            this.chcExoner.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtCBNumRecibo.Enabled = false;
            this.btnMiniAceptar.Enabled = false;

            if (dtgFormatos.Rows.Count > 0)
            {
                ((DataTable)dtgFormatos.DataSource).Rows.Clear();
            }
            dtgFormatos.Refresh();
            p_idCta = 0;
            p_idSolicitud = 0;
            btnSolAprobadas.Enabled = true;
            btnSolAprobadas.Focus();
           
        }

        private void txtCBNumRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
             string cValor;
             if (string.IsNullOrEmpty(this.txtCBNumRecibo.Text.ToString().Trim()))
            {
                cValor = "0";
            }
            else
                 cValor = this.txtCBNumRecibo.Text.ToString().Trim();
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.txtCBNumRecibo.Text = cValor;
                this.btnMiniAceptar.PerformClick();

            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.txtCBNumRecibo.Text = cValor;
            }

        }

        private void btnMiniAceptar1_Click(object sender, EventArgs e)
        {
            string cValor = this.txtCBNumRecibo.Text.ToString().Trim();
            bool lIndCertificado = false;
            if (!string.IsNullOrEmpty(cValor))
            {
                DataTable dtValidkardex = clsImpresion.CNValidaKardex(Convert.ToInt32(cValor), lIndCertificado, clsVarGlobal.nIdAgencia);
                if (dtValidkardex.Rows.Count == 0)
                {
                    MessageBox.Show("Nro de Kardex No Valido", "Reimpresion de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtCBNumRecibo.Focus();
                    this.txtCBNumRecibo.SelectAll();
                    return;
                }
                else
                {
                    DataTable dtValidVinculacion = clsImpresion.CNValidaVinculacionKardex(Convert.ToInt32(cValor), clsVarGlobal.idModulo);
                    if (dtValidVinculacion.Rows.Count > 0)
                    {
                        MessageBox.Show("Nro de Kardex  " + dtValidVinculacion.Rows[0]["IdKardex"].ToString() + " se encuentra Vinculado a la Cuenta  " + dtValidVinculacion.Rows[0]["idCuenta"].ToString(), "Reimpresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCBNumRecibo.Focus();
                        this.txtCBNumRecibo.SelectAll();
                        return;
                    }
                    else
                    {
                        this.btnImprimir.Enabled = true;
                        this.txtCBNumRecibo.Enabled = false;
                        this.btnMiniAceptar.Enabled = false;
                        this.btnImprimir.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Número Válido", "Reimpresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBNumRecibo.Focus();
                return;
            }
        }
        #endregion
        
        #region Metodos

        private void LimpiarControles()
        {
            p_idCta = 0;
            dtValorados.Rows.Clear();
            idTipoImpresion = 0;
            this.conBusCtaAho.LimpiarControles();
            dtValImp.Rows.Clear();
            this.txtProducto.Clear();
            txtNroImpresiones.Clear();
            this.txtCBNumRecibo.Clear();
            this.txtMotivo.Clear();
            txtCodCertificado.Clear();
            txtNroFolio.Clear();
            chcExoner.Checked = false;
        }

        private void LlenarDocumentos()
        {
            DataTable dtDocs = clsImpresion.CNListadoDocsReimpresion(p_idCta, p_idSolicitud);
            dtgFormatos.DataSource = dtDocs;
            dtgFormatos.Columns["idTipDocImp"].Visible = false;
            dtgFormatos.Columns["lIsImpresion"].Width = 60;
            dtgFormatos.Columns["lIsImpresion"].HeaderText = "Impresiones";
            dtgFormatos.Columns["lIsImpresion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFormatos.Columns["cDescripcion"].HeaderText = "Documentos para Reimpresión";
            dtgFormatos.Columns["cDescripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFormatos.Columns["cDescripcion"].Width = 200;
            dtgFormatos.Columns["nNroImpresiones"].HeaderText = "Nro Impresiones";
            dtgFormatos.Columns["nNroImpresiones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
               
        private void ConverNumLetras(Decimal nMontoTotal)
        {
            objNumLetras.LetraCapital = true;
            objNumLetras.MascaraSalidaDecimal = "/100 " + cboMoneda.Text;
            objNumLetras.SeparadorDecimalSalida = "con";
            objNumLetras.Decimales = 2;
            cMontoLetras = objNumLetras.ToCustomCardinal(nMontoTotal);
        }

        private void DatosCuenta()
        {
            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(p_idCta, "1", idTipOpe);
            if (dtbNumCuentas.Rows.Count >0)
            {
                idEstado = Convert.ToInt32(dtbNumCuentas.Rows[0]["idEstado"]);
                if (idEstado==4)
                {
                    MessageBox.Show("La Cuenta se Encuentra en Estado Pre Solicitado, No puede Reimprimir...", "Reimpresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                if (Convert.ToInt32(dtbNumCuentas.Rows[0]["lIndGarantia"]) == 1)
                {
                    MessageBox.Show("La Cuenta se encuentra como Garantia. No se puede Reimprimir", "Impresión de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                               
                //------------------------------------------------------------------------      
                //Validando que la Cuenta No se Encuentre Bloqueada
                //------------------------------------------------------------------------      
                DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuentaGen(p_idCta, clsVarGlobal.idModulo);
                if (dtEstCuenta.Rows.Count > 0)
                {
                    if ((int)dtEstCuenta.Rows[0]["nIdUsuBloq"] > 0)
                    {
                        DataTable dtUsu = RetornaNumCuenta.BusUsuBlo((int)dtEstCuenta.Rows[0]["nIdUsuBloq"]);
                        if (dtUsu.Rows.Count > 0)
                        {
                            MessageBox.Show("La Cuenta está siendo consultada: " + dtUsu.Rows[0]["cNombre"].ToString() + " - " + dtUsu.Rows[0]["cNombreAge"].ToString(), "Validar Consulta de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            p_idCta = 0;
                            conBusCtaAho.LimpiarControles();
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("No se Encontró Datos del Usuario que está consultando la Cuenta", "Error en la Carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conBusCtaAho.LimpiarControles();
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                        }
                    }

                }

                //--==================================================================================
                //--Validar si ya Tiene Certificado
                //--==================================================================================
                if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNumeCertificado"]) > 0)
                {
                    txtCodCertificado.Text = dtbNumCuentas.Rows[0]["nNumeCertificado"].ToString();
                    if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNroFolio"]) > 0)
                    {
                        txtNroFolio.Text = dtbNumCuentas.Rows[0]["nNroFolio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Folio no Existe, Inconsistencia de datos...Por Favor Revisar", "Validación de Reimpresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarControles();
                        conBusCtaAho.LimpiarControles();
                        conBusCtaAho.HabDeshabilitarCtrl(true);
                        this.conBusCtaAho.txtCodAge.Focus();
                        return;
                    }
                }
                                
                DataTable dtNumImpresion = clsImpresion.CNRetornaNumImpresion(p_idCta, clsVarGlobal.idModulo);
                if (string.IsNullOrEmpty(dtNumImpresion.Rows[0]["nNumImpresion"].ToString()))
                {
                    this.txtNroImpresiones.Text = "0";
                }
                else
                {
                    this.txtNroImpresiones.Text = dtNumImpresion.Rows[0]["nNumImpresion"].ToString();
                }

                if (Convert.ToInt32(this.txtNroImpresiones.Text)==0)
                {
                    MessageBox.Show("Para la reimpresión, el número de impresiones no puede ser Cero...Revisar", "Validación de Reimpresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.HabDeshabilitarCtrl(true);
                    this.conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                LlenarDocumentos();
                this.txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                this.cboMoneda.SelectedValue = dtbNumCuentas.Rows[0]["idMoneda"].ToString();
                this.cboTipoCuenta.SelectedValue = dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString();
                nMontoDeposito = Convert.ToDecimal(dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString());
                this.dtpFecApe.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]);
                this.btnCancelar.Enabled = true;
                txtCBNumRecibo.Enabled = false;
                btnMiniAceptar.Enabled = false;
                btnImprimir.Enabled = true;
                btnImprimir.Focus();

            }
            else
            {
                MessageBox.Show("Número de Cuenta no Válido para Reimpresión de Formatos", "Validación de Reimpresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                this.btnImprimir.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
                return;
            }

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
            if (p_idCta!=0)
            {
                RetornaNumCuenta.CNDesbloqueaCuenta(p_idCta, clsVarGlobal.idModulo); 
            }
           
        }

        private void chcExoner_CheckedChanged(object sender, EventArgs e)
        {
            if (chcExoner.Checked == true)
            {
                this.txtCBNumRecibo.Enabled = false;
                this.btnMiniAceptar.Enabled = false;
                this.btnImprimir.Enabled = true;
            }
            else
            {
                this.txtCBNumRecibo.Enabled = true;
                this.btnMiniAceptar.Enabled = true;
                //this.txtMotivo.Clear();
                this.btnImprimir.Enabled = false;
               
            }
        }

        private void btnSolAprobadas_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            p_idCta = 0;
            p_idSolicitud = 0;
            frmSolAprobReimpresion frmSolApr = new frmSolAprobReimpresion();
            frmSolApr.ShowDialog();
            if (frmSolApr.pidCta > 0)
            {
                p_idCta = frmSolApr.pidCta;
                p_idSolicitud = frmSolApr.pidSolicitud;
                conBusCtaAho.txtCodAge.Text = (frmSolApr.pcNroCuenta).ToString().Substring(3, 3);
                conBusCtaAho.txtCodMod.Text = (frmSolApr.pcNroCuenta).ToString().Substring(6, 3);
                conBusCtaAho.txtCodMon.Text = (frmSolApr.pcNroCuenta).ToString().Substring(9, 1);
                conBusCtaAho.txtNroCta.Text = (frmSolApr.pcNroCuenta).ToString().Substring(10, 12);
                conBusCtaAho.txtCodCli.Text = (frmSolApr.pidCli).ToString();
                conBusCtaAho.txtNroDoc.Text = (frmSolApr.pcNroDoc).ToString();
                conBusCtaAho.txtNombre.Text = (frmSolApr.pcNomCli).ToString();
                conBusCtaAho.pcCodCliLargo = frmSolApr.pcCodClienteLargo;
                txtMotivo.Text = (frmSolApr.pcMtivoReimpres).ToString();

                conBusCtaAho.idTipoDocumento = frmSolApr.pidTipoDocumento;
                conBusCtaAho.nidTipoPersona = frmSolApr.pIdTipoPersona;
                this.DatosCuenta();
                btnSolAprobadas.Enabled = false;
            }
        }

        
    }
}
