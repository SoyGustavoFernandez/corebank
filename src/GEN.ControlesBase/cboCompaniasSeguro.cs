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
    public partial class cboCompaniasSeguro : cboBase
    {
        public cboCompaniasSeguro()
        {
            InitializeComponent();
        }

        public void cargarTodas()
        {
            this.DataSource = new clsCNCompaniaSeguro().listarTodas();
            this.ValueMember = "idCompania";
            this.DisplayMember = "cCompania";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void cargarActivas()
        {
            this.DataSource = new clsCNCompaniaSeguro().listarActivas();
            this.ValueMember = "idCompania";
            this.DisplayMember = "cCompania";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
