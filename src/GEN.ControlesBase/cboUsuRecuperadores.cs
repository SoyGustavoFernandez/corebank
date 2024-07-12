using RCP.CapaNegocio;
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
    public partial class cboUsuRecuperadores : cboBase
    {
        clsCNRecuperador cnRecuperador = new clsCNRecuperador();
        public cboUsuRecuperadores()
        {
            InitializeComponent();
        }

        public cboUsuRecuperadores(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dt = cnRecuperador.ListarUsuariosRecuperaciones();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        public void cargarTodosGestores()
        {
            DataTable dt = cnRecuperador.ListarUsuariosRecuperacionesYLegal();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        public void cargarTodosGestoresYTodos()
        {
            DataTable dt = cnRecuperador.ListarUsuariosRecuperacionesYLegal();
            this.DataSource = dt;
            DataRow dr = dt.NewRow();
            dr["idUsuario"] = 0;
            dr["cNombre"] = "TODOS";
            dr["idPerfil"] = 0;
            dt.Rows.Add(dr);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }


        public void cargarTodosGestoresUnicos()
        {
            DataTable dt = cnRecuperador.ListarUsuariosRecuperacionesYLegalUnicos();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        public void CargarUsuariosReasignacion()
        {
            DataTable dt = cnRecuperador.ListarUsuariosRecuperaciones();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "CARTERA NO ASIGNADA";
            dt.Rows.Add(dr);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        public void cargarUsuarioSupervisados(int idUsuarioSupervisor)
        {
            DataTable dt = cnRecuperador.ListarUsuariosSupervisados(idUsuarioSupervisor);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = -1;
        }

        public void cargarGestoresLegalesYTodos()
        {
            DataTable dt = cnRecuperador.ListarGestoresLegalesTodos();
            this.DataSource = dt;
            DataRow dr = dt.NewRow();
            dr["idUsuario"] = 0;
            dr["cNombre"] = "TODOS";
            dt.Rows.Add(dr);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = dt.Rows.Count -1;
        }
    }
}
