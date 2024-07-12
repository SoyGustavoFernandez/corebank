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
    public partial class cboTipoResultado : cboBase
    {
        public cboTipoResultado()
        {
            InitializeComponent();
        }

        public cboTipoResultado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNTipoResultado obj = new clsCNTipoResultado();
            DataTable dtTipoResultado = obj.Lista();
            this.DataSource = dtTipoResultado;
            this.ValueMember = dtTipoResultado.Columns[0].ToString();
            this.DisplayMember = dtTipoResultado.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
