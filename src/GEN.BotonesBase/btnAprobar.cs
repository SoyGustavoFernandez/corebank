using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnAprobar : Boton
    {
        public btnAprobar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Approve_24x24;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Aprobar";
        }
    }
}
