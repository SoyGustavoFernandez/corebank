using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRegistroComprobantes : frmBase
    {
        private int nidCajChica = 0, nidComprobantePago = 0;
        private bool lFlagValidar = true;
        clsCNCajaChica objCajaChica = new clsCNCajaChica();
        clsCNComprobantes objCmp = new clsCNComprobantes();
        DataTable dtBienServDetra, dtComprPago, dtDetComprPago, dtDescComprPago, dtDatosCajChica;
        DataTable dtDatosCajChica1, dtBuscaCompCajaChica;
        DataTable dtConfigTipCompr;
        bool lBloquearCalcular = false, lIsCierre = false;
        Transaccion eoperacion = Transaccion.Selecciona;
        int idDestino = 0, pEstadoCpg = 0;

        public frmRegistroComprobantes()
        {
            InitializeComponent();
            cboAgencias1.SelectedValue = 0;           
        }

        private void frmRegistroComprobantes_Load(object sender, EventArgs e)
        {

            if (ValidarRespCajChica())
            {
                MessageBox.Show("Usted no es responsable de Caja Chica", "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }

            CargarTipoOperacion();
            CargarTipoPago();
            CargarCboDestinos();
            CargarCboCajaChica(0);           

            if (Convert.ToInt32(cboAgencias1.SelectedValue)<=0)
            {
                cboCajaChica.SelectedIndex = -1;
            }
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem.Date;
           
            LimpiarComponentes();  
            dtComprPago = new DataTable();
            dtDetComprPago = new DataTable();
            dtDescComprPago = new DataTable();
            CrearDataTables();
            
            dtgDetalleComprobante.DataSource = dtDetComprPago;
            FormatoGridDetalle();
                      
            HabilitarComponentes(3);
            //--Solo debe aceptar CPG en Soles
            cboMoneda.SelectedValue = 1;
            cboMoneda.Enabled = false;
            txtCodigo.Enabled = true;

            cboAgencias1.Enabled = true;
            cboCajaChica.Enabled = true;
            cboAgencias1.SelectedValue = 0;
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            txtCodigo.Focus();
            txtCodigo.SelectAll();
            //Control de objetos
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
            frmBusqCompPago.chcTieneComprobante.Checked = true;
            frmBusqCompPago.chcCajChic.Checked = true;
            frmBusqCompPago.ShowDialog();
            nidComprobantePago = frmBusqCompPago.pidComprobantePago;
            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DesvincularComponentes();
            LimpiarComponentes();

            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtComprPago = null;
            dtDetComprPago = null;
            dtDescComprPago = null;
            dtComprPago = new DataTable("dtComprPago");
            dtDetComprPago = new DataTable("dtDetComprPago");
            dtDescComprPago = new DataTable("dtDescComprPago");

            //=======================================================================
            //--Buscar Datos del maestro y detalle 
            //=======================================================================
            dtComprPago = objCajaChica.BuscarComprPago(nidComprobantePago);
            dtDetComprPago = objCajaChica.BuscarDetComprPago(nidComprobantePago);
            dtDetComprPago.DefaultView.RowFilter = ("lVigente <> 0");           

            foreach (DataColumn column in dtComprPago.Columns)
            {
                column.ReadOnly = false;
            }

            VincularComponentes();

            dtDescComprPago = objCajaChica.BuscarDescComprPago(nidComprobantePago);

            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            conBusCliente.txtCodCli.Text = dtComprPago.Rows[0]["idCliente"].ToString();
            conBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.txtCodCli.Focus();
            SendKeys.Send("{ENTER}");
            

            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetComprPago;
            FormatoGridDetalle();

            //=======================================================================
            //--Llenar datagridview descuentos de comprobante y darle formato
            //=======================================================================
            dtgOtrosDesctosCpg.DataSource = dtDescComprPago;
            FormatoGridOtrosDescuentos();

            if (dtComprPago.Rows[0]["dFechaPago"] != DBNull.Value)
            {
                dtpFechaPago.Format = DateTimePickerFormat.Short;
                dtpFechaPago.Text = dtComprPago.Rows[0]["dFechaPago"].ToString();
            }

            if (dtComprPago.Rows[0]["idTipoPago"] != DBNull.Value)
            {
                cboTipoPago.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoPago"]);
            }

            if (string.IsNullOrEmpty(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString()))
            {
                rbtnSinDetraccion.Checked = true;
                cboTipoOperacion.SelectedIndex = -1;
                cboBienServicio.SelectedIndex = -1;
                txtPorcDetraccion.Text = "";
            }
            else
            {
                rbtnConDetraccion.Checked = true;
                cboTipoOperacion.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString());
            }

            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 1)
            {
                btnEditar.Enabled = true;
                btnAnular.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnAnular.Enabled = false;
            }

            if (dtComprPago.Rows[0]["dFechaProvision"] != DBNull.Value)
            {
                dtpFechaProvision.Format = DateTimePickerFormat.Short;
                dtpFechaProvision.Text = dtComprPago.Rows[0]["dFechaProvision"].ToString();
            }

            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            cboTipoOperacion.Enabled = false;
            cboBienServicio.Enabled = false;
            dtpFechaProvision.Enabled = false;
            rbtnConDetraccion.Enabled = false;
            rbtnSinDetraccion.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = false;
            cboDestino.Enabled = false;
            dtgDetalleComprobante.Columns["btnDetConcepto"].Visible = false;
            dtgDetalleComprobante.Columns["btnDetCentroCosto"].Visible = false;           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //DetalleCajaChica(Convert.ToInt32(cboCajaChica.SelectedValue));

            //if (dtDatosCajChica1.Rows.Count <= 0)
            //{
            //    MessageBox.Show("Falta Realizar Habilitación de Fondo Fijo para esa Agencia, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    Dispose();
            //    return;
            //}

            //if (!ValidarCajaChica())
            //{
            //    this.Dispose();
            //    return;
            //}
            if (cboAgencias1.SelectedIndex==-1)
            {
                MessageBox.Show("Primero Debe Seleccionar la Agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias1.Focus();
                return;
            }
            if (cboCajaChica.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar la Caja Chica, por Favor", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCajaChica.Focus();
                return;
            }
            if (!ValidarCajaChica(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia))
            {
                return;
            }

            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            lBloquearCalcular = false;
            dtComprPago = null;
            dtDetComprPago = null;
            dtDescComprPago = null;
            dtComprPago = new DataTable("dtComprPago");
            dtDetComprPago = new DataTable("dtDetComprPago");
            dtDescComprPago = new DataTable("dtDescComprPago");
            dtgDetalleComprobante.Columns.Clear();                   

            DesvincularComponentes();
            LimpiarComponentes();
            CrearDataTables();   

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Maestro 
            //=======================================================================
            DataRow dr = dtComprPago.NewRow();
            dr["idComprobantePago"] = 0;
            dr["idCliente"] = 0;
            dr["idAgencia"] = clsVarGlobal.nIdAgencia;
            dr["nMontoITF"] = 0.00;
            dr["dFechaOpe"] = clsVarApl.dicVarGen["dFechaAct"];
            dr["dFechaEmision"] = clsVarApl.dicVarGen["dFechaAct"];
            dr["dFechaPago"] = clsVarApl.dicVarGen["dFechaAct"];
            dr["lTieneComprobante"] = 1;
            dr["idBienServicioDetr"] = DBNull.Value;
            dr["nSubTotal"] = 0.00;
            dr["nTotalIGV"] = 0.00;
            dr["nTotal"] = 0.00;
            dr["nTotalDetraccion"] = 0.00;
            dr["lAfeCuartaCateg"] = false;
            dr["nPorcCuartaCateg"] = 0.00;
            dr["nTotCuartaCateg"] = 0.00;
            dr["nTotOtros"] = 0.00;	
            dr["idUsuarioRegistro"] = clsVarGlobal.User.idUsuario;
            dr["dFechaProvision"] = clsVarApl.dicVarGen["dFechaAct"];
            dr["lEstadoProvision"] = false;
            dr["lCpgCajChica"] = 1;
            dr["idEstadoComprobante"] = 1;
            dr["idTipoPago"] = 1;
            dr["nMonto"] = 0.00;
            dr["nTotDescuento"] = 0.00;
            dr["nNetoPagar"] = 0.00;
            dtComprPago.Rows.Add(dr);

            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetComprPago;
            FormatoGridDetalle();

            //=======================================================================
            //--Llenar datagridview descuentos de comprobante y darle formato
            //=======================================================================
            CargarOtrosDescuentos();
                        
            VincularComponentes();

            nidCajChica = 0; // Convert.ToInt32(dtDatosCajChica1.Rows[0]["idCajChica"]);
            txtTotPag.Text = "0.00";
            txtDescuentos.Text = "0.00";
            txtNetoPagar.Text = "0.00";

            HabilitarComponentes(2);
            //chcProvisionar.Checked = false;

            txtCodigo.Enabled = false;
            btnAnular.Enabled = false;
            cboMoneda.SelectedValue = 1;
            cboMoneda.Enabled = false;
            chcCuartaCateg.Visible = false;
            cboTipoComprobantePago.Focus();
            cboAgencias1.Enabled = false;
            cboCajaChica.Enabled = false;

            chcProvisionar.Checked = true;
            chcCuartaCateg.Enabled = true;
            chcProvisionar.Enabled = false;

            eoperacion = Transaccion.Nuevo;
            lIsCierre = false;
            pEstadoCpg = 0;
           
        }
       
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (ValidarExistenDetalle("") == 0) return;
            if (dtgDetalleComprobante.Rows.Count > 0)
            {
                foreach (DataRow nrow in dtDetComprPago.Rows)
                {
                    if (nrow["nMontoImporte"].ToString().Equals(""))
                    {
                        return;
                    }
                }
            }

            if (cboTipoComprobantePago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de comprobante", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!rbtnConDetraccion.Checked && !rbtnSinDetraccion.Checked)
            {
                MessageBox.Show("Indique si el recibo es con detraccion o sin detraccion", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rbtnConDetraccion.Checked)
            {
                if (string.IsNullOrEmpty(txtPorcDetraccion.Text.Trim()))
                {
                    MessageBox.Show("Seleccione un el tipo de operacion y el bien y servicio para el calculo de detraccion.", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (cboDestino.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de destino del comprobante", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //=======================================================================
            //--Asignar Datos Por Defecto para la insercion en el Detalle
            //=======================================================================   
            int idCpg = 0;
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                idCpg = 0;
            }
            if (Convert.ToInt32(txtCodigo.Text) > 0)
            {
                idCpg = Convert.ToInt32(txtCodigo.Text);
            }

            DataRow dr = dtDetComprPago.NewRow();
            dr["idDetalleComprobante"]=-1;
            dr["idComprobantePago"] = idCpg;
            dr["nSubtotalImporte"]=0.00;
            dr["nIgvImporte"]=0.00;
            dr["nMontoDetraccion"]=0.00;
            dr["nCuartaCategImporte"] = 0.00;
            dr["nMontoImporte"] = 0.00;
            dr["nOtrosImporte"] = 0.00;
            dr["nMontoPagar"] = 0.00;
            dr["lVigente"] = 1;
            dr["idAgencia"] = clsVarGlobal.nIdAgencia;
            dr["cConceptoComprPago"] = "";
            dr["idConceptoComprobante"] = 0;
            dr["lVigente"] = 1;
            dr["idCentroCosto"] = 0;
            dr["cCentroCosto"] = "";
            dtDetComprPago.Rows.Add(dr);
        }

        private void btnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleComprobante.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {             
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleComprobante.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetalleComprobante.Rows[nFilaActual].Cells["idDetalleComprobante"].Value) == -1)
                {
                    dtgDetalleComprobante.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetalleComprobante.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetalleComprobante.Focus();
                ProcessTabKey(true);
                CalcularTotal(true);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cboCajaChica.SelectedIndex ==-1)
            {
                MessageBox.Show("Debe Seleccionar Primero una Caja Chica...Verificar", "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCajaChica.Focus();
                return;
            }

            nidCajChica = Convert.ToInt32(cboCajaChica.SelectedValue);
            ValidarDatos();
            if (!lFlagValidar) return;        

            //=======================================================================
            //--Validar Montos para registro en caja chica
            //=======================================================================
            ValidarMontosCajChica();
            if (!lFlagValidar) return;

            //=======================================================================
            //--Crear los DataSet y agregar los Datatables para los xml
            //=======================================================================
            DataSet dsComprPago = new DataSet("dsComprPago");
            DataSet dsDetComprPago = new DataSet("dsDetComprPago");
            DataSet dsDescComprPago = new DataSet("dsDescComprPago");

            dtDescComprPago = CrearTablaOtrosDescuentos(dtDescComprPago.Copy());
            dtComprPago.TableName = "dtComprPago";
            dtDetComprPago.TableName = "dtDetComprPago";
            dtDescComprPago.TableName = "dtDescComprPago";

            dsComprPago.Tables.Add(dtComprPago);
            dsDetComprPago.Tables.Add(dtDetComprPago);
            dsDescComprPago.Tables.Add(dtDescComprPago);
            
            string xmlComprPago = clsCNFormatoXML.EncodingXML(dsComprPago.GetXml());
            string xmlDetComprPago = clsCNFormatoXML.EncodingXML(dsDetComprPago.GetXml());
            string xmlDescComprPago = clsCNFormatoXML.EncodingXML(dsDescComprPago.GetXml());

            dsComprPago.Tables.Clear();
            dsDetComprPago.Tables.Clear();
            dsDescComprPago.Tables.Clear();

			//=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(conBusCliente.idCli, nidCajChica, "Inicio - Registro de Comprobantes", btnGrabar);
            //==============================================================================

            DataTable result = objCajaChica.GuardarComprPgCajChica(xmlComprPago, xmlDetComprPago,xmlDescComprPago,nidCajChica);			
            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString() + "NRO DE REGISTRO: " + result.Rows[0]["nNroRegistro"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = result.Rows[0]["nNroRegistro"].ToString();
                HabilitarComponentes(1);
                btnEditar.Enabled = true;
                txtCodigo.Enabled = false;
                btnAnular.Enabled = false;
                //=================   Registro Fin Rastreo    ================================
                this.registrarRastreo(conBusCliente.idCli, nidCajChica, "Fin - Registro de Comprobantes", btnGrabar);
                //============================================================================

                //DataTable dtAtoCnt = objCmp.CNGeneraAsientoCmp(clsVarGlobal.dFecSystem, Convert.ToInt32(txtCodigo.Text));
                //if (Convert.ToInt32(dtAtoCnt.Rows[0]["nResultado"])==1)
                //{
                //    btnImprimir1.Enabled = true;
                //}
                //else
                //{
                //    MessageBox.Show(dtAtoCnt.Rows[0]["cMensaje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            lBloquearCalcular = false;
            btnEditar.Enabled = false;
            lIsCierre = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {           
            DesvincularComponentes();
            LimpiarComponentes();
            HabilitarComponentes(3);
            txtCodigo.Enabled = true;
            cboMoneda.SelectedValue = 1;
            cboMoneda.Enabled = false;
            lBloquearCalcular = false;
            cboAgencias1.Enabled = true;
            cboCajaChica.Enabled = true;

            chcCuartaCateg.Visible = false;
            chcImpRenta.Visible = false;
            lblFecVenc.Visible = false;
            dtpFecVenc.Visible = false;
            btnImprimir1.Enabled = false;
            cboAgencias1.Enabled = false;
            cboCajaChica.Enabled = false;

            lIsCierre = false;
            pEstadoCpg = 0;
            txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarComponentes(2);
            txtCodigo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnAnular.Enabled = false;
            dtgDetalleComprobante.Enabled = true;
            btnAgregarDetalle.Enabled = false;
            btnQuitarDetalle.Enabled = false;
            cboTipoComprobantePago.Enabled = false;
            rbtnConDetraccion.Enabled = false;
            rbtnSinDetraccion.Enabled = false;
            dtpFechaEmision.Enabled = false;
            cboMoneda.Enabled = false;
            cboTipoOperacion.Enabled = false;
            cboBienServicio.Enabled = false;
            txtCIIU.Enabled = false;
            txtPorcDetraccion.Enabled = false;
            if (dtComprPago.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtComprPago.Rows[0]["idDestino"]).In(1, 2))
                {
                    cboDestino.Enabled = true;
                }
                else
                {
                    cboDestino.Enabled = false;
                }
            }
            dtpFechaEmision.Enabled = true;
            txtCodigo.Enabled = false;
            btnImprimir1.Enabled = false;

            
            cboAgencias1.Enabled = true;
            cboCajaChica.Enabled = true;           


            btnNuevo.Enabled = false;
            dtgOtrosDesctosCpg.Enabled = false;
            eoperacion = Transaccion.Edita;

            switch (pEstadoCpg)
            {
                case 1: //--Registrado
                    dtgDetalleComprobante.Enabled = true;
                    dtgDetalleComprobante.ReadOnly = false;
                    dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = false;
                    dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = false;

                    btnAgregarDetalle.Enabled = true;
                    btnQuitarDetalle.Enabled = true;
                    rbtnConDetraccion.Enabled = true;
                    rbtnSinDetraccion.Enabled = true;
                    dtpFechaEmision.Enabled = true;
                    grbDetraccion.Enabled = true;
                    rbtnSinDetraccion.Enabled = true;
                    rbtnConDetraccion.Enabled = true;
                    cboTipoOperacion.Enabled = true;
                    cboBienServicio.Enabled = true;
                    lBloquearCalcular = false;
                    cboTipoComprobantePago.Enabled = true;
                    cboAgencias1.Enabled = false;
                    cboCajaChica.Enabled = true;
                    cboTipoComprobantePago.Focus();
                    break;
                case 2:  //--Pagado
                    dtgDetalleComprobante.Enabled = true;
                    dtgDetalleComprobante.Columns["cConceptoComprPago"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["cCentroCosto"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = true;
                    dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = true;

                    cboTipoComprobantePago.Enabled = false;
                    rbtnConDetraccion.Enabled = false;
                    rbtnSinDetraccion.Enabled = false;
                    dtpFechaEmision.Enabled = false;
                    cboMoneda.Enabled = false;
                    cboTipoOperacion.Enabled = false;
                    cboBienServicio.Enabled = false;
                    txtCIIU.Enabled = false;
                    txtPorcDetraccion.Enabled = false;
                    txtCodigo.Enabled = false;
                    cboDestino.Enabled = false;
                    dtgOtrosDesctosCpg.Enabled = false;
                    dtpFechaEmision.Enabled = true;
                    btnAnular.Enabled = false;
                    conBusCliente.btnBusCliente.Enabled = false;
                    conBusCliente.txtCodCli.Enabled = false;
                    txtSerie.Enabled = true;
                    txtNumero.Enabled = true;
                    txtSerie.Focus();
                    lBloquearCalcular = true;
                    cboAgencias1.Enabled = false;
                    cboCajaChica.Enabled = false;
                    dtpFechaEmision.Focus();
                    break;
                default:
                    break;
            }
            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Primero debe Buscar el Comprobante a Eliminar", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;   
            }
            
            int idCpg = Convert.ToInt32(txtCodigo.Text);     

            if (idCpg<=0)
            {
                MessageBox.Show("El Número de Comprobante no es Válido", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmMotAnulacion frmMotivoAnula = new frmMotAnulacion();            
            frmMotivoAnula.ShowDialog();
            string cMotivoEli = frmMotivoAnula.cMotivoEli;

            if (string.IsNullOrEmpty(cMotivoEli))
            {
                MessageBox.Show("No existe motivo de Anulación", "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Esta seguro(a) de anular este comprobante de pago?", "Registro de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DataTable result = objCajaChica.CNElimRegCompCajChica(idCpg, cMotivoEli, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (result.Rows[0]["nResp"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarComponentes(1);
                btnEditar.Enabled = false;
                txtCodigo.Enabled = false;
                btnAnular.Enabled = false;
                btnCancelar.Enabled = true;
                objCmp.CNAnulaAsientoCmp(dtpFechaEmision.Value.Date, idCpg, 3);
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Eliminar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chcProvisionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chcProvisionar.Checked)
            {
                dtpFechaProvision.Format = DateTimePickerFormat.Short;
                dtpFechaProvision.Enabled = true;
                dtpFechaProvision.Value = clsVarGlobal.dFecSystem;

                //if (dtComprPago.Rows.Count>0)
                //{
                //    if (dtComprPago.Rows[0]["dFechaProvision"] == DBNull.Value)
                //    {
                //        //dtpFechaProvision.Format = DateTimePickerFormat.Short;
                //        //dtpFechaProvision.Enabled = true;
                //        //DateTime dFechaActual = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
                //        //DateTime dUltDiaMes = Convert.ToDateTime("01/" + (dFechaActual.Month + 1) + "/" + dFechaActual.Year).AddDays(-1);
                //        //dtpFechaProvision.Value = dUltDiaMes.Date;
                //        dtpFechaProvision.Value = clsVarGlobal.dFecSystem;
                //    }   
                //}
               
            }
            else
            {
                dtpFechaProvision.Format = DateTimePickerFormat.Custom;
                dtpFechaProvision.CustomFormat = " ";
                dtpFechaProvision.Enabled = false;
                dtpFechaProvision.Value = clsVarGlobal.dFecSystem;
                //dtComprPago.Rows[0]["dFechaProvision"] = DBNull.Value;
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblCambio.Visible = true;
                    txtCambio.Visible = true;                    
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
            }
        }

        private void cboTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOperacion.SelectedValue != null)
            {
                CargarBienServicio(Convert.ToInt32(cboTipoOperacion.SelectedValue.ToString()));
            }
        }

        private void cboBienServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBienServicio.Items.Count > 0 && cboBienServicio.DataSource != null)
            {
                int index = cboBienServicio.SelectedIndex;
                txtPorcDetraccion.Text = dtBienServDetra.Rows[index]["nPorcentaje"].ToString();
            }
        }

        private void rbtnConDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConDetraccion.Checked)
            {
                if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text) || string.IsNullOrEmpty(conBusCliente.txtNombre.Text))
                {
                    MessageBox.Show("Seleccione un proveedor.", "Registro de Comprobantes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbtnConDetraccion.Checked = false;
                    return;
                }
                cboTipoOperacion.Enabled = true;
                cboBienServicio.Enabled = true;
                txtCIIU.Enabled = true;
                txtPorcDetraccion.Enabled = true;

                DataTable dtCIIU = objCajaChica.BusCIIUCliente(Convert.ToInt32(conBusCliente.txtCodCli.Text));
                if (dtCIIU.Rows.Count <= 0) return;
                int nCIIU = Convert.ToInt32(dtCIIU.Rows[0]["nIdActivEco"]);
                txtCIIU.Text = nCIIU.ToString();
            }
        }

        private void rbtnSinDetraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSinDetraccion.Checked)
            {
                cboTipoOperacion.Enabled = false;
                cboBienServicio.Enabled = false;
                txtCIIU.Enabled = false;
                txtPorcDetraccion.Enabled = false;
                cboTipoOperacion.SelectedIndex = -1;
                cboBienServicio.DataSource=null;
                txtPorcDetraccion.Text = "";
                dtComprPago.Rows[0]["idBienServicioDetr"] = DBNull.Value;
                txtCIIU.Text = "";
            }
        }

        private void txtSerie_Leave(object sender, EventArgs e)
        {            
            txtSerie.Text = txtSerie.Text.PadLeft(4, '0');
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            //txtNumero.Text = txtNumero.Text.PadLeft(11, '0');
        }

        private void dtgDetalleComprobante_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 0)
            {
                frmBuscarConceptoComprPago frmBscConcepto = new frmBuscarConceptoComprPago();
                frmBscConcepto.ShowDialog();
                if (frmBscConcepto.pidSubConcepto == 0) return;
                dtgDetalleComprobante.CurrentRow.Cells["idConceptoComprobante"].Value = frmBscConcepto.pidSubConcepto;
                dtgDetalleComprobante.CurrentRow.Cells["cConceptoComprPago"].Value = frmBscConcepto.pcSubConcpeto;                              
            }
            if (dtgDetalleComprobante.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgDetalleComprobante.Columns[e.ColumnIndex].DisplayIndex) == 2)
            {
                frmBuscaCentroCosto frmBuscaCtrCosto = new frmBuscaCentroCosto();
                frmBuscaCtrCosto.ShowDialog();
                if (frmBuscaCtrCosto.pnidCentroCosto == 0) return;
                dtgDetalleComprobante.CurrentRow.Cells["IdCentroCosto"].Value = frmBuscaCtrCosto.pnidCentroCosto;
                dtgDetalleComprobante.CurrentRow.Cells["cCentroCosto"].Value = frmBuscaCtrCosto.pcNombreCentroCosto;
            }
        }

        private void dtgDetalleComprobante_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nSubtotalImporte" ||
                dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nOtrosImporte"  )
            {
                CalcularTotal(true);
            }
            if (dtgDetalleComprobante.Columns[e.ColumnIndex].Name == "nIgvImporte" ) //Para Editar IGV
            {
                CalcularTotal(false);
            }
        }       

        private void dtgOtrosDesctosCpg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "nMonto")
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["lVigente"];

                bool isChecked = (bool)checkbox.EditedFormattedValue;
                if (!isChecked)
                {
                    dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].ReadOnly = true;
                    MessageBox.Show("Seleccione el check de este descuento.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "lVigente")
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["lVigente"];

                bool isChecked = (bool)checkbox.EditedFormattedValue;
                if (!isChecked)
                {
                    dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].ReadOnly = false;
                    dtgOtrosDesctosCpg.Rows[e.RowIndex].Cells["nMonto"].Value = 0.00;
                }
            }
        }        

        private void cboTipoComprobantePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoComprobantePago.SelectedIndex == -1) return;
            int idTipoCompr = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
            dtConfigTipCompr = objCajaChica.RetConfigTipoComp(idTipoCompr);
            if (dtConfigTipCompr.Rows.Count > 0)
            {
                dtgOtrosDesctosCpg.DataSource = null;
                CargarOtrosDescuentos();
                txtIgvCalculo.Text = dtConfigTipCompr.Rows[0]["nValIgv"].ToString();
                if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lPermiteDocRef"]))
                {
                    lblCodRef.Visible = true;
                    txtCodRef.Visible = true;
                    btnBusqCodRef.Visible = true;
                    btnBusqCodRef.Enabled = true;
                }
                else
                {
                    lblCodRef.Visible = false;
                    txtCodRef.Visible = false;
                    btnBusqCodRef.Visible = false;
                    btnBusqCodRef.Enabled = false;
                }    

				if (Convert.ToBoolean(dtConfigTipCompr.Rows[0]["lisGravado"]))
                {
                    cboDestino.SelectedValue = 2;
                    cboDestino.Enabled = true;
                }
                else
                {
                    cboDestino.SelectedValue = 3;
                    //cboDestino.Enabled = false;
                }
				
				if (Convert.ToInt32(dtConfigTipCompr.Rows[0]["nnumero"]) == 14)
                {
                    lblFecVenc.Visible = true;
                    dtpFecVenc.Visible = true;
                    if (eoperacion == Transaccion.Nuevo)
                    {
                        dtComprPago.Rows[0]["dFechaVencimiento"] = clsVarGlobal.dFecSystem;
                    }
                }
                else
                {
                    lblFecVenc.Visible = false;
                    dtpFecVenc.Visible = false;
                    dtComprPago.Rows[0]["dFechaVencimiento"] = DBNull.Value;
                }
            }

            if (Convert.ToInt32(cboTipoComprobantePago.SelectedValue) == 2)//factura
            {
                rbtnSinDetraccion.Checked = false;
                rbtnConDetraccion.Checked = false;
                rbtnSinDetraccion.Enabled = true;
                rbtnConDetraccion.Enabled = true;
            }
            else
            {
                //detracciones
                rbtnSinDetraccion.Checked = true;
                rbtnConDetraccion.Checked = false;
                rbtnConDetraccion.Enabled = false;
                rbtnSinDetraccion_CheckedChanged(sender, e);
            }            
            FormatoGridDetalle();
            CalcularTotal(true);
            cboDestino.Enabled = true;
        }

        private void txtPorcDetraccion_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal(true);
        }

        private void txtIgvCalculo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIgvCalculo.Text)) return;
            CalcularTotal(true);
        }

        private void cboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDestino.SelectedIndex == -1) return;
            if (dtComprPago != null)
            {
                if (dtComprPago.Rows.Count > 0)
                {
                    if (eoperacion == Transaccion.Edita)
                    {
                        var idDestinoNew = Convert.ToInt32(cboDestino.SelectedValue);
                        if (idDestinoNew == 3 && idDestino.In(1, 2))
                        {
                            MessageBox.Show("Destino ya tenía afectación de IGV, por favor validar los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //cboDestino.SelectedValue = idDestino;
                        }
                    }
                }
            }
            CalcularTotal(true);
        }

        private void dtgOtrosDesctosCpg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgOtrosDesctosCpg.Columns[e.ColumnIndex].Name == "nMonto")
            {
                CalcularTotal(true);
            }
        }

        public DataTable CrearTablaOtrosDescuentos(DataTable dtDescuentos)
        {
            DataView dv = dtDescuentos.DefaultView;
            dv.RowFilter = ("lVigente = true or idComprobantePago <> -1");
            dtDescuentos = dv.ToTable();
            return dtDescuentos;
        }

        private void CrearDataTables()
        {
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
            dtComprPago.Columns.Add("lAfeCuartaCateg", typeof(bool));
            dtComprPago.Columns.Add("nPorcCuartaCateg", typeof(decimal));
            dtComprPago.Columns.Add("nTotCuartaCateg", typeof(decimal));
            dtComprPago.Columns.Add("nTotOtros", typeof(decimal));
            dtComprPago.Columns.Add("nTipCambio", typeof(decimal));

            dtComprPago.Columns.Add("nMonto", typeof(decimal));
            dtComprPago.Columns.Add("nTotDescuento", typeof(decimal));
            dtComprPago.Columns.Add("nNetoPagar", typeof(decimal));
            dtComprPago.Columns.Add("dFechaVencimiento", typeof(DateTime));
            dtComprPago.Columns.Add("lAfecLeyImpRenta", typeof(bool));

            dtDetComprPago.Columns.Add("idDetalleComprobante", typeof(Int32));
            dtDetComprPago.Columns.Add("idComprobantePago", typeof(Int32));
            dtDetComprPago.Columns.Add("idConceptoComprobante", typeof(Int32));
            dtDetComprPago.Columns.Add("cConceptoComprPago", typeof(string));
            dtDetComprPago.Columns.Add("IdCentroCosto", typeof(Int32)); // centro de costos
            dtDetComprPago.Columns.Add("cCentroCosto", typeof(string));
            dtDetComprPago.Columns.Add("idAgencia", typeof(Int32));

            dtDetComprPago.Columns.Add("nSubtotalImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nIgvImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nMontoDetraccion", typeof(decimal));
            dtDetComprPago.Columns.Add("nMontoImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("lVigente", typeof(bool));
            dtDetComprPago.Columns.Add("nOtrosImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nCuartaCategImporte", typeof(decimal));
            dtDetComprPago.Columns.Add("nMontoPagar", typeof(decimal));               

            dtDescComprPago.Columns.Add("idDescuentosComprPago", typeof(Int32));
            dtDescComprPago.Columns.Add("idComprobantePago", typeof(Int32));
            dtDescComprPago.Columns.Add("idTipoDescComPago", typeof(Int32));
            dtDescComprPago.Columns.Add("nMonto", typeof(decimal));
            dtDescComprPago.Columns.Add("lVigente", typeof(bool));

            DataGridViewButtonColumn btnDetConcepto = new DataGridViewButtonColumn();
            btnDetConcepto.HeaderText = "";
            btnDetConcepto.Name = "btnDetConcepto";
            btnDetConcepto.FillWeight = 20;
            btnDetConcepto.UseColumnTextForButtonValue = true;
            btnDetConcepto.Text = "...";
            this.dtgDetalleComprobante.Columns.Add(btnDetConcepto);

            DataGridViewButtonColumn btnDetCentroCosto = new DataGridViewButtonColumn();
            btnDetCentroCosto.HeaderText = "";
            btnDetCentroCosto.Name = "btnDetCentroCosto";
            btnDetCentroCosto.FillWeight = 20;            
            btnDetCentroCosto.UseColumnTextForButtonValue = true;
            btnDetCentroCosto.Text = "...";
            this.dtgDetalleComprobante.Columns.Add(btnDetCentroCosto);

            //=======================================================================
            //--Agregar Colummna de tipo combobox
            //=======================================================================
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dtAgencia = ListadoAgencia.ListarAgencias();
            DataGridViewComboBoxColumn cboAgencia = new DataGridViewComboBoxColumn();
            cboAgencia.Name = "cboAgencia";
            cboAgencia.DataPropertyName = "idAgencia";
            cboAgencia.DataSource = dtAgencia;
            cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            cboAgencia.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
            this.dtgDetalleComprobante.Columns.Add(cboAgencia);            
        }

        private void FormatoGridDetalle()
        {
            if (dtgDetalleComprobante.DataSource == null) return;
            this.dtgDetalleComprobante.CellValueChanged -= new DataGridViewCellEventHandler(dtgDetalleComprobante_CellValueChanged);
            dtgDetalleComprobante.ReadOnly = false;

            dtgDetalleComprobante.Columns["idDetalleComprobante"].Visible = false;
            dtgDetalleComprobante.Columns["idComprobantePago"].Visible = false;
            dtgDetalleComprobante.Columns["idConceptoComprobante"].Visible = false;
            dtgDetalleComprobante.Columns["cConceptoComprPago"].Visible = true;
            dtgDetalleComprobante.Columns["IdCentroCosto"].Visible = false;     // centro de costos
            dtgDetalleComprobante.Columns["cCentroCosto"].Visible = true;
            dtgDetalleComprobante.Columns["nSubtotalImporte"].Visible = true;
            dtgDetalleComprobante.Columns["nIgvImporte"].Visible = true;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].Visible = true;
            dtgDetalleComprobante.Columns["nMontoImporte"].Visible = true;
            dtgDetalleComprobante.Columns["lVigente"].Visible = false;
            if (dtConfigTipCompr != null)
            {
                if (Convert.ToDecimal(dtConfigTipCompr.Rows[0]["nValCuartaCateg"]) > 0)
                {
                    chcCuartaCateg.Visible = true;
					chcImpRenta.Visible = true;
                    txtTot4taCateg.Visible = true;
                    dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = true;
                    dtgDetalleComprobante.Columns["nCuartaCategImporte"].FillWeight = 52;
                }
                else
                {
                    chcCuartaCateg.Visible = false;
                    chcCuartaCateg.Checked = false;
                    txtTot4taCateg.Visible = false;
                    chcImpRenta.Visible = false;
                    chcImpRenta.Checked = false;
                    dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = false;
                }
            }
            else
            {
                chcCuartaCateg.Visible = false;
                chcCuartaCateg.Checked = false;
				chcImpRenta.Visible = false;
                chcImpRenta.Checked = false;
                txtTot4taCateg.Visible = false;                
                dtgDetalleComprobante.Columns["nCuartaCategImporte"].Visible = false;
            }
            dtgDetalleComprobante.Columns["nOtrosImporte"].Visible = true;
            dtgDetalleComprobante.Columns["nMontoPagar"].Visible = true;
            dtgDetalleComprobante.Columns["cboAgencia"].Visible = true;

            dtgDetalleComprobante.Columns["cConceptoComprPago"].HeaderText = "Concepto";
            dtgDetalleComprobante.Columns["cCentroCosto"].HeaderText = "Centro Costo";
            dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderText = "Subtotal";
            dtgDetalleComprobante.Columns["nIgvImporte"].HeaderText = "IGV";
            dtgDetalleComprobante.Columns["nMontoDetraccion"].HeaderText = "Detraccion";
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].HeaderText = "4ta Cat.";
            dtgDetalleComprobante.Columns["nMontoImporte"].HeaderText = "Total";
            dtgDetalleComprobante.Columns["nOtrosImporte"].HeaderText = "Otros";
            dtgDetalleComprobante.Columns["nMontoPagar"].HeaderText = "Mont.Pagar";
            dtgDetalleComprobante.Columns["cboAgencia"].HeaderText = "Agencia";

            dtgDetalleComprobante.Columns["nSubtotalImporte"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nIgvImporte"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nMontoDetraccion"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nMontoImporte"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nOtrosImporte"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleComprobante.Columns["nMontoPagar"].DefaultCellStyle.Format = "##,##0.00";

            dtgDetalleComprobante.Columns["nSubtotalImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nIgvImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nMontoImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nOtrosImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetalleComprobante.Columns["nMontoPagar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetalleComprobante.Columns["cConceptoComprPago"].ReadOnly = true;
            dtgDetalleComprobante.Columns["cCentroCosto"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nSubtotalImporte"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nIgvImporte"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nMontoImporte"].ReadOnly = true;
            dtgDetalleComprobante.Columns["nOtrosImporte"].ReadOnly = false;
            dtDetComprPago.Columns["nMontoPagar"].ReadOnly = false;
            dtgDetalleComprobante.Columns["nMontoPagar"].ReadOnly = true;
            dtgDetalleComprobante.Columns["cboAgencia"].ReadOnly = false;

            dtgDetalleComprobante.Columns["cConceptoComprPago"].FillWeight = 80;
            dtgDetalleComprobante.Columns["cCentroCosto"].FillWeight = 80;
            dtgDetalleComprobante.Columns["nSubtotalImporte"].FillWeight = 52;
            dtgDetalleComprobante.Columns["nIgvImporte"].FillWeight = 52;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].FillWeight = 52;
            dtgDetalleComprobante.Columns["nMontoImporte"].FillWeight = 52;
            dtgDetalleComprobante.Columns["nOtrosImporte"].FillWeight = 52;
            dtgDetalleComprobante.Columns["nMontoPagar"].FillWeight = 52;
            dtgDetalleComprobante.Columns["cboAgencia"].FillWeight = 80;

            dtgDetalleComprobante.Columns["btnDetConcepto"].DisplayIndex = 0;
            dtgDetalleComprobante.Columns["cConceptoComprPago"].DisplayIndex = 1;
            dtgDetalleComprobante.Columns["btnDetCentroCosto"].DisplayIndex = 2;
            dtgDetalleComprobante.Columns["cCentroCosto"].DisplayIndex = 3;
            dtgDetalleComprobante.Columns["cboAgencia"].DisplayIndex = 4;
            dtgDetalleComprobante.Columns["nSubtotalImporte"].DisplayIndex = 5;
            dtgDetalleComprobante.Columns["nIgvImporte"].DisplayIndex = 6;
            dtgDetalleComprobante.Columns["nOtrosImporte"].DisplayIndex = 7;
            dtgDetalleComprobante.Columns["nMontoImporte"].DisplayIndex = 8;
            dtgDetalleComprobante.Columns["nMontoDetraccion"].DisplayIndex = 9;
            dtgDetalleComprobante.Columns["nCuartaCategImporte"].DisplayIndex = 10;
            dtgDetalleComprobante.Columns["nMontoPagar"].DisplayIndex = 11;

            dtgDetalleComprobante.CellValueChanged += new DataGridViewCellEventHandler(dtgDetalleComprobante_CellValueChanged);

            foreach (DataGridViewColumn column in dtgDetalleComprobante.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            FormatoTextBox();
        }

        private void CargarOtrosDescuentos()
        {
            dtDescComprPago = objCajaChica.ListarOtrosDescuentoComprobantes();
            dtgOtrosDesctosCpg.DataSource = dtDescComprPago;
            FormatoGridOtrosDescuentos();
        }

        private void FormatoGridOtrosDescuentos()
        {
            dtDescComprPago.Columns["idDescuentosComprPago"].ReadOnly = false;
            dtDescComprPago.Columns["idComprobantePago"].ReadOnly = false;
            dtDescComprPago.Columns["idTipoDescComPago"].ReadOnly = false;
            dtDescComprPago.Columns["Concepto"].ReadOnly = true;
            dtDescComprPago.Columns["nMonto"].ReadOnly = false;
            dtDescComprPago.Columns["lVigente"].ReadOnly = false;

            dtgOtrosDesctosCpg.ReadOnly = false;

            dtgOtrosDesctosCpg.Columns["idDescuentosComprPago"].Visible = false;
            dtgOtrosDesctosCpg.Columns["idTipoDescComPago"].Visible = false;
            dtgOtrosDesctosCpg.Columns["idComprobantePago"].Visible = false;
            dtgOtrosDesctosCpg.Columns["Concepto"].Visible = true;
            dtgOtrosDesctosCpg.Columns["nMonto"].Visible = true;
            dtgOtrosDesctosCpg.Columns["lVigente"].Visible = true;
            if (dtgOtrosDesctosCpg.Columns.Contains("cAbrev"))
            {
                dtgOtrosDesctosCpg.Columns["cAbrev"].Visible = false;
            }

            dtgOtrosDesctosCpg.Columns["lVigente"].Width = 50;
            dtgOtrosDesctosCpg.Columns["Concepto"].Width = 250;
            dtgOtrosDesctosCpg.Columns["nMonto"].Width = 80;

            dtgOtrosDesctosCpg.Columns["lVigente"].ReadOnly = false;
            dtgOtrosDesctosCpg.Columns["Concepto"].ReadOnly = true;
            dtgOtrosDesctosCpg.Columns["nMonto"].ReadOnly = false;

            dtgOtrosDesctosCpg.Columns["lVigente"].HeaderText = "";
            dtgOtrosDesctosCpg.Columns["Concepto"].HeaderText = "Concepto";
            dtgOtrosDesctosCpg.Columns["nMonto"].HeaderText = "Monto";

            dtgOtrosDesctosCpg.Columns["nMonto"].DefaultCellStyle.Format = "##,##0.00";
        }

        private void CargarTipoOperacion()
        {
            this.cboTipoOperacion.SelectedIndexChanged -= new EventHandler(cboTipoOperacion_SelectedIndexChanged);

            DataTable listaTipoOperDetra = objCajaChica.ListarTipoOperacionDetraccion();
            cboTipoOperacion.DataSource = listaTipoOperDetra;
            cboTipoOperacion.ValueMember = "idTipoOperacionDetr";
            cboTipoOperacion.DisplayMember = "cDescripcion";

            this.cboTipoOperacion.SelectedIndexChanged += new EventHandler(cboTipoOperacion_SelectedIndexChanged);
        }

        private void CargarCboDestinos()
        {
            DataTable Destinos = objCajaChica.ListarDestinoComprPago(clsVarGlobal.nIdAgencia);
            cboDestino.DataSource = Destinos;
            cboDestino.ValueMember = "idDetinoComprPago";
            cboDestino.DisplayMember = "cDescripcion";
        }

        private void CargarCboCajaChica( int Agencia)
        {
            DataTable ListCajaChica = objCajaChica.CNListCajChicaAge(Agencia);
            if (Agencia == 0)
            {
                cboCajaChica.SelectedText = "";
                //txtNroCajChica.Text = "0";
            }
            else
            {
                cboCajaChica.SelectedIndexChanged -= new EventHandler(cboCajaChica_SelectedIndexChanged);
                cboCajaChica.DataSource = ListCajaChica;
                cboCajaChica.ValueMember = "idCajChica";
                cboCajaChica.DisplayMember = "cNomCajChi";
                cboCajaChica.SelectedIndexChanged += new EventHandler(cboCajaChica_SelectedIndexChanged);
                //DetalleCajaChica(Convert.ToInt32(cboCajaChica.SelectedValue));
            }            
        }

        //private void DetalleCajaChica(int idCajChica)
        //{
        //    dtDatosCajChica1 = objCajaChica.CNDatosCajChicaAct(idCajChica);
        //    if (dtDatosCajChica1.Rows.Count > 0)
        //    {
        //        this.txtNroCajChica.Text = Convert.ToString(dtDatosCajChica1.Rows[0]["nNroCajChi"]);
        //    }            
        //    nidCajChica = idCajChica;
        //}


        private void CargarBienServicio(int idTipoOpera)
        {
            dtBienServDetra = objCajaChica.ListarBienServicioDetraccion(idTipoOpera);
            cboBienServicio.DataSource = dtBienServDetra;
            cboBienServicio.ValueMember = "idBienServicioDetr";
            cboBienServicio.DisplayMember = "cDescripcion";
        }

        private void LimpiarComponentes()
        {
            cboTipoComprobantePago.SelectedIndex = -1;
            txtSerie.Text = "";
            txtNumero.Text = "";
            cboMoneda.SelectedIndex = -1;
            txtCambio.Text = "";
            txtCodigo.Text = "";
            txtIgvCalculo.Text = "";
            cboTipoPago.SelectedIndex = -1;
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechaPago.Format = DateTimePickerFormat.Custom;
            dtpFechaPago.CustomFormat = " ";

            conBusCliente.limpiarControles();
            dtgOtrosDesctosCpg.DataSource = null;
            cboDestino.SelectedIndex = -1;
            rbtnSinDetraccion.Checked = false;
            rbtnConDetraccion.Checked = false;
            cboBienServicio.DataSource = null;
            cboTipoOperacion.SelectedIndex = -1;
            txtCIIU.Text = "";
            txtPorcDetraccion.TextChanged -= new EventHandler(txtPorcDetraccion_TextChanged);
            txtPorcDetraccion.Text = "";
            txtPorcDetraccion.TextChanged += new EventHandler(txtPorcDetraccion_TextChanged);
            dtgDetalleComprobante.DataSource = null;
            txtValorCompra.Text = "";
            txtIGV.Text = "";
            txtDetraccion.Text = "";
            txtTotal.Text = "";
            chcProvisionar.Checked = false;
            dtpFechaProvision.Format = DateTimePickerFormat.Custom;
            dtpFechaProvision.CustomFormat = " ";
            dtpFechaProvision.Enabled = false;
            txtGlosa.Text = "";
            txtTotOtros.Text = "";
            txtTotPag.Text = "";
            txtDescuentos.Text = "";
            txtNetoPagar.Text = "";
            chcCuartaCateg.Checked = false;
            chcImpRenta.Checked = false;
            dtpFecVenc.Value = clsVarGlobal.dFecSystem;
        }

        private void VincularComponentes()
        {
            txtCodigo.DataBindings.Add("Text", dtComprPago, "idComprobantePago", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            cboTipoComprobantePago.DataBindings.Add("SelectedValue", dtComprPago, "idTipoComprobantePago", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            cboMoneda.DataBindings.Add("SelectedValue", dtComprPago, "idMoneda", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            txtIgvCalculo.DataBindings.Add("Text", dtComprPago, "nIgvCalculo", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            conBusCliente.txtCodCli.DataBindings.Add("Text", dtComprPago, "idCliente", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtSerie.DataBindings.Add("Text", dtComprPago, "cSerie", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtNumero.DataBindings.Add("Text", dtComprPago, "cNumero", true, DataSourceUpdateMode.OnPropertyChanged, "");
            cboDestino.DataBindings.Add("SelectedValue", dtComprPago, "idDestino", true, DataSourceUpdateMode.OnPropertyChanged, "0");
            cboBienServicio.DataBindings.Add("SelectedValue", dtComprPago, "idBienServicioDetr", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            txtGlosa.DataBindings.Add("Text", dtComprPago, "cGlosa", true, DataSourceUpdateMode.OnPropertyChanged, "");
            txtValorCompra.DataBindings.Add("Text", dtComprPago, "nSubTotal", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtIGV.DataBindings.Add("Text", dtComprPago, "nTotalIGV", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtDetraccion.DataBindings.Add("Text", dtComprPago, "nTotalDetraccion", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            chcCuartaCateg.DataBindings.Add("Checked", dtComprPago, "lAfeCuartaCateg", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            txtTot4taCateg.DataBindings.Add("Text", dtComprPago, "nTotCuartaCateg", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtTotOtros.DataBindings.Add("Text", dtComprPago, "nTotOtros", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtTotal.DataBindings.Add("Text", dtComprPago, "nTotal", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");

            txtTotPag.DataBindings.Add("Text", dtComprPago, "nMonto", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtDescuentos.DataBindings.Add("Text", dtComprPago, "nTotDescuento", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");
            txtNetoPagar.DataBindings.Add("Text", dtComprPago, "nNetoPagar", true, DataSourceUpdateMode.OnPropertyChanged, null, "##0.00");

            dtpFechaEmision.DataBindings.Add("Value", dtComprPago, "dFechaEmision", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpFechaPago.DataBindings.Add("Text", dtComprPago, "dFechaPago", true, DataSourceUpdateMode.OnPropertyChanged, " ");
            dtpFechaProvision.DataBindings.Add("Text", dtComprPago, "dFechaProvision", true, DataSourceUpdateMode.OnPropertyChanged, " ");
            chcProvisionar.DataBindings.Add("Checked", dtComprPago, "lEstadoProvision", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTipoPago.DataBindings.Add("SelectedValue", dtComprPago, "idTipoPago", true, DataSourceUpdateMode.OnPropertyChanged, -1);
            txtCambio.DataBindings.Add("Text", dtComprPago, "nTipCambio", true, DataSourceUpdateMode.OnPropertyChanged, "0.0000", "##0.0000");    
			dtpFecVenc.DataBindings.Add("Value", dtComprPago, "dFechaVencimiento", true, DataSourceUpdateMode.OnPropertyChanged,"");
            chcImpRenta.DataBindings.Add("Checked", dtComprPago, "lAfecLeyImpRenta", true, DataSourceUpdateMode.OnPropertyChanged);            
        }

        private void DesvincularComponentes()
        {
            txtCodigo.DataBindings.Clear();
            cboTipoComprobantePago.DataBindings.Clear();
            cboMoneda.DataBindings.Clear();
            txtIgvCalculo.DataBindings.Clear();
            conBusCliente.txtCodCli.DataBindings.Clear();
            txtSerie.DataBindings.Clear();
            txtNumero.DataBindings.Clear();
            cboDestino.DataBindings.Clear();
            cboBienServicio.DataBindings.Clear();
            txtGlosa.DataBindings.Clear();
            txtValorCompra.DataBindings.Clear();
            txtIGV.DataBindings.Clear();
            txtDetraccion.DataBindings.Clear();
            chcCuartaCateg.DataBindings.Clear();
            txtTot4taCateg.DataBindings.Clear();
            txtTotOtros.DataBindings.Clear();
            txtTotal.DataBindings.Clear();
            dtpFechaEmision.DataBindings.Clear();          
            dtpFechaProvision.DataBindings.Clear();
            chcProvisionar.DataBindings.Clear();
            cboTipoPago.DataBindings.Clear();
            txtCambio.DataBindings.Clear();

            dtpFechaPago.DataBindings.Clear();
            txtTotPag.DataBindings.Clear();
            txtDescuentos.DataBindings.Clear();
            txtNetoPagar.DataBindings.Clear();
			dtpFecVenc.DataBindings.Clear();
            chcImpRenta.DataBindings.Clear();
        }

        private void HabilitarComponentes(int nOpc)
        {
            if (nOpc == 1)
            {
                cboTipoComprobantePago.Enabled = false;
                txtSerie.Enabled = false;
                txtNumero.Enabled = false;
                dtpFechaEmision.Enabled = false;
                cboMoneda.Enabled = false;
                txtCambio.Enabled = false;
                txtCodigo.Enabled = false;
                txtIgvCalculo.Enabled = false;
                cboTipoPago.Enabled = false;

                conBusCliente.Enabled = false;
                dtgOtrosDesctosCpg.Enabled = false;
                cboDestino.Enabled = false;
                rbtnSinDetraccion.Enabled = false;
                rbtnConDetraccion.Enabled = false;
                cboTipoOperacion.Enabled = false;
                cboBienServicio.Enabled = false;
                txtGlosa.Enabled = false;
                txtCIIU.Enabled = false;
                txtPorcDetraccion.Enabled = false;
                dtgDetalleComprobante.Enabled = false;
                chcProvisionar.Enabled = false;
                dtpFechaProvision.Enabled = false;
                chcCuartaCateg.Enabled = false;
                chcImpRenta.Enabled = false;
                dtpFecVenc.Enabled = false;                

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnAnular.Enabled = false;
                btnBuscar.Enabled = true;
                btnAgregarDetalle.Enabled = false;
                btnQuitarDetalle.Enabled = false;                
            }
            else if (nOpc == 2)
            {
                cboTipoComprobantePago.Enabled = true;
                txtSerie.Enabled = true;
                txtNumero.Enabled = true;
                cboMoneda.Enabled = true;
                txtCambio.Enabled = true;
                txtCodigo.Enabled = true;
                txtIgvCalculo.Enabled = true;
                cboTipoPago.Enabled = false;
                conBusCliente.Enabled = true;
                dtgOtrosDesctosCpg.Enabled = true;
                cboDestino.Enabled = true;
                rbtnSinDetraccion.Enabled = true;
                rbtnConDetraccion.Enabled = true;
                cboTipoOperacion.Enabled = false;
                cboBienServicio.Enabled = false;
                txtGlosa.Enabled = true;
                txtCIIU.Enabled = true;
                txtPorcDetraccion.Enabled = true;
                dtgDetalleComprobante.Enabled = true;
                chcProvisionar.Enabled = true;
                if (chcProvisionar.Checked)
                {
                    dtpFechaProvision.Enabled = true;
                }
                else
                {
                    dtpFechaProvision.Enabled = false;
                }

                chcCuartaCateg.Enabled = true;

                dtpFechaEmision.Format = DateTimePickerFormat.Short;
                dtpFechaEmision.CustomFormat = "dd/mm/yyyy";
                dtpFechaEmision.Enabled = true;

                dtpFechaPago.Format = DateTimePickerFormat.Short;
                dtpFechaPago.CustomFormat = "dd/mm/yyyy";

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAnular.Enabled = false;
                btnBuscar.Enabled = false;
                btnAgregarDetalle.Enabled = true;
                btnQuitarDetalle.Enabled = true;

                conBusCliente.Enabled = true;
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.btnBusCliente.Enabled = true;
				chcImpRenta.Enabled = true;

                dtpFecVenc.Format = DateTimePickerFormat.Short;
                dtpFecVenc.CustomFormat = "dd/mm/yyyy";
                dtpFecVenc.Enabled = true; 
            }
            else if (nOpc == 3) //inicio de formulario
            {
                cboTipoComprobantePago.Enabled = false;
                txtSerie.Enabled = false;
                txtNumero.Enabled = false;
                dtpFechaEmision.Enabled = false;
                cboMoneda.Enabled = false;
                txtCambio.Enabled = false;
                txtCodigo.Enabled = false;
                txtIgvCalculo.Enabled = false;
                cboTipoPago.Enabled = false;
                conBusCliente.Enabled = false;
                dtgOtrosDesctosCpg.Enabled = false;
                cboDestino.Enabled = false;
                rbtnSinDetraccion.Enabled = false;
                rbtnConDetraccion.Enabled = false;
                cboTipoOperacion.Enabled = false;
                txtGlosa.Enabled = false;
                cboBienServicio.Enabled = false;
                txtCIIU.Enabled = false;
                txtPorcDetraccion.Enabled = false;
                dtgDetalleComprobante.Enabled = false;
                chcProvisionar.Enabled = false;
                chcCuartaCateg.Enabled = false;
                chcImpRenta.Enabled = false;                
                dtpFecVenc.Enabled = false;
                lblFecVenc.Visible = false;
                dtpFecVenc.Visible = false;

                dtpFechaProvision.Format = DateTimePickerFormat.Custom;
                dtpFechaProvision.CustomFormat = " ";
                dtpFechaProvision.Enabled = false;

                dtpFechaPago.Format = DateTimePickerFormat.Custom;
                dtpFechaPago.CustomFormat = " ";
                
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAnular.Enabled = false;
                btnBuscar.Enabled = true;
                btnAgregarDetalle.Enabled = false;
                btnQuitarDetalle.Enabled = false;               
            }
        }

        private int ValidarExistenDetalle(string valor)
        {
            if (dtgDetalleComprobante.Rows.Count > 0)
            {
                foreach (DataRow nrow in dtDetComprPago.Rows)
                {
                    if (nrow["idConceptoComprobante"].ToString().Equals(valor))
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }

        private void ValidarDatos()
        {
            string Msje = "";
            lFlagValidar = true;

            if (cboTipoComprobantePago.SelectedIndex == -1)
            {
                Msje += "Seleccione un tipo de Comprobante por favor.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text.Trim()))
            {
                Msje += "Ingrese la serie del comprobante por favor.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
            {
                Msje += "Ingrese el numero del recibo.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text.Trim()))// || Convert.ToInt32(txtSerie.Text.Trim()) <= 0)
            {
                Msje += "El numero de serie del comprobante debe ser mayor a 0.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtNumero.Text.Trim()))// && Convert.ToInt32(txtNumero.Text.Trim()) <= 0)
            {
                Msje += "El numero del comprobante debe ser mayor a 0.\n";
                lFlagValidar = false;
            }
            if (Convert.ToInt32(cboMoneda.SelectedIndex) == -1)
            {
                Msje += "Ingrese el tipo de moneda.\n";
                lFlagValidar = false;
            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                if (string.IsNullOrEmpty(txtCambio.Text.Trim()))
                {
                    Msje += "Ingrese el tipo de cambio.\n";
                    lFlagValidar = false;
                }
            }
            if (string.IsNullOrEmpty(txtIgvCalculo.Text.Trim()))
            {
                Msje += "Ingrese el porcentaje del igv con el que se calculará el comprobante.\n";
                lFlagValidar = false;
            }
            if (conBusCliente.txtCodCli.Text == "0")
            {
                Msje += "Seleccione un cliente por favor.\n";
                lFlagValidar = false;
            }
            if (cboDestino.SelectedIndex == -1)
            {
                Msje += "Seleccione el tipo de destino del comprobante.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtGlosa.Text.Trim()))
            {
                Msje += "Ingrese una descripcion del comprobante por favor.\n";
                lFlagValidar = false;
            }
            if (dtgDetalleComprobante.RowCount == 0)
            {
                Msje += "Ingrese el detalle del comprobante por favor.";
                lFlagValidar = false;
            }
            if (dtgDetalleComprobante.RowCount > 0)
            {
                foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
                {
                    if (string.IsNullOrEmpty(row.Cells["cConceptoComprPago"].Value.ToString()))
                    {
                        Msje += "Ingrese el concepto de todos los items del detalle.";
                        lFlagValidar = false;
                        break;
                    }
                    if (Convert.ToDecimal(row.Cells["nMontoPagar"].Value.ToString()) <= 0)
                    {
                        Msje += "El monto de los items del detalle deben de ser mayores a 0.";
                        lFlagValidar = false;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(Msje.Trim()))
            {
                MessageBox.Show(Msje, "Registro de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }

            if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                if (Convert.ToDecimal(txtNetoPagar.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariSoles"]))
                {
                    MessageBox.Show("No puede registrar Comprobante, Monto Límite de Bancarización: " + "\r\n" + "S/. " + clsVarApl.dicVarGen["nMontoBancariSoles"], "Validar Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lFlagValidar = false;
                }
            }

            if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                if (Convert.ToDecimal(txtNetoPagar.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariDolares"]))
                {
                    MessageBox.Show("No puede registrar Comprobante, Monto Límite de Bancarización: " + "\r\n" + "$ " + clsVarApl.dicVarGen["nMontoBancariDolares"], "Validar Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lFlagValidar = false;
                }
            }            
        }
        
        private void CalcularTotal(bool lRecalcularIGV)
        {
            if (lBloquearCalcular) return;
            decimal nSubTotal = 0.00M;
            decimal nTotalIGV = 0.00M;
            decimal nTotalOtros = 0.00M;
            decimal nTotalDetraccion = 0.00M;
            decimal nTotCuartaCateg = 0.00M;
            decimal nTotal = 0.00M;
            decimal nTotPagar = 0.00M;
            decimal nTotDes = 0.00M;

            foreach (DataGridViewRow row in dtgDetalleComprobante.Rows)
            {
                if (Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) < 0)
                {
                    MessageBox.Show("Valor no puede ser negativo", "Registro de comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    row.Cells["nSubtotalImporte"].Value = 0;
                    return;
                }

                decimal nPorcCuartaCateg;
                
                if (chcCuartaCateg.Checked)
                {
                    nPorcCuartaCateg = Convert.ToDecimal(dtConfigTipCompr.Rows[0]["nValCuartaCateg"]);
                }
                else
	            {
                    nPorcCuartaCateg = Convert.ToDecimal(0.00);
	            }

                decimal nPorcIgv = string.IsNullOrEmpty(txtIgvCalculo.Text) ? 0.00M : Convert.ToDecimal(txtIgvCalculo.Text);
                decimal nPorcDetraccion = string.IsNullOrEmpty(txtPorcDetraccion.Text) ? 0.00M : Convert.ToDecimal(txtPorcDetraccion.Text);
                DataTable dtDestinos = (DataTable)cboDestino.DataSource;
                bool lAfectaIGV = Convert.ToBoolean(dtDestinos.Rows[cboDestino.SelectedIndex]["lAplIgv"]);
                if (lAfectaIGV)
                {
                    if (lRecalcularIGV)
                    {
                        row.Cells["nIgvImporte"].Value = Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2);
                    }
                    else
                    {
                        if (Math.Abs(Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2) - Convert.ToDecimal(row.Cells["nIgvImporte"].Value)) > 0.01M) // Si el IGV difiere en mas de 1 centimo se recalcula
                        {
                            row.Cells["nIgvImporte"].Value = Math.Round((Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) * nPorcIgv) / (100.00M), 2);
                        }
                    }
                }
                else
                {
                    row.Cells["nIgvImporte"].Value = 0.00M;
                }
                row.Cells["nMontoImporte"].Value = Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value) +
                                                   Convert.ToDecimal(row.Cells["nIgvImporte"].Value) +
                                                   Convert.ToDecimal(row.Cells["nOtrosImporte"].Value);

                if (rbtnConDetraccion.Checked)
                {                    
					row.Cells["nMontoDetraccion"].Value = Math.Round((Convert.ToDecimal(row.Cells["nMontoImporte"].Value) * nPorcDetraccion) / (100.00M), 0);   //2);  REDONDEO DE LA DETRACION A ENTERO
                }
                else
                {
                    row.Cells["nMontoDetraccion"].Value = 0.00M;
                }

                row.Cells["nCuartaCategImporte"].Value = (Convert.ToDecimal(row.Cells["nMontoImporte"].Value) * nPorcCuartaCateg) / 100.00M;

                row.Cells["nMontoPagar"].Value = Convert.ToDecimal(row.Cells["nMontoImporte"].Value) - Convert.ToDecimal(row.Cells["nMontoDetraccion"].Value) - Convert.ToDecimal(row.Cells["nCuartaCategImporte"].Value);

                nSubTotal += Convert.ToDecimal(row.Cells["nSubtotalImporte"].Value);
                nTotalIGV += Convert.ToDecimal(row.Cells["nIgvImporte"].Value);
                nTotalOtros += Convert.ToDecimal(row.Cells["nOtrosImporte"].Value);
                nTotal += Convert.ToDecimal(row.Cells["nMontoImporte"].Value);
                nTotalDetraccion += Convert.ToDecimal(row.Cells["nMontoDetraccion"].Value);
                nTotCuartaCateg += Convert.ToDecimal(row.Cells["nCuartaCategImporte"].Value);
                nTotPagar += Convert.ToDecimal(row.Cells["nMontoPagar"].Value);
            }

            foreach (DataGridViewRow row in dtgOtrosDesctosCpg.Rows)
            {
                nTotDes += Convert.ToDecimal(row.Cells["nMonto"].Value);
            }

            this.txtValorCompra.Text = nSubTotal.ToString("##,##0.00");
            this.txtIGV.Text = nTotalIGV.ToString("##,##0.00");
            this.txtDetraccion.Text = nTotalDetraccion.ToString("##,##0.00");
            this.txtTot4taCateg.Text = nTotCuartaCateg.ToString("##,##0.00");
            this.txtTotOtros.Text = nTotalOtros.ToString("##,##0.00");
            this.txtTotal.Text = nTotal.ToString("##,##0.00");
            this.txtTotPag.Text = nTotPagar.ToString("##,##0.00");
            this.txtDescuentos.Text = nTotDes.ToString("##,##0.00");
            this.txtNetoPagar.Text = (nTotPagar-nTotDes).ToString("##,##0.00");
        }

        //private bool ValidarCajaChica()
        //{
        //    int nIdEstCajaChica = Convert.ToInt16(dtDatosCajChica1.Rows[0]["idEstCajChi"]);
        //    if (nIdEstCajaChica == 4)
        //    {
        //        MessageBox.Show("Falta Realizar Habilitación de Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return false;
        //    }
        //    if (nIdEstCajaChica == 1)
        //    {
        //        MessageBox.Show("Falta Iniciar Fondo Fijo, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return false;
        //    }
        //    if (nIdEstCajaChica == 3)
        //    {
        //        MessageBox.Show("Caja Chica Cerrada, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return false;
        //    }
        //    return true;
        //}

        private void ValidarMontosCajChica()
        {
            lFlagValidar = true;
            int x_idCajChica = Convert.ToInt32(cboCajaChica.SelectedValue);
            dtDatosCajChica1 = objCajaChica.CNDatosCajChicaAct(x_idCajChica);

            if (Convert.ToDecimal(dtDatosCajChica1.Rows[0]["nMonMaxCpg"].ToString()) <= Convert.ToDecimal(dtComprPago.Rows[0]["nMonto"].ToString()))
            {
                MessageBox.Show("EL MONTO DEL COMPROBANTE EXCEDE EL MONTO MAXIMO PERMITIDO", "Registro de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }

            //if (Convert.ToDecimal(dtDatosCajChica1.Rows[0]["nSaldoAcum"].ToString()) + Convert.ToDecimal(dtComprPago.Rows[0]["nTotal"].ToString()) >= Convert.ToDecimal(dtDatosCajChica1.Rows[0]["nMonMaxCaj"].ToString()))
            //{
            //    MessageBox.Show("FONDOS INSUFICIENTES PARA ESTE COMPROBANTE", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    lFlagValidar = false;
            //}
            //validar que el monto sea diferente a null
            if (dtgDetalleComprobante.Rows.Count > 0)
            {
                foreach (DataRow nrow in dtDetComprPago.Rows)
                {
                    if (nrow["nMontoImporte"].ToString().Equals(""))
                    {
                        MessageBox.Show("Por Favor Ingrese el monto del Concepto", "Registro de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lFlagValidar = false;
                    }
                }
            }

        }        

        private void CargarTipoPago()
        {
            GEN.CapaNegocio.clsCNTipoPago objTipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable ListaTipoPago = objTipoPago.ListaTipoPago();
            cboTipoPago.DataSource = ListaTipoPago;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";
            cboTipoPago.SelectedIndex = -1;
        }      

        private void FormatoTextBox()
        {
            var SubTotRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nSubtotalImporte"].Index, true);
            var IgvRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nIgvImporte"].Index, true);
            var nMontDetracRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoDetraccion"].Index, true);
            var nMontoImportRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoImporte"].Index, true);
            var CuartaCategRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nCuartaCategImporte"].Index, true);
            var OtrosRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nOtrosImporte"].Index, true);
            var TotPagRectangle = dtgDetalleComprobante.GetColumnDisplayRectangle(dtgDetalleComprobante.Columns["nMontoPagar"].Index, true);

            int PosY = SubTotRectangle.Y + dtgDetalleComprobante.Height + dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderCell.Size.Height;

            this.txtValorCompra.Width = dtgDetalleComprobante.Columns["nSubtotalImporte"].HeaderCell.Size.Width;
            this.txtIGV.Width = dtgDetalleComprobante.Columns["nIgvImporte"].HeaderCell.Size.Width;
            this.txtDetraccion.Width = dtgDetalleComprobante.Columns["nMontoDetraccion"].HeaderCell.Size.Width;
            this.txtTot4taCateg.Width = dtgDetalleComprobante.Columns["nCuartaCategImporte"].HeaderCell.Size.Width;
            this.txtTotOtros.Width = dtgDetalleComprobante.Columns["nOtrosImporte"].HeaderCell.Size.Width;
            this.txtTotal.Width = dtgDetalleComprobante.Columns["nMontoImporte"].HeaderCell.Size.Width;
            this.txtTotPag.Width = dtgDetalleComprobante.Columns["nMontoPagar"].HeaderCell.Size.Width;
            this.txtDescuentos.Width = txtTotPag.Width;
            this.txtNetoPagar.Width = txtTotPag.Width;

            this.txtValorCompra.Location = new Point(SubTotRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtIGV.Location = new Point(IgvRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtDetraccion.Location = new Point(nMontDetracRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtTot4taCateg.Location = new Point(CuartaCategRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtTotOtros.Location = new Point(OtrosRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtTotal.Location = new Point(nMontoImportRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtTotPag.Location = new Point(TotPagRectangle.X + dtgDetalleComprobante.Location.X, txtValorCompra.Location.Y);
            this.txtDescuentos.Location = new Point(txtTotPag.Location.X, txtDescuentos.Location.Y);
            this.txtNetoPagar.Location = new Point(txtTotPag.Location.X, txtNetoPagar.Location.Y);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
            frmBusqCompPago.chcTieneComprobante.Checked = true;
            frmBusqCompPago.chcCajChic.Checked = true;
            frmBusqCompPago.ShowDialog();
            nidComprobantePago = frmBusqCompPago.pidComprobantePago;
            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarComprobante(nidComprobantePago);
        }

        private void btnBusqCodRef_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
            frmBusqCompPago.chcTieneComprobante.Checked = true;
            frmBusqCompPago.chcCajChic.Checked = false;
            frmBusqCompPago.ShowDialog();
            nidComprobantePago = frmBusqCompPago.pidComprobantePago;
            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtCodRef.Text = nidComprobantePago.ToString();
        }

        private void BuscarComprobante(int idCpg)
        {
            lBloquearCalcular= true;
            DesvincularComponentes();
            LimpiarComponentes();
            btnNuevo.Enabled = true;

            //=======================================================================
            //--Referenciar a null los DataTable y Crear Nuevos Objetos 
            //=======================================================================
            dtComprPago = null;
            dtDetComprPago = null;
            dtDescComprPago = null;
            dtBuscaCompCajaChica = null;
            dtComprPago = new DataTable("dtComprPago");
            dtDetComprPago = new DataTable("dtDetComprPago");
            dtDescComprPago = new DataTable("dtDescComprPago");
            //=======================================================================
            //--Buscar la caja chica en que se registro el comprobante
            //=======================================================================
            dtBuscaCompCajaChica = objCajaChica.CNCompCajChica(idCpg);

            if (dtBuscaCompCajaChica.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Comprobante...Validar", "Buscar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lBloquearCalcular = false;
                return;
            }
            cboAgencias1.SelectedValue = 0;
            cboAgencias1.SelectedValue = Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idAgencia"]);
            cboCajaChica.SelectedValue = Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idCajChica"]);
            txtNroCajChica.Text = Convert.ToString(dtBuscaCompCajaChica.Rows[0]["nNroCajChi"]);
            nidCajChica = Convert.ToInt32(dtBuscaCompCajaChica.Rows[0]["idCajChica"]);

            //=======================================================================
            //--Buscar Datos del Maestro y detalle 
            //=======================================================================
            dtComprPago = objCajaChica.BuscarComprPago(idCpg);
            if (dtComprPago.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Comprobante...Validar", "Buscar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lBloquearCalcular = false;
                return;
            }

            if (Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"])==3)
            {
                MessageBox.Show("El Comprobante se Encuentra Eliminado", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lBloquearCalcular = false;
                return;
            }

            if (Convert.ToInt16(dtComprPago.Rows[0]["lCpgCajChica"]) == 0)
            {
                MessageBox.Show("El Comprobante no Pertenece a Caja Chica", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lBloquearCalcular = false;
                return;
            }

            btnNuevo.Enabled = false;

            dtDetComprPago = objCajaChica.BuscarDetComprPago(idCpg);
            dtDetComprPago.DefaultView.RowFilter = ("lVigente <> 0");

            foreach (DataColumn column in dtComprPago.Columns)
            {
                column.ReadOnly = false;
            }

            VincularComponentes();

            dtDescComprPago = objCajaChica.BuscarDescComprPago(idCpg);

            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            var idCli = Convert.ToInt32(dtComprPago.Rows[0]["idCliente"]);

            conBusCliente.CargardatosCli(idCli);
            conBusCliente.txtCodCli.Enabled = false;


            //=======================================================================
            //--Agregar Colummna de tipo combobox
            //=======================================================================
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dtAgencia = ListadoAgencia.ListarAgencias();
            DataGridViewComboBoxColumn cboAgencia = new DataGridViewComboBoxColumn();
            cboAgencia.Name = "cboAgencia";
            cboAgencia.DataPropertyName = "idAgencia";
            cboAgencia.DataSource = dtAgencia;
            cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            cboAgencia.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
            this.dtgDetalleComprobante.Columns.Add(cboAgencia);

            //=======================================================================
            //--Llenar datagridview detalle de comprobante y darle formato
            //=======================================================================
            dtgDetalleComprobante.DataSource = dtDetComprPago;
            FormatoGridDetalle();

            //=======================================================================
            //--Llenar datagridview descuentos de comprobante y darle formato
            //=======================================================================
            dtgOtrosDesctosCpg.DataSource = dtDescComprPago;
            FormatoGridOtrosDescuentos();

            if (dtComprPago.Rows[0]["dFechaPago"] != DBNull.Value)
            {
                dtpFechaPago.Format = DateTimePickerFormat.Short;
                dtpFechaPago.Text = dtComprPago.Rows[0]["dFechaPago"].ToString();
            }

            if (dtComprPago.Rows[0]["idTipoPago"] != DBNull.Value)
            {
                cboTipoPago.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoPago"]);
                
            }

            if (string.IsNullOrEmpty(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString()))
            {
                rbtnSinDetraccion.Checked = true;
                cboTipoOperacion.SelectedIndex = -1;
                cboBienServicio.SelectedIndex = -1;
                txtPorcDetraccion.Text = "";
            }
            else
            {
                rbtnConDetraccion.Checked = true;               

                cboTipoOperacion.DataBindings.Clear();
                cboBienServicio.DataBindings.Clear();
                cboTipoOperacion.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString());
                cboBienServicio.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idBienServicioDetr"].ToString());
            }

            if (dtComprPago.Rows[0]["dFechaProvision"] != DBNull.Value)
            {
                dtpFechaProvision.Format = DateTimePickerFormat.Short;
                dtpFechaProvision.Text = dtComprPago.Rows[0]["dFechaProvision"].ToString();
            }

            FormatoGridDetalle();
            btnEditar.Enabled = true;
            btnAnular.Enabled = true;
            cboTipoOperacion.Enabled = false;
            cboBienServicio.Enabled = false;
            cboDestino.Enabled = false;

            lblCodigo.Visible = true;
            txtCodigo.Visible = true;
            cboTipoOperacion.Enabled = false;
            cboBienServicio.Enabled = false;
            dtpFechaProvision.Enabled = false;
            rbtnConDetraccion.Enabled = false;
            rbtnSinDetraccion.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = false;
            cboDestino.Enabled = false;
            dtgDetalleComprobante.Enabled = false;
            lBloquearCalcular = false;

            cboAgencias1.Enabled = false;
            cboCajaChica.Enabled = false;

            lIsCierre = Convert.ToBoolean(dtComprPago.Rows[0]["lIsCierre"]); //--Indica si el comprobante ya esta cerrado o no
            pEstadoCpg = Convert.ToInt16(dtComprPago.Rows[0]["idEstadoComprobante"]);

            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 2)
            {
                MessageBox.Show("EL COMPROBANTE ESTA PAGADO...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnAnular.Enabled = false;
            }

            if (lIsCierre)
            {
                MessageBox.Show("El Comprobante pertenece a un periódo cerrado, no puede modificar", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnEditar.Enabled = false;
            }

            idDestino = Convert.ToInt32(dtComprPago.Rows[0]["idDestino"]);
            txtCodigo.Enabled = false;
        
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtCodigo.Text.Trim()))
                {
                    MessageBox.Show("Ingrese Codigo de Comprobante...", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(txtCodigo.Text) <= 0)
                {
                    MessageBox.Show("Ingrese Codigo de Comprobante Valido", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BuscarComprobante(Convert.ToInt32(txtCodigo.Text));
            }
        }
        
        private void chcCuartaCateg_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotal(false); //Se debe mantener el valor de IGV
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCboCajaChica(Convert.ToInt32(cboAgencias1.SelectedValue));

        }

        private void cboCajaChica_SelectedIndexChanged(object sender, EventArgs e)

        {
            //int idCajaChica = Convert.ToInt32(cboCajaChica.SelectedValue);
            //DetalleCajaChica(idCajaChica);

        }

        private void dtpFechaEmision_ValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblCambio.Visible = true;
                    txtCambio.Visible = true;
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }                    
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
            }
        }

        private void dtpFechaEmision_Leave(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedValue != null)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) == 2)
                {
                    clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
                    DataTable tbTipCam = dtTipCam.RetornaTiposCambio(dtpFechaEmision.Value);
                    lblCambio.Visible = true;
                    txtCambio.Visible = true;                    
                    if (tbTipCam.Rows.Count > 0)
                    {
                        txtCambio.Text = Convert.ToString(tbTipCam.Rows[0]["nTipCamProVen"]);
                    }
                    else
                    {
                        MessageBox.Show("No existe Tipo de Cambio para la Fecha, POR FAVOR REGISTRAR", "Validar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCambio.Text = "0.00";
                        return;
                    }
                }
                else
                {
                    lblCambio.Visible = false;
                    txtCambio.Visible = false;
                    txtCambio.Text = "";
                }
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpFechaEmision.Value.Date;
            DateTime dFecFin = dtpFechaEmision.Value.Date;
            int idModulo = 3;
            decimal nTipCambio = clsVarApl.dicVarGen["nTipoCambio"];
            int nCuenta = Convert.ToInt32(txtCodigo.Text);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("x_dfecini", dFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString(), false));
            paramlist.Add(new ReportParameter("x_idCuenta", nCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("x_TipoCambio", nTipCambio.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsAsientoCuenta", new clsRPTCNContabilidad().CNAsientoTRX(dFecIni, dFecFin, nCuenta, idModulo)));

            string reportpath = "RptAsientoTrx.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private bool ValidarRespCajChica()
        {
            bool valRespCajChi = false;
            DataTable dtRespCajaChica = objCajaChica.BuscarCajChicResp(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtRespCajaChica.Rows.Count <= 0)
            {
                valRespCajChi = true;
            }
            return valRespCajChi;
        }
        private void grbDetalleCompr_Enter(object sender, EventArgs e)
        {

        }
        private bool ValidarCajaChica(int idResCajChi, int idAgencia)
        {
            dtDatosCajChica = objCajaChica.RetDatCajChic(idResCajChi, idAgencia);
            if (dtDatosCajChica.Rows.Count <= 0)
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
            int nrocajachica = Convert.ToInt16(dtDatosCajChica.Rows[0]["idcajchica"]);
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
            if (nrocajachica !=Convert.ToInt16(cboCajaChica.SelectedValue))
            {
                MessageBox.Show("Ud. no es responsable de la caja chica seleccionada, seleccione la caja chica correcta. Por favor.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //if (nIdEstCajaChica == 3)
            //{
            //    MessageBox.Show("Caja Chica Cerrada, No puede registrar comprobantes.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            return true;
        }
    }
}
