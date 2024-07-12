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
    public partial class cboSexo : cboBase
    {
        public cboSexo()
        {
            InitializeComponent();
        }

        public cboSexo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNSexo ListaSexo = new clsCNSexo();

            DataTable tbSexo = ListaSexo.ListarSexo();
            this.DataSource = tbSexo;
            this.ValueMember = tbSexo.Columns[0].ToString();
            this.DisplayMember = tbSexo.Columns[1].ToString();
        }
    }
}
