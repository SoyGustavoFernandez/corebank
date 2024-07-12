using CRE.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCambioEstadoSolCredGrupoSol : frmBase
    {
        clsCNGrupoSolidario objCNGrupoSol = new clsCNGrupoSolidario();
        private string cTituloForm;

        public frmCambioEstadoSolCredGrupoSol()
        {
            InitializeComponent();
            this.cTituloForm = "Cambio de estado sol. cred. grupo sol.";
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            this.btnAnular.Enabled = false;
            this.AnularSolCredGrupoSol();
        }

        private void AnularSolCredGrupoSol()
        {
            DataTable dtRes = this.objCNGrupoSol.CambiarEstadoSolCredGrupoSol(Convert.ToInt32(this.nudIdGrupoSol.Text), Convert.ToInt32(this.nudIdSolCredGrupoSol.Text));
            if (dtRes.Rows.Count > 0 && Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "CAMBIO DE ESTADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "CAMBIO DE ESTADO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnAnular.Enabled = true;
            }
        }

        private void frmCambioEstadoSolCredGrupoSol_Load(object sender, EventArgs e)
        {
            this.Text = this.cTituloForm;
        }
    }
}
