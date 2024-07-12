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

namespace RCP.Presentacion
{
    public partial class frmRegistraSupervisado : frmBase
    {
        public bool lAceptar = false;
        public int idAgencia = 0;
        public frmRegistraSupervisado()
        {
            InitializeComponent();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            lAceptar = true;
            idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lAceptar = false;            
            this.Dispose();
        }

        private void frmRegistraSupervisado_Load(object sender, EventArgs e)
        {
            cboAgencia1.cargarSoloAgencias();
        }
    }
}
