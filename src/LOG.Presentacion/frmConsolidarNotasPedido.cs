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
using EntityLayer;
using LOG.CapaNegocio;
using CLI.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmConsolidarNotasPedido : frmBase
    {

        #region Variables

        private int idArea = 0;
        private clsNotaPedido objNotaPedido;

        #endregion

        #region Eventos

        private void frmConsolidarNotasPedido_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            dtgDetalleNP.AutoGenerateColumns = false;
            LimpiarControles();
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            dtpFechaNP.Value = clsVarGlobal.dFecSystem;
            btnCancelar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            objNotaPedido = new clsNotaPedido();
            LimpiarControles();
            txtCBNumNP.Enabled = false;
            HabilitarControles(true);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            chcIgv.Checked = false;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.HabilitarControles(true);
            this.txtCBNumNP.Enabled = false;
            this.btnBusqueda.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            chcIgv.Checked = false;
            LimpiarControles();
            HabilitarControles(false);
            txtCBNumNP.Enabled = true;
            btnAnular.Enabled = false;
            txtCBNumNP.Focus();
            btnCancelar.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = true;
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidGen())
            {
                return;
            }
            decimal nMontoMinimo = Convert.ToDecimal(clsVarApl.dicVarGen["nMonMinimoNotPedido"]);
            if (nMontoMinimo > Convert.ToDecimal(txtConvertido.Text))
            {
                MessageBox.Show("El Monto Minimo para Una Nota de Pedido es:  S/. " + nMontoMinimo.ToString(), "Registro Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable DatosCli = new clsCNRetDatosCliente().ListarDatosCli(clsVarGlobal.User.idCli, "F");

            objNotaPedido.idAreGen = (DatosCli.Rows.Count > 0) ? Convert.ToInt32(DatosCli.Rows[0]["idArea"].ToString()) : 0;
            objNotaPedido.idAgenciaGen = clsVarGlobal.nIdAgencia;
            objNotaPedido.cMotivoNotaPedido = txtObjetivoNP.Text;
            objNotaPedido.idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            objNotaPedido.idTipoPedido = Convert.ToInt16(cboTipoPedidoLog.SelectedValue);
            objNotaPedido.idUsuarioGen = clsVarGlobal.User.idUsuario;
            objNotaPedido.nSubTotal = Convert.ToDecimal(this.txtSubTotal.Text);
            objNotaPedido.nTotalCosto = Convert.ToDecimal(this.txtTotal.Text);
            objNotaPedido.nTotalConvertido = Convert.ToDecimal(this.txtConvertido.Text);
            objNotaPedido.nIGV = Convert.ToDecimal(txtIgv.Text);
            objNotaPedido.lIncluImpuesto = chcIgv.Checked;
            objNotaPedido.nMonTipoCambio = Convert.ToDecimal(clsVarApl.dicVarGen["nTipoCambio"]);

            DateTime dFechaReg = this.dtpFechaNP.Value;
            clsDBResp objDbResp = new clsCNNotaPedido().CNGuardarNotaPedidoConsolidado(objNotaPedido);

            if (objDbResp.nMsje > 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCBNumNP.Text = objDbResp.idGenerado.ToString();
                txtEstadoNP.Text = Convert.ToString(EstLog.SOLICITADO);
                HabilitarControles(false);
                btnBusqueda.Enabled = false;
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarNotaPedido frmBscNotaPed = new frmBuscarNotaPedido();
            frmBscNotaPed.opcFrm = 2;
            frmBscNotaPed.ShowDialog();

            if (frmBscNotaPed.objNotaPedido == null)
            {
                MessageBox.Show("No se seleccionó ninguna nota de pedido.", "Busqueda Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsNotaPedido lObjNotaPedido = frmBscNotaPed.objNotaPedido;

            var validaexiste = objNotaPedido.lstNotaPedidoConsolid.Where(x => x.idNotaPedido == lObjNotaPedido.idNotaPedido).Count();
            if (validaexiste > 0)
            {
                MessageBox.Show("La nota de pedido ya se encuentra agregada.", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgNotasPedido.RowCount > 0)
            {
                var objNotPedPivot = dtgNotasPedido.Rows[0].DataBoundItem as clsNotaPedido;
                if (lObjNotaPedido.idTipoPedido != objNotPedPivot.idTipoPedido)
                {
                    MessageBox.Show("La Nota de Pedido tiene que ser del mismo tipo de Pedido", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lObjNotaPedido.idMoneda != objNotPedPivot.idMoneda)
                {
                    MessageBox.Show("La Nota de Pedido tiene que ser del mismo tipo de Moneda ", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (lObjNotaPedido.lIncluImpuesto != objNotPedPivot.lIncluImpuesto)
                {
                    if (objNotPedPivot.lIncluImpuesto)
                    {
                        MessageBox.Show("La Nota de Pedido tiene que incluir IGV", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("La Nota de Pedido no Tienen que incluir IGV", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }

            //carga las notas de pedido 
            cboTipoPedidoLog.SelectedValue = lObjNotaPedido.idTipoPedido;
            cboMoneda.SelectedValue = lObjNotaPedido.idMoneda;
            chcIgv.Checked = lObjNotaPedido.lIncluImpuesto;

            //cargar detalle de Nota de Pedido
            lObjNotaPedido.lstDetNotPedido = new clsCNNotaPedido().buscarDetalleNotaPedido(lObjNotaPedido.idNotaPedido);
            lObjNotaPedido.lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(lObjNotaPedido.idNotaPedido);

            objNotaPedido.lstNotaPedidoConsolid.Add(lObjNotaPedido);
            objNotaPedido.lstDetNotPedido.AddRange(lObjNotaPedido.lstDetNotPedido);
            objNotaPedido.lstReqMin.AddRange(lObjNotaPedido.lstReqMin);

            ReprocesarNroItem();
            SumaValRefrencial();

            dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
            dtgNotasPedido.DataSource = objNotaPedido.lstNotaPedidoConsolid.ToList();
            FormatoGridViewNotasPedido();

            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = objNotaPedido.lstDetNotPedido.ToList();
            FormatoGridViewDetalleNotasPedido();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgNotasPedido.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen Nota de Pedido para Quitar", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtgNotasPedido.CurrentRow == null)
                {
                    MessageBox.Show("Debe de seleccionar el Registro que desea Eliminar", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                clsNotaPedido lObjDetNotPed = dtgNotasPedido.SelectedRows[0].DataBoundItem as clsNotaPedido;

                if (lObjDetNotPed.idNotaPedido != 0)
                {
                    objNotaPedido.lstNotaPedidoConsolid.Remove(lObjDetNotPed);
                    objNotaPedido.lstDetNotPedido = objNotaPedido.lstDetNotPedido.Where(x => x.idNotaPedido != lObjDetNotPed.idNotaPedido).ToList();
                    objNotaPedido.lstReqMin = objNotaPedido.lstReqMin.Where(y => y.idDetalleNotaPedido == lObjDetNotPed.idNotaPedido).ToList();                 

                }
                else
                {
                    lObjDetNotPed.lVigente = false;
                    var lstItemQuit = objNotaPedido.lstDetNotPedido.Where(x => x.idNotaPedido == lObjDetNotPed.idNotaPedido).ToList();
                    foreach (clsDetalleNotaPedido objDetNP in lstItemQuit)
                    {
                        objDetNP.lVigente = false;
                        var lstReqMinQuit = objNotaPedido.lstReqMin.Where(x => x.idDetalleNotaPedido == objDetNP.idDetalleNotaPedido).ToList();
                        foreach (clsEvaRequisitosMinimos objReqMin in lstReqMinQuit)
                        {
                            objReqMin.lVigente = false;
                        }
                    }
                }

                ReprocesarNroItem();
                SumaValRefrencial();

                dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
                dtgNotasPedido.DataSource = objNotaPedido.lstNotaPedidoConsolid.ToList();
                FormatoGridViewNotasPedido();

                dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
                dtgDetalleNP.DataSource = objNotaPedido.lstDetNotPedido.ToList();
                FormatoGridViewDetalleNotasPedido();
            }
        }

        private void dtgNotasPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNotasPedido.CurrentRow == null)
            {
                return;
            }

            var objNotaPedido = (clsNotaPedido)dtgNotasPedido.CurrentRow.DataBoundItem;
            txtActividad.Text = objNotaPedido.cActividadLog;
        }

        private void txtCBNumNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(this.txtCBNumNP.Text.ToString()))
                {
                    int idNotaPedido;
                    idNotaPedido = Convert.ToInt32(this.txtCBNumNP.Text.ToString().Trim());
                    if (idNotaPedido == 0)
                    {
                        MessageBox.Show("Ingrese Valor Diferente de Cero(0)", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        //BuscarNotaPedido(idNotaPedido);
                        //objNotaPedido = new clsNotaPedido();
                        //LimpiarControles();
                        txtCBNumNP.Enabled = false;
                        //HabilitarControles(true);

                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = false;
                        btnCancelar.Enabled = true;
                        chcIgv.Checked = false;
                        //cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;

                        objNotaPedido = new clsCNNotaPedido().CNRetornaDatosNPConsolidado(idNotaPedido);
                        if (objNotaPedido != null && objNotaPedido.idNotaPedido != 0)
                        {
                            txtEstadoNP.Text = objNotaPedido.cNombreEstado;
                            dtpFechaNP.Value = objNotaPedido.dFechaNotaPedido;
                            cboAgencia.SelectedValue = objNotaPedido.idAgenciaGen;
                            cboTipoPedidoLog.SelectedValue = objNotaPedido.idTipoPedido;
                            txtObjetivoNP.Text = objNotaPedido.cMotivoNotaPedido;
                            chcIgv.Checked = objNotaPedido.lIncluImpuesto;
                            cboMoneda.SelectedValue = objNotaPedido.idMoneda;
                            txtTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto);
                            txtConvertido.Text = string.Format("{0:0.00}", objNotaPedido.nTotalConvertido);
                            txtIgv.Text = string.Format("{0:0.00}", objNotaPedido.nIGV);
                            txtSubTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto - objNotaPedido.nIGV);
                            //clsNotaPedido objNotaPedido;
                            //List<clsNotaPedido> listNotPed = new List<clsNotaPedido>();
                            //cargar detalle de Nota de Pedido
                            //objNotaPedido.lstDetNotPedido = new clsCNNotaPedido().buscarDetalleNotaPedido(idNotaPedido);
                            //objNotaPedido.lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(idNotaPedido);

                            objNotaPedido.lstNotaPedidoConsolid.Add(objNotaPedido);
                            //objNotaPedido.lstDetNotPedido.AddRange(objNotaPedido.lstDetNotPedido);

                            objNotaPedido.lstReqMin.AddRange(objNotaPedido.lstReqMin);

                            ReprocesarNroItem();
                            SumaValRefrencial();

                            dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
                            dtgNotasPedido.DataSource = objNotaPedido.lstNotaPedidoConsolid;
                            FormatoGridViewNotasPedido();

                            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
                            dtgDetalleNP.DataSource = objNotaPedido.lstDetNotPedido;
                            FormatoGridViewDetalleNotasPedido();

                            //Retorna Estimacion de Precios
                            if (objNotaPedido.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO))
                            {
                                btnEditar.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Existe La Nota de Pedido Consolidad", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCBNumNP.Enabled = true;
                            txtCBNumNP.Text = String.Empty;
                            txtCBNumNP.Focus();
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Valor de Búsqueda No Válido", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        #endregion

        #region Metodos

        public frmConsolidarNotasPedido()
        {
            InitializeComponent();
        }

        private void SumaValRefrencial()
        {
            txtSubTotal.Text = objNotaPedido.lstDetNotPedido.Sum(x => x.nSubTotal).ToString();
            txtIgv.Text = objNotaPedido.lstNotaPedidoConsolid.Sum(y => y.nIGV).ToString();
            txtTotal.Text = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtIgv.Text)).ToString();

            if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                txtConvertido.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text) * Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]));
            }
            else
            {
                txtConvertido.Text = txtTotal.Text;
            }
        }

        private void LimpiarControles()
        {
            //objNotaPedido.lstNotaPedidoConsolid.Clear();
            //objNotaPedido.lstDetNotPedido.Clear();

            txtCBNumNP.Clear();
            txtEstadoNP.Clear();

            dtpFechaNP.Value = clsVarGlobal.dFecSystem;

            cboMoneda.SelectedIndex = -1;
            cboTipoPedidoLog.SelectedIndex = -1;
            txtSubTotal.Text = "0.00";
            txtConvertido.Text = "0.00";
            txtObjetivoNP.Clear();
            txtIgv.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void HabilitarControles(bool val)
        {
            btnBusqueda.Enabled = !val;
            btnGrabar.Enabled = val;
            btnAgregar.Enabled = val;
            btnQuitar.Enabled = val;
            btnAnular.Enabled = !val;
            txtObjetivoNP.Enabled = val;
        }

        public bool ValidGen()
        {
            if (dtgNotasPedido.RowCount <= 1)
            {
                MessageBox.Show("Debe Ingresar mas de una Nota de Pedido", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAgregar.Focus();
                return false;
            }
            if (cboTipoPedidoLog.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de pedido de la nota de pedido", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPedidoLog.Focus();
                return false;
            }

            if (cboMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de moneda de la nota de pedido", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }

            if (dtgDetalleNP.RowCount <= 0)
            {
                MessageBox.Show("Agregue por lo menos un item al detalle de la nota de pedido.", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAgregar.PerformClick();
                return false;
            }

            if (string.IsNullOrEmpty(txtObjetivoNP.Text))
            {
                MessageBox.Show("Ingrese el objetivo de la Nota de Pedido", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObjetivoNP.Focus();
                return false;
            }
            return true;
        }

        private void ReprocesarNroItem()
        {
            int i = 1;
            foreach (var item in objNotaPedido.lstDetNotPedido)
            {
                if (item.lVigente)
                {
                    item.nItem = i;
                    i++;
                }
            }
        }

        private void BuscarNotaPedido(int idNotaPedido)
        {
            objNotaPedido = new clsCNNotaPedido().CNRetornaDatosNPConsolidado(idNotaPedido);

            if (objNotaPedido != null && objNotaPedido.idNotaPedido != 0)
            {
                txtCBNumNP.Enabled = false;
                btnBusqueda.Enabled = false;
                btnCancelar.Enabled = true;
                txtEstadoNP.Text = objNotaPedido.cNombreEstado;
                dtpFechaNP.Value = objNotaPedido.dFechaNotaPedido;
                cboAgencia.SelectedValue = objNotaPedido.idAgenciaGen;
                cboTipoPedidoLog.SelectedValue = objNotaPedido.idTipoPedido;
                txtObjetivoNP.Text = objNotaPedido.cMotivoNotaPedido;
                chcIgv.Checked = objNotaPedido.lIncluImpuesto;
                cboMoneda.SelectedValue = objNotaPedido.idMoneda;
                txtTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto);
                txtConvertido.Text = string.Format("{0:0.00}", objNotaPedido.nTotalConvertido);
                txtIgv.Text = string.Format("{0:0.00}", objNotaPedido.nIGV);
                txtSubTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto - objNotaPedido.nIGV);                

                //cargar Notas de Pedido consolidadas
                objNotaPedido.lstNotaPedidoConsolid = new clsCNNotaPedido().buscarListaNotaPedido(idNotaPedido);
                objNotaPedido.lstDetNotPedido = new clsCNNotaPedido().buscarDetalleNotaPedido(idNotaPedido);
                objNotaPedido.lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(idNotaPedido);

                dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
                dtgNotasPedido.DataSource = objNotaPedido.lstNotaPedidoConsolid.Where(x => x.lVigente == true);
                FormatoGridViewNotasPedido();

                dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
                dtgDetalleNP.DataSource = objNotaPedido.lstDetNotPedido.Where(x => x.lVigente == true);
                //dtgDetalleNP.DataSource = objNotaPedido.lstReqMin.Where(x => x.lVigente == true);
                FormatoGridViewDetalleNotasPedido();

                //Retorna Estimacion de Precios
                if (objNotaPedido.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO))
                {
                    btnEditar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("No Existe La Nota de Pedido Consolidad", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCBNumNP.Focus();
            }
        }

        private void FormatoGridViewNotasPedido()
        {
            foreach (DataGridViewColumn column in dtgNotasPedido.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgNotasPedido.Columns["idNotaPedido"].Visible = true;
            dtgNotasPedido.Columns["dFechaNotaPedido"].Visible = true;
            dtgNotasPedido.Columns["cAgencia"].Visible = true;
            dtgNotasPedido.Columns["cArea"].Visible = true;
            dtgNotasPedido.Columns["cUsuarioGen"].Visible = true;
            dtgNotasPedido.Columns["nTotalCosto"].Visible = true;
            dtgNotasPedido.Columns["nIGV"].Visible = true;

            dtgNotasPedido.Columns["idNotaPedido"].HeaderText = "Nota Pedido";
            dtgNotasPedido.Columns["dFechaNotaPedido"].HeaderText = "Fecha";
            dtgNotasPedido.Columns["cAgencia"].HeaderText = "Agencia";
            dtgNotasPedido.Columns["cArea"].HeaderText = "Area";
            dtgNotasPedido.Columns["cUsuarioGen"].HeaderText = "Usuario";
            dtgNotasPedido.Columns["nTotalCosto"].HeaderText = "Costo Total";
            dtgNotasPedido.Columns["nIGV"].HeaderText = "IGV";

            dtgNotasPedido.Columns["idNotaPedido"].DisplayIndex = 0;
            dtgNotasPedido.Columns["dFechaNotaPedido"].DisplayIndex = 1;
            dtgNotasPedido.Columns["cAgencia"].DisplayIndex = 2;
            dtgNotasPedido.Columns["cArea"].DisplayIndex = 3;
            dtgNotasPedido.Columns["cUsuarioGen"].DisplayIndex = 4;
            dtgNotasPedido.Columns["nTotalCosto"].DisplayIndex = 5;
            dtgNotasPedido.Columns["nIGV"].DisplayIndex = 6;

            dtgNotasPedido.Columns["idNotaPedido"].FillWeight = 9;
            dtgNotasPedido.Columns["dFechaNotaPedido"].FillWeight = 11;
            dtgNotasPedido.Columns["cAgencia"].FillWeight = 16;
            dtgNotasPedido.Columns["cArea"].FillWeight = 24;
            dtgNotasPedido.Columns["cUsuarioGen"].FillWeight = 13;
            dtgNotasPedido.Columns["nTotalCosto"].FillWeight = 15;
            dtgNotasPedido.Columns["nIGV"].FillWeight = 12;

            dtgNotasPedido.Columns["nTotalCosto"].DefaultCellStyle.Format = "##,##0.00";
            dtgNotasPedido.Columns["nIGV"].DefaultCellStyle.Format = "##,##0.00";
        }

        private void FormatoGridViewDetalleNotasPedido()
        {
            foreach (DataGridViewColumn column in dtgDetalleNP.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgDetalleNP.Columns["nItem"].Visible = true;
            dtgDetalleNP.Columns["idCatalogo"].Visible = true;
            dtgDetalleNP.Columns["cProducto"].Visible = true;
            dtgDetalleNP.Columns["cUnidad"].Visible = true;
            dtgDetalleNP.Columns["nCantidad"].Visible = true;
            dtgDetalleNP.Columns["nPrecioUnit"].Visible = true;

            dtgDetalleNP.Columns["nItem"].HeaderText = "Item";
            dtgDetalleNP.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNP.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleNP.Columns["cUnidad"].HeaderText = "Unidad";
            dtgDetalleNP.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNP.Columns["nPrecioUnit"].HeaderText = "Precio Unit";

            dtgDetalleNP.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleNP.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleNP.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleNP.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetalleNP.Columns["nCantidad"].DisplayIndex = 4;
            dtgDetalleNP.Columns["nPrecioUnit"].DisplayIndex = 5;

            dtgDetalleNP.Columns["nItem"].FillWeight = 5;
            dtgDetalleNP.Columns["idCatalogo"].FillWeight = 7;
            dtgDetalleNP.Columns["cProducto"].FillWeight = 55;
            dtgDetalleNP.Columns["cUnidad"].FillWeight = 8;
            dtgDetalleNP.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nPrecioUnit"].FillWeight = 15;

            dtgDetalleNP.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetalleNP.Columns["nPrecioUnit"].DefaultCellStyle.Format = "##,##0.00";
        }

        #endregion

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            LimpiarControles();
            HabilitarControles(false);
            objNotaPedido = new clsNotaPedido();
            //LimpiarControles();
            txtCBNumNP.Enabled = false;
            //HabilitarControles(true);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            chcIgv.Checked = false;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;

            frmBuscarNotaPedido frmBscNotaPed = new frmBuscarNotaPedido();
            frmBscNotaPed.opcFrm = 2;
            frmBscNotaPed.ShowDialog();

            if (frmBscNotaPed.objNotaPedido == null)
            {
                MessageBox.Show("No se encontro la nota de pedido", "Busqueda Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsNotaPedido lObjNotaPedido = frmBscNotaPed.objNotaPedido;

            var validaexiste = objNotaPedido.lstNotaPedidoConsolid.Where(x => x.idNotaPedido == lObjNotaPedido.idNotaPedido).Count();
            if (validaexiste > 0)
            {
                MessageBox.Show("Ya Existe la Nota de Pedido", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            objNotaPedido = new clsCNNotaPedido().CNRetornaDatosNPConsolidado(lObjNotaPedido.idNotaPedido);
            if (objNotaPedido != null && objNotaPedido.idNotaPedido != 0)
            {
                txtEstadoNP.Text = objNotaPedido.cNombreEstado;
                txtCBNumNP.Text = lObjNotaPedido.idNotaPedido.ToString();
            }
            //carga las notas de pedido 
            cboTipoPedidoLog.SelectedValue = lObjNotaPedido.idTipoPedido;
            cboMoneda.SelectedValue = lObjNotaPedido.idMoneda;
            chcIgv.Checked = lObjNotaPedido.lIncluImpuesto;

            //cargar detalle de Nota de Pedido
            lObjNotaPedido.lstDetNotPedido = new clsCNNotaPedido().buscarDetalleNotaPedido(lObjNotaPedido.idNotaPedido);
            lObjNotaPedido.lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(lObjNotaPedido.idNotaPedido);

            objNotaPedido.lstNotaPedidoConsolid.Add(lObjNotaPedido);
            //objNotaPedido.lstDetNotPedido.AddRange(lObjNotaPedido.lstDetNotPedido);

            objNotaPedido.lstReqMin.AddRange(lObjNotaPedido.lstReqMin);

            ReprocesarNroItem();
            SumaValRefrencial();

            dtgNotasPedido.DataSource = typeof(List<clsNotaPedido>);
            dtgNotasPedido.DataSource = objNotaPedido.lstNotaPedidoConsolid;
            FormatoGridViewNotasPedido();

            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = objNotaPedido.lstDetNotPedido;
            FormatoGridViewDetalleNotasPedido();
        }

    }
}
