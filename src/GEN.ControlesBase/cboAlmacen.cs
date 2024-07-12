using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using System.Data;
using LOG.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class cboAlmacen : cboBase
    {
        public cboAlmacen()
        {
            InitializeComponent();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboAlmacen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarAlmacen(int idAgencia)
        {
            DataTable dtAlmacen = new clsCNAlmacen().CNListarAlmacenAgencia(idAgencia);
            this.DataSource = dtAlmacen;
            this.ValueMember = dtAlmacen.Columns[0].ToString();
            this.DisplayMember = dtAlmacen.Columns[1].ToString();
        }

        public void CargarAlmacenYTodos(int idAgencia)
        {
            DataTable dtAlmacen = new clsCNAlmacen().CNListarAlmacenAgencia(idAgencia);
            this.DataSource = dtAlmacen;
            DataRow row = dtAlmacen.NewRow();
            row["idAlmacen"] = 0;
            row["cNombreAlmacen"] = "TODOS";
            dtAlmacen.Rows.Add(row);
            this.ValueMember = dtAlmacen.Columns[0].ToString();
            this.DisplayMember = dtAlmacen.Columns[1].ToString();
        }
    }
}
