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
    public partial class cboEstPersonal : cboBase
    {
        public cboEstPersonal()
        {
            InitializeComponent();
        }

        public cboEstPersonal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNEstPersonal ListaEstPersonal = new clsCNEstPersonal();
            DataTable dtListaEstPersonal = ListaEstPersonal.ListaEstPersonal();
            this.DataSource= dtListaEstPersonal;
            this.ValueMember = dtListaEstPersonal.Columns[0].ToString();
            this.DisplayMember = dtListaEstPersonal.Columns[1].ToString();
        }

    }
}


