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
    public partial class btnEliLista : Boton
    {
        public btnEliLista()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btn_detalle;
        }

        public btnEliLista(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Text = "&Limpiar";
        }
    }
}
