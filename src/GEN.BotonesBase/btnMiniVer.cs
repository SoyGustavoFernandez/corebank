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
    public partial class btnMiniVer : Button
    {
        public btnMiniVer()
        {
            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.btnMiniVer_MouseLeave);
            this.MouseHover += new System.EventHandler(this.btnMiniVer_MouseHover);
            this.BackgroundImage = Properties.Resources.imagenVisible;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Size = new System.Drawing.Size(22, 22);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }

        private void btnMiniVer_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void btnMiniVer_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
