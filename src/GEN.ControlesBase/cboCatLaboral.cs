using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboCatLaboral : cboBase
    {
        public cboCatLaboral()
        {
            InitializeComponent();
        }

        public cboCatLaboral(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idTipoCatLaboral", typeof(int));
            dt.Columns.Add("cTipoCatLaboral", typeof(string));

            DataRow dr = dt.NewRow();
            dr["idTipoCatLaboral"] = 1;
            dr["cTipoCatLaboral"] = "4ta. categoría";
            DataRow dr2 = dt.NewRow();
            dr2["idTipoCatLaboral"] = 2;
            dr2["cTipoCatLaboral"] = "5ta. categoría";

            dt.Rows.Add(dr);
            dt.Rows.Add(dr2);

            this.DisplayMember = dt.Columns[1].ToString();
            this.ValueMember = dt.Columns[0].ToString();
            this.DataSource = dt;
        }
    }
}
