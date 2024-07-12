using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboMotivoBloqTarjeta : cboBase
    {
        public cboMotivoBloqTarjeta()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboMotivoBloqTarjeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarMotBloq(1);
        }

        public void CargarMotBloq(int idTipBloqDesb)
        {
            DataTable dtTarj = new DataTable();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns["idMotivoBloq"].ToString();
            this.DisplayMember = dtTarj.Columns["cMotivoBloq"].ToString();
        }
    }
}
