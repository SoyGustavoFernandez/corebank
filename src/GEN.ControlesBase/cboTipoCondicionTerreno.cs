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
    public partial class cboTipoCondicionTerreno : cboBase
    {
        public cboTipoCondicionTerreno()
        {
            InitializeComponent();
        }

        public cboTipoCondicionTerreno(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoCondicionTerreno ListaCondicionTerreno = new clsCNTipoCondicionTerreno();
            DataTable tbCondicionTerreno = ListaCondicionTerreno.ListaCondicionTerreno();
            this.DataSource = tbCondicionTerreno;
            this.ValueMember = tbCondicionTerreno.Columns[0].ToString();
            this.DisplayMember = tbCondicionTerreno.Columns[1].ToString();
        }
        
    }
}
