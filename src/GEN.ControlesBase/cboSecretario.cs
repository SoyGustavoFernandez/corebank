using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboSecretario : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();
        public cboSecretario()
        {
            InitializeComponent();
        }

        public cboSecretario(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            cargarVigentes();
        }

        public void cargarVigentes()
        {
            DataTable dt = objProcJud.ListarSecretario();
            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }
            ValueMember = "idSecretario";
            DisplayMember = "cNomSecretario";
            DataSource = dt;
        }

        public void cargarTodos()
        {
            DataTable dt = objProcJud.ListarSecretario();
            ValueMember = "idSecretario";
            DisplayMember = "cNomSecretario";
            DataSource = dt;
        }
    }
}
