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
    public partial class btnMiniActualizar : Button
    {
        public btnMiniActualizar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.MiniUpdate;  
        }

        public btnMiniActualizar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
            protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(36, 28);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }

    }

}
