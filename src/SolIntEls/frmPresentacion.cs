using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;

namespace SolIntEls
{
    public partial class frmPresentacion : frmBase
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            int nAnio = DateTime.Now.Year;
            lblCopyright.Text = "© Copyrigth " + nAnio .ToString() + " Soluciones Integrales ELS SAC - Todos los Derechos Reservados";
        }

        
    }
}
