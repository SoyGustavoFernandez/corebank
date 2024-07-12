using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboSeguros : cboBase
    {
        public DataTable dtSeguro;
        public cboSeguros()
        {
            InitializeComponent();
        }

        public cboSeguros(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            dtSeguro = new clsCNSeguros().LisSeguro();
            this.DataSource = dtSeguro;

            if (dtSeguro.Rows.Count > 0)
            {
                this.ValueMember = dtSeguro.Columns["idTipoPlan"].ToString();
                this.DisplayMember = dtSeguro.Columns["cDescripcion"].ToString();
            }
        }
    }
}