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
    public partial class txtBase : TextBox
    {
        public txtBase()
        {
            InitializeComponent();
        }

        public txtBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void txtBase_KeyUp(object sender, KeyEventArgs e)
        {
          //  if (e.KeyData == (Keys.Control | Keys.V))
          //      (sender as TextBox).Paste();
        }
    }
}
