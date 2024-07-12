using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConSolesDolar : UserControl
    {
        public int idMoneda;
        public ConSolesDolar()
        {
            InitializeComponent();
        }

        private void ConSolesDolar_Load(object sender, EventArgs e)
        {
            
        }
        public void iMagenMoneda(int _idMoneda)
        {
            this.idMoneda = _idMoneda;
            this.picDolar.Visible = false;
            if (idMoneda == 1)
            {
                this.picDolar.Visible = true;
                this.picDolar.Image = GEN.ControlesBase.Properties.Resources.signo_soles;
            }
            else if (idMoneda == 2)
            {
                this.picDolar.Visible = true;
                this.picDolar.Image = GEN.ControlesBase.Properties.Resources.Signo_dolar;
            }
        }

        private void picDolar_Click(object sender, EventArgs e)
        {

        }

        public int getIdMoneda()
        {
            return this.idMoneda;
        }
    }
}
