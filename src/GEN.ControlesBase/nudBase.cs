using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class nudBase : NumericUpDown
    {
        public nudBase()
        {
            InitializeComponent();
        }

        public nudBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
