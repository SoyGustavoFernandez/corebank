using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using EntityLayer;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboListaPerfil : cboBase 
    {
        public cboListaPerfil()
        {
            InitializeComponent();
        }

        public cboListaPerfil(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();       
            List<clsPerfil> lisPerfiles = new List<clsPerfil>();
            lisPerfiles = Perfiles.ListarPerfiles();
            this.DataSource = lisPerfiles;
            this.DisplayMember = "cPerfil";
            this.ValueMember = "idPerfil";
        }
        public void cargarPerfilRecuperadores()
        {
            clsCNPerfilUsu Perfiles = new clsCNPerfilUsu();       
            List<clsPerfil> lisPerfiles = new List<clsPerfil>();
            lisPerfiles = Perfiles.ListarPerfilRecuperadores();
            this.DataSource = lisPerfiles;
            this.DisplayMember = "cPerfil";
            this.ValueMember = "idPerfil";
        }

        public void CargarPerfilOrdenadoAsc()
        {
            clsCNPerfilUsu ListadoAgencia = new clsCNPerfilUsu();
            DataTable dt = ListadoAgencia.CNListarPerfilOrdenadoAsc();

            DataRow row = dt.NewRow();
            row["idPerfil"] = 0;
            row["cPerfil"] = "TODOS";
            dt.Rows.Add(row);

            dt = dt.AsEnumerable().OrderBy(x => x.Field<int>("idPerfil")).CopyToDataTable();

            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
