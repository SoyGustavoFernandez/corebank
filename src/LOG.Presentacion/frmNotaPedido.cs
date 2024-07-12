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
using CLI.CapaNegocio;
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmNotaPedido : frmBase
    {

        #region Variables

        private int idArea = 0;
        private clsCNNotaPedido clsNotPedido = new clsCNNotaPedido();
        private clsNotaPedido objNotaPedido;
        private List<clsDetalleNotaPedido> lstDetalleNotaPedido = new List<clsDetalleNotaPedido>();
        List<clsEvaRequisitosMinimos> lstReqMin = new List<clsEvaRequisitosMinimos>();

        #endregion

        #region  Eventos

        private void frmNotaPedido_Load(object sender, EventArgs e)
        {
            dtpFechaNP.Value = clsVarGlobal.dFecSystem;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            DatosUsuario(clsVarGlobal.User.idCli);
        }

        #region Botones

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBuscarNotaPedido frmBscNotaPed = new frmBuscarNotaPedido();
            frmBscNotaPed.ShowDialog();

            if (frmBscNotaPed.lAcepta == true)
            {
                txtCBNumNP.Text = frmBscNotaPed.objNotaPedido.idNotaPedido.ToString();
                BuscarNotaPedido(frmBscNotaPed.objNotaPedido.idNotaPedido);
            }
            else {
                return;
            }
   
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            objNotaPedido = new clsNotaPedido(0);
            LimpiarControles();
            txtCBNumNP.Enabled = false;
            HabilitarControles(true);
            DatosUsuario(clsVarGlobal.User.idCli);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            lstReqMin.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            txtCBNumNP.Enabled = false;
            btnBusqueda.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            dtgDetalleNP.ReadOnly = false;
            FormatoGridView();
        } 

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoPedidoLog.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Tipo de Pedido", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmBusquedaCatalogo frmcatalogo = new frmBusquedaCatalogo();
            frmcatalogo.nTipBusqueda = 1;
            frmcatalogo.pidTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue.ToString());
            frmcatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmcatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningun item.", "Validación de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int nRepetidos = 0;
            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                if (lstDetalleNotaPedido.Where(x => x.idCatalogo == objCatalogo.idCatalogo && x.lVigente == true).Count() > 0)
                {
                    nRepetidos++;
                }
                else
                {
                    int nNroItems = lstDetalleNotaPedido.Where(x => x.lVigente == true).Count();
                    clsDetalleNotaPedido objDetNotPedida = new clsDetalleNotaPedido(0);
                    objDetNotPedida.idNotaPedido = objNotaPedido.idNotaPedido;
                    objDetNotPedida.nItem = nNroItems + 1;
                    objDetNotPedida.idCatalogo = objCatalogo.idCatalogo;
                    objDetNotPedida.cProducto = objCatalogo.cProducto;
                    objDetNotPedida.idUnidad = objCatalogo.idUnidadAlmacenaje;
                    objDetNotPedida.cUnidad = objCatalogo.cUnidAlmacenaje;
                    objDetNotPedida.lVigente = true;

                    lstDetalleNotaPedido.Add(objDetNotPedida);
                    dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
                    dtgDetalleNP.DataSource = lstDetalleNotaPedido.Where(x => x.lVigente == true).ToList();
                    FormatoGridView();

                    txtSubTotal.Text = lstDetalleNotaPedido.Sum(x => x.nSubTotal).ToString();
                }
            }

            if (nRepetidos > 0)
            {
                MessageBox.Show("Se encontraron item's repetidos, solo los item's no repetidos fueron agregados.", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            activarEdicionTipoPedido();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNP.Rows.Count <= 0)
            {
                MessageBox.Show("No Existen Items para Quitar", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (dtgDetalleNP.CurrentRow == null)
                {
                    MessageBox.Show("Debe de seleccionar el registro que desea eliminar", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    clsDetalleNotaPedido objDetNotPed = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
                    if (objDetNotPed.idDetalleNotaPedido == 0)
                    {
                        lstDetalleNotaPedido.Remove(objDetNotPed);
                        lstReqMin.RemoveAll(x => x.nItem == objDetNotPed.nItem);
                    }
                    else
                    {
                        objDetNotPed.lVigente = false;
                        foreach (var item in objDetNotPed.lstReqMin)
                        {
                            item.lVigente = false;                          
                        }
                    }
                    ReprocesarNroItem();
                    txtSubTotal.Text = lstDetalleNotaPedido.Sum(x => x.nSubTotal).ToString();
                    dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
                    dtgDetalleNP.DataSource = lstDetalleNotaPedido.Where(x => x.lVigente == true).ToList();
                    FormatoGridView();
                }
                
            }
        } 

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidGen())
                return;
            
            objNotaPedido.idAgenciaGen = clsVarGlobal.nIdAgencia;
            objNotaPedido.idActividad = Convert.ToInt32(cboActividadLog.SelectedValue);
            objNotaPedido.cMotivoNotaPedido = txtObjetivoNP.Text;
            objNotaPedido.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            objNotaPedido.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue);
            objNotaPedido.idUsuarioGen = clsVarGlobal.User.idUsuario;
            objNotaPedido.nSubTotal = Convert.ToDecimal(txtSubTotal.Text);
            objNotaPedido.nTotalCosto = Convert.ToDecimal(txtTotal.Text);
            objNotaPedido.nTotalConvertido = Convert.ToDecimal(txtConvertido.Text);
            objNotaPedido.nIGV = Convert.ToDecimal(txtIgv.Text);
            objNotaPedido.lIncluImpuesto = chcIgv.Checked;
            objNotaPedido.nMonTipoCambio = Convert.ToDecimal(clsVarApl.dicVarGen["nTipoCambio"]);
            objNotaPedido.idAreGen = idArea;
            objNotaPedido.dFechaNotaPedido = objNotaPedido.idNotaPedido > 0 ? clsVarGlobal.dFecSystem.Date : dtpFechaNP.Value.Date;

            objNotaPedido.lstDetNotPedido = lstDetalleNotaPedido;

            clsDBResp objDbResp = clsNotPedido.CNGuardarNotaPedido(objNotaPedido);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCBNumNP.Text = objDbResp.idGenerado.ToString();
                objNotaPedido.idNotaPedido = Convert.ToInt32(txtCBNumNP.Text);
                BuscarNotaPedido(objNotaPedido.idNotaPedido);
                HabilitarControles(false);
                btnBusqueda.Enabled = false;
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            chcIgv.CheckedChanged -= new EventHandler(chcIgv_CheckedChanged);
            chcIgv.Checked = false;
            chcIgv.CheckedChanged += new EventHandler(chcIgv_CheckedChanged);

            LimpiarControles();
            LimpiarUsuario();
            HabilitarControles(false);
            txtCBNumNP.Enabled = true;
            txtCBNumNP.Focus();
            btnAnular.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;  
            lblNotPed.Visible = false;
            dtgDetalleNP.ReadOnly = true;
        }

        private void btnReqMinimo_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNP.Rows.Count <= 0)
            {
                MessageBox.Show("Registre Item(s) para la Nota de Pedido", "Registro de Requisitos Mínimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmRequisitosMin frmRequisitos = new frmRequisitosMin();
            frmRequisitos.xIdNotaPedido = objNotaPedido.idNotaPedido;
            frmRequisitos.lIndicaConsolidado = objNotaPedido.lIndicaConsolidado;
            frmRequisitos.pLstDetNot = lstDetalleNotaPedido;
            //frmRequisitos.cProcesoOper = "NOTA_PEDIDO";
            //frmRequisitos.pLstReqMin = lstReqMin;
            //frmRequisitos.cTipoOpe = pcTipOpe;
            frmRequisitos.ShowDialog();
            //lstReqMin = frmRequisitos.pLstReqMin;
        }

        private void btnProforma_Click(object sender, EventArgs e)
        {
            if (lstDetalleNotaPedido.Count <= 0)
            {
                MessageBox.Show("Registre Item(s) para la Nota de Pedido", "Registro de Estimacion de Precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string msje = "";
            foreach (var item in lstDetalleNotaPedido.Where(x => x.nCantidad == 0).ToList())
            {
                msje += "Ingrese la cantidad del item " + item.nItem + ".\n";
            }

            if (!string.IsNullOrEmpty(msje))
            {
                msje += "La cantidad de un item no puede ser 0.";
                MessageBox.Show(msje, "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgDetalleNP.Focus();
                return;
            }

            frmEstimaPrecios frmEstPrecios = new frmEstimaPrecios();
            frmEstPrecios.idNotaPedido = objNotaPedido.idNotaPedido;
            frmEstPrecios.pLstDetNot = lstDetalleNotaPedido;
            frmEstPrecios.lIndicaConsolidado = objNotaPedido.lIndicaConsolidado;
            frmEstPrecios.cUserWin = txtCBUsuarioSol.Text.ToString();
            frmEstPrecios.cMoneda = cboMoneda.Text.ToString();
            frmEstPrecios.dtFechaReg = dtpFechaNP.Value;
            frmEstPrecios.ShowDialog();

            lstDetalleNotaPedido = frmEstPrecios.pLstDetNot;

            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = lstDetalleNotaPedido.Where(x => x.lVigente == true).ToList();
            FormatoGridView();
            txtSubTotal.Text = lstDetalleNotaPedido.Sum(x => x.nSubTotal).ToString();
            txtTotal.Text = Convert.ToString(Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtIgv.Text));
            CalcularConvertido();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCBNumNP.Text))
            {
                DataTable dtNotaPedido = new clsRPTCNLogistica().CNNotaPedido(Convert.ToInt32(this.txtCBNumNP.Text));
                DataTable dtDetNotaPed = new clsRPTCNLogistica().CNDetalleNotaPedido(Convert.ToInt32(this.txtCBNumNP.Text));                

                List<ReportParameter> paramlist = new List<ReportParameter>();
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
                String cNomAgen = clsVarGlobal.cNomAge;
                String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                paramlist.Add(new ReportParameter("cNomAgencia", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutLogo, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("DSNotaPedido", dtNotaPedido));
                dtslist.Add(new ReportDataSource("DSDetalle", dtDetNotaPed));

                string reportpath = "rptRequerimientoNP.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se cargo Nota de pedido", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
        #endregion

        #region GridView

        private void dtgDetalleNP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        private void dtgDetalleNP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgDetalleNP.CurrentRow != null)
                {
                    clsDetalleNotaPedido objDetNotPedido = (clsDetalleNotaPedido)dtgDetalleNP.CurrentRow.DataBoundItem;
                    objDetNotPedido.nSubTotal = objDetNotPedido.nPrecioUnit * objDetNotPedido.nCantidad;
                    txtSubTotal.Text = lstDetalleNotaPedido.Where(x=>x.lVigente==true).Sum(x => x.nSubTotal).ToString();
                }
            }
        }

        private void dtgDetalleNP_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleNP.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgDetalleNP.CurrentRow.Cells["nCantidad"].EditedFormattedValue.ToString()))
                {
                    dtgDetalleNP.EditingControl.Text = "0";
                    return;
                }
            }
        }

        #endregion

        #region Textbox

        private void txtCBNumNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtCBNumNP.Text.Trim()))
                {
                    if (Convert.ToInt32(txtCBNumNP.Text.Trim()) == 0)
                    {
                        MessageBox.Show("Ingrese Valor Diferente de Cero(0)", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {

                        BuscarNotaPedido(Convert.ToInt32(txtCBNumNP.Text));
                    }
                }
                else
                {
                    MessageBox.Show("Valor de Búsqueda No Válido", "Búsqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            chcIgv_CheckedChanged(sender, e);
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        private void chcIgv_CheckedChanged(object sender, EventArgs e)
        {
            if (chcIgv.Checked)
            {
                txtIgv.Text = Convert.ToString(Convert.ToDecimal(txtSubTotal.Text) * Convert.ToDecimal(clsVarApl.dicVarGen["nIGV"]));
            }
            else
            {
                txtIgv.Text = "0.00";
            }
            txtTotal.Text = Convert.ToString(Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtIgv.Text));
            CalcularConvertido();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularConvertido();
        }

        #endregion

        #region Metodos

        public frmNotaPedido()
        {
            InitializeComponent();
            this.cboActividadLog.ListarActividad(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            btnCancelar.Enabled = false;
        }

        private void BuscarNotaPedido(int idNotaPedido)
        {
            objNotaPedido = clsNotPedido.CNRetornaDatosNPbyID(idNotaPedido);

            if (objNotaPedido == null || objNotaPedido.idNotaPedido == 0)
            {
                MessageBox.Show("No se encontro la nota de pedido.", "Busqueda de nota de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MapeaEntidadControles(objNotaPedido);
            dtgDetalleNP.ReadOnly = true;

            txtCBNumNP.Enabled = false;
            btnBusqueda.Enabled = false;
            btnCancelar.Enabled = true;

            if (objNotaPedido.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO) && objNotaPedido.idUsuarioGen == clsVarGlobal.User.idUsuario)
            {
                this.btnEditar.Enabled = true;
            }

            if (objNotaPedido.lIndicaConsolidado)
            {
                lblNotPed.Visible = true;
                btnEditar.Enabled = false;
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnReqMinimo.Enabled = true;
                btnProforma.Enabled = true;
            }
        }

        private void MapeaEntidadControles(clsNotaPedido objNotaPedido)
        {
            txtEstadoNP.Text = objNotaPedido.cNombreEstado;
            dtpFechaNP.Value = objNotaPedido.dFechaNotaPedido;
            cboAgencia.SelectedValue = objNotaPedido.idAgenciaGen;
            cboActividadLog.SelectedValue = objNotaPedido.idActividad == null ? -1 : objNotaPedido.idActividad;
            cboTipoPedidoLog.SelectedValue = objNotaPedido.idTipoPedido;
            cboMoneda.SelectedValue = objNotaPedido.idMoneda;

            txtObjetivoNP.Text = objNotaPedido.cMotivoNotaPedido;
            txtTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto);
            txtConvertido.Text = string.Format("{0:0.00}", objNotaPedido.nTotalConvertido);
            chcIgv.CheckedChanged -= new EventHandler(chcIgv_CheckedChanged);
            chcIgv.Checked = objNotaPedido.lIncluImpuesto;
            chcIgv.CheckedChanged += new EventHandler(chcIgv_CheckedChanged);
            txtIgv.Text = string.Format("{0:0.00}", objNotaPedido.nIGV);
            txtSubTotal.Text = string.Format("{0:0.00}", objNotaPedido.nTotalCosto - objNotaPedido.nIGV);

            //Retorna datos de usuario que genera
            DatosUsuario(objNotaPedido.idCli);

            lstDetalleNotaPedido = objNotaPedido.lstDetNotPedido;
            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            dtgDetalleNP.DataSource = lstDetalleNotaPedido.Where(x => x.lVigente == true).ToList();
            FormatoGridView();

            //Retorna Requisitos Minimos
            lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(objNotaPedido.idNotaPedido);
            //foreach (var objDetNP in lstDetalleNotaPedido)
            //{
            //    objDetNP.lstReqMin = lstReqMin.Where(x => x.idDetalleNotaPedido == objDetNP.idDetalleNotaPedido).ToList();
            //}
        }

        private bool ValidGen()
        {
            if (string.IsNullOrEmpty(this.txtCBNombre.Text.Trim()))
            {
                MessageBox.Show("No Existe un Usuario Válido para la Nota de Pedido", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboActividadLog.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de actividad de la nota de pedido", "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboActividadLog.Focus();
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

            string msjeItem = "";
            foreach (var item in lstDetalleNotaPedido.Where(x => x.nCantidad == 0).ToList())
            {
                msjeItem += "Ingrese la cantidad del Item : " + item.cProducto + ".\n";
            }

            if (!string.IsNullOrEmpty(msjeItem))
            {
                msjeItem += "La cantidad de un item no puede ser 0.";
                MessageBox.Show(msjeItem, "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgDetalleNP.Focus();
                return false;
            }

            foreach (var item in lstDetalleNotaPedido.Where(x => x.nPrecioUnit == 0).ToList())
            {
                msjeItem += "Ingrese el Precio del Item : " + item.cProducto + ".\n";
            }

            if (!string.IsNullOrEmpty(msjeItem))
            {
                msjeItem += "El Precio de un item no puede ser 0.";
                MessageBox.Show(msjeItem, "Registro de Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgDetalleNP.Focus();
                return false;
            }

            foreach (var itemDet in lstDetalleNotaPedido)
            {
                int CountReq = itemDet.lstReqMin.Where(y => y.lIndica == true).Count();
                if (CountReq == 0)
                {
                    msjeItem += "Falta Registrar los Requisitos Mínimos para el Item : " + itemDet.cProducto + ".\n";
                }
            }

            if (!string.IsNullOrEmpty(msjeItem))
            {
                MessageBox.Show(msjeItem, "Registro de Requisitos Mínimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnReqMinimo.PerformClick();
                return false;
            }

            foreach (var item in lstDetalleNotaPedido.Where(x => x.idProveedor == 0).ToList())
            {
                msjeItem += "Agregue el proveedor para el Item :" + item.cProducto + ".\n";
            }

            if (!string.IsNullOrEmpty(msjeItem))
            {
                MessageBox.Show(msjeItem, "Registro de Estimación de Precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnProforma.PerformClick();
                return false;
            }

            if (string.IsNullOrEmpty(txtObjetivoNP.Text))
            {
                MessageBox.Show("Ingrese el objetivo de la Nota de Pedido", "Registro de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObjetivoNP.Focus();
                return false;
            }

            decimal nMontoMinimo = Convert.ToDecimal(clsVarApl.dicVarGen["nMonMinimoNotPedido"]);
            if (nMontoMinimo > Convert.ToDecimal(txtConvertido.Text))
            {
                MessageBox.Show("El Monto Minimo para Una Nota de Pedido es:  S/. " + nMontoMinimo.ToString(), "Registro Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void HabilitarControles(bool val)
        {
            chcIgv.Enabled = val;
            btnBusqueda.Enabled = !val;
            btnReqMinimo.Enabled = val;
            btnProforma.Enabled = val;
            btnGrabar.Enabled = val;
            btnCancelar.Enabled = !val;
            btnAgregar.Enabled = val;
            btnQuitar.Enabled = val;
            btnAnular.Enabled = !val;
            cboActividadLog.Enabled = val;
            cboMoneda.Enabled = val;
            cboTipoPedidoLog.Enabled = val;
            txtObjetivoNP.Enabled = val;
            this.btnImprimir.Enabled = !val;
            activarEdicionTipoPedido();
        }

        private void CalcularConvertido()
        {
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                txtConvertido.Text = Convert.ToString(Convert.ToDecimal((String.IsNullOrEmpty(txtTotal.Text))? "0": txtTotal.Text ) * Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]));
            }
            else
            {
                txtConvertido.Text = txtTotal.Text;
            }
        }

        private void FormatoGridView()
        {
            dtgDetalleNP.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNP.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgDetalleNP.Columns["nItem"].Visible = true;
            dtgDetalleNP.Columns["idCatalogo"].Visible = true;
            dtgDetalleNP.Columns["cProducto"].Visible = true;
            dtgDetalleNP.Columns["cUnidad"].Visible = true;
            dtgDetalleNP.Columns["nCantidad"].Visible = true;
            dtgDetalleNP.Columns["nPrecioUnit"].Visible = true;
            dtgDetalleNP.Columns["nSubTotal"].Visible = true;

            dtgDetalleNP.Columns["nItem"].HeaderText = "Item";
            dtgDetalleNP.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNP.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetalleNP.Columns["cUnidad"].HeaderText = "UM";
            dtgDetalleNP.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetalleNP.Columns["nPrecioUnit"].HeaderText = "Pre.Uni";
            dtgDetalleNP.Columns["nSubTotal"].HeaderText = "Sub Total";

            dtgDetalleNP.Columns["nItem"].DisplayIndex = 0;
            dtgDetalleNP.Columns["idCatalogo"].DisplayIndex = 1;
            dtgDetalleNP.Columns["cProducto"].DisplayIndex = 2;
            dtgDetalleNP.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetalleNP.Columns["nCantidad"].DisplayIndex = 4;
            dtgDetalleNP.Columns["nPrecioUnit"].DisplayIndex = 5;
            dtgDetalleNP.Columns["nSubTotal"].DisplayIndex = 6;

            dtgDetalleNP.Columns["nItem"].FillWeight = 5;
            dtgDetalleNP.Columns["idCatalogo"].FillWeight = 10;
            dtgDetalleNP.Columns["cProducto"].FillWeight = 35;
            dtgDetalleNP.Columns["cUnidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nCantidad"].FillWeight = 10;
            dtgDetalleNP.Columns["nPrecioUnit"].FillWeight = 10;
            dtgDetalleNP.Columns["nSubTotal"].FillWeight = 20;

            dtgDetalleNP.Columns["nCantidad"].ReadOnly = false;
        }

        private void DatosUsuario(int idusuario)
        {
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(idusuario, "F");
            if (DatosCli.Rows.Count > 0)
            {
                txtCBNombre.Text = DatosCli.Rows[0]["cNombre"].ToString();
                txtCBUsuarioSol.Text = DatosCli.Rows[0]["cWinUser"].ToString();
                txtCBAreaSol.Text = DatosCli.Rows[0]["cArea"].ToString();
                txtCBEstUsuSol.Text = DatosCli.Rows[0]["cEstPersonal"].ToString();
                idArea = Convert.ToInt32(DatosCli.Rows[0]["idArea"].ToString());
            }
            else
            {
                txtCBNombre.Text = "";
                txtCBUsuarioSol.Text = "";
                txtCBAreaSol.Text = "";
                txtCBEstUsuSol.Text = "";
            }
        }

        private void LimpiarControles()
        {
            dtpFechaNP.Value = clsVarGlobal.dFecSystem;
            cboActividadLog.SelectedIndex = -1;
            cboMoneda.SelectedIndex = -1;
            cboTipoPedidoLog.SelectedIndex = -1;
            txtObjetivoNP.Text = string.Empty;
            txtCBNumNP.Text = string.Empty;
            txtEstadoNP.Text = string.Empty;
            txtSubTotal.Text = "0.00";
            txtConvertido.Text = "0.00";
            txtIgv.Text = "0.00";
            txtTotal.Text = "0.00";
            //dtgDetalleNP.DataBindings.Clear();
            lstDetalleNotaPedido.Clear();
            dtgDetalleNP.DataSource = typeof(List<clsDetalleNotaPedido>);
            //dtgDetalleNP.DataSource = null;
            
        }

        private void LimpiarUsuario()
        {
            txtCBNombre.Text = string.Empty;
            txtCBAreaSol.Text = string.Empty;
            txtCBEstUsuSol.Text = string.Empty;
            txtCBUsuarioSol.Text = string.Empty;
        }

        private void ReprocesarNroItem()
        {
            int i = 1;
            foreach (var item in lstDetalleNotaPedido)
            {
                if (item.lVigente)
                {
                    item.nItem = i;
                    i++;
                }
            }
        }

        #endregion

        private void activarEdicionTipoPedido()
        {
            int nFila = dtgDetalleNP.RowCount;
            if (nFila == 0)
            {
                cboTipoPedidoLog.Enabled = true;
            }
            else
            {
                cboTipoPedidoLog.Enabled = false;
            }
        }

        private void dtgDetalleNP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDetalleNP.IsCurrentCellDirty)
            {
                dtgDetalleNP.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
