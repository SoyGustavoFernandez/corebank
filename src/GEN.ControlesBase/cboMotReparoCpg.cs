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
    public partial class cboMotReparoCpg : cboBase
    {
        public cboMotReparoCpg()
        {
            InitializeComponent();
        }

        public cboMotReparoCpg(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNCajaChica objCajChica = new clsCNCajaChica();
            DataTable dt = objCajChica.ListarMotReparoCpg();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["IdMotReparoCpg"].ToString();
            this.DisplayMember = dt.Columns["cDesMotReparo"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
