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
    public partial class btnReimpresionVoucher : Boton
    {
        public btnReimpresionVoucher()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.miniImprimir;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }
    }
}
