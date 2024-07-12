using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class lblBase : Label
    {
        public lblBase()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Font = new Font("verdana", 8, FontStyle.Regular);
            this.ForeColor = Color.Navy;
        }
    }
}
