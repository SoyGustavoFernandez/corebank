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
    public partial class cboTipoTramo : cboBase
    {
        public cboTipoTramo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }


        public cboTipoTramo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dtTipoTramo = new clsCNTramo().ListarTipoTramos();
            this.DataSource = dtTipoTramo;
            this.ValueMember = dtTipoTramo.Columns[0].ToString();
            this.DisplayMember = dtTipoTramo.Columns[1].ToString();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }                
    }
}
