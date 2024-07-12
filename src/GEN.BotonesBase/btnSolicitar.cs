using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnSolicitar : Boton
    {

        public btnSolicitar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnSolicitar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "Solicitar";
        }
    }
}
