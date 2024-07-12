using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboConvenio : cboBase
    {
        clsCNConvenios Convenio = new clsCNConvenios();
        public cboConvenio()
        {
            InitializeComponent();
        }

        public cboConvenio(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            DataTable dtConvenio = Convenio.CNListaConveniosXml();

            this.DataSource = dtConvenio;
            this.ValueMember = dtConvenio.Columns["idConvenio"].ToString();
            this.DisplayMember = dtConvenio.Columns["cConvenio"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
