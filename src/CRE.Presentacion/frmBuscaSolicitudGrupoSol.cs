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
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmBuscaSolicitudGrupoSol : frmBase
    {
        #region Variables
        private int idGrupoSol = 0;
        public int idSolicitudCredGrupoSol = 0;
        private int idEvalCredGS = 0;
        #endregion
        #region Eventos
        public frmBuscaSolicitudGrupoSol()
        {
            InitializeComponent();
        }

        public frmBuscaSolicitudGrupoSol(int idGrupoSol)
        {
            InitializeComponent();
            this.idGrupoSol = idGrupoSol;
        }

        private void frmBuscaSolicitudGrupoSol_Load(object sender, EventArgs e)
        {
            conBusGrupoSol1.ObtenerSolCredGrupoSolidario(idGrupoSol);
            clsCNSolicitud nListSoli = new clsCNSolicitud();
            
            DataTable dtResultado = nListSoli.CNBuscaSolicitudesGS(idGrupoSol);
            dtgBase1.Enabled = true;
            dtgBase1.DataSource = dtResultado;
            cargarSolicitudesGrupoSol();
        }

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(conBusGrupoSol1.txtIdGrupoSolidario.Text.Trim()))
            {
                MessageBox.Show("No hay datos para buscar \n", "Documentos en Línea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idGS = Convert.ToInt32(conBusGrupoSol1.txtIdGrupoSolidario.Text.ToString());
            clsCNSolicitud nListSoli = new clsCNSolicitud();
            DataTable dtResultado = nListSoli.CNBuscaSolicitudesGS(idGS);
            if (dtResultado.Rows.Count > 0)
            {
                dtgBase1.Enabled = true;
                dtgBase1.DataSource = dtResultado;
                cargarSolicitudesGrupoSol();
            }
            else
            {
                btnAceptar1.Enabled = false;
            }

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (idSolicitudCredGrupoSol == 0)
            {
                MessageBox.Show("Seleccione una Solicitud de Grupo Solidario", "Solicitud Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Close();
            }
        }

        private void dtgBase1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idSolicitudCredGrupoSol = Convert.ToInt32(dtgBase1.Rows[dtgBase1.SelectedCells[0].RowIndex].Cells["idSolicitudCredGrupoSol"].Value.ToString());
            idEvalCredGS = Convert.ToInt32(dtgBase1.Rows[dtgBase1.SelectedCells[0].RowIndex].Cells["idEvalCredGrupoSol"].Value.ToString());
            this.txtSolicitud.Text = Convert.ToString(idSolicitudCredGrupoSol);
            this.txtBase8.Text = Convert.ToString(idEvalCredGS);
        }

        private void dtgBase1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idSolicitudCredGrupoSol == 0)
            {
                MessageBox.Show("Seleccione una Solicitud de Grupo Solidario", "Solicitud Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Close();
            }
        }
        #endregion
        

        #region Metodos
        private void cargarSolicitudesGrupoSol()
        {

            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgBase1.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgBase1.Columns["cEstado"].Visible = true;
            dtgBase1.Columns["cNombreAge"].Visible = true;
            dtgBase1.Columns["cOperacion"].Visible = true;
            dtgBase1.Columns["nMontoSolicitado"].Visible = true;
            dtgBase1.Columns["nMontoAprobado"].Visible = true;
            dtgBase1.Columns["nCuotas"].Visible = true;

            dtgBase1.Columns["idSolicitudCredGrupoSol"].HeaderText = "N°Solicitud";
            dtgBase1.Columns["cEstado"].HeaderText = "Estado";
            dtgBase1.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgBase1.Columns["cOperacion"].HeaderText = "Operación";
            dtgBase1.Columns["nMontoSolicitado"].HeaderText = "Monto Solic.";
            dtgBase1.Columns["nMontoAprobado"].HeaderText = "Monto Aprob.";
            dtgBase1.Columns["nCuotas"].HeaderText = "Cuotas";

            dtgBase1.Columns["idSolicitudCredGrupoSol"].Width = 30;
            dtgBase1.Columns["cEstado"].Width = 50;
            dtgBase1.Columns["cNombreAge"].Width = 50;
            dtgBase1.Columns["cOperacion"].Width = 50;
            dtgBase1.Columns["nMontoSolicitado"].Width = 50;
            dtgBase1.Columns["nMontoAprobado"].Width = 50;
            dtgBase1.Columns["nCuotas"].Width = 50;

            dtgBase1.Columns["idSolicitudCredGrupoSol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgBase1.Columns["cEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["cNombreAge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["cOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nMontoSolicitado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nMontoAprobado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nCuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public int getSolicitudGrupoSolidario()
        {
            return idSolicitudCredGrupoSol;
        }
        #endregion
    }
}
