using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class dtLargoBase : DateTimePicker
    {
        public dtLargoBase()
        {
            InitializeComponent();
        }

        public dtLargoBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
