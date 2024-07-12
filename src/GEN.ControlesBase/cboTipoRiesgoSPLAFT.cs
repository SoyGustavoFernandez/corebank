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
    public partial class cboTipoRiesgoSPLAFT : cboBase
    {
        private clsCNScoring _objCnScoring;
        public bool lAgregarTodos { get; set; }
        public cboTipoRiesgoSPLAFT()
        {
            InitControl();
        }

        public cboTipoRiesgoSPLAFT(IContainer container)
        {
            container.Add(this);
            InitControl();
        }

        private void InitControl()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();
        }

        public void ListarTodos()
        {
            DataTable dt = _objCnScoring.GetTipoRiesgoSPLAFT();
            DisplayMember = "cTipoRiesgo";
            ValueMember = "idTipoRiesgo";
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
