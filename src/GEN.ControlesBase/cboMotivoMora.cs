using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboMotivoMora : cboBase
    {
        public cboMotivoMora()
        {
            InitializeComponent();
        }

        public cboMotivoMora(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNMotivoMora cnMotivoMora = new clsCNMotivoMora();
            DataTable dt = cnMotivoMora.Lista();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }    }
}
