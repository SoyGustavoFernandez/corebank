using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnValidar : Boton
    {
        public btnValidar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Valida;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Validar";
        }

    }
}
