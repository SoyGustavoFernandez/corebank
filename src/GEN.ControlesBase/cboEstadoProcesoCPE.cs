using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNT.CapaNegocio;
using EntityLayer.CPE;
using GEN.ControlesBase;
using System.Data;

namespace GEN.ControlesBase
{
    public partial class cboEstadoProcesoCPE : cboBase
    {

        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        public cboEstadoProcesoCPE()
        {
            InitializeComponent();
        }

        public cboEstadoProcesoCPE(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarDatos()
        {          
            DataTable dtEstados = _cnComprobantePagoElectronico.GetEstadoProcesoCPE();

            DataRow row = dtEstados.NewRow();
            row["idEstadoProcesoCPE"] = 0;
            row["Descripcion"] = "TODOS";
            dtEstados.Rows.Add(row);

            ValueMember = "IdEstadoProcesoCPE";
            DisplayMember = "Descripcion";
            DataSource = dtEstados;
        }
    }
}
