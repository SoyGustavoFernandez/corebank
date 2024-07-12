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
    public partial class cboTipVivienda : cboBase
    {
        public cboTipVivienda()
        {
            InitializeComponent();
        }

        public cboTipVivienda(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoVivienda ListaVivienda = new clsCNTipoVivienda();
            DataTable tbVivienda = ListaVivienda.ListaViviendas();
            this.DataSource = tbVivienda;
            this.ValueMember = tbVivienda.Columns[0].ToString();
            this.DisplayMember = tbVivienda.Columns[1].ToString();
        }
    }
}
