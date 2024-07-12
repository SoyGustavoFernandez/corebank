using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMonedas : cboBase
    {
        public cboMonedas()
        {
            InitializeComponent();
        }

        public cboMonedas(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNMoneda ListadoMoneda = new clsCNMoneda();
            DataTable dt = ListadoMoneda.CNListaMonedas();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
