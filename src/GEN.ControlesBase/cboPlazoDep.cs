using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPlazoDep : cboBase
    {
        public cboPlazoDep()
        {
            InitializeComponent();
        }
        public cboPlazoDep(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CargarPlazos(Int32 CodSubPro)
        {
            clsCNDeposito deposito = new clsCNDeposito();
            DataTable dt = deposito.CNListarPlazoDep(CodSubPro);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
