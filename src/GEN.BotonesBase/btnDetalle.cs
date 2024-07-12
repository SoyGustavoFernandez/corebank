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
    public partial class btnDetalle : Boton
    {
        private string _texto = "&Detallar";

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public btnDetalle()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btn_detalle;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = _texto;
        }
    }
}
