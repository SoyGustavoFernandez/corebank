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
    public partial class CboGrupoSolidarioCiclo : cboBase
    {
        public CboGrupoSolidarioCiclo()
        {
            InitializeComponent();
        }

        public CboGrupoSolidarioCiclo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            CargarDatos();
        }

        public void CargarDatos()
        {
            clsCNGrupoSolidarioCiclo objCiclo = new clsCNGrupoSolidarioCiclo();

            this.ValueMember = "idGrupoSolidarioCiclo";
            this.DisplayMember = "cDescripcion";
            this.DataSource = objCiclo.ListarCiclos(); ;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
