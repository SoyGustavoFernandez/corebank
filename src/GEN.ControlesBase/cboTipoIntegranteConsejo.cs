using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRC.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoIntegranteConsejo : cboBase
    {
        public cboTipoIntegranteConsejo()
        {
            InitializeComponent();
        }

        public cboTipoIntegranteConsejo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            DataTable dt = new clsCNTipoIntegranteConsejo().ListarTipoIntegranteConsejo();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
