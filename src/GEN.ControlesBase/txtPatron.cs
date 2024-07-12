using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class txtPatron : TextBox
    {
        public string cPatron = "^.*$";
        public string cPatronValidacion = "^.*$";

        private string cUltimoValido;
        private int lastSelectionStart;

        public txtPatron()
        {
            InitializeComponent();
            this.cUltimoValido = this.Text;
        }

        public txtPatron(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void txtPatron_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.Text, this.cPatron))
            {
                this.Text = this.cUltimoValido;
                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }
            else
            {
                this.cUltimoValido = this.Text;
            }
        }

        public bool valido()
        {
            if (Regex.IsMatch(this.Text, this.cPatronValidacion))
            {
                return true;
            }
            return false;
        }
    }
}
