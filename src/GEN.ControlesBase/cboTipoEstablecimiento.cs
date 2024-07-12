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
    public partial class cboTipoEstablecimiento : cboBase
    {
        private clsCNTipoEstablecimiento objTipoEstablecimiento;

        public cboTipoEstablecimiento()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DropDownWidth = 150;

            this.objTipoEstablecimiento = new clsCNTipoEstablecimiento();
        }

        public cboTipoEstablecimiento(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DropDownWidth = 150;

            this.objTipoEstablecimiento = new clsCNTipoEstablecimiento();
        }

        public void CargarDatos()
        {
            DataTable dt = this.objTipoEstablecimiento.ListarTipoEstablecimiento();

            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoEstablec"].ToString();
            this.DisplayMember = dt.Columns["cTipoEstablec"].ToString();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
