using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class tbcBase : TabControl
    {
        public tbcBase()
        {
            InitializeComponent();
        }

        public tbcBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
