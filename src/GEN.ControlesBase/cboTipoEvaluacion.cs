using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoEvaluacion : cboBase
    {
        clsCNTipoEvaluacion TipoEval = new clsCNTipoEvaluacion();

        public cboTipoEvaluacion()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoEvaluacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListarTipoEvaluacion()
        {
            DataTable dtOperacion = TipoEval.CNListarTipoEvaluacion();
            this.DataSource = dtOperacion;
            this.ValueMember = dtOperacion.Columns["idTipEvalcred"].ToString();
            this.DisplayMember = dtOperacion.Columns["cTipEvalCred"].ToString();
        }
    }
}
