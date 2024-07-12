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
    public partial class cboJuzgado : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();
        public cboJuzgado()
        {
            InitializeComponent();
        }

        public cboJuzgado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
           
            cargarVigentes();
        }

        public void cargarVigentes()
        {
            DataTable dt = objProcJud.ListarJuzgados();
            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }
            ValueMember = "idJuzgado";
            DisplayMember = "cJuzgado";
            DataSource = dt;
        }

        public void cargarTodos()
        {
            DataTable dt = objProcJud.ListarJuzgados();
            
            ValueMember = "idJuzgado";
            DisplayMember = "cJuzgado";
            DataSource = dt;
        }
    }
}
