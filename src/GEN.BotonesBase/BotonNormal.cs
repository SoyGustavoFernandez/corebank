using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class BotonNormal : Button
    {
        public BotonNormal()
        {
            InitializeComponent();
        }

        public BotonNormal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void BotonNormal_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void BotonNormal_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
