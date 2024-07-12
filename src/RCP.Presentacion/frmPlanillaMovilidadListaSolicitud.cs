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
    public partial class frmPlanillaMovilidadListaSolicitud : frmBase
    {
        #region Variables Globales

        private clsCNPlanillaMovilidad objCNPlanillaMovilidad { get; set; }
        private List<clsFlujoPlanillaMovilidad> lstPlanillaMovilidadSolicitado { get; set; }
        private BindingSource bsPlanillamovilidadSolicitado { get; set; }


        public clsFlujoPlanillaMovilidad objFlujoPlanillaMovilidad { get; set; }
        #endregion
        public frmPlanillaMovilidadListaSolicitud()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmPlanillaMovilidadListaSolicitud_Load(object sender, EventArgs e)
        {
            cargarDatosDefecto();
            cargarListaPlanillaMovilidadSolicitado();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgPlanillaMovilidadSolicitado.SelectedRows.Count > 0)
            {
                objFlujoPlanillaMovilidad = (clsFlujoPlanillaMovilidad)dtgPlanillaMovilidadSolicitado.CurrentRow.DataBoundItem;
                this.Dispose();
            }
            else
            {
                objFlujoPlanillaMovilidad = new clsFlujoPlanillaMovilidad();
            }
        }

        #endregion

        #region Metodos

        private void cargarDatosDefecto()
        {
            objCNPlanillaMovilidad = new clsCNPlanillaMovilidad();
            objFlujoPlanillaMovilidad = new clsFlujoPlanillaMovilidad();

            lstPlanillaMovilidadSolicitado = new List<clsFlujoPlanillaMovilidad>();
            bsPlanillamovilidadSolicitado = new BindingSource();
            bsPlanillamovilidadSolicitado.DataSource = lstPlanillaMovilidadSolicitado;
            dtgPlanillaMovilidadSolicitado.DataSource = bsPlanillamovilidadSolicitado;
            formatearGridPlanillaMovilidad();
        }

        private void cargarListaPlanillaMovilidadSolicitado()
        {
            List<clsFlujoPlanillaMovilidad> lstPlanillaMovilidadLista = objCNPlanillaMovilidad.CNListarPlanillaMovilidadSolicitado(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            lstPlanillaMovilidadSolicitado.AddRange(lstPlanillaMovilidadLista);

            bsPlanillamovilidadSolicitado.ResetBindings(false);
            dtgPlanillaMovilidadSolicitado.Refresh();
            formatearGridPlanillaMovilidad();
        }

        private void formatearGridPlanillaMovilidad()
        {
            dtgPlanillaMovilidadSolicitado.ReadOnly = true;

            foreach (DataGridViewColumn dgvColumna in dtgPlanillaMovilidadSolicitado.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
            }

            dtgPlanillaMovilidadSolicitado.Columns["idPlanillaMovilidad"].Visible   = true;
            dtgPlanillaMovilidadSolicitado.Columns["cAgencia"].Visible                    = true;
            dtgPlanillaMovilidadSolicitado.Columns["cPeriodo"].Visible                    = true;
            dtgPlanillaMovilidadSolicitado.Columns["cEstadoFinal"].Visible                = true;
            dtgPlanillaMovilidadSolicitado.Columns["cUsuario"].Visible                    = true;
            dtgPlanillaMovilidadSolicitado.Columns["cCargo"].Visible                      = true;
            dtgPlanillaMovilidadSolicitado.Columns["dFechaRegistro"].Visible              = true;

            dtgPlanillaMovilidadSolicitado.Columns["idPlanillaMovilidad"].HeaderText            = "Cod. Planilla";
            dtgPlanillaMovilidadSolicitado.Columns["cAgencia"].HeaderText                       = "Agencia";
            dtgPlanillaMovilidadSolicitado.Columns["cPeriodo"].HeaderText                       = "Período";
            dtgPlanillaMovilidadSolicitado.Columns["cEstadoFinal"].HeaderText                   = "Estado";
            dtgPlanillaMovilidadSolicitado.Columns["cUsuario"].HeaderText                       = "Usuario";
            dtgPlanillaMovilidadSolicitado.Columns["cCargo"].HeaderText                         = "Cargo";
            dtgPlanillaMovilidadSolicitado.Columns["dFechaRegistro"].HeaderText                 = "Fecha Registro";

            dtgPlanillaMovilidadSolicitado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        #endregion


    }
}
