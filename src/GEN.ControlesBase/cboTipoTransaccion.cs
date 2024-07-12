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
    public partial class cboTipoTransaccion : cboBase
    {
        public cboTipoTransaccion()
        {
            InitializeComponent();
        }

        public cboTipoTransaccion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNTipoTransaccion ListaTipoTrasac = new clsCNTipoTransaccion();

            DataTable tbTipoTrasac = ListaTipoTrasac.ListarTipoTransac();
            this.DataSource = tbTipoTrasac;
            this.ValueMember = tbTipoTrasac.Columns[0].ToString();
            this.DisplayMember = tbTipoTrasac.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
