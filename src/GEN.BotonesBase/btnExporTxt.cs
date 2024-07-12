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
    public partial class btnExporTxt : Boton
    {
        private string _texto = "A&rchivo";

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public btnExporTxt()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnExporTxt;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = _texto;
        }
    }
}
