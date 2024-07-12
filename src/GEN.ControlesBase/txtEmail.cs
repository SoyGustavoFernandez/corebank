using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GEN.ControlesBase
{
    public partial class txtEmail : txtBase
    {
        public int arrobas;
        public int puntos;
        Regex xrEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        public txtEmail()
        {
            InitializeComponent();
        }

        public txtEmail(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            puntos = 0;

            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtEmail1_KeyPress);

        }


        public void txtEmail1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)//retroceso
            {
                e.Handled = false;
                return;
            }
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)//numeros
            {
                e.Handled = false;
                return;
            }
            else if (e.KeyChar >= 65 && e.KeyChar <= 90)//letras mayusculas
            {
                e.Handled = false;
                return;
            }
            else if (e.KeyChar >= 97 && e.KeyChar <= 122)//letras minusculas
            {
                e.Handled = false;
                return;
            }

            else if ( e.KeyChar == 45 ||  e.KeyChar == 95 )//guion y subguion
            {
                e.Handled = false;
                return;
            }
            else if( e.KeyChar == 64)//arroba
            {
                int CantArrobas = 0;

                for (int i = 0; i < this.TextLength; i++) {

                    if (this.Text.Substring(i, 1) == "@")
                    {
                        CantArrobas = 1;
                    }
                }
                if(CantArrobas==1)
                         e.Handled = true;
                    else
                        e.Handled = false;
            }
            else if (e.KeyChar == 46)//punto
            {
                int CantLetras = this.TextLength;
                if (CantLetras >= 1) {
                    if (this.Text.Substring((CantLetras-1), 1) == ".")
                    {
                        e.Handled = true;
                    }
                    else
                        e.Handled = false;
                }
            }

            else
                {
                    e.Handled = true;
                }
        }


        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!xrEmail.IsMatch(this.Text) && !String.IsNullOrEmpty(this.Text.Trim()))
            {
                MessageBox.Show("El texto introducido no tiene el formato de un email ", "Validación de Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
                this.Clear();
                return;
            }
        }
    }
}

