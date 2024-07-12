using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class txtTelefCel : txtBase
    {
        public txtTelefCel()
        {
            InitializeComponent();
        }

        public txtTelefCel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtTelCel_KeyPress);
        }
        private void txtTelCel_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 47 && e.KeyChar != 8 && e.KeyChar != 35 && e.KeyChar != 42 && e.KeyChar != 32) || e.KeyChar > 57)
            {
                e.Handled = true;
            }


        }
    }
}
