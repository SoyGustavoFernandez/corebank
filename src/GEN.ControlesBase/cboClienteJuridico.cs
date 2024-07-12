using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CLI.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboClienteJuridico : cboBase
    {
        public cboClienteJuridico()
        {
            InitializeComponent();
        }

        public cboClienteJuridico(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNRetDatosCliente ListaClientesJuridicos = new clsCNRetDatosCliente();
            DataTable dt = ListaClientesJuridicos.ListarClientesJuridicos();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idCli"].ToString();
            this.DisplayMember = dt.Columns["cNombreComercial"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
