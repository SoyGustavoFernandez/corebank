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
    public partial class btnFiltrar : Boton
    {
        public btnFiltrar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnFiltrar; 
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Text = "Filtrar";
        }
    }
}
