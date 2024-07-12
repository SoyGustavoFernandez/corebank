using ADM.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipDocGasto : cboBase
    {
        public cboTipDocGasto()
        {
            InitializeComponent();
        }

        public cboTipDocGasto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            this.DisplayMember = "cTipDocGastos";
            this.ValueMember = "idTipDocGastos";
            this.DataSource = new clsCNConfigGastComiSeg().ListaTipDocGastos();
        }
    }
}
