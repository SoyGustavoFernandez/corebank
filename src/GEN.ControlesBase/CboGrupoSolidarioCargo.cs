using CRE.CapaNegocio;
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
    public partial class CboGrupoSolidarioCargo : cboBase
    {
        public CboGrupoSolidarioCargo()
        {
            InitializeComponent();
        }

        public CboGrupoSolidarioCargo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            clsCNGrupoSolidarioCargo objCargo = new clsCNGrupoSolidarioCargo();

            this.ValueMember = "idGrupoSolidarioCargo";
            this.DisplayMember = "cDescripcion";
            this.DataSource = objCargo.ListarCargos(); ;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
