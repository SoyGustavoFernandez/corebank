using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using DEP.CapaNegocio;
using System.Net;
using System.Net.Mail;

using System.IO;

namespace CRE.Presentacion
{
    public partial class frmSolicitudCondonacion : frmBase
    {

        #region Variables

        CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsFunUtiles objFunciones = new clsFunUtiles();

        int idCuenta = 0;
        private DataTable tbDatosCuenta;
        String xmlCoutasCondonadas = clsCNFormatoXML.EncodingXML(" "); 
        String cGastosSeguro = String.Empty;

        int nAtraso    = 0;
        int idContable = 0;

        public DataTable archivos = null;
        public string tipoFormulario = "M";
        //int idCuenta = 0;
        int idSolAproba = 0;
        decimal getnMontoPagar = 0;

        int cboCorrespondeciaTmp = 1;
        int cboCondonacionTmp = 1;
        private bool lvalidaCboCorrespondencia = false;

        #endregion
        public frmSolicitudCondonacion()
        {
            InitializeComponent();
        }
        #region Eventos

        public DataTable getDtgFiles()
        {
            return archivos;
        }

        private void frmSolicitudCondonacion_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            this.conBusCuentaCli.MyClic += new EventHandler(conBusCuentaCli_MyClic);
            this.conBusCuentaCli.MyKey += new KeyPressEventHandler(conBusCuentaCli_MyKey);

            HabilitarControles(false);

            cboMot.CargarMotivos(2);
            cboTipoCorrespondencia1.SelectedIndexChanged -= cboTipoCorrespondencia1_SelectedIndexChanged;
            this.cboTipoCondonacion1.ListaCondonacionVigentes(clsVarGlobal.PerfilUsu.idPerfil);
            this.cboTipoCorrespondencia1.ListaTipoCorrespondencia();
            cboTipoCorrespondencia1.SelectedIndexChanged += cboTipoCorrespondencia1_SelectedIndexChanged;

            this.conBusCuentaCli.txtCodCli.Enabled = true;
            this.conBusCuentaCli.txtCodCli.BackColor = Color.White;
            
            this.activarControlCobs(false);
            this.mostrarSubTipoCorrespondencia(false);
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            cboTipoCorrespondencia1.SelectedIndex = 0;
            CleanData();
            
            nMontoPagar.Text = "0";
            nMontoCondonar.Text = "0";
            conBusCuentaCli.limpiarControles();
            btnEnviar.Enabled = false;
            btnAdjuntarFile1.Enabled = false;
            btnRptSbs.Enabled = false;
            btnCancelar.Enabled = false;
            cboMot.Enabled = true;
            txtMot.Enabled = true;
            nMontoCondonar.Text = "0.00";
            maxCondonacion.Text = "0";
            idSolAproba = 0;
            HabilitarControles(false);
            //((DataTable)dtgCobs.DataSource).Clear();
            ((DataTable)dtgCobs.DataSource).Clear();
            //dtgCobs.Rows.Clear();
            txtAgencia.Clear();
            txtNroCondonaciones.Clear();
            archivos = null;
            btnRptSbs.Visible = false;
            txtNroDepositos.Clear();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            //MessageBox.Show("Guardandose..");
            
            if (cboTipoCorrespondencia1.SelectedIndex != 1)
            {
                this.xmlCoutasCondonadas = "<Table1></Table1>";  
            }

            decimal nMontoPagarFin = Convert.ToDecimal(nMontoPagar.Text);
            if (dtgCobs.RowCount == 0)
                nMontoPagarFin = 0;

            string archivosXML = "<NewDataSet/>";

            if (archivos != null)
            {
                archivosXML = convertXMLFiles(archivos);
            }
            
            DataTable tbInsDet = SolicCondonacion.CNInsertaDetalleCondonado(Convert.ToInt32(clsVarGlobal.nIdAgencia), Convert.ToInt32(tbDatosCuenta.Rows[0]["idCli"]), 7, 1,
                                                                            Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]), Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]), Convert.ToDecimal(txtCondTotal.Text),
                                                                            Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]), Convert.ToInt32(cboMot.SelectedValue), Convert.ToString(txtMot.Text), 1,
                                                                            Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario), false,
                                                                            Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text),
                                                                            Convert.ToDecimal(txtCondCapital.Text),
                                                                            Convert.ToDecimal(txtCondInteres.Text),
                                                                            Convert.ToDecimal(txtCondIntComp.Text),
                                                                            Convert.ToDecimal(txtCondMora.Text),
                                                                            Convert.ToDecimal(txtCondOtros.Text),
                                                                            Convert.ToInt32(this.cboTipoCondonacion1.SelectedValue),
                                                                            Convert.ToDecimal(this.txtCap.Text),
                                                                            Convert.ToDecimal(this.txtInt.Text),
                                                                            Convert.ToDecimal(this.txtIntComp.Text),
                                                                            Convert.ToDecimal(this.txtMora.Text),
                                                                            Convert.ToDecimal(this.txtOtro.Text),
                                                                            false,
                                                                            "", //txtNumeroCtaCOB.Text.Trim(),
                                                                            Convert.ToDecimal(txtMontoTotalCTA.Text.Trim()),
                                                                            this.xmlCoutasCondonadas,
                                                                            archivosXML,
                                                                            Convert.ToInt32(cboTipoCorrespondencia1.SelectedValue),
                                                                            obtenerXmlCobs()
                                                                            , (string.IsNullOrEmpty(txtCuotasCondonar.Text) ? 0 : Convert.ToInt32(txtCuotasCondonar.Text))
                                                                            , nMontoPagarFin
                                                                            , Convert.ToDecimal(txtITF.Text)
                                                                            , Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil)
                                                                            , Convert.ToInt32(cboSubTipoCorrespondencia1.SelectedValue)
                                                                            );

            if (Convert.ToInt32(tbInsDet.Rows[0]["lEstadoProc"].ToString()) == 0)
            {
                MessageBox.Show("Error al insertar detalle de condonación", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(Convert.ToInt32(tbInsDet.Rows[0]["idSolAproba"]), Convert.ToInt32(Modulo.CREDITOS), Convert.ToInt32(TipoOperacion.CONDONACION));
                objNivelAproba.obtenerNivelAprobacionSolicitud();
                if (objNivelAproba.getIdNivelAprobacion() != 0)
                {
                    this.guardarParaAprobar(EstadoAprobacion.VoBo, Convert.ToInt32(tbInsDet.Rows[0]["idSolAproba"]));
                    if (Int32.Parse(txtDiasAtraso.Text) >= 1 && Int32.Parse(txtDiasAtraso.Text) <= 30)
                    {
                        if (Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 3 || Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 4)
                        {
                            enviarAlertaCorreo();
                        }
                    }
                    MessageBox.Show(tbInsDet.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbInsDet.Rows[0]["idSolAproba"].ToString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                archivos = null;
            }

            cboMot.Enabled = false;
            txtMot.Enabled = false;
            btnEnviar.Enabled = false;
            btnAdjuntarFile1.Enabled = false;
            btnRptSbs.Enabled = false;
            btnCancelar.Enabled = true;

            HabilitarControles(false);
        }
        private void txtCondCapital_Validating(object sender, CancelEventArgs e)
        {            
            validarMonto(this.txtCondCapital, this.txtCap, this.lblMaxDesCapital);
        }
        private void txtCondCapital_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validarMonto(this.txtCondCapital, this.txtCap, this.lblMaxDesCapital);
            }
        }

        private void txtCondInteres_Validating(object sender, CancelEventArgs e)
        {            
            validarMonto(this.txtCondInteres, this.txtInt, lblMaxDesInteres);
        }
        private void txtCondInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validarMonto(this.txtCondInteres, this.txtInt, lblMaxDesInteres);
            }
        }

        private void txtCondIntComp_Validating(object sender, CancelEventArgs e)
        {            
            validarMonto(this.txtCondIntComp, this.txtIntComp, this.lblMaxDesIntComp);
        }
        private void txtCondIntComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validarMonto(this.txtCondIntComp, this.txtIntComp, this.lblMaxDesIntComp);
            }
        }

        private void txtCondOtros_Validating(object sender, CancelEventArgs e)
        {            
            validarMonto(this.txtCondOtros, this.txtOtro, this.lblMaxDesGastos);
            calculaGastoSeguro();
        }
        private void txtCondOtros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validarMonto(this.txtCondOtros, this.txtOtro, this.lblMaxDesGastos);
                calculaGastoSeguro();
            }
        }

        private void txtCondMora_Validating(object sender, CancelEventArgs e)
        {
            validarMonto(this.txtCondMora, this.txtMora, this.lblMaxDesMora);
        }
        private void txtCondMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validarMonto(this.txtCondMora, this.txtMora, this.lblMaxDesMora);
            }
        }
       
        private void frmSolicitudCondonacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }
        private void cboTipoCondonacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTipoCorrespondencia1.ListaTipoCorrespondencia();
            this.lvalidaCboCorrespondencia = false;
            if (Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 10)
            {
                this.lvalidaCboCorrespondencia = true;
            }
            verificaCampania();
        }
    
        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            int idCli = 0;
            String cDocumento = String.Empty;
            Int32 nCifras = conBusCuentaCli.txtCodCli.TextLength;
            if (nCifras == 0)
            {
                MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCuentaCli.txtCodCli.Focus();
                idCli = 0;
            }
            else
            {
                if (Convert.ToInt32(this.conBusCuentaCli.txtCodCli.Text) <= 0)
                {
                    MessageBox.Show("Ingrese un Código de Cliente Válido", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.conBusCuentaCli.txtCodCli.Focus();
                    this.conBusCuentaCli.txtCodCli.SelectAll();
                    idCli = 0;
                    return;
                }
                idCli = Convert.ToInt32(this.conBusCuentaCli.txtCodCli.Text);
                //conBusCuentaCli.buscarCuentasPorCliente(idCli);
                string cEvento = conBusCuentaCli.buscarCuentasPorCliente(idCli);
                switch (cEvento)
                {
                    case "E": // evento Solo
                        //if (conBusCuentaCli.MyClic != null)
                        //conBusCuentaCli.MyClic(sender, e);
                        this.conBusCuentaCli.txtCodCli.Clear();
                        LoadData();
                        this.conBusCuentaCli.txtCodCli.Focus();
                        break;
                    case "EB": // evento Botones
                        //if (conBusCuentaCli.MyClic != null)
                        //{
                        //conBusCuentaCli.MyClic(sender, e);
                        //this.conBusCuentaCli.txtCodCli.Clear();
                        LoadData();
                        conBusCuentaCli.btnBusCliente1.Enabled = false;
                        conBusCuentaCli.txtNroBusqueda.Enabled = false;
                        //}
                        break;
                }               
            }
        }
        #endregion

        #region Métodos
        private void verificaCampania()
        {
            Boolean lAplicaReglas = false;
            DataTable dtReglasCondonacion = SolicCondonacion.listaReglasTipoCondonaXCondicCtb(Convert.ToInt32(this.cboTipoCondonacion1.SelectedValue), Convert.ToInt32(this.cboCondicionContNormal.SelectedValue));

            if (dtReglasCondonacion.Rows.Count != 0) // DEBE EXISTIR REGLAS
            {
                if (dtReglasCondonacion.Rows[0]["idRangoTipoDato"].ToString() == "0") //sin rangos
                {
                    foreach (DataRow item in dtReglasCondonacion.Rows)
                    {
                        muestraPorcDesc(Convert.ToDecimal (item["nPorcDsctoCapital"].ToString()),
                                        Convert.ToDecimal (item["nPorcDsctoInteres"].ToString()),
                                        Convert.ToDecimal (item["nPorcDsctoIntComp"].ToString()),
                                        Convert.ToDecimal (item["nPorcDsctoMora"].ToString()),
                                        Convert.ToDecimal (item["nPorcDsctoGastos"].ToString())
                                        );
                        lAplicaReglas = true;
                    }
                }
                if (dtReglasCondonacion.Rows[0]["idRangoTipoDato"].ToString() == "1") //dias de atraso
                {
                    foreach (DataRow item in dtReglasCondonacion.Rows)
                    {
                        if (Convert.ToInt32(item["nRangoMinimo"].ToString()) <= Convert.ToInt32(this.txtDiasAtraso.Text) && Convert.ToInt32(this.txtDiasAtraso.Text) <= Convert.ToInt32(item["nRangoMaximo"].ToString()))
                        {
                            muestraPorcDesc(Convert.ToDecimal (item["nPorcDsctoCapital"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoInteres"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoIntComp"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoMora"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoGastos"].ToString())
                                         );
                            lAplicaReglas = true;
                            break;
                        }
                    }
                }
                if (dtReglasCondonacion.Rows[0]["idRangoTipoDato"].ToString() == "2") //año de castigo
                {
                    foreach (DataRow item in dtReglasCondonacion.Rows)
                    {
                        if (Convert.ToInt32(item["nRangoMinimo"].ToString()) <= Convert.ToInt32(this.txtAnioCastigo.Text) && Convert.ToInt32(this.txtAnioCastigo.Text) <= Convert.ToInt32(item["nRangoMaximo"].ToString()))
                        {
                            muestraPorcDesc(Convert.ToDecimal (item["nPorcDsctoCapital"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoInteres"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoIntComp"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoMora"].ToString()),
                                            Convert.ToDecimal (item["nPorcDsctoGastos"].ToString())
                                         );
                            lAplicaReglas = true;
                            break;
                        }
                    }
                }
                /*********************/
                decimal deuda = (Math.Truncate(Convert.ToDecimal(txtOtro.Text) * Convert.ToDecimal(lblMaxDesGastos.Text)) / 100) +
                (Math.Truncate(Convert.ToDecimal(txtMora.Text) * Convert.ToDecimal(lblMaxDesMora.Text)) / 100) +
                (Math.Truncate(Convert.ToDecimal(txtIntComp.Text) * Convert.ToDecimal(lblMaxDesIntComp.Text)) / 100) +
                (Math.Truncate(Convert.ToDecimal(txtInt.Text) * Convert.ToDecimal(lblMaxDesInteres.Text)) / 100) +
                (Math.Truncate(Convert.ToDecimal(txtCap.Text) * Convert.ToDecimal(lblMaxDesCapital.Text)) / 100);
                maxCondonacion.Text = deuda.ToString();
                minPagar.Text =  deuda.ToString();
                minPagar.Text = (Convert.ToDecimal(txtTotal.Text) - deuda).ToString();
                /*********************/

                
            }

            if (!lAplicaReglas)
            {
                if (this.lvalidaCboCorrespondencia == true)
                {
                    this.cboTipoCorrespondencia1.ListaTipoCorrespondenciaEspecific();
                    if (this.lvalidaCboCorrespondencia == true)
                    {
                        MessageBox.Show("Para esta campaña los DÍAS DE ATRASO se deben encontrar entre 91 a 120 días.", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.lvalidaCboCorrespondencia = false;
                        this.btnCancelar.PerformClick();
                    }
                    reiniarPorcDesc(0);
                    this.btnEnviar.Enabled = false;
                    this.btnAdjuntarFile1.Enabled = false;
                    this.btnRptSbs.Enabled = false;
                    verificarCambioCombos();

                }
                else if (this.lvalidaCboCorrespondencia == false && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) != 10)
                {
                    MessageBox.Show("La cuenta no cumple caracteristicas para la campaña", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    reiniarPorcDesc(0);
                    this.btnEnviar.Enabled = false;
                    this.btnAdjuntarFile1.Enabled = false;
                    this.btnRptSbs.Enabled = false;
                    //***this.chcPorCuota.Enabled = false;
                }
            }
            else
            {
                this.btnEnviar.Enabled = true;
                this.btnAdjuntarFile1.Enabled = true;
                this.btnRptSbs.Enabled = true;
                //**this.chcPorCuota.Enabled = true;
                this.txtCondCapital.Text = "0.00";
                this.txtCondInteres.Text = "0.00";
                this.txtCondIntComp.Text = "0.00";
                this.txtCondMora.Text = "0.00";
                this.txtCondOtros.Text = "0.00";
                this.txtCondTotal.Text = "0.00";

                verificarCambioCombos();
            }
        }
        private void validarMonto(txtNumRea txtCond, txtNumRea txtDeuda, lblBase lblMaxPorcentajeDsto, bool lActualizaSaldo = true)
        {
            Decimal d;
            /*if (string.IsNullOrEmpty(txtCond.Text))
            {
                txtCond.Text = "0.00";
            }
            if (!Decimal.TryParse(txtCond.Text, out d))
            {
                MessageBox.Show("Ingrese un monto correcto", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCond.Text = "0.00";
                txtCond.Focus();
            }
            if (0 > Convert.ToDecimal(txtCond.Text))
            {
                MessageBox.Show("El monto a condonar no puede ser negativo", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCond.Text = "0.00";
                txtCond.Focus();
            }
            if (Convert.ToDecimal(txtCond.Text) > (Convert.ToDecimal(txtDeuda.Text) * Convert.ToDecimal(lblMaxPorcentajeDsto.Text)) / 100)
            {
                MessageBox.Show("El monto a condonar supera el porcentaje máximo de descuento", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCond.Text = ((Convert.ToDecimal(txtDeuda.Text) * Convert.ToDecimal(lblMaxPorcentajeDsto.Text)) / 100).ToString();
                txtCond.Focus();
            }*/
            txtCond.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCond.Text));
            CalculaCond(lActualizaSaldo);
        }
        public void LoadData()
        {
           CleanData();

            int idCuenta_ = Convert.ToInt32(conBusCuentaCli.nValBusqueda);
            if (esPendienteARefinanciar(idCuenta_)  )
            {
                btnRptSbs.Visible = false;
                LiberarCuenta();
                CleanData();
                conBusCuentaCli.limpiarControles();
                return;
            }
            tbDatosCuenta = Credito.CNSaldoCredito(conBusCuentaCli.nValBusqueda);
            if (tbDatosCuenta.Rows.Count > 0)
            {
                txtCap.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALCAP"]));
                txtInt.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALINT"]));
                txtIntComp.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nSalIntComp"]));
                txtOtro.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALOTR"]));
                txtMora.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALMOR"]));
                //txtTotal.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]));
                txtTotal.Text = Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]).ToString();

                txtSaldoCap.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALCAP"]));
                txtSaldoInt.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALINT"]));
                txtSaldoIntComp.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nSalIntComp"]));
                txtSaldoOtr.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALOTR"]));
                txtSaldoMora.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALMOR"]));
                txtSaldoTotal.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]));
                txtMontoDesembolsado.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nCapitalDesembolso"]));
                txtAgencia.Text = tbDatosCuenta.Rows[0]["cNombreAge"].ToString();
                txtNroCondonaciones.Text = tbDatosCuenta.Rows[0]["nNroCondo"].ToString();
                txtFechaDesmbolso.Text = Convert.ToDateTime(tbDatosCuenta.Rows[0]["dFechaDesembolso"]).ToString("yyyy-MM-dd");
                txtNroCuotas.Text = tbDatosCuenta.Rows[0]["nCuotas"].ToString();
                                
                this.conProducto1.cargarProductos(1, Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]));
                this.txtDiasAtraso.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAtraso"]);
                this.cboCondicionContNormal.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableNormal"]);
                this.cboCondicionContVenc.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableVenc"]);
                this.txtAnioCastigo.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAnioCastigo"]);
                this.cboMoneda1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]);
                this.idCuenta = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCuenta"]);

                idContable = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableVenc"]);
                nAtraso = Convert.ToInt32(tbDatosCuenta.Rows[0]["nAtraso"]);

                DataTable dtDepositos = new clsCNDeposito().CNConsultaDeposito(Convert.ToInt32(tbDatosCuenta.Rows[0]["idCli"]), "[1]");
                txtNroDepositos.Text = dtDepositos.Rows.Count.ToString();

                DataTable dtGastosSeguro = SolicCondonacion.obtieneGastosCuenta(this.idCuenta, 2, Convert.ToInt32(tbDatosCuenta.Rows[0]["idPlanPagos"]), 0);//2 = gastos de seguro
                if (dtGastosSeguro.Rows.Count > 0)
                {
                    this.lblSeguro.Text = dtGastosSeguro.Rows[0]["nSuma"].ToString();
                    this.lblSeguro.Visible = true;
                    this.cGastosSeguro = "Existen gastos por Seguro.";
                }
                else {
                    this.lblSeguro.Text = "0.00";
                    this.lblSeguro.Visible = false;
                }

                //Validar que no exista una solicitud pendiente o aprobada

                DataTable SolicDuplicada = SolicCondonacion.CNBuscaSolicitudAprobacion(Convert.ToInt32(tbDatosCuenta.Rows[0]["idCli"]), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
                btnRptSbs.Visible = false;
                if (SolicDuplicada.Rows.Count > 0)
                {
                    btnRptSbs.Visible = true;
                    if (btnEnviar.Visible)
                    {
                        MessageBox.Show("La solicitud de condonación ya fue enviada por:" +
                                        "\nUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                        "\nAgencia:  " + SolicDuplicada.Rows[0]["cNombreAge"] +
                                        "\nFecha:    " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación",
                                                                                                                                        MessageBoxButtons.OK,
                                                                                                                                        MessageBoxIcon.Exclamation);
                        idSolAproba = Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAProba"]);
                    }
                    tbDatosCuenta = Credito.CNObtieneDetalleCondonacion(Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAproba"]));

                    if (tbDatosCuenta.Rows.Count > 0)
                    {
                        cboTipoCondonacion1.SelectedIndexChanged -= cboTipoCondonacion1_SelectedIndexChanged;
                        cboTipoCorrespondencia1.SelectedIndexChanged -= cboTipoCorrespondencia1_SelectedIndexChanged;
                        nMontoCondonar.TextChanged -= nMontoCondonar_TextChanged_1;
                        nMontoPagar.KeyPress -= nMontoPagar_KeyPress;
                        nMontoPagar.Leave -= nMontoPagar_Leave;
                        if (Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCondonacion"]) == 1 && ((System.Data.DataRowView)cboTipoCondonacion1.SelectedItem).Row.ItemArray[0].ToString() != "1")
                        {
                            this.cboTipoCondonacion1.ListaCondonacionVigentes(0);
                        }
                        cboTipoCondonacion1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCondonacion"]);

                        cboTipoCorrespondencia1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCorr"]);

                        if (Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 3 || Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 4)
                        {
                            mostrarSubTipoCorrespondencia(true);
                            this.cboSubTipoCorrespondencia1.ListarSubTipoCorrespondencia(Convert.ToInt32(this.cboTipoCorrespondencia1.SelectedValue));
                            cboSubTipoCorrespondencia1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idSubTipoCorrespon"]);
                        }

                        txtCondCapital.Text = tbDatosCuenta.Rows[0]["NSALCAP"].ToString();
                        txtCondInteres.Text = tbDatosCuenta.Rows[0]["NSALINT"].ToString();
                        txtCondIntComp.Text = tbDatosCuenta.Rows[0]["nSalIntComp"].ToString();
                        txtCondOtros.Text = tbDatosCuenta.Rows[0]["NSALOTR"].ToString();
                        txtCondMora.Text = tbDatosCuenta.Rows[0]["NSALMOR"].ToString();
                        txtCondTotal.Text = tbDatosCuenta.Rows[0]["NSALTOT"].ToString();

                        txtCuotasCondonar.Text = tbDatosCuenta.Rows[0]["nNroCuotasACondonar"].ToString();
                        nMontoPagar.Text = Convert.ToDecimal(tbDatosCuenta.Rows[0]["nMontoAPagar"]).ToString("N2");
                        txtITF.Text = Convert.ToDecimal(tbDatosCuenta.Rows[0]["nMontoITF"]).ToString("N2");
                        nMontoCondonar.Text = Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]).ToString("N2");

                        CalculaCond(false);
                        this.activarControlCobs(false);
                        if (Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCondonacion"]) == 2)
                        {
                            abrirFrmXcuotas(false);
                        }
                        if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lPorCouta"]))
                        {
                            DataTable dtCoutasCond = SolicCondonacion.ListaDetalleCondXCuota(Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAproba"]));
                            DataSet dsCoutasCondonadas = new DataSet("DSCoutasCondonadas");
                            String xmlCoutasCond = String.Empty;
                            if (dtCoutasCond.Rows.Count > 0)
                            {
                                dsCoutasCondonadas.Tables.Add(dtCoutasCond);
                                xmlCoutasCond = dsCoutasCondonadas.GetXml();
                                xmlCoutasCond = clsCNFormatoXML.EncodingXML(xmlCoutasCond);
                                dsCoutasCondonadas.Tables.Clear();
                            }
                            this.xmlCoutasCondonadas = xmlCoutasCond;

                        }

                        cboTipoCondonacion1.SelectedIndexChanged += cboTipoCondonacion1_SelectedIndexChanged;
                        cboTipoCorrespondencia1.SelectedIndexChanged += cboTipoCorrespondencia1_SelectedIndexChanged;
                        nMontoCondonar.TextChanged += nMontoCondonar_TextChanged_1;
                        nMontoPagar.KeyPress += nMontoPagar_KeyPress;
                        nMontoPagar.Leave += nMontoPagar_Leave;
                    }
                    cboMot.SelectedValue = Convert.ToInt32(SolicDuplicada.Rows[0]["idMotivo"]);
                    txtMot.Text = SolicDuplicada.Rows[0]["cSustento"].ToString();

                    //txtNumeroCtaCOB.Text = SolicDuplicada.Rows[0]["cCuentasCOB"].ToString();
                    //txtMontoTotalCTA.Text = SolicDuplicada.Rows[0]["nMontoCuentaCOB"].ToString();
                    cboMot.Enabled = false;
                    txtMot.Enabled = false;

                    btnEnviar.Enabled = false;
                    /*******************************************************/
                    btnAdjuntarFile1.Enabled = true;
                    btnCancelar.Enabled = true;

                    this.btnMiniBusq1.Enabled = this.conBusCuentaCli.btnBusCliente1.Enabled;
                    this.conBusCuentaCli.txtCodCli.Enabled = this.conBusCuentaCli.txtNroBusqueda.Enabled;
                    this.cargaCobsIdSolicitudAproba(Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAproba"]));

                    return;
                }
                else
                {
                    DataTable solCond = SolicCondonacion.verificarSolicitudCondonacion(Convert.ToInt32(conBusCuentaCli.nValBusqueda));
                    if (solCond.Rows.Count > 0)
                    {
                        MessageBox.Show("Esta Cuenta tiene una Solicitud de " + solCond.Rows[0]["cTipoOperacion"] + " pendiente", "Afectación Individual", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnCancelar.Enabled = true;
                        return;
                    }
                }

                this.cargaCobsIdCuenta(conBusCuentaCli.nValBusqueda);
                this.activarControlCobs(true);
                HabilitarControles(true);

                btnEnviar.Enabled = true;
                btnAdjuntarFile1.Enabled = true;
                btnCancelar.Enabled = true;

                this.cboTipoCondonacion1.Focus();                
                verificaCampania();
            }
        }

        private bool esPendienteARefinanciar(int idCuenta)
        {
            DataTable res = SolicCondonacion.esPendienteARefinanciar(idCuenta);
            if (Convert.ToBoolean(res.Rows[0]["estado"]))
            {
                MessageBox.Show(res.Rows[0]["msg"].ToString(), "Solicitud de Condonación",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        public void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        public void CleanData()
        {
            cboMot.SelectedIndex = -1;
            //cboTipoCorrespondencia1.SelectedIndex = -1;
            txtCap.Text = "0.00";
            txtInt.Text = "0.00";
            txtIntComp.Text = "0.00";
            txtOtro.Text = "0.00";
            txtMora.Text = "0.00";
            txtTotal.Text = "0.00";
            txtMot.Text = string.Empty;

            txtCondCapital.Text = "0.00";
            txtCondInteres.Text = "0.00";
            txtCondIntComp.Text = "0.00";
            txtCondMora.Text = "0.00";
            txtCondOtros.Text = "0.00";
            txtCondTotal.Text = "0.00";

            txtSaldoCap.Text = "0.00";
            txtSaldoInt.Text = "0.00";
            txtSaldoIntComp.Text = "0.00";
            txtSaldoMora.Text = "0.00";
            txtSaldoOtr.Text = "0.00";
            txtSaldoTotal.Text = "0.00";
            txtMontoDesembolsado.Text = "0.00";
            txtFechaDesmbolso.Text = string.Empty;
            txtNroCuotas.Text = string.Empty;

            this.conProducto1.limpiar();
            this.cboCondicionContNormal.SelectedIndex = -1;
            this.cboCondicionContVenc.SelectedIndex = -1;
            this.txtDiasAtraso.Clear();
            this.cboMoneda1.SelectedIndex = -1;

            
            //this.txtNumeroCtaCOB.Clear();
            this.txtMontoTotalCTA.Clear();

            if (this.cboTipoCondonacion1.Items.Count > 0)
            {
                this.cboTipoCondonacion1.SelectedIndex = 0;
                this.cboTipoCorrespondencia1.ListaTipoCorrespondencia();
            }

            this.xmlCoutasCondonadas = null;
            this.lblSeguro.Text = String.Empty;
        }

        private void CalculaCond(bool lActualizaSaldo= true)
        {
            txtSaldoCap.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtCap.Text) - Convert.ToDecimal(txtCondCapital.Text)));
            txtSaldoInt.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtInt.Text) - Convert.ToDecimal(txtCondInteres.Text)));
            txtSaldoIntComp.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtIntComp.Text) - Convert.ToDecimal(txtCondIntComp.Text)));
            txtSaldoMora.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtMora.Text) - Convert.ToDecimal(txtCondMora.Text)));
            txtSaldoOtr.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtOtro.Text) - Convert.ToDecimal(txtCondOtros.Text)));

            txtCondTotal.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtCondCapital.Text) + 
                                                            Convert.ToDecimal(txtCondInteres.Text) + 
                                                            Convert.ToDecimal(txtCondIntComp.Text) +
                                                            Convert.ToDecimal(txtCondMora.Text) + 
                                                            Convert.ToDecimal(txtCondOtros.Text)));
            txtSaldoTotal.Text = String.Format("{0:#,0.00}",(Convert.ToDecimal(txtSaldoCap.Text) + 
                                                            Convert.ToDecimal(txtSaldoInt.Text) + 
                                                            Convert.ToDecimal(txtSaldoIntComp.Text) +
                                                            Convert.ToDecimal(txtSaldoMora.Text) + 
                                                            Convert.ToDecimal(txtSaldoOtr.Text)));

            if (lActualizaSaldo)
            {
                if (cboTipoCorrespondencia1.SelectedIndex != 2)
                    nMontoPagar.Text = txtSaldoTotal.Text;
            }
        }

        private void HabilitarControles(bool lHabil)
        {
            grbDetCond.Enabled = lHabil;
            this.cboMot.Enabled = lHabil;
            this.txtMot.Enabled = lHabil;
            
            //this.txtNumeroCtaCOB.ReadOnly = !lHabil;
            this.txtMontoTotalCTA.ReadOnly = !lHabil;

            //**this.chcPorCuota.Enabled = lHabil;
            this.btnMiniBusq1.Enabled = this.conBusCuentaCli.btnBusCliente1.Enabled;
            this.conBusCuentaCli.txtCodCli.Enabled = this.conBusCuentaCli.txtNroBusqueda.Enabled;
            //this.btnPorCuota.Enabled = lHabil;
            if (lHabil)
            {
                this.cboTipoCondonacion1.SelectedIndexChanged += new EventHandler(cboTipoCondonacion1_SelectedIndexChanged);    
            }
            else
            {
                this.cboTipoCondonacion1.SelectedIndexChanged -= new EventHandler(cboTipoCondonacion1_SelectedIndexChanged);   
            }
            this.cboTipoCondonacion1.Enabled = lHabil;
            if (Convert.ToInt32(cboCondicionContNormal.SelectedValue) == 6 && Convert.ToInt32(cboCondicionContVenc.SelectedValue) == 6)
            {
                cboTipoCorrespondencia1.SelectedValue = 1;
                cboTipoCorrespondencia1.Enabled = false;
            }
            else
            {
                cboTipoCorrespondencia1.Enabled = true;
            }
            /*if (idCuenta != 0 && lHabil)
            {
                this.txtCondCapital.Enabled = !((idContable == 3 || idContable ==1 || idContable == 5) && nAtraso < 120);
            }*/
        }

        private bool Validar()
        {
            validarMonto(this.txtCondCapital, this.txtCap, this.lblMaxDesCapital, false);
            validarMonto(this.txtCondInteres, this.txtInt, lblMaxDesInteres, false);
            validarMonto(this.txtCondIntComp, this.txtIntComp, this.lblMaxDesIntComp, false);
            validarMonto(this.txtCondOtros, this.txtOtro, this.lblMaxDesGastos, false);
            validarMonto(this.txtCondMora, this.txtMora, this.lblMaxDesMora, false);

            clsCNGenVariables RetVar = new clsCNGenVariables();
            string cfecha = RetVar.RetornaVariable("dFechaAct", clsVarGlobal.nIdAgencia).Trim();
            if (clsVarGlobal.dFecSystem != Convert.ToDateTime(cfecha))
            {
                MessageBox.Show("La fecha actual es distinto al del sistema", "Validar el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (conBusCuentaCli.nValBusqueda == 0)
            {
                MessageBox.Show("Debe asignar una cuenta valida", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboMot.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un motivo", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboTipoCorrespondencia1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una Correspondencia", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToDecimal(txtCondTotal.Text) <= 0.0m)
            {
                MessageBox.Show("El Monto a Condonar debe ser mayor a 0", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMot.Text.Length < 51)
            {
                MessageBox.Show("Debe asignar una breve descripción para el Motivo (Mín. 50 caracteres)", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMontoTotalCTA.Text == "")
            {
                MessageBox.Show("Ingrese el Monto Total ", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToDecimal(nMontoCondonar.Text) + Convert.ToDecimal(nMontoPagar.Text) > Convert.ToDecimal(txtTotal.Text))
            {
                MessageBox.Show("Monto a Condonar mas Monto a Pagar excede al Total de Dueda", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!(Convert.ToInt32(cboMot.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["idMotivoCondonacionCovi19"]) && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["idTipoCondonacionCovi19"])))
            {
                if (archivos == null)
                {
                    MessageBox.Show("Se debe Adjuntar todos los Documentos obligatorios", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                foreach (DataRow row in archivos.Rows)
                {
                    if (Convert.ToBoolean(row["lEstado"]) && String.IsNullOrEmpty(row["cNombreDoc"].ToString()))
                    {
                        MessageBox.Show("Se debe Adjuntar todos los Documentos obligatorios", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            

            if (perfilHabilitado(clsVarGlobal.PerfilUsu.idPerfil))
            {
                if (dtgCobs.RowCount == 0 && Convert.ToDecimal(nMontoPagar.Text) != 0
                    && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 1 && Convert.ToInt32(cboTipoCorrespondencia1.SelectedValue) != 3)
                {
                    frmMsgAdvertencia msg = new frmMsgAdvertencia("Advertencia de Solicitud Sin Pago", "Se está intentando enviar la Solicitud de Condonacion Sin Pago. Cualquier responsabilidad será asumida por su usuario: " + clsVarGlobal.User.cWinUser + "\n Recuerde:\n  El Monto a Pagar se guardará con CERO");
                    msg.ShowDialog();
                    DialogResult dr = msg.dRes;

                    if (dr != DialogResult.OK)
                    {
                        return false;
                    }
                    else return true;
                }

                if (dtgCobs.RowCount == 0 && Convert.ToDecimal(nMontoPagar.Text) == 0 &&
                    (Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 1 || Convert.ToInt32(cboTipoCorrespondencia1.SelectedValue) == 3 || Convert.ToInt32(txtTotal.Text) == Convert.ToInt32(nMontoCondonar.Text)))
                {
                    frmMsgAdvertencia msg = new frmMsgAdvertencia("Advertencia de Solicitud Sin Pago", "Se está intentando enviar la Solicitud de Condonacion Sin Pago. Cualquier responsabilidad será asumida por su usuario: " + clsVarGlobal.User.cWinUser);
                    msg.ShowDialog();
                    DialogResult dr = msg.dRes;

                    if (dr != DialogResult.OK)
                    {
                        return false;
                    }
                    else return true;
                }
            }

            if (!(Convert.ToInt32(cboMot.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["idMotivoCondonacionCovi19"]) && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["idTipoCondonacionCovi19"])))
            {
                if (dtgCobs.RowCount == 0)
                {
                    MessageBox.Show("No hay ninguna Cob vinculada a la solicitud", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (nMontoPagar.nDecValor + txtITF.nDecValor > this.obtenerSumaCobs())
                {
                    MessageBox.Show("El monto a pagar mas el ITF debe ser menor o igual a la suma de las cobs", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (this.obtenerSumaCobs() > 0 && nMontoPagar.nDecValor == 0)
                {
                    MessageBox.Show("Hay Cob's Vinculadas, el Monto a Pagar no puede ser Cero", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        public bool perfilHabilitado(int idPerfil)
        {
            string[] idsHab = clsVarApl.dicVarGen["idPerfilSP"].Split(',');
            int[] idsHabSP = Array.ConvertAll<string, int>(idsHab, int.Parse);

            int pos = Array.IndexOf(idsHabSP, idPerfil);
            if (pos > -1)
            {
                return true;
            }

            return false;
        }

        private void muestraPorcDesc(decimal nDescCapital, decimal nDescInteres, decimal nDescIntComp, decimal nDescMora, decimal nDescGastos)
        {
            this.lblMaxDesCapital.Text = nDescCapital.ToString();
            this.lblMaxDesInteres.Text = nDescInteres.ToString();
            this.lblMaxDesIntComp.Text = nDescIntComp.ToString();
            this.lblMaxDesMora.Text = nDescMora.ToString();
            this.lblMaxDesGastos.Text = nDescGastos.ToString();
            if (!Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])) && cboTipoCorrespondencia1.SelectedIndex == 2)
            {
                lblMaxDesCapital.Text = "0.00";
            }
        }
        private void reiniarPorcDesc(decimal porcentaje)
        {
            this.lblMaxDesCapital.Text = porcentaje.ToString();
            this.lblMaxDesInteres.Text = porcentaje.ToString();
            this.lblMaxDesIntComp.Text = porcentaje.ToString();
            this.lblMaxDesMora.Text = porcentaje.ToString();
            this.lblMaxDesGastos.Text = porcentaje.ToString();
            if (!Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])) && cboTipoCorrespondencia1.SelectedIndex == 2)
            {
                lblMaxDesCapital.Text = "0.00";
            }
        }

        private void calculaGastoSeguro()
        {
            //if (Convert.ToDecimal(this.txtCondOtros.Text) > (Convert.ToDecimal(this.txtOtro.Text) * Convert.ToDecimal(this.txtOtro.Text) / 100) - Convert.ToDecimal(this.lblSeguro.Text))
            //{
            //    MessageBox.Show("La condonación de Otros supera a gastos por seguro", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtCondOtros.Text = "0.00";
            //    txtCondOtros.Focus();
            //}
        }

        private void mostrarSubTipoCorrespondencia(bool lBool)
        {
            lblBaseSubTipoCorres.Visible = lBool;
            cboSubTipoCorrespondencia1.Visible = lBool;
        }

        #endregion                        


        

        private void btnAdjuntarFile1_Click(object sender, EventArgs e)
        {
            cargaAdjuntaArchivos();

        }

        private void cargaAdjuntaArchivos()
        {
            if (archivos == null || archivos.Rows.Count == 0)
            {
                DataTable dt = SolicCondonacion.filesCondonacion(idSolAproba, idCuenta);

                foreach (DataColumn item in dt.Columns)
                {
                    item.ReadOnly = false;
                }
                archivos = dt.Copy();
            }

            frmAdjArchivosCondonacion frm_ = new frmAdjArchivosCondonacion(archivos, idSolAproba);
            frm_.ShowDialog();

            archivos = frm_.getDtgFiles();
        }

        public string convertXMLFiles(DataTable dt)
        {
            dt.TableName = "files";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }

            
            return ds.GetXml();
        }
        
        private void nMontoCondonar_TextChanged_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nMontoCondonar.Text))
                return;

            if (Convert.ToDecimal(nMontoCondonar.Text) > Convert.ToDecimal(maxCondonacion.Text))
            {
                MessageBox.Show("El monto a condonar exede el permitido", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nMontoCondonar.Text = maxCondonacion.Text;
            }
            if (nMontoCondonar.Text == "")
                nMontoCondonar.Text = "0";
            if (Convert.ToDecimal(nMontoCondonar.Text) > Convert.ToDecimal(maxCondonacion.Text))
            {
                MessageBox.Show("El monto a condonar exede el permitido", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
            
                decimal val = 0;
                decimal deuda = 0;
                decimal totalTmp = Convert.ToDecimal(nMontoCondonar.Text);

                deuda = (Math.Truncate(Convert.ToDecimal(txtOtro.Text) * Convert.ToDecimal(lblMaxDesGastos.Text)) / 100);
                val = (deuda < totalTmp) ? deuda : totalTmp;
                txtCondOtros.Text = val.ToString();
                totalTmp = totalTmp - val;
                validarMonto(txtCondOtros, txtOtro, lblMaxDesGastos);

                deuda = (Math.Truncate(Convert.ToDecimal(txtMora.Text) * Convert.ToDecimal(lblMaxDesMora.Text)) / 100);
                val = (deuda < totalTmp) ? deuda : totalTmp;
                txtCondMora.Text = val.ToString();
                totalTmp = totalTmp - val;
                validarMonto(txtCondMora, txtMora, lblMaxDesMora);

                deuda = (Math.Truncate(Convert.ToDecimal(txtIntComp.Text) * Convert.ToDecimal(lblMaxDesIntComp.Text)) / 100);
                val = (deuda < totalTmp) ? deuda : totalTmp;
                txtCondIntComp.Text = val.ToString();
                totalTmp = totalTmp - val;
                validarMonto(txtCondIntComp, txtIntComp, lblMaxDesIntComp);

                deuda = (Math.Truncate(Convert.ToDecimal(txtInt.Text) * Convert.ToDecimal(lblMaxDesInteres.Text)) / 100);
                val = (deuda < totalTmp) ? deuda : totalTmp;
                txtCondInteres.Text = val.ToString();
                totalTmp = totalTmp - val;
                validarMonto(txtCondInteres, txtInt, lblMaxDesInteres);

                deuda = (Math.Truncate(Convert.ToDecimal(txtCap.Text) * Convert.ToDecimal(lblMaxDesCapital.Text)) / 100);
                val = (deuda < totalTmp) ? deuda : totalTmp;
                txtCondCapital.Text = val.ToString();
                totalTmp = totalTmp - val;
                validarMonto(txtCondCapital, txtCap, lblMaxDesCapital);

                cargaITF();
            
        }

        private void cargaCobsIdCuenta(int idCuenta)
        {
            DataTable dtCobs = SolicCondonacion.CNCobsVinculadasACuenta(idCuenta);
            dtgCobs.DataSource = dtCobs;
            formatoCobs();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
        }

        private void cargaCobsIdSolicitudAproba(int idSolicitudAproba)
        {
            DataTable dtCobs = SolicCondonacion.CNListaCobsVincSolicitudCondonacion(idSolicitudAproba);
            dtgCobs.DataSource = dtCobs;
            formatoCobs();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
        }

        private void formatoCobs()
        {
            foreach (DataGridViewColumn item in dtgCobs.Columns)
            {
                item.Visible = false;
            }

            dtgCobs.Columns["idRecibo"].Visible = true;
            dtgCobs.Columns["cMoneda"].Visible = true;
            dtgCobs.Columns["nMontoTot"].Visible = true;
            dtgCobs.Columns["cSustento"].Visible = true;
            dtgCobs.Columns["idCli"].Visible = true;
            dtgCobs.Columns["IdKardex"].Visible = true;
            dtgCobs.Columns["dFechaOpe"].Visible = true;

            dtgCobs.Columns["idRecibo"].HeaderText = "Nro. Recibo";
            dtgCobs.Columns["cMoneda"].HeaderText = "M.";
            dtgCobs.Columns["nMontoTot"].HeaderText = "Monto";
            dtgCobs.Columns["cSustento"].HeaderText = "Sustento";
            dtgCobs.Columns["idCli"].HeaderText = "Cod. Cli";
            dtgCobs.Columns["IdKardex"].HeaderText = "Nro Ope.";
            dtgCobs.Columns["dFechaOpe"].HeaderText = "Fecha";

            dtgCobs.Columns["idRecibo"].DisplayIndex = 1;
            dtgCobs.Columns["cMoneda"].DisplayIndex = 2;
            dtgCobs.Columns["nMontoTot"].DisplayIndex = 3;
            dtgCobs.Columns["cSustento"].DisplayIndex = 6;
            dtgCobs.Columns["idCli"].DisplayIndex = 5;
            dtgCobs.Columns["IdKardex"].DisplayIndex = 0;
            dtgCobs.Columns["dFechaOpe"].DisplayIndex = 4;

            pintarGridCobs();
        }

        private void pintarGridCobs()
        {
            foreach (DataGridViewRow item in dtgCobs.Rows)
            {
                if (!Convert.ToBoolean(item.Cells["lRecVincCreditos"].Value))
                {
                    item.DefaultCellStyle.BackColor = Color.Cyan;
                }
            }
        }

        private decimal obtenerSumaCobs()
        {
            decimal nTotal = 0.00m;
            foreach (DataGridViewRow item in dtgCobs.Rows)
            {
                nTotal = nTotal + Convert.ToDecimal(item.Cells["nMontoTot"].Value);
            }
            return nTotal;
        }

        private string obtenerXmlCobs()
        {
            DataSet ds = new DataSet("CobsDS");
            DataTable dt = (DataTable)(dtgCobs.DataSource);
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }
            return ds.GetXml();
        }

        private void cboTipoCorrespondencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarCambioCombos();
            if(cboTipoCorrespondencia1.SelectedIndex != 1)
                verificaCampania();
        }

        public void verificarCambioCombos()
        {
            mostrarSubTipoCorrespondencia(false);
            this.cboSubTipoCorrespondencia1.SelectedIndex = -1;
            this.cboSubTipoCorrespondencia1.DataSource = null;
            if (cboTipoCorrespondencia1.SelectedIndex != cboCorrespondeciaTmp || Convert.ToInt32(cboTipoCondonacion1.SelectedValue) != cboCondonacionTmp)
            {
                cboCorrespondeciaTmp = cboTipoCorrespondencia1.SelectedIndex;
                cboCondonacionTmp = Convert.ToInt32(cboTipoCondonacion1.SelectedValue);
                nMontoCondonar.Text = "0.00";
                nMontoPagar.Text = "0.00";
                txtCuotasCondonar.Text = "0";
            }

            lblBase24.Visible = false;
            txtCuotasCondonar.Visible = false;
            nMontoCondonar.Enabled = false;
            nMontoPagar.Enabled = false;

            if (Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 1)
            {
                abrirFrmXcuotas();
                lblBase24.Visible = true;
                txtCuotasCondonar.Visible = true;
            }

            if (Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 2)
            {
                nMontoCondonar.Enabled = true;
                nMontoPagar.Enabled = true;
                //verificaCampania();
            }

            if (cboTipoCorrespondencia1.SelectedIndex == 0 && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 1)
                nMontoCondonar.Enabled = true;

            if (cboTipoCorrespondencia1.SelectedIndex == 0)
                nMontoPagar.Enabled = true;
            
            //Agrega para casos Vigentes y Sub Tipo Correspondencia
            if ((Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 3 && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 1)
                || (Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex) == 4 && Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 1))
            {
                this.mostrarSubTipoCorrespondencia(true);
                int idTipoCorrespondencia = Convert.ToInt32(this.cboTipoCorrespondencia1.SelectedValue);
                this.cboSubTipoCorrespondencia1.ListarSubTipoCorrespondencia(idTipoCorrespondencia);                
                nMontoCondonar.Enabled = true;
                nMontoPagar.Enabled = true;
            }

            if (Convert.ToInt32(cboTipoCondonacion1.SelectedValue) == 10)
            {
                this.cboTipoCorrespondencia1.ListaTipoCorrespondenciaEspecific();
                if (cboTipoCorrespondencia1.SelectedIndex == 0)
                {
                    nMontoCondonar.Enabled = true;
                }
            }
                
        }

        public void abrirFrmXcuotas(bool lEditar = true)
        {
            nMontoCondonar.TextChanged -= nMontoCondonar_TextChanged_1;
            nMontoCondonar.Enabled = false;
            nMontoPagar.Enabled = false;
            bool enable = false;//!this.chcPorCuota.Enabled;
            frmSolCondonaPorCuota frmcondonaporcuota = new frmSolCondonaPorCuota(this.idCuenta, Convert.ToInt32(this.cboTipoCondonacion1.SelectedValue), Convert.ToString(((DataRowView)this.cboTipoCondonacion1.SelectedItem)["cNombreCondonacion"]), xmlCoutasCondonadas, enable, Convert.ToDecimal(nMontoPagar.Text), Convert.ToDecimal(nMontoCondonar.Text), lEditar, Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]), Convert.ToInt32(txtCuotasCondonar.Text));
            frmcondonaporcuota.ShowDialog();


            if (frmcondonaporcuota.lHayCondonacion)
            {
                this.txtCondCapital.Text = frmcondonaporcuota.nCapital.ToString();
                this.txtCondInteres.Text = frmcondonaporcuota.nInteres.ToString();
                this.txtCondIntComp.Text = frmcondonaporcuota.nInteresComp.ToString();
                this.txtCondMora.Text = frmcondonaporcuota.nMora.ToString();
                this.txtCondOtros.Text = frmcondonaporcuota.nOtros.ToString();
                this.xmlCoutasCondonadas = frmcondonaporcuota.xmlCoutasCondonadas;

                calculaGastoSeguro();
                CalculaCond();
                nMontoCondonar.Text = txtCondTotal.Text;
                getnMontoPagar = Convert.ToDecimal(frmcondonaporcuota.getMontoXCuota());
                nMontoPagar.Text = getnMontoPagar.ToString();
                txtCuotasCondonar.Text = frmcondonaporcuota.getRowsAfected().ToString();

                cargaITF();
            }
            nMontoCondonar.TextChanged += nMontoCondonar_TextChanged_1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.cargaCobsIdCuenta(conBusCuentaCli.nValBusqueda);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCobs.RowCount == 0)
                return;
            if (dtgCobs.SelectedRows == null)
                return;

            int idRecibo = Convert.ToInt32(dtgCobs.SelectedRows[0].Cells["idRecibo"].Value);
            dtgCobs.Rows.RemoveAt(dtgCobs.SelectedRows[0].Index);
            dtgCobs.Update();
            txtMontoTotalCTA.Text = obtenerSumaCobs().ToString("N2");
        }

        private void activarControlCobs(bool lBool)
        {
            btnAgregar.Enabled = lBool;
            btnQuitar.Enabled = lBool;
            btnAgregaCobsTerceros.Enabled = lBool;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCobsDeTerceros frmCobsTerceros = new frmCobsDeTerceros(Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]));
            frmCobsTerceros.ShowDialog();

            if (frmCobsTerceros.drRes != null)
            {
                DataTable dt = (DataTable)dtgCobs.DataSource;
                dt.AcceptChanges();
                if (buscarRepetidos(dt, frmCobsTerceros.drRes))
                {
                    dt.ImportRow(frmCobsTerceros.drRes);
                    dtgCobs.DataSource = null;

                    dtgCobs.DataSource = dt;
                    formatoCobs();
                    txtMontoTotalCTA.Text = this.obtenerSumaCobs().ToString("N2");
                }
            }
        }

        private bool buscarRepetidos(DataTable dt, DataRow dr)
        {
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["idRecibo"]) == Convert.ToInt32(dr["idRecibo"]))
                {
                    MessageBox.Show("El recibo con Nro de Operación :" + dr["idKardex"].ToString() + ", ya se encuentra vinculado a esta solicitud de condonación", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void nMontoPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (nMontoPagar.Text == "")
                    nMontoPagar.Text = "0";
                if (cboTipoCorrespondencia1.SelectedIndex != 2)
                {
                    if (Convert.ToDecimal(nMontoPagar.Text) > Convert.ToDecimal(txtTotal.Text))
                    {
                        MessageBox.Show("Monto fuera de los limites permitidos", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nMontoPagar.Text = txtTotal.Text;
                        nMontoCondonar.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(nMontoPagar.Text)).ToString();
                        validarMontoCondonar();
                    }
                    else
                    {
                        nMontoCondonar.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(nMontoPagar.Text)).ToString();
                        validarMontoCondonar();
                    }
                }
                cargaITF();
            }
        }

        private void nMontoPagar_Leave(object sender, EventArgs e)
        {
            if (nMontoPagar.Text == "")
                nMontoPagar.Text = "0";
            if (cboTipoCorrespondencia1.SelectedIndex != 2)
            {
                if (Convert.ToDecimal(nMontoPagar.Text) > Convert.ToDecimal(txtTotal.Text))
                {
                    MessageBox.Show("Monto fuera de los limites permitidos", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nMontoPagar.Text = txtTotal.Text;
                    nMontoCondonar.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(nMontoPagar.Text)).ToString();
                    validarMontoCondonar();
                }
                else
                {
                    nMontoCondonar.Text = (Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(nMontoPagar.Text)).ToString();
                    validarMontoCondonar();
                }
            }
            cargaITF();
        }

        private void nMontoCondonar_KeyPress(object sender, KeyPressEventArgs e)
        {
            nMontoCondonar_change(e.KeyChar);
        }

        private void nMontoCondonar_Leave(object sender, EventArgs e)
        {
            nMontoCondonar_change(13);
        }

        public void nMontoCondonar_change(int key){
            if(key == 13){

                validarMontoCondonar();
            }
        }

        public void validarMontoCondonar()
        {
            //nMontoCondonar.Text = "0.00";
            if (nMontoCondonar.Text == "")
                nMontoCondonar.Text = "0";
            
            if (Convert.ToDecimal(nMontoCondonar.Text) > Convert.ToDecimal(maxCondonacion.Text))
            {
                MessageBox.Show("Monto fuera de los limites permitidos", "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nMontoCondonar.Text = maxCondonacion.Text;
                
            }
            
            llenarCondonacion();
        }

        public void llenarCondonacion()
        {
            decimal val = 0;
            decimal deuda = 0;
            decimal totalTmp = Convert.ToDecimal(nMontoCondonar.Text);

            deuda = (Math.Truncate(Convert.ToDecimal(txtOtro.Text) * Convert.ToDecimal(lblMaxDesGastos.Text)) / 100);
            val = (deuda < totalTmp) ? deuda : totalTmp;
            txtCondOtros.Text = val.ToString();
            totalTmp = totalTmp - val;
            validarMonto(txtCondOtros, txtOtro, lblMaxDesGastos);

            deuda = (Math.Truncate(Convert.ToDecimal(txtMora.Text) * Convert.ToDecimal(lblMaxDesMora.Text)) / 100);
            val = (deuda < totalTmp) ? deuda : totalTmp;
            txtCondMora.Text = val.ToString();
            totalTmp = totalTmp - val;
            validarMonto(txtCondMora, txtMora, lblMaxDesMora);

            deuda = (Math.Truncate(Convert.ToDecimal(txtIntComp.Text) * Convert.ToDecimal(lblMaxDesIntComp.Text)) / 100);
            val = (deuda < totalTmp) ? deuda : totalTmp;
            txtCondIntComp.Text = val.ToString();
            totalTmp = totalTmp - val;
            validarMonto(txtCondIntComp, txtIntComp, lblMaxDesIntComp);

            deuda = (Math.Truncate(Convert.ToDecimal(txtInt.Text) * Convert.ToDecimal(lblMaxDesInteres.Text)) / 100);
            val = (deuda < totalTmp) ? deuda : totalTmp;
            txtCondInteres.Text = val.ToString();
            totalTmp = totalTmp - val;
            validarMonto(txtCondInteres, txtInt, lblMaxDesInteres);

            deuda = (Math.Truncate(Convert.ToDecimal(txtCap.Text) * Convert.ToDecimal(lblMaxDesCapital.Text)) / 100);
            val = (deuda < totalTmp) ? deuda : totalTmp;
            txtCondCapital.Text = val.ToString();
            totalTmp = totalTmp - val;
            validarMonto(txtCondCapital, txtCap, lblMaxDesCapital);
        }

        private void lblBase1_Click(object sender, EventArgs e)
        {

        }

        private void cargaITF()
        {
            if (tbDatosCuenta == null)
                return;

            decimal nMonPago = Convert.ToDecimal(nMontoPagar.Text);
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]));

            if (Math.Round(nITF, 2) > 0)
            {
                grbITF.Visible = true;
                this.txtITF.Text = Math.Round(nITF, 2).ToString();
            }
            else
            {
                grbITF.Visible = false;
                this.txtITF.Text = "0".ToString();
            }
            
        }

        private void btnRptSbs_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            DataTable datos = SolicCondonacion.rptSBSCliente(idCuenta);
            dtsList.Add(new ReportDataSource("dtsSaldosRCD", datos));

            
            paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cWinUser, false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            string reportPath = "rptSBSCliente.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private void txtMot_TextChanged(object sender, EventArgs e)
        {
            if (txtMot.Text.Length >= 230)
            {
                numCharacter.Text = (250 - txtMot.Text.Length).ToString();
                numCharacter.Visible = true;
                textNumCharacter.Visible = true;
            }
            else
            {
                numCharacter.Visible = false;
                textNumCharacter.Visible = false;
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string guardarParaAprobar(int idEstadoAproba, int idSolicitudAproba)
        {
            clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(idSolicitudAproba, Convert.ToInt32(Modulo.CREDITOS), Convert.ToInt32(TipoOperacion.CONDONACION));
            return objNivelAproba.guardarParaAprobacion(idEstadoAproba);
        }
        private void enviarAlertaCorreo()
        {
            clsCNCondonacion cnTipoCorrespondencia = new clsCNCondonacion();
            DataTable dtTipoCorrespondencia = cnTipoCorrespondencia.listaTipoCorrespondencia();

            clsCNCondonacion cnSubTipoCorrespondencia = new clsCNCondonacion();
            DataTable dtSubTipoCorrespondencia = cnSubTipoCorrespondencia.listaSubTipoCorrespondencia(Convert.ToInt32(this.cboTipoCorrespondencia1.SelectedValue));

            DataTable dtAlertaCorreo = SolicCondonacion.listarAlertaCorreo();
            DataRow[] cCorreoRemit = dtAlertaCorreo.Select("cIdentificacionCorreo = 'Remitente'");

            string cAsuntoMensaje = "Condonación Caso Vigente";
            string cFuenteIni = "<FONT FACE='Calibri'>";
            string cUsuario = "<b>- Usuario: </b>" + clsVarGlobal.User.cWinUser + "<br>";
            string cNombreUsuario = "<b>- Nombre: </b>" + clsVarGlobal.User.cNomUsu + "<br><br>";
            string cNroCuentaCre = "<b>- Nro. Cuenta Crédito: </b>" + this.idCuenta.ToString() + "<br>";
            string cCodigoCliente = "<b>- Código del cliente: </b>" + this.conBusCuentaCli.txtCodCli.Text + "<br>";
            string cNroDocumento = "<b>- Nro. de Documento: </b>" + this.conBusCuentaCli.txtNroDoc.Text + "<br>";
            string cNombreApellidos = "<b>- Nombres y Apellidos del Cliente: </b>" + this.conBusCuentaCli.txtNombreCli.Text + "<br>";
            string cDiasAtraso = "<b>- Días de atraso: </b>" + txtDiasAtraso.Text + "<br>";
            string cMontoDesembolso = "<b>- Monto desembolso: </b>" + txtMontoDesembolsado.Text + "<br>";
            string cTipoCorrespondencia1 = "<b>- Tipo Condonación: </b>" + dtTipoCorrespondencia.Rows[Convert.ToInt32(cboTipoCorrespondencia1.SelectedIndex)]["cCorrespondencia"].ToString() + "<br>";
            string cSubTipoCorrespondencia1 = "<b>- Sub tipo Condonación: </b>" + dtSubTipoCorrespondencia.Rows[Convert.ToInt32(cboSubTipoCorrespondencia1.SelectedIndex)]["cSubTipoCorrespondencia"].ToString() + "<br><br>";
            string cFuenteFin = "</FONT>";

            string cSmtpCliente = "mail.cajalosandes.pe";
            int nPuertoSmtpCliente = clsVarApl.dicVarGen["nPuertoSmtpCliente"];

            SmtpClient smtpcliente = new SmtpClient(cSmtpCliente, nPuertoSmtpCliente);
            smtpcliente.UseDefaultCredentials = false;
            NetworkCredential credenciales = new NetworkCredential(cCorreoRemit[0]["cCorreo"].ToString(), cCorreoRemit[0]["cPassCorreo"].ToString());
            smtpcliente.Credentials = credenciales;

            MailAddress mensajeDE = new MailAddress(cCorreoRemit[0]["cCorreo"].ToString(), cAsuntoMensaje);
            MailMessage mensaje = new MailMessage();

            mensaje.From = mensajeDE;
            foreach (DataRow correo in dtAlertaCorreo.Rows)
            {
                if (correo["cIdentificacionCorreo"].ToString() == "Destinatario")
                {
                    mensaje.To.Add(correo["cCorreo"].ToString());
                }
            }
            mensaje.Priority = MailPriority.High;
            mensaje.Subject = cAsuntoMensaje;
            mensaje.SubjectEncoding = Encoding.UTF8;
            mensaje.Body = cFuenteIni + cUsuario + cNombreUsuario + cNroCuentaCre + cCodigoCliente + cNroDocumento + cNombreApellidos + cDiasAtraso + cMontoDesembolso + cTipoCorrespondencia1 + cSubTipoCorrespondencia1 + cFuenteFin;
            mensaje.BodyEncoding = Encoding.UTF8;
            mensaje.IsBodyHtml = true;

            smtpcliente.Send(mensaje);
        }
    }
}
