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
    public partial class cboTipoRolHogar : cboBase
    {
        private clsCNTipoRolHogar ObjRolHogar = new clsCNTipoRolHogar();
        public cboTipoRolHogar()
        {
            InitializeComponent();
        }

        public cboTipoRolHogar(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            DataTable dtTipoRolHogar = ObjRolHogar.CNListaTipoRolHogar();
            this.DataSource = dtTipoRolHogar;
            this.DisplayMember = dtTipoRolHogar.Columns["cRolHogar"].ToString();
            this.ValueMember = dtTipoRolHogar.Columns["idRolHogar"].ToString();
        }
    }
}
