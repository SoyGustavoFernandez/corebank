using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoVia : cboBase
    {
        public cboTipoVia()
        {
            InitializeComponent();
        }

        public cboTipoVia(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNTipoVia ListaVia = new clsCNTipoVia();
            DataTable tbVia = ListaVia.ListaVias();
            this.DataSource = tbVia;
            this.ValueMember = tbVia.Columns[0].ToString();
            this.DisplayMember = tbVia.Columns[1].ToString();
        }
    }
}
