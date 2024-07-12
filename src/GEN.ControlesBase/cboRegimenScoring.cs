using SPL.CapaNegocio;
using System.ComponentModel;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboRegimenScoring : cboBase
    {
        private clsCNScoring _objCnScoring;

        public bool lAgregarTodos { get; set; }

        public cboRegimenScoring()
        {
            InitControl();
        }

        public cboRegimenScoring(IContainer container)
        {
            container.Add(this);

            InitControl();
        }

        private void InitControl()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();
        }

        public void CargarTodos()
        {
            DataTable dt = _objCnScoring.GetRegimenScoring();
            DisplayMember = "cRegimen";
            ValueMember = "idRegimen";
            if (lAgregarTodos)
            {
                DataRow dr = dt.NewRow();
                dr[ValueMember] = 0;
                dr[DisplayMember] = "TODOS";
                dt.Rows.InsertAt(dr, 0);
            }
            DataSource = dt;
            SelectedIndex = -1;
        }

    }
}
