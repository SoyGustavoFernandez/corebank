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
    public partial class btnBusCol : Boton
    {
        public btnBusCol()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnBuscar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Personal";
        }
    }
}
