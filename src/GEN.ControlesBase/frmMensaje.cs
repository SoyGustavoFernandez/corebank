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
    public partial class frmMensaje : frmBase
    {
        public string cMotivoAproba;
        public frmMensaje()
        {
            InitializeComponent();
        }

        private void frmMensaje_Load(object sender, EventArgs e)
        {
            txtMotivo.Text = cMotivoAproba;
        }
    }
}
