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
    public partial class cboTipoSiembraEval : cboBase
    {
        public cboTipoSiembraEval()
        {
            InitializeComponent();
        }

        public cboTipoSiembraEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.cargarDatos();
        }

        public void cargarDatos()
        {
            DataTable dt = new clsCNEvalAgrico().obtenerTiposSiembra();
            this.ValueMember = "idTipoSiembra";
            this.DisplayMember = "cTipoSiembra";
            this.DataSource = dt;
        }
    }
}
