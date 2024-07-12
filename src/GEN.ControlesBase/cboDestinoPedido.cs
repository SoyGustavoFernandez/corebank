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
    public partial class cboDestinoPedido : cboBase
    {
        public cboDestinoPedido()
        {
            InitializeComponent();
        }

        public cboDestinoPedido(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dt = new clsCNDestinoPedido().ListaDestinoPedido(0);
            this.DataSource = dt;
            this.ValueMember = "idDestinoPedido";
            this.DisplayMember = "cDescripcionPedido";
        }
    }
}
