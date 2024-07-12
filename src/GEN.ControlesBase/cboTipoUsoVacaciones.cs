using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoUsoVacaciones : cboBase
    {
        public cboTipoUsoVacaciones()
        {
            InitializeComponent();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoUsoVacaciones(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DataSource = new clsCNVacaciones().CNListarTipoUsoVacaciones();
            this.ValueMember = "idTipoUso";
            this.DisplayMember = "cTipoUso";
        }
    }
}
