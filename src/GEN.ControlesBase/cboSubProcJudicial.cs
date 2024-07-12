using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboSubProcJudicial : cboBase
    {
        public cboSubProcJudicial()
        {
            InitializeComponent();
        }

        public cboSubProcJudicial(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CargarVigentes();
        }

        public void CargarVigentes()
        {
            DataTable dt = new clsCNProcJud().ListarSubProcesosJudiciales();
            ValueMember = "idSubProcJudicial";
            DisplayMember = "cSubProcJudicial";
            DataSource = dt;
        }
    }
}
