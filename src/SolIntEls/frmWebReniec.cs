using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace SolIntEls
{
    public partial class frmWebReniec : frmBase
    {
        public frmWebReniec()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.wbrDniReniec.Url = new Uri(clsVarApl.dicVarGen["curlReniec"]);
            this.wbrDniReniec.Refresh();            
        }
    }
}
