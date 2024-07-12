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
    public partial class cboTipoCuentasCobrar : cboBase
    {
        public cboTipoCuentasCobrar()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }


        public cboTipoCuentasCobrar(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtTipoCxC = new clsCNTipoCuentasCobrar().ListarTipoCuentasCobrar();
            this.DataSource = dtTipoCxC;
            this.ValueMember = dtTipoCxC.Columns[0].ToString();
            this.DisplayMember = dtTipoCxC.Columns[1].ToString();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }                
    }
}
