using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoCuentaCli :cboBase
    {
        public cboEstadoCuentaCli()
        {
            InitializeComponent();
        }

        public cboEstadoCuentaCli(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNEstadoActual ListadoEstadoActual = new clsCNEstadoActual();
            DataTable dt = ListadoEstadoActual.listarEstadoCuentaCli();
            this.DataSource=dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
