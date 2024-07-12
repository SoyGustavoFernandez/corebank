using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnEmitirRecibo : Boton
    {
        public btnEmitirRecibo()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnProforma;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }
    }
}
