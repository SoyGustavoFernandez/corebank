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
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmEmisionCheques : frmBase
    {
        private int nIdCuentaInst = 0;
        private int nIdChequeBco = 0;
        private int nIdEstadoCheque = 1;
        clsCNMovimientoBanco objMov = new clsCNMovimientoBanco();
        DataTable dtDetCheque = new DataTable("dtDetCheque");        
        private int nidComprobantePago = 0;
        DataTable dtComprPago;

        clsCNCajaChica BuscaComprobante = new clsCNCajaChica();

        public frmEmisionCheques()
        {
            InitializeComponent();
        }

        private void frmEmisionCheques_Load(object sender, EventArgs e)
        {
            this.cboTipoCuentaBco.SelectedIndex = -1;
            this.cboMoneda.SelectedIndex = -1;
            LimpiarDetalle();
            Habilitar(3);
            cboMotOperacionBco.cargarMotivoOperacion(7);
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst cuenta = new frmBusquedaCuentaInst();
            cuenta.ShowDialog();
            if (cuenta.pcNumeroCuenta == null) return;
            nIdCuentaInst = cuenta.pidCuentaInstitucion;
            this.cboEntidad.CargarEntidades(cuenta.pidTipoEntidad);
            this.cboEntidad.SelectedValue = cuenta.pidEntidad;
            this.txtNroCuenta.Text = cuenta.pcNumeroCuenta;
            this.cboMoneda.SelectedValue = cuenta.pidMoneda;
            this.cboTipoCuentaBco.SelectedValue = cuenta.pidTipoCuenta;
            this.txtSalCont.Text = cuenta.pcSaldoContable;
            this.txtSalDisp.Text = cuenta.pcSaldoDisponible;
           
            LlenarGridViewTalonarios();
            Habilitar(1);

            if (dtgCheques.Rows.Count > 0)
            {
                int idEstadoCheque = Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idEstadoCheque"].Value.ToString());
                if (idEstadoCheque == 1)
                {
                    chcAnular.Enabled = true;
                    btnEditar.Enabled = true;
                }
                else
                {
                    chcAnular.Enabled = false;
                    btnEditar.Enabled = false;
                }
            }

            if (dtgCheques.Rows.Count == 0)
            {
                txtMonto.Text = "0.00";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            nIdEstadoCheque = 1;
            this.dtpFechaEmision.Focus();
            LimpiarDetalle();
            CalcularTotal();
            if (txtNroCuenta.Text == "")
            {
                MessageBox.Show("Seleccione una cuenta primero.", "Emision Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgTalonarios.Rows.Count <= 0)
            {
                MessageBox.Show("Necesita registrar un NUEVO talonario", "Emision Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToString(dtgTalonarios.Rows[dtgTalonarios.SelectedCells[0].RowIndex].Cells["lVigente"].Value) == "TERMINADO")
            {
                MessageBox.Show("El(los) Talonario(s) seleccionado esta en estado TERMINADO", "Emision Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           
            

            nIdChequeBco = Convert.ToInt32(dtgTalonarios.Rows[dtgTalonarios.SelectedCells[0].RowIndex].Cells["idChequeBco"].Value.ToString());
            txtNroCheque.Text = (Convert.ToInt32(dtgTalonarios.Rows[dtgTalonarios.SelectedCells[0].RowIndex].Cells["nNroActual"].Value) + 1).ToString().PadLeft(5, '0');

            Habilitar(2);
            this.chcAnular.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string cMsje = Validar();
            if (cMsje == "")
            {
                if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
                {
                    conBusCli.txtCodCli.Text = "0";
                }


                int x_idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
                int idMotOpe = Convert.ToInt32(cboMotOperacionBco.SelectedValue);
                if (idMotOpe<=0)
                {
                    MessageBox.Show("Debe Seleccionar el Motivo de la Operación", "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataTable dtEMitirCheque = objMov.EmitirCheque(nIdChequeBco,Convert.ToInt32(txtNroCheque.Text), 
                                    dtpFechaEmision.Value,Convert.ToInt32(conBusCli.txtCodCli.Text),
                                    conBusCli.txtNroDoc.Text,conBusCli.txtNombre.Text,
                                    conBusCli.txtDireccion.Text, idMotOpe,
                                    txtDescrMot.Text,Convert.ToDecimal(txtMonto.Text),
                                    nIdEstadoCheque, nidComprobantePago,
                                    clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, x_idMoneda);
                if (dtEMitirCheque.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dtEMitirCheque.Rows[0]["cMsje"].ToString(), "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(1);
                    LlenarGridViewTalonarios();
                    chcAnular.Checked = false;
                    txtSalCont.Text = dtEMitirCheque.Rows[0]["nSaldo"].ToString();
                }
                else
                {
                    MessageBox.Show(dtEMitirCheque.Rows[0]["cMsje"].ToString(), "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(cMsje, "Registro Cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgCheques.Rows.Count > 0)
            {
                AsignarDatos();
                chcAnular.Checked = false;
            }
            else
            {
                LimpiarDetalle();
            }
            Habilitar(1);
        }

        private void chcVerificarCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chcVerificarCliente.Checked)
            {
                this.conBusCli.btnBusCliente.Enabled = false;
                this.conBusCli.txtCodCli.Enabled = false;
                this.conBusCli.txtNroDoc.Enabled = true;
                this.conBusCli.txtNombre.Enabled = true;
                this.conBusCli.txtDireccion.Enabled = true;
                this.conBusCli.txtCodCli.Text = "";
                this.conBusCli.txtCodAge.Text = "";
                this.conBusCli.txtCodInst.Text = "";
                this.conBusCli.txtNombre.Text = "";
                this.conBusCli.txtNroDoc.Text = "";
                this.conBusCli.txtDireccion.Text = "";
                this.conBusCli.txtNroDoc.Focus();
            }
            else
            {
                this.conBusCli.btnBusCliente.Enabled = true;
                this.conBusCli.txtCodCli.Enabled = true;
                this.conBusCli.txtNroDoc.Enabled = false;
                this.conBusCli.txtNombre.Enabled = false;
                this.conBusCli.txtDireccion.Enabled = false;
                this.conBusCli.txtCodCli.Text = "";
                this.conBusCli.txtCodAge.Text = "";
                this.conBusCli.txtCodInst.Text = "";
                this.conBusCli.txtNombre.Text = "";
                this.conBusCli.txtNroDoc.Text = "";
                this.conBusCli.txtDireccion.Text = "";
            }
        }

        private void dtgTalonarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            LlenarGridViewCheques();
        }

        private void dtgCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarDatos();
        }

        string Validar()
        {
            string cMsje = ""; 

             if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                cMsje += "Seleccionar un codigo de comprobante.";
                return cMsje;                
            }
            if (string.IsNullOrEmpty(this.conBusCli.txtNroDoc.Text))
            {
                cMsje += "Seleccionar un cliente.";
                return cMsje;
            }
            if (Convert.ToInt32(this.cboMotOperacionBco.SelectedValue) <= 0)
            {
                cMsje += "\nSeleccione un Motivo de Operacion.";
                return cMsje;
            }

            if (string.IsNullOrEmpty(this.txtDescrMot.Text))
            {
                cMsje += "\nRegistre el Motivo de la Operacion.";
                return cMsje;
            }
            if (string.IsNullOrEmpty(this.txtMonto.Text))
            {
                cMsje += "\nEscriba el Monto del Cheque a emitir.";
                return cMsje;
                if (Convert.ToDecimal(this.txtMonto.Text)<= new decimal(0.00))
                {
                    cMsje += "\nEl monto del cheque tiene que ser mayor que 0.";
                    return cMsje;
                }
            }
            
            return cMsje;
        }

        void LlenarGridViewTalonarios()
        {
            DataTable dtTalonarios = objMov.VerificarExisteTalonario(nIdCuentaInst);
            DataView dv = dtTalonarios.DefaultView;
            //dv.RowFilter = "lVigente = 'VIGENTE'";
            dtTalonarios = dv.ToTable();
            dtgTalonarios.DataSource = dtTalonarios;
            FormatoDataGridViewTalonarios();
            LlenarGridViewCheques();
        }
        
        void LlenarGridViewCheques()
        {
            //dtTalonarios = objMov.VerificarExisteTalonario(nIdCuentaInst);
            //if (dtTalonarios.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(dtTalonarios.Rows[0].ItemArray[1]) < Convert.ToInt32(dtTalonarios.Rows[0].ItemArray[2]))
            //    {
            //        nIdChequeBco = Convert.ToInt32(dtTalonarios.Rows[0].ItemArray[0]);
            //    }
            //}
            dtgCheques.DataSource = null;
            LimpiarDetalle();
            if (dtgTalonarios.Rows.Count > 0)
            {
                nIdChequeBco = (Convert.ToInt32(dtgTalonarios.Rows[dtgTalonarios.SelectedCells[0].RowIndex].Cells["idChequeBco"].Value));
                dtDetCheque = objMov.ListarCheques(0,nIdChequeBco, 0);
                dtgCheques.DataSource = dtDetCheque;
                FormatoDataGridViewCheques();
                AsignarDatos();
                CalcularTotal();
            }
        }

        void FormatoDataGridViewTalonarios()
        {
            dtgTalonarios.Columns["nNroTalonario"].Visible = true;
            dtgTalonarios.Columns["idChequeBco"].Visible = false;
            dtgTalonarios.Columns["nNroActual"].Visible = false;
            dtgTalonarios.Columns["nNroInicial"].Visible = true;
            dtgTalonarios.Columns["nNroFinal"].Visible = true;
            dtgTalonarios.Columns["lVigente"].Visible = true;

            dtgTalonarios.Columns["nNroTalonario"].HeaderText = "Nro. Talonario";
            dtgTalonarios.Columns["nNroInicial"].HeaderText = "Nro. Inicio";
            dtgTalonarios.Columns["nNroFinal"].HeaderText = "Nro. Fin";
            dtgTalonarios.Columns["lVigente"].HeaderText = "Estado";

            foreach (DataGridViewColumn column in dtgTalonarios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        void FormatoDataGridViewCheques()
        {
            dtgCheques.Columns["idEmiChequeBco"].Visible = false;
            dtgCheques.Columns["cNroCheque"].Visible = true;
            dtgCheques.Columns["dFechaEmision"].Visible = false;
            dtgCheques.Columns["idCliente"].Visible = false;
            dtgCheques.Columns["cNroDocCli"].Visible = false;
            dtgCheques.Columns["cApNomCli"].Visible = true;
            dtgCheques.Columns["cDireccionCli"].Visible = false;
            dtgCheques.Columns["idMotOperBco"].Visible = false;
            dtgCheques.Columns["cDescripcion"].Visible = false;
            dtgCheques.Columns["nMonto"].Visible = true;
            dtgCheques.Columns["idEstadoCheque"].Visible = false;
            dtgCheques.Columns["cEstado"].Visible = true;
            dtgCheques.Columns["lValorizar"].Visible = false;
			dtgCheques.Columns["idComprobantePago"].Visible = false;

            dtgCheques.Columns["cNroCheque"].DisplayIndex = 1;
            dtgCheques.Columns["cApNomCli"].DisplayIndex = 2;
            dtgCheques.Columns["nMonto"].DisplayIndex = 3;
            dtgCheques.Columns["cEstado"].DisplayIndex = 4;

            dtgCheques.Columns["cNroCheque"].HeaderText = "Nro. Cheque";
            dtgCheques.Columns["cApNomCli"].HeaderText = "Nombre";
            dtgCheques.Columns["nMonto"].HeaderText = "Monto";
            dtgCheques.Columns["cEstado"].HeaderText = "Estado";

            dtgCheques.Columns["cNroCheque"].Width = 70;
            dtgCheques.Columns["cApNomCli"].Width = 200;
            dtgCheques.Columns["nMonto"].Width = 80;
            dtgCheques.Columns["cEstado"].Width = 100;
            
            foreach (DataGridViewColumn column in dtgCheques.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        void LimpiarDetalle()
        {
            this.txtNroCheque.Text = "";
            this.dtpFechaEmision.Value = clsVarGlobal.dFecSystem;
            this.chcVerificarCliente.Checked = false;
            this.txtDescrMot.Text = "";
            this.chcVerificarCliente.Checked = false;
            this.conBusCli.txtCodCli.Text = "";
            this.conBusCli.txtCodAge.Text = "";
            this.conBusCli.txtCodInst.Text = "";
            this.conBusCli.txtNombre.Text = "";
            this.conBusCli.txtNroDoc.Text = "";
            this.conBusCli.txtDireccion.Text = "";
            this.cboMotOperacionBco.SelectedIndex = -1;
            this.txtMonto.Text = "";
            this.chcAnular.Checked = false;
            this.txtCodigo.Text = "";
        }

        void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) //nuevo o editar
            {
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnBuscarCuenta.Enabled = true;
                this.grbDatosEmision.Enabled = false;
                this.chcAnular.Enabled = false;
                this.grbDatosCuenta.Enabled = true;
            }
            else if (nOpcion == 2)//cancelar o Grabar
            {
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnBuscarCuenta.Enabled = false;
                this.grbDatosEmision.Enabled = true;
                HabilitarDetalle(true);
                this.chcAnular.Enabled = true;
                this.grbDatosCuenta.Enabled = false;
            }
            else if (nOpcion == 3)// inicio
            {             
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.grbDatosEmision.Enabled = false;
                this.chcAnular.Enabled = false;
                this.grbDatosCuenta.Enabled = true;
            }
            
        }

        void AsignarDatos()
        {
            if (dtgCheques.Rows.Count > 0)
            {
                txtNroCheque.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["cNroCheque"].Value.ToString();
                dtpFechaEmision.Value = Convert.ToDateTime(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["dFechaEmision"].Value.ToString());
                conBusCli.txtCodCli.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idCliente"].Value.ToString();
                conBusCli.txtNroDoc.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["cNroDocCli"].Value.ToString();
                conBusCli.txtNombre.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["cApNomCli"].Value.ToString();
                conBusCli.txtDireccion.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["cDireccionCli"].Value.ToString();
                cboMotOperacionBco.SelectedValue = Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idMotOperBco"].Value.ToString());
                txtDescrMot.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["cDescripcion"].Value.ToString();
                txtMonto.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["nMonto"].Value.ToString();
				txtCodigo.Text = dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idComprobantePago"].Value.ToString();
                if (dtgCheques.Rows.Count > 0)
                {
                    int idEstadoCheque = Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idEstadoCheque"].Value.ToString());
                    if (idEstadoCheque == 1)
                    {
                        chcAnular.Enabled = true;
                        btnEditar.Enabled = true;
                    }
                    else
                    {
                        chcAnular.Enabled = false;
                        btnEditar.Enabled = false;
                    }
                }
            }
            else
            {
                LimpiarDetalle();
            }
        }

        private void chcAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAnular.Checked)
            {
                if (MessageBox.Show("¿Está seguro de anular este cheque?", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    nIdEstadoCheque = 3;
                    cboMotOperacionBco.Enabled = false;
                    txtDescrMot.Enabled = false;
                }
                else
                {
                    nIdEstadoCheque = 1;
                    cboMotOperacionBco.Enabled = true;
                    txtDescrMot.Enabled = true;
                    chcAnular.Checked = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgCheques.RowCount > 0)
            {
                this.grbDatosEmision.Enabled = true;
                this.chcAnular.Enabled = false;
                Habilitar(2);
                HabilitarDetalle(false);

                dtpFechaEmision.Enabled = true;
                cboMotOperacionBco.Enabled = true;
                this.txtDescrMot.Enabled = true;

                if (Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idEstadoCheque"].Value.ToString()) == 1)
                {
                    this.chcAnular.Enabled = true;
                }
                else if (Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idEstadoCheque"].Value.ToString()) == 2)
                {
                    this.chcAnular.Enabled = false;
                    MessageBox.Show("El Cheque no puede ser anulado. Ya se encuentra VALORIZADO.", "Emision cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(dtgCheques.Rows[dtgCheques.SelectedCells[0].RowIndex].Cells["idEstadoCheque"].Value.ToString()) == 3)
                {
                    this.chcAnular.Enabled = false;
                    MessageBox.Show("El Cheque no puede ser anulado. Ya se encuentra ANULADO.", "Emision cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void HabilitarDetalle(bool lVal)
        {
            this.txtNroCheque.Enabled = lVal;
            this.dtpFechaEmision.Enabled = lVal;
            this.chcVerificarCliente.Enabled = lVal;
            this.conBusCli.Enabled = lVal;
            this.cboMotOperacionBco.Enabled = lVal;
            this.txtDescrMot.Enabled = lVal;
            this.txtMonto.Enabled = lVal;
        }

        private void CalcularTotal()
        {
            decimal nTot = 0.00M;
            if (dtgCheques.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgCheques.Rows)
                {
                    if (Convert.ToInt32(row.Cells["idEstadoCheque"].Value) != 3)
                    {
                        nTot += Convert.ToDecimal(row.Cells["nMonto"].Value);
                    }
                }
                txtTotMonto.Text = nTot.ToString();
            }
            else
            {
                txtMonto.Text = "0.00";
            }
        }

        private void dtgCheques_KeyDown(object sender, KeyEventArgs e)
        {
            AsignarDatos();
        }

        private void dtgCheques_KeyUp(object sender, KeyEventArgs e)
        {
            AsignarDatos();
        }

        private void dtgTalonarios_KeyUp(object sender, KeyEventArgs e)
        {
            LlenarGridViewCheques();
        }

        private void dtgTalonarios_KeyDown(object sender, KeyEventArgs e)
        {
            LlenarGridViewCheques();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Recuperar datos de gasto sin comprobante
            //--Checked  = false ---> Gasto sin comprobante
            //--Checked  = true  ---> Gasto con comprobante
            //=======================================================================
            frmBuscarComprPagoPendiente frmBusqCompPago = new frmBuscarComprPagoPendiente();
            frmBusqCompPago.chcTieneComprobante.Checked = true;
            frmBusqCompPago.chcCajChic.Checked = false;
            frmBusqCompPago.idMonedaCtaBcos = Convert.ToInt32(cboMoneda.SelectedValue);
            frmBusqCompPago.ShowDialog();

            nidComprobantePago      = frmBusqCompPago.pidComprobantePago;
            string pidCliente       = frmBusqCompPago.pidCliente;
            string pcDocumentoID    = frmBusqCompPago.pcDocumentoID;
            string pcNombre         = frmBusqCompPago.pcNombre;
            string pcDireccion      = frmBusqCompPago.pcDireccion;
            string pcDescripcion    = frmBusqCompPago.pcDescripcion;
            string pcGlosa          = frmBusqCompPago.pcGlosa;
            decimal pnTotal         = frmBusqCompPago.pnTotal;

            if (nidComprobantePago == 0)
            {
                MessageBox.Show("No seleccionó ningun comprobante.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                this.txtCodigo.Text = Convert.ToString(nidComprobantePago);

                this.conBusCli.txtCodInst.Text = pidCliente.Substring(0, 3);
                this.conBusCli.txtCodAge.Text = pidCliente.Substring(3, 3);
                this.conBusCli.txtCodCli.Text = pidCliente.Substring(6);

                this.conBusCli.txtNombre.Text = pcNombre;
                this.conBusCli.txtNroDoc.Text = pcDocumentoID;
                this.conBusCli.txtDireccion.Text = pcDireccion;
                this.txtDescrMot.Text = pcDescripcion + " - " + pcGlosa;
                this.txtMonto.Text = Convert.ToString(pnTotal);
            }

            foreach (DataGridViewRow row in dtgCheques.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idComprobantePago"].Value);

                if (idMon == nidComprobantePago)
                {
                    MessageBox.Show("El comprobante tiene destinado un cheque.", "Registro de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarDetalle();
                    return;
                }
            }
                
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
                if (Convert.ToInt32(txtCodigo.Text)<=0)
                {
                    MessageBox.Show("Ingrese Codigo de Comprobante Valido", "Validar Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nidComprobantePago = Convert.ToInt32(txtCodigo.Text);
                dtComprPago = BuscaComprobante.BuscarComprPago(Convert.ToInt32(txtCodigo.Text));

                this.conBusCli.txtCodInst.Text      = Convert.ToString(dtComprPago.Rows[0]["cCodCliente"]).Substring(0, 3);
                this.conBusCli.txtCodAge.Text       = Convert.ToString(dtComprPago.Rows[0]["cCodCliente"]).Substring(3, 3);
                this.conBusCli.txtCodCli.Text       = Convert.ToString(dtComprPago.Rows[0]["cCodCliente"]).Substring(6);

                this.conBusCli.txtNombre.Text       = Convert.ToString(dtComprPago.Rows[0]["cNombre"]);
                this.conBusCli.txtNroDoc.Text       = Convert.ToString(dtComprPago.Rows[0]["cDocumentoID"]);
                this.conBusCli.txtDireccion.Text    = Convert.ToString(dtComprPago.Rows[0]["cDireccion"]);
                this.txtDescrMot.Text               = Convert.ToString(dtComprPago.Rows[0]["cGlosa"]);
                this.txtMonto.Text                  = Convert.ToString(dtComprPago.Rows[0]["nMonto"]);
            }
        }
    }
}
