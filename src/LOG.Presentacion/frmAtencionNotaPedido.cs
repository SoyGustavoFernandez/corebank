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
using GEN.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmAtencionNotaPedido : frmBase
    {

        #region Variables

        private List<clsNotaPedido> lstNotPed = new List<clsNotaPedido>();
        private clsCNNotaPedido objCNNotPed = new clsCNNotaPedido();
        private decimal nTipCambio;
        private Boolean lIgv = false;

        #endregion

        #region Eventos

        private void frmAtencionNotaPedido_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            chcIGV.Enabled = false;
            limpiar();
            rbtPorAgencia_CheckedChanged(sender,e);
        }      

        private void btnBusNotPed_Click(object sender, EventArgs e)
        {
            if (rbtPorAgencia.Checked==true && cboAgencia.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccionar la Agencia...","Buscar Nota de Pedido",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            limpiar();
            if (rbtPorAgencia.Checked)
            {
                lstNotPed = objCNNotPed.BuscarNotaPedido(0, dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, Convert.ToInt32(cboAgencia.SelectedValue), 1, 4);    
            }
            if (rbtPorFecha.Checked)
            {
                lstNotPed = objCNNotPed.BuscarNotaPedido(0, dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, Convert.ToInt32(cboAgencia.SelectedValue), 1, 3);
            }
            
            if (lstNotPed.Count == 0)
            {
                limpiar();
            }
            else
            {
                dtgListNotPed.DataSource = lstNotPed;
                FormatDtgNotPedido();
                // validar el boton aprobar
                //List<clsNotaPedido> lista = new List<clsNotaPedido>();
                int num = 0;
                int val = 0;
                foreach (var ntp in lstNotPed)
                {
                    num++;
                    if(num == 1)
                    {
                        val = (int)ntp.idEstadoLog;
                    }
                    
                }
                if (val == 1)
                {
                    btnAprobar.Enabled = true;
                    btnDenegar.Enabled = true;
                }
                else {
                    btnAprobar.Enabled = false;
                    btnDenegar.Enabled = false;
                }

                //btnAprobar.Enabled = true;
                //btnDenegar.Enabled = true;
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            clsNotaPedido objNotPedido = null;
            
            if (dtgListNotPed.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la nota de pedido a aprobar o denegar.", "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objNotPedido = (clsNotaPedido)dtgListNotPed.SelectedRows[0].DataBoundItem;
            List<clsDetalleNotaPedido> lstDetNP = (List<clsDetalleNotaPedido>)dtgItems.DataSource;
            objNotPedido.lstDetNotPedido = lstDetNP;

            string msjItem = string.Empty;
            foreach (var item in lstDetNP.Where(x => x.nCantApro == 0).ToList())
            {
                msjItem += "Ingrese la cantidad Aprobada del Item : " + item.cProducto + ".\n";
            }

            if (!string.IsNullOrEmpty(msjItem))
            {
                msjItem += "La Cantidad Aprobada de un item no puede ser 0.";
                MessageBox.Show(msjItem, "Aprobar Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgItems.Focus();
                return ;
            }

            foreach (var item in lstDetNP.Where(x => x.nCantApro > x.nCantidad).ToList())
            {
                msjItem += "la cantidad Aprobada es Mayor al Solicitado en el Item : " + item.cProducto + ".\n";
            }

            if (!string.IsNullOrEmpty(msjItem))
            {
                msjItem += "La Cantidad Aprobada debe ser Igual o Menor al Solicitado.";
                MessageBox.Show(msjItem, "Aprobar Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgItems.Focus();
                return;
            }

            objNotPedido.idEstadoLog = Convert.ToInt16(EstLog.APROBADO);
            objNotPedido.dFechaAprob = clsVarGlobal.dFecSystem;
            objNotPedido.idUsuAprob = clsVarGlobal.User.idUsuario;
            objNotPedido.nTotalCostoAprobado = Convert.ToDecimal(txtTotAprob.Text);
            objNotPedido.nTotalConvertAprob = Convert.ToDecimal(txtTotConverAprob.Text);
            objNotPedido.nMonTipCambioAprob = nTipCambio;
            clsDBResp objDbResp = objCNNotPed.CNAprobarDenegarNotaPedido(objNotPedido);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAprobar.Enabled = false;
                btnDenegar.Enabled = false;
                              
                btnBusNotPed_Click(sender,e);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            clsNotaPedido objNotPedido = null;

            if (dtgListNotPed.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la nota de pedido a aprobar o denegar.", "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objNotPedido = (clsNotaPedido)dtgListNotPed.CurrentRow.DataBoundItem;
            List<clsDetalleNotaPedido> lstDetNP = (List<clsDetalleNotaPedido>)dtgItems.DataSource;
            objNotPedido.lstDetNotPedido = lstDetNP;

            objNotPedido.idEstadoLog = Convert.ToInt16(EstLog.DENEGADO);
            objNotPedido.dFechaAprob = clsVarGlobal.dFecSystem;
            objNotPedido.idUsuAprob = clsVarGlobal.User.idUsuario;
            objNotPedido.nTotalCostoAprobado = 0;
            objNotPedido.nTotalConvertAprob = 0;
            objNotPedido.nMonTipCambioAprob = 0;

            clsDBResp objDbResp = objCNNotPed.CNAprobarDenegarNotaPedido(objNotPedido);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAprobar.Enabled = false;
                btnDenegar.Enabled = false;

                btnBusNotPed_Click(sender, e);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Atención de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgListNotPed_SelectionChanged(object sender, EventArgs e)
        {
            txtTotAprob.Text = "0.00";
            txtTotConverAprob.Text = "0.00";
            if (dtgListNotPed.SelectedRows.Count > 0 && dtgListNotPed.SelectedRows != null)
            {
                clsNotaPedido objNotPedido = (clsNotaPedido)dtgListNotPed.CurrentRow.DataBoundItem;
                txtNumNP.Text = objNotPedido.idNotaPedido.ToString();
                txtUsuGen.Text = objNotPedido.cUsuarioGen.ToString();
                dtpFechaNP.Value = objNotPedido.dFechaNotaPedido.Date;
                txtActividad.Text = objNotPedido.cActividadLog.ToString();
                txtObjetivoNP.Text = objNotPedido.cMotivoNotaPedido.ToString();
                txtUsuAprob.Text = objNotPedido.cUsuarioApro.ToString();
                cboAgencia1.SelectedValue = objNotPedido.idAgenciaGen;

                if (objNotPedido.nIGV > 0)
                {
                    chcIGV.Checked = true;
                    lIgv = true;
                }
                else
                {
                    chcIGV.Checked = false;
                    lIgv = false;
                }

                List<clsDetalleNotaPedido> ItemsNotPed = objCNNotPed.buscarDetalleAtencionNotaPedido(objNotPedido.idNotaPedido, lIgv);
                dtgItems.DataSource = ItemsNotPed;
                FormatDtgDetNotPed();

                if (!objNotPedido.idEstadoLog.In(Convert.ToInt32(EstLog.SOLICITADO)))
                {
                    dtgItems.ReadOnly = true;
                    btnAprobar.Enabled = false;
                    btnDenegar.Enabled = false;
                }
                else
                {
                    FormatDtgDetNotPed();
                    btnAprobar.Enabled = true;
                    btnDenegar.Enabled = true;
                }

                CalcularTotalFinal();
            }
        }

        private void dtgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgItems.CurrentRow != null)
                {
                    clsDetalleNotaPedido objDetNotSalida = (clsDetalleNotaPedido)dtgItems.CurrentRow.DataBoundItem;
                    if (objDetNotSalida.nCantApro > objDetNotSalida.nCantidad)
                    {
                        MessageBox.Show("La cantidad atendida no puede ser mayor a la cantidad aprobada.", "Atención de nota de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtgItems.CurrentRow.Cells["nCantApro"].Value = 0m;
                    }
                    else
                    {
                        CalcularTotalFila(e.RowIndex);
                        CalcularTotalFinal();
                    }
                }
            }
        }

        private void dtgItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }

        private void dtgItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgItems.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgItems.CurrentRow.Cells["nCantApro"].EditedFormattedValue.ToString()))
                {
                    dtgItems.EditingControl.Text = "0";
                    return;
                }
            }
        }

        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void rbtPorAgencia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPorAgencia.Checked)
            {
                cboAgencia.SelectedIndex = -1;
                cboAgencia.Enabled = true;
                dtpFechaIni.Enabled = false;
                dtpFechaFin.Enabled = false;
                limpiar();
            }
        }

        private void rbtPorFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPorFecha.Checked)
            {
                cboAgencia.SelectedIndex = -1;
                cboAgencia.Enabled = false;
                dtpFechaIni.Enabled = true;
                dtpFechaFin.Enabled = true;
                limpiar();
            }
        }

        #endregion

        #region Metodos

        public frmAtencionNotaPedido()
        {
            InitializeComponent();
        }

        private void FormatDtgNotPedido()
        {
            foreach (DataGridViewColumn column in dtgListNotPed.Columns)
            {
                column.Visible = false;
            }

            dtgListNotPed.Columns["idNotaPedido"].Visible = true;
            dtgListNotPed.Columns["dFechaNotaPedido"].Visible = true;
            dtgListNotPed.Columns["cUsuarioGen"].Visible = true;
            dtgListNotPed.Columns["cNombreEstado"].Visible = true;

            dtgListNotPed.Columns["idNotaPedido"].HeaderText = "Nro.";
            dtgListNotPed.Columns["dFechaNotaPedido"].HeaderText = "Fecha";
            dtgListNotPed.Columns["cUsuarioGen"].HeaderText = "Usuario";
            dtgListNotPed.Columns["cNombreEstado"].HeaderText = "Estado";

            dtgListNotPed.Columns["dFechaNotaPedido"].FillWeight = 40;
            dtgListNotPed.Columns["idNotaPedido"].FillWeight = 30;
            dtgListNotPed.Columns["cUsuarioGen"].FillWeight = 50;
            dtgListNotPed.Columns["cNombreEstado"].FillWeight = 50;

            dtgListNotPed.Columns["dFechaNotaPedido"].DisplayIndex = 0;
            dtgListNotPed.Columns["idNotaPedido"].DisplayIndex = 1;
            dtgListNotPed.Columns["cUsuarioGen"].DisplayIndex = 2;
            dtgListNotPed.Columns["cNombreEstado"].DisplayIndex = 3;

        }

        private void FormatDtgDetNotPed()
        {
            dtgItems.ReadOnly = false;

            foreach (DataGridViewColumn column in dtgItems.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgItems.Columns["nItem"].Visible = true;
            dtgItems.Columns["cProducto"].Visible = true;
            dtgItems.Columns["cUnidad"].Visible = true;
            dtgItems.Columns["nCantidad"].Visible = true;
            dtgItems.Columns["nPrecioUnit"].Visible = true;
            dtgItems.Columns["nCantApro"].Visible = true;
            dtgItems.Columns["nSubTotApro"].Visible = true;

            dtgItems.Columns["nItem"].HeaderText = "Item";
            dtgItems.Columns["cProducto"].HeaderText = "Descripcion";
            dtgItems.Columns["cUnidad"].HeaderText = "UM";
            dtgItems.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgItems.Columns["nPrecioUnit"].HeaderText = "P.U.";
            dtgItems.Columns["nSubTotApro"].HeaderText = "Total";
            dtgItems.Columns["nCantApro"].HeaderText = "Cant. Apro.";

            dtgItems.Columns["nItem"].DisplayIndex = 0;
            dtgItems.Columns["cProducto"].DisplayIndex = 1;
            dtgItems.Columns["cUnidad"].DisplayIndex = 2;
            dtgItems.Columns["nCantidad"].DisplayIndex = 3;
            dtgItems.Columns["nCantApro"].DisplayIndex = 4;
            dtgItems.Columns["nPrecioUnit"].DisplayIndex = 5;
            dtgItems.Columns["nSubTotApro"].DisplayIndex = 6;

            dtgItems.Columns["nItem"].FillWeight = 20;
            dtgItems.Columns["cProducto"].FillWeight = 80;
            dtgItems.Columns["cUnidad"].FillWeight = 25;
            dtgItems.Columns["nCantidad"].FillWeight = 30;
            dtgItems.Columns["nCantApro"].FillWeight = 30;
            dtgItems.Columns["nPrecioUnit"].FillWeight = 35;
            dtgItems.Columns["nSubTotApro"].FillWeight = 35;

            dtgItems.Columns["nCantidad"].DefaultCellStyle.Format = "##,##0.00";
            dtgItems.Columns["nCantApro"].DefaultCellStyle.Format = "##,##0.00";
            dtgItems.Columns["nPrecioUnit"].DefaultCellStyle.Format = "##,##0.00";
            dtgItems.Columns["nSubTotApro"].DefaultCellStyle.Format = "##,##0.00";

            dtgItems.Columns["nCantApro"].ReadOnly = false;
        }

        private void CalcularTotalFila(int index)
        {
            if (chcIGV.Checked)
            {
                dtgItems.Rows[index].Cells["nSubTotApro"].Value = Convert.ToDecimal(dtgItems.Rows[index].Cells["nCantApro"].Value) * Convert.ToDecimal(dtgItems.Rows[index].Cells["nPrecioUnit"].Value) * (1 + clsVarApl.dicVarGen["nIGV"]);
            }
            else
            {
                dtgItems.Rows[index].Cells["nSubTotApro"].Value = Convert.ToDecimal(dtgItems.Rows[index].Cells["nCantApro"].Value) * Convert.ToDecimal(dtgItems.Rows[index].Cells["nPrecioUnit"].Value);
            }
        }

        private void CalcularTotalFinal()
        {
            clsNotaPedido notPed = null;
            if (dtgListNotPed.RowCount > 0 && dtgListNotPed.SelectedRows.Count > 0)
            {
                notPed = (clsNotaPedido)dtgListNotPed.SelectedRows[0].DataBoundItem;
            }
            decimal nTotalAprob = 0.00M;
            decimal nTotalConver = 0.00M;
            foreach (DataGridViewRow row in dtgItems.Rows)
            {
                nTotalAprob += Convert.ToDecimal(row.Cells["nSubTotApro"].Value);
            }
            nTotalAprob = decimal.Round(nTotalAprob, 2);
            if (notPed.idMoneda == 2)
            {
                nTotalConver = nTotalAprob * nTipCambio;
            }

            txtTotAprob.Text = nTotalAprob.ToString("##,##0.00");
            txtTotConverAprob.Text = nTotalConver.ToString("##,##0.00");

        }

        private void limpiar()
        {
            nTipCambio = clsVarApl.dicVarGen["nTipCamFij"];
            btnAprobar.Enabled = false;
            btnDenegar.Enabled = false;
            chcIGV.Checked = false;
            //dtgListNotPed.DataSource = null;
            if (this.dtgListNotPed.DataSource != null)
            {

                this.dtgListNotPed.DataSource = null;


            }else{
                this.dtgListNotPed.Rows.Clear();
            }


            if (this.dtgItems.DataSource != null)
            {
                this.dtgItems.DataSource = null;
            }
            else
            {
                this.dtgItems.Rows.Clear();
            }
            //dtgItems.DataSource = null;
            
            txtNumNP.Clear();
            txtUsuGen.Clear();
            txtActividad.Clear();
            txtUsuAprob.Clear();
            txtObjetivoNP.Clear();
            cboAgencia1.SelectedIndex = -1;
        }

        #endregion

    }
}
