using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnDevolver : Boton
    {
        public btnDevolver()
        {
            InitializeComponent();
        }

        public btnDevolver(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Devolver";
        }
    }
}
