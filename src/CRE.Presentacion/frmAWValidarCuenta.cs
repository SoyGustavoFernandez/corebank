using CLI.Presentacion;
using DEP.CapaNegocio;
using DEP.CapaNegocio.AhorroWeb;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmAWValidarCuenta : frmBase
    {
        #region Variables Privadas
        private clsCNDeposito cnDeposito = new clsCNDeposito();
        private clsCNAWPostApertura objCNAWPostApertura = new clsCNAWPostApertura(); 
        private DataTable dtFormatos = new DataTable();
        private clsCNImpresion cnImpresion = new clsCNImpresion();
        private clsCNListaFormatoImp cnListaFormatoImp = new clsCNListaFormatoImp();
        private clsAWTramite objAWTramite = new clsAWTramite();

        private int idCli;
        private int idCuenta;
        private int idModulo;
        private string cDocumentoID;
        private DataTable dtResValidacionCuenta;
        #endregion

        #region Variables Públicas
        public bool lCancelado = false;
        #endregion

        #region Constructores
        public frmAWValidarCuenta(int idCuenta, int idModulo, string cDocumentoID, DataTable dtResValidacionCuenta)
        {
            InitializeComponent();
            
            this.idCuenta = idCuenta;
            this.idModulo = idModulo;
            this.cDocumentoID = cDocumentoID;
            this.dtResValidacionCuenta = dtResValidacionCuenta;

            this.chcIdentidadValidada.Enabled = false;
            this.chcDatosActualizados.Enabled = false;
            this.chcDocumentosRegularizados.Enabled = false;

            this.chcIdentidadValidada.Checked = bool.Parse(this.dtResValidacionCuenta.Rows[0]["lIdentidadConfirmada"].ToString());
            this.idCli = Int32.Parse(this.dtResValidacionCuenta.Rows[0]["idCli"].ToString());
            this.chcDatosActualizados.Checked = this.dtResValidacionCuenta.Rows[0]["lDatosCliente"].ToString() == "1";
            this.chcDocumentosRegularizados.Checked = this.dtResValidacionCuenta.Rows[0]["lImpresionDocumentos"].ToString() == "1";

            this.btnValidarCliente.Enabled = !this.chcIdentidadValidada.Checked;
            this.btnValidarDatos.Enabled = !this.chcDatosActualizados.Checked;
            this.btnValidarImpresion.Enabled = !this.chcDocumentosRegularizados.Checked;
        }
        #endregion

        #region Métodos Públicos
        public bool validarCuentaAperturada()
        {
            if (!this.chcIdentidadValidada.Checked || !this.chcDatosActualizados.Checked || !this.chcDocumentosRegularizados.Checked)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Métodos Privados
        private void btnValidarCliente_Click(object sender, EventArgs e)
        {
            frmConsultaDni frmConsultaDni = new frmConsultaDni(this.cDocumentoID);
            frmConsultaDni.ShowDialog();
            this.chcIdentidadValidada.Checked = true;
            this.btnValidarCliente.Enabled = false;
            this.btnCancelar.Enabled = !this.validarCuentaAperturada();
        }

        private void btnValidarDatos_Click(object sender, EventArgs e)
        {
            if (!this.chcIdentidadValidada.Checked)
            {
                MessageBox.Show("Debe validar la identidad del cliente, antes de actualizar sus datos.", "Validar Apertura de Cuenta en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmAWActualizarCliente frmAWActualizarCliente = new frmAWActualizarCliente(this.idCli);
            frmAWActualizarCliente.ShowDialog();
            if (!frmAWActualizarCliente.lCancelado)
            {
                this.chcDatosActualizados.Checked = true;
                this.btnValidarDatos.Enabled = false;
            }
            this.btnCancelar.Enabled = !this.validarCuentaAperturada();
        }

        private void btnValidarImpresion_Click(object sender, EventArgs e)
        {
            if (!this.chcDatosActualizados.Checked)
            {
                MessageBox.Show("Debe Actualizar los datos mínimos necesarios del cliente, antes de Imprimir los documentos contractuales de la Cuenta.", "Validar Apertura de Cuenta en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            imprimirDocumentosCtaAhorro(idCuenta);
            this.chcDocumentosRegularizados.Checked = true;

            this.btnValidarImpresion.Enabled = false;
            this.btnCancelar.Enabled = !this.validarCuentaAperturada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.lCancelado = true;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!this.validarCuentaAperturada())
            {
                if (!this.chcIdentidadValidada.Checked)
                {
                    MessageBox.Show("Debe validar la identidad del cliente.", "Validar Apertura de Cuenta en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!this.chcDatosActualizados.Checked)
                {
                    MessageBox.Show("Debe Actualizar los datos mínimos necesarios del cliente.", "Validar Apertura de Cuenta en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!this.chcDocumentosRegularizados.Checked)
                {
                    MessageBox.Show("El cliente debe firmar los documentos de la Apertura de Cuenta.", "Validar Apertura de Cuenta en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }
            else
            {
                DialogResult drResult = MessageBox.Show("Al presionar 'Aceptar' confirmo la veracidad de la verificación de datos del cliente.", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (drResult == DialogResult.OK)
                {                                        
                    this.objAWTramite.idAgenciaRegulariza = clsVarGlobal.nIdAgencia;
                    this.objAWTramite.idUsuarioRegulariza = clsVarGlobal.User.idUsuario;
                    this.objAWTramite.dFechaRegulariza = clsVarGlobal.dFecSystem;
                    this.objAWTramite.lIdentidadConfirmada = this.chcIdentidadValidada.Checked;
                    this.objAWTramite.lDatosRegularizados = this.chcDatosActualizados.Checked;
                    this.objAWTramite.lDocumentosRegularizados = this.chcDocumentosRegularizados.Checked;
                    this.objCNAWPostApertura.registrarRegularizacion(this.idCuenta, this.objAWTramite);
                    this.Close();
                }                
            }
        }
        
        private void imprimirDocumentosCtaAhorro(int idCuentaApertura)
        {
            LlenarTiposDeDocumento();
            int fila = 0;
            bool lIndImpre = false;
            string cMontoLetras = String.Empty;
            decimal nMontoDeposito = 0.00m;
            int nNumeroImpresiones = 0;
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

                                    reportpathCart = "rptCartillaInforCTS.rdlc";
                                    break;
                                case 48: //Plazo Fijo

                                        paramlistCart.Add(new ReportParameter("x_lOriginal", "1", false));
                                        dtslistCart.Add(new ReportDataSource("dtsInterv", dtIntervs));

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

            //btnImprimir1.Enabled = false;
            //btnGrabar.Enabled = false;
            //btnSalir1.Enabled = true;
            //lblMensaje.Text = String.Empty;
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

        private void ConverNumLetras(Decimal nMontoTotal, ref string cMontoLetras)
        {
            clsNumLetras cnNumLetras = new clsNumLetras();
            cnNumLetras.LetraCapital = true;
            cnNumLetras.MascaraSalidaDecimal = "/100 " + this.dtResValidacionCuenta.Rows[0]["cMoneda"].ToString();
            cnNumLetras.SeparadorDecimalSalida = "con";
            cnNumLetras.Decimales = 2;
            cMontoLetras = cnNumLetras.ToCustomCardinal(nMontoTotal);
        }

        private string CharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
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
        #endregion
    }
}
