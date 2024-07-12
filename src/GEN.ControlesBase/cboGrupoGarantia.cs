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
    public partial class cboGrupoGarantia : cboBase
    {
        public cboGrupoGarantia()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboGrupoGarantia(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
             this.DataSource = new clsCNGarantia().listarGrupoGarantiaXML();
             this.ValueMember = "idGrupo";
             this.DisplayMember = "cDesGrupo";
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
