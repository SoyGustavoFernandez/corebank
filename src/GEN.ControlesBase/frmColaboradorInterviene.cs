using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class frmColaboradorInterviene : frmBase
    {
        #region Variables
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        public DataRow dtRowSelect;
        #endregion

        #region Metodos
        public frmColaboradorInterviene()
        {
            InitializeComponent();
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            cargarUsuario();
        }

        private void cargarUsuario()
        {
            int idUsuario;
            if (String.IsNullOrEmpty(conBusCol1.idUsu))
            {
                idUsuario = -1;
            }
            else
            {
                idUsuario = Convert.ToInt32(conBusCol1.idUsu);
                DataTable dtAsignados = clsVisita.ListarPerfilAsigXUsuario(idUsuario);
                dtgPerfilAsignado.DataSource = dtAsignados;
                formatoGrids();

            }
        }

        private void formatoGrids()
        {
            foreach (DataGridViewColumn item in dtgPerfilAsignado.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPerfilAsignado.Columns["cPerfil"].Visible = true;
            dtgPerfilAsignado.Columns["lPrincipal"].Visible = true;

            dtgPerfilAsignado.Columns["cPerfil"].HeaderText = "Perfil Asignado";
            dtgPerfilAsignado.Columns["lPrincipal"].HeaderText = "Principal";

            dtgPerfilAsignado.Columns["cPerfil"].Width = 180;
            dtgPerfilAsignado.Columns["lPrincipal"].Width = 55;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtgPerfilAsignado.DataSource = null;
            conBusCol1.LimpiarDatos();
            conBusCol1.HabilitarControles(true);
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgPerfilAsignado.SelectedRows.Count > 0)
            {
                DataTable table = dtgPerfilAsignado.DataSource as DataTable;
                DataRow row = table.NewRow();
                row = ((DataRowView)dtgPerfilAsignado.SelectedRows[0].DataBoundItem).Row;
                dtRowSelect = row;
                Dispose();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún colaborador", "Agregar Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
