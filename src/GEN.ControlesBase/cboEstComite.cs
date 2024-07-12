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
    public partial class cboEstComite : cboBase
    {
        public cboEstComite()
        {
            InitializeComponent();
        }

        public cboEstComite(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos();
        }

        public void cargarDatos()
        {
            this.ValueMember = "idEstComiteCred";
            this.DisplayMember = "cEstComiteCred";
            this.DataSource = new clsCNComiteCred().CNLstEstComiteCred();
        }
    }
}
