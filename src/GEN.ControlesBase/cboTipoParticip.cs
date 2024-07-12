using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoParticip : cboBase
    {
        public cboTipoParticip()
        {
            InitializeComponent();
            ListarTodos();
        }

        public cboTipoParticip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListarTodos();
        }

        public void ListarTodos()
        {
            DataTable dtData = new clsCNTipoParticipacion().CNLstTipoParticip();
            this.ValueMember = "idTipoParticip";
            this.DisplayMember = "cTipoParticip";
            this.DataSource = dtData;
        }
    }
}
