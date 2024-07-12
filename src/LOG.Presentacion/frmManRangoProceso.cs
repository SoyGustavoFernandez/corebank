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
using LOG.CapaNegocio;
using EntityLayer;
namespace LOG.Presentacion
{
    public partial class frmManRangoProceso : frmBase
    {
        clsCNTipoProcAdj manRango = new clsCNTipoProcAdj();
        clsListaRangoPedidoProceso lstRangoPedido = new clsListaRangoPedidoProceso();
        int pIdTipoPedidoPro;
        public frmManRangoProceso()
        {
            InitializeComponent();
        }

        private void frmMantenimientoRangoProceso_Load(object sender, EventArgs e)
        {
            cargarRangoProceso(0);
            habilitarControles(grbDetTipoPed,false);
            habilitarBotones(true);
        }

        private void dtgRangoPedido_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDatos();
        }
        private void mostrarDatos()
        {
            if (dtgRangoPedido.RowCount <= 0)
            {
                return;
            }
            var itemselc = (clsRangoPedidoProceso)dtgRangoPedido.CurrentRow.DataBoundItem;
            txtValMin.Text = itemselc.nValorMin.ToString();
            txtValMax.Text = itemselc.nValorMax.ToString();
            cboTipoPedidoLog.SelectedValue = itemselc.idTipoPedido;
            cboTipoEvalAdjudicacion.SelectedValue = itemselc.idTipoEvaluacion;
            pIdTipoPedidoPro=itemselc.idRelPedidoProceso;
        }
        private void cargarRangoProceso(int idTipoProceso){
            lstRangoPedido = manRango.buscaRangoPedido(idTipoProceso);
            dtgRangoPedido.DataSource = null;
            dtgRangoPedido.DataSource = lstRangoPedido;
            if (dtgRangoPedido.RowCount<=0)
            {
                limpiarTexto();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                return;
            }
            int indice =0;
            if (dtgRangoPedido.RowCount>0)
            {
                if (dtgRangoPedido.CurrentRow != null)
                {
                    indice = dtgRangoPedido.CurrentRow.Index;
                }    
            }            
            clsRangoPedidoProceso newRangoPedPro = new clsRangoPedidoProceso();
            newRangoPedPro.idRelPedidoProceso = pIdTipoPedidoPro;
            newRangoPedPro.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue.ToString());
            newRangoPedPro.idTipoProceso = Convert.ToInt32(cboTipoProcesoLog.SelectedValue.ToString());
            newRangoPedPro.nValorMax = Convert.ToDecimal(txtValMax.Text);
            newRangoPedPro.nValorMin = Convert.ToDecimal(txtValMin.Text);
            newRangoPedPro.lVigente = (chcVigente.Checked==true)?false:true;
            newRangoPedPro.cTipoPedio = cboTipoPedidoLog.Text;
            newRangoPedPro.idTipoEvaluacion = Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue);
            int nResp=0;
            DataTable rspt = manRango.GrabarRangoPedido(newRangoPedPro, ref nResp);
            if (nResp == 0)
            {
                MessageBox.Show(rspt.Rows[0]["mResp"].ToString(), "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(rspt.Rows[0]["mResp"].ToString(), "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarRangoProceso(Convert.ToInt32(cboTipoProcesoLog.SelectedValue));
                habilitarControles(grbDetTipoPed, false);
                habilitarBotones(true);
                dtgRangoPedido.Enabled = true;

                seleccionaFila(Convert.ToInt32(rspt.Rows[0]["idRel"]));
                mostrarDatos();
                cboTipoProcesoLog.Enabled = true;
                chcVigente.Enabled = false;
                chcVigente.Checked = false;
            }
            
        }

        private void seleccionaFila(int idRelPedidoProceso)
        {
            foreach (DataGridViewRow item in dtgRangoPedido.Rows)
            {
                if (Convert.ToInt32(item.Cells["idRelPedidoProceso"].Value) == idRelPedidoProceso)
                {
                    item.Selected = true;
                    dtgRangoPedido.FirstDisplayedScrollingRowIndex = item.Index;
                    this.dtgRangoPedido.CurrentCell = this.dtgRangoPedido[1, item.Index];
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDetTipoPed, true);
            habilitarBotones(false);
            limpiarTexto();
            chcVigente.Enabled = false;
            dtgRangoPedido.Enabled = false;
            chcVigente.Checked = false;
            pIdTipoPedidoPro = 0;
            cboTipoProcesoLog.Enabled = false;
        }
        private void limpiarTexto()
        {
            cboTipoPedidoLog.SelectedIndex = -1;
            cboTipoEvalAdjudicacion.SelectedIndex = -1;
            txtValMax.Text ="0";
            txtValMin.Text="0";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgRangoPedido.RowCount<=0)
            {
                return;
            }
            habilitarControles(grbDetTipoPed, true);
            habilitarBotones(false);
            chcVigente.Enabled =true;
            chcVigente.Checked = false;
            dtgRangoPedido.Enabled = false;
            cboTipoProcesoLog.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDetTipoPed, false);
            habilitarBotones(true);
            chcVigente.Enabled = false;
            chcVigente.Checked = false;
            dtgRangoPedido.Enabled = true;
            cboTipoProcesoLog.Enabled = true;
            mostrarDatos();
        }
        private void habilitarBotones(bool lActivo)
        {
            btnNuevo.Enabled = lActivo;
            btnEditar.Enabled = lActivo;
            btnGrabar.Enabled = !lActivo;
            btnCancelar.Enabled = !lActivo;
        }

        private void cboTipoProcesoLog1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarRangoProceso(Convert.ToInt32(cboTipoProcesoLog.SelectedValue));
        }
        private bool Validar()
        {
            if (cboTipoProcesoLog.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de Proceso.", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMin.Focus();
                return true;
            }
            if (Convert.ToDecimal(txtValMin.Text) <=0)
            {
                MessageBox.Show("Ingrese Valor Minimo mayor a Cero", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMin.Focus();
                return true;
            }
            if ( Convert.ToDecimal(txtValMax.Text)<=0)
            {
                MessageBox.Show("Ingrese Valor Maximo mayor a Cero", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValMax.Focus();
                return true;
            }
          
            if (Convert.ToDecimal(txtValMin.Text)>Convert.ToDecimal(txtValMax.Text))
            {
                MessageBox.Show("Valor Minino debe ser Menor a Valor Maximo","Mantenimiento de Rango de Proceso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtValMin.Focus();
                return true;
            }
            if (cboTipoPedidoLog.SelectedIndex ==-1)
            {
                MessageBox.Show("Seleccione Tipo de Pedido.", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPedidoLog.Focus();
                return true;
            }
            if (cboTipoEvalAdjudicacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Tipo de Evaluación.", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEvalAdjudicacion.Focus();
                return true;
            }
            //int xidTipoPedio = Convert.ToInt32(cboTipoPedidoLog.SelectedValue);
            //int xidTipoEval = Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue);
            //int cantidad = lstRangoPedido.Count(x => x.idTipoPedido == xidTipoPedio && x.idTipoEvaluacion==xidTipoEval);
            //if (cantidad>1)
            //{
            //    MessageBox.Show("Ya Existe el Tipo de Pedido y Tipo de Evaluación.", "Mantenimiento de Rango de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            return false;
        }

        private void dtgRangoPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarDatos();
        }
    }
}
