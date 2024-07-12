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
    public partial class btnImportar : Boton
    {
        public btnImportar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnImportar;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Importar";
        }
    }
}