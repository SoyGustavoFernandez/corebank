using CAJ.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboEstadoCuentaBco : cboBase
    {
        public cboEstadoCuentaBco()
        {
            InitializeComponent();
        }

        public cboEstadoCuentaBco(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNMovimientoBanco ListaEstadoCtaBco = new clsCNMovimientoBanco();
            DataTable dt = ListaEstadoCtaBco.listarEstadoCuenta();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[2].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
