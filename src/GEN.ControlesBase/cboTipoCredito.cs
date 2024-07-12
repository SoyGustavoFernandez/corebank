using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Text;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoCredito : cboBase
    {
        public cboTipoCredito()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoCredito(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            clsCNTipoCredito ListaTipoCredito = new clsCNTipoCredito();
            DataTable dt = ListaTipoCredito.listarTipoCredito();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
