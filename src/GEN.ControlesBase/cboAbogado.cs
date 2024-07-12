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
    public partial class cboAbogado : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();
        public cboAbogado()
        {
            InitializeComponent();
        }

        public cboAbogado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            cargarVigentes();
        }

        public void cargarVigentes()
        {
            DataTable dt = objProcJud.ListarAbogado();
            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }
            ValueMember = "idAbogado";
            DisplayMember = "cNomAbogadoIFI";
            DataSource = dt;     
        }

        public void cargarTodos()
        {
            DataTable dt = objProcJud.ListarAbogado(); 
            ValueMember = "idAbogado";
            DisplayMember = "cNomAbogadoIFI";
            DataSource = dt;
        }


    }
}
