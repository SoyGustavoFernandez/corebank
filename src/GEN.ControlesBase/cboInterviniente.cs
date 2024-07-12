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
    public partial class cboInterviniente : cboBase
    {
        clsCNInterviniente cnInterviniente = new clsCNInterviniente();

        public cboInterviniente()
        {
            InitializeComponent();
        }

        public cboInterviniente(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void cargarDatos(int idCuenta)
        {
            DataTable dt = cnInterviniente.ListarIntervinientesCredito(idCuenta);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idCli"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
            this.SelectedIndex = -1;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
