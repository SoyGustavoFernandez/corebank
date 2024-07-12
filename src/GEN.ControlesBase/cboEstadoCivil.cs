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
    public partial class cboEstadoCivil : cboBase
    {
        public DataTable tbEstCivil= new DataTable() ;
        public cboEstadoCivil()
        {
            InitializeComponent();
        }

        public cboEstadoCivil(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }
        public void CargarEstadoCivil(Int32 nInd)
        {
            clsCNEstadoCivil ListaEstCivil = new clsCNEstadoCivil();
            tbEstCivil = ListaEstCivil.ListaEstadoCivil(nInd);
            this.DataSource = tbEstCivil;
            this.ValueMember = tbEstCivil.Columns[0].ToString();
            this.DisplayMember = tbEstCivil.Columns[1].ToString();

        }
    }
}
