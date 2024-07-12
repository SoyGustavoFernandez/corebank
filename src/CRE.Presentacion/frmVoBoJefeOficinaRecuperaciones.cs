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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmVoBoJefeOficinaRecuperaciones : frmBase
    {
        CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
        private DataTable tbDatosCuenta;
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsFunUtiles objFunciones = new clsFunUtiles();
        private string cTituloMsg = "V°B° - Condonaciones";

        int idCuenta = 0;
        private int idContable = 0;
        private int nAtraso = 0;
        int idSolicitudAproba = 0;
        int idModulo = 1; //Creditos 
        int idTipoOperacion = 7; //Condonaciones

        int idAgencia = 0;
        public DataTable archivos = null;
        private string xmlCoutasCondonadas;

        EventoFormulario evento = EventoFormulario.INICIO;

        private void frmVoBoJefeOficinaRecuperaciones_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";
            cboMot.CargarMotivos(2);

            this.cboTipoCondonacion1.ListaCondonacionVigentes(0);
            this.cboTipoCorrespondencia1.ListaTipoCorrespondencia();

            evento = EventoFormulario.INICIO;
            controlComponentes();

            //Auto cargado cuando se ha seteado el idcuenta al cargar el formulario
            if (this.idCuenta != 0)
            {
                this.conBusCuentaCli.txtNroBusqueda.Text = this.idCuenta.ToString();
                this.conBusCuentaCli.consultar();
                if (Convert.ToInt32((revisarVistoBueno(idSolicitudAproba).Rows[0]["idEstado"])) == 1)
                {
                    evento = EventoFormulario.ENVIAR;
                    controlComponentes();
                }
                else
                {
                    evento = EventoFormulario.ENVIAR;
                    controlComponentes();
                    btnBandeja.Visible = false;
                    grbBase1.Visible = false;
                }

                
            }
        }

        public frmVoBoJefeOficinaRecuperaciones()
        {
            InitializeComponent();
            idAgencia = clsVarGlobal.nIdAgencia;
        }

        public frmVoBoJefeOficinaRecuperaciones(int _idCuenta)
        {
            InitializeComponent();
            this.idCuenta = _idCuenta;
            idAgencia = 0;
        }

        private void btnAdjuntarFile1_Click(object sender, EventArgs e)
        {
            this.cargaAdjuntaArchivos();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargarData();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            cargarData();
        }

        private void cargarData()
        {
            CleanData();
            tbDatosCuenta = Credito.CNSaldoCredito(conBusCuentaCli.nValBusqueda);
            if (tbDatosCuenta.Rows.Count > 0)
            {
                txtCap.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALCAP"]));
                txtInt.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALINT"]));
                txtIntComp.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nSalIntComp"]));
                txtOtro.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALOTR"]));
                txtMora.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALMOR"]));
                txtTotal.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]));

                txtSaldoCap.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALCAP"]));
                txtSaldoInt.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALINT"]));
                txtSaldoIntComp.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nSalIntComp"]));
                txtSaldoOtr.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALOTR"]));
                txtSaldoMora.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALMOR"]));
                txtSaldoTotal.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]));
                txtMontoDesembolsado.Text = String.Format("{0:#,0.00}", Convert.ToDecimal(tbDatosCuenta.Rows[0]["nCapitalDesembolso"]));

                txtAgencia.Text = tbDatosCuenta.Rows[0]["cNombreAge"].ToString();
                txtNroCondonaciones.Text = tbDatosCuenta.Rows[0]["nNroCondo"].ToString();


                this.conProducto1.cargarProductos(1, Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]));
                this.txtDiasAtraso.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAtraso"]);
                this.cboCondicionContNormal.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableNormal"]);
                this.cboCondicionContVenc.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableVenc"]);
                this.txtAnioCastigo.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nAnioCastigo"]);
                this.cboMoneda1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["IdMoneda"]);
                this.idCuenta = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCuenta"]);

                idContable = Convert.ToInt32(tbDatosCuenta.Rows[0]["idCondContableVenc"]);
                nAtraso = Convert.ToInt32(tbDatosCuenta.Rows[0]["nAtraso"]);

                DataTable dtGastosSeguro = SolicCondonacion.obtieneGastosCuenta(this.idCuenta, 2, Convert.ToInt32(tbDatosCuenta.Rows[0]["idPlanPagos"]), 0);//2 = gastos de seguro
                if (dtGastosSeguro.Rows.Count > 0)
                {
                    this.lblSeguro.Text = dtGastosSeguro.Rows[0]["nSuma"].ToString();
                    this.lblSeguro.Visible = true;
                    //this.cGastosSeguro = "Existen gastos por Seguro.";
                }
                else
                {
                    this.lblSeguro.Text = "0.00";
                    this.lblSeguro.Visible = false;
                }

                //Validar que no exista una solicitud pendiente o aprobada

                DataTable SolicDuplicada = SolicCondonacion.CNBuscaSolicitudAprobacion(Convert.ToInt32(tbDatosCuenta.Rows[0]["idCli"]), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text), idAgencia);
                if (SolicDuplicada.Rows.Count > 0)
                {
                    //if (btnEnviar.Visible)
                    //{
                    //    MessageBox.Show("La solicitud de condonación ya fue enviada por:" +
                    //                    "\nUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                    //                    "\nAgencia:  " + SolicDuplicada.Rows[0]["cNombreAge"] +
                    //                    "\nFecha:    " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación",
                    //                                                                                                                    MessageBoxButtons.OK,
                    //                                                                                                                    MessageBoxIcon.Exclamation);
                    //}
                    //btnRptSbs.Enabled = true;
                    idSolicitudAproba = Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAproba"]);

                    tbDatosCuenta = Credito.CNObtieneDetalleCondonacion(idSolicitudAproba);
                    
                    if (tbDatosCuenta.Rows.Count > 0)
                    {
                        cboTipoCondonacion1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCondonacion"]);
                        cboTipoCorrespondencia1.SelectedValue = Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCorr"]);

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

                        if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lPorCouta"]))
                        {
                            DataTable dtCoutasCond = SolicCondonacion.ListaDetalleCondXCuota(idSolicitudAproba);
                            DataSet dsCoutasCondonadas = new DataSet("DSCoutasCondonadas");
                            String xmlCoutasCond = String.Empty;
                            if (dtCoutasCond.Rows.Count > 0)
                            {
                                dsCoutasCondonadas.Tables.Add(dtCoutasCond);
                                xmlCoutasCond = dsCoutasCondonadas.GetXml();
                                //xmlCoutasCond = clsCNFormatoXML.EncodingXML(xmlCoutasCond);
                                dsCoutasCondonadas.Tables.Clear();
                            }
                            //this.xmlCoutasCondonadas = xmlCoutasCond;
                            xmlCoutasCondonadas = xmlCoutasCond;
                        }
                        //Consultar si hay visto Bueno
                        clsGestionaNivelAprobacion oNivel = new clsGestionaNivelAprobacion();
                        clsFinVoBoNivelesAproba oVoBo = oNivel.validarVoBoNivelAproba(idSolicitudAproba);
                        
                        if (Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoCorr"]) == 2)
                        {
                            abrirFrmXcuotas(false);
                        }

                        this.cargaCobsIdSolicitudAproba(idSolicitudAproba);

                        if (oVoBo != null)
                        {
                            txtComentario.Text = oVoBo.cComentario;
                            evento = EventoFormulario.NUEVO;
                            MessageBox.Show("La solicitud de condonacion para esta cuenta ya tiene un VoBo.", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            controlComponentes();
                            //btnRptSbs.Enabled = false;
                            btnBandeja.Visible = false;
                            
                        }
                        else
                        {
                            if (Convert.ToInt32((revisarVistoBueno(idSolicitudAproba).Rows[0]["idEstado"]))==1)
                            {
                                evento = EventoFormulario.EDITAR;
                                controlComponentes();
                            }
                            else 
                            {
                                evento = EventoFormulario.NUEVO;
                                controlComponentes();
                                btnBandeja.Visible = false;
                                grbBase1.Visible = false;
                            }
                            

                            
                        }
                    }
                    else
                    {
                        evento = EventoFormulario.INICIO;
                        controlComponentes();
                        MessageBox.Show("La cuenta no tiene ninguna solicitud de condonación en estado SOLICITADO", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarDatos();
                        return;
                    }
                    cboMot.SelectedValue = Convert.ToInt32(SolicDuplicada.Rows[0]["idMotivo"]);
                    txtMot.Text = SolicDuplicada.Rows[0]["cSustento"].ToString();
                    //chcRefinanciamiento.Checked = Convert.ToBoolean(SolicDuplicada.Rows[0]["lRefinanciamiento"]);
                    //txtNumeroCtaCOB.Text = SolicDuplicada.Rows[0]["cCuentasCOB"].ToString();
                    txtMontoTotalCTA.Text = SolicDuplicada.Rows[0]["nMontoCuentaCOB"].ToString();
                    cboMot.Enabled = false;
                    txtMot.Enabled = false;

                    //this.btnMiniBusq1.Enabled = this.conBusCuentaCli.btnBusCliente1.Enabled;
                    this.conBusCuentaCli.txtCodCli.Enabled = this.conBusCuentaCli.txtNroBusqueda.Enabled;
                    if (Convert.ToDecimal(txtCap.Text)!=0)
                        porcCap.Text = Math.Round(Convert.ToDecimal(txtCondCapital.Text) * 100 / Convert.ToDecimal(txtCap.Text),2).ToString("#0.00");
                    if (Convert.ToDecimal(txtInt.Text) != 0)
                        porcInt.Text = Math.Round(Convert.ToDecimal(txtCondInteres.Text) * 100 / Convert.ToDecimal(txtInt.Text), 2).ToString("#0.00");
                    if (Convert.ToDecimal(txtIntComp.Text) != 0)
                        porcIntComp.Text = Math.Round(Convert.ToDecimal(txtCondIntComp.Text) * 100 / Convert.ToDecimal(txtIntComp.Text), 2).ToString("#0.00");
                    if (Convert.ToDecimal(txtMora.Text) != 0)
                        porcMor.Text = Math.Round(Convert.ToDecimal(txtCondMora.Text) * 100 / Convert.ToDecimal(txtMora.Text), 2).ToString("#0.00");
                    if (Convert.ToDecimal(txtOtro.Text) != 0)
                        porcOtros.Text = Math.Round(Convert.ToDecimal(txtCondOtros.Text) * 100 / Convert.ToDecimal(txtOtro.Text), 2).ToString("#0.00");

                    return;
                }
                btnAdjuntarFile1.Enabled = true;
                btnRptSbs.Enabled = true;
            }
        }

        public void CleanData()
        {
            cboMot.SelectedIndex = -1;
            cboTipoCorrespondencia1.SelectedIndex = -1;
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
            //txtMontoDesembolsado.Text = "0.00";

            //this.conProducto1.limpiar();
            //this.cboCondicionContNormal.SelectedIndex = -1;
            //this.cboCondicionContVenc.SelectedIndex = -1;
            //this.txtDiasAtraso.Clear();
            //this.cboMoneda1.SelectedIndex = -1;

            //this.chcRefinanciamiento.Checked = false;
            //this.txtNumeroCtaCOB.Clear();
            this.txtMontoTotalCTA.Clear();

            if (this.cboTipoCondonacion1.Items.Count > 0)
            {
                this.cboTipoCondonacion1.SelectedIndex = 0;
            }

            //this.xmlCoutasCondonadas = null;
            this.lblSeguro.Text = String.Empty;
        }

        private void btnBuenaPro1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;
            clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(this.idSolicitudAproba, this.idModulo, this.idTipoOperacion);
            
            MessageBox.Show(objNivelAproba.obtenerNivelAprobacionSolicitud(), this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (objNivelAproba.getIdNivelAprobacion() != 0)
            {
                this.guardarVoBo(txtComentario.Text, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, EstadoAprobacion.VoBo);
                evento = EventoFormulario.INICIO;
                controlComponentes();
            }

        }

        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            MessageBox.Show(this.guardarVoBo(txtComentario.Text, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, EstadoAprobacion.Denegado)
                    , this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            evento = EventoFormulario.INICIO;
            controlComponentes();
        }

        private string guardarVoBo(string cComentario, int idUsuario, int idPerfil, DateTime dFecha, int idEstadoAproba)
        { 
            clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(this.idSolicitudAproba, this.idModulo, this.idTipoOperacion);
            return objNivelAproba.guardarVoBoNivelAprobacion(cComentario, idUsuario, idPerfil, dFecha, idEstadoAproba);
        }
        private DataTable revisarVistoBueno(int idSolicitudAproba)
        {
            clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(this.idSolicitudAproba, this.idModulo, this.idTipoOperacion);
            return objNivelAproba.revisarVistoBuenoNivelAprobacion(idSolicitudAproba);
        }

        private bool validar()
        {
            if (String.IsNullOrEmpty(txtComentario.Text))
            {
                MessageBox.Show("Debe registrar un comentario", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtComentario.Focus();
                return false;
            }

            return true;
        }

        private void controlComponentes()
        {
            switch (evento)
            { 
                case EventoFormulario.INICIO:
                    txtComentario.Enabled = false;
                    btnAdjuntarFile1.Enabled = false;
                    btnVoBo.Enabled = false;
                    btnDenegar.Enabled = false;
                    btnCancelar.Enabled = true;

                    break;
                case EventoFormulario.EDITAR:
                    txtComentario.Enabled = true;
                    btnAdjuntarFile1.Enabled = true;
                    btnRptSbs.Enabled = true;
                    btnVoBo.Enabled = true;
                    btnDenegar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case EventoFormulario.ENVIAR:
                    txtComentario.Enabled = false;
                    btnAdjuntarFile1.Enabled = true;
                    btnRptSbs.Enabled = true;
                    btnVoBo.Enabled = false;
                    btnDenegar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }
        }

        private void limpiarDatos()
        { 
            idCuenta = 0;
            idContable = 0;
            nAtraso = 0;
            idSolicitudAproba = 0;
            conBusCuentaCli.limpiarControles();
            conProducto1.limpiar();
            txtDiasAtraso.Clear();
            txtAnioCastigo.Clear();
            cboMoneda1.SelectedIndex = -1;
            txtMontoDesembolsado.Clear();
            cboCondicionContNormal.SelectedIndex = -1;
            cboCondicionContVenc.SelectedIndex = -1;
            cboTipoCorrespondencia1.SelectedIndex = -1;
            cboTipoCondonacion1.SelectedIndex = -1;
            txtCap.Clear();
            txtInt.Clear();
            txtIntComp.Clear();
            txtMora.Clear();
            txtOtro.Clear();
            txtTotal.Clear();
            txtCondCapital.Clear();
            txtCondInteres.Clear();
            txtCondIntComp.Clear();
            txtCondMora.Clear();
            txtCondOtros.Clear();
            txtCondTotal.Clear();
            txtSaldoCap.Clear();
            txtSaldoInt.Clear();
            txtSaldoIntComp.Clear();
            txtSaldoMora.Clear();
            txtSaldoOtr.Clear();
            txtSaldoOtr.Clear();
            txtSaldoTotal.Clear();
            cboMot.SelectedIndex = -1;
            //txtNumeroCtaCOB.Clear();
            txtMontoTotalCTA.Clear();
            txtMot.Clear();
            txtComentario.Clear();
        }

        public void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            evento = EventoFormulario.INICIO;
            LiberarCuenta();
            controlComponentes();
            limpiarDatos();
            if (dtgCobs.Rows.Count > 0)
                ((DataTable)dtgCobs.DataSource).Clear();
            btnRptSbs.Enabled = false;
            archivos = null;
        }

        private void frmVoBoJefeOficinaRecuperaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cargaAdjuntaArchivos()
        {
            if (archivos == null || archivos.Rows.Count == 0)
            {
                DataTable dt = SolicCondonacion.filesCondonacion(idSolicitudAproba, idCuenta);

                foreach (DataColumn item in dt.Columns)
                {
                    item.ReadOnly = false;
                }
                archivos = dt.Copy();
            }

            frmAdjArchivosCondonacion frm_ = new frmAdjArchivosCondonacion(archivos, idSolicitudAproba);
            frm_.ShowDialog();

            archivos = frm_.getDtgFiles();
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

        private decimal obtenerSumaCobs()
        {
            decimal nTotal = 0.00m;
            foreach (DataGridViewRow item in dtgCobs.Rows)
            {
                nTotal = nTotal + Convert.ToDecimal(item.Cells["nMontoTot"].Value);
            }
            return nTotal;
        }

        private void CalculaCond(bool lActualizaSaldo = true)
        {
            txtSaldoCap.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtCap.Text) - Convert.ToDecimal(txtCondCapital.Text)));
            txtSaldoInt.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtInt.Text) - Convert.ToDecimal(txtCondInteres.Text)));
            txtSaldoIntComp.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtIntComp.Text) - Convert.ToDecimal(txtCondIntComp.Text)));
            txtSaldoMora.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtMora.Text) - Convert.ToDecimal(txtCondMora.Text)));
            txtSaldoOtr.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtOtro.Text) - Convert.ToDecimal(txtCondOtros.Text)));

            txtCondTotal.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtCondCapital.Text) +
                                                            Convert.ToDecimal(txtCondInteres.Text) +
                                                            Convert.ToDecimal(txtCondIntComp.Text) +
                                                            Convert.ToDecimal(txtCondMora.Text) +
                                                            Convert.ToDecimal(txtCondOtros.Text)));
            txtSaldoTotal.Text = String.Format("{0:#,0.00}", (Convert.ToDecimal(txtSaldoCap.Text) +
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

        private void cboTipoCorrespondencia1_SelectedValueChanged(object sender, EventArgs e)
        {

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

        public void abrirFrmXcuotas(bool lEditar = true)
        {
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
                

                
                CalculaCond();
                nMontoCondonar.Text = txtCondTotal.Text;
                nMontoPagar.Text = Convert.ToDecimal(frmcondonaporcuota.getMontoXCuota()).ToString();
                txtCuotasCondonar.Text = frmcondonaporcuota.nNumCuotasAfectadas.ToString();

                cargaITF();
            }
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

        private void btnBandeja_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            frmBandejaSolVoBo bandeja = new frmBandejaSolVoBo();
            bandeja.ShowDialog();
            int idCuenta = bandeja.idCuentaSelect();
            conBusCuentaCli.nValBusqueda = idCuenta;
            conBusCuentaCli.txtNroBusqueda.Text = idCuenta.ToString();
            conBusCuentaCli.asignarCuenta(idCuenta);
            cargarData();
            archivos = null;
            //conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e);
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

    }
}
