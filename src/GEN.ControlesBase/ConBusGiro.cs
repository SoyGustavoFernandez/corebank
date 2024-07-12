using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConBusGiro : UserControl
    {
        public new event EventHandler ClicBusGiro;
        public ConBusGiro()
        {
            InitializeComponent();
        }

        private void btnBusGiro_Click(object sender, EventArgs e)
        {
            frmBusGiro frmbuscarGiro = new frmBusGiro();
            frmbuscarGiro.cOpcForm = 1;
            frmbuscarGiro.ShowDialog();
            this.txtNroGiro.Text = frmbuscarGiro.pnGiro.ToString();

            if (ClicBusGiro != null)
                ClicBusGiro(sender, e);
        }
    }
}
