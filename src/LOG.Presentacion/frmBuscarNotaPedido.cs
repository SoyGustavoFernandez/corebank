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
    public partial class frmBuscarNotaPedido : frmBase
    {
        public clsNotaPedido objNotaPedido;
        private List<clsNotaPedido> listNotPed = new List<clsNotaPedido>();
        public int opcFrm=0;
        public int opcion;
        public bool lAcepta = false;

        public frmBuscarNotaPedido()
        {
            InitializeComponent();
        }

        private void frmBuscarNotaPedido_Load(object sender, EventArgs e)
        {
            cboEstadoProcLog.listarEstadoProcesoAdj(1);
            if (opcFrm == 0)//Nota de Pedido
            {
                rbtNotaPedido.Checked = true;
                opcion = 1;
                habilitarBusqueda();
            }
            else if (opcFrm == 2)//Consolidar Nota de Pedido
            {
                rbtEstado.Checked = true;
                grbBuscar.Enabled = false;

                opcion = 2;
                habilitarBusqueda();
                cboEstadoProcLog.SelectedValue = 1;
                cboEstadoProcLog.Enabled = false;
            }
            else
            {
                //opcFrm == 1 :Registro de Aquisiciones
                rbtEstado.Checked = true;
                grbBuscar.Enabled = false;
                
                opcion = 2;
                habilitarBusqueda();
                cboEstadoProcLog.SelectedValue = 2;
                cboEstadoProcLog.Enabled = false;
            }
        }        

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            int idNotaPedido;
            if (string.IsNullOrEmpty(txtNroNotaPedido.Text))
            {
                idNotaPedido = 0;
            }
            else
            {
                idNotaPedido = Convert.ToInt32(txtNroNotaPedido.Text);
            }

            buscarNotaPedido(idNotaPedido);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgNotasPedido.CurrentRow==null)
            {
                MessageBox.Show("Seleccione una nota de pedido.", "Busqueda nota de pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            objNotaPedido = (clsNotaPedido)dtgNotasPedido.CurrentRow.DataBoundItem;
            lAcepta = true;
            this.Dispose();
        }
        
        private void rbtNotaPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNotaPedido.Checked)
            { 
                opcion = 1;
                habilitarBusqueda();
            }
        }

        private void rbtEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEstado.Checked)
            {
                opcion = 2;
                habilitarBusqueda();
            }
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFecha.Checked)
            {  
                opcion = 3;
                habilitarBusqueda();
            }
        }

        private void buscarNotaPedido(int idNotaPedido)
        {
            if (opcion == 1 && idNotaPedido == 0)
            {
                MessageBox.Show("Ingrese Nro de Nota de Pedido...", "Busqueda de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listNotPed = null;
            dtgNotasPedido.DataSource = null;
            listNotPed = new clsCNNotaPedido().BuscarNotaPedido(idNotaPedido, dFechaIni.Value.Date, dFechaFin.Value.Date, 0, Convert.ToInt32(cboEstadoProcLog.SelectedValue), opcion);
            dtgNotasPedido.DataSource = listNotPed;
        }

        private void habilitarBusqueda()
        {
            if (opcion == 1)//estado
            {
                txtNroNotaPedido.Enabled = true;
                cboEstadoProcLog.Enabled = false;
                dFechaIni.Enabled = false;
                dFechaFin.Enabled = false;
            }
            else if (opcion == 2)//nota de pedido
            {
                txtNroNotaPedido.Enabled = false;
                cboEstadoProcLog.Enabled = true;
                cboEstadoProcLog.SelectedIndex = -1;
                dFechaIni.Enabled = false;
                dFechaFin.Enabled = false;
                txtNroNotaPedido.Clear();
            }
            else if (opcion == 3)//fecha
            {
                txtNroNotaPedido.Enabled = false;
                cboEstadoProcLog.Enabled = false;
                cboEstadoProcLog.SelectedIndex = -1;
                dFechaIni.Enabled = true;
                dFechaFin.Enabled = true;

                txtNroNotaPedido.Clear();
            }
            dtgNotasPedido.DataSource = null;
        }

    }
}
