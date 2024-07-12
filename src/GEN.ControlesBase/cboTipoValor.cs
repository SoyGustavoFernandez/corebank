using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoValor : cboBase
    {
        public DataTable dtTipoValor;
        public cboTipoValor()
        {
            InitializeComponent();
        }

        public cboTipoValor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtTipoValor = new clsCNTipoValor().ListaTipoValor();
            this.DataSource = dtTipoValor;
            this.ValueMember = dtTipoValor.Columns["idTipoValor"].ToString();
            this.DisplayMember = dtTipoValor.Columns["cTipoValor"].ToString();
        }
    }
}
