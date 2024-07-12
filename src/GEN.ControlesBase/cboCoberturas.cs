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
    public partial class cboCoberturas : cboBase
    {
        public cboCoberturas()
        {
            InitializeComponent();
        }

        public void cargarTodas()
        {
            this.DataSource = new clsCNCobertura().listarTodas();
            this.ValueMember = "idCobertura";
            this.DisplayMember = "cCobertura";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarActivas()
        {
            this.DataSource = new clsCNCobertura().listarActivas();
            this.ValueMember = "idCobertura";
            this.DisplayMember = "cCobertura";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
