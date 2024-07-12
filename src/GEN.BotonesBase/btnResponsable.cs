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
    public partial class btnResponsable : BotonNormal
    {
        public btnResponsable()
        {
            InitializeComponent();
        }

        public btnResponsable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [System.Diagnostics.DebuggerNonUserCode]
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Responsable";
        }
    }
}
