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
    public partial class cboTipoCliente : cboBase
    {
        public cboTipoCliente()
        {
            InitializeComponent();
        }

        public cboTipoCliente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoCliente ListaTipo = new clsCNTipoCliente();
            DataTable dt = ListaTipo.Lista();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ListaPorModulo(int idModulo)
        {
            clsCNTipoCliente ListaTipo = new clsCNTipoCliente();
            DataTable dt = ListaTipo.ListaPorModulo(idModulo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
