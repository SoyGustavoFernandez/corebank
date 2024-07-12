using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnCancelarCred : Boton
    {
        public btnCancelarCred()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.CancelarCred_;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
  
        }
    }
}
