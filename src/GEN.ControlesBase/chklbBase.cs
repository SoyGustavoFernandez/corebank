using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class chklbBase : CheckedListBox
    {
        public chklbBase()
        {
            InitializeComponent();
        }

        public chklbBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
