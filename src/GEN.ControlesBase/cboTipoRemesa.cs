using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoRemesa : cboBase
    {
        public cboTipoRemesa()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoRemesa(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            clsCNRemesa objTipoRemesa = new clsCNRemesa();
            DataTable dtTiposRemesa = objTipoRemesa.CNListarTiposRemesa();
            this.DataSource = dtTiposRemesa;
            this.ValueMember = dtTiposRemesa.Columns[0].ToString();
            this.DisplayMember = dtTiposRemesa.Columns[1].ToString();
            this.SelectedValue = -1;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
