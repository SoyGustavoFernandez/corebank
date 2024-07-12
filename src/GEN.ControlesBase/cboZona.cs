using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.CapaNegocio;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboZona : cboBase
    {
        clsCNMantenimiento cnMante =  new clsCNMantenimiento();
        public cboZona()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboZona(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarZona();
        }

        public void cargarZona(bool lTodos = false, bool lNinguno = false)
        {
            DataTable dt = cnMante.CNListarZona();
            if (lTodos)
            {
                DataRow row = dt.NewRow();
                row["idZona"] = 0;
                row["cDesZona"] = "-TODOS-";
                row["lVigente"] = 1;
                dt.Rows.InsertAt(row, 0);
            }
            if (lNinguno)
            {
                DataRow row = dt.NewRow();
                row["idZona"] = -1;
                row["cDesZona"] = "-NINGUNO-";
                row["lVigente"] = 1;
                dt.Rows.InsertAt(row, 0);
            }
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }

        public void AgregarNingunoTodos()
        {
            DataTable dt = this.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row["idZona"] = 0;
            row["cDesZona"] = "TODOS";
            row["lVigente"] = 1;
            dt.Rows.Add(row);

            DataRow row2 = dt.NewRow();
            row2["idZona"] = -1;
            row2["cDesZona"] = "";
            row2["lVigente"] = 0;
            dt.Rows.Add(row2);

            this.ValueMember = "idZona";
            this.DisplayMember = "cDesZona";
            this.DataSource = dt;

            this.SelectedValue = -1;
        }

        public void AgregarTodos()
        {
            DataTable dt = this.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row["idZona"] = 0;
            row["cDesZona"] = "TODOS";
            row["lVigente"] = 1;
            dt.Rows.Add(row);

            dt = dt.AsEnumerable().OrderBy(x => x.Field<int>("idZona")).CopyToDataTable();

            this.ValueMember = "idZona";
            this.DisplayMember = "cDesZona";
            this.DataSource = dt;
        }

        public void cargarZonasAsignadas(int idUsuario)
        {
            DataTable dt = cnMante.CNListarZonaAsiganado(idUsuario);
            DataRow row = dt.NewRow();
            
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;

            if (dt.Rows.Count > 1)
            {
                this.SelectedIndex = -1;
            }
        }

    }
}
