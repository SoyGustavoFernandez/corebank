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
    public partial class frmManTipoPedido : frmBase
    {
        clsListaTipoPedido lstTipPedido = new clsListaTipoPedido();
        clsCNTipoPedido cnTipoPed = new clsCNTipoPedido();
        int pidNueEdt;
        public frmManTipoPedido()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoPedido_Load(object sender, EventArgs e)
        {
            mostrarTipoPedido();
            habilitarBotones(true);
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
        }
        private void habilitarBotones(bool lActivo)
        {
            btnNuevo1.Enabled = lActivo;
            btnEditar.Enabled = lActivo;
            btnGrabar.Enabled = !lActivo;
            btnCancelar.Enabled = !lActivo;

        }
        private void mostrarTipoPedido()
        {
            lstTipPedido = cnTipoPed.buscaTipoPedido();
            dtgTipoPedido.DataSource = null;
            dtgTipoPedido.DataSource = lstTipPedido;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            var itemSelc = (clsTipoPedio)dtgTipoPedido.CurrentRow.DataBoundItem;
            txtTipoPedido.Text = itemSelc.cTipoPedido;
            habilitarBotones(false);
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            pidNueEdt = 1;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            cnTipoPed.GrabarTipoPedido(lstTipPedido);

            habilitarBotones(true);
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            mostrarTipoPedido();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int ncount = lstTipPedido.Where(x => x.cTipoPedido == txtTipoPedido.Text.Trim()).Count();
            if (ncount > 0)
            {
                MessageBox.Show("Ya Existe Tipo Pedido", "Advertencia Tipo Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (pidNueEdt == 1)
            {
                var itenselc = (clsTipoPedio)dtgTipoPedido.CurrentRow.DataBoundItem;
                itenselc.cTipoPedido = txtTipoPedido.Text;
                txtTipoPedido.Clear();
            }
            else
            {
                lstTipPedido.Add(new clsTipoPedio()
                {
                    cTipoPedido = txtTipoPedido.Text,
                    idTipoPedido = 0,
                    lVigente = true
                });
            }
            dtgTipoPedido.DataSource = null;
            dtgTipoPedido.DataSource = lstTipPedido;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgTipoPedido.RowCount <= 0)
            {
                return;
            }

            var itenselc = (clsTipoPedio)dtgTipoPedido.CurrentRow.DataBoundItem;
            itenselc.lVigente = false;

            lstTipPedido.RemoveAll(x => x.cTipoPedido == itenselc.cTipoPedido);

            dtgTipoPedido.DataSource = null;
            dtgTipoPedido.DataSource = lstTipPedido;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarBotones(false);
            pidNueEdt = 0;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
        }
    }
}
