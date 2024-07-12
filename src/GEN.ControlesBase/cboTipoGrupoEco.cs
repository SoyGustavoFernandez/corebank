using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboTipoGrupoEco : cboBase
    {
        public cboTipoGrupoEco()
        {
            InitializeComponent(); 
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboTipoGrupoEco(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DataSource = new clsCNGrupoEconomico().listartipoGrupoEco();
            this.ValueMember = "idTipoGrupoEco";
            this.DisplayMember = "cTipoGrupoEco";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
