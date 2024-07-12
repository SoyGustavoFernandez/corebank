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
    public partial class btnNumerar : Boton
    {
        public btnNumerar()
        {
            InitializeComponent();
            BackgroundImage = Properties.Resources.btnNumerar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Text = "&Numerar";
        }
    }
}
