using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNT.CapaNegocio;
using EntityLayer.CPE;

namespace GEN.ControlesBase
{
    public partial class cboEstadoEnvioCPE : cboBase
    {
        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        public cboEstadoEnvioCPE()
        {
            InitializeComponent();
        }

        public cboEstadoEnvioCPE(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CargarDatos()
        {
            var data = _cnComprobantePagoElectronico.GetEstadoEnvioCPE();
            DataSource = data;
            ValueMember = "IdEstadoEnvioCPE";
            DisplayMember = "Descripcion";
        }     
    }
}
