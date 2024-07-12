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
    public partial class btnMiniBusqueda : Button
    {
        public btnMiniBusqueda()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnBuscar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Size = new System.Drawing.Size(32, 25);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }

        public btnMiniBusqueda(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnBuscar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Size = new System.Drawing.Size(32, 25);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Text = "";
        }
    }
}
