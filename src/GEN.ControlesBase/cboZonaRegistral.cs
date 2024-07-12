using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboZonaRegistral : cboBase
    {
        public cboZonaRegistral()
        {
            InitializeComponent();
        }

        public cboZonaRegistral(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

        }
        public void CargarZonaRegistral(Int32 nidZonaRegistral)
        {
            clsCNZonaRegistral ListZonaRegistral = new clsCNZonaRegistral();
            DataTable dt = ListZonaRegistral.CNListarZonaRegistral(nidZonaRegistral);
            DataSource = dt;
            ValueMember = dt.Columns["idZonaReg"].ToString();
            DisplayMember = dt.Columns["cDesCorta"].ToString();
        }
    }
}
