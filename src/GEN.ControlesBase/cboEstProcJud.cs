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
    public partial class cboEstProcJud : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();

        public cboEstProcJud()
        {
            InitializeComponent();
        }

        public cboEstProcJud(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            cargarActivos();
        }

        public void cargarActivos()
        {
            DataTable dt = objProcJud.ListarEstProcJud();
            if (dt.AsEnumerable().Count(x => Convert.ToBoolean(x["lVigente"])) > 0)
            {
                dt = dt.AsEnumerable().Where(x => Convert.ToBoolean(x["lVigente"])).CopyToDataTable();
            }
            this.ValueMember ="idEstProcJud";
            this.DisplayMember = "cEstProcJud";
            this.DataSource = dt; 
        }

        public void cargarTodos()
        {
            DataTable dt = objProcJud.ListarEstProcJud();
            this.ValueMember = "idEstProcJud";
            this.DisplayMember = "cEstProcJud";
            this.DataSource = dt; 
        }

        public void cargarPorTipoProc(int idTipoProcJud)
        {
            DataTable dt = objProcJud.ListarEstPorTipoProc(idTipoProcJud);
            this.ValueMember = "idEstProcJud";
            this.DisplayMember = "cEstProcJud";
            this.DataSource = dt;
        }

        public void cargarPorTipoProcMant(int idTipoProcJud)
        {
            DataTable dt = objProcJud.ListarEstPorTipoProcMant(idTipoProcJud);
            this.ValueMember = "idEstProcJud";
            this.DisplayMember = "cEstProcJud";
            this.DataSource = dt;
        }        
    }
}
