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
    public partial class cboTipoUsoDelPredio : cboBase
    {
        public cboTipoUsoDelPredio()
        {
            InitializeComponent();
        }

        public cboTipoUsoDelPredio(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoUsoDelPredio ListaUsoDelPredio = new clsCNTipoUsoDelPredio();
            DataTable tbUsoDelPredio = ListaUsoDelPredio.ListaUsoDelPredio();
            this.DataSource = tbUsoDelPredio;
            this.ValueMember = tbUsoDelPredio.Columns[0].ToString();
            this.DisplayMember = tbUsoDelPredio.Columns[2].ToString();
        }

    }//end class

}
