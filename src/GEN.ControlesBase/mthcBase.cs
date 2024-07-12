using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class mthcBase : MonthCalendar
    {
        public mthcBase()
        {
            InitializeComponent();
        }

        public mthcBase(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
