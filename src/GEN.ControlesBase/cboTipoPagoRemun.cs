using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GRH.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboTipoPagoRemun : cboBase
    {
        public cboTipoPagoRemun()
        {
            InitializeComponent();
        }

        public cboTipoPagoRemun(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ListTipoPagoRemun(Int32 idtipoPago)
        {
            clsCNConceptoRemunerativo ListadoTipoPagoRemuneracion = new clsCNConceptoRemunerativo();
            DataTable dt = ListadoTipoPagoRemuneracion.CNListaTipoPagoRemun(idtipoPago);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
