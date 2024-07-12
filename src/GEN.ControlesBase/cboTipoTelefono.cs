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
    public partial class cboTipoTelefono : cboBase
    {
        clsCNTipoTel cTipoTel = new clsCNTipoTel();
        public cboTipoTelefono()
        {
            InitializeComponent();
            cargarTodos();
        }

        public cboTipoTelefono(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            cargarTodos();
        }

        public void cargarTodos()
        {
            DataTable dt = cTipoTel.ListarTipos();
            ValueMember = "idTipoTelefono";
            DisplayMember = "cTipoTelefono";
            DataSource = dt;
        }




    }
}
