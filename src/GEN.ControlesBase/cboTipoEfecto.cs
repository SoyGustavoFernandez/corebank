using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoEfecto : cboBase
    {
        public cboTipoEfecto()
        {
            InitializeComponent();
        }

        public cboTipoEfecto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dt = new clsCNTipoEfecto().ListarTipoEfecto();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
