using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using ADM.CapaNegocio;
using CAJ.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboAgencias : cboBase
    {
        public cboAgencias()
        {
            InitializeComponent();
        }

        public cboAgencias(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dt = ListadoAgencia.ListarAgencias();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idAgencia"].ToString();
            this.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void AgenciasYTodos()
        {
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dt = ListadoAgencia.ListarAgencias();

            DataRow row = dt.NewRow();
            row["idAgencia"] = 0;
            row["cNombreAge"] = "TODOS";
            dt.Rows.Add(row);

            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
            

        }
        public void FiltrarPorZona(int idZona, bool lTodos = false, bool lNinguno = false)
        {
            clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
            DataTable dt = ListadoAgencia.CNListarOficinaByZona(idZona);
            if (lTodos)
            {
                DataRow row = dt.NewRow();
                row["idAgencia"] = 0;
                row["cNombreAge"] = "-TODOS-";
                dt.Rows.InsertAt(row, 0);
            }
            if (lNinguno)
            {
                DataRow row = dt.NewRow();
                row["idAgencia"] = -1;
                row["cNombreAge"] = "-NINGUNO-";
                dt.Rows.InsertAt(row, 0);
            }
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idAgencia"].ToString();
            this.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void FiltrarPorZonaTodos(int idZona)
        {
            clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
            DataTable dt = ListadoAgencia.CNListarOficinaByZona(idZona);
            DataRow row = dt.NewRow();
            row["idAgencia"] = 0;
            row["cNombreAge"] = "**TODOS**";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.ValueMember = dt.Columns["idAgencia"].ToString();
            this.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        // devuelve agencias que pueden participar en Giros
        public void SoloAptosAgiros()
        {
            clsCNControlOpe cncontrolope = new clsCNControlOpe();
            DataTable dt = cncontrolope.ListarAgenciasAptasAgiro();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idAgencia"].ToString();
            this.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void AgenciasYNinguno()
        {
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dt = ListadoAgencia.ListarAgencias();

            DataRow row = dt.NewRow();
            row["idAgencia"] = 0;
            row["cNombreAge"] = "NINGUNO";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }

        public string obtenerNombreAgenciaPorId(int idAgencia)
        {
            DataTable dt = (DataTable)this.DataSource;
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["idAgencia"]) == idAgencia)
                {
                    return item["cNombreAge"].ToString();
                }
            }
            return "";
        }

        public void clearDisable()
        {
            this.DataSource = null;
            this.Enabled = false;
        }
        public void FiltrarPorZonaUbigeo(int idZona)
        {
            clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
            DataTable dt = ListadoAgencia.CNListarOficinaByZonaUbigeo(idZona);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idAgencia"].ColumnName;
            this.DisplayMember = dt.Columns["cNombreAge"].ColumnName;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void FiltrarPorZonaAgenciaVigenteTodos(int idZona)
        {
            clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
            DataTable dt = ListadoAgencia.CNFiltrarPorZonaAgenciaTodos(idZona);
            this.DataSource = dt;

            if (idZona == 0)
            {
                DataRow row = dt.NewRow();
                row["idAgencia"] = 0;
                row["cNombreAge"] = "TODOS";
                dt.Rows.Add(row);
            }

            dt = dt.AsEnumerable().OrderBy(x => x.Field<int>("idAgencia")).CopyToDataTable();

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.ValueMember = dt.Columns["idAgencia"].ToString();
            this.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
