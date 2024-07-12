using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstSolCred : cboBase
    {
        public cboEstSolCred()
        {
            InitializeComponent();
        }

        public void ListEstCred(int idEstadoPadre = 0, bool lTodos = false)
        {
            DataTable dtRes = new clsCNEstadoCredito().CNListarEstadoSolCredito(idEstadoPadre);
            if (lTodos)
            {
                DataRow drTodos = dtRes.NewRow();
                drTodos["IdEstado"] = 9999;
                drTodos["cEstado"] = "TODOS";
                dtRes.Rows.InsertAt(drTodos, 0);
            }
            this.DisplayMember = "cEstado";
            this.ValueMember = "IdEstado";
            this.DataSource = dtRes;
        }
    }
}