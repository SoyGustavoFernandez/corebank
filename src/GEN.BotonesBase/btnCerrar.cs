using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnCerrar : Boton
    {
        public btnCerrar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnCerrar;
            this.Text = "Ce&rrar";
        }
    }
}
