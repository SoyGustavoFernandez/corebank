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
    public partial class cboClienteCargo : cboBase
    {
        public cboClienteCargo()
        {
            InitializeComponent();
        }

        public cboClienteCargo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNClienteCargo objClienteCargo = new clsCNClienteCargo();
            DataTable dt = objClienteCargo.CNListaClienteCargos();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idCliCargo"].ToString();
            this.DisplayMember = dt.Columns["cClienteCargo"].ToString();
        }
    }
}