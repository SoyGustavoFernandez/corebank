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
    public partial class cboUsuarioSupervisorRec : cboBase
    {
        public cboUsuarioSupervisorRec()
        {
            InitializeComponent();         
        }


        public cboUsuarioSupervisorRec(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DataSource = new clsCNUsuario().listarUsuarioSupervisores();
            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
        }
    }
}
