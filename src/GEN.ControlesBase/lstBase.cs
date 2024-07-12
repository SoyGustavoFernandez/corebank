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
    public partial class lstBase : ListBox
    {
        public lstBase()
        {
            InitializeComponent();
        }

        public lstBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
