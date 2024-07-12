using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoConst : cboBase
    {
        private clsCNTipoConstruccion objTipoCons = new clsCNTipoConstruccion();
      
        public cboTipoConst()
        {
            InitializeComponent();
        }

        public cboTipoConst(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtTipoCons = objTipoCons.CNListaTipoContruccion();
            this.DataSource = dtTipoCons;
            this.ValueMember = dtTipoCons.Columns["idTipoConstruccion"].ToString();
            this.DisplayMember = dtTipoCons.Columns["cTipoConstruccion"].ToString();
        }

    }
}
