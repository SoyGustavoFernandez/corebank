using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboCriBusGar : cboBase
    {
        public cboCriBusGar()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboCriBusGar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable TablaCriBus = new clsCNGarantia().listarCriterioBus();
            this.DataSource = TablaCriBus;
            this.ValueMember = TablaCriBus.Columns[0].ToString();
            this.DisplayMember = TablaCriBus.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
          }
    }
}
