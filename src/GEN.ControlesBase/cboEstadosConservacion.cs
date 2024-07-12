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

namespace GEN.ControlesBase
{
    public partial class cboEstadosConservacion : cboBase
    {
        public cboEstadosConservacion()
        {
            InitializeComponent();
        }

        
        public void cargarTodas()
        {
            this.DataSource = new clsCNEstadoConservacion().listarTodos();
            this.ValueMember = "idEstadoConservacion";
            this.DisplayMember = "cEstadoConservacion";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarActivas()
        {
            this.DataSource = new clsCNEstadoConservacion().listarActivos();
            this.ValueMember = "idEstadoConservacion";
            this.DisplayMember = "cEstadoConservacion";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
