using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRC.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoConsejo : cboBase
    {
        public cboTipoConsejo()
        {
            InitializeComponent();
        }

        public cboTipoConsejo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dt = new clsCNTipoConsejo().ListarTipoConsejo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
