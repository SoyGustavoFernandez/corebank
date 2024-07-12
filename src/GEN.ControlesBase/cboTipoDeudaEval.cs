using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoDeudaEval : cboBase
    {
        public cboTipoDeudaEval()
        {
            InitializeComponent();
        }

        public cboTipoDeudaEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargarDatos()
        {
            clsCNEvalConsumo cnEvalCon = new clsCNEvalConsumo();
            DataTable dtRes = cnEvalCon.CNListaTipoDeuda(1);
            this.ValueMember = dtRes.Columns[0].ToString();
            this.DisplayMember = dtRes.Columns[1].ToString();
            this.DataSource = dtRes;
        }
    }
}
