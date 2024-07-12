using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoPermiso : cboBase
    {
        clsCNTipoPermiso objTipoPermiso = new clsCNTipoPermiso();

        public cboTipoPermiso()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoPermiso(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dtTipoPermiso = objTipoPermiso.CNListarTiposPermiso();
            this.DataSource = dtTipoPermiso;
            this.ValueMember = dtTipoPermiso.Columns["idTipoPermiso"].ToString();
            this.DisplayMember = dtTipoPermiso.Columns["cTipoPermiso"].ToString();
        }
    }
}
