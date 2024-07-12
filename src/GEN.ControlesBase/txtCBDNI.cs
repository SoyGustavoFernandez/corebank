﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class txtCBDNI : txtBase
    {
        public Boolean lSoloNumeros = false;
        public txtCBDNI()
        {
            InitializeComponent();
        }

        public txtCBDNI(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.MaxLength = 8;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDNI1_KeyPress);
        }

        private void txtDNI1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(!lSoloNumeros)
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
                    var fff = (from L in this.Text.ToString()
                               where L.ToString() == "."
                               select L).Count();

                    if (fff > 0)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                        if (e.KeyChar == 13)
                        {
                            Int32 nCifras = this.TextLength;
                            if (nCifras < 8)
                            {
                                MessageBox.Show("Ingres el DNI correcto ");
                                this.Focus();
                            }
                        }
                    }
                }
            }
        }
    }
}
