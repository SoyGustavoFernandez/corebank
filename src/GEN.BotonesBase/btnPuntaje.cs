using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnPuntaje : Boton2
    {
        public btnPuntaje()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnPuntaje1;
            this.Text = "Puntajes";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40); 
        }
    }
}
