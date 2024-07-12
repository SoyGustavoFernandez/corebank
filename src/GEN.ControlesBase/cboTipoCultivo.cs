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
    public partial class cboTipoCultivo : cboBase
    {
        private clsCNEvalCred objCNEvalCred = new clsCNEvalCred();

        public cboTipoCultivo()
        {
            InitializeComponent();
        }

        public cboTipoCultivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargar(int idRegistroMatriz, int idAgencia, int idCultivoEval, int idVariedadCultivoEval)
        {
            DataTable dt = this.objCNEvalCred.dtTipoCultivoMatriz(idRegistroMatriz, idAgencia, idCultivoEval, idVariedadCultivoEval);
            this.DisplayMember = "cTipoCultivo";
            this.ValueMember = "idTipoCultivo";
            this.DataSource = dt;
        }
    }
}
