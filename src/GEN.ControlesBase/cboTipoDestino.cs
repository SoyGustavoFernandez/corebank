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
    public partial class cboTipoDestino : cboBase
    {
        public cboTipoDestino()
        {
            InitializeComponent();
        }

        public cboTipoDestino(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNMovimientoBancario listaMovBco = new clsCNMovimientoBancario();
            DataTable dt = listaMovBco.ListarTipoDestino();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
