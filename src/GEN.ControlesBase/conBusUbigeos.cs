using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class conBusUbigeos : UserControl
    {
        private Int32 nIdNodo = 0;

        public conBusUbigeos()
        {
            InitializeComponent();
            this.cboUbigeo1.CargarUbigeo(nIdNodo);
        }

        private void cboUbigeo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUbigeo1.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboUbigeo1.SelectedValue);
                cboUbigeo2.CargarUbigeo(nIdNodo);
            }
            else
            {
                cboUbigeo1.SelectedIndex = 0;
            }
        }

        private void cboUbigeo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUbigeo2.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboUbigeo2.SelectedValue);
                cboUbigeo3.CargarUbigeo(nIdNodo);
            }
            else
            {
                cboUbigeo2.SelectedIndex = 0;
            }
        }

        private void cboUbigeo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUbigeo3.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboUbigeo3.SelectedValue);
                cboUbigeo4.CargarUbigeo(nIdNodo);
            }
            else
            {
                cboUbigeo3.SelectedIndex = 0;
            }
        }


        private void cboUbigeo4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboUbigeo4.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboUbigeo4.SelectedValue);
                cboUbigeo5.CargarUbigeo(nIdNodo);
                
            }
            else
            {
                cboUbigeo4.SelectedIndex = 0;
            }
        }

        private void conBusUbigeos_Load(object sender, EventArgs e)
        {
           
        }

    }
}
