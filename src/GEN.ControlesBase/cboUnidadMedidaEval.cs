using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboUnidadMedidaEval : cboBase
    {
        public cboUnidadMedidaEval()
        {
            InitializeComponent();
        }

        public cboUnidadMedidaEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.cargarDatos();
        }

        public void cargarDatos()
        {
            DataTable dt = new clsCNEvalAgrico().obtenerUnidadesMedida();
            this.ValueMember = "idUnidadMedida";
            this.DisplayMember = "cUnidadMedida";
            this.DataSource = dt;
        }
    }
}
