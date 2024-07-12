using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnLeer : Boton
    {
        public btnLeer()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnLeer;
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Leer";
        }
    }
}
