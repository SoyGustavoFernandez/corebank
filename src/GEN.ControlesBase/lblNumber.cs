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
    public partial class lblNumber: Label
    {
        private decimal value = 0;
        private string format = "0";

        public lblNumber()
        {
            InitializeComponent();
        }

        public string Format { get; set; }

        public decimal Value { 
            get {
                return this.value;
            }
            set {
                this.value = value;
                this.Text = this.value.ToString(this.format);
            }
        }
    }
}
