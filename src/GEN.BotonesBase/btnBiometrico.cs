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
    public partial class btnBiometrico : Boton
    {
        public btnBiometrico()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.huella_digital;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Huella";
        }
    }
}
