using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboEstadoCtaDeposito : cboBase
    {
        public cboEstadoCtaDeposito()
        {
            InitializeComponent();
        }

        public cboEstadoCtaDeposito(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNEstadoCtaDeposito ListaEstadoDep = new clsCNEstadoCtaDeposito();
            DataTable dt = ListaEstadoDep.ListarEstadoDep();

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
        public void EstadoCtaYTodos()
        {
            clsCNEstadoCtaDeposito ListaEstadoDep = new clsCNEstadoCtaDeposito();
            DataTable dt = ListaEstadoDep.ListarEstadoDep();

            DataRow row = dt.NewRow();
            row["idEstado"] = 0;
            row["cEstado"] = "TODOS";
            dt.Rows.Add(row);

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }


    }
}
