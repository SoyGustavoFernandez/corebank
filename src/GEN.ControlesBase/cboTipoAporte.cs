using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboTipoAporte : cboBase
    {
        public cboTipoAporte()
        {
            InitializeComponent();
        }

        public cboTipoAporte(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNTipoAporte TipoAporte= new clsCNTipoAporte();

            DataTable tbTipoAporte = TipoAporte.CNListarTipoAporte();
            this.DataSource = tbTipoAporte;
            this.ValueMember = tbTipoAporte.Columns["idTipoAporte"].ToString();
            this.DisplayMember = tbTipoAporte.Columns["cTipoAPorte"].ToString();
        }
    }
}
