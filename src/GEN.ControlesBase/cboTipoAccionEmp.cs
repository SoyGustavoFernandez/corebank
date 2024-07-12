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
    public partial class cboTipoAccionEmp : cboBase
    {
        public cboTipoAccionEmp()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }


        public cboTipoAccionEmp(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtTipoAccioines = new clsCNTipoAccionesEmp().ListarTipoAccionEmp();
            this.DataSource = dtTipoAccioines;
            this.ValueMember = dtTipoAccioines.Columns[0].ToString();
            this.DisplayMember = dtTipoAccioines.Columns[1].ToString();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }                
    }
}
