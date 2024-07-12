using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboOperacionCre : cboBase
    {
        public cboOperacionCre()
        {
            InitializeComponent();
        }

        public cboOperacionCre(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNOperacionCre ListaOperacionCre = new clsCNOperacionCre();
            DataTable dt = ListaOperacionCre.ListarOperacionCre();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();

        }
    }
}
