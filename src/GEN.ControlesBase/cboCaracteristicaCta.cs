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
    public partial class cboCaracteristicaCta : cboBase
    {
        public cboCaracteristicaCta()
        {
            InitializeComponent();
        }

        public cboCaracteristicaCta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNCaracteristCta ListadoCarac = new clsCNCaracteristCta();
            DataTable dt = ListadoCarac.listarCaractCta();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            
        }
        public void CaractCtaYTodos()
        {
            clsCNCaracteristCta ListadoCarac = new clsCNCaracteristCta();
            DataTable dt = ListadoCarac.listarCaractCta();

            DataRow row = dt.NewRow();
            row["idCaracteristica"] = 0;
            row["cDescripcion"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
