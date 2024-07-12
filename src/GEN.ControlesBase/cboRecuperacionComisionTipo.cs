using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RCP.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboRecuperacionComisionTipo : cboBase
    {
        public cboRecuperacionComisionTipo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboRecuperacionComisionTipo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Cargar();
        }

        public void Cargar()
        {
            DataTable dtRecuperacionComisionTipo = new clsCNRecuperacionComision().ListarRecuperacionComisionTipo();
            this.DataSource = dtRecuperacionComisionTipo;
            this.ValueMember = dtRecuperacionComisionTipo.Columns["idRecuperacionComisionTipo"].ToString();
            this.DisplayMember = dtRecuperacionComisionTipo.Columns["cRecuperacionComisionTipo"].ToString();
        }
    }
}
