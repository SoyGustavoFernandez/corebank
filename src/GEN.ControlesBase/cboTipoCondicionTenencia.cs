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
    public partial class cboTipoCondicionTenencia : cboBase
    {
        public cboTipoCondicionTenencia()
        {
            InitializeComponent();
        }

        public cboTipoCondicionTenencia(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoCondicionTenencia ListaCondicionTenencia = new clsCNTipoCondicionTenencia();
            DataTable tbCondicionTenencia = ListaCondicionTenencia.ListaCondicionTenencia();
            this.DataSource = tbCondicionTenencia;
            this.ValueMember = tbCondicionTenencia.Columns[0].ToString();
            this.DisplayMember = tbCondicionTenencia.Columns[1].ToString();
        }
        
    }
}
