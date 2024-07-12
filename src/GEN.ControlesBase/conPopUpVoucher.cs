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
    public partial class conPopUpVoucher : UserControl
    {
        public string cContenidoVoucher { get; set; }
        public conPopUpVoucher()
        {
            InitializeComponent();

            MinimumSize = Size;
            MaximumSize = new Size(Size.Width * 3, Size.Height * 3);
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void WndProc(ref Message m)
        {
            if ((Parent as Popup).ProcessResizing(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void conPopUpVoucher_Load(object sender, EventArgs e)
        {
            lblVoucher.Text = cContenidoVoucher;
        }
    }
}
