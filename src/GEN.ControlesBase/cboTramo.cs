using EntityLayer;
using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboTramo : cboBase
    {
        clsCNTramo cnTramo = new clsCNTramo();
        public cboTramo()
        {
            InitializeComponent();
        }

        public cboTramo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            int idPerfil = Convert.ToInt32(clsVarApl.dicVarGen["nPerfilGestorRecuperaciones"]);
            DataTable dt = cnTramo.listar(idPerfil);
            DataRow row = dt.NewRow();
            row["idTramo"] = 0;
            row["cNombre"] = "TODOS";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTramo"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;            
        }

        public void cargarTramosPerfil(int idPerfil)
        {
            DataTable dt = cnTramo.listar(idPerfil);
            DataRow row = dt.NewRow();
            row["idTramo"] = 0;
            row["cNombre"] = "TODOS";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTramo"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;          
        }

        public void ListarTodos()
        {
            DataTable dt = cnTramo.listarTodo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;    
        }
    }
}
