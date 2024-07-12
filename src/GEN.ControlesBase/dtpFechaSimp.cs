using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GEN.ControlesBase
{
    public partial class dtpFechaSimp : DateTimePicker
    {

        public dtpFechaSimp()
        {
            InitializeComponent();
            
        }

        public dtpFechaSimp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

    }
}
