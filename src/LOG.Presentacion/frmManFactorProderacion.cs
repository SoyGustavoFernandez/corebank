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
namespace LOG.Presentacion
{
    public partial class frmManFactorProderacion : frmBase
    {
        clsListaTipoFacPonderacion lstTipoFacTec = new clsListaTipoFacPonderacion();
        clsCNNotaPedido facPond = new clsCNNotaPedido();
        public int idFactoTecnico;
        public frmManFactorProderacion()
        {
            InitializeComponent();
        }

        private void frmManFactorProderacion_Load(object sender, EventArgs e)
        {
            cargarFactorPonderacion();
            this.habilitarControles(grbDetFacPon, false);
            habilitarBotones(true);
        }
        private void limpiarTexto()
        {
            txtTipoFactor.Clear();
            txtEvaMax.Clear();
            txtEvaMin.Clear();
            txtFacMax.Clear();
            txtFacMin.Clear();
        }
        private void habilitarBotones(bool lActiva )
        {            
            btnEditar1.Enabled = lActiva;
            btnGrabar1.Enabled = !lActiva;
            btnCancelar1.Enabled = !lActiva;
        }
        private void dtgFactPond_SelectionChanged(object sender, EventArgs e)
        {
            var itemSelc = (clsTipoFacPonderacion)dtgFactPond.CurrentRow.DataBoundItem;
            txtTipoFactor.Text = itemSelc.cFactorPonderacion;
            txtEvaMax.Text = itemSelc.nEvaMax.ToString();
            txtEvaMin.Text = itemSelc.nEvaMin.ToString();
            txtFacMax.Text = itemSelc.nFacMax.ToString();
            txtFacMin.Text = itemSelc.nFacMin.ToString();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            int indice = dtgFactPond.CurrentRow.Index;
            clsTipoFacPonderacion newTipFacTec = new clsTipoFacPonderacion();
            newTipFacTec.cFactorPonderacion = txtTipoFactor.Text;
            newTipFacTec.idTipoFacPonderacion = idFactoTecnico;
            newTipFacTec.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog1.SelectedValue);
            newTipFacTec.lVigente = true;
            newTipFacTec.nEvaMax=Convert.ToDecimal(txtEvaMax.Text);
            newTipFacTec.nEvaMin = Convert.ToDecimal(txtEvaMin.Text);
            newTipFacTec.nFacMin= Convert.ToDecimal(txtFacMin.Text);
            newTipFacTec.nFacMax = Convert.ToDecimal(txtFacMax.Text);
            int nResp=0;
            string msg = new clsCNProcesoAdjudicacion().GrabarTipFacPonderacion(newTipFacTec, ref nResp);
            if (nResp == 0)
            {
                MessageBox.Show(msg, "Grabar Factor de Ponderación ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(msg, "Grabar Factor de Ponderación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoPedidoLog1.Enabled = true;
                habilitarBotones(true);
                dtgFactPond.Enabled = true;
                txtFacMax.Enabled = false;
                txtFacMin.Enabled = false;
                cargarFactorPonderacion();
                dtgFactPond.FirstDisplayedScrollingRowIndex = indice;
                dtgFactPond.Rows[indice].Selected = true;
                this.dtgFactPond.CurrentCell = this.dtgFactPond[2, indice];
                dtgFactPond_SelectionChanged(sender,e);
            }
        }

        //private void btnNuevo1_Click(object sender, EventArgs e)
        //{
        //    idFactoTecnico = 0;
        //    txtTipoFactor.Enabled = true;
        //    txtFacMax.Enabled = true;
        //    txtFacMin.Enabled = true;

        //    cboTipoPedidoLog1.Enabled = false;
        //    limpiarTexto();
        //    txtEvaMax.Text = "100";
        //    txtEvaMin.Text = "100";
        //    habilitarBotones(false);
        //}
        
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgFactPond.RowCount <= 0)
            {
                //limpiarTexto();
                return;
            }

            txtFacMax.Enabled = true;
            txtFacMin.Enabled = true;

            var itemSelc=(clsTipoFacPonderacion)dtgFactPond.CurrentRow.DataBoundItem;
            idFactoTecnico = itemSelc.idTipoFacPonderacion;
            cboTipoPedidoLog1.Enabled = false;
            habilitarBotones(false);
            dtgFactPond.Enabled = false;
            txtFacMin.Focus();

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarFactorPonderacion();
            txtFacMax.Enabled = false;
            txtFacMin.Enabled = false;
            if (dtgFactPond.RowCount <= 0)
            {
                limpiarTexto();
            }
            cboTipoPedidoLog1.Enabled = true;
            habilitarBotones(true);
            dtgFactPond.Enabled = true;
        }

        private void cboTipoPedidoLog1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFactorPonderacion();
        }
        private void cargarFactorPonderacion()
        {
            int idTipoPedido = Convert.ToInt32(cboTipoPedidoLog1.SelectedValue);
            lstTipoFacTec=new clsCNProcesoAdjudicacion().buscaFacTipPonderacion(idTipoPedido);
            dtgFactPond.DataSource = null;
            dtgFactPond.DataSource = lstTipoFacTec;
            if (dtgFactPond.RowCount<=0)
            {
                limpiarTexto();
            }

        }
        private bool validar()
        {
            //if (string.IsNullOrEmpty(txtTipoFactor.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese el Tipo de Factor","Factor de Ponderación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //    return true;
            //}
            decimal nFacMin = Convert.ToDecimal(txtFacMin.Text);
            if (nFacMin <= 0 || nFacMin>1)
            {
                MessageBox.Show("Ingrese Valor Mayor a CERO y Menor(Igual) a UNO de Factibilidad Minima", "Validar Factor de Ponderación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFacMin.Focus();
                return true;
            }
            decimal nFacMax=Convert.ToDecimal(txtFacMax.Text);
            if (nFacMax <= 0 || nFacMax >1)
            {
                MessageBox.Show("Ingrese Valor Mayor a CERO y Menor(Igual) a UNO de Factibilidad Maxima", "Validar Factor de Ponderación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFacMax.Focus();
                return true;
            }
            //if ((nFacMax + nFacMin) != 1)
            //{
            //    MessageBox.Show("La Suma de Factibilidad Minima y Maxima Debe Ser igual a 1.", "Factor de Ponderación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return true;
            //}
            return false;
        }
    }
}
