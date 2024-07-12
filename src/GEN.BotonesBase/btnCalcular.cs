using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnCalcular : Boton
    {
        public btnCalcular()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnCalcular;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "C&alcular";
        }
    }
}
