using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class dtpCorto : DateTimePicker
    {
        public dtpCorto()
        {
            InitializeComponent();            
        }

        public dtpCorto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Format = DateTimePickerFormat.Short;
        }
    }
}
