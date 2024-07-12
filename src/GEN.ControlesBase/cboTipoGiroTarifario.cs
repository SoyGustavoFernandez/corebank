using SER.CapaNegocio;
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
    public partial class cboTipoGiroTarifario : cboBase
    {
        public cboTipoGiroTarifario()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboTipoGiroTarifario(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CargaDatos();
        }

        public void CargaDatos()
        {
            clsCNControlServ objCNControlServ = new clsCNControlServ();
            DataTable dt = objCNControlServ.CNListarTipoGiroTarifario();

            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
