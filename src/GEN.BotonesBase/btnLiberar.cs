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
    public partial class btnLiberar : Boton
    {
        public btnLiberar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Liberar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Liberar";
        }
    }
}
