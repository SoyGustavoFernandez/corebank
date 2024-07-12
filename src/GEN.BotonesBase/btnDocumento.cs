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
    public partial class btnDocumento : Boton2
    {
        public btnDocumento()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnDocumentos;
            this.Text = "Documentos";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40); 
        }
    }
}
