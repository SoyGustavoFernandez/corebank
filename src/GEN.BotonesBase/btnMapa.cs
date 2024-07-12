using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnMapa : Boton
    {
        public btnMapa()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.mapa;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "Mapa";
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;            
        }
    }
}
