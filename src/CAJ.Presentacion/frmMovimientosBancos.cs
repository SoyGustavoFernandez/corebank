using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using System.Xml.Linq;
using EntityLayer;
namespace CAJ.Presentacion
{
    public partial class frmMovimientosBancos : frmBase
    {
        int pidCuentaInstitucion, pidMovimiento;
        clsCNMovimientoBanco objMovBco = new clsCNMovimientoBanco();
        DataTable dtTipoOpeMovBco, dtCmp;
        public frmMovimientosBancos()
        {
            InitializeComponent();          
        }
        #region eventos
        private void frmMovimientosBancos_Load(object sender, EventArgs e)
        {
            
            habilitarControles(grbDatosCuenta, false);
            habilitarControles(grbDatosMovimiento,false);            
            habilitarControles(grbCliente, false);
            habilitarControles(grbCapInt, false);
            cboMotOperacionBco.cargarMotivoOperacion(0);
            habilitarBotones(3);
            cargarTipoIdentificado();
            cargarTipoDocumento();
            cboTipoPago.SelectedIndexChanged -= new EventHandler(cboTipoPago_SelectedIndexChanged);
            CargarTipoPago();
            cboTipoPago.SelectedIndexChanged += new EventHandler(cboTipoPago_SelectedIndexChanged);
            cargarTipoOperMovBanco();

            cboMoneda.SelectedValue = -1;

            cboTipoPago.SelectedIndexChanged -= new EventHandler(cboTipoPago_SelectedIndexChanged);
            cboTipoPago.SelectedValue = -1;
            cboTipoPago.SelectedIndexChanged += new EventHandler(cboTipoPago_SelectedIndexChanged);

            cboMotOperacionBco.SelectedValue = -1;
            
            cboMedioPagoSunat.SelectedIndexChanged -= new EventHandler(cboMedioPagoSunat_SelectedIndexChanged);
            cboMedioPagoSunat.SelectedValue = -1;
            cboMedioPagoSunat.SelectedIndexChanged += new EventHandler(cboMedioPagoSunat_SelectedIndexChanged);
        }        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pidMovimiento = -1;
            habilitarControles(grbDatosMovimiento, true);
            habilitarControles(grbCapInt, true);
            habilitarBotones(2);
            limpiarControles();
            txtMontoOperac.ReadOnly = false;
            dtgMovimientos.Enabled = false;            
            cboMoneda.Enabled = false;
            cboTipoDestino.Enabled = false;
            txtTEA.Enabled = false;
            
            grbCapInt.Enabled = true;
            cboMedioPagoSunat.Enabled = true;
            dtpfechaOperac.Value = clsVarGlobal.dFecSystem;
            cboTipoDocumentoBco.SelectedValue = 0;
            if (rbtInteres.Checked)
            {
                rbtInteres_CheckedChanged(sender,e);               
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {   
            if (dtgMovimientos.RowCount>0)
            {
                habilitarControles(grbDatosMovimiento, true);
                habilitarControles(grbCapInt, true);
                txtMontoOperac.ReadOnly = true;
                habilitarBotones(2);
                dtgMovimientos.Enabled = false;                
                txtTEA.Enabled = false;
                asignarDatos();
                if (cboTipoOperacionBco.SelectedValue.ToString() == "2")
                {
                        cboTipoDestino.Enabled = false;
                        btnBusquedaDestino.Enabled = false;
                }
                else if (cboTipoOperacionBco.SelectedValue.ToString() == "1")
                {
                    cboTipoDestino.Enabled = true;
                    btnBusquedaDestino.Enabled = true;
                }
                
                grbCapInt.Enabled = false;
                cboMoneda.Enabled = false;
                cboTipoMotOpeBco.Enabled = false;
                cboMedioPagoSunat.Enabled = false;
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarRegistro())
            {
                DataTable dtSaldos = new DataTable();
                dtSaldos = objMovBco.grabarMovimientoBancos(convertXml(), dtpfechaOperac.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda.SelectedValue));
                if (dtSaldos.Rows.Count > 0)
                {
                    DataRow row = dtSaldos.Rows[0];
                    txtSaldoContable.Text = row["nSaldoContable"].ToString();
                    txtSaldoDisponible.Text = row["nSaldoDisponible"].ToString();
                }
                MessageBox.Show("Movimiento Grabado Correctamente", "Movimiento Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarControles(grbDatosMovimiento, false);
                habilitarBotones(1);
                cargarDataGridMovimiento();
                dtgMovimientos.Enabled = true;
                asignarDatos();
               
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDatosMovimiento, false);
            habilitarControles(grbCapInt, false);
            habilitarBotones(1);
            asignarDatos();
            btnBusquedaDestino.Enabled = false;
            dtgMovimientos.Enabled = true;
        }
        private void btnBusCtaBco_Click(object sender, EventArgs e)
        {
            
            frmBusquedaCuentaInst buscar = new frmBusquedaCuentaInst();
            buscar.ShowDialog();

            if (buscar.pidCuentaInstitucion == 0) return;
            txtSaldoContable.Text= buscar.pcSaldoContable;
            txtSaldoDisponible.Text = buscar.pcSaldoDisponible;
            txtNroCuenta.Text = buscar.pcNumeroCuenta;
            pidCuentaInstitucion=buscar.pidCuentaInstitucion;            
            cboEntidad.CargarEntidades(buscar.pidTipoEntidad);
            cboEntidad.SelectedValue = buscar.pidEntidad;
            cboMoneda.SelectedValue = buscar.pidMoneda;
            cboTipoCuentaBco.SelectedValue = buscar.pidTipoCuenta;
            txtTEA.Text = buscar.pcTEA;
            habilitarBotones(1);
            cargarDataGridMovimiento();
            asignarDatos();
            btnBusquedaDestino.Enabled = false;
        }

        private void btnBusquedaDestino_Click(object sender, EventArgs e)
        {
            FrmBusCli cliente = new FrmBusCli();
            cliente.ShowDialog();
            txtCodigo.Text = cliente.pcCodCli;
            txtCliente.Text = cliente.pcNomCli;
        }
       
        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (dtgMovimientos.RowCount > 0)
            {

                if (MessageBox.Show("¿Esta Seguro de Extornar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    decimal nMontoOpe;
                    nMontoOpe = Convert.ToDecimal(txtMontoOperac.Text);
                    DataTable dtSaldos = new DataTable();
                    dtSaldos = objMovBco.ExtornarMovimientoBancos(pidMovimiento, pidCuentaInstitucion, nMontoOpe);
                    if (Convert.ToInt16(dtSaldos.Rows[0]["idRpta"])==0)
                    {
                        MessageBox.Show("la Operacion Fue Extornada Correctamente", "Extorno de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataRow row = dtSaldos.Rows[0];
                        txtSaldoContable.Text = row["nSaldocontable"].ToString();
                        txtSaldoDisponible.Text = row["nSaldoDisponible"].ToString();
                        cargarDataGridMovimiento();
                        asignarDatos();
                    }
                    else
                    {
                        MessageBox.Show(dtSaldos.Rows[0]["cMensaje"].ToString(), "Extorno de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
            }
        }
        private void cboTipoOperacionBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoOperacionBco.SelectedIndex != -1)
            {
                if (cboTipoOperacionBco.SelectedValue.ToString() == "2" && btnGrabar.Enabled == true)
                {
                    cboTipoDestino.SelectedValue = 0;
                    cboTipoDestino.Enabled = false;
                    btnBusquedaDestino.Enabled = false;
                }
                else if (cboTipoOperacionBco.SelectedValue.ToString() == "1" && grbDatosMovimiento.Enabled == true)
                {
                    if (dtTipoOpeMovBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "1")//transaccion de ingreso
                    {
                        cboTipoDestino.SelectedValue = 2;
                    }
                    else if (dtTipoOpeMovBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "2")//transaccion de Egreso
                    {
                        cboTipoDestino.SelectedValue = 1;
                    }
                    if (btnGrabar.Enabled == true)
                    {
                        cboTipoDestino.Enabled = true;
                    }
                    btnBusquedaDestino.Enabled = true;
                }
            }
        }
        private void dtgMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            asignarDatos();
        }
       
        #endregion
        #region Metodos
        private void habilitarBotones(int nOpcion)
        {
            if (nOpcion == 1)
            {//nuevo o editar
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnExtorno.Enabled = true;
                btnBusCtaBco.Enabled = true;
                btnBusquedaDestino.Enabled = false;
                txtNroConciliaBco.Enabled = false;
            }
            else if (nOpcion == 2)//cancelar o Grabar 
            {
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                btnExtorno.Enabled = false;
                btnBusCtaBco.Enabled = false;
                btnBusquedaDestino.Enabled = true;
                chcVerificarFecha.Checked = false;
                btnProcesar1.Enabled = false;
                dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                dtpFechaFin.Value = clsVarGlobal.dFecSystem;
                txtNroConciliaBco.Enabled = true;
            }
            else if (nOpcion == 3)// inicio
            {
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnExtorno.Enabled = false;
                btnBusquedaDestino.Enabled = false;
                chcVerificarFecha.Checked = false;
                btnProcesar1.Enabled = false;
                dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
                dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            }
        }
        private void cargarDataGridMovimiento()
        {
            int idEntidad;
            string cNumeroCuenta;
            idEntidad = Convert.ToInt32(cboEntidad.SelectedValue);
            cNumeroCuenta = txtNroCuenta.Text;
            DateTime dFechaIni = dtpFechaInicio.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            Boolean lFiltroFecha = chcVerificarFecha.Checked;


            dtgMovimientos.SelectionChanged-= new EventHandler(dtgMovimientos_SelectionChanged);

            dtgMovimientos.DataSource = objMovBco.listarMovimientos(idEntidad, cNumeroCuenta, dFechaIni, dFechaFin, lFiltroFecha);
                        
            dtgMovimientos.Columns[1].Visible = false;
            dtgMovimientos.Columns[2].Visible = false;
            dtgMovimientos.Columns[3].Visible = false;
            dtgMovimientos.Columns[4].Visible = false;

            dtgMovimientos.Columns[8].Visible = false;
            dtgMovimientos.Columns[9].Visible = false;

            dtgMovimientos.Columns[13].Visible = false;
            dtgMovimientos.Columns[14].Visible = false;
            dtgMovimientos.Columns[15].Visible = false;
            dtgMovimientos.Columns[16].Visible = false;
            dtgMovimientos.Columns[17].Visible = false;
            dtgMovimientos.Columns[18].Visible = false;
            dtgMovimientos.Columns[19].Visible = false;
            dtgMovimientos.Columns[20].Visible = false;
            
            dtgMovimientos.Columns[0].Width = 60;
            dtgMovimientos.Columns[5].Width= 150;
            dtgMovimientos.Columns[6].Width = 80;
            dtgMovimientos.Columns[7].Width = 98;

            dtgMovimientos.Columns[10].Width = 98;
            dtgMovimientos.Columns[11].Width = 80;
            dtgMovimientos.Columns[12].Width = 115;
            dtgMovimientos.Columns[21].Width = 60;

            dtgMovimientos.Columns[0].HeaderText = "N° Mov. Bco";
            dtgMovimientos.Columns[21].HeaderText = "N° Ope Conciliar";

            dtgMovimientos.SelectionChanged += new EventHandler(dtgMovimientos_SelectionChanged);
        }
        private void asignarDatos()
        {
            if (dtgMovimientos.Rows.Count > 0)
            {
                cboMedioPagoSunat.SelectedIndexChanged -= new EventHandler(cboMedioPagoSunat_SelectedIndexChanged);
                pidMovimiento = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                cboMotOperacionBco.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
                cboMedioPagoSunat.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
                cboTipoMotOpeBco.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[17].Value.ToString());
                cboMoneda.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[4].Value.ToString());
                txtMontoOperac.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[7].Value.ToString();
                txtConcepto.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[10].Value.ToString();
                dtpfechaOperac.Value = Convert.ToDateTime(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[11].Value.ToString());
                txtDocumento.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[14].Value.ToString();
                cboTipoDestino.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[9].Value.ToString());
                cboTipoOperacionBco.SelectedValue = Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[8].Value.ToString());
                txtCodigo.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[16].Value.ToString();
                txtCliente.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[15].Value.ToString();
                cboTipoDocumentoBco.SelectedValue = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[13].Value.ToString();
                txtTEA.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[18].Value.ToString();

                EstableceCapitalOInteres(Convert.ToInt32(dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[19].Value.ToString()));

                cboTipoPago.SelectedValue = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[20].Value.ToString();
                cboMedioPagoSunat.SelectedIndexChanged += new EventHandler(cboMedioPagoSunat_SelectedIndexChanged);

                txtNroConciliaBco.Text = dtgMovimientos.Rows[dtgMovimientos.SelectedCells[0].RowIndex].Cells[21].Value.ToString();
            }
            else
            {
                limpiarControles();
            }
        }
        public void EstableceCapitalOInteres(int idTipoCapInt)
        {   
            rbtCapital.CheckedChanged -= new EventHandler(rbtCapital_CheckedChanged);
            rbtInteres.CheckedChanged -= new EventHandler(rbtInteres_CheckedChanged);
            if (idTipoCapInt == 1)
            {
                rbtCapital.Checked = true;
                rbtInteres.Checked = false;
            }
            else if (idTipoCapInt == 2)
            {
                rbtCapital.Checked = false;
                rbtInteres.Checked = true;
            }
            rbtCapital.CheckedChanged += new EventHandler(rbtCapital_CheckedChanged);
            rbtInteres.CheckedChanged += new EventHandler(rbtInteres_CheckedChanged);
        }
        private void limpiarControles()
        {
            txtDocumento.Clear();
            txtMontoOperac.Clear();
            txtConcepto.Clear();
            txtCodigo.Clear();
            txtCliente.Clear();
            txtTEA.Clear();
            cboMotOperacionBco.SelectedIndex = -1;
            cboMedioPagoSunat.SelectedIndex = -1;
            cboTipoOperacionBco.SelectedIndex = -1;
            cboTipoMotOpeBco.SelectedIndex = -1;
            cboTipoDestino.SelectedIndex = -1;
            cboTipoPago.SelectedIndex = -1;
            cboTipoDocumentoBco.SelectedIndex = -1;
        }
        private void cargarTipoIdentificado()
        {
            cboTipoOperacionBco.DataSource = objMovBco.CNListarTiposIdentificadosBanco();
            cboTipoOperacionBco.DisplayMember = "cDescripcion";
            cboTipoOperacionBco.ValueMember = "idTipoOpeBco";
        }
        private void cargarTipoOperMovBanco()
        {
            dtTipoOpeMovBco = objMovBco.listarTipoOperMovBanco();
            cboTipoMotOpeBco.DataSource = dtTipoOpeMovBco;
            cboTipoMotOpeBco.ValueMember = "idTipOpeMovBco";
            cboTipoMotOpeBco.DisplayMember="cTipoOperacion";
        }

        private void cargarTipoDocumento()
        {
            cboTipoDocumentoBco.DataSource = objMovBco.ListarTipoDocumentoBanco();
            cboTipoDocumentoBco.DisplayMember = "cDescripcion";
            cboTipoDocumentoBco.ValueMember = "idTipoDocBco";
        }
        private string convertXml()
        {
            int idCliente = 0, idMotOpeBanco = 0, idTipOpeMovBco = 0;
            int idTipMedPago = 0, idTipoDocumento = 0, idTipoOperaBco = 0, idTipoDestino = 0;
            decimal nMontoOpera;            
            DateTime dfechaOpe;
            string cDescripcion, cNroDocumento;
            int nTipMovCapInt, idTipoPago;

            idMotOpeBanco   = Convert.ToInt32(cboMotOperacionBco.SelectedValue);
            idTipOpeMovBco = Convert.ToInt32(cboTipoMotOpeBco.SelectedValue);
            idTipMedPago    = Convert.ToInt32(cboMedioPagoSunat.SelectedValue);
            nMontoOpera     = Convert.ToDecimal(txtMontoOperac.Text);
            idTipoOperaBco  = Convert.ToInt32(cboTipoOperacionBco.SelectedValue);
            idTipoDestino   = Convert.ToInt32(cboTipoDestino.SelectedValue);

            idCliente       =txtCodigo.Text.Trim()==""? 0:Convert.ToInt32(txtCodigo.Text);            
            cDescripcion    = txtConcepto.Text;
            dfechaOpe       = dtpfechaOperac.Value;
            idTipoDocumento = Convert.ToInt32(cboTipoDocumentoBco.SelectedValue);            
            cNroDocumento   = txtDocumento.Text;
            nTipMovCapInt   =(rbtCapital.Checked)?1:2;
            idTipoPago      = Convert.ToInt32(cboTipoPago.SelectedValue);
            string cNroConciliaBcos = txtNroConciliaBco.Text;

            string xmlMovimiento = clsCNFormatoXML.EncodingXML(objMovBco.convertMovimientoXml(pidMovimiento, pidCuentaInstitucion, idMotOpeBanco, idTipOpeMovBco, idTipMedPago, nMontoOpera, idTipoOperaBco, idTipoDestino, idCliente, cDescripcion, dfechaOpe, idTipoDocumento, cNroDocumento, nTipMovCapInt, idTipoPago, cNroConciliaBcos));
            return xmlMovimiento;            
        }
        private bool validarRegistro()
        {
            bool valida = true;
            int nContApertura = 0;

            foreach (DataGridViewRow row in dtgMovimientos.Rows)
            {
                if (Convert.ToInt32(row.Cells["idTipOpeMovBco"].Value) == 1)
                {
                    nContApertura++; 
                }
            }

            if (cboTipoOperacionBco.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de operacion del movimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipoOperacionBco.Focus();
                valida = false;
            }else if (cboTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la modalidad de la operacion del movimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipoPago.Focus();
                valida = false;
            }else if (cboMedioPagoSunat.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el medio de pago de la SUNAT del movimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMedioPagoSunat.Focus();
                valida = false;
            }else if (cboTipoDocumentoBco.SelectedIndex == -1 || string.IsNullOrEmpty(cboTipoDocumentoBco.Text))
            {
                MessageBox.Show("Seleccione el tipo de documento del movimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipoDocumentoBco.Focus();
                valida = false;
            }else if (txtMontoOperac.Text.Trim() == "" || Convert.ToDecimal(txtMontoOperac.Text) == 0)
            {
                MessageBox.Show("Debe Ingresar Monto de Operación Mayor a Cero","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtMontoOperac.Focus();
                valida = false ;
            }
            else if(txtConcepto.Text.Trim().Length<=5)
            {
                MessageBox.Show("Debe Ingresar un Concepto Valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConcepto.Focus();
                valida = false;
            }
            else if (Convert.ToInt32(cboTipoOperacionBco.SelectedValue) == 1 && (cboTipoDestino.SelectedIndex == -1 || string.IsNullOrEmpty(cboTipoDestino.Text)))
            {
                MessageBox.Show("Seleccione el Tipo de destino del Movimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoDestino.Focus();
                valida = false;
            }
            else if(txtCodigo.Text.Trim() == "" && Convert.ToInt32(cboTipoOperacionBco.SelectedValue)==1)
            {
                MessageBox.Show("Debe Ingresar Beneficiario/Girador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                valida = false;
            }
            else if (Convert.ToInt32(cboTipoOperacionBco.SelectedValue) == 1 && !(cboTipoDestino.SelectedIndex == -1 || string.IsNullOrEmpty(cboTipoDestino.Text))
                    && (txtCodigo.Text.Trim() == "0" || txtCodigo.Text.Trim() == ""))
            {
                MessageBox.Show("Seleccione un Beneficiario/Girador", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                valida = false;
            }
            else if (nContApertura>0 && Convert.ToInt32(cboTipoMotOpeBco.SelectedValue) == 1)
            {
                MessageBox.Show("Solo puede existir una operacion de apertura por cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoOperacionBco.Focus();
                valida = false;
            }
            else if (Convert.ToInt32(cboMotOperacionBco.SelectedValue) == 101)
            {
                if (string.IsNullOrEmpty(txtNroConciliaBco.Text))
                {
                    MessageBox.Show("El concepto seleccionado es Detracciones Dólares, el Nro de comprobante ingresado no es valido", "Detracciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    valida = false;
                }
                else
                {
                    int idComprobante = Convert.ToInt32(txtNroConciliaBco.Text);
                    if (Convert.ToInt32(cboTipoMotOpeBco.SelectedValue)==2)
                    {
                        dtCmp = new clsCNCajaChica().BuscarRegVenta(idComprobante);
                    }
                    else if (Convert.ToInt32(cboTipoMotOpeBco.SelectedValue) == 3)
                    {
                        dtCmp = new clsCNCajaChica().BuscarComprPago(idComprobante);
                    }
                }
                if (dtCmp.Rows.Count == 0)
                {
                    MessageBox.Show("El concepto seleccionado es detracciones, el Nro de comprobante ingresado no existe", "Detracciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    valida = false;
                }
                else if (Convert.ToInt32(dtCmp.Rows[0]["idMoneda"])==1)
                {
                    MessageBox.Show("El comprobante es en soles selecciones el concepto DETRACCIONES", "Detracciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    valida = false;
                }
                else if (Convert.ToInt32(cboTipoMotOpeBco.SelectedValue)==2)
                {
                    if (Convert.ToDecimal(dtCmp.Rows[0]["nMontoDetraccion"]) == 0)
                    {
                        MessageBox.Show("El comprobante no tiene detracciones por pagar", "Detracciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        valida = false;
                    }
                }
                else if (Convert.ToInt32(cboTipoMotOpeBco.SelectedValue) == 3)
                {
                    if (Convert.ToDecimal(dtCmp.Rows[0]["nTotalDetraccion"]) == 0)
                    {
                        MessageBox.Show("El comprobante no tiene detracciones por pagar", "Detracciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        valida = false;
                    }
                }
            }

            //if ((int)cboTipoPago.SelectedValue == 2)  //--Transferencia Interna
            //{
            //    MessageBox.Show("Este Tipo de Pago, no puede realizar en Movimiento de Bancos  \n Realizar este tipo de pago desde Pago de Comprobantes",
            //                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.cboTipoPago.Focus();
            //    valida = false;
            //}

            //if ((int)cboTipoPago.SelectedValue == 6)  //--Cheuqe Gerencia
            //{
            //    MessageBox.Show("Este Tipo de Pago, no puede realizar en Movimiento de Bancos  \n Realizar este tipo de pago desde la Valorización de Cheques", 
            //                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.cboTipoPago.Focus();
            //    valida = false;
            //}

            return valida;
        }
        private void validaTipoTransac()
        {
            if (cboTipoOperacionBco.SelectedIndex != -1)
            {
                if (Convert.ToInt32(cboTipoOperacionBco.SelectedValue) == 1)//operacion identificada
                {
                    if (cboTipoMotOpeBco.SelectedIndex != -1)
                    {

                        if (dtTipoOpeMovBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "1")//transaccion de ingreso
                        {
                            cboTipoDestino.SelectedValue = 2;
                        }
                        else if (dtTipoOpeMovBco.Rows[cboTipoMotOpeBco.SelectedIndex]["idTipoTransac"].ToString() == "2")//transaccion de Egreso
                        {
                            cboTipoDestino.SelectedValue = 1;
                        }
                    }
                }
                else if (Convert.ToInt32(cboTipoOperacionBco.SelectedValue) == 0)
                {
                    cboTipoDestino.SelectedValue = 0;
                }
            }
        }
        #endregion
        //==========================================================
        //--Cargar Modalidad de Operacion(Tipo de Pago)
        //==========================================================
        private void CargarTipoPago()
        {
            GEN.CapaNegocio.clsCNTipoPago objTipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable ListaTipoPago = objTipoPago.CNListaTipPagOpeBanco();
            cboTipoPago.DataSource = ListaTipoPago;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";
        }

        private void cboMedioPagoSunat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedioPagoSunat.SelectedIndex == -1) return;
            if (cboMedioPagoSunat.Items.Count > 0)
            {
                if (Convert.ToInt32(cboMedioPagoSunat.SelectedValue.ToString()) == 1)
                {
                    //solo para deposito
                    cboTipoOperacionBco.Enabled = true;
                }
                else
                {
                    cboTipoOperacionBco.Enabled = false;
                    cboTipoMotOpeBco.SelectedValue = 1;
                    cboTipoOperacionBco.SelectedValue = 1;
                }
            }
        }

        private void cboTipoMotOpeBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoMotOpeBco.SelectedIndex == -1) return;
            validaTipoTransac();
        }

        private void rbtInteres_CheckedChanged(object sender, EventArgs e)
        {
            cboTipoMotOpeBco.SelectedValue = 2;
            cboTipoMotOpeBco.Enabled = false;
        }

        private void rbtCapital_CheckedChanged(object sender, EventArgs e)
        {
            cboTipoMotOpeBco.Enabled = true;
        }

        private void dtgMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            asignarDatos();
        }

        private void chcVerificarCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chcVerificarFecha.Checked)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFin.Enabled = true;
                btnProcesar1.Enabled = true;
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFin.Enabled = false;
                btnProcesar1.Enabled = false;
            }
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (!ValidaFiltrarFecha())
            {
                return;
            }
            cargarDataGridMovimiento();
            asignarDatos();                        
        }
        private bool ValidaFiltrarFecha()
        {
            bool lvalor = true;

            if (dtpFechaFin.Value < dtpFechaInicio.Value )
            {
                MessageBox.Show("La Fecha de Fin debe ser MAYOR a la Fecha de Inicio", "Movimiento Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalor = false;
            }
            if (Convert.ToInt32(cboEntidad.SelectedValue) < 0 || string.IsNullOrEmpty(cboEntidad.Text))
	        {
		        MessageBox.Show("Seleccione la Cuenta de Bancos", "Movimiento Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalor = false; 
	        }
            return lvalor;
        }

        private void cboTipoPago_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 || Convert.ToInt32(cboTipoPago.SelectedValue) == 6)
            {
                cboTipoDocumentoBco.SelectedValue = 2;
            }
            else
            {
                cboTipoDocumentoBco.SelectedValue = 1;
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 || Convert.ToInt32(cboTipoPago.SelectedValue) == 6)
            {
                cboTipoDocumentoBco.SelectedValue = 2;
            }
            else
            {
                cboTipoDocumentoBco.SelectedValue = 1;
            }
        }
    }
}
