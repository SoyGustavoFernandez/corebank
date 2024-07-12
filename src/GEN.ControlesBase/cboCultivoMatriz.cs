using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboCultivoMatriz : cboBase
    {
        private clsCNEvalCred objCNEvalCred = new clsCNEvalCred();

        public cboCultivoMatriz()
        {
            InitializeComponent();
        }

        public cboCultivoMatriz(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargar(int idRegistroMatriz, int idAgencia)
        {
            DataTable dt = this.objCNEvalCred.dtCultivoMatriz(idRegistroMatriz, idAgencia);
            this.DisplayMember = "cCultivoEval";
            this.ValueMember = "idCultivoEval";
            this.DataSource = dt;
        }
    }
}
