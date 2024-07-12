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
    public partial class frmSeguimientoNotaPedido : frmBase
    {
        List<clsNotaPedido> lstNotaPedido = new List<clsNotaPedido>();
        clsCNNotaPedido consultaNP = new clsCNNotaPedido();
        public frmSeguimientoNotaPedido()
        {
            InitializeComponent();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpInicial.Value;
            DateTime dFecFin = dtpFinal.Value;
            if (dtpFinal.Value<dtpInicial.Value)
            {
                txtActividad.Clear();
                txtMotivo.Clear();
                MessageBox.Show("La Fecha Final Debe ser Mayor a la Fecha Inicial","Buscar Nota de Pedido",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            int idAgencia=Convert.ToInt32(cboAgencia1.SelectedValue);
            int idArea = Convert.ToInt32(cboArea1.SelectedValue);
            int idTipoProceso = Convert.ToInt32(cboTipoProcesoLog1.SelectedValue);
            int idEstado = 0;
            txtActividad.Clear();
            txtMotivo.Clear();
            lstNotaPedido = consultaNP.buscaSeguimientoNP(dFecIni, dFecFin, idAgencia, idArea, idTipoProceso, idEstado);
            dtgNotaPedido.DataSource = lstNotaPedido;
        }

        private void frmSeguimientoNotaPedido_Load(object sender, EventArgs e)
        {
            dtpInicial.Value = clsVarGlobal.dFecSystem;
            dtpFinal.Value = clsVarGlobal.dFecSystem;
            cboArea1.CargarTodasArea();
            cboTipoProcesoLog1.CargarTotalNotaPedio();
        }

        private void dtgNotaPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgNotaPedido.RowCount<=0)
            {
                txtActividad.Clear();
                txtMotivo.Clear();
                return;
            }
            var itemSel = (clsNotaPedido)dtgNotaPedido.CurrentRow.DataBoundItem;
            txtActividad.Text = itemSel.cActividadLog;
            txtMotivo.Text = itemSel.cMotivoNotaPedido;
        }

        private void dtgNotaPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNotaPedido.RowCount <= 0)
            {
                txtActividad.Clear();
                txtMotivo.Clear();
                return;
            }
            var itemSel = (clsNotaPedido)dtgNotaPedido.CurrentRow.DataBoundItem;
            txtActividad.Text = itemSel.cActividadLog;
            txtMotivo.Text = itemSel.cMotivoNotaPedido;
        }

        private void cboTipoProcesoLog1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstNotaPedido.Clear();
            txtActividad.Clear();
            txtMotivo.Clear();
        }
    }
}
