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
    public partial class cboTipoTasa : cboBase
    {
        public cboTipoTasa()
        {
            InitializeComponent();
        }

        public cboTipoTasa(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoTasa objTipTasa= new clsCNTipoTasa();
            DataTable dtTipoTasa = objTipTasa.LisTipTasa();
            this.DataSource = dtTipoTasa;
            this.ValueMember = dtTipoTasa.Columns[0].ToString();
            this.DisplayMember = dtTipoTasa.Columns[1].ToString();
        }
    }
}
