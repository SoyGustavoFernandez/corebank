using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipObsSol : cboBase
    {
        public cboTipObsSol()
        {
            InitializeComponent();
        }

        public cboTipObsSol(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            cargarDatos();
        }

        private void cargarDatos()
        {
            this.ValueMember = "idTipObsSol";
            this.DisplayMember = "cTipObsSol";
            this.DataSource = new clsCNTipObsSol().CNLstTipObsSol();
        }
    }
}
