using GEN.CapaNegocio;
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
    public partial class cboVariableRecuperaciones : cboBase
    {
        public cboVariableRecuperaciones()
        {
            InitializeComponent();
        }

        public cboVariableRecuperaciones(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dt = new clsCNVariableRecuperaciones().listar();

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idVariableRecuperacion"].ToString();
            this.DisplayMember = dt.Columns["cVariableRecuperacion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
