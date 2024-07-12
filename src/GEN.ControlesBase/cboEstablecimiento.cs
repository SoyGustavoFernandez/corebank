using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstablecimiento : cboBase
    {
        public DataTable dtEstablecimiento;

        public cboEstablecimiento()
        {
            InitializeComponent();
        }

        public cboEstablecimiento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarEstablecimiento(int idAgencia)
        {
            dtEstablecimiento = new clsCNEstablecimeinto().ListadoEstablec(idAgencia);
            this.DataSource = dtEstablecimiento;
            this.ValueMember = dtEstablecimiento.Columns[0].ToString();
            this.DisplayMember = dtEstablecimiento.Columns[1].ToString();
        }

        public void CargarEstablecimientos(int idAgencia)
        {
            dtEstablecimiento = new clsCNEstablecimeinto().ListadoEstablec(idAgencia);
            DataRow row = dtEstablecimiento.NewRow();
            row["idEstablecimiento"] = 0;
            row["cNombreEstab"] = "** TODOS **";
            dtEstablecimiento.Rows.Add(row);

            dtEstablecimiento.DefaultView.Sort = "idEstablecimiento asc";
            
            this.DataSource = dtEstablecimiento;
            this.ValueMember = dtEstablecimiento.Columns[0].ToString();
            this.DisplayMember = dtEstablecimiento.Columns[1].ToString();

            this.SelectedValue = 0;
        }
    }
}
