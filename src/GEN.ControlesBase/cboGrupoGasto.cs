using ADM.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboGrupoGasto : cboBase
    {
        public cboGrupoGasto()
        {
            InitializeComponent();
        }

        public cboGrupoGasto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DataSource = new clsCNConfigGastComiSeg().CargarGrupoGasto();
            this.DisplayMember = "cGrupoConcepto";
            this.ValueMember = "idGrupoConcepto";
            
        }
    }
}
