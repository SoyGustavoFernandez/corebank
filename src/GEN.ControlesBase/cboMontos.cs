using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMontos : cboBase
    {
        public cboMontos()
        {
            InitializeComponent();
        }

        public cboMontos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            
        }
        public void CargarMontos(int idModulo) {
            clsCNMontos ListadoMonto = new clsCNMontos();
            DataTable dt = ListadoMonto.ListarMontos(idModulo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void CargarMontosTodos(int idModulo)
        {
            clsCNMontos ListadoMonto = new clsCNMontos();
            DataTable dt = ListadoMonto.ListarMontosTodos(idModulo);

            DataRow row = dt.NewRow();
            row["idMonto"] = 0;
            row["cMonto"] = "TODOS";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
