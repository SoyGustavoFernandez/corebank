using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class txtCBRUC : txtBase
    {
        public txtCBRUC()
        {
            InitializeComponent();

        }

        public txtCBRUC(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.MaxLength = 11;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtRUC_KeyPress);

        }

        private void txtRUC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;

            }
            else
            {
                    e.Handled = true;
                  if (e.KeyChar == 13)
                     {
                    Int32 NumeroRuc = this.TextLength;
                    if (NumeroRuc < 11)
                    {
                        MessageBox.Show("Ingres el Numero de RUC Correcto");
                        this.Focus();
                    }
                        
                
                }
               


            }


        }
    
    }
}
