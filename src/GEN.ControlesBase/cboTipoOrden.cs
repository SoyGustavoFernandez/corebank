using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoOrden : cboBase
    {    
        public cboTipoOrden()
        {
            InitializeComponent();
        }

        public cboTipoOrden(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtResult = new clsCNOrdenCompra().ListarTipoOrden();
            this.DataSource = dtResult;
            this.ValueMember = "idTipoOrden";
            this.DisplayMember = "cTipoOrden";
        }
    }
}
