using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboResultComite : cboBase
    {
        public cboResultComite()
        {
            InitializeComponent();
        }

        public cboResultComite(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            cargarDatos();
        }

        public void cargarDatos()
        {
            this.ValueMember = "idResultado";
            this.DisplayMember = "cResultado";
            this.DataSource = new clsCNComiteCred().CNLstResultComiteCred();
        }
    }
}
