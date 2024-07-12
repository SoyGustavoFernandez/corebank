using SPL.CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace GEN.ControlesBase
{
    public partial class cboCalifScoring : cboBase
    {

        private clsCNScoring _objCnScoring;

        public bool lAgregarTodos { get; set; }

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

        public cboCalifScoring()
        {
            InitControl();
        }

        public cboCalifScoring(IContainer container)
        {
            container.Add(this);
            InitControl();
        }

        private void InitControl()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();
        }

        public void CargarTodos(int idCalif)
        {
            DataTable dt = _objCnScoring.ListaDesCalificacion(idCalif);
            DisplayMember = "cCalificativo";
            ValueMember = "idCalificativo";
            if (lAgregarTodos)
            {
                DataRow dr = dt.NewRow();
                dr[ValueMember] = 0;
                dr[DisplayMember] = "*** TODOS ***";
                dt.Rows.InsertAt(dr, 0);
                
            }

            DataSource = dt;
            SelectedIndex = -1;
        }

        public void CargarVigentes(int idCalif)
        {
            DataTable dt = _objCnScoring.ListaDesCalificacion(idCalif);
            dt.DefaultView.RowFilter = "lVigente = 1";
            DisplayMember = "cCalificativo";
            ValueMember = "idCalificativo";
            if (lAgregarTodos)
            {
                foreach(DataColumn col in dt.Columns)
                {
                    col.AllowDBNull = true;
                }
                DataRow dr = dt.NewRow();
                dr[ValueMember] = 0;
                dr[DisplayMember] = "*** TODOS ***";
                dr["lVigente"] = true;
                dt.Rows.InsertAt(dr, 0);
            }
            DataSource = dt;
            SelectedIndex = -1;
        }
    }
}
