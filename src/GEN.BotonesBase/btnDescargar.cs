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
    public partial class btnDescargar : Boton
    {
        public btnDescargar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.Download_24x24;
        }

            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);
            }
    }
}
