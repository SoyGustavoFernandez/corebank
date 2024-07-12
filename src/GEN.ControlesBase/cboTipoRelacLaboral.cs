using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class cboTipoRelacLaboral : cboBase
    {
        public cboTipoRelacLaboral()
        {
            InitializeComponent();
        }

        clsCNRelacLaboral objrelaclab = new clsCNRelacLaboral();

        public void cargarTodos()
        {
            this.DataSource = objrelaclab.listarRelacionLaboralTodos();
            this.ValueMember = "idRelacLaboral";
            this.DisplayMember = "cRelacLaboral";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarActivos()
        {           
            this.DataSource = objrelaclab.listarRelacionLaboralActivos();
            this.ValueMember = "idRelacLaboral";
            this.DisplayMember = "cRelacLaboral";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
