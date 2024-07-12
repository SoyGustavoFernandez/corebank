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
    public partial class cboObjetoAhorro : cboBase
    {
        public cboObjetoAhorro()
        {
            InitializeComponent();
            
        }

        public cboObjetoAhorro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            ListaObjetoAhorro();
        }

        private void ListaObjetoAhorro()
        {
            clsCNTipoCuenta objTipoCuenta = new clsCNTipoCuenta();
            DataTable dt = objTipoCuenta.ListaObjetoAhorro();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idObjetoAho"].ToString();
            this.DisplayMember = dt.Columns["cDescripcion"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
