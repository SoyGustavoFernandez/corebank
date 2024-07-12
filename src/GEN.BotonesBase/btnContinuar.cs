using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnContinuar : Boton
    {
        public btnContinuar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnContinuar;
            this.Text = "C&ontinuar";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
           
        }
    }
}
