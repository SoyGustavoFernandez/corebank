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
    public partial class btnRecibido : Boton
    {
        public btnRecibido()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnRecibido;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Recibido";
        }
    }
}
