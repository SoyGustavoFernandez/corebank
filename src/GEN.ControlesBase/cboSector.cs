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
    public partial class cboSector : cboBase
    {
        private clsCNSector objSector = new clsCNSector();

        public cboSector()
        {
            InitializeComponent();
        }

        public cboSector(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtSector = objSector.CNListaSector();
            this.DataSource = dtSector;
            this.DisplayMember = dtSector.Columns["cSector"].ToString();
            this.ValueMember = dtSector.Columns["idSector"].ToString();
        }
    }
}
