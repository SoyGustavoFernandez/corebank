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
    public partial class cboEtapaCultivoEval : cboBase
    {
        public cboEtapaCultivoEval()
        {
            InitializeComponent();
        }

        public cboEtapaCultivoEval(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.cargarDatos();
        }

        public void cargarDatos()
        {
            DataTable dt = new clsCNEvalAgrico().obtenerEtapasCultivo();
            this.ValueMember = "idEtapaCultivo";
            this.DisplayMember = "cEtapaCultivo";
            this.DataSource = dt;
        }
    }
}
