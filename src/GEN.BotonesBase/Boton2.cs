using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class Boton2 : Button
    {
        public Boton2()
        {
            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Boton_MouseHover);

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(50, 21);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
