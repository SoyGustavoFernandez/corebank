using CAJ.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboEstadoSolic : cboBase
    {
        public cboEstadoSolic()
        {
            InitializeComponent();
        }

        public cboEstadoSolic(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNEstadoSolic ListaEstadoSol = new clsCNEstadoSolic();
            DataTable dt = ListaEstadoSol.listarEstadoSolic();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            
        }
        public void EstadosYTodos()
        {
            clsCNEstadoSolic ListaEstadoSol = new clsCNEstadoSolic();
            DataTable dt = ListaEstadoSol.listarEstadoSolic();

            DataRow row = dt.NewRow();
            row["idEstadoSol"] = 0;
            row["cEstadoSol"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }

        public void EstSol(int idEstadoSol)
        {
            clsCNEstadoSolic ListaEstadoSol = new clsCNEstadoSolic();
            DataTable dt = ListaEstadoSol.CNlistarEstSolic(idEstadoSol);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }

        public void EstadosPermisos()
        {
            clsCNEstadoSolic ListaEstadoSol = new clsCNEstadoSolic();
            DataTable dt = ListaEstadoSol.CNlistaEstSolicitudPermiso();

            DataRow row = dt.NewRow();
            row["idEstadoSol"] = 0;
            row["cEstadoSol"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }

        public void EstadosFiltroTodos(string cVariableLista)
        {
            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable == cVariableLista);
            List<int> lstRolFormulario = objVarGen.cValVar.Split(',').Select(item => Convert.ToInt32(item)).ToList();
            
            clsCNEstadoSolic ListaEstadoSol = new clsCNEstadoSolic();
            DataTable dt = ListaEstadoSol.listarEstadoSolic();

            DataTable dtFiltro = dt.AsEnumerable().Where(item => lstRolFormulario.Contains(Convert.ToInt32(item["idEstadoSol"]))).CopyToDataTable();

            DataRow row = (dtFiltro.Rows.Count > 0) ? dtFiltro.NewRow() : dt.NewRow(); 
            row["idEstadoSol"] = 0;
            row["cEstadoSol"] = "TODOS";
            
            if (dtFiltro.Rows.Count > 0)
                dtFiltro.Rows.Add(row);
            else
                dt.Rows.Add(row);

            //this.DataSource =  dt ;
            this.DataSource = (dtFiltro.Rows.Count > 0) ? dtFiltro : dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
