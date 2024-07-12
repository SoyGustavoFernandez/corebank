using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMotAnulCpg : cboBase
    {
        public cboMotAnulCpg()
        {
            InitializeComponent();
        }

        public cboMotAnulCpg(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dt = new clsCNCajaChica().ListarMotAnulCpg();
            this.DataSource = dt;
            this.ValueMember = "IdMotAnulCpg";
            this.DisplayMember = "cMotAnulCpg";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
