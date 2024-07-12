using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnCalendario : Boton2
    {
        public btnCalendario()
        {
            InitializeComponent();         
            this.BackgroundImage = Properties.Resources.btncalendar;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(89, 40);
            this.Text = "Calendario";
        }
    }
}
