using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboEstadoCli : cboBase
    {
        private clsCNEstadoCli Estado = new clsCNEstadoCli();
        public cboEstadoCli()
        {
            InitializeComponent();
        }

        public cboEstadoCli(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void ListaEstadoCli(int idTipoPersona)
        {
            DataTable dtEstadoCli = Estado.CNListaEstadoCli(idTipoPersona);
            this.DataSource = dtEstadoCli;
            this.ValueMember = dtEstadoCli.Columns["idEstadoCli"].ToString();
            this.DisplayMember = dtEstadoCli.Columns["cDescripcion"].ToString();
        }
    }
}
