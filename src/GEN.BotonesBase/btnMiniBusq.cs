using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnMiniBusq : Button
    {
        public btnMiniBusq()
        {
            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Boton_MouseHover);
            this.BackgroundImage = Properties.Resources.btnBuscar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(36, 28);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }

        public btnMiniBusq(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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
