using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public partial class frmExcepcion : Form
    {
        #region Variable Globales

        public string cTituloVentana { get; set; }
        public string cTextoLabel { get; set; }
        public string cSustento { get; set; }
        public bool lExcepcion { get; set; }
        public bool lAcepto { get; set; }
        public bool lBloqNoExcepcion { get; set; }

        #endregion

        public frmExcepcion()
        {
            InitializeComponent();
        }

        #region Eventos


        private void frmExcepcion_Load(object sender, EventArgs e)
        {
            this.Text = cTituloVentana;
            lblDescExcep.Text = cTextoLabel;

            btnCancelar1.DialogResult = DialogResult.Cancel;
            this.CancelButton = btnCancelar1;

            txtSustento.Text = "Ingrese sustento o justificación de no ser excepción...";
            this.txtSustento.GotFocus += txtSustento_GotFocus;
            lAcepto = false;

            rbtExcepcion.Enabled = lBloqNoExcepcion;
            rbtNoExcepcion.Enabled = lBloqNoExcepcion;
        }

        private void txtSustento_GotFocus(object sender, EventArgs e)
        {
 	        txtSustento.Text = "";
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MessageBox.Show("Ingrese un sustento por favor", "Validación sustento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cSustento = txtSustento.Text.Trim();
            lExcepcion = rbtExcepcion.Checked;
            lAcepto = true;
            this.Dispose();
        }

        #endregion
               
    }
}
