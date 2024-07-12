using EntityLayer;
using GEN.ControlesBase;
using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarReversaDialog : frmBase
    {
        int idPDPSetDep;
        clsCNPdp cnRptPdp = new clsCNPdp();

        public frmPDPGestionarReversaDialog()
        {
            InitializeComponent();
        }

        public void CargarComponentes(int idPDPSetDep)
        {
            this.idPDPSetDep = idPDPSetDep;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.txtMensaje.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ingrese un mensaje para continuar...", "Gestionar Reversa", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            cnRptPdp.RegistrarReversa(1, this.idPDPSetDep, clsVarGlobal.User.idUsuario, this.txtMensaje.Text);
            this.Close();            
        }
    }
}
