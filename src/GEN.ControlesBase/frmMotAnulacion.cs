using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmMotAnulacion : frmBase
    {
        public string cMotivoEli;
        public frmMotAnulacion()
        {
            InitializeComponent();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotAnul.Text))
            {
                MessageBox.Show("Debe ingresar descripcion de Motivo de Anulación", "Motivo de Anulación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cMotivoEli = txtMotAnul.Text;
            Dispose();

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }
    }
}
