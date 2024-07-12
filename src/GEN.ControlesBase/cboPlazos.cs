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
    public partial class cboPlazos : cboBase
    {
        public cboPlazos()
        {
            InitializeComponent();
        }

        public cboPlazos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }
        public void CargarPLazos(int idModulo)
        {
            clsCNPlazos ListadoPlazo = new clsCNPlazos();
            DataTable dt = ListadoPlazo.ListarPlazos(idModulo);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        public void CargarPLazosTodos(int idModulo)
        {
            clsCNPlazos ListadoPlazosTodos = new clsCNPlazos();
            DataTable dt = ListadoPlazosTodos.ListarPlazosTodos(idModulo);

            DataRow row = dt.NewRow();
            row["idPlazo"] = 0;
            row["cPlazo"] = "TODOS";
            dt.Rows.Add(row);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();  
        }
    }
}
