using SPL.CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace GEN.ControlesBase
{
    public partial class cboTipoEvalScoring : cboBase
    {
        private clsCNScoring _objCnScoring;

        public IEnumerable<DataRow> DataSourceRows
        {
            get
            {
                if (DataSource != null)
                    return ((DataTable)DataSource).AsEnumerable();
                else
                    return null;
            }
        }

        public cboTipoEvalScoring()
        {
            InitControl();
        }

        public cboTipoEvalScoring(IContainer container)
        {
            container.Add(this);

            InitControl();
        }

        private void InitControl()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();
        }

        public void CargarPorGrupo(int idGrupoEval, bool lSoloVigentes = true)
        {
            FillControl(idGrupoEval, 0, lSoloVigentes);
        }

        public void CargarPorTipoPersona(int idTipoPersona, bool lSoloVigentes = true)
        {
            FillControl(0, idTipoPersona, lSoloVigentes);
        }

        public void CargarListaTipoEval() {
            FillControl(0, 0, true, true);
        }

        private void FillControl(int idGrupoEval, int idTipoPersona, bool lSoloVigentes, bool lTodos = false)
        {
            DataTable dt = _objCnScoring.ListaTiposEvaluacion(idGrupoEval, idTipoPersona);


            if (lSoloVigentes)
                dt.DefaultView.RowFilter = ("lVigente = 1");

            if (lTodos)
            {
                DataRow dr = dt.NewRow();
                dr["cEvaluacion"] = " *** TODOS ***";
                dr["idEvaluacion"] = 0;
                dr["lVigente"] = 1;
                dt.Rows.Add(dr);

            }
            this.DataSource = dt;
            this.DisplayMember = "cEvaluacion";
            this.ValueMember = "idEvaluacion";

            if (lTodos)
            {
                SelectedValue = 0;
            }
            else
            {
                SelectedIndex = -1;
            }
        }
    }
}
