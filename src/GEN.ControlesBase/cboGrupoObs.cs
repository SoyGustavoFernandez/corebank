using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboGrupoObs : cboBase
    {
        public cboGrupoObs()
        {
            InitializeComponent();
            CargarTodos();
        }

        public cboGrupoObs(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            CargarTodos();
        }

        public void CargarTodos()
        {
            DataTable dtData = new clsCNObservaciones().CNGetGrupoObs();
            ValueMember = "idGrupoObs";
            DisplayMember = "cGrupoObs";
            DataSource = dtData;
        }
    }
}
