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
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
namespace CAJ.Presentacion
{
    public partial class frmPagoComprobantesCNT : frmBase
    {
        #region Variables
        clsCNCajaChica objComprobante = new clsCNCajaChica();
        clsCNComprobantes objCpg = new clsCNComprobantes();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsListaTipoComisionesCpg lstTipoComision = new clsListaTipoComisionesCpg();
        clsListaApruebaCPGPago lstAprobador = new clsListaApruebaCPGPago();
        DataTable dtComprPago;
        DataTable dtComprPagoCheque;
        decimal nValRetIgv = 0;
        decimal nMontoPag = 0;
        #endregion
        
        #region Eventos

        public frmPagoComprobantesCNT()
        {
            InitializeComponent();
        }
        private void frmPagoComprobantes_Load(object sender, EventArgs e)
        {
            conBusCli.txtCodCli.Enabled = false;
            conBusCli.btnBusCliente.Enabled = false;
            LimpiarDatos();
            habilitarBotones(0);
            CargarTipoPago();
            habilitarControl(0);

            DataTable Destinos = objComprobante.ListarDestinoComprPago(clsVarGlobal.nIdAgencia);
            cboDestino.DataSource = Destinos;
            cboDestino.ValueMember = "idDetinoComprPago";
            cboDestino.DisplayMember = "cDescripcion";
            cboDestino.SelectedIndex = -1;
        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            int nidComprobantePago = 0;
            //=======================================================================
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPago frmBusqCompPago = new frmBuscarComprPago();
            frmBusqCompPago.chcTieneComprobante.Checked = true;
            frmBusqCompPago.ShowDialog();
            nidComprobantePago = frmBusqCompPago.pidComprobantePago;
            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //=======================================================================
            //--Buscar Comprobantes
            //=======================================================================
            BuscarComprobante(nidComprobantePago);
            BuscaChequeComprobante(nidComprobantePago);
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
                    LimpiarDatos();
                    MessageBox.Show("Ingrese Codigo de Comprobante Valido", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BuscarComprobante(Convert.ToInt32(txtCodigo.Text));
                BuscaChequeComprobante(Convert.ToInt32(txtCodigo.Text));
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotones(3);
            if (string.IsNullOrEmpty(txtNroCheque.Text))
            {
                habilitarControl(1);
            }
            else
            {
                habilitarControl(2);
            }            
            FormatoGrids();
            FormatoGridAprobador();

            DataTable dtConfigCompr = objComprobante.RetConfigTipoComp(Convert.ToInt32(cboTipoComprobantePago.SelectedValue));
            if (dtConfigCompr.Rows.Count > 0)
            {
                nValRetIgv = Convert.ToDecimal(dtConfigCompr.Rows[0]["nValRetIGV"].ToString());
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            int idComprobante = Convert.ToInt32(txtCodigo.Text);
            decimal nMontoComprobante = Convert.ToDecimal(txtTotCompro.Text);
            decimal nTotalOtrosDscts = Convert.ToDecimal(txtTotOtrosDesc.Text);
            decimal nTotalComisiones = Convert.ToDecimal(txtTotComision.Text);
            bool lIndAfecRetIGV = chcRetIGV.Checked;
            decimal nRetncionIgv = Convert.ToDecimal(txtRetIGV.Text);
            decimal nImportePagado = Convert.ToDecimal(txtMontoPagar.Text);
            decimal nMontoITF = Convert.ToDecimal(txtMontoITF.Text);
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            DateTime dFechaPag = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaPagoAnt"].ToString());
            int idUsuario = Convert.ToInt32(dtComprPago.Rows[0]["idUsuRegAnt"].ToString());
            int idAgencia = Convert.ToInt32(dtComprPago.Rows[0]["idAgencia"].ToString());
            int idTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue);
            int idEntidad = Convert.ToInt32(cboEntidad.SelectedValue);
            int idCuentaIFI = Convert.ToInt32(cboCuenta.SelectedValue);

            string x_cNroCuenta = "";

            switch (idTipoPago)
            {
                case 1:
                    break;
                case 2: //--Transferencias
                    x_cNroCuenta = cboCuenta.Text;
                    break;
                case 3: //--Cheques Externos
                    x_cNroCuenta = txtNroCta.Text;
                    break;
                case 4: //--Interbancarios
                    x_cNroCuenta = txtNroCta.Text;
                    break;
                case 6: //--Cheque Interno
                    x_cNroCuenta = cboCuenta.Text;
                    break;
                default:
                    break;
            }
            string cNroCheque = txtNroCheque.Text.Trim();
            string xmlComisiones = lstTipoComision.obtenerXml();
            string xmlAprobador = lstAprobador.obtenerXml();

			//=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Inicio - Pago de Comprobantes", btnGrabar);
            //==============================================================================

            //-----------------------------------------------------------------------------
            //--valida Saldos de Caja
            //-----------------------------------------------------------------------------
            //if (Convert.ToInt16(cboTipoPago.SelectedValue) == 1)
            //{
            //    if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 2, nImportePagado))
            //    {
            //        return;
            //    }
            //}

            bool lModificaSaldoLinea = false;
            DateTime dfechaOpe = clsVarGlobal.dFecSystem;
            int idTipoTransac = 0;

            DataTable result = objCpg.GrabarPagoComprobantes(idComprobante, nMontoComprobante, nTotalOtrosDscts, nTotalComisiones, lIndAfecRetIGV, nRetncionIgv, nImportePagado, nMontoITF, idMoneda,
                                                        dFechaPag, idUsuario, idAgencia, idTipoPago,
                                                        idEntidad, idCuentaIFI, cNroCheque, xmlComisiones, xmlAprobador, x_cNroCuenta, idTipoTransac, dfechaOpe, lModificaSaldoLinea);

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Fin - Pago de Comprobantes", btnGrabar);
            //============================================================================
            habilitarBotones(2);
            if (result.Rows[0]["idMsje"].ToString() == "1")
            {
                //-----------------------------------------------------------------------------
                ////--actualiza Saldos de Caja
                ////-----------------------------------------------------------------------------
                //if (Convert.ToInt16(cboTipoPago.SelectedValue) == 1)
                //{
                //    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt16(cboMoneda.SelectedValue), 2, nImportePagado);
                //}

                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnExtorno.Enabled = true;
                dtpFechaPago.Enabled = false;
                grbDetPago.Enabled = false;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(0);
            habilitarControl(0);
            lstAprobador.Clear();
            txtCodigo.Enabled = true;
            btnBusqueda.Enabled = true;
            LimpiarDatos();
            txtCodigo.Clear();
            txtCodigo.Focus();
            dtgOtrosDescuentos.DataSource = "";
            dtgComisiones.DataSource = "";
            lstTipoComision.Clear();
            dtgAprobador.ReadOnly = true;
            grbDetPago.Visible = false;
            chcRetIGV.Checked = false;
            txtNroCta.Enabled = false;
            dtpFechaPago.Enabled = false;
            cboDestino.SelectedIndex = -1;

        }
        private void dtgComisiones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 6)
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextboxNumeric_KeyPress);
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
            }
        }
        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean nonNumberEntered;

            nonNumberEntered = true;

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {
                nonNumberEntered = false;
            }

            if (nonNumberEntered == true)
            {
                var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        private void dtgComisiones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgComisiones.RowCount <= 0)
            {
                return;
            }
            txtTotComision.Text = lstTipoComision.Sum(x => x.nMonto).ToString();
            //calcular monto a pagar
            CalcularMontoPagar();
        }
        private void dtgComisiones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgComisiones.Refresh();
        }
        private void dtgComisiones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex != 6)
                return;
            if (e.Exception.Message.ToString() == @"Input string was not in a correct format.")
            {
                e.ThrowException = false;
            }
        }
        private void dtgComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgComisiones.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgComisiones.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;

                var detalleSele = ((clsTipoComisionesComprobante)dtgComisiones.CurrentRow.DataBoundItem);

                if (isChecked)
                {
                    dtgComisiones.CurrentRow.Cells[3].ReadOnly = false;

                }
                else
                {
                    dtgComisiones.CurrentRow.Cells[3].ReadOnly = true;
                    detalleSele.nMonto = 0;
                }
                dtgComisiones.Refresh();
                txtTotComision.Text = lstTipoComision.Sum(y => y.nMonto).ToString();
                //calcular monto a pagar
                CalcularMontoPagar();
            }
        }
        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.DataSource == null || cboTipoPago.SelectedIndex <= -1 || cboTipoPago.Items.Count <= 0)
            {
                return;
            }
            try
            {
                DataTable dtEntidad;
                txtNroCta.Visible = false;
                lblCheque.Text = "Nro de Cheque:";
                txtNroCta.Clear();
                txtNroCheque.Clear();

                switch (Convert.ToInt32(cboTipoPago.SelectedValue.ToString()))
                {                        
                    case 1: //--Efectivo
                        lblCheque.Visible = false;
                        txtNroCheque.Visible = false;
                        lblCuenta.Visible = false;
                        grbDetPago.Visible = false;
                        break;
                    case 2: //--Transferencia Interna
                        lblCheque.Visible = false;
                        lblCuenta.Visible = true;
                        txtNroCheque.Visible = false;
                        grbDetPago.Visible = true;
                        cboCuenta.Visible = true;

                        dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));
                        cboEntidad.DataSource = dtEntidad;
                        cboEntidad.ValueMember = "idEntidad";
                        cboEntidad.DisplayMember = "cNombre";
                        break;
                    case 3: //--Cheque Externo
                        lblCheque.Text = "Nro de Cheque:";
                        txtNroCta.Visible = true;
                        lblCheque.Visible = true;
                        lblCuenta.Visible = true;
                        txtNroCheque.Visible = true;
                        cboCuenta.Visible = false;
                        grbDetPago.Visible = true;

                        dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue),0);
                        cboEntidad.DataSource = dtEntidad;
                        cboEntidad.ValueMember = "idEntidad";
                        cboEntidad.DisplayMember = "cNombre";
                        break;
                    case 4:  //--Interbancario
                        lblCheque.Text = "Nro Operación:";
                        txtNroCta.Visible = true;
                        lblCheque.Visible = true;
                        lblCuenta.Visible = true;
                        txtNroCheque.Visible = true;
                        cboCuenta.Visible = false;
                        grbDetPago.Visible = true;

                        dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue),0);
                        cboEntidad.DataSource = dtEntidad;
                        cboEntidad.ValueMember = "idEntidad";
                        cboEntidad.DisplayMember = "cNombre";
                        break;
                    case 6: //--Cheque de gerencia
                        lblCheque.Text = "Nro de Cheque:";
                        lblCheque.Visible = true;
                        lblCuenta.Visible = true;
                        txtNroCta.Visible = false;
                        txtNroCheque.Visible = true;
                        cboCuenta.Visible = true;
                        grbDetPago.Visible = true;

                        dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));
                        cboEntidad.DataSource = dtEntidad;
                        cboEntidad.ValueMember = "idEntidad";
                        cboEntidad.DisplayMember = "cNombre";
                        break;
                    default:
                        break;
                }
                //if (Convert.ToInt32(cboTipoPago.SelectedValue.ToString()) == 1)
                //{
                //    lblCheque.Visible = false;
                //    txtNroCheque.Visible = false;
                //    lblCuenta.Visible = false;
                //    grbDetPago.Visible = false;
                //}
                //else if (Convert.ToInt32(cboTipoPago.SelectedValue) == 2 || Convert.ToInt32(cboTipoPago.SelectedValue) == 4)
                //{
                //    lblCheque.Visible = false;
                //    lblCuenta.Visible = true;
                //    txtNroCheque.Visible = false;
                //    grbDetPago.Visible = true;
                //    cboCuenta.Visible = true;
                //    DataTable dtEntidad;
                //    dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue));
                //    cboEntidad.DataSource = dtEntidad;
                //    cboEntidad.ValueMember = "idEntidad";
                //    cboEntidad.DisplayMember = "cNombreCorto";
                //}
                //else if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 || Convert.ToInt32(cboTipoPago.SelectedValue) == 6)
                //{
                //    lblCheque.Visible = true;
                //    lblCuenta.Visible = true;

                //    txtNroCheque.Visible = true;
                //    cboCuenta.Visible = true;
                //    grbDetPago.Visible = true;

                //    DataTable dtEntidad;
                //    dtEntidad = objCpg.ListarEntidadesConCuenta(Convert.ToInt32(cboTipoPago.SelectedValue));
                //    cboEntidad.DataSource = dtEntidad;
                //    cboEntidad.ValueMember = "idEntidad";
                //    cboEntidad.DisplayMember = "cNombreCorto";
                //}
                cboEntidad.SelectedIndex = -1;
                cboCuenta.SelectedIndex = -1;
                txtNroCheque.Clear();



            }
            catch (Exception)
            {
            }

        }
        private void btnExtorno_Click(object sender, EventArgs e)
        {
            int idComprobante = Convert.ToInt32(txtCodigo.Text);
            string cSustento = "";
            //==================================================================
            //BUSCAR SOLICITUD DE EXTORNO.
            //==================================================================
            //DataTable dtSolicitud;
            //dtSolicitud = objCpg.buscarSolicitudExtorno(idComprobante, clsVarGlobal.User.idUsuario,
            //    clsVarGlobal.nIdAgencia);
            //int idEstadoApro = 0;

            //if (dtSolicitud.Rows.Count > 0)
            //{
            //    idEstadoApro = Convert.ToInt32(dtSolicitud.Rows[0]["idEstadoSol"].ToString());
            //    cSustento = dtSolicitud.Rows[0]["cSustento"].ToString();
            //    if (idEstadoApro == 1)
            //    {
            //        MessageBox.Show("ESPERANDO LA APROBACION DE LA SOLICITUD DE EXTONO Nº " + dtSolicitud.Rows[0]["idSolAproba"].ToString(), "Extornar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}

            //if (idEstadoApro == 0)
            //{
                InputBoxValidation validation = delegate(string val)
                {
                    if (val == "")
                        return "INGRESE MOTIVO DE EXTORNO..";
                    return "";
                };                
                if (InputBox("¿ESTA SEGURO DE EXTORNAR EL PAGO DEL" + "\r\n" + " COMPROBANTE?", "Extornar Pago de Comprobante", "Motivo de Extorno : ", ref cSustento, validation) == DialogResult.No)
                {
                    return;
                }
            //}
            //if (MessageBox.Show("SOLICITUD DE EXTONO Nº " + dtSolicitud.Rows[0]["idSolAproba"].ToString() + " FUE APROBADO " + "\r\n" + " ¿ESTA SEGURO DE EXTORNAR EL PAGO DE COMPROBANTE? ", "Extornar Pago de Comprobantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            //{
            //    return;

            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());            
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMontoPagar.Text);

            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Inicio - Extorno de Comprobantes", btnExtorno);
            //==============================================================================
            int idEstadoApro = 2;//aprobado

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0; //INGRESO

            DataTable result = objCpg.ExtornoPagoComprobantes(idComprobante, idEstadoApro, cSustento, Convert.ToDecimal(txtMontoPagar.Text),
                clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idMon, idTipoTransac, lModificaSaldoLinea);

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Fin - Extorno de Comprobantes", btnExtorno);
            //============================================================================

            if (result.Rows[0]["nResp"].ToString() == "1")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Extorno de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btnExtorno.Enabled = false;
                //btnEditar.Enabled = true;
                dtgOtrosDescuentos.DataSource = "";
                dtgComisiones.DataSource = "";
                lstTipoComision.Clear();
                BuscarComprobante(Convert.ToInt32(txtCodigo.Text));
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Extorno de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad.SelectedIndex == -1 || cboEntidad.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            dt = objCpg.ListarCuentaXEntidades(Convert.ToInt32(cboEntidad.SelectedValue), Convert.ToInt32(cboMoneda.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }
        private void chcRetIGV_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDestino.SelectedIndex <= -1)
            {
                return;
            }
            if (chcRetIGV.Checked == true)
            {
                if (Convert.ToInt32(cboDestino.SelectedValue) != 1)
                {
                    MessageBox.Show("La Operacion debe ser con Destino Gravado", "Calculo de Retencion de IGV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chcRetIGV.Checked = false;
                    txtRetIGV.Clear();
                    return;
                }
            }
            else
            {
                txtRetIGV.Text = "0";
            }
            CalcularMontoPagar();
        }
        public static DialogResult InputBox(string Texto, string title, string promptText, ref string value, InputBoxValidation validation)
        {
            Form form = new Form();
            Label lblTexto = new Label();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            PictureBox pxbImg = new PictureBox();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            lblTexto.Text = Texto;
            pxbImg.Image = Bitmap.FromHicon(SystemIcons.Question.Handle);

            buttonOk.Text = "YES";
            buttonCancel.Text = "NO";
            buttonOk.DialogResult = DialogResult.Yes;
            buttonCancel.DialogResult = DialogResult.No;
            pxbImg.SetBounds(10, 10, 40, 40);
            lblTexto.SetBounds(49, 12, 392, 13);
            label.SetBounds(50, 45, 382, 13);
            textBox.SetBounds(51, 60, 382, 20);

            buttonOk.SetBounds(228, 122, 75, 23);
            buttonCancel.SetBounds(309, 122, 75, 23);

            lblTexto.AutoSize = true;
            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            textBox.Multiline = true;
            textBox.Size = new Size(339, 53);

            form.ClientSize = new Size(406, 157);
            form.Controls.AddRange(new Control[] { pxbImg, lblTexto, label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(320, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            if (validation != null)
            {
                form.FormClosing += delegate(object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.Yes)
                    {
                        string errorText = validation(textBox.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validar Extorno de Comprobante",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Focus();
                        }
                    }
                };
            }

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }
        #endregion

        #region Metodos
      
        private void BuscarComprobante(int idComprobante)
        {
            //=======================================================================
            //--Buscar Datos del maestro y detalle 
            //=======================================================================
          
            dtComprPago = objComprobante.BuscarComprPago(idComprobante);
            if (dtComprPago.Rows.Count <= 0)
            {
                LimpiarDatos();
                MessageBox.Show("El Comprobante No Existe ...", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(dtComprPago.Rows[0]["nPagoCheque"]) > 0)
            {
                LimpiarDatos();
                MessageBox.Show("Comprobante registrado con pagó de cheque", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToBoolean(dtComprPago.Rows[0]["lCpgCajChica"]) == true)
            {
                LimpiarDatos();
                MessageBox.Show("El Comprobante Pertenece a Caja Chica...", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 3)
            {
                LimpiarDatos();
                MessageBox.Show("El Comprobante se encuentra en estado ANULADO...", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(dtComprPago.Rows[0]["lIsCierre"])==1)
            {
                LimpiarDatos();
                MessageBox.Show("El comprobante pertenece a un periodo contable cerrado", "Validar comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal ntipCamFij = clsVarApl.dicVarGen["nTipCamFij"];
            txtTipCamProm.Text = ntipCamFij.ToString();
            //=======================================================================
            //--Asignar valores a controles
            //=======================================================================
            conBusCli.txtCodCli.Text = dtComprPago.Rows[0]["idCliente"].ToString();
            conBusCli.CargardatosCli(Convert.ToInt32(conBusCli.txtCodCli.Text));

            txtCodigo.Text = dtComprPago.Rows[0]["idComprobantePago"].ToString();
            cboTipoComprobantePago.SelectedValue = dtComprPago.Rows[0]["idTipoComprobantePago"].ToString();
            cboMoneda.SelectedValue = dtComprPago.Rows[0]["idMoneda"].ToString();
            
            dtpFechaEmision.Value = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaEmision"].ToString());
            
            txtSerie.Text = dtComprPago.Rows[0]["cSerie"].ToString();
            txtNumero.Text = dtComprPago.Rows[0]["cNumero"].ToString();
            txtConceptoPago.Text = dtComprPago.Rows[0]["cGlosa"].ToString();
            txtRetIGV.Text = "0";
            cboDestino.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idDestino"].ToString());

            txtTotCompro.Text = (Convert.ToDecimal(dtComprPago.Rows[0]["nMonto"].ToString())).ToString(); //-- - Convert.ToDecimal(dtComprPago.Rows[0]["nTotalDetraccion"].ToString()) - Convert.ToDecimal(dtComprPago.Rows[0]["nTotCuartaCateg"].ToString())).ToString();
            txtSubTotal.Text = (Convert.ToDecimal(dtComprPago.Rows[0]["nSubTotal"].ToString())).ToString();
            txtMontoIgv.Text = (Convert.ToDecimal(dtComprPago.Rows[0]["nTotalIGV"].ToString())).ToString();
            txtRentaCuarta.Text = (Convert.ToDecimal(dtComprPago.Rows[0]["nTotCuartaCateg"].ToString())).ToString();
            txtDetraccion.Text = dtComprPago.Rows[0]["nTotalDetraccion"].ToString();

            txtTipoCambio.Text = dtComprPago.Rows[0]["nTipCambio"].ToString();
            
            //txtNroCta.Text = dtComprPago.Rows[0]["cNroCuenta"].ToString();

            if (string.IsNullOrEmpty(dtComprPago.Rows[0]["idTipoOperacionDetr"].ToString()))
            {
                rbtnSinDetraccion.Checked = true;
            }
            else
            {
                rbtnConDetraccion.Checked = true;
            }            

            OtrosDescuentos(idComprobante);
            txtCodigo.Enabled = false;
            btnBusqueda.Enabled = false;
            lstAprobador.Clear();
            habilitarControl(0);

            if (Convert.ToInt32(dtComprPago.Rows[0]["idEstadoComprobante"]) == 2)
            {
                MessageBox.Show("EL COMPROBANTE ESTA PAGADO...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                #region Carga Datos Comprobantes Pagados
                txtTotCompro.Text = dtComprPago.Rows[0]["nTotComprobante"].ToString();
                txtTotComision.Text = dtComprPago.Rows[0]["nTotComision"].ToString();
                txtTotOtrosDesc.Text = dtComprPago.Rows[0]["nTotDescuento"].ToString();
                txtRetIGV.Text = dtComprPago.Rows[0]["nRetIGV"].ToString();
                txtMontoITF.Text = dtComprPago.Rows[0]["nMontoITFPag"].ToString();
                txtNroCheque.Text = dtComprPago.Rows[0]["cNroCheque"].ToString();
                txtMontoPagar.Text = dtComprPago.Rows[0]["nMonto"].ToString();
                dtpFechaPago.Value = Convert.ToDateTime(dtComprPago.Rows[0]["dFechaPago"].ToString());
                cboTipoPago.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idTipoPago"].ToString());
                if (!string.IsNullOrEmpty(dtComprPago.Rows[0]["idEntidadFI"].ToString()))
                {
                    cboEntidad.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idEntidadFI"].ToString());
                }
                if (!string.IsNullOrEmpty(dtComprPago.Rows[0]["idCtaInstitucion"].ToString()))
                {
                    cboCuenta.SelectedValue = Convert.ToInt32(dtComprPago.Rows[0]["idCtaInstitucion"].ToString());
                }
                txtNroCheque.Text = dtComprPago.Rows[0]["cNroCheque"].ToString();
                txtNroCta.Text = dtComprPago.Rows[0]["cNroCuenta"].ToString();

                cboEntidad.Enabled = false;
                cboCuenta.Enabled = false;
                txtNroCheque.Enabled = false;
                DataTable resultComision = objCpg.BuscarComisionComproPagado(idComprobante);

                foreach (DataRow nRow in resultComision.Rows)
                {
                    lstTipoComision.Add(new clsTipoComisionesComprobante()
                    {
                        cComision = nRow["cDescripcion"].ToString(),
                        idComprobantePago = Convert.ToInt32(nRow["idComprobantePago"]),
                        idTipoComisionComprPago = Convert.ToInt32(nRow["IdComComprobante"]),
                        lOpcion = Convert.ToBoolean(nRow["lOpcion"]),
                        lVigente = Convert.ToBoolean(nRow["lVigente"]),
                        nMonto = Convert.ToDecimal(nRow["nMonto"])
                    }
                    );
                }
                dtgComisiones.DataSource = lstTipoComision;
                dtgComisiones.ReadOnly = true;
                dtgComisiones.Columns[2].ReadOnly = true;
                dtgComisiones.Columns[3].ReadOnly = true;

                DataTable resultAprobador = objCpg.BuscarAutorizaComproPagado(idComprobante);
                dtgAprobador.DataSource = "";
                foreach (DataRow nRow in resultAprobador.Rows)
                {
                    lstAprobador.Add(new clsApruebaCPGPago()
                    {
                        cAprobador = nRow["cNombre"].ToString(),
                        idAprobador = Convert.ToInt32(nRow["idUsuario"]),
                        lSeleccion = Convert.ToBoolean(nRow["lSelec"]),
                        lVigente = true
                    }
                    );
                }

                dtgAprobador.DataSource = lstAprobador;

                dtgAprobador.ReadOnly = true;
                habilitarBotones(2);
                #endregion
                //if (!chcBajaFecha.Checked)
                //{
                //    if (dtpFechaPago.Value.Date!=clsVarGlobal.dFecSystem)                
                //    {
                //        MessageBox.Show("El Comprobante Fue Pagado en otra Fecha", "Mensaje: Pago de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        btnExtorno.Enabled = false;
                //        return;
                //    }
                //    if (dtComprPago.Rows[0]["idUsuReg"].ToString() != clsVarGlobal.User.idUsuario.ToString())
                //    {
                //        MessageBox.Show("El Comprobante Fue Pagado Por otro Usuario", "Mensaje: Pago de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        btnExtorno.Enabled = false;
                //    }
                //}                
            }
            else
            {
                CargarTipoComisionCPG();
                //calcular monto a pagar
                CalcularMontoPagar();
                habilitarBotones(1);
                cboEntidad.Enabled = true;
                cboCuenta.Enabled = true;
                dtgComisiones.ReadOnly = true;
                dtgComisiones.Columns[2].ReadOnly = true;
                dtgComisiones.Columns[3].ReadOnly = true;
                //if (dtpFechaEmision.Value.Date != clsVarGlobal.dFecSystem)
                //{
                //    MessageBox.Show("El Comprobante Fue Registrado en otra Fecha", "Mensaje: Pago de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    btnEditar.Enabled = false;
                //}
            }

        }
        private void CalcularMontoPagar()
        {
            if (chcRetIGV.Checked)
            {
                txtRetIGV.Text = ((nValRetIgv / 100) * (Convert.ToDecimal(txtTotCompro.Text) - Convert.ToDecimal(txtTotOtrosDesc.Text) - Convert.ToDecimal(txtTotComision.Text))).ToString();
            }

            txtMontoPagar.Text = (Convert.ToDecimal(txtTotCompro.Text) - Convert.ToDecimal(txtTotOtrosDesc.Text) - Convert.ToDecimal(txtTotComision.Text) - Convert.ToDecimal(txtRetIGV.Text)).ToString();
            Decimal nMotoPagar = Convert.ToDecimal (txtMontoPagar.Text);
            if (cboMoneda.SelectedIndex <= -1)
            {
                return;
            }
            Decimal nItf;
            nItf = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMotoPagar, 2, (Int32)this.cboMoneda.SelectedValue);
            txtMontoITF.Text = nItf.ToString();
        }
        private void OtrosDescuentos(int idComprobante)
        {
            DataTable dtDescComprPago;
            dtgOtrosDescuentos.DataSource = "";
            dtDescComprPago = objComprobante.BuscarDescComprPago(idComprobante);
            dtgOtrosDescuentos.DataSource = dtDescComprPago;

            decimal suma = 0;
            int i = 0;
            for (i = 0; i < dtDescComprPago.Rows.Count; i++)
            {
                suma = suma + Convert.ToDecimal(dtDescComprPago.Rows[i][5]);
            }
            txtTotOtrosDesc.Text = suma.ToString();
            FormatoGridOtrosDescuentos();
        }
        private void CargarTipoComisionCPG()
        {
            DataTable dtTipoComisionCPG;
            dtgComisiones.DataSource = "";
            dtTipoComisionCPG = objCpg.BuscarTipoComisionComprPago();

            foreach (DataRow nRow in dtTipoComisionCPG.Rows)
            {
                lstTipoComision.Add(new clsTipoComisionesComprobante()
                {
                    cComision = nRow["cDescripcion"].ToString(),
                    idComprobantePago = Convert.ToInt32(nRow["idComprobantePago"]),
                    idTipoComisionComprPago = Convert.ToInt32(nRow["IdComComprobante"]),
                    lOpcion = Convert.ToBoolean(nRow["lOpcion"]),
                    lVigente = Convert.ToBoolean(nRow["lVigente"]),
                    nMonto = Convert.ToDecimal(nRow["nMonto"])
                }
                );
            }
            dtgComisiones.DataSource = lstTipoComision;
            dtgComisiones.ReadOnly = false;
            txtTotComision.Text = lstTipoComision.Sum(y => y.nMonto).ToString();
            dtgComisiones.Columns[2].ReadOnly = true;
            dtgComisiones.Columns[3].ReadOnly = true;

            DataTable resultAprobador = objCpg.BuscarAprobadorComproPagado(clsVarGlobal.nIdAgencia);
            dtgAprobador.DataSource = "";
            foreach (DataRow nRow in resultAprobador.Rows)
            {
                lstAprobador.Add(new clsApruebaCPGPago()
                {
                    cAprobador = nRow["cNombre"].ToString(),
                    idAprobador = Convert.ToInt32(nRow["idUsuario"]),
                    lSeleccion = Convert.ToBoolean(nRow["lSelec"]),
                    lVigente = true
                }
                );
            }
            dtgAprobador.DataSource = lstAprobador;
        }
        private void LimpiarDatos()
        {
            cboTipoComprobantePago.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            txtSerie.Clear();
            txtNumero.Clear();
            txtConceptoPago.Clear();
            dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
            dtpFechaPago.Value = clsVarGlobal.dFecSystem;
            txtTipCamProm.Clear();
            conBusCli.txtCodCli.Clear();
            conBusCli.txtCodAge.Clear();
            conBusCli.txtCodInst.Clear();
            conBusCli.txtNombre.Clear();
            conBusCli.txtNroDoc.Clear();
            conBusCli.txtDireccion.Clear();

            txtSubTotal.Clear();
            txtTotComision.Clear();
            txtDetraccion.Clear();
            txtMontoIgv.Clear();
            txtRentaCuarta.Clear();
            txtTipoCambio.Clear();
            txtTotCompro.Clear();
            txtTotOtrosDesc.Clear();
            txtRetIGV.Clear();
            txtMontoPagar.Clear();
            txtMontoITF.Clear();
            txtNroCta.Clear();
            txtNroCheque.Clear();
            rbtnConDetraccion.Checked = false;
            rbtnSinDetraccion.Checked = false;
        }
        private void habilitarBotones(int opcion)
        {
            if (opcion == 0)//Inhabilitar Todo
            {
                btnEditar.Enabled = false;
                btnExtorno.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                habilitarControl(0);
                return;
            }
            if (opcion == 1)//comprobante Sin Pagar
            {
                btnEditar.Enabled = true;
                btnExtorno.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                //habilitarControl(1);
                return;
            }
            if (opcion == 2)//comprobante Pagado
            {
                btnEditar.Enabled = false;
                btnExtorno.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                //habilitarControl(0);
            }
            if (opcion == 3)//Click Editar
            {
                btnEditar.Enabled = false;
                btnExtorno.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                //habilitarControl(1);
            }
        }
        private void BuscaChequeComprobante(int idComprobante)
        {
            clsCNComprobantes ChequeComprobante = new clsCNComprobantes();
            DataTable dtBuscaCheque = ChequeComprobante.CNListChequeComprobante(idComprobante);
            if (dtBuscaCheque.Rows.Count > 0)
            {
               cboTipoPago.SelectedValue = 6;
               grbDetPago.Enabled = true;
               cboEntidad.Enabled = false;
               cboCuenta.Enabled = false;
                
               cboEntidad.SelectedValue = dtBuscaCheque.Rows[0]["idEntidad"];
               cboCuenta.SelectedValue  = dtBuscaCheque.Rows[0]["idCuentaInstitucion"];
               txtNroCheque.Text        = Convert.ToString(dtBuscaCheque.Rows[0]["nNroCheque"]);
               nMontoPag                = Convert.ToDecimal(dtBuscaCheque.Rows[0]["nMonto"]);
                     
            }
        }
        private void habilitarControl(int opcControl)
        {
            if (opcControl == 0)
            {
                dtgComisiones.ReadOnly = true;
                dtgOtrosDescuentos.ReadOnly = true;

                dtgAprobador.ReadOnly = true;
                chcRetIGV.Enabled = false;
                cboTipoPago.Enabled = false;
                txtNroCheque.Enabled = false;
                txtNroCta.Enabled = false;
                cboTipoPago.SelectedIndex = -1;
                return;
            }
            if (opcControl == 1)
            {
                cboTipoPago.Enabled = true;
                txtNroCheque.Enabled = true;
                txtNroCta.Enabled = true;
                dtgComisiones.ReadOnly = false;
                chcRetIGV.Enabled = true;
                dtpFechaPago.Enabled = true;
            }
            if (opcControl == 2)
            {
                cboTipoPago.Enabled = false;
                txtNroCheque.Enabled = false;
                txtNroCta.Enabled = false;
                dtgComisiones.ReadOnly = false;
                chcRetIGV.Enabled = true;
                dtpFechaPago.Enabled = true;
            }
        }
        private void CargarTipoPago()
        {
            DataTable dt;
            dt = objCpg.CNListaTipoPago();

            cboTipoPago.DataSource = dt;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";
        }
        private bool validar()
        {
            if (cboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Pago...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 2 && cboEntidad.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Entidad de Pago...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 && cboCuenta.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Debe Seleccionar La Cuenta de Pago...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 && string.IsNullOrEmpty(txtNroCheque.Text.Trim()) == true)
            //{
            //    MessageBox.Show("Debe Seleccionar La Cuenta de Pago...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 && string.IsNullOrEmpty(txtNroCheque.Text.Trim()) == true)
            //{
            //    MessageBox.Show("Debe Seleccionar La Cuenta de Pago...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            //if (Convert.ToInt32(cboTipoPago.SelectedValue) == 3 && Convert.ToDecimal(txtMontoPagar.Text.Trim()) != nMontoPag)
            //{
            //    MessageBox.Show("El monto del Cheque emitido es diferente al monto del Comprobante a pagar...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            int idTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue);

           
            switch (idTipoPago)
            {
                case 1:
                    break;
                case 2: //--Transferencia Interna
                    break;
                case 3: //--Cheque
                    if (cboEntidad.SelectedIndex==-1)
                    {
                         MessageBox.Show("Debe seleccionar la entidad...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         cboEntidad.Focus();
                         return true;
                    }
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe ingresar el número de cuenta...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCta.Focus();
                        return true;
                    }
                    if (string.IsNullOrEmpty(txtNroCheque.Text))
                    {
                        MessageBox.Show("Debe ingresar el número de cheque...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCheque.Focus();
                        return true;
                    }
                    break;
                case 4: //--Interbancarios
                    if (cboEntidad.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la entidad...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboEntidad.Focus();
                        return true;
                    }
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe ingresar el número de cuenta...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCta.Focus();
                        return true;
                    }
                    if (string.IsNullOrEmpty(txtNroCheque.Text))
                    {
                        MessageBox.Show("Debe ingresar el número de operación...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCheque.Focus();
                        return true;
                    }
                    break;
                case 6: //--Cheque Interno
                    if (cboEntidad.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la entidad financiera...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboEntidad.Focus();
                        return true;
                    }
                    if (cboCuenta.SelectedIndex==-1)
                    {
                        MessageBox.Show("Debe seleccionar el número de cuenta...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboCuenta.Focus();
                        return true;
                    }
                    if (string.IsNullOrEmpty(txtNroCheque.Text))
                    {
                        MessageBox.Show("Debe ingresar el número de cheque...", "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCheque.Focus();
                        return true;
                    }
                    break;
                default:
                    break;
            }

            if (idTipoPago == 6)//--con cheque de gerencia
            {
                int idEntidad = Convert.ToInt32(cboEntidad.SelectedValue);
                int idCuentaIFI = Convert.ToInt32(cboCuenta.SelectedValue);
                decimal nImportePagado = Convert.ToDecimal(txtMontoPagar.Text);
                string cNroCheque = txtNroCheque.Text.Trim();
                DataTable dtValida = objCpg.ValidarPagadoComprobante(idTipoPago, idEntidad, idCuentaIFI, cNroCheque,
                    nImportePagado);
                if (dtValida.Rows[0]["nResp"].ToString() == "0")
                {
                    MessageBox.Show(dtValida.Rows[0]["msje"].ToString(), "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (idTipoPago == 2)//transferencia
                    {
                        cboCuenta.Focus();
                    }
                    if (idTipoPago == 3)//cheque
                    {
                        txtNroCheque.Focus();
                    }

                    return true;
                }
            }


           if (lstTipoComision.Exists(x => x.lOpcion == true && x.nMonto==0))
            {
                var myItem = lstTipoComision.Find(x => x.lOpcion == true && x.nMonto == 0);
                MessageBox.Show("Debe Ingrese Monto de Comisión " + myItem.cComision + "\r\n" + " Ya que esta se encuentra Seleccionado..." , "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
           if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1 && Convert.ToInt32(cboMoneda.SelectedValue) == 1)  
           {
               if (Convert.ToDecimal(txtMontoPagar.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariSoles"]))
               {
                   MessageBox.Show("Debe Seleccionar un Tipo de Pago <> Efectivo..." + "\r\n" + "Monto limite de Bancarización: " +"S/. "+ clsVarApl.dicVarGen["nMontoBancariSoles"], "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return true; 
               }               
           }

           if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1 && Convert.ToInt32(cboMoneda.SelectedValue) == 2)
           {
               if (Convert.ToDecimal(txtMontoPagar.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoBancariDolares"]))
               {
                   MessageBox.Show("Debe Seleccionar un Tipo de Pago <> Efectivo..." + "\r\n" + "Monto limite de Bancarización: " + "$ " + clsVarApl.dicVarGen["nMontoBancariDolares"], "Validar Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   return true;
               }
           }
            return false;
        }
        private void FormatoGridOtrosDescuentos()
        {
            dtgOtrosDescuentos.ReadOnly = false;
            dtgOtrosDescuentos.Columns["idDescuentosComprPago"].Visible = false;
            dtgOtrosDescuentos.Columns["idTipoDescComPago"].Visible = false;
            dtgOtrosDescuentos.Columns["idComprobantePago"].Visible = false;
            dtgOtrosDescuentos.Columns["Concepto"].Visible = true;
            dtgOtrosDescuentos.Columns["nMonto"].Visible = true;
            dtgOtrosDescuentos.Columns["lVigente"].Visible = false;
            if (dtgOtrosDescuentos.Columns.Contains("cAbrev"))
            {
                dtgOtrosDescuentos.Columns["cAbrev"].Visible = false;
            }
            dtgOtrosDescuentos.Columns["Concepto"].Width = 300;
            dtgOtrosDescuentos.Columns["nMonto"].Width = 80;

            dtgOtrosDescuentos.Columns["Concepto"].HeaderText = "Concepto";
            dtgOtrosDescuentos.Columns["nMonto"].HeaderText = "Monto";

            dtgOtrosDescuentos.Columns["nMonto"].DefaultCellStyle.Format = "##,##0.00";
        }
        private void FormatoGrids()
        {
            dtgComisiones.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgComisiones.Columns)
            {
                item.ReadOnly = true;
                if (item.HeaderText == "X")
                {
                    item.ReadOnly = false;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void FormatoGridAprobador()
        {
            dtgAprobador.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgAprobador.Columns)
            {
                item.ReadOnly = true;
                if (item.HeaderText == "Sel")
                {
                    item.ReadOnly = false;
                }
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void cboCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
  
}
