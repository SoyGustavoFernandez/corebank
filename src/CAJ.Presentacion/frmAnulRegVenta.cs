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

namespace CAJ.Presentacion
{
    public partial class frmAnulRegVenta : frmBase
    {
        public int idMotAnul = 0;
        public string cMotAnul = "";
        public bool lFlagAceptar = false;

        public frmAnulRegVenta()
        {
            InitializeComponent();
        }

        private void frmAnulRegVenta_Load(object sender, EventArgs e)
        {
            cboMotAnulCpg.SelectedIndex = -1;
            txtMotAnul.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboMotAnulCpg.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccion el motivo de anulación.", "Anular Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtMotAnul.Text))
            {
                MessageBox.Show("Ingrese la descripción del motivo de anulación.", "Anular Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            idMotAnul = Convert.ToInt32(cboMotAnulCpg.SelectedValue);
            cMotAnul = txtMotAnul.Text;
            lFlagAceptar = true;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lFlagAceptar = false;
            this.Dispose();
        }
    }
}
