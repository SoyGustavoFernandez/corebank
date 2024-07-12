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
    public partial class cboPeriodoRiegos : cboBase
    {
        public cboPeriodoRiegos()
        {
            InitializeComponent();
        }

        public cboPeriodoRiegos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarPeriodo();
        }

        public void cargarPeriodo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nPeriodo", typeof(int));
            dt.Columns.Add("cPeriodo", typeof(string));
            
            DataRow dr = dt.NewRow();
            dr["nPeriodo"] = 1;
            dr["cPeriodo"] = "MENSUAL";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["nPeriodo"] = 6;
            dr["cPeriodo"] = "SEMESTRAL";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["nPeriodo"] = 12;
            dr["cPeriodo"] = "ANUAL";
            dt.Rows.Add(dr);

            this.ValueMember = "nPeriodo";
            this.DisplayMember = "cPeriodo";
            this.DataSource = dt;
        }
    }
}
