using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboPersonalCargo : cboBase
    {
        clsCNPersonal cnpersonal = new clsCNPersonal();
        public cboPersonalCargo()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public cboPersonalCargo(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarPersonal(string cVariable,int idAgencia)
        {
            DataTable dt = cnpersonal.ListaPersonalCargo(cVariable, idAgencia);
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idUsuario"].ToString();
            this.DisplayMember = dt.Columns["cNombre"].ToString();
        }
    }
}
