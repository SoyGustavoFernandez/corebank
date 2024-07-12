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
    public partial class btnFinalizar : Boton
    {
        public btnFinalizar()
        {
            InitializeComponent();
            this.Text = "Finalizar";
            this.BackgroundImage = Properties.Resources.btnFinalizar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
