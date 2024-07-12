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
    public partial class cboFrecTiempo : cboBase
    {
        public cboFrecTiempo()
        {
            InitializeComponent();
        }

        public cboFrecTiempo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DataSource = new clsCNFrecTiempo().ListarFrecTiempo();
            this.ValueMember = "IdTipoPeriodo";
            this.DisplayMember = "cDesTipoPeriodo";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
