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
    public partial class chcBase : CheckBox
    {
        public chcBase()
        {
            InitializeComponent();
        }

        public chcBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
