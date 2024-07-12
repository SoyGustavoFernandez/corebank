using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DEP.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoCuenta : cboBase
    {
        public cboTipoCuenta()
        {
            InitializeComponent();
        }

        public cboTipoCuenta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoCuenta objTipoCuenta= new clsCNTipoCuenta();
            DataTable dtTipoCuenta=objTipoCuenta.LisTipoCuenta();
            this.DataSource= dtTipoCuenta;
            this.ValueMember=dtTipoCuenta.Columns[0].ToString();
            this.DisplayMember=dtTipoCuenta.Columns[1].ToString();
        }
    }
}
