using CNT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoIntangible : cboBase
    {
        public cboTipoIntangible()
        {
            InitializeComponent();
        }

        public cboTipoIntangible(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtTipoIntangible = new clsCNAmortizacion().CNTipoIntangible();
            this.DataSource = dtTipoIntangible;
            this.ValueMember = dtTipoIntangible.Columns[0].ToString();
            this.DisplayMember = dtTipoIntangible.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
