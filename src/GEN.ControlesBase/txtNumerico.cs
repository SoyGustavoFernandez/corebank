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
    public partial class txtNumerico : TextBox
    {
        #region "Declarations"
        private string nFormat = "n2";
        #endregion

        #region "Properties"
        /// <summary>
        /// Establece el formato del TextBox con ".NET Standard Number Format Strings"
        /// 
        /// Ejemplo : 
        ///     Format  : "N2";
        ///     Input   : 1234
        ///     Retorno : 1,234.00
        /// </summary>
        public string Format
        {
            get
            {
                return nFormat;
            }
            set
            {
                nFormat = value;
            }
        }

        #endregion

        public txtNumerico()
        {
            InitializeComponent();
        }

        public txtNumerico(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(txtNumerico_KeyPress);
            this.LostFocus += new EventHandler(txtNumerico_LostFocus);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void txtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Format == null) this.Format = "N2";

            char d = this.Format[1];

            bool esInt = true;
            int intValue = 0;
            esInt = int.TryParse(d.ToString(), out intValue);

            if (intValue == 0)
            {
                // allowed only numeric value  ex. 10
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                // allowed numeric and one dot  ex. 10.23
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtNumerico_LostFocus(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (string.IsNullOrEmpty(tbx.Text))
            {
                tbx.Text = "0";
            }
            else
            {
                //bool esInt = true;
                //double doubleValue = 0;
                //esInt = double.TryParse(tbx.Text, out doubleValue);
                //tbx.Text = string.Format("{0:" + Format + "}", doubleValue);

                if (tbx.Text == ".")
                    this.Text = "0.00";

            }

            //tbx.Text = string.Format("{0:" + Format + "}", Convert.ToDecimal(tbx.Text));
            tbx.Text = string.Format("{0:" + Format + "}", tbx.Text);
        }
    }
}
