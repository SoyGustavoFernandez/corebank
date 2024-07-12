using System;
using System.Drawing;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnMiniExcel : Button
    {
        public btnMiniExcel()
        {
            InitializeComponent();
            this.MouseLeave += new EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new EventHandler(this.Boton_MouseHover);
            this.BackgroundImage = Properties.Resources.exportexcel;
            this.BackgroundImageLayout = ImageLayout.None;
            this.Size = new Size(100, 30);
            this.TextAlign = ContentAlignment.MiddleRight;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Padding = new Padding(2, 2, 2, 1);
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void Boton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        public void Boton_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
