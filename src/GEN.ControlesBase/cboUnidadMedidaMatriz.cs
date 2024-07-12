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
    public partial class cboUnidadMedidaMatriz : cboBase
    {
        private clsCNEvalCred objCNEvalCred = new clsCNEvalCred();

        public cboUnidadMedidaMatriz()
        {
            InitializeComponent();
        }

        public cboUnidadMedidaMatriz(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargar(int idRegistroMatriz, int idAgencia, int idCultivoEval, int idVariedadCultivoEval, int idTipoCultivo, int idTipoFinanciamiento)
        {
            DataTable dt = this.objCNEvalCred.dtUnidadMedidaMatriz(idRegistroMatriz, idAgencia, idCultivoEval, idVariedadCultivoEval, idTipoCultivo, idTipoFinanciamiento);
            this.DisplayMember = "cUnidadMedida";
            this.ValueMember = "idUnidadMedida";
            this.DataSource = dt;
        }
    }
}
