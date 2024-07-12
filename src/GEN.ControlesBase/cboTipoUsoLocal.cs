using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoUsoLocal : cboBase
    {
        public cboTipoUsoLocal()
        {
            InitializeComponent();
        }

        public cboTipoUsoLocal(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DataSource = new clsCNTipoUsoLocal().ListarTipoUsoLocal();
            this.ValueMember = "IdTipoUsolocal";
            this.DisplayMember = "cDesTipoUso";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
