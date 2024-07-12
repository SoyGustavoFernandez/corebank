using SPL.CapaNegocio;
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
    public partial class cboGrupoFactoresScoring : cboBase
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

        public DataTable DataSourceTable
        {
            get
            {
                if (DataSource != null)
                    return (DataTable)DataSource;
                else
                    return null;
            }
        }

        public cboGrupoFactoresScoring()
        {
            InitControl();
        }

        public cboGrupoFactoresScoring(IContainer container)
        {
            container.Add(this);

            InitControl();
        }

        private void InitControl()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();
        }

        public void CargarTodos(int idTipEval)
        {
            DataTable dt = _objCnScoring.ListaGruposFactoresCalific(idTipEval);
            DisplayMember = "cFactores";
            ValueMember = "idFactor";
            DataSource = dt;
            SelectedIndex = -1;
        }

    }
}
