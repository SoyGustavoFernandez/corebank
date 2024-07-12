using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboModalidadCredito : cboBase
    {
        public cboModalidadCredito()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboModalidadCredito(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            clsCNModalidadCredito objModalidadCredito = new clsCNModalidadCredito();
            DataTable dtModalidadCredito = objModalidadCredito.CNListarModalidadCredito();
            this.DataSource = dtModalidadCredito;
            this.ValueMember = dtModalidadCredito.Columns[0].ToString();
            this.DisplayMember = dtModalidadCredito.Columns[1].ToString();
        }
    }
}