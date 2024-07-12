using System.ComponentModel;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipObs : cboBase
    {
        public cboTipObs()
        {
            InitializeComponent();
            //LisTipObs(0, 0, 0);
        }

        public cboTipObs(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //LisTipObs(0, 0, 0);
        }

        public void LisTipObs(int idOrigenObs = 0, int idGrupoObs = 0, int idEtapaEvalCred = 0, bool lTodos = false)
        {
            DataTable dtResult = new clsCNObservaciones().CNGetTipObs(idOrigenObs, idGrupoObs, idEtapaEvalCred);
            if (lTodos)
            {
                DataRow drTodos = dtResult.NewRow();
                drTodos["idTipObs"] = 0;
                drTodos["cTipObs"] = "TODOS";
                dtResult.Rows.InsertAt(drTodos, 0);
            }
            this.DisplayMember = "cTipObs";
            this.ValueMember = "idTipObs";
            this.DataSource = dtResult;
        }
    }
}
