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
    public partial class cboTipoCalculado : cboBase
    {
        public cboTipoCalculado()
        {
            InitializeComponent();
        }

        public cboTipoCalculado(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoCal ListadoTipoCalculado = new clsCNTipoCal();
            DataTable dt = ListadoTipoCalculado.listarTipCal();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            
        }
    }
}
