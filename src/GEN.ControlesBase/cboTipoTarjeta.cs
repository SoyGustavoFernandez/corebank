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
    public partial class cboTipoTarjeta : cboBase
    {
        public cboTipoTarjeta()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoTarjeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtTarj = new DataTable();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns["idTipTarjeta"].ToString();
            this.DisplayMember = dtTarj.Columns["cTipoTarjeta"].ToString();
        }
    }
}
