using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class pbxAyuda : PictureBox
    {
        public pbxAyuda()
        {
            InitializeComponent();
            this.Image = Properties.Resources.ayuda;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Width = 20;
            this.Height = 20;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
