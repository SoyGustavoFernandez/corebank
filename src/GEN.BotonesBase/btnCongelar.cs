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
    public partial class btnCongelar : Boton
    {
        public btnCongelar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnCongelar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "C&ongelar tasas";
        }
    }
}
