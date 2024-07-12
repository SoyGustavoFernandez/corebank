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
    public partial class cboMotivoCancelacion : cboBase
    {
        public cboMotivoCancelacion()
        {
            InitializeComponent();
        }

        public cboMotivoCancelacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtResult = new clsCNMotCancelacion().CNLstMotCancelacion(1);
            this.DataSource = dtResult;
            this.ValueMember = "idMotivoCancelacion";
            this.DisplayMember = "cMotivoCancelacion";

        }

        public void cboMotivoCancelacionPorModulo(int idModulo)
        {
            DataTable dtResult = new clsCNMotCancelacion().CNLstMotCancelacion(idModulo);
            this.DataSource = dtResult;
            this.ValueMember = "idMotivoCancelacion";
            this.DisplayMember = "cMotivoCancelacion";

        }
    }
}
