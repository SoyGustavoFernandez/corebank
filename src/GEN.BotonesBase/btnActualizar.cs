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
    public partial class btnActualizar : Boton
    {
        private string _texto="Act&ualiza";

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public btnActualizar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.update;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = _texto;
            
        }
    }
}
