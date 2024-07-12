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
    public partial class cboTipoComiteCred : cboBase
    {
        private clsCNTipoComiteCred objTipoComiteCred;

        public cboTipoComiteCred()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DropDownWidth = 150;

            this.objTipoComiteCred = new clsCNTipoComiteCred();
        }

        public cboTipoComiteCred(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DropDownWidth = 150;

            this.objTipoComiteCred = new clsCNTipoComiteCred();
        }

        public void CargarDatos()
        {
            DataTable dt = this.objTipoComiteCred.ListarTipoComiteCred();

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoComiteCred"].ToString();
            this.DisplayMember = dt.Columns["cTipoComiteCred"].ToString();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
