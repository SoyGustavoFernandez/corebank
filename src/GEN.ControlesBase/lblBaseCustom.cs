using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class lblBaseCustom : Label
    {
        public lblBaseCustom()
        {
            InitializeComponent();
        }

        public lblBaseCustom(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
