using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnMarcarAsistencia : Boton
    {
        public btnMarcarAsistencia()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnMarcarAsistencia;
            this.Text = "Marcar";
        }
    }
}
