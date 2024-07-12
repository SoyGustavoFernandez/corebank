using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRegGastosSinComprobante : frmBase
    {
        private decimal ntipoCambioFijo;
        private int nidCajChica = 0, nidComprobantePago = 0;
        private bool lFlagValidar = true;
        clsCNCajaChica objCajaChica = new clsCNCajaChica();
        clsCNComprobantes objComp = new clsCNComprobantes();
        DataTable dtComprPago, dtDetComprPago,dtDatosCajChica;        
        DataTable dtBuscaCompCajaChica;

        int IdCentroCosto = 0;
        DataTable dtMovilidad;

        public frmRegGastosSinComprobante()
        {
            InitializeComponent();                       
        }

        private void frmRegGastosSinComprobante_Load(object sender, EventArgs e)
        {
            if (!ValidarCajaChica(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia))
            {
                return;
            }
            this.txtNroCajChica.Text = dtDatosCajChica.Rows[0]["nNroCajChi"].ToString();
            this.txtNomCajChica.Text = dtDatosCajChica.Rows[0]["cNomCajChi"].ToString();
            
            CargarConceptos(3);
            LimpiarComponentes();
            CargarTipoCambio();
            HabilitarComponentes(3);

            lblTipoCambio.Visible = false;
            txtTipoCambio.Visible = false;
            lblMontoCalculado.Visible = false;
            txtMontoCalculado.Visible = false;
            cboMoneda.SelectedValue = 1;
            cboMoneda.Enabled = false;            
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
        }

        private void btnBusqGasto_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
            frmBusqCompPago.chcTieneComprobante.Checked = false;
            frmBusqCompPago.chcCajChic.Checked = true;
            frmBusqCompPago.ShowDialog();
            nidComprobantePago = frmBusqCompPago.pidComprobantePago;
            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarComprobante(nidComprobantePago);
            btnCancelar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarCajaChica(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia))
            {
                return;
            }
            this.txtNroCajChica.Text = dtDatosCajChica.Rows[0]["nNroCajChi"].ToString();
            this.txtNomCajChica.Text = dtDatosCajChica.Rows[0]["cNomCajChi"].ToString();
            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtDetComprPago = null;
            dtComprPago = null;
            dtMovilidad = null;
            dtComprPago = new DataTable("dtComprPago");
            dtDetComprPago = new DataTable("dtDetComprPago");
            dtMovilidad = new DataTable("dtMovilidad");

            //=======================================================================
            //--Limpiar controles y crear columnas para los DataTables
            //=======================================================================
            LimpiarComponentes();
            CrearDataTables();

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Maestro 
            //=======================================================================
            DataRow drComprPago = dtComprPago.NewRow();
            drComprPago["idComprobantePago"] = -1;
            drComprPago["idCliente"] = 0;
            drComprPago["idTipoComprobantePago"] = 49;
            drComprPago["idMoneda"] = -1;
            drComprPago["idDestino"] = 0;
            drComprPago["idAgencia"] = clsVarGlobal.nIdAgencia;
            drComprPago["cSerie"] = "";
            drComprPago["cNumero"] = "";
            drComprPago["nMontoITF"] = 0.00;
            drComprPago["dFechaOpe"] = clsVarApl.dicVarGen["dFechaAct"];            
            drComprPago["lTieneComprobante"] = 0;
            drComprPago["idBienServicioDetr"] = DBNull.Value;
            drComprPago["nSubTotal"] = 0.00;
            drComprPago["nTotalIGV"] = 0.00;
            drComprPago["nIgvCalculo"] = 0.00;
            drComprPago["nTotal"] = 0.00;
            drComprPago["nTotalDetraccion"] = 0.00;
            drComprPago["idUsuarioRegistro"] = clsVarGlobal.User.idUsuario;
            drComprPago["dFechaProvision"] = DBNull.Value;
            drComprPago["lEstadoProvision"] = false;
            drComprPago["lCpgCajChica"] = 1;
            drComprPago["idEstadoComprobante"] = 2;
            drComprPago["idTipoPago"] = 1;
            drComprPago["nTipCambio"] = clsVarApl.dicVarGen["nTipCamFij"];
            drComprPago["lAfeCuartaCateg"] = false;
            //drComprPago["IdCentroCosto"] = IdCentroCosto;
            dtComprPago.Rows.Add(drComprPago);

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Detalle
            //=======================================================================
            DataRow drDetComprPago = dtDetComprPago.NewRow();
            drDetComprPago["idDetalleComprobante"] = -1;
            drDetComprPago["idComprobantePago"] = -1;
            drDetComprPago["idConceptoPadre"] = -1;
            drDetComprPago["cConceptoComprPago"] = "Concepto";
            drDetComprPago["idConceptoComprobante"] = -1;
            drDetComprPago["nSubtotalImporte"] = 0.00;
            drDetComprPago["nIgvImporte"] = 0.00;
            drDetComprPago["nMontoImporte"] = 0.00;
            drDetComprPago["nMontoDetraccion"] = 0.00;
            drDetComprPago["lVigente"] = 1;
            drDetComprPago["idAgencia"] = clsVarGlobal.nIdAgencia;
            drDetComprPago["IdCentroCosto"] = IdCentroCosto;
            dtDetComprPago.Rows.Add(drDetComprPago);

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Detalle
            //=======================================================================
            //DataRow drMovilidad = dtMovilidad.NewRow();
            //drMovilidad["cLugarOrigen"] = "";
            //drMovilidad["cLugarDestino"] = "";
            //dtMovilidad.Rows.Add(drMovilidad);

            nidCajChica = Convert.ToInt32(dtDatosCajChica.Rows[0]["idCajChica"]);

            txtCodigo.Text = "0";
            btnImprimir.Enabled = false;
            HabilitarComponentes(2);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ValidarDatos();
            if (!lFlagValidar) return;

            //=======================================================================
            //--Asignar Datos a DataTable Maestro y Detalla para Grabar 
            //=======================================================================
            nidCajChica = Convert.ToInt32(dtDatosCajChica.Rows[0]["idCajChica"]);

            dtComprPago.Rows[0]["idCliente"] = conBusCliente.txtCodCli.Text.Trim();
            dtComprPago.Rows[0]["idMoneda"] = Convert.ToInt32(cboMoneda.SelectedValue.ToString());
            dtComprPago.Rows[0]["cGlosa"] = txtGlosa.Text.Trim();
            if (txtTipoCambio.Text == "0.00")
            {
                dtComprPago.Rows[0]["nTipCambio"] = "0.00";
            }
            else
            {
                dtComprPago.Rows[0]["nTipCambio"] = Convert.ToDecimal(txtTipoCambio.Text);
            }
            dtDetComprPago.Rows[0]["idConceptoComprobante"] = Convert.ToInt32(cboConcepto.SelectedValue.ToString());            
            if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 1)
            {
                dtComprPago.Rows[0]["nTotal"] = Convert.ToDecimal(txtMonto.Text);
            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
            {
                dtComprPago.Rows[0]["nTotal"] = Convert.ToDecimal(txtMontoCalculado.Text);
            }
            dtComprPago.Rows[0]["nSubTotal"] = dtComprPago.Rows[0]["nTotal"];
            dtDetComprPago.Rows[0]["nSubtotalImporte"] = dtComprPago.Rows[0]["nTotal"];
            dtDetComprPago.Rows[0]["nMontoImporte"] = dtComprPago.Rows[0]["nTotal"];
            dtComprPago.Rows[0]["dFechaEmision"] = dtpFechaEmision.Value;
            dtComprPago.Rows[0]["dFechaPago"] = dtpFechaEmision.Value;

            dtDetComprPago.Rows[0]["IdCentroCosto"] = IdCentroCosto;
            dtDetComprPago.Rows[0]["idAgencia"] = cboAgencias.SelectedValue;

            //dtComprPago.Rows[0]["IdCentroCosto"] = IdCentroCosto;

            //=======================================================================
            //--Validar Montos para registro en caja chica
            //=======================================================================
            ValidarMontosCajChica();
            if (!lFlagValidar) return;

            dtComprPago.TableName = "dtComprPago";
            dtDetComprPago.TableName = "dtDetComprPago";
            
            //=======================================================================
            //--Crear los DataSet y agregar los Datatables para los xml
            //=======================================================================
            int x_idCpg = 0;
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                x_idCpg = Convert.ToInt32(txtCodigo.Text);
            }

            if (chcMovilidad.Checked)
            {
                DataRow drMovilidad = dtMovilidad.NewRow();
                drMovilidad["idComprobantePago"] = x_idCpg;
                drMovilidad["cLugarOrigen"] = txtMovOri.Text.ToString();
                drMovilidad["cLugarDestino"] = txtMovDest.Text.ToString();
                drMovilidad["lVigente"] = 1;
                dtMovilidad.Rows.Add(drMovilidad);
            }
            else
            {
                DataRow drMovilidad = dtMovilidad.NewRow();
                drMovilidad["idComprobantePago"] = x_idCpg;
                drMovilidad["cLugarOrigen"] = "";
                drMovilidad["cLugarDestino"] = "";
                drMovilidad["lVigente"] = 0;
                dtMovilidad.Rows.Add(drMovilidad);
            }     

            //=======================================================================
            //--Crear los DataSet y agregar los Datatables para los xml
            //=======================================================================
            DataSet dsComprPago = new DataSet("dsComprPago");
            DataSet dsDetComprPago = new DataSet("dsDetComprPago");
            DataSet dsDescComprPago = new DataSet("dsDescComprPago");
            DataSet dsMovilidad = new DataSet("dsMovilidad");

            dsComprPago.Tables.Add(dtComprPago);
            dsDetComprPago.Tables.Add(dtDetComprPago);
            dsMovilidad.Tables.Add(dtMovilidad);

            string xmlComprPago = clsCNFormatoXML.EncodingXML(dsComprPago.GetXml());
            string xmlDetComprPago = clsCNFormatoXML.EncodingXML(dsDetComprPago.GetXml());
            string xmlDescComprPago = clsCNFormatoXML.EncodingXML(dsDescComprPago.GetXml());
            string xmlMovilidad = clsCNFormatoXML.EncodingXML(dsMovilidad.GetXml());

            dsComprPago.Tables.Clear();
            dsDetComprPago.Tables.Clear();
            dsDescComprPago.Tables.Clear();
            dsMovilidad.Tables.Clear();

            DateTime dFechaPago = dtpFechaEmision.Value;
            bool lTieneComprobante = false;
            int idUsuario = clsVarGlobal.User.idUsuario;

            //DataTable result = objCajaChica.GuardarComprPgCajChica(xmlComprPago, xmlDetComprPago, xmlDescComprPago,nidCajChica);
            DataTable result = objCajaChica.CNPagoComprCajaChica(xmlComprPago, xmlDetComprPago, xmlDescComprPago, nidCajChica, dFechaPago, lTieneComprobante, idUsuario, xmlMovilidad, clsVarGlobal.nIdAgencia);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString() + "NRO REGISTRO: " + result.Rows[0]["nNroRegistro"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BuscarComprobante(Convert.ToInt32(result.Rows[0]["nNroRegistro"].ToString()));
                txtCodigo.Text = result.Rows[0]["nNroRegistro"].ToString();
                txtSerie.Text = result.Rows[0]["cSerie"].ToString();
                txtNumero.Text = result.Rows[0]["cNumero"].ToString();
                HabilitarComponentes(1);
                btnEditar.Enabled = false;
                btnAnular.Enabled = true;
                btnCancelar.Enabled = true;
                btnImprimir.Enabled = true;

                DataTable dtBuscaDestinoMov = objComp.CNListDestinoMov(Convert.ToInt32(result.Rows[0]["nNroRegistro"]));

                if (dtBuscaDestinoMov.Rows.Count > 0)
                {
                    chcMovilidad.Checked = true;
                    lblMovOrigen.Visible = chcMovilidad.Checked;
                    lblMovDestino.Visible = chcMovilidad.Checked;
                    txtMovOri.Visible = chcMovilidad.Checked;
                    txtMovDest.Visible = chcMovilidad.Checked;
                    txtMovOri.Enabled = false;
                    txtMovDest.Enabled = false;

                    txtMovOri.Text = Convert.ToString(dtBuscaDestinoMov.Rows[0]["cLugarOrigen"]);
                    txtMovDest.Text = Convert.ToString(dtBuscaDestinoMov.Rows[0]["cLugarDestino"]);
                }
           }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarComponentes();
            HabilitarComponentes(1);
            btnImprimir.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarComponentes(2);
            btnCentroCosto.Enabled = true;
            cboConcepto.Enabled = true;
            cboAgencias.Enabled = true;
            
            this.btnEditar.Enabled = false;
            this.btnAnular.Enabled = false;
            dtpFechaEmision.Enabled = false;
            cboMoneda.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = true;

            txtMonto.Enabled = false;
            txtMontoCalculado.Enabled = false;
            btnCentroCosto.Focus();
        }        

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Primero debe Buscar el Comprobante a Eliminar", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //VALIDA EL USUARIO DE REGISTRO EL COMPROBANTE

            if (Convert.ToInt32(dtComprPago.Rows[0]["idUsuarioRegistro"]) != Convert.ToInt32(clsVarGlobal.User.idUsuario))
            {
                MessageBox.Show("El Usuario que ANULA debe ser el mismo del REGISTRO ", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //VALIDA LA CAJA CHICA DEL COMPROBANTE QUE SE QUIERE ANULAR

            DataTable dtValidaCajChica = objCajaChica.RetDatCajChic(Convert.ToInt32(dtComprPago.Rows[0]["idUsuarioRegistro"]), Convert.ToInt32(dtDetComprPago.Rows[0]["idAgencia"]));

            if (dtValidaCajChica.Rows.Count == 0)
            {
                MessageBox.Show("Usted no es responsable de Caja Chica", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int nIdEstCajaChica = Convert.ToInt16(dtValidaCajChica.Rows[0]["idEstCajChi"]);
            if (nIdEstCajaChica == 4)
            {
                MessageBox.Show("Falta Realizar Habilitación de Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (nIdEstCajaChica == 1)
            {
                MessageBox.Show("Falta Iniciar Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (nIdEstCajaChica == 3)
            {
                MessageBox.Show("Caja Chica Cerrada, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //
            int idCpg = Convert.ToInt32(txtCodigo.Text);


            frmMotAnulacion frmMotivoAnula = new frmMotAnulacion();
            frmMotivoAnula.ShowDialog();
            string cMotivoEli = frmMotivoAnula.cMotivoEli;

            if (string.IsNullOrEmpty(cMotivoEli))
            {
                MessageBox.Show("No existe motivo de Anulación", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //string cMotivoEli = "Comprobante Mal Emitido";

            if (idCpg <= 0)
            {
                MessageBox.Show("El Número de Comprobante no es Válido", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Esta seguro(a) de anular este comprobante de pago?", "Registro de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            //==================================================================================
            //--Anular Comprobante
            //==================================================================================
            DataTable result = objCajaChica.CNEliminarComprobanteCaja(idCpg, cMotivoEli, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (result.Rows[0]["nResp"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarComponentes(1);
                btnEditar.Enabled = false;
                txtCodigo.Enabled = false;
                btnAnular.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblTipoCambio.Visible = true;
                    txtTipoCambio.Visible = true;
                    txtTipoCambio.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamProVen"]);
                }
                else
                {
                    lblTipoCambio.Visible = false;
                    txtTipoCambio.Visible = false;
                    lblMontoCalculado.Visible = false;
                    txtMontoCalculado.Visible = false;
                    txtTipoCambio.Text = "0.00";
                }
            }
        }        

       private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonto.Text))
            {
                txtMonto.Text = Convert.ToDecimal(txtMonto.Text).ToString("##,##0.00");
            }
            else
            {
                txtMonto.Text = "0.00";
            }
            if (txtMontoCalculado.Visible)
            {
                txtMontoCalculado.Text = Math.Round(Convert.ToDecimal(txtMonto.Text) * Convert.ToDecimal(txtTipoCambio.Text),2,MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void CrearDataTables()
        {
            //=======================================================================
            //--Crear las columnas del DataTable del Maestro del comprobante 
            //=======================================================================
            dtComprPago.Columns.Add("idComprobantePago", typeof(Int32));
            dtComprPago.Columns.Add("idCliente", typeof(Int32));
            dtComprPago.Columns.Add("idTipoComprobantePago", typeof(Int32));
            dtComprPago.Columns.Add("idMoneda", typeof(Int32));
            dtComprPago.Columns.Add("idDestino", typeof(Int32));
            dtComprPago.Columns.Add("idAgencia", typeof(Int32));
            dtComprPago.Columns.Add("dFechaRegistro", typeof(DateTime));
            dtComprPago.Columns.Add("dFechaEmision", typeof(DateTime));
            dtComprPago.Columns.Add("dFechaPago", typeof(DateTime));
            dtComprPago.Columns.Add("lTieneComprobante", typeof(bool));
            dtComprPago.Columns.Add("cSerie", typeof(string));
            dtComprPago.Columns.Add("cNumero", typeof(string));
            dtComprPago.Columns.Add("idBienServicioDetr", typeof(Int32));
            dtComprPago.Columns.Add("cGlosa", typeof(string));
            dtComprPago.Columns.Add("nSubTotal", typeof(decimal));
            dtComprPago.Columns.Add("nTotalIGV", typeof(decimal));
            dtComprPago.Columns.Add("nIgvCalculo", typeof(decimal));
            dtComprPago.Columns.Add("nTotal", typeof(decimal));
            dtComprPago.Columns.Add("nTotalDetraccion", typeof(decimal));
            dtComprPago.Columns.Add("idUsuarioRegistro", typeof(Int32));
            dtComprPago.Columns.Add("dFechaProvision", typeof(DateTime));
            dtComprPago.Columns.Add("lEstadoProvision", typeof(bool));
            dtComprPago.Columns.Add("lCpgCajChica", typeof(bool));
            dtComprPago.Columns.Add("idEstadoComprobante", typeof(Int32));
            dtComprPago.Columns.Add("idTipoPago", typeof(Int32));
            dtComprPago.Columns.Add("dFechaOpe", typeof(DateTime));
            dtComprPago.Columns.Add("nMontoITF", typeof(decimal));
            dtComprPago.Columns.Add("nTipCambio", typeof(decimal));
            dtComprPago.Columns.Add("lAfeCuartaCateg", typeof(bool));
            //dtComprPago.Columns.Add("IdCentroCosto", typeof(Int32));   //se añadio los centros de Costos a caja chica

            //=======================================================================
            //--Crear las columnas del DataTable del Detalle del comprobante 
            //=======================================================================
            dtDetComprPago.Columns.Add("idDetalleComprobante", typeof(Int32));
            dtDetComprPago.Columns.Add("idComprobantePago", typeof(Int32));
            dtDetComprPago.Columns.Add("idConceptoPadre", typeof(Int32));
            dtDetComprPago.Columns.Add("idConceptoComprobante", typeof(Int32));
            dtDetComprPago.Columns.Add("cConceptoComprPago", typeof(string));
            dtDetComprPago.Columns.Add("nSubtotalImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nIgvImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nMontoDetraccion", typeof(decimal));
            dtDetComprPago.Columns.Add("nMontoImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("lVigente", typeof(bool));
            dtDetComprPago.Columns.Add("idAgencia", typeof(Int32));
            dtDetComprPago.Columns.Add("IdCentroCosto", typeof(Int32));

            //=======================================================================
            //--Crear las columnas del DataTable del Detalle del comprobante 
            //=======================================================================
            dtMovilidad = new DataTable("dtMovilidad");
            dtMovilidad.Columns.Add("idComprobantePago", typeof(int));
            dtMovilidad.Columns.Add("cLugarOrigen", typeof(string));
            dtMovilidad.Columns.Add("cLugarDestino", typeof(string));
            dtMovilidad.Columns.Add("lVigente", typeof(bool));
        }        

        private void ValidarDatos()
        {
            string Msje = "";
            lFlagValidar = true;
            if (conBusCliente.txtCodCli.Text.Trim().Equals(""))
            {
                Msje += "Seleccione un cliente.";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(cboMoneda.SelectedIndex) == -1)
            {
                Msje += "Seleccione el tipo de moneda del gasto.";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(cboConcepto.SelectedIndex) == -1)
            {
                Msje += "\nSeleccione un concepto.";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
         
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                Msje += "\nIngrese el Monto del Gasto.";
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
                return;
            }
            if (Convert.ToDecimal(txtMonto.Text)<=0)
            {
                Msje += "\nEl Monto del gasto debe de ser mayor a 0.";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtGlosa.Text))
            {
                Msje += "\nIngrese una descripcion del gasto.";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //NO DEBE VALIDAD CENTRO DE COSTOS PORQUE ES OPCIONAL PARA GASTOS SIN COMPROBANTES

            //if (IdCentroCosto<=0)
            //{
            //    Msje += "\nDebe seleccionar un Centro de Costos para el Gasto";
            //    lFlagValidar = false;
            //    MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            if (chcMovilidad.Checked)
            {
                if (string.IsNullOrEmpty(txtMovOri.Text))
                {
                    Msje += "\nDebe Ingresar el origen de la Movilidad";
                    lFlagValidar = false;
                    MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (string.IsNullOrEmpty(txtMovDest.Text))
                {
                    Msje += "\nDebe Ingresar el Destino de la Movilidad";
                    lFlagValidar = false;
                    MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                
            }

            if (Convert.ToInt32(cboAgencias.SelectedIndex) == -1)
            {
                Msje += "\nSeleccione Agencia";
                lFlagValidar = false;
                MessageBox.Show(Msje, "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void ValidarMontosCajChica()
        {
            lFlagValidar = true;

            if (Convert.ToDecimal(dtDatosCajChica.Rows[0]["nMonMaxCpg"].ToString()) < Convert.ToDecimal(dtComprPago.Rows[0]["nTotal"].ToString()))
            {
                MessageBox.Show("EL MONTO DEL COMPROBANTE EXCEDE EL MONTO MAXIMO PERMITIDO", "Registro de Gastos Sin Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
                return;
            }

            if (Convert.ToDecimal(dtDatosCajChica.Rows[0]["nSaldoAcum"].ToString()) + Convert.ToDecimal(dtComprPago.Rows[0]["nTotal"].ToString()) >= Convert.ToDecimal(dtDatosCajChica.Rows[0]["nMonMaxCaj"].ToString()))
            {
                MessageBox.Show("FONDOS INSUFICIENTES PARA ESTE COMPROBANTE", "Registro de Gastos Sin Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }
        }

        public void LimpiarComponentes()
        {
            txtCodigo.Text = "";
            dtpFechaEmision.Value = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
            conBusCliente.txtCodAge.Text = "";
            conBusCliente.txtCodCli.Text = "";
            conBusCliente.txtCodInst.Text = "";
            conBusCliente.txtDireccion.Text = "";
            conBusCliente.txtNombre.Text = "";
            conBusCliente.txtNroDoc.Text = "";
            cboConcepto.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtMonto.Text = "";
            txtMontoCalculado.Text = "";
            txtGlosa.Text = "";
            txtNumero.Clear();
            txtSerie.Clear();
            txtCentroCosto.Text = "";
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;

        }

        private void HabilitarComponentes(int nOpc)
        {
            if (nOpc == 1)
            {
                dtpFechaEmision.Enabled = false;
                cboMoneda.Enabled = false;
                txtCodigo.Enabled = false;
                conBusCliente.Enabled = false;
                txtGlosa.Enabled = false;
                cboConcepto.Enabled = false;
                
                txtMonto.Enabled = false;
                txtMontoCalculado.Enabled = false;

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnAnular.Enabled = false;
                btnBusqGasto.Enabled = true;
                cboMoneda.SelectedValue = 1;
                cboMoneda.Enabled = false;
                btnCentroCosto.Enabled = false;
                chcMovilidad.Enabled = false;
                chcMovilidad.Checked = false;
                cboAgencias.Enabled = false; 
                lblMovOrigen.Visible = chcMovilidad.Checked;
                lblMovDestino.Visible = chcMovilidad.Checked;
                txtMovOri.Visible = chcMovilidad.Checked;
                txtMovDest.Visible = chcMovilidad.Checked;
                
                if (!chcMovilidad.Checked)
                {
                   
                    txtMovOri.Text = "";
                    txtMovDest.Text = "";
                }

            }
            else if (nOpc == 2)
            {
                dtpFechaEmision.Enabled = false;
                cboMoneda.Enabled = true;
                txtCodigo.Enabled = true;
                conBusCliente.Enabled = true;
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.btnBusCliente.Enabled = true;
                txtGlosa.Enabled = true;
                cboConcepto.Enabled = true;
                
                txtMonto.Enabled = true;
                txtMontoCalculado.Enabled = true;

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAnular.Enabled = false;
                btnBusqGasto.Enabled = false;
                cboMoneda.SelectedValue = 1;
                cboMoneda.Enabled = false;
                btnCentroCosto.Enabled = true;
                chcMovilidad.Enabled = true;
                chcMovilidad.Checked = false;
                cboAgencias.Enabled = true; 
                lblMovOrigen.Visible = chcMovilidad.Checked;
                lblMovDestino.Visible = chcMovilidad.Checked;
                txtMovOri.Visible = chcMovilidad.Checked;
                txtMovDest.Visible = chcMovilidad.Checked;

                if (!chcMovilidad.Checked)
                {

                    txtMovOri.Text = "";
                    txtMovDest.Text = "";
                }
            }
            else if (nOpc == 3)
            {
                
                dtpFechaEmision.Enabled = false;
                cboMoneda.Enabled = false;                
                txtCodigo.Enabled = false;                
                conBusCliente.Enabled = false;               
                txtGlosa.Enabled = false;
                cboConcepto.Enabled = false;
                txtMonto.Enabled = false;
                txtMontoCalculado.Enabled = false;

                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAnular.Enabled = false;
                btnBusqGasto.Enabled = true;
                cboMoneda.SelectedValue = 1;
                cboMoneda.Enabled = false;
                btnCentroCosto.Enabled = false;
                chcMovilidad.Enabled = false;
                chcMovilidad.Checked = false;
                cboAgencias.Enabled = false; 
                lblMovOrigen.Visible = chcMovilidad.Checked;
                lblMovDestino.Visible = chcMovilidad.Checked;
                txtMovOri.Visible = chcMovilidad.Checked;
                txtMovDest.Visible = chcMovilidad.Checked;

                if (!chcMovilidad.Checked)
                {

                    txtMovOri.Text = "";
                    txtMovDest.Text = "";
                }
            }
        }        

        private void CargarTipoCambio()
        {
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RetornaTiposCambio(clsVarGlobal.dFecSystem);
            if (tbTipCam.Rows.Count > 0)
            {
                ntipoCambioFijo = Convert.ToDecimal(tbTipCam.Rows[0]["nTipCamFij"].ToString());
            }
            txtTipoCambio.Text = ntipoCambioFijo.ToString();
        }

        private void CargarConceptos(int nVal)
        {
            clsCNControlOpe objConceptos = new clsCNControlOpe();
            DataTable dtConceptos = objConceptos.ListaConceptos(4,"");
            cboConcepto.DataSource = dtConceptos;
            cboConcepto.DisplayMember = "cConcepto";
            cboConcepto.ValueMember = "idConcepto";
        }

        private bool ValidarCajaChica(int idResCajChi, int idAgencia)
        {
            dtDatosCajChica = objCajaChica.RetDatCajChic(idResCajChi, idAgencia);
            if (dtDatosCajChica.Rows.Count<=0)
            {
                 MessageBox.Show("No Existe Caja Chica Registrada, Por favor Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 this.Dispose();
                 return false;
            }


            if (idResCajChi != clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("Usted no es responsable de Caja Chica: " + dtDatosCajChica.Rows[0]["cNomCajChi"], "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAnular.Enabled = false;
                return false;
            }
            int nIdEstCajaChica = Convert.ToInt16(dtDatosCajChica.Rows[0]["idEstCajChi"]);
            if (nIdEstCajaChica == 4)
            {
                MessageBox.Show("Falta Realizar Habilitación de Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (nIdEstCajaChica == 1)
            {
                MessageBox.Show("Falta Iniciar Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //if (nIdEstCajaChica == 3)
            //{
            //    MessageBox.Show("Caja Chica Cerrada, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            return true;
        }

        private void BuscarComprobante(int idCpg)
        {
            LimpiarComponentes();

            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtDetComprPago = null;
            dtComprPago = null;
            dtBuscaCompCajaChica = null;
            dtMovilidad = null;
            dtMovilidad = new DataTable("dtMovilidad");

            dtComprPago = new DataTable("dtComprPago");
            dtDetComprPago = new DataTable("dtDetComprPago");

            //=======================================================================
            //--Buscar Datos del maestro y detalle 
            //=======================================================================
            dtComprPago = objCajaChica.BuscarComprPago(idCpg);
            dtDetComprPago = objCajaChica.BuscarDetComprPago(idCpg);
            dtDetComprPago.DefaultView.RowFilter = ("lVigente <> 0");

            foreach (DataColumn column in dtComprPago.Columns)
            {
                column.ReadOnly = false;
            }

            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(dtComprPago.Rows[0]["idCliente"].ToString()));

            conBusCliente.txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
            conBusCliente.txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
            conBusCliente.txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);
            conBusCliente.txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
            conBusCliente.txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
            conBusCliente.txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
            conBusCliente.txtCodCli.Enabled = false;

            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            txtCodigo.Text = dtComprPago.Rows[0]["idComprobantePago"].ToString();
            dtpFechaEmision.Text = dtComprPago.Rows[0]["dFechaEmision"].ToString();
            conBusCliente.txtCodCli.Text = dtComprPago.Rows[0]["idCliente"].ToString();
            cboMoneda.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idMoneda"].ToString());
            txtGlosa.Text = dtComprPago.Rows[0]["cGlosa"].ToString();
            cboConcepto.SelectedValue = Convert.ToInt32(dtDetComprPago.Rows[0]["idConceptoComprobante"].ToString());
            cboAgencias.SelectedValue = Convert.ToInt32(dtDetComprPago.Rows[0]["idAgencia"].ToString());

            txtSerie.Text = dtComprPago.Rows[0]["cSerie"].ToString();
            txtNumero.Text = dtComprPago.Rows[0]["cNumero"].ToString();


            if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 1)
            {
                txtMonto.Text = dtComprPago.Rows[0]["nTotal"].ToString();
            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
            {
                txtMontoCalculado.Text = dtComprPago.Rows[0]["nTotal"].ToString();
                txtMonto.Text = (Convert.ToDecimal(txtMontoCalculado.Text) / Convert.ToDecimal(txtTipoCambio.Text)).ToString();
            }

            txtCentroCosto.Text = dtDetComprPago.Rows[0]["cCentroCosto"].ToString();

            // valida el comprobante

            dtBuscaCompCajaChica = objCajaChica.CNCompCajChica(idCpg);

            if (dtBuscaCompCajaChica.Rows.Count <= 0)
            {
                LimpiarComponentes();
                MessageBox.Show("No Existe Comprobante...Validar", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            txtNroCajChica.Text = Convert.ToString(dtBuscaCompCajaChica.Rows[0]["nNroCajChi"]);
            txtNomCajChica.Text = Convert.ToString(dtBuscaCompCajaChica.Rows[0]["cNomCajChi"]);

            //fin de validacion

            btnEditar.Enabled = true;
            btnAnular.Enabled = true;
            btnImprimir.Enabled = true;
            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 2)
            {
                MessageBox.Show("EL COMPROBANTE ESTA PAGADO...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
            }

            if (Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idEstActCie"]) == 3)
            {
                MessageBox.Show("Caja Chica Cerrada, No puede MODIFICAR el comprobante...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnAnular.Enabled = false;
            }

            if (!ValidarCajaChica(Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idResCajChi"]), Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idAgencia"])))
            {
                return;
            }
            conBusCliente.btnBusCliente.Enabled = false;

            DataTable dtBuscaDestinoMov = objComp.CNListDestinoMov(idCpg);
            dtMovilidad = dtBuscaDestinoMov;

            if (dtBuscaDestinoMov.Rows.Count>0)
            {
                chcMovilidad.Checked = true;
                lblMovOrigen.Visible = chcMovilidad.Checked;
                lblMovDestino.Visible = chcMovilidad.Checked;
                txtMovOri.Visible = chcMovilidad.Checked;
                txtMovDest.Visible = chcMovilidad.Checked;
                txtMovOri.Enabled = false;
                txtMovDest.Enabled = false;

                txtMovOri.Text = Convert.ToString(dtBuscaDestinoMov.Rows[0]["cLugarOrigen"]);
                txtMovDest.Text = Convert.ToString(dtBuscaDestinoMov.Rows[0]["cLugarDestino"]);

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("No existe Codigo del Comprobante de Gastos", "Reporte de Comprobantes de Gastos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int idCpgGas = Convert.ToInt32(txtCodigo.Text);
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("idComprobantePago", idCpgGas.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtGastisCPG", new clsCNCajaChica().RptCpgGastos(idCpgGas)));

            string reportpath = "RptGastosSinCPG1.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCentroCosto_Click(object sender, EventArgs e)
        {
            frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto();
            frmBuscaCtrCosto.ShowDialog();
            IdCentroCosto = frmBuscaCtrCosto.pnidCentroCosto;
            txtCentroCosto.Text = frmBuscaCtrCosto.pcNombreCentroCosto;
        }

        private void chcMovilidad_CheckedChanged(object sender, EventArgs e)
        {
                lblMovOrigen.Visible = chcMovilidad.Checked;
                lblMovDestino.Visible = chcMovilidad.Checked;
                txtMovOri.Visible = chcMovilidad.Checked;
                txtMovDest.Visible = chcMovilidad.Checked;
                txtMovOri.Enabled = true;
                txtMovDest.Enabled = true;
                if (!chcMovilidad.Checked)
                {
                txtMovOri.Text = "";
                txtMovDest.Text = "";
                }
        }

        private void lblBase5_Click(object sender, EventArgs e)
        {

        }

        private void txtCentroCosto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblTipoCambio.Visible = true;
                    txtTipoCambio.Visible = true;
                    txtTipoCambio.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamProVen"]);
                }
                else
                {
                    lblTipoCambio.Visible = false;
                    txtTipoCambio.Visible = false;
                    lblMontoCalculado.Visible = false;
                    txtMontoCalculado.Visible = false;
                    txtTipoCambio.Text = "0.00";
                }
            }
        }

        private void dtpFechaEmision_Leave(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblTipoCambio.Visible = true;
                    txtTipoCambio.Visible = true;
                    txtTipoCambio.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamProVen"]);
                }
                else
                {
                    lblTipoCambio.Visible = false;
                    txtTipoCambio.Visible = false;
                    lblMontoCalculado.Visible = false;
                    txtMontoCalculado.Visible = false;
                    txtTipoCambio.Text = "0.00";
                }
            }
        }
    }
}
