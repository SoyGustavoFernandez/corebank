using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoPeriodo : cboBase
    {
        public cboEstadoPeriodo()
        {
            InitializeComponent();
        }

        public cboEstadoPeriodo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtTarj = new clsCNEstadoPeriodo().CNListadoEstPeriodo();
            this.DataSource = dtTarj;
            this.ValueMember = dtTarj.Columns[0].ToString();
            this.DisplayMember = dtTarj.Columns[1].ToString();
        }
    }
}
