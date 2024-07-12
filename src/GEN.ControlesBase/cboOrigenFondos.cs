using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboOrigenFondos : cboBase
    {
        public cboOrigenFondos()
        {
            InitializeComponent();
        }

        public cboOrigenFondos(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListaOrigenFondos();
        }

        private void ListaOrigenFondos()
        {
            clsCNTipoCuenta objTipoCuenta = new clsCNTipoCuenta();
            DataTable dt = objTipoCuenta.ListaOrigenFondos();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idOrigenFondo"].ToString();
            this.DisplayMember = dt.Columns["cDescripcion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
