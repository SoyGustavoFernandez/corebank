using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class rbtnBase : RadioButton
    {
        public rbtnBase()
        {
            InitializeComponent();
        }

        public rbtnBase(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        
    }
}
