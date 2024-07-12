using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboDocumentoDesembolso : cboBase
    {
        clsCNCredito cncredito = new clsCNCredito();
        public cboDocumentoDesembolso()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public cboDocumentoDesembolso(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dt = cncredito.ListarDocumentoDesembolso();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
