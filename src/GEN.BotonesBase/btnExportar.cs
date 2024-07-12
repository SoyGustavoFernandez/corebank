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
    public partial class btnExportar : Boton
    {
        public btnExportar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnExportar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "E&xportar";
        }
    }
}
