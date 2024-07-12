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
    public partial class cboVariedadCultivoMatriz : cboBase
    {
        private clsCNEvalCred objCNEvalCred = new clsCNEvalCred();

        public cboVariedadCultivoMatriz()
        {
            InitializeComponent();
        }

        public cboVariedadCultivoMatriz(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargar(int idRegistroMatriz, int idAgencia, int idCultivoEval)
        {
            DataTable dt = this.objCNEvalCred.dtVariedadCultivoMatriz(idRegistroMatriz, idAgencia, idCultivoEval);
            this.DisplayMember = "cVariedadCultivoEval";
            this.ValueMember = "idVariedadCultivoEval";
            this.DataSource = dt;
        }
    }
}
