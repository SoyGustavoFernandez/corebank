using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEP.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboLimitesVal : cboBase
    {
        public cboLimitesVal()
        {
            InitializeComponent();
        }

        public cboLimitesVal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNValorados objListaLimVal = new clsCNValorados();
            DataTable dt = objListaLimVal.CNListaLimiteValorados();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idLimiteVal"].ToString();
            this.DisplayMember = dt.Columns["nValorLim"].ToString();

        }
    }
}
