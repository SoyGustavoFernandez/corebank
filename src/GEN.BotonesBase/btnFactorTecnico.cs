using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnFactorTecnico : Boton2
    {
        public btnFactorTecnico()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnFacTecnico;
            this.Text = "Fac. Tecnico";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40); 
        }
     
    }
}
