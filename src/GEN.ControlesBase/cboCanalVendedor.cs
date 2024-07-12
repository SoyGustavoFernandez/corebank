using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboCanalVendedor : cboBase
    {
        public DataTable dtCanalVendedor;

        public cboCanalVendedor()
        {
            InitializeComponent();
        }

        public cboCanalVendedor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            dtCanalVendedor = new clsCNMantenimientoCanales().ListaMantenimientoCanales(1);

            DataRow row = dtCanalVendedor.NewRow();
            //row["idCanal"] = 0;
            //row["cDescripcion"] = "TODOS";
            //dtCanalVendedor.Rows.Add(row);

            ValueMember = "idCanal";
            DisplayMember = "cDescripcion";
            DataSource = dtCanalVendedor;
        }

        public void listapromotores() {
            dtCanalVendedor = new clsCNMantenimientoCanales().ListaMantenimientoCanales(1);

            DataRow row = dtCanalVendedor.NewRow();
            row["idCanal"] = 0;
            row["cDescripcion"] = "TODOS";
            dtCanalVendedor.Rows.Add(row);

            ValueMember = "idCanal";
            DisplayMember = "cDescripcion";
            DataSource = dtCanalVendedor;
        }

    }
}
