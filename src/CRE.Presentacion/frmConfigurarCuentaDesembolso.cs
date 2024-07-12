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
using SPL.Presentacion;
using Microsoft.Reporting.WinForms;
using GEN.Funciones;
using RPT.CapaNegocio;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmConfigurarCuentaDesembolso : frmBase
    {
        #region Variables
        public bool lPeticionCuentaNueva { get; set; }
        public bool lNuevaCuenta { get; set; }
        private clsCNProducto cnProducto { get; set; }
        private clsCNSolicitud cnSolicitud { get; set; }
        private clsCNDeposito cnDeposito { get; set; }
        public DataTable dtSolicitud { get; set; }
        public DataTable dtCuentaDepositoSeleccionado { get; set; }
        private List<int> lstProductoPermitido { get; set; }
        private DataTable dtIntervinientesSolicitud { get; set; }
        private DataTable dtIntervinientesConfirmacion { get; set; }
        private DataTable dtProductoDefecto { get; set; }
        private DataTable dtAhorroProgramando { get; set; }
        private DataTable dtCuentasCanceladas { get; set; }
        private DataTable dtComision { get; set; }
        private DataTable dtFormatos { get; set; }
        private clsCNAperturaCta cnAperturaCta { get; set; }
        private clsCNCalculosAho cnCalculosAho { get; set; }
        private clsNumLetras cnNumLetras { get; set; }
        private clsCNImpresion cnImpresion { get; set; }
        private clsCNListaFormatoImp cnListaFormatoImp { get; set; }

        private DataTable dtIntervinientesSolicitudAhorro { get; set; }

        private int idCliente { get; set; }
        private int idSolicitud { get; set; }
        private int idCuentaCredito { get; set; }
        private int idCuentaApertura { get; set; }
        private int idProductoDefecto { get; set; }
        private string cNroCuentaApertura { get; set; }

        public bool lCuentaDepositoAutomatico { get; set; }
        private int nNumeroImpresiones { get; set; }
        public bool lRespuestaVinculacion { get; set; }

        private bool lRespuestaSolicitud { get; set; }
        private bool lRespuestaApertura { get; set; }

        #endregion

        #region Constructores
        public frmConfigurarCuentaDesembolso()
        {
            InitializeComponent();
        }

        public frmConfigurarCuentaDesembolso(int _idCliente, int _idSolicitud, DataTable _dtSolicitud, DataTable _dtCuentaDepositoSeleccionado,bool _lPeticionCuentaNueva = false, int _idCuentaDeposito = 0, bool _lCuentaDepositoAutomatico = false)
        {
            InitializeComponent();

            CargarDatosDefecto();

            this.idCliente              = _idCliente;
            this.idSolicitud            = _idSolicitud;
            this.lPeticionCuentaNueva   = _lPeticionCuentaNueva;
            this.dtSolicitud            = _dtSolicitud;
            this.dtCuentaDepositoSeleccionado = _dtCuentaDepositoSeleccionado;
            this.idCuentaCredito        = Convert.ToInt32(dtSolicitud.Rows[0]["idCuenta"]);
            this.idCuentaApertura       = _idCuentaDeposito;
            this.lCuentaDepositoAutomatico = _lCuentaDepositoAutomatico;

            CargarComponentes();
        }
        #endregion

        #region Eventos
        private void frmConfigurarCuentaDesembolso_Load(object sender, EventArgs e)
        {
            DatosCuentaDeposito();
            
            LlenarTiposDeDocumento();
            if (idCuentaApertura == 0)
            {
                cboEnvioEstCta.SelectedIndex = -1;
            }

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int fila = 0;
            bool lIndImpre = false;
            string cMontoLetras = String.Empty;
            decimal nMontoDeposito = 0.00m;
            nNumeroImpresiones = 0;
            string cFechaFinAhoCre;

            DataTable dtResultado = (cnDeposito.CNRetornaFechaFin());
            string cFechaFin = Convert.ToString(dtResultado.Rows[0]["cFechaFin"]);
            cFechaFinAhoCre = cFechaFin;

            DataTable dtbNumCuentas = cnDeposito.CNRetornaDatosCuenta(idCuentaApertura, "1", 16);

            bool lIsRequeCert = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsRequeCert"]);
            bool lisCtaCTS = false; //Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsProdCTS"]);--Solo se debe imprimir la Cartilla en caso de CTS
            AsignarValImp(lIsRequeCert, true, false, lisCtaCTS);

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
                MessageBox.Show("Debe de seleccionar al menos un formato a imprimir", "Validación de reimpresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < dtFormatos.Rows.Count; i++)
            {
                int idTipImpresion = Convert.ToInt32(dtFormatos.Rows[i]["idTipDocImp"]);

                ConverNumLetras(Convert.ToDecimal(nMontoDeposito), ref cMontoLetras);

                clsCodigoBarra Funcion = new clsCodigoBarra();
                DataTable dtcertificado = new clsRPTCNDeposito().CNRetornaDatosCerti(idCuentaApertura, true);
                DataTable dtIntervs = new clsRPTCNDeposito().CNRetornaDatosInterv(idCuentaApertura);
                DataTable dtIntervsDetalle = new clsRPTCNDeposito().CNRetornaDatosIntervDetalle(idCuentaApertura);
                DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();

                clsCNProducto cnProducto = new clsCNProducto();
               

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
                            paramlist.Add(new ReportParameter("x_idCuenta", idCuentaApertura.ToString(), false));
                            paramlist.Add(new ReportParameter("x_cMontoLetras", CharToUpper(cMontoLetras), false));
                            paramlist.Add(new ReportParameter("x_nMontoDeposito", x_nMontoDeposito, false));

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
                            nNumeroImpresiones = 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = cnImpresion.CNGuardaImpresion(idCuentaApertura, 2, nNumeroImpresiones, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
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
                                dtDatosTitulares = cnDeposito.CNRetornaDatosIntervRegFirmas(idCuentaApertura);
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

                            string cDuplicado = Convert.ToString(dtcertificado.Rows[0]["cDuplicado"]);

                            List<ReportParameter> paramlistCart = new List<ReportParameter>();
                            paramlistCart.Clear();

                            string x_nMonTasa = "";
                            if (dtcertificado.Rows.Count > 0)
                            {
                                x_nMonTasa = Convert.ToDecimal(dtcertificado.Rows[0]["nMonTasa"]).ToString("N2");
                            }

                            paramlistCart.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlistCart.Add(new ReportParameter("x_idCuenta", idCuentaApertura.ToString(), false));
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

                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false)); 
                                         dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));

                                    reportpathCart = "rptCartillaInforCTS.rdlc";
                                    break;
                                case 48: //Plazo Fijo

                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                         dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));
                                        dtslistCart.Add(new ReportDataSource("dtIntervDetalle", dtIntervsDetalle));

                                    reportpathCart = "rptCartillaInforPlazoFijo.rdlc";
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
                            nNumeroImpresiones = 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = cnImpresion.CNGuardaImpresion(idCuentaApertura, 2, nNumeroImpresiones, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
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

                                DataTable dtDatosCuentaRF = cnDeposito.CNRetornaDatosCuentaRegFirmas(idCuentaApertura);
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

                                DataTable dtDatosClienteRF = cnDeposito.CNRetornaDatosIntervRegFirmas(idCuentaApertura);

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
                                DataTable dtDatosCuentaRF = cnDeposito.CNRetornaDatosCuentaRegFirmas(idCuentaApertura);
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
                                DataTable dtDatosClientePJRF = cnDeposito.CNRetornaDatosIntervRegFirmasPJ(idCuentaApertura);

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

                                DataTable dtDatosClienteRF = cnDeposito.CNRetornaDatosIntervRegFirmas(idCuentaApertura);

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
                            nNumeroImpresiones = 1;
                            string cMotivo = "Impresión por la Apertura de Cuenta";
                            bool lIndExoner = true;
                            DataTable dtResp = cnImpresion.CNGuardaImpresion(idCuentaApertura, 2, nNumeroImpresiones, idKardex, clsVarGlobal.User.idUsuario, idTipImpresion, clsVarGlobal.dFecSystem, cMotivo, lIndExoner, 0);
                        }

                        fila++;
                        break;
                }
            }

            btnImprimir1.Enabled = false;
            btnGrabar.Enabled = false;
            btnSalir1.Enabled = true;
            lblMensaje.Text = String.Empty;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            lRespuestaSolicitud = (lRespuestaSolicitud) ? true : false;
            lRespuestaApertura = false;
            

            if (lNuevaCuenta)
            {
                if (!ValidarDatosEnvioExtracto())
                    return;

                lRespuestaSolicitud = RegistrarSolicitudApertura();
                lRespuestaApertura = (lRespuestaSolicitud) ? RegistrarConfirmacionApertura() : false ;
                if (!lRespuestaApertura)
                    return;
                lblMensaje.Text = (lRespuestaApertura) ? "Debe imprimir los documentos de la cuenta antes de salir." : String.Empty;
            }
            if((lRespuestaApertura && idCuentaApertura != 0) || idCuentaApertura != 0)
            {
                lRespuestaVinculacion = VincularCuentaDepositoCredito();
                btnImprimir1.Enabled = (lNuevaCuenta && lRespuestaSolicitud && lRespuestaApertura && lRespuestaVinculacion) ? true : false;
            }
            else
            {
                return;
            }

            if(lNuevaCuenta)
            {
                btnGrabar.Enabled = (lRespuestaVinculacion && lRespuestaSolicitud && lRespuestaApertura) ? false : true;
            }
            else
            {
                btnGrabar.Enabled = (lRespuestaVinculacion) ? false : true;
            }
            btnSalir1.Enabled = true;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEnvioEstCta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEnvioEstCta.SelectedValue) == 3)
            {
                txtDireccionEnvioEstCta.Text = String.Empty;
                txtDireccionEnvioEstCta.Enabled = false;
            }
            else if (Convert.ToInt32(cboEnvioEstCta.SelectedValue) == 2)
            {
                txtDireccionEnvioEstCta.Text = String.Empty;
                this.txtDireccionEnvioEstCta.Enabled = false;
                recuperarDatosCorreo();
            }
            else
            {
                txtDireccionEnvioEstCta.Enabled = true;
                txtDireccionEnvioEstCta.Text = String.Empty;
            }
        }

        private void recuperarDatosCorreo()
        {

            dtIntervinientesSolicitudAhorro = dtIntervinientesSolicitud.Clone();
            DataRow drInterviniente = dtIntervinientesSolicitudAhorro.NewRow();

            drInterviniente["codigo"] = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);
            drInterviniente["nombres"] = Convert.ToString(dtSolicitud.Rows[0]["cNombre"]);
            drInterviniente["tipodoc"] = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoDocumento"]);
            drInterviniente["documento"] = Convert.ToString(dtSolicitud.Rows[0]["cDocumentoID"]);
            drInterviniente["idTipoInterv"] = 6;
            drInterviniente["idCuenta"] = 0;
            drInterviniente["direccion"] = Convert.ToString(dtSolicitud.Rows[0]["cDireccion"]); ;
            drInterviniente["lEsAfeItf"] = 1;
            drInterviniente["idTipoDocumento"] = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoDocumento"]); ;

            dtIntervinientesSolicitudAhorro.Rows.Add(drInterviniente);

            DataTable tbCliIntervinientes = dtIntervinientesSolicitudAhorro;

            frmBuscarEmailAhorros frmBuscar = new frmBuscarEmailAhorros(tbCliIntervinientes);
            frmBuscar.ShowDialog();
            string cCorreo = frmBuscar.cCorreoAsignadoPrincipal();
            if (!String.IsNullOrEmpty(cCorreo))
            {
                MessageBox.Show("Se ha recuperado el siguiente correo: " + cCorreo + ".", "Solicitud de Apertura de Cuentas de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccionEnvioEstCta.Text = cCorreo;
            }

            dtIntervinientesSolicitudAhorro = null;

        }

        private void frmConfigurarCuentaDesembolso_FormClosing(object sender, FormClosingEventArgs e)
        {
            int idCuentaVinculada = Convert.ToInt32(dtSolicitud.Rows[0]["idCuentaDeposito"]);
            bool lCuenta = false;
            bool lBloquearCierre = false;
            if ((idCuentaApertura == 0 || !lRespuestaVinculacion) && lNuevaCuenta)
            {
                DialogResult drRespuesta = MessageBox.Show("No se creará la cuenta de ahorro. ¿Está seguro de salir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                lBloquearCierre = (drRespuesta == DialogResult.Yes) ? false: true;
                lCuenta = (drRespuesta == DialogResult.Yes) ? false: true;
            }
            else if (!lRespuestaVinculacion &&(idCuentaApertura != idCuentaVinculada && idCuentaApertura == 0) )
            {
                DialogResult drRespuesta = MessageBox.Show("No se vinculará la cuenta de ahorro. ¿Está seguro de salir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                lBloquearCierre = (drRespuesta == DialogResult.Yes) ? false : true;
            }

            if(lNuevaCuenta && nNumeroImpresiones == 0 && lRespuestaVinculacion)
            {
                DialogResult drRespuesta = MessageBox.Show("No se imprimio los documentos de la nueva cuenta ¿Está seguro de salir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                lBloquearCierre = (drRespuesta == DialogResult.Yes) ? false : true;
            }

            e.Cancel = lBloquearCierre;
        }

        #endregion

        #region Metodos

        private void CargarDatosDefecto()
        {
            lPeticionCuentaNueva            = false;
            lNuevaCuenta                    = true;
            cnProducto                      = new clsCNProducto();
            cnSolicitud                     = new clsCNSolicitud();
            cnDeposito                      = new clsCNDeposito();
            cnAperturaCta                   = new clsCNAperturaCta();
            cnCalculosAho                   = new clsCNCalculosAho();
            cnImpresion                     = new clsCNImpresion();
            cnListaFormatoImp               = new clsCNListaFormatoImp();
            cnNumLetras                     = new clsNumLetras();
            lstProductoPermitido            = new List<int>();
            dtSolicitud                     = new DataTable();
            dtCuentaDepositoSeleccionado    = new DataTable();
            dtProductoDefecto               = new DataTable();
            dtIntervinientesSolicitud       = new DataTable();
            dtIntervinientesConfirmacion    = new DataTable();
            dtAhorroProgramando             = new DataTable();
            dtCuentasCanceladas             = new DataTable();
            dtComision                      = new DataTable();
            dtFormatos                      = new DataTable();
            idCliente                       = 0;
            idSolicitud                     = 0;
            idCuentaApertura                = 0;
            idCuentaCredito                 = 0;
            lCuentaDepositoAutomatico       = false;
            nNumeroImpresiones              = 0;
            cNroCuentaApertura              = String.Empty;
            lRespuestaVinculacion           = false;
        }

        private void CargarComponentes()
        {
            
            string cListaProductoPermitidos = Convert.ToString(clsVarApl.dicVarGen["cIdProductoDesembolsoAhorro"]);
            lstProductoPermitido = cListaProductoPermitidos.Split(',').Select(Int32.Parse).ToList();

            idProductoDefecto = (lstProductoPermitido.Count > 0) ? lstProductoPermitido[0] : 0;
            dtProductoDefecto = cnProducto.CNListaNivelesSupProductos(2, idProductoDefecto);

            cboTipoDeposito.CargarProducto(Convert.ToInt32(dtProductoDefecto.Rows[0]["idProductoPadre"]));
            cboSubTipoDeposito.CargarProducto(Convert.ToInt32(dtProductoDefecto.Rows[1]["idProductoPadre"]));
            cboProducto.CargarProducto(Convert.ToInt32(dtProductoDefecto.Rows[2]["idProductoPadre"]));
            cboSubProducto.CargarProducto(Convert.ToInt32(dtProductoDefecto.Rows[3]["idProductoPadre"]));

            CargarModalidadPago();
            FormatearIntervinientesSolicitud();
            FormatearCuentasCanceladas();
        }

        private void DatosCuentaDeposito()
        {
            int idTipoOperacion = 22;
            int idEstadoCuenta = 1;
            int idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            bool lCuentaDiferente = true;

            if(dtCuentaDepositoSeleccionado.Rows.Count > 0)
            {
                if(idCuentaApertura != Convert.ToInt32(dtCuentaDepositoSeleccionado.Rows[0]["idNum"]))
                {
                    dtCuentaDepositoSeleccionado = cnDeposito.CNRetornaDatosxCuenta(idCuentaApertura, idEstadoCuenta, idMoneda, idTipoOperacion);
                }
            }
            else
            {
                dtCuentaDepositoSeleccionado = cnDeposito.CNRetornaDatosxCuenta(idCuentaApertura, idEstadoCuenta, idMoneda, idTipoOperacion);
            }

            int idCuentaDepositoVinculado = Convert.ToInt32(dtSolicitud.Rows[0]["idCuentaDeposito"]);

            lCuentaDiferente = (idCuentaDepositoVinculado != idCuentaApertura || idCuentaDepositoVinculado == 0) ? true : false ;

            bool lCuentaDepositoAutomaticoVinculado = Convert.ToBoolean(dtSolicitud.Rows[0]["lCuentaDepositoAutomatico"]);
            string cNroCuenta = (dtCuentaDepositoSeleccionado.Rows.Count > 0) ? Convert.ToString(dtCuentaDepositoSeleccionado.Rows[0]["cNroCuenta"]) : "-" ;

            if (lPeticionCuentaNueva && !lCuentaDepositoAutomatico)
            {
                CargarDatosNuevaCuenta();
                lNuevaCuenta = true;
                lRespuestaVinculacion = false;
            }
            else
            {
                lblNumeroCuenta.Text = cNroCuenta + ((lCuentaDepositoAutomatico) ? " - Automatico" : String.Empty);
                if(lCuentaDepositoAutomatico)
                {
                    RecuperarDatosCuenta(idCuentaApertura);
                    lNuevaCuenta = false;
                    lRespuestaVinculacion = true;
                }
                else
                {
                    RecuperarDatosCuenta(idCuentaApertura);
                    lNuevaCuenta = false;
                    lRespuestaVinculacion = (lCuentaDiferente) ? false : true ;
                }
            }
        }

        private void CargarDatosNuevaCuenta()
        {
            cboTipoDeposito.SelectedValue = Convert.ToInt32(dtProductoDefecto.Rows[0]["idProducto"]);
            cboSubTipoDeposito.SelectedValue = Convert.ToInt32(dtProductoDefecto.Rows[1]["idProducto"]);
            cboProducto.SelectedValue = Convert.ToInt32(dtProductoDefecto.Rows[2]["idProducto"]);
            cboSubProducto.SelectedValue = Convert.ToInt32(dtProductoDefecto.Rows[3]["idProducto"]);

            cboTipoPersona.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["IdTipoPersona"]);
            cboTipoCuenta.SelectedValue = 1;
            cboModPago.SelectedValue = 2;
            cboMoneda.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            txtMonto.Text = "0";
            chcOrdPago.Checked = false;

            cboOrigenFondos.SelectedValue = 74;
            cboObjetoAhorro.SelectedValue = 4;

            conBusCol.CargarColaboradorxUsuario(Convert.ToInt32(dtSolicitud.Rows[0]["idUsuario"]));
            HabilitarDatosEnvioExtracto(true);

            btnImprimir1.Enabled = false;
            btnGrabar.Enabled = true;
            btnSalir1.Enabled = true;
        }

        public void RecuperarDatosCuenta(int idCuenta)
        {
            int idCuentaSolicitudDeposito = Convert.ToInt32(dtSolicitud.Rows[0]["idCuentaDeposito"]);
            bool lCuentaSolicitudDepositoAutomatico = Convert.ToBoolean(dtSolicitud.Rows[0]["lCuentaDepositoAutomatico"]);

            DataTable dtCuentaSeleccionada = cnDeposito.CNRetornaDatosCuenta(idCuenta, "1", 9);
            DataTable dtProductoProducto = cnProducto.CNListaNivelesSupProductos(2, Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idProducto"]));
            idCuentaApertura = Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idCuenta"]);
            idCuentaCredito = Convert.ToInt32(dtSolicitud.Rows[0]["idCuenta"]);

            cboTipoDeposito.CargarProducto(Convert.ToInt32(dtProductoProducto.Rows[0]["idProductoPadre"]));
            cboSubTipoDeposito.CargarProducto(Convert.ToInt32(dtProductoProducto.Rows[1]["idProductoPadre"]));
            cboProducto.CargarProducto(Convert.ToInt32(dtProductoProducto.Rows[2]["idProductoPadre"]));
            cboSubProducto.CargarProducto(Convert.ToInt32(dtProductoProducto.Rows[3]["idProductoPadre"]));

            cboTipoDeposito.SelectedValue = Convert.ToInt32(dtProductoProducto.Rows[0]["idProducto"]);
            cboSubTipoDeposito.SelectedValue = Convert.ToInt32(dtProductoProducto.Rows[1]["idProducto"]);
            cboProducto.SelectedValue = Convert.ToInt32(dtProductoProducto.Rows[2]["idProducto"]);
            cboSubProducto.SelectedValue = Convert.ToInt32(dtProductoProducto.Rows[3]["idProducto"]);

            cboTipoPersona.SelectedValue = Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idTipoPersona"]);
            cboTipoCuenta.SelectedValue = Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idTipoCuenta"]);
            cboModPago.SelectedIndex = -1;
            cboMoneda.SelectedValue = Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idMoneda"]);

            cboEnvioEstCta.SelectedValue = Convert.ToInt32(dtCuentaSeleccionada.Rows[0]["idTipoEnvioEstCta"]);
            txtDireccionEnvioEstCta.Text = Convert.ToString(dtCuentaSeleccionada.Rows[0]["cDireccionEnvioEstCta"]);

            txtMonto.Text = "0";
            chcOrdPago.Checked = false;

            cboOrigenFondos.SelectedIndex = -1;
            cboObjetoAhorro.SelectedIndex = -1;
            HabilitarDatosEnvioExtracto(false);

            btnGrabar.Enabled = (idCuentaSolicitudDeposito == 0 && !lCuentaSolicitudDepositoAutomatico) ? true : false ;
            btnGrabar.Enabled = (idCuentaApertura == idCuentaSolicitudDeposito) ? false : true ;
            btnImprimir1.Enabled = false;
            btnSalir1.Enabled = true;
        }

        public bool RegistrarSolicitudApertura()
        {
            DataRow drInterviniente = dtIntervinientesSolicitud.NewRow();

            drInterviniente["codigo"] = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);
            drInterviniente["nombres"] = Convert.ToString(dtSolicitud.Rows[0]["cNombre"]);
            drInterviniente["tipodoc"] = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoDocumento"]);
            drInterviniente["documento"] = Convert.ToString(dtSolicitud.Rows[0]["cDocumentoID"]);
            drInterviniente["idTipoInterv"] = 6;
            drInterviniente["idCuenta"] = 0;
            drInterviniente["direccion"] = Convert.ToString(dtSolicitud.Rows[0]["cDireccion"]); ;
            drInterviniente["lEsAfeItf"] = 1;
            drInterviniente["idTipoDocumento"] = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoDocumento"]); ;

            dtIntervinientesSolicitud.Rows.Add(drInterviniente);

            //===================================================================
            //---VALIDACION DE CLIENTE PEP         
            //===================================================================
            for (int i = 0; i < dtIntervinientesSolicitud.Rows.Count; i++)
            {
                string mensaje = "",
                        x_cNroDni = "";
                int x_idEstApr = 0;
                int CodCliente = Convert.ToInt32(dtIntervinientesSolicitud.Rows[i]["codigo"].ToString());
                int CodidTipoDocumento = Convert.ToInt32(dtIntervinientesSolicitud.Rows[i]["idTipoDocumento"].ToString());
                bool lAperturaAutomatica = (clsVarApl.dicVarGen["lAperturaAutomaticaAhorroPEP"] == "1") ? true : false;

                if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
                {
                    if(lAperturaAutomatica)
                    {
                        MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (x_idEstApr == 1) //--Solicitado
                        {
                            frmPep frmPepx = new frmPep(CodidTipoDocumento, x_cNroDni);
                            frmPepx.ShowDialog();
                        }
                        dtIntervinientesSolicitud.Clear();
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("El interviniente de la cuentas es un cliente PEP, la apertura de la cuenta debe realizarse por el flujo normal.", "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtIntervinientesSolicitud.Clear();
                        return false;
                    }
                    
                }
            }
            //--==================================================
            //--Pago es por Transferencia
            //--==================================================

            int idModalidadPago = Convert.ToInt32(cboModPago.SelectedValue);
            int nPlazo = 0;
            int idProducto = (lstProductoPermitido.Count > 0) ? lstProductoPermitido[0] : 0;
            decimal nMonto = Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalSolicitado"]);
            int idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idTipoPersona = Convert.ToInt32(dtSolicitud.Rows[0]["IdTipoPersona"]);
            int idTipoTasa = 1;
            int idUsuario = Convert.ToInt32(dtSolicitud.Rows[0]["idUsuario"]);

            DataTable dtTasa = cnAperturaCta.RetornaTasaAhorros(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipoPersona);
            int idTasa = 0;
            decimal nTasaCompensatorio = Decimal.Zero;
            if (dtTasa.Rows.Count > 0)
            {
                idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);
                nTasaCompensatorio = Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoria"]);
            }
            else
            {
                MessageBox.Show("No se encontró una tasa de ahorro configurada para el producto. Comuníquese con el área de sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtIntervinientesSolicitud.Clear();
                return false;
            }

            //============================================================
            //--Retorna Estructura Para depositos
            //============================================================

            DataTable dtDepos = cnAperturaCta.ListaCamposDep(1);
            DataRow dr = dtDepos.NewRow();
            //--Asignar Datos Para Registrar la Solicitud de Apertura
            dr["idEstado"] = 4;//--Estado Solicitado
            dr["idProducto"] = cboSubProducto.SelectedValue;
            dr["idTipoCuenta"] = cboTipoCuenta.SelectedValue;
            dr["idTipoTasa"] = idTipoTasa;
            dr["idTasa"] = idTasa;
            dr["nMonTasa"] = nTasaCompensatorio;
            dr["idMoneda"] = idMoneda;
            dr["idAgencia"] = idAgencia;
            dr["idUsuario"] = clsVarGlobal.User.idUsuario;
            dr["nMontoDeposito"] = 0; //Debe ir el Monto Total a Recibir
            dr["nInteresGen"] = 0.00;
            dr["nInteresPag"] = 0;
            dr["nMonIntTot"] = 0;
            dr["dFechaApertura"] = clsVarGlobal.dFecSystem;
            dr["nNumeroFirmas"] = dtIntervinientesSolicitud.Rows.Count;
            dr["idUsuAsig"] = conBusCol.txtCod.Text;
            dr["nSaldoDis"] = 0;
            dr["nSaldoCnt"] = 0;
            dr["dFecUltMov"] = clsVarGlobal.dFecSystem.ToShortDateString();
            dr["lInactiva"] = 0;

            dr["lIsAfectoITF"] = (true) ? 1 : 0; //
            dr["lIsCtaOrdPago"] = 0;
            dr["idRenovacion"] = 0;

            dr["idPagoInt"] = 0;

            dr["nSaldoMinimo"] = 0.00;
            dr["idTipoPersona"] = idTipoPersona;
            dr["nPlazoCta"] = 0;

            dr["cRucEmpleador"] = String.Empty;

            dr["cDescripcionCta"] = String.Empty;
            dr["idTipoEnvioEstCta"] = (cboEnvioEstCta.SelectedIndex < 0) ? 3 : Convert.ToInt32(cboEnvioEstCta.SelectedValue);
            dr["cDireccionEnvioEstCta"] = txtDireccionEnvioEstCta.Text;
            dr["idOrigenFondo"] = Convert.ToInt16(cboOrigenFondos.SelectedValue);
            dr["idObjetoAho"] = Convert.ToInt16(cboObjetoAhorro.SelectedValue);

            dtDepos.Rows.Add(dr);

            //============================================================
            //--Retorna Estructura Para Empleador 
            //============================================================
            clsCNAperturaCta Empleador = new clsCNAperturaCta();
            DataTable dtEmp = Empleador.ListaCamposDep(2);

            //--Generar XML de Datos Empleador
            DataSet dsEmpleador = new DataSet("dsDeposito");
            dsEmpleador.Tables.Add(dtEmp);
            string xmlEmpleador = clsCNFormatoXML.EncodingXML(dsEmpleador.GetXml());  //dsEmpleador.GetXml();

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================

            DataTable dtDatosPago = cnAperturaCta.ListaCamposDep(3);
            DataRow drDatosPago = dtDatosPago.NewRow();
            ////--Asignar Datos Para Registrar Apertura

            drDatosPago["idTipoValorado"] = 2; //--Tipo Pago Transferencia
            drDatosPago["cNroCuentaDoc"] = String.Empty;
            drDatosPago["cNroDocumento"] = "000";
            drDatosPago["cSerieDocumento"] = "0";
            drDatosPago["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
            drDatosPago["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
            drDatosPago["nDiasValoriz"] = 0;
            drDatosPago["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
            drDatosPago["nNroFolio"] = "0";
            drDatosPago["lisMismaCta"] = 1;//

            dtDatosPago.Rows.Add(drDatosPago);

            DataSet dsTipoPago = new DataSet("dsDeposito");
            dsTipoPago.Tables.Add(dtDatosPago);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipoPago.GetXml());

            //--Variables Adicionales
            int idEntFin = clsVarApl.dicVarGen["idInstFin"];

            string cNroDocPag = String.Empty;//txtNroDocu.Text.Trim();

            //===================================================================
            //--Generar XML de Datos Deposito
            //===================================================================
            DataSet ds = new DataSet("dsDeposito");
            ds.Tables.Add(dtDepos);
            string xmlDeposito = ds.GetXml();
            xmlDeposito = clsCNFormatoXML.EncodingXML(xmlDeposito);

            //===================================================================
            //--Generar XML de Datos Aho Programado
            //===================================================================

            dtAhorroProgramando = cnCalculosAho.CalculaPpgDep(0.00m, clsVarGlobal.dFecSystem, clsVarGlobal.dFecSystem, 1, 0, 2, clsVarGlobal.dFecSystem.Day, 0);

            DataSet dsAhorroProgamado = new DataSet("dsDeposito");
            dsAhorroProgamado.Tables.Add(dtAhorroProgramando);
            string xmlAhoPrg = clsCNFormatoXML.EncodingXML(dsAhorroProgamado.GetXml());

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable tbCliIntervi = dtIntervinientesSolicitud.Clone();
            for (int i = 0; i < dtIntervinientesSolicitud.Rows.Count; i++)
            {
                tbCliIntervi.ImportRow(dtIntervinientesSolicitud.Rows[i]);
            }

            DataSet dsInterv = new DataSet("dsDeposito");
            dsInterv.Tables.Add(tbCliIntervi);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsInterv.GetXml());

            //===================================================================
            //--Generar XML de Datos de las Cuentas Canceladas
            //===================================================================
            DataTable dtCtasCancel = dtCuentasCanceladas.Clone();
            for (int i = 0; i < dtCuentasCanceladas.Rows.Count; i++)
            {
                dtCtasCancel.ImportRow(dtCuentasCanceladas.Rows[i]);
            }

            DataSet dsCtasCancel = new DataSet("dsDeposito");
            dsCtasCancel.Tables.Add(dtCtasCancel);
            string xmlCtasCancel = clsCNFormatoXML.EncodingXML(dsCtasCancel.GetXml());

            //===================================================================
            //--Guardar Apertura Cuenta
            //===================================================================
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue);
            int nCuotas = 0;
            //int idCanal = 1;

            decimal nMonCapital = 0.00m;

            bool lEsAhoProg = false;
            bool lIsRequeCert = false;
            bool lEsCtaCTS = false;
            bool lEsReqEmpleador = false;

            int idCtaTrans = 0;

            //===================================================================
            //--Registrar Apertura de Cuenta
            //===================================================================

            clsCNAperturaCta dtRegApe = new clsCNAperturaCta();
            DataTable tbRegApe = dtRegApe.RegistraAperturaCta(xmlDeposito, xmlInterv, xmlTipPago, xmlEmpleador, xmlAhoPrg
                                            , clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, nCuotas, 0,
                                            lEsAhoProg, lIsRequeCert, lEsCtaCTS, idTipPago, idCtaTrans, clsVarGlobal.dFecSystem, lEsReqEmpleador, cNroDocPag, idEntFin, 0,
                                            nMonCapital, xmlCtasCancel);

            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE CUENTA: " + tbRegApe.Rows[0]["idNroCta"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                idCuentaApertura = Convert.ToInt32(tbRegApe.Rows[0]["idCuentaAho"]);
                cNroCuentaApertura = Convert.ToString(tbRegApe.Rows[0]["idNroCta"]);
                lblNumeroCuenta.Text = cNroCuentaApertura;
                return true;
            }
            else
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }

        public bool RegistrarConfirmacionApertura()
        {
            DataTable dtIntervinienteCuenta = cnDeposito.CNRetornaIntervinientesCuenta(idCuentaApertura);
            int idClienteValido = 0;

            DataRow drInterviniente = dtIntervinienteCuenta.AsEnumerable().Where(item => Convert.ToBoolean(item["isReqFirma"]))
                                                                            .OrderBy(item => Convert.ToInt32(item["idCli"]))
                                                                            .FirstOrDefault();

            idClienteValido = (drInterviniente != null ) ? Convert.ToInt32(drInterviniente["idCli"]) : 0 ;

            var lstTitulares = dtIntervinienteCuenta.AsEnumerable().Where(item => Convert.ToInt32(item["idTipoInterv"]) == 6);

            

            clsValidacionPreviaOpe objValidacionPerviaOpe = new clsValidacionPreviaOpe(idClienteValido, "", clsVarGlobal.nIdAgencia, 0, idClienteValido);

            if(objValidacionPerviaOpe.verificPararOperacion())
            {
                return false;
            }

            dtIntervinientesConfirmacion = dtIntervinienteCuenta;

            //--==================================================
            //--Pago es por Transferencia
            //--==================================================

            int idModalidadPago = Convert.ToInt32(cboModPago.SelectedValue);
            int nPlazo = 0;
            int idProducto = (lstProductoPermitido.Count > 0) ? lstProductoPermitido[0] : 0;
            decimal nMonto = Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalSolicitado"]);
            int idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idTipoPersona = Convert.ToInt32(dtSolicitud.Rows[0]["IdTipoPersona"]);
            int idUsuario = Convert.ToInt32(dtSolicitud.Rows[0]["idUsuario"]);

            DataTable dtTasa = cnAperturaCta.RetornaTasaAhorros(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipoPersona);

            int idTasa = (dtTasa.Rows.Count > 0) ? Convert.ToInt32(dtTasa.Rows[0]["idTasa"]) : 0;
            decimal nTasaCompensatorio = (dtTasa.Rows.Count > 0) ? Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoria"]) : 0;




            //============================================================
            //--Retorna Estructura Para Empleador 
            //============================================================
            clsCNAperturaCta Empleador = new clsCNAperturaCta();
            DataTable dtEmp = Empleador.ListaCamposDep(2);

            //--Generar XML de Datos Empleador
            DataSet dsEmpleador = new DataSet("dsDeposito");
            dsEmpleador.Tables.Add(dtEmp);
            string xmlEmpleador = clsCNFormatoXML.EncodingXML(dsEmpleador.GetXml());  //dsEmpleador.GetXml();

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================

            DataTable dtDatosPago = cnAperturaCta.ListaCamposDep(3);
            DataRow drDatosPago = dtDatosPago.NewRow();
            ////--Asignar Datos Para Registrar Apertura

            drDatosPago["idTipoValorado"] = 2; //--Tipo Pago Transferencia
            drDatosPago["cNroCuentaDoc"] = String.Empty;
            drDatosPago["cNroDocumento"] = "000";
            drDatosPago["cSerieDocumento"] = "0";
            drDatosPago["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
            drDatosPago["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
            drDatosPago["nDiasValoriz"] = 0;
            drDatosPago["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
            drDatosPago["nNroFolio"] = "0";
            drDatosPago["lisMismaCta"] = 1;//

            dtDatosPago.Rows.Add(drDatosPago);

            DataSet dsTipoPago = new DataSet("dsDeposito");
            dsTipoPago.Tables.Add(dtDatosPago);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipoPago.GetXml());

            //--Variables Adicionales
            int idEntFin = clsVarApl.dicVarGen["idInstFin"];

            string cNroDocPag = String.Empty;//txtNroDocu.Text.Trim();

            //===================================================================
            //--Generar XML de Datos Aho Programado
            //===================================================================

            dtAhorroProgramando = cnCalculosAho.CalculaPpgDep(0.00m, clsVarGlobal.dFecSystem, clsVarGlobal.dFecSystem, 1, 0, 2, clsVarGlobal.dFecSystem.Day, 0);

            DataSet dsAhorroProgamado = new DataSet("dsDeposito");
            dsAhorroProgamado.Tables.Add(dtAhorroProgramando);
            string xmlAhoPrg = clsCNFormatoXML.EncodingXML(dsAhorroProgamado.GetXml());

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable tbCliIntervi = dtIntervinientesConfirmacion.Clone();
            for (int i = 0; i < dtIntervinientesConfirmacion.Rows.Count; i++)
            {
                tbCliIntervi.ImportRow(dtIntervinientesConfirmacion.Rows[i]);
            }

            DataSet dsInterv = new DataSet("dsDeposito");
            dsInterv.Tables.Add(tbCliIntervi);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsInterv.GetXml());

            //===================================================================
            //--Generar XML de Datos de las Cuentas Canceladas
            //===================================================================
            DataTable dtCtasCancel = dtCuentasCanceladas.Clone();
            for (int i = 0; i < dtCuentasCanceladas.Rows.Count; i++)
            {
                dtCtasCancel.ImportRow(dtCuentasCanceladas.Rows[i]);
            }

            DataSet dsCtasCancel = new DataSet("dsDeposito");
            dsCtasCancel.Tables.Add(dtCtasCancel);
            string xmlCtasCancel = clsCNFormatoXML.EncodingXML(dsCtasCancel.GetXml());

            //===================================================================
            //--Guardar Apertura Cuenta
            //===================================================================
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue);
            int nCuotas = 0;
            //int idCanal = 1;

            decimal nMonOpe = 0.00m;
            decimal nMonCapital = 0.00m;

            bool lEsAhoProg = false;
            bool lEsCtaCTS = false;
            
            int idCtaTrans = idCuentaApertura;

            //===================================================================
            //--Generar XML de Datos Comisiones
            //===================================================================
            DataSet dsComision = new DataSet("dsDeposito");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

            DataSet dsAhoPrg = new DataSet("dsDeposito");

            //===================================================================
            //--Registrar Apertura de Cuenta
            //===================================================================

            clsCNAperturaCta dtRegApe = new clsCNAperturaCta();
            DataTable tbRegApe = dtRegApe.RegistraConfirmApeCtaAutomatico(idCuentaApertura, xmlComision, xmlTipPago, xmlInterv,
                                            nMonOpe, 0, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, nCuotas,
                                            lEsAhoProg, false, lEsCtaCTS, cNroDocPag, idEntFin, idCtaTrans, idTipPago,
                                            0, 0, 0, 0, nMonCapital, 1, 0,
                                            false, 1, idTasa, nTasaCompensatorio, 0, true);
            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE CUENTA: " + tbRegApe.Rows[0]["idNroCta"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //--Liberar Variables

                dtTasa.Dispose();
                dtEmp.Dispose();
                dsEmpleador.Dispose();
                dtDatosPago.Dispose();
                dsTipoPago.Dispose();
                dtAhorroProgramando.Clear();
                dsAhorroProgamado.Dispose();
                tbCliIntervi.Clear();
                dsInterv.Dispose();
                dtCtasCancel.Dispose();
                dsCtasCancel.Clear();
                dsComision.Dispose();
                dsAhoPrg.Dispose();
                tbRegApe.Dispose();
                dtComision = new DataTable();
                HabilitarDatosEnvioExtracto(false);
                Limpiar();
                return true;
            }
            else
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtTasa.Dispose();
                dtEmp.Dispose();
                dsEmpleador.Dispose();
                dtDatosPago.Dispose();
                dsTipoPago.Dispose();
                dtAhorroProgramando.Clear();
                dsAhorroProgamado.Dispose();
                tbCliIntervi.Clear();
                dsInterv.Dispose();
                dtCtasCancel.Dispose();
                dsCtasCancel.Clear();
                dsComision.Dispose();
                dsAhoPrg.Dispose();
                tbRegApe.Dispose();
                Limpiar();
                HabilitarDatosEnvioExtracto(true);
                return false;
            }

        }

        private void Limpiar()
        {
            dtIntervinientesSolicitud.Clear();
            dtAhorroProgramando.Clear();
            dtCuentasCanceladas.Clear();
            dtComision.Clear();
        }

        private void Comision()
        {
            dtComision = null;
            int x_idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            int idCta = Convert.ToInt32(idCuentaApertura);
            Decimal nMonto = Convert.ToDecimal(0);

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProductoDefecto, 9, Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPersona"]), Convert.ToInt16(dtSolicitud.Rows[0]["idMoneda"]),
                                                        idCta, 1, clsVarGlobal.nIdAgencia, nMonto, 0, x_idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal(dtComision.Compute("SUM(nValorAplica)", ""));
            }
        }

        public void FormatearIntervinientesSolicitud()
        {
            dtIntervinientesSolicitud.Columns.Add("codigo", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("nombres", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("tipodoc", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("documento", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("idTipoInterv", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("idCuenta", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("direccion", typeof(string));
            dtIntervinientesSolicitud.Columns.Add("lEsAfeItf", typeof(bool));
            dtIntervinientesSolicitud.Columns.Add("idTipoDocumento", typeof(int));
        }

        private void FormatearCuentasCanceladas()
        {
            dtCuentasCanceladas.Columns.Add("lMarca", typeof(string));
            dtCuentasCanceladas.Columns.Add("idCuenta", typeof(int));
            dtCuentasCanceladas.Columns.Add("cMoneda", typeof(string));
            dtCuentasCanceladas.Columns.Add("cProducto", typeof(string));
            dtCuentasCanceladas.Columns.Add("cTipoCuenta", typeof(string));
            dtCuentasCanceladas.Columns.Add("dFechaCancelacion", typeof(DateTime));
        }

        private void CargarModalidadPago()
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(9);
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

        private void LlenarTiposDeDocumento()
        {
            DataTable dt = cnListaFormatoImp.CNListaFormato();

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
        }

        private void ConverNumLetras(Decimal nMontoTotal, ref string cMontoLetras)
        {
            cnNumLetras.LetraCapital = true;
            cnNumLetras.MascaraSalidaDecimal = "/100 " + cboMoneda.Text;
            cnNumLetras.SeparadorDecimalSalida = "con";
            cnNumLetras.Decimales = 2;
            cMontoLetras = cnNumLetras.ToCustomCardinal(nMontoTotal);
        }

        public string CharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private void AsignarValImp(bool lIndCerti, bool lIndCartilla, bool lIndOrdDep, bool lisCtaCTS)
        {
            for (int i = 0; i < dtFormatos.Rows.Count; i++)
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

        private bool VincularCuentaDepositoCredito()
        {
            int idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]);

            DataTable dtResultado = cnSolicitud.VincularCuentaDepositoCredito(idSolicitud, idCuentaApertura, idCuentaCredito, lNuevaCuenta);

            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 0)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void HabilitarDatosEnvioExtracto(bool lValor)
        {
            cboEnvioEstCta.Enabled = lValor;
            txtDireccionEnvioEstCta.Enabled = (Convert.ToInt32(cboEnvioEstCta.SelectedValue) == 3) ? false: lValor;
        }

        private bool ValidarDatosEnvioExtracto()
        {
            bool lValida = true;
            if (cboEnvioEstCta.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la modalidad del envio de estado de cuenta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lValida = false;
            }
            if(String.IsNullOrEmpty(txtDireccionEnvioEstCta.Text))
            {
                if(Convert.ToInt32(cboEnvioEstCta.SelectedValue) == 1)
                {
                    MessageBox.Show("Ingrese la direccion a la que se enviara el estado de cuenta ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lValida = false;
                }
                else if(Convert.ToInt32(cboEnvioEstCta.SelectedValue) == 2)
                {
                    MessageBox.Show("Ingrese email al que se enviara el estado de cuenta ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lValida = false;
                }
            }
            return lValida;
        }
        #endregion
    }
}
