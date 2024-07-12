using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.BotonesBase;
namespace GEN.BotonesBase
{
    public partial class btnEvaEconomica : Boton2
    {
        public btnEvaEconomica()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnEconomica1;
            this.Text = "Eva. Económica";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40); 
        }

       
    }
}
