using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTipoCuentaBco : cboBase
    {
        public cboTipoCuentaBco()
        {
            InitializeComponent();
        }

        public cboTipoCuentaBco(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNMovimientoBancario listaTipoCuentaBco = new clsCNMovimientoBancario();
            DataTable dt = listaTipoCuentaBco.ListarTipoCuentaBco();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
