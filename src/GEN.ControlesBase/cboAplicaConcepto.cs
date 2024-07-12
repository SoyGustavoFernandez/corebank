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
    public partial class cboAplicaConcepto : cboBase
    {
        public cboAplicaConcepto()
        {
            InitializeComponent();
        }

        public cboAplicaConcepto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DataSource = new clsCNConfigGastComiSeg().CargarAplicaConcepto();
            this.ValueMember = "idAplicaConc";
            this.DisplayMember = "cAplicaConc";

        }
    }
}
