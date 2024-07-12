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
    public partial class ConSemaforoLimOpe : UserControl
    {
        public ConSemaforoLimOpe()
        {
            InitializeComponent();
        }

        public ConSemaforoLimOpe(string cNombre, Color color, decimal nValor)
        {
            InitializeComponent();
            lblNombre.Text = cNombre.Trim();
            conCirculoSemaforo.Color = color;
            lblVal.Text = string.Format("{0:#,0.00}%", nValor);
        }
    }
}
