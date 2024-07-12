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
    public partial class cboUnidadProductivaEval : cboBase
    {
        public cboUnidadProductivaEval()
        {
            InitializeComponent();
        }

        public cboUnidadProductivaEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.cargarDatos();
        }

        public void cargarDatos()
        {
            DataTable dt = new clsCNEvalAgrico().obtenerUnidadesProductivas();
            this.ValueMember = "idUnidadProductiva";
            this.DisplayMember = "cUnidadProductiva";
            this.DataSource = dt;
        }
    }
}
