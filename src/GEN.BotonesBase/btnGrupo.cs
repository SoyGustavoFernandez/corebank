using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnGrupo : Boton2
    {
        public btnGrupo()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnGrupo;
            this.Text = "Grupo";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40); 
        }

       
    }
}
