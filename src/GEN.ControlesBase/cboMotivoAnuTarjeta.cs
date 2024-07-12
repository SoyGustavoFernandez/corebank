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
    public partial class cboMotivoAnuTarjeta : cboBase
    {
        public cboMotivoAnuTarjeta()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboMotivoAnuTarjeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtTarj = new DataTable();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns["idMotivoAnul"].ToString();
            this.DisplayMember = dtTarj.Columns["cMotivoAnul"].ToString();
        }
    }
}
