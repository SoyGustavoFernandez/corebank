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
    public partial class cboTipoGrupoSolidario : cboBase
    {
        public cboTipoGrupoSolidario()
        {
            InitializeComponent();
        }

        public cboTipoGrupoSolidario(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarTipoGrupoSolidario();
        }

        private void cargarTipoGrupoSolidario()
        {
            clsCNGrupoSolidarioTipo objCiclo = new clsCNGrupoSolidarioTipo();

            this.ValueMember = "idTipoGrupoSolidario";
            this.DisplayMember = "cTipoGrupoSolidario";
            this.DataSource = objCiclo.CNListarTipoGrupoSolidario(); 
        }
    }
}
