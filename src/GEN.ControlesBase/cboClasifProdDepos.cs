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
    public partial class cboClasifProdDepos : cboBase
    {
        public cboClasifProdDepos()
        {
            InitializeComponent();
        }

        public cboClasifProdDepos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNClasifProdDepos ListaClasifProd = new clsCNClasifProdDepos();
            DataTable dt = ListaClasifProd.ListarClasifProd();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
