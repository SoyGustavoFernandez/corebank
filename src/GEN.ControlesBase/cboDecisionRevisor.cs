using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboDecisionRevisor : cboBase 
    {
        public cboDecisionRevisor()
        {
            InitializeComponent();
        }

        public cboDecisionRevisor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            cargarDatos();
        }

        public void cargarDatos()
        {
            this.ValueMember = "idEstadoEvalCred";
            this.DisplayMember = "cEstado";

            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("idEstadoEvalCred", typeof(int));
            dt.Columns.Add(dc);

            dc = new DataColumn("cEstado", typeof(string));
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr[0] = 6;
            dr[1] = "DERIVAR";
            dt.Rows.Add(dr);


            DataRow dr2 = dt.NewRow();
            dr2[0] = 8;
            dr2[1] = "DEVOLVER";
            dt.Rows.Add(dr2);
            //this.DataSource = new clsCNComiteCred().CNLstResultComiteCred();
            this.DataSource = dt;
        }
    }
}
