using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class CboGrupoSolidarioTipo : cboBase
    {
        public CboGrupoSolidarioTipo()
        {
            InitializeComponent();
        }

        public CboGrupoSolidarioTipo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            clsCNGrupoSolidarioTipo objCiclo = new clsCNGrupoSolidarioTipo();

            this.ValueMember = "idGrupoSolidarioTipo";
            this.DisplayMember = "cDescripcion";
            this.DataSource = objCiclo.ListarTipos(); ;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
