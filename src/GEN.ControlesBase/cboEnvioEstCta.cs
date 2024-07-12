using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboEnvioEstCta : cboBase
    {
        public cboEnvioEstCta()
        {
            InitializeComponent();
        }

        public cboEnvioEstCta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ListaEnvioEstadoCta();
        }

        private void ListaEnvioEstadoCta()
        {
            clsCNTipoCuenta objTipoCuenta = new clsCNTipoCuenta();
            DataTable dt = objTipoCuenta.ListaEnvioEstCta();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoEnvioEstCta"].ToString();
            this.DisplayMember = dt.Columns["cDescripcion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
