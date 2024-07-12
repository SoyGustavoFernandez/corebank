using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoIncentivo : cboBase
    {
        clsCNMeta cnMeta = new clsCNMeta();

        public cboTipoIncentivo()
        {
            InitializeComponent();
        }

        public cboTipoIncentivo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            cargarDatos(Convert.ToBoolean(0));
        }

        public void cargarDatos(Boolean lTodos)
        {
            DataTable dt = cnMeta.CNListaTipoInsentivo(lTodos);
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
            this.DataSource = dt;
        }
    }
}
