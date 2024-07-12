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
    public partial class cboEstadoTarjeta : cboBase
    {
        public cboEstadoTarjeta()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboEstadoTarjeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtTarj = new DataTable();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns["idEstTarjeta"].ToString();
            this.DisplayMember = dtTarj.Columns["cEstadoTarjeta"].ToString();

        }
    }
}
