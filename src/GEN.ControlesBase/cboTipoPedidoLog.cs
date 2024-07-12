using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoPedidoLog : cboBase
    {
        public cboTipoPedidoLog()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoPedidoLog(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            DataTable dt = listTipoProceso.listarTipoPedido();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();  
        }
    }
}
