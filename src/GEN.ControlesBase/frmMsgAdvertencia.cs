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
    public partial class frmMsgAdvertencia : frmBase
    {
        public DialogResult dRes;

        private string cTitulo;
        private string cMensaje;

        public frmMsgAdvertencia()
        {
            InitializeComponent();
        }

        public frmMsgAdvertencia(string _cTitulo, string _cMensaje)
        {
            InitializeComponent();
            this.cTitulo = _cTitulo;
            this.cMensaje = _cMensaje;

            this.dRes = DialogResult.Cancel;
        }

        private void cargarFormulario()
        {
            this.Name = this.cTitulo;
            this.lblTitulo.Text = this.cTitulo;
            this.txtMensaje.Text = this.cMensaje;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.dRes = DialogResult.OK;
            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dRes = DialogResult.Cancel;
            this.Dispose();
        }

        private void frmMsgAdvertencia_Load(object sender, EventArgs e)
        {
            cargarFormulario();
        }
    }
}
