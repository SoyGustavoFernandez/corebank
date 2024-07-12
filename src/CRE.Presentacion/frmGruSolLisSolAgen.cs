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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmGruSolLisSolAgen : frmBase
    {
        #region Variables
        public int idSolicitudCredGrupoSol = -1;
        private clsCNGrupoSolidario cngruposolidario = new clsCNGrupoSolidario();
        #endregion

        #region Constructor
        public frmGruSolLisSolAgen()
        {
            InitializeComponent();

            this.dtgSolicitudes.DataSource = cngruposolidario.listaSolicitudesAgencia(clsVarGlobal.nIdAgencia);

            foreach (DataGridViewColumn dtgvc in dtgSolicitudes.Columns)
            {
                dtgvc.Visible = false;
            }

            this.dtgSolicitudes.Columns["idSolicitudCredGrupoSol"].HeaderText = "ID Sol. Credito";
            this.dtgSolicitudes.Columns["idSolicitudCredGrupoSol"].Visible = true;
            this.dtgSolicitudes.Columns["idGrupoSolidario"].HeaderText = "ID Grupo Solidario";
            this.dtgSolicitudes.Columns["idGrupoSolidario"].Visible = true;
            this.dtgSolicitudes.Columns["cEstado"].HeaderText = "Estado Solicitud";
            this.dtgSolicitudes.Columns["cEstado"].Visible = true;
            this.dtgSolicitudes.Columns["cNombre"].HeaderText = "Grupo Solidario";
            this.dtgSolicitudes.Columns["cNombre"].Visible = true;
        }
        #endregion

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.SelectedRows.Count > 0)
            {
                DataRow aSolicitudes = ((DataRowView)this.dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;
                this.idSolicitudCredGrupoSol = Convert.ToInt32(aSolicitudes["idSolicitudCredGrupoSol"]);
                this.Close();
            }
        }


    }
}
