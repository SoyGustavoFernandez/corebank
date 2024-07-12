using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CAJ.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoEntrega : cboBase
    {
        private clsCNCuentasPorPagar cnCuentasPorPagar = new clsCNCuentasPorPagar();

        public cboTipoEntrega()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoEntrega(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cargarTipoEntrega()
        {
            DataTable dtTipoEntrega = cnCuentasPorPagar.listarTipoEntrega();
            this.DataSource = dtTipoEntrega;
            this.ValueMember = dtTipoEntrega.Columns["idTipoEntrega"].ToString();
            this.DisplayMember = dtTipoEntrega.Columns["cTipoEntrega"].ToString();
        }
    }
}
