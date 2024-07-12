using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnObservacion : Boton
    {
        public btnObservacion()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnObservacion;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Obs.";
        }
    }
}
