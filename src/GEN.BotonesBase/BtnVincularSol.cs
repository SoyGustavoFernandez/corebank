using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class Btn_Vincular : Boton
    {
        public Btn_Vincular()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Btn_Vinculo;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Vincular";
        }
    }
}
