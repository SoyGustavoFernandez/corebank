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
    public partial class btnProyeccion : Button
    {
        public btnProyeccion()
        {
            InitializeComponent();
            this.Image = Properties.Resources.btnProyeccion;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
          
        }
    }
}
