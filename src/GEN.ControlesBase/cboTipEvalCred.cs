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
    public partial class cboTipEvalCred : cboBase
    {
        clsCNEvalCred objEval;
        public cboTipEvalCred()
        {
            InitializeComponent();
            this.objEval = new clsCNEvalCred();
        }

        public cboTipEvalCred(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.objEval = new clsCNEvalCred();
        }

        public void cargarTipEvaluacion(int idClase)
        {
            DataTable dtTipEval = objEval.listarTipoEvaluacion(idClase);
            
            this.ValueMember = "idTipEvalCred";
            this.DisplayMember = "cTipEvalCred";
            this.DataSource = dtTipEval;
        }
    }
}
