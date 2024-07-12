using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboMeses : cboBase
    {
        public cboMeses()
        {
            InitializeComponent();
        }

        public cboMeses(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNMeses cnMeses = new clsCNMeses();
            DataTable dt = cnMeses.listarMeses();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarTodos()
        {
            clsCNMeses cnMeses = new clsCNMeses();
            DataTable dt = cnMeses.listarMeses();

            var dr = dt.NewRow();
            dr["idMeses"] = 0;
            dr["cMes"] = "TODOS";
            dr["lVigente"] = true;

            dt.Rows.Add(dr);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
