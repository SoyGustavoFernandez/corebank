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
    public partial class btnMiniImprimir : Button
    {
        public btnMiniImprimir()
        {
            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Boton_MouseHover);
            this.BackgroundImage = Properties.Resources.miniImprimir;
        }

        public btnMiniImprimir(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Boton_MouseHover);
            this.BackgroundImage = Properties.Resources.miniImprimir;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(36, 28);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }

        public void Boton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        public void Boton_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        
    }
}
