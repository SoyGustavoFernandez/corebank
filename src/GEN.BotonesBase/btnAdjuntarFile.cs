using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.BotonesBase
{
    public partial class btnAdjuntarFile : Boton
    {
        public btnAdjuntarFile()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.pdf;
        }

        public btnAdjuntarFile(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.BackgroundImage = Properties.Resources.pdf;
        }
    }
}
