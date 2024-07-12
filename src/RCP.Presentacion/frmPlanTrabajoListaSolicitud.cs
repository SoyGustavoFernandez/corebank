#region Referencias
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
using RCP.CapaNegocio;
#endregion


namespace RCP.Presentacion
{
    public partial class frmPlanTrabajoListaSolicitud : frmBase
    {
        #region Variables globales
        private clsCNPlanTrabajo cnplantrabajo { get; set; }
        private List<clsFlujoPlanTrabajoRecuperacion> lstPlanTrabajoSolicitado { get; set; }
        private BindingSource bsPlanTrabajoSolicitado { get; set; }

        public clsFlujoPlanTrabajoRecuperacion objPlanTrabajoSolicitud { get; set; }
        #endregion
        public frmPlanTrabajoListaSolicitud()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmPlanTrabajoListaSolicitud_Load(object sender, EventArgs e)
        {
            cargarDatosDefecto();
            cargarListaPlanTrabajoSolicitado();
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if(dtgPlanTrabajoSolicitado.SelectedRows.Count > 0)
            {
                objPlanTrabajoSolicitud = (clsFlujoPlanTrabajoRecuperacion)dtgPlanTrabajoSolicitado.CurrentRow.DataBoundItem;
                this.Dispose();
            }
            else
            {
                objPlanTrabajoSolicitud = new clsFlujoPlanTrabajoRecuperacion();
            }
        }

        #endregion

        #region Metodos
        private void cargarDatosDefecto()
        {
            cnplantrabajo = new clsCNPlanTrabajo();
            objPlanTrabajoSolicitud = new clsFlujoPlanTrabajoRecuperacion();

            lstPlanTrabajoSolicitado = new List<clsFlujoPlanTrabajoRecuperacion>();
            bsPlanTrabajoSolicitado = new BindingSource();
            bsPlanTrabajoSolicitado.DataSource = lstPlanTrabajoSolicitado;
            dtgPlanTrabajoSolicitado.DataSource = bsPlanTrabajoSolicitado;
            formatearGridListaPlanTrabajoSolicitado();
        }

        private void cargarListaPlanTrabajoSolicitado()
        {
            List<clsFlujoPlanTrabajoRecuperacion> lstPlanTrabajoLista = cnplantrabajo.CNListarPlanTrabajoSolicitado(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            lstPlanTrabajoSolicitado.AddRange(lstPlanTrabajoLista);

            bsPlanTrabajoSolicitado.ResetBindings(false);
            dtgPlanTrabajoSolicitado.Refresh();
        }

        private void formatearGridListaPlanTrabajoSolicitado()
        {
            dtgPlanTrabajoSolicitado.ReadOnly = true;

            foreach (DataGridViewColumn dgvColumna in dtgPlanTrabajoSolicitado.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
            }

            dtgPlanTrabajoSolicitado.Columns["idPlanTrabajoRecuperacion"].Visible   = true;
            dtgPlanTrabajoSolicitado.Columns["cAgencia"].Visible                    = true;
            dtgPlanTrabajoSolicitado.Columns["cPeriodo"].Visible                    = true;
            dtgPlanTrabajoSolicitado.Columns["cEstadoFinal"].Visible                = true;
            dtgPlanTrabajoSolicitado.Columns["cUsuario"].Visible                    = true;
            dtgPlanTrabajoSolicitado.Columns["cCargo"].Visible                      = true;
            dtgPlanTrabajoSolicitado.Columns["dFechaRegistro"].Visible              = true;

            dtgPlanTrabajoSolicitado.Columns["idPlanTrabajoRecuperacion"].HeaderText    = "Cod. Plan Trabajo";
            dtgPlanTrabajoSolicitado.Columns["cAgencia"].HeaderText                     = "Agencia";
            dtgPlanTrabajoSolicitado.Columns["cPeriodo"].HeaderText                     = "Periodo";
            dtgPlanTrabajoSolicitado.Columns["cEstadoFinal"].HeaderText                 = "Estado";
            dtgPlanTrabajoSolicitado.Columns["cUsuario"].HeaderText                     = "Usuario";
            dtgPlanTrabajoSolicitado.Columns["cCargo"].HeaderText                       = "Cargo";
            dtgPlanTrabajoSolicitado.Columns["dFechaRegistro"].HeaderText               = "Fecha Registro";

            dtgPlanTrabajoSolicitado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        #endregion
    }
}
