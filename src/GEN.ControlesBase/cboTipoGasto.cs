using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoGasto : cboBase
    {
        public cboTipoGasto()
        {
            InitializeComponent();
        }

        public cboTipoGasto(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNTipoGasto objTipoGasto = new clsCNTipoGasto();
            DataTable dtbTipoGasto = objTipoGasto.ListaTipoGasto();
            this.DataSource = dtbTipoGasto;
            this.ValueMember = dtbTipoGasto.Columns["idGasto"].ToString();
            this.DisplayMember = dtbTipoGasto.Columns["cGasto"].ToString();
        }

    }
}
