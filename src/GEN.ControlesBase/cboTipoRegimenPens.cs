using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GRH.CapaNegocio;
using System.Data;


namespace GEN.ControlesBase
{
    public partial class cboTipoRegimenPens : cboBase
    {
        public cboTipoRegimenPens()
        {
            InitializeComponent();
        }

        public cboTipoRegimenPens(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoRegimen obj = new clsCNTipoRegimen();
            DataTable dtTipoRegimen = obj.CNListaTipoRegimen();
            this.DataSource = dtTipoRegimen;
            this.ValueMember = dtTipoRegimen.Columns[0].ToString();
            this.DisplayMember = dtTipoRegimen.Columns[1].ToString();

        }
    }
}
