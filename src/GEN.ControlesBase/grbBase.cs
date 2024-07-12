using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class grbBase : GroupBox
    {
        public grbBase()
        {
            InitializeComponent();
        }

        public grbBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
