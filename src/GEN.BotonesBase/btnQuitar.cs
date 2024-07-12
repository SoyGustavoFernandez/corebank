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
    public partial class btnQuitar : Boton
    {
        public btnQuitar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btn_quitar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Quitar";
        }
    }
}
