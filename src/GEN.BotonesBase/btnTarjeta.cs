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
    public partial class btnTarjeta : Boton
    {
        public btnTarjeta()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnTarjeta;
        }

        public btnTarjeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Text = "&Tarjeta";
        }
    }
}
