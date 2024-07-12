using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.ControlesBase
{
    public partial class cboTipoMeta : cboBase
    {
        DataTable dtTipoMeta;
        public cboTipoMeta()
        {
            InitializeComponent();
        }
        public cboTipoMeta(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos(1); //incentivo meta
        }

        public void cargarDatos(int idTipoIncentivo)
        {
            dtTipoMeta = new clsCNTipoMeta().CNListaTipoMeta(idTipoIncentivo);

            this.DataSource = dtTipoMeta;
            this.ValueMember = dtTipoMeta.Columns["idTipoMeta"].ToString();
            this.DisplayMember = dtTipoMeta.Columns["cTipoMeta"].ToString();
        }

    }
}
