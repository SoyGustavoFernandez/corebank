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

    public partial class txtCBCorreoElectronico : txtBase
    {
        public txtCBCorreoElectronico()
        {
            InitializeComponent();
        }

        public txtCBCorreoElectronico(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCorreoElectronico1_KeyPress);
        }
        private void txtCorreoElectronico1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
            
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 64 && e.KeyChar <= 90)
            {
                e.Handled = false;
            }
            else if (e.KeyChar >= 97 && e.KeyChar <= 122)
            {
                e.Handled = false;
            }
           
            else
            {
                
                if (e.KeyChar == 47 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 95 || e.KeyChar ==64)
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }

            }

                                  
        }
    }
}
