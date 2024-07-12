using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoPagoMasivo : cboBase
    {
        clsCNTipoPago TipoPago = new clsCNTipoPago();
        public DataTable dtTipoPago;

        public cboTipoPagoMasivo()
        {
            InitializeComponent();
        }

        public cboTipoPagoMasivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ListarTipoPagoMasivos();
        }

        public void ListarTipoPagoMasivos()
        {
            dtTipoPago = TipoPago.CNListarTipoPagoMasivos();

            this.DataSource = dtTipoPago;
            this.ValueMember = dtTipoPago.Columns["idTipoPagoMasivo"].ToString();
            this.DisplayMember = dtTipoPago.Columns["cTipoPagoMasivo"].ToString();
        }
    }
}
