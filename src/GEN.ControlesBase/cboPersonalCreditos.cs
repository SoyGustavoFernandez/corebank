using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using EntityLayer;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboPersonalCreditos : cboBase
    {
        Int32 idAgencia = clsVarGlobal.nIdAgencia;
        DataTable originalDt = null;
        public cboPersonalCreditos()
        {
            InitializeComponent();
        }

        public cboPersonalCreditos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListarPersonal(idAgencia);
        }

        public void ListarPersonal(int idAgencias, Boolean lTodos = false, int idEstadoPersonal = 0)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarPersonalCre(idAgencias, idEstadoPersonal);
            originalDt = dt;
            if (lTodos)
            {
                DataRow dr = dt.NewRow();
                dr["idUsuario"] = 0;
                dr["cNombre"] = "**TODOS**";
                dt.Rows.InsertAt(dr, 0);
            }
            
            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ListarPersonalCompleto(int idAgencias, Boolean lTodos = false)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarPersonalCompletoCre(idAgencias);
            originalDt = dt;
            if (lTodos)
            {
                DataRow dr = dt.NewRow();
                dr["idUsuario"] = 0;
                dr["cNombre"] = "**TODOS**";
                dt.Rows.InsertAt(dr, 0);
            }

            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void clearDisable()
        {
            this.DataSource = null;
            this.Enabled = false;
        }

        public string ObtenerListaPersonal()
        {
            List<string> ids = new List<string>();
            foreach (DataRow row in originalDt.Rows)
            {
                ids.Add(row[this.ValueMember.ToString()].ToString());
            }
            return String.Join(",", ids.ToArray());
        }

        public void ListarUsuarioConCartera(DateTime dFechaIni, DateTime dFechaFin, int idZona, int idAgencia, Boolean lTodos = false)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarUsuariosConCartera(dFechaIni, dFechaFin, idZona, idAgencia);
            originalDt = dt;
            if (lTodos)
            {
                DataRow dr = dt.NewRow();
                dr["idUsuario"] = 0;
                dr["cNombre"] = "**TODOS**";
                dt.Rows.InsertAt(dr, 0);
            }

            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ListarPersonalAsesorPrincipal(int idAgencias, Boolean lTodos = false)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarPersonalAsesorPrincipal(idAgencias);
            originalDt = dt;
            if (lTodos)
            {
                DataRow dr = dt.NewRow();
                dr["idUsuario"] = 0;
                dr["cNombre"] = "**TODOS**";
                dt.Rows.InsertAt(dr, 0);
            }

            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
