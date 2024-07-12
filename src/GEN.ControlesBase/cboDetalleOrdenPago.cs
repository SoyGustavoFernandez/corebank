using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SPL.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboDetalleOrdenPago : cboBase
    {
        public cboDetalleOrdenPago()
        {
            InitializeComponent();
        }

        public cboDetalleOrdenPago(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dt = new clsCNRegistroOperacion().CNListarSplaftDetNotaPedido();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
