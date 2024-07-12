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
    public partial class cboTipoZona : cboBase
    {
        public cboTipoZona()
        {
            InitializeComponent();
        }

        public cboTipoZona(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoZona ListaZona = new clsCNTipoZona();
            DataTable tbZona = ListaZona.ListaZonas();
            this.DataSource = tbZona;
            this.ValueMember = tbZona.Columns[0].ToString();
            this.DisplayMember = tbZona.Columns[1].ToString();
        }
        
    }
}
